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
        Me.cbSimulation = New System.Windows.Forms.CheckBox()
        Me.btnUpdateFirmware = New System.Windows.Forms.Button()
        Me.cbComPort = New System.Windows.Forms.ComboBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.cmbVersion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbChannel = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbColor = New System.Windows.Forms.ComboBox()
        Me.cbBrightness = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.btnOutputs.Location = New System.Drawing.Point(8, 54)
        Me.btnOutputs.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnOutputs.Name = "btnOutputs"
        Me.btnOutputs.Size = New System.Drawing.Size(188, 76)
        Me.btnOutputs.TabIndex = 4
        Me.btnOutputs.Text = "Send Output Data"
        Me.btnOutputs.UseVisualStyleBackColor = True
        '
        'gbMenu
        '
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
        'cbChannel
        '
        Me.cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbChannel.Font = New System.Drawing.Font("Impact", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbChannel.FormattingEnabled = True
        Me.cbChannel.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8"})
        Me.cbChannel.Location = New System.Drawing.Point(214, 97)
        Me.cbChannel.Name = "cbChannel"
        Me.cbChannel.Size = New System.Drawing.Size(103, 33)
        Me.cbChannel.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(209, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 29)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Channel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(348, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 29)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Color"
        '
        'cbColor
        '
        Me.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbColor.Font = New System.Drawing.Font("Impact", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbColor.FormattingEnabled = True
        Me.cbColor.Items.AddRange(New Object() {"Red", "Blue", "Green", "White", "Off"})
        Me.cbColor.Location = New System.Drawing.Point(353, 97)
        Me.cbColor.Name = "cbColor"
        Me.cbColor.Size = New System.Drawing.Size(103, 33)
        Me.cbColor.TabIndex = 30
        '
        'cbBrightness
        '
        Me.cbBrightness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBrightness.Font = New System.Drawing.Font("Impact", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBrightness.FormattingEnabled = True
        Me.cbBrightness.Items.AddRange(New Object() {"10", "20", "30", "40", "50", "60", "70", "80", "90", "100"})
        Me.cbBrightness.Location = New System.Drawing.Point(490, 97)
        Me.cbBrightness.Name = "cbBrightness"
        Me.cbBrightness.Size = New System.Drawing.Size(103, 33)
        Me.cbBrightness.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(485, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 29)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Brightness"
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
End Class
