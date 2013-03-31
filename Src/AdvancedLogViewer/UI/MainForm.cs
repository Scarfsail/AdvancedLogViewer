using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using AdvancedLogViewer.BL;
using AdvancedLogViewer.Common.Parser;
using AdvancedLogViewer.BL.Filters;
using AdvancedLogViewer.BL.Comm;
using AdvancedLogViewer.BL.Comm.Messages;
using AdvancedLogViewer.BL.ColorHighlight;
using AdvancedLogViewer.UI.Items;
using AdvancedLogViewer.BL.Settings;
using AdvancedLogViewer.Common.Plugins;
using Scarfsail.Common.UI.Controls;
using System.Threading;
using AdvancedLogViewer.Common;
using Scarfsail.Common.Utils;
using System.Reflection;
using AdvancedLogViewer.UI.Controls.Filters;
using Scarfsail.SoftwareUpdates;
using AdvancedLogViewer.Properties;
using AdvancedLogViewer.BL.MessageContentExtraction;
using Scarfsail.Common.UI;
using Scarfsail.Common.UI.Shortcuts;
using AdvancedLogViewer.BL.LogAdjuster;
using Scarfsail.Common.BL;
using System.Text.RegularExpressions;
using AdvancedLogViewer.UI.Controls;
using AdvancedLogViewer.BL.FindText;

namespace AdvancedLogViewer.UI
{
    public partial class MainForm : Form, ILogListViewOwner
    {
        private ShortcutManager shortcutManager = new ShortcutManager();

        private CommManager commManager;


        private string fileName;
        private LogParser logParser = null;
        private List<LogEntry> logEntries;
        private DateTime logLoadingStartTime;
        private FilterManager filterManager;
        private List<Guid> synchronizeAnotherLogs;
        private DateTime? goToDateTimeAfterLoad = null;
        private int? goToLineAfterLoad = null;
        private string lastGoToDateFile;
        private AlvSettings settings;
        private LogAdjusters customlogAdjusters;
        private LogAdjusters systemlogAdjusters;
        private LogAdjuster activeLogAdjuster;
        private Dictionary<Guid, IAnalyseLogPlugin> plugins;
        private FindTextDlg findDlg;
        private LogBrowserDlg logBrowser;
        private ListViewItem prevSelectedListItem;
        private static Scarfsail.Logging.Log log = new Scarfsail.Logging.Log();
        private SoftwareUpdatesClient softwareUpdatesClient;
        private MessageContentExtractor messageContentExtractor;
        private System.Windows.Forms.Timer eraseUpdatesStatusCheckTimer;
        private GetDistinctValues getDistinctValues;
        private LogPattern forceParser = null;
        private string lastCompletelyLoadedLogFileName = String.Empty;
        private bool lastChangeReaded = true;

        public bool DontRunApplication = false;

        public MainForm(string[] args)
        {
            //this.Visible = false;
            log.Debug("Creating main form");
            try
            {
                this.SuspendLayout();
                InitializeComponent();

                this.settings = AlvSettings.LoadFromFile(Path.Combine(Globals.UserDataDir, "Settings.xml"), XmlSerializableFileCorruptedAction.ShowDialogAndLoadDefaults);

                this.logListView.Init(this);

                this.synchronizeAnotherLogs = new List<Guid>();

                this.getDistinctValues = new GetDistinctValues()
                {
                    Threads = delegate() { return GetListOfLogEntriesInLock(entries => entries.Select(entry => entry.Thread).Distinct(new StringIgnoreCaseEqualityComparer())); },
                    Types = delegate() { return GetListOfLogEntriesInLock(entries => entries.Select(entry => entry.Type).Distinct(new StringIgnoreCaseEqualityComparer())); },
                    Classes = delegate() { return GetListOfLogEntriesInLock(entries => entries.Select(entry => entry.Class).Distinct(new StringIgnoreCaseEqualityComparer())); }

                };

                this.otherInstancesButton.DropDown.KeyUp += new KeyEventHandler(otherInstancesButtonDropDown_KeyUp);

                //Get filename and other parameters from command line parameters
                if (args.Length == 1 && (args[0].Equals("?") || args[0].Equals("-?") || args[0].Equals("/?")))
                {
                    showCommandLineParamsToolStripMenuItem_Click(showCommandLineParamsToolStripMenuItem, null);
                    args = new string[0];
                }

                if (args.Length > 0)
                {
                    if (args[0].Equals("UseExistingInstance", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] args2 = args.Skip(1).ToArray();

                        List<LogViewerInstance> logViewers = CommManager.GetListOfOtherInstances();
                        if (logViewers.Count > 0)
                        {
                            CommManager.ProcessAppArgsInAnotherInstance(logViewers.OrderBy(lv => lv.ID).First().ID, args2);
                            this.DontRunApplication = true;
                        }
                        else
                            ParseAndProcessAppArgs(args2, false);
                    }
                    else
                    {
                        ParseAndProcessAppArgs(args, false);
                    }
                }
                else
                {
                    this.LoadRecentFiles();
                    this.Text = this.ProductName + " " + this.ProductVersion + (Globals.IsPortable ? " (Portable)" : "");
                }


                //UI
                int margins = SystemInformation.VerticalScrollBarArrowHeight + 4;
                this.markersPanelParent.Padding = new Padding(0, margins, 0, margins);
                this.searchMarkersPanelParent.Padding = new Padding(0, margins, 0, margins);

                //Bookmarks
                for (int i = 1; i <= 9; i++)
                {
                    this.bookmarkButton.DropDownItems.Add("").Click += new EventHandler(bookmarkMenuItem_Click);
                    SetBookmarkMenuItemText(i, String.Empty);
                }
                this.ResumeLayout(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating main form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error(ex);
                throw;
            }

            log.Debug("Main form created.");
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            log.Info("Main form shown with following filename: " + this.fileName);
#if !(DEBUG)
            try
#endif
            {
                //UI Settings           
                this.autoRefreshButton.Checked = this.settings.MainFormUI.AutoRefresh;
                this.enableFiltersButton.Checked = this.settings.MainFormUI.EnableFilter && this.settings.MainFormUI.RememberFiltersEnabled;
                this.enableHighlightsButton.Checked = this.settings.MainFormUI.EnableHighlights;
                this.markersPanelParent.Visible = this.settings.MainFormUI.ShowMarkers;
                this.stayOnTopButton.Checked = this.settings.MainFormUI.StayOnTop;
                this.autoRefreshTimer.Interval = this.settings.MainFormUI.AutoRefreshPeriod;

                this.TopMost = this.stayOnTopButton.Checked;

                //Load file                
                if (!String.IsNullOrEmpty(this.fileName))
                {
                    if (!File.Exists(this.fileName))
                    {
                        string tmpFileName = this.fileName;
                        this.fileName = null;
                        if (tmpFileName.EndsWith("\\"))
                        {
                            this.LogBrowser.Show(tmpFileName);
                            this.LoadRecentFiles();
                        }
                        else
                        {
                            this.ShowAndLogError(String.Format("File: '{0}' doesn't exists.", tmpFileName));
                        }

                    }
                    else
                    {
                        this.logListView.Enabled = true;
                        this.logListView.Focus();
                        this.ReloadLog();
                    }
                }
                else
                {
                    openFileButton.ShowDropDown();
                    this.CommManager.CurrentLogFileName = String.Empty;
                }

                //Upgrade or First run
                if (this.settings.MainFormUI.LastRunVersion == null)
                {
                    this.ShowSettingsDialog(" - This is first run of the application, please review the settings", true);
                    this.settings.MainFormUI.LastRunVersion = this.ProductVersion;
                    this.settings.Save();
                }
                else
                {
                    if (this.settings.MainFormUI.LastRunVersion != this.ProductVersion)
                    {
                        Version lastRunVersion = new Version(this.settings.MainFormUI.LastRunVersion);

                        this.settings.MainFormUI.LastRunVersion = this.ProductVersion;
                        this.settings.Save();

                        //Do upgrade steps
                        this.DoUpgradeSteps(lastRunVersion);

                        //Show history list
                        using (ApplicationHistoryDlg dlg = new ApplicationHistoryDlg(Path.Combine(Globals.AppDir, "History.xml"), lastRunVersion))
                        {
                            dlg.ShowDialog();
                        }
                    }
                }


                //Sofware update
                eraseUpdatesStatusCheckTimer = new System.Windows.Forms.Timer();
                eraseUpdatesStatusCheckTimer.Interval = 3000;
                eraseUpdatesStatusCheckTimer.Tick += new EventHandler(eraseUpdatesStatusCheckTimer_Tick);
                eraseUpdatesStatusCheckTimer.Enabled = false;


                SoftwareUpdatesClientSettings updatesSettings = new SoftwareUpdatesClientSettings()
                {
                    ProductPathToStoreHistoryInfo = Globals.UserDataDir,
                    ProductVersion = new Version(this.ProductVersion),
                    RemoteDefinitionXmlUrl = "http://salplachta.net/SofwareUpdates/AdvancedLogViewer/AdvancedLogViewer.xml",
                    UpdateCheckPeriod = TimeSpan.FromHours(this.settings.AutomaticUpdates.CheckInterval)
                };

                this.softwareUpdatesClient = new SoftwareUpdatesClient(updatesSettings);
                this.softwareUpdatesClient.UpdateFound += new EventHandler<UpdateFoundEventArgs>(SoftwaresUpdateClient_UpdateFound);
                this.softwareUpdatesClient.UpdateError += new EventHandler<UpdateEventArgs>(updatesClient_UpdateError);
                this.softwareUpdatesClient.UpdateNotFound += new EventHandler<UpdateEventArgs>(softwareUpdatesClient_UpdateNotFound);
                this.softwareUpdatesClient.UpdateCheckStarted += new EventHandler(softwareUpdatesClient_UpdateCheckStarted);
                this.softwareUpdatesClient.UpdateCheckFinished += new EventHandler(softwareUpdatesClient_UpdateCheckFinished);
                if (this.settings.AutomaticUpdates.EnableAutomaticCheck)
                {
                    this.softwareUpdatesClient.CheckForUpdate(true, true, true);
                }

                this.messageContentExtractor = new MessageContentExtractor(Path.Combine(Globals.UserDataDir, "MessageContentExtractor.xml"));


                //Register shortcuts
                shortcutManager.Add(new ShortcutItem(Keys.Escape, () => this.settings.MainFormUI.ExitAppOnESC, () => this.Close(), "Close application"));

                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.Tab, () => switchBetweenAlvInstancesCtrlTab(), "Switch between running ALV instances."));

                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.Home, () => (this.logEntries != null && this.logListView.Focused && this.logEntries.Count > 0),
                    () => logListView.GoToLogItem(logListView.GetLogListItem(GetLogListItemType.First).LogItem), "Jump to first log item"));

                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.End, () => (this.logEntries != null && this.logListView.Focused && this.logEntries.Count > 0),
                    () => logListView.GoToLogItem(logListView.GetLogListItem(GetLogListItemType.Last).LogItem), "Jump to last log item"));

                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.Left, () => this.ShowPrevLogFilePart(), "Show previous log part (e.g.: log.1, log.2, ...)"));
                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.Right, () => this.ShowNextLogFilePart(), "Show next log part (e.g.: log.1, log.2, ...)"));

                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.Up, () => this.logEntries != null && this.logListView.Focused && this.logEntries.Count > 0, () => logListView.JumpToSameNearestType(false), "Jump to nearest upper row with same Type (Error, Warning, ...) as on currently selected time."));
                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.Down, () => this.logEntries != null && this.logListView.Focused && this.logEntries.Count > 0, () => logListView.JumpToSameNearestType(true), "Jump to nearest lower row with same Type (Error, Warning, ...) as on currently selected time."));

                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.O, () => this.openFileButton.PerformButtonClick(), "Show Open File dialog"));
                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.R, () => this.openFileButton.ShowDropDown(), "Show recent files"));
                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.B, this.showLogBrowserButton));
                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.S, this.exportButton));
                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.Q, this.sqlFilterButton));
                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.P, manageParsersMenuItem));

                shortcutManager.Add(new ShortcutItem(Keys.F, this.starFileButton));

                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.F, this.findButton, "Find text in the log"));
                shortcutManager.Add(new ShortcutItem(Keys.F3, () => this.FindDlg.Find(this.fileName, this.logParser.LogPattern.PatternItems, true),
                    "Find next occurence of the text"));

                shortcutManager.Add(new ShortcutItem(Keys.Shift | Keys.F3, () => this.FindDlg.Find(this.fileName, this.logParser.LogPattern.PatternItems, false),
                    "Find previous occurence of the text"));

                shortcutManager.Add(new ShortcutItem(Keys.F5, this.refreshButton));
                shortcutManager.Add(new ShortcutItem(Keys.P, this.autoRefreshButton));

                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.H, this.enableHighlightsButton));
                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.E, this.enableFiltersButton));
                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.T, this.showOnlyNewItemsButton));

                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.G, this.goToItemButton));
                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.D, this.textDiffButton));
                shortcutManager.Add(new ShortcutItem(Keys.Control | Keys.L, this.logAdjusterButton));
                shortcutManager.Add(new ShortcutItem(Keys.Alt | Keys.N, this.openInTextEditorButton));
                shortcutManager.Add(new ShortcutItem(Keys.Alt | Keys.T, this.openInExternalTextEditorToolStripMenuItem));

                logListView.RegisterKeyboardShortcuts(shortcutManager);

                shortcutManager.Add(new ShortcutItem(
                    (Keys inputKey) => (((inputKey & Keys.Control) == Keys.Control) && ((inputKey & Keys.Shift) == Keys.Shift) && (GetKeyNumber(inputKey) >= (int)Keys.D1 && GetKeyNumber(inputKey) <= (int)Keys.D9)),
                    (Keys inputKey) => logListView.ToggleBookmark(GetKeyNumber(inputKey) - 48),
                    "CTRL + SHIFT + Number", "Toggle the bookmark with appropriate number on current line"));

                shortcutManager.Add(new ShortcutItem(
                    (Keys inputKey) => (((inputKey & Keys.Control) == Keys.Control) && (GetKeyNumber(inputKey) >= (int)Keys.D1 && GetKeyNumber(inputKey) <= (int)Keys.D9)),
                    (Keys inputKey) => logListView.GotoBookmark(GetKeyNumber(inputKey) - 48),
                    "CTRL + Number", "Goto the bookmark with appropriate number."));
            }
