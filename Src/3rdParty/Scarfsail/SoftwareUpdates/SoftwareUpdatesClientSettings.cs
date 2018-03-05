using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scarfsail.SoftwareUpdates
{
    public struct SoftwareUpdatesClientSettings
    {
        public Version ProductVersion;
        public string RemoteDefinitionXmlUrl;
        public string ProductPathToStoreHistoryInfo;
        public TimeSpan UpdateCheckPeriod;
    }
}
