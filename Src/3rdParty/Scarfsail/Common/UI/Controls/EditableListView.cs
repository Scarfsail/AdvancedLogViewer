using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace Scarfsail.Common.UI.Controls
{
    //[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    [Designer(typeof(EditableListViewDesigner))]
    public partial class EditableListView : UserControl
    {
        public EditableListView()
        {
            InitializeComponent();
        }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ListView.ColumnHeaderCollection ListViewColumns
        {
            get
            {
                return this.listView.Columns;
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ListViewItemCollection Items
        {
            get
            {
                return this.listView.Items;
            }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem SelectedItem
        {
            get
            {
                if (listView.SelectedItems.Count == 0)
                    return null;

                return listView.SelectedItems[0];
            }
        }
        
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ContainerPanel
        {
            get
            {
                return buttonsPanel;
            }
        }


        public bool ListViewHideSelection
        {
            get
            {
                return this.listView.HideSelection;
            }
            set
            {
                this.listView.HideSelection = value;
                
            }
        }

        public ColumnHeaderStyle ListViewHeaderStyle
        {
            get
            {
                return this.listView.HeaderStyle;
            }
            set
            {
                this.listView.HeaderStyle = value;
            }
        }

        public event EventHandler ListViewDoubleClick;
        
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (ListViewDoubleClick != null)
                ListViewDoubleClick(sender, e);
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = listView.SelectedItems.Count > 0 ? listView.SelectedItems[0] : null;

            if (item == null)
            {
                itemTextBox.Enabled = false;
                itemTextBox.Text = String.Empty;
                return;
            }
            itemTextBox.Enabled = true;
            itemTextBox.Text = item.Text;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem("New item");
            listView.Items.Add(item);
            item.Selected = true;
            item.Focused = true;
            itemTextBox.Focus();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.SelectedItem;
            if (item == null)
                return;

            item.Remove();
        }

        private void itemTextBox_TextChanged(object sender, EventArgs e)
        {
            ListViewItem item = this.SelectedItem;
            if (item == null)
                return;

            item.Text = itemTextBox.Text;
        }
    }



    public class EditableListViewDesigner : ParentControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);

            if (this.Control is EditableListView)
            {
                this.EnableDesignMode(((EditableListView)this.Control).ContainerPanel, "ContainerPanel");
            }
        }
    }


    
}
