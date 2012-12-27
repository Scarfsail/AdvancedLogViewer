using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using AdvancedLogViewer.Common.Parser;

namespace AdvancedLogViewer.Plugins.BlackoutAnalyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        internal void Execute(List<LogEntry> logEntries)
        {
            DataTable table = new DataTable();

            table.Columns.Add("From");
            table.Columns.Add("To");
            table.Columns.Add("Period");

            DateTime from = DateTime.MinValue;
            DateTime to = DateTime.MinValue;

            foreach (LogEntry logEntry in logEntries)
            {
                DateTime temp = logEntry.Date;

                if (temp != DateTime.MinValue)
                {
                    if (from == DateTime.MinValue)
                    {
                        from = temp;
                        to = temp;
                    }
                    else
                    {
                        if ((temp - to).TotalMinutes > 10)
                        {
                            DataRow newRow = table.NewRow();

                            newRow["From"] = from;
                            newRow["To"] = to;
                            newRow["Period"] = to - from;

                            table.Rows.Add(newRow);

                            from = temp;
                            to = temp;
                        }
                        else
                        {
                            to = temp;
                        }
                    }
                }
            }

            this.dataView.DataSource = table;
        }
    }
}
