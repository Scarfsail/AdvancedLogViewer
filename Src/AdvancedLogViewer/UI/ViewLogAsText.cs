using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

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
                var isGzip = false;
                if (fileName.Contains(".gz"))
                {
                    // Check for GZip file mark
                    var firstByte = fs.ReadByte();
                    var secondByte = fs.ReadByte();
                    isGzip = firstByte == 0x1f && secondByte == 0x8b;
                    // Rewind the stream
                    fs.Seek(0, SeekOrigin.Begin);
                }

                Stream stream = isGzip ? new GZipStream(fs, CompressionMode.Decompress) : fs; // Not necessary to employ using block on GZipStream, StreamReader closes it

                using (TextReader sr = new StreamReader(stream))
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
