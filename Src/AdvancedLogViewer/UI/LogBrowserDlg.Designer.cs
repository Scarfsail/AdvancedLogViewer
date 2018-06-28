namespace AdvancedLogViewer.UI
{
    partial class LogBrowserDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogBrowserDlg));
            this.logsTreeView = new System.Windows.Forms.TreeView();
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.filterByEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.selectFolder = new System.Windows.Forms.Button();
            this.settingsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.showButton = new System.Windows.Forms.Button();
            this.showAndCloseButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchChangedTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // logsTreeView
            // 
            this.logsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logsTreeView.HideSelection = false;
            this.logsTreeView.ImageIndex = 1;
            this.logsTreeView.ImageList = this.imageListTreeView;
            this.logsTreeView.Location = new System.Drawing.Point(0, 22);
            this.logsTreeView.Name = "logsTreeView";
            this.logsTreeView.SelectedImageIndex = 0;
            this.logsTreeView.Size = new System.Drawing.Size(499, 507);
            this.logsTreeView.StateImageList = this.imageListTreeView;
            this.logsTreeView.TabIndex = 1;
            this.logsTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.logsTreeView_BeforeCollapse);
            this.logsTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.logsTreeView_BeforeExpand);
            this.logsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.logsTreeView_AfterSelect);
            this.logsTreeView.DoubleClick += new System.EventHandler(this.logsTreeView_DoubleClick);
            this.logsTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.logsTreeView_KeyDown);
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeView.ImageStream")));
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Magenta;
            this.imageListTreeView.Images.SetKeyName(0, "FolderOpened.bmp");
            this.imageListTreeView.Images.SetKeyName(1, "FolderClosed.bmp");
            this.imageListTreeView.Images.SetKeyName(2, "LogFileIcon.bmp");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.filterByEdit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.refreshButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 22);
            this.panel2.TabIndex = 0;
            // 
            // filterByEdit
            // 
            this.filterByEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterByEdit.Location = new System.Drawing.Point(37, 1);
            this.filterByEdit.Name = "filterByEdit";
            this.filterByEdit.Size = new System.Drawing.Size(441, 20);
            this.filterByEdit.TabIndex = 1;
            this.filterByEdit.TextChanged += new System.EventHandler(this.searchEdit_TextChanged);
            this.filterByEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filterByEdit_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filter:";
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Image = global::AdvancedLogViewer.Properties.Resources.Refresh;
            this.refreshButton.Location = new System.Drawing.Point(478, 0);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(22, 23);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.selectFolder);
            this.panel3.Controls.Add(this.settingsLinkLabel);
            this.panel3.Controls.Add(this.showButton);
            this.panel3.Controls.Add(this.showAndCloseButton);
            this.panel3.Controls.Add(this.cancelButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 529);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(499, 40);
            this.panel3.TabIndex = 2;
            // 
            // selectFolder
            // 
            this.selectFolder.Location = new System.Drawing.Point(58, 8);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(102, 23);
            this.selectFolder.TabIndex = 6;
            this.selectFolder.Text = "Change root folder";
            this.selectFolder.UseVisualStyleBackColor = true;
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // settingsLinkLabel
            // 
            this.settingsLinkLabel.AutoSize = true;
            this.settingsLinkLabel.Location = new System.Drawing.Point(7, 12);
            this.settingsLinkLabel.Name = "settingsLinkLabel";
            this.settingsLinkLabel.Size = new System.Drawing.Size(45, 13);
            this.settingsLinkLabel.TabIndex = 5;
            this.settingsLinkLabel.TabStop = true;
            this.settingsLinkLabel.Text = "Settings";
            this.settingsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.settingsLinkLabel_LinkClicked);
            // 
            // showButton
            // 
            this.showButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showButton.Location = new System.Drawing.Point(212, 8);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(89, 23);
            this.showButton.TabIndex = 2;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // showAndCloseButton
            // 
            this.showAndCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showAndCloseButton.Location = new System.Drawing.Point(307, 8);
            this.showAndCloseButton.Name = "showAndCloseButton";
            this.showAndCloseButton.Size = new System.Drawing.Size(89, 23);
            this.showAndCloseButton.TabIndex = 3;
            this.showAndCloseButton.Text = "Show && Close";
            this.showAndCloseButton.UseVisualStyleBackColor = true;
            this.showAndCloseButton.Click += new System.EventHandler(this.showAndCloseButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(402, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(89, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Close";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // searchChangedTimer
            // 
            this.searchChangedTimer.Tick += new System.EventHandler(this.searchChangedTimer_Tick);
            // 
            // LogBrowserDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(499, 569);
            this.Controls.Add(this.logsTreeView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LogBrowserDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Browser";
            this.Activated += new System.EventHandler(this.LogBrowser_Activated);
            this.Deactivate += new System.EventHandler(this.LogBrowser_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogBrowserDlg_FormClosed);
            this.Load += new System.EventHandler(this.LogBrowserDlg_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView logsTreeView;
        private System.Windows.Forms.ImageList imageListTreeView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button showAndCloseButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TextBox filterByEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer searchChangedTimer;
        private System.Windows.Forms.LinkLabel settingsLinkLabel;
        private System.Windows.Forms.Button selectFolder;
    }
}