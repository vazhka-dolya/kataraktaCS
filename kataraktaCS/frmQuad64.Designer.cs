using kataraktaCS.Controls.kataraktaListView;
namespace kataraktaCS
{
    partial class frmQuad64
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuad64));
            this.splitToolStripAndRest = new System.Windows.Forms.SplitContainer();
            this.kataraktaToolStrip1 = new kataraktaCS.Controls.kataraktaToolStrip.kataraktaToolStrip();
            this.menuScanForTextures = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuIconBigger = new System.Windows.Forms.ToolStripButton();
            this.menuIconSmaller = new System.Windows.Forms.ToolStripButton();
            this.splitListAndDetails = new System.Windows.Forms.SplitContainer();
            this.listView1 = new kataraktaCS.Controls.kataraktaListView.kataraktaListView();
            this.buttonExportTexture = new System.Windows.Forms.Button();
            this.textBoxVirAddr = new System.Windows.Forms.TextBox();
            this.labelVirAddr = new System.Windows.Forms.Label();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxFormat = new System.Windows.Forms.TextBox();
            this.textBoxSegAddr = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelFormat = new System.Windows.Forms.Label();
            this.labelSegAddr = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitToolStripAndRest)).BeginInit();
            this.splitToolStripAndRest.Panel1.SuspendLayout();
            this.splitToolStripAndRest.Panel2.SuspendLayout();
            this.splitToolStripAndRest.SuspendLayout();
            this.kataraktaToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitListAndDetails)).BeginInit();
            this.splitListAndDetails.Panel1.SuspendLayout();
            this.splitListAndDetails.Panel2.SuspendLayout();
            this.splitListAndDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitToolStripAndRest
            // 
            resources.ApplyResources(this.splitToolStripAndRest, "splitToolStripAndRest");
            this.splitToolStripAndRest.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitToolStripAndRest.Name = "splitToolStripAndRest";
            // 
            // splitToolStripAndRest.Panel1
            // 
            this.splitToolStripAndRest.Panel1.Controls.Add(this.kataraktaToolStrip1);
            // 
            // splitToolStripAndRest.Panel2
            // 
            this.splitToolStripAndRest.Panel2.Controls.Add(this.splitListAndDetails);
            // 
            // kataraktaToolStrip1
            // 
            resources.ApplyResources(this.kataraktaToolStrip1, "kataraktaToolStrip1");
            this.kataraktaToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuScanForTextures,
            this.toolStripSeparator1,
            this.menuIconBigger,
            this.menuIconSmaller});
            this.kataraktaToolStrip1.Name = "kataraktaToolStrip1";
            // 
            // menuScanForTextures
            // 
            this.menuScanForTextures.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.menuScanForTextures, "menuScanForTextures");
            this.menuScanForTextures.Name = "menuScanForTextures";
            this.menuScanForTextures.Click += new System.EventHandler(this.menuScanForTextures_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // menuIconBigger
            // 
            this.menuIconBigger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuIconBigger.Image = global::kataraktaCS.Properties.Resources.Icon_Plus;
            resources.ApplyResources(this.menuIconBigger, "menuIconBigger");
            this.menuIconBigger.Name = "menuIconBigger";
            this.menuIconBigger.Click += new System.EventHandler(this.menuIconBigger_Click);
            // 
            // menuIconSmaller
            // 
            this.menuIconSmaller.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuIconSmaller.Image = global::kataraktaCS.Properties.Resources.Icon_Minus;
            resources.ApplyResources(this.menuIconSmaller, "menuIconSmaller");
            this.menuIconSmaller.Name = "menuIconSmaller";
            this.menuIconSmaller.Click += new System.EventHandler(this.menuIconSmaller_Click);
            // 
            // splitListAndDetails
            // 
            resources.ApplyResources(this.splitListAndDetails, "splitListAndDetails");
            this.splitListAndDetails.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitListAndDetails.Name = "splitListAndDetails";
            // 
            // splitListAndDetails.Panel1
            // 
            this.splitListAndDetails.Panel1.Controls.Add(this.listView1);
            // 
            // splitListAndDetails.Panel2
            // 
            this.splitListAndDetails.Panel2.Controls.Add(this.buttonExportTexture);
            this.splitListAndDetails.Panel2.Controls.Add(this.textBoxVirAddr);
            this.splitListAndDetails.Panel2.Controls.Add(this.labelVirAddr);
            this.splitListAndDetails.Panel2.Controls.Add(this.textBoxHeight);
            this.splitListAndDetails.Panel2.Controls.Add(this.textBoxWidth);
            this.splitListAndDetails.Panel2.Controls.Add(this.textBoxFormat);
            this.splitListAndDetails.Panel2.Controls.Add(this.textBoxSegAddr);
            this.splitListAndDetails.Panel2.Controls.Add(this.labelHeight);
            this.splitListAndDetails.Panel2.Controls.Add(this.labelWidth);
            this.splitListAndDetails.Panel2.Controls.Add(this.labelFormat);
            this.splitListAndDetails.Panel2.Controls.Add(this.labelSegAddr);
            this.splitListAndDetails.Panel2.Controls.Add(this.pictureBox1);
            this.splitListAndDetails.Panel2.Controls.Add(this.labelWarning);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.HideSelection = false;
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // buttonExportTexture
            // 
            resources.ApplyResources(this.buttonExportTexture, "buttonExportTexture");
            this.buttonExportTexture.Name = "buttonExportTexture";
            this.buttonExportTexture.UseVisualStyleBackColor = true;
            this.buttonExportTexture.Click += new System.EventHandler(this.buttonExportTexture_Click);
            // 
            // textBoxVirAddr
            // 
            this.textBoxVirAddr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxVirAddr, "textBoxVirAddr");
            this.textBoxVirAddr.ForeColor = System.Drawing.Color.Gray;
            this.textBoxVirAddr.Name = "textBoxVirAddr";
            this.textBoxVirAddr.ReadOnly = true;
            // 
            // labelVirAddr
            // 
            resources.ApplyResources(this.labelVirAddr, "labelVirAddr");
            this.labelVirAddr.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelVirAddr.ForeColor = System.Drawing.Color.Gray;
            this.labelVirAddr.Name = "labelVirAddr";
            this.toolTip1.SetToolTip(this.labelVirAddr, resources.GetString("labelVirAddr.ToolTip"));
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxHeight, "textBoxHeight");
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.ReadOnly = true;
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxWidth, "textBoxWidth");
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.ReadOnly = true;
            // 
            // textBoxFormat
            // 
            this.textBoxFormat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxFormat, "textBoxFormat");
            this.textBoxFormat.Name = "textBoxFormat";
            this.textBoxFormat.ReadOnly = true;
            // 
            // textBoxSegAddr
            // 
            this.textBoxSegAddr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxSegAddr, "textBoxSegAddr");
            this.textBoxSegAddr.Name = "textBoxSegAddr";
            this.textBoxSegAddr.ReadOnly = true;
            // 
            // labelHeight
            // 
            resources.ApplyResources(this.labelHeight, "labelHeight");
            this.labelHeight.Name = "labelHeight";
            // 
            // labelWidth
            // 
            resources.ApplyResources(this.labelWidth, "labelWidth");
            this.labelWidth.Name = "labelWidth";
            // 
            // labelFormat
            // 
            resources.ApplyResources(this.labelFormat, "labelFormat");
            this.labelFormat.Name = "labelFormat";
            // 
            // labelSegAddr
            // 
            resources.ApplyResources(this.labelSegAddr, "labelSegAddr");
            this.labelSegAddr.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelSegAddr.Name = "labelSegAddr";
            this.toolTip1.SetToolTip(this.labelSegAddr, resources.GetString("labelSegAddr.ToolTip"));
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // labelWarning
            // 
            resources.ApplyResources(this.labelWarning, "labelWarning");
            this.labelWarning.ForeColor = System.Drawing.Color.Gray;
            this.labelWarning.Name = "labelWarning";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmQuad64
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitToolStripAndRest);
            this.Name = "frmQuad64";
            this.splitToolStripAndRest.Panel1.ResumeLayout(false);
            this.splitToolStripAndRest.Panel1.PerformLayout();
            this.splitToolStripAndRest.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitToolStripAndRest)).EndInit();
            this.splitToolStripAndRest.ResumeLayout(false);
            this.kataraktaToolStrip1.ResumeLayout(false);
            this.kataraktaToolStrip1.PerformLayout();
            this.splitListAndDetails.Panel1.ResumeLayout(false);
            this.splitListAndDetails.Panel2.ResumeLayout(false);
            this.splitListAndDetails.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitListAndDetails)).EndInit();
            this.splitListAndDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private kataraktaListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitToolStripAndRest;
        private Controls.kataraktaToolStrip.kataraktaToolStrip kataraktaToolStrip1;
        private System.Windows.Forms.SplitContainer splitListAndDetails;
        private System.Windows.Forms.ToolStripButton menuScanForTextures;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton menuIconBigger;
        private System.Windows.Forms.ToolStripButton menuIconSmaller;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.Label labelSegAddr;
        private System.Windows.Forms.TextBox textBoxSegAddr;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxFormat;
        private System.Windows.Forms.TextBox textBoxVirAddr;
        private System.Windows.Forms.Label labelVirAddr;
        private System.Windows.Forms.Button buttonExportTexture;
    }
}