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

        public static string UserDataDir
        {
            get
            {
                if (userDataDir == null)
                {
                    if (IsPortable)
                    {
                        userDataDir = Path.Combine(AppDir, "UserData");
                    }
                    else
                    {
                        userDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "AdvancedLogViewer\\");
                        if (!Directory.Exists(userDataDir))
                            Directory.CreateDirectory(userDataDir);
                    }
                }
                return userDataDir;
            }
        }

        public static bool IsPortable
        {
            get
            {
                if (isPortable == null)
                {
                    isPortable = Directory.Exists(Path.Combine(AppDir, "UserData"));
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
                    appDataDir = Path.Combine(AppDir, "Data\\");
                    if (!Directory.Exists(appDataDir))
                        Directory.CreateDirectory(appDataDir);
                }
                return appDataDir;
            }
        }

        public static string AppDir
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

    }
}
