using System;
using System.Windows.Forms;

namespace kataraktaCS.Controls.kataraktaMenuStrip
{
    public class kataraktaMenuStrip : MenuStrip
    {
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == kataraktaMenuStripNativeConstants.WM_MOUSEACTIVATE &&
                m.Result == (IntPtr)kataraktaMenuStripNativeConstants.MA_ACTIVATEANDEAT)
            {
                m.Result = (IntPtr)kataraktaMenuStripNativeConstants.MA_ACTIVATE;
            }
        }
    }
}

internal sealed class kataraktaMenuStripNativeConstants
{

    private kataraktaMenuStripNativeConstants()
    {

    }

    internal const uint WM_MOUSEACTIVATE = 0x21;
    internal const uint MA_ACTIVATE = 1;
    internal const uint MA_ACTIVATEANDEAT = 2;
    internal const uint MA_NOACTIVATE = 3;
    internal const uint MA_NOACTIVATEANDEAT = 4;
}