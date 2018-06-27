using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AdvancedLogViewer.Common;
using AdvancedLogViewer.BL.LogBrowser;
using System.Text.RegularExpressions;

namespace AdvancedLogViewer.UI
{
    public partial class LogBrowserDlg : Form
    {
        private static Scarfsail.Logging.Log log = new Scarfsail.Logging.Log();

        public delegate void OpenLogFile(string logFileName, bool focusOnListView);

        private OpenLogFile openLogFile;
        private LogBrowserSettings settings;
        private Func<string, bool, bool> showSettingsDlg;
        private string currentLogFileName;

        private const int idxImgFolderOpened = 0;
        private const int idxImgFolderClosed = 1;
        private const int idxImgLogFile = 2;

        public LogBrowserDlg(OpenLogFile openLogFile, Form ownerForm, Func<string, bool, bool> showSettingsDlg)
        {            
            this.openLogFile = openLogFile;
            this.showSettingsDlg = showSettingsDlg;
            this.Owner = ownerForm;
            this.settings = LogBrowserSettings.Instance;

            InitializeComponent();
        }

        public void Show(string currentLogFileNameOrPath)
        {
            log.Info("Showing log browser for: "+currentLogFileNameOrPath);
            if (String.IsNullOrEmpty(currentLogFileNameOrPath))
            {
                if (String.IsNullOrEmpty(this.rootDir))
                    if (!this.ShowSelectFolderDialog())
                        return;
            }
            else
            {
                currentLogFileNameOrPath = Path.GetFullPath(currentLogFileNameOrPath);
                this.LoadLogFileNameOrPath(currentLogFileNameOrPath);
            }


            if (this.Visible)
                base.Show();
            else
                base.Show(this.Owner);

            this.filterByEdit.Focus();
            this.filterByEdit.SelectAll();
        }

        private bool ShowSelectFolderDialog()
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select folder which contains list of logs you want to show";
                dlg.SelectedPath = this.rootDir ?? this.settings.LastRootFolder ?? "C:\\";
                dlg.ShowNewFolderButton = false;

