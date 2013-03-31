namespace AdvancedLogViewer.UI
{
    partial class FindTextDlg
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.findPrevButton = new System.Windows.Forms.Button();
            this.closelButton = new System.Windows.Forms.Button();
            this.findNextButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.findInCombo = new System.Windows.Forms.ComboBox();
            this.caseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.useRegExCheckBox = new System.Windows.Forms.CheckBox();
            this.findWhatCombo = new System.Windows.Forms.ComboBox();
            this.dockedCheckBox = new System.Windows.Forms.CheckBox();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.statusLabel);
            this.bottomPanel.Controls.Add(this.findPrevButton);
            this.bottomPanel.Controls.Add(this.closelButton);
            this.bottomPanel.Controls.Add(this.findNextButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 52);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(401, 31);
            this.bottomPanel.TabIndex = 6;
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(3, 2);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(175, 26);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // findPrevButton
            // 
            this.findPrevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findPrevButton.Location = new System.Drawing.Point(187, 5);
            this.findPrevButton.Name = "findPrevButton";
            this.findPrevButton.Size = new System.Drawing.Size(61, 23);
            this.findPrevButton.TabIndex = 1;
            this.findPrevButton.Text = "Find &prev";
            this.findPrevButton.UseVisualStyleBackColor = true;
            this.findPrevButton.Click += new System.EventHandler(this.findPrevButton_Click);
            // 
            // closelButton
            // 
            this.closelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closelButton.Location = new System.Drawing.Point(331, 5);
            this.closelButton.Name = "closelButton";
            this.closelButton.Size = new System.Drawing.Size(61, 23);
            this.closelButton.TabIndex = 3;
            this.closelButton.Text = "Close";
            this.closelButton.UseVisualStyleBackColor = true;
            this.closelButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // findNextButton
            // 
            this.findNextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findNextButton.Location = new System.Drawing.Point(254, 5);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(61, 23);
            this.findNextButton.TabIndex = 2;
            this.findNextButton.Text = "Find &next";
            this.findNextButton.UseVisualStyleBackColor = true;
            this.findNextButton.Click += new System.EventHandler(this.findNextButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Find in:";
            // 
            // findInCombo
            // 
            this.findInCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.findInCombo.FormattingEnabled = true;
            this.findInCombo.Location = new System.Drawing.Point(60, 29);
            this.findInCombo.Name = "findInCombo";
            this.findInCombo.Size = new System.Drawing.Size(93, 21);
            this.findInCombo.TabIndex = 3;
            this.findInCombo.SelectedValueChanged += new System.EventHandler(this.findInCombo_SelectedValueChanged);
            // 
            // caseSensitiveCheckBox
            // 
            this.caseSensitiveCheckBox.AutoSize = true;
            this.caseSensitiveCheckBox.Location = new System.Drawing.Point(239, 32);
            this.caseSensitiveCheckBox.Name = "caseSensitiveCheckBox";
            this.caseSensitiveCheckBox.Size = new System.Drawing.Size(94, 17);
            this.caseSensitiveCheckBox.TabIndex = 5;
            this.caseSensitiveCheckBox.Text = "&Case sensitive";
            this.caseSensitiveCheckBox.UseVisualStyleBackColor = true;
            this.caseSensitiveCheckBox.CheckedChanged += new System.EventHandler(this.SearchConditionsChanged);
            // 
            // useRegExCheckBox
            // 
            this.useRegExCheckBox.AutoSize = true;
            this.useRegExCheckBox.Location = new System.Drawing.Point(159, 32);
            this.useRegExCheckBox.Name = "useRegExCheckBox";
            this.useRegExCheckBox.Size = new System.Drawing.Size(80, 17);
            this.useRegExCheckBox.TabIndex = 4;
            this.useRegExCheckBox.Text = "Use Reg&Ex";
            this.useRegExCheckBox.UseVisualStyleBackColor = true;
            this.useRegExCheckBox.CheckedChanged += new System.EventHandler(this.SearchConditionsChanged);
            // 
            // findWhatCombo
            // 
            this.findWhatCombo.FormattingEnabled = true;
            this.findWhatCombo.Location = new System.Drawing.Point(60, 4);
            this.findWhatCombo.Name = "findWhatCombo";
            this.findWhatCombo.Size = new System.Drawing.Size(332, 21);
            this.findWhatCombo.TabIndex = 1;
            this.findWhatCombo.TextChanged += new System.EventHandler(this.SearchConditionsChanged);
            // 
            // dockedCheckBox
            // 
            this.dockedCheckBox.AutoSize = true;
            this.dockedCheckBox.Checked = true;
            this.dockedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dockedCheckBox.Location = new System.Drawing.Point(334, 32);
            this.dockedCheckBox.Name = "dockedCheckBox";
            this.dockedCheckBox.Size = new System.Drawing.Size(64, 17);
            this.dockedCheckBox.TabIndex = 7;
            this.dockedCheckBox.Text = "&Docked";
            this.dockedCheckBox.UseVisualStyleBackColor = true;
            this.dockedCheckBox.CheckedChanged += new System.EventHandler(this.dockedCheckBox_CheckedChanged);
            // 
            // FindTextDlg
            // 
            this.AcceptButton = this.findNextButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closelButton;
            this.ClientSize = new System.Drawing.Size(401, 83);
            this.Controls.Add(this.dockedCheckBox);
            this.Controls.Add(this.findWhatCombo);
            this.Controls.Add(this.useRegExCheckBox);
            this.Controls.Add(this.caseSensitiveCheckBox);
            this.Controls.Add(this.findInCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindTextDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find";
            this.Activated += new System.EventHandler(this.FindTextDlg_Activated);
            this.Deactivate += new System.EventHandler(this.FindTextDlg_Deactivate);
            this.Load += new System.EventHandler(this.FindTextDlg_Load);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button closelButton;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.Button findPrevButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox findInCombo;
        private System.Windows.Forms.CheckBox caseSensitiveCheckBox;
        private System.Windows.Forms.CheckBox useRegExCheckBox;
        private System.Windows.Forms.ComboBox findWhatCombo;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox dockedCheckBox;

    }
}