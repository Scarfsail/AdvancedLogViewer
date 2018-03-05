/*=============================================================================
*
*	(C) Copyright 2007, Michael Carlisle (mike.carlisle@thecodeking.co.uk)
*
*   http://www.TheCodeKing.co.uk
*  
*	All rights reserved.
*	The code and information is provided "as-is" without waranty of any kind,
*	either expressed or implied.
*
*=============================================================================
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using TheCodeKing.Net.Messaging;
using System.Windows.Forms;
using System.Threading;

namespace Test_Service
{
    /// <summary>
    /// A sample Windows Service that demonstrates interprocess communication from a Windows Service. Run an
    /// instance of Messager to view the broadcast messages.
    /// </summary>
    public partial class TestService : ServiceBase
    {
        /// <summary>
        /// The instance used to listen to broadcast messages.
        /// </summary>
        private IXDListener listener;

        /// <summary>
        /// The instance used to broadcast messages on a particular channel.
        /// </summary>
        private IXDBroadcast broadcast;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TestService()
        {
            InitializeComponent();
            this.ServiceName = "Test Service";

            //only the following mode is supported in windows services
            broadcast = XDBroadcast.CreateBroadcast(XDTransportMode.IOStream);
            listener = XDListener.CreateListener(XDTransportMode.IOStream);
            listener.MessageReceived += new XDListener.XDMessageHandler(OnMessageReceived);
            listener.RegisterChannel("Status");
            listener.RegisterChannel("Channel1");
            listener.RegisterChannel("Channel2");
        }

        /// <summary>
        /// Broadcast a message that the service has started.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            // broadcast to all processes listening on the status channel that the service has started
            broadcast.SendToChannel("status", "Test Service has started");
        }

        /// <summary>
        /// Broadcast a message that the service has stopped.
        /// </summary>
        protected override void OnStop()
        {
            // broadcast to all processes listening on the status channel that the service has stoped
            broadcast.SendToChannel("status", "Test Service has stopped");
        }

        /// <summary>
        /// Handle the MessageReceived event and trace the message to standard debug.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMessageReceived(object sender, XDMessageEventArgs e)
        {
            // view these debug messages using SysInternals Dbgview.
            Debug.WriteLine("Test Service: "+e.DataGram.Channel+" "+e.DataGram.Message);
        }
    }
}
