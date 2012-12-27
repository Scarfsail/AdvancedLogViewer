namespace AdvancedLogViewer.UI.Controls.Filters
{
    partial class FilterSettingsMessage
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
            this.textEdit = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.regeExHelpLink = new System.Windows.Forms.LinkLabel();
            this.useRegexCheckBox = new System.Windows.Forms.CheckBox();
            this.hintLabel = new System.Windows.Forms.Label();
            this.textFromCurrentItemButton = new System.Windows.Forms.Button();
            this.includeItemsFromColorHighlightCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textEdit);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Size = new System.Drawing.Size(310, 229);
            this.groupBox1.Controls.SetChildIndex(this.panel1, 0);
            this.groupBox1.Controls.SetChildIndex(this.enabledCheckBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.textEdit, 0);
            // 
            // textEdit
            // 
            this.textEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEdit.Location = new System.Drawing.Point(3, 16);
            this.textEdit.Multiline = true;
            this.textEdit.Name = "textEdit";
            this.textEdit.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textEdit.Size = new System.Drawing.Size(304, 166);
            this.textEdit.TabIndex = 0;
            this.textEdit.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.regeExHelpLink);
            this.panel1.Controls.Add(this.useRegexCheckBox);
            this.panel1.Controls.Add(this.hintLabel);
            this.panel1.Controls.Add(this.textFromCurrentItemButton);
            this.panel1.Controls.Add(this.includeItemsFromColorHighlightCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 44);
            this.panel1.TabIndex = 1;
            // 
            // regeExHelpLink
            // 
            this.regeExHelpLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.regeExHelpLink.AutoSize = true;
            this.regeExHelpLink.Location = new System.Drawing.Point(287, 4);
            this.regeExHelpLink.Name = "regeExHelpLink";
            this.regeExHelpLink.Size = new System.Drawing.Size(13, 13);
            this.regeExHelpLink.TabIndex = 7;
            this.regeExHelpLink.TabStop = true;
            this.regeExHelpLink.Text = "?";
            this.regeExHelpLink.Visible = false;
            this.regeExHelpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.regeExHelpLink_LinkClicked);
            // 
            // useRegexCheckBox
            // 
            this.useRegexCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.useRegexCheckBox.AutoSize = true;
            this.useRegexCheckBox.Location = new System.Drawing.Point(233, 3);
            this.useRegexCheckBox.Name = "useRegexCheckBox";
            this.useRegexCheckBox.Size = new System.Drawing.Size(58, 17);
            this.useRegexCheckBox.TabIndex = 3;
            this.useRegexCheckBox.Text = "RegEx";
            this.useRegexCheckBox.UseVisualStyleBackColor = true;
            this.useRegexCheckBox.CheckedChanged += new System.EventHandler(this.useRegexCheckBox_CheckedChanged);
            // 
            // hintLabel
            // 
            this.hintLabel.AutoSize = true;
            this.hintLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.hintLabel.Location = new System.Drawing.Point(5, 4);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(180, 13);
            this.hintLabel.TabIndex = 6;
            this.hintLabel.Text = "Start line with: ~ to negate condition.";
            // 
            // textFromCurrentItemButton
            // 
            this.textFromCurrentItemButton.Location = new System.Drawing.Point(3, 19);
            this.textFromCurrentItemButton.Name = "textFromCurrentItemButton";
            this.textFromCurrentItemButton.Size = new System.Drawing.Size(99, 23);
            this.textFromCurrentItemButton.TabIndex = 5;
            this.textFromCurrentItemButton.Text = "Insert current item";
            this.textFromCurrentItemButton.UseVisualStyleBackColor = true;
            this.textFromCurrentItemButton.Click += new System.EventHandler(this.textFromCurrentItemButton_Click);
            // 
            // includeItemsFromColorHighlightCheckBox
            // 
            this.includeItemsFromColorHighlightCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.includeItemsFromColorHighlightCheckBox.AutoSize = true;
            this.includeItemsFromColorHighlightCheckBox.Location = new System.Drawing.Point(106, 23);
            this.includeItemsFromColorHighlightCheckBox.Name = "includeItemsFromColorHighlightCheckBox";
            this.includeItemsFromColorHighlightCheckBox.Size = new System.Drawing.Size(194, 17);
            this.includeItemsFromColorHighlightCheckBox.TabIndex = 0;
            this.includeItemsFromColorHighlightCheckBox.Text = "Include items from color highlight list";
            this.includeItemsFromColorHighlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterSettingsMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FilterSettingsMessage";
            this.Size = new System.Drawing.Size(310, 229);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox includeItemsFromColorHighlightCheckBox;
        private System.Windows.Forms.Button textFromCurrentItemButton;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.CheckBox useRegexCheckBox;
        private System.Windows.Forms.LinkLabel regeExHelpLink;

    }
}
