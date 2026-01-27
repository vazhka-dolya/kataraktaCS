using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace kataraktaCS.Controls.kataraktaTreeView
{
    public class kataraktaTreeView : TreeView
    {
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowTheme(this.Handle, "explorer", null);
        }

        private bool OptionUseSimplifiedTreeView = true;
        private bool OptionDisplayIcons = true;
        private bool OptionDisplayCache = true;
        private bool OptionDisplayCacheOnRight = true;

        bool IsInDesignMode()
        {
            return (this.Site != null && this.Site.DesignMode) || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        public kataraktaTreeView()
        {
            // If we don't check this then Visual Studio will publicly execute us
            if (!this.IsInDesignMode()) LoadTreeViewSettings();

            SetDrawingSettings();
        }

        public void ReloadSettings()
        {
            LoadTreeViewSettings();
            SetDrawingSettings();
        }

        public void SetDrawingSettings()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, false);
            this.AfterExpand -= (s, e) => Invalidate();
            this.AfterCollapse -= (s, e) => Invalidate();
            this.AfterSelect -= (s, e) => Invalidate();
            this.Resize -= (s, e) => Invalidate();
            if (!OptionUseSimplifiedTreeView)
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
                this.AfterExpand += (s, e) => Invalidate();
                this.AfterCollapse += (s, e) => Invalidate();
                this.AfterSelect += (s, e) => Invalidate();
                this.Resize += (s, e) => Invalidate();
            }
        }

        private void LoadTreeViewSettings()
        {
            JObject JSONSettings = JObject.Parse(File.ReadAllText(MainDefinitions.SettingsPath));

            OptionUseSimplifiedTreeView = JSONSettings.Value<bool?>("TreeView_UseSimplifiedTreeView") ?? false;
            OptionDisplayIcons = JSONSettings.Value<bool?>("TreeView_DisplayIcons") ?? true;
            OptionDisplayCache = JSONSettings.Value<bool?>("TreeView_DisplayCache") ?? false;
            OptionDisplayCacheOnRight = JSONSettings.Value<bool?>("TreeView_DisplayCacheOnRight") ?? false;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Don't do this if either the simplified treeview is enabled
            // or if the icons and cache are both disabled (there would be
            // nothing that we need to render there)
            if (!OptionUseSimplifiedTreeView && (OptionDisplayIcons || OptionDisplayCache))
            {
                if (m.Msg == 0x0F) // WM_PAINT
                {
                    using (Graphics g = this.CreateGraphics())
                    {
                        Image DrawnCacheImage = kTVResizeImage
                            (
                            Properties.Resources.Icon_CacheList,
                            AdjustDPIInt(16),
                            AdjustDPIInt(16)
                            );

                        foreach (TreeNode node in this.Nodes)
                        {
                            if (node.IsVisible || node.IsExpanded) DrawIcons(g, node, DrawnCacheImage);
                        }
                    }
                }
            }
        }

        private void DrawIcons(Graphics g, TreeNode node, Image CacheImage)
        {
            if (!OptionUseSimplifiedTreeView)
            {
                if (node.IsVisible || node.IsExpanded)
                {
                    Rectangle bounds = node.Bounds;
                    int IconDistance = AdjustDPIInt(19);

                    int OffsetX = bounds.Left;
                    int OffsetY = bounds.Top + AdjustDPIInt(2);
                    int OffsetIconTexture;
                    int OffsetIconCache = OffsetX - IconDistance;

                    //if (((NodeData)node.Tag).Cached == true && OptionDisplayCache && !OptionDisplayCacheOnRight)
                    if (OptionDisplayCache && !OptionDisplayCacheOnRight)
                    {
                        OffsetIconTexture = OffsetX;
                    }
                    else
                    {
                        OffsetIconTexture = OffsetX - IconDistance;
                        OffsetIconCache = this.Width - IconDistance;
                        if (IsVerticalScrollBarVisible(this))
                            OffsetIconCache -= SystemInformation.VerticalScrollBarWidth + AdjustDPIInt(1);
                    }

                    if (OptionDisplayCache && ((NodeData)node.Tag).Cached)
                    {
                        g.DrawImage(CacheImage, OffsetIconCache, OffsetY);
                    }

                    if (OptionDisplayIcons && ((NodeData)node.Tag).Icon != null)
                    {
                        g.DrawImage(((NodeData)node.Tag).Icon, OffsetIconTexture, OffsetY);
                    }

                    if (node.Nodes != null && node.Nodes.Count > 0)
                    {
                        foreach (TreeNode child in node.Nodes)
                        {
                            if (child.IsVisible || (node.IsExpanded && child.IsExpanded)) DrawIcons(g, child, CacheImage);
                        }
                    }
                }
            }
        }

        private const int SB_VERT = 1;
        private const int GWL_STYLE = -16;
        private const int WS_VSCROLL = 0x00200000;

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public static bool IsVerticalScrollBarVisible(TreeView tree)
        {
            int style = GetWindowLong(tree.Handle, GWL_STYLE);
            return (style & WS_VSCROLL) != 0;
        }

        private double CalculateDPIDifference()
        {
            // 96 is 1080p DPI
            return (double)(this.DeviceDpi - 96) / Math.Abs(96) + 1;
        }

        private int AdjustDPIInt(int ValueToAdjust)
        {
            return (int)(ValueToAdjust * CalculateDPIDifference());
        }

        private Image kTVResizeImage(Image original, int width, int height, bool Bicubic = true)
        {
            var destImage = new Bitmap(width, height);
            using (var g = Graphics.FromImage(destImage))
            {
                //g.Clear(Color.FromArgb(0xAA, 0xAA, 0xAA));

                // Calculate aspect-preserving dimensions
                float ratio = Math.Min(
                    (float)width / original.Width,
                    (float)height / original.Height
                );
                int newWidth = (int)(original.Width * ratio);
                int newHeight = (int)(original.Height * ratio);

                // Center the image
                int x = (width - newWidth) / 2;
                int y = (height - newHeight) / 2;

                // Configure rendering
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // Draw the thing
                g.DrawImage(original, x, y, newWidth, newHeight);
            }

            return destImage;
        }
    }
}
