using kataraktaCS.Controls.kataraktaListView;
using kataraktaCS.Controls.kataraktaTreeViewLessFancy;
using kataraktaCS.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace kataraktaCS
{
    public partial class frmTemplateManager : Form
    {
        public bool isSelecting = false;
        private string OpenedPath = null;

        private MainDefinitions MainDefinitions;
        private VariousFunctions VariousFunctions;
        private TemplateFunctions TemplateFunctions;

        public frmTemplateManager(string Path = null)
        {
            //582; 450

            InitializeComponent();

            Point Point1 = new Point(
                groupTemplateMain.Location.X,
                groupTemplateMain.Location.Y);
            Point Point2 = new Point(
                groupTemplateItems.Location.X + groupTemplateItems.Width,
                groupTemplateItems.Location.Y + groupTemplateItems.Height);
            Point MiddlePoint = new Point((Point1.X + Point2.X) / 2, (Point1.Y + Point2.Y) / 2);
            MiddlePoint.X -= labelSelectSomething.Width / 2;
            MiddlePoint.Y -= labelSelectSomething.Height / 2;
            labelSelectSomething.Show();
            labelSelectSomething.Location = MiddlePoint;
            groupFolderSettings.Hide();
            groupFolderSettings.Location = groupTemplateMain.Location;
            groupTemplateMain.Hide();
            groupTemplateItems.Hide();

            MainDefinitions = new MainDefinitions();
            VariousFunctions = new VariousFunctions();
            TemplateFunctions = new TemplateFunctions();

            comboFolderSettingsTemplateUsed.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTextureFormat.DropDownStyle = ComboBoxStyle.DropDownList;

            listViewEditTemplate.BackColor = Color.FromArgb(0xD6, 0xD6, 0xD6);

            LoadDirectory(MainDefinitions.MainFolderPath, treeViewTemplateExplorer.Nodes);
            ApplyTags(treeViewTemplateExplorer.Nodes);

            if (Path != null)
            {
                OpenedPath = Path;
                if (OpenedPath.EndsWith("\\"))
                    OpenedPath = OpenedPath.Remove(OpenedPath.Length - 1);
            }

            this.Shown += OnShown;
        }

        private void LoadDirectory(string path, TreeNodeCollection nodes)
        {
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string dirName = Path.GetFileName(file);
                FileAttributes attributes = File.GetAttributes(file);

                TreeNode node = new TreeNode(dirName);

                if (dirName == "FolderSettings.json")
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                }
                else if (dirName.EndsWith(".json"))
                {
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                }
                else
                {
                    continue;
                }
                nodes.Add(node);
            }

            foreach (string directory in directories)
            {
                string dirName = Path.GetFileName(directory);
                FileAttributes attributes = File.GetAttributes(directory);

                TreeNode node = new TreeNode(dirName);
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                LoadDirectory(directory, node.Nodes);
                nodes.Add(node);
            }
        }

        private void ApplyTags(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Tag = node.FullPath;
                ApplyTags(node.Nodes);
            }
        }

        protected void treeViewTemplateExplorer_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (isSelecting) // Should prevent the method from repeating when it's not needed
            {
                return;
            }

            isSelecting = true;

            e.Cancel = true;

            kataraktaTreeViewLessFancy treeView = sender as kataraktaTreeViewLessFancy;

            // The canceling and programmatic selecting are done because otherwise
            // it would scroll to the selected node even when it's not needed
            treeView.SelectedNode = e.Node;

            isSelecting = false;
        }

        protected void treeViewTemplateExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            kataraktaTreeViewLessFancy treeView = sender as kataraktaTreeViewLessFancy;

            if (treeView != null)
            {
                listViewEditTemplate.Items.Clear();

                buttonCreateFolderSettings.Text = Resources.buttonCreateFolderSettings;
                buttonCreateTemplate.Text = Resources.buttonCreateTemplate;

                ClearInputs();

                string NodeFullPath = MainDefinitions.MainFolderPath + treeView.SelectedNode.FullPath;
                string NodeDirectory = NodeFullPath;
                if (treeView.SelectedNode.Text == "FolderSettings.json")
                {
                    buttonCreateFolderSettings.Text = Resources.buttonRemoveFolderSettings;
                    NodeDirectory = Path.GetDirectoryName(NodeDirectory);
                    if (ReadFolderSettings(NodeFullPath))
                    {
                        // Only do all this if ReadFolderSettings
                        // returned true, which means that it has
                        // read everything without any errors.
                        buttonSave.Enabled = true;
                        groupFolderSettings.Enabled = true;
                        groupFolderSettings.Show();
                        labelSelectSomething.Hide();
                    }
                }
                else if (treeView.SelectedNode.Text.EndsWith(".json"))
                {
                    buttonCreateTemplate.Text = Resources.buttonRemoveTemplate;
                    NodeDirectory = Path.GetDirectoryName(NodeDirectory);
                    if (ReadTemplateTextures(NodeFullPath))
                    {
                        // Only do all this if ReadTemplateTextures
                        // returned true, which means that it has
                        // read everything without any errors.
                        groupTemplateMain.Enabled = true;
                        buttonAddTexture.Enabled = true;
                        buttonSave.Enabled = true;
                        groupTemplateMain.Show();
                        groupTemplateItems.Show();
                        labelSelectSomething.Hide();
                    }
                }

                if (File.Exists(Path.Combine(NodeDirectory, "FolderSettings.json")))
                {
                    buttonCreateFolderSettings.Text = Resources.buttonRemoveFolderSettings;
                }
            }
        }

        protected void listViewEditTemplate_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            kataraktaListView listView = sender as kataraktaListView;

            groupTemplateItems.Enabled = true;

            if (listView.SelectedItems.Count == 0)
                return;

            ListViewItem item = listView.SelectedItems[0];
            item.ImageIndex = 3;

            textBoxTextureTitle.Text = ((kCSTemplateTexture)item.Tag).Title;
            checkTextureDisplay.Checked = ((kCSTemplateTexture)item.Tag).Display;
            textBoxTexturePackFilename.Text = ((kCSTemplateTexture)item.Tag).TexturePackFilename;
            textBoxTextureAltFilename.Text = ((kCSTemplateTexture)item.Tag).AlternativeFilename;
            textBoxTextureSegAddr.Text = ((kCSTemplateTexture)item.Tag).RAM;

            string RAMFormat = ((kCSTemplateTexture)item.Tag).RAMFormat;
            switch (RAMFormat)
            {
                case "I4": comboTextureFormat.Text = "I4"; break;
                case "IA4": comboTextureFormat.Text = "IA4"; break;
                case "I8": comboTextureFormat.Text = "I8"; break;
                case "IA8": comboTextureFormat.Text = "IA8"; break;
                case "RGBA16": comboTextureFormat.Text = "RGBA16"; break;
                case "IA16": comboTextureFormat.Text = "IA16"; break;
                case "RGBA32": comboTextureFormat.Text = "RGBA32"; break;
                default: comboTextureFormat.Text = ""; break;
            }

            buttonRemoveTexture.Enabled = true;
        }

        private bool ReadFolderSettings(string FolderSettingsPath)
        {
            try
            {
                kCSFolderClass JSONFolderSettings =
                    JsonConvert.DeserializeObject<kCSFolderClass>(File.ReadAllText(FolderSettingsPath));

                ReadAvailableTemplates(Path.GetDirectoryName(FolderSettingsPath));

                comboFolderSettingsTemplateUsed.Text = JSONFolderSettings.Template.Filename;
                checkFolderSettingsCoverSubfolders.Checked = JSONFolderSettings.Template.CoverSubfolders;
                return true;
            }
            catch
            {
                MessageBox.Show(
                    Resources.Error_NotValidFolderSettings,
                    Resources.Error_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }
        }

        private void ReadAvailableTemplates(string TemplatePath)
        {
            comboFolderSettingsTemplateUsed.Items.Clear();
            string[] files = Directory.GetFiles(TemplatePath);

            foreach (string file in files)
            {
                string dirName = Path.GetFileName(file);
                FileAttributes attributes = File.GetAttributes(file);

                if (dirName == "FolderSettings.json")
                {
                    continue;
                }
                else if (dirName.EndsWith(".json"))
                {
                    comboFolderSettingsTemplateUsed.Items.Add(Path.GetFileNameWithoutExtension(dirName));
                }
            }
        }

        private bool ReadTemplateTextures(string TemplatePath)
        {
            listViewEditTemplate.Items.Clear();

            kCSTemplateClass JSONTemplate =
                JsonConvert.DeserializeObject<kCSTemplateClass>(File.ReadAllText(TemplatePath));

            string Filename = Path.GetFileName(Path.GetFileNameWithoutExtension(TemplatePath));
            if (JSONTemplate.Description != null)
            {
                textBoxTemplateFilename.Text = Filename;
                textBoxTemplateTitle.Text = JSONTemplate.Title;
                textBoxTemplateDesc.Text = JSONTemplate.Description;

                foreach (kCSTemplateTexture Texture in JSONTemplate.UsedTextures)
                {
                    ListViewItem item = new ListViewItem(Texture.Title);
                    item.ImageIndex = 3;
                    item.Tag = Texture;
                    listViewEditTemplate.Items.Add(item);
                }
                return true;
            }
            else
            {
                MessageBox.Show(
                    Resources.Error_NotValidTemplate,
                    Resources.Error_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }
        }

        private void ClearInputs()
        {
            groupFolderSettings.Hide();
            groupTemplateMain.Hide();
            groupTemplateItems.Hide();
            labelSelectSomething.Show();

            buttonAddTexture.Enabled = false;
            buttonRemoveTexture.Enabled = false;
            buttonSave.Enabled = false;

            textBoxTemplateFilename.Text = "";
            textBoxTemplateTitle.Text = "";
            textBoxTemplateDesc.Text = "";

            textBoxTextureTitle.Text = "";
            checkTextureDisplay.Checked = false;
            textBoxTexturePackFilename.Text = "";
            textBoxTextureAltFilename.Text = "";
            textBoxTextureSegAddr.Text = "";
            comboTextureFormat.Text = "";

            comboFolderSettingsTemplateUsed.Text = "";
            checkFolderSettingsCoverSubfolders.Checked = false;

            groupFolderSettings.Enabled = false;
            groupTemplateMain.Enabled = false;
            groupTemplateItems.Enabled = false;
        }

        private void comboFolderSettingsTemplateType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ReadAvailableTemplates(Path.GetDirectoryName(MainDefinitions.MainFolderPath + treeViewTemplateExplorer.SelectedNode.FullPath));
        }

        private void buttonCreateTemplate_Click(object sender, System.EventArgs e)
        {
            TreeNode SelectedNode = treeViewTemplateExplorer.SelectedNode;
            string NodeFullPath = MainDefinitions.MainFolderPath + SelectedNode.FullPath;
            string NodeDirectory = NodeFullPath;
            if ((SelectedNode.Text == "FolderSettings.json") || (!SelectedNode.Text.EndsWith(".json")))
            {
                if (SelectedNode.Text == "FolderSettings.json")
                {
                    NodeDirectory = Path.GetDirectoryName(NodeDirectory);
                    SelectedNode = SelectedNode.Parent;
                }

                bool FileCreated = false;
                int FileNumber = 1;
                while (!FileCreated)
                {
                    string AttemptedFilename = Path.Combine(NodeDirectory, Resources.NewTemplate + " " + FileNumber.ToString() + ".json");
                    if (!File.Exists(AttemptedFilename))
                    {
                        var NewTemplate = new
                        {
                            kCSTemplateRevision = "2",
                            Title = Resources.NewTemplate,
                            Description = "",
                            UsedTextures = Array.Empty<string>()
                        };

                        using (var SW = new StreamWriter(AttemptedFilename))
                        using (var Writer = new JsonTextWriter(SW))
                        {
                            Writer.Formatting = Formatting.Indented;
                            Writer.IndentChar = '\t';
                            Writer.Indentation = 1;

                            var Serializer = new JsonSerializer();
                            Serializer.Serialize(Writer, NewTemplate);
                        }

                        TreeNode NewTemplateNode = new TreeNode();
                        NewTemplateNode.Text = Resources.NewTemplate + " " + FileNumber.ToString() + ".json";
                        NewTemplateNode.ImageIndex = 2;
                        NewTemplateNode.SelectedImageIndex = 2;
                        SelectedNode.Nodes.Add(NewTemplateNode);
                        FileCreated = true;
                    }
                    else FileNumber++;
                }
            }
            else if (SelectedNode.Text.EndsWith(".json"))
            {
                DialogResult result = MessageBox.Show(
                    Resources.TemplateRemovalConfirm,
                    Resources.RemovalConfirmTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.Yes)
                {
                    File.Delete(NodeDirectory);
                    treeViewTemplateExplorer.SelectedNode.Remove();
                    ClearInputs();
                }
            }
        }

        private void buttonCreateFolderSettings_Click(object sender, EventArgs e)
        {
            TreeNode SelectedNode = treeViewTemplateExplorer.SelectedNode;
            string NodeFullPath = MainDefinitions.MainFolderPath + SelectedNode.FullPath;
            string NodeDirectory = NodeFullPath;
            TreeNode ParentNode = SelectedNode;

            if (SelectedNode.Text.EndsWith(".json"))
            {
                NodeDirectory = Path.GetDirectoryName(NodeDirectory);
                ParentNode = ParentNode.Parent;
            }

            if (File.Exists(Path.Combine(NodeDirectory, "FolderSettings.json")))
            {
                DialogResult result = MessageBox.Show(
                    Resources.FolderSettingsRemovalConfirm,
                    Resources.RemovalConfirmTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.Yes)
                {
                    File.Delete(Path.Combine(NodeDirectory, "FolderSettings.json"));
                    foreach (TreeNode node in ParentNode.Nodes)
                        if (node.Text == "FolderSettings.json")
                        {
                            node.Remove();
                            break;
                        }
                    ClearInputs();
                    buttonCreateFolderSettings.Text = Resources.buttonCreateFolderSettings;
                }
            }
            else
            {
                var NewFolderSettings = new
                {
                    kCSFolderRevision = "2",
                    Template = new {
                        Filename = "Insert Template Here",
                        CoverSubfolders = true
                    }
                };

                using (var SW = new StreamWriter(Path.Combine(NodeDirectory, "FolderSettings.json")))
                using (var Writer = new JsonTextWriter(SW))
                {
                    Writer.Formatting = Formatting.Indented;
                    Writer.IndentChar = '\t';
                    Writer.Indentation = 1;

                    var Serializer = new JsonSerializer();
                    Serializer.Serialize(Writer, NewFolderSettings);
                }

                TreeNode NewFolderSettingsNode = new TreeNode();
                NewFolderSettingsNode.Text = "FolderSettings.json";
                NewFolderSettingsNode.ImageIndex = 1;
                NewFolderSettingsNode.SelectedImageIndex = 1;
                ParentNode.Nodes.Add(NewFolderSettingsNode);
                buttonCreateFolderSettings.Text = Resources.buttonRemoveFolderSettings;
            }
        }

        private void buttonAddTexture_Click(object sender, EventArgs e)
        {
            kCSTemplateTexture Texture = new kCSTemplateTexture();
            Texture.Title = Resources.NewTexture;
            Texture.Display = true;
            Texture.AlternativeFilename = "";
            Texture.TexturePackFilename = "";
            Texture.RAM = "";
            Texture.RAMFormat = "RGBA16";

            ListViewItem item = new ListViewItem(Resources.NewTexture);
            item.ImageIndex = 3;
            item.Tag = Texture;
            listViewEditTemplate.Items.Add(item);
        }

        private void buttonRemoveTexture_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    Resources.TextureRemovalConfirm,
                    Resources.RemovalConfirmTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
            if (result == DialogResult.Yes &&
                listViewEditTemplate.SelectedItems.Count > 0)
            {
                listViewEditTemplate.SelectedItems[0].Remove();
                listViewEditTemplate.Items[0].Selected = true;
            }
        }

        #region text box text changed checked changed and shi

        private void textBoxTextureTitle_TextChanged(object sender, EventArgs e)
        {
            TreeNode SelectedNode = treeViewTemplateExplorer.SelectedNode;
            if (SelectedNode.Text != "FolderSettings.json" &&
                SelectedNode.Text.EndsWith(".json") &&
                listViewEditTemplate.SelectedItems.Count > 0)
            {
                listViewEditTemplate.SelectedItems[0].Text = textBoxTextureTitle.Text;
                ((kCSTemplateTexture)listViewEditTemplate.SelectedItems[0].Tag).Title =
                    textBoxTextureTitle.Text;
            }
        }

        private void checkTextureDisplay_CheckedChanged(object sender, EventArgs e)
        {
            TreeNode SelectedNode = treeViewTemplateExplorer.SelectedNode;
            if (SelectedNode.Text != "FolderSettings.json" &&
                SelectedNode.Text.EndsWith(".json") &&
                listViewEditTemplate.SelectedItems.Count > 0)
            {
                ((kCSTemplateTexture)listViewEditTemplate.SelectedItems[0].Tag).Display =
                    checkTextureDisplay.Checked;
            }
        }

        private void textBoxTexturePackFilename_TextChanged(object sender, EventArgs e)
        {
            TreeNode SelectedNode = treeViewTemplateExplorer.SelectedNode;
            if (SelectedNode.Text != "FolderSettings.json" &&
                SelectedNode.Text.EndsWith(".json") &&
                listViewEditTemplate.SelectedItems.Count > 0)
            {
                string text = textBoxTexturePackFilename.Text;
                ((kCSTemplateTexture)listViewEditTemplate.SelectedItems[0].Tag).TexturePackFilename =
                    text;

                int hashIndex = text.IndexOf('#');
                if (hashIndex < 0)
                    return;

                // Keep everything starting from #
                text = text.Substring(hashIndex);

                // Remove extension
                int dotIndex = text.LastIndexOf('.');
                if (dotIndex > -1)
                    text = text.Substring(0, dotIndex);

                // Avoid infinite loop
                if (textBoxTexturePackFilename.Text != text)
                {
                    textBoxTexturePackFilename.Text = text;
                    textBoxTexturePackFilename.SelectionStart = text.Length;
                }
            }
        }

        private void textBoxTextureAltFilename_TextChanged(object sender, EventArgs e)
        {
            TreeNode SelectedNode = treeViewTemplateExplorer.SelectedNode;
            if (SelectedNode.Text != "FolderSettings.json" &&
                SelectedNode.Text.EndsWith(".json") &&
                listViewEditTemplate.SelectedItems.Count > 0)
            {
                ((kCSTemplateTexture)listViewEditTemplate.SelectedItems[0].Tag).AlternativeFilename =
                    textBoxTextureAltFilename.Text;
            }
        }

        private void textBoxTextureSegAddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            TreeNode SelectedNode = treeViewTemplateExplorer.SelectedNode;
            if (SelectedNode.Text != "FolderSettings.json" &&
                SelectedNode.Text.EndsWith(".json") &&
                listViewEditTemplate.SelectedItems.Count > 0)
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void textBoxTextureSegAddr_TextChanged(object sender, EventArgs e)
        {
            TreeNode SelectedNode = treeViewTemplateExplorer.SelectedNode;
            if (SelectedNode.Text != "FolderSettings.json" &&
                SelectedNode.Text.EndsWith(".json") &&
                listViewEditTemplate.SelectedItems.Count > 0)
            {
                TextBox CurrentTextBox = (TextBox)sender;
                string Allowed = "0123456789ABCDEFabcdef";
                string Filtered = new string(CurrentTextBox.Text.Where(c => Allowed.Contains(c)).ToArray());

                if (CurrentTextBox.Text != Filtered)
                {
                    int Position = CurrentTextBox.SelectionStart;
                    CurrentTextBox.Text = Filtered;
                    CurrentTextBox.SelectionStart = Math.Min(Position, CurrentTextBox.Text.Length);
                }
                
                ((kCSTemplateTexture)listViewEditTemplate.SelectedItems[0].Tag).RAM = CurrentTextBox.Text;
            }
        }

        private void comboTextureFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode SelectedNode = treeViewTemplateExplorer.SelectedNode;
            if (SelectedNode.Text != "FolderSettings.json" &&
                SelectedNode.Text.EndsWith(".json") &&
                listViewEditTemplate.SelectedItems.Count > 0)
            {
                ((kCSTemplateTexture)listViewEditTemplate.SelectedItems[0].Tag).RAMFormat = comboTextureFormat.Text;
            }
        }

        #endregion

        private void buttonSave_Click(object sender, EventArgs e)
        {
            TreeNode SelectedNode = treeViewTemplateExplorer.SelectedNode;
            if (SelectedNode.Text == "FolderSettings.json")
            {
                string NodeFullPath = MainDefinitions.MainFolderPath + SelectedNode.FullPath;

                var NewFolderSettings = new
                {
                    kCSFolderRevision = "2",
                    Template = new
                    {
                        Filename = comboFolderSettingsTemplateUsed.Text,
                        CoverSubfolders = checkFolderSettingsCoverSubfolders.Checked
                    }
                };

                using (var SW = new StreamWriter(NodeFullPath))
                using (var Writer = new JsonTextWriter(SW))
                {
                    Writer.Formatting = Formatting.Indented;
                    Writer.IndentChar = '\t';
                    Writer.Indentation = 1;

                    var Serializer = new JsonSerializer();
                    Serializer.Serialize(Writer, NewFolderSettings);
                }
            }
            else if (SelectedNode.Text.EndsWith(".json"))
            {
                string NodeFullPath = MainDefinitions.MainFolderPath + SelectedNode.FullPath;
                string NodeDirectory = Path.GetDirectoryName(NodeFullPath);

                List<kCSTemplateTexture> Textures = new List<kCSTemplateTexture>();
                foreach (ListViewItem item in listViewEditTemplate.Items)
                {
                    ListViewItem AddedItem = item;
                    string RAM = ((kCSTemplateTexture)item.Tag).RAM;
                    if (RAM != "")
                        ((kCSTemplateTexture)item.Tag).RAM = RAM.PadLeft(8, '0').ToUpper();
                    Textures.Add((kCSTemplateTexture)AddedItem.Tag);
                }

                string AttemptedFilename = Path.Combine(NodeDirectory, textBoxTemplateFilename.Text) + ".json";
                if (File.Exists(AttemptedFilename) &&
                    !String.Equals(NodeFullPath, AttemptedFilename, StringComparison.OrdinalIgnoreCase))
                {
                    DialogResult result =
                        MessageBox.Show(
                            Resources.TemplateFilenameAlreadyExistsError,
                            Resources.Error_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                }
                else
                {
                    var NewTemplate = new
                    {
                        kCSTemplateRevision = "2",
                        Title = textBoxTemplateTitle.Text,
                        Description = textBoxTemplateDesc.Text,
                        UsedTextures = Textures
                    };

                    using (var SW = new StreamWriter(AttemptedFilename))
                    using (var Writer = new JsonTextWriter(SW))
                    {
                        Writer.Formatting = Formatting.Indented;
                        Writer.IndentChar = '\t';
                        Writer.Indentation = 1;

                        var Serializer = new JsonSerializer();
                        Serializer.Serialize(Writer, NewTemplate);
                    }

                    if (!String.Equals(NodeFullPath, AttemptedFilename, StringComparison.Ordinal))
                        File.Delete(NodeFullPath);
                    SelectedNode.Text = textBoxTemplateFilename.Text + ".json";
                }
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            if (OpenedPath != null)
                SelectInitialNode();
        }

        private void SelectInitialNode()
        {
            TreeNode node = FindNodeByTag(OpenedPath);
            treeViewTemplateExplorer.SelectedNode = node;
            node.EnsureVisible();
        }

        TreeNode FindNodeByTag(string value)
        {
            foreach (TreeNode node in treeViewTemplateExplorer.Nodes)
            {
                TreeNode found = FindNodeByTagRecursive(node, value);
                if (found != null)
                    return found;
            }
            return null;
        }

        TreeNode FindNodeByTagRecursive(TreeNode node, string value)
        {
            if (node.Tag?.ToString() == value)
                return node;

            foreach (TreeNode child in node.Nodes)
            {
                TreeNode found = FindNodeByTagRecursive(child, value);
                if (found != null)
                    return found;
            }

            return null;
        }
    }
}
