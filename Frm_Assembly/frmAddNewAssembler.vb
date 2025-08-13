Public Class frmAddNewAssembler
    Private Sub frmAddNewAssembler_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Me.cbDefaultClampNumber.DataSource = KPGeneral.WebRef_Local.GetTable("SELECT ClampName, ClampID FROM Clamps ORDER BY ClampID", "Clamp")
        Me.cbDefaultClampNumber.DataSource = KPGeneral.KPDataSQL.SP_EXEC("t_GetClamps")
        Me.cbDefaultClampNumber.DisplayMember = "ClampName"
        Me.cbDefaultClampNumber.ValueMember = "ClampID"
        Me.cbDefaultClampNumber.DisplayLayout.Bands(0).Columns("ClampName").Width = Me.cbDefaultClampNumber.Width
        Me.cbDefaultClampNumber.DisplayLayout.Bands(0).Columns("ClampID").Hidden = True
        Me.cbDefaultClampNumber.DisplayLayout.Bands(0).ColHeadersVisible = False

    End Sub

    Private Function VerifyTextBoxes() As String

        If Me.tbStationName.Text.Trim.Length = 0 Then
            Return "You must enter a valid station name."
        End If
        Dim stationName As String = Me.tbStationName.Text.Trim.ToLower()
        If KPGeneral.KPDataSQL.SP_EXEC("t_GetAssemblerByName", stationName).Tables(0).Rows.Count > 0 Then
            Return "This station name already exists. Please input a different one."
        End If
        If Not Me.cbDefaultClampNumber.IsItemInList Then
            Return "You must select a valid clamp."
        End If
        If Me.tbEmpRef.Text.Trim.Length <> 4 Then
            Return "You must enter a valid employee #.  Valid employee numbers are 4 digits long."
        End If
        If Me.tbPassword.Text.Trim.Length <> 4 Then
            Return "You must enter a valid password.  Valid password are 4 digits long."
        End If
        Return "valid"

    End Function

    Private Sub btnAddWorker_Click(sender As Object, e As EventArgs) Handles btnAddWorker.Click

        Dim validateText As String = Me.VerifyTextBoxes()
        If validateText = "valid" Then
            KPGeneral.KPDataSQL.SP_EXEC("t_AddNewAssembler",
                                        Me.tbEmpRef.Value,
                                        Me.tbPassword.Value,
                                        Me.tbStationName.Text.Trim,
                                        Me.cbDefaultClampNumber.Value,
                                        IIf(Me.tbAvgPerformance.Text = "", DBNull.Value, Me.tbAvgPerformance.Text),
                                        IIf(Me.tbTargetPercentage.Text = "", DBNull.Value, Me.tbTargetPercentage.Text))
            Me.DialogResult = DialogResult.OK
        Else
            MsgBox(validateText, MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If

    End Sub

    Private Sub tbEmpRef_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEmpRef.KeyPress

        If Not InputValidation.InputNumericOnly(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub tbAvgPerformance_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbAvgPerformance.KeyPress

        If Not InputValidation.InputNumericOnly(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub tbPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbPassword.KeyPress

        If Not InputValidation.InputNumericOnly(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub tbTargetPercentage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbTargetPercentage.KeyPress

        If Not InputValidation.InputNumericOnly(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        Me.Close()
    End Sub

End Class