Imports System.Drawing.Text
Imports System.Runtime.Remoting.Contexts
Imports System.Threading

Public Class DummyBoard

    Implements BoardInterface
    Private trd As Thread
    Private outputs As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Private inputs As Integer() = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Private plunger As Integer = 0
    Private threadContinue As Boolean = False
    Private context As Threading.SynchronizationContext = Threading.SynchronizationContext.Current


    Public Sub connect(port As String, type As String) Implements BoardInterface.connect

    End Sub
    Public Sub disconnect() Implements BoardInterface.disconnect

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

    Private Function getRandomValue() As String
        Return (CInt(Math.Ceiling(Rnd() * 255)) + 1).ToString
    End Function

    Public Sub sendRaw(value() As Byte) Implements BoardInterface.sendRaw

    End Sub

    Public Function getBytes(numberBytes As Integer) As Byte() Implements BoardInterface.getBytes
        Return {1}
    End Function
End Class
