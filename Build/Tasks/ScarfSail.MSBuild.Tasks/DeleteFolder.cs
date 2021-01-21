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
    /// Delete whole directory including all files in the directory
    /// </summary>
    public class DeleteDirectory : Task
    {
        [Required]
        public string DirectoryToDelete { get; set; }

        public override bool Execute()
        {
            try
            {
                if (Directory.Exists(DirectoryToDelete))
                {
                    Directory.Delete(DirectoryToDelete, true);
                    base.Log.LogMessage("Folder: '{0}' deleted.", DirectoryToDelete);
                }
                else
                    base.Log.LogWarning("Folder: '{0}' not found.", DirectoryToDelete);

                return true;
            }
            catch (Exception ex)
            {
                string message = string.Format("Error while deleting directory: '{0}'. Message: {1}", this.DirectoryToDelete, ex.Message);
                base.Log.LogError(message, null);
                return false;
            }
        }
    }
}
