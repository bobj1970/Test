Public Class frmDORDepartmentHours
    Public Shared SplitDepartmentID As Integer
    Public Shared SplitHours As Double
    Private Sub frmDORDepartmentHours_Load(sender As Object, e As EventArgs) Handles Me.Load
        uccSelDate.Text = Now.Date

        KPGeneral.SetDefaultGridSettings(ug_DORDepartmentHours_Department)
        KPGeneral.SetDefaultGridSettings(ug_DORDepartmentHours_SplitHours)

        RefreshDepartments()
    End Sub
    Private Sub RefreshDepartments()
        Dim dsMappedAccess As New DataSet
        dsMappedAccess = KPGeneral.WebRef_Local.usp_DOR_getMappedAccessByUserID(KPGeneral.User.UserProfile("UserLoginName"))

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
    Private Sub RefreshDailyData()
        If ucDepartments.IsItemInList = True Then
            RefreshDepartmentEmployees()
            RefreshSplitHours()

            CalculateDORHours()

            SetGridColour(ug_DORDepartmentHours_Department)
            SetGridColour(ug_DORDepartmentHours_SplitHours)
        End If
    End Sub
    Private Sub ucDepartments_ValueChanged(sender As Object, e As EventArgs) Handles ucDepartments.ValueChanged
        RefreshDailyData()
    End Sub
    Private Sub RefreshDepartmentEmployees()
        Dim dsEmployees As New DataSet
        dsEmployees = KPGeneral.WebRef_Local.usp_DOR_getDepartmentClockInfoByDepartmentIDAndDate(ucDepartments.Value, uccSelDate.Text)

        ug_DORDepartmentHours_Department.DataSource = dsEmployees

        KPGeneral.RefreshGridFromLayout(ug_DORDepartmentHours_Department, Me.GetType.Name)

        ug_DORDepartmentHours_Department.DisplayLayout.Bands(0).Columns("ClockIN").Format = KPGeneral.Time12HourFormatString
        ug_DORDepartmentHours_Department.DisplayLayout.Bands(0).Columns("ClockOUT").Format = KPGeneral.Time12HourFormatString
    End Sub
    Private Sub CalculateDORHours()
        Dim x, TotalHours As Integer
        For x = 0 To ug_DORDepartmentHours_Department.Rows.Count - 1
            If IsDBNull(ug_DORDepartmentHours_Department.Rows(x).Cells("TotalHours").Value) = False Then
                TotalHours = TotalHours + ug_DORDepartmentHours_Department.Rows(x).Cells("TotalHours").Text
            End If
        Next

        For x = 0 To ug_DORDepartmentHours_SplitHours.Rows.Count - 1
            If ug_DORDepartmentHours_SplitHours.Rows(x).Cells("SplitDepartment").Text.ToLower = ucDepartments.Text.ToLower Then
                If IsDBNull(ug_DORDepartmentHours_SplitHours.Rows(x).Cells("TotalHours").Value) = False Then
                    TotalHours = TotalHours + ug_DORDepartmentHours_SplitHours.Rows(x).Cells("TotalHours").Text
                End If
            End If
        Next

        lblTotalHours.Text = "Total Hours for DOR: " & TotalHours
    End Sub
    Private Sub RefreshSplitHours()
        Dim dsSplitHours As New DataSet
        dsSplitHours = KPGeneral.WebRef_Local.usp_DOR_getDepartmentClockInfo_SplitDepartments_ByDepartmentIDAndDate(ucDepartments.Value, uccSelDate.Text)

        ug_DORDepartmentHours_SplitHours.DataSource = dsSplitHours

        KPGeneral.RefreshGridFromLayout(ug_DORDepartmentHours_SplitHours, Me.GetType.Name)

        ug_DORDepartmentHours_SplitHours.DisplayLayout.Bands(0).Columns("ClockIN").Format = KPGeneral.Time12HourFormatString
        ug_DORDepartmentHours_SplitHours.DisplayLayout.Bands(0).Columns("ClockOUT").Format = KPGeneral.Time12HourFormatString
    End Sub
    Private Sub uccSelDate_TextChanged(sender As Object, e As EventArgs) Handles uccSelDate.TextChanged
        RefreshDailyData()
    End Sub
    Private Sub ColumnChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem.Click
        KPGeneral.ColumnChooser(ug_DORDepartmentHours_Department, Me.GetType.Name)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem1.Click
        KPGeneral.ColumnChooser(ug_DORDepartmentHours_SplitHours, Me.GetType.Name)
    End Sub
    Private Sub VerifyHoursToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerifyHoursToolStripMenuItem.Click
        If ug_DORDepartmentHours_Department.Selected.Rows.Count > 0 Then
            Dim ShowError As Boolean = False

            Dim x As Integer
            For x = 0 To ug_DORDepartmentHours_Department.Selected.Rows.Count - 1
                If IsDBNull(ug_DORDepartmentHours_Department.Selected.Rows(x).Cells("ClockIN").Value) = False Then
                    If IsDBNull(ug_DORDepartmentHours_Department.Selected.Rows(x).Cells("ClockOUT").Value) = False Then
                        Dim ProcessVerify As Boolean = True

                        If IsDBNull(ug_DORDepartmentHours_Department.Selected.Rows(x).Cells("TotalHours").Value) = False Then
                            If MsgBox("The employee ( " & ug_DORDepartmentHours_Department.Selected.Rows(x).Cells("FullName").Text & " ) has already been verified.  Do you wish to re-verify them?  It will remove any split time as well.", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.No Then
                                ProcessVerify = False
                            End If
                        End If

                        If ProcessVerify = True Then
                            KPGeneral.WebRef_Local.usp_DOR_VerifyClockHours(ug_DORDepartmentHours_Department.Selected.Rows(x).Cells("Empref").Text,
                                                                            ucDepartments.Value, ug_DORDepartmentHours_Department.Selected.Rows(x).Cells("ClockIN").Value,
                                                                            ug_DORDepartmentHours_Department.Selected.Rows(x).Cells("ClockOUT").Value,
                                                                            0, 0, KPGeneral.User.UserProfile("UserLoginName"))
                        End If

                    Else
                        ShowError = True
                    End If
                Else
                    ShowError = True
                End If
            Next

            If ShowError = True Then
                MsgBox("Some of the selected employees had a missing start or end time.  Hours cannot be verified for them without it.  Please have their clock information fixed before verifying them again.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If

            RefreshDailyData()
        End If
    End Sub
    Private Sub SplitHoursToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SplitHoursToolStripMenuItem.Click
        If ug_DORDepartmentHours_Department.ActiveRow.Index > -1 Then
            SplitHours = 0
            SplitDepartmentID = 0

            Dim ProcessVerify As Boolean = True

            If IsDBNull(ug_DORDepartmentHours_Department.ActiveRow.Cells("TotalHours").Value) = False Then
                If MsgBox("The employee ( " & ug_DORDepartmentHours_Department.ActiveRow.Cells("FullName").Text & " ) has already been verified.  Do you wish to split them?  It will remove any split time as well.", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.No Then
                    ProcessVerify = False
                End If
            End If

            If ProcessVerify = True Then
                Dim SplitDepartmentPopUp = New frmDORSplitDepartmentPopUp
                SplitDepartmentPopUp.EmployeeName = ug_DORDepartmentHours_Department.ActiveRow.Cells("FullName").Text
                SplitDepartmentPopUp.ShowDialog()

                If SplitDepartmentID > 0 Then
                    KPGeneral.WebRef_Local.usp_DOR_VerifyClockHours(ug_DORDepartmentHours_Department.ActiveRow.Cells("Empref").Text,
                                                    ucDepartments.Value, ug_DORDepartmentHours_Department.ActiveRow.Cells("ClockIN").Value,
                                                    ug_DORDepartmentHours_Department.ActiveRow.Cells("ClockOUT").Value,
                                                    SplitDepartmentID, SplitHours, KPGeneral.User.UserProfile("UserLoginName"))
                End If

                RefreshDailyData()
            End If

        End If
    End Sub
    Private Sub SetGridColour(ByVal uGrid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim x As Integer
        For x = 0 To uGrid.Rows.Count - 1
            uGrid.Rows(x).Appearance.BackColor = Color.White

            If IsDBNull(uGrid.Rows(x).Cells("ClockOUT").Value) = False Then
                uGrid.Rows(x).Appearance.BackColor = Color.Salmon
            Else
                If IsDBNull(uGrid.Rows(x).Cells("ClockIN").Value) = True Then
                    uGrid.Rows(x).Appearance.BackColor = Color.Salmon
                End If
            End If
        Next
    End Sub
End Class