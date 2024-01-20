
Imports System.CodeDom.Compiler
Imports System.Runtime.Remoting.Contexts
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.SqlServer.Server

Public Class RS232ChangedArgs
    Public message As Byte()
    Public Sub New(message As Byte())
        Me.message = message
    End Sub
End Class
Public Class RS232CompletedArgs
    Public message As Byte()
    Public Sub New()

    End Sub
End Class
Public Class RS232
    Private WithEvents objSerial As System.IO.Ports.SerialPort
    Private context As Threading.SynchronizationContext = Threading.SynchronizationContext.Current
    Private _ReceiveDataEvents As Boolean = False
    Public Sub New(port As String)
        objSerial = New IO.Ports.SerialPort(port)
    End Sub

    Public Property ReceiveDataEvents As Boolean
        Get
            Return _ReceiveDataEvents
        End Get
        Set(value As Boolean)
            If value Then
                AddHandler objSerial.DataReceived, AddressOf objSerial_DataReceived
            Else
                RemoveHandler objSerial.DataReceived, AddressOf objSerial_DataReceived
            End If
            _ReceiveDataEvents = value
        End Set
    End Property
    Public Sub open(type As String)
        objSerial.BaudRate = 2000000
        objSerial.Handshake = IO.Ports.Handshake.None

        objSerial.ReadTimeout = 500
        objSerial.Open()

        If type = "Wemos S2 Mini" Then
            objSerial.DtrEnable = True
        End If

    End Sub

    Public Sub open1200()
        objSerial.BaudRate = 1200
        objSerial.Handshake = IO.Ports.Handshake.None

        objSerial.ReadTimeout = 500
        objSerial.Open()
        objSerial.NewLine = vbLf
    End Sub

    Public Sub close()
        objSerial.Close()
    End Sub

    Public Function read() As String
        Return objSerial.ReadExisting()
    End Function

    Public Function ReadBytes() As Byte()
        Thread.Sleep(100)
        Dim byteCount As Integer = objSerial.BytesToRead
        If byteCount > 0 Then
            Dim buffer(byteCount - 1) As Byte
            objSerial.Read(buffer, 0, byteCount)
            Console.WriteLine(BytesToString(buffer))
            Console.WriteLine(ByteArrayToASCIIString(buffer))
            Return buffer
        Else
            Return New Byte() {}
        End If
    End Function
    Public Sub send(bytes() As Byte)
        Dim sendStr As String = ""
        For i As Integer = 0 To bytes.Length - 2
            sendStr += bytes(i).ToString & ","
        Next
        sendStr += bytes(bytes.Length - 1).ToString
        Console.WriteLine("rs232 actual send Data: " & sendStr)
        objSerial.Write(bytes, 0, bytes.Length)
    End Sub

    Public Event RS232Changed As EventHandler(Of RS232ChangedArgs)
    Protected Overridable Sub OnIESChanged(ByVal e As RS232ChangedArgs)
        RaiseEvent RS232Changed(Me, e)
    End Sub
    Public Event RS232Completed As EventHandler(Of RS232CompletedArgs)
    Protected Overridable Sub OnIESCompleted(ByVal e As RS232CompletedArgs)
        RaiseEvent RS232Completed(Me, e)
    End Sub
    Private Sub sendRS232Changed(e As RS232ChangedArgs)
        If Not e.message Is Nothing And e.message.Length > 0 Then
            If context Is Nothing Then
                OnIESChanged(e)
            Else
                ThreadExtensions.ScSend(context, New Action(Of RS232ChangedArgs)(AddressOf OnIESChanged), e)
            End If
        End If
    End Sub
    Private Sub sendRS232Completed(e As RS232CompletedArgs)
        If context Is Nothing Then
            OnIESCompleted(e)
        Else
            ThreadExtensions.ScSend(context, New Action(Of RS232CompletedArgs)(AddressOf OnIESCompleted), e)
        End If
    End Sub

    Private lineData As StringBuilder = New StringBuilder
    Private Sub objSerial_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) 'Handles objSerial.DataReceived
        Dim bytes As Byte() = ReadBytes()
        Console.WriteLine(BytesToString(bytes))
        Console.WriteLine(ByteArrayToASCIIString(bytes))
        sendRS232Changed(New RS232ChangedArgs(bytes))


    End Sub

    Private Sub objSerial_error(sender As Object, e As IO.Ports.SerialErrorReceivedEventArgs) Handles objSerial.ErrorReceived

    End Sub
    Public Function ByteArrayToASCIIString(ByVal byteArray As Byte()) As String
        If byteArray Is Nothing OrElse byteArray.Length = 0 Then
            Return String.Empty
        End If

        Return System.Text.Encoding.ASCII.GetString(byteArray)
    End Function
    Public Function BytesToString(ByVal bytes As Byte()) As String
        If bytes Is Nothing OrElse bytes.Length = 0 Then
            Return String.Empty
        End If

        Dim result As New StringBuilder()

        For Each b As Byte In bytes
            result.Append(b.ToString())
            result.Append(",")
        Next

        ' Remove the last comma
        result.Length -= 1

        Return result.ToString()
    End Function
End Class

