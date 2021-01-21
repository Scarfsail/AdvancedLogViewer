using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UpdateAppFromZip.Properties;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace UpdateAppFromZip
{
    public partial class MainForm : Form
    {

        private string updatedAppName;
        private string updatedAppProcessName;
        private string updatedAppLocation;
        private string updatedAppExeName;

        public MainForm(string[] args)
        {
            InitializeComponent();
            this.GetInfoFromUpdatedAppXml();
            if (args.Length != 1)
            {
                MessageBox.Show("Application has to be run with destination path parameter!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            this.updatedAppLocation = args[0];
            this.Text = "Updating application: " + updatedAppName + " ...";
        }

        private void GetInfoFromUpdatedAppXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Resources.UpdatedAppDescription);
            XmlNode node = doc.SelectSingleNode("UpdateAppFromZip/AppDescription");
            this.updatedAppName = node.Attributes["AppName"].Value;
            this.updatedAppProcessName = node.Attributes["ProcessName"].Value;
            this.updatedAppExeName = node.Attributes["AppToLaunch"].Value;
        }


        private void MainForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            string basePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TmpUpdate");
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);
            string archiveFileName = Path.Combine(basePath, "UpdatedApp.exe");
            string whereToExtract = Path.Combine(basePath, "Extracted");
            if (!Directory.Exists(whereToExtract))
                Directory.CreateDirectory(whereToExtract);

            using (FileStream fs = new FileStream(archiveFileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(Resources.UpdatedAppContent, 0, Resources.UpdatedAppContent.Length);
            }

            this.UncompressExeToLocation(archiveFileName, whereToExtract);

            if (this.WaitUntilProcessIsDown(updatedAppProcessName, this.updatedAppLocation))
            {
                string pathOfAppToLaunchAfterUpdate = Path.Combine(updatedAppLocation, updatedAppExeName);
                if (this.CopyFilesToDestination(whereToExtract, updatedAppLocation))
                {
                    this.statusLabel.Text = "Update complete.";
                    if (MessageBox.Show("Application has been succesfully updated." + Environment.NewLine + "Do you want to run the application: " + pathOfAppToLaunchAfterUpdate,
                        "Update succeed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Process lExe = new Process();
                        lExe.StartInfo.FileName = pathOfAppToLaunchAfterUpdate;
                        lExe.Start();
                    }
                }
                else
                {
                    this.statusLabel.Text = "Update failed.";
                    MessageBox.Show("Application can't be updated because some files can't be replaced. Try again later, please.", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                this.statusLabel.Text = "Update failed.";
                MessageBox.Show("Application can't be updated because is running. Try again later, please.", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private bool WaitUntilProcessIsDown(string updatedAppProcessName, string appLocation)
        {
            Process[] processes;
            while ((processes = Process.GetProcessesByName(updatedAppProcessName)).Length > 0)
            {
                bool exists = false;
                foreach (Process process in processes)
                {
                    string path;
                    try
                    {
                        path = Path.GetDirectoryName(process.MainModule.FileName);
                    }
                    catch
                    {
                        path = null;
                    }



                    if (string.IsNullOrEmpty(path) || appLocation.Equals(path, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        if (MessageBox.Show(String.Format("Please close all running instances of:{0}{1} {0}in:{0}{2}", Environment.NewLine, updatedAppName, appLocation),
                            "Updated application is running", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Cancel)
                            return false;
                    }
                }
                if (!exists)
                    return true;
            }
            return true;
        }

        private void UncompressExeToLocation(string exeArchive, string whereToExtract)
        {
            // Create a new process object
            Process process = new Process();

            process.StartInfo.FileName = exeArchive;
            process.StartInfo.Arguments = String.Format("x -o\"{0}\" -y", whereToExtract);

            // These two optional flags ensure that no DOS window appears
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // This ensures that you get the output from the DOS application
            process.StartInfo.RedirectStandardOutput = true;

            // Start the process
            process.Start();

            // Wait that the process exits
            process.WaitForExit();
        }

        private bool CopyFilesToDestination(string sourceDir, string destDir)
        {
            string[] files = (Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories));

            int i = 0;
            while (i < files.Length)
            {
                string srcFileName = files[i];
                string dstFileName = Path.Combine(destDir, srcFileName.Replace(sourceDir + "\\", ""));
                try
                {
                    Application.DoEvents();
                    File.Copy(srcFileName, dstFileName, true);
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show(String.Format("Can't update file: '{0}' because of following error: {1}", dstFileName, ex.Message), "Can't update file", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Cancel)
                        return false;
                    else
                        i--; //Try the same file again
                }
                i++;
            }
            return true;
        }
    }
}
