namespace kataraktaCS
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonApplyAndClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkTreeViewSimplified = new System.Windows.Forms.CheckBox();
            this.checkTreeViewDisplayIcons = new System.Windows.Forms.CheckBox();
            this.checkTreeViewDisplayCache = new System.Windows.Forms.CheckBox();
            this.checkDisplayCacheOnRight = new System.Windows.Forms.CheckBox();
            this.labelHiResPath = new System.Windows.Forms.Label();
            this.labelOtherGames = new System.Windows.Forms.Label();
            this.labelTexturePackMainGame = new System.Windows.Forms.Label();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.groupTexturePack = new System.Windows.Forms.GroupBox();
            this.buttonAddGame = new System.Windows.Forms.Button();
            this.buttonRemoveSelected = new System.Windows.Forms.Button();
            this.listViewOtherGames = new kataraktaCS.Controls.kataraktaListView.kataraktaListView();
            this.buttonHiResPath = new System.Windows.Forms.Button();
            this.textBoxTexturePackHiResPath = new System.Windows.Forms.TextBox();
            this.textBoxTexturePackMainGame = new System.Windows.Forms.TextBox();
            this.groupMisc = new System.Windows.Forms.GroupBox();
            this.groupBackgroundColor = new System.Windows.Forms.GroupBox();
            this.buttonResetBackgroundColor = new System.Windows.Forms.Button();
            this.buttonBackgroundColor = new System.Windows.Forms.Button();
            this.checkStayOnTop = new System.Windows.Forms.CheckBox();
            this.groupTreeView = new System.Windows.Forms.GroupBox();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabGeneral.SuspendLayout();
            this.groupTexturePack.SuspendLayout();
            this.groupMisc.SuspendLayout();
            this.groupBackgroundColor.SuspendLayout();
            this.groupTreeView.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.toolTip1.SetToolTip(this.buttonClose, resources.GetString("buttonClose.ToolTip"));
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonApply
            // 
            resources.ApplyResources(this.buttonApply, "buttonApply");
            this.buttonApply.Name = "buttonApply";
            this.toolTip1.SetToolTip(this.buttonApply, resources.GetString("buttonApply.ToolTip"));
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonApplyAndClose
            // 
            resources.ApplyResources(this.buttonApplyAndClose, "buttonApplyAndClose");
            this.buttonApplyAndClose.Name = "buttonApplyAndClose";
            this.toolTip1.SetToolTip(this.buttonApplyAndClose, resources.GetString("buttonApplyAndClose.ToolTip"));
            this.buttonApplyAndClose.UseVisualStyleBackColor = true;
            this.buttonApplyAndClose.Click += new System.EventHandler(this.buttonApplyAndClose_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 32767;
            this.toolTip1.InitialDelay = 300;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipTitle = "Объяснение";
            // 
            // checkTreeViewSimplified
            // 
            resources.ApplyResources(this.checkTreeViewSimplified, "checkTreeViewSimplified");
            this.checkTreeViewSimplified.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkTreeViewSimplified.Name = "checkTreeViewSimplified";
            this.toolTip1.SetToolTip(this.checkTreeViewSimplified, resources.GetString("checkTreeViewSimplified.ToolTip"));
            this.checkTreeViewSimplified.UseVisualStyleBackColor = true;
            // 
            // checkTreeViewDisplayIcons
            // 
            resources.ApplyResources(this.checkTreeViewDisplayIcons, "checkTreeViewDisplayIcons");
            this.checkTreeViewDisplayIcons.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkTreeViewDisplayIcons.Name = "checkTreeViewDisplayIcons";
            this.toolTip1.SetToolTip(this.checkTreeViewDisplayIcons, resources.GetString("checkTreeViewDisplayIcons.ToolTip"));
            this.checkTreeViewDisplayIcons.UseVisualStyleBackColor = true;
            // 
            // checkTreeViewDisplayCache
            // 
            resources.ApplyResources(this.checkTreeViewDisplayCache, "checkTreeViewDisplayCache");
            this.checkTreeViewDisplayCache.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkTreeViewDisplayCache.Name = "checkTreeViewDisplayCache";
            this.toolTip1.SetToolTip(this.checkTreeViewDisplayCache, resources.GetString("checkTreeViewDisplayCache.ToolTip"));
            this.checkTreeViewDisplayCache.UseVisualStyleBackColor = true;
            // 
            // checkDisplayCacheOnRight
            // 
            resources.ApplyResources(this.checkDisplayCacheOnRight, "checkDisplayCacheOnRight");
            this.checkDisplayCacheOnRight.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkDisplayCacheOnRight.Name = "checkDisplayCacheOnRight";
            this.toolTip1.SetToolTip(this.checkDisplayCacheOnRight, resources.GetString("checkDisplayCacheOnRight.ToolTip"));
            this.checkDisplayCacheOnRight.UseVisualStyleBackColor = true;
            // 
            // labelHiResPath
            // 
            resources.ApplyResources(this.labelHiResPath, "labelHiResPath");
            this.labelHiResPath.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelHiResPath.Name = "labelHiResPath";
            this.toolTip1.SetToolTip(this.labelHiResPath, resources.GetString("labelHiResPath.ToolTip"));
            // 
            // labelOtherGames
            // 
            resources.ApplyResources(this.labelOtherGames, "labelOtherGames");
            this.labelOtherGames.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelOtherGames.Name = "labelOtherGames";
            this.toolTip1.SetToolTip(this.labelOtherGames, resources.GetString("labelOtherGames.ToolTip"));
            // 
            // labelTexturePackMainGame
            // 
            resources.ApplyResources(this.labelTexturePackMainGame, "labelTexturePackMainGame");
            this.labelTexturePackMainGame.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelTexturePackMainGame.Name = "labelTexturePackMainGame";
            this.toolTip1.SetToolTip(this.labelTexturePackMainGame, resources.GetString("labelTexturePackMainGame.ToolTip"));
            // 
            // tabGeneral
            // 
            resources.ApplyResources(this.tabGeneral, "tabGeneral");
            this.tabGeneral.Controls.Add(this.groupTexturePack);
            this.tabGeneral.Controls.Add(this.groupMisc);
            this.tabGeneral.Controls.Add(this.groupTreeView);
            this.tabGeneral.Name = "tabGeneral";
            this.toolTip1.SetToolTip(this.tabGeneral, resources.GetString("tabGeneral.ToolTip"));
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupTexturePack
            // 
            resources.ApplyResources(this.groupTexturePack, "groupTexturePack");
            this.groupTexturePack.Controls.Add(this.buttonAddGame);
            this.groupTexturePack.Controls.Add(this.buttonRemoveSelected);
            this.groupTexturePack.Controls.Add(this.listViewOtherGames);
            this.groupTexturePack.Controls.Add(this.buttonHiResPath);
            this.groupTexturePack.Controls.Add(this.textBoxTexturePackHiResPath);
            this.groupTexturePack.Controls.Add(this.labelHiResPath);
            this.groupTexturePack.Controls.Add(this.labelOtherGames);
            this.groupTexturePack.Controls.Add(this.textBoxTexturePackMainGame);
            this.groupTexturePack.Controls.Add(this.labelTexturePackMainGame);
            this.groupTexturePack.Name = "groupTexturePack";
            this.groupTexturePack.TabStop = false;
            this.toolTip1.SetToolTip(this.groupTexturePack, resources.GetString("groupTexturePack.ToolTip"));
            // 
            // buttonAddGame
            // 
            resources.ApplyResources(this.buttonAddGame, "buttonAddGame");
            this.buttonAddGame.Name = "buttonAddGame";
            this.toolTip1.SetToolTip(this.buttonAddGame, resources.GetString("buttonAddGame.ToolTip"));
            this.buttonAddGame.UseVisualStyleBackColor = true;
            this.buttonAddGame.Click += new System.EventHandler(this.buttonAddGame_Click);
            // 
            // buttonRemoveSelected
            // 
            resources.ApplyResources(this.buttonRemoveSelected, "buttonRemoveSelected");
            this.buttonRemoveSelected.Name = "buttonRemoveSelected";
            this.toolTip1.SetToolTip(this.buttonRemoveSelected, resources.GetString("buttonRemoveSelected.ToolTip"));
            this.buttonRemoveSelected.UseVisualStyleBackColor = true;
            this.buttonRemoveSelected.Click += new System.EventHandler(this.buttonRemoveSelected_Click);
            // 
            // listViewOtherGames
            // 
            resources.ApplyResources(this.listViewOtherGames, "listViewOtherGames");
            this.listViewOtherGames.AllowDrop = true;
            this.listViewOtherGames.HideSelection = false;
            this.listViewOtherGames.LabelEdit = true;
            this.listViewOtherGames.Name = "listViewOtherGames";
            this.toolTip1.SetToolTip(this.listViewOtherGames, resources.GetString("listViewOtherGames.ToolTip"));
            this.listViewOtherGames.UseCompatibleStateImageBehavior = false;
            this.listViewOtherGames.View = System.Windows.Forms.View.List;
            // 
            // buttonHiResPath
            // 
            resources.ApplyResources(this.buttonHiResPath, "buttonHiResPath");
            this.buttonHiResPath.Name = "buttonHiResPath";
            this.toolTip1.SetToolTip(this.buttonHiResPath, resources.GetString("buttonHiResPath.ToolTip"));
            this.buttonHiResPath.UseVisualStyleBackColor = true;
            this.buttonHiResPath.Click += new System.EventHandler(this.buttonHiresPath_Click);
            // 
            // textBoxTexturePackHiResPath
            // 
            resources.ApplyResources(this.textBoxTexturePackHiResPath, "textBoxTexturePackHiResPath");
            this.textBoxTexturePackHiResPath.Name = "textBoxTexturePackHiResPath";
            this.toolTip1.SetToolTip(this.textBoxTexturePackHiResPath, resources.GetString("textBoxTexturePackHiResPath.ToolTip"));
            // 
            // textBoxTexturePackMainGame
            // 
            resources.ApplyResources(this.textBoxTexturePackMainGame, "textBoxTexturePackMainGame");
            this.textBoxTexturePackMainGame.Name = "textBoxTexturePackMainGame";
            this.toolTip1.SetToolTip(this.textBoxTexturePackMainGame, resources.GetString("textBoxTexturePackMainGame.ToolTip"));
            // 
            // groupMisc
            // 
            resources.ApplyResources(this.groupMisc, "groupMisc");
            this.groupMisc.Controls.Add(this.groupBackgroundColor);
            this.groupMisc.Controls.Add(this.checkStayOnTop);
            this.groupMisc.Name = "groupMisc";
            this.groupMisc.TabStop = false;
            this.toolTip1.SetToolTip(this.groupMisc, resources.GetString("groupMisc.ToolTip"));
            // 
            // groupBackgroundColor
            // 
            resources.ApplyResources(this.groupBackgroundColor, "groupBackgroundColor");
            this.groupBackgroundColor.Controls.Add(this.buttonResetBackgroundColor);
            this.groupBackgroundColor.Controls.Add(this.buttonBackgroundColor);
            this.groupBackgroundColor.Name = "groupBackgroundColor";
            this.groupBackgroundColor.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBackgroundColor, resources.GetString("groupBackgroundColor.ToolTip"));
            // 
            // buttonResetBackgroundColor
            // 
            resources.ApplyResources(this.buttonResetBackgroundColor, "buttonResetBackgroundColor");
            this.buttonResetBackgroundColor.Name = "buttonResetBackgroundColor";
            this.toolTip1.SetToolTip(this.buttonResetBackgroundColor, resources.GetString("buttonResetBackgroundColor.ToolTip"));
            this.buttonResetBackgroundColor.UseVisualStyleBackColor = true;
            this.buttonResetBackgroundColor.Click += new System.EventHandler(this.buttonResetBackgroundColor_Click);
            // 
            // buttonBackgroundColor
            // 
            resources.ApplyResources(this.buttonBackgroundColor, "buttonBackgroundColor");
            this.buttonBackgroundColor.BackColor = System.Drawing.Color.Transparent;
            this.buttonBackgroundColor.Name = "buttonBackgroundColor";
            this.toolTip1.SetToolTip(this.buttonBackgroundColor, resources.GetString("buttonBackgroundColor.ToolTip"));
            this.buttonBackgroundColor.UseVisualStyleBackColor = false;
            this.buttonBackgroundColor.Click += new System.EventHandler(this.buttonBackgroundColor_Click);
            // 
            // checkStayOnTop
            // 
            resources.ApplyResources(this.checkStayOnTop, "checkStayOnTop");
            this.checkStayOnTop.Name = "checkStayOnTop";
            this.toolTip1.SetToolTip(this.checkStayOnTop, resources.GetString("checkStayOnTop.ToolTip"));
            this.checkStayOnTop.UseVisualStyleBackColor = true;
            // 
            // groupTreeView
            // 
            resources.ApplyResources(this.groupTreeView, "groupTreeView");
            this.groupTreeView.Controls.Add(this.checkDisplayCacheOnRight);
            this.groupTreeView.Controls.Add(this.checkTreeViewDisplayCache);
            this.groupTreeView.Controls.Add(this.checkTreeViewDisplayIcons);
            this.groupTreeView.Controls.Add(this.checkTreeViewSimplified);
            this.groupTreeView.Name = "groupTreeView";
            this.groupTreeView.TabStop = false;
            this.toolTip1.SetToolTip(this.groupTreeView, resources.GetString("groupTreeView.ToolTip"));
            // 
            // tabSettings
            // 
            resources.ApplyResources(this.tabSettings, "tabSettings");
            this.tabSettings.Controls.Add(this.tabGeneral);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.toolTip1.SetToolTip(this.tabSettings, resources.GetString("tabSettings.ToolTip"));
            // 
            // frmSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonApplyAndClose);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSettings";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.tabGeneral.ResumeLayout(false);
            this.groupTexturePack.ResumeLayout(false);
            this.groupTexturePack.PerformLayout();
            this.groupMisc.ResumeLayout(false);
            this.groupMisc.PerformLayout();
            this.groupBackgroundColor.ResumeLayout(false);
            this.groupTreeView.ResumeLayout(false);
            this.groupTreeView.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonApplyAndClose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupTreeView;
        private System.Windows.Forms.CheckBox checkDisplayCacheOnRight;
        private System.Windows.Forms.CheckBox checkTreeViewDisplayCache;
        private System.Windows.Forms.CheckBox checkTreeViewDisplayIcons;
        private System.Windows.Forms.CheckBox checkTreeViewSimplified;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.GroupBox groupBackgroundColor;
        private System.Windows.Forms.Button buttonBackgroundColor;
        private System.Windows.Forms.Button buttonResetBackgroundColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupMisc;
        private System.Windows.Forms.CheckBox checkStayOnTop;
        private System.Windows.Forms.GroupBox groupTexturePack;
        private System.Windows.Forms.TextBox textBoxTexturePackMainGame;
        private System.Windows.Forms.Label labelTexturePackMainGame;
        private System.Windows.Forms.Label labelOtherGames;
        private System.Windows.Forms.TextBox textBoxTexturePackHiResPath;
        private System.Windows.Forms.Label labelHiResPath;
        private System.Windows.Forms.Button buttonHiResPath;
        private Controls.kataraktaListView.kataraktaListView listViewOtherGames;
        private System.Windows.Forms.Button buttonAddGame;
        private System.Windows.Forms.Button buttonRemoveSelected;
    }
}