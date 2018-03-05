namespace Scarfsail.SoftwareUpdates.UI
{
    partial class NewVersionFoundDialog
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateButton = new System.Windows.Forms.Button();
            this.newVersionReleasedLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.installedVersionLabel = new System.Windows.Forms.Label();
            this.newVersionLabel = new System.Windows.Forms.Label();
            this.whatsNewLinkLabel = new System.Windows.Forms.LinkLabel();
            this.updateTypeLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cancelButton.Location = new System.Drawing.Point(356, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.updateButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 39);
            this.panel1.TabIndex = 2;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.updateButton.Location = new System.Drawing.Point(264, 8);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // newVersionReleasedLabel
            // 
            this.newVersionReleasedLabel.AutoSize = true;
            this.newVersionReleasedLabel.Location = new System.Drawing.Point(11, 10);
            this.newVersionReleasedLabel.Name = "newVersionReleasedLabel";
            this.newVersionReleasedLabel.Size = new System.Drawing.Size(163, 13);
            this.newVersionReleasedLabel.TabIndex = 3;
            this.newVersionReleasedLabel.Text = "New version of {0} was released.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Installed version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "New version:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(293, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Do you want to update your application to the latest version?";
            // 
            // installedVersionLabel
            // 
            this.installedVersionLabel.AutoSize = true;
            this.installedVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.installedVersionLabel.Location = new System.Drawing.Point(97, 38);
            this.installedVersionLabel.Name = "installedVersionLabel";
            this.installedVersionLabel.Size = new System.Drawing.Size(31, 13);
            this.installedVersionLabel.TabIndex = 7;
            this.installedVersionLabel.Text = "0.0.0";
            // 
            // newVersionLabel
            // 
            this.newVersionLabel.AutoSize = true;
            this.newVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newVersionLabel.Location = new System.Drawing.Point(97, 57);
            this.newVersionLabel.Name = "newVersionLabel";
            this.newVersionLabel.Size = new System.Drawing.Size(36, 13);
            this.newVersionLabel.TabIndex = 8;
            this.newVersionLabel.Text = "0.0.0";
            // 
            // whatsNewLinkLabel
            // 
            this.whatsNewLinkLabel.AutoSize = true;
            this.whatsNewLinkLabel.Location = new System.Drawing.Point(10, 80);
            this.whatsNewLinkLabel.Name = "whatsNewLinkLabel";
            this.whatsNewLinkLabel.Size = new System.Drawing.Size(197, 13);
            this.whatsNewLinkLabel.TabIndex = 9;
            this.whatsNewLinkLabel.TabStop = true;
            this.whatsNewLinkLabel.Text = "See what\'s new against installed version";
            this.whatsNewLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.whatsNewLinkLabel_LinkClicked);
            // 
            // updateTypeLabel
            // 
            this.updateTypeLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.updateTypeLabel.Location = new System.Drawing.Point(10, 103);
            this.updateTypeLabel.Name = "updateTypeLabel";
            this.updateTypeLabel.Size = new System.Drawing.Size(431, 28);
            this.updateTypeLabel.TabIndex = 11;
            this.updateTypeLabel.Text = "UpdateType";
            // 
            // NewVersionFoundDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(443, 202);
            this.Controls.Add(this.updateTypeLabel);
            this.Controls.Add(this.whatsNewLinkLabel);
            this.Controls.Add(this.newVersionLabel);
            this.Controls.Add(this.installedVersionLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newVersionReleasedLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewVersionFoundDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New version found ...";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label newVersionReleasedLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label installedVersionLabel;
        private System.Windows.Forms.Label newVersionLabel;
        private System.Windows.Forms.LinkLabel whatsNewLinkLabel;
        private System.Windows.Forms.Label updateTypeLabel;
    }
}