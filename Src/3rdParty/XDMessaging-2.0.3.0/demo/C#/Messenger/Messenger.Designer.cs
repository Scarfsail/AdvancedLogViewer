namespace TheCodeKing.Demo
{
    partial class Messenger
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
            this.propagateCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusCheckBox = new System.Windows.Forms.CheckBox();
            this.channel1Check = new System.Windows.Forms.CheckBox();
            this.channel2Check = new System.Windows.Forms.CheckBox();
            this.Mode = new System.Windows.Forms.GroupBox();
            this.mailRadio = new System.Windows.Forms.RadioButton();
            this.ioStreamRadio = new System.Windows.Forms.RadioButton();
            this.wmRadio = new System.Windows.Forms.RadioButton();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.displayTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Mode.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.propagateCheck);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Mode);
            this.panel1.Controls.Add(this.inputTextBox);
            this.panel1.Controls.Add(this.sendBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 157);
            this.panel1.TabIndex = 2;
            // 
            // propagateCheck
            // 
            this.propagateCheck.AutoSize = true;
            this.propagateCheck.Checked = true;
            this.propagateCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.propagateCheck.Location = new System.Drawing.Point(13, 128);
            this.propagateCheck.Name = "propagateCheck";
            this.propagateCheck.Size = new System.Drawing.Size(269, 17);
            this.propagateCheck.TabIndex = 3;
            this.propagateCheck.Text = "Propagate messages to local Workgroup or Domain";
            this.propagateCheck.UseVisualStyleBackColor = true;
            this.propagateCheck.CheckedChanged += new System.EventHandler(this.propagateCheck_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusCheckBox);
            this.groupBox1.Controls.Add(this.channel1Check);
            this.groupBox1.Controls.Add(this.channel2Check);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channels";
            // 
            // statusCheckBox
            // 
            this.statusCheckBox.Checked = true;
            this.statusCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusCheckBox.Location = new System.Drawing.Point(15, 63);
            this.statusCheckBox.Name = "statusCheckBox";
            this.statusCheckBox.Size = new System.Drawing.Size(61, 18);
            this.statusCheckBox.TabIndex = 5;
            this.statusCheckBox.Text = "Status";
            this.statusCheckBox.UseVisualStyleBackColor = true;
            this.statusCheckBox.Click += new System.EventHandler(this.statusChannel_CheckedChanged);
            // 
            // channel1Check
            // 
            this.channel1Check.Checked = true;
            this.channel1Check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.channel1Check.Location = new System.Drawing.Point(15, 18);
            this.channel1Check.Name = "channel1Check";
            this.channel1Check.Size = new System.Drawing.Size(94, 17);
            this.channel1Check.TabIndex = 3;
            this.channel1Check.Text = "Channel 1";
            this.channel1Check.UseVisualStyleBackColor = true;
            this.channel1Check.Click += new System.EventHandler(this.channel1_CheckedChanged);
            // 
            // channel2Check
            // 
            this.channel2Check.Location = new System.Drawing.Point(15, 41);
            this.channel2Check.Name = "channel2Check";
            this.channel2Check.Size = new System.Drawing.Size(94, 17);
            this.channel2Check.TabIndex = 4;
            this.channel2Check.Text = "Channel 2";
            this.channel2Check.UseVisualStyleBackColor = true;
            this.channel2Check.Click += new System.EventHandler(this.channel2_CheckedChanged);
            // 
            // Mode
            // 
            this.Mode.Controls.Add(this.mailRadio);
            this.Mode.Controls.Add(this.ioStreamRadio);
            this.Mode.Controls.Add(this.wmRadio);
            this.Mode.Location = new System.Drawing.Point(148, 35);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(130, 90);
            this.Mode.TabIndex = 0;
            this.Mode.TabStop = false;
            this.Mode.Text = "Mode";
            // 
            // mailRadio
            // 
            this.mailRadio.AutoSize = true;
            this.mailRadio.Location = new System.Drawing.Point(15, 64);
            this.mailRadio.Name = "mailRadio";
            this.mailRadio.Size = new System.Drawing.Size(65, 17);
            this.mailRadio.TabIndex = 8;
            this.mailRadio.TabStop = true;
            this.mailRadio.Text = "Mail Slot";
            this.mailRadio.UseVisualStyleBackColor = true;
            this.mailRadio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mailRadio_MouseClick);
            this.mailRadio.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // ioStreamRadio
            // 
            this.ioStreamRadio.AutoSize = true;
            this.ioStreamRadio.Location = new System.Drawing.Point(15, 41);
            this.ioStreamRadio.Name = "ioStreamRadio";
            this.ioStreamRadio.Size = new System.Drawing.Size(72, 17);
            this.ioStreamRadio.TabIndex = 7;
            this.ioStreamRadio.TabStop = true;
            this.ioStreamRadio.Text = "IO Stream";
            this.ioStreamRadio.UseVisualStyleBackColor = true;
            this.ioStreamRadio.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // wmRadio
            // 
            this.wmRadio.AutoSize = true;
            this.wmRadio.Checked = true;
            this.wmRadio.Location = new System.Drawing.Point(15, 18);
            this.wmRadio.Name = "wmRadio";
            this.wmRadio.Size = new System.Drawing.Size(67, 17);
            this.wmRadio.TabIndex = 6;
            this.wmRadio.TabStop = true;
            this.wmRadio.Text = "Win Msg";
            this.wmRadio.UseVisualStyleBackColor = true;
            this.wmRadio.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(13, 6);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(178, 20);
            this.inputTextBox.TabIndex = 1;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(197, 6);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(80, 23);
            this.sendBtn.TabIndex = 2;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // displayTextBox
            // 
            this.displayTextBox.BackColor = System.Drawing.Color.White;
            this.displayTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayTextBox.Location = new System.Drawing.Point(0, 0);
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.ReadOnly = true;
            this.displayTextBox.Size = new System.Drawing.Size(289, 247);
            this.displayTextBox.TabIndex = 4;
            this.displayTextBox.TabStop = false;
            this.displayTextBox.Text = "";
            // 
            // Messenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 404);
            this.Controls.Add(this.displayTextBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Messenger";
            this.Text = "XDMessaging Demo";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.Mode.ResumeLayout(false);
            this.Mode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.RichTextBox displayTextBox;
        private System.Windows.Forms.GroupBox Mode;
        private System.Windows.Forms.RadioButton ioStreamRadio;
        private System.Windows.Forms.RadioButton wmRadio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox statusCheckBox;
        private System.Windows.Forms.CheckBox channel2Check;
        private System.Windows.Forms.RadioButton mailRadio;
        private System.Windows.Forms.CheckBox channel1Check;
        private System.Windows.Forms.CheckBox propagateCheck;

    }
}

