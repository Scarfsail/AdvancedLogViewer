using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Scarfsail.Common.Utils
{
    public class ExternalTextDiff
    {
        /// <summary>
        /// Create instance of ExternalTextDiff
        /// </summary>
        /// <param name="pathToExternalDiffTool">Path to external diff tool</param>
        /// <param name="externalDiffToolParameters">Parameters for external diff tool. There has to be: %File1% and %File2% variables which will be replaced by real filenames.</param>
        public ExternalTextDiff(string pathToExternalDiffTool, string externalDiffToolParameters)
        {
            this.pathToExternalDiffTool = pathToExternalDiffTool;
            this.externalDiffToolParameters = externalDiffToolParameters;
        }

        /// <summary>
        /// Diff the text in external diff tool
        /// </summary>
        /// <param name="textContent1">First Text to diff</param>
        /// <param name="textContent2">Second Text to diff</param>
        /// <param name="textTitle1">Title for first text (will be used as filename)</param>
        /// <param name="textTitle2">Title for second text (will be used as filename)</param>
        public void DiffText(string textContent1, string textContent2, string textTitle1, string textTitle2)
        {
            if (!File.Exists(this.pathToExternalDiffTool))
                throw new FileNotFoundException("External diff tool: " + this.pathToExternalDiffTool + " not found", this.pathToExternalDiffTool);

            //Create temp files with text content
            string tempFolder = Path.Combine(Path.GetTempPath(), "TextDiff-" + Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempFolder);
            
            string fileName1 = Path.Combine(tempFolder, textTitle1);
            string fileName2 = Path.Combine(tempFolder, textTitle2);

            File.WriteAllText(fileName1, textContent1);
            File.WriteAllText(fileName2, textContent2);

            
            //Start Diff
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = this.pathToExternalDiffTool;
            proc.StartInfo.Arguments = externalDiffToolParameters.Replace("%File1%", '"'+ fileName1+'"').Replace("%File2%", '"' + fileName2 + '"');
            proc.Start();
        }


        private string pathToExternalDiffTool;
        private string externalDiffToolParameters;

    }
}
