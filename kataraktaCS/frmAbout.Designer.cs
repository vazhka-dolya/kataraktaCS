namespace kataraktaCS
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lbAddonName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbVerNum = new System.Windows.Forms.Label();
            this.buttonLicense = new System.Windows.Forms.Button();
            this.pictureArt = new System.Windows.Forms.PictureBox();
            this.htmlLabelAuthor = new TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel();
            this.htmlLabelLegalNotice = new TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel();
            this.htmlLabelDescription = new TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureArt)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAddonName
            // 
            resources.ApplyResources(this.lbAddonName, "lbAddonName");
            this.lbAddonName.Name = "lbAddonName";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            // 
            // lbVerNum
            // 
            resources.ApplyResources(this.lbVerNum, "lbVerNum");
            this.lbVerNum.Name = "lbVerNum";
            // 
            // buttonLicense
            // 
            resources.ApplyResources(this.buttonLicense, "buttonLicense");
            this.buttonLicense.Name = "buttonLicense";
            this.buttonLicense.UseVisualStyleBackColor = true;
            this.buttonLicense.Click += new System.EventHandler(this.buttonLicense_Click);
            // 
            // pictureArt
            // 
            this.pictureArt.BackgroundImage = global::kataraktaCS.Properties.Resources.AboutWindowArt;
            resources.ApplyResources(this.pictureArt, "pictureArt");
            this.pictureArt.Name = "pictureArt";
            this.pictureArt.TabStop = false;
            // 
            // htmlLabelAuthor
            // 
            this.htmlLabelAuthor.BackColor = System.Drawing.Color.Transparent;
            this.htmlLabelAuthor.BaseStylesheet = "";
            resources.ApplyResources(this.htmlLabelAuthor, "htmlLabelAuthor");
            this.htmlLabelAuthor.Name = "htmlLabelAuthor";
            // 
            // htmlLabelLegalNotice
            // 
            this.htmlLabelLegalNotice.BackColor = System.Drawing.Color.Transparent;
            this.htmlLabelLegalNotice.BaseStylesheet = null;
            resources.ApplyResources(this.htmlLabelLegalNotice, "htmlLabelLegalNotice");
            this.htmlLabelLegalNotice.Name = "htmlLabelLegalNotice";
            // 
            // htmlLabelDescription
            // 
            this.htmlLabelDescription.BackColor = System.Drawing.Color.Transparent;
            this.htmlLabelDescription.BaseStylesheet = "";
            resources.ApplyResources(this.htmlLabelDescription, "htmlLabelDescription");
            this.htmlLabelDescription.Name = "htmlLabelDescription";
            // 
            // frmAbout
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.htmlLabelLegalNotice);
            this.Controls.Add(this.htmlLabelDescription);
            this.Controls.Add(this.htmlLabelAuthor);
            this.Controls.Add(this.pictureArt);
            this.Controls.Add(this.buttonLicense);
            this.Controls.Add(this.lbVerNum);
            this.Controls.Add(this.lbAddonName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            ((System.ComponentModel.ISupportInitialize)(this.pictureArt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbAddonName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbVerNum;
        private System.Windows.Forms.Button buttonLicense;
        private System.Windows.Forms.PictureBox pictureArt;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel htmlLabelAuthor;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel htmlLabelLegalNotice;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel htmlLabelDescription;
    }
}