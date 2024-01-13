Imports System.Runtime.Remoting.Contexts
Imports System.Threading

Public Class CSDBoard
    Implements BoardInterface
    Private WithEvents CSDConnection As RS232
    Private context As Threading.SynchronizationContext = Threading.SynchronizationContext.Current




    Public Sub connect(port As String) Implements BoardInterface.connect
        If port = "Auto" Then
            For Each sp As String In My.Computer.Ports.SerialPortNames

                CSDConnection = New RS232(sp)
                Try
                    CSDConnection.open()
                    sendRaw({"V"})
                    Do While True
                        Dim result As Byte() = CSDConnection.ReadBytes()
                        If result(0) = 2 And result(1) = 1 Then
                            CSDConnection.ReceiveDataEvents = True
                            Return
                        End If
                    Loop

                Catch ex As Exception
                    CSDConnection.close()
                End Try
            Next
        Else
            CSDConnection = New RS232(port)
            Try
                CSDConnection.open()
                sendRaw(System.Text.Encoding.Unicode.GetBytes("V"))
                'CSDConnection.send({0, 251, 0, 0, 0, 0, 0, 0, 0})
                Do While True
                    Dim result As Byte() = CSDConnection.ReadBytes()
                    If result.Length > 0 Then
                        CSDConnection.ReceiveDataEvents = True
                        Return
                    End If
                Loop

            Catch ex As Exception
                CSDConnection.close()
            End Try
        End If

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

    Public Function setBootloader(port As String) As String Implements BoardInterface.setBootloader
        Dim currentPorts As New Dictionary(Of String, String)
        Dim initialPortToOpen As String

        For Each sp As String In My.Computer.Ports.SerialPortNames
            If Not currentPorts.ContainsKey(sp) Then
                currentPorts.Add(sp, sp)
            End If
        Next
        If currentPorts.Count > 1 And port = "Auto" Then
            Return "MULTIPLE"
        End If
        If port = "Auto" Then
            initialPortToOpen = currentPorts.First().Key
            CSDConnection = New RS232(currentPorts.First().Key)
        Else
            initialPortToOpen = port
            CSDConnection = New RS232(port)
        End If

        Try
            Dim foundPort = False
            Dim tryCounter = 0
            Dim portAdded As String
            CSDConnection.open1200()


            Console.WriteLine("searching for port added")
            While foundPort = False And tryCounter < 25

                Dim newPorts As New Dictionary(Of String, String)
                For Each sp As String In My.Computer.Ports.SerialPortNames
                    If Not newPorts.ContainsKey(sp) Then
                        newPorts.Add(sp, sp)
                    End If
                Next
                Dim newComPorts As String = String.Join(", ", newPorts.Keys)
                Dim oldComPorts As String = String.Join(", ", currentPorts.Keys)
                Console.WriteLine("new com ports: " & newComPorts)
                Console.WriteLine("old com ports: " & oldComPorts)
                For Each spInitial As KeyValuePair(Of String, String) In newPorts
                    If Not currentPorts.ContainsKey(spInitial.Key) Then
                        portAdded = spInitial.Key
                        foundPort = True
                        Console.WriteLine("Found added port on " & portAdded & ", ready to receive data")
                    End If
                Next
                If foundPort = False Then Console.WriteLine("no port added, continuing search")

                Thread.Sleep(50)
                tryCounter += 1
            End While
            'Thread.Sleep(700)
            CSDConnection.close()


            If foundPort Then
                Return portAdded
            Else
                Console.WriteLine("no new port found, trying on initial port")
                Return initialPortToOpen
            End If
            'Thread.Sleep(700)
            For Each spBoot As String In My.Computer.Ports.SerialPortNames
                If Not currentPorts.ContainsKey(spBoot) Then
                    Return spBoot
                End If
            Next
        Catch ex As Exception
            CSDConnection.close()
            Return currentPorts.First().Key
        End Try

        Throw New Exception("Unable to connect to any board")
    End Function
End Class
