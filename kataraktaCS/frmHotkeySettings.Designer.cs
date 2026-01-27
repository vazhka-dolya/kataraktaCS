using kataraktaCS.Controls.kataraktaTreeView;
namespace kataraktaCS

{
    partial class frmHotkeySettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHotkeySettings));
            this.splitHotkeySettings = new System.Windows.Forms.SplitContainer();
            this.HotkeyToolStripMain = new kataraktaCS.Controls.kataraktaToolStrip.kataraktaMenuStrip();
            this.toolHotkeySave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolHotkeyEdit = new System.Windows.Forms.ToolStripButton();
            this.toolHotkeyDelete = new System.Windows.Forms.ToolStripButton();
            this.splitTreeAndEdit = new System.Windows.Forms.SplitContainer();
            this.treeViewHotkeys = new kataraktaCS.Controls.kataraktaTreeView.kataraktaTreeView();
            this.splitEditAndEdit = new System.Windows.Forms.SplitContainer();
            this.ToolStripEditHotkey = new kataraktaCS.Controls.kataraktaToolStrip.kataraktaMenuStrip();
            this.ToolLabelHotkey = new System.Windows.Forms.ToolStripLabel();
            this.ToolTextBoxHotkey = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripEditPath = new kataraktaCS.Controls.kataraktaToolStrip.kataraktaMenuStrip();
            this.ToolButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolLabelPath = new System.Windows.Forms.ToolStripLabel();
            this.ToolTextBoxPath = new System.Windows.Forms.ToolStripTextBox();
            this.HotkeyToolStripEdit = new kataraktaCS.Controls.kataraktaToolStrip.kataraktaMenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitHotkeySettings)).BeginInit();
            this.splitHotkeySettings.Panel1.SuspendLayout();
            this.splitHotkeySettings.Panel2.SuspendLayout();
            this.splitHotkeySettings.SuspendLayout();
            this.HotkeyToolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTreeAndEdit)).BeginInit();
            this.splitTreeAndEdit.Panel1.SuspendLayout();
            this.splitTreeAndEdit.Panel2.SuspendLayout();
            this.splitTreeAndEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitEditAndEdit)).BeginInit();
            this.splitEditAndEdit.Panel1.SuspendLayout();
            this.splitEditAndEdit.Panel2.SuspendLayout();
            this.splitEditAndEdit.SuspendLayout();
            this.ToolStripEditHotkey.SuspendLayout();
            this.ToolStripEditPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitHotkeySettings
            // 
            this.splitHotkeySettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitHotkeySettings.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitHotkeySettings.Location = new System.Drawing.Point(0, 0);
            this.splitHotkeySettings.Name = "splitHotkeySettings";
            this.splitHotkeySettings.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitHotkeySettings.Panel1
            // 
            this.splitHotkeySettings.Panel1.Controls.Add(this.HotkeyToolStripMain);
            // 
            // splitHotkeySettings.Panel2
            // 
            this.splitHotkeySettings.Panel2.Controls.Add(this.splitTreeAndEdit);
            this.splitHotkeySettings.Size = new System.Drawing.Size(384, 329);
            this.splitHotkeySettings.SplitterDistance = 25;
            this.splitHotkeySettings.TabIndex = 0;
            // 
            // HotkeyToolStripMain
            // 
            this.HotkeyToolStripMain.ClickThrough = true;
            this.HotkeyToolStripMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HotkeyToolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolHotkeySave,
            this.toolStripSeparator1,
            this.toolHotkeyEdit,
            this.toolHotkeyDelete});
            this.HotkeyToolStripMain.Location = new System.Drawing.Point(0, 0);
            this.HotkeyToolStripMain.Name = "HotkeyToolStripMain";
            this.HotkeyToolStripMain.Size = new System.Drawing.Size(384, 25);
            this.HotkeyToolStripMain.TabIndex = 0;
            this.HotkeyToolStripMain.Text = "HotkeyToolStripMain";
            // 
            // toolHotkeySave
            // 
            this.toolHotkeySave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolHotkeySave.Image = ((System.Drawing.Image)(resources.GetObject("toolHotkeySave.Image")));
            this.toolHotkeySave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolHotkeySave.Name = "toolHotkeySave";
            this.toolHotkeySave.Size = new System.Drawing.Size(35, 22);
            this.toolHotkeySave.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolHotkeyEdit
            // 
            this.toolHotkeyEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolHotkeyEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolHotkeyEdit.Image")));
            this.toolHotkeyEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolHotkeyEdit.Name = "toolHotkeyEdit";
            this.toolHotkeyEdit.Size = new System.Drawing.Size(78, 22);
            this.toolHotkeyEdit.Text = "Edit Selected";
            // 
            // toolHotkeyDelete
            // 
            this.toolHotkeyDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolHotkeyDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolHotkeyDelete.Image")));
            this.toolHotkeyDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolHotkeyDelete.Name = "toolHotkeyDelete";
            this.toolHotkeyDelete.Size = new System.Drawing.Size(135, 22);
            this.toolHotkeyDelete.Text = "Delete/Restore Selected";
            // 
            // splitTreeAndEdit
            // 
            this.splitTreeAndEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTreeAndEdit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitTreeAndEdit.Location = new System.Drawing.Point(0, 0);
            this.splitTreeAndEdit.Name = "splitTreeAndEdit";
            this.splitTreeAndEdit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitTreeAndEdit.Panel1
            // 
            this.splitTreeAndEdit.Panel1.Controls.Add(this.treeViewHotkeys);
            // 
            // splitTreeAndEdit.Panel2
            // 
            this.splitTreeAndEdit.Panel2.Controls.Add(this.splitEditAndEdit);
            this.splitTreeAndEdit.Size = new System.Drawing.Size(384, 300);
            this.splitTreeAndEdit.SplitterDistance = 220;
            this.splitTreeAndEdit.TabIndex = 1;
            // 
            // treeViewHotkeys
            // 
            this.treeViewHotkeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewHotkeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewHotkeys.FullRowSelect = true;
            this.treeViewHotkeys.HideSelection = false;
            this.treeViewHotkeys.HotTracking = true;
            this.treeViewHotkeys.ItemHeight = 20;
            this.treeViewHotkeys.Location = new System.Drawing.Point(0, 0);
            this.treeViewHotkeys.Name = "treeViewHotkeys";
            this.treeViewHotkeys.ShowLines = false;
            this.treeViewHotkeys.Size = new System.Drawing.Size(384, 220);
            this.treeViewHotkeys.TabIndex = 0;
            this.treeViewHotkeys.Visible = false;
            this.treeViewHotkeys.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewHotkeys_BeforeSelect);
            // 
            // splitEditAndEdit
            // 
            this.splitEditAndEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitEditAndEdit.Location = new System.Drawing.Point(0, 0);
            this.splitEditAndEdit.Name = "splitEditAndEdit";
            this.splitEditAndEdit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitEditAndEdit.Panel1
            // 
            this.splitEditAndEdit.Panel1.Controls.Add(this.ToolStripEditHotkey);
            // 
            // splitEditAndEdit.Panel2
            // 
            this.splitEditAndEdit.Panel2.Controls.Add(this.ToolStripEditPath);
            this.splitEditAndEdit.Size = new System.Drawing.Size(384, 76);
            this.splitEditAndEdit.SplitterDistance = 34;
            this.splitEditAndEdit.TabIndex = 0;
            // 
            // ToolStripEditHotkey
            // 
            this.ToolStripEditHotkey.ClickThrough = false;
            this.ToolStripEditHotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripEditHotkey.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolLabelHotkey,
            this.ToolTextBoxHotkey});
            this.ToolStripEditHotkey.Location = new System.Drawing.Point(0, 0);
            this.ToolStripEditHotkey.Name = "ToolStripEditHotkey";
            this.ToolStripEditHotkey.Size = new System.Drawing.Size(384, 34);
            this.ToolStripEditHotkey.TabIndex = 0;
            this.ToolStripEditHotkey.Text = "ToolStripEditHotkey";
            // 
            // ToolLabelHotkey
            // 
            this.ToolLabelHotkey.Name = "ToolLabelHotkey";
            this.ToolLabelHotkey.Size = new System.Drawing.Size(48, 31);
            this.ToolLabelHotkey.Text = "Hotkey:";
            // 
            // ToolTextBoxHotkey
            // 
            this.ToolTextBoxHotkey.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ToolTextBoxHotkey.Name = "ToolTextBoxHotkey";
            this.ToolTextBoxHotkey.Size = new System.Drawing.Size(271, 34);
            // 
            // ToolStripEditPath
            // 
            this.ToolStripEditPath.ClickThrough = false;
            this.ToolStripEditPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripEditPath.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolButtonSave,
            this.toolStripSeparator2,
            this.ToolLabelPath,
            this.ToolTextBoxPath});
            this.ToolStripEditPath.Location = new System.Drawing.Point(0, 0);
            this.ToolStripEditPath.Name = "ToolStripEditPath";
            this.ToolStripEditPath.Size = new System.Drawing.Size(384, 38);
            this.ToolStripEditPath.TabIndex = 1;
            this.ToolStripEditPath.Text = "ToolStripEditPath";
            // 
            // ToolButtonSave
            // 
            this.ToolButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonSave.Image")));
            this.ToolButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonSave.Name = "ToolButtonSave";
            this.ToolButtonSave.Size = new System.Drawing.Size(35, 35);
            this.ToolButtonSave.Text = "Save";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // ToolLabelPath
            // 
            this.ToolLabelPath.Name = "ToolLabelPath";
            this.ToolLabelPath.Size = new System.Drawing.Size(34, 35);
            this.ToolLabelPath.Text = "Path:";
            // 
            // ToolTextBoxPath
            // 
            this.ToolTextBoxPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ToolTextBoxPath.Name = "ToolTextBoxPath";
            this.ToolTextBoxPath.Size = new System.Drawing.Size(244, 38);
            // 
            // HotkeyToolStripEdit
            // 
            this.HotkeyToolStripEdit.ClickThrough = true;
            this.HotkeyToolStripEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HotkeyToolStripEdit.Location = new System.Drawing.Point(0, 0);
            this.HotkeyToolStripEdit.Name = "HotkeyToolStripEdit";
            this.HotkeyToolStripEdit.Size = new System.Drawing.Size(100, 25);
            this.HotkeyToolStripEdit.TabIndex = 0;
            // 
            // frmHotkeySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 329);
            this.Controls.Add(this.splitHotkeySettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHotkeySettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Hotkeys";
            this.splitHotkeySettings.Panel1.ResumeLayout(false);
            this.splitHotkeySettings.Panel1.PerformLayout();
            this.splitHotkeySettings.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitHotkeySettings)).EndInit();
            this.splitHotkeySettings.ResumeLayout(false);
            this.HotkeyToolStripMain.ResumeLayout(false);
            this.HotkeyToolStripMain.PerformLayout();
            this.splitTreeAndEdit.Panel1.ResumeLayout(false);
            this.splitTreeAndEdit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTreeAndEdit)).EndInit();
            this.splitTreeAndEdit.ResumeLayout(false);
            this.splitEditAndEdit.Panel1.ResumeLayout(false);
            this.splitEditAndEdit.Panel1.PerformLayout();
            this.splitEditAndEdit.Panel2.ResumeLayout(false);
            this.splitEditAndEdit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitEditAndEdit)).EndInit();
            this.splitEditAndEdit.ResumeLayout(false);
            this.ToolStripEditHotkey.ResumeLayout(false);
            this.ToolStripEditHotkey.PerformLayout();
            this.ToolStripEditPath.ResumeLayout(false);
            this.ToolStripEditPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitHotkeySettings;
        private kataraktaTreeView treeViewHotkeys;
        private Controls.kataraktaToolStrip.kataraktaMenuStrip HotkeyToolStripMain;
        private System.Windows.Forms.ToolStripButton toolHotkeyEdit;
        private System.Windows.Forms.ToolStripButton toolHotkeyDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolHotkeySave;
        private System.Windows.Forms.SplitContainer splitTreeAndEdit;
        private Controls.kataraktaToolStrip.kataraktaMenuStrip HotkeyToolStripEdit;
        private System.Windows.Forms.SplitContainer splitEditAndEdit;
        private Controls.kataraktaToolStrip.kataraktaMenuStrip ToolStripEditHotkey;
        private Controls.kataraktaToolStrip.kataraktaMenuStrip ToolStripEditPath;
        private System.Windows.Forms.ToolStripLabel ToolLabelHotkey;
        private System.Windows.Forms.ToolStripLabel ToolLabelPath;
        private System.Windows.Forms.ToolStripTextBox ToolTextBoxHotkey;
        private System.Windows.Forms.ToolStripTextBox ToolTextBoxPath;
        private System.Windows.Forms.ToolStripButton ToolButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}