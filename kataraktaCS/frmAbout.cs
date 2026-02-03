using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

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

            JObject JSONSettings = JObject.Parse(File.ReadAllText(MainDefinitions.SettingsPath));

            if (JSONSettings.Value<bool?>("LinuxCompatibility") ?? false)
            {
                this.Width += 24;
                buttonLicense.Width += 24;
                htmlLabelLegalNotice.Location = new Point(htmlLabelLegalNotice.Location.X + 12, htmlLabelLegalNotice.Location.Y);
            }
        }

        private void buttonLicense_Click(object sender, EventArgs e)
        {
            license.ShowDialog();
        }
    }
}