#if !(DEBUG)
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show("Error while showing main form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
#endif

            log.Debug("Main form shown event finished");
        }

        private void DoUpgradeSteps(Version upgradedFrom)
        {
            if (upgradedFrom <= new Version("2.6.1"))
            {
                if (this.settings.MainFormUI.AddOnlyBaseNameInRecentList)
                    this.ReplaceRecentFileNamesByBaseFileNames();
            }
            else if (upgradedFrom <= new Version("3.2.3"))
            {
                this.settings.AutomaticUpdates.CheckInterval = 12;
                this.settings.Save();
            }
        }

        public Form Form { get { return this; } }
        public AlvSettings Settings { get { return settings; } }
        public LogParser LogParser { get { return logParser; } }
        public List<LogEntry> LogEntries { get { return logEntries; } }
        public bool FiltersEnabled
        {
            get
            {
                return this.enableFiltersButton.Checked;
            }
            set
            {
                this.enableFiltersButton.Checked = value;
            }
        }

        private bool SqlFilterEnabled
        {
            get
            {
                return this.sqlFilterPanel.Visible;
            }
        }


        public ColorHighlightManager ColorHighlightManager
        {
            get
            {
                if (this.colorHighlightManager == null)
                {
                    this.colorHighlightManager = ColorHighlightManager.LoadFromFile(Path.Combine(Globals.UserDataDir, "ColorHighlights.xml"), XmlSerializableFileCorruptedAction.ShowDialogAndLoadDefaults);
                }
                return this.colorHighlightManager;
            }
        }

        public FilterManager FilterManager
        {
            get
            {
                if (this.filterManager == null)
                {
                    this.filterManager = FilterManager.LoadFromFile(Path.Combine(Globals.UserDataDir, "Filters.xml"), XmlSerializableFileCorruptedAction.ShowDialogAndLoadDefaults);
                }
                return this.filterManager;
            }
        }

        public GetDistinctValues GetDistinctValues { get { return this.getDistinctValues; } }

        private void ParseAndProcessAppArgs(string[] args, bool appIsInitialized)
        {
            if (args.Length > 1)
            {
                for (int i = 1; i < args.Length; i++)
                {
                    string arg = args[i];
                    if (arg.StartsWith("ForceParser", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] parts = arg.Split(':');
                        if (parts.Length != 2)
                            throw new InvalidOperationException("Expected format of ForceParser parameters is: ForceParser:ParserName");
                        LogPattern pattern = PatternManager.GetPatternByName(parts[1]);
                        if (pattern == null)
                            throw new InvalidOperationException(String.Format("Forced parser by ForceParser command line parameter: '{0}' doesn't exist", parts[1]));
                        this.forceParser = pattern;
                        args = args.Where((a, idx) => idx != i).ToArray();
                        break;
                    }
                }
                if (args.Length > 1)
                {
                    int line;
                    if (int.TryParse(args[1], out line))
                    {
                        this.goToLineAfterLoad = line;
                    }
                    else
                    {
                        this.goToDateTimeAfterLoad = DateTime.ParseExact(args[1], CommManager.CommDateFormat, CultureInfo.InvariantCulture);
                    }
                }
            }
            if (!appIsInitialized)
                this.fileName = args[0].Replace('"', '\\'); //Will be opened in mainForm_Shown method
            else
                this.OpenLog(args[0]);
        }


        void bookmarkMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            int bookmarkNumber = this.bookmarkButton.DropDownItems.IndexOf(item) + 1;
            logListView.ToggleOrGotoBookmark(bookmarkNumber);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            try
            {
                if (!(SqlFilterEnabled && sqlFilterControl.EditBoxHasFocus))
                {
                    if (shortcutManager.ProcessKey(keyData))
                        return true;
                }
            }
            catch (Exception Ex)
            {
                this.ShowAndLogError("Key Overrided Events Error:" + Ex.Message);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void ReloadLog()
        {
            this.ReloadLog(this.forceParser);
            this.forceParser = null;
        }

        private void ReloadLog(LogPattern logPattern)
        {
            if (String.IsNullOrEmpty(this.fileName))
                return;

            if (this.customlogAdjusters == null)
            {
                this.customlogAdjusters = LogAdjusters.LoadFromFile(Path.Combine(Globals.UserDataDir, "LogAdjusters.xml"), XmlSerializableFileCorruptedAction.ShowDialogAndLoadDefaults);
                this.systemlogAdjusters = LogAdjusters.LoadFromFile(Path.Combine(Globals.AppDataDir, "SystemLogAdjusters.xml"), XmlSerializableFileCorruptedAction.ShowDialogAndLoadDefaults);
            }

            bool fileIsTheSame = logPattern == null && this.logParser != null && this.logParser.LogFileName == this.fileName;

            if (this.logParser != null && this.logParser.LoadingInProgress && !fileIsTheSame)
            {
                this.logParser.LoadingComplete -= logParser_LoadingComplete;
                this.logParser.LoadingError -= logParser_LoadingError;
                this.logLoadingErrorsStatus.Text = String.Empty;
                this.logParser.AbortLoading();
            }

            if (fileIsTheSame)
            {
                this.logParser.LoadingProgress -= logParser_LoadingProgress; //We don't need to update progress for updating same file
            }

            log.DebugFormat("Reloading log: {0}, Pattern: {1}, FileIsTheSame: {2}", this.fileName, logPattern, fileIsTheSame);

            //this.Cursor = Cursors.WaitCursor;
            this.openOtherPartsButton.Enabled = false;
            this.mergeLogPartsButton.Enabled = false;


            try
            {
                this.loadingStatus.Tag = this.loadingStatus.Text; //Save original text

                this.logLoadingStartTime = DateTime.Now;

                if (!fileIsTheSame)
                {
                    this.loadingStatus.Text = "Loading log ...";
                    if (this.findDlg != null)
                    {
                        this.findDlg.Close();
                        this.findDlg.ResetSearchResults();
                    }

                    //Log Parser
                    if (this.logParser != null)
                    {
                        this.logParser.LoadingComplete -= logParser_LoadingComplete;
                        this.logParser.LoadingProgress -= logParser_LoadingProgress;
                        this.logParser.LoadingError -= logParser_LoadingError;
                        this.logLoadingErrorsStatus.Text = String.Empty;
                    }

                    //Clear current logs
                    if (this.logEntries != null)
                    {
                        this.logListView.VirtualListSize = 0;
                        this.logEntries.Clear();
                    }

                    //Init LogAdjuster
                    this.InitLogAdjuster();

                    this.logParser = new LogParser(this.fileName, logPattern);
                    this.parserPatternToolStripStatus.Text = "Parser: " + logParser.LogPattern.FileMask;

                    this.logParser.LoadingComplete += new LogParser.LoadingCompleteEventHandler(logParser_LoadingComplete);
                    this.logParser.LoadingError += new ErrorEventHandler(logParser_LoadingError);
                    if (!fileIsTheSame)
                        this.logParser.LoadingProgress += new EventHandler(logParser_LoadingProgress);

                    //Set columns visible
                    this.logListView.SetColumnsVisibility(logParser);

                    this.logListView.SetColumnSizes();
                    log.Debug("Columns visibility set");

                    //Init SQL filter
                    this.sqlFilterControl.SetAvailableColumns(this.logParser.LogPattern.GetAvailableColumns());
                    sqlFilterControl.Execute += sqlFilterControl_Execute;
                    this.sqlFilterControl.WhereClause = this.settings.MainFormUI.SqlFilterText;

                    //Caption
                    this.Text = "ALV - " + this.fileName;


                    //Comm manager
                    this.CommManager.CurrentLogFileName = this.fileName;
                }

                log.Debug("Loading log entries async");
                logParser.LoadLogEntriesAsync();
            }
            finally
            {
                //this.Cursor = Cursors.Default;
            }
        }

        void sqlFilterControl_Execute(object sender, EventArgs e)
        {
            this.ShowLoadedLog(false, true);
        }

        private void InitLogAdjuster()
        {
            for (int i = this.logAdjusterButton.DropDownItems.IndexOf(this.logAdjusterMenuDivider) - 1; i >= 0; i--)
            {
                this.logAdjusterButton.DropDownItems.RemoveAt(i);
            }
            this.editConfigFileDirectlyToolStripMenuItem.Visible = false;
            this.configureLogAdjusterForThisLogFileToolStripMenuItem.Text = "Select Config file for this Log file to allow log level adjustments ...";
            this.activeLogAdjuster = null;
            this.logAdjusterButton.Image = Resources.LogAdjust;

        }

        private void LoadLogAdjuster()
        {
            this.activeLogAdjuster = this.customlogAdjusters.GetLogAdjuster(this.logParser.BaseLogFileName);

            if (activeLogAdjuster == null)
            {
                this.activeLogAdjuster = this.systemlogAdjusters.GetLogAdjuster(this.logParser.BaseLogFileName);

                if (activeLogAdjuster == null)
                    return;
            }

            List<LogAdjuster.Logger> loggers;
            try
            {
                loggers = this.activeLogAdjuster.GetActiveLogLevels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while loading Log Adjuster", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.editConfigFileDirectlyToolStripMenuItem.Visible = true;
            this.configureLogAdjusterForThisLogFileToolStripMenuItem.Text = "Change Config file for this Log file";

            ToolStripDropDownItem parentItem = this.logAdjusterButton;
            ToolStripDropDownItem additinalLoggersItem = null;
            Func<int> insertBefore = delegate() { return this.logAdjusterButton.DropDown.Items.IndexOf(logAdjusterMenuDivider); };

            for (int i = 0; i < loggers.Count; i++)
            {
                var logger = loggers[i];

                if (i == 1)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem("Additional loggers");
                    this.logAdjusterButton.DropDownItems.Insert(insertBefore(), item);
                    additinalLoggersItem = item;
                    insertBefore = delegate() { return -1; };
                }
                if (i > 0)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(logger.Name);
                    additinalLoggersItem.DropDownItems.Add(item);
                    parentItem = item;
                }

                foreach (string logLevel in activeLogAdjuster.LogLevelsList)
                {
                    CreateLogAdjustMenuItem(parentItem, insertBefore(), logger.Path, logLevel);
                }

                this.LogAdjusterReflectActiveLogLevel(parentItem, logger.ActiveLevel);
            }
        }

        private ToolStripMenuItem CreateLogAdjustMenuItem(ToolStripDropDownItem parentItem, int insertBefore, string path, string logLevel)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(logLevel);
            item.Tag = path;
            item.Name = "LogAdjust_" + logLevel;
            item.ToolTipText = "Set log level in Config file for currently opened log file to: " + logLevel;
            item.Click += new EventHandler(setLogLevelItem_Click);

            item.Image = logListView.GetImageForLogLevel(logLevel);

            if (insertBefore > -1)
                parentItem.DropDownItems.Insert(insertBefore, item);
            else
                parentItem.DropDownItems.Add(item);

            return item;
        }


        private void LogAdjusterReflectActiveLogLevel(ToolStripDropDownItem parentMenuItem, string logLevel)
        {
            ToolStripMenuItem itemToCheck = null;

            for (int i = 0; i < parentMenuItem.DropDownItems.Count; i++)
            {
                if (parentMenuItem.DropDownItems[i] == this.logAdjusterMenuDivider)
                    break;

                ToolStripMenuItem item = parentMenuItem.DropDownItems[i] as ToolStripMenuItem;
                if (item.Name.Equals("LogAdjust_" + logLevel))
                {
                    itemToCheck = item;
                }
                else
                    item.Checked = false;
            }
            if (itemToCheck != null)
            {
                itemToCheck.Checked = true;
                parentMenuItem.Image = itemToCheck.Image;
            }
            else
            {
                //TODO: What to do when log level doesn't exist
                /*
                if (itemToCheck == null)
                    itemToCheck = CreateLogAdjustMenuItem(logLevel);
                */
                MessageBox.Show(String.Format("LogLevel: {0} doesn't exist."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void setLogLevelItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string requiredLogLevel = item.Text;

            try
            {
                activeLogAdjuster.SetActiveLogLevel((string)item.Tag, requiredLogLevel);
                this.LogAdjusterReflectActiveLogLevel((item.OwnerItem as ToolStripDropDownItem), requiredLogLevel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while setting Log Level", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void commManager_GoToItemRequest(object sender, GoToItemRequestEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => commManager_GoToItemRequest(sender, e)));
            }
            else
            {
                log.Debug("CommManager: Go to log item: " + e.GoTo.ToString());
                if (this.WindowState == FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                logListView.GoToLogItem(e.GoTo, false);
            }
        }

        private void logParser_LoadingError(object sender, ErrorEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => logParser_LoadingError(sender, e)));
            }
            else
            {
                string exceptionMessage = e.GetException().Message;
                log.Error("Erorr while loading log:" + exceptionMessage);
                this.logLoadingErrorsStatus.Text = exceptionMessage;
            }
        }

        private void logParser_LoadingProgress(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => logParser_LoadingProgress(sender, e)));
            }
            else
            {
                log.Debug("Loading in progress event");
                this.ShowLoadedLog(true, false);
            }
        }


        private void logParser_LoadingComplete(object sender, LoadingCompleteEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => logParser_LoadingComplete(sender, e)));
            }
            else
            {
                log.Debug("Loading complete event");
                this.lastRefreshStatus.Text = "Last refresh: " + DateTime.Now.ToLongTimeString();
                if (e.LogIsChanged)
                {
                    log.Debug("Log is changed, showing log");
                    if (this.logParser.LogFileExists)
                    {
                        this.lastChangeStatus.Text = "Change: " + DateTime.Now.ToLongTimeString();

                        //ListView
                        this.ShowLoadedLog(false, false);
                        if (this.findDlg != null)
                            this.findDlg.LogHasBeenChanged();

                        if (this.lastCompletelyLoadedLogFileName != this.fileName)
                        {
                            //Buttons
                            this.refreshButton.Enabled = true;
                            this.logAdjusterButton.Enabled = true;
                            this.openInTextEditorButton.Enabled = true;
                            this.logLevelAdjustmentSettingsToolStripMenuItem.Enabled = true;
                            this.exportButton.Enabled = true;
                            this.starFileButton.Enabled = true;
                            this.autoRefreshButton.Enabled = true;
                            this.goToItemButton.Enabled = true;
                            this.bookmarkButton.Enabled = true;
                            this.manageFiltersButton.Enabled = true;
                            this.enableFiltersButton.Enabled = true;
                            this.sqlFilterButton.Enabled = true;
                            this.showOnlyNewItemsButton.Enabled = true;
                            this.manageHighlightsButton.Enabled = true;
                            this.enableHighlightsButton.Enabled = true;
                            this.pluginsMenuItem.Enabled = true;
                            this.textDiffButton.Enabled = true;
                            this.findButton.Enabled = true;
                            this.extractMessageContentButton.Enabled = true;
                            this.logMessageEdit.Enabled = true;

                            //Load file names of other parts of the log
                            this.openOtherPartsButton.DropDown.Items.Clear();
                            foreach (string fileName in this.logParser.AllLogPartsFileNames)
                            {
                                string onlyFileName = Path.GetFileName(fileName);

                                ToolStripMenuItem openItem = new ToolStripMenuItem(onlyFileName);
                                openItem.Click += new EventHandler(openOtherLogsItem_Click);
                                openItem.Tag = fileName;
                                this.openOtherPartsButton.DropDown.Items.Add(openItem);

                                if (fileName.Equals(this.logParser.LogFileName))
                                {
                                    openItem.Enabled = false;
                                    openItem.Font = new Font(openItem.Font, FontStyle.Bold);
                                }
                            }

                            //Load Log Adjuster
                            this.LoadLogAdjuster();

                            //Add log file name into recent file list
                            this.settings.RecentFiles.AddFile(this.settings.MainFormUI.AddOnlyBaseNameInRecentList ? this.logParser.BaseLogFileName : this.fileName);
                            this.LoadRecentFiles();

                            //This log was completely loaded
                            this.lastCompletelyLoadedLogFileName = this.fileName;
                        }
                        else
                        {
                            SetChangeReadedStatus(logListView.GetSelectedListItem());
                        }
                    }
                    else
                    {
                        log.Warn("Log file doesn't exist.");

                        this.ShowLoadedLog(false, true);

                        this.lastChangeStatus.Text = "Log file doesn't exist.";
                        this.goToItemButton.Enabled = false;
                        this.bookmarkButton.Enabled = false;
                        this.manageFiltersButton.Enabled = false;
                        this.enableFiltersButton.Enabled = false;
                        this.sqlFilterButton.Enabled = false;
                        this.showOnlyNewItemsButton.Enabled = false;
                        this.manageHighlightsButton.Enabled = false;
                        this.enableHighlightsButton.Enabled = false;
                        this.pluginsMenuItem.Enabled = false;
                        this.textDiffButton.Enabled = false;
                        this.findButton.Enabled = false;
                    }
                }
                else
                {
                    log.Debug("Log isn't changed");
                }
                this.openOtherPartsButton.Enabled = this.logParser.AllLogPartsFileNames.Count > 0;
                this.mergeLogPartsButton.Enabled = this.logParser.AllLogPartsFileNames.Count > 0;

                if (e.LogIsChanged)
                    this.loadingStatus.Text = String.Format("Log loaded in: {0:N} s", (DateTime.Now - logLoadingStartTime).TotalSeconds);
                else
                    this.loadingStatus.Text = this.loadingStatus.Tag.ToString();
            }
        }

        public void ShowLoadedLog(bool loadingInProgress, bool resetSearchResults)
        {
            if (this.logParser == null)
                return;

            if (resetSearchResults && this.findDlg != null)
                findDlg.ResetSearchResults();

            log.Debug("ShowLoadedLog, loading in progress: " + loadingInProgress.ToString());
            LogListViewItem selListItem = logListView.GetSelectedListItem();
            LogEntry prevSelectedItem = selListItem == null ? null : selListItem.LogItem;
            int prevCountOfShownItems = this.logListView.VirtualListSize;
            bool lastItemSelected = selListItem != null && selListItem.Index == this.logListView.VirtualListSize - 1;

            lock (this.logParser.LogEntriesLocker)
            {
                bool itemsFiltered = false;
                IEnumerable<LogEntry> entries = this.logParser.LogEntries;
                if (!loadingInProgress)
                {
                    if (SqlFilterEnabled)
                    {
                        entries = sqlFilterControl.FilterLogEntries(entries, out itemsFiltered);
                        log.Debug(itemsFiltered ? "SQL Filtering enabled" : "SQL Filtering disabled");
                    }

                    if (this.FiltersEnabled || this.FilterManager.CurrentFilter.DateTimeRange.Enabled)
                    {
                        itemsFiltered = true;
                        log.Debug("Filtering enabled");
                        FilterEntry filter = this.FilterManager.CurrentFilter;
                        List<KeyValuePair<bool, string>> filterMessages = filter.Messages.GetItemsWithColorHighlights(this.ColorHighlightManager.CurrentGroup.Highlights);

                        log.Debug("Building query with filters");

                        bool filtersEnabled = this.enableFiltersButton.Checked;
                        entries = from logEntry in entries
                                  where (filter.DateTimeRange.Match(logEntry.Date)) &&
                                              (!filtersEnabled ||
                                              (
                                                (filter.Threads.Match(logEntry.Thread)) &&
                                                (filter.Types.Match(logEntry.Type)) &&
                                                (filter.Classes.Match(logEntry.Class)) &&
                                               (filter.Messages.Match(logEntry.Message, filterMessages))
                                              ))
                                  select logEntry;
                    }
                }

                this.logEntries = entries.ToList(); //We need to get copy of the logParser's entries to avoid locking during work with the collection
                if (itemsFiltered)
                {
                    this.totalItemsStatus.Text = String.Format("Total items: {0} / {1}", this.logEntries.Count, this.logParser.LogEntries.Count);
                    this.totalItemsStatus.Font = new Font(this.totalItemsStatus.Font, FontStyle.Bold);
                    log.Debug("logEntries are filtered now");

                }
                else
                {
                    log.Debug("Loading all entries");
                    this.totalItemsStatus.Text = "Total items: " + this.logEntries.Count.ToString();
                    this.totalItemsStatus.Font = new Font(this.totalItemsStatus.Font, FontStyle.Regular);
                }
            }
            logListView.IndicateCurrentFiltersInColumnHeaders();

            //this.SuspendLayout();
            this.logListView.BeginUpdate();
            try
            {
                this.logListView.VirtualListSize = this.logEntries.Count;
            }
            catch (Exception ex)
            {
                log.Error("Error while setting VirtualListSize: " + ex.ToString());
            }



            this.logListView.EndUpdate();
            //this.ResumeLayout(false);

            this.totalLinesStatus.Text = "Lines: " + this.logParser.LinesCount.ToString();

            if (logListView.GetSelectedListItem() == null)
            {
                logListView.GoToLogItem(0, true);
            }

            if (!loadingInProgress)
            {
                log.Debug("Show markers...");
                this.ShowMarkers();

                if ((!this.logParser.ForcedLogPattern) && (this.logParser.LinesCount > 2) && (this.logParser.LogEntriesCount == 0))
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        ShowAndLogError(@"There is not suitable parser pattern for this log file. Please add appropriate custom pattern in following dialog.");

                        this.manageParsersMenuItem.PerformClick();
                    }));
                }


                log.Debug("Select some item");
                if (this.goToLineAfterLoad != null)
                {
                    log.Debug("Go to line after load: " + goToLineAfterLoad.Value.ToString());
                    logListView.GoToLine(this.goToLineAfterLoad.Value);
                    this.goToLineAfterLoad = null;
                }
                if (this.goToDateTimeAfterLoad != null)
                {
                    log.Debug("Go to date after load: " + goToDateTimeAfterLoad.Value.ToString());
                    logListView.GoToLogItem(goToDateTimeAfterLoad.Value, false);
                    this.goToDateTimeAfterLoad = null;
                }
                else if (this.autoRefreshButton.Checked && this.settings.MainFormUI.AutoScrollWhenAutoRefresh &&
                    this.logListView.VirtualListSize > 0 && prevCountOfShownItems != this.logListView.VirtualListSize)
                {
                    if (lastItemSelected)
                    {

                        log.Debug("Autoscroll enabled, going to item: " + (this.logListView.VirtualListSize - 1).ToString());
                        if (this.settings.MainFormUI.AutoScrollShowTwoItems)
                        {
                            if (this.logListView.SelectedIndices.Count == 2) //Hack to always select last from previous refresh and last from current refresh
                                this.prevSelectedListItem = this.logListView.Items[this.logListView.SelectedIndices[0]];
                        }
                        logListView.GoToLogItem(this.logListView.VirtualListSize - 1, !this.settings.MainFormUI.AutoScrollShowTwoItems);
                    }
                    else
                    {
                        log.Debug("Autoscroll enabled, but last item wasn't selected.");
                    }
                }
                else
                {
                    if (this.logListView.VirtualListSize == 0 || prevSelectedItem == null)
                    {
                        log.Debug("Refreshing message detail");
                        RefreshMessageDetail(logListView.GetSelectedListItem(), false);
                    }
                    else
                    {
                        selListItem = logListView.GetSelectedListItem();
                        if (selListItem == null || selListItem.LogItem != prevSelectedItem)
                        {
                            log.Debug("Going to previously selected item");
                            if (!logListView.GoToLogItem(prevSelectedItem))
                                logListView.GoToLogItem(prevSelectedItem.Date, false);
                        }
                        else
                        {
                            log.Debug("The same item is already selected, refreshing message detail");
                            RefreshMessageDetail(selListItem, false);
                        }
                    }
                }
            }
        }

        private void SetChangeReadedStatus(ListViewItem selectedItem)
        {
            bool readed = selectedItem != null && selectedItem.Index == this.logListView.VirtualListSize - 1;

            if (lastChangeReaded != readed)
            {
                lastChangeReaded = readed;
                this.lastChangeStatus.Font = new Font(this.lastChangeStatus.Font, lastChangeReaded ? FontStyle.Regular : FontStyle.Bold);
            }
        }


        private void LoadRecentFiles()
        {
            for (int i = openFileButton.DropDown.Items.Count - 1; i > 1; i--)
            {
                openFileButton.DropDown.Items.RemoveAt(i);
            }
            this.starFileButton.Image = Resources.Star_Gray;
            this.starFileButton.Tag = null;
            int numberShortCut = 0;
            foreach (string recentFile in this.settings.RecentFiles.FileListFavorites)
            {
                string text = numberShortCut < 10 ? numberShortCut++.ToString() + " - " + recentFile : recentFile;
                var item = new ToolStripMenuItem(text);
                item.Name = recentFile;
                item.Click += new EventHandler(recentFileItem_Click);
                item.Image = Resources.Star_Yellow;
                item.ImageTransparentColor = Color.Magenta;
                openFileButton.DropDown.Items.Add(item);

                if (this.fileName != null && this.starFileButton.Tag == null && this.fileName.Equals(recentFile, StringComparison.OrdinalIgnoreCase))
                {
                    this.starFileButton.Image = Resources.Star_Yellow;
                    this.starFileButton.Tag = true;
                }
            }
            if (this.settings.RecentFiles.FileListFavorites.Count > 0 && this.settings.RecentFiles.FileList.Count > 0)
            {
                var separator = new ToolStripSeparator();
                openFileButton.DropDown.Items.Add(separator);
            }
            foreach (string recentFile in this.settings.RecentFiles.FileList)
            {
                string text = numberShortCut < 10 ? numberShortCut++.ToString() + " - " + recentFile : recentFile;
                var item = new ToolStripMenuItem(text);
                item.Name = recentFile;
                item.Click += new EventHandler(recentFileItem_Click);

                openFileButton.DropDown.Items.Add(item);
            }
        }



        private void RefreshMessageDetail(LogListViewItem listItem, bool forceRefresh)
        {
            if (listItem == null)
            {
                logMessageEdit.Text = String.Empty;
                currentItemStatus.Text = String.Empty;
                currentLineStatus.Text = String.Empty;
                return;
            }
            if (logMessageEdit.Visible)
            {
                if (forceRefresh || prevSelectedListItem == null || prevSelectedListItem.Index != listItem.Index)
                {
                    LogEntry logEntry = listItem.LogItem;
                    logMessageEdit.Text = "";
                    logMessageEdit.SelectionColor = SystemColors.GrayText;
                    logMessageEdit.AppendText(logParser.GetFormattedMessageDetailHeader(logEntry));
                    logMessageEdit.SelectionColor = SystemColors.WindowText;
                    logMessageEdit.AppendText(logEntry.Message);


                    if (settings.MainFormUI.EnableHighlights)
                        ColorHighlightManager.CurrentGroup.HighlightTextInMessageDetail(logMessageEdit);

                    logMessageEdit.SelectionStart = 0;
                    logMessageEdit.SelectionLength = 0;
                }

            }
            currentItemStatus.Text = "Current item: " + (listItem.Index + 1).ToString();
            currentLineStatus.Text = "Line: " + listItem.LogItem.LineInFile;
        }

        private void GoToSameTimeInAnotherLog(Guid anotherLogID)
        {
            LogListViewItem selectedItem = logListView.GetSelectedListItem();
            if (selectedItem == null)
                return;

            this.CommManager.GoToTimeInAnotherLog(anotherLogID, selectedItem.LogItem.Date);
        }

        private void ShowPrevLogFilePart()
        {
            int idx = this.logParser.AllLogPartsFileNames.IndexOf(this.logParser.LogFileName) - 1;
            if (idx >= 0)
            {
                string prevFileName = this.logParser.AllLogPartsFileNames[idx];
                this.OpenLog(prevFileName);
            }
        }

        private void ShowNextLogFilePart()
        {
            int idx = this.logParser.AllLogPartsFileNames.IndexOf(this.logParser.LogFileName) + 1;
            if (idx < this.logParser.AllLogPartsFileNames.Count)
            {
                string nextFileName = this.logParser.AllLogPartsFileNames[idx];
                this.OpenLog(nextFileName);
            }
        }
        private void OpenLog(string fileName)
        {
            this.OpenLog(fileName, true);
        }

        private void OpenLog(string fileName, bool focusOnListView)
        {
            log.Debug("Open log: " + fileName);
            if (!File.Exists(fileName))
            {
                this.ShowAndLogError(String.Format("File: {0} doesn't exists.", fileName));
                return;
            }

            this.fileName = fileName;
            this.logListView.Enabled = true;

            if (focusOnListView)
                this.logListView.Focus();

            this.ReloadLog();
        }


        private void ShowMarkers()
        {
            if (this.settings.MainFormUI.ShowMarkers)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object threadContext)
                {
                    log.Debug("Showing markers");

                    try
                    {
                        Dictionary<int, Color> markers = new Dictionary<int, Color>();
                        for (int i = 0; i < this.logEntries.Count; i++)
                        {
                            LogEntry logEntry = this.logEntries[i];
                            if (logEntry.LogType == LogType.ERROR ||
                                logEntry.LogType == LogType.FATAL ||
                                logEntry.LogType == LogType.WARN)
                            {
                                markers.Add(i, this.logListView.LogTypeColors[(int)logEntry.LogType]);
                            }
                        }

                        this.markerPanel.ShowMarkers(this.logEntries.Count, markers);

                        log.Debug("Markers are shown");
                    }
                    catch (Exception ex)
                    {
                        log.Error("Error while showing markers: " + ex.ToString());
                    }
                }));
            }
            else
            {
                log.Debug("Markers panel isn't shown, markers will be not loaded.");
            }
        }

        private void TryLogPatternOnCurrentLog(LogPattern logPattern)
        {
            this.ReloadLog(logPattern);
        }

        private void ShowAndLogError(string errorMessage)
        {
            log.Error(errorMessage);
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetBookmarkMenuItemText(int bookmarkNumber, string text)
        {
            ToolStripItem item = this.bookmarkButton.DropDownItems[bookmarkNumber - 1];
            item.ToolTipText = String.IsNullOrEmpty(text) ? "Click to set bookmark on current line." : "Click to go to this bookmark.";
            item.Text = "(" + bookmarkNumber.ToString() + ") - " + (String.IsNullOrEmpty(text) ? "Empty" : text);
        }

        private bool ShowSettingsDialog(string additionalTextInCaption, bool firstTimeShown)
        {
            using (SettingsDlg dlg = new SettingsDlg(this.settings, firstTimeShown))
            {
                log.Debug("Settings...");
                if (!String.IsNullOrEmpty(additionalTextInCaption))
                    dlg.Text += additionalTextInCaption;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    log.Debug("Settings OK");

                    //Reflect settings
                    this.markersPanelParent.Visible = this.settings.MainFormUI.ShowMarkers;
                    if (this.settings.MainFormUI.ShowMarkers)
                        this.ShowMarkers();
                    this.autoRefreshTimer.Interval = this.settings.MainFormUI.AutoRefreshPeriod;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private int GetKeyNumber(Keys keys)
        {
            return (int)(keys & (Keys.D0 | Keys.D1 | Keys.D2 | Keys.D3 | Keys.D4 | Keys.D5 | Keys.D6 | Keys.D7 | Keys.D8 | Keys.D9));
        }


        private void softwareUpdatesClient_UpdateCheckStarted(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => softwareUpdatesClient_UpdateCheckStarted(sender, e)));
            }
            else
            {
                SetUpdatesStatusText("Checking for ALV update...");
            }
        }


        private void softwareUpdatesClient_UpdateNotFound(object sender, UpdateEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => softwareUpdatesClient_UpdateNotFound(sender, e)));
            }
            else
            {
                SetUpdatesStatusText("ALV is up to date.");
                if (!e.SkipIfPeriodNotElapsed) //SkipIfPeriodNotElapsed is true when it's automatic check
                    MessageBox.Show(String.Format("No updates were found, this is the latest version {0}.", this.ProductVersion.ToString()), "Software update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void updatesClient_UpdateError(object sender, UpdateEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => updatesClient_UpdateError(sender, e)));
            }
            else
            {
                log.ErrorFormat("Error while checking updates: " + e.Description);
                SetUpdatesStatusText("Error while checking updates.");
                this.checkForUpdatesStatus.ForeColor = Color.Red;

                if (!e.SkipIfPeriodNotElapsed)
                    MessageBox.Show(e.Description, "Error while checking updates...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SoftwaresUpdateClient_UpdateFound(object sender, UpdateFoundEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => SoftwaresUpdateClient_UpdateFound(sender, e)));
            }
            else
            {
                SetUpdatesStatusText("Newer version of ALV has been found.");
                bool updateApplied = false;
                updateApplied = e.ShowUiAndAskForUpdateDownload(this, "Advanced Log Viewer", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    Globals.IsPortable ? UpdateType.Portable : UpdateType.MSI);
                if (updateApplied)
                    this.Close();
            }
        }

        void softwareUpdatesClient_UpdateCheckFinished(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => softwareUpdatesClient_UpdateCheckFinished(sender, e)));
            }
            else
            {
                if (checkForUpdatesStatus.Text == "Checking for ALV update...")
                    SetUpdatesStatusText("");
                else
                    this.eraseUpdatesStatusCheckTimer.Enabled = true;
            }
        }

        void SetUpdatesStatusText(string text)
        {
            eraseUpdatesStatusCheckTimer_Tick(this.eraseUpdatesStatusCheckTimer, null);
            this.checkForUpdatesStatus.Text = text;
        }

        void eraseUpdatesStatusCheckTimer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = (sender as System.Windows.Forms.Timer);
            timer.Enabled = false;
            this.checkForUpdatesStatus.Text = "";
            this.checkForUpdatesStatus.ForeColor = SystemColors.ControlText;
        }


        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            this.logListView.SetColumnSizes();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {

            Array a = (Array)e.Data.GetData(DataFormats.FileDrop);

            if (a != null)
            {
                // Extract string from first array element
                // (ignore all files except first if number of files are dropped).

                string s = a.GetValue(0).ToString();

                // Call OpenFile asynchronously.
                // Explorer instance from which file is dropped is not responding
                // all the time when DragDrop handler is active, so we need to return
                // immidiately (especially if OpenFile shows MessageBox).

                this.BeginInvoke(new MethodInvoker(() => this.OpenLog(s)));
                this.Activate();        // in the case Explorer overlaps this form
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.logParser != null)
                {
                    logParser.AbortLoading();
                }

                this.settings.MainFormUI.SqlFilterText = this.sqlFilterControl.WhereClause;

                this.settings.Save();
                if (this.findDlg != null)
                    this.findDlg.SaveSettings();
            }
            catch (Exception ex)
            {
                log.Error("Error during form closing: " + ex.ToString());
            }
            e.Cancel = false;
        }

        private void openOtherLogsItem_Click(object sender, EventArgs e)
        {
            this.OpenLog((sender as ToolStripMenuItem).Tag as string);
        }


        private void openOtherPartsButton_ButtonClick(object sender, EventArgs e)
        {
            int idx = this.logParser.AllLogPartsFileNames.IndexOf(this.logParser.LogFileName);
            idx = idx == this.logParser.AllLogPartsFileNames.Count - 1 ? 0 : idx + 1;
            string nextFileName = this.logParser.AllLogPartsFileNames[idx];
            if (nextFileName == null)
            {
                nextFileName = this.openOtherPartsButton.DropDown.Items[0].Tag as string;
            }

            this.OpenLog(nextFileName);
        }

        private void recentFileItem_Click(object sender, EventArgs e)
        {
            log.Debug("Recent file menu click: " + ((ToolStripMenuItem)sender).Name);
            this.OpenLog(((ToolStripMenuItem)sender).Name);
        }

        private void logListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            try
            {
                e.Item = new LogListViewItem(this.logEntries.ElementAt(e.ItemIndex), this.enableHighlightsButton.Checked ? this.ColorHighlightManager.CurrentGroup : null, this.findDlg != null && this.findDlg.Visible);
            }
            catch (Exception ex)
            {
                ShowAndLogError("Exception while retrieving virtual item: " + ex.ToString());

            }
        }

        private void logListView_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (logListView.SelectedIndices.Count > 1)
                {
                    for (int i = this.logListView.SelectedIndices.Count - 2; i > 0; i--)
                    {
                        this.logListView.Items[this.logListView.SelectedIndices[i]].Selected = false;
                    }

                    ListViewItem item = this.logListView.Items[e.EndIndex];
                    this.logListView_ItemSelectionChanged(this.logListView, new ListViewItemSelectionChangedEventArgs(item, item.Index, true));
                }
            }
        }

        private void logListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //Unselect more than 2 selected items
            if (logListView.SelectedIndices.Count > 2)
            {
                this.prevSelectedListItem.Selected = false;
            }

            RefreshMessageDetail(e.Item as LogListViewItem, false);

            if (e.IsSelected)
                this.prevSelectedListItem = e.Item;


            if (e.IsSelected && e.Item != null)
            {
                foreach (Guid id in this.synchronizeAnotherLogs)
                {
                    this.GoToSameTimeInAnotherLog(id);
                }
            }

            if (e.IsSelected && logListView.SelectedIndices.Count == 2 && this.logParser.DateIsParsed)
            {
                this.timeSpanBetweenTwoItems.Visible = true;
                DateTime date1 = ((LogListViewItem)logListView.Items[logListView.SelectedIndices[0]]).LogItem.Date;
                DateTime date2 = ((LogListViewItem)logListView.Items[logListView.SelectedIndices[1]]).LogItem.Date;
                TimeSpan timeSpan = date1 > date2 ? date1 - date2 : date2 - date1;
                this.timeSpanBetweenTwoItems.Text = "Time span: " + String.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
            }
            else
            {
                this.timeSpanBetweenTwoItems.Visible = false;
            }

            if (!lastChangeReaded)
                SetChangeReadedStatus(e.Item);
        }

        private void autoRefreshButton_CheckedChanged(object sender, EventArgs e)
        {
            log.Debug("Autorefresh button click");
            this.autoRefreshTimer.Enabled = this.autoRefreshButton.Checked;
            this.settings.MainFormUI.AutoRefresh = this.autoRefreshButton.Checked;


            this.settings.MainFormUI.AutoRefresh = this.autoRefreshButton.Checked;
            this.autoRefreshButton.Image = this.autoRefreshButton.Checked ? Resources.Pause : Resources.Play;

            int logEntriesCount = this.logParser == null ? -1 : this.logParser.LogEntriesCount;
            if (this.settings.MainFormUI.AutoRefresh && this.settings.MainFormUI.AutoScrollWhenAutoRefresh &&
                logEntriesCount > 0)
            {
                logListView.GoToLogItem(logEntriesCount - 1, true);
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (this.logParser != null && this.logParser.LoadingInProgress)
                return;
            this.ReloadLog();
        }

        private void manageHighlightsButton_Click(object sender, EventArgs e)
        {
            using (ManageHighlights dlg = new ManageHighlights(this.ColorHighlightManager))
            {
                log.Debug("Manage highlights...");
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    log.Debug("Manage highlights OK");
                    if (!this.enableHighlightsButton.Checked)
                    {
                        this.enableHighlightsButton.Checked = true;
                        this.settings.MainFormUI.EnableHighlights = this.enableHighlightsButton.Checked;
                    }

                    logListView.Refresh();
                    this.RefreshMessageDetail(logListView.GetSelectedListItem(), true);
                }
            }
        }

        private void manageFiltersButton_Click(object sender, EventArgs e)
        {
            lock (logParser.LogEntriesLocker)
            {
                if (logParser == null || logParser.LogEntries.Count == 0)
                    return;

                if (logParser.DateIsParsed)
                {
                    if (this.FilterManager.CurrentFilter.DateTimeRange.From == DateTime.MinValue)
                    {
                        this.FilterManager.CurrentFilter.DateTimeRange.From = logParser.LogEntries[0].Date;
                        this.FilterManager.CurrentFilter.DateTimeRange.To = logParser.LogEntries[logParser.LogEntries.Count - 1].Date;
                    }
                }
            }
            log.Debug("Manage filters...");

            using (ManageFilters dlg = new ManageFilters(this.FilterManager, this.logParser.DateIsParsed, logListView.GetSelectedListItem() == null ? null : logListView.GetSelectedListItem().LogItem, getDistinctValues))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    log.Debug("Manage filters OK");

                    if (!this.enableFiltersButton.Checked)
                    {
                        this.enableFiltersButton.Checked = true;
                        this.settings.MainFormUI.EnableFilter = this.enableFiltersButton.Checked;
                    }

                    this.ShowLoadedLog(false, true);
                }
            }
        }

        private void goToItemButton_Click(object sender, EventArgs e)
        {
            logListView.GotoLogItemWithDialog();
        }

        private void goToItemInAnotherLogMenuItem_Click(object sender, EventArgs e)
        {
            this.GoToSameTimeInAnotherLog(((LogViewerInstanceToolStripItem)sender).LogInstance.ID);
        }

        private void synchronizeAnotherLogMenuItem_Click(object sender, EventArgs e)
        {
            LogViewerInstance instance = ((LogViewerInstanceToolStripItem)sender).LogInstance;

            if (this.synchronizeAnotherLogs.IndexOf(instance.ID) > -1)
            {
                this.synchronizeAnotherLogs.Remove(instance.ID);
            }
            else
            {
                this.synchronizeAnotherLogs.Add(instance.ID);
                this.GoToSameTimeInAnotherLog(instance.ID);
            }
        }

        private void openLogAndGoToTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lastGoToDateFile))
            {
                this.openFileDialog.InitialDirectory = Path.GetDirectoryName(lastGoToDateFile);
            }
            else if (!String.IsNullOrEmpty(this.fileName))
                this.openFileDialog.InitialDirectory = Path.GetDirectoryName(this.fileName);


            if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.lastGoToDateFile = this.openFileDialog.FileName;
                Process.Start(Application.ExecutablePath, String.Format("{0}{1}{0} {0}{2}{0}", '"', this.openFileDialog.FileName, logListView.GetSelectedListItem().LogItem.Date.ToString(CommManager.CommDateFormat)));
            }
        }

        private void openLogAndSynchronizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Priority: low");
        }

        private void logViewContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (logListView.GetSelectedListItem() == null)
            {
                e.Cancel = true;
                return;
            }

            //Synchronization with another LogViewers

            //Remove current instaces from menu
            for (int i = this.goToSameTimeInAnotherLogMenuItem.DropDownItems.Count - 1; i > 1; i--)
            {
                this.goToSameTimeInAnotherLogMenuItem.DropDownItems.RemoveAt(i);
            }

            for (int i = this.synchronizeAnotherLogToolStripMenuItem.DropDownItems.Count - 1; i > 1; i--)
            {
                this.synchronizeAnotherLogToolStripMenuItem.DropDownItems.RemoveAt(i);
            }


            //Get other instances of LogViewer
            List<LogViewerInstance> instances = this.CommManager.GetListOfOtherInstances().Where(lvi => lvi.LogFileName != String.Empty).ToList();


            //Check currently sychronized instances, if doesn't exits, remove it from synchronization list
            for (int i = this.synchronizeAnotherLogs.Count - 1; i >= 0; i--)
            {
                if (!instances.Exists(instance => instance.ID == this.synchronizeAnotherLogs[i]))
                    this.synchronizeAnotherLogs.RemoveAt(i);
            }

            //Populate menu items
            foreach (var instance in instances)
            {
                //Go to
                LogViewerInstanceToolStripItem menuItem = new LogViewerInstanceToolStripItem(instance);
                menuItem.Click += new EventHandler(goToItemInAnotherLogMenuItem_Click);
                this.goToSameTimeInAnotherLogMenuItem.DropDownItems.Add(menuItem);

                //Synchronize
                menuItem = new LogViewerInstanceToolStripItem(instance);
                menuItem.Click += new EventHandler(synchronizeAnotherLogMenuItem_Click);
                menuItem.Checked = this.synchronizeAnotherLogs.IndexOf(instance.ID) > -1;
                this.synchronizeAnotherLogToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }


        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.fileName))
                this.openFileDialog.InitialDirectory = Path.GetDirectoryName(this.fileName);

            if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.OpenLog(this.openFileDialog.FileName);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.ReloadLog();
        }

        private void enableFiltersButton_Click(object sender, EventArgs e)
        {
            log.Debug("EnableFilters button click");

            this.ShowLoadedLog(false, true);

            this.settings.MainFormUI.EnableFilter = this.enableFiltersButton.Checked;
        }

        private void enableHighlightsButton_Click(object sender, EventArgs e)
        {
            log.Debug("EnableHighlights button click");
            this.settings.MainFormUI.EnableHighlights = this.enableHighlightsButton.Checked;

            logListView.Refresh();
            this.RefreshMessageDetail(logListView.GetSelectedListItem(), true);
        }


        private void pluginItem_Click(object sender, EventArgs e)
        {
            this.plugins[(Guid)(((ToolStripMenuItem)sender).Tag)].Execute(this.logEntries, this, this.logListView);
        }

        private void removeNonexistingRecentFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.RecentFiles.RemoveNonExistingFiles();
            this.LoadRecentFiles();
        }

        /// <summary>Remove log parts and replace them by base log filenames (e.g. instead of x.log.2 show x.log)</summary>
        private void ReplaceRecentFileNamesByBaseFileNames()
        {
            if (settings.MainFormUI.AddOnlyBaseNameInRecentList)
            {
                settings.RecentFiles.ReplaceFileNamesByBaseNames(LogParser.GetBaseLogFileName);
            }

            this.LoadRecentFiles();
        }

        private void logMessageEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                logMessageEdit.SelectAll();
                e.Handled = true;
            }
        }

        private void pluginsNotFoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you want to write your own plugin for analyse logs, just implement IAnalyseLogPlugin interface from AdvancedLogViewer.Common assembly in some your class and put your DLL into same directory as is AdvancedLogViewer.exe.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mergeLogPartsButton_Click(object sender, EventArgs e)
        {
            using (MergeLogParts dlg = new MergeLogParts())
            {
                string mergedFileName = dlg.MergeLogs(this.logParser.AllLogPartsFileNames, this);
                if (!String.IsNullOrEmpty(mergedFileName))
                {
                    this.OpenLog(mergedFileName);
                }
            }
        }

        private void markerPanel_MarkClick(object sender, MarkPanelClickEventArgs e)
        {
            log.Debug("Marker panel click");
            logListView.GoToLogItem(e.LineNumber, true);
        }

        private void commManager_AnotherInstanceOpenedLogFile(object sender, AnotherInstanceOpenedLogFileEventArgs e)
        {
            this.settings.RecentFiles.AddFile(e.FileName);
            //this.LoadRecentFiles();
        }

        private void manageParsersMenuItem_Click(object sender, EventArgs e)
        {
            log.Debug("Manage parsers button click");

            TryLogPatternOnLogFile callback = null;
            if (!String.IsNullOrEmpty(this.fileName))
                callback = this.TryLogPatternOnCurrentLog;

            using (ManageParserPatterns dlg = new ManageParserPatterns(callback, this.fileName))
            {
                dlg.ShowDialog(this);
            }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutDialog dlg = new AboutDialog())
            {
                dlg.ShowDialog(this);
            }
        }

        private void textDiffButton_Click(object sender, EventArgs e)
        {
            log.Debug("Text diff button click");

            if (logListView.SelectedIndices.Count != 2)
            {
                MessageBox.Show("Select two log items which you want to compare. To select second log item, use CTRL + Click on second item.", "Select second item", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ExternalTextDiff diff = new ExternalTextDiff(this.settings.TextDiff.DiffPath, this.settings.TextDiff.DiffParameters);

            LogListViewItem item1 = logListView.Items[logListView.SelectedIndices[0]] as LogListViewItem;
            LogListViewItem item2 = logListView.Items[logListView.SelectedIndices[1]] as LogListViewItem;

            if (item1.LogItem.Message.Equals(item2.LogItem.Message))
            {
                MessageBox.Show("These two texts are identical.", "No difference", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                diff.DiffText(item1.LogItem.Message, item2.LogItem.Message, item1.LogItem.DateText.Replace(':', ';'), item2.LogItem.DateText.Replace(':', ';'));
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("External diff tool: " + ex.FileName + " not found.", "Diff error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.settingsMenuItem.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Diff error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pluginsMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (this.plugins == null)
            {
                //Load plugins
                this.plugins = PluginManager.GetPlugins<IAnalyseLogPlugin>(Application.StartupPath);
                if (this.plugins.Count > 0)
                {
                    this.pluginsContextMenu.Items.Clear();
                    foreach (IAnalyseLogPlugin plugin in this.plugins.Values)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem(plugin.PluginTitle);
                        item.Tag = plugin.PluginGuid;
                        item.Click += new EventHandler(pluginItem_Click);
                        this.pluginsContextMenu.Items.Add(item);
                    }
                }
            }
        }

        private void stayOnTopButton_Click(object sender, EventArgs e)
        {
            this.TopMost = stayOnTopButton.Checked;
            this.settings.MainFormUI.StayOnTop = this.stayOnTopButton.Checked;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            this.FindDlg.Show(this.fileName, this.logParser.LogPattern.PatternItems);
        }

        private void bookmarkButton_ButtonClick(object sender, EventArgs e)
        {
            LogListViewItem selectedItem = logListView.GetSelectedListItem();
            if (selectedItem == null)
                return;

            if (selectedItem.LogItem.Bookmark > 0)
            {
                logListView.ToggleBookmark(selectedItem.LogItem.Bookmark);
            }
            else
            {
                logListView.SetFirstEmptyBookmark();
            }
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ShowSettingsDialog(String.Empty, false))
            {
                if (this.settings.MainFormUI.AddOnlyBaseNameInRecentList)
                    this.ReplaceRecentFileNamesByBaseFileNames();
            }
        }


        private List<string> GetListOfLogEntriesInLock(Func<List<LogEntry>, IEnumerable<string>> fnc)
        {
            lock (this.logParser.LogEntriesLocker)
            {
                return fnc(this.logParser.LogEntries).ToList();
            }
        }


        private void showOnlyNewItemsButton_Click(object sender, EventArgs e)
        {
            FilterEntry.FilterItemDate filter = this.FilterManager.CurrentFilter.DateTimeRange;


            filter.FromEnabled = true;
            filter.From = DateTime.Now;
            filter.ToEnabled = false;
            filter.Enabled = true;

            this.ShowLoadedLog(false, true);
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.softwareUpdatesClient.CheckForUpdate(false, true, true);
        }


        private ColorHighlightManager colorHighlightManager;


        private CommManager CommManager
        {
            get
            {
                if (this.commManager == null)
                {
                    //Comm manager
                    this.commManager = new CommManager();
                    this.commManager.GoToItemRequest += new CommManager.GoToItemRequestEventHandler(commManager_GoToItemRequest);
                    this.commManager.ProcessAppArgs += new CommManager.ProcessAppArgsEventHandler(commManager_ProcessAppArgs);
                    this.commManager.AnotherInstanceOpenedLogFile += new CommManager.AnotherInstanceOpenedLogFileEventHandler(commManager_AnotherInstanceOpenedLogFile);
                }
                return this.commManager;
            }
        }


        void commManager_ProcessAppArgs(object sender, ProcessAppArgsEventArgs e)
        {
            this.ParseAndProcessAppArgs(e.Args, true);
            this.Activate();
        }

        /*private FindTextDlg FindDlg
        {
            get
            {
                if (this.findDlg == null)
                {
                    this.findDlg = new FindTextDlg(this,
                                                   () => this.logEntries,
                                                   (GetLogListItemType type) => logListView.GetLogListItem(type),
                                                   (int itemIndex) => logListView.GoToLogItem(itemIndex, true),
                                                   this.logMessageEdit);
                }
                return this.findDlg;
            }
        }*/

        private FindTextDlg FindDlg
        {
            get
            {
                if (this.findDlg == null)
                {
                    var context = new FindDialogContext(
                                                       () => this.logEntries,
                                                       (GetLogListItemType type) => logListView.GetLogListItem(type),
                                                       (LogEntry entry) => logListView.GoToLogItem(entry),
                                                       this.logMessageEdit,
                                                       () => this.logListView.Invalidate(),
                                                       (bool visible) => { this.searchMarkersPanelParent.Visible = visible; this.logListView.SetColumnSizes(); },
                                                       this.searchMarkerPanel.ShowMarkers,
                                                       (int dlgWidth) => GetLocationForSearchWindow(dlgWidth)
                                                   );

                    this.findDlg = new FindTextDlg(this, context);
                }
                return this.findDlg;
            }
        }

        private Point GetLocationForSearchWindow(int dialogWidth)
        {
            Point logListViewLocation = this.logListView.PointToScreen(this.logListView.Location);
            return new Point(logListViewLocation.X + logListView.ClientSize.Width - dialogWidth, logListViewLocation.Y);
        }

        private LogBrowserDlg LogBrowser
        {
            get
            {
                if (this.logBrowser == null)
                {
                    this.logBrowser = new LogBrowserDlg(this.OpenLog, this, this.ShowSettingsDialog);
                }
                return this.logBrowser;
            }
        }



        private void starFileButton_Click(object sender, EventArgs e)
        {
            settings.RecentFiles.AddFile(this.fileName, starFileButton.Tag == null);
            this.LoadRecentFiles();
        }

        private void extractMessageContentButton_ButtonClick(object sender, EventArgs e)
        {
            this.ExtractSelectedMessage(MessageContentExtractorAction.Default);
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ExtractSelectedMessage(MessageContentExtractorAction.Save);
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ExtractSelectedMessage(MessageContentExtractorAction.Copy);
        }

        private void openInDefaultApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ExtractSelectedMessage(MessageContentExtractorAction.Open);
        }

        private void ExtractSelectedMessage(MessageContentExtractorAction action)
        {
            LogListViewItem selectedItem = logListView.GetSelectedListItem();
            if (selectedItem == null)
                return;

            this.messageContentExtractor.ExtractMessage(selectedItem.LogItem.Message, action);
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ManageContentExtraction dlg = new ManageContentExtraction(this.messageContentExtractor.Config))
            {
                dlg.ShowDialog(this);
            }
        }

        private void showHideBottomPane_Click(object sender, EventArgs e)
        {
            if (logMessageEdit.Visible)
            {
                splitter1.Hide();
                logMessageEdit.Hide();
            }
            else
            {
                splitter1.Show();
                logMessageEdit.Show();
                RefreshMessageDetail(logListView.GetSelectedListItem(), true);
            }
        }

        private void applicationHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ApplicationHistoryDlg dlg = new ApplicationHistoryDlg(Path.Combine(Globals.AppDir, "History.xml"), null))
            {
                dlg.ShowDialog(this);
            }
        }

        private void setAsIncludeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetSelectedMessageAsFilter(false, false);
        }

        private void setAsExcludeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetSelectedMessageAsFilter(false, true);
        }

        private void addAsIncludeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetSelectedMessageAsFilter(true, false);
        }

        private void addAsExcludeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetSelectedMessageAsFilter(true, true);
        }

        private void SetSelectedMessageAsFilter(bool addToExisting, bool exclude)
        {
            if ((logMessageEdit.Text == string.Empty) || (this.logMessageEdit.SelectedText == string.Empty))
            {
                MessageBox.Show("Please select text which should be added to message filter.", "Select text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filterItem = this.logMessageEdit.SelectedText;


            List<string> list;
            if (addToExisting)
                list = this.FilterManager.CurrentFilter.Messages.TextLines.ToList();
            else
                list = new List<string>();

            if (exclude)
                list.Insert(0, '~' + filterItem);
            else
                list.Add(filterItem);

            this.FilterManager.CurrentFilter.Messages.Enabled = true;
            this.FilterManager.CurrentFilter.Messages.SaveTextLines(list);

            this.enableFiltersButton.Checked = true;
            this.settings.MainFormUI.EnableFilter = this.enableFiltersButton.Checked;

            this.FilterManager.Save();
            this.ShowLoadedLog(false, true);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((logMessageEdit.Text == string.Empty) || (this.logMessageEdit.SelectedText == string.Empty))
            {
                MessageBox.Show("Please select text which you want to copy into clipboard.", "Select text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Clipboard.SetText(logMessageEdit.SelectedText);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.logMessageEdit.SelectAll();
        }

        private void showLogBrowserButton_Click(object sender, EventArgs e)
        {
            this.LogBrowser.Show(this.fileName);
        }

        private void showListOfShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ListOfShortcutsDlg dlg = new ListOfShortcutsDlg(this.shortcutManager))
            {
                dlg.ShowDialog(this);
            }
        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FeedbackDlg dlg = new FeedbackDlg())
            {
                dlg.ShowDialog(this);
            }
        }

        private void editConfigFileDirectlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.activeLogAdjuster == null)
            {
                MessageBox.Show("No active Log Adjuster for currently opened log file. Please reconfigure Log Adjuster.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Diagnostics.Process.Start("notepad.exe", activeLogAdjuster.ConfigFileName);

        }


        private void configureLogAdjusterForThisLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LogAdjustersDlg dlg = new LogAdjustersDlg(this.customlogAdjusters, this.systemlogAdjusters, this.fileName))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.InitLogAdjuster();
                    this.LoadLogAdjuster();
                }
            }
        }

        private void logLevelAdjustmentSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LogAdjustersDlg dlg = new LogAdjustersDlg(this.customlogAdjusters, this.systemlogAdjusters, null))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.InitLogAdjuster();
                    this.LoadLogAdjuster();
                }
            }
        }

        private void openInTextEditorButton_Click(object sender, EventArgs e)
        {
            OpenLogFileInTextEditor(1);
        }

        private void OpenLogFileInTextEditor(int lineNumber)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = this.settings.TextEditor.TextEditorPath;
            proc.StartInfo.Arguments = this.settings.TextEditor.TextEditorParameteres.Replace("%FileName%", this.fileName).Replace("%LineNumber%", lineNumber.ToString());
            proc.Start();
        }

        private void openInExternalTextEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogListViewItem item = logListView.GetSelectedListItem();
            if (item == null)
                return;
            OpenLogFileInTextEditor(item.LogItem.LineInFile);
        }

        private void otherInstancesButton_DropDownOpening(object sender, EventArgs e)
        {
            log.Debug("otherInstancesButton_DropDownOpening");

            //Remove current items
            for (int i = this.otherInstancesButton.DropDownItems.Count - 1; i >= 0; i--)
            {
                this.otherInstancesButton.DropDownItems.RemoveAt(i);
            }

            List<LogViewerInstance> instances = this.CommManager.GetListOfOtherInstances().OrderByDescending(lvi => lvi.WhenWasActive).ToList();

            string noLogFileOpenedText = "No log file opened";
            instances.Insert(0, new LogViewerInstance(Guid.NewGuid(), "(This) - " + (String.IsNullOrEmpty(this.fileName) ? noLogFileOpenedText : this.fileName), DateTime.Now, IntPtr.Zero));
            instances.Add(new LogViewerInstance(Guid.Empty, "Open new instance of ALV ...", DateTime.Now, IntPtr.Zero));

            //Populate menu items
            foreach (var instance in instances)
            {
                LogViewerInstanceToolStripItem menuItem = new LogViewerInstanceToolStripItem(instance);
                if (String.IsNullOrEmpty(instance.LogFileName))
                    menuItem.Text = noLogFileOpenedText;
                menuItem.Click += new EventHandler(showAnotherInstanceMenuItem_Click);
                this.otherInstancesButton.DropDownItems.Add(menuItem);
            }

            this.otherInstancesButton.DropDownItems[0].Enabled = false;
            this.otherInstancesButton.DropDownItems[0].Font = new Font(this.otherInstancesButton.DropDownItems[0].Font, FontStyle.Bold);
        }

        void otherInstancesButtonDropDown_KeyUp(object sender, KeyEventArgs e)
        {
            log.DebugFormat("otherInstancesButtonDropDown_KeyUp, Tag {0}, Keys: {1} ", this.otherInstancesButton.DropDown.Tag, e.KeyData);

            if (this.otherInstancesButton.DropDown.Tag != null) //Need to ignore fist time in order to avoid double actio
            {
                this.otherInstancesButton.DropDown.Tag = null;
            }
            else
            {
                this.shortcutManager.ProcessKey(e.KeyData);

                if (e.KeyData == Keys.ControlKey || e.KeyData == Keys.Tab)
                {
                    int idx;
                    ToolStripItem selectedItem = GetSelectedToolStripItem(this.otherInstancesButton.DropDown.Items, out idx);
                    this.otherInstancesButton.HideDropDown();

                    if (selectedItem.Enabled)
                        showAnotherInstanceMenuItem_Click(selectedItem, new EventArgs());
                }
            }
        }

        /// <summary>Called when user press CTRL+TAB</summary>
        private void switchBetweenAlvInstancesCtrlTab()
        {
            log.Debug("switchBetweenAlvInstancesCtrlTab");
            if (!this.otherInstancesButton.DropDown.Visible)
            {
                this.otherInstancesButton.ShowDropDown();
                this.otherInstancesButton.DropDown.Tag = new object();
            }
            if (this.otherInstancesButton.DropDown.Items.Count == 0)
            {
                this.otherInstancesButton.HideDropDown();
                return;
            }

            int selectIDx = -1;
            if (GetSelectedToolStripItem(this.otherInstancesButton.DropDown.Items, out selectIDx) != null)
                selectIDx++;

            if (selectIDx == this.otherInstancesButton.DropDown.Items.Count)
                selectIDx = 0;

            if (selectIDx == -1)
                selectIDx = 1;

            this.otherInstancesButton.DropDown.Items[selectIDx].Select();
        }

        private ToolStripItem GetSelectedToolStripItem(ToolStripItemCollection items, out int index)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Selected)
                {
                    index = i;
                    return items[i];
                }
            }
            index = -1;
            return null;
        }

        void showAnotherInstanceMenuItem_Click(object sender, EventArgs e)
        {
            log.Info("showAnotherInstanceMenuItem_Click");

            LogViewerInstanceToolStripItem item = sender as LogViewerInstanceToolStripItem;
            if (item == null)
                return;

            if (item.LogInstance.ID == Guid.Empty)
            {
                log.Info("Run new instance.");
                ProcessStartInfo startInfo = new ProcessStartInfo(Application.ExecutablePath);
                Process.Start(startInfo);
            }
            else
            {
                log.Info("Switch to: " + item.LogInstance.LogFileName);
                Application.DoEvents();
                WinFormHelper.ForceForegroundWindow(item.LogInstance.MainWindowHandle);
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            this.CommManager.AppLastActivation = DateTime.Now;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.OverwritePrompt = true;
                dlg.Title = "Export currently shown items to a log file ...";
                dlg.Filter = "*.log|*.log|*.*|*.*";
                dlg.DefaultExt = ".log";
                dlg.InitialDirectory = Path.GetDirectoryName(this.fileName);
                dlg.FileName = Path.GetFileName(this.fileName);

                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        if (File.Exists(dlg.FileName))
                            File.Delete(dlg.FileName);

                        using (TextWriter tw = new StreamWriter(dlg.FileName))
                        {
                            foreach (LogEntry entry in this.logEntries)
                            {
                                tw.WriteLine(logParser.GetFormattedWholeEntry(entry));
                            }
                        }
                        string baseMessage = String.Format("Log has been successfully saved into file: '{0}'", dlg.FileName);
                        if (this.fileName.Equals(dlg.FileName, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show(baseMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (MessageBox.Show(baseMessage + Environment.NewLine + Environment.NewLine + "Do you want to open it now?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                this.OpenLog(dlg.FileName);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while saving data into new log file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void showCommandLineParamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = String.Format(@"ALV supports following command line parameters:

AdvancedLogViewer.exe [UseExistingInstance] LogFileNameToOpen [GotoLineNr/GotoDateTime] [ForceParser:MyParser]

UseExistingInstance {0}- When is specified, the LogFileNameToOpen will be opened in existing ALV instance if there is any. Otherwise opens new ALV instance.
LogFileNameToOpen {0}- Full log file name to open in ALV. (has to be in "" when is long name)
GotoLineNr {0}{0}- Line number to jump onto when the log file is opened
GotoDateTime {0}{0}- DateTime to jump onto when log file is opened. DateTime format: ""yyyy-MM-dd HH:mm:ss,fff""
ForceParser {0}{0}- Force the parser specified after the colon instead of using parser based on the file name.
", "\t");

            CustomMessageBox.Show(text, "ALV Command line parameters", MessageBoxIcon.Information, new Size(700, 270));
        }

        private void sqlFilterButton_Click(object sender, EventArgs e)
        {
            this.sqlFilterPanel.Visible = !this.sqlFilterPanel.Visible;
            this.splitter2.Visible = this.sqlFilterPanel.Visible;
            this.sqlFilterButton.Checked = this.sqlFilterPanel.Visible;
            if (sqlFilterPanel.Visible)
            {
                sqlFilterControl.Focus();
            }
            this.ShowLoadedLog(false, true);
        }
    }


    public enum GetLogListItemType
    {
        First,
        Last,
        Selected
    }
}