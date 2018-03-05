namespace Scarfsail.Common.UI.Controls
{
    partial class TimeLinePanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timeLineContainer = new System.Windows.Forms.Panel();
            this.itemsContainer = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeLineContainer
            // 
            this.timeLineContainer.Location = new System.Drawing.Point(0, 0);
            this.timeLineContainer.Name = "timeLineContainer";
            this.timeLineContainer.Size = new System.Drawing.Size(272, 34);
            this.timeLineContainer.TabIndex = 0;
            // 
            // itemsContainer
            // 
            this.itemsContainer.Location = new System.Drawing.Point(0, 0);
            this.itemsContainer.Name = "itemsContainer";
            this.itemsContainer.Size = new System.Drawing.Size(431, 40);
            this.itemsContainer.TabIndex = 1;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.bottomPanel.AutoScroll = true;
            this.bottomPanel.Controls.Add(this.itemsContainer);
            this.bottomPanel.Location = new System.Drawing.Point(0, 35);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(435, 160);
            this.bottomPanel.TabIndex = 2;
            // 
            // TimeLinePanel
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.timeLineContainer);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimumSize = new System.Drawing.Size(0, 1);
            this.Name = "TimeLinePanel";
            this.Size = new System.Drawing.Size(456, 195);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel timeLineContainer;
        private System.Windows.Forms.Panel itemsContainer;
        private System.Windows.Forms.Panel bottomPanel;


    }
}
