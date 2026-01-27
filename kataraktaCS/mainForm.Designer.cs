using kataraktaCS.Controls.kataraktaTreeView;
using kataraktaCS.Controls.kataraktaToolStrip;
using kataraktaCS.Controls.kataraktaMenuStrip;
using System.Windows.Forms;

namespace kataraktaCS
{
    partial class mainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.splitRestAndTools = new System.Windows.Forms.SplitContainer();
            this.splitMainAndTexture = new System.Windows.Forms.SplitContainer();
            this.MenuFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.splitTextureListAndView = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new kataraktaCS.Controls.kataraktaTreeView.kataraktaTreeView();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new kataraktaCS.Controls.kataraktaToolStrip.kataraktaToolStrip();
            this.ToolApplyRAM = new System.Windows.Forms.ToolStripButton();
            this.SeparatorRAM = new System.Windows.Forms.ToolStripSeparator();
            this.DropDownApplyTPOther = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolApplyTP = new System.Windows.Forms.ToolStripButton();
            this.SeparatorTP = new System.Windows.Forms.ToolStripSeparator();
            this.ToolRefresh = new System.Windows.Forms.ToolStripButton();
            this.ToolSearch = new System.Windows.Forms.ToolStripTextBox();
            this.ToolSearchButton = new System.Windows.Forms.ToolStripButton();
            this.splitMenuAndRest = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new kataraktaCS.Controls.kataraktaMenuStrip.kataraktaMenuStrip();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenKataraktaCSFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenQuad64 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenTemplateManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUtilities = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConvertTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStayOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdatesRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.TextureList = new System.Windows.Forms.TabControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextApplyTexture = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparatorApply = new System.Windows.Forms.ToolStripSeparator();
            this.contextHotkeyAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.contextHotkeyEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextHotkeyRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparatorHotkeys = new System.Windows.Forms.ToolStripSeparator();
            this.contextRemoveBorders = new System.Windows.Forms.ToolStripMenuItem();
            this.contextRemoveBordersSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.contextRemoveBordersSelectedAndSub = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCache = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCacheGenSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCacheGenSelectedAndSub = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparatorGenerateCache = new System.Windows.Forms.ToolStripSeparator();
            this.contextCacheClearSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCacheClearSelectedAndSub = new System.Windows.Forms.ToolStripMenuItem();
            this.contextSwapTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.SeparatorUtilities = new System.Windows.Forms.ToolStripSeparator();
            this.contextShowInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.contextEditTemplates = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitRestAndTools)).BeginInit();
            this.splitRestAndTools.Panel1.SuspendLayout();
            this.splitRestAndTools.Panel2.SuspendLayout();
            this.splitRestAndTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMainAndTexture)).BeginInit();
            this.splitMainAndTexture.Panel1.SuspendLayout();
            this.splitMainAndTexture.Panel2.SuspendLayout();
            this.splitMainAndTexture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTextureListAndView)).BeginInit();
            this.splitTextureListAndView.Panel1.SuspendLayout();
            this.splitTextureListAndView.Panel2.SuspendLayout();
            this.splitTextureListAndView.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMenuAndRest)).BeginInit();
            this.splitMenuAndRest.Panel1.SuspendLayout();
            this.splitMenuAndRest.Panel2.SuspendLayout();
            this.splitMenuAndRest.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitRestAndTools
            // 
            resources.ApplyResources(this.splitRestAndTools, "splitRestAndTools");
            this.splitRestAndTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitRestAndTools.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitRestAndTools.Name = "splitRestAndTools";
            // 
            // splitRestAndTools.Panel1
            // 
            resources.ApplyResources(this.splitRestAndTools.Panel1, "splitRestAndTools.Panel1");
            this.splitRestAndTools.Panel1.Controls.Add(this.splitMainAndTexture);
            this.toolTip1.SetToolTip(this.splitRestAndTools.Panel1, resources.GetString("splitRestAndTools.Panel1.ToolTip"));
            // 
            // splitRestAndTools.Panel2
            // 
            resources.ApplyResources(this.splitRestAndTools.Panel2, "splitRestAndTools.Panel2");
            this.splitRestAndTools.Panel2.Controls.Add(this.toolStrip1);
            this.toolTip1.SetToolTip(this.splitRestAndTools.Panel2, resources.GetString("splitRestAndTools.Panel2.ToolTip"));
            this.toolTip1.SetToolTip(this.splitRestAndTools, resources.GetString("splitRestAndTools.ToolTip"));
            // 
            // splitMainAndTexture
            // 
            resources.ApplyResources(this.splitMainAndTexture, "splitMainAndTexture");
            this.splitMainAndTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitMainAndTexture.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMainAndTexture.Name = "splitMainAndTexture";
            // 
            // splitMainAndTexture.Panel1
            // 
            resources.ApplyResources(this.splitMainAndTexture.Panel1, "splitMainAndTexture.Panel1");
            this.splitMainAndTexture.Panel1.Controls.Add(this.MenuFLP);
            this.toolTip1.SetToolTip(this.splitMainAndTexture.Panel1, resources.GetString("splitMainAndTexture.Panel1.ToolTip"));
            // 
            // splitMainAndTexture.Panel2
            // 
            resources.ApplyResources(this.splitMainAndTexture.Panel2, "splitMainAndTexture.Panel2");
            this.splitMainAndTexture.Panel2.Controls.Add(this.splitTextureListAndView);
            this.toolTip1.SetToolTip(this.splitMainAndTexture.Panel2, resources.GetString("splitMainAndTexture.Panel2.ToolTip"));
            this.toolTip1.SetToolTip(this.splitMainAndTexture, resources.GetString("splitMainAndTexture.ToolTip"));
            // 
            // MenuFLP
            // 
            resources.ApplyResources(this.MenuFLP, "MenuFLP");
            this.MenuFLP.Name = "MenuFLP";
            this.toolTip1.SetToolTip(this.MenuFLP, resources.GetString("MenuFLP.ToolTip"));
            // 
            // splitTextureListAndView
            // 
            resources.ApplyResources(this.splitTextureListAndView, "splitTextureListAndView");
            this.splitTextureListAndView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitTextureListAndView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitTextureListAndView.Name = "splitTextureListAndView";
            // 
            // splitTextureListAndView.Panel1
            // 
            resources.ApplyResources(this.splitTextureListAndView.Panel1, "splitTextureListAndView.Panel1");
            this.splitTextureListAndView.Panel1.Controls.Add(this.treeView1);
            this.toolTip1.SetToolTip(this.splitTextureListAndView.Panel1, resources.GetString("splitTextureListAndView.Panel1.ToolTip"));
            // 
            // splitTextureListAndView.Panel2
            // 
            resources.ApplyResources(this.splitTextureListAndView.Panel2, "splitTextureListAndView.Panel2");
            this.splitTextureListAndView.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.toolTip1.SetToolTip(this.splitTextureListAndView.Panel2, resources.GetString("splitTextureListAndView.Panel2.ToolTip"));
            this.toolTip1.SetToolTip(this.splitTextureListAndView, resources.GetString("splitTextureListAndView.ToolTip"));
            // 
            // treeView1
            // 
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.HotTracking = true;
            this.treeView1.ImageList = this.ImageList;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowLines = false;
            this.toolTip1.SetToolTip(this.treeView1, resources.GetString("treeView1.ToolTip"));
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.toolTip1.SetToolTip(this.flowLayoutPanel1, resources.GetString("flowLayoutPanel1.ToolTip"));
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolApplyRAM,
            this.SeparatorRAM,
            this.DropDownApplyTPOther,
            this.ToolApplyTP,
            this.SeparatorTP,
            this.ToolRefresh,
            this.ToolSearch,
            this.ToolSearchButton});
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolTip1.SetToolTip(this.toolStrip1, resources.GetString("toolStrip1.ToolTip"));
            // 
            // ToolApplyRAM
            // 
            resources.ApplyResources(this.ToolApplyRAM, "ToolApplyRAM");
            this.ToolApplyRAM.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolApplyRAM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolApplyRAM.Name = "ToolApplyRAM";
            this.ToolApplyRAM.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ToolApplyRAM.Click += new System.EventHandler(this.ToolApplyRAM_Click);
            // 
            // SeparatorRAM
            // 
            resources.ApplyResources(this.SeparatorRAM, "SeparatorRAM");
            this.SeparatorRAM.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SeparatorRAM.Name = "SeparatorRAM";
            // 
            // DropDownApplyTPOther
            // 
            resources.ApplyResources(this.DropDownApplyTPOther, "DropDownApplyTPOther");
            this.DropDownApplyTPOther.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DropDownApplyTPOther.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DropDownApplyTPOther.Name = "DropDownApplyTPOther";
            // 
            // ToolApplyTP
            // 
            resources.ApplyResources(this.ToolApplyTP, "ToolApplyTP");
            this.ToolApplyTP.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolApplyTP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolApplyTP.Name = "ToolApplyTP";
            this.ToolApplyTP.Click += new System.EventHandler(this.ToolApplyTP_Click);
            // 
            // SeparatorTP
            // 
            resources.ApplyResources(this.SeparatorTP, "SeparatorTP");
            this.SeparatorTP.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SeparatorTP.Name = "SeparatorTP";
            // 
            // ToolRefresh
            // 
            resources.ApplyResources(this.ToolRefresh, "ToolRefresh");
            this.ToolRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolRefresh.Image = global::kataraktaCS.Properties.Resources.Refresh;
            this.ToolRefresh.Name = "ToolRefresh";
            this.ToolRefresh.Click += new System.EventHandler(this.ToolRefresh_Click);
            // 
            // ToolSearch
            // 
            resources.ApplyResources(this.ToolSearch, "ToolSearch");
            this.ToolSearch.Name = "ToolSearch";
            // 
            // ToolSearchButton
            // 
            resources.ApplyResources(this.ToolSearchButton, "ToolSearchButton");
            this.ToolSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolSearchButton.Image = global::kataraktaCS.Properties.Resources.Search;
            this.ToolSearchButton.Name = "ToolSearchButton";
            this.ToolSearchButton.Click += new System.EventHandler(this.ToolSearchButton_Click);
            // 
            // splitMenuAndRest
            // 
            resources.ApplyResources(this.splitMenuAndRest, "splitMenuAndRest");
            this.splitMenuAndRest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitMenuAndRest.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMenuAndRest.Name = "splitMenuAndRest";
            // 
            // splitMenuAndRest.Panel1
            // 
            resources.ApplyResources(this.splitMenuAndRest.Panel1, "splitMenuAndRest.Panel1");
            this.splitMenuAndRest.Panel1.Controls.Add(this.menuStrip1);
            this.toolTip1.SetToolTip(this.splitMenuAndRest.Panel1, resources.GetString("splitMenuAndRest.Panel1.ToolTip"));
            // 
            // splitMenuAndRest.Panel2
            // 
            resources.ApplyResources(this.splitMenuAndRest.Panel2, "splitMenuAndRest.Panel2");
            this.splitMenuAndRest.Panel2.Controls.Add(this.splitRestAndTools);
            this.toolTip1.SetToolTip(this.splitMenuAndRest.Panel2, resources.GetString("splitMenuAndRest.Panel2.ToolTip"));
            this.toolTip1.SetToolTip(this.splitMenuAndRest, resources.GetString("splitMenuAndRest.ToolTip"));
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptions,
            this.menuAbout,
            this.menuUpdates,
            this.menuUpdatesRefresh});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.toolTip1.SetToolTip(this.menuStrip1, resources.GetString("menuStrip1.ToolTip"));
            // 
            // menuOptions
            // 
            resources.ApplyResources(this.menuOptions, "menuOptions");
            this.menuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenKataraktaCSFolder,
            this.menuOpenQuad64,
            this.menuOpenTemplateManager,
            this.menuUtilities,
            this.toolStripSeparator6,
            this.menuSettings,
            this.toolStripSeparator7,
            this.menuStayOnTop});
            this.menuOptions.Image = global::kataraktaCS.Properties.Resources.Icon_Settings;
            this.menuOptions.Name = "menuOptions";
            // 
            // menuOpenKataraktaCSFolder
            // 
            resources.ApplyResources(this.menuOpenKataraktaCSFolder, "menuOpenKataraktaCSFolder");
            this.menuOpenKataraktaCSFolder.Name = "menuOpenKataraktaCSFolder";
            this.menuOpenKataraktaCSFolder.Click += new System.EventHandler(this.openKataraktaCSFolderToolStripMenuItem_Click);
            // 
            // menuOpenQuad64
            // 
            resources.ApplyResources(this.menuOpenQuad64, "menuOpenQuad64");
            this.menuOpenQuad64.Name = "menuOpenQuad64";
            this.menuOpenQuad64.Click += new System.EventHandler(this.menuOpenQuad64_Click);
            // 
            // menuOpenTemplateManager
            // 
            resources.ApplyResources(this.menuOpenTemplateManager, "menuOpenTemplateManager");
            this.menuOpenTemplateManager.Name = "menuOpenTemplateManager";
            this.menuOpenTemplateManager.Click += new System.EventHandler(this.menuOpenTemplateManager_Click);
            // 
            // menuUtilities
            // 
            resources.ApplyResources(this.menuUtilities, "menuUtilities");
            this.menuUtilities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConvertTemplates});
            this.menuUtilities.Name = "menuUtilities";
            // 
            // menuConvertTemplates
            // 
            resources.ApplyResources(this.menuConvertTemplates, "menuConvertTemplates");
            this.menuConvertTemplates.Name = "menuConvertTemplates";
            this.menuConvertTemplates.Click += new System.EventHandler(this.menuConvertTemplates_Click);
            // 
            // toolStripSeparator6
            // 
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // menuSettings
            // 
            resources.ApplyResources(this.menuSettings, "menuSettings");
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            // 
            // menuStayOnTop
            // 
            resources.ApplyResources(this.menuStayOnTop, "menuStayOnTop");
            this.menuStayOnTop.Name = "menuStayOnTop";
            this.menuStayOnTop.Click += new System.EventHandler(this.stayOnTopToolStripMenuItem_Click);
            // 
            // menuAbout
            // 
            resources.ApplyResources(this.menuAbout, "menuAbout");
            this.menuAbout.Image = global::kataraktaCS.Properties.Resources.Icon_About;
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // menuUpdates
            // 
            resources.ApplyResources(this.menuUpdates, "menuUpdates");
            this.menuUpdates.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuUpdates.Image = global::kataraktaCS.Properties.Resources.updates_unknown;
            this.menuUpdates.Name = "menuUpdates";
            this.menuUpdates.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.menuUpdates.Click += new System.EventHandler(this.menuUpdates_Click);
            // 
            // menuUpdatesRefresh
            // 
            resources.ApplyResources(this.menuUpdatesRefresh, "menuUpdatesRefresh");
            this.menuUpdatesRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuUpdatesRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuUpdatesRefresh.Image = global::kataraktaCS.Properties.Resources.updates_refresh;
            this.menuUpdatesRefresh.Name = "menuUpdatesRefresh";
            this.menuUpdatesRefresh.Click += new System.EventHandler(this.menuUpdatesRefresh_Click);
            // 
            // TextureList
            // 
            resources.ApplyResources(this.TextureList, "TextureList");
            this.TextureList.Name = "TextureList";
            this.TextureList.SelectedIndex = 0;
            this.toolTip1.SetToolTip(this.TextureList, resources.GetString("TextureList.ToolTip"));
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 32767;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // contextMenu
            // 
            resources.ApplyResources(this.contextMenu, "contextMenu");
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextApplyTexture,
            this.SeparatorApply,
            this.contextHotkeyAdd,
            this.contextHotkeyEdit,
            this.contextHotkeyRemove,
            this.SeparatorHotkeys,
            this.contextRemoveBorders,
            this.contextCache,
            this.contextSwapTemplates,
            this.SeparatorUtilities,
            this.contextShowInExplorer,
            this.contextEditTemplates});
            this.contextMenu.Name = "contextHotkeys";
            this.toolTip1.SetToolTip(this.contextMenu, resources.GetString("contextMenu.ToolTip"));
            // 
            // contextApplyTexture
            // 
            resources.ApplyResources(this.contextApplyTexture, "contextApplyTexture");
            this.contextApplyTexture.Name = "contextApplyTexture";
            this.contextApplyTexture.Click += new System.EventHandler(this.contextApplyTexture_Click);
            // 
            // SeparatorApply
            // 
            resources.ApplyResources(this.SeparatorApply, "SeparatorApply");
            this.SeparatorApply.Name = "SeparatorApply";
            // 
            // contextHotkeyAdd
            // 
            resources.ApplyResources(this.contextHotkeyAdd, "contextHotkeyAdd");
            this.contextHotkeyAdd.Name = "contextHotkeyAdd";
            this.contextHotkeyAdd.Click += new System.EventHandler(this.contextHotkeyAdd_Click);
            // 
            // contextHotkeyEdit
            // 
            resources.ApplyResources(this.contextHotkeyEdit, "contextHotkeyEdit");
            this.contextHotkeyEdit.Name = "contextHotkeyEdit";
            this.contextHotkeyEdit.Click += new System.EventHandler(this.contextHotkeyEdit_Click);
            // 
            // contextHotkeyRemove
            // 
            resources.ApplyResources(this.contextHotkeyRemove, "contextHotkeyRemove");
            this.contextHotkeyRemove.Name = "contextHotkeyRemove";
            this.contextHotkeyRemove.Click += new System.EventHandler(this.contextHotkeyRemove_Click);
            // 
            // SeparatorHotkeys
            // 
            resources.ApplyResources(this.SeparatorHotkeys, "SeparatorHotkeys");
            this.SeparatorHotkeys.Name = "SeparatorHotkeys";
            // 
            // contextRemoveBorders
            // 
            resources.ApplyResources(this.contextRemoveBorders, "contextRemoveBorders");
            this.contextRemoveBorders.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextRemoveBordersSelected,
            this.contextRemoveBordersSelectedAndSub});
            this.contextRemoveBorders.Image = global::kataraktaCS.Properties.Resources.Icon_FixBorders;
            this.contextRemoveBorders.Name = "contextRemoveBorders";
            // 
            // contextRemoveBordersSelected
            // 
            resources.ApplyResources(this.contextRemoveBordersSelected, "contextRemoveBordersSelected");
            this.contextRemoveBordersSelected.Name = "contextRemoveBordersSelected";
            this.contextRemoveBordersSelected.Click += new System.EventHandler(this.contextRemoveBordersSelected_Click);
            // 
            // contextRemoveBordersSelectedAndSub
            // 
            resources.ApplyResources(this.contextRemoveBordersSelectedAndSub, "contextRemoveBordersSelectedAndSub");
            this.contextRemoveBordersSelectedAndSub.Name = "contextRemoveBordersSelectedAndSub";
            this.contextRemoveBordersSelectedAndSub.Click += new System.EventHandler(this.contextRemoveBordersSelectedAndSub_Click);
            // 
            // contextCache
            // 
            resources.ApplyResources(this.contextCache, "contextCache");
            this.contextCache.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextCacheGenSelected,
            this.contextCacheGenSelectedAndSub,
            this.SeparatorGenerateCache,
            this.contextCacheClearSelected,
            this.contextCacheClearSelectedAndSub});
            this.contextCache.Image = global::kataraktaCS.Properties.Resources.Icon_CacheColor;
            this.contextCache.Name = "contextCache";
            // 
            // contextCacheGenSelected
            // 
            resources.ApplyResources(this.contextCacheGenSelected, "contextCacheGenSelected");
            this.contextCacheGenSelected.Name = "contextCacheGenSelected";
            this.contextCacheGenSelected.Click += new System.EventHandler(this.contextCacheGenSelected_Click);
            // 
            // contextCacheGenSelectedAndSub
            // 
            resources.ApplyResources(this.contextCacheGenSelectedAndSub, "contextCacheGenSelectedAndSub");
            this.contextCacheGenSelectedAndSub.Name = "contextCacheGenSelectedAndSub";
            this.contextCacheGenSelectedAndSub.Click += new System.EventHandler(this.contextCacheGenSelectedAndSub_Click);
            // 
            // SeparatorGenerateCache
            // 
            resources.ApplyResources(this.SeparatorGenerateCache, "SeparatorGenerateCache");
            this.SeparatorGenerateCache.Name = "SeparatorGenerateCache";
            // 
            // contextCacheClearSelected
            // 
            resources.ApplyResources(this.contextCacheClearSelected, "contextCacheClearSelected");
            this.contextCacheClearSelected.Name = "contextCacheClearSelected";
            this.contextCacheClearSelected.Click += new System.EventHandler(this.contextCacheClearSelected_Click);
            // 
            // contextCacheClearSelectedAndSub
            // 
            resources.ApplyResources(this.contextCacheClearSelectedAndSub, "contextCacheClearSelectedAndSub");
            this.contextCacheClearSelectedAndSub.Name = "contextCacheClearSelectedAndSub";
            this.contextCacheClearSelectedAndSub.Click += new System.EventHandler(this.contextCacheClearSelectedAndSub_Click);
            // 
            // contextSwapTemplates
            // 
            resources.ApplyResources(this.contextSwapTemplates, "contextSwapTemplates");
            this.contextSwapTemplates.Image = global::kataraktaCS.Properties.Resources.Icon_FolderSettings;
            this.contextSwapTemplates.Name = "contextSwapTemplates";
            // 
            // SeparatorUtilities
            // 
            resources.ApplyResources(this.SeparatorUtilities, "SeparatorUtilities");
            this.SeparatorUtilities.Name = "SeparatorUtilities";
            // 
            // contextShowInExplorer
            // 
            resources.ApplyResources(this.contextShowInExplorer, "contextShowInExplorer");
            this.contextShowInExplorer.Name = "contextShowInExplorer";
            this.contextShowInExplorer.Click += new System.EventHandler(this.contextShowInExplorer_Click);
            // 
            // contextEditTemplates
            // 
            resources.ApplyResources(this.contextEditTemplates, "contextEditTemplates");
            this.contextEditTemplates.Name = "contextEditTemplates";
            this.contextEditTemplates.Click += new System.EventHandler(this.contextEditTemplates_Click);
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitMenuAndRest);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.splitRestAndTools.Panel1.ResumeLayout(false);
            this.splitRestAndTools.Panel2.ResumeLayout(false);
            this.splitRestAndTools.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRestAndTools)).EndInit();
            this.splitRestAndTools.ResumeLayout(false);
            this.splitMainAndTexture.Panel1.ResumeLayout(false);
            this.splitMainAndTexture.Panel1.PerformLayout();
            this.splitMainAndTexture.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMainAndTexture)).EndInit();
            this.splitMainAndTexture.ResumeLayout(false);
            this.splitTextureListAndView.Panel1.ResumeLayout(false);
            this.splitTextureListAndView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTextureListAndView)).EndInit();
            this.splitTextureListAndView.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitMenuAndRest.Panel1.ResumeLayout(false);
            this.splitMenuAndRest.Panel1.PerformLayout();
            this.splitMenuAndRest.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMenuAndRest)).EndInit();
            this.splitMenuAndRest.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TextureList;
        private System.Windows.Forms.SplitContainer splitRestAndTools;
        private kataraktaCS.Controls.kataraktaToolStrip.kataraktaToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolApplyRAM;
        private System.Windows.Forms.SplitContainer splitMainAndTexture;
        private System.Windows.Forms.SplitContainer splitTextureListAndView;
        private kataraktaCS.Controls.kataraktaTreeView.kataraktaTreeView treeView1;
        private System.Windows.Forms.ToolStripButton ToolRefresh;
        private System.Windows.Forms.ToolStripSeparator SeparatorRAM;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.FlowLayoutPanel MenuFLP;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripTextBox ToolSearch;
        private System.Windows.Forms.ToolStripButton ToolSearchButton;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem contextHotkeyAdd;
        private ToolStripMenuItem contextHotkeyRemove;
        private ToolStripMenuItem contextHotkeyEdit;
        private ToolStripMenuItem contextShowInExplorer;
        private ToolStripSeparator SeparatorApply;
        private ToolStripMenuItem contextApplyTexture;
        private ToolStripSeparator SeparatorHotkeys;
        private ToolStripMenuItem contextCache;
        private ToolStripMenuItem contextCacheClearSelected;
        private ToolStripMenuItem contextCacheGenSelected;
        private ToolStripMenuItem contextCacheGenSelectedAndSub;
        private ToolStripSeparator SeparatorGenerateCache;
        private ToolStripMenuItem contextCacheClearSelectedAndSub;
        private kataraktaMenuStrip menuStrip1;
        private ToolStripMenuItem menuOptions;
        private ToolStripMenuItem menuAbout;
        private ToolStripMenuItem menuOpenKataraktaCSFolder;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem menuSettings;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem menuStayOnTop;
        private SplitContainer splitMenuAndRest;
        private ToolStripMenuItem menuUpdates;
        private ToolStripMenuItem menuUpdatesRefresh;
        private ToolStripMenuItem menuOpenQuad64;
        private ToolStripSeparator SeparatorUtilities;
        private ToolStripMenuItem contextEditTemplates;
        private ToolStripMenuItem menuUtilities;
        private ToolStripMenuItem menuConvertTemplates;
        private ToolStripMenuItem menuOpenTemplateManager;
        private ToolStripButton ToolApplyTP;
        private ToolStripSeparator SeparatorTP;
        private ToolStripDropDownButton DropDownApplyTPOther;
        private ToolStripMenuItem contextRemoveBorders;
        private ToolStripMenuItem contextRemoveBordersSelected;
        private ToolStripMenuItem contextRemoveBordersSelectedAndSub;
        private ToolStripMenuItem contextSwapTemplates;
    }
}

