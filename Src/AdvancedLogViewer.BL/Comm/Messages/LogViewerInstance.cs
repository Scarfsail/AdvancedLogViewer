using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedLogViewer.BL.Comm.Messages
{
    public class LogViewerInstance : BaseMessage
    {
        public LogViewerInstance(string data)
        {
            int idx = -1;
            this.ID = new Guid(GetMessagePart(data, ref idx));
            this.LogFileName = GetMessagePart(data, ref idx);
            this.WhenWasActive = DateTime.Parse(GetMessagePart(data, ref idx));
            this.MainWindowHandle = new IntPtr(Int64.Parse(GetRestOfMessage(data, idx)));
        }

        public LogViewerInstance(Guid id, string logFileName, DateTime whenWasActive, IntPtr mainWindowHandle)
        {
            this.ID = id;
            this.LogFileName = logFileName;
            this.WhenWasActive = whenWasActive;
            this.MainWindowHandle = mainWindowHandle;
        }

        public override string GetTextMessage()
        {
            return ID.ToString() + msgDelimiter + (LogFileName ?? String.Empty) + msgDelimiter + WhenWasActive.ToString("s") + msgDelimiter + MainWindowHandle.ToString();
        }


        public Guid ID { get; private set; }
        public string LogFileName { get; private set; }
        public DateTime WhenWasActive { get; private set; }
        public IntPtr MainWindowHandle { get; private set; }
    }
}
