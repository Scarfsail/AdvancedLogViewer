using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scarfsail.Common.UI.Controls;

namespace AdvancedLogBrowser.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.timeLinePanel1.Items.Count == 0)
            {
                TimeLineItem item1 = new TimeLineItem();
                item1.DateFrom = new DateTime(2010, 1, 3, 10, 0, 0);
                item1.DateTo = new DateTime(2010, 1, 3, 12, 0, 0);
                item1.Element = new Button();

                TimeLineItem item2 = new TimeLineItem();
                item2.DateFrom = new DateTime(2010, 1, 3, 11, 00, 0);
                item2.DateTo = new DateTime(2010, 1, 3, 12, 30, 0);
                item2.Element = new ListBox();

                TimeLineItem item3 = new TimeLineItem();
                item3.DateFrom = new DateTime(2010, 1, 3, 10, 30, 0);
                item3.DateTo = new DateTime(2010, 1, 5, 11, 30, 0);
                MarkerPanel markerPanel3 = new MarkerPanel() { Horizontal = true, BackColor = SystemColors.ButtonHighlight };
                markerPanel3.Text = "SomeLogFileName.log";
                markerPanel3.ShowMarkersAsync(20, new Dictionary<int, Color>() { { 1, Color.Red }, { 5, Color.Orange }, { 7, Color.Red } });
                item3.Element = markerPanel3;
                
                this.timeLinePanel1.Items.Add(item1);
                this.timeLinePanel1.Items.Add(item2);
                this.timeLinePanel1.Items.Add(item3);
            }
            this.timeLinePanel1.PixelsPerHour = this.trackBar1.Value;
            this.timeLinePanel1.RefreshContent();            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.timeLinePanel1.PixelsPerHour = this.trackBar1.Value;
            this.timeLinePanel1.RefreshContent();
        }
    }
}
