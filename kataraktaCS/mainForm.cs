using kataraktaCS.Controls.kataraktaTreeView;
using kataraktaCS.Properties;
using M64MM.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kataraktaCS
{
    public partial class mainForm : Form
    {
        string IsLatestVersion = "Unknown";
        string LatestVersion = "Unknown";
        static string CreatorName = "vazhka-dolya";
        static string AddonLinkName = "kataraktaCS";
        static string AddonReleaseName = "kataraktaCS";

        static frmAbout About;
        static frmSettings Settings;
        //static frmHotkeySettings HotkeySettings = new frmHotkeySettings();

        public bool isSelecting = false;
        public string SelectedMainFolder;
        public string RightClickType;
        public string RightClickPath;

        private MainDefinitions MainDefinitions;
        private ColorFunctions ColorFunctions;
        private VariousFunctions VariousFunctions;
        private TemplateFunctions TemplateFunctions;

        private frmQuickHotkey CurrentQuickHotkey;
        private HotkeyManager HotkeyManager;
        private HotkeyConverter HotkeyConverter;
        private HotkeyEdit HotkeyEdit;
        private frmQuad64 Quad64;
        private frmTemplateManager TemplateManager;

        public Bitmap FixBordersIcon;
        public bool OptionUseSimplifiedTreeView = false;
        public bool OptionDisplayIcons = true;
        public bool OptionDisplayCache = false;
        public bool OptionDisplayCacheOnRight = false;
        public Color TextureBG = Color.FromArgb(255, 170, 170, 170);
        public string HiResTexturePath = "";
        public string MainGameName = "";
        public List<string> OtherGamesNames = new List<string>();

        public mainForm()
        {
            if (!File.Exists(MainDefinitions.SettingsPath))
                CreateSettings();

            MainDefinitions = new MainDefinitions();
            ColorFunctions = new ColorFunctions();
            VariousFunctions = new VariousFunctions();
            TemplateFunctions = new TemplateFunctions();

            HotkeyEdit = new HotkeyEdit();
            Application.EnableVisualStyles();
            InitializeComponent();
            this.Load += mainForm_Load;
            RefreshMainFolderList();
            CheckIfANodeIsSelected();
            flowLayoutPanel1.SizeChanged += flowLayoutPanel1_SizeChanged;

            this.KeyPreview = true;
            this.KeyDown += mainForm_KeyDown;

            this.Text = $"kataraktaCS ({kataraktaVersion.VersionName})";

            SettingsToLoadOnce();

            treeView1.NodeMouseClick += treeView1_NodeMouseClick;

            // Rounded corners for Windows 11
            var attribute = RoundedCorners.DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = RoundedCorners.DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;

            RoundedCorners.DwmSetWindowAttribute(menuStrip1.Handle, attribute, ref preference, sizeof(uint));
            RoundedCorners.DwmSetWindowAttribute(menuOptions.DropDown.Handle, attribute, ref preference, sizeof(uint));
            RoundedCorners.DwmSetWindowAttribute(menuUtilities.DropDown.Handle, attribute, ref preference, sizeof(uint));

            RoundedCorners.DwmSetWindowAttribute(contextMenu.Handle, attribute, ref preference, sizeof(uint));
            RoundedCorners.DwmSetWindowAttribute(contextCache.DropDown.Handle, attribute, ref preference, sizeof(uint));
            RoundedCorners.DwmSetWindowAttribute(contextRemoveBorders.DropDown.Handle, attribute, ref preference, sizeof(uint));
            RoundedCorners.DwmSetWindowAttribute(contextSwapTemplates.DropDown.Handle, attribute, ref preference, sizeof(uint));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            HotkeyManager = new HotkeyManager(this);
            HotkeyConverter = new HotkeyConverter();

            InitializeHotkeys();

            // Designer removes mainMenu from mainForm each time I
            // edit something like contextMenu, so I'll instead
            // just add it in here

            SetUpTreeViewAndDPI(Startup: true);
        }

        protected override void WndProc(ref Message m)
        {
            if (HotkeyManager != null)
                HotkeyManager.HandleMessage(ref m);

            base.WndProc(ref m);
        }

        // Settings that only need to be loaded once upon kCS opening
        private void SettingsToLoadOnce()
        {
            JObject JSONSettings = JObject.Parse(File.ReadAllText(MainDefinitions.SettingsPath));

            switch (JSONSettings.Value<bool?>("EnableStayOnTop") ?? false)
            {
                case true:
                    CheckStayOnTop();
                    break;
                default:
                    break;
            }
        }
        private void CreateSettings()
        {
            var NewSettings = new
            {
                TexturePack_HiResPath = "",
                TexturePack_MainGameName = "SUPER MARIO 64",
                TexturePack_OtherGamesNames = Array.Empty<string>(),
                EnableStayOnTop = false,
                TreeView_UseSimplifiedTreeView = false,
                TreeView_DisplayIcons = true,
                TreeView_DisplayCache = false,
                TreeView_DisplayCacheOnRight = false,
                Appearance_TextureBG = $"AAAAAA"
            };

            using (var SW = new StreamWriter(MainDefinitions.SettingsPath))
            using (var Writer = new JsonTextWriter(SW))
            {
                Writer.Formatting = Formatting.Indented;
                Writer.IndentChar = '\t';
                Writer.Indentation = 1;

                var Serializer = new JsonSerializer();
                Serializer.Serialize(Writer, NewSettings);
            }
        }

        // Settings whose changes can come into effect right after applying
        private void ReloadableSettings()
        {
            JObject JSONSettings = JObject.Parse(File.ReadAllText(MainDefinitions.SettingsPath));

            OptionUseSimplifiedTreeView = JSONSettings.Value<bool?>("TreeView_UseSimplifiedTreeView") ?? false;
            OptionDisplayIcons = JSONSettings.Value<bool?>("TreeView_DisplayIcons") ?? true;
            OptionDisplayCache = JSONSettings.Value<bool?>("TreeView_DisplayCache") ?? false;
            OptionDisplayCacheOnRight = JSONSettings.Value<bool?>("TreeView_DisplayCacheOnRight") ?? false;

            string BackColor = JSONSettings.Value<string>("Appearance_TextureBG") ?? "AAAAAA";
            TextureBG = ColorTranslator.FromHtml("#" + BackColor);

            HiResTexturePath = JSONSettings.Value<string>("TexturePack_HiResPath") ?? "";
            MainGameName = JSONSettings.Value<string>("TexturePack_MainGameName") ?? "";
            OtherGamesNames = JSONSettings["TexturePack_OtherGamesNames"]?
                .ToObject<List<string>>()
                ?? new List<string>();

            if (HiResTexturePath == "")
            {
                SeparatorTP.Visible = false;
                ToolApplyTP.Visible = false;
                DropDownApplyTPOther.Visible = false;
            }
            else
            {
                SeparatorTP.Visible = true;
                ToolApplyTP.Visible = true;
                DropDownApplyTPOther.Visible = true;
            }

            if (OtherGamesNames.Count == 0)
            {
                DropDownApplyTPOther.Visible = false;
                if (MainGameName == "")
                {
                    SeparatorTP.Visible = false;
                    ToolApplyTP.Visible = false;
                    DropDownApplyTPOther.Visible = false;
                }
            }

            Image FixBordersIcon = AddBGColor(Resources.Icon_FixBorders, TextureBG);
            contextRemoveBorders.Image = FixBordersIcon;
        }

        private void RefreshMainFolderList()
        {
            ReloadableSettings();
            ToolApplyRAM.Enabled = false;
            SelectedMainFolder = GetCurrentMainFolder();
            RadioButton FoundSelectedFolder = null;
            MenuFLP.Controls.Clear();
            SetUpTreeViewAndDPI();
            treeView1.ReloadSettings();
            flowLayoutPanel1.BackColor = TextureBG;
            foreach (var dir in Directory.GetDirectories(MainDefinitions.MainFolderPath))
            {
                string dirName = new DirectoryInfo(dir).Name;
                RadioButton newMainFolder = new RadioButton();
                newMainFolder.Text = dirName;
                newMainFolder.Appearance = Appearance.Button;
                newMainFolder.Margin = new Padding(0, 0, 0, 0);
                AdjustMainFolderSize(newMainFolder);
                newMainFolder.Click += MainFolderClick;
                newMainFolder.MouseDown += MainFolderRightClick;
                newMainFolder.TextAlign = ContentAlignment.MiddleCenter;
                MenuFLP.Controls.Add(newMainFolder);

                if (dirName == SelectedMainFolder)
                {
                    FoundSelectedFolder = newMainFolder;
                }
            }
            if (FoundSelectedFolder != null)
            {
                OpenMainFolder(FoundSelectedFolder);
            }

            if (!OptionUseSimplifiedTreeView)
            {
                // Without these there's a weird bug where a subnode's text
                // can sometimes get rendered on the top left for some reason.
                treeView1.BeforeExpand -= (s, e) => treeView1.Invalidate();
                treeView1.BeforeCollapse -= (s, e) => treeView1.Invalidate();
                treeView1.BeforeExpand += (s, e) => treeView1.Invalidate();
                treeView1.BeforeCollapse += (s, e) => treeView1.Invalidate();

                // If the cache icon is on the right, then we'll have to redraw
                // the whole thing each time it's resized, because otherwise it
                // leaves a trail of garbage behind when it moves horizontally.
                // This redraw causes some lag, but I don't know any other fix.
                if (!OptionUseSimplifiedTreeView && OptionDisplayCache && OptionDisplayCacheOnRight)
                {
                    treeView1.Resize += (s, e) => treeView1.Invalidate();
                }
                else
                {
                    treeView1.Resize -= (s, e) => treeView1.Invalidate();
                }
            }
            else
            {
                treeView1.BeforeExpand -= (s, e) => treeView1.Invalidate();
                treeView1.BeforeCollapse -= (s, e) => treeView1.Invalidate();
            }
        }

        #region DPI

        private double CalculateDPIDifference()
        {
            // 96 is 1080p DPI
            return (double)(this.DeviceDpi - 96) / Math.Abs(96) + 1;
        }

        private int AdjustDPIInt(int ValueToAdjust)
        {
            return (int)(ValueToAdjust * CalculateDPIDifference());
        }

        private void SetUpTreeViewAndDPI(bool Startup = false)
        {
            // Only do this at startup. No reason to adjust those after
            // initialization and it will cause problems if we do so.
            if (Startup)
            {
                // If I understand correctly, if the splitter is on the earlier half, then we can just use
                // AdjustDPIInt on it, but if it's on the later half, then we have to do SplitContainer's
                // width minus AdjustDPIInt(SplitContainer's width minus splitter distance) for some reason?
                splitMenuAndRest.SplitterDistance = AdjustDPIInt
                    (splitMenuAndRest.SplitterDistance);
                splitMainAndTexture.SplitterDistance = AdjustDPIInt
                    (splitMainAndTexture.SplitterDistance);
                splitTextureListAndView.SplitterDistance =
                    splitTextureListAndView.Width - AdjustDPIInt
                    (splitTextureListAndView.Width - splitTextureListAndView.SplitterDistance);
                splitRestAndTools.SplitterDistance =
                    splitRestAndTools.Height - AdjustDPIInt
                    (splitRestAndTools.Height - splitRestAndTools.SplitterDistance);
            }

            treeView1.ImageList.ImageSize = new Size(AdjustDPIInt(16), AdjustDPIInt(16));
            treeView1.Font = new Font("Microsoft Sans Serif",
                // A bit complex but ensures that the size is good on all DPIs
                AdjustDPIInt(9) + (float)0.6 - (float)((CalculateDPIDifference() - 1) * 5),
                GraphicsUnit.Point);
            treeView1.ItemHeight = AdjustDPIInt(20);

            // We apply this thing only once at launch, because if we reapply it each refresh,
            // then it will start drawing the text more than one time for some reason.
            if (Startup)
            {
                // Since WinForms's TreeView doesn't have columns and moving to an external
                // tree control would be a pain in all the right places, we will instead draw
                // the right text ourselves, including a second string that will be used for
                // showing keyboard shortcuts that the user will be able to set for a texture.

                // The text is a bit higher than it should be so we use this to move it a bit lower
                int VerticalAdjust = AdjustDPIInt(2);

                treeView1.DrawNode += (s, e) =>
                {
                    int IconDistance = AdjustDPIInt(19);

                    int XOffset = e.Bounds.Left;
                    if (((NodeData)e.Node.Tag).Icon == null || !OptionDisplayIcons)
                        XOffset -= IconDistance;
                    //if (((NodeData)e.Node.Tag).Cached == true && OptionDisplayCache && !OptionDisplayCacheOnRight)
                    if (OptionDisplayCache && !OptionDisplayCacheOnRight)
                        XOffset += IconDistance;

                    string FirstColText = ((NodeData)e.Node.Tag).Name;
                    e.Graphics.DrawString(FirstColText, treeView1.Font, Brushes.Black, XOffset, e.Bounds.Top + VerticalAdjust);

                    // Finding the place for where the second text will begin
                    int width;
                    using (Graphics g = treeView1.CreateGraphics())
                    {
                        width = TextRenderer.MeasureText(g, FirstColText, treeView1.Font).Width;
                    }
                    int SecondColX = XOffset + width;

                    string SecondColText = ((NodeData)e.Node.Tag).HotkeyDisplay;
                    e.Graphics.DrawString(SecondColText, treeView1.Font, Brushes.Gray, SecondColX, e.Bounds.Top + VerticalAdjust);
                };
            }

            if (!OptionUseSimplifiedTreeView)
            {
                treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            }
            else treeView1.DrawMode = TreeViewDrawMode.Normal;
        }

        #endregion

        #region Hotkeys

        private void InitializeHotkeys()
        {
            if (!File.Exists(MainDefinitions.HotkeysPath))
            {
                var NewHotkeys = new
                {
                    kCSHotkeysRevision = "2",
                    Hotkeys = Array.Empty<string>()
                };

                using (var SW = new StreamWriter(MainDefinitions.HotkeysPath))
                using (var Writer = new JsonTextWriter(SW))
                {
                    Writer.Formatting = Formatting.Indented;
                    Writer.IndentChar = '\t';
                    Writer.Indentation = 1;

                    var Serializer = new JsonSerializer();
                    Serializer.Serialize(Writer, NewHotkeys);
                }
            }

            HotkeyManager.UnregisterAll();

            kCSHotkeysClass JSONHotkeys =
                JsonConvert.DeserializeObject<kCSHotkeysClass>
                (File.ReadAllText(MainDefinitions.HotkeysPath));

            foreach (var hotkey in JSONHotkeys.Hotkeys)
            {
                try
                {
                    string StringPath = hotkey.Path;
                    string StringKeys = hotkey.Keys;
                    HotkeyManager.RegisterHotkey
                        (HotkeyConverter.StringToHotkey(StringKeys), () => UseHotkeyByPath(StringPath));
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void NodeHotkeyDisplay(TreeNode node, string StringKeys)
        {
            ((NodeData)node.Tag).HotkeyDisplay = StringKeys;
        }

        private void UseHotkeyByPath(string SpecifiedPath)
        {
            TreeNode FoundNode = FindNodeByPath(SpecifiedPath);
            if (FoundNode != null)
            {
                treeView1.SelectedNode = FoundNode;
                ApplyRAMButton();
            }
            else
            {
                string AbsoluteSpecifiedPath = Path.Combine(MainDefinitions.MainFolderPath, SpecifiedPath);
                if (Directory.Exists(AbsoluteSpecifiedPath))
                {
                    ApplyRAMButton(AbsoluteSpecifiedPath);
                }
                else
                {
                    MessageBox.Show(String.Format(Resources.Error_PathDoesNotExist, AbsoluteSpecifiedPath));
                }
            }
        }

#endregion

        #region Texture preview

        private int flowLayoutPanel1CalculateFreeWidth()
        {
            double MultiplyBy;
            MultiplyBy = 1.5;
            /* // the following is very buggy so it will be commented out for now
			switch (flowLayoutPanel1.VerticalScroll.Visible)
			{
				case true:
					MultiplyBy = 2;
					break;
				default:
					MultiplyBy = 0.5;
					break;
			}
			*/
            return (int)Math.Round(System.Windows.Forms.SystemInformation.VerticalScrollBarWidth * MultiplyBy);
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            // Makes the following run AFTER the resizing has been done.
            // Without this, it uses the width that was before the resizing.
            this.BeginInvoke((MethodInvoker)delegate
            {
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is PictureBox pictureBox)
                    {
                        int EndWidth = flowLayoutPanel1CalculateFreeWidth();
                        Image UsedImage = pictureBox.Image;
                        int NeededWidth = flowLayoutPanel1.Width - EndWidth;
                        pictureBox.Width = NeededWidth;
                        pictureBox.Height = (int)(UsedImage.Height * (NeededWidth / (float)UsedImage.Width));
                    }
                }
            });
        }

        private void AddTextureToPanel(kCSTemplateTextureAbsolutePath TextureInfo)
        {
            int EndWidth = flowLayoutPanel1CalculateFreeWidth();
            Image UsedImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(TextureInfo.AbsolutePath)));
            int NeededWidth = flowLayoutPanel1.Width - EndWidth;
            var pictureBox = new PictureBox
            {
                Image = UsedImage,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = NeededWidth,
                Height = (int)(UsedImage.Height * (NeededWidth / (float)UsedImage.Width)),
                BorderStyle = BorderStyle.FixedSingle,
            };

            pictureBox.MouseHover += new EventHandler((s, e) => TexturePanelHover(s, e, pictureBox));

            string TexturePackFilenameString = String.Format(Resources.TextureToolTip_TexturePackFilename, TextureInfo.TexturePackFilename);
            string AlternativeFilenameString = String.Format(Resources.TextureToolTip_AlternativeFilename, TextureInfo.AlternativeFilename);

            if (TextureInfo.TexturePackFilename == "")
            {
                TexturePackFilenameString = Resources.TextureToolTip_NoTexturePackFilename + "\n";
                AlternativeFilenameString += $" {Resources.TextureToolTip_PathIsUsed}";
            }
            if (TextureInfo.AlternativeFilename == "")
            {
                TexturePackFilenameString += $" {Resources.TextureToolTip_PathIsUsed}\n";
                AlternativeFilenameString = Resources.TextureToolTip_NoAlternativeFilename;
            }
            if (TextureInfo.TexturePackFilename != "" && TextureInfo.AlternativeFilename != "")
            {
                switch (TextureInfo.AbsolutePath.EndsWith(TextureInfo.AlternativeFilename + ".png"))
                {
                    case true:
                        TexturePackFilenameString += "\n";
                        AlternativeFilenameString += $" {Resources.TextureToolTip_PathIsUsed}";
                        break;
                    case false:
                        TexturePackFilenameString += $" {Resources.TextureToolTip_PathIsUsed}\n";
                        break;
                }
            }
            
            toolTip1.SetToolTip(pictureBox, String.Format(Resources.TextureToolTip_Title, TextureInfo.Title) + "\n" +

                String.Format(Resources.TextureToolTip_Display,
                TextureInfo.Display ? Resources.TextureToolTip_Yes : Resources.TextureToolTip_No) + "\n" +

                String.Format(Resources.TextureToolTip_RAMAddress, TextureInfo.RAM) + "\n" +

                String.Format(Resources.TextureToolTip_RAMFormat, TextureInfo.RAMFormat) + "\n\n" +

                TexturePackFilenameString +

                AlternativeFilenameString);

            flowLayoutPanel1.Controls.Add(pictureBox);
        }

        private void TexturePanelHover(object sender, EventArgs e, PictureBox pictureBox)
        {
            Task.Delay(500).Wait();
            if (pictureBox.ClientRectangle.Contains(pictureBox.PointToClient(Cursor.Position)))
            {
                toolTip1.Show(toolTip1.GetToolTip(pictureBox), pictureBox);
            }
        }

        private void ShowTexturesFromFolder(string mainFolder, string textureFolder)
        {
            flowLayoutPanel1.Controls.Clear();

            List<kCSTemplateTextureAbsolutePath> FoundTextures = TemplateFunctions.GetTexturesInFolder(textureFolder);

            foreach (kCSTemplateTextureAbsolutePath Texture in FoundTextures)
            {
                if (Texture.Display)
                {
                    string TextureString = Texture.AbsolutePath;
                    if (TextureString.Length > 0)
                    {
                        AddTextureToPanel(Texture);
                    }
                }
            }
        }

        #endregion

        #region Main folders

        private void AdjustMainFolderSize(Control control)
        {
            using (Graphics g = control.CreateGraphics())
            {
                SizeF stringSize = g.MeasureString(control.Text, control.Font);
                int width = (int)Math.Ceiling(stringSize.Width) + control.Padding.Horizontal + AdjustDPIInt(10);
                int height = (int)Math.Ceiling(stringSize.Height) + control.Padding.Horizontal + AdjustDPIInt(9);
                control.Size = new Size(width, height);
            }
        }

        private void OpenMainFolder(RadioButton OpenedMainFolder, bool Search = false)
        {
            flowLayoutPanel1.Controls.Clear();
            treeView1.Nodes.Clear();
            CheckIfANodeIsSelected();
            AddBlankIcon();

            foreach (RadioButton MainFolder in MenuFLP.Controls)
            {
                MainFolder.Checked = false;
            }
            OpenedMainFolder.Checked = true;
            string MainFolderRoot = MainDefinitions.MainFolderPath + OpenedMainFolder.Text + "\\";

            switch (Search)
            {
                default:
                    LoadDirectory(MainFolderRoot, treeView1.Nodes);
                    break;
                case true:
                    LoadDirectory(MainFolderRoot, treeView1.Nodes, ToolSearch.Text);
                    break;
            }
        }

        private void MainFolderClick(object sender, EventArgs e)
        {
            RadioButton clickedButton = sender as RadioButton;
            OpenMainFolder(clickedButton);
        }

        private void MainFolderRightClick(object sender, MouseEventArgs e)
        {
            RadioButton clickedButton = sender as RadioButton;

            if (e.Button == MouseButtons.Right)
            {
                contextSwapTemplates.DropDownItems.Clear();
                RightClickType = "MainFolder";
                RightClickPath = Path.Combine(MainDefinitions.MainFolderPath, clickedButton.Text);

                TemplateManager = new frmTemplateManager(clickedButton.Text);

                contextApplyTexture.Visible = false;
                contextShowInExplorer.Visible = true;

                SeparatorApply.Visible = false;

                contextHotkeyAdd.Visible = false;
                contextHotkeyEdit.Visible = false;
                contextHotkeyRemove.Visible = false;

                SeparatorHotkeys.Visible = false;

                contextCache.Visible = false;
                contextCacheGenSelected.Visible = false;
                contextCacheGenSelectedAndSub.Visible = false;
                SeparatorGenerateCache.Visible = false;
                contextCacheClearSelected.Visible = false;
                contextCacheClearSelectedAndSub.Visible = false;
                contextRemoveBorders.Visible = false;
                contextRemoveBordersSelected.Visible = false;
                contextRemoveBordersSelectedAndSub.Visible = false;
                contextSwapTemplates.Visible = false;
                SeparatorUtilities.Visible = false;

                List<string> UsedTemplates =
                    TemplateFunctions.GetAllTemplateFiles(RightClickPath, Subfolders: false);
                if (UsedTemplates.Count > 0 && TemplateFunctions.HasFolderSettings(RightClickPath))
                {
                    contextSwapTemplates.Visible = true;
                    SeparatorUtilities.Visible = true;

                    string FolderSettingsPath = Path.Combine(RightClickPath, "FolderSettings.json");
                    JObject JSONFolderSettings = JObject.Parse(File.ReadAllText(FolderSettingsPath));
                    foreach (string Template in UsedTemplates)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        string Filename = Path.GetFileNameWithoutExtension(Template);
                        item.Text = Filename;
                        item.Click += (sender_, e_) =>
                        {
                            TemplateFunctions.SwapFolderSettingsTemplate
                            (FolderSettingsPath, Filename);

                            // Clear cache because using the wrong
                            // cache in a wrong place can end badly
                            CacheButtonClearBatch(RightClickPath, UpdateTreeNode: false);
                            RefreshButton();
                        };

                        // If the current template of the folder settings matches
                        // the filename of this item, then make it checked
                        if (JSONFolderSettings["Template"]?["Filename"]?.ToString() == Filename)
                            item.Checked = true;
                        contextSwapTemplates.DropDownItems.Add(item);
                    }
                }

                contextEditTemplates.Visible = true;

                contextMenu.Show(clickedButton, e.Location);
            }
        }

        private string GetCurrentMainFolder()
        {
            string CurrentMainFolder = "";
            foreach (RadioButton MenuFolder in MenuFLP.Controls)
            {
                if (MenuFolder.Checked == true)
                {
                    CurrentMainFolder = MenuFolder.Text;
                    break;
                }
            }

            return CurrentMainFolder;
        }

        private RadioButton GetCurrentMainFolderRadio()
        {
            RadioButton CurrentMainFolderRadio = null;
            foreach (RadioButton MenuFolder in MenuFLP.Controls)
            {
                if (MenuFolder.Checked == true)
                {
                    CurrentMainFolderRadio = MenuFolder;
                    break;
                }
            }

            return CurrentMainFolderRadio;
        }

