using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace kataraktaCS.Controls.kataraktaTreeViewLessFancy
{
    public class kataraktaTreeViewLessFancy : TreeView
    {
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowTheme(this.Handle, "explorer", null);
        }
    }
}