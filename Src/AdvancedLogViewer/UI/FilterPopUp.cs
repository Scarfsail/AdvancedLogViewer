using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.Common.Parser;
using AdvancedLogViewer.UI.Controls.Filters;
using AdvancedLogViewer.BL.Filters;
using System.Runtime.InteropServices;

namespace AdvancedLogViewer.UI
{
    public partial class FilterPopup<TControl, TItem, TContentType> : Form, IFilterPopup
        where TControl : FilterSettingsBaseControl<TItem, TContentType>, new()
        where TItem : FilterEntry.FilterItem
    {
        private TItem filterItem;
        private TControl filterControl;
        private bool ignoreDeactivate = false;

        public FilterPopup(TItem filterItem, TContentType currentItemValue, string caption, Form owner, Func<List<string>> getDistinctValues)
            : base()
        {
            this.InitializeComponent();
            this.Text += " - " + caption;
            this.Owner = owner;

            this.filterItem = filterItem;
            this.filterControl = new TControl();
            this.filterControl.Margin = new Padding(0);
            this.filterControl.MaxWidthChanged += new EventHandler<WidthChangedEventArgs>(filterControl_MaxWidthChanged);

            this.mainPanel.Controls.Add(this.filterControl);
            this.ClientSize = new Size(filterControl.Width, filterControl.Height + bottomPanel.Height);
            this.filterControl.Dock = DockStyle.Fill;
            this.filterControl.LoadContent(filterItem, currentItemValue, getDistinctValues);
            this.filterControl.Caption = caption + " filter &enabled";

        }

        void filterControl_MaxWidthChanged(object sender, WidthChangedEventArgs e)
        {
            if (e.Width > this.ClientSize.Width)
                this.ClientSize = new Size(e.Width, this.ClientSize.Height);
        }



        void filterControl_Resize(object sender, EventArgs e)
        {
            this.ClientSize = new Size(filterControl.Width, filterControl.Height + bottomPanel.Height);
        }


        public FilterEntry.FilterItem GetFilterItem()
        {
            return this.filterItem;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.filterControl.SaveContent(this.filterItem);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                ignoreDeactivate = true;
                MessageBox.Show("Cant't save filter: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ignoreDeactivate = false;
            }
        }

        private void FilterPopup_Deactivate(object sender, EventArgs e)
        {
            if (!ignoreDeactivate)
                this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }

    public interface IFilterPopup
    {
        FilterEntry.FilterItem GetFilterItem();
    }
    

}
