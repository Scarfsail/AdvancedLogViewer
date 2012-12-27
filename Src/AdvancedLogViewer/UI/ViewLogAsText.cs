using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AdvancedLogViewer.UI
{
    public partial class ViewLogAsText : Form
    {
        public ViewLogAsText()
        {
            InitializeComponent();
        }

        public void LoadFile(string fileName, int numberOfRowsToShow)
        {
            this.Text = fileName;
            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (TextReader sr = new StreamReader(fs))
                {
                    string line;
                    int lineNumber = 0;
                    while (((line = sr.ReadLine()) != null) && ((numberOfRowsToShow == -1) || (lineNumber < numberOfRowsToShow)))
                    {
                        lineNumber ++;
                        this.textBox.Text += line + Environment.NewLine;
                    }
                    this.textBox.SelectionStart = 0;
                    this.textBox.SelectionLength = 0;
                }
            }
        }
    }
}
