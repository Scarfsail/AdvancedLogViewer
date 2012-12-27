namespace AdvancedLogViewer.UI
{
    partial class ManageParserPatterns
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
            this.components = new System.ComponentModel.Container();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.viewCurrentLogAsTextButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.customPatternsListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.addNewButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.systemPatternsListBox = new System.Windows.Forms.ListBox();
            this.createCopyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fileMaskEdit = new System.Windows.Forms.TextBox();
            this.patternEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFormatEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fileMaskError = new System.Windows.Forms.ErrorProvider(this.components);
            this.patternError = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateFormatError = new System.Windows.Forms.ErrorProvider(this.components);
            this.editSelectedPatternGroupBox = new System.Windows.Forms.GroupBox();
            this.tryOnCurrentLogButton = new System.Windows.Forms.Button();
            this.dateFormatPatternsListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.patternTextPatternsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileMaskError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patternError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFormatError)).BeginInit();
            this.editSelectedPatternGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.viewCurrentLogAsTextButton);
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.okButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 499);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(663, 39);
            this.bottomPanel.TabIndex = 3;
            // 
            // viewCurrentLogAsTextButton
            // 
            this.viewCurrentLogAsTextButton.Location = new System.Drawing.Point(10, 8);
            this.viewCurrentLogAsTextButton.Name = "viewCurrentLogAsTextButton";
            this.viewCurrentLogAsTextButton.Size = new System.Drawing.Size(179, 23);
            this.viewCurrentLogAsTextButton.TabIndex = 15;
            this.viewCurrentLogAsTextButton.Text = "View part of current log as a text";
            this.viewCurrentLogAsTextButton.UseVisualStyleBackColor = true;
            this.viewCurrentLogAsTextButton.Click += new System.EventHandler(this.viewCurrentLogAsTextButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(570, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(466, 8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // customPatternsListBox
            // 
            this.customPatternsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPatternsListBox.FormattingEnabled = true;
            this.customPatternsListBox.Location = new System.Drawing.Point(3, 16);
            this.customPatternsListBox.Name = "customPatternsListBox";
            this.customPatternsListBox.Size = new System.Drawing.Size(202, 228);
            this.customPatternsListBox.TabIndex = 4;
            this.customPatternsListBox.SelectedIndexChanged += new System.EventHandler(this.customPatternsListBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 499);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customPatternsListBox);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 305);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom patterns";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.removeButton);
            this.panel2.Controls.Add(this.addNewButton);
            this.panel2.Controls.Add(this.moveDownButton);
            this.panel2.Controls.Add(this.moveUpButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 244);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 58);
            this.panel2.TabIndex = 5;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(7, 32);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addNewButton
            // 
            this.addNewButton.Location = new System.Drawing.Point(7, 3);
            this.addNewButton.Name = "addNewButton";
            this.addNewButton.Size = new System.Drawing.Size(75, 23);
            this.addNewButton.TabIndex = 2;
            this.addNewButton.Text = "Add new";
            this.addNewButton.UseVisualStyleBackColor = true;
            this.addNewButton.Click += new System.EventHandler(this.addNewButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownButton.Location = new System.Drawing.Point(117, 32);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(75, 23);
            this.moveDownButton.TabIndex = 1;
            this.moveDownButton.Text = "Move down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpButton.Location = new System.Drawing.Point(117, 3);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(75, 23);
            this.moveUpButton.TabIndex = 0;
            this.moveUpButton.Text = "Move up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.systemPatternsListBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 194);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System patterns";
            // 
            // systemPatternsListBox
            // 
            this.systemPatternsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemPatternsListBox.FormattingEnabled = true;
            this.systemPatternsListBox.Location = new System.Drawing.Point(3, 16);
            this.systemPatternsListBox.Name = "systemPatternsListBox";
            this.systemPatternsListBox.Size = new System.Drawing.Size(202, 175);
            this.systemPatternsListBox.TabIndex = 4;
            this.systemPatternsListBox.SelectedIndexChanged += new System.EventHandler(this.systemPatternsListBox_SelectedIndexChanged);
            // 
            // createCopyButton
            // 
            this.createCopyButton.Location = new System.Drawing.Point(12, 466);
            this.createCopyButton.Name = "createCopyButton";
            this.createCopyButton.Size = new System.Drawing.Size(179, 23);
            this.createCopyButton.TabIndex = 3;
            this.createCopyButton.Text = "Create copy of this pattern";
            this.createCopyButton.UseVisualStyleBackColor = true;
            this.createCopyButton.Click += new System.EventHandler(this.createCopyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "File mask:";
            // 
            // fileMaskEdit
            // 
            this.fileMaskEdit.Location = new System.Drawing.Point(12, 36);
            this.fileMaskEdit.Name = "fileMaskEdit";
            this.fileMaskEdit.Size = new System.Drawing.Size(425, 20);
            this.fileMaskEdit.TabIndex = 7;
            this.fileMaskEdit.Validating += new System.ComponentModel.CancelEventHandler(this.fileMaskEdit_Validating);
            // 
            // patternEdit
            // 
            this.patternEdit.HideSelection = false;
            this.patternEdit.Location = new System.Drawing.Point(12, 112);
            this.patternEdit.Name = "patternEdit";
            this.patternEdit.Size = new System.Drawing.Size(425, 20);
            this.patternEdit.TabIndex = 9;
            this.patternEdit.Validating += new System.ComponentModel.CancelEventHandler(this.patternEdit_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pattern:";
            // 
            // dateFormatEdit
            // 
            this.dateFormatEdit.HideSelection = false;
            this.dateFormatEdit.Location = new System.Drawing.Point(12, 267);
            this.dateFormatEdit.Name = "dateFormatEdit";
            this.dateFormatEdit.Size = new System.Drawing.Size(425, 20);
            this.dateFormatEdit.TabIndex = 11;
            this.dateFormatEdit.Validating += new System.ComponentModel.CancelEventHandler(this.dateFormatEdit_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Date time format:";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(434, 37);
            this.label4.TabIndex = 12;
            this.label4.Text = "File mask (e.g.: MyLogFile.log*). . First pattern whose file mask match the log f" +
    "ile name will be used.";
            // 
            // fileMaskError
            // 
            this.fileMaskError.ContainerControl = this;
            // 
            // patternError
            // 
            this.patternError.ContainerControl = this;
            // 
            // dateFormatError
            // 
            this.dateFormatError.ContainerControl = this;
            // 
            // editSelectedPatternGroupBox
            // 
            this.editSelectedPatternGroupBox.Controls.Add(this.tryOnCurrentLogButton);
            this.editSelectedPatternGroupBox.Controls.Add(this.dateFormatPatternsListView);
            this.editSelectedPatternGroupBox.Controls.Add(this.patternTextPatternsListView);
            this.editSelectedPatternGroupBox.Controls.Add(this.patternEdit);
            this.editSelectedPatternGroupBox.Controls.Add(this.createCopyButton);
            this.editSelectedPatternGroupBox.Controls.Add(this.label1);
            this.editSelectedPatternGroupBox.Controls.Add(this.label4);
            this.editSelectedPatternGroupBox.Controls.Add(this.fileMaskEdit);
            this.editSelectedPatternGroupBox.Controls.Add(this.dateFormatEdit);
            this.editSelectedPatternGroupBox.Controls.Add(this.label2);
            this.editSelectedPatternGroupBox.Controls.Add(this.label3);
            this.editSelectedPatternGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editSelectedPatternGroupBox.Location = new System.Drawing.Point(208, 0);
            this.editSelectedPatternGroupBox.Name = "editSelectedPatternGroupBox";
            this.editSelectedPatternGroupBox.Size = new System.Drawing.Size(455, 499);
            this.editSelectedPatternGroupBox.TabIndex = 13;
            this.editSelectedPatternGroupBox.TabStop = false;
            this.editSelectedPatternGroupBox.Text = "Edit selected pattern";
            // 
            // tryOnCurrentLogButton
            // 
            this.tryOnCurrentLogButton.Location = new System.Drawing.Point(258, 466);
            this.tryOnCurrentLogButton.Name = "tryOnCurrentLogButton";
            this.tryOnCurrentLogButton.Size = new System.Drawing.Size(179, 23);
            this.tryOnCurrentLogButton.TabIndex = 2;
            this.tryOnCurrentLogButton.Text = "Try on current log";
            this.tryOnCurrentLogButton.UseVisualStyleBackColor = true;
            this.tryOnCurrentLogButton.Click += new System.EventHandler(this.tryOnCurrentLogButton_Click);
            // 
            // dateFormatPatternsListView
            // 
            this.dateFormatPatternsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.dateFormatPatternsListView.FullRowSelect = true;
            this.dateFormatPatternsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.dateFormatPatternsListView.Location = new System.Drawing.Point(12, 287);
            this.dateFormatPatternsListView.MultiSelect = false;
            this.dateFormatPatternsListView.Name = "dateFormatPatternsListView";
            this.dateFormatPatternsListView.Size = new System.Drawing.Size(425, 174);
            this.dateFormatPatternsListView.TabIndex = 14;
            this.dateFormatPatternsListView.UseCompatibleStateImageBehavior = false;
            this.dateFormatPatternsListView.View = System.Windows.Forms.View.Details;
            this.dateFormatPatternsListView.DoubleClick += new System.EventHandler(this.dateFormatPatternsListView_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Format pattern";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 300;
            // 
            // patternTextPatternsListView
            // 
            this.patternTextPatternsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.patternTextPatternsListView.FullRowSelect = true;
            this.patternTextPatternsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.patternTextPatternsListView.Location = new System.Drawing.Point(12, 132);
            this.patternTextPatternsListView.MultiSelect = false;
            this.patternTextPatternsListView.Name = "patternTextPatternsListView";
            this.patternTextPatternsListView.Size = new System.Drawing.Size(425, 107);
            this.patternTextPatternsListView.TabIndex = 13;
            this.patternTextPatternsListView.UseCompatibleStateImageBehavior = false;
            this.patternTextPatternsListView.View = System.Windows.Forms.View.Details;
            this.patternTextPatternsListView.DoubleClick += new System.EventHandler(this.patternTextPatternsListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Format pattern";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 300;
            // 
            // ManageParserPatterns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(663, 538);
            this.Controls.Add(this.editSelectedPatternGroupBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageParserPatterns";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage parser patterns";
            this.bottomPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileMaskError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patternError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFormatError)).EndInit();
            this.editSelectedPatternGroupBox.ResumeLayout(false);
            this.editSelectedPatternGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ListBox customPatternsListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addNewButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox systemPatternsListBox;
        private System.Windows.Forms.Button createCopyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileMaskEdit;
        private System.Windows.Forms.TextBox patternEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dateFormatEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider fileMaskError;
        private System.Windows.Forms.ErrorProvider patternError;
        private System.Windows.Forms.ErrorProvider dateFormatError;
        private System.Windows.Forms.GroupBox editSelectedPatternGroupBox;
        private System.Windows.Forms.ListView dateFormatPatternsListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView patternTextPatternsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button tryOnCurrentLogButton;
        private System.Windows.Forms.Button viewCurrentLogAsTextButton;
    }
}