using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using AdvancedLogViewer.Common;
using System.Text.RegularExpressions;
using Scarfsail.Common.BL;

namespace AdvancedLogViewer.BL.MessageContentExtraction
{
    public class MessageContentExtractor
    {
        public MessageContentExtractor(string configFileName)
        {
            this.configFileName = configFileName;
        }

        public void ExtractMessage(string message, MessageContentExtractorAction action)
        {
            string content = message;
            string ext = Config.FileExtension;
            MessageContentExtractorAction act = action == MessageContentExtractorAction.Default ? Config.DefaultAction : action;

            foreach (CustomMessageExtractor extractor in Config.CustomExtractors)
            {
                Regex regex = new Regex(extractor.RegexToExtract, RegexOptions.Singleline);
                Match match = regex.Match(message);
                if (match.Success)
                {
                    ext = extractor.FileExtension;
                    act = action == MessageContentExtractorAction.Default ? (extractor.DefaultAction == MessageContentExtractorAction.Default ? act : extractor.DefaultAction) : action;

                    if (match.Groups.Count > 0)
                        content = match.Groups["GroupToCapture"].Value;
                    else
                        content = match.Value;
                    break;
                }
            }

            this.DoAction(content, act, ext);
        }

        public MessageContentExtractorConfig Config
        {
            get
            {
                if (this.config == null)
                {
                    config = MessageContentExtractorConfig.LoadFromFile(configFileName, XmlSerializableFileCorruptedAction.ShowDialogAndLoadDefaults);
                }
                return this.config;
            }
        }

        private void DoAction(string content, MessageContentExtractorAction action, string extension)
        {
            switch (action)
            {
                case MessageContentExtractorAction.Default:
                    throw new InvalidOperationException("The action has to be specified, default action isn't allowed here.");

                case MessageContentExtractorAction.Open:
                    string fileName = Path.GetTempFileName() + "." + extension;
                    File.WriteAllText(fileName, content);

                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.FileName = fileName;
                    proc.Start();

                    break;

                case MessageContentExtractorAction.Copy:
                    Clipboard.SetText(content);
                    break;

                case MessageContentExtractorAction.Save:
                    using (SaveFileDialog dlg = new SaveFileDialog())
                    {
                        dlg.Title = "Save message content ...";
                        dlg.OverwritePrompt = true;
                        dlg.DefaultExt = extension;
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            if (File.Exists(dlg.FileName))
                                File.Delete(dlg.FileName);

                            File.WriteAllText(dlg.FileName, content);
                        }
                    }
                    break;

                default:
                    throw new InvalidOperationException(String.Format("Action: '{0}' is not supported.", action));
            }
        }

        private MessageContentExtractorConfig config;
        private string configFileName;
    }
}
