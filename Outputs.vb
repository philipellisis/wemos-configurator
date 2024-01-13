Public Class Outputs
    Private _userControlList As New List(Of Output)
    Public _board As BoardInterface
    Private outputOn As Integer = -1
    Public Sub New(board As BoardInterface)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _board = board
    End Sub
    Private Sub Outputs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler _board.BoardChanged, AddressOf _board_BoardChanged
    End Sub

    Private Sub _board_BoardChanged(sender As Object, e As BoardChangedArgs)
        Try

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Outputs_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        RemoveHandler _board.BoardChanged, AddressOf _board_BoardChanged
    End Sub

End Class