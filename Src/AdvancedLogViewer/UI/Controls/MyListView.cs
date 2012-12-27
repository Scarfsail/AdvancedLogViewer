using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedLogViewer.UI.Controls
{
    public class MyListView:ListView
    {
        public MyListView()
            : base()
        {
            //It has to be in the constructor, because later it has no any effect.
            //With this tweak there are no flickering during setting VirtualSize
            //Thanks to this advice: http://www.eggheadcafe.com/software/aspnet/30897515/redraw-flashing-problem-w.aspx
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
