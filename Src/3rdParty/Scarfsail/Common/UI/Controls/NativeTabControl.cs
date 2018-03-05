using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Scarfsail.Common.UI.Controls
{
    public class NativeTabControl : NativeWindow
    {

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == TCM_ADJUSTRECT))
            {
                RECT rc = (RECT)m.GetLParam(typeof(RECT));
                //Adjust these values to suit, dependant upon Appearance
                rc.Left -= 3;
                rc.Right += 3;
                rc.Top -= 3;
                rc.Bottom += 3;
                Marshal.StructureToPtr(rc, m.LParam, true);
            }
            base.WndProc(ref m);
        }

        private const Int32 TCM_FIRST = 0x1300;
        private const Int32 TCM_ADJUSTRECT = (TCM_FIRST + 40);
        private struct RECT
        {
            public Int32 Left;
            public Int32 Top;
            public Int32 Right;
            public Int32 Bottom;
        }
    }
}
