using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scarfsail.Common.UI.Shortcuts
{
    public class ShortcutManager
    {
        private List<ShortcutItem> shortcuts = new List<ShortcutItem>();

        public void Add(ShortcutItem item)
        {
            this.shortcuts.Add(item);
        }

        public bool ProcessKey(Keys keys)
        {
            foreach (ShortcutItem item in this.shortcuts)
            {
                if (item.EvaluateKey(keys))
                {
                    if (item.DoAction != null)
                        item.DoAction();
                    
                    if (item.DoActionWithKeys != null)
                        item.DoActionWithKeys(keys);
                    return true;
                }
            }
            return false;
        }

        public List<ShortcutItem> Shortcuts { get { return this.shortcuts; } }

    }
}
