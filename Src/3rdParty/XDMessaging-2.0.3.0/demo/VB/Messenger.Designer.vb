Namespace TheCodeKing.Demo
    Partial Class Messenger
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.panel1 = New System.Windows.Forms.Panel()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.statusCheckBox = New System.Windows.Forms.CheckBox()
            Me.channel1Check = New System.Windows.Forms.CheckBox()
            Me.channel2Check = New System.Windows.Forms.CheckBox()
            Me.Mode = New System.Windows.Forms.GroupBox()
            Me.mailRadio = New System.Windows.Forms.RadioButton()
            Me.ioStreamRadio = New System.Windows.Forms.RadioButton()
            Me.wmRadio = New System.Windows.Forms.RadioButton()
            Me.inputTextBox = New System.Windows.Forms.TextBox()
            Me.sendBtn = New System.Windows.Forms.Button()
            Me.displayTextBox = New System.Windows.Forms.RichTextBox()
            Me.propagateCheck = New System.Windows.Forms.CheckBox()
            Me.panel1.SuspendLayout()
            Me.groupBox1.SuspendLayout()
            Me.Mode.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' panel1
            ' 
            Me.panel1.Controls.Add(Me.propagateCheck)
            Me.panel1.Controls.Add(Me.groupBox1)
            Me.panel1.Controls.Add(Me.Mode)
            Me.panel1.Controls.Add(Me.inputTextBox)
            Me.panel1.Controls.Add(Me.sendBtn)
            Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.panel1.Location = New System.Drawing.Point(0, 247)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(289, 157)
            Me.panel1.TabIndex = 2
            ' 
            ' groupBox1
            ' 
            Me.groupBox1.Controls.Add(Me.statusCheckBox)
            Me.groupBox1.Controls.Add(Me.channel1Check)
            Me.groupBox1.Controls.Add(Me.channel2Check)
            Me.groupBox1.Location = New System.Drawing.Point(12, 35)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(130, 90)
            Me.groupBox1.TabIndex = 0
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Channels"
            ' 
            ' statusCheckBox
            ' 
            Me.statusCheckBox.Checked = True
            Me.statusCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
            Me.statusCheckBox.Location = New System.Drawing.Point(15, 63)
            Me.statusCheckBox.Name = "statusCheckBox"
            Me.statusCheckBox.Size = New System.Drawing.Size(61, 18)
            Me.statusCheckBox.TabIndex = 5
            Me.statusCheckBox.Text = "Status"
            Me.statusCheckBox.UseVisualStyleBackColor = True
            AddHandler Me.statusCheckBox.Click, AddressOf Me.statusChannel_CheckedChanged
            ' 
            ' channel1Check
            ' 
            Me.channel1Check.Checked = True
            Me.channel1Check.CheckState = System.Windows.Forms.CheckState.Checked
            Me.channel1Check.Location = New System.Drawing.Point(15, 18)
            Me.channel1Check.Name = "channel1Check"
            Me.channel1Check.Size = New System.Drawing.Size(94, 17)
            Me.channel1Check.TabIndex = 3
            Me.channel1Check.Text = "Channel 1"
            Me.channel1Check.UseVisualStyleBackColor = True
            AddHandler Me.channel1Check.Click, AddressOf Me.channel1_CheckedChanged
            ' 
            ' channel2Check
            ' 
            Me.channel2Check.Location = New System.Drawing.Point(15, 41)
            Me.channel2Check.Name = "channel2Check"
            Me.channel2Check.Size = New System.Drawing.Size(94, 17)
            Me.channel2Check.TabIndex = 4
            Me.channel2Check.Text = "Channel 2"
            Me.channel2Check.UseVisualStyleBackColor = True
            AddHandler Me.channel2Check.Click, AddressOf Me.channel2_CheckedChanged
            ' 
            ' Mode
            ' 
            Me.Mode.Controls.Add(Me.mailRadio)
            Me.Mode.Controls.Add(Me.ioStreamRadio)
            Me.Mode.Controls.Add(Me.wmRadio)
            Me.Mode.Location = New System.Drawing.Point(148, 35)
            Me.Mode.Name = "Mode"
            Me.Mode.Size = New System.Drawing.Size(130, 90)
            Me.Mode.TabIndex = 0
            Me.Mode.TabStop = False
            Me.Mode.Text = "Mode"
            ' 
            ' mailRadio
            ' 
            Me.mailRadio.AutoSize = True
            Me.mailRadio.Location = New System.Drawing.Point(15, 64)
            Me.mailRadio.Name = "mailRadio"
            Me.mailRadio.Size = New System.Drawing.Size(65, 17)
            Me.mailRadio.TabIndex = 8
            Me.mailRadio.TabStop = True
            Me.mailRadio.Text = "Mail Slot"
            Me.mailRadio.UseVisualStyleBackColor = True
            AddHandler Me.mailRadio.MouseClick, AddressOf Me.mailRadio_MouseClick
            AddHandler Me.mailRadio.CheckedChanged, AddressOf Me.mode_CheckedChanged
            ' 
            ' ioStreamRadio
            ' 
            Me.ioStreamRadio.AutoSize = True
            Me.ioStreamRadio.Location = New System.Drawing.Point(15, 41)
            Me.ioStreamRadio.Name = "ioStreamRadio"
            Me.ioStreamRadio.Size = New System.Drawing.Size(72, 17)
            Me.ioStreamRadio.TabIndex = 7
            Me.ioStreamRadio.TabStop = True
            Me.ioStreamRadio.Text = "IO Stream"
            Me.ioStreamRadio.UseVisualStyleBackColor = True
            AddHandler Me.ioStreamRadio.CheckedChanged, AddressOf Me.mode_CheckedChanged
            ' 
            ' wmRadio
            ' 
            Me.wmRadio.AutoSize = True
            Me.wmRadio.Checked = True
            Me.wmRadio.Location = New System.Drawing.Point(15, 18)
            Me.wmRadio.Name = "wmRadio"
            Me.wmRadio.Size = New System.Drawing.Size(67, 17)
            Me.wmRadio.TabIndex = 6
            Me.wmRadio.TabStop = True
            Me.wmRadio.Text = "Win Msg"
            Me.wmRadio.UseVisualStyleBackColor = True
            AddHandler Me.wmRadio.CheckedChanged, AddressOf Me.mode_CheckedChanged
            ' 
            ' inputTextBox
            ' 
            Me.inputTextBox.Location = New System.Drawing.Point(13, 6)
            Me.inputTextBox.Name = "inputTextBox"
            Me.inputTextBox.Size = New System.Drawing.Size(178, 20)
            Me.inputTextBox.TabIndex = 1
            ' 
            ' sendBtn
            ' 
            Me.sendBtn.Location = New System.Drawing.Point(197, 6)
            Me.sendBtn.Name = "sendBtn"
            Me.sendBtn.Size = New System.Drawing.Size(80, 23)
            Me.sendBtn.TabIndex = 2
            Me.sendBtn.Text = "Send"
            Me.sendBtn.UseVisualStyleBackColor = True
            AddHandler Me.sendBtn.Click, AddressOf Me.sendBtn_Click
            ' 
            ' displayTextBox
            ' 
            Me.displayTextBox.BackColor = System.Drawing.Color.White
            Me.displayTextBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.displayTextBox.Location = New System.Drawing.Point(0, 0)
            Me.displayTextBox.Name = "displayTextBox"
            Me.displayTextBox.[ReadOnly] = True
            Me.displayTextBox.Size = New System.Drawing.Size(289, 247)
            Me.displayTextBox.TabIndex = 4
            Me.displayTextBox.TabStop = False
            Me.displayTextBox.Text = ""
            ' 
            ' propagateCheck
            ' 
            Me.propagateCheck.AutoSize = True
            Me.propagateCheck.Checked = True
            Me.propagateCheck.CheckState = System.Windows.Forms.CheckState.Checked
            Me.propagateCheck.Location = New System.Drawing.Point(13, 128)
            Me.propagateCheck.Name = "propagateCheck"
            Me.propagateCheck.Size = New System.Drawing.Size(269, 17)
            Me.propagateCheck.TabIndex = 3
            Me.propagateCheck.Text = "Propagate messages to local Workgroup or Domain"
            Me.propagateCheck.UseVisualStyleBackColor = True
            AddHandler Me.propagateCheck.CheckedChanged, AddressOf Me.propagateCheck_CheckedChanged
            ' 
            ' Messenger
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(289, 404)
            Me.Controls.Add(Me.displayTextBox)
            Me.Controls.Add(Me.panel1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "Messenger"
            Me.Text = "XDMessaging Demo"
            Me.TopMost = True
            Me.panel1.ResumeLayout(False)
            Me.panel1.PerformLayout()
            Me.groupBox1.ResumeLayout(False)
            Me.Mode.ResumeLayout(False)
            Me.Mode.PerformLayout()

            Me.ResumeLayout(False)
        End Sub

#End Region

        Private panel1 As System.Windows.Forms.Panel
        Private inputTextBox As System.Windows.Forms.TextBox
        Private sendBtn As System.Windows.Forms.Button
        Private displayTextBox As System.Windows.Forms.RichTextBox
        Private Mode As System.Windows.Forms.GroupBox
        Private ioStreamRadio As System.Windows.Forms.RadioButton
        Private wmRadio As System.Windows.Forms.RadioButton
        Private groupBox1 As System.Windows.Forms.GroupBox
        Private statusCheckBox As System.Windows.Forms.CheckBox
        Private channel2Check As System.Windows.Forms.CheckBox
        Private mailRadio As System.Windows.Forms.RadioButton
        Private channel1Check As System.Windows.Forms.CheckBox
        Private propagateCheck As System.Windows.Forms.CheckBox

    End Class
End Namespace
