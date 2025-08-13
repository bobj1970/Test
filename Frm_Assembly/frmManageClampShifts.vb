Imports Infragistics.Win.UltraWinSchedule
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinTabControl
Imports Org.BouncyCastle.Crypto.Engines

Public Class frmManageClampShifts
    Dim ClampShiftID As Integer

    Dim MondayDate As DateTime
    Dim TuesdayDate As DateTime
    Dim WednesdayDate As DateTime
    Dim ThursdayDate As DateTime
    Dim FridayDate As DateTime
    Dim SaturdayDate As DateTime
    Private Sub frmManageClampShifts_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshShiftDropdowns()

        LoadClampEmployees()

        umvShiftDate.CalendarInfo.SelectedDateRanges.Clear()
        umvShiftDate.CalendarInfo.SelectedDateRanges.Add(Now.Date)

        umvShiftDate.CalendarInfo.ActiveDay = umvShiftDate.CalendarInfo.SelectedDateRanges(0).FirstDay

        RefreshDataBasedOffTab()
    End Sub
    Private Sub RefreshShiftDropdowns()
        Dim dsShiftStart, dsShiftEnd As New DataSet
        dsShiftStart = KPGeneral.WebRef_Local.usp_GetClampShiftTimes(True)
        dsShiftEnd = KPGeneral.WebRef_Local.usp_GetClampShiftTimes(False)

        ucShiftStart.DataSource = dsShiftStart
        ucShiftStart.DisplayLayout.Bands(0).Columns("ShiftTime").Width = ucShiftStart.Width
        ucShiftStart.DisplayLayout.Bands(0).ColHeadersVisible = False

        ucShiftEnd.DataSource = dsShiftEnd
        ucShiftEnd.DisplayLayout.Bands(0).Columns("ShiftTime").Width = ucShiftEnd.Width
        ucShiftEnd.DisplayLayout.Bands(0).ColHeadersVisible = False

        ucShiftStartWeekly.DataSource = dsShiftStart
        ucShiftStartWeekly.DisplayLayout.Bands(0).Columns("ShiftTime").Width = ucShiftStart.Width
        ucShiftStartWeekly.DisplayLayout.Bands(0).ColHeadersVisible = False

        ucShiftEndWeekly.DataSource = dsShiftEnd
        ucShiftEndWeekly.DisplayLayout.Bands(0).Columns("ShiftTime").Width = ucShiftEnd.Width
        ucShiftEndWeekly.DisplayLayout.Bands(0).ColHeadersVisible = False
    End Sub
    Function ConvertDateTimeToDropdown(ByVal OriginalDateTimeValue As DateTime) As String
        Dim OriginalTime As String

        OriginalTime = OriginalDateTimeValue.ToShortTimeString

        Return OriginalTime
    End Function
    Function ConvertStringToDateTime(ByVal StringValue As String) As DateTime
        Dim NewTime As DateTime

        NewTime = Convert.ToDateTime(StringValue)

        Return NewTime
    End Function
    Private Sub CheckDropdowns(ByVal uCombo As UltraCombo, ByVal ConvertedValue As String)
        Dim x As Integer

        Dim Match As Boolean = False

        For x = 0 To uCombo.Rows.Count - 1
            If uCombo.Rows(x).Cells("ShiftTime").Text.ToLower.Trim = ConvertedValue.ToLower.Trim Then
                uCombo.Text = ConvertedValue
                Match = True
                Exit For
            End If
        Next

        If Match = False Then
            uCombo.Text = ""
        End If
    End Sub
    Private Sub LoadClampEmployees()
        Dim dsEmployees As New DataSet
        dsEmployees = KPGeneral.WebRef_Local.usp_GetActiveClampWorkers()

        LoadClampCombos(ucClamp1, dsEmployees)
        LoadClampCombos(ucClamp2, dsEmployees)
        LoadClampCombos(ucClamp3, dsEmployees)
        LoadClampCombos(ucClamp4, dsEmployees)
        LoadClampCombos(ucClamp5, dsEmployees)
        LoadClampCombos(ucClamp6, dsEmployees)
        LoadClampCombos(ucClamp7, dsEmployees)
        LoadClampCombos(ucClamp8, dsEmployees)
    End Sub
    Private Sub LoadClampCombos(ByVal uCombo As UltraCombo, ByVal dsEmployees As DataSet)
        uCombo.DataSource = dsEmployees
        uCombo.DisplayMember = "StationName"
        uCombo.ValueMember = "ID"

        Dim x As Integer
        For x = 0 To uCombo.DisplayLayout.Bands(0).Columns.Count - 1
            Dim ColumnName As String = uCombo.DisplayLayout.Bands(0).Columns(x).Key.ToLower

            If ColumnName <> "stationname" Then
                uCombo.DisplayLayout.Bands(0).Columns(x).Hidden = True
            Else
                uCombo.DisplayLayout.Bands(0).Columns(x).Hidden = False
                uCombo.DisplayLayout.Bands(0).Columns(x).Width = uCombo.Width
            End If
        Next

    End Sub
    Private Sub RefreshInfo()
        Dim ShiftDate As DateTime = umvShiftDate.CalendarInfo.ActiveDay.Date

        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetClampShiftInfoByDate(ShiftDate)

        ClampShiftID = 0

        Dim ModifiedByStartText As String = "Modified By: "
        Dim ModifiedOnStartText As String = "Modified On: "

        Dim ShiftStart As DateTime

        If ds.Tables(0).Rows.Count > 0 Then
            ClampShiftID = ds.Tables(0).Rows(0)("ClampShiftID")

            Dim ConvertedDateTimeValue As String

            If IsDBNull(ds.Tables(0).Rows(0)("ShiftStart")) = False Then
                ConvertedDateTimeValue = ConvertDateTimeToDropdown(ds.Tables(0).Rows(0)("ShiftStart"))
            Else
                ucShiftStart.Text = ""
            End If

            If ConvertedDateTimeValue.Trim.Length > 0 Then
                CheckDropdowns(ucShiftStart, ConvertedDateTimeValue)
            Else
                ucShiftStart.Text = ""
            End If

            ConvertedDateTimeValue = ""

            If IsDBNull(ds.Tables(0).Rows(0)("ShiftEnd")) = False Then
                ConvertedDateTimeValue = ConvertDateTimeToDropdown(ds.Tables(0).Rows(0)("ShiftEnd"))
            Else
                ucShiftEnd.Text = ""
            End If

            If ConvertedDateTimeValue.Trim.Length > 0 Then
                CheckDropdowns(ucShiftEnd, ConvertedDateTimeValue)
            Else
                ucShiftEnd.Text = ""
            End If

            If IsDBNull(ds.Tables(0).Rows(0)("ModifiedBy")) = False Then
                lblModifiedBy.Text = ModifiedByStartText & ds.Tables(0).Rows(0)("ModifiedBy")
            Else
                lblModifiedBy.Text = ModifiedByStartText
            End If

            If IsDBNull(ds.Tables(0).Rows(0)("ModifiedOn")) = False Then
                lblModifiedOn.Text = ModifiedOnStartText & ds.Tables(0).Rows(0)("ModifiedOn")
            Else
                lblModifiedOn.Text = ModifiedOnStartText
            End If

            LoadPreviousInfo(ClampShiftID, chkClamp1, ucClamp1, 1)
            LoadPreviousInfo(ClampShiftID, chkClamp2, ucClamp2, 2)
            LoadPreviousInfo(ClampShiftID, chkClamp3, ucClamp3, 3)
            LoadPreviousInfo(ClampShiftID, chkClamp4, ucClamp4, 4)
            LoadPreviousInfo(ClampShiftID, chkClamp5, ucClamp5, 5)
            LoadPreviousInfo(ClampShiftID, chkClamp6, ucClamp6, 6)
            LoadPreviousInfo(ClampShiftID, chkClamp7, ucClamp7, 7)
            LoadPreviousInfo(ClampShiftID, chkClamp8, ucClamp8, 8)
        Else
            ucShiftStart.Text = ""
            ucShiftEnd.Text = ""
            lblModifiedOn.Text = ModifiedOnStartText
            lblModifiedBy.Text = ModifiedByStartText
            chkClamp1.CheckedValue = False
            chkClamp2.CheckedValue = False
            chkClamp3.CheckedValue = False
            chkClamp4.CheckedValue = False
            chkClamp5.CheckedValue = False
            chkClamp6.CheckedValue = False
            chkClamp7.CheckedValue = False
            chkClamp8.CheckedValue = False
            ucClamp1.Text = ""
            ucClamp2.Text = ""
            ucClamp3.Text = ""
            ucClamp4.Text = ""
            ucClamp5.Text = ""
            ucClamp6.Text = ""
            ucClamp7.Text = ""
            ucClamp8.Text = ""
        End If
    End Sub
    Private Sub UpdateInfo()
        Dim ShiftStartDateTime As DateTime
        Dim ShiftEndDateTime As DateTime

        If ucShiftStart.IsItemInList = True Then
            ShiftStartDateTime = ConvertStringToDateTime(ucShiftStart.Text.Trim)
        Else
            MsgBox("Please select a value from the Shift Start drop down.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Exit Sub
        End If

        If ucShiftEnd.IsItemInList = True Then
            ShiftEndDateTime = ConvertStringToDateTime(ucShiftEnd.Text.Trim)
        Else
            MsgBox("Please select a value from the Shift End drop down.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Exit Sub
        End If

        KPGeneral.WebRef_Local.usp_UpdateClampShiftDateInfo(ClampShiftID, umvShiftDate.CalendarInfo.ActiveDay.Date,
                                                            ShiftStartDateTime, ShiftEndDateTime, KPGeneral.User.UserProfile("UserLoginName"))

        SaveDailyClampInfo()

        RefreshInfo()
    End Sub
    Private Sub umvShiftDate_MouseClick(sender As Object, e As MouseEventArgs) Handles umvShiftDate.MouseClick
        If umvShiftDate.GetDayFromPoint(e.Location) Is Nothing = False Then
            RefreshDataBasedOffTab()
        End If
    End Sub
    Private Sub btnSaveShift_Click(sender As Object, e As EventArgs) Handles btnSaveShift.Click
        UpdateInfo()
    End Sub
    Private Sub btnNonWorkingDay_Click(sender As Object, e As EventArgs) Handles btnNonWorkingDay.Click
        If MsgBox("Are you sure you wish to clear the shift info for this date?", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.Yes Then
            KPGeneral.WebRef_Local.usp_DeleteClampShiftDateInfo(ClampShiftID, KPGeneral.User.UserProfile("UserLoginName"))

            RefreshInfo()
        End If

    End Sub
    Private Sub SaveDailyClampInfo()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetClampShiftInfoByDate(umvShiftDate.CalendarInfo.ActiveDay.Date)

        ClampShiftID = 0

        If ds.Tables(0).Rows.Count > 0 Then
            ClampShiftID = ds.Tables(0).Rows(0)("ClampShiftID")

            InsertClampDetail(chkClamp1, ucClamp1, ClampShiftID, 1)
            InsertClampDetail(chkClamp2, ucClamp2, ClampShiftID, 2)
            InsertClampDetail(chkClamp3, ucClamp3, ClampShiftID, 3)
            InsertClampDetail(chkClamp4, ucClamp4, ClampShiftID, 4)
            InsertClampDetail(chkClamp5, ucClamp5, ClampShiftID, 5)
            InsertClampDetail(chkClamp6, ucClamp6, ClampShiftID, 6)
            InsertClampDetail(chkClamp7, ucClamp7, ClampShiftID, 7)
            InsertClampDetail(chkClamp8, ucClamp8, ClampShiftID, 8)
        End If
    End Sub
    Private Sub InsertClampDetail(ByVal uChk As UltraCheckEditor, ByVal uCombo As UltraCombo, ByVal ClampShiftID As Integer, ByVal ClampNum As Integer)
        If uChk.CheckedValue = True Then
            If uCombo.IsItemInList = True Then
                KPGeneral.WebRef_Local.usp_UpdateClampShiftDetailInfo(ClampShiftID, ClampNum, uCombo.Value, KPGeneral.User.UserProfile("UserLoginName"), False)
            End If
        Else
            KPGeneral.WebRef_Local.usp_UpdateClampShiftDetailInfo(ClampShiftID, ClampNum, 0, KPGeneral.User.UserProfile("UserLoginName"), True)
        End If
    End Sub
    Private Sub LoadPreviousInfo(ByVal ClampShiftID As Integer, ByVal uChk As UltraCheckEditor, ByVal uCombo As UltraCombo, ByVal ClampNum As Integer)
        Dim dsDailyInfo As New DataSet
        dsDailyInfo = KPGeneral.WebRef_Local.usp_GetClampShiftDetailInfoByClampShiftID(ClampShiftID)

        uCombo.Text = ""
        uChk.CheckedValue = False

        Dim x As Integer
        For x = 0 To dsDailyInfo.Tables(0).Rows.Count - 1
            If dsDailyInfo.Tables(0).Rows(x)("ClampNumber") = ClampNum Then
                uChk.CheckedValue = True

                uCombo.Value = dsDailyInfo.Tables(0).Rows(x)("WorkerID")
            End If
        Next
    End Sub
    Private Sub RefreshDataBasedOffTab()
        If UltraTabControl1.ActiveTab.Key = "Daily" Then
            RefreshInfo()
        Else
            RefreshInfoWeekly()
        End If
    End Sub
    Private Sub SetVariableDates()
        Dim SelectedDate As DateTime = umvShiftDate.CalendarInfo.ActiveDay.Date

        Select Case SelectedDate.DayOfWeek
            Case System.DayOfWeek.Monday
                MondayDate = SelectedDate
                TuesdayDate = SelectedDate.AddDays(1)
                WednesdayDate = SelectedDate.AddDays(2)
                ThursdayDate = SelectedDate.AddDays(3)
                FridayDate = SelectedDate.AddDays(4)
                SaturdayDate = SelectedDate.AddDays(5)
            Case System.DayOfWeek.Tuesday
                MondayDate = SelectedDate.AddDays(-1)
                TuesdayDate = SelectedDate
                WednesdayDate = SelectedDate.AddDays(1)
                ThursdayDate = SelectedDate.AddDays(2)
                FridayDate = SelectedDate.AddDays(3)
                SaturdayDate = SelectedDate.AddDays(4)
            Case System.DayOfWeek.Wednesday
                MondayDate = SelectedDate.AddDays(-2)
                TuesdayDate = SelectedDate.AddDays(-1)
                WednesdayDate = SelectedDate
                ThursdayDate = SelectedDate.AddDays(1)
                FridayDate = SelectedDate.AddDays(2)
                SaturdayDate = SelectedDate.AddDays(3)
            Case System.DayOfWeek.Thursday
                MondayDate = SelectedDate.AddDays(-3)
                TuesdayDate = SelectedDate.AddDays(-2)
                WednesdayDate = SelectedDate.AddDays(-1)
                ThursdayDate = SelectedDate
                FridayDate = SelectedDate.AddDays(1)
                SaturdayDate = SelectedDate.AddDays(2)
            Case System.DayOfWeek.Friday
                MondayDate = SelectedDate.AddDays(-4)
                TuesdayDate = SelectedDate.AddDays(-3)
                WednesdayDate = SelectedDate.AddDays(-2)
                ThursdayDate = SelectedDate.AddDays(-1)
                FridayDate = SelectedDate
                SaturdayDate = SelectedDate.AddDays(1)
            Case System.DayOfWeek.Saturday
                MondayDate = SelectedDate.AddDays(-5)
                TuesdayDate = SelectedDate.AddDays(-4)
                WednesdayDate = SelectedDate.AddDays(-3)
                ThursdayDate = SelectedDate.AddDays(-2)
                FridayDate = SelectedDate.AddDays(-1)
                SaturdayDate = SelectedDate
            Case System.DayOfWeek.Sunday
                MondayDate = SelectedDate.AddDays(1)
                TuesdayDate = SelectedDate.AddDays(2)
                WednesdayDate = SelectedDate.AddDays(3)
                ThursdayDate = SelectedDate.AddDays(4)
                FridayDate = SelectedDate.AddDays(5)
                SaturdayDate = SelectedDate.AddDays(6)
        End Select
    End Sub
    Private Sub RefreshInfoWeekly()
        SetVariableDates()

        ucShiftStartWeekly.Text = ""
        ucShiftEndWeekly.Text = ""

        CheckWeeklyDateInfo(MondayDate, chkMonday)
        CheckWeeklyDateInfo(TuesdayDate, chkTuesday)
        CheckWeeklyDateInfo(WednesdayDate, chkWednesday)
        CheckWeeklyDateInfo(ThursdayDate, chkThursday)
        CheckWeeklyDateInfo(FridayDate, chkFriday)

        Dim ShiftStartDateTime As DateTime
        Dim ShiftEndDateTime As DateTime

        If ucShiftStartWeekly.IsItemInList = True Then
            ShiftStartDateTime = ConvertStringToDateTime(ucShiftStartWeekly.Text.Trim)
        Else
            'MsgBox("Please select a value from the Shift Start drop down.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            'Exit Sub
        End If

        If ucShiftEndWeekly.IsItemInList = True Then
            ShiftEndDateTime = ConvertStringToDateTime(ucShiftEndWeekly.Text.Trim)
        Else
            'MsgBox("Please select a value from the Shift End drop down.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            'Exit Sub
        End If

        LoopThroughCheckboxes(ShiftStartDateTime, ShiftEndDateTime, False)
    End Sub
    Private Sub CheckWeeklyDateInfo(ByVal ShiftDate As DateTime, ByVal uChk As UltraCheckEditor)
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetClampShiftInfoByDate(ShiftDate)

        Dim ShiftStart As DateTime

        If ds.Tables(0).Rows.Count > 0 Then
            Dim ConvertedStartDateTimeValue As String = ""
            Dim ConvertedEndDateTimeValue As String = ""

            If IsDBNull(ds.Tables(0).Rows(0)("ShiftStart")) = False Then
                ConvertedStartDateTimeValue = ConvertDateTimeToDropdown(ds.Tables(0).Rows(0)("ShiftStart"))
            End If

            If ucShiftStartWeekly.Text = "" Then
                If ConvertedStartDateTimeValue.Trim.Length > 0 Then
                    CheckDropdowns(ucShiftStartWeekly, ConvertedStartDateTimeValue)
                End If
            End If

            If IsDBNull(ds.Tables(0).Rows(0)("ShiftEnd")) = False Then
                ConvertedEndDateTimeValue = ConvertDateTimeToDropdown(ds.Tables(0).Rows(0)("ShiftEnd"))
            End If

            If ucShiftEndWeekly.Text = "" Then
                If ConvertedEndDateTimeValue.Trim.Length > 0 Then
                    CheckDropdowns(ucShiftEndWeekly, ConvertedEndDateTimeValue)
                End If
            End If

            If ucShiftEndWeekly.Text.ToLower = ConvertedEndDateTimeValue.ToLower And ucShiftStartWeekly.Text.ToLower = ConvertedStartDateTimeValue.ToLower Then
                uChk.CheckedValue = True
            Else
                uChk.CheckedValue = False
            End If
        Else
            uChk.CheckedValue = False
        End If
    End Sub
    Private Sub UpdateShiftDateWeekly(ByVal ShiftDate As DateTime, ByVal ShiftStartDateTime As DateTime, ByVal ShiftEndDateTime As DateTime, ByVal uChk As UltraCheckEditor, ByVal isForced As Boolean)
        If uChk.CheckedValue = True Or isForced = True Then
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.usp_GetClampShiftInfoByDate(ShiftDate)

            ClampShiftID = 0

            If ds.Tables(0).Rows.Count > 0 Then
                ClampShiftID = ds.Tables(0).Rows(0)("ClampShiftID")
            End If

            KPGeneral.WebRef_Local.usp_UpdateClampShiftDateInfo(ClampShiftID, ShiftDate,
                                                        ShiftStartDateTime, ShiftEndDateTime, KPGeneral.User.UserProfile("UserLoginName"))
        End If
    End Sub
    Private Sub btnSaveWeeklyInfo_Click(sender As Object, e As EventArgs) Handles btnSaveWeeklyInfo.Click
        Dim ShiftStartDateTime As DateTime
        Dim ShiftEndDateTime As DateTime

        If ucShiftStartWeekly.IsItemInList = True Then
            ShiftStartDateTime = ConvertStringToDateTime(ucShiftStartWeekly.Text.Trim)
        Else
            MsgBox("Please select a value from the Shift Start drop down.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Exit Sub
        End If

        If ucShiftEndWeekly.IsItemInList = True Then
            ShiftEndDateTime = ConvertStringToDateTime(ucShiftEndWeekly.Text.Trim)
        Else
            MsgBox("Please select a value from the Shift End drop down.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Exit Sub
        End If

        UpdateShiftDateWeekly(MondayDate, ShiftStartDateTime, ShiftEndDateTime, chkMonday, False)
        UpdateShiftDateWeekly(TuesdayDate, ShiftStartDateTime, ShiftEndDateTime, chkTuesday, False)
        UpdateShiftDateWeekly(WednesdayDate, ShiftStartDateTime, ShiftEndDateTime, chkWednesday, False)
        UpdateShiftDateWeekly(ThursdayDate, ShiftStartDateTime, ShiftEndDateTime, chkThursday, False)
        UpdateShiftDateWeekly(FridayDate, ShiftStartDateTime, ShiftEndDateTime, chkFriday, False)
    End Sub
    Private Sub UltraTabControl1_ActiveTabChanged(sender As Object, e As ActiveTabChangedEventArgs) Handles UltraTabControl1.ActiveTabChanged
        RefreshDataBasedOffTab()
    End Sub
    Private Sub btnSaveWeeklyClampInfo_Click(sender As Object, e As EventArgs) Handles btnSaveWeeklyClampInfo.Click
        Dim ShiftStartDateTime As DateTime
        Dim ShiftEndDateTime As DateTime

        If ucShiftStartWeekly.IsItemInList = True Then
            ShiftStartDateTime = ConvertStringToDateTime(ucShiftStartWeekly.Text.Trim)
        Else
            MsgBox("Please select a value from the Shift Start drop down.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Exit Sub
        End If

        If ucShiftEndWeekly.IsItemInList = True Then
            ShiftEndDateTime = ConvertStringToDateTime(ucShiftEndWeekly.Text.Trim)
        Else
            MsgBox("Please select a value from the Shift End drop down.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Exit Sub
        End If

        LoopThroughCheckboxes(ShiftStartDateTime, ShiftEndDateTime, True)

        MsgBox("Weekly clamp info saved.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)

        RefreshInfoWeekly()
    End Sub
    Private Sub LoopThroughCheckboxes(ByVal ShiftStartDateTime As DateTime, ByVal ShiftEndDateTime As DateTime, ByVal isUpdate As Boolean)
        Dim x As Integer
        For x = 0 To Me.Controls.Count - 1
            Dim ControlType As String

            ControlType = Me.Controls.Item(x).ToString

            If ControlType = "Infragistics.Win.UltraWinEditors.UltraCheckEditor" Then
                Dim chkControl As Infragistics.Win.UltraWinEditors.UltraCheckEditor = Me.Controls.Item(x)
                ProcessWeeklyClampCheckboxes(chkControl, ShiftStartDateTime, ShiftEndDateTime, isUpdate)
            ElseIf ControlType = "Infragistics.Win.UltraWinTabControl.UltraTabControl" Then
                Dim SubControlType As String

                Dim z As Integer
                For z = 0 To Me.Controls.Item(x).Controls.Count - 1
                    If Me.Controls.Item(x).Controls.Item(z).ToString.StartsWith("Infragistics.Win.UltraWinTabControl.UltraTabPageControl") Then
                        Dim y As Integer
                        For y = 0 To Me.Controls.Item(x).Controls.Item(z).Controls.Count - 1
                            SubControlType = Me.Controls.Item(x).Controls.Item(z).Controls.Item(y).ToString

                            If SubControlType = "Infragistics.Win.UltraWinEditors.UltraCheckEditor" Then
                                Dim chkSubControl As Infragistics.Win.UltraWinEditors.UltraCheckEditor = Me.Controls.Item(x).Controls.Item(z).Controls.Item(y)
                                ProcessWeeklyClampCheckboxes(chkSubControl, ShiftStartDateTime, ShiftEndDateTime, isUpdate)
                            End If
                        Next
                    End If
                Next

            Else

            End If
        Next
    End Sub
    Private Sub ProcessWeeklyClampCheckboxes(ByVal uChk As UltraCheckEditor, ByVal ShiftStartDateTime As DateTime, ByVal ShiftEndDateTime As DateTime, ByVal isUpdate As Boolean)
        Dim chkName As String = uChk.Name

        If chkName.Contains("_") Then
            Dim ClampNum As Integer = 0

            Dim SelDate As DateTime

            If chkName.ToLower.EndsWith("c1") Then
                ClampNum = 1
            ElseIf chkName.ToLower.EndsWith("c2") Then
                ClampNum = 2
            ElseIf chkName.ToLower.EndsWith("c3") Then
                ClampNum = 3
            ElseIf chkName.ToLower.EndsWith("c4") Then
                ClampNum = 4
            ElseIf chkName.ToLower.EndsWith("c5") Then
                ClampNum = 5
            ElseIf chkName.ToLower.EndsWith("c6") Then
                ClampNum = 6
            ElseIf chkName.ToLower.EndsWith("c7") Then
                ClampNum = 7
            ElseIf chkName.ToLower.EndsWith("c8") Then
                ClampNum = 8
            End If

            If chkName.ToLower.StartsWith("chkmonday_c") Then
                SelDate = MondayDate
            ElseIf chkName.ToLower.StartsWith("chktuesday_c") Then
                SelDate = TuesdayDate
            ElseIf chkName.ToLower.StartsWith("chkwednesday_c") Then
                SelDate = WednesdayDate
            ElseIf chkName.ToLower.StartsWith("chkthursday_c") Then
                SelDate = ThursdayDate
            ElseIf chkName.ToLower.StartsWith("chkfriday_c") Then
                SelDate = FridayDate
            End If

            ClampShiftID = 0

            ClampShiftID = CheckClampShiftID(SelDate)

            If isUpdate = True Then
                If ClampShiftID = 0 Then
                    UpdateShiftDateWeekly(SelDate, ShiftStartDateTime, ShiftEndDateTime, uChk, True)
                End If

                ClampShiftID = CheckClampShiftID(SelDate)

                If ClampShiftID > 0 Then
                    KPGeneral.WebRef_Local.usp_UpdateClampShiftWeeklyDetailInfo(ClampShiftID, ClampNum, KPGeneral.User.UserProfile("UserLoginName"), uChk.CheckedValue)
                End If
            Else
                Dim dsDailyInfo As New DataSet
                dsDailyInfo = KPGeneral.WebRef_Local.usp_GetClampShiftWeeklyInfoByClampShiftIDAndClampNum(ClampShiftID, ClampNum)

                If dsDailyInfo.Tables(0).Rows.Count > 0 Then
                    uChk.CheckedValue = True
                Else
                    uChk.CheckedValue = False
                End If
            End If

        End If


    End Sub
    Function CheckClampShiftID(ByVal SelDate As DateTime) As Integer
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetClampShiftInfoByDate(SelDate)

        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0)("ClampShiftID")
        End If

        Return 0
    End Function
End Class