'=============================================================================
'*
'*	(C) Copyright 2007, Michael Carlisle (mike.carlisle@thecodeking.co.uk)
'*
'*   http://www.TheCodeKing.co.uk
'*  
'*	All rights reserved.
'*	The code and information is provided "as-is" without waranty of any kind,
'*	either expressed or implied.
'*
'*=============================================================================
'

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports TheCodeKing.Net.Messaging
Imports System.Threading
Imports System.Diagnostics

Namespace TheCodeKing.Demo
    ''' <summary>
    ''' A demo messaging application which demostrates the cross AppDomain Messaging API.
    ''' This independent instances of the application to receive and send messages between
    ''' each other.
    ''' </summary>
    Partial Public Class Messenger
        Inherits Form
        ''' <summary>
        ''' The instance used to listen to broadcast messages.
        ''' </summary>
        Private listener As IXDListener

        ''' <summary>
        ''' The instance used to broadcast messages on a particular channel.
        ''' </summary>
        Private broadcast As IXDBroadcast

        ''' <summary>
        ''' Delegate used for invoke callback.
        ''' </summary>
        ''' <param name="dataGram"></param>
        ''' <remarks></remarks>
        Private Delegate Sub UpdateDisplay(ByVal dataGram As DataGram)

        ''' <summary>
        ''' Default constructor.
        ''' </summary>
        Public Sub New()
            InitializeComponent()
        End Sub
        ''' <summary>
        ''' The onload event which initializes the messaging API by registering
        ''' for the Status and Message channels. This also assigns a delegate for
        ''' processing messages received. 
        ''' </summary>
        ''' <param name="e"></param>
        Protected Overloads Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)

            Dim tooltips As New ToolTip()
            tooltips.SetToolTip(sendBtn, "Broadcast message on Channel 1" & vbCr & vbLf & "and Channel2")
            tooltips.SetToolTip(groupBox1, "Choose which channels" & vbCr & vbLf & "this instance will" & vbCr & vbLf & "listen on")
            tooltips.SetToolTip(Mode, "Choose which mode" & vbCr & vbLf & "to use for sending" & vbCr & vbLf & "and receiving")

            UpdateDisplayText("Launch multiple instances of this application to demo interprocess communication." & vbCr & vbLf, Color.Gray)

            ' set the handle id in the form title
            Me.Text += String.Format(" - Window {0}", Me.Handle)

            InitializeMode(XDTransportMode.WindowsMessaging)

            ' broadcast on the status channel that we have loaded
            broadcast.SendToChannel("Status", String.Format("{0} has joined", Me.Handle))
        End Sub

        ''' <summary>
        ''' The closing overrride used to broadcast on the status channel that the window is
        ''' closing.
        ''' </summary>
        ''' <param name="e"></param>
        Protected Overloads Overrides Sub OnClosing(ByVal e As CancelEventArgs)
            MyBase.OnClosing(e)
            broadcast.SendToChannel("Status", String.Format("{0} is shutting down", Me.Handle))
        End Sub
        ''' <summary>
        ''' The delegate which processes all cross AppDomain messages and writes them to screen.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub OnMessageReceived(ByVal sender As Object, ByVal e As XDMessageEventArgs)
            If MyBase.InvokeRequired Then
                Try
                    Dim callback As New UpdateDisplay(AddressOf UpdateDisplayText)
                    MyBase.Invoke(callback, e.DataGram)
                Catch
                End Try
            Else
                Me.UpdateDisplayText(e.DataGram)
            End If
        End Sub

        ''' <summary>
        ''' A helper method used to update the Windows Form.
        ''' </summary>
        ''' <param name="dataGram">dataGram</param>
        Private Sub UpdateDisplayText(ByVal dataGram As DataGram)
            Dim textColor As Color
            Select Case dataGram.Channel.ToLower()
                Case "status"
                    textColor = Color.Green
                    Exit Select
                Case Else
                    textColor = Color.Blue
                    Exit Select
            End Select
            Dim msg As String = String.Format("{0}: {1}" & vbCr & vbLf, dataGram.Channel, dataGram.Message)
            UpdateDisplayText(msg, textColor)
        End Sub

        ''' <summary>
        ''' A helper method used to update the Windows Form.
        ''' </summary>
        ''' <param name="message">The message to be displayed on the form.</param>
        ''' <param name="textColor">The colour text to use for the message.</param>
        Private Sub UpdateDisplayText(ByVal message As String, ByVal textColor As Color)
            If Not IsDisposed Then
                Me.displayTextBox.AppendText(message)
                Me.displayTextBox.[Select](Me.displayTextBox.Text.Length - message.Length + 1, Me.displayTextBox.Text.Length)
                Me.displayTextBox.SelectionColor = textColor
                Me.displayTextBox.[Select](Me.displayTextBox.Text.Length, Me.displayTextBox.Text.Length)
                Me.displayTextBox.ScrollToCaret()
            End If
        End Sub

        ''' <summary>
        ''' Sends a user input string on the Message channel. A message is not sent if
        ''' the string is empty.
        ''' </summary>
        ''' <param name="sender">The event sender.</param>
        ''' <param name="e">The event args.</param>
        Private Sub sendBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
            SendMessage()
        End Sub

        ''' <summary>
        ''' Wire up the enter key to submit a message.
        ''' </summary>
        ''' <param name="m"></param>
        ''' <param name="k"></param>
        ''' <returns></returns>
        Protected Overloads Overrides Function ProcessCmdKey(ByRef m As Message, ByVal k As Keys) As Boolean
            ' allow enter to send message
            If m.Msg = 256 AndAlso k = Keys.Enter Then
                SendMessage()
                Return True
            End If
            Return MyBase.ProcessCmdKey(m, k)
        End Function

        ''' <summary>
        ''' Helper method for sending message.
        ''' </summary>
        Private Sub SendMessage()
            If Me.inputTextBox.Text.Length > 0 Then
                ' send to all channels
                broadcast.SendToChannel("Channel1", String.Format("{0} says {1}", Me.Handle, Me.inputTextBox.Text))
                broadcast.SendToChannel("Channel2", String.Format("{0} says {1}", Me.Handle, Me.inputTextBox.Text))
                Me.inputTextBox.Text = ""
            End If
        End Sub

        ''' <summary>
        ''' Adds or removes the Message channel from the messaging API. This effects whether messages 
        ''' sent on this channel will be received by the application. Status messages are broadcast 
        ''' on the Status channel whenever this setting is changed. 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub channel1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If channel1Check.Checked Then
                listener.RegisterChannel("Channel1")
                broadcast.SendToChannel("Status", String.Format("{0} is registering Channel1.", Me.Handle))
            Else
                listener.UnRegisterChannel("Channel1")
                broadcast.SendToChannel("Status", String.Format("{0} is unregistering Channel1.", Me.Handle))
            End If
        End Sub

        ''' <summary>
        ''' Adds or removes the Message channel from the messaging API. This effects whether messages 
        ''' sent on this channel will be received by the application. Status messages are broadcast 
        ''' on the Status channel whenever this setting is changed. 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub channel2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If channel2Check.Checked Then
                listener.RegisterChannel("Channel2")
                broadcast.SendToChannel("Status", String.Format("{0} is registering Channel2.", Me.Handle))
            Else
                listener.UnRegisterChannel("Channel2")
                broadcast.SendToChannel("Status", String.Format("{0} is unregistering Channel2.", Me.Handle))
            End If
        End Sub

        ''' <summary>
        ''' Adds or removes the Status channel from the messaging API. This effects whether messages 
        ''' sent on this channel will be received by the application. Status messages are broadcast 
        ''' on the Status channel whenever this setting is changed. 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub statusChannel_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If statusCheckBox.Checked Then
                listener.RegisterChannel("Status")
                broadcast.SendToChannel("Status", String.Format("{0} is registering Status.", Me.Handle))
            Else
                listener.UnRegisterChannel("Status")
                broadcast.SendToChannel("Status", String.Format("{0} is unregistering Status.", Me.Handle))
            End If
        End Sub

        ''' <summary>
        ''' Initialize the broadcast and listener mode.
        ''' </summary>
        ''' <param name="mode">The new mode.</param>
        Private Sub InitializeMode(ByVal mode As XDTransportMode)
            If listener IsNot Nothing Then
                ' ensure we dispose any previous listeners, dispose should aways be
                ' called on IDisposable objects when we are done with it to avoid leaks
                listener.Dispose()
            End If

            ' creates an instance of the IXDListener object using the given implementation  
            listener = XDListener.CreateListener(mode)

            ' attach the message handler
            AddHandler listener.MessageReceived, AddressOf OnMessageReceived

            ' register the channels we want to listen on
            If statusCheckBox.Checked Then
                listener.RegisterChannel("Status")
            End If

            ' register if checkbox is checked
            If channel1Check.Checked Then
                listener.RegisterChannel("Channel1")
            End If

            ' register if checkbox is checked
            If channel2Check.Checked Then
                listener.RegisterChannel("Channel2")
            End If

            ' if we already have a broadcast instance
            If broadcast IsNot Nothing Then
                broadcast.SendToChannel("Status", String.Format("{0} is changing mode to {1}", Me.Handle, mode))
            End If

            ' create an instance of IXDBroadcast using the given mode, 
            ' note IXDBroadcast does not implement IDisposable
            broadcast = XDBroadcast.CreateBroadcast(mode, propagateCheck.Checked)
        End Sub

        ''' <summary>
        ''' On form changed mode.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub mode_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If DirectCast(sender, RadioButton).Checked Then
                SetMode()
            End If
        End Sub

        Private Sub SetMode()
            If wmRadio.Checked Then
                InitializeMode(XDTransportMode.WindowsMessaging)
            ElseIf ioStreamRadio.Checked Then
                InitializeMode(XDTransportMode.IOStream)
            Else
                InitializeMode(XDTransportMode.MailSlot)
            End If
        End Sub

        ''' <summary>
        ''' If the MailSlot checkbox is checked, display info about single-instance limitation.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub mailRadio_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
            If mailRadio.Checked Then
                UpdateDisplayText("MailSlot mode only allows one listener on a single channel at any one time." & vbCr & vbLf, Color.Red)
            End If
        End Sub

        Private Sub propagateCheck_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            If propagateCheck.Checked Then
                UpdateDisplayText("Messages will be propagated to all machines on the same domain or workgroup." & vbCr & vbLf, Color.Red)
            Else
                UpdateDisplayText("Message are restricted to the current machine." & vbCr & vbLf, Color.Red)
            End If
            SetMode()
        End Sub
    End Class
End Namespace




