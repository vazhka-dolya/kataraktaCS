namespace kataraktaCS
{
    partial class frmTemplateManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemplateManager));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewTemplateExplorer = new kataraktaCS.Controls.kataraktaTreeViewLessFancy.kataraktaTreeViewLessFancy();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listViewEditTemplate = new kataraktaCS.Controls.kataraktaListView.kataraktaListView();
            this.labelTemplateTitle = new System.Windows.Forms.Label();
            this.groupTemplateMain = new System.Windows.Forms.GroupBox();
            this.textBoxTemplateFilename = new System.Windows.Forms.TextBox();
            this.labelTemplateFilename = new System.Windows.Forms.Label();
            this.textBoxTemplateDesc = new System.Windows.Forms.TextBox();
            this.labelTemplateDesc = new System.Windows.Forms.Label();
            this.textBoxTemplateTitle = new System.Windows.Forms.TextBox();
            this.groupTemplateItems = new System.Windows.Forms.GroupBox();
            this.textBoxTextureSegAddr = new System.Windows.Forms.TextBox();
            this.labelTextureSegAddr = new System.Windows.Forms.Label();
            this.comboTextureFormat = new System.Windows.Forms.ComboBox();
            this.textBoxTextureAltFilename = new System.Windows.Forms.TextBox();
            this.labelTextureFormat = new System.Windows.Forms.Label();
            this.labelTextureAltFilename = new System.Windows.Forms.Label();
            this.checkTextureDisplay = new System.Windows.Forms.CheckBox();
            this.textBoxTexturePackFilename = new System.Windows.Forms.TextBox();
            this.labelTexturePackFilename = new System.Windows.Forms.Label();
            this.textBoxTextureTitle = new System.Windows.Forms.TextBox();
            this.labelTextureTitle = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelFolderSettingsTemplateUsed = new System.Windows.Forms.Label();
            this.checkFolderSettingsCoverSubfolders = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonAddTexture = new System.Windows.Forms.Button();
            this.buttonRemoveTexture = new System.Windows.Forms.Button();
            this.buttonCreateFolderSettings = new System.Windows.Forms.Button();
            this.buttonCreateTemplate = new System.Windows.Forms.Button();
            this.groupFolderSettings = new System.Windows.Forms.GroupBox();
            this.comboFolderSettingsTemplateUsed = new System.Windows.Forms.ComboBox();
            this.labelSelectSomething = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupTemplateMain.SuspendLayout();
            this.groupTemplateItems.SuspendLayout();
            this.groupFolderSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewTemplateExplorer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewEditTemplate);
            // 
            // treeViewTemplateExplorer
            // 
            this.treeViewTemplateExplorer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.treeViewTemplateExplorer, "treeViewTemplateExplorer");
            this.treeViewTemplateExplorer.FullRowSelect = true;
            this.treeViewTemplateExplorer.HideSelection = false;
            this.treeViewTemplateExplorer.HotTracking = true;
            this.treeViewTemplateExplorer.ImageList = this.imageList1;
            this.treeViewTemplateExplorer.ItemHeight = 16;
            this.treeViewTemplateExplorer.Name = "treeViewTemplateExplorer";
            this.treeViewTemplateExplorer.ShowLines = false;
            this.treeViewTemplateExplorer.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewTemplateExplorer_BeforeSelect);
            this.treeViewTemplateExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTemplateExplorer_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "folder_settings.png");
            this.imageList1.Images.SetKeyName(2, "template.png");
            this.imageList1.Images.SetKeyName(3, "texture.png");
            // 
            // listViewEditTemplate
            // 
            this.listViewEditTemplate.AllowDrop = true;
            resources.ApplyResources(this.listViewEditTemplate, "listViewEditTemplate");
            this.listViewEditTemplate.HideSelection = false;
            this.listViewEditTemplate.LargeImageList = this.imageList1;
            this.listViewEditTemplate.MultiSelect = false;
            this.listViewEditTemplate.Name = "listViewEditTemplate";
            this.listViewEditTemplate.SmallImageList = this.imageList1;
            this.listViewEditTemplate.UseCompatibleStateImageBehavior = false;
            this.listViewEditTemplate.View = System.Windows.Forms.View.List;
            this.listViewEditTemplate.SelectedIndexChanged += new System.EventHandler(this.listViewEditTemplate_SelectedIndexChanged);
            // 
            // labelTemplateTitle
            // 
            resources.ApplyResources(this.labelTemplateTitle, "labelTemplateTitle");
            this.labelTemplateTitle.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelTemplateTitle.Name = "labelTemplateTitle";
            this.toolTip1.SetToolTip(this.labelTemplateTitle, resources.GetString("labelTemplateTitle.ToolTip"));
            // 
            // groupTemplateMain
            // 
            this.groupTemplateMain.Controls.Add(this.textBoxTemplateFilename);
            this.groupTemplateMain.Controls.Add(this.labelTemplateFilename);
            this.groupTemplateMain.Controls.Add(this.textBoxTemplateDesc);
            this.groupTemplateMain.Controls.Add(this.labelTemplateDesc);
            this.groupTemplateMain.Controls.Add(this.textBoxTemplateTitle);
            this.groupTemplateMain.Controls.Add(this.labelTemplateTitle);
            resources.ApplyResources(this.groupTemplateMain, "groupTemplateMain");
            this.groupTemplateMain.Name = "groupTemplateMain";
            this.groupTemplateMain.TabStop = false;
            // 
            // textBoxTemplateFilename
            // 
            resources.ApplyResources(this.textBoxTemplateFilename, "textBoxTemplateFilename");
            this.textBoxTemplateFilename.Name = "textBoxTemplateFilename";
            // 
            // labelTemplateFilename
            // 
            resources.ApplyResources(this.labelTemplateFilename, "labelTemplateFilename");
            this.labelTemplateFilename.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelTemplateFilename.Name = "labelTemplateFilename";
            this.toolTip1.SetToolTip(this.labelTemplateFilename, resources.GetString("labelTemplateFilename.ToolTip"));
            // 
            // textBoxTemplateDesc
            // 
            resources.ApplyResources(this.textBoxTemplateDesc, "textBoxTemplateDesc");
            this.textBoxTemplateDesc.Name = "textBoxTemplateDesc";
            // 
            // labelTemplateDesc
            // 
            resources.ApplyResources(this.labelTemplateDesc, "labelTemplateDesc");
            this.labelTemplateDesc.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelTemplateDesc.Name = "labelTemplateDesc";
            this.toolTip1.SetToolTip(this.labelTemplateDesc, resources.GetString("labelTemplateDesc.ToolTip"));
            // 
            // textBoxTemplateTitle
            // 
            resources.ApplyResources(this.textBoxTemplateTitle, "textBoxTemplateTitle");
            this.textBoxTemplateTitle.Name = "textBoxTemplateTitle";
            // 
            // groupTemplateItems
            // 
            this.groupTemplateItems.Controls.Add(this.textBoxTextureSegAddr);
            this.groupTemplateItems.Controls.Add(this.labelTextureSegAddr);
            this.groupTemplateItems.Controls.Add(this.comboTextureFormat);
            this.groupTemplateItems.Controls.Add(this.textBoxTextureAltFilename);
            this.groupTemplateItems.Controls.Add(this.labelTextureFormat);
            this.groupTemplateItems.Controls.Add(this.labelTextureAltFilename);
            this.groupTemplateItems.Controls.Add(this.checkTextureDisplay);
            this.groupTemplateItems.Controls.Add(this.textBoxTexturePackFilename);
            this.groupTemplateItems.Controls.Add(this.labelTexturePackFilename);
            this.groupTemplateItems.Controls.Add(this.textBoxTextureTitle);
            this.groupTemplateItems.Controls.Add(this.labelTextureTitle);
            resources.ApplyResources(this.groupTemplateItems, "groupTemplateItems");
            this.groupTemplateItems.Name = "groupTemplateItems";
            this.groupTemplateItems.TabStop = false;
            // 
            // textBoxTextureSegAddr
            // 
            resources.ApplyResources(this.textBoxTextureSegAddr, "textBoxTextureSegAddr");
            this.textBoxTextureSegAddr.Name = "textBoxTextureSegAddr";
            this.textBoxTextureSegAddr.TextChanged += new System.EventHandler(this.textBoxTextureSegAddr_TextChanged);
            // 
            // labelTextureSegAddr
            // 
            resources.ApplyResources(this.labelTextureSegAddr, "labelTextureSegAddr");
            this.labelTextureSegAddr.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelTextureSegAddr.Name = "labelTextureSegAddr";
            this.toolTip1.SetToolTip(this.labelTextureSegAddr, resources.GetString("labelTextureSegAddr.ToolTip"));
            // 
            // comboTextureFormat
            // 
            this.comboTextureFormat.FormattingEnabled = true;
            this.comboTextureFormat.Items.AddRange(new object[] {
            resources.GetString("comboTextureFormat.Items"),
            resources.GetString("comboTextureFormat.Items1"),
            resources.GetString("comboTextureFormat.Items2"),
            resources.GetString("comboTextureFormat.Items3"),
            resources.GetString("comboTextureFormat.Items4"),
            resources.GetString("comboTextureFormat.Items5"),
            resources.GetString("comboTextureFormat.Items6")});
            resources.ApplyResources(this.comboTextureFormat, "comboTextureFormat");
            this.comboTextureFormat.Name = "comboTextureFormat";
            this.comboTextureFormat.SelectedIndexChanged += new System.EventHandler(this.comboTextureFormat_SelectedIndexChanged);
            // 
            // textBoxTextureAltFilename
            // 
            resources.ApplyResources(this.textBoxTextureAltFilename, "textBoxTextureAltFilename");
            this.textBoxTextureAltFilename.Name = "textBoxTextureAltFilename";
            this.textBoxTextureAltFilename.TextChanged += new System.EventHandler(this.textBoxTextureAltFilename_TextChanged);
            // 
            // labelTextureFormat
            // 
            resources.ApplyResources(this.labelTextureFormat, "labelTextureFormat");
            this.labelTextureFormat.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelTextureFormat.Name = "labelTextureFormat";
            this.toolTip1.SetToolTip(this.labelTextureFormat, resources.GetString("labelTextureFormat.ToolTip"));
            // 
            // labelTextureAltFilename
            // 
            resources.ApplyResources(this.labelTextureAltFilename, "labelTextureAltFilename");
            this.labelTextureAltFilename.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelTextureAltFilename.Name = "labelTextureAltFilename";
            this.toolTip1.SetToolTip(this.labelTextureAltFilename, resources.GetString("labelTextureAltFilename.ToolTip"));
            // 
            // checkTextureDisplay
            // 
            resources.ApplyResources(this.checkTextureDisplay, "checkTextureDisplay");
            this.checkTextureDisplay.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkTextureDisplay.Name = "checkTextureDisplay";
            this.toolTip1.SetToolTip(this.checkTextureDisplay, resources.GetString("checkTextureDisplay.ToolTip"));
            this.checkTextureDisplay.UseVisualStyleBackColor = true;
            this.checkTextureDisplay.CheckedChanged += new System.EventHandler(this.checkTextureDisplay_CheckedChanged);
            // 
            // textBoxTexturePackFilename
            // 
            resources.ApplyResources(this.textBoxTexturePackFilename, "textBoxTexturePackFilename");
            this.textBoxTexturePackFilename.Name = "textBoxTexturePackFilename";
            this.textBoxTexturePackFilename.TextChanged += new System.EventHandler(this.textBoxTexturePackFilename_TextChanged);
            // 
            // labelTexturePackFilename
            // 
            resources.ApplyResources(this.labelTexturePackFilename, "labelTexturePackFilename");
            this.labelTexturePackFilename.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelTexturePackFilename.Name = "labelTexturePackFilename";
            this.toolTip1.SetToolTip(this.labelTexturePackFilename, resources.GetString("labelTexturePackFilename.ToolTip"));
            // 
            // textBoxTextureTitle
            // 
            resources.ApplyResources(this.textBoxTextureTitle, "textBoxTextureTitle");
            this.textBoxTextureTitle.Name = "textBoxTextureTitle";
            this.textBoxTextureTitle.TextChanged += new System.EventHandler(this.textBoxTextureTitle_TextChanged);
            // 
            // labelTextureTitle
            // 
            resources.ApplyResources(this.labelTextureTitle, "labelTextureTitle");
            this.labelTextureTitle.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelTextureTitle.Name = "labelTextureTitle";
            this.toolTip1.SetToolTip(this.labelTextureTitle, resources.GetString("labelTextureTitle.ToolTip"));
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 32767;
            this.toolTip1.InitialDelay = 300;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipTitle = "Объяснение";
            // 
            // labelFolderSettingsTemplateUsed
            // 
            resources.ApplyResources(this.labelFolderSettingsTemplateUsed, "labelFolderSettingsTemplateUsed");
            this.labelFolderSettingsTemplateUsed.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelFolderSettingsTemplateUsed.Name = "labelFolderSettingsTemplateUsed";
            this.toolTip1.SetToolTip(this.labelFolderSettingsTemplateUsed, resources.GetString("labelFolderSettingsTemplateUsed.ToolTip"));
            // 
            // checkFolderSettingsCoverSubfolders
            // 
            resources.ApplyResources(this.checkFolderSettingsCoverSubfolders, "checkFolderSettingsCoverSubfolders");
            this.checkFolderSettingsCoverSubfolders.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkFolderSettingsCoverSubfolders.Name = "checkFolderSettingsCoverSubfolders";
            this.toolTip1.SetToolTip(this.checkFolderSettingsCoverSubfolders, resources.GetString("checkFolderSettingsCoverSubfolders.ToolTip"));
            this.checkFolderSettingsCoverSubfolders.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonAddTexture
            // 
            resources.ApplyResources(this.buttonAddTexture, "buttonAddTexture");
            this.buttonAddTexture.Name = "buttonAddTexture";
            this.buttonAddTexture.UseVisualStyleBackColor = true;
            this.buttonAddTexture.Click += new System.EventHandler(this.buttonAddTexture_Click);
            // 
            // buttonRemoveTexture
            // 
            resources.ApplyResources(this.buttonRemoveTexture, "buttonRemoveTexture");
            this.buttonRemoveTexture.Name = "buttonRemoveTexture";
            this.buttonRemoveTexture.UseVisualStyleBackColor = true;
            this.buttonRemoveTexture.Click += new System.EventHandler(this.buttonRemoveTexture_Click);
            // 
            // buttonCreateFolderSettings
            // 
            resources.ApplyResources(this.buttonCreateFolderSettings, "buttonCreateFolderSettings");
            this.buttonCreateFolderSettings.Name = "buttonCreateFolderSettings";
            this.buttonCreateFolderSettings.UseVisualStyleBackColor = true;
            this.buttonCreateFolderSettings.Click += new System.EventHandler(this.buttonCreateFolderSettings_Click);
            // 
            // buttonCreateTemplate
            // 
            resources.ApplyResources(this.buttonCreateTemplate, "buttonCreateTemplate");
            this.buttonCreateTemplate.Name = "buttonCreateTemplate";
            this.buttonCreateTemplate.UseVisualStyleBackColor = true;
            this.buttonCreateTemplate.Click += new System.EventHandler(this.buttonCreateTemplate_Click);
            // 
            // groupFolderSettings
            // 
            this.groupFolderSettings.Controls.Add(this.comboFolderSettingsTemplateUsed);
            this.groupFolderSettings.Controls.Add(this.checkFolderSettingsCoverSubfolders);
            this.groupFolderSettings.Controls.Add(this.labelFolderSettingsTemplateUsed);
            resources.ApplyResources(this.groupFolderSettings, "groupFolderSettings");
            this.groupFolderSettings.Name = "groupFolderSettings";
            this.groupFolderSettings.TabStop = false;
            // 
            // comboFolderSettingsTemplateUsed
            // 
            this.comboFolderSettingsTemplateUsed.FormattingEnabled = true;
            resources.ApplyResources(this.comboFolderSettingsTemplateUsed, "comboFolderSettingsTemplateUsed");
            this.comboFolderSettingsTemplateUsed.Name = "comboFolderSettingsTemplateUsed";
            // 
            // labelSelectSomething
            // 
            resources.ApplyResources(this.labelSelectSomething, "labelSelectSomething");
            this.labelSelectSomething.Name = "labelSelectSomething";
            // 
            // frmTemplateManager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSelectSomething);
            this.Controls.Add(this.groupFolderSettings);
            this.Controls.Add(this.buttonCreateTemplate);
            this.Controls.Add(this.buttonCreateFolderSettings);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonRemoveTexture);
            this.Controls.Add(this.buttonAddTexture);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupTemplateItems);
            this.Controls.Add(this.groupTemplateMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTemplateManager";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupTemplateMain.ResumeLayout(false);
            this.groupTemplateMain.PerformLayout();
            this.groupTemplateItems.ResumeLayout(false);
            this.groupTemplateItems.PerformLayout();
            this.groupFolderSettings.ResumeLayout(false);
            this.groupFolderSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.kataraktaListView.kataraktaListView listViewEditTemplate;
        private System.Windows.Forms.Label labelTemplateTitle;
        private System.Windows.Forms.GroupBox groupTemplateMain;
        private System.Windows.Forms.TextBox textBoxTemplateTitle;
        private System.Windows.Forms.TextBox textBoxTemplateDesc;
        private System.Windows.Forms.Label labelTemplateDesc;
        private System.Windows.Forms.GroupBox groupTemplateItems;
        private System.Windows.Forms.TextBox textBoxTextureTitle;
        private System.Windows.Forms.Label labelTextureTitle;
        private System.Windows.Forms.CheckBox checkTextureDisplay;
        private System.Windows.Forms.TextBox textBoxTexturePackFilename;
        private System.Windows.Forms.Label labelTexturePackFilename;
        private System.Windows.Forms.TextBox textBoxTextureAltFilename;
        private System.Windows.Forms.Label labelTextureAltFilename;
        private System.Windows.Forms.Label labelTextureSegAddr;
        private System.Windows.Forms.ComboBox comboTextureFormat;
        private System.Windows.Forms.Label labelTextureFormat;
        private System.Windows.Forms.TextBox textBoxTextureSegAddr;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonAddTexture;
        private System.Windows.Forms.Button buttonRemoveTexture;
        private System.Windows.Forms.ImageList imageList1;
        private Controls.kataraktaTreeViewLessFancy.kataraktaTreeViewLessFancy treeViewTemplateExplorer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonCreateFolderSettings;
        private System.Windows.Forms.Button buttonCreateTemplate;
        private System.Windows.Forms.TextBox textBoxTemplateFilename;
        private System.Windows.Forms.Label labelTemplateFilename;
        private System.Windows.Forms.GroupBox groupFolderSettings;
        private System.Windows.Forms.CheckBox checkFolderSettingsCoverSubfolders;
        private System.Windows.Forms.Label labelFolderSettingsTemplateUsed;
        private System.Windows.Forms.ComboBox comboFolderSettingsTemplateUsed;
        private System.Windows.Forms.Label labelSelectSomething;
    }
}