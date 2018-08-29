using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Utilities;
using System.Reflection;
using Microsoft.Build.Framework;
using System.IO;

namespace ScarfSail.MSBuild.Tasks
{
    /// <summary>
    /// Get latest file name with specified mask
    /// </summary>
    public class GetLatestFile : Task
    {
        [Required]
        public string DirectoryPath { get; set; }

        [Required]
        public string FileMask { get; set; }

        [Output]
        public string FoundFileName { get; private set; }

        public override bool Execute()
        {
            try
            {
                base.Log.LogMessage("Getting files ({0}) in: {1}", FileMask, DirectoryPath);
                string[] files = Directory.GetFiles(DirectoryPath, FileMask);
                if (files.Length > 0)
                {
                    this.FoundFileName = files.OrderBy(f => new FileInfo(f).CreationTime).First();
                    this.FoundFileName = Path.GetFullPath(FoundFileName);
                    Log.LogMessage("Found following file: " + FoundFileName);
                    return true;
                }
                else
                {
                    this.FoundFileName = "";
                    this.Log.LogError("File {0} not found in: {1}", FileMask, DirectoryPath);
                    return false;
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Error while searching for file in: '{0}'. Message: {1}", this.DirectoryPath, ex.Message);
                base.Log.LogError(message, null);
                return false;
            }
        }
    }
}
