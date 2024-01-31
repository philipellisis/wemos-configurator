Imports System.Runtime.Remoting.Contexts
Imports System.Threading

Public Class CSDBoard
    Implements BoardInterface
    Private WithEvents CSDConnection As RS232
    Private context As Threading.SynchronizationContext = Threading.SynchronizationContext.Current




    Public Sub connect(port As String, type As String) Implements BoardInterface.connect

        CSDConnection = New RS232(port)
        Try
            CSDConnection.open(type)
            Thread.Sleep(100)
            sendRaw(System.Text.Encoding.Unicode.GetBytes("V"))
            Thread.Sleep(100)
            'CSDConnection.send({0, 251, 0, 0, 0, 0, 0, 0, 0})
            Dim retryCount = 0
            Do While retryCount < 5
                Dim result As Byte() = CSDConnection.ReadBytes(0)
                If result.Length > 0 Then
                    'CSDConnection.ReceiveDataEvents = True
                    Return
                End If
                retryCount += 1
                Thread.Sleep(100)
            Loop

        Catch ex As Exception
            CSDConnection.close()
        End Try


        Throw New Exception("Unable to connect to any board")
    End Sub
    Public Sub disconnect() Implements BoardInterface.disconnect
        Try
            CSDConnection.close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OnBoardChanged(ByVal e As BoardChangedArgs)
        RaiseEvent BoardChanged(Me, e)
    End Sub
    Private Sub OnBoardDisconnected(ByVal e As BoardCompletedArgs)
        RaiseEvent BoardDisconnected(Me, e)
    End Sub
    Private Sub sendBoardChanged(e As BoardChangedArgs)
        If context Is Nothing Then
            OnBoardChanged(e)
        Else
            ThreadExtensions.ScSend(context, New Action(Of BoardChangedArgs)(AddressOf OnBoardChanged), e)
        End If
    End Sub

    Public Event BoardChanged As EventHandler(Of BoardChangedArgs) Implements BoardInterface.BoardChanged
    Public Event BoardDisconnected As EventHandler(Of BoardCompletedArgs) Implements BoardInterface.BoardDisconnected

    Private Sub sendBoardDisconnected(e As BoardCompletedArgs)
        If context Is Nothing Then
            OnBoardDisconnected(e)
        Else
            ThreadExtensions.ScSend(context, New Action(Of BoardCompletedArgs)(AddressOf OnBoardDisconnected), e)
        End If
    End Sub

    Private incomingMessage As String
    Private Sub CSDConnection_RS232Changed(sender As Object, e As RS232ChangedArgs) Handles CSDConnection.RS232Changed
        sendBoardChanged(New BoardChangedArgs(e.message))


    End Sub
    Public Sub sendRaw(value() As Byte) Implements BoardInterface.sendRaw
        CSDConnection.send(value)
    End Sub
    Public Function getBytes(numberBytes As Integer) As Byte() Implements BoardInterface.getBytes
        Return CSDConnection.ReadBytes(numberBytes)
    End Function


End Class
