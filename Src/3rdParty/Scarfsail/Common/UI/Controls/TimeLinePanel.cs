using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace Scarfsail.Common.UI.Controls
{
    public partial class TimeLinePanel : UserControl
    {
        private DrawBackgroundImage drawBackround;
        private int hoursCount;
        private float secondsPerPixel;
        private Dictionary<int, int> minutePeaks;

        public TimeLinePanel()
        {
            InitializeComponent();
            this.Items = new List<TimeLineItem>();

            this.drawBackround = new DrawBackgroundImage(this.timeLineContainer);
            this.drawBackround.DrawCustomContent += new DrawBackroundImageEventHandler(drawBackround_DrawCustomContent);
            this.minutePeaks = new Dictionary<int, int>();
            this.minutePeaks.Add(60, 5);  // 1  2  3  4  5
            this.minutePeaks.Add(30, 5);  // 2  4  6  8  10
            this.minutePeaks.Add(20, 5);  // 3  6  9 12  15
            this.minutePeaks.Add(15, 5);  // 4  8 12 15 
            this.minutePeaks.Add(11, 4);  // 5 10 15 20
            this.minutePeaks.Add(10, 5);  // 6 12 18 24  30
            this.minutePeaks.Add(6, 3); //10 20 30
            this.minutePeaks.Add(4, 2); //15 30
            this.minutePeaks.Add(3, 0); //20
            this.minutePeaks.Add(2, 0); //30
            

            //Set default values
            this.PixelsPerHour = 600;
            this.ItemHeight = 30;
            this.ItemMargins = 5;
        }


        public int PixelsPerHour { get; set; }
        public int ItemHeight { get; set; }
        public int ItemMargins { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateStart { get; private set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateEnd {get; private set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TimeLineItem> Items { get; private set; }

        public void RefreshContent()
        {
            if (this.Items.Count == 0)
                return;

            //Calculate some basic stuff
            this.DateStart = this.Items.OrderBy(i => i.DateFrom).First().DateFrom;
            this.DateEnd = this.Items.OrderBy(i => i.DateTo).Last().DateTo;
            this.hoursCount = (int)(this.DateEnd - this.DateStart).TotalHours + 1;
            this.secondsPerPixel = 1.00F / ((float)this.PixelsPerHour / 3600);

            //Set Sizes
            this.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.itemsContainer.SuspendLayout();
            try
            {
                int width = this.PixelsPerHour * this.hoursCount +1;
                this.timeLineContainer.Width = width;
                this.bottomPanel.Width = width;
                this.itemsContainer.Width = width;
                this.itemsContainer.Height = (this.ItemHeight + this.ItemMargins) * this.Items.Count;


                //Draw time line (in another thread)
                this.drawBackround.RefreshCustomContentAsync();

                //Put items into timeline
                for (int i = 0; i < this.Items.Count; i++)
                {
                    TimeLineItem item = this.Items[i];

                    if (item.Element.Parent != this.itemsContainer)
                        item.Element.Parent = this.itemsContainer;
                    
                    item.Element.Top = (this.ItemHeight + this.ItemMargins) * i;
                    item.Element.Left = (int)((item.DateFrom - this.DateStart).TotalSeconds / this.secondsPerPixel);

                    item.Element.Size = new Size((int)((item.DateTo - item.DateFrom).TotalSeconds / this.secondsPerPixel), this.ItemHeight);
                }
            }
            finally
            {
                this.bottomPanel.ResumeLayout();
                this.itemsContainer.ResumeLayout();
                this.ResumeLayout();

            }

        }


        protected override void OnClientSizeChanged(EventArgs e)
        {
            //this.RefreshMarkersAsync();
            base.OnClientSizeChanged(e);
        }


        private void drawBackround_DrawCustomContent(object sender, DrawBackroundImageEventArgs e)
        {
            Graphics canvas = e.Canvas;
            canvas.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            //Draw timeline
            Pen pen = new Pen(Brushes.Black);
            Font font = new Font("Microsoft Sans Serif", 8);
            SolidBrush brush = new SolidBrush(Color.Black);
            float textHeight = canvas.MeasureString("yX", font).Height;

            const int minimumPixelsBetweenMinutes = 6;
            int numberOfMinutesToDraw = (int)((this.PixelsPerHour / minimumPixelsBetweenMinutes));
            numberOfMinutesToDraw = this.minutePeaks.Keys.Where(m => m <= numberOfMinutesToDraw).FirstOrDefault();
            int highlightMinute = 0;
            float pixelsBetweenMinutes = 0;
            if (numberOfMinutesToDraw > 0)
            {
                highlightMinute = this.minutePeaks[numberOfMinutesToDraw];
                pixelsBetweenMinutes = (float)PixelsPerHour / numberOfMinutesToDraw;
            }

            for (int hour = 0; hour <= this.hoursCount; hour++)
            {
                DateTime whereWeAre = this.DateStart.AddHours(hour);
                
                float positionX = this.PixelsPerHour * hour;
                float positionY = 0;
                float textPositionX = positionX;


                if (whereWeAre.Hour == 0 || hour == 0)
                {
                    //Draw day text
                    string dateTxt = whereWeAre.ToShortDateString();
                    canvas.DrawString(dateTxt, font, brush, new PointF(positionX, positionY));
                    /*
                    //Draw day line
                    pen.Width = 2;
                    pen.Color = Color.Blue;
                    canvas.DrawLine(pen, positionX, positionY, positionX, positionY + 10);
                    */
                }

                positionY = textHeight;

                //Draw hour text                               
                string hourTxt = whereWeAre.ToString("HH");
                //SizeF textSize = canvas.MeasureString(hourTxt, font);
                //textPositionX = (int)(positionX - (textSize.Width / 2));
                canvas.DrawString(hourTxt, font, brush, new PointF(positionX-1, positionY));

                //Draw hour line
                positionY = positionY + textHeight + 2;
                pen.Color = Color.Black;
                canvas.DrawLine(pen, positionX, positionY, positionX, positionY + 5);
                
                //Draw minute lines
                int highilightCounter = 0;
                pen.Color = Color.DarkGray;
                for (int i = 0; i < numberOfMinutesToDraw-1; i++)
                {
                    highilightCounter++;
                    if (highilightCounter == highlightMinute)
                    {
                        highilightCounter = 0;
                        pen.Width = 2;
                    }
                    else
                    {
                        pen.Width = 1;
                    }
                    positionX += pixelsBetweenMinutes;

                    canvas.DrawLine(pen, positionX, positionY, positionX, positionY + 5);
                }

            }

        }
    }

    public class TimeLineItem
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Control Element { get; set; }
    }


}
