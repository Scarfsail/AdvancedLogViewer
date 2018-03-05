using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scarfsail.Common.UI
{
    public partial class InputBox : Form
    {
        public InputBox(string title, string instructionText) : this(title, instructionText, String.Empty)
        {
            
        }
        
        public InputBox(string title, string instructionText, string defaultValue)
        {
            InitializeComponent();
            this.Text = title;
            this.instructionLabel.Text = instructionText;
            this.Value = defaultValue;
        }

        public string Value
        {
            get
            {
                return this.textBox.Text;
            }
            set
            {
                this.textBox.Text = value;

            }
        }
    }
}
