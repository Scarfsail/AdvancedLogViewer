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
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TheCodeKing.Net.Messaging;
using System.Threading;
using System.Diagnostics;

namespace TheCodeKing.Demo
{
    /// <summary>
    /// A demo messaging application which demostrates the cross AppDomain Messaging API.
    /// This independent instances of the application to receive and send messages between
    /// each other.
    /// </summary>
    public partial class Messenger : Form
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
        public Messenger()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The onload event which initializes the messaging API by registering
        /// for the Status and Message channels. This also assigns a delegate for
        /// processing messages received. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ToolTip tooltips = new ToolTip();
            tooltips.SetToolTip(sendBtn, "Broadcast message on Channel 1\r\nand Channel2");
            tooltips.SetToolTip(groupBox1, "Choose which channels\r\nthis instance will\r\nlisten on");
            tooltips.SetToolTip(Mode, "Choose which mode\r\nto use for sending\r\nand receiving");

            UpdateDisplayText("Launch multiple instances of this application to demo interprocess communication.\r\n", Color.Gray);

            // set the handle id in the form title
            this.Text += string.Format(" - Window {0}", this.Handle);

            InitializeMode(XDTransportMode.WindowsMessaging);

            // broadcast on the status channel that we have loaded
            broadcast.SendToChannel("Status", string.Format("{0} has joined", this.Handle));
       }

        /// <summary>
        /// The closing overrride used to broadcast on the status channel that the window is
        /// closing.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            broadcast.SendToChannel("Status", string.Format("{0} is shutting down", this.Handle));
        }
        /// <summary>
        /// The delegate which processes all cross AppDomain messages and writes them to screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMessageReceived(object sender, XDMessageEventArgs e)
        {
            // If called from a seperate thread, rejoin so that be can update form elements.
            if (InvokeRequired && !IsDisposed)
            {
                try
                {
                    // onClosing messages may fail if the form is being disposed.
                    Invoke((MethodInvoker)delegate() { UpdateDisplayText(e.DataGram); });
                }
                catch (ObjectDisposedException) { }
            }
            else
            {
                UpdateDisplayText(e.DataGram);
            }
        }

        /// <summary>
        /// A helper method used to update the Windows Form.
        /// </summary>
        /// <param name="dataGram">dataGram</param>
        private void UpdateDisplayText(DataGram dataGram)
        {
            Color textColor;
            switch (dataGram.Channel.ToLower())
            {
                case "status":
                    textColor = Color.Green;
                    break;
                default:
                    textColor = Color.Blue;
                    break;
            }
            string msg = string.Format("{0}: {1}\r\n", dataGram.Channel, dataGram.Message);
            UpdateDisplayText(msg, textColor);
        }

        /// <summary>
        /// A helper method used to update the Windows Form.
        /// </summary>
        /// <param name="message">The message to be displayed on the form.</param>
        /// <param name="textColor">The colour text to use for the message.</param>
        private void UpdateDisplayText(string message, Color textColor)
        {
            if (!IsDisposed)
            {
                this.displayTextBox.AppendText(message);
                this.displayTextBox.Select(this.displayTextBox.Text.Length - message.Length + 1, this.displayTextBox.Text.Length);
                this.displayTextBox.SelectionColor = textColor;
                this.displayTextBox.Select(this.displayTextBox.Text.Length, this.displayTextBox.Text.Length);
                this.displayTextBox.ScrollToCaret();
            }
        }

        /// <summary>
        /// Sends a user input string on the Message channel. A message is not sent if
        /// the string is empty.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        private void sendBtn_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        /// <summary>
        /// Wire up the enter key to submit a message.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message m, Keys k)
        {
            // allow enter to send message
            if (m.Msg == 256 && k == Keys.Enter)
            {
                SendMessage();
                return true;
            }
            return base.ProcessCmdKey(ref m, k);
        }

        /// <summary>
        /// Helper method for sending message.
        /// </summary>
        private void SendMessage()
        {
            if (this.inputTextBox.Text.Length > 0)
            {
               // send to all channels
               broadcast.SendToChannel("Channel1", string.Format("{0} says {1}", this.Handle, this.inputTextBox.Text));
               broadcast.SendToChannel("Channel2", string.Format("{0} says {1}", this.Handle, this.inputTextBox.Text));
               this.inputTextBox.Text = "";
            }
        }

        /// <summary>
        /// Adds or removes the Message channel from the messaging API. This effects whether messages 
        /// sent on this channel will be received by the application. Status messages are broadcast 
        /// on the Status channel whenever this setting is changed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void channel1_CheckedChanged(object sender, EventArgs e)
        {
            if (channel1Check.Checked)
            {
                listener.RegisterChannel("Channel1");
                broadcast.SendToChannel("Status", string.Format("{0} is registering Channel1.", this.Handle));
            }
            else
            {
                listener.UnRegisterChannel("Channel1");
                broadcast.SendToChannel("Status", string.Format("{0} is unregistering Channel1.", this.Handle));
            }
        }

        /// <summary>
        /// Adds or removes the Message channel from the messaging API. This effects whether messages 
        /// sent on this channel will be received by the application. Status messages are broadcast 
        /// on the Status channel whenever this setting is changed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void channel2_CheckedChanged(object sender, EventArgs e)
        {
            if (channel2Check.Checked)
            {
                listener.RegisterChannel("Channel2");
                broadcast.SendToChannel("Status", string.Format("{0} is registering Channel2.", this.Handle));
            }
            else
            {
                listener.UnRegisterChannel("Channel2");
                broadcast.SendToChannel("Status", string.Format("{0} is unregistering Channel2.", this.Handle));
            }
        }

        /// <summary>
        /// Adds or removes the Status channel from the messaging API. This effects whether messages 
        /// sent on this channel will be received by the application. Status messages are broadcast 
        /// on the Status channel whenever this setting is changed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusChannel_CheckedChanged(object sender, EventArgs e)
        {
            if (statusCheckBox.Checked)
            {
                listener.RegisterChannel("Status");
                broadcast.SendToChannel("Status", string.Format("{0} is registering Status.", this.Handle));
            }
            else
            {
                listener.UnRegisterChannel("Status");
                broadcast.SendToChannel("Status", string.Format("{0} is unregistering Status.", this.Handle));
            }
        }

        /// <summary>
        /// Initialize the broadcast and listener mode.
        /// </summary>
        /// <param name="mode">The new mode.</param>
        private void InitializeMode(XDTransportMode mode)
        {
            if (listener != null)
            {
                // ensure we dispose any previous listeners, dispose should aways be
                // called on IDisposable objects when we are done with it to avoid leaks
                listener.Dispose();
            }

            // creates an instance of the IXDListener object using the given implementation  
            listener = XDListener.CreateListener(mode);

            // attach the message handler
            listener.MessageReceived += new XDListener.XDMessageHandler(OnMessageReceived);

            // register the channels we want to listen on
            if (statusCheckBox.Checked)
            {
                listener.RegisterChannel("Status");
            }

            // register if checkbox is checked
            if (channel1Check.Checked)
            {
                listener.RegisterChannel("Channel1");
            }

            // register if checkbox is checked
            if (channel2Check.Checked)
            {
                listener.RegisterChannel("Channel2");
            }

            // if we already have a broadcast instance
            if (broadcast != null)
            {
                broadcast.SendToChannel("Status", string.Format("{0} is changing mode to {1}", this.Handle, mode));
            }

            // create an instance of IXDBroadcast using the given mode, 
            // note IXDBroadcast does not implement IDisposable
            broadcast = XDBroadcast.CreateBroadcast(mode, propagateCheck.Checked);
        }

        /// <summary>
        /// On form changed mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mode_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                SetMode();
            }
        }

        private void SetMode()
        {
            if (wmRadio.Checked)
            {
                InitializeMode(XDTransportMode.WindowsMessaging);
            }
            else if (ioStreamRadio.Checked)
            {
                InitializeMode(XDTransportMode.IOStream);
            }
            else
            {
                InitializeMode(XDTransportMode.MailSlot);
            }
        }

        /// <summary>
        /// If the MailSlot checkbox is checked, display info about single-instance limitation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mailRadio_MouseClick(object sender, MouseEventArgs e)
        {
            if (mailRadio.Checked)
            {
                UpdateDisplayText("MailSlot mode only allows one listener on a single channel at any one time.\r\n", Color.Red);
            }
        }

        private void propagateCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (propagateCheck.Checked)
            {
                UpdateDisplayText("Messages will be propagated to all machines on the same domain or workgroup.\r\n", Color.Red);
            }
            else
            {
                UpdateDisplayText("Message are restricted to the current machine.\r\n", Color.Red);
            }
            SetMode();
        }
    }
}