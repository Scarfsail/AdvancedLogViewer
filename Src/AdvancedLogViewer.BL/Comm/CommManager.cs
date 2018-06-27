using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheCodeKing.Net.Messaging;
using AdvancedLogViewer.BL.Comm.Messages;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace AdvancedLogViewer.BL.Comm
{
    public class GoToItemRequestEventArgs : EventArgs
    {
        public GoToItemRequestEventArgs(DateTime goTo)
        {
            this.GoTo = goTo;
        }

        public DateTime GoTo { get; private set; }
    }

    public class ProcessAppArgsEventArgs : EventArgs
    {
        public ProcessAppArgsEventArgs(string[] args)
        {
            this.Args = args;
        }

        public string[] Args { get; private set; }
    }

    public class AnotherInstanceOpenedLogFileEventArgs : EventArgs
    {
        public AnotherInstanceOpenedLogFileEventArgs(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName { get; private set; }
    }

    public class CommManager
    {
        private const string ChannelBroadcast = "Broadcast";

        private IXDListener listener;
        private IXDBroadcast broadcast;

        private static Guid myID = Guid.NewGuid();
        private List<LogViewerInstance> otherInstances;
        private string currentLogFileName = null;


        public CommManager()
        {
            this.otherInstances = new List<LogViewerInstance>();

            this.listener = XDListener.CreateListener(XDTransportMode.WindowsMessaging);
            this.broadcast = XDBroadcast.CreateBroadcast(XDTransportMode.WindowsMessaging, false);

            this.listener.RegisterChannel(myID.ToString()); //Channel only for me
            this.listener.RegisterChannel(ChannelBroadcast); //Channel for everyone

            listener.MessageReceived += new XDListener.XDMessageHandler(listener_MessageReceived);
            this.MainWindowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
        }

        public const string CommDateFormat = "yyyy-MM-dd HH:mm:ss,fff";

        public delegate void GoToItemRequestEventHandler(object sender, GoToItemRequestEventArgs e);
        public delegate void ProcessAppArgsEventHandler(object sender, ProcessAppArgsEventArgs e);
        public delegate void AnotherInstanceOpenedLogFileEventHandler(object sender, AnotherInstanceOpenedLogFileEventArgs e);

        public List<LogViewerInstance> GetListOfOtherInstances()
        {
            this.otherInstances.Clear();
            SendMessage(null, MessageType.GetInstance);
            return otherInstances;
        }

        public void GoToTimeInAnotherLog(Guid logViewerInstanceId, DateTime goTo)
        {
            SendMessage(logViewerInstanceId, MessageType.GoToDateTime, goTo.ToString(CommDateFormat));
        }

        public void ProcessAppArgsInAnotherInstance(Guid logViewerInstanceId, string[] args)
        {
            string argsTxt = String.Empty;
            foreach (string arg in args)
            {
                argsTxt += (argsTxt == String.Empty ? "" : "|") + arg;
            }
            SendMessage(logViewerInstanceId, MessageType.ProcessAppArgs, argsTxt);
        }

        public string CurrentLogFileName
        {
            get
            {
                return this.currentLogFileName;
            }
            set
            {
                if (this.currentLogFileName != value)
                {
                    this.currentLogFileName = value;

                    //Send my log file name to other instances
                    SendMessage(null, MessageType.ReturnCurrentLogFileName, value);
                }
            }
        }

        public DateTime AppLastActivation { get; set; }

        public IntPtr MainWindowHandle  {get;private set;}

        public event GoToItemRequestEventHandler GoToItemRequest;        
        public event AnotherInstanceOpenedLogFileEventHandler AnotherInstanceOpenedLogFile;
        public event ProcessAppArgsEventHandler ProcessAppArgs;

        protected void OnGoToItemRequest(DateTime goTo)
        {
            if (this.GoToItemRequest != null)
                this.GoToItemRequest(this, new GoToItemRequestEventArgs(goTo));
        }

        protected void OnAnotherInstanceOpenedLogFile(string fileName)
        {
            if (this.AnotherInstanceOpenedLogFile != null)
                this.AnotherInstanceOpenedLogFile(this, new AnotherInstanceOpenedLogFileEventArgs(fileName));
        }

        private void OnProcessAppArgs(string[] args)
        {
            if (this.ProcessAppArgs != null)
                this.ProcessAppArgs(this, new ProcessAppArgsEventArgs(args));
        }
        

        private void listener_MessageReceived(object sender, XDMessageEventArgs e)
        {
            CommDatagram dtg = CommDatagram.ParseDatagram(e.DataGram);
            if (dtg.SenderId == myID)
                return;

            switch (dtg.MessageType)
            {
                case MessageType.GetInstance:
                    //if (!String.IsNullOrEmpty(this.CurrentLogFileName))
                    SendMessage(dtg.SenderId, MessageType.ReturnInstance, new LogViewerInstance(myID, this.CurrentLogFileName, this.AppLastActivation, this.MainWindowHandle).GetTextMessage());
                    break;
                case MessageType.ReturnInstance:
                    this.otherInstances.Add(new LogViewerInstance(dtg.Data));
                    break;
                case MessageType.GoToDateTime:
                    OnGoToItemRequest(DateTime.ParseExact(dtg.Data, CommDateFormat, CultureInfo.InvariantCulture));
                    break;
                case MessageType.ReturnCurrentLogFileName:
                    OnAnotherInstanceOpenedLogFile(dtg.Data);
                    break;
                case MessageType.ProcessAppArgs:
                    OnProcessAppArgs(dtg.Data.Split('|'));
                    break;
                default:
                    throw new NotImplementedException(String.Format("Message type: '{0}' is not supported.", dtg.MessageType));
            }
        }


        private void SendMessage(Guid? toID, MessageType messageType)
        {
            this.SendMessage(toID, messageType, String.Empty);
        }

        private void SendMessage(Guid? toID, MessageType messageType, string data)
        {
            string message = CommDatagram.GetMessage(myID, messageType, data);
            if (toID == null)
                broadcast.SendToChannel(ChannelBroadcast, message);
            else
                broadcast.SendToChannel(toID.ToString(), message);
        }

    }
}
