using System;
using System.IO;
using System.Windows.Forms;
using kataraktaCS.Controls.kataraktaTreeView;
using Newtonsoft.Json;
using System.Drawing;

namespace kataraktaCS
{
    public partial class frmHotkeySettings : Form
    {
        public bool isSelecting = false;

        private MainDefinitions MainDefinitions;
        private HotkeyManager HotkeyManager;
        private HotkeyConverter HotkeyConverter;

        public frmHotkeySettings()
        {
            InitializeComponent();
            SetUpTreeViewDrawMode();
            this.KeyPreview = true;
            this.KeyDown += ToolTextBoxHotkey_KeyDown;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            HotkeyManager = new HotkeyManager(this);
            HotkeyConverter = new HotkeyConverter();

            LoadHotkeys();
        }

        private void ToolTextBoxHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            if (ToolTextBoxHotkey.Focused == true)
            {
                e.SuppressKeyPress = true;

                string Hotkey = "";

                if (e.Control) Hotkey += "Ctrl + ";
                if (e.Shift) Hotkey += "Shift + ";
                if (e.Alt) Hotkey += "Alt + ";

                if (e.KeyCode != Keys.ControlKey &&
                    e.KeyCode != Keys.ShiftKey &&
                    e.KeyCode != Keys.Menu) // Menu = Alt
                {
                    Hotkey += e.KeyCode.ToString().ToUpper();
                }

                else if (Hotkey.EndsWith(" + "))
                {
                    // Remove trailing " + " if there's nothing afterwards
                    Hotkey = Hotkey.Substring(0, Hotkey.Length - 3);
                }

                ToolTextBoxHotkey.Text = Hotkey;
            }
        }

        public void SetUpTreeViewDrawMode()
        {
            // See explanation in mainForm.cs
            treeViewHotkeys.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeViewHotkeys.DrawNode += (s, e) =>
            {
                string FirstColText = ((frmHotkeySettingsNodeData)e.Node.Tag).Hotkey.Replace("+", " + ");
                e.Graphics.DrawString(FirstColText, treeViewHotkeys.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 2);

                int width;
                using (Graphics g = treeViewHotkeys.CreateGraphics())
                {
                    width = TextRenderer.MeasureText(g, FirstColText, treeViewHotkeys.Font).Width;
                }
                int SecondColX = e.Bounds.Left + width;

                string SecondColText = ((frmHotkeySettingsNodeData)e.Node.Tag).Path;
                e.Graphics.DrawString(SecondColText, treeViewHotkeys.Font, Brushes.Gray, SecondColX, e.Bounds.Top + 2);
            };
        }

        public void LoadHotkeys()
        {
            treeViewHotkeys.Controls.Clear();

            // BeginUpdate and SuspendLayout make it load way faster
            treeViewHotkeys.BeginUpdate();
            treeViewHotkeys.SuspendLayout();
            treeViewHotkeys.Visible = false;

            if (File.Exists(MainDefinitions.HotkeysPath))
            {
                kCSHotkeysRoot JSONHotkeys = JsonConvert.DeserializeObject<kCSHotkeysRoot>(File.ReadAllText($"{MainDefinitions.kataraktaPath}Hotkeys.json"));

                foreach (var hotkey in JSONHotkeys.kCSHotkeys.Hotkeys)
                {
                    try
                    {
                        TreeNode node = new TreeNode("");

                        string StringPath = hotkey.Path;
                        string StringKeys = hotkey.Keys;

                        node.Tag = new frmHotkeySettingsNodeData { Path = StringPath, Hotkey = StringKeys };

                        //treeViewHotkeys.Nodes.Add($"{StringKeys.Replace("+", " + ")} | {StringPath}");
                        treeViewHotkeys.Nodes.Add(node);
                        // HotkeyManagerInstance.RegisterHotkey(HotkeyEditInstance.StringToHotkey(StringKeys), () => UseHotkeyByPath(StringPath));
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Cannot find the path to the hotkeys file, which is supposed to be at: {MainDefinitions.HotkeysPath}");
            }

            treeViewHotkeys.EndUpdate();
            treeViewHotkeys.ResumeLayout();
            treeViewHotkeys.Visible = true;
        }

        protected void treeViewHotkeys_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (isSelecting) // Should prevent the method from repeating when it's not needed
            {
                return;
            }

            isSelecting = true;

            e.Cancel = true;

            kataraktaTreeView treeView = sender as kataraktaTreeView;

            // The canceling and programmatic selecting are done because otherwise it would scroll to the selected node even when it's not needed
            treeView.SelectedNode = e.Node;

            isSelecting = false;
        }
    }
}
