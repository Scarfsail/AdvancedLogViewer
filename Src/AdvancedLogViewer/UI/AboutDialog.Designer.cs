namespace AdvancedLogViewer.UI
{
    partial class AboutDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.productAuthorLabel = new System.Windows.Forms.Label();
            this.productVersionLabel = new System.Windows.Forms.Label();
            this.webLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.usersConfigurationLocationLabel = new System.Windows.Forms.Label();
            this.ForumLink = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.productIconPicture = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productIconPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 38);
            this.panel1.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(110, 7);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.productNameLabel.Location = new System.Drawing.Point(75, 12);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(85, 13);
            this.productNameLabel.TabIndex = 1;
            this.productNameLabel.Text = "Product name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Author:";
            // 
            // productAuthorLabel
            // 
            this.productAuthorLabel.AutoSize = true;
            this.productAuthorLabel.Location = new System.Drawing.Point(122, 55);
            this.productAuthorLabel.Name = "productAuthorLabel";
            this.productAuthorLabel.Size = new System.Drawing.Size(74, 13);
            this.productAuthorLabel.TabIndex = 5;
            this.productAuthorLabel.Text = "Author\'s name";
            // 
            // productVersionLabel
            // 
            this.productVersionLabel.AutoSize = true;
            this.productVersionLabel.Location = new System.Drawing.Point(122, 31);
            this.productVersionLabel.Name = "productVersionLabel";
            this.productVersionLabel.Size = new System.Drawing.Size(40, 13);
            this.productVersionLabel.TabIndex = 6;
            this.productVersionLabel.Text = "0.0.0.0";
            // 
            // webLinkLabel
            // 
            this.webLinkLabel.AutoSize = true;
            this.webLinkLabel.Location = new System.Drawing.Point(122, 72);
            this.webLinkLabel.Name = "webLinkLabel";
            this.webLinkLabel.Size = new System.Drawing.Size(38, 13);
            this.webLinkLabel.TabIndex = 7;
            this.webLinkLabel.TabStop = true;
            this.webLinkLabel.Text = "Github";
            this.webLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.webLinkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Web:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "User\'s configuration is stored in:";
            // 
            // usersConfigurationLocationLabel
            // 
            this.usersConfigurationLocationLabel.Location = new System.Drawing.Point(12, 212);
            this.usersConfigurationLocationLabel.Name = "usersConfigurationLocationLabel";
            this.usersConfigurationLocationLabel.Size = new System.Drawing.Size(282, 26);
            this.usersConfigurationLocationLabel.TabIndex = 10;
            this.usersConfigurationLocationLabel.Text = "User\'s configuration is stored in: asdf sadf sadf sadf sadfsad fsad fasd fasf";
            // 
            // ForumLink
            // 
            this.ForumLink.AutoSize = true;
            this.ForumLink.Location = new System.Drawing.Point(175, 98);
            this.ForumLink.Name = "ForumLink";
            this.ForumLink.Size = new System.Drawing.Size(33, 13);
            this.ForumLink.TabIndex = 11;
            this.ForumLink.TabStop = true;
            this.ForumLink.Text = "forum";
            this.ForumLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forumLink_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "You can put your feedback in the";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "on the web.";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(283, 35);
            this.label7.TabIndex = 14;
            this.label7.Text = "This application is absolutely free for private and also for commercial use.";
            // 
            // productIconPicture
            // 
            this.productIconPicture.Location = new System.Drawing.Point(15, 12);
            this.productIconPicture.Name = "productIconPicture";
            this.productIconPicture.Size = new System.Drawing.Size(32, 32);
            this.productIconPicture.TabIndex = 4;
            this.productIconPicture.TabStop = false;
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(294, 289);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ForumLink);
            this.Controls.Add(this.usersConfigurationLocationLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webLinkLabel);
            this.Controls.Add(this.productVersionLabel);
            this.Controls.Add(this.productAuthorLabel);
            this.Controls.Add(this.productIconPicture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productIconPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox productIconPicture;
        private System.Windows.Forms.Label productAuthorLabel;
        private System.Windows.Forms.Label productVersionLabel;
        private System.Windows.Forms.LinkLabel webLinkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label usersConfigurationLocationLabel;
        private System.Windows.Forms.LinkLabel ForumLink;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}