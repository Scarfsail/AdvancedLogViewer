namespace AdvancedLogViewer.UI.Controls
{
    partial class LogViewerControl
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
            this.components = new System.ComponentModel.Container();
            this.logListView = new AdvancedLogViewer.UI.Controls.MyListView();
            this.dateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.threadColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.classColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.messageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.markersPanelParent = new System.Windows.Forms.Panel();
            this.markerPanel = new Scarfsail.Common.UI.Controls.MarkerPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.logMessageEdit = new System.Windows.Forms.RichTextBox();
            this.messageDetailContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsIncludeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsExcludeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAsIncludeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAsExcludeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToSameTimeInAnotherLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogAndJumpToTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.synchronizeAnotherLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogAndSynchronizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.openInExternalTextEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markersPanelParent.SuspendLayout();
            this.messageDetailContextMenu.SuspendLayout();
            this.logViewContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // logListView
            // 
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dateColumn,
            this.threadColumn,
            this.typeColumn,
            this.classColumn,
            this.messageColumn});
            this.logListView.ContextMenuStrip = this.logViewContextMenu;
            this.logListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logListView.Enabled = false;
            this.logListView.FullRowSelect = true;
            this.logListView.HideSelection = false;
            this.logListView.Location = new System.Drawing.Point(0, 0);
            this.logListView.Name = "logListView";
            this.logListView.OwnerDraw = true;
            this.logListView.Size = new System.Drawing.Size(782, 593);
            this.logListView.TabIndex = 0;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.View = System.Windows.Forms.View.Details;
            this.logListView.VirtualMode = true;
            this.logListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.logListView_ColumnClick);
            this.logListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.logListView_ColumnWidthChanged);
            this.logListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.logListView_DrawColumnHeader);
            this.logListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.logListView_DrawSubItem);
            this.logListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.logListView_ItemSelectionChanged);
            this.logListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.logListView_RetrieveVirtualItem);
            this.logListView.VirtualItemsSelectionRangeChanged += new System.Windows.Forms.ListViewVirtualItemsSelectionRangeChangedEventHandler(this.logListView_VirtualItemsSelectionRangeChanged);
            this.logListView.DoubleClick += new System.EventHandler(this.logListView_DoubleClick);
            // 
            // dateColumn
            // 
            this.dateColumn.Text = "Date";
            this.dateColumn.Width = 150;
            // 
            // threadColumn
            // 
            this.threadColumn.Text = "Thread";
            // 
            // typeColumn
            // 
            this.typeColumn.Text = "Type";
            // 
            // classColumn
            // 
            this.classColumn.Text = "Class";
            this.classColumn.Width = 80;
            // 
            // messageColumn
            // 
            this.messageColumn.Text = "Message";
            this.messageColumn.Width = 450;
            // 
            // markersPanelParent
            // 
            this.markersPanelParent.Controls.Add(this.markerPanel);
            this.markersPanelParent.Dock = System.Windows.Forms.DockStyle.Right;
            this.markersPanelParent.Location = new System.Drawing.Point(782, 0);
            this.markersPanelParent.Name = "markersPanelParent";
            this.markersPanelParent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.markersPanelParent.Size = new System.Drawing.Size(10, 593);
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
            this.markerPanel.Size = new System.Drawing.Size(10, 573);
            this.markerPanel.TabIndex = 6;
            this.markerPanel.Click += new System.EventHandler(this.markerPanel_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 593);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(792, 4);
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
            this.logMessageEdit.Location = new System.Drawing.Point(0, 597);
            this.logMessageEdit.Name = "logMessageEdit";
            this.logMessageEdit.ReadOnly = true;
            this.logMessageEdit.Size = new System.Drawing.Size(792, 125);
            this.logMessageEdit.TabIndex = 7;
            this.logMessageEdit.Text = "Open some log first ...";
            this.logMessageEdit.WordWrap = false;
            this.logMessageEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.logMessageEdit_KeyDown);
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
            // logViewContextMenu
            // 
            this.logViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToSameTimeInAnotherLogMenuItem,
            this.synchronizeAnotherLogToolStripMenuItem,
            this.toolStripMenuItem8,
            this.openInExternalTextEditorToolStripMenuItem});
            this.logViewContextMenu.Name = "contextMenuStrip1";
            this.logViewContextMenu.Size = new System.Drawing.Size(290, 98);
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
            this.openLogAndJumpToTimeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openLogAndJumpToTimeToolStripMenuItem.Text = "Open log ...";
            this.openLogAndJumpToTimeToolStripMenuItem.Click += new System.EventHandler(this.openLogAndJumpToTimeToolStripMenuItem_Click);
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
            this.openLogAndSynchronizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            // LogViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logListView);
            this.Controls.Add(this.markersPanelParent);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.logMessageEdit);
            this.Name = "LogViewerControl";
            this.Size = new System.Drawing.Size(792, 722);
            this.markersPanelParent.ResumeLayout(false);
            this.messageDetailContextMenu.ResumeLayout(false);
            this.logViewContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyListView logListView;
        private System.Windows.Forms.ColumnHeader dateColumn;
        private System.Windows.Forms.ColumnHeader threadColumn;
        private System.Windows.Forms.ColumnHeader typeColumn;
        private System.Windows.Forms.ColumnHeader classColumn;
        private System.Windows.Forms.ColumnHeader messageColumn;
        private System.Windows.Forms.Panel markersPanelParent;
        private Scarfsail.Common.UI.Controls.MarkerPanel markerPanel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox logMessageEdit;
        private System.Windows.Forms.ContextMenuStrip messageDetailContextMenu;
        private System.Windows.Forms.ToolStripMenuItem setAsIncludeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAsExcludeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAsIncludeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAsExcludeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip logViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem goToSameTimeInAnotherLogMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogAndJumpToTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem synchronizeAnotherLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogAndSynchronizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem openInExternalTextEditorToolStripMenuItem;
    }
}