#endregion

        #region Finding textures

        public List<kCSTemplateTextureAbsolutePath> FindTextures(string SpecificPathToUse = "")
        {
            if (SpecificPathToUse == "") SpecificPathToUse = GetSelectedTexturePath();

            SpecificPathToUse = VariousFunctions.EnsureTrailingSlash(SpecificPathToUse);
            string CurrentMainFolder = GetCurrentMainFolder();

            string TemplatePath = TemplateFunctions.GetLowestTemplatePath(SpecificPathToUse);

            List<kCSTemplateTextureAbsolutePath> FoundTextures = new List<kCSTemplateTextureAbsolutePath>();
            if (TemplatePath != "")
            {
                if (File.Exists(TemplatePath))
                {
                    kCSTemplateClass JSONTemplateFolder =
                        JsonConvert.DeserializeObject<kCSTemplateClass>(File.ReadAllText(TemplatePath));
                    FoundTextures = TemplateFunctions.GetTexturesInFolder(SpecificPathToUse);
                }
                else
                    MessageBox.Show(String.Format(Resources.TemplatePathDoesNotExist, Path.GetFileName(TemplatePath)));
            }

            return FoundTextures;
        }

        public List<TPApplyItem> DetermineTexturesTP(List<kCSTemplateTextureAbsolutePath> TextureList)
        {
            List<TPApplyItem> ToUse = new List<TPApplyItem>();
            foreach (kCSTemplateTextureAbsolutePath Texture in TextureList)
            {
                if (Texture.TexturePackFilename != "")
                {
                    TPApplyItem FoundTexture = new TPApplyItem();
                    FoundTexture.AbsolutePath = Texture.AbsolutePath;
                    FoundTexture.Filename = Texture.TexturePackFilename;
                    ToUse.Add(FoundTexture);
                }
            }

            return ToUse;
        }

        public bool SeeIfHasTP(List<kCSTemplateTextureAbsolutePath> TextureList)
        {
            foreach (kCSTemplateTextureAbsolutePath Texture in TextureList)
                if (Texture.TexturePackFilename != "")
                    return true;

            return false;
        }

        public bool SeeIfHasRAM(List<kCSTemplateTextureAbsolutePath> TextureList)
        {
            foreach (kCSTemplateTextureAbsolutePath FoundTexture in TextureList)
                if (FoundTexture.RAM != "")
                    return true;

            return false;
        }

        public List<RAMApplyItem> FindAndConvertTexturesRAM(string SpecificPathToUse = "")
        {
            if (SpecificPathToUse == "") SpecificPathToUse = GetSelectedTexturePath();

            SpecificPathToUse = VariousFunctions.EnsureTrailingSlash(SpecificPathToUse);
            string CurrentMainFolder = GetCurrentMainFolder();

            string TemplatePath = TemplateFunctions.GetLowestTemplatePath(SpecificPathToUse);
            List<RAMApplyItem> ToUse = new List<RAMApplyItem>();

            if (TemplatePath != "")
            {
                kCSTemplateClass JSONTemplateFolder =
                    JsonConvert.DeserializeObject<kCSTemplateClass>(File.ReadAllText(TemplatePath));
                List<kCSTemplateTextureAbsolutePath> FoundTextures = TemplateFunctions.GetTexturesInFolder(SpecificPathToUse);

                List<string> FoundTexturesPaths = new List<string>();
                foreach (kCSTemplateTextureAbsolutePath FoundTexture in FoundTextures)
                    FoundTexturesPaths.Add(FoundTexture.AbsolutePath);

                var UsedTextures = JSONTemplateFolder.UsedTextures;
                List<RAMConvertItem> ToConvert = new List<RAMConvertItem>();
                foreach (var texture in UsedTextures)
                {
                    string TextureName = "";
                    if (FoundTexturesPaths.Contains
                        ($"{SpecificPathToUse}{texture.AlternativeFilename}.png"))
                    {
                        TextureName = texture.AlternativeFilename;
                    }
                    else if (FoundTexturesPaths.Contains
                        ($"{SpecificPathToUse}{MainDefinitions.GameName}{texture.TexturePackFilename}.png"))
                    {
                        TextureName = $"{MainDefinitions.GameName}{texture.TexturePackFilename}";
                    }
                    if (TextureName != "")
                    {
                        Bitmap SourceTexture = new Bitmap($"{SpecificPathToUse}{TextureName}.png");
                        uint SegAddress = Convert.ToUInt32(string.Join("", texture.RAM), 16);

                        int width = SourceTexture.Width;
                        int height = SourceTexture.Height;
                        Color[] SourceTexturePixels = new Color[width * height];

                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                SourceTexturePixels[y * width + x] = SourceTexture.GetPixel(x, y);
                            }
                        }

                        ToConvert.Add(new RAMConvertItem
                        {
                            RAMFormat = texture.RAMFormat,
                            Pixels = SourceTexturePixels,
                            SegAddress = SegAddress
                        });
                    }
                }
                foreach (var item in ToConvert)
                {
                    ToUse.Add(new RAMApplyItem
                    {
                        Pixels = ColorFunctions.EncodeTexture(item.RAMFormat, item.Pixels),
                        SegAddress = item.SegAddress
                    });
                }
            }

            return ToUse;
        }

        #endregion

        #region TreeView

        private string GetSelectedTexturePath()
        {
            return MainDefinitions.MainFolderPath + ((NodeData)treeView1.SelectedNode.Tag).Path;
        }

        protected void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (isSelecting) // Should prevent the method from repeating when it's not needed
            {
                return;
            }

            isSelecting = true;

            e.Cancel = true;

            kataraktaTreeView treeView = sender as kataraktaTreeView;

            // The canceling and programmatic selecting are done because otherwise
            // it would scroll to the selected node even when it's not needed
            treeView.SelectedNode = e.Node;

            isSelecting = false;
        }

        protected void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            kataraktaTreeView treeView = sender as kataraktaTreeView;

            if (treeView != null)
            {
                string CurrentMainFolder = GetCurrentMainFolder();

                string SelectedTexturePath = GetSelectedTexturePath();

                ShowTexturesFromFolder($"{MainDefinitions.MainFolderPath + CurrentMainFolder}", SelectedTexturePath);
            }

            CheckIfANodeIsSelected();
        }

        private void AddBlankIcon()
        {
            // For some reason, if there's no icon for a texture found,
            // then it resorts to using the first icon that was loaded.
            // I couldn't get it to work with any other way so I just made
            // it create a blank icon that gets loaded first.
            Bitmap blankIcon = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(blankIcon))
            {
            }
            treeView1.ImageList.Images.Add(blankIcon);
        }

        private bool LoadDirectory(string path, TreeNodeCollection nodes, string filter = "", bool TreeViewShowLoadingScreen = true)
        {
            try
            {
                if (TreeViewShowLoadingScreen)
                {
                    // BeginUpdate and SuspendLayout make it load way faster
                    treeView1.BeginUpdate();
                    treeView1.SuspendLayout();
                    treeView1.Visible = false;
                    treeView1.Nodes.Clear();
                }

                filter = filter.ToLowerInvariant();
                bool anyMatchInThisLevel = false;

                string[] directories = Directory.GetDirectories(path);

                kCSHotkeysClass JSONHotkeys =
                    JsonConvert.DeserializeObject<kCSHotkeysClass>
                    (File.ReadAllText(MainDefinitions.HotkeysPath));

                List<List<string>> HotkeyList = new List<List<string>>();
                foreach (var Hotkey in JSONHotkeys.Hotkeys)
                {
                    HotkeyList.Add(new List<string> { Hotkey.Path, Hotkey.Keys });
                }

                foreach (string directory in directories)
                {
                    string dirName = Path.GetFileName(directory);
                    bool nodeMatches = dirName.ToLowerInvariant().Contains(filter);

                    TreeNode node;
                    Image folderIcon = GetFolderIcon(directory);
                    Image ImageIndex = null;

                    bool Cached = false;
                    if (File.Exists(Path.Combine(directory, MainDefinitions.CacheFilename)))
                        Cached = true;

                    if (!OptionUseSimplifiedTreeView)
                    {
                        // Without a name since we'll have the name in the NodeData class
                        // (that'll work better with OwnerDrawText that we have with treeView1)
                        node = new TreeNode("");

                        if (folderIcon != null)
                        {
                            int iconSize = (int)(16 * (this.DeviceDpi / 96f));

                            ImageIndex = ResizeImage(folderIcon, iconSize, iconSize);
                            folderIcon.Dispose();
                        }
                    }
                    else
                    {
                        // If the fancy treeview is disabled then do it like a normal person
                        node = new TreeNode(dirName);

                        if (folderIcon != null)
                        {
                            int iconSize = (int)(16 * (this.DeviceDpi / 96f));

                            Image Icon = ResizeImage(folderIcon, iconSize, iconSize);
                            if (Cached && OptionDisplayCache) Icon = AddSimplifiedCacheIcon(Icon);

                            treeView1.ImageList.Images.Add(Icon);

                            node.ImageIndex = treeView1.ImageList.Images.Count - 1;
                            node.SelectedImageIndex = node.ImageIndex;
                            folderIcon.Dispose();
                        }
                        else
                        {
                            node.ImageIndex = 0;
                            node.SelectedImageIndex = 0;
                        }
                    }

                    // Recursively load children and apply filter there (if exists)
                    bool hasMatchingChildren = LoadDirectory(directory, node.Nodes, filter, false);

                    int index = directory.IndexOf(MainDefinitions.MainFolderPath);
                    string NodePath = (index < 0)
                        ? directory
                        : VariousFunctions.EnsureTrailingSlash(directory.Remove(index, MainDefinitions.MainFolderPath.Length));

                    // Find hotkey
                    string HotkeyDisplay = "";
                    List<string> FoundHotkey = null;
                    foreach (List<string> Hotkey in HotkeyList)
                    {
                        if (NodePath == Hotkey[0])
                        {
                            HotkeyDisplay = Hotkey[1].Replace("+", " + ");
                        }
                    }
                    if (FoundHotkey != null)
                    {
                        HotkeyList.Remove(FoundHotkey);
                    }
                    node.Tag = new NodeData
                    {
                        Name = dirName,
                        Path = NodePath,
                        HotkeyDisplay = HotkeyDisplay,
                        Icon = ImageIndex,
                        Cached = Cached
                    };

                    if (OptionUseSimplifiedTreeView)
                    {
                        if (HotkeyDisplay != "")
                            node.Text += $" ({HotkeyDisplay})";
                    }

                    // Search
                    switch (filter)
                    {
                        case "":
                            nodes.Add(node);
                            break;
                        default:
                            if (((NodeData)node.Tag).Path.ToLower().Contains
                                (filter.ToLower().Replace("/", "\\")) || hasMatchingChildren)
                            {
                                nodes.Add(node);
                                anyMatchInThisLevel = true;
                            }
                            break;
                    }
                }

                return anyMatchInThisLevel;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (TreeViewShowLoadingScreen)
                {
                    treeView1.EndUpdate();
                    treeView1.ResumeLayout();
                    treeView1.Visible = true;
                }
            }
        }

        private TreeNode FindNodeByPath(string path)
        {
            var stack = new Stack<TreeNode>();

            foreach (TreeNode n in treeView1.Nodes)
                stack.Push(n);

            while (stack.Count > 0)
            {
                TreeNode current = stack.Pop();

                if (current.Tag is NodeData data && data.Path == path)
                    return current;

                foreach (TreeNode child in current.Nodes)
                    stack.Push(child);
            }

            return null; // Not found
        }

        private Image GetFolderIcon(string folderPath)
        {
            try
            {
                // See if a folder has a special icon
                string directoryIconPath = Path.Combine(folderPath, "DirectoryIcon.png");
                if (File.Exists(directoryIconPath))
                {
                    return Image.FromStream
                        (new MemoryStream(File.ReadAllBytes(directoryIconPath)));
                }

                // If not, try using the first match in the template
                List<kCSTemplateTextureAbsolutePath> FoundTextures = TemplateFunctions.GetTexturesInFolder($"{folderPath}\\");
                if (FoundTextures.Count > 0)
                {
                    return Image.FromStream
                        (new MemoryStream(File.ReadAllBytes(FoundTextures[0].AbsolutePath)));
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        private void UpdateNodeDisplay(TreeNode node, bool InvalidateAfterwards)
        {
            ((NodeData)node.Tag).HotkeyDisplay = FindHotkeyForNode(node);

            if (!OptionUseSimplifiedTreeView)
            {
                if (InvalidateAfterwards) treeView1.Invalidate();
            }
            else
            {
                node.Text = ((NodeData)node.Tag).Name;
                if (((NodeData)node.Tag).HotkeyDisplay != "")
                    node.Text += $" ({((NodeData)node.Tag).HotkeyDisplay})";

                Image folderIcon = GetFolderIcon(Path.Combine(MainDefinitions.MainFolderPath, ((NodeData)node.Tag).Path));
                int iconSize = (int)(16 * (this.DeviceDpi / 96f));

                Image Icon = ResizeImage(folderIcon, iconSize, iconSize);
                if (((NodeData)node.Tag).Cached && OptionDisplayCache) Icon = AddSimplifiedCacheIcon(Icon);

                treeView1.ImageList.Images[node.ImageIndex] = Icon;

                node.SelectedImageIndex = node.ImageIndex;
                folderIcon.Dispose();
            }
        }

        private void CheckIfANodeIsSelected()
        {
            DropDownApplyTPOther.DropDownItems.Clear();
            ToolApplyTP.Enabled = false;
            DropDownApplyTPOther.Enabled = false;
            ToolApplyRAM.Enabled = false;
            switch (treeView1.SelectedNode)
            {
                case null:
                    break;
                default:
                    List<kCSTemplateTextureAbsolutePath> FoundTextures = FindTextures();
                    if (FoundTextures.Count > 0)
                    {
                        if (SeeIfHasRAM(FoundTextures))
                            ToolApplyRAM.Enabled = true;

                        if (SeeIfHasTP(FoundTextures))
                        {
                            if (MainGameName != "")
                                ToolApplyTP.Enabled = true;
                            if (OtherGamesNames.Count > 0)
                            {
                                DropDownApplyTPOther.Enabled = true;
                                foreach (string Game in OtherGamesNames)
                                {
                                    ToolStripDropDownItem item = new ToolStripMenuItem();
                                    item.Text = Game;
                                    item.Click += (sender, e) =>
                                    {
                                        ApplyTPButton(Game);
                                    };
                                    DropDownApplyTPOther.DropDownItems.Add(item);
                                }
                            }
                        }
                    }
                    break;
            }
        }

        private string FindHotkeyForNode(TreeNode node)
        {
            kCSHotkeysClass JSONHotkeys =
                JsonConvert.DeserializeObject<kCSHotkeysClass>
                (File.ReadAllText(MainDefinitions.HotkeysPath));

            List<List<string>> HotkeyList = new List<List<string>>();
            foreach (var Hotkey in JSONHotkeys.Hotkeys)
            {
                HotkeyList.Add(new List<string> { Hotkey.Path, Hotkey.Keys });
            }

            string HotkeyDisplay = "";

            foreach (List<string> Hotkey in HotkeyList)
            {
                if (((NodeData)node.Tag).Path == Hotkey[0])
                {
                    HotkeyDisplay = Hotkey[1].Replace("+", " + ");
                    break;
                }
            }

            return HotkeyDisplay;
        }

        #endregion

        #region Removing Black Borders

        private void RemoveFromSelectedTextures(string SpecificPathToUse = "")
        {
            if (SpecificPathToUse == "") SpecificPathToUse = GetSelectedTexturePath();
            List<kCSTemplateTextureAbsolutePath> FoundTextures = FindTextures(SpecificPathToUse);
            foreach (kCSTemplateTextureAbsolutePath Texture in FoundTextures)
                ColorFunctions.MakeNeighborsTransparent(Texture.AbsolutePath);
        }

        private void RemoveFromSelectedTexturesAndSub(string SpecificPathToUse = "")
        {
            if (SpecificPathToUse == "") SpecificPathToUse = GetSelectedTexturePath();

            RemoveFromSelectedTextures(SpecificPathToUse);
            foreach (string Dir in Directory.GetDirectories(SpecificPathToUse))
            {
                RemoveFromSelectedTextures(Dir);
                foreach (string SubDir in Directory.GetDirectories(Dir))
                {
                    RemoveFromSelectedTextures(SubDir);
                }
            }
        }

        #endregion

        #region Cache

        private void CacheButtonGenerate(string SpecificPathToUse = "", bool InvalidateAfterwards = true)
        {
            if (SpecificPathToUse == "") SpecificPathToUse = GetSelectedTexturePath();

            List<RAMApplyItem> ToUse = FindAndConvertTexturesRAM(SpecificPathToUse);
            if (ToUse.Count > 0) CacheGenerate
                    (
                ToUse,
                SpecificPathToUse: SpecificPathToUse
                );

            TreeNode node = treeView1.SelectedNode;
            ((NodeData)node.Tag).Cached = true;

            UpdateNodeDisplay(node, InvalidateAfterwards);
        }

        private void CacheButtonGenerateBatch()
        {
            CacheButtonGenerate(InvalidateAfterwards: false);
            foreach (string Dir in Directory.GetDirectories(GetSelectedTexturePath()))
            {
                CacheButtonGenerate(Dir, false);
                foreach (string SubDir in Directory.GetDirectories(Dir))
                {
                    CacheButtonGenerate(SubDir, false);
                }
            }

            foreach (TreeNode node in treeView1.SelectedNode.Nodes)
            {
                ((NodeData)node.Tag).Cached = true;
                UpdateNodeDisplay(node, false);

                foreach (TreeNode subnode in node.Nodes)
                {
                    ((NodeData)subnode.Tag).Cached = true;
                    UpdateNodeDisplay(subnode, false);
                }
            }

            treeView1.Invalidate();
        }

        private void CacheButtonClear(string SpecificPathToUse = "", bool InvalidateAfterwards = true, bool UpdateTreeNode = true)
        {
            if (SpecificPathToUse == "") SpecificPathToUse = GetSelectedTexturePath();

            string CacheLocation = Path.Combine(SpecificPathToUse, MainDefinitions.CacheFilename);
            if (File.Exists(CacheLocation))
                File.Delete(CacheLocation);
            if (UpdateTreeNode)
            {
                TreeNode node = treeView1.SelectedNode;
                ((NodeData)node.Tag).Cached = false;
                UpdateNodeDisplay(node, InvalidateAfterwards);
            }
        }

        private void CacheButtonClearBatch(string SpecificPathToUse = "", bool UpdateTreeNode = true)
        {
            if (SpecificPathToUse == "") SpecificPathToUse = GetSelectedTexturePath();

            CacheButtonClear(SpecificPathToUse, InvalidateAfterwards: false, UpdateTreeNode);
            foreach (string Dir in Directory.GetDirectories(SpecificPathToUse))
            {
                CacheButtonClear(Dir, InvalidateAfterwards: false, UpdateTreeNode);
                foreach (string SubDir in Directory.GetDirectories(Dir))
                {
                    CacheButtonClear(SubDir, InvalidateAfterwards: false, UpdateTreeNode);
                }
            }

            if (UpdateTreeNode)
            {
                foreach (TreeNode node in treeView1.SelectedNode.Nodes)
                {
                    ((NodeData)node.Tag).Cached = false;
                    UpdateNodeDisplay(node, false);

                    foreach (TreeNode subnode in node.Nodes)
                    {
                        ((NodeData)subnode.Tag).Cached = false;
                        UpdateNodeDisplay(subnode, false);
                    }
                }
            }

            treeView1.Invalidate();
        }

        public List<RAMApplyItem> CacheRead(string SpecificPathToUse = "")
        {
            if (SpecificPathToUse == "") SpecificPathToUse = GetSelectedTexturePath();

            string CurrentMainFolder = GetCurrentMainFolder();
            string CachePath = Path.Combine(SpecificPathToUse, MainDefinitions.CacheFilename);

            byte[] Cache = File.ReadAllBytes(CachePath);

            List<RAMApplyItem> FoundCacheTextures = new List<RAMApplyItem>();

            using (FileStream fs = new FileStream(CachePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    // Get first four bytes as the address
                    uint address = reader.ReadUInt32();

                    // Get the next four bytes as the length (aka the amount of bytes in the texture)
                    uint length = reader.ReadUInt32();

                    // Give an error if the specified length is longer than the rest of the file
                    if (reader.BaseStream.Position + length > reader.BaseStream.Length)
                    {
                        throw new Exception
                            (Resources.Error_InvalidCache);
                    }

                    // Treat the specified amount (length) of bytes as the texture.
                    byte[] TextureData = reader.ReadBytes((int)length);
                    FoundCacheTextures.Add(new RAMApplyItem
                    {
                        Pixels = TextureData,
                        SegAddress = BitConverter.ToUInt32(Core.SwapEndian(BitConverter.GetBytes(address), 4), 0)
                    });
                }
            }

            return FoundCacheTextures;
        }

        public bool CacheCheck(string SpecificPathToUse = "")
        {
            if (SpecificPathToUse == "")
            {
                string SelectedTexturePath = GetSelectedTexturePath();
            }

            string CachePath = Path.Combine(SpecificPathToUse, MainDefinitions.CacheFilename);

            return File.Exists(CachePath);
        }

        public void CacheGenerate(List<RAMApplyItem> Textures, string SpecificPathToUse = "")
        {
            // For each texture, a kataraktaCS cache file stores:
            // 1. The segmented address of that texture (to know where to write it in the game's RAM).
            // 2. The length of the texture (to know when the current texture's data ends and another texture's data starts).
            // 3. The texture itself.
            byte[] Cache = { };

            if (Textures.Count > 0)
            {
                foreach (var Texture in Textures)
                {
                    Cache = ColorFunctions.AppendUInt32(Cache, Texture.SegAddress, true);
                    Cache = ColorFunctions.AppendBytes(Cache, BitConverter.GetBytes((UInt32)Texture.Pixels.Length));
                    Cache = ColorFunctions.AppendBytes(Cache, (byte[])Texture.Pixels);
                }

                bool UnspecifiedPath = false;

                if (SpecificPathToUse == "")
                {
                    UnspecifiedPath = true;
                    SpecificPathToUse = GetSelectedTexturePath();
                }

                File.WriteAllBytes(Path.Combine(SpecificPathToUse, MainDefinitions.CacheFilename), Cache);

                if (UnspecifiedPath == true)
                {
                    TreeNode node = treeView1.SelectedNode;
                    ((NodeData)node.Tag).Cached = true;
                    UpdateNodeDisplay(treeView1.SelectedNode, true);
                }
            }
        }

#endregion

        #region Applying

        private void ApplyTPButton(string GameName, string SpecificPathToUse = "")
        {
            if (SpecificPathToUse == "") SpecificPathToUse =
                    Path.Combine(MainDefinitions.MainFolderPath + ((NodeData)treeView1.SelectedNode.Tag).Path);
            SpecificPathToUse = VariousFunctions.EnsureTrailingSlash(SpecificPathToUse);

            List<kCSTemplateTextureAbsolutePath> FoundTextures = FindTextures(SpecificPathToUse);
            List<TPApplyItem> ToApply = DetermineTexturesTP(FoundTextures);

            string DestPath = Path.Combine(HiResTexturePath, GameName);
            Directory.CreateDirectory(DestPath);

            foreach (TPApplyItem Texture in ToApply)
            {
                File.Copy(
                    Texture.AbsolutePath,
                    Path.Combine(
                        DestPath, GameName + Texture.Filename + ".png"
                    ),
                    true
                );
            }

            // Remove the cache file, which is created by some graphics
            // plugins and can result in inability to change textures
            File.Delete(Path.Combine(DestPath, "Cache.ini"));
            File.Delete(Path.Combine(DestPath, "cache.ini"));
            File.Delete(Path.Combine(HiResTexturePath, "Cache.ini"));
            File.Delete(Path.Combine(HiResTexturePath, "cache.ini"));
        }

        private void ApplyRAMButton(string SpecificPathToUse = "")
        {
            if (SpecificPathToUse == "") SpecificPathToUse =
                    Path.Combine(MainDefinitions.MainFolderPath + ((NodeData)treeView1.SelectedNode.Tag).Path);
            SpecificPathToUse = VariousFunctions.EnsureTrailingSlash(SpecificPathToUse);
            // Apply the cache even if it's outdated.
            // It will get verified and reapplied in
            // a moment anyway.
            if (CacheCheck(SpecificPathToUse))
            {
                List<RAMApplyItem> CurrentCache = CacheRead(SpecificPathToUse);
                foreach (var item in CurrentCache)
                    ApplyTextureRAM(item.Pixels, item.SegAddress);
            }
            List<RAMApplyItem> ToApply = FindAndConvertTexturesRAM(SpecificPathToUse);
            if (ToApply.Count > 0)
            {
                foreach (var item in ToApply)
                    ApplyTextureRAM(item.Pixels, item.SegAddress);
                CacheGenerate(ToApply);
            }
        }

        public void ApplyRAMApplyItem(List<RAMApplyItem> Textures)
        {
            foreach (var item in Textures)
            {
                ApplyTextureRAM(item.Pixels, item.SegAddress);
            }
        }

        public void ApplyTextureRAM(byte[] Pixels, uint SegAddress)
        {
            Core.WriteBytes(Core.SegmentedToVirtual(SegAddress), Pixels);
        }

        #endregion

        #region Various

        private Image AddBGColor(Image original, Color BG)
        {
            var destImage = new Bitmap(original.Width, original.Height);
            using (var g = Graphics.FromImage(destImage))
            {
                g.Clear(BG);
                g.DrawImage(original, new Point(0, 0));
            }
            return destImage;
        }

        private Image AddSimplifiedCacheIcon(Image original)
        {
            Image ImageBackground = original;
            Image ImageOverlay = Resources.Icon_Cache;

            Bitmap FinalImage = new Bitmap(ImageBackground.Width, ImageBackground.Height, PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(FinalImage))
            {
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.DrawImage(ImageBackground, new Point(0, 0));
                g.DrawImage(ImageOverlay, new Point(0, 0));
            }

            return FinalImage;
        }

        private Image ResizeImage(Image original, int width, int height)
        // WinForms doesn't resize icons with filtering and it looks weird,
        // so this is a function that manually does it. It just looks better
        // but it's also in line with the original katarakta.
        {
            var destImage = new Bitmap(width, height);
            using (var g = Graphics.FromImage(destImage))
            {
                g.Clear(TextureBG);

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

            if (treeView1.RightToLeftLayout)
            {
                destImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            return destImage;
        }

        #endregion

        #region UI Methods

        private void ToolSearchMethod()
        {
            RadioButton CurrentFolder = GetCurrentMainFolderRadio();
            if (CurrentFolder != null)
            {
                OpenMainFolder(CurrentFolder, true);
            }

            // original katarakta easter egg
            if (ToolSearch.Text == $"2023.05.20") this.Text = $"katarakta ({kataraktaVersion.VersionName})";
        }

        public void RefreshButton()
        {
            HotkeyManager.UnregisterAll();

            flowLayoutPanel1.Controls.Clear();
            treeView1.Nodes.Clear();
            RefreshMainFolderList();

            InitializeHotkeys();
        }

        private void CheckStayOnTop()
        {
            switch (menuStayOnTop.Checked)
            {
                case false:
                    menuStayOnTop.Checked = true;
                    TopMost = true;
                    break;
                default:
                    menuStayOnTop.Checked = false;
                    TopMost = false;
                    break;
            }
        }

        #endregion

        #region Updates


        private async void mainForm_Load(object sender, EventArgs e)
        {
            await CheckForUpdates();
        }

        private void UpdatesButtonPress()
        {
            switch (IsLatestVersion)
            {
                case "True":
                    Process.Start($"https://github.com/{CreatorName}/{AddonLinkName}/releases");
                    break;
                case "False":
                    Process.Start($"https://github.com/{CreatorName}/{AddonLinkName}/releases/latest");
                    break;
                default:
                    DialogResult result = MessageBox.Show(
                        Resources.updates_unknown_elaborate,
                        Resources.updates_unknown_string,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        Process.Start($"https://github.com/{CreatorName}/{AddonLinkName}/releases/latest");
                    }
                    break;
            }
        }

        private async Task CheckForUpdates()
        {
            menuUpdates.Image = Resources.updates_unknown;
            menuUpdates.Text = Resources.updates_checking_string;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", $"{AddonLinkName}")
;
                    var LatestResponse = await client.GetStringAsync($"https://api.github.com/repos/{CreatorName}/{AddonLinkName}/releases/latest");

                    JObject json = JObject.Parse(LatestResponse);
                    LatestVersion = (string)json["name"];

                    if ($"{AddonReleaseName} v" + ProductVersion == LatestVersion)
                        IsLatestVersion = "True";
                    else IsLatestVersion = "False";
                }
            }
            catch
            {
                IsLatestVersion = "Unknown";
                LatestVersion = "Unknown";
            }

            switch (IsLatestVersion)
            {
                case "True":
                    menuUpdates.Image = Resources.updates_latest;
                    menuUpdates.Text = Resources.updates_latest_string;
                    break;
                case "False":
                    menuUpdates.Image = Resources.updates_outdated;
                    menuUpdates.Text = Resources.updates_outdated_string;
                    break;
                default:
                    menuUpdates.Image = Resources.updates_unknown;
                    menuUpdates.Text = Resources.updates_unknown_string;
                    break;
            }
        }

        #endregion

        #region Hooking up to UI

        private void ToolRefresh_Click(object sender, EventArgs e)
        {
            RefreshButton();
        }

        private void ToolApplyRAM_Click(object sender, EventArgs e)
        {
            ApplyRAMButton();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void menuStayOnTop_Click(object sender, EventArgs e)
        {
            CheckStayOnTop();
        }

        private void ToolSearchButton_Click(object sender, EventArgs e)
        {
            ToolSearchMethod();
        }

        private void menuManualGenerateCache_Click(object sender, EventArgs e)
        {
            List<RAMApplyItem> ToUse = FindAndConvertTexturesRAM();
            CacheGenerate(ToUse);
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                ToolSearch.Focus();
                e.Handled = true;
                // Below is a thing that prevents Windows from doing that “ding” sound when you press a key
                e.SuppressKeyPress = true;
            }

            if (ToolSearch.Focused && e.KeyCode == Keys.Enter)
            {
                ToolSearchMethod();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.R)
            {
                RefreshButton();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextSwapTemplates.DropDownItems.Clear();
                RightClickType = "TreeNode";
                RightClickPath = ((NodeData)e.Node.Tag).Path;
                string FullPath = MainDefinitions.MainFolderPath + ((NodeData)e.Node.Tag).Path;
                bool ShowSeparatorUtilities = false;

                treeView1.SelectedNode = e.Node;

                CurrentQuickHotkey = new frmQuickHotkey(RightClickPath, ((NodeData)e.Node.Tag).HotkeyDisplay);
                TemplateManager = new frmTemplateManager(RightClickPath);

                CurrentQuickHotkey.RefreshMainForm -= () => UpdateNodeDisplay(e.Node, true);
                CurrentQuickHotkey.RefreshMainForm -= () => InitializeHotkeys();
                CurrentQuickHotkey.RefreshMainForm += () => UpdateNodeDisplay(e.Node, true);
                CurrentQuickHotkey.RefreshMainForm += () => InitializeHotkeys();

                //contextApplyTexture.Visible = true;
                //SeparatorApply.Visible = true;

                contextShowInExplorer.Visible = true;
                contextEditTemplates.Visible = true;

                if (((NodeData)e.Node.Tag).HotkeyDisplay != "")
                {
                    contextHotkeyAdd.Visible = false;
                    contextHotkeyEdit.Visible = true;
                    contextHotkeyRemove.Visible = true;
                }
                else
                {
                    contextHotkeyAdd.Visible = true;
                    contextHotkeyEdit.Visible = false;
                    contextHotkeyRemove.Visible = false;
                }

                List<kCSTemplateTextureAbsolutePath> UsedTextures = FindTextures();
                if (SeeIfHasRAM(UsedTextures))
                {
                    contextCache.Visible = true;
                    contextCacheGenSelected.Visible = true;
                    contextCacheGenSelectedAndSub.Visible = true;
                    SeparatorGenerateCache.Visible = true;
                    contextCacheClearSelected.Visible = true;
                    contextCacheClearSelectedAndSub.Visible = true;
                    SeparatorHotkeys.Visible = true;
                    ShowSeparatorUtilities = true;
                }
                else
                {
                    contextCache.Visible = false;
                    contextCacheGenSelected.Visible = false;
                    contextCacheGenSelectedAndSub.Visible = false;
                    SeparatorGenerateCache.Visible = false;
                    contextCacheClearSelected.Visible = false;
                    contextCacheClearSelectedAndSub.Visible = false;

                    contextHotkeyAdd.Visible = false;
                    contextHotkeyEdit.Visible = false;
                    contextHotkeyRemove.Visible = false;
                    SeparatorHotkeys.Visible = false;
                }

                if (UsedTextures.Count > 0)
                {
                    contextRemoveBorders.Visible = true;
                    contextRemoveBordersSelected.Visible = true;
                    contextRemoveBordersSelectedAndSub.Visible = true;
                    ShowSeparatorUtilities = true;
                }
                else
                {
                    contextRemoveBorders.Visible = false;
                    contextRemoveBordersSelected.Visible = false;
                    contextRemoveBordersSelectedAndSub.Visible = false;
                }

                List<string> UsedTemplates =
                    TemplateFunctions.GetAllTemplateFiles(FullPath, Subfolders: false);
                if (UsedTemplates.Count > 0 && TemplateFunctions.HasFolderSettings(FullPath))
                {
                    contextSwapTemplates.Visible = true;
                    ShowSeparatorUtilities = true;

                    string FolderSettingsPath = Path.Combine(FullPath, "FolderSettings.json");
                    JObject JSONFolderSettings = JObject.Parse(File.ReadAllText(FolderSettingsPath));
                    foreach (string Template in UsedTemplates)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        string Filename = Path.GetFileNameWithoutExtension(Template);
                        item.Text = Filename;
                        item.Click += (sender_, e_) =>
                        {
                            TemplateFunctions.SwapFolderSettingsTemplate
                            (FolderSettingsPath, Filename);

                            // Clear cache because using the wrong
                            // cache in a wrong place can end badly
                            CacheButtonClearBatch();
                        };

                        // If the current template of the folder settings matches
                        // the filename of this item, then make it checked
                        if (JSONFolderSettings["Template"]?["Filename"]?.ToString() == Filename)
                            item.Checked = true;
                        contextSwapTemplates.DropDownItems.Add(item);
                    }
                }
                else
                    contextSwapTemplates.Visible = false;

                if (ShowSeparatorUtilities)
                    SeparatorUtilities.Visible = true;
                else SeparatorUtilities.Visible = false;

                contextMenu.Show(treeView1, e.Location);
            }
        }

        private void contextHotkeyAdd_Click(object sender, EventArgs e)
        {
            HotkeyManager.UnregisterAll();
            CurrentQuickHotkey.ShowDialog();
        }

        private void contextHotkeyEdit_Click(object sender, EventArgs e)
        {
            HotkeyManager.UnregisterAll();
            CurrentQuickHotkey.ShowDialog();
        }

        private void contextHotkeyRemove_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            HotkeyEdit.ModifyHotkeys(
                PathOfHotkey: ((NodeData)node.Tag).Path,
                RemoveInsteadOfAdd: false);
            UpdateNodeDisplay(node, true);
            
            HotkeyManager.UnregisterAll();
            InitializeHotkeys();
        }

        private void contextShowInExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(
            MainDefinitions.MainFolderPath, RightClickPath)
            );
        }

        private void contextApplyTexture_Click(object sender, EventArgs e)
        {
            ApplyRAMButton();
        }

        private void contextCacheGenSelected_Click(object sender, EventArgs e)
        {
            CacheButtonGenerate();
        }

        private void contextCacheGenSelectedAndSub_Click(object sender, EventArgs e)
        {
            CacheButtonGenerateBatch();
        }

        private void contextCacheClearSelected_Click(object sender, EventArgs e)
        {
            CacheButtonClear();
        }

        private void contextCacheClearSelectedAndSub_Click(object sender, EventArgs e)
        {
            CacheButtonClearBatch();
        }

        private void openKataraktaCSFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(MainDefinitions.kataraktaPath);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings = new frmSettings();

            Settings.RefreshMainForm -= () => RefreshMainFolderList();
            Settings.RefreshMainForm += () => RefreshMainFolderList();

            Settings.Show();
        }

        private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckStayOnTop();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About = new frmAbout();
            About.Show();
        }

        private void menuOpenQuad64_Click(object sender, EventArgs e)
        {
            Quad64 = new frmQuad64();
            Quad64.Show();
        }

        private void contextEditTemplates_Click(object sender, EventArgs e)
        {
            TemplateManager.Show();
        }

        private void menuConvertTemplates_Click(object sender, EventArgs e)
        {
            foreach (string Path in TemplateFunctions.GetAllTemplateFiles(MainDefinitions.MainFolderPath))
                TemplateFunctions.ConvertTemplate(Path);
            foreach (string Path in TemplateFunctions.GetAllFolderSettingsFiles(MainDefinitions.MainFolderPath))
                TemplateFunctions.ConvertFolderSettings(Path);
        }

        private void menuOpenTemplateManager_Click(object sender, EventArgs e)
        {
            TemplateManager = new frmTemplateManager();
            TemplateManager.Show();
        }

        private void ToolApplyTP_Click(object sender, EventArgs e)
        {
            ApplyTPButton(MainGameName);
        }

        private void contextRemoveBordersSelected_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                Resources.ConfirmTextureBorders,
                Resources.Confirm_Title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.Yes)
            {
                RemoveFromSelectedTextures();
                CacheButtonGenerate();
            }
        }

        private void contextRemoveBordersSelectedAndSub_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                Resources.ConfirmTextureBorders,
                Resources.Confirm_Title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.Yes)
            {
                RemoveFromSelectedTexturesAndSub();
                CacheButtonGenerateBatch();
            }
        }

        private void menuUpdates_Click(object sender, EventArgs e)
        {
            UpdatesButtonPress();
        }

        private async void menuUpdatesRefresh_Click(object sender, EventArgs e)
        {
            await CheckForUpdates();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
    }
}

#endregion