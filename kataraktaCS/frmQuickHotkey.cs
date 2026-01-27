using System;
using System.Windows.Forms;

namespace kataraktaCS
{
    public partial class frmQuickHotkey : Form
    {
        public bool isSelecting = false;

        private HotkeyEdit HotkeyEdit;

        public event Action RefreshMainForm;

        public frmQuickHotkey(string Path, string Hotkey)
        {
            InitializeComponent();

            HotkeyEdit = new HotkeyEdit();

            this.KeyPreview = true;
            this.KeyDown += textBoxHotkey_KeyDown;

            textBoxPath.Text = Path;
            textBoxHotkey.Text = Hotkey;

            if (textBoxHotkey.Text != "") buttonSaveAndClose.Enabled = true;
            else buttonSaveAndClose.Enabled = false;
        }

        // UI

        private void textBoxHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxHotkey.Focused == true)
            {
                e.SuppressKeyPress = true;

                string Hotkey = "";

                if (e.Control) Hotkey += "Ctrl + ";
                if (e.Shift) Hotkey += "Shift + ";
                if (e.Alt) Hotkey += "Alt + ";

                if (e.KeyCode != Keys.ControlKey &&
                    e.KeyCode != Keys.ShiftKey &&
                    e.KeyCode != Keys.Menu) // Menu = Alt
                {
                    Hotkey += e.KeyCode.ToString().ToUpper();
                }

                else if (Hotkey.EndsWith(" + "))
                {
                    // Remove trailing " + " if there's nothing afterwards
                    Hotkey = Hotkey.Substring(0, Hotkey.Length - 3);
                }

                textBoxHotkey.Text = Hotkey;

                if (textBoxHotkey.Text != "") buttonSaveAndClose.Enabled = true;
                else buttonSaveAndClose.Enabled = false;
            }
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            if (textBoxHotkey.Text != "")
            {
                HotkeyEdit.ModifyHotkeys(
                    PathOfHotkey: textBoxPath.Text,
                    RemoveInsteadOfAdd: false,
                    TheHotkey: textBoxHotkey.Text);
                Close();
            }
        }

        private void frmQuickHotkeys_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshMainForm?.Invoke();
            Dispose();
        }
    }
}
