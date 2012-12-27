using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.Common.Parser;

namespace AdvancedLogViewer.UI
{
    public partial class GoToItem : Form
    {
        public GoToItem(int itemNumber, DateTime dateTime, bool enableDateGoto)
        {
            InitializeComponent();
            this.ItemNumber = itemNumber;
            if (enableDateGoto)
            {
                this.DateTime = dateTime;
            }
            else
            {
                this.dateTimeEdit.Enabled = false;
                this.selectDateTimeRadioButton.Enabled = false;
            }
            this.itemNumberUpDown.Select(0, itemNumber.ToString().Length);
        }

        public int ItemNumber
        {
            get
            {
                return (int)this.itemNumberUpDown.Value;
            }
            set
            {
                this.itemNumberUpDown.Value = value;

            }
        }

        public DateTime DateTime
        {
            get
            {

                return dateTimeEdit.Value;
            }
            set
            {
                this.dateTimeEdit.Value = value;
            }
        }

        public bool DateTimeSelected
        {
            get
            {
                return selectDateTimeRadioButton.Checked;
            }
        }


        private void itemNumberUpDown_Enter(object sender, EventArgs e)
        {
            selectItemRadioButton.Checked = true;
        }

        private void dateTimeEdit_Enter(object sender, EventArgs e)
        {
            selectDateTimeRadioButton.Checked = true;
        }
    }
}
