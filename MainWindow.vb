﻿Imports System.IO
Imports CSDAddressableControllerTool.My
Imports CSDAddressableControllerTool.My.Resources
Imports System.Windows.Forms
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.IO.Compression

Public Class MainWindow
    Private OutputsWindow As Outputs

    Private version As Integer() = {1, 13, 0}
    'Private WithEvents arduino As RS232
    Private Board As BoardInterface
    Private connected As Boolean
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cbComPort.Items.Add(sp)
            cbComPort.SelectedIndex = 0
        Next

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
                Board.connect(cbComPort.SelectedItem)
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

        If cbColor.SelectedItem = "Red" Then
            For i As Integer = 0 To 3071 Step 3
                outputArray(i) = 55
            Next
        ElseIf cbColor.SelectedItem = "Green" Then
            For i As Integer = 1 To 3071 Step 3
                outputArray(i) = 55
            Next
        ElseIf cbColor.SelectedItem = "Blue" Then
            For i As Integer = 2 To 3071 Step 3
                outputArray(i) = 55
            Next
        ElseIf cbColor.SelectedItem = "White" Then
            For i As Integer = 0 To 3071 Step 1
                outputArray(i) = 55
            Next
        ElseIf cbColor.SelectedItem = "Off" Then
            For i As Integer = 0 To 3071 Step 1
                outputArray(i) = 0
            Next
        End If



        Board.sendRaw({82, cbChannel.SelectedIndex * 2, 0, 4, 0})
        Board.sendRaw(outputArray)
        Board.getBytes()
        Dim CommandData As Byte() = New Byte() {AscW("O"c)}
        Board.sendRaw(CommandData)
        Board.getBytes()
        'RemoveHandler Board.BoardChanged, AddressOf Board_BoardChanged

        'OutputsWindow = New Outputs(Board)

        'OutputsWindow.ShowDialog()
        'AddHandler Board.BoardChanged, AddressOf Board_BoardChanged
    End Sub






    Private Sub btnUpdateFirmware_Click(sender As Object, e As EventArgs) Handles btnUpdateFirmware.Click
        'AVRResources.avrdude

        If MessageBox.Show("Ensure you only have one CSD board connected before proceeding to install or you have the correct COM port selected, this will install the latest firmware. Click OK to continue", "Warning", MessageBoxButtons.OKCancel,
            Nothing, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
        Else
            Exit Sub
        End If
        If cmbVersion.SelectedItem = "Wemos D1 Mini" Then
            updateD1Firmware()
        Else
            updateS2Firmware()
        End If



    End Sub
    Private Sub updateS2Firmware()
        Try
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "esptool.exe"))
                output.Write(AVRResources.esptool, 0, AVRResources.esptool.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "boot_app0.bin"))
                output.Write(AVRResources.boot_app0, 0, AVRResources.boot_app0.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "WEMOS_Addressable.ino.partitions.bin"))
                output.Write(AVRResources.WEMOS_Addressable_ino_partitions, 0, AVRResources.WEMOS_Addressable_ino_partitions.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "WEMOS_Addressable_s2.ino.bin"))
                output.Write(AVRResources.WEMOS_Addressable_s2_ino, 0, AVRResources.WEMOS_Addressable_s2_ino.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "WEMOS_Addressable.ino.bootloader.bin"))
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
            pHelp.FileName = ".\esptool.exe"
            pHelp.Arguments = "--chip esp32s2 --port " & cbComPort.SelectedItem & " --baud 921600 --before default_reset --after hard_reset write_flash -z --flash_mode dio --flash_freq 80m --flash_size 4MB 0x1000 ./WEMOS_Addressable.ino.bootloader.bin 0x8000 ./WEMOS_Addressable.ino.partitions.bin 0xe000 ./boot_app0.bin 0x10000 ./WEMOS_Addressable_s2.ino.bin"
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
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "python3Full.zip"))
                output.Write(AVRResources.python3Full, 0, AVRResources.python3Full.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "build.zip"))
                output.Write(AVRResources.build, 0, AVRResources.build.Length)
            End Using
            Using output As Stream = File.OpenWrite(System.IO.Path.Combine(Application.StartupPath(), "WEMOS_Addressable.ino.bin"))
                output.Write(AVRResources.WEMOS_Addressable_ino, 0, AVRResources.WEMOS_Addressable_ino.Length)
            End Using
            UnzipFile(System.IO.Path.Combine(Application.StartupPath(), "python3Full.zip"))
            UnzipFile(System.IO.Path.Combine(Application.StartupPath(), "build.zip"))


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
            pHelp.FileName = ".\python3.exe"
            pHelp.Arguments = "-I ./upload.py --chip esp8266 --port " & cbComPort.SelectedItem & " --baud 921600 --before default_reset --after hard_reset write_flash 0x0 ./WEMOS_Addressable.ino.bin"
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
        Dim extractPath As String = Directory.GetCurrentDirectory()

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
End Class
