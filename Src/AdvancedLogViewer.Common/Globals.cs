using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AdvancedLogViewer.Common
{
    public static class Globals
    {
        private static string userDataDir = null;
        private static string appDataDir = null;
        private static bool? isPortable;

        public static string UserDataDataForPre9Version =>
            GetUserDataDir(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

        public static string UserDataDir
        {
            get
            {
                if (userDataDir == null)
                {
                    userDataDir = GetUserDataDir(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                    if (!Directory.Exists(userDataDir))
                        Directory.CreateDirectory(userDataDir);
                }
                return userDataDir;
            }
        }

        private static string GetUserDataDir(string applicationDataPath)
            => IsPortable ? Path.Combine(AppExeDir, "UserData") : Path.Combine(applicationDataPath, "AdvancedLogViewer\\");

        public static bool IsPortable
        {
            get
            {
                if (isPortable == null)
                {
                    isPortable = Directory.Exists(Path.Combine(AppExeDir, "UserData"));
                }
                return isPortable.Value;
            }
        }

        public static string AppDataDir
        {
            get
            {
                if (appDataDir == null)
                {
                    appDataDir = Path.Combine(AppEmbeddedDir, "Data\\");
                    if (!Directory.Exists(appDataDir))
                        Directory.CreateDirectory(appDataDir);
                }
                return appDataDir;
            }
        }
        public static string AppEmbeddedDir => AppDomain.CurrentDomain.BaseDirectory;
        private static string AppExeDir => Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

    }
}
