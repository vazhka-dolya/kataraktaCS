using System;
using System.Windows.Forms;

namespace kataraktaCS.Controls.kataraktaToolStrip
{
    public class kataraktaToolStrip : ToolStrip
    {
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == kataraktaToolStripNativeConstants.WM_MOUSEACTIVATE &&
                m.Result == (IntPtr)kataraktaToolStripNativeConstants.MA_ACTIVATEANDEAT)
            {
                m.Result = (IntPtr)kataraktaToolStripNativeConstants.MA_ACTIVATE;
            }
        }
    }
}

internal sealed class kataraktaToolStripNativeConstants
{

    private kataraktaToolStripNativeConstants()
    {

    }

    internal const uint WM_MOUSEACTIVATE = 0x21;
    internal const uint MA_ACTIVATE = 1;
    internal const uint MA_ACTIVATEANDEAT = 2;
    internal const uint MA_NOACTIVATE = 3;
    internal const uint MA_NOACTIVATEANDEAT = 4;
}