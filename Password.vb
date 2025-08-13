Public Class Password
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        KPGeneral.AccessPassword = txtPassword.Text
        txtPassword.Text = Nothing
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        KPGeneral.AccessPassword = Nothing
        txtPassword.Text = Nothing
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                e.Handled = True
                KPGeneral.AccessPassword = txtPassword.Text
                txtPassword.Text = Nothing
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Password_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPassword.Focus()
    End Sub
End Class