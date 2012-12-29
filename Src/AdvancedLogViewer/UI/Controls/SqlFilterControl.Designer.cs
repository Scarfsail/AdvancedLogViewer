namespace AdvancedLogViewer.UI.Controls
{
    partial class SqlFilterControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.availableColumnsListBox = new System.Windows.Forms.ListBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.executeButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.queryEditor = new Sarfsail.Common.UI.SyntaxHighlighter.SyntaxHighlightingTextBox();
            this.groupBox1.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.availableColumnsListBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.groupBox1.Size = new System.Drawing.Size(130, 251);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available columns";
            // 
            // availableColumnsListBox
            // 
            this.availableColumnsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.availableColumnsListBox.FormattingEnabled = true;
            this.availableColumnsListBox.IntegralHeight = false;
            this.availableColumnsListBox.Location = new System.Drawing.Point(2, 13);
            this.availableColumnsListBox.Name = "availableColumnsListBox";
            this.availableColumnsListBox.Size = new System.Drawing.Size(126, 238);
            this.availableColumnsListBox.TabIndex = 5;
            this.availableColumnsListBox.DoubleClick += new System.EventHandler(this.availableColumnsListBox_DoubleClick);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.statusLabel);
            this.bottomPanel.Controls.Add(this.executeButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomPanel.Location = new System.Drawing.Point(2, 13);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(374, 26);
            this.bottomPanel.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(84, 6);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "status";
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(3, 1);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(76, 23);
            this.executeButton.TabIndex = 0;
            this.executeButton.Text = "Execute (F5)";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.queryEditor);
            this.groupBox2.Controls.Add(this.bottomPanel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(133, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.groupBox2.Size = new System.Drawing.Size(378, 251);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SQL Where condition";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(130, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 251);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // queryEditor
            // 
            this.queryEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryEditor.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.queryEditor.HideSelection = false;
            this.queryEditor.Location = new System.Drawing.Point(2, 39);
            this.queryEditor.Name = "queryEditor";
            this.queryEditor.Size = new System.Drawing.Size(374, 212);
            this.queryEditor.TabIndex = 0;
            this.queryEditor.Text = "";
            this.queryEditor.TextChanged += new System.EventHandler(this.queryEditor_TextChanged);
            this.queryEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.queryEditor_KeyDown);
            // 
            // SqlFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SqlFilterControl";
            this.Size = new System.Drawing.Size(511, 251);
            this.groupBox1.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Sarfsail.Common.UI.SyntaxHighlighter.SyntaxHighlightingTextBox queryEditor;
        private System.Windows.Forms.ListBox availableColumnsListBox;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label statusLabel;
    }
}
