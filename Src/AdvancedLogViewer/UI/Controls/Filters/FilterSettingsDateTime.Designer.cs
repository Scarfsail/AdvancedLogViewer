namespace AdvancedLogViewer.UI.Controls.Filters
{
    partial class FilterSettingsDateTime
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
            this.timeToNowButton = new System.Windows.Forms.Button();
            this.timeFromNowButton = new System.Windows.Forms.Button();
            this.dateTimeToCheckBox = new System.Windows.Forms.CheckBox();
            this.dateTimeFromCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeTo = new Scarfsail.Common.UI.Controls.DateTimeEdit();
            this.dateTimeFrom = new Scarfsail.Common.UI.Controls.DateTimeEdit();
            this.timeFromCurrentItemButton = new System.Windows.Forms.Button();
            this.timeToCurrentItemButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.timeToCurrentItemButton);
            this.groupBox1.Controls.Add(this.timeFromCurrentItemButton);
            this.groupBox1.Controls.Add(this.timeToNowButton);
            this.groupBox1.Controls.Add(this.timeFromNowButton);
            this.groupBox1.Controls.Add(this.dateTimeToCheckBox);
            this.groupBox1.Controls.Add(this.dateTimeFromCheckBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimeTo);
            this.groupBox1.Controls.Add(this.dateTimeFrom);
            this.groupBox1.Size = new System.Drawing.Size(180, 233);
            this.groupBox1.Controls.SetChildIndex(this.enabledCheckBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.dateTimeFrom, 0);
            this.groupBox1.Controls.SetChildIndex(this.dateTimeTo, 0);
            this.groupBox1.Controls.SetChildIndex(this.label4, 0);
            this.groupBox1.Controls.SetChildIndex(this.dateTimeFromCheckBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.dateTimeToCheckBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.timeFromNowButton, 0);
            this.groupBox1.Controls.SetChildIndex(this.timeToNowButton, 0);
            this.groupBox1.Controls.SetChildIndex(this.timeFromCurrentItemButton, 0);
            this.groupBox1.Controls.SetChildIndex(this.timeToCurrentItemButton, 0);
            this.groupBox1.Controls.SetChildIndex(this.label1, 0);
            // 
            // timeToNowButton
            // 
            this.timeToNowButton.Location = new System.Drawing.Point(11, 132);
            this.timeToNowButton.Name = "timeToNowButton";
            this.timeToNowButton.Size = new System.Drawing.Size(71, 23);
            this.timeToNowButton.TabIndex = 6;
            this.timeToNowButton.Text = "Now";
            this.timeToNowButton.UseVisualStyleBackColor = true;
            this.timeToNowButton.Click += new System.EventHandler(this.timeToNowButton_Click);
            // 
            // timeFromNowButton
            // 
            this.timeFromNowButton.Location = new System.Drawing.Point(11, 61);
            this.timeFromNowButton.Name = "timeFromNowButton";
            this.timeFromNowButton.Size = new System.Drawing.Size(71, 23);
            this.timeFromNowButton.TabIndex = 2;
            this.timeFromNowButton.Text = "Now";
            this.timeFromNowButton.UseVisualStyleBackColor = true;
            this.timeFromNowButton.Click += new System.EventHandler(this.timeFromNowButton_Click);
            // 
            // dateTimeToCheckBox
            // 
            this.dateTimeToCheckBox.AutoSize = true;
            this.dateTimeToCheckBox.Location = new System.Drawing.Point(10, 91);
            this.dateTimeToCheckBox.Name = "dateTimeToCheckBox";
            this.dateTimeToCheckBox.Size = new System.Drawing.Size(42, 17);
            this.dateTimeToCheckBox.TabIndex = 4;
            this.dateTimeToCheckBox.Text = "To:";
            this.dateTimeToCheckBox.UseVisualStyleBackColor = true;
            this.dateTimeToCheckBox.CheckedChanged += new System.EventHandler(this.dateTimeToCheckBox_CheckedChanged);
            // 
            // dateTimeFromCheckBox
            // 
            this.dateTimeFromCheckBox.AutoSize = true;
            this.dateTimeFromCheckBox.Location = new System.Drawing.Point(10, 20);
            this.dateTimeFromCheckBox.Name = "dateTimeFromCheckBox";
            this.dateTimeFromCheckBox.Size = new System.Drawing.Size(52, 17);
            this.dateTimeFromCheckBox.TabIndex = 0;
            this.dateTimeFromCheckBox.Text = "From:";
            this.dateTimeFromCheckBox.UseVisualStyleBackColor = true;
            this.dateTimeFromCheckBox.CheckedChanged += new System.EventHandler(this.dateTimeFromCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(11, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 31);
            this.label4.TabIndex = 8;
            this.label4.Text = "Show only items which are in this timeframe.";
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.Location = new System.Drawing.Point(11, 110);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(160, 20);
            this.dateTimeTo.TabIndex = 5;
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Location = new System.Drawing.Point(11, 39);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(160, 20);
            this.dateTimeFrom.TabIndex = 1;
            // 
            // timeFromCurrentItemButton
            // 
            this.timeFromCurrentItemButton.Location = new System.Drawing.Point(100, 61);
            this.timeFromCurrentItemButton.Name = "timeFromCurrentItemButton";
            this.timeFromCurrentItemButton.Size = new System.Drawing.Size(71, 23);
            this.timeFromCurrentItemButton.TabIndex = 3;
            this.timeFromCurrentItemButton.Text = "Current item";
            this.timeFromCurrentItemButton.UseVisualStyleBackColor = true;
            this.timeFromCurrentItemButton.Click += new System.EventHandler(this.timeFromCurrentItemButton_Click);
            // 
            // timeToCurrentItemButton
            // 
            this.timeToCurrentItemButton.Location = new System.Drawing.Point(100, 132);
            this.timeToCurrentItemButton.Name = "timeToCurrentItemButton";
            this.timeToCurrentItemButton.Size = new System.Drawing.Size(71, 23);
            this.timeToCurrentItemButton.TabIndex = 7;
            this.timeToCurrentItemButton.Text = "Current item";
            this.timeToCurrentItemButton.UseVisualStyleBackColor = true;
            this.timeToCurrentItemButton.Click += new System.EventHandler(this.timeToCurrentItemButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(11, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Note: This filter is autonomous\r\n(is enabled / disabled separately)";
            // 
            // FilterSettingsDateTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FilterSettingsDateTime";
            this.Size = new System.Drawing.Size(180, 233);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button timeToNowButton;
        private System.Windows.Forms.Button timeFromNowButton;
        private System.Windows.Forms.CheckBox dateTimeToCheckBox;
        private System.Windows.Forms.CheckBox dateTimeFromCheckBox;
        private System.Windows.Forms.Label label4;
        private Scarfsail.Common.UI.Controls.DateTimeEdit dateTimeTo;
        private Scarfsail.Common.UI.Controls.DateTimeEdit dateTimeFrom;
        private System.Windows.Forms.Button timeToCurrentItemButton;
        private System.Windows.Forms.Button timeFromCurrentItemButton;
        private System.Windows.Forms.Label label1;
    }
}
