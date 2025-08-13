Public Class frmDORSplitDepartmentPopUp
    Public Shared EmployeeName As String
    Dim AllowedChars As String = "0123456789."
    Dim AllowedChars2 As String = "0123456789"

    Private Sub FillDepartmentList()
        Dim dsMappedAccess As New DataSet
        dsMappedAccess = KPGeneral.WebRef_Local.usp_DOR_getDepartments

        ucDepartments.DataSource = dsMappedAccess

        Dim x As Integer
        For x = 0 To ucDepartments.DisplayLayout.Bands(0).Columns.Count - 1
            ucDepartments.DisplayLayout.Bands(0).Columns(x).Hidden = True
        Next

        ucDepartments.DisplayLayout.Bands(0).Columns("DepartmentName").Hidden = False
        ucDepartments.DisplayLayout.Bands(0).Columns("DepartmentName").Width = ucDepartments.Width

        ucDepartments.ValueMember = "DepartmentID"
        ucDepartments.DisplayMember = "DepartmentName"
    End Sub
    Private Sub btnSaveSplitHours_Click(sender As Object, e As EventArgs) Handles btnSaveSplitHours.Click
        If ucDepartments.IsItemInList = True Then
            If txtHoursSplit.Text.Trim.Length > 0 Then
                frmDORDepartmentHours.SplitDepartmentID = ucDepartments.Value
                frmDORDepartmentHours.SplitHours = txtHoursSplit.Text.Trim
                Me.Close()
            Else
                MsgBox("Please enter valid hours worked before saving.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        Else
            MsgBox("Please select a valid department before saving.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub txtHoursSplit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoursSplit.KeyPress
        If txtHoursSplit.Text.Contains(".") Then
            If AllowedChars2.IndexOf(e.KeyChar) = -1 Then
                e.Handled = True
            End If
        Else
            If AllowedChars.IndexOf(e.KeyChar) = -1 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frmDORSplitDepartmentPopUp_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "DOR Split Department - " & EmployeeName
        FillDepartmentList()
    End Sub
End Class