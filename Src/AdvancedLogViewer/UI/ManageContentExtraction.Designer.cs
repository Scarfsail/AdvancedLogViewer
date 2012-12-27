namespace AdvancedLogViewer.UI
{
    partial class ManageContentExtraction
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.customExtractorsListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.addNewButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.createCopyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.extractorRegexEdit = new System.Windows.Forms.TextBox();
            this.extractorRegexError = new System.Windows.Forms.ErrorProvider(this.components);
            this.topGroupBox = new System.Windows.Forms.GroupBox();
            this.fileExtension = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.defaultActionCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.middleGroupBox = new System.Windows.Forms.GroupBox();
            this.editSelectedExtractorPanel = new System.Windows.Forms.Panel();
            this.extractorFileExtensionEdit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.extractorDefaultActionCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.extractorNameEdit = new System.Windows.Forms.TextBox();
            this.extractorNameError = new System.Windows.Forms.ErrorProvider(this.components);
            this.extractorAppToOpenError = new System.Windows.Forms.ErrorProvider(this.components);
            this.extractorFileExtensionError = new System.Windows.Forms.ErrorProvider(this.components);
            this.bottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extractorRegexError)).BeginInit();
            this.topGroupBox.SuspendLayout();
            this.middleGroupBox.SuspendLayout();
            this.editSelectedExtractorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extractorNameError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extractorAppToOpenError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extractorFileExtensionError)).BeginInit();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.okButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 411);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(658, 39);
            this.bottomPanel.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(571, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(472, 8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // customExtractorsListBox
            // 
            this.customExtractorsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customExtractorsListBox.FormattingEnabled = true;
            this.customExtractorsListBox.Location = new System.Drawing.Point(0, 0);
            this.customExtractorsListBox.Name = "customExtractorsListBox";
            this.customExtractorsListBox.Size = new System.Drawing.Size(177, 216);
            this.customExtractorsListBox.TabIndex = 4;
            this.customExtractorsListBox.SelectedIndexChanged += new System.EventHandler(this.customExtractorsListBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.customExtractorsListBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 274);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.removeButton);
            this.panel2.Controls.Add(this.addNewButton);
            this.panel2.Controls.Add(this.moveDownButton);
            this.panel2.Controls.Add(this.moveUpButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 216);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 58);
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
            this.moveDownButton.Location = new System.Drawing.Point(94, 32);
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
            this.moveUpButton.Location = new System.Drawing.Point(94, 3);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(75, 23);
            this.moveUpButton.TabIndex = 0;
            this.moveUpButton.Text = "Move up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // createCopyButton
            // 
            this.createCopyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createCopyButton.Location = new System.Drawing.Point(6, 248);
            this.createCopyButton.Name = "createCopyButton";
            this.createCopyButton.Size = new System.Drawing.Size(153, 23);
            this.createCopyButton.TabIndex = 3;
            this.createCopyButton.Text = "Create copy of this extractor";
            this.createCopyButton.UseVisualStyleBackColor = true;
            this.createCopyButton.Click += new System.EventHandler(this.createCopyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Regex to match and extract message content:";
            // 
            // extractorRegexEdit
            // 
            this.extractorRegexEdit.Location = new System.Drawing.Point(10, 68);
            this.extractorRegexEdit.Name = "extractorRegexEdit";
            this.extractorRegexEdit.Size = new System.Drawing.Size(447, 20);
            this.extractorRegexEdit.TabIndex = 7;
            this.extractorRegexEdit.Validating += new System.ComponentModel.CancelEventHandler(this.extractorRegexEdit_Validating);
            // 
            // extractorRegexError
            // 
            this.extractorRegexError.ContainerControl = this;
            // 
            // topGroupBox
            // 
            this.topGroupBox.Controls.Add(this.fileExtension);
            this.topGroupBox.Controls.Add(this.label4);
            this.topGroupBox.Controls.Add(this.defaultActionCombo);
            this.topGroupBox.Controls.Add(this.label3);
            this.topGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.topGroupBox.Location = new System.Drawing.Point(0, 0);
            this.topGroupBox.Name = "topGroupBox";
            this.topGroupBox.Size = new System.Drawing.Size(658, 118);
            this.topGroupBox.TabIndex = 14;
            this.topGroupBox.TabStop = false;
            this.topGroupBox.Text = "General settings";
            // 
            // fileExtension
            // 
            this.fileExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileExtension.Location = new System.Drawing.Point(8, 82);
            this.fileExtension.Name = "fileExtension";
            this.fileExtension.Size = new System.Drawing.Size(629, 20);
            this.fileExtension.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Temp file extension:";
            // 
            // defaultActionCombo
            // 
            this.defaultActionCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultActionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultActionCombo.FormattingEnabled = true;
            this.defaultActionCombo.Location = new System.Drawing.Point(8, 36);
            this.defaultActionCombo.Name = "defaultActionCombo";
            this.defaultActionCombo.Size = new System.Drawing.Size(629, 21);
            this.defaultActionCombo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Default action:";
            // 
            // middleGroupBox
            // 
            this.middleGroupBox.Controls.Add(this.editSelectedExtractorPanel);
            this.middleGroupBox.Controls.Add(this.panel1);
            this.middleGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middleGroupBox.Location = new System.Drawing.Point(0, 118);
            this.middleGroupBox.Name = "middleGroupBox";
            this.middleGroupBox.Size = new System.Drawing.Size(658, 293);
            this.middleGroupBox.TabIndex = 15;
            this.middleGroupBox.TabStop = false;
            this.middleGroupBox.Text = "Custom extractors";
            // 
            // editSelectedExtractorPanel
            // 
            this.editSelectedExtractorPanel.Controls.Add(this.extractorFileExtensionEdit);
            this.editSelectedExtractorPanel.Controls.Add(this.label7);
            this.editSelectedExtractorPanel.Controls.Add(this.extractorDefaultActionCombo);
            this.editSelectedExtractorPanel.Controls.Add(this.label6);
            this.editSelectedExtractorPanel.Controls.Add(this.label2);
            this.editSelectedExtractorPanel.Controls.Add(this.extractorNameEdit);
            this.editSelectedExtractorPanel.Controls.Add(this.createCopyButton);
            this.editSelectedExtractorPanel.Controls.Add(this.label1);
            this.editSelectedExtractorPanel.Controls.Add(this.extractorRegexEdit);
            this.editSelectedExtractorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editSelectedExtractorPanel.Location = new System.Drawing.Point(180, 16);
            this.editSelectedExtractorPanel.Name = "editSelectedExtractorPanel";
            this.editSelectedExtractorPanel.Size = new System.Drawing.Size(475, 274);
            this.editSelectedExtractorPanel.TabIndex = 13;
            this.editSelectedExtractorPanel.Text = "Edit selected extractor";
            // 
            // extractorFileExtensionEdit
            // 
            this.extractorFileExtensionEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.extractorFileExtensionEdit.Location = new System.Drawing.Point(11, 166);
            this.extractorFileExtensionEdit.Name = "extractorFileExtensionEdit";
            this.extractorFileExtensionEdit.Size = new System.Drawing.Size(446, 20);
            this.extractorFileExtensionEdit.TabIndex = 16;
            this.extractorFileExtensionEdit.Validating += new System.ComponentModel.CancelEventHandler(this.extractorFileExtensionEdit_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Temp file extension:";
            // 
            // extractorDefaultActionCombo
            // 
            this.extractorDefaultActionCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.extractorDefaultActionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.extractorDefaultActionCombo.FormattingEnabled = true;
            this.extractorDefaultActionCombo.Location = new System.Drawing.Point(11, 115);
            this.extractorDefaultActionCombo.Name = "extractorDefaultActionCombo";
            this.extractorDefaultActionCombo.Size = new System.Drawing.Size(446, 21);
            this.extractorDefaultActionCombo.TabIndex = 11;
            this.extractorDefaultActionCombo.Validating += new System.ComponentModel.CancelEventHandler(this.extractorDefaultActionCombo_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Extractor default action:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Extractor name:";
            // 
            // extractorNameEdit
            // 
            this.extractorNameEdit.Location = new System.Drawing.Point(11, 20);
            this.extractorNameEdit.Name = "extractorNameEdit";
            this.extractorNameEdit.Size = new System.Drawing.Size(446, 20);
            this.extractorNameEdit.TabIndex = 9;
            this.extractorNameEdit.Validating += new System.ComponentModel.CancelEventHandler(this.extractorNameEdit_Validating);
            // 
            // extractorNameError
            // 
            this.extractorNameError.ContainerControl = this;
            // 
            // extractorAppToOpenError
            // 
            this.extractorAppToOpenError.ContainerControl = this;
            // 
            // extractorFileExtensionError
            // 
            this.extractorFileExtensionError.ContainerControl = this;
            // 
            // ManageContentExtraction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(658, 450);
            this.Controls.Add(this.middleGroupBox);
            this.Controls.Add(this.topGroupBox);
            this.Controls.Add(this.bottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageContentExtraction";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage message content extraction";
            this.bottomPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.extractorRegexError)).EndInit();
            this.topGroupBox.ResumeLayout(false);
            this.topGroupBox.PerformLayout();
            this.middleGroupBox.ResumeLayout(false);
            this.editSelectedExtractorPanel.ResumeLayout(false);
            this.editSelectedExtractorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extractorNameError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extractorAppToOpenError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extractorFileExtensionError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ListBox customExtractorsListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addNewButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button createCopyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox extractorRegexEdit;
        private System.Windows.Forms.ErrorProvider extractorRegexError;
        private System.Windows.Forms.GroupBox middleGroupBox;
        private System.Windows.Forms.GroupBox topGroupBox;
        private System.Windows.Forms.Panel editSelectedExtractorPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox extractorNameEdit;
        private System.Windows.Forms.ComboBox defaultActionCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox extractorDefaultActionCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider extractorNameError;
        private System.Windows.Forms.ErrorProvider extractorAppToOpenError;
        private System.Windows.Forms.TextBox extractorFileExtensionEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider extractorFileExtensionError;
        private System.Windows.Forms.TextBox fileExtension;
        private System.Windows.Forms.Label label4;
    }
}