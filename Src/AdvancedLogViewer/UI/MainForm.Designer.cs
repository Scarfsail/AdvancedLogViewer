namespace AdvancedLogViewer.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.logViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToSameTimeInAnotherLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogAndJumpToTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.synchronizeAnotherLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogAndSynchronizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.openInExternalTextEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageDetailContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsIncludeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsExcludeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAsIncludeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAsExcludeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.logViewPanel = new System.Windows.Forms.Panel();
            this.logListView = new AdvancedLogViewer.UI.Controls.LogListView();
            this.searchMarkersPanelParent = new System.Windows.Forms.Panel();
            this.searchMarkerPanel = new Scarfsail.Common.UI.Controls.MarkerPanel();
            this.markersPanelParent = new System.Windows.Forms.Panel();
            this.markerPanel = new Scarfsail.Common.UI.Controls.MarkerPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.logMessageEdit = new System.Windows.Forms.RichTextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.sqlFilterPanel = new System.Windows.Forms.Panel();
            this.sqlFilterControl = new AdvancedLogViewer.UI.Controls.SqlFilterControl();
            this.autoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.openFileButton = new System.Windows.Forms.ToolStripSplitButton();
            this.removeNonexistingRecentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.showLogBrowserButton = new System.Windows.Forms.ToolStripButton();
            this.exportButton = new System.Windows.Forms.ToolStripButton();
            this.openOtherPartsButton = new System.Windows.Forms.ToolStripSplitButton();
            this.starFileButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.mergeLogPartsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.otherInstancesButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openInTextEditorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.logAdjusterButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.logAdjusterMenuDivider = new System.Windows.Forms.ToolStripSeparator();
            this.editConfigFileDirectlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureLogAdjusterForThisLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.autoRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bookmarkButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.goToItemButton = new System.Windows.Forms.ToolStripButton();
            this.findButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showOnlyNewItemsButton = new System.Windows.Forms.ToolStripButton();
            this.sqlFilterButton = new System.Windows.Forms.ToolStripButton();
            this.enableFiltersButton = new System.Windows.Forms.ToolStripButton();
            this.manageFiltersButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.enableHighlightsButton = new System.Windows.Forms.ToolStripButton();
            this.manageHighlightsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.textDiffButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.showHideBottomPane = new System.Windows.Forms.ToolStripButton();
            this.stayOnTopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.otherButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logLevelAdjustmentSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageParsersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showListOfShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCommandLineParamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.pluginsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pluginsNotFoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.sendFeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadingStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastRefreshStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastChangeStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalItemsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalLinesStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentItemStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentLineStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeSpanBetweenTwoItems = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkForUpdatesStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.extractMessageContentButton = new System.Windows.Forms.ToolStripSplitButton();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.openInDefaultApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logLoadingErrorsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.parserPatternToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.logViewContextMenu.SuspendLayout();
            this.messageDetailContextMenu.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.logViewPanel.SuspendLayout();
            this.searchMarkersPanelParent.SuspendLayout();
            this.markersPanelParent.SuspendLayout();
            this.sqlFilterPanel.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.pluginsContextMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // logViewContextMenu
            // 
            this.logViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToSameTimeInAnotherLogMenuItem,
            this.synchronizeAnotherLogToolStripMenuItem,
            this.toolStripMenuItem8,
            this.openInExternalTextEditorToolStripMenuItem});
            this.logViewContextMenu.Name = "contextMenuStrip1";
            this.logViewContextMenu.Size = new System.Drawing.Size(290, 76);
            this.logViewContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.logViewContextMenu_Opening);
            // 
            // goToSameTimeInAnotherLogMenuItem
            // 
            this.goToSameTimeInAnotherLogMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLogAndJumpToTimeToolStripMenuItem,
            this.toolStripMenuItem1});
            this.goToSameTimeInAnotherLogMenuItem.Name = "goToSameTimeInAnotherLogMenuItem";
            this.goToSameTimeInAnotherLogMenuItem.Size = new System.Drawing.Size(289, 22);
            this.goToSameTimeInAnotherLogMenuItem.Text = "Go to same time in another log";
            // 
            // openLogAndJumpToTimeToolStripMenuItem
            // 
            this.openLogAndJumpToTimeToolStripMenuItem.Name = "openLogAndJumpToTimeToolStripMenuItem";
            this.openLogAndJumpToTimeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.openLogAndJumpToTimeToolStripMenuItem.Text = "Open log ...";
            this.openLogAndJumpToTimeToolStripMenuItem.Click += new System.EventHandler(this.openLogAndGoToTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(132, 6);
            // 
            // synchronizeAnotherLogToolStripMenuItem
            // 
            this.synchronizeAnotherLogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLogAndSynchronizeToolStripMenuItem,
            this.toolStripMenuItem2});
            this.synchronizeAnotherLogToolStripMenuItem.Name = "synchronizeAnotherLogToolStripMenuItem";
            this.synchronizeAnotherLogToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.synchronizeAnotherLogToolStripMenuItem.Text = "Synchronize movement with another log";
            // 
            // openLogAndSynchronizeToolStripMenuItem
            // 
            this.openLogAndSynchronizeToolStripMenuItem.Name = "openLogAndSynchronizeToolStripMenuItem";
            this.openLogAndSynchronizeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.openLogAndSynchronizeToolStripMenuItem.Text = "Open log ...";
            this.openLogAndSynchronizeToolStripMenuItem.Click += new System.EventHandler(this.openLogAndSynchronizeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(132, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(286, 6);
            // 
            // openInExternalTextEditorToolStripMenuItem
            // 
            this.openInExternalTextEditorToolStripMenuItem.Name = "openInExternalTextEditorToolStripMenuItem";
            this.openInExternalTextEditorToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.openInExternalTextEditorToolStripMenuItem.Text = "Open in external text editor";
            this.openInExternalTextEditorToolStripMenuItem.ToolTipText = "Open the log file in associated text editor and jump to selected line (if is supp" +
    "orted by the configured text editor like is Notepad++).";
            this.openInExternalTextEditorToolStripMenuItem.Click += new System.EventHandler(this.openInExternalTextEditorToolStripMenuItem_Click);
            // 
            // messageDetailContextMenu
            // 
            this.messageDetailContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsIncludeFilterToolStripMenuItem,
            this.setAsExcludeFilterToolStripMenuItem,
            this.addAsIncludeFilterToolStripMenuItem,
            this.addAsExcludeFilterToolStripMenuItem,
            this.toolStripMenuItem7,
            this.copyToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.messageDetailContextMenu.Name = "messageDetailContextMenu";
            this.messageDetailContextMenu.Size = new System.Drawing.Size(181, 142);
            // 
            // setAsIncludeFilterToolStripMenuItem
            // 
            this.setAsIncludeFilterToolStripMenuItem.Name = "setAsIncludeFilterToolStripMenuItem";
            this.setAsIncludeFilterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setAsIncludeFilterToolStripMenuItem.Text = "Set as Include filter";
            this.setAsIncludeFilterToolStripMenuItem.Click += new System.EventHandler(this.setAsIncludeFilterToolStripMenuItem_Click);
            // 
            // setAsExcludeFilterToolStripMenuItem
            // 
            this.setAsExcludeFilterToolStripMenuItem.Name = "setAsExcludeFilterToolStripMenuItem";
            this.setAsExcludeFilterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setAsExcludeFilterToolStripMenuItem.Text = "Set as Exclude filter";
            this.setAsExcludeFilterToolStripMenuItem.Click += new System.EventHandler(this.setAsExcludeFilterToolStripMenuItem_Click);
            // 
            // addAsIncludeFilterToolStripMenuItem
            // 
            this.addAsIncludeFilterToolStripMenuItem.Name = "addAsIncludeFilterToolStripMenuItem";
            this.addAsIncludeFilterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addAsIncludeFilterToolStripMenuItem.Text = "Add as Include filter";
            this.addAsIncludeFilterToolStripMenuItem.Click += new System.EventHandler(this.addAsIncludeFilterToolStripMenuItem_Click);
            // 
            // addAsExcludeFilterToolStripMenuItem
            // 
            this.addAsExcludeFilterToolStripMenuItem.Name = "addAsExcludeFilterToolStripMenuItem";
            this.addAsExcludeFilterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addAsExcludeFilterToolStripMenuItem.Text = "Add as Exclude filter";
            this.addAsExcludeFilterToolStripMenuItem.Click += new System.EventHandler(this.addAsExcludeFilterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(177, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.logViewPanel);
            this.mainPanel.Controls.Add(this.splitter2);
            this.mainPanel.Controls.Add(this.sqlFilterPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 25);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1022, 644);
            this.mainPanel.TabIndex = 0;
            // 
            // logViewPanel
            // 
            this.logViewPanel.Controls.Add(this.logListView);
            this.logViewPanel.Controls.Add(this.searchMarkersPanelParent);
            this.logViewPanel.Controls.Add(this.markersPanelParent);
            this.logViewPanel.Controls.Add(this.splitter1);
            this.logViewPanel.Controls.Add(this.logMessageEdit);
            this.logViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logViewPanel.Location = new System.Drawing.Point(0, 86);
            this.logViewPanel.Name = "logViewPanel";
            this.logViewPanel.Size = new System.Drawing.Size(1022, 558);
            this.logViewPanel.TabIndex = 8;
            // 
            // logListView
            // 
            this.logListView.ContextMenuStrip = this.logViewContextMenu;
            this.logListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logListView.Enabled = false;
            this.logListView.FullRowSelect = true;
            this.logListView.HideSelection = false;
            this.logListView.Location = new System.Drawing.Point(0, 0);
            this.logListView.Name = "logListView";
            this.logListView.OwnerDraw = true;
            this.logListView.Size = new System.Drawing.Size(1002, 429);
            this.logListView.TabIndex = 0;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.View = System.Windows.Forms.View.Details;
            this.logListView.VirtualMode = true;
            this.logListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.logListView_ItemSelectionChanged);
            this.logListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.logListView_RetrieveVirtualItem);
            this.logListView.VirtualItemsSelectionRangeChanged += new System.Windows.Forms.ListViewVirtualItemsSelectionRangeChangedEventHandler(this.logListView_VirtualItemsSelectionRangeChanged);
            this.logListView.DoubleClick += new System.EventHandler(this.bookmarkButton_ButtonClick);
            // 
            // searchMarkersPanelParent
            // 
            this.searchMarkersPanelParent.Controls.Add(this.searchMarkerPanel);
            this.searchMarkersPanelParent.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchMarkersPanelParent.Location = new System.Drawing.Point(1002, 0);
            this.searchMarkersPanelParent.Name = "searchMarkersPanelParent";
            this.searchMarkersPanelParent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.searchMarkersPanelParent.Size = new System.Drawing.Size(10, 429);
            this.searchMarkersPanelParent.TabIndex = 8;
            this.searchMarkersPanelParent.Visible = false;
            // 
            // searchMarkerPanel
            // 
            this.searchMarkerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.searchMarkerPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchMarkerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchMarkerPanel.Horizontal = false;
            this.searchMarkerPanel.Location = new System.Drawing.Point(0, 10);
            this.searchMarkerPanel.MinimumSize = new System.Drawing.Size(0, 1);
            this.searchMarkerPanel.Name = "searchMarkerPanel";
            this.searchMarkerPanel.Padding = new System.Windows.Forms.Padding(0, 21, 0, 21);
            this.searchMarkerPanel.Size = new System.Drawing.Size(10, 409);
            this.searchMarkerPanel.TabIndex = 6;
            this.searchMarkerPanel.MarkClick += new Scarfsail.Common.UI.Controls.MarkPanelClickEventHandler(this.markerPanel_MarkClick);
            // 
            // markersPanelParent
            // 
            this.markersPanelParent.Controls.Add(this.markerPanel);
            this.markersPanelParent.Dock = System.Windows.Forms.DockStyle.Right;
            this.markersPanelParent.Location = new System.Drawing.Point(1012, 0);
            this.markersPanelParent.Name = "markersPanelParent";
            this.markersPanelParent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.markersPanelParent.Size = new System.Drawing.Size(10, 429);
            this.markersPanelParent.TabIndex = 6;
            // 
            // markerPanel
            // 
            this.markerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.markerPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.markerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markerPanel.Horizontal = false;
            this.markerPanel.Location = new System.Drawing.Point(0, 10);
            this.markerPanel.MinimumSize = new System.Drawing.Size(0, 1);
            this.markerPanel.Name = "markerPanel";
            this.markerPanel.Padding = new System.Windows.Forms.Padding(0, 21, 0, 21);
            this.markerPanel.Size = new System.Drawing.Size(10, 409);
            this.markerPanel.TabIndex = 6;
            this.markerPanel.MarkClick += new Scarfsail.Common.UI.Controls.MarkPanelClickEventHandler(this.markerPanel_MarkClick);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 429);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1022, 4);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // logMessageEdit
            // 
            this.logMessageEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logMessageEdit.ContextMenuStrip = this.messageDetailContextMenu;
            this.logMessageEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logMessageEdit.Enabled = false;
            this.logMessageEdit.HideSelection = false;
            this.logMessageEdit.Location = new System.Drawing.Point(0, 433);
            this.logMessageEdit.Name = "logMessageEdit";
            this.logMessageEdit.ReadOnly = true;
            this.logMessageEdit.Size = new System.Drawing.Size(1022, 125);
            this.logMessageEdit.TabIndex = 7;
            this.logMessageEdit.Text = "Open some log first ...";
            this.logMessageEdit.WordWrap = false;
            this.logMessageEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.logMessageEdit_KeyDown);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 82);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1022, 4);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            this.splitter2.Visible = false;
            // 
            // sqlFilterPanel
            // 
            this.sqlFilterPanel.Controls.Add(this.sqlFilterControl);
            this.sqlFilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.sqlFilterPanel.Location = new System.Drawing.Point(0, 0);
            this.sqlFilterPanel.Name = "sqlFilterPanel";
            this.sqlFilterPanel.Size = new System.Drawing.Size(1022, 82);
            this.sqlFilterPanel.TabIndex = 8;
            this.sqlFilterPanel.Visible = false;
            // 
            // sqlFilterControl
            // 
            this.sqlFilterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlFilterControl.Location = new System.Drawing.Point(0, 0);
            this.sqlFilterControl.Name = "sqlFilterControl";
            this.sqlFilterControl.Size = new System.Drawing.Size(1022, 82);
            this.sqlFilterControl.TabIndex = 0;
            this.sqlFilterControl.WhereClause = "";
            // 
            // autoRefreshTimer
            // 
            this.autoRefreshTimer.Interval = 1000;
            this.autoRefreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Log files (*.log*)|*.log*|All files (*.*)|*.*";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileButton,
            this.showLogBrowserButton,
            this.exportButton,
            this.openOtherPartsButton,
            this.starFileButton,
            this.toolStripSeparator12,
            this.mergeLogPartsButton,
            this.toolStripSeparator13,
            this.otherInstancesButton,
            this.toolStripSeparator1,
            this.openInTextEditorButton,
            this.toolStripSeparator11,
            this.logAdjusterButton,
            this.toolStripSeparator7,
            this.refreshButton,
            this.autoRefreshButton,
            this.toolStripSeparator2,
            this.bookmarkButton,
            this.toolStripSeparator9,
            this.goToItemButton,
            this.findButton,
            this.toolStripSeparator4,
            this.showOnlyNewItemsButton,
            this.sqlFilterButton,
            this.enableFiltersButton,
            this.manageFiltersButton,
            this.toolStripSeparator3,
            this.enableHighlightsButton,
            this.manageHighlightsButton,
            this.toolStripSeparator5,
            this.textDiffButton,
            this.toolStripSeparator6,
            this.showHideBottomPane,
            this.stayOnTopButton,
            this.toolStripSeparator8,
            this.otherButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1022, 25);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // openFileButton
            // 
            this.openFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeNonexistingRecentFilesToolStripMenuItem,
            this.toolStripMenuItem3});
            this.openFileButton.Image = global::AdvancedLogViewer.Properties.Resources.Open;
            this.openFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(32, 22);
            this.openFileButton.ToolTipText = "Click on button to show Open File dialog (CTRL + O)\r\nClick on arrow to show recen" +
    "t files (CTRL + R)";
            this.openFileButton.ButtonClick += new System.EventHandler(this.openFileButton_Click);
            // 
            // removeNonexistingRecentFilesToolStripMenuItem
            // 
            this.removeNonexistingRecentFilesToolStripMenuItem.Name = "removeNonexistingRecentFilesToolStripMenuItem";
            this.removeNonexistingRecentFilesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.removeNonexistingRecentFilesToolStripMenuItem.Text = "Remove  nonexisting recent files";
            this.removeNonexistingRecentFilesToolStripMenuItem.Click += new System.EventHandler(this.removeNonexistingRecentFilesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(241, 6);
            // 
            // showLogBrowserButton
            // 
            this.showLogBrowserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showLogBrowserButton.Image = ((System.Drawing.Image)(resources.GetObject("showLogBrowserButton.Image")));
            this.showLogBrowserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showLogBrowserButton.Name = "showLogBrowserButton";
            this.showLogBrowserButton.Size = new System.Drawing.Size(23, 22);
            this.showLogBrowserButton.ToolTipText = "Browse for logs";
            this.showLogBrowserButton.Click += new System.EventHandler(this.showLogBrowserButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportButton.Enabled = false;
            this.exportButton.Image = global::AdvancedLogViewer.Properties.Resources.Save;
            this.exportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(23, 22);
            this.exportButton.ToolTipText = "Save currently shown items to a new log file";
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // openOtherPartsButton
            // 
            this.openOtherPartsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openOtherPartsButton.Enabled = false;
            this.openOtherPartsButton.Image = global::AdvancedLogViewer.Properties.Resources.LogParts;
            this.openOtherPartsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openOtherPartsButton.Name = "openOtherPartsButton";
            this.openOtherPartsButton.Size = new System.Drawing.Size(32, 22);
            this.openOtherPartsButton.ToolTipText = "Open another log part (.1, .2, ...)\r\nClick on this button to open following part." +
    "\r\n\r\nPress CTRL+Right to open following part.\r\nPress CTRL+Left to open previous p" +
    "art.\r\n";
            this.openOtherPartsButton.ButtonClick += new System.EventHandler(this.openOtherPartsButton_ButtonClick);
            // 
            // starFileButton
            // 
            this.starFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.starFileButton.Enabled = false;
            this.starFileButton.Image = global::AdvancedLogViewer.Properties.Resources.Star_Gray;
            this.starFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.starFileButton.Name = "starFileButton";
            this.starFileButton.Size = new System.Drawing.Size(23, 22);
            this.starFileButton.ToolTipText = "Mark / unmark currently opened file as favorite ";
            this.starFileButton.Click += new System.EventHandler(this.starFileButton_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // mergeLogPartsButton
            // 
            this.mergeLogPartsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mergeLogPartsButton.Enabled = false;
            this.mergeLogPartsButton.Image = global::AdvancedLogViewer.Properties.Resources.Merge;
            this.mergeLogPartsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mergeLogPartsButton.Name = "mergeLogPartsButton";
            this.mergeLogPartsButton.Size = new System.Drawing.Size(23, 22);
            this.mergeLogPartsButton.ToolTipText = "Merge log parts into one file";
            this.mergeLogPartsButton.Click += new System.EventHandler(this.mergeLogPartsButton_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // otherInstancesButton
            // 
            this.otherInstancesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.otherInstancesButton.Image = global::AdvancedLogViewer.Properties.Resources.InstancesManager;
            this.otherInstancesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.otherInstancesButton.Name = "otherInstancesButton";
            this.otherInstancesButton.Size = new System.Drawing.Size(29, 22);
            this.otherInstancesButton.ToolTipText = "Running instances of ALV.\r\nUse also CTRL+Tab to easy switch between running insta" +
    "nces of ALV.";
            this.otherInstancesButton.DropDownOpening += new System.EventHandler(this.otherInstancesButton_DropDownOpening);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // openInTextEditorButton
            // 
            this.openInTextEditorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openInTextEditorButton.Enabled = false;
            this.openInTextEditorButton.Image = global::AdvancedLogViewer.Properties.Resources.Notepad1;
            this.openInTextEditorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openInTextEditorButton.Name = "openInTextEditorButton";
            this.openInTextEditorButton.Size = new System.Drawing.Size(23, 22);
            this.openInTextEditorButton.ToolTipText = "Open the log file in associated text editor.\r\nHint: Use context menu on appropria" +
    "te row to open log on exact line (If supported by the configured text editor).";
            this.openInTextEditorButton.Click += new System.EventHandler(this.openInTextEditorButton_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // logAdjusterButton
            // 
            this.logAdjusterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.logAdjusterButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logAdjusterMenuDivider,
            this.editConfigFileDirectlyToolStripMenuItem,
            this.configureLogAdjusterForThisLogFileToolStripMenuItem});
            this.logAdjusterButton.Enabled = false;
            this.logAdjusterButton.Image = global::AdvancedLogViewer.Properties.Resources.LogAdjust;
            this.logAdjusterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logAdjusterButton.Name = "logAdjusterButton";
            this.logAdjusterButton.Size = new System.Drawing.Size(29, 22);
            this.logAdjusterButton.ToolTipText = "Adjust log level in associated Config file for currently opened log file.";
            // 
            // logAdjusterMenuDivider
            // 
            this.logAdjusterMenuDivider.Name = "logAdjusterMenuDivider";
            this.logAdjusterMenuDivider.Size = new System.Drawing.Size(221, 6);
            // 
            // editConfigFileDirectlyToolStripMenuItem
            // 
            this.editConfigFileDirectlyToolStripMenuItem.Name = "editConfigFileDirectlyToolStripMenuItem";
            this.editConfigFileDirectlyToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.editConfigFileDirectlyToolStripMenuItem.Text = "Edit Config file directly";
            this.editConfigFileDirectlyToolStripMenuItem.Click += new System.EventHandler(this.editConfigFileDirectlyToolStripMenuItem_Click);
            // 
            // configureLogAdjusterForThisLogFileToolStripMenuItem
            // 
            this.configureLogAdjusterForThisLogFileToolStripMenuItem.Name = "configureLogAdjusterForThisLogFileToolStripMenuItem";
            this.configureLogAdjusterForThisLogFileToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.configureLogAdjusterForThisLogFileToolStripMenuItem.Text = "It\'s configured in the code ...";
            this.configureLogAdjusterForThisLogFileToolStripMenuItem.Click += new System.EventHandler(this.configureLogAdjusterForThisLogFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // refreshButton
            // 
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton.Enabled = false;
            this.refreshButton.Image = global::AdvancedLogViewer.Properties.Resources.refresh16_transparent;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(23, 22);
            this.refreshButton.ToolTipText = "Refresh log file now";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // autoRefreshButton
            // 
            this.autoRefreshButton.CheckOnClick = true;
            this.autoRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.autoRefreshButton.Enabled = false;
            this.autoRefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("autoRefreshButton.Image")));
            this.autoRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autoRefreshButton.Name = "autoRefreshButton";
            this.autoRefreshButton.Size = new System.Drawing.Size(23, 22);
            this.autoRefreshButton.ToolTipText = "Toggle auto refresh (Play / Pause)";
            this.autoRefreshButton.CheckedChanged += new System.EventHandler(this.autoRefreshButton_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bookmarkButton
            // 
            this.bookmarkButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bookmarkButton.Enabled = false;
            this.bookmarkButton.Image = global::AdvancedLogViewer.Properties.Resources.Bookmark;
            this.bookmarkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bookmarkButton.Name = "bookmarkButton";
            this.bookmarkButton.Size = new System.Drawing.Size(32, 22);
            this.bookmarkButton.ToolTipText = "Click on the button to create first free bookmark on current line.\r\nPress CTRL + " +
    "Bookmark number to go to the bookmark.\r\nPress CTRL + SHIFT + Bookmark number to " +
    "toggle the bookmark on current line.";
            this.bookmarkButton.ButtonClick += new System.EventHandler(this.bookmarkButton_ButtonClick);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // goToItemButton
            // 
            this.goToItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goToItemButton.Enabled = false;
            this.goToItemButton.Image = global::AdvancedLogViewer.Properties.Resources.Goto;
            this.goToItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goToItemButton.Name = "goToItemButton";
            this.goToItemButton.Size = new System.Drawing.Size(23, 22);
            this.goToItemButton.ToolTipText = "Go to an item";
            this.goToItemButton.Click += new System.EventHandler(this.goToItemButton_Click);
            // 
            // findButton
            // 
            this.findButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.findButton.Enabled = false;
            this.findButton.Image = global::AdvancedLogViewer.Properties.Resources.Find;
            this.findButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(23, 22);
            this.findButton.ToolTipText = "Find text in the log (CTRL + F)\r\nF3 - Find next occurence of the text\r\nSHIFT + F3" +
    " - Find previous occurence of the text\r\n";
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // showOnlyNewItemsButton
            // 
            this.showOnlyNewItemsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showOnlyNewItemsButton.Enabled = false;
            this.showOnlyNewItemsButton.Image = global::AdvancedLogViewer.Properties.Resources.Erase;
            this.showOnlyNewItemsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showOnlyNewItemsButton.Name = "showOnlyNewItemsButton";
            this.showOnlyNewItemsButton.Size = new System.Drawing.Size(23, 22);
            this.showOnlyNewItemsButton.ToolTipText = "Show only new log items since now, older items will be hidden.\r\nThis action enabl" +
    "e Date filter and put current time into \'From\' field.";
            this.showOnlyNewItemsButton.Click += new System.EventHandler(this.showOnlyNewItemsButton_Click);
            // 
            // sqlFilterButton
            // 
            this.sqlFilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sqlFilterButton.Enabled = false;
            this.sqlFilterButton.Image = global::AdvancedLogViewer.Properties.Resources.SqlFilter;
            this.sqlFilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sqlFilterButton.Name = "sqlFilterButton";
            this.sqlFilterButton.Size = new System.Drawing.Size(23, 22);
            this.sqlFilterButton.ToolTipText = "Show / Hide SQL Filter edit. When the edit isn\'t shown, the sql filter isn\'t appl" +
    "ied.";
            this.sqlFilterButton.Click += new System.EventHandler(this.sqlFilterButton_Click);
            // 
            // enableFiltersButton
            // 
            this.enableFiltersButton.CheckOnClick = true;
            this.enableFiltersButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.enableFiltersButton.Enabled = false;
            this.enableFiltersButton.Image = global::AdvancedLogViewer.Properties.Resources.Filter;
            this.enableFiltersButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enableFiltersButton.Name = "enableFiltersButton";
            this.enableFiltersButton.Size = new System.Drawing.Size(23, 22);
            this.enableFiltersButton.ToolTipText = "Enable / disable filters";
            this.enableFiltersButton.Click += new System.EventHandler(this.enableFiltersButton_Click);
            // 
            // manageFiltersButton
            // 
            this.manageFiltersButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.manageFiltersButton.Enabled = false;
            this.manageFiltersButton.Image = global::AdvancedLogViewer.Properties.Resources.FilterSettings;
            this.manageFiltersButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.manageFiltersButton.Name = "manageFiltersButton";
            this.manageFiltersButton.Size = new System.Drawing.Size(23, 22);
            this.manageFiltersButton.ToolTipText = "Manage filters";
            this.manageFiltersButton.Click += new System.EventHandler(this.manageFiltersButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // enableHighlightsButton
            // 
            this.enableHighlightsButton.CheckOnClick = true;
            this.enableHighlightsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.enableHighlightsButton.Enabled = false;
            this.enableHighlightsButton.Image = global::AdvancedLogViewer.Properties.Resources.Highlight;
            this.enableHighlightsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enableHighlightsButton.Name = "enableHighlightsButton";
            this.enableHighlightsButton.Size = new System.Drawing.Size(23, 22);
            this.enableHighlightsButton.ToolTipText = "Enable / disable highlights";
            this.enableHighlightsButton.Click += new System.EventHandler(this.enableHighlightsButton_Click);
            // 
            // manageHighlightsButton
            // 
            this.manageHighlightsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.manageHighlightsButton.Enabled = false;
            this.manageHighlightsButton.Image = global::AdvancedLogViewer.Properties.Resources.HighlightSettings;
            this.manageHighlightsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.manageHighlightsButton.Name = "manageHighlightsButton";
            this.manageHighlightsButton.Size = new System.Drawing.Size(23, 22);
            this.manageHighlightsButton.ToolTipText = "Manage highlights";
            this.manageHighlightsButton.Click += new System.EventHandler(this.manageHighlightsButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // textDiffButton
            // 
            this.textDiffButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.textDiffButton.Enabled = false;
            this.textDiffButton.Image = global::AdvancedLogViewer.Properties.Resources.TextDiff;
            this.textDiffButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textDiffButton.Name = "textDiffButton";
            this.textDiffButton.Size = new System.Drawing.Size(23, 22);
            this.textDiffButton.ToolTipText = "Show text differences between two log items";
            this.textDiffButton.Click += new System.EventHandler(this.textDiffButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // showHideBottomPane
            // 
            this.showHideBottomPane.Checked = true;
            this.showHideBottomPane.CheckOnClick = true;
            this.showHideBottomPane.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showHideBottomPane.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showHideBottomPane.Image = global::AdvancedLogViewer.Properties.Resources.ShowHideBottomPane;
            this.showHideBottomPane.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showHideBottomPane.Name = "showHideBottomPane";
            this.showHideBottomPane.Size = new System.Drawing.Size(23, 22);
            this.showHideBottomPane.ToolTipText = "Show / Hide bottom pane with message details";
            this.showHideBottomPane.Click += new System.EventHandler(this.showHideBottomPane_Click);
            // 
            // stayOnTopButton
            // 
            this.stayOnTopButton.CheckOnClick = true;
            this.stayOnTopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stayOnTopButton.Image = ((System.Drawing.Image)(resources.GetObject("stayOnTopButton.Image")));
            this.stayOnTopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stayOnTopButton.Name = "stayOnTopButton";
            this.stayOnTopButton.Size = new System.Drawing.Size(23, 22);
            this.stayOnTopButton.ToolTipText = "Main window stay on top";
            this.stayOnTopButton.Click += new System.EventHandler(this.stayOnTopButton_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // otherButton
            // 
            this.otherButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.otherButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.logLevelAdjustmentSettingsToolStripMenuItem,
            this.manageParsersMenuItem,
            this.toolStripMenuItem5,
            this.showListOfShortcutsToolStripMenuItem,
            this.showCommandLineParamsToolStripMenuItem,
            this.toolStripMenuItem4,
            this.pluginsMenuItem,
            this.toolStripMenuItem10,
            this.checkForUpdateToolStripMenuItem,
            this.applicationHistoryToolStripMenuItem,
            this.toolStripMenuItem9,
            this.sendFeedbackToolStripMenuItem,
            this.aboutMenuItem});
            this.otherButton.Image = ((System.Drawing.Image)(resources.GetObject("otherButton.Image")));
            this.otherButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.otherButton.Name = "otherButton";
            this.otherButton.Size = new System.Drawing.Size(48, 22);
            this.otherButton.Text = "More";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(245, 22);
            this.settingsMenuItem.Text = "Application settings";
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
            // 
            // logLevelAdjustmentSettingsToolStripMenuItem
            // 
            this.logLevelAdjustmentSettingsToolStripMenuItem.Enabled = false;
            this.logLevelAdjustmentSettingsToolStripMenuItem.Name = "logLevelAdjustmentSettingsToolStripMenuItem";
            this.logLevelAdjustmentSettingsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.logLevelAdjustmentSettingsToolStripMenuItem.Text = "Log Level Adjustment settings";
            this.logLevelAdjustmentSettingsToolStripMenuItem.Click += new System.EventHandler(this.logLevelAdjustmentSettingsToolStripMenuItem_Click);
            // 
            // manageParsersMenuItem
            // 
            this.manageParsersMenuItem.Name = "manageParsersMenuItem";
            this.manageParsersMenuItem.Size = new System.Drawing.Size(245, 22);
            this.manageParsersMenuItem.Text = "Manage parser patterns";
            this.manageParsersMenuItem.ToolTipText = "Shows manager of parser patterns";
            this.manageParsersMenuItem.Click += new System.EventHandler(this.manageParsersMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(242, 6);
            // 
            // showListOfShortcutsToolStripMenuItem
            // 
            this.showListOfShortcutsToolStripMenuItem.Name = "showListOfShortcutsToolStripMenuItem";
            this.showListOfShortcutsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.showListOfShortcutsToolStripMenuItem.Text = "Show list of keyboard shortcuts";
            this.showListOfShortcutsToolStripMenuItem.Click += new System.EventHandler(this.showListOfShortcutsToolStripMenuItem_Click);
            // 
            // showCommandLineParamsToolStripMenuItem
            // 
            this.showCommandLineParamsToolStripMenuItem.Name = "showCommandLineParamsToolStripMenuItem";
            this.showCommandLineParamsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.showCommandLineParamsToolStripMenuItem.Text = "Show command line parameters";
            this.showCommandLineParamsToolStripMenuItem.Click += new System.EventHandler(this.showCommandLineParamsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(242, 6);
            // 
            // pluginsMenuItem
            // 
            this.pluginsMenuItem.DropDown = this.pluginsContextMenu;
            this.pluginsMenuItem.Enabled = false;
            this.pluginsMenuItem.Name = "pluginsMenuItem";
            this.pluginsMenuItem.Size = new System.Drawing.Size(245, 22);
            this.pluginsMenuItem.Text = "Plugins";
            this.pluginsMenuItem.DropDownOpening += new System.EventHandler(this.pluginsMenuItem_DropDownOpening);
            // 
            // pluginsContextMenu
            // 
            this.pluginsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginsNotFoundToolStripMenuItem});
            this.pluginsContextMenu.Name = "pluginsContextMenu";
            this.pluginsContextMenu.OwnerItem = this.pluginsMenuItem;
            this.pluginsContextMenu.Size = new System.Drawing.Size(205, 26);
            // 
            // pluginsNotFoundToolStripMenuItem
            // 
            this.pluginsNotFoundToolStripMenuItem.Name = "pluginsNotFoundToolStripMenuItem";
            this.pluginsNotFoundToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.pluginsNotFoundToolStripMenuItem.Text = "There are no any plugins";
            this.pluginsNotFoundToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pluginsNotFoundToolStripMenuItem.Click += new System.EventHandler(this.pluginsNotFoundToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(242, 6);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for updates ...";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // applicationHistoryToolStripMenuItem
            // 
            this.applicationHistoryToolStripMenuItem.Name = "applicationHistoryToolStripMenuItem";
            this.applicationHistoryToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.applicationHistoryToolStripMenuItem.Text = "Application history";
            this.applicationHistoryToolStripMenuItem.Click += new System.EventHandler(this.applicationHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(242, 6);
            // 
            // sendFeedbackToolStripMenuItem
            // 
            this.sendFeedbackToolStripMenuItem.Name = "sendFeedbackToolStripMenuItem";
            this.sendFeedbackToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.sendFeedbackToolStripMenuItem.Text = "Send feedback to author";
            this.sendFeedbackToolStripMenuItem.Click += new System.EventHandler(this.sendFeedbackToolStripMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(245, 22);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // loadingStatus
            // 
            this.loadingStatus.Name = "loadingStatus";
            this.loadingStatus.Size = new System.Drawing.Size(10, 17);
            this.loadingStatus.Text = " ";
            // 
            // lastRefreshStatus
            // 
            this.lastRefreshStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lastRefreshStatus.Name = "lastRefreshStatus";
            this.lastRefreshStatus.Size = new System.Drawing.Size(10, 17);
            this.lastRefreshStatus.Text = " ";
            // 
            // lastChangeStatus
            // 
            this.lastChangeStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lastChangeStatus.Name = "lastChangeStatus";
            this.lastChangeStatus.Size = new System.Drawing.Size(10, 17);
            this.lastChangeStatus.Text = " ";
            // 
            // totalItemsStatus
            // 
            this.totalItemsStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.totalItemsStatus.Name = "totalItemsStatus";
            this.totalItemsStatus.Size = new System.Drawing.Size(10, 17);
            this.totalItemsStatus.Text = " ";
            // 
            // totalLinesStatus
            // 
            this.totalLinesStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.totalLinesStatus.Name = "totalLinesStatus";
            this.totalLinesStatus.Size = new System.Drawing.Size(10, 17);
            this.totalLinesStatus.Text = " ";
            // 
            // currentItemStatus
            // 
            this.currentItemStatus.Name = "currentItemStatus";
            this.currentItemStatus.Size = new System.Drawing.Size(10, 17);
            this.currentItemStatus.Text = " ";
            // 
            // currentLineStatus
            // 
            this.currentLineStatus.Name = "currentLineStatus";
            this.currentLineStatus.Size = new System.Drawing.Size(10, 17);
            this.currentLineStatus.Text = " ";
            // 
            // timeSpanBetweenTwoItems
            // 
            this.timeSpanBetweenTwoItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.timeSpanBetweenTwoItems.Name = "timeSpanBetweenTwoItems";
            this.timeSpanBetweenTwoItems.Size = new System.Drawing.Size(10, 17);
            this.timeSpanBetweenTwoItems.Text = " ";
            // 
            // checkForUpdatesStatus
            // 
            this.checkForUpdatesStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkForUpdatesStatus.Name = "checkForUpdatesStatus";
            this.checkForUpdatesStatus.Size = new System.Drawing.Size(10, 17);
            this.checkForUpdatesStatus.Text = " ";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingStatus,
            this.lastRefreshStatus,
            this.lastChangeStatus,
            this.totalItemsStatus,
            this.totalLinesStatus,
            this.currentItemStatus,
            this.currentLineStatus,
            this.timeSpanBetweenTwoItems,
            this.checkForUpdatesStatus,
            this.extractMessageContentButton,
            this.logLoadingErrorsStatus,
            this.parserPatternToolStripStatus});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 669);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new System.Drawing.Size(1022, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // extractMessageContentButton
            // 
            this.extractMessageContentButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.extractMessageContentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.extractMessageContentButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.toolStripMenuItem6,
            this.openInDefaultApplicationToolStripMenuItem,
            this.copyToClipboardToolStripMenuItem,
            this.saveToFileToolStripMenuItem});
            this.extractMessageContentButton.Enabled = false;
            this.extractMessageContentButton.Image = global::AdvancedLogViewer.Properties.Resources.ExtractMessageContent;
            this.extractMessageContentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.extractMessageContentButton.Name = "extractMessageContentButton";
            this.extractMessageContentButton.Size = new System.Drawing.Size(32, 20);
            this.extractMessageContentButton.Text = "Extract message content";
            this.extractMessageContentButton.ButtonClick += new System.EventHandler(this.extractMessageContentButton_ButtonClick);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.configureToolStripMenuItem.Text = "Configure";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(219, 6);
            // 
            // openInDefaultApplicationToolStripMenuItem
            // 
            this.openInDefaultApplicationToolStripMenuItem.Name = "openInDefaultApplicationToolStripMenuItem";
            this.openInDefaultApplicationToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.openInDefaultApplicationToolStripMenuItem.Text = "Open in external application";
            this.openInDefaultApplicationToolStripMenuItem.Click += new System.EventHandler(this.openInDefaultApplicationToolStripMenuItem_Click);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.saveToFileToolStripMenuItem.Text = "Save to file";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // logLoadingErrorsStatus
            // 
            this.logLoadingErrorsStatus.Name = "logLoadingErrorsStatus";
            this.logLoadingErrorsStatus.Size = new System.Drawing.Size(10, 17);
            this.logLoadingErrorsStatus.Text = " ";
            // 
            // parserPatternToolStripStatus
            // 
            this.parserPatternToolStripStatus.Name = "parserPatternToolStripStatus";
            this.parserPatternToolStripStatus.Size = new System.Drawing.Size(10, 17);
            this.parserPatternToolStripStatus.Text = " ";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 691);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Log Viewer";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.logViewContextMenu.ResumeLayout(false);
            this.messageDetailContextMenu.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.logViewPanel.ResumeLayout(false);
            this.searchMarkersPanelParent.ResumeLayout(false);
            this.markersPanelParent.ResumeLayout(false);
            this.sqlFilterPanel.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.pluginsContextMenu.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdvancedLogViewer.UI.Controls.LogListView logListView;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Timer autoRefreshTimer;
        private System.Windows.Forms.ContextMenuStrip logViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem goToSameTimeInAnotherLogMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogAndJumpToTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem synchronizeAnotherLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogAndSynchronizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.ToolStripButton autoRefreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton goToItemButton;
        private System.Windows.Forms.ToolStripButton manageHighlightsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton enableFiltersButton;
        private System.Windows.Forms.ToolStripButton enableHighlightsButton;
        private System.Windows.Forms.ToolStripButton manageFiltersButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ContextMenuStrip pluginsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem pluginsNotFoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton openFileButton;
        private System.Windows.Forms.ToolStripMenuItem removeNonexistingRecentFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSplitButton openOtherPartsButton;
        private System.Windows.Forms.ToolStripButton mergeLogPartsButton;
        private System.Windows.Forms.Panel markersPanelParent;
        private Scarfsail.Common.UI.Controls.MarkerPanel markerPanel;
        private System.Windows.Forms.ToolStripDropDownButton otherButton;
        private System.Windows.Forms.ToolStripMenuItem manageParsersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripButton textDiffButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton stayOnTopButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton findButton;
        private System.Windows.Forms.ToolStripSplitButton bookmarkButton;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton showOnlyNewItemsButton;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton starFileButton;
        private System.Windows.Forms.ToolStripStatusLabel loadingStatus;
        private System.Windows.Forms.ToolStripStatusLabel lastRefreshStatus;
        private System.Windows.Forms.ToolStripStatusLabel lastChangeStatus;
        private System.Windows.Forms.ToolStripStatusLabel totalItemsStatus;
        private System.Windows.Forms.ToolStripStatusLabel totalLinesStatus;
        private System.Windows.Forms.ToolStripStatusLabel currentItemStatus;
        private System.Windows.Forms.ToolStripStatusLabel currentLineStatus;
        private System.Windows.Forms.ToolStripStatusLabel timeSpanBetweenTwoItems;
        private System.Windows.Forms.ToolStripSplitButton extractMessageContentButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem openInDefaultApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripButton showHideBottomPane;
        private System.Windows.Forms.ToolStripMenuItem applicationHistoryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip messageDetailContextMenu;
        private System.Windows.Forms.ToolStripMenuItem setAsIncludeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAsExcludeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAsIncludeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAsExcludeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton showLogBrowserButton;
        private System.Windows.Forms.ToolStripMenuItem showListOfShortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel checkForUpdatesStatus;
        private System.Windows.Forms.ToolStripMenuItem sendFeedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton logAdjusterButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem configureLogAdjusterForThisLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editConfigFileDirectlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator logAdjusterMenuDivider;
        private System.Windows.Forms.ToolStripMenuItem logLevelAdjustmentSettingsToolStripMenuItem;
        private System.Windows.Forms.RichTextBox logMessageEdit;
        private System.Windows.Forms.ToolStripButton openInTextEditorButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openInExternalTextEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripDropDownButton otherInstancesButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton exportButton;
        private System.Windows.Forms.ToolStripStatusLabel logLoadingErrorsStatus;
        private System.Windows.Forms.ToolStripMenuItem showCommandLineParamsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel parserPatternToolStripStatus;
        private System.Windows.Forms.Panel sqlFilterPanel;
        private System.Windows.Forms.ToolStripButton sqlFilterButton;
        private System.Windows.Forms.Panel logViewPanel;
        private System.Windows.Forms.Splitter splitter2;
        private Controls.SqlFilterControl sqlFilterControl;
        private System.Windows.Forms.Panel searchMarkersPanelParent;
        private Scarfsail.Common.UI.Controls.MarkerPanel searchMarkerPanel;
    }
}

