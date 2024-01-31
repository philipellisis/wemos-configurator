Imports System.IO
Imports CSDAddressableControllerTool.My
Imports CSDAddressableControllerTool.My.Resources
Imports System.Windows.Forms
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.IO.Compression

Public Class MainWindow

    Private currentComPorts = My.Computer.Ports.SerialPortNames
    Private OutputsWindow As Outputs

    Private version As Integer() = {1, 13, 0}
    'Private WithEvents arduino As RS232
    Private Board As BoardInterface
    Private connected As Boolean
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each sp As String In currentComPorts
            cbComPort.Items.Add(sp)
            cbComPort.SelectedIndex = 0
        Next
        cbBrightness.SelectedIndex = 0
        cbChannel.SelectedIndex = 0
        cbColor.SelectedIndex = 0
        tmrComPort.Enabled = True

    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If connected Then
            Board.disconnect()
            btnConnect.Text = "Connect"
            btnUpdateFirmware.Enabled = True
            cmbVersion.Enabled = True
            cbComPort.Enabled = True
            gbMenu.Enabled = False
            connected = False
        Else
            Try
                If cbSimulation.Checked = True Then
                    Board = New DummyBoard
                Else
                    Board = New CSDBoard
                End If
                Board.connect(cbComPort.SelectedItem, cmbVersion.SelectedItem)
                gbMenu.Enabled = True
                connected = True
                btnConnect.Text = "Disconnect"
                btnUpdateFirmware.Enabled = False
                cmbVersion.Enabled = False
                cbComPort.Enabled = False

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If


    End Sub

    Private Sub btnOutputs_Click(sender As Object, e As EventArgs) Handles btnOutputs.Click
        Dim outputArray(3071) As Byte
        Dim brightness As Byte
        brightness = CInt(cbBrightness.SelectedItem) * 2.55

        If cbColor.SelectedItem = "Red" Then
            For i As Integer = 0 To 3071 Step 3
                outputArray(i) = brightness
            Next
        ElseIf cbColor.SelectedItem = "Green" Then
            For i As Integer = 1 To 3071 Step 3
                outputArray(i) = brightness
            Next
        ElseIf cbColor.SelectedItem = "Blue" Then
            For i As Integer = 2 To 3071 Step 3
                outputArray(i) = brightness
            Next
        ElseIf cbColor.SelectedItem = "White" Then
            For i As Integer = 0 To 3071 Step 1
                outputArray(i) = brightness
            Next
        ElseIf cbColor.SelectedItem = "Off" Then
            For i As Integer = 0 To 3071 Step 1
                outputArray(i) = 0
            Next
        End If



        Board.sendRaw({82, cbChannel.SelectedIndex * 4, 0, 4, 0})
        Board.sendRaw(outputArray)
        Thread.Sleep(100)
        Board.getBytes(1)
        Dim CommandData As Byte() = New Byte() {AscW("O"c)}
        Board.sendRaw(CommandData)
        Board.getBytes(1)
        'RemoveHandler Board.BoardChanged, AddressOf Board_BoardChanged

        'OutputsWindow = New Outputs(Board)

        'OutputsWindow.ShowDialog()
        'AddHandler Board.BoardChanged, AddressOf Board_BoardChanged
    End Sub






    Private Sub btnUpdateFirmware_Click(sender As Object, e As EventArgs) Handles btnUpdateFirmware.Click
        'AVRResources.avrdude


        If cmbVersion.SelectedItem = "Wemos D1 Mini" Then
            If MessageBox.Show("this will install the latest firmware. During connection, you will likely need to push the 'reset' button on the device. Click OK to continue", "Warning", MessageBoxButtons.OKCancel,
            Nothing, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            Else
                Exit Sub
            End If

            updateD1Firmware()
        Else
            If MessageBox.Show("this will install the latest firmware. Before proceeding, ensure it is in program mode (Hold '0' button while pressing 'reset', and a new COM port will be created used for uploading firmware) Click OK to continue", "Warning", MessageBoxButtons.OKCancel,
            Nothing, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            Else
                Exit Sub
            End If
            updateS2Firmware()
        End If



    End Sub
    Private Sub updateS2Firmware()
        Try
            If Not Directory.Exists(System.IO.Path.Combine(Application.StartupPath(), "csd_temp")) Then
                Directory.CreateDirectory(System.IO.Path.Combine(Application.StartupPath(), "csd_temp"))
            End If

            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "csd_temp", "esptool.exe"))
                output.Write(AVRResources.esptool, 0, AVRResources.esptool.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "csd_temp", "boot_app0.bin"))
                output.Write(AVRResources.boot_app0, 0, AVRResources.boot_app0.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "csd_temp", "WEMOS_Addressable.ino.partitions.bin"))
                output.Write(AVRResources.WEMOS_Addressable_ino_partitions, 0, AVRResources.WEMOS_Addressable_ino_partitions.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "csd_temp", "WEMOS_Addressable_s2.ino.bin"))
                output.Write(AVRResources.WEMOS_Addressable_s2_ino, 0, AVRResources.WEMOS_Addressable_s2_ino.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "csd_temp", "WEMOS_Addressable.ino.bootloader.bin"))
                output.Write(AVRResources.WEMOS_Addressable_ino_bootloader, 0, AVRResources.WEMOS_Addressable_ino_bootloader.Length)
            End Using



            If cbSimulation.Checked = True Then
                Board = New DummyBoard
            Else
                Board = New CSDBoard
            End If
            'Dim port As String = Board.setBootloader(cbComPort.SelectedItem)
            'If port = "MULTIPLE" Then
            '    MessageBox.Show("Ensure that the PinOne is the only COM PORT device plugged into the computer before installing new firmware")
            '    Exit Sub
            'End If
            Dim pHelp As New ProcessStartInfo
            pHelp.FileName = ".\csd_temp\esptool.exe"
            pHelp.Arguments = "--chip esp32s2 --port " & cbComPort.SelectedItem & " --baud 921600 --before default_reset --after hard_reset write_flash -z --flash_mode dio --flash_freq 80m --flash_size 4MB 0x1000 ./csd_temp/WEMOS_Addressable.ino.bootloader.bin 0x8000 ./csd_temp/WEMOS_Addressable.ino.partitions.bin 0xe000 ./csd_temp/boot_app0.bin 0x10000 ./csd_temp/WEMOS_Addressable_s2.ino.bin"
            'pHelp.Arguments = "-Cavrdude.conf -v -patmega32u4 -cavr109 -P" & port & " -b57600 -D -Uflash:w:.\joystick.ino.hex:i"
            pHelp.UseShellExecute = True
            pHelp.WindowStyle = ProcessWindowStyle.Normal
            Dim proc As Process = Process.Start(pHelp)

            ' Wait for the process to exit
            proc.WaitForExit()

            ' Check the exit code
            If proc.ExitCode = 0 Then
                MessageBox.Show("Successfully updated firmware")
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub updateD1Firmware()
        Try
            If Not Directory.Exists(System.IO.Path.Combine(Application.StartupPath(), "csd_temp")) Then
                Directory.CreateDirectory(System.IO.Path.Combine(Application.StartupPath(), "csd_temp"))
            End If
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "csd_temp", "python3Full.zip"))
                output.Write(AVRResources.python3Full, 0, AVRResources.python3Full.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "csd_temp", "build.zip"))
                output.Write(AVRResources.build, 0, AVRResources.build.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "csd_temp", "WEMOS_Addressable.ino.bin"))
                output.Write(AVRResources.WEMOS_Addressable_ino, 0, AVRResources.WEMOS_Addressable_ino.Length)
            End Using
            UnzipFile(System.IO.Path.Combine(Application.StartupPath(), "csd_temp", "python3Full.zip"))
            UnzipFile(System.IO.Path.Combine(Application.StartupPath(), "csd_temp", "build.zip"))


            If cbSimulation.Checked = True Then
                Board = New DummyBoard
            Else
                Board = New CSDBoard
            End If
            'Dim port As String = Board.setBootloader(cbComPort.SelectedItem)
            'If port = "MULTIPLE" Then
            '    MessageBox.Show("Ensure that the PinOne is the only COM PORT device plugged into the computer before installing new firmware")
            '    Exit Sub
            'End If
            Dim pHelp As New ProcessStartInfo
            pHelp.FileName = ".\csd_temp\python3.exe"
            pHelp.Arguments = "-I ./csd_temp/upload.py --chip esp8266 --port " & cbComPort.SelectedItem & " --baud 921600 --before default_reset --after hard_reset write_flash 0x0 ./csd_temp/WEMOS_Addressable.ino.bin"
            'pHelp.Arguments = "-Cavrdude.conf -v -patmega32u4 -cavr109 -P" & port & " -b57600 -D -Uflash:w:.\joystick.ino.hex:i"
            pHelp.UseShellExecute = True
            pHelp.WindowStyle = ProcessWindowStyle.Normal
            Dim proc As Process = Process.Start(pHelp)

            ' Wait for the process to exit
            proc.WaitForExit()

            ' Check the exit code
            If proc.ExitCode = 0 Then
                MessageBox.Show("Successfully updated firmware")
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub UnzipFile(zipPath As String)
        Dim extractPath As String = System.IO.Path.Combine(Application.StartupPath(), "csd_temp")

        If File.Exists(zipPath) Then
            Using archive As ZipArchive = ZipFile.OpenRead(zipPath)
                For Each entry In archive.Entries
                    Dim destinationPath As String = Path.Combine(extractPath, entry.FullName)
                    Dim directoryPath As String = Path.GetDirectoryName(destinationPath)

                    ' Ensure the directory exists
                    If Not Directory.Exists(directoryPath) Then
                        Directory.CreateDirectory(directoryPath)
                    End If

                    ' Overwrite the file if it exists
                    If File.Exists(destinationPath) Then
                        File.Delete(destinationPath)
                    End If

                    entry.ExtractToFile(destinationPath)
                Next
            End Using
            Console.WriteLine("Files extracted and overwritten to " + extractPath)
        Else
            Console.WriteLine("The zip file could not be found.")
        End If
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        MessageBox.Show("Version " & version(0).ToString & "." & version(1).ToString & "." & version(2).ToString)
    End Sub

    Private Sub cmbVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVersion.SelectedIndexChanged
        btnConnect.Enabled = True
        btnUpdateFirmware.Enabled = True
    End Sub

    Private Sub tmrComPort_Tick(sender As Object, e As EventArgs) Handles tmrComPort.Tick
        If Not connected Then
            Dim names = My.Computer.Ports.SerialPortNames
            Dim update = False
            For Each sp As String In names
                If Not currentComPorts.Contains(sp) Then
                    update = True
                End If
            Next
            If update Then
                currentComPorts = names
                cbComPort.Items.Clear()

                For Each sp As String In currentComPorts
                    cbComPort.Items.Add(sp)
                    cbComPort.SelectedIndex = 0
                Next
            End If
        End If



    End Sub

    Private Sub btnChannelLength_Click(sender As Object, e As EventArgs) Handles btnChannelLength.Click

        Dim textBoxes(8) As TextBox
        textBoxes(0) = TextBox1
        textBoxes(1) = TextBox2
        textBoxes(2) = TextBox3
        textBoxes(3) = TextBox4
        textBoxes(4) = TextBox5
        textBoxes(5) = TextBox6
        textBoxes(6) = TextBox7
        textBoxes(7) = TextBox8
        Dim max As UShort = 0
        For i As Integer = 0 To 7
            If CUShort(textBoxes(i).Text) > max Then max = CUShort(textBoxes(i).Text)
        Next
        Dim result As Byte() = BitConverter.GetBytes(max)
        Dim CommandData As Byte() = New Byte() {AscW("L"c), result(1), result(0)}

        Board.sendRaw(CommandData)
        Board.getBytes(1)
        For i As Integer = 0 To 7
            'If CUShort(textBoxes(i).Text) > 0 Then
            Dim result2 As Byte() = BitConverter.GetBytes(CUShort(textBoxes(i).Text))

                CommandData = New Byte() {AscW("Z"c), i, 7, result2(1), result2(0)}

                Board.sendRaw(CommandData)
                Board.getBytes(1)
            'End If

        Next


    End Sub


    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Dim CommandData As Byte() = New Byte() {AscW("T"c)}
        Board.sendRaw(CommandData)
        Board.getBytes(1)
    End Sub
End Class
