using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Scarfsail.Common.UI.Controls
{
    public partial class MarkerPanel : Control
    {
        public MarkerPanel()
        {
            InitializeComponent();
            this.drawBackround = new DrawBackgroundImage(this);
            this.drawBackround.DrawCustomContent += new DrawBackroundImageEventHandler(drawBackround_DrawCustomContent);
            //this.Markers = new Dictionary<int, Color>();
        }


        #region ------------- Public -------------------------

        /// <summary>
        /// Show markers in own thread
        /// </summary>
        /// <param name="totalLines">Total lines in the file</param>
        /// <param name="markers">Markers in the file (line, color)</param>
        public void ShowMarkersAsync(int totalLines, Dictionary<int, Color> markers)
        {
            this.TotalLines = totalLines;
            this.markers = markers;
            this.RefreshMarkersAsync();
        }

        /// <summary>
        /// Show markers on the panel, this method could be called in a non UI thread (it's thread safe)
        /// </summary>
        /// <param name="totalLines">Total lines in the file</param>
        /// <param name="markers">Markers in the file (line, color)</param>
        public void ShowMarkers(int totalLines, Dictionary<int, Color> markers)
        {
            this.TotalLines = totalLines;
            this.markers = markers;
            this.RefreshMarkers();           
        }

        /// <summary>
        /// Determines orientation of the control and markers (Horizontal or Vertical)
        /// </summary>
        public bool Horizontal 
        {
            get
            {
                return this.horizontal;
            }

            set
            {
                this.horizontal = value;
                this.RefreshMarkers();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TotalLines { get; private set; }

        public event MarkPanelClickEventHandler MarkClick;

        #endregion



        #region ------------- Protected -------------------------

        protected void OnMarkClick(int lineNumber)
        {
            if (this.MarkClick != null)
                this.MarkClick(this, new MarkPanelClickEventArgs(lineNumber));
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            this.RefreshMarkersAsync();
        }

        protected override void OnClick(EventArgs e)
        {
            if (this.markers == null || this.markers.Count == 0)
                return;

            int pos = this.horizontal ? this.PointToClient(Control.MousePosition).X : this.PointToClient(Control.MousePosition).Y;
            int pixels = this.horizontal ? this.Width : this.Height;

            int line = (int)(this.TotalLines > pixels ? pos * linesPerPixel : pos / linesPerPixel);

            int lt = this.markers.LastOrDefault(i => i.Key <= line).Key;
            int gt = this.markers.FirstOrDefault(i => i.Key >= line).Key;
            if (gt == 0)
                gt = this.markers.Last().Key;

            line = line - lt < gt - line ? lt : gt;

            this.OnMarkClick(line);
            
            base.OnClick(e);
        }

        #endregion


        #region ------------- Private -------------------------


        private void drawBackround_DrawCustomContent(object sender, DrawBackroundImageEventArgs e)
        {
            Graphics canvas = e.Canvas;

            int pixels = this.horizontal ? this.Width : this.Height;
            linesPerPixel = (this.TotalLines > pixels) ? ((float)this.TotalLines / pixels) : ((float)pixels / this.TotalLines);

            Pen pen = new Pen(Brushes.Red);

            foreach (var marker in this.markers)
            {
                pen.Color = marker.Value;
                int position = (int)(this.TotalLines > pixels ? marker.Key / linesPerPixel : marker.Key * linesPerPixel);
                if (position > pixels)
                    position = pixels;

                if (this.horizontal)
                    canvas.DrawLine(pen, position, 0, position, this.Height);
                else
                    canvas.DrawLine(pen, 0, position, this.Width, position);
            }

            if (this.Horizontal)
            {
                canvas.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
                canvas.DrawString(this.Text, new Font("Arial", 7), new SolidBrush(Color.FromArgb(100, 0, 0, 0)), new PointF(0, 0));
            }
        }
        
        
        private void RefreshMarkersAsync()  
        {
            if (this.markers == null || this.Parent==null)
                return;
            
            this.drawBackround.RefreshCustomContentAsync();
        }
                
        private void RefreshMarkers()
        {
            if (this.markers == null)
                return;

            this.drawBackround.RefreshCustomContent();
        }

        private DrawBackgroundImage drawBackround;
        private float linesPerPixel;
        private bool horizontal;

        /// <summary>
        /// Markers dictionary: Line, Color
        /// </summary>
        private Dictionary<int, Color> markers;

        #endregion
    }

    public class MarkPanelClickEventArgs : EventArgs
    {
        public MarkPanelClickEventArgs(int lineNumber)
        {
            this.LineNumber = lineNumber;
        }

        public int LineNumber { get; private set; }
    }

    public delegate void MarkPanelClickEventHandler(object sender, MarkPanelClickEventArgs e);

}
