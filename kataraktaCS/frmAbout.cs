using System;
using System.Windows.Forms;

namespace kataraktaCS
{
    public partial class frmAbout : Form
    {
        static frmLicense license = new frmLicense();
        public frmAbout()
        {
            InitializeComponent();

            // For normal releases
            lbVerNum.Text = kataraktaVersion.VersionName;

            // For Tester Builds
            //public static string VersionName = "Tester Build 1 Fix 2";
            //lbVerNum.Text = $"{kataraktaVersion.VersionName} ({ProductVersion})";
        }

        private void buttonLicense_Click(object sender, EventArgs e)
        {
            license.ShowDialog();
        }
    }
}
