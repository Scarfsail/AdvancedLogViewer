using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedLogViewer.Plugins.TimeLapse
{
    partial class MainForm : Form
    {
        const int sample_width = 8;
        List<double> diffs = new List<double>();

        Func<int, bool, bool> GoToLogItem;
        

        private MainForm()
        {
            InitializeComponent();
        }

        public    MainForm(IWin32Window owner)
            : this()
        {

            if (owner.GetType().Name.Contains("MainForm"))
            {
                var met = owner.GetType().GetMethod("GoToLogItem", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                    null, new Type[] { typeof(int), typeof(bool) }, null);

                GoToLogItem = (x, y) => (bool)met.Invoke(owner, new object[] { x, y });
            }
            
        }

        internal void Execute(List<Common.Parser.LogEntry> logEntries)
        {
            diffs = new List<double>();

            for(int i = 0; i < logEntries.Count - 1; i++)
            {
                diffs.Add((logEntries[i + 1].Date - logEntries[i].Date).TotalSeconds);
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.TranslateTransform(10, 0);
            e.Graphics.DrawLines(Pens.Black, new Point[] { new Point(0, 0), new Point(0, canvas.Height-1), new Point(canvas.Width, canvas.Height-1)});
            //e.Graphics.ResetTransform();

            int samples_count = canvas.Width / sample_width;
            int lines_per_sample = diffs.Count / samples_count;

            List<double> samples = new List<double>();

            var points = new List<Point>();
            for (int i = 0; i < diffs.Count; i++)
            {
                double sample = 0;
                for (int y = 0; y < lines_per_sample && i < diffs.Count; y++, i++)
                {
                    sample += diffs[i];
                }
                samples.Add(sample);
            }

            double max = samples.Max();
            double min = samples.Min();


            for (int i = 0; i < samples.Count; i++)
            {
                double size = ((samples[i] / (max-min)) * canvas.Height)*0.8;
                int r = (int)(samples[i] / (max - min) * 255);
                if (r < 0)
                    r = 0;
                if (r > 255)
                    r = 255;

                points.Add(new Point(i * sample_width + sample_width/2, canvas.Height - (int)size));

                using (var b = new SolidBrush(Color.FromArgb(r, 0, 0)))
                {
                    e.Graphics.FillRectangle(b, new Rectangle(i * sample_width, canvas.Height - (int)size, sample_width, (int)size));
                    e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(i * sample_width, canvas.Height - (int)size, sample_width, (int)size));
                }
            }

            e.Graphics.DrawLines(Pens.Blue, points.ToArray());
            
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;


            int samples_count = canvas.Width / sample_width;
            int lines_per_sample = diffs.Count / samples_count;

            int u = e.X * (lines_per_sample / sample_width);
            if (u < 0)
                return;

            GoToLogItem(e.X * (lines_per_sample / sample_width), true);
        }


    }
}
