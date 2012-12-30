using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedLogViewer.UI.Controls
{
    public class LogListView : MyListView
    {
        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            base.OnDrawSubItem(e);
        }
    }
}
