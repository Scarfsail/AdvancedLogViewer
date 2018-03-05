using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Scarfsail.Common.UI
{
    public class DrawBackgroundImage
    {
        public DrawBackgroundImage(Control control)
        {
            this.control = control;
        }

        #region ------------- Public -------------------------

        public void RefreshCustomContentAsync()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.RefreshGraphics));
        }

        public void RefreshCustomContent()
        {
            this.RefreshGraphics(null);
        }

        public event DrawBackroundImageEventHandler DrawCustomContent;
        
        #endregion



        #region ------------- Protected ------------------------

        protected void OnDrawCustomContent(Graphics canvas)
        {
            if (this.DrawCustomContent != null)
                this.DrawCustomContent(this, new DrawBackroundImageEventArgs(canvas));
        }
        
        #endregion



        #region ------------- Private -------------------------
        
        private void RefreshGraphics(object stateInfo)
        {
            int width = control.Width;
            int height = control.Height;

            Bitmap bufferBitmap = this.GetBitmap(width, height); //It could be called in non UI thread (bitmap is drawn into bufferBitmap)

            control.BeginInvoke(new MethodInvoker(delegate() //Now we have to show our bufferBitmap on user's control (UI thread)
            {
                if (control.BackgroundImage != null)
                    control.BackgroundImage.Dispose();

                control.BackgroundImage = new Bitmap(width, height);

                Graphics graphics = Graphics.FromImage(control.BackgroundImage);
                graphics.DrawImageUnscaled(bufferBitmap, 0, 0);

                graphics.Dispose();
                bufferBitmap.Dispose(); //We have to dispose bufferBitmap now, because this is different thread (UI thread)

                control.Refresh(); //Refresh panel to show changes
            }));
        }

        private Bitmap GetBitmap(int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics canvas = Graphics.FromImage(result))
            {
                this.OnDrawCustomContent(canvas); //Event handler draws custom content to the canvas (bufferBitmap)
            }

            return result; //Bitmap has to be disposed by a caller
        }

        private Control control;

        #endregion
    }

    public class DrawBackroundImageEventArgs : EventArgs
    {
        public DrawBackroundImageEventArgs(Graphics canvas)
        {
            this.Canvas = canvas;
        }

        public Graphics Canvas { get; private set; }
    }

    public delegate void DrawBackroundImageEventHandler(object sender, DrawBackroundImageEventArgs e);
}
