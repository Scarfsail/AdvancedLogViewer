using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.BL.Filters;

namespace AdvancedLogViewer.UI.Controls.Filters
{
    public partial class FilterSettingsBaseControl<TFilter, TContentType> : UserControl
        where TFilter : FilterEntry.FilterItem
    {
        public FilterSettingsBaseControl()
        {
            InitializeComponent();
        }

        public event EventHandler<WidthChangedEventArgs> MaxWidthChanged;

        protected void DoMaxWidthChanged(int width)
        {
            if (MaxWidthChanged != null)
                MaxWidthChanged(this, new WidthChangedEventArgs(width));
        }
        
        public string Caption
        {
            get { return this.enabledCheckBox.Text; }
            set { this.enabledCheckBox.Text = value; }
        }

        public virtual void LoadContent(TFilter filterItem, TContentType currentItemValue, Func<List<string>> getDistinctValues)
        {
            this.enabledCheckBox.Checked = filterItem.Enabled;
            this.CurrentItemValue = currentItemValue;
            this.GetDistinctValues = getDistinctValues;
            this.InternalLoadContent(filterItem);
        }

        public virtual void SaveContent(TFilter filterItem)
        {
            filterItem.Enabled = this.enabledCheckBox.Checked;
        }

        protected virtual void InternalLoadContent(TFilter filterItem)
        {
            throw new InvalidOperationException("This method can't be called.");
        }

        protected TContentType CurrentItemValue {get; private set;}
        protected Func<List<string>> GetDistinctValues { get; private set; }
    }

    public class WidthChangedEventArgs : EventArgs
    {
        public WidthChangedEventArgs(int width)
        {
            this.Width = width;
        }

        public int Width { get; private set; }
    }
}
