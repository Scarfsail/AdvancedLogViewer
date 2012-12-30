using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.Common.Parser;
using QueryAnything;
using Sarfsail.Common.UI.SyntaxHighlighter;

namespace AdvancedLogViewer.UI.Controls
{
    public partial class SqlFilterControl : UserControl
    {
        private string executedWhereClause = String.Empty;
        private static Scarfsail.Logging.Log log = new Scarfsail.Logging.Log();
        private string lastExecutionStatus = "Log isn't filtered";
        private EnumerableQuery<LogEntry, LogEntry> compiledQuery = null;

        public SqlFilterControl()
        {
            InitializeComponent();
            SetHighlighting();
        }

        public IEnumerable<LogEntry> FilterLogEntries(IEnumerable<LogEntry> logEntries, out bool itemsFiltered)
        {
            IEnumerable<LogEntry> entries = logEntries;
            itemsFiltered = false;
            if (this.executedWhereClause == string.Empty)
            {
                log.Debug("No query specified, returning original list.");
                this.lastExecutionStatus = "Log isn't filtered because the where condition is empty";
            }
            else
            {
                log.Debug("Query specified, executing query.");
                try
                {
                    string sqlQuery = "SELECT * FROM THIS WHERE " + executedWhereClause;

                    if (compiledQuery == null)
                    {
                        log.Debug("Compiling new query");
                        compiledQuery = new EnumerableQuery<LogEntry, LogEntry>(sqlQuery);
                        compiledQuery.Compile();
                    }
                    else
                    {
                        log.Debug("Query is already compiled");
                    }

                    entries = entries.Query(compiledQuery);

                    this.lastExecutionStatus = "Log is filtered";
                    itemsFiltered = true;
                    log.Debug("Query executed.");
                }
                catch (Exception ex)
                {
                    this.lastExecutionStatus = "Log isn't filtered, because of execution error";
                    this.Invoke(new MethodInvoker(() =>
                        MessageBox.Show(ex.Message, "Error while executing query", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                }
            }
            this.lastExecutionStatus += ". Last query execution: " + DateTime.Now.ToLongTimeString();
            UpdateStatusText();
            return entries;
        }

        private bool IsQueryChangeSinceLastExecution
        {
            get
            {
                return !this.queryEditor.Text.Equals(this.executedWhereClause);
            }
        }

        private void UpdateStatusText()
        {

            this.statusLabel.Text = lastExecutionStatus + ". " + (IsQueryChangeSinceLastExecution ?
                 "Query has been modified since last execution." :
                 "Query isn't modified since last execution.");
        }

        public string WhereClause
        {
            get
            {
                return this.queryEditor.Text;
            }
            set
            {
                this.queryEditor.Text = value;
                this.queryEditor.Highlight();
            }
        }

        public void SetAvailableColumns(List<ColumnDescription> columns)
        {
            this.availableColumnsListBox.BeginUpdate();

            for (int i = colorHighlighterColumnIndexes.Count - 1; i >= 0; i--)
            {
                this.queryEditor.RemoveHighlightDescriptiorById(colorHighlighterColumnIndexes[i]);
            }
            colorHighlighterColumnIndexes.Clear();

            this.availableColumnsListBox.Items.Clear();
            foreach (ColumnDescription column in columns)
            {
                this.availableColumnsListBox.Items.Add(column);
                this.colorHighlighterColumnIndexes.Add(this.queryEditor.AddHighlightDescriptor(DescriptorRecognition.WholeWord, column.ColumnName, DescriptorType.Word, Color.FromArgb(255, 43, 145, 175), queryEditor.Font, true));
            }
            this.availableColumnsListBox.EndUpdate();
            this.queryEditor.Text = this.queryEditor.Text;
        }

        private List<int> colorHighlighterColumnIndexes = new List<int>();

        public event EventHandler Execute;

        public bool EditBoxHasFocus
        {
            get
            {
                return this.queryEditor.Focused;
            }
        }

        protected virtual void OnExecute()
        {
            if (Execute != null)
                Execute(this, new EventArgs());
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            if (IsQueryChangeSinceLastExecution)
                compiledQuery = null;

            if (this.queryEditor.Text.Trim() == String.Empty)
                this.queryEditor.Text = String.Empty;
            
            executedWhereClause = this.queryEditor.Text;
            log.Info("New query executed: " + executedWhereClause);

            OnExecute();
        }

        private void SetHighlighting()
        {

            queryEditor.Seperators.Add(' ');
            queryEditor.Seperators.Add('\r');
            queryEditor.Seperators.Add('\n');
            queryEditor.Seperators.Add(',');
            queryEditor.Seperators.Add('.');
            queryEditor.Seperators.Add(')');
            queryEditor.Seperators.Add('(');
            queryEditor.Seperators.Add(']');
            queryEditor.Seperators.Add('[');
            queryEditor.Seperators.Add('}');
            queryEditor.Seperators.Add('{');
            queryEditor.Seperators.Add('+');
            queryEditor.Seperators.Add('=');
            queryEditor.Seperators.Add('\t');

            queryEditor.WordWrap = false;
            queryEditor.ScrollBars = RichTextBoxScrollBars.Both;

            //highlight keywords
            List<string> keywords = new List<string>(){"AND", "BETWEEN", "EXISTS", "FALSE", 
                "IN", "IS", "NOT", "OR", "TRUE", "LIKE", "ORDER", "BY"};

            foreach (string keyword in keywords)
                queryEditor.AddHighlightDescriptor(DescriptorRecognition.WholeWord, keyword, DescriptorType.Word, Color.Blue, queryEditor.Font, true);

            /*
            List<string> macros = new List<string>() { "#RETURNAS", "#TOTIMESTAMP" };

            foreach (string macro in macros)
                queryEditor.AddHighlightDescriptor(DescriptorRecognition.WholeWord, macro, DescriptorType.Word, Color.Red, queryEditor.Font, true);
            */

            //highlight numbers
            queryEditor.AddHighlightDescriptor(DescriptorRecognition.RegEx, "\\b(?:[0-9]*\\.)?[0-9]+\\b", DescriptorType.Word, Color.Magenta, queryEditor.Font, false);
            queryEditor.AddHighlightDescriptor(DescriptorRecognition.StartsWith, "--", DescriptorType.ToEOL, Color.Green, queryEditor.Font, false);
            queryEditor.AddHighlightDescriptor(DescriptorRecognition.StartsWith, "'", DescriptorType.ToCloseToken, "'", Color.Red, queryEditor.Font, false);

            queryEditor.Text = queryEditor.Text;
        }

        private void queryEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
                executeButton.PerformClick();
        }

        private void availableColumnsListBox_DoubleClick(object sender, EventArgs e)
        {
            ColumnDescription column = this.availableColumnsListBox.SelectedItem as ColumnDescription;
            if (column != null)
                this.queryEditor.SelectedText = column.ColumnName;
        }

        private void queryEditor_TextChanged(object sender, EventArgs e)
        {
            UpdateStatusText();
        }
    }
}
