using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scarfsail.Common.UI.Shortcuts
{
    public class ShortcutItem
    {

        public ShortcutItem(Func<Keys, bool> evaluate, Action<Keys> action, string shortcutKeysDesc, string description)
        {
            this.Register(evaluate, action, shortcutKeysDesc, description);
        }

        public ShortcutItem(Keys keys, ToolStripItem toolStripItem)
        {
            Action action = delegate()
            {
                if (toolStripItem is ToolStripDropDownButton)
                    (toolStripItem as ToolStripDropDownButton).ShowDropDown();
                else
                    toolStripItem.PerformClick();
            };

            if (toolStripItem is ToolStripMenuItem)
            {
                Register(keys, () => toolStripItem.Enabled, action,
                    toolStripItem.Text); 
                toolStripItem.Text += " (" + this.ShortcutKeysDesc + ")";
            }
            else
            {
                Register(keys, () => toolStripItem.Enabled, action,
                    toolStripItem.ToolTipText.Replace(Environment.NewLine, " "));
            }
            

            toolStripItem.ToolTipText += Environment.NewLine + "(" + this.ShortcutKeysDesc + ")";
        }

        public ShortcutItem(Keys keys, ToolStripItem toolStripItem, string description)
        {
            Register(keys, () => toolStripItem.Enabled, () => toolStripItem.PerformClick(), description);
        }

        public ShortcutItem(Keys keys, Func<bool> enabled, Action action, string description)
        {
            Register(keys, enabled, action, description);
        }

        public ShortcutItem(Keys keys, Action action, string description)
        {
            Register(keys, () => true, action, description);
        }

        private void Register(Keys keys, Func<bool> enabled, Action action, string description)
        {
            this.EvaluateKey = delegate(Keys pressedKeys)
            {
                return enabled() && (pressedKeys == keys);
            };

            this.DoAction = action;
            this.ShortcutKeysDesc = keys.ToString();
            if (this.ShortcutKeysDesc.Contains(", Shift"))
                this.ShortcutKeysDesc = "SHIFT + " + ShortcutKeysDesc.Replace(", Shift", "");

            if (this.ShortcutKeysDesc.Contains(", Control"))
                this.ShortcutKeysDesc = "CTRL + " + ShortcutKeysDesc.Replace(", Control", "");

            this.Description = description;
        }

        private void Register(Func<Keys, bool> evaluate, Action<Keys> action, string shortcutKeysDesc, string description)
        {
            this.EvaluateKey = evaluate;
            this.DoActionWithKeys = action;
            this.ShortcutKeysDesc = shortcutKeysDesc;
            this.Description = description;
        }

        internal Func<Keys, bool> EvaluateKey;
        internal Action DoAction;
        internal Action<Keys> DoActionWithKeys;
        public string ShortcutKeysDesc { protected set; get; }
        public string Description { protected set; get; }

    }
}
