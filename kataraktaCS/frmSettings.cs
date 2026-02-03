using kataraktaCS.Properties;
using M64MM.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace kataraktaCS
{
    public partial class frmSettings : Form
    {
        public event Action RefreshMainForm;
        Color TextureBG;

        public frmSettings()
        {
            InitializeComponent();

            SettingsLoad();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void SettingsLoad()
        {
            JObject JSONSettings = JObject.Parse(File.ReadAllText(MainDefinitions.SettingsPath));

            textBoxTexturePackHiResPath.Text = JSONSettings.Value<string>("TexturePack_HiResPath") ?? "";
            textBoxTexturePackMainGame.Text = JSONSettings.Value<string>("TexturePack_MainGameName") ?? "SUPER MARIO 64";
            string[] OtherGamesNames = JSONSettings["TexturePack_OtherGamesNames"]?
                .ToObject<string[]>()
                ?? Array.Empty<string>();

            foreach (string OtherGameName in OtherGamesNames)
                listViewOtherGames.Items.Add(OtherGameName);

            checkStayOnTop.Checked = JSONSettings.Value<bool?>("EnableStayOnTop") ?? false;
            checkLinuxCompatibility.Checked = JSONSettings.Value<bool?>("LinuxCompatibility") ?? false;

            checkTreeViewSimplified.Checked = JSONSettings.Value<bool?>("TreeView_UseSimplifiedTreeView") ?? false;
            checkTreeViewDisplayIcons.Checked = JSONSettings.Value<bool?>("TreeView_DisplayIcons") ?? true;
            checkTreeViewDisplayCache.Checked = JSONSettings.Value<bool?>("TreeView_DisplayCache") ?? false;
            checkDisplayCacheOnRight.Checked = JSONSettings.Value<bool?>("TreeView_DisplayCacheOnRight") ?? false;

            string BackColor = JSONSettings.Value<string>("Appearance_TextureBG") ?? "AAAAAA";
            buttonBackgroundColor.BackColor = ColorTranslator.FromHtml("#" + BackColor);
        }

        private void SettingsSave()
        {
            TextureBG = buttonBackgroundColor.BackColor;
            List<string> OtherGamesNames = new List<string>();
            foreach (ListViewItem item in listViewOtherGames.Items)
                OtherGamesNames.Add(item.Text);

            var NewSettings = new
            {
                TexturePack_HiResPath = textBoxTexturePackHiResPath.Text,
                TexturePack_MainGameName = textBoxTexturePackMainGame.Text,
                TexturePack_OtherGamesNames = OtherGamesNames,
                EnableStayOnTop = checkStayOnTop.Checked,
                LinuxCompatibility = checkLinuxCompatibility.Checked,
                TreeView_UseSimplifiedTreeView = checkTreeViewSimplified.Checked,
                TreeView_DisplayIcons = checkTreeViewDisplayIcons.Checked,
                TreeView_DisplayCache = checkTreeViewDisplayCache.Checked,
                TreeView_DisplayCacheOnRight = checkDisplayCacheOnRight.Checked,
                Appearance_TextureBG = $"{TextureBG.R:X2}{TextureBG.G:X2}{TextureBG.B:X2}"
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

            RefreshMainForm?.Invoke();
        }

        private void ChangeTextureBG()
        {
            colorDialog1.Color = buttonBackgroundColor.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TextureBG = colorDialog1.Color;
                buttonBackgroundColor.BackColor = TextureBG;
            }
        }

        private void ResetTextureBG()
        {
            TextureBG = Color.FromArgb(0xFF, 0xAA, 0xAA, 0xAA);
            buttonBackgroundColor.BackColor = TextureBG;
        }

        private void buttonApply_Click(object sender, System.EventArgs e)
        {
            SettingsSave();
        }

        private void buttonApplyAndClose_Click(object sender, System.EventArgs e)
        {
            SettingsSave();
            Close();
        }

        private void buttonClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void buttonResetBackgroundColor_Click(object sender, EventArgs e)
        {
            ResetTextureBG();
        }

        private void buttonBackgroundColor_Click(object sender, EventArgs e)
        {
            ChangeTextureBG();
        }

        private void buttonHiresPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = Resources.Settings_SelectHiResPath;
                dialog.ShowNewFolderButton = true;
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string SelectedPath = dialog.SelectedPath;
                    if (!SelectedPath.EndsWith("\\"))
                        SelectedPath += "\\";
                    textBoxTexturePackHiResPath.Text = SelectedPath;
                }
            }
        }

        private void buttonAddGame_Click(object sender, EventArgs e)
        {
            listViewOtherGames.Items.Add(Resources.Settings_InsertGameNameHere);
        }

        private void buttonRemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewOtherGames.SelectedItems)
                item.Remove();
        }
    }
}
