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
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO

Namespace TheCodeKing.Demo
    Module Program
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()> _
        Public Sub Main()
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
            AddHandler Application.ThreadException, AddressOf Application_ThreadException

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New Messenger())
        End Sub

        ''' <summary>
        ''' Exception handler.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
            LogException(DirectCast(e.ExceptionObject, Exception))
        End Sub

        ''' <summary>
        ''' Exception handler.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub Application_ThreadException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
            LogException(e.Exception)
        End Sub

        ''' <summary>
        ''' Log exceptions to error log.
        ''' </summary>
        ''' <param name="e"></param>
        Private Sub LogException(ByVal e As Exception)
            Using log As StreamWriter = File.CreateText(Path.Combine(Environment.CurrentDirectory, "XDMessaging.log"))
                log.WriteLine(e)
            End Using
            MessageBox.Show("Something when wrong." & vbCr & vbLf & "See XDMessaging.log for details." & vbCr & vbLf, "Oops", MessageBoxButtons.OK, MessageBoxIcon.[Error])

            Application.[Exit]()
        End Sub
    End Module
End Namespace
