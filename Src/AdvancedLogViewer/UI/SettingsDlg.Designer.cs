namespace AdvancedLogViewer.UI
{
    partial class SettingsDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDlg));
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.mainWindowGroupBox = new System.Windows.Forms.GroupBox();
            this.trimClassColumnFromLeftCheckBox = new System.Windows.Forms.CheckBox();
            this.rememberFiltersEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.addOnlyBaseNameInRecentListCheckBox = new System.Windows.Forms.CheckBox();
            this.autoScrollShowTwoItemsCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.autoRefreshPeriodEdit = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.autoScrollCheckBox = new System.Windows.Forms.CheckBox();
            this.exitAppOnESCCheckBox = new System.Windows.Forms.CheckBox();
            this.showMarkersCheckBox = new System.Windows.Forms.CheckBox();
            this.diffToolGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.extDiffBrowseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.extDiffParametersEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.extDiffPathEdit = new System.Windows.Forms.TextBox();
            this.totalCmdGroupBox = new System.Windows.Forms.GroupBox();
            this.associateWithAlvCheckBox = new System.Windows.Forms.CheckBox();
            this.totalCmdStatusLabel = new System.Windows.Forms.Label();
            this.integrateWithTotalCmdCheckBox = new System.Windows.Forms.CheckBox();
            this.automaticUpdateGroup = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.automaticUpdateCheckPeriodEdit = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.automaticUpdateEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.logBrowserGroupBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.topLevelFolders = new System.Windows.Forms.TextBox();
            this.openAndExitOnDoubleClickCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.extTextEditBrowseButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.extTextEditParametersEdit = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.extTextEditPathEdit = new System.Windows.Forms.TextBox();
            this.showLogIconsCheckBox = new System.Windows.Forms.CheckBox();
            this.bottomPanel.SuspendLayout();
            this.mainWindowGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoRefreshPeriodEdit)).BeginInit();
            this.diffToolGroupBox.SuspendLayout();
            this.totalCmdGroupBox.SuspendLayout();
            this.automaticUpdateGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.automaticUpdateCheckPeriodEdit)).BeginInit();
            this.logBrowserGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.okButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 712);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(585, 39);
            this.bottomPanel.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(501, 8);
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
            this.okButton.Location = new System.Drawing.Point(400, 8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // mainWindowGroupBox
            // 
            this.mainWindowGroupBox.Controls.Add(this.showLogIconsCheckBox);
            this.mainWindowGroupBox.Controls.Add(this.trimClassColumnFromLeftCheckBox);
            this.mainWindowGroupBox.Controls.Add(this.rememberFiltersEnabledCheckBox);
            this.mainWindowGroupBox.Controls.Add(this.addOnlyBaseNameInRecentListCheckBox);
            this.mainWindowGroupBox.Controls.Add(this.autoScrollShowTwoItemsCheckBox);
            this.mainWindowGroupBox.Controls.Add(this.label5);
            this.mainWindowGroupBox.Controls.Add(this.autoRefreshPeriodEdit);
            this.mainWindowGroupBox.Controls.Add(this.label4);
            this.mainWindowGroupBox.Controls.Add(this.autoScrollCheckBox);
            this.mainWindowGroupBox.Controls.Add(this.exitAppOnESCCheckBox);
            this.mainWindowGroupBox.Controls.Add(this.showMarkersCheckBox);
            this.mainWindowGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainWindowGroupBox.Location = new System.Drawing.Point(0, 0);
            this.mainWindowGroupBox.Name = "mainWindowGroupBox";
            this.mainWindowGroupBox.Size = new System.Drawing.Size(585, 230);
            this.mainWindowGroupBox.TabIndex = 0;
            this.mainWindowGroupBox.TabStop = false;
            this.mainWindowGroupBox.Text = "Main window";
            // 
            // trimClassColumnFromLeftCheckBox
            // 
            this.trimClassColumnFromLeftCheckBox.AutoSize = true;
            this.trimClassColumnFromLeftCheckBox.Location = new System.Drawing.Point(12, 182);
            this.trimClassColumnFromLeftCheckBox.Name = "trimClassColumnFromLeftCheckBox";
            this.trimClassColumnFromLeftCheckBox.Size = new System.Drawing.Size(516, 17);
            this.trimClassColumnFromLeftCheckBox.TabIndex = 9;
            this.trimClassColumnFromLeftCheckBox.Text = "Trim text in Class column from the left instead of right side. Thus right part of" +
    " class name is always visible.";
            this.trimClassColumnFromLeftCheckBox.UseVisualStyleBackColor = true;
            // 
            // rememberFiltersEnabledCheckBox
            // 
            this.rememberFiltersEnabledCheckBox.AutoSize = true;
            this.rememberFiltersEnabledCheckBox.Location = new System.Drawing.Point(12, 161);
            this.rememberFiltersEnabledCheckBox.Name = "rememberFiltersEnabledCheckBox";
            this.rememberFiltersEnabledCheckBox.Size = new System.Drawing.Size(250, 17);
            this.rememberFiltersEnabledCheckBox.TabIndex = 8;
            this.rememberFiltersEnabledCheckBox.Text = "Remember if filters are enabled for next session.";
            this.rememberFiltersEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // addOnlyBaseNameInRecentListCheckBox
            // 
            this.addOnlyBaseNameInRecentListCheckBox.AutoSize = true;
            this.addOnlyBaseNameInRecentListCheckBox.Location = new System.Drawing.Point(12, 138);
            this.addOnlyBaseNameInRecentListCheckBox.Name = "addOnlyBaseNameInRecentListCheckBox";
            this.addOnlyBaseNameInRecentListCheckBox.Size = new System.Drawing.Size(474, 17);
            this.addOnlyBaseNameInRecentListCheckBox.TabIndex = 7;
            this.addOnlyBaseNameInRecentListCheckBox.Text = "Add only base file names into recent file list. E.g.: Add LogName.log instead of " +
    "LogName.Log.3.";
            this.addOnlyBaseNameInRecentListCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoScrollShowTwoItemsCheckBox
            // 
            this.autoScrollShowTwoItemsCheckBox.AutoSize = true;
            this.autoScrollShowTwoItemsCheckBox.Location = new System.Drawing.Point(29, 91);
            this.autoScrollShowTwoItemsCheckBox.Name = "autoScrollShowTwoItemsCheckBox";
            this.autoScrollShowTwoItemsCheckBox.Size = new System.Drawing.Size(507, 17);
            this.autoScrollShowTwoItemsCheckBox.TabIndex = 6;
            this.autoScrollShowTwoItemsCheckBox.Text = "Select previous last item and curent last item when auto refresh (otherwise selec" +
    "t only current last item)";
            this.autoScrollShowTwoItemsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "ms";
            // 
            // autoRefreshPeriodEdit
            // 
            this.autoRefreshPeriodEdit.Location = new System.Drawing.Point(119, 114);
            this.autoRefreshPeriodEdit.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.autoRefreshPeriodEdit.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.autoRefreshPeriodEdit.Name = "autoRefreshPeriodEdit";
            this.autoRefreshPeriodEdit.Size = new System.Drawing.Size(65, 20);
            this.autoRefreshPeriodEdit.TabIndex = 4;
            this.autoRefreshPeriodEdit.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Auto refresh period:";
            // 
            // autoScrollCheckBox
            // 
            this.autoScrollCheckBox.AutoSize = true;
            this.autoScrollCheckBox.Location = new System.Drawing.Point(12, 70);
            this.autoScrollCheckBox.Name = "autoScrollCheckBox";
            this.autoScrollCheckBox.Size = new System.Drawing.Size(392, 17);
            this.autoScrollCheckBox.TabIndex = 2;
            this.autoScrollCheckBox.Text = "Auto scroll to latest item when Auto refresh is enabled and last item is selected" +
    "";
            this.autoScrollCheckBox.UseVisualStyleBackColor = true;
            // 
            // exitAppOnESCCheckBox
            // 
            this.exitAppOnESCCheckBox.AutoSize = true;
            this.exitAppOnESCCheckBox.Location = new System.Drawing.Point(12, 47);
            this.exitAppOnESCCheckBox.Name = "exitAppOnESCCheckBox";
            this.exitAppOnESCCheckBox.Size = new System.Drawing.Size(208, 17);
            this.exitAppOnESCCheckBox.TabIndex = 1;
            this.exitAppOnESCCheckBox.Text = "Exit from application on ESC keystroke";
            this.exitAppOnESCCheckBox.UseVisualStyleBackColor = true;
            // 
            // showMarkersCheckBox
            // 
            this.showMarkersCheckBox.AutoSize = true;
            this.showMarkersCheckBox.Location = new System.Drawing.Point(12, 24);
            this.showMarkersCheckBox.Name = "showMarkersCheckBox";
            this.showMarkersCheckBox.Size = new System.Drawing.Size(144, 17);
            this.showMarkersCheckBox.TabIndex = 0;
            this.showMarkersCheckBox.Text = "Show markers side panel";
            this.showMarkersCheckBox.UseVisualStyleBackColor = true;
            // 
            // diffToolGroupBox
            // 
            this.diffToolGroupBox.Controls.Add(this.label3);
            this.diffToolGroupBox.Controls.Add(this.extDiffBrowseButton);
            this.diffToolGroupBox.Controls.Add(this.label2);
            this.diffToolGroupBox.Controls.Add(this.extDiffParametersEdit);
            this.diffToolGroupBox.Controls.Add(this.label1);
            this.diffToolGroupBox.Controls.Add(this.extDiffPathEdit);
            this.diffToolGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.diffToolGroupBox.Location = new System.Drawing.Point(0, 315);
            this.diffToolGroupBox.Name = "diffToolGroupBox";
            this.diffToolGroupBox.Size = new System.Drawing.Size(585, 100);
            this.diffToolGroupBox.TabIndex = 1;
            this.diffToolGroupBox.TabStop = false;
            this.diffToolGroupBox.Text = "External diff tool settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(74, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(316, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Variables %File1% and %File2% will be replaced by real file names.";
            // 
            // extDiffBrowseButton
            // 
            this.extDiffBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.extDiffBrowseButton.Location = new System.Drawing.Point(519, 27);
            this.extDiffBrowseButton.Name = "extDiffBrowseButton";
            this.extDiffBrowseButton.Size = new System.Drawing.Size(57, 22);
            this.extDiffBrowseButton.TabIndex = 3;
            this.extDiffBrowseButton.Text = "Browse";
            this.extDiffBrowseButton.UseVisualStyleBackColor = true;
            this.extDiffBrowseButton.Click += new System.EventHandler(this.extDiffBrowseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Parameters:";
            // 
            // extDiffParametersEdit
            // 
            this.extDiffParametersEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extDiffParametersEdit.Location = new System.Drawing.Point(74, 55);
            this.extDiffParametersEdit.Name = "extDiffParametersEdit";
            this.extDiffParametersEdit.Size = new System.Drawing.Size(440, 20);
            this.extDiffParametersEdit.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path:";
            // 
            // extDiffPathEdit
            // 
            this.extDiffPathEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extDiffPathEdit.Location = new System.Drawing.Point(74, 29);
            this.extDiffPathEdit.Name = "extDiffPathEdit";
            this.extDiffPathEdit.Size = new System.Drawing.Size(440, 20);
            this.extDiffPathEdit.TabIndex = 2;
            // 
            // totalCmdGroupBox
            // 
            this.totalCmdGroupBox.Controls.Add(this.associateWithAlvCheckBox);
            this.totalCmdGroupBox.Controls.Add(this.totalCmdStatusLabel);
            this.totalCmdGroupBox.Controls.Add(this.integrateWithTotalCmdCheckBox);
            this.totalCmdGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.totalCmdGroupBox.Location = new System.Drawing.Point(0, 230);
            this.totalCmdGroupBox.Name = "totalCmdGroupBox";
            this.totalCmdGroupBox.Size = new System.Drawing.Size(585, 85);
            this.totalCmdGroupBox.TabIndex = 3;
            this.totalCmdGroupBox.TabStop = false;
            this.totalCmdGroupBox.Text = "System integration";
            // 
            // associateWithAlvCheckBox
            // 
            this.associateWithAlvCheckBox.AutoSize = true;
            this.associateWithAlvCheckBox.Location = new System.Drawing.Point(12, 62);
            this.associateWithAlvCheckBox.Name = "associateWithAlvCheckBox";
            this.associateWithAlvCheckBox.Size = new System.Drawing.Size(331, 17);
            this.associateWithAlvCheckBox.TabIndex = 6;
            this.associateWithAlvCheckBox.Text = "Associate *.LOG files with this Advanced Log Viewer application.";
            this.associateWithAlvCheckBox.UseVisualStyleBackColor = true;
            // 
            // totalCmdStatusLabel
            // 
            this.totalCmdStatusLabel.AutoSize = true;
            this.totalCmdStatusLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.totalCmdStatusLabel.Location = new System.Drawing.Point(13, 42);
            this.totalCmdStatusLabel.Name = "totalCmdStatusLabel";
            this.totalCmdStatusLabel.Size = new System.Drawing.Size(83, 13);
            this.totalCmdStatusLabel.TabIndex = 5;
            this.totalCmdStatusLabel.Text = "TotalCmd status";
            // 
            // integrateWithTotalCmdCheckBox
            // 
            this.integrateWithTotalCmdCheckBox.AutoSize = true;
            this.integrateWithTotalCmdCheckBox.Location = new System.Drawing.Point(12, 24);
            this.integrateWithTotalCmdCheckBox.Name = "integrateWithTotalCmdCheckBox";
            this.integrateWithTotalCmdCheckBox.Size = new System.Drawing.Size(571, 17);
            this.integrateWithTotalCmdCheckBox.TabIndex = 4;
            this.integrateWithTotalCmdCheckBox.Text = "Use Advanced Log Viewer as a viewer in Total Commander for ALT + F3 shortcut (sta" +
    "ndard F3 remains unchanged)";
            this.integrateWithTotalCmdCheckBox.UseVisualStyleBackColor = true;
            // 
            // automaticUpdateGroup
            // 
            this.automaticUpdateGroup.Controls.Add(this.label8);
            this.automaticUpdateGroup.Controls.Add(this.label7);
            this.automaticUpdateGroup.Controls.Add(this.automaticUpdateCheckPeriodEdit);
            this.automaticUpdateGroup.Controls.Add(this.label6);
            this.automaticUpdateGroup.Controls.Add(this.automaticUpdateEnabledCheckBox);
            this.automaticUpdateGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.automaticUpdateGroup.Location = new System.Drawing.Point(0, 607);
            this.automaticUpdateGroup.Name = "automaticUpdateGroup";
            this.automaticUpdateGroup.Size = new System.Drawing.Size(585, 112);
            this.automaticUpdateGroup.TabIndex = 4;
            this.automaticUpdateGroup.TabStop = false;
            this.automaticUpdateGroup.Text = "Application update";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(162, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "hours";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(6, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(561, 39);
            this.label7.TabIndex = 7;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // automaticUpdateCheckPeriodEdit
            // 
            this.automaticUpdateCheckPeriodEdit.Location = new System.Drawing.Point(110, 45);
            this.automaticUpdateCheckPeriodEdit.Name = "automaticUpdateCheckPeriodEdit";
            this.automaticUpdateCheckPeriodEdit.Size = new System.Drawing.Size(46, 20);
            this.automaticUpdateCheckPeriodEdit.TabIndex = 6;
            this.automaticUpdateCheckPeriodEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Check period:";
            // 
            // automaticUpdateEnabledCheckBox
            // 
            this.automaticUpdateEnabledCheckBox.AutoSize = true;
            this.automaticUpdateEnabledCheckBox.Location = new System.Drawing.Point(12, 24);
            this.automaticUpdateEnabledCheckBox.Name = "automaticUpdateEnabledCheckBox";
            this.automaticUpdateEnabledCheckBox.Size = new System.Drawing.Size(255, 17);
            this.automaticUpdateEnabledCheckBox.TabIndex = 4;
            this.automaticUpdateEnabledCheckBox.Text = "Automatically check for new application versions";
            this.automaticUpdateEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // logBrowserGroupBox
            // 
            this.logBrowserGroupBox.Controls.Add(this.label10);
            this.logBrowserGroupBox.Controls.Add(this.label9);
            this.logBrowserGroupBox.Controls.Add(this.topLevelFolders);
            this.logBrowserGroupBox.Controls.Add(this.openAndExitOnDoubleClickCheckBox);
            this.logBrowserGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logBrowserGroupBox.Location = new System.Drawing.Point(0, 524);
            this.logBrowserGroupBox.Name = "logBrowserGroupBox";
            this.logBrowserGroupBox.Size = new System.Drawing.Size(585, 83);
            this.logBrowserGroupBox.TabIndex = 7;
            this.logBrowserGroupBox.TabStop = false;
            this.logBrowserGroupBox.Text = "Log Browser";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.Location = new System.Drawing.Point(133, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(412, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "When one of folders is found above current log, all logs under the folder are dis" +
    "played.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Top level folders names:";
            // 
            // topLevelFolders
            // 
            this.topLevelFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topLevelFolders.Location = new System.Drawing.Point(134, 19);
            this.topLevelFolders.Name = "topLevelFolders";
            this.topLevelFolders.Size = new System.Drawing.Size(227, 20);
            this.topLevelFolders.TabIndex = 8;
            // 
            // openAndExitOnDoubleClickCheckBox
            // 
            this.openAndExitOnDoubleClickCheckBox.AutoSize = true;
            this.openAndExitOnDoubleClickCheckBox.Location = new System.Drawing.Point(17, 58);
            this.openAndExitOnDoubleClickCheckBox.Name = "openAndExitOnDoubleClickCheckBox";
            this.openAndExitOnDoubleClickCheckBox.Size = new System.Drawing.Size(483, 17);
            this.openAndExitOnDoubleClickCheckBox.TabIndex = 6;
            this.openAndExitOnDoubleClickCheckBox.Text = "Show && Close on double click / Enter. Otherwise just show selected log and keep " +
    "dialog opened.";
            this.openAndExitOnDoubleClickCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.extTextEditBrowseButton);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.extTextEditParametersEdit);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.extTextEditPathEdit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 415);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 109);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "External text file editor settings";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.Location = new System.Drawing.Point(74, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(346, 26);
            this.label11.TabIndex = 5;
            this.label11.Text = "Variable %FileName% will be replaced by full opened log file name.\r\nVariable %Lin" +
    "eNumber% will be replaced by line number of selected row.";
            // 
            // extTextEditBrowseButton
            // 
            this.extTextEditBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.extTextEditBrowseButton.Location = new System.Drawing.Point(519, 27);
            this.extTextEditBrowseButton.Name = "extTextEditBrowseButton";
            this.extTextEditBrowseButton.Size = new System.Drawing.Size(57, 22);
            this.extTextEditBrowseButton.TabIndex = 3;
            this.extTextEditBrowseButton.Text = "Browse";
            this.extTextEditBrowseButton.UseVisualStyleBackColor = true;
            this.extTextEditBrowseButton.Click += new System.EventHandler(this.extTextEditBrowseButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Parameters:";
            // 
            // extTextEditParametersEdit
            // 
            this.extTextEditParametersEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extTextEditParametersEdit.Location = new System.Drawing.Point(74, 55);
            this.extTextEditParametersEdit.Name = "extTextEditParametersEdit";
            this.extTextEditParametersEdit.Size = new System.Drawing.Size(440, 20);
            this.extTextEditParametersEdit.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Path:";
            // 
            // extTextEditPathEdit
            // 
            this.extTextEditPathEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extTextEditPathEdit.Location = new System.Drawing.Point(74, 29);
            this.extTextEditPathEdit.Name = "extTextEditPathEdit";
            this.extTextEditPathEdit.Size = new System.Drawing.Size(440, 20);
            this.extTextEditPathEdit.TabIndex = 2;
            // 
            // showLogIconsCheckBox
            // 
            this.showLogIconsCheckBox.AutoSize = true;
            this.showLogIconsCheckBox.Location = new System.Drawing.Point(12, 203);
            this.showLogIconsCheckBox.Name = "showLogIconsCheckBox";
            this.showLogIconsCheckBox.Size = new System.Drawing.Size(332, 17);
            this.showLogIconsCheckBox.TabIndex = 10;
            this.showLogIconsCheckBox.Text = "Show type\'s icon on each row (The icon on left side of each row)";
            this.showLogIconsCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(585, 751);
            this.Controls.Add(this.automaticUpdateGroup);
            this.Controls.Add(this.logBrowserGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.diffToolGroupBox);
            this.Controls.Add(this.totalCmdGroupBox);
            this.Controls.Add(this.mainWindowGroupBox);
            this.Controls.Add(this.bottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.bottomPanel.ResumeLayout(false);
            this.mainWindowGroupBox.ResumeLayout(false);
            this.mainWindowGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoRefreshPeriodEdit)).EndInit();
            this.diffToolGroupBox.ResumeLayout(false);
            this.diffToolGroupBox.PerformLayout();
            this.totalCmdGroupBox.ResumeLayout(false);
            this.totalCmdGroupBox.PerformLayout();
            this.automaticUpdateGroup.ResumeLayout(false);
            this.automaticUpdateGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.automaticUpdateCheckPeriodEdit)).EndInit();
            this.logBrowserGroupBox.ResumeLayout(false);
            this.logBrowserGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox mainWindowGroupBox;
        private System.Windows.Forms.CheckBox showMarkersCheckBox;
        private System.Windows.Forms.CheckBox exitAppOnESCCheckBox;
        private System.Windows.Forms.GroupBox diffToolGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button extDiffBrowseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox extDiffParametersEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox extDiffPathEdit;
        private System.Windows.Forms.CheckBox autoScrollCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown autoRefreshPeriodEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox totalCmdGroupBox;
        private System.Windows.Forms.Label totalCmdStatusLabel;
        private System.Windows.Forms.CheckBox integrateWithTotalCmdCheckBox;
        private System.Windows.Forms.CheckBox autoScrollShowTwoItemsCheckBox;
        private System.Windows.Forms.GroupBox automaticUpdateGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown automaticUpdateCheckPeriodEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox automaticUpdateEnabledCheckBox;
        private System.Windows.Forms.CheckBox addOnlyBaseNameInRecentListCheckBox;
        private System.Windows.Forms.GroupBox logBrowserGroupBox;
        private System.Windows.Forms.CheckBox openAndExitOnDoubleClickCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox topLevelFolders;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox rememberFiltersEnabledCheckBox;
        private System.Windows.Forms.CheckBox trimClassColumnFromLeftCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button extTextEditBrowseButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox extTextEditParametersEdit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox extTextEditPathEdit;
        private System.Windows.Forms.CheckBox associateWithAlvCheckBox;
        private System.Windows.Forms.CheckBox showLogIconsCheckBox;
    }
}