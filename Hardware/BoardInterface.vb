Imports System.Runtime.InteropServices.WindowsRuntime

Public Enum ORIENTATION
    UP
    DOWN
    LEFT
    RIGHT
End Enum




Public Class BoardChangedArgs
    Public message As Byte()
    Public Sub New(message As Byte())
        Me.message = message
    End Sub
End Class
Public Class BoardCompletedArgs
    Public message As String
    Public status As String
    Public Sub New(message As String, status As String)
        Me.message = message
        Me.status = status
    End Sub
End Class
Public Interface BoardInterface
    Event BoardChanged As EventHandler(Of BoardChangedArgs)
    Event BoardDisconnected As EventHandler(Of BoardCompletedArgs)
    Sub connect(port As String, type As String)

    Sub disconnect()

    Sub sendRaw(value As Byte())

    Function getBytes() As Byte()

End Interface
