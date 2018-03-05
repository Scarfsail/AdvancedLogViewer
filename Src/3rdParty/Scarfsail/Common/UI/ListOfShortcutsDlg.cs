using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Scarfsail.Common.BL;
using Scarfsail.Common.UI.Shortcuts;

namespace Scarfsail.Common.UI
{
    public partial class ListOfShortcutsDlg : Form
    {
        public ListOfShortcutsDlg(ShortcutManager shortcutManager)
        {
            InitializeComponent();
            foreach (ShortcutItem item in shortcutManager.Shortcuts)
            {
                shortcutsListView.Items.Add(new ListViewItem(new string[] { item.ShortcutKeysDesc, item.Description }));
            }
        }

    }
}
