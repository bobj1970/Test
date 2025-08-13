Public Class frmCompletionRequestNote
    Public Shared CompletionNote As String

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        frmCompletions.CompletionNote = txtNote.Text.Trim
        Me.DialogResult = DialogResult.OK
    End Sub
    Private Sub frmCompletionRequestNote_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtNote.Text = CompletionNote

    End Sub
End Class