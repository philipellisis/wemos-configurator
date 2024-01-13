Imports System.Threading

Public Class Output
    Private _board As BoardInterface
    Private _number As Byte
    Private _delayRefresh As Boolean = False
    Private _intensityValue As Byte = 0
    Private trdCount As Integer = 5
    Public Sub New(board As BoardInterface, outputNumber As Byte)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _board = board
        _number = outputNumber
        gbMain.Text = "Output #" & (outputNumber + 1).ToString
        If outputNumber > 3 And outputNumber < 15 Then
            tbIntensity.Enabled = False
        End If
    End Sub

End Class
