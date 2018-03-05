using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scarfsail.Common.UI.Controls
{
    public partial class DateTimeEdit : UserControl
    {
        public DateTimeEdit()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Value
        {
            get
            {

                return new DateTime(this.datePicker.Value.Date.Ticks + this.timePicker.Value.TimeOfDay.Ticks);
            }
            set
            {
                this.datePicker.Value = value.Date;
                this.timePicker.Value = value;                               
            }
        }

        public event EventHandler ValueChanged;

        protected virtual void DoValueChanged()
        {
            if (this.ValueChanged != null)
            {
                this.ValueChanged(this, new EventArgs());
            }
        }

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            this.DoValueChanged();
        }
    }
}