                if (dlg.ShowDialog(this.Owner) == DialogResult.OK)
                {
                    this.LoadLogFileNameOrPath(dlg.SelectedPath + '\\');
                    return true;
                }
                else
                    return false;
            }

        }

        private void LoadLogFileNameOrPath(string currentLogFileNameOrPath)
        {
            string root;

            if (currentLogFileNameOrPath.EndsWith("\\"))
            { //It's Path
                root = currentLogFileNameOrPath.TrimEnd('\\');
                this.currentLogFileName = null;
            }
            else
            { //It's Log File Name
                this.currentLogFileName = currentLogFileNameOrPath;
                root = GetRootPathFromLogFileName(this.currentLogFileName);
            }

            if (this.rootDir == null || !this.rootDir.Equals(root))
            { //Read list of logs and show them for new Root dir
                this.rootDir = root;
                this.ReadListOfLogsForCurrentPath();
            }
            else
            { //Just Show already readed Logs in Tree view
                this.ShowReadedLogsInTreeView();
            }

        }

        private string GetRootPathFromLogFileName(string logFileName)
        {
            DirectoryInfo dirInfo = Directory.GetParent(logFileName);
            string[] topFolders = this.settings.TopLevelFolders.ToUpperInvariant().Split(';');

            while (dirInfo != null)
            {
                if (topFolders.Contains(dirInfo.Name.ToUpperInvariant()))
                    break;
                dirInfo = Directory.GetParent(dirInfo.FullName);
            }
            if (dirInfo == null)
            {
                dirInfo = Directory.GetParent(logFileName);
                log.Info("No top level folder found, please specify name of top level folder in settings dialog. Currently shown content of this folder.");
            }
            return dirInfo.FullName;
        }

        private void ReadListOfLogsForCurrentPath()
        {
            this.settings.LastRootFolder = this.rootDir;

            //Get list of files and show them in tree view
            this.allLogFiles = Directory.GetFiles(this.rootDir, "*.log*", SearchOption.AllDirectories).ToList();
            this.allLogFiles.Sort();

            this.ShowReadedLogsInTreeView();
        }

        private List<string> allLogFiles;
        private string rootDir;

        private void ShowReadedLogsInTreeView()
        {
            List<string> logFiles = this.allLogFiles;
            string rootDirectory = this.rootDir;
            string filterBy = this.filterByEdit.Text;


            this.logsTreeView.BeginUpdate();
            this.logsTreeView.Nodes.Clear();

            string prevDir = rootDirectory;
            TreeNode dirNode = logsTreeView.Nodes.Add(rootDirectory, rootDirectory);
            TreeNode rootDirNode = dirNode;
            TreeNode fileNode = null;

            foreach (string logFile in String.IsNullOrEmpty(filterBy) ? logFiles : logFiles.Where(f => f.IndexOf(filterBy, StringComparison.OrdinalIgnoreCase) > -1))
            {
                string dir = Path.GetDirectoryName(logFile);
                if (dir != prevDir)
                {
                    dirNode = AddDirectoryToTree(dir, dirNode);
                    prevDir = dir;
                }

                TreeNode newNode;
                if (fileNode != null && AreFilesRelated(fileNode.Name, logFile))
                { //Numbered log file name
                    newNode = fileNode.Nodes.Add(logFile, Path.GetFileName(logFile));
                }
                else
                { //Base log name
                    newNode = dirNode.Nodes.Add(logFile, Path.GetFileName(logFile));
                    fileNode = newNode;
                    if (!String.IsNullOrEmpty(filterBy))
                        fileNode.EnsureVisible();

                }
                newNode.ImageIndex = idxImgLogFile;
                newNode.SelectedImageIndex = idxImgLogFile;

                if (!String.IsNullOrEmpty(currentLogFileName) && logFile.Equals(currentLogFileName, StringComparison.OrdinalIgnoreCase))
                {
                    fileNode.EnsureVisible();
                    logsTreeView.SelectedNode = fileNode;
                }
            }

            rootDirNode.Expand();
                       

            this.logsTreeView.EndUpdate();
            this.setButtonsEnabled();
        }

        private static readonly Regex numericRegex = new Regex(@"\d+", RegexOptions.Compiled);

        private bool AreFilesRelated(string baseFilename, string filename)
        {
            if (filename.Contains(baseFilename))        // check suffix match first, e.g. 'test.log' and 'test.log.1'
            {
                return true;
            }
            else
            {
                var baseFilenameWithoutNumbers = numericRegex.Replace(Path.GetFileName(baseFilename), string.Empty);
                var fileNameWithoutNumbers = numericRegex.Replace(Path.GetFileName(filename), string.Empty);

                return baseFilenameWithoutNumbers.Equals(fileNameWithoutNumbers, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        private TreeNode AddDirectoryToTree(string dir, TreeNode currentDirNode)
        {
            while (!(dir + '\\').Contains(currentDirNode.Name + '\\'))
            {
                currentDirNode = currentDirNode.Parent;
            }

            string diff = dir.Remove(0, currentDirNode.Name.Length);
            string[] dirs = diff.Split('\\');
            string fullPath = currentDirNode.Name;
            foreach (string subDir in dirs)
            {
                if (subDir == string.Empty)
                    continue;
                fullPath = Path.Combine(fullPath, subDir);
                currentDirNode = currentDirNode.Nodes.Add(fullPath, subDir);

            }
            return currentDirNode;

        }

        private void logsTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ImageIndex < idxImgLogFile)
            {
                e.Node.ImageIndex = idxImgFolderClosed;
                e.Node.SelectedImageIndex = idxImgFolderClosed;
            }
        }

        private void logsTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ImageIndex < idxImgLogFile)
            {
                e.Node.ImageIndex = idxImgFolderOpened;
                e.Node.SelectedImageIndex = idxImgFolderOpened;
            }
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            Owner.Show();
            base.OnClosing(e);
        }


        private void LogBrowser_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1.0;
        }

        private void LogBrowser_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.75;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            this.openLogFile(logsTreeView.SelectedNode.Name, false);
        }

        private void showAndCloseButton_Click(object sender, EventArgs e)
        {
            this.openLogFile(logsTreeView.SelectedNode.Name, true);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogBrowserDlg_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(this.Owner.Location.X /*+ (this.Owner.Width - this.Width)*/, this.Owner.Location.Y + (this.Owner.Height - this.Height));
        }

        private void logsTreeView_DoubleClick(object sender, EventArgs e)
        {
            if (!this.showButton.Enabled)
                return;

            this.logsTreeView.SelectedNode.Toggle();
            if (this.settings.ShowAndCloseOnDoubleClick)
                this.showAndCloseButton.PerformClick();
            else
                this.showButton.PerformClick();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.ReadListOfLogsForCurrentPath();
        }

        private void logsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            setButtonsEnabled();
        }

        private void setButtonsEnabled()
        {
            TreeNode node = logsTreeView.SelectedNode;
            bool enabled = node != null && node.ImageIndex == idxImgLogFile;

            this.showAndCloseButton.Enabled = enabled;
            this.showButton.Enabled = enabled;

        }

        private void searchChangedTimer_Tick(object sender, EventArgs e)
        {
            this.searchChangedTimer.Enabled = false;
            this.ShowReadedLogsInTreeView();
        }

        private void searchEdit_TextChanged(object sender, EventArgs e)
        {
            this.searchChangedTimer.Enabled = false;
            this.searchChangedTimer.Enabled = true;
        }

        private void settingsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.showSettingsDlg(null, false);
        }

        private void filterByEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.logsTreeView.Focus();
        }

        private void logsTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                logsTreeView_DoubleClick(logsTreeView, null);

            if (e.KeyCode == Keys.Up && (System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control)
                filterByEdit.Focus();
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            this.ShowSelectFolderDialog();
        }

        private void LogBrowserDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.settings.Save();

        }
    }
}
