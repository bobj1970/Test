Imports Infragistics.Win.UltraWinGrid

Public Class frmManageAssemblersAndClamps

    Private MondayDate As DateTime
    Private TuesdayDate As DateTime
    Private WednesdayDate As DateTime
    Private ThursdayDate As DateTime
    Private FridayDate As DateTime
    Private SaturdayDate As DateTime
    Private SelectedDate As Date
    Private BeginMondayDate As Date

    Private Sub frmManageAssemblersAndClamps_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.SelectedDate = Now.Date
        KPGeneral.SetDefaultGridSettings(Me.ugAllSchedule)
        KPGeneral.SetDefaultGridSettings(Me.ugAssemblerList)
        KPGeneral.SetGridRowFilterSettings(Me.ugAssemblerList)
        KPGeneral.SetGridRowFilterSettings(Me.ugPickers)
        RefreshWorkerList()
        Me.cbDefaultClampNumber.DataSource = KPGeneral.KPDataSQL.SP_EXEC("t_GetClamps")
        Me.cbDefaultClampNumber.DisplayMember = "ClampName"
        Me.cbDefaultClampNumber.ValueMember = "ClampID"
        Me.cbDefaultClampNumber.DisplayLayout.Bands(0).Columns("ClampName").Width = Me.cbDefaultClampNumber.Width
        Me.cbDefaultClampNumber.DisplayLayout.Bands(0).Columns("ClampID").Hidden = True
        Me.cbDefaultClampNumber.DisplayLayout.Bands(0).ColHeadersVisible = False
        Dim dt As DataTable = KPGeneral.KPDataSQL.SP_EXEC("t_ShiftTime", True).Tables(0)
        Me.LoadShiftTimeCombos(Me.cbTimeStart, dt)
        dt = KPGeneral.KPDataSQL.SP_EXEC("t_ShiftTime", False).Tables(0)
        Me.LoadShiftTimeCombos(Me.cbTimeEnd, dt)
        dt = KPGeneral.KPDataSQL.SP_EXEC("t_GetActiveAssemblers").Tables(0)
        Me.LoadAssemblerCombos(Me.cbAssembler, dt)
        Me.RefreshIndivisualSchedule()
        Me.BeginMondayDate = Me.MondayDate
        Me.RefreshAssemblerPerformance()

    End Sub

    Private Sub btnAddWorker_Click(sender As Object, e As EventArgs) Handles btnAddWorker.Click

        Dim temp As New frmAddNewAssembler
        If temp.ShowDialog = DialogResult.OK Then
            Me.RefreshAllTabs()
        End If

    End Sub

    Private Sub btnUpdateWorker_Click(sender As Object, e As EventArgs) Handles btnUpdateWorker.Click

        Dim assemblerID As String = Me.ugAssemblerList.ActiveRow.Cells("AssemblerID").Text
        Dim validateText As String = Me.VerifyTextBoxes(assemblerID)
        If validateText = "valid" Then
            KPGeneral.KPDataSQL.SP_EXEC("t_UpdateAssembler",
                                        assemblerID,
                                        Me.tbEmpRef.Value,
                                        Me.tbPassword.Value,
                                        Me.tbStationName.Text.Trim,
                                        Me.cbDefaultClampNumber.Value,
                                        IIf(Me.tbAvgPerformance.Text = "", DBNull.Value, Me.tbAvgPerformance.Text),
                                        IIf(Me.tbTargetPercentage.Text = "", DBNull.Value, Me.tbTargetPercentage.Text))
            Me.RefreshAllTabs()
        Else
            MsgBox(validateText, MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If

    End Sub

    Private Sub ReactivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReactivateToolStripMenuItem.Click

        If Me.ugAssemblerList.ActiveRow IsNot Nothing AndAlso Me.ugAssemblerList.ActiveRow.Index > -1 Then
            KPGeneral.KPDataSQL.SP_EXEC("t_UpdateAssemblerActive",
                                        Me.ugAssemblerList.ActiveRow.Cells("AssemblerID").Value,
                                        Not Me.ugAssemblerList.ActiveRow.Cells("IsActive").Value)
            Me.RefreshAllTabs()
        Else
            MsgBox("Please select a row.")
        End If

    End Sub

    Private Sub ColumnChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem.Click
        KPGeneral.ColumnChooser(Me.ugAssemblerList, Me.GetType.Name)
    End Sub

    Private Sub RefreshWorkerList()

        Me.ugAssemblerList.DataSource = KPGeneral.KPDataSQL.SP_EXEC("t_GetAllAssemblers")
        KPGeneral.RefreshGridFromLayout(Me.ugAssemblerList, Me.GetType.Name)
        Me.ugAssemblerList.DisplayLayout.Bands(0).Columns("StationName").Width = 200
        Me.ugPickers.DataSource = KPGeneral.KPDataSQL.SP_EXEC("t_GetAllPickers")
        Me.ugPickers.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn

    End Sub

    Private Sub ugAssemblerList_AfterRowActivate(sender As Object, e As EventArgs) Handles ugAssemblerList.AfterRowActivate

        If Me.ugAssemblerList.ActiveRow.Index > -1 Then
            tbStationName.Text = Me.ugAssemblerList.ActiveRow.Cells("StationName").Text
            tbEmpRef.Text = Me.ugAssemblerList.ActiveRow.Cells("EmpRef").Text
            Me.cbDefaultClampNumber.Value = Me.ugAssemblerList.ActiveRow.Cells("DefaultClamp").Value
            Me.tbPassword.Text = Me.ugAssemblerList.ActiveRow.Cells("Password").Text
            If IsDBNull(Me.ugAssemblerList.ActiveRow.Cells("AverageDailyPerformance").Value) = False Then
                tbAvgPerformance.Text = Me.ugAssemblerList.ActiveRow.Cells("AverageDailyPerformance").Text
            Else
                tbAvgPerformance.Text = ""
            End If
            If IsDBNull(Me.ugAssemblerList.ActiveRow.Cells("TargetPercentage").Value) = False Then
                tbTargetPercentage.Text = Me.ugAssemblerList.ActiveRow.Cells("TargetPercentage").Text
            Else
                tbTargetPercentage.Text = ""
            End If
            If Me.ugAssemblerList.ActiveRow.Cells("IsActive").Value Then
                Me.ReactivateToolStripMenuItem.Text = "Unactive"
            Else
                Me.ReactivateToolStripMenuItem.Text = "Reactive"
            End If
            If Me.ugAssemblerList.ActiveRow.Cells("IncludeInPerformanceData").Value Then
                Me.IncludeInPerformanceDataToolStripMenuItem.Text = "Exclude In Performance Data"
            Else
                Me.IncludeInPerformanceDataToolStripMenuItem.Text = "Include In Performance Data"
            End If
        End If

    End Sub

    Private Sub RefreshAllTabs()

        Me.RefreshWorkerList()
        Me.RefreshIndivisualSchedule()
        Me.RefreshAssemblerPerformance()
        Me.LoadAssemblerCombos(Me.cbAssembler, KPGeneral.KPDataSQL.SP_EXEC("t_GetActiveAssemblers").Tables(0))

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

    Private Function VerifyTextBoxes(ByVal WorkerID As String) As String

        If Me.tbStationName.Text.Trim.Length = 0 Then
            Return "You must enter a valid station name."
        End If
        Dim stationName As String = Me.tbStationName.Text.Trim.ToLower()
        For i As Int16 = 0 To Me.ugAssemblerList.Rows.Count - 1
            If Me.ugAssemblerList.Rows(i).Cells("StationName").Text.Trim.ToLower() = stationName AndAlso WorkerID <> Me.ugAssemblerList.Rows(i).Cells("AssemblerID").Text Then
                Return "This station name already exists. Please update the original."
            End If
        Next
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

    Private Sub LoadShiftTimeCombos(ByRef uCombo As Infragistics.Win.UltraWinGrid.UltraCombo, ByVal dt As DataTable)

        uCombo.DataSource = dt
        uCombo.DisplayMember = "ShiftTime"
        uCombo.ValueMember = "ShiftTime"
        uCombo.DisplayLayout.Bands(0).Columns("ShiftTimeID").Hidden = True
        uCombo.DisplayLayout.Bands(0).Columns("ShiftTime").Width = uCombo.Width
        uCombo.DisplayLayout.Bands(0).ColHeadersVisible = False

    End Sub

    Private Sub LoadAssemblerCombos(ByRef uCombo As Infragistics.Win.UltraWinGrid.UltraCombo, ByVal dt As DataTable)

        uCombo.DataSource = dt
        uCombo.DisplayMember = "StationName"
        uCombo.ValueMember = "AssemblerID"
        uCombo.DisplayLayout.Bands(0).Columns("AssemblerID").Hidden = True
        uCombo.DisplayLayout.Bands(0).Columns("StationName").Width = uCombo.Width

    End Sub

    Private Sub RefreshIndivisualSchedule()

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
        Dim dt As DataTable = KPGeneral.KPDataSQL.SP_EXEC("t_GetClamps").Tables(0)
        dt.Columns.Add("Monday", Type.GetType("System.String"))
        dt.Columns.Add("Tuesday", Type.GetType("System.String"))
        dt.Columns.Add("Wednesday", Type.GetType("System.String"))
        dt.Columns.Add("Thursday", Type.GetType("System.String"))
        dt.Columns.Add("Friday", Type.GetType("System.String"))
        dt.Columns.Add("Saturday", Type.GetType("System.String"))
        'KPGeneral.WebRef_Local.GetTable("SELECT ClampID, ClampName, '' AS Monday, '' AS Tuesday, '' AS Wednesday, '' AS Thursday, '' AS Friday,'' AS Saturday FROM Clamps", "Clamp")

        For Each dr As DataRow In dt.Rows
            Dim dtTemp As DataTable = KPGeneral.KPDataSQL.SP_EXEC("t_GetClampScheduleByDate", dr("ClampID"), Me.MondayDate, Me.SaturdayDate).Tables(0)
            'KPGeneral.WebRef_Local.GetTable("Select S.ScheduleDate,S.StartTime,S.EndTime,A.StationName,A.EmpRef FROM ClampDailySchedule S " _
            '                                                & "LEFT JOIN Assemblers A On S.AssemblerID=A.AssemblerID " _
            '                                                & "WHERE (IncludeInPerformanceData=1 OR S.AssemblerID IS NULL) AND IsDeleted=0 AND ScheduleDate>=CONVERT(DATE,'" & Me.MondayDate & "') AND " _
            '                                                & "ScheduleDate<=CONVERT(DATE,'" & Me.SaturdayDate & "') AND S.ClampID=" & dr("ClampID").ToString _
            '                                                & " ORDER BY ScheduleDate", "AllSchedule")
            For Each drTemp As DataRow In dtTemp.Rows
                Dim empShift As DataTable = KPGeneral.KPDataSQL.SP_EXEC("usp_GetEmployeeTimeCardByDate", drTemp("EmpRef").ToString, drTemp("ScheduleDate").ToString).Tables(0)
                Dim checkInString As String = ""
                If empShift.Rows.Count > 0 AndAlso empShift.Rows(0)("ClockIN") IsNot DBNull.Value AndAlso empShift.Rows(0)("ClockOUT") IsNot DBNull.Value Then
                    checkInString = CType(empShift.Rows(0)("ClockIN"), DateTime).ToLongTimeString & " - " & CType(empShift.Rows(0)("ClockOUT"), DateTime).ToLongTimeString
                End If
                Dim d As String = CType(drTemp("ScheduleDate"), Date).DayOfWeek.ToString
                dr(d) = drTemp("StartTime").ToString & " - " & drTemp("EndTime") & IIf(drTemp("AfternoonBreak"), " [AB]", "") _
                        & vbNewLine & vbNewLine & checkInString.ToLower & vbNewLine & vbNewLine & drTemp("StationName").ToString
            Next
        Next
        Me.ugAllSchedule.DataSource = dt
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Monday").Width = 190
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Tuesday").Width = 190
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Wednesday").Width = 190
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Thursday").Width = 190
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Friday").Width = 190
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Saturday").Width = 190
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("ClampID").Hidden = True
        Me.ugAllSchedule.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Monday").Header.Caption = "Monday " & Me.MondayDate.ToShortDateString()
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Tuesday").Header.Caption = "Tuesday " & Me.TuesdayDate.ToShortDateString()
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Wednesday").Header.Caption = "Wednesday " & Me.WednesdayDate.ToShortDateString()
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Thursday").Header.Caption = "Thursday " & Me.ThursdayDate.ToShortDateString()
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Friday").Header.Caption = "Friday " & Me.FridayDate.ToShortDateString()
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("Saturday").Header.Caption = "Saturday " & Me.SaturdayDate.ToShortDateString()
        Me.ugAllSchedule.DisplayLayout.Bands(0).Columns("ClampName").Header.Caption = "Clamp"
        Me.ugAllSchedule.ActiveRow = Nothing
        Me.cbAssembler.Text = ""
        Me.cbTimeStart.Text = ""
        Me.cbTimeEnd.Text = ""
        Me.chWeekly.Checked = False
        Me.chAfternoonBreak.Checked = False

    End Sub

    Private Sub btUpdate_Click(sender As Object, e As EventArgs) Handles btUpdate.Click

        If Me.ugAllSchedule.ActiveCell Is Nothing Then
            MsgBox("Please select a day.")
            Exit Sub
        End If
        Dim temp As String = Me.ugAllSchedule.ActiveCell.Column.Header.Caption.Trim
        Dim selecteDate As Date = CType(temp.Substring(temp.IndexOf(" ")).Trim, Date)
        Dim clampID As String = Me.ugAllSchedule.ActiveRow.Cells("ClampID").Value
        Dim assemblerID As String
        Dim startTime As String = Me.cbTimeStart.Value
        Dim endTime As String = Me.cbTimeEnd.Value
        If CType(Today.ToShortDateString & " " & startTime, DateTime) >= CType(Today.ToShortDateString & " " & endTime, DateTime) Then
            MsgBox("End time can't be early than start time.")
            Exit Sub
        End If
        startTime = startTime.Substring(0, startTime.Length - 3)
        endTime = endTime.Substring(0, endTime.Length - 3)
        Dim index As Int16 = startTime.IndexOf(":")
        Dim startH As Int16 = CType(startTime.Substring(0, index), Int16)
        Dim startM As Int16 = CType(startTime.Substring(index + 1), Int16)
        index = endTime.IndexOf(":")
        Dim endH As Int16 = CType(endTime.Substring(0, index), Int16)
        Dim endM As Int16 = CType(endTime.Substring(index + 1), Int16)
        Dim lunch As Int16 = 30
        If endH < 6 Then
            endH = endH + 12
        Else
            lunch = 0
        End If
        Dim workingInMinutes As Int32 = (endH - startH) * 60 + endM - startM - lunch
        'If (endH - startH) * 60 + endM - startM > 540 Then
        '    workingInMinutes = workingInMinutes - 30
        'Else
        If (endH > 9 OrElse (endH = 9 AndAlso endM > 15)) AndAlso (startH < 9 OrElse (startH = 9 AndAlso startM < 15)) Then
            workingInMinutes = workingInMinutes - 15
        End If
        'End If
        If Me.chAfternoonBreak.Checked Then
            workingInMinutes = workingInMinutes - 15
        End If
        If Me.cbAssembler.Text = "" Then
            assemblerID = "NULL"
        Else
            assemblerID = Me.cbAssembler.Value
        End If
        Dim afternoonBreak As Int16 = IIf(Me.chAfternoonBreak.Checked, 1, 0)
        If Me.ValidateIndivisualSchedule(selecteDate, clampID) Then
            If Me.chWeekly.Checked Then
                'Dim sqlstatements(6) As String
                'sqlstatements(0) = "UPDATE ClampDailySchedule SET IsDeleted=1,ModifiedOn=GETDATE(),ModifiedBy='" & KPGeneral.User.UserProfile("UserLoginName") & "' WHERE ClampID=" & clampID _
                '                                      & " AND IsDeleted=0 AND ScheduleDate>=CONVERT(DATE,'" & Me.MondayDate & "') AND ScheduleDate<=CONVERT(DATE,'" & Me.FridayDate & "')"
                'sqlstatements(1) = "INSERT INTO ClampDailySchedule(ScheduleDate,StartTime,EndTime,ClampID,AssemblerID,ModifiedBy,ModifiedOn,IsDeleted,WorkingMinutes,AfternoonBreak)" _
                '                & " VALUES(CONVERT(DATE,'" & Me.MondayDate & "'),'" & Me.cbTimeStart.Value & "','" & Me.cbTimeEnd.Value & "'," & clampID & "," _
                '                & assemblerID & ",'" & KPGeneral.User.UserProfile("UserLoginName") & "',GETDATE(),0," & workingInMinutes & "," & afternoonBreak & ")"

                'sqlstatements(2) = "INSERT INTO ClampDailySchedule VALUES(CONVERT(DATE,'" & Me.TuesdayDate & "'),'" & Me.cbTimeStart.Value & "','" & Me.cbTimeEnd.Value & "'," _
                '                & clampID & "," & assemblerID & ",'" & KPGeneral.User.UserProfile("UserLoginName") & "',GETDATE(),0," & workingInMinutes & "," & afternoonBreak & ")"
                'sqlstatements(3) = "INSERT INTO ClampDailySchedule VALUES(CONVERT(DATE,'" & Me.WednesdayDate & "'),'" & Me.cbTimeStart.Value & "','" & Me.cbTimeEnd.Value & "'," _
                '                & clampID & "," & assemblerID & ",'" & KPGeneral.User.UserProfile("UserLoginName") & "',GETDATE(),0," & workingInMinutes & "," & afternoonBreak & ")"
                'sqlstatements(4) = "INSERT INTO ClampDailySchedule VALUES(CONVERT(DATE,'" & Me.ThursdayDate & "'),'" & Me.cbTimeStart.Value & "','" & Me.cbTimeEnd.Value & "'," _
                '                & clampID & "," & assemblerID & ",'" & KPGeneral.User.UserProfile("UserLoginName") & "',GETDATE(),0," & workingInMinutes & "," & afternoonBreak & ")"
                'sqlstatements(5) = "INSERT INTO ClampDailySchedule VALUES(CONVERT(DATE,'" & Me.FridayDate & "'),'" & Me.cbTimeStart.Value & "','" & Me.cbTimeEnd.Value & "'," _
                '                & clampID & "," & assemblerID & ",'" & KPGeneral.User.UserProfile("UserLoginName") & "',GETDATE(),0," & workingInMinutes & "," & afternoonBreak & ")"
                'sqlstatements(6) = "INSERT INTO ClampDailySchedule VALUES(CONVERT(DATE,'" & Me.SaturdayDate & "'),'" & Me.cbTimeStart.Value & "','" & Me.cbTimeEnd.Value & "'," _
                '                & clampID & "," & assemblerID & ",'" & KPGeneral.User.UserProfile("UserLoginName") & "',GETDATE(),0," & workingInMinutes & "," & afternoonBreak & ")"
                'KPGeneral.WebRef_Local.ExcuteSqlStatements(sqlstatements)
                KPGeneral.KPDataSQL.SP_EXEC("t_UpdateAssemblerSchedule",
                                            Me.MondayDate,
                                            Me.cbTimeStart.Value,
                                            Me.cbTimeEnd.Value,
                                            clampID,
                                            assemblerID,
                                            KPGeneral.User.UserProfile("UserLoginName"),
                                            0,
                                            workingInMinutes,
                                            afternoonBreak,
                                            1)
            Else
                'Dim sqlstatements(1) As String
                'sqlstatements(0) = "UPDATE ClampDailySchedule SET IsDeleted=1,ModifiedOn=GETDATE(),ModifiedBy='" & KPGeneral.User.UserProfile("UserLoginName") _
                '                                      & "' WHERE ScheduleDate=CONVERT(DATE,'" & selecteDate & "') AND ClampID=" & clampID & " AND IsDeleted=0"
                'sqlstatements(1) = "INSERT INTO ClampDailySchedule VALUES(CONVERT(DATE,'" & selecteDate & "'),'" & Me.cbTimeStart.Value & "','" & Me.cbTimeEnd.Value & "'," _
                '                & clampID & "," & assemblerID & ",'" & KPGeneral.User.UserProfile("UserLoginName") & "',GETDATE(),0," & workingInMinutes & "," & afternoonBreak & ")"
                'KPGeneral.WebRef_Local.ExcuteSqlStatements(sqlstatements)
                KPGeneral.KPDataSQL.SP_EXEC("t_UpdateAssemblerSchedule",
                                            selecteDate,
                                            Me.cbTimeStart.Value,
                                            Me.cbTimeEnd.Value,
                                            clampID,
                                            assemblerID,
                                            KPGeneral.User.UserProfile("UserLoginName"),
                                            0,
                                            workingInMinutes,
                                            afternoonBreak,
                                            0)
            End If
            Me.RefreshIndivisualSchedule()
        Else
            MsgBox(Me.cbAssembler.Text & " was already assigned to another clamp on same date. Please select another station.")
        End If

    End Sub

    Private Function ValidateIndivisualSchedule(ByVal scheduleDate As Date, ByVal clampID As String) As Boolean

        If Not Me.cbTimeStart.IsItemInList Then
            MsgBox("Please select a valid start time.")
            Return False
        End If
        If Not Me.cbTimeEnd.IsItemInList Then
            MsgBox("Please select a valid end time.")
            Return False
        End If
        If Me.cbAssembler.Text <> "" AndAlso Not Me.cbAssembler.IsItemInList Then
            MsgBox("Please select a valid station for clamp or leave it empty.")
            Return False
        ElseIf Me.cbAssembler.IsItemInList Then
            'Dim sql As String
            'If Me.chWeekly.Checked Then
            '    sql = "SELECT * FROM ClampDailySchedule WHERE ClampID<>" & clampID & " AND ScheduleDate>=CONVERT(DATE,'" & Me.MondayDate & "') AND ScheduleDate<=CONVERT(DATE,'" _
            '          & Me.SaturdayDate & "') AND IsDeleted=0 AND AssemblerID=" & Me.cbAssembler.Value
            'Else
            '    sql = "SELECT * FROM ClampDailySchedule WHERE ClampID<>" & clampID & " AND ScheduleDate=CONVERT(DATE,'" & scheduleDate & "') AND " & "IsDeleted=0 AND AssemblerID=" & Me.cbAssembler.Value
            'End If
            'If KPGeneral.WebRef_Local.GetTable(sql, "Schedule").Rows.Count > 0 Then
            '    MsgBox(Me.cbAssembler.Text & " was already assigned to another clamp on same date. Please select another station.")
            '    Return False
            'End If
            Dim startDate As Date = scheduleDate
            Dim endDate As Date = scheduleDate
            If Me.chWeekly.Checked Then
                startDate = Me.MondayDate
                endDate = Me.SaturdayDate
            End If
            Return KPGeneral.KPDataSQL.SP_EXEC("t_IsAssemblerAssignToOtherClamp", clampID, Me.cbAssembler.Value, startDate, endDate).Tables(0).Rows(0)(0) = 0
        End If
        Return True

    End Function

    Private Sub btPreviousWeek_Click(sender As Object, e As EventArgs) Handles btPreviousWeek.Click

        Me.SelectedDate = Me.SelectedDate.AddDays(-7)
        Me.RefreshIndivisualSchedule()

    End Sub

    Private Sub btNextWeek_Click(sender As Object, e As EventArgs) Handles btNextWeek.Click

        Me.SelectedDate = Me.SelectedDate.AddDays(7)
        Me.RefreshIndivisualSchedule()

    End Sub

    Private Sub ugAllSchedule_AfterCellActivate(sender As Object, e As EventArgs) Handles ugAllSchedule.AfterCellActivate

        If Me.ugAllSchedule.ActiveCell.IsDataCell AndAlso Me.ugAllSchedule.ActiveCell.Column.Key <> "ClampName" Then
            Dim temp As String = Me.ugAllSchedule.ActiveCell.Column.Header.Caption.Trim
            'Dim selecteDate As Date = CType(temp.Substring(temp.IndexOf(" ")).Trim, Date)
            Dim v As String = Me.ugAllSchedule.ActiveCell.Value.ToString.Trim
            If v = "" Then
                Me.cbAssembler.Text = ""
                Me.cbTimeStart.Text = ""
                Me.cbTimeEnd.Text = ""
                Me.chWeekly.Checked = False
                Me.chAfternoonBreak.Checked = False
            Else
                Dim contain As String() = v.Split(vbNewLine)
                Dim fromTime As String = contain(0).Split("-")(0).Trim 'v.Substring(0, v.IndexOf("am") + 2).Trim
                Dim endTime As String = contain(0).Split("-")(1).Trim 'v.Substring(v.IndexOf("-") + 1, (v.IndexOf("pm") - v.IndexOf("-") + 1)).Trim
                If endTime.Contains("[AB]") Then
                    endTime = endTime.Substring(0, endTime.Length - 4).Trim
                End If
                'If v.Length >= v.LastIndexOf("pm") + 2 Then
                '    Me.cbAssembler.Text = v.Substring(v.LastIndexOf("pm") + 2).Trim
                'Else
                '    Me.cbAssembler.Text = ""
                'End If
                Me.cbAssembler.Text = contain(contain.Length - 1).Trim
                Me.cbTimeStart.Text = fromTime
                Me.cbTimeEnd.Text = endTime
                Dim row As UltraGridRow = Me.ugAllSchedule.ActiveRow
                If row.Cells("Monday").Text = row.Cells("Tuesday").Text AndAlso row.Cells("Monday").Text = row.Cells("Wednesday").Text _
                    AndAlso row.Cells("Monday").Text = row.Cells("Thursday").Text AndAlso row.Cells("Monday").Text = row.Cells("Friday").Text Then
                    Me.chWeekly.Checked = True
                Else
                    Me.chWeekly.Checked = False
                End If
                Dim selecteDate As Date = CType(temp.Substring(temp.IndexOf(" ")).Trim, Date)
                Dim clampID As String = Me.ugAllSchedule.ActiveRow.Cells("ClampID").Value
                Dim dt As DataTable = KPGeneral.KPDataSQL.SP_EXEC("t_GetAssemblerAfternoonBreak", selecteDate, clampID).Tables(0)
                If dt.Rows.Count = 0 Then
                    Me.chAfternoonBreak.Checked = False
                Else
                    Me.chAfternoonBreak.Checked = dt.Rows(0)(0)
                End If
            End If
        Else
            Me.cbAssembler.Text = ""
            Me.cbTimeStart.Text = ""
            Me.cbTimeEnd.Text = ""
            Me.chWeekly.Checked = False
            Me.chAfternoonBreak.Checked = False
        End If

    End Sub

    Private Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click

        Dim clampID As String = Me.ugAllSchedule.ActiveRow.Cells("ClampID").Value
        Dim temp As String = Me.ugAllSchedule.ActiveCell.Column.Header.Caption.Trim
        Dim selecteDate As Date = CType(temp.Substring(temp.IndexOf(" ")).Trim, Date)
        KPGeneral.WebRef_Local.ExcuteSqlStatement("UPDATE ClampDailySchedule SET IsDeleted=1,ModifiedOn=GETDATE(),ModifiedBy='" & KPGeneral.User.UserProfile("UserLoginName") _
                                                  & "' WHERE IsDeleted=0 AND ClampID=" & clampID & " AND ScheduleDate=CONVERT(DATE,'" & selecteDate & "')")

        Me.RefreshIndivisualSchedule()

    End Sub

    Private Sub btPrevious_Click(sender As Object, e As EventArgs) Handles btPrevious.Click

        Me.BeginMondayDate = Me.BeginMondayDate.AddDays(-7)
        Me.RefreshAssemblerPerformance()

    End Sub

    Private Sub btNext_Click(sender As Object, e As EventArgs) Handles btNext.Click

        Me.BeginMondayDate = Me.BeginMondayDate.AddDays(7)
        Me.RefreshAssemblerPerformance()

    End Sub

    Private Sub RefreshAssemblerPerformance()

        Me.lbFromDate.Text = "From: " & Me.BeginMondayDate.ToShortDateString
        Me.lbToDate.Text = "To: " & Me.BeginMondayDate.AddDays(11).ToShortDateString
        Dim sql As String = "SELECT DISTINCT EmpRef,StationName,'' AS Total,'' AS Monday,'' AS Tuesday,'' AS Wednesday,'' AS Thursday,'' AS Friday,'' AS Saturday,'' AS Monday2,'' AS Tuesday2, " _
                            & "'' AS Wednesday2,'' AS Thursday2,'' AS Friday2,'' AS Saturday2,AssemblerID FROM Assemblers INNER JOIN tblCabinetLabel ON EmpRef=ScanUser WHERE ScanDate>=CONVERT(DATE,'" _
                            & Me.BeginMondayDate & "') AND ScanDate<=CONVERT(DATE,'" & Me.BeginMondayDate.AddDays(12) & "') AND IncludeInPerformanceData=1 ORDER BY StationName"
        Dim dt As DataTable = KPGeneral.WebRef_Local.GetTable(sql, "Assembler")
        Dim drTotal As DataRow = dt.NewRow
        drTotal("StationName") = "Total"
        dt.Rows.Add(drTotal)
        Dim tTotalP As Int32 = 0
        Dim tMonP As Int32 = 0
        Dim tTueP As Int32 = 0
        Dim tWedP As Int32 = 0
        Dim tThuP As Int32 = 0
        Dim tFriP As Int32 = 0
        Dim tSatP As Int32 = 0
        Dim tMon2P As Int32 = 0
        Dim tTue2P As Int32 = 0
        Dim tWed2P As Int32 = 0
        Dim tThu2P As Int32 = 0
        Dim tFri2P As Int32 = 0
        Dim tSat2P As Int32 = 0
        Dim tTotalW As Int32 = 0
        Dim tMonW As Int32 = 0
        Dim tTueW As Int32 = 0
        Dim tWedW As Int32 = 0
        Dim tThuW As Int32 = 0
        Dim tFriW As Int32 = 0
        Dim tSatW As Int32 = 0
        Dim tMon2W As Int32 = 0
        Dim tTue2W As Int32 = 0
        Dim tWed2W As Int32 = 0
        Dim tThu2W As Int32 = 0
        Dim tFri2W As Int32 = 0
        Dim tSat2W As Int32 = 0
        Dim tTotalC As Int32 = 0
        Dim tMonC As Int32 = 0
        Dim tTueC As Int32 = 0
        Dim tWedC As Int32 = 0
        Dim tThuC As Int32 = 0
        Dim tFriC As Int32 = 0
        Dim tSatC As Int32 = 0
        Dim tMon2C As Int32 = 0
        Dim tTue2C As Int32 = 0
        Dim tWed2C As Int32 = 0
        Dim tThu2C As Int32 = 0
        Dim tFri2C As Int32 = 0
        Dim tSat2C As Int32 = 0
        For Each dr As DataRow In dt.Rows
            Dim totalW As Int32 = 0
            Dim totalC As Int32 = 0
            Dim totalP As Int32 = 0
            Dim dtTemp As DataTable = KPGeneral.WebRef_Local.GetTable("Select CONVERT(Date,ScanDate) AS ScanDate,ScanUser,ISNULL(SUM(AssemblyPlannedTime),0) AS 'TotalPlanTime',COUNT(ScanUser) AS 'TotalCabinet' " _
                                                                & "FROM tblCabinetLabel WHERE ScanUser='" & dr("EmpRef").ToString & "' AND ScanDate>=CONVERT(DATE,'" _
                                                                & Me.BeginMondayDate & "') AND ScanDate<CONVERT(DATE,'" & Me.BeginMondayDate.AddDays(12) & "') GROUP BY CONVERT(Date,ScanDate)," _
                                                                & "ScanUser", "Performance")
            For Each drTemp As DataRow In dtTemp.Rows
                Dim workingMinutes As Int32 = Me.GetWorkingMinutes(dr("AssemblerID").ToString, drTemp("ScanDate").ToString)
                Dim d As String = CType(drTemp("ScanDate"), Date).DayOfWeek.ToString
                If d <> "Sunday" Then
                    If CType(drTemp("ScanDate"), Date) >= Me.BeginMondayDate.AddDays(7) Then
                        d = d & "2"
                    End If
                    Dim totalPlanTime As Double = CType(drTemp("TotalPlanTime").ToString, Double)
                    totalP += Convert.ToInt32(totalPlanTime)
                    totalW += workingMinutes
                    totalC += CType(drTemp("TotalCabinet"), Int32)
                    If workingMinutes = 0 Then
                        dr(d) = "0%" & vbNewLine & drTemp("TotalCabinet") & vbNewLine & Convert.ToInt32(totalPlanTime)
                    Else
                        dr(d) = Convert.ToInt32(totalPlanTime / workingMinutes * 100) & "%" & vbNewLine & drTemp("TotalCabinet") & vbNewLine & Convert.ToInt32(totalPlanTime)
                    End If
                    Select Case d
                        Case "Monday2"
                            tMon2C += CType(drTemp("TotalCabinet"), Int32)
                            tMon2P += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tMon2W += workingMinutes
                        Case "Monday"
                            tMonC += CType(drTemp("TotalCabinet"), Int32)
                            tMonP += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tMonW += workingMinutes
                        Case "Tuesday2"
                            tTue2C += CType(drTemp("TotalCabinet"), Int32)
                            tTue2P += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tTue2W += workingMinutes
                        Case "Tuesday"
                            tTueC += CType(drTemp("TotalCabinet"), Int32)
                            tTueP += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tTueW += workingMinutes
                        Case "Wednesday2"
                            tWed2C += CType(drTemp("TotalCabinet"), Int32)
                            tWed2P += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tWed2W += workingMinutes
                        Case "Wednesday"
                            tWedC += CType(drTemp("TotalCabinet"), Int32)
                            tWedP += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tWedW += workingMinutes
                        Case "Thursday2"
                            tThu2C += CType(drTemp("TotalCabinet"), Int32)
                            tThu2P += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tThu2W += workingMinutes
                        Case "Thursday"
                            tThuC += CType(drTemp("TotalCabinet"), Int32)
                            tThuP += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tThuW += workingMinutes
                        Case "Friday2"
                            tFri2C += CType(drTemp("TotalCabinet"), Int32)
                            tFri2P += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tFri2W += workingMinutes
                        Case "Friday"
                            tFriC += CType(drTemp("TotalCabinet"), Int32)
                            tFriP += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tFriW += workingMinutes
                        Case "Saturday2"
                            tSat2C += CType(drTemp("TotalCabinet"), Int32)
                            tSat2P += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tSat2W += workingMinutes
                        Case "Saturday"
                            tSatC += CType(drTemp("TotalCabinet"), Int32)
                            tSatP += Convert.ToInt32(CType(drTemp("TotalPlanTime").ToString, Double))
                            tSatW += workingMinutes
                    End Select
                End If
            Next
            If totalW = 0 Then
                dr("Total") = "Total PP: 0%" & vbNewLine & "Total TC: " & totalC & vbNewLine & "Total APT: " & totalP
            Else
                dr("Total") = "Total PP: " & Convert.ToInt32(totalP / totalW * 100) & "%" & vbNewLine & "Total TC: " & totalC & vbNewLine & "Total APT: " & totalP
            End If
            tTotalC += totalC
            tTotalP += totalP
            tTotalW += totalW
            If dr("StationName").ToString = "Total" Then
                If tTotalW = 0 Then
                    dr("Total") = "SUM(PP): 0%" & vbNewLine & "SUM(TC): " & tTotalC & vbNewLine & "SUM(APT): " & tTotalP
                Else
                    dr("Total") = "SUM(PP): " & Convert.ToInt32(tTotalP / tTotalW * 100) & "%" & vbNewLine & "SUM(TC): " & tTotalC & vbNewLine & "SUM(APT): " & tTotalP
                End If
                If tMonW = 0 Then
                    dr("Monday") = "Total PP: 0%" & vbNewLine & "Total TC: " & tMonC & vbNewLine & "Total APT: " & tMonP
                Else
                    dr("Monday") = "Total PP: " & Convert.ToInt32(tMonP / tMonW * 100) & "%" & vbNewLine & "Total TC: " & tMonC & vbNewLine & "Total APT: " & tMonP
                End If
                If tMon2W = 0 Then
                    dr("Monday2") = "Total PP: 0%" & vbNewLine & "Total TC: " & tMon2C & vbNewLine & "Total APT: " & tMon2P
                Else
                    dr("Monday2") = "Total PP: " & Convert.ToInt32(tMon2P / tMon2W * 100) & "%" & vbNewLine & "Total TC: " & tMon2C & vbNewLine & "Total APT: " & tMon2P
                End If
                If tTueW = 0 Then
                    dr("Tuesday") = "Total PP: 0%" & vbNewLine & "Total TC: " & tTueC & vbNewLine & "Total APT: " & tTueP
                Else
                    dr("Tuesday") = "Total PP: " & Convert.ToInt32(tTueP / tTueW * 100) & "%" & vbNewLine & "Total TC: " & tTueC & vbNewLine & "Total APT: " & tTueP
                End If
                If tTue2W = 0 Then
                    dr("Tuesday2") = "Total PP: 0%" & vbNewLine & "Total TC: " & tTue2C & vbNewLine & "Total APT: " & tTue2P
                Else
                    dr("Tuesday2") = "Total PP: " & Convert.ToInt32(tTue2P / tTue2W * 100) & "%" & vbNewLine & "Total TC: " & tTue2C & vbNewLine & "Total APT: " & tTue2P
                End If
                If tWedW = 0 Then
                    dr("Wednesday") = "Total PP: 0%" & vbNewLine & "Total TC: " & tWedC & vbNewLine & "Total APT: " & tWedP
                Else
                    dr("Wednesday") = "Total PP: " & Convert.ToInt32(tWedP / tWedW * 100) & "%" & vbNewLine & "Total TC: " & tWedC & vbNewLine & "Total APT: " & tWedP
                End If
                If tWed2W = 0 Then
                    dr("Wednesday2") = "Total PP: 0%" & vbNewLine & "Total TC: " & tWed2C & vbNewLine & "Total APT: " & tWed2P
                Else
                    dr("Wednesday2") = "Total PP: " & Convert.ToInt32(tWed2P / tWed2W * 100) & "%" & vbNewLine & "Total TC: " & tWed2C & vbNewLine & "Total APT: " & tWed2P
                End If
                If tThuW = 0 Then
                    dr("Thursday") = "Total PP: 0%" & vbNewLine & "Total TC: " & tThuC & vbNewLine & "Total APT: " & tThuP
                Else
                    dr("Thursday") = "Total PP: " & Convert.ToInt32(tThuP / tThuW * 100) & "%" & vbNewLine & "Total TC: " & tThuC & vbNewLine & "Total APT: " & tThuP
                End If
                If tThu2W = 0 Then
                    dr("Thursday2") = "Total PP: 0%" & vbNewLine & "Total TC: " & tThu2C & vbNewLine & "Total APT: " & tThu2P
                Else
                    dr("Thursday2") = "Total PP: " & Convert.ToInt32(tThu2P / tThu2W * 100) & "%" & vbNewLine & "Total TC: " & tThu2C & vbNewLine & "Total APT: " & tThu2P
                End If
                If tFriW = 0 Then
                    dr("Friday") = "Total PP: 0%" & vbNewLine & "Total TC: " & tFriC & vbNewLine & "Total APT: " & tFriP
                Else
                    dr("Friday") = "Total PP: " & Convert.ToInt32(tFriP / tFriW * 100) & "%" & vbNewLine & "Total TC: " & tFriC & vbNewLine & "Total APT: " & tFriP
                End If
                If tFri2W = 0 Then
                    dr("Friday2") = "Total PP: 0%" & vbNewLine & "Total TC: " & tFri2C & vbNewLine & "Total APT: " & tFri2P
                Else
                    dr("Friday2") = "Total PP: " & Convert.ToInt32(tFri2P / tFri2W * 100) & "%" & vbNewLine & "Total TC: " & tFri2C & vbNewLine & "Total APT: " & tFri2P
                End If
                If tSatW = 0 Then
                    dr("Saturday") = "Total PP: 0%" & vbNewLine & "Total TC: " & tSatC & vbNewLine & "Total APT: " & tSatP
                Else
                    dr("Saturday") = "Total PP: " & Convert.ToInt32(tSatP / tSatW * 100) & "%" & vbNewLine & "Total TC: " & tSatC & vbNewLine & "Total APT: " & tSatP
                End If
                If tSat2W = 0 Then
                    dr("Saturday2") = "Total PP: 0%" & vbNewLine & "Total TC: " & tSat2C & vbNewLine & "Total APT: " & tSat2P
                Else
                    dr("Saturday2") = "Total PP: " & Convert.ToInt32(tSat2P / tSat2W * 100) & "%" & vbNewLine & "Total TC: " & tSat2C & vbNewLine & "Total APT: " & tSat2P
                End If
            End If
        Next
        Me.ugAssemblerPerformance.DataSource = dt
        Me.ugAssemblerPerformance.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed
        Me.ugAssemblerPerformance.DisplayLayout.Bands(0).Columns("StationName").Width = 150
        Me.ugAssemblerPerformance.DisplayLayout.Bands(0).Columns("Total").Width = 150
        Me.ugAssemblerPerformance.DisplayLayout.Bands(0).Columns("EmpRef").Hidden = True
        Me.ugAssemblerPerformance.DisplayLayout.Bands(0).Columns("AssemblerID").Hidden = True
        Me.ugAssemblerPerformance.DisplayLayout.Bands(0).Columns("Monday2").Header.Caption = "Monday"
        Me.ugAssemblerPerformance.DisplayLayout.Bands(0).Columns("Tuesday2").Header.Caption = "Tuesday"
        Me.ugAssemblerPerformance.DisplayLayout.Bands(0).Columns("Wednesday2").Header.Caption = "Wednesday"
        Me.ugAssemblerPerformance.DisplayLayout.Bands(0).Columns("Thursday2").Header.Caption = "Thursday"
        Me.ugAssemblerPerformance.DisplayLayout.Bands(0).Columns("Friday2").Header.Caption = "Friday"
        Me.ugAssemblerPerformance.DisplayLayout.Bands(0).Columns("Saturday2").Header.Caption = "Saturday"
        Me.ugAssemblerPerformance.DisplayLayout.Bands(0).Columns("StationName").Header.Caption = ""
        For i As Int16 = 0 To Me.ugAssemblerPerformance.Rows.Count - 1
            For Each c As UltraGridCell In Me.ugAssemblerPerformance.Rows(i).Cells
                If c.Column.Header.Caption.Contains("day") AndAlso c.Value.ToString.StartsWith("0%") Then
                    c.Appearance.BackColor = Color.Salmon
                End If
            Next
        Next
        Me.ugAssemblerPerformance.ActiveRow = Nothing

    End Sub

    Private Function GetWorkingMinutes(ByVal assemblerId As String, ByVal scheduleDate As String) As Int32

        Dim dt As DataTable = KPGeneral.WebRef_Local.GetTable("SELECT WorkingInMinutes,StartTime,EndTime,AfternoonBreak FROM ClampDailySchedule WHERE IsDeleted=0 AND AssemblerID=" _
                                                              & assemblerId & " AND ScheduleDate=CONVERT(DATE,'" & scheduleDate & "')", "ScheduleTime")
        If dt.Rows.Count > 0 Then
            Dim start As DateTime = CType(Today.ToShortDateString & " " & dt.Rows(0)("StartTime").ToString, DateTime)
            Dim endTime As DateTime = CType(Today.ToShortDateString & " " & dt.Rows(0)("EndTime").ToString, DateTime)
            Dim totalMinutes As Int16 = (endTime - start).TotalMinutes
            If CType(scheduleDate, Date) = Today Then
                Dim t1130 As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 11, 45, 1)
                Dim t915 As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 9, 15, 1)
                Dim t230 As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 14, 30, 1)

                If Now < t915 Then
                    If totalMinutes > CInt((Now - start).TotalMinutes) Then
                        Return CInt((Now - start).TotalMinutes)
                    Else
                        Return totalMinutes
                    End If
                ElseIf Now < t915.AddMinutes(15) Then 'morning break
                    If totalMinutes - 15 > CInt((t915 - start).TotalMinutes) Then
                        Return CInt((t915 - start).TotalMinutes)
                    Else
                        Return totalMinutes - 15
                    End If
                ElseIf Now < t1130 Then
                    If totalMinutes > CInt((Now - start).TotalMinutes) Then
                        Return CInt((Now - start).TotalMinutes) - 15
                    Else
                        Return totalMinutes - 15
                    End If
                ElseIf Now < t1130.AddMinutes(30) Then 'lunch time
                    If endTime.Hour = 12 Then 'no lunch time
                        Return IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 15, dt.Rows(0)("WorkingInMinutes").ToString)
                    Else
                        Return CInt((t1130 - start).TotalMinutes) - 15
                    End If
                Else ' after lunch
                    If endTime.Hour = 12 Then 'no lunch time
                        Return IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 15, CInt((endTime - start).TotalMinutes) - 15)
                    Else ' work after 12
                        If Now < t230 Then
                            Return IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                        ElseIf Now < t230.AddMinutes(15) Then
                            If dt.Rows(0)("AfternoonBreak") Then ' (endTime - start).TotalMinutes > 540 Then
                                Return IIf(endTime > Now, CInt((t230 - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                            Else
                                Return IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                            End If
                        Else
                            If dt.Rows(0)("AfternoonBreak") Then '(endTime - start).TotalMinutes > 540 Then
                                Return IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 60, CInt((endTime - start).TotalMinutes) - 60)
                            Else
                                Return IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                            End If
                        End If
                    End If
                End If
            Else
                'If (endTime - start).TotalMinutes > 540 Then 'has afternoon break
                '    Return CInt((endTime - start).TotalMinutes) - 60
                'ElseIf endTime.Hour = 12 Then 'no lunch time
                '    Return CInt((endTime - start).TotalMinutes) - 15
                'Else 'no afternoon break
                '    Return CInt((endTime - start).TotalMinutes) - 45
                'End If
                Return dt.Rows(0)("WorkingInMinutes")
            End If
        Else
            Return 0
        End If

    End Function

    Private Sub ugAssemblerPerformance_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugAssemblerPerformance.DoubleClickCell

        If e.Cell.Value.ToString <> "" AndAlso e.Cell.Row.Cells("StationName").Value <> "Total" AndAlso e.Cell.Column.Key.Contains("day") Then
            Dim tempForm As New frmAssemblerPerformanceDetails
            tempForm.assemblerID = e.Cell.Row.Cells("AssemblerID").Value
            Select Case e.Cell.Column.Key
                Case "Monday2"
                    tempForm.performanceDate = Me.BeginMondayDate.AddDays(7)
                Case "Monday"
                    tempForm.performanceDate = Me.BeginMondayDate
                Case "Tuesday2"
                    tempForm.performanceDate = Me.BeginMondayDate.AddDays(8)
                Case "Tuesday"
                    tempForm.performanceDate = Me.BeginMondayDate.AddDays(1)
                Case "Wednesday2"
                    tempForm.performanceDate = Me.BeginMondayDate.AddDays(9)
                Case "Wednesday"
                    tempForm.performanceDate = Me.BeginMondayDate.AddDays(2)
                Case "Thursday2"
                    tempForm.performanceDate = Me.BeginMondayDate.AddDays(10)
                Case "Thursday"
                    tempForm.performanceDate = Me.BeginMondayDate.AddDays(3)
                Case "Friday2"
                    tempForm.performanceDate = Me.BeginMondayDate.AddDays(11)
                Case "Friday"
                    tempForm.performanceDate = Me.BeginMondayDate.AddDays(4)
                Case "Saturday2"
                    tempForm.performanceDate = Me.BeginMondayDate.AddDays(12)
                Case "Saturday"
                    tempForm.performanceDate = Me.BeginMondayDate.AddDays(5)
            End Select
            tempForm.ShowDialog()
        End If

    End Sub

    Private Sub IncludeInPerformanceDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncludeInPerformanceDataToolStripMenuItem.Click

        If Me.ugAssemblerList.ActiveRow IsNot Nothing AndAlso Me.ugAssemblerList.ActiveRow.Index > -1 Then
            KPGeneral.KPDataSQL.SP_EXEC("t_UpdateAssemblerIncluded",
                                        Me.ugAssemblerList.ActiveRow.Cells("AssemblerID").Value,
                                        Not Me.ugAssemblerList.ActiveRow.Cells("IncludeInPerformanceData").Value)
            Me.RefreshAllTabs()
        Else
            MsgBox("Please select a row.")
        End If

    End Sub

    Private Sub tbTargetPercentage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbTargetPercentage.KeyPress

        If Not InputValidation.InputNumericOnly(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub btUpdatePicker_Click(sender As Object, e As EventArgs) Handles btUpdatePicker.Click

        Try
            KPGeneral.KPDataSQL.SP_EXEC("usp_UpdatePicker", Me.tbPickerID.Text,
                                    IIf(Me.tbPickerEmpRef.Text.Trim = "", DBNull.Value, Me.tbPickerEmpRef.Text.Trim),
                                    IIf(Me.tbPickerStationName.Text.Trim = "", DBNull.Value, Me.tbPickerStationName.Text.Trim),
                                    IIf(Me.tbNotes.Text.Trim = "", DBNull.Value, Me.tbNotes.Text.Trim),
                                    Me.chIsActive.Checked
                                    )
            Me.btClear_Click(sender, e)
            Me.RefreshWorkerList()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btAddPicker_Click(sender As Object, e As EventArgs) Handles btAddPicker.Click

        Try
            KPGeneral.KPDataSQL.SP_EXEC("usp_UpdatePicker", 0,
                                    IIf(Me.tbPickerEmpRef.Text.Trim = "", DBNull.Value, Me.tbPickerEmpRef.Text.Trim),
                                    IIf(Me.tbPickerStationName.Text.Trim = "", DBNull.Value, Me.tbPickerStationName.Text.Trim),
                                    IIf(Me.tbNotes.Text.Trim = "", DBNull.Value, Me.tbNotes.Text.Trim),
                                    Me.chIsActive.Checked
                                    )
            Me.btClear_Click(sender, e)
            Me.RefreshWorkerList()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ugPickers_AfterRowActivate(sender As Object, e As EventArgs) Handles ugPickers.AfterRowActivate

        If Me.ugPickers.ActiveRow IsNot Nothing AndAlso Me.ugPickers.ActiveRow.Index > -1 Then
            Me.tbPickerID.Text = Me.ugPickers.ActiveRow.Cells("PickerID").Value
            Me.tbPickerEmpRef.Text = IIf(IsDBNull(Me.ugPickers.ActiveRow.Cells("EmpRef").Value), "", Me.ugPickers.ActiveRow.Cells("EmpRef").Value)
            Me.tbPickerStationName.Text = IIf(IsDBNull(Me.ugPickers.ActiveRow.Cells("StationName").Value), "", Me.ugPickers.ActiveRow.Cells("StationName").Value)
            Me.tbNotes.Text = IIf(IsDBNull(Me.ugPickers.ActiveRow.Cells("Notes").Value), "", Me.ugPickers.ActiveRow.Cells("Notes").Value)
            Me.chIsActive.Checked = Me.ugPickers.ActiveRow.Cells("IsActive").Value
        End If

    End Sub

    Private Sub btClear_Click(sender As Object, e As EventArgs) Handles btClear.Click

        Me.tbPickerID.Text = ""
        Me.tbPickerEmpRef.Text = ""
        Me.tbPickerStationName.Text = ""
        Me.tbNotes.Text = ""
        Me.chIsActive.Checked = False

    End Sub

End Class