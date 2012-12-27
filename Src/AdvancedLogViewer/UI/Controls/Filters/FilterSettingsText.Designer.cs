namespace AdvancedLogViewer.UI.Controls.Filters
{
    partial class FilterSettingsText
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.freeDefinitionTabPage = new System.Windows.Forms.TabPage();
            this.distinctValuesTabPage = new System.Windows.Forms.TabPage();
            this.distinctValuesListBox = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.unselectAllButton = new System.Windows.Forms.Button();
            this.negateAllButton = new System.Windows.Forms.Button();
            this.filterAllButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.freeDefinitionTabPage.SuspendLayout();
            this.distinctValuesTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl);
            this.groupBox1.Size = new System.Drawing.Size(201, 229);
            this.groupBox1.Controls.SetChildIndex(this.enabledCheckBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.tabControl, 0);
            // 
            // textEdit
            // 
            this.textEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEdit.Location = new System.Drawing.Point(0, 0);
            this.textEdit.Margin = new System.Windows.Forms.Padding(0);
            this.textEdit.Multiline = true;
            this.textEdit.Name = "textEdit";
            this.textEdit.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textEdit.Size = new System.Drawing.Size(187, 136);
            this.textEdit.TabIndex = 0;
            this.textEdit.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.regeExHelpLink);
            this.panel1.Controls.Add(this.useRegexCheckBox);
            this.panel1.Controls.Add(this.hintLabel);
            this.panel1.Controls.Add(this.textFromCurrentItemButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 48);
            this.panel1.TabIndex = 1;
            // 
            // regeExHelpLink
            // 
            this.regeExHelpLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.regeExHelpLink.AutoSize = true;
            this.regeExHelpLink.Location = new System.Drawing.Point(174, 19);
            this.regeExHelpLink.Name = "regeExHelpLink";
            this.regeExHelpLink.Size = new System.Drawing.Size(13, 13);
            this.regeExHelpLink.TabIndex = 3;
            this.regeExHelpLink.TabStop = true;
            this.regeExHelpLink.Text = "?";
            this.regeExHelpLink.Visible = false;
            this.regeExHelpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.regeExHelpLink_LinkClicked);
            // 
            // useRegexCheckBox
            // 
            this.useRegexCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.useRegexCheckBox.AutoSize = true;
            this.useRegexCheckBox.Location = new System.Drawing.Point(132, 5);
            this.useRegexCheckBox.Name = "useRegexCheckBox";
            this.useRegexCheckBox.Size = new System.Drawing.Size(58, 17);
            this.useRegexCheckBox.TabIndex = 2;
            this.useRegexCheckBox.Text = "RegEx";
            this.useRegexCheckBox.UseVisualStyleBackColor = true;
            this.useRegexCheckBox.CheckedChanged += new System.EventHandler(this.useRegexCheckBox_CheckedChanged);
            // 
            // hintLabel
            // 
            this.hintLabel.AutoSize = true;
            this.hintLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.hintLabel.Location = new System.Drawing.Point(0, 5);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(134, 13);
            this.hintLabel.TabIndex = 0;
            this.hintLabel.Text = "Start line with: ~ to negate.";
            // 
            // textFromCurrentItemButton
            // 
            this.textFromCurrentItemButton.Location = new System.Drawing.Point(2, 22);
            this.textFromCurrentItemButton.Name = "textFromCurrentItemButton";
            this.textFromCurrentItemButton.Size = new System.Drawing.Size(99, 23);
            this.textFromCurrentItemButton.TabIndex = 1;
            this.textFromCurrentItemButton.Text = "Insert current item";
            this.textFromCurrentItemButton.UseVisualStyleBackColor = true;
            this.textFromCurrentItemButton.Click += new System.EventHandler(this.textFromCurrentItemButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.freeDefinitionTabPage);
            this.tabControl.Controls.Add(this.distinctValuesTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(78, 18);
            this.tabControl.Location = new System.Drawing.Point(3, 16);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(195, 210);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            this.tabControl.Enter += new System.EventHandler(this.tabControl_Enter);
            // 
            // freeDefinitionTabPage
            // 
            this.freeDefinitionTabPage.Controls.Add(this.textEdit);
            this.freeDefinitionTabPage.Controls.Add(this.panel1);
            this.freeDefinitionTabPage.Location = new System.Drawing.Point(4, 22);
            this.freeDefinitionTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.freeDefinitionTabPage.Name = "freeDefinitionTabPage";
            this.freeDefinitionTabPage.Size = new System.Drawing.Size(187, 184);
            this.freeDefinitionTabPage.TabIndex = 0;
            this.freeDefinitionTabPage.Text = "Editor";
            // 
            // distinctValuesTabPage
            // 
            this.distinctValuesTabPage.Controls.Add(this.distinctValuesListBox);
            this.distinctValuesTabPage.Controls.Add(this.panel2);
            this.distinctValuesTabPage.Location = new System.Drawing.Point(4, 22);
            this.distinctValuesTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.distinctValuesTabPage.Name = "distinctValuesTabPage";
            this.distinctValuesTabPage.Size = new System.Drawing.Size(238, 262);
            this.distinctValuesTabPage.TabIndex = 1;
            this.distinctValuesTabPage.Text = "List";
            // 
            // distinctValuesListBox
            // 
            this.distinctValuesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.distinctValuesListBox.CheckOnClick = true;
            this.distinctValuesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.distinctValuesListBox.HorizontalScrollbar = true;
            this.distinctValuesListBox.IntegralHeight = false;
            this.distinctValuesListBox.Location = new System.Drawing.Point(0, 0);
            this.distinctValuesListBox.Margin = new System.Windows.Forms.Padding(0);
            this.distinctValuesListBox.Name = "distinctValuesListBox";
            this.distinctValuesListBox.Size = new System.Drawing.Size(238, 237);
            this.distinctValuesListBox.Sorted = true;
            this.distinctValuesListBox.TabIndex = 0;
            this.distinctValuesListBox.ThreeDCheckBoxes = true;
            this.distinctValuesListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.distinctValuesListBox_ItemCheck);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.unselectAllButton);
            this.panel2.Controls.Add(this.negateAllButton);
            this.panel2.Controls.Add(this.filterAllButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 237);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 25);
            this.panel2.TabIndex = 3;
            // 
            // unselectAllButton
            // 
            this.unselectAllButton.Location = new System.Drawing.Point(116, 2);
            this.unselectAllButton.Name = "unselectAllButton";
            this.unselectAllButton.Size = new System.Drawing.Size(70, 21);
            this.unselectAllButton.TabIndex = 2;
            this.unselectAllButton.Text = "Unselect all";
            this.unselectAllButton.UseVisualStyleBackColor = true;
            this.unselectAllButton.Click += new System.EventHandler(this.unselectAllButton_Click);
            // 
            // negateAllButton
            // 
            this.negateAllButton.Location = new System.Drawing.Point(52, 2);
            this.negateAllButton.Name = "negateAllButton";
            this.negateAllButton.Size = new System.Drawing.Size(63, 21);
            this.negateAllButton.TabIndex = 1;
            this.negateAllButton.Text = "Negate all";
            this.negateAllButton.UseVisualStyleBackColor = true;
            this.negateAllButton.Click += new System.EventHandler(this.negateAllButton_Click);
            // 
            // filterAllButton
            // 
            this.filterAllButton.Location = new System.Drawing.Point(1, 2);
            this.filterAllButton.Name = "filterAllButton";
            this.filterAllButton.Size = new System.Drawing.Size(50, 21);
            this.filterAllButton.TabIndex = 0;
            this.filterAllButton.Text = "Filter all";
            this.filterAllButton.UseVisualStyleBackColor = true;
            this.filterAllButton.Click += new System.EventHandler(this.filterAllButton_Click);
            // 
            // FilterSettingsText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FilterSettingsText";
            this.Size = new System.Drawing.Size(201, 229);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.freeDefinitionTabPage.ResumeLayout(false);
            this.freeDefinitionTabPage.PerformLayout();
            this.distinctValuesTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button textFromCurrentItemButton;
        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage freeDefinitionTabPage;
        private System.Windows.Forms.TabPage distinctValuesTabPage;
        private System.Windows.Forms.CheckedListBox distinctValuesListBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button unselectAllButton;
        private System.Windows.Forms.Button negateAllButton;
        private System.Windows.Forms.Button filterAllButton;
        private System.Windows.Forms.CheckBox useRegexCheckBox;
        private System.Windows.Forms.LinkLabel regeExHelpLink;

    }
}
