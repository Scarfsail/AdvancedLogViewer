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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDlg));
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.DefaultFontButton = new System.Windows.Forms.Button();
            this.MessageFontSize = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.FontComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.messageWordWrapCheckBox = new System.Windows.Forms.CheckBox();
            this.showLogIconsCheckBox = new System.Windows.Forms.CheckBox();
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
            this.label3 = new System.Windows.Forms.Label();
            this.extDiffBrowseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.extDiffParametersEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.extDiffPathEdit = new System.Windows.Forms.TextBox();
            this.associateWithAlvCheckBox = new System.Windows.Forms.CheckBox();
            this.showBrowseWithAlvCheckBox = new System.Windows.Forms.CheckBox();
            this.totalCmdStatusLabel = new System.Windows.Forms.Label();
            this.integrateWithTotalCmdCheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.automaticUpdateCheckPeriodEdit = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.automaticUpdateEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.topLevelFolders = new System.Windows.Forms.TextBox();
            this.openAndExitOnDoubleClickCheckBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.extTextEditBrowseButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.extTextEditParametersEdit = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.extTextEditPathEdit = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.mainWindowTab = new System.Windows.Forms.TabPage();
            this.totalCmdTab = new System.Windows.Forms.TabPage();
            this.diffToolTab = new System.Windows.Forms.TabPage();
            this.textEditorTab = new System.Windows.Forms.TabPage();
            this.logBrowserTab = new System.Windows.Forms.TabPage();
            this.automaticUpdateTab = new System.Windows.Forms.TabPage();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessageFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoRefreshPeriodEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.automaticUpdateCheckPeriodEdit)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.mainWindowTab.SuspendLayout();
            this.totalCmdTab.SuspendLayout();
            this.diffToolTab.SuspendLayout();
            this.textEditorTab.SuspendLayout();
            this.logBrowserTab.SuspendLayout();
            this.automaticUpdateTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.okButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 385);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(888, 45);
            this.bottomPanel.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(790, 9);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 27);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(673, 9);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 27);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // DefaultFont
            // 
            this.DefaultFontButton.Location = new System.Drawing.Point(502, 292);
            this.DefaultFontButton.Name = "DefaultFont";
            this.DefaultFontButton.Size = new System.Drawing.Size(75, 23);
            this.DefaultFontButton.TabIndex = 17;
            this.DefaultFontButton.Text = "Default";
            this.DefaultFontButton.UseVisualStyleBackColor = true;
            this.DefaultFontButton.Click += new System.EventHandler(this.DefaultFont_Click);
            // 
            // MessageFontSize
            // 
            this.MessageFontSize.DecimalPlaces = 2;
            this.MessageFontSize.Location = new System.Drawing.Point(372, 293);
            this.MessageFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MessageFontSize.Name = "MessageFontSize";
            this.MessageFontSize.Size = new System.Drawing.Size(81, 23);
            this.MessageFontSize.TabIndex = 16;
            this.MessageFontSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(316, 295);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 15);
            this.label16.TabIndex = 15;
            this.label16.Text = "Font Size";
            // 
            // FontComboBox
            // 
            this.FontComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FontComboBox.FormattingEnabled = true;
            this.FontComboBox.Location = new System.Drawing.Point(90, 293);
            this.FontComboBox.Name = "FontComboBox";
            this.FontComboBox.Size = new System.Drawing.Size(213, 23);
            this.FontComboBox.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 297);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 15);
            this.label15.TabIndex = 13;
            this.label15.Text = "Font Family";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 275);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 15);
            this.label14.TabIndex = 12;
            this.label14.Text = "Message Preview:";
            // 
            // messageWordWrapCheckBox
            // 
            this.messageWordWrapCheckBox.AutoSize = true;
            this.messageWordWrapCheckBox.Location = new System.Drawing.Point(17, 244);
            this.messageWordWrapCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.messageWordWrapCheckBox.Name = "messageWordWrapCheckBox";
            this.messageWordWrapCheckBox.Size = new System.Drawing.Size(190, 19);
            this.messageWordWrapCheckBox.TabIndex = 11;
            this.messageWordWrapCheckBox.Text = "Word wrap message in preview";
            this.messageWordWrapCheckBox.UseVisualStyleBackColor = true;
            // 
            // showLogIconsCheckBox
            // 
            this.showLogIconsCheckBox.AutoSize = true;
            this.showLogIconsCheckBox.Location = new System.Drawing.Point(17, 217);
            this.showLogIconsCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.showLogIconsCheckBox.Name = "showLogIconsCheckBox";
            this.showLogIconsCheckBox.Size = new System.Drawing.Size(365, 19);
            this.showLogIconsCheckBox.TabIndex = 10;
            this.showLogIconsCheckBox.Text = "Show type\'s icon on each row (The icon on left side of each row)";
            this.showLogIconsCheckBox.UseVisualStyleBackColor = true;
            // 
            // trimClassColumnFromLeftCheckBox
            // 
            this.trimClassColumnFromLeftCheckBox.AutoSize = true;
            this.trimClassColumnFromLeftCheckBox.Location = new System.Drawing.Point(17, 193);
            this.trimClassColumnFromLeftCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trimClassColumnFromLeftCheckBox.Name = "trimClassColumnFromLeftCheckBox";
            this.trimClassColumnFromLeftCheckBox.Size = new System.Drawing.Size(581, 19);
            this.trimClassColumnFromLeftCheckBox.TabIndex = 9;
            this.trimClassColumnFromLeftCheckBox.Text = "Trim text in Class column from the left instead of right side. Thus right part of" +
    " class name is always visible.";
            this.trimClassColumnFromLeftCheckBox.UseVisualStyleBackColor = true;
            // 
            // rememberFiltersEnabledCheckBox
            // 
            this.rememberFiltersEnabledCheckBox.AutoSize = true;
            this.rememberFiltersEnabledCheckBox.Location = new System.Drawing.Point(17, 169);
            this.rememberFiltersEnabledCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rememberFiltersEnabledCheckBox.Name = "rememberFiltersEnabledCheckBox";
            this.rememberFiltersEnabledCheckBox.Size = new System.Drawing.Size(278, 19);
            this.rememberFiltersEnabledCheckBox.TabIndex = 8;
            this.rememberFiltersEnabledCheckBox.Text = "Remember if filters are enabled for next session.";
            this.rememberFiltersEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // addOnlyBaseNameInRecentListCheckBox
            // 
            this.addOnlyBaseNameInRecentListCheckBox.AutoSize = true;
            this.addOnlyBaseNameInRecentListCheckBox.Location = new System.Drawing.Point(17, 142);
            this.addOnlyBaseNameInRecentListCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addOnlyBaseNameInRecentListCheckBox.Name = "addOnlyBaseNameInRecentListCheckBox";
            this.addOnlyBaseNameInRecentListCheckBox.Size = new System.Drawing.Size(528, 19);
            this.addOnlyBaseNameInRecentListCheckBox.TabIndex = 7;
            this.addOnlyBaseNameInRecentListCheckBox.Text = "Add only base file names into recent file list. E.g.: Add LogName.log instead of " +
    "LogName.Log.3.";
            this.addOnlyBaseNameInRecentListCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoScrollShowTwoItemsCheckBox
            // 
            this.autoScrollShowTwoItemsCheckBox.AutoSize = true;
            this.autoScrollShowTwoItemsCheckBox.Location = new System.Drawing.Point(37, 88);
            this.autoScrollShowTwoItemsCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.autoScrollShowTwoItemsCheckBox.Name = "autoScrollShowTwoItemsCheckBox";
            this.autoScrollShowTwoItemsCheckBox.Size = new System.Drawing.Size(569, 19);
            this.autoScrollShowTwoItemsCheckBox.TabIndex = 6;
            this.autoScrollShowTwoItemsCheckBox.Text = "Select previous last item and curent last item when auto refresh (otherwise selec" +
    "t only current last item)";
            this.autoScrollShowTwoItemsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "ms";
            // 
            // autoRefreshPeriodEdit
            // 
            this.autoRefreshPeriodEdit.Location = new System.Drawing.Point(139, 112);
            this.autoRefreshPeriodEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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
            this.autoRefreshPeriodEdit.Size = new System.Drawing.Size(76, 23);
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
            this.label4.Location = new System.Drawing.Point(19, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Auto refresh period:";
            // 
            // autoScrollCheckBox
            // 
            this.autoScrollCheckBox.AutoSize = true;
            this.autoScrollCheckBox.Location = new System.Drawing.Point(17, 64);
            this.autoScrollCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.autoScrollCheckBox.Name = "autoScrollCheckBox";
            this.autoScrollCheckBox.Size = new System.Drawing.Size(439, 19);
            this.autoScrollCheckBox.TabIndex = 2;
            this.autoScrollCheckBox.Text = "Auto scroll to latest item when Auto refresh is enabled and last item is selected" +
    "";
            this.autoScrollCheckBox.UseVisualStyleBackColor = true;
            // 
            // exitAppOnESCCheckBox
            // 
            this.exitAppOnESCCheckBox.AutoSize = true;
            this.exitAppOnESCCheckBox.Location = new System.Drawing.Point(17, 37);
            this.exitAppOnESCCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.exitAppOnESCCheckBox.Name = "exitAppOnESCCheckBox";
            this.exitAppOnESCCheckBox.Size = new System.Drawing.Size(229, 19);
            this.exitAppOnESCCheckBox.TabIndex = 1;
            this.exitAppOnESCCheckBox.Text = "Exit from application on ESC keystroke";
            this.exitAppOnESCCheckBox.UseVisualStyleBackColor = true;
            // 
            // showMarkersCheckBox
            // 
            this.showMarkersCheckBox.AutoSize = true;
            this.showMarkersCheckBox.Location = new System.Drawing.Point(17, 11);
            this.showMarkersCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.showMarkersCheckBox.Name = "showMarkersCheckBox";
            this.showMarkersCheckBox.Size = new System.Drawing.Size(156, 19);
            this.showMarkersCheckBox.TabIndex = 0;
            this.showMarkersCheckBox.Text = "Show markers side panel";
            this.showMarkersCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(89, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(353, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Variables %File1% and %File2% will be replaced by real file names.";
            // 
            // extDiffBrowseButton
            // 
            this.extDiffBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.extDiffBrowseButton.Location = new System.Drawing.Point(792, 14);
            this.extDiffBrowseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.extDiffBrowseButton.Name = "extDiffBrowseButton";
            this.extDiffBrowseButton.Size = new System.Drawing.Size(66, 25);
            this.extDiffBrowseButton.TabIndex = 3;
            this.extDiffBrowseButton.Text = "Browse";
            this.extDiffBrowseButton.UseVisualStyleBackColor = true;
            this.extDiffBrowseButton.Click += new System.EventHandler(this.extDiffBrowseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Parameters:";
            // 
            // extDiffParametersEdit
            // 
            this.extDiffParametersEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extDiffParametersEdit.Location = new System.Drawing.Point(89, 46);
            this.extDiffParametersEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.extDiffParametersEdit.Name = "extDiffParametersEdit";
            this.extDiffParametersEdit.Size = new System.Drawing.Size(700, 23);
            this.extDiffParametersEdit.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path:";
            // 
            // extDiffPathEdit
            // 
            this.extDiffPathEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extDiffPathEdit.Location = new System.Drawing.Point(89, 16);
            this.extDiffPathEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.extDiffPathEdit.Name = "extDiffPathEdit";
            this.extDiffPathEdit.Size = new System.Drawing.Size(700, 23);
            this.extDiffPathEdit.TabIndex = 2;
            // 
            // associateWithAlvCheckBox
            // 
            this.associateWithAlvCheckBox.AutoSize = true;
            this.associateWithAlvCheckBox.Location = new System.Drawing.Point(17, 55);
            this.associateWithAlvCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.associateWithAlvCheckBox.Name = "associateWithAlvCheckBox";
            this.associateWithAlvCheckBox.Size = new System.Drawing.Size(364, 19);
            this.associateWithAlvCheckBox.TabIndex = 6;
            this.associateWithAlvCheckBox.Text = "Associate *.LOG files with this Advanced Log Viewer application.";
            this.associateWithAlvCheckBox.UseVisualStyleBackColor = true;
            // 
            // showBrowseWithAlvCheckBox
            // 
            this.showBrowseWithAlvCheckBox.AutoSize = true;
            this.showBrowseWithAlvCheckBox.Location = new System.Drawing.Point(17, 80);
            this.showBrowseWithAlvCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.showBrowseWithAlvCheckBox.Name = "showBrowseWithAlvCheckBox";
            this.showBrowseWithAlvCheckBox.Size = new System.Drawing.Size(364, 19);
            this.showBrowseWithAlvCheckBox.TabIndex = 6;
            this.showBrowseWithAlvCheckBox.Text = "Show \"Browse for Logs\" in Windows Explorer's context menu on each folder.";
            this.showBrowseWithAlvCheckBox.UseVisualStyleBackColor = true;

            
            // 
            // totalCmdStatusLabel
            // 
            this.totalCmdStatusLabel.AutoSize = true;
            this.totalCmdStatusLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.totalCmdStatusLabel.Location = new System.Drawing.Point(18, 31);
            this.totalCmdStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalCmdStatusLabel.Name = "totalCmdStatusLabel";
            this.totalCmdStatusLabel.Size = new System.Drawing.Size(92, 15);
            this.totalCmdStatusLabel.TabIndex = 5;
            this.totalCmdStatusLabel.Text = "TotalCmd status";
            // 
            // integrateWithTotalCmdCheckBox
            // 
            this.integrateWithTotalCmdCheckBox.AutoSize = true;
            this.integrateWithTotalCmdCheckBox.Location = new System.Drawing.Point(17, 11);
            this.integrateWithTotalCmdCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.integrateWithTotalCmdCheckBox.Name = "integrateWithTotalCmdCheckBox";
            this.integrateWithTotalCmdCheckBox.Size = new System.Drawing.Size(626, 19);
            this.integrateWithTotalCmdCheckBox.TabIndex = 4;
            this.integrateWithTotalCmdCheckBox.Text = "Use Advanced Log Viewer as a viewer in Total Commander for ALT + F3 shortcut (sta" +
    "ndard F3 remains unchanged)";
            this.integrateWithTotalCmdCheckBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "hours";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(7, 64);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(867, 45);
            this.label7.TabIndex = 7;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // automaticUpdateCheckPeriodEdit
            // 
            this.automaticUpdateCheckPeriodEdit.Location = new System.Drawing.Point(128, 36);
            this.automaticUpdateCheckPeriodEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.automaticUpdateCheckPeriodEdit.Name = "automaticUpdateCheckPeriodEdit";
            this.automaticUpdateCheckPeriodEdit.Size = new System.Drawing.Size(54, 23);
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
            this.label6.Location = new System.Drawing.Point(37, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Check period:";
            // 
            // automaticUpdateEnabledCheckBox
            // 
            this.automaticUpdateEnabledCheckBox.AutoSize = true;
            this.automaticUpdateEnabledCheckBox.Location = new System.Drawing.Point(17, 15);
            this.automaticUpdateEnabledCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.automaticUpdateEnabledCheckBox.Name = "automaticUpdateEnabledCheckBox";
            this.automaticUpdateEnabledCheckBox.Size = new System.Drawing.Size(285, 19);
            this.automaticUpdateEnabledCheckBox.TabIndex = 4;
            this.automaticUpdateEnabledCheckBox.Text = "Automatically check for new application versions";
            this.automaticUpdateEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.Location = new System.Drawing.Point(158, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(462, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "When one of folders is found above current log, all logs under the folder are dis" +
    "played.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Top level folders names:";
            // 
            // topLevelFolders
            // 
            this.topLevelFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topLevelFolders.Location = new System.Drawing.Point(159, 13);
            this.topLevelFolders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.topLevelFolders.Name = "topLevelFolders";
            this.topLevelFolders.Size = new System.Drawing.Size(717, 23);
            this.topLevelFolders.TabIndex = 8;
            // 
            // openAndExitOnDoubleClickCheckBox
            // 
            this.openAndExitOnDoubleClickCheckBox.AutoSize = true;
            this.openAndExitOnDoubleClickCheckBox.Location = new System.Drawing.Point(23, 58);
            this.openAndExitOnDoubleClickCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.openAndExitOnDoubleClickCheckBox.Name = "openAndExitOnDoubleClickCheckBox";
            this.openAndExitOnDoubleClickCheckBox.Size = new System.Drawing.Size(533, 19);
            this.openAndExitOnDoubleClickCheckBox.TabIndex = 6;
            this.openAndExitOnDoubleClickCheckBox.Text = "Show && Close on double click / Enter. Otherwise just show selected log and keep " +
    "dialog opened.";
            this.openAndExitOnDoubleClickCheckBox.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.Location = new System.Drawing.Point(89, 75);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(391, 30);
            this.label11.TabIndex = 5;
            this.label11.Text = "Variable %FileName% will be replaced by full opened log file name.\r\nVariable %Lin" +
    "eNumber% will be replaced by line number of selected row.";
            // 
            // extTextEditBrowseButton
            // 
            this.extTextEditBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.extTextEditBrowseButton.Location = new System.Drawing.Point(809, 14);
            this.extTextEditBrowseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.extTextEditBrowseButton.Name = "extTextEditBrowseButton";
            this.extTextEditBrowseButton.Size = new System.Drawing.Size(66, 25);
            this.extTextEditBrowseButton.TabIndex = 3;
            this.extTextEditBrowseButton.Text = "Browse";
            this.extTextEditBrowseButton.UseVisualStyleBackColor = true;
            this.extTextEditBrowseButton.Click += new System.EventHandler(this.extTextEditBrowseButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 50);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Parameters:";
            // 
            // extTextEditParametersEdit
            // 
            this.extTextEditParametersEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extTextEditParametersEdit.Location = new System.Drawing.Point(89, 46);
            this.extTextEditParametersEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.extTextEditParametersEdit.Name = "extTextEditParametersEdit";
            this.extTextEditParametersEdit.Size = new System.Drawing.Size(717, 23);
            this.extTextEditParametersEdit.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Path:";
            // 
            // extTextEditPathEdit
            // 
            this.extTextEditPathEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extTextEditPathEdit.Location = new System.Drawing.Point(89, 16);
            this.extTextEditPathEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.extTextEditPathEdit.Name = "extTextEditPathEdit";
            this.extTextEditPathEdit.Size = new System.Drawing.Size(717, 23);
            this.extTextEditPathEdit.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.mainWindowTab);
            this.tabControl1.Controls.Add(this.totalCmdTab);
            this.tabControl1.Controls.Add(this.diffToolTab);
            this.tabControl1.Controls.Add(this.textEditorTab);
            this.tabControl1.Controls.Add(this.logBrowserTab);
            this.tabControl1.Controls.Add(this.automaticUpdateTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.ImageList = this.imageList;
            this.tabControl1.ItemSize = new System.Drawing.Size(108, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(888, 385);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // mainWindowTab
            // 
            this.mainWindowTab.Controls.Add(this.DefaultFontButton);
            this.mainWindowTab.Controls.Add(this.MessageFontSize);
            this.mainWindowTab.Controls.Add(this.label16);
            this.mainWindowTab.Controls.Add(this.FontComboBox);
            this.mainWindowTab.Controls.Add(this.label15);
            this.mainWindowTab.Controls.Add(this.label14);
            this.mainWindowTab.Controls.Add(this.messageWordWrapCheckBox);
            this.mainWindowTab.Controls.Add(this.showLogIconsCheckBox);
            this.mainWindowTab.Controls.Add(this.trimClassColumnFromLeftCheckBox);
            this.mainWindowTab.Controls.Add(this.rememberFiltersEnabledCheckBox);
            this.mainWindowTab.Controls.Add(this.addOnlyBaseNameInRecentListCheckBox);
            this.mainWindowTab.Controls.Add(this.autoScrollShowTwoItemsCheckBox);
            this.mainWindowTab.Controls.Add(this.label5);
            this.mainWindowTab.Controls.Add(this.autoRefreshPeriodEdit);
            this.mainWindowTab.Controls.Add(this.label4);
            this.mainWindowTab.Controls.Add(this.autoScrollCheckBox);
            this.mainWindowTab.Controls.Add(this.exitAppOnESCCheckBox);
            this.mainWindowTab.Controls.Add(this.showMarkersCheckBox);
            this.mainWindowTab.ImageIndex = 0;
            this.mainWindowTab.Location = new System.Drawing.Point(4, 34);
            this.mainWindowTab.Name = "mainWindowTab";
            this.mainWindowTab.Padding = new System.Windows.Forms.Padding(3);
            this.mainWindowTab.Size = new System.Drawing.Size(880, 347);
            this.mainWindowTab.TabIndex = 0;
            this.mainWindowTab.Text = "Main Window";
            this.mainWindowTab.UseVisualStyleBackColor = true;
            // 
            // totalCmdTab
            // 
            this.totalCmdTab.Controls.Add(this.associateWithAlvCheckBox);
            this.totalCmdTab.Controls.Add(this.showBrowseWithAlvCheckBox);            
            this.totalCmdTab.Controls.Add(this.totalCmdStatusLabel);
            this.totalCmdTab.Controls.Add(this.integrateWithTotalCmdCheckBox);
            this.totalCmdTab.ImageIndex = 1;
            this.totalCmdTab.Location = new System.Drawing.Point(4, 34);
            this.totalCmdTab.Name = "totalCmdTab";
            this.totalCmdTab.Padding = new System.Windows.Forms.Padding(3);
            this.totalCmdTab.Size = new System.Drawing.Size(880, 347);
            this.totalCmdTab.TabIndex = 1;
            this.totalCmdTab.Text = "System Integration";
            this.totalCmdTab.UseVisualStyleBackColor = true;
            // 
            // diffToolTab
            // 
            this.diffToolTab.Controls.Add(this.label3);
            this.diffToolTab.Controls.Add(this.extDiffBrowseButton);
            this.diffToolTab.Controls.Add(this.label2);
            this.diffToolTab.Controls.Add(this.extDiffParametersEdit);
            this.diffToolTab.Controls.Add(this.label1);
            this.diffToolTab.Controls.Add(this.extDiffPathEdit);
            this.diffToolTab.ImageIndex = 2;
            this.diffToolTab.Location = new System.Drawing.Point(4, 34);
            this.diffToolTab.Name = "diffToolTab";
            this.diffToolTab.Padding = new System.Windows.Forms.Padding(3);
            this.diffToolTab.Size = new System.Drawing.Size(880, 347);
            this.diffToolTab.TabIndex = 2;
            this.diffToolTab.Text = "External Diff Tool Settings";
            this.diffToolTab.UseVisualStyleBackColor = true;
            // 
            // textEditorTab
            // 
            this.textEditorTab.Controls.Add(this.label11);
            this.textEditorTab.Controls.Add(this.extTextEditBrowseButton);
            this.textEditorTab.Controls.Add(this.label12);
            this.textEditorTab.Controls.Add(this.extTextEditParametersEdit);
            this.textEditorTab.Controls.Add(this.label13);
            this.textEditorTab.Controls.Add(this.extTextEditPathEdit);
            this.textEditorTab.ImageIndex = 3;
            this.textEditorTab.Location = new System.Drawing.Point(4, 34);
            this.textEditorTab.Name = "textEditorTab";
            this.textEditorTab.Padding = new System.Windows.Forms.Padding(3);
            this.textEditorTab.Size = new System.Drawing.Size(880, 347);
            this.textEditorTab.TabIndex = 3;
            this.textEditorTab.Text = "External Text File Editor Settings";
            this.textEditorTab.UseVisualStyleBackColor = true;
            // 
            // logBrowserTab
            // 
            this.logBrowserTab.Controls.Add(this.label10);
            this.logBrowserTab.Controls.Add(this.label9);
            this.logBrowserTab.Controls.Add(this.topLevelFolders);
            this.logBrowserTab.Controls.Add(this.openAndExitOnDoubleClickCheckBox);
            this.logBrowserTab.ImageIndex = 4;
            this.logBrowserTab.Location = new System.Drawing.Point(4, 34);
            this.logBrowserTab.Name = "logBrowserTab";
            this.logBrowserTab.Padding = new System.Windows.Forms.Padding(3);
            this.logBrowserTab.Size = new System.Drawing.Size(880, 347);
            this.logBrowserTab.TabIndex = 4;
            this.logBrowserTab.Text = "Log Browser";
            this.logBrowserTab.UseVisualStyleBackColor = true;
            // 
            // automaticUpdateTab
            // 
            this.automaticUpdateTab.Controls.Add(this.label8);
            this.automaticUpdateTab.Controls.Add(this.label7);
            this.automaticUpdateTab.Controls.Add(this.automaticUpdateCheckPeriodEdit);
            this.automaticUpdateTab.Controls.Add(this.label6);
            this.automaticUpdateTab.Controls.Add(this.automaticUpdateEnabledCheckBox);
            this.automaticUpdateTab.ImageIndex = 5;
            this.automaticUpdateTab.Location = new System.Drawing.Point(4, 34);
            this.automaticUpdateTab.Name = "automaticUpdateTab";
            this.automaticUpdateTab.Padding = new System.Windows.Forms.Padding(3);
            this.automaticUpdateTab.Size = new System.Drawing.Size(880, 347);
            this.automaticUpdateTab.TabIndex = 5;
            this.automaticUpdateTab.Text = "Application Update";
            this.automaticUpdateTab.UseVisualStyleBackColor = true;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Main Window.png");
            this.imageList.Images.SetKeyName(1, "System Integration.png");
            this.imageList.Images.SetKeyName(2, "External Diff Tool.png");
            this.imageList.Images.SetKeyName(3, "External Text Editor.png");
            this.imageList.Images.SetKeyName(4, "Log Browser.png");
            this.imageList.Images.SetKeyName(5, "Application Update.png");
            // 
            // SettingsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(888, 430);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.bottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MessageFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoRefreshPeriodEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.automaticUpdateCheckPeriodEdit)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.mainWindowTab.ResumeLayout(false);
            this.mainWindowTab.PerformLayout();
            this.totalCmdTab.ResumeLayout(false);
            this.totalCmdTab.PerformLayout();
            this.diffToolTab.ResumeLayout(false);
            this.diffToolTab.PerformLayout();
            this.textEditorTab.ResumeLayout(false);
            this.textEditorTab.PerformLayout();
            this.logBrowserTab.ResumeLayout(false);
            this.logBrowserTab.PerformLayout();
            this.automaticUpdateTab.ResumeLayout(false);
            this.automaticUpdateTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox showMarkersCheckBox;
        private System.Windows.Forms.CheckBox exitAppOnESCCheckBox;
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
        private System.Windows.Forms.Label totalCmdStatusLabel;
        private System.Windows.Forms.CheckBox integrateWithTotalCmdCheckBox;
        private System.Windows.Forms.CheckBox autoScrollShowTwoItemsCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown automaticUpdateCheckPeriodEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox automaticUpdateEnabledCheckBox;
        private System.Windows.Forms.CheckBox addOnlyBaseNameInRecentListCheckBox;
        private System.Windows.Forms.CheckBox openAndExitOnDoubleClickCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox topLevelFolders;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox rememberFiltersEnabledCheckBox;
        private System.Windows.Forms.CheckBox trimClassColumnFromLeftCheckBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button extTextEditBrowseButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox extTextEditParametersEdit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox extTextEditPathEdit;
        private System.Windows.Forms.CheckBox associateWithAlvCheckBox;
        private System.Windows.Forms.CheckBox showBrowseWithAlvCheckBox;        
        private System.Windows.Forms.CheckBox showLogIconsCheckBox;
        private System.Windows.Forms.CheckBox messageWordWrapCheckBox;
        private System.Windows.Forms.Button DefaultFontButton;
        private System.Windows.Forms.NumericUpDown MessageFontSize;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox FontComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage mainWindowTab;
        private System.Windows.Forms.TabPage totalCmdTab;
        private System.Windows.Forms.TabPage diffToolTab;
        private System.Windows.Forms.TabPage textEditorTab;
        private System.Windows.Forms.TabPage logBrowserTab;
        private System.Windows.Forms.TabPage automaticUpdateTab;
        private System.Windows.Forms.ImageList imageList;
    }
}