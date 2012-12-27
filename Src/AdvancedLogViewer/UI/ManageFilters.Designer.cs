namespace AdvancedLogViewer.UI
{
    partial class ManageFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageFilters));
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.renameFilterButton = new System.Windows.Forms.Button();
            this.removeFilterButton = new System.Windows.Forms.Button();
            this.addFilterButton = new System.Windows.Forms.Button();
            this.filtersComboBox = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.filterSettingsMessages = new AdvancedLogViewer.UI.Controls.Filters.FilterSettingsMessage();
            this.filterSettingsClasses = new AdvancedLogViewer.UI.Controls.Filters.FilterSettingsText();
            this.filterSettingsTypes = new AdvancedLogViewer.UI.Controls.Filters.FilterSettingsText();
            this.filterSettingsThreads = new AdvancedLogViewer.UI.Controls.Filters.FilterSettingsText();
            this.filterSettingsDateTime = new AdvancedLogViewer.UI.Controls.Filters.FilterSettingsDateTime();
            this.bottomPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.label3);
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.okButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 255);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1027, 39);
            this.bottomPanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(645, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(940, 8);
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
            this.okButton.Location = new System.Drawing.Point(842, 8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ColumnHeadera";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.renameFilterButton);
            this.panel2.Controls.Add(this.removeFilterButton);
            this.panel2.Controls.Add(this.addFilterButton);
            this.panel2.Controls.Add(this.filtersComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1027, 27);
            this.panel2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Filters:";
            // 
            // renameFilterButton
            // 
            this.renameFilterButton.Location = new System.Drawing.Point(452, 2);
            this.renameFilterButton.Name = "renameFilterButton";
            this.renameFilterButton.Size = new System.Drawing.Size(55, 23);
            this.renameFilterButton.TabIndex = 3;
            this.renameFilterButton.Text = "Rename";
            this.renameFilterButton.UseVisualStyleBackColor = true;
            this.renameFilterButton.Click += new System.EventHandler(this.renameFilterButton_Click);
            // 
            // removeFilterButton
            // 
            this.removeFilterButton.Location = new System.Drawing.Point(395, 2);
            this.removeFilterButton.Name = "removeFilterButton";
            this.removeFilterButton.Size = new System.Drawing.Size(55, 23);
            this.removeFilterButton.TabIndex = 2;
            this.removeFilterButton.Text = "Remove";
            this.removeFilterButton.UseVisualStyleBackColor = true;
            this.removeFilterButton.Click += new System.EventHandler(this.removeFilterButton_Click);
            // 
            // addFilterButton
            // 
            this.addFilterButton.Location = new System.Drawing.Point(338, 2);
            this.addFilterButton.Name = "addFilterButton";
            this.addFilterButton.Size = new System.Drawing.Size(55, 23);
            this.addFilterButton.TabIndex = 1;
            this.addFilterButton.Text = "Add";
            this.addFilterButton.UseVisualStyleBackColor = true;
            this.addFilterButton.Click += new System.EventHandler(this.addFilterButton_Click);
            // 
            // filtersComboBox
            // 
            this.filtersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filtersComboBox.FormattingEnabled = true;
            this.filtersComboBox.Location = new System.Drawing.Point(46, 3);
            this.filtersComboBox.Name = "filtersComboBox";
            this.filtersComboBox.Size = new System.Drawing.Size(286, 21);
            this.filtersComboBox.TabIndex = 0;
            this.filtersComboBox.SelectedIndexChanged += new System.EventHandler(this.filtersComboBox_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.filterSettingsMessages);
            this.panel3.Controls.Add(this.filterSettingsClasses);
            this.panel3.Controls.Add(this.filterSettingsTypes);
            this.panel3.Controls.Add(this.filterSettingsThreads);
            this.panel3.Controls.Add(this.filterSettingsDateTime);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1027, 228);
            this.panel3.TabIndex = 7;
            // 
            // filterSettingsMessages
            // 
            this.filterSettingsMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterSettingsMessages.Caption = "Message";
            this.filterSettingsMessages.Location = new System.Drawing.Point(645, 0);
            this.filterSettingsMessages.Name = "filterSettingsMessages";
            this.filterSettingsMessages.Size = new System.Drawing.Size(380, 226);
            this.filterSettingsMessages.TabIndex = 13;
            // 
            // filterSettingsClasses
            // 
            this.filterSettingsClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filterSettingsClasses.Caption = "Class";
            this.filterSettingsClasses.Location = new System.Drawing.Point(490, 0);
            this.filterSettingsClasses.Name = "filterSettingsClasses";
            this.filterSettingsClasses.Size = new System.Drawing.Size(152, 227);
            this.filterSettingsClasses.TabIndex = 12;
            // 
            // filterSettingsTypes
            // 
            this.filterSettingsTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filterSettingsTypes.Caption = "Type";
            this.filterSettingsTypes.Location = new System.Drawing.Point(335, 0);
            this.filterSettingsTypes.Name = "filterSettingsTypes";
            this.filterSettingsTypes.Size = new System.Drawing.Size(152, 227);
            this.filterSettingsTypes.TabIndex = 11;
            // 
            // filterSettingsThreads
            // 
            this.filterSettingsThreads.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filterSettingsThreads.Caption = "Thread";
            this.filterSettingsThreads.Location = new System.Drawing.Point(180, 0);
            this.filterSettingsThreads.Name = "filterSettingsThreads";
            this.filterSettingsThreads.Size = new System.Drawing.Size(152, 227);
            this.filterSettingsThreads.TabIndex = 10;
            // 
            // filterSettingsDateTime
            // 
            this.filterSettingsDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filterSettingsDateTime.Caption = "Date time";
            this.filterSettingsDateTime.DateTimeFunctionsEnabled = true;
            this.filterSettingsDateTime.Location = new System.Drawing.Point(2, 0);
            this.filterSettingsDateTime.Name = "filterSettingsDateTime";
            this.filterSettingsDateTime.Size = new System.Drawing.Size(175, 226);
            this.filterSettingsDateTime.TabIndex = 6;
            // 
            // ManageFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1027, 294);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageFilters";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage filters";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageFilters_FormClosed);
            this.bottomPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button renameFilterButton;
        private System.Windows.Forms.Button removeFilterButton;
        private System.Windows.Forms.Button addFilterButton;
        private System.Windows.Forms.ComboBox filtersComboBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private Controls.Filters.FilterSettingsDateTime filterSettingsDateTime;
        private Controls.Filters.FilterSettingsText filterSettingsThreads;
        private Controls.Filters.FilterSettingsText filterSettingsClasses;
        private Controls.Filters.FilterSettingsText filterSettingsTypes;
        private Controls.Filters.FilterSettingsMessage filterSettingsMessages;
    }
}