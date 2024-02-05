<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnOutputs = New System.Windows.Forms.Button()
        Me.gbMenu = New System.Windows.Forms.GroupBox()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnChannelLength = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbBrightness = New System.Windows.Forms.ComboBox()
        Me.cbColor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbChannel = New System.Windows.Forms.ComboBox()
        Me.cbSimulation = New System.Windows.Forms.CheckBox()
        Me.btnUpdateFirmware = New System.Windows.Forms.Button()
        Me.cbComPort = New System.Windows.Forms.ComboBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.cmbVersion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmrComPort = New System.Windows.Forms.Timer(Me.components)
        Me.gbMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Enabled = False
        Me.btnConnect.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConnect.Location = New System.Drawing.Point(186, 466)
        Me.btnConnect.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(224, 85)
        Me.btnConnect.TabIndex = 3
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'btnOutputs
        '
        Me.btnOutputs.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOutputs.Location = New System.Drawing.Point(14, 327)
        Me.btnOutputs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnOutputs.Name = "btnOutputs"
        Me.btnOutputs.Size = New System.Drawing.Size(188, 76)
        Me.btnOutputs.TabIndex = 4
        Me.btnOutputs.Text = "Send Output Data"
        Me.btnOutputs.UseVisualStyleBackColor = True
        '
        'gbMenu
        '
        Me.gbMenu.Controls.Add(Me.btnTest)
        Me.gbMenu.Controls.Add(Me.Label13)
        Me.gbMenu.Controls.Add(Me.Label12)
        Me.gbMenu.Controls.Add(Me.Label11)
        Me.gbMenu.Controls.Add(Me.Label10)
        Me.gbMenu.Controls.Add(Me.Label9)
        Me.gbMenu.Controls.Add(Me.Label8)
        Me.gbMenu.Controls.Add(Me.Label7)
        Me.gbMenu.Controls.Add(Me.Label6)
        Me.gbMenu.Controls.Add(Me.Label5)
        Me.gbMenu.Controls.Add(Me.TextBox8)
        Me.gbMenu.Controls.Add(Me.TextBox7)
        Me.gbMenu.Controls.Add(Me.TextBox6)
        Me.gbMenu.Controls.Add(Me.TextBox5)
        Me.gbMenu.Controls.Add(Me.TextBox4)
        Me.gbMenu.Controls.Add(Me.TextBox3)
        Me.gbMenu.Controls.Add(Me.TextBox2)
        Me.gbMenu.Controls.Add(Me.TextBox1)
        Me.gbMenu.Controls.Add(Me.btnChannelLength)
        Me.gbMenu.Controls.Add(Me.Label4)
        Me.gbMenu.Controls.Add(Me.cbBrightness)
        Me.gbMenu.Controls.Add(Me.cbColor)
        Me.gbMenu.Controls.Add(Me.Label3)
        Me.gbMenu.Controls.Add(Me.Label2)
        Me.gbMenu.Controls.Add(Me.cbChannel)
        Me.gbMenu.Controls.Add(Me.btnOutputs)
        Me.gbMenu.Enabled = False
        Me.gbMenu.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMenu.Location = New System.Drawing.Point(12, 12)
        Me.gbMenu.Name = "gbMenu"
        Me.gbMenu.Size = New System.Drawing.Size(734, 408)
        Me.gbMenu.TabIndex = 8
        Me.gbMenu.TabStop = False
        Me.gbMenu.Text = "Menu"
        '
        'btnTest
        '
        Me.btnTest.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTest.Location = New System.Drawing.Point(539, 27)
        Me.btnTest.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(188, 76)
        Me.btnTest.TabIndex = 51
        Me.btnTest.Text = "Do Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(384, 246)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 29)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "8"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(384, 203)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 29)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "7"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(384, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 29)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "6"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(384, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 29)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "5"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(225, 246)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 29)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "4"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(225, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 29)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "3"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(225, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 29)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(225, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 29)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(312, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 29)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Strip Length"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(412, 238)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(100, 37)
        Me.TextBox8.TabIndex = 41
        Me.TextBox8.Text = "0"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(412, 195)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(100, 37)
        Me.TextBox7.TabIndex = 40
        Me.TextBox7.Text = "0"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(412, 152)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(100, 37)
        Me.TextBox6.TabIndex = 39
        Me.TextBox6.Text = "10"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(412, 109)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 37)
        Me.TextBox5.TabIndex = 38
        Me.TextBox5.Text = "10"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(253, 238)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 37)
        Me.TextBox4.TabIndex = 37
        Me.TextBox4.Text = "10"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(253, 195)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 37)
        Me.TextBox3.TabIndex = 36
        Me.TextBox3.Text = "10"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(253, 152)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 37)
        Me.TextBox2.TabIndex = 35
        Me.TextBox2.Text = "10"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(253, 109)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 37)
        Me.TextBox1.TabIndex = 34
        Me.TextBox1.Text = "10"
        '
        'btnChannelLength
        '
        Me.btnChannelLength.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChannelLength.Location = New System.Drawing.Point(13, 109)
        Me.btnChannelLength.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnChannelLength.Name = "btnChannelLength"
        Me.btnChannelLength.Size = New System.Drawing.Size(188, 76)
        Me.btnChannelLength.TabIndex = 33
        Me.btnChannelLength.Text = "Send Strip Lengths"
        Me.btnChannelLength.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(491, 327)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 29)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Brightness"
        '
        'cbBrightness
        '
        Me.cbBrightness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBrightness.Font = New System.Drawing.Font("Impact", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBrightness.FormattingEnabled = True
        Me.cbBrightness.Items.AddRange(New Object() {"10", "20", "30", "40", "50", "60", "70", "80", "90", "100"})
        Me.cbBrightness.Location = New System.Drawing.Point(496, 370)
        Me.cbBrightness.Name = "cbBrightness"
        Me.cbBrightness.Size = New System.Drawing.Size(103, 33)
        Me.cbBrightness.TabIndex = 31
        '
        'cbColor
        '
        Me.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbColor.Font = New System.Drawing.Font("Impact", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbColor.FormattingEnabled = True
        Me.cbColor.Items.AddRange(New Object() {"Red", "Blue", "Green", "White", "Off"})
        Me.cbColor.Location = New System.Drawing.Point(359, 370)
        Me.cbColor.Name = "cbColor"
        Me.cbColor.Size = New System.Drawing.Size(103, 33)
        Me.cbColor.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(354, 327)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 29)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Color"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(215, 327)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 29)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Channel"
        '
        'cbChannel
        '
        Me.cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbChannel.Font = New System.Drawing.Font("Impact", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbChannel.FormattingEnabled = True
        Me.cbChannel.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cbChannel.Location = New System.Drawing.Point(220, 370)
        Me.cbChannel.Name = "cbChannel"
        Me.cbChannel.Size = New System.Drawing.Size(103, 33)
        Me.cbChannel.TabIndex = 27
        '
        'cbSimulation
        '
        Me.cbSimulation.AutoSize = True
        Me.cbSimulation.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSimulation.Location = New System.Drawing.Point(20, 425)
        Me.cbSimulation.Name = "cbSimulation"
        Me.cbSimulation.Size = New System.Drawing.Size(145, 33)
        Me.cbSimulation.TabIndex = 9
        Me.cbSimulation.Text = "Simulation"
        Me.cbSimulation.UseVisualStyleBackColor = True
        Me.cbSimulation.Visible = False
        '
        'btnUpdateFirmware
        '
        Me.btnUpdateFirmware.Enabled = False
        Me.btnUpdateFirmware.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateFirmware.Location = New System.Drawing.Point(551, 466)
        Me.btnUpdateFirmware.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUpdateFirmware.Name = "btnUpdateFirmware"
        Me.btnUpdateFirmware.Size = New System.Drawing.Size(224, 85)
        Me.btnUpdateFirmware.TabIndex = 10
        Me.btnUpdateFirmware.Text = "Update Firmware"
        Me.btnUpdateFirmware.UseVisualStyleBackColor = True
        '
        'cbComPort
        '
        Me.cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbComPort.Font = New System.Drawing.Font("Impact", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbComPort.FormattingEnabled = True
        Me.cbComPort.Location = New System.Drawing.Point(781, 512)
        Me.cbComPort.Name = "cbComPort"
        Me.cbComPort.Size = New System.Drawing.Size(102, 33)
        Me.cbComPort.TabIndex = 24
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.Location = New System.Drawing.Point(781, 482)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(100, 29)
        Me.lblValue.TabIndex = 25
        Me.lblValue.Text = "COM Port"
        '
        'btnAbout
        '
        Me.btnAbout.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbout.Location = New System.Drawing.Point(418, 468)
        Me.btnAbout.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(104, 83)
        Me.btnAbout.TabIndex = 11
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'cmbVersion
        '
        Me.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersion.Font = New System.Drawing.Font("Impact", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVersion.FormattingEnabled = True
        Me.cmbVersion.Items.AddRange(New Object() {"Wemos D1 Mini", "Wemos S2 Mini"})
        Me.cmbVersion.Location = New System.Drawing.Point(20, 512)
        Me.cmbVersion.Name = "cmbVersion"
        Me.cmbVersion.Size = New System.Drawing.Size(153, 33)
        Me.cmbVersion.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 476)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 29)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Version"
        '
        'tmrComPort
        '
        Me.tmrComPort.Interval = 5000
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 565)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.cmbVersion)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.cbComPort)
        Me.Controls.Add(Me.btnUpdateFirmware)
        Me.Controls.Add(Me.cbSimulation)
        Me.Controls.Add(Me.gbMenu)
        Me.Controls.Add(Me.btnConnect)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "MainWindow"
        Me.Text = "CSD Configuration Tool"
        Me.gbMenu.ResumeLayout(False)
        Me.gbMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConnect As Button
    Friend WithEvents btnOutputs As Button
    Friend WithEvents gbMenu As GroupBox
    Friend WithEvents cbSimulation As CheckBox
    Friend WithEvents btnUpdateFirmware As Button
    Friend WithEvents cbComPort As ComboBox
    Friend WithEvents lblValue As Label
    Friend WithEvents btnAbout As Button
    Friend WithEvents cmbVersion As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbColor As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbChannel As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbBrightness As ComboBox
    Friend WithEvents tmrComPort As Timer
    Friend WithEvents btnChannelLength As Button
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnTest As Button
End Class
