using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Utilities;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Build.Framework;
using System.IO;

namespace ScarfSail.MSBuild.Tasks
{
    /// <summary>
    /// Given the path to an assembly this will return
    /// its version information.
    /// 
    /// <example>
    /// <code source="Sedodream.MSBuild.Tasks\SampleTargets\SampleFindUnder.targets" 
    ///                 title="Sample" lang="XML" tabSize="4" />
    /// </example>
    /// </summary>
    public class GetAssemblyVersion : Task
    {
        #region Fields
        private string assemblyPath;
        private Version version;
        #endregion

        #region Properties
        /// <summary>
        /// Required MSBuild input property that contains the path of the 
        /// Assembly that is to be loaded.
        /// </summary>
        [Required]
        public string AssemblyPath
        {
            get { return this.assemblyPath; }
            set { this.assemblyPath = value; }
        }
        /// <summary>
        /// Gets the version field
        /// </summary>
        public Version Version
        {
            get { return this.version; }
        }
        /// <summary>
        /// MSBuild output property that can be used to get the entire version string.
        /// If there is no version information then <c>string.Empty</c> will be returned.
        /// </summary>
        [Output]
        public string VersionString
        {
            get
            {
                if (this.Version == null)
                    return string.Empty;
                return Version.ToString(4);
            }
        }
        /// <summary>
        /// MSBuild output property that will return the <c>Version.Major</c> value.
        /// If no version info available the <c>int.MinValue</c> will be returned
        /// </summary>
        [Output]
        public int Major
        {
            get
            {
                if (this.Version == null)
                    return int.MinValue;
                return Version.Major;
            }
        }
        /// <summary>
        /// MSBuild output property that will return the <c>Version.MajorRevision</c> value.
        /// If no version info available the <c>int.MinValue</c> will be returned
        /// </summary>
        [Output]
        public int MajorRevision
        {
            get
            {
                if (this.Version == null)
                    return int.MinValue;
                return Version.MajorRevision;
            }
        }
        /// <summary>
        /// MSBuild output property that will return the <c>Version.Minor</c> value.
        /// If no version info available the <c>int.MinValue</c> will be returned
        /// </summary>
        [Output]
        public int Minor
        {
            get
            {
                if (this.Version == null)
                    return int.MinValue;
                return Version.Minor;
            }
        }
        /// <summary>
        /// MSBuild output property that will return the <c>Version.MinorRevision</c> value.
        /// If no version info available the <c>int.MinValue</c> will be returned
        /// </summary>
        [Output]
        public int MinorRevision
        {
            get
            {
                if (this.Version == null)
                    return int.MinValue;
                return Version.MinorRevision;
            }
        }
        /// <summary>
        /// MSBuild output property that will return the <c>Version.Revision</c> value.
        /// If no version info available the <c>int.MinValue</c> will be returned
        /// </summary>
        [Output]
        public int Revision
        {
            get
            {
                if (this.Version == null)
                    return int.MinValue;
                return Version.Revision;
            }
        }
        /// <summary>
        /// MSBuild output property that will return the <c>Version.Build</c> value.
        /// If no version info available the <c>int.MinValue</c> will be returned
        /// </summary>
        [Output]
        public int Build
        {
            get
            {
                if (this.Version == null)
                    return int.MinValue;
                return Version.Build;
            }
        }
        #endregion

        /// <summary>
        /// When overridden in a derived class, executes the task.
        /// </summary>
        /// <returns>
        /// true if the task successfully executed; otherwise, false.
        /// </returns>
        public override bool Execute()
        {
            try
            {
                if (AssemblyPath == null || AssemblyPath.Trim().Equals(string.Empty))
                {
                    string message = string.Format("Unable to determine the assembly version because AssemblyPath provided is empty");
                    base.Log.LogError(message);
                    return false;
                }
                FileInfo assemblyFi = new FileInfo(AssemblyPath);
                if (!assemblyFi.Exists)
                {
                    string message = string.Format("Unable to determine the assembly version because AssemblyPath provided [{0}] doesn't exist.", assemblyFi.FullName);
                    base.Log.LogError(message);
                    return false;
                }
                var fileVersion = FileVersionInfo.GetVersionInfo(assemblyFi.FullName).FileVersion+".0";
                this.version = new Version(fileVersion);
                return true;
            }
            catch (Exception ex)
            {
                string message = string.Format("Unable to determine the assembly version information for assembly at [{0}]. Message: {1}", AssemblyPath, ex.Message);
                base.Log.LogError(message, null);
                return false;
            }
        }
    }
}
