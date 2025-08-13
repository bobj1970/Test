Public Class frmAssemblerPerformanceDetails

    Public assemblerID As String
    Public performanceDate As Date

    Private Sub frmAssemblerPerformanceDetails_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.RefreshPerformance()

    End Sub

    Private Sub btPreviousDay_Click(sender As Object, e As EventArgs) Handles btPreviousDay.Click

        Me.performanceDate = Me.performanceDate.AddDays(-1)
        Me.RefreshPerformance()

    End Sub

    Private Sub btNextDay_Click(sender As Object, e As EventArgs) Handles btNextDay.Click

        Me.performanceDate = Me.performanceDate.AddDays(1)
        Me.RefreshPerformance()

    End Sub

    Private Sub RefreshPerformance()

        Me.lbScheduleDate.Text = "Current Date: " & Me.performanceDate.ToShortDateString
        Dim dt As DataTable = KPGeneral.WebRef_Local.GetTable("SELECT StationName,EmpRef,StartTime,EndTime,WorkingInMinutes,AfternoonBreak FROM ClampDailySchedule INNER JOIN Assemblers ON " _
                                                              & "ClampDailySchedule.AssemblerID=Assemblers.AssemblerID WHERE IsDeleted=0 And Assemblers.AssemblerID=" & Me.assemblerID _
                                                              & " And ScheduleDate=CONVERT(DATE,'" & Me.performanceDate & "')", "ScheduleTime")
        If dt.Rows.Count > 0 Then

            Me.tbEmployeeNumber.Text = dt.Rows(0)("EmpRef").ToString
            Me.tbName.Text = dt.Rows(0)("StationName").ToString
            Me.tbShiftTime.Text = dt.Rows(0)("StartTime").ToString & " - " & dt.Rows(0)("EndTime").ToString
            Dim start As DateTime = CType(Today.ToShortDateString & " " & dt.Rows(0)("StartTime").ToString, DateTime)
            Dim endTime As DateTime = CType(Today.ToShortDateString & " " & dt.Rows(0)("EndTime").ToString, DateTime)
            If Me.performanceDate = Today Then
                Dim t1130 As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 11, 45, 1)
                Dim t915 As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 9, 15, 1)
                Dim t230 As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 14, 30, 1)
                If Now < t915 Then
                    Me.tbWorkingMinutes.Text = CInt((Now - start).TotalMinutes)
                ElseIf Now < t915.AddMinutes(15) Then 'morning break
                    Me.tbWorkingMinutes.Text = CInt((t915 - start).TotalMinutes)
                ElseIf Now < t1130 Then
                    Me.tbWorkingMinutes.Text = CInt((Now - start).TotalMinutes) - 15
                ElseIf Now < t1130.AddMinutes(30) Then 'lunch time
                    If endTime.Hour = 12 Then 'no lunch time
                        Me.tbWorkingMinutes.Text = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 15, CInt((endTime - start).TotalMinutes) - 15)
                    Else
                        Me.tbWorkingMinutes.Text = CInt((t1130 - start).TotalMinutes) - 15
                    End If
                Else ' after lunch time
                    If endTime.Hour = 12 Then 'no lunch time
                        Me.tbWorkingMinutes.Text = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 15, CInt((endTime - start).TotalMinutes) - 15)
                    Else ' work after 12
                        If Now < t230 Then
                            Me.tbWorkingMinutes.Text = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                        ElseIf Now < t230.AddMinutes(15) Then
                            If dt.Rows(0)("AfternoonBreak") Then '(endTime - start).TotalMinutes > 540 Then
                                Me.tbWorkingMinutes.Text = IIf(endTime > Now, CInt((t230 - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                            Else
                                Me.tbWorkingMinutes.Text = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                            End If
                        Else
                            If dt.Rows(0)("AfternoonBreak") Then '(endTime - start).TotalMinutes > 540 Then
                                Me.tbWorkingMinutes.Text = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 60, CInt((endTime - start).TotalMinutes) - 60)
                            Else
                                Me.tbWorkingMinutes.Text = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                            End If
                        End If
                    End If
                End If
            Else
                'If (endTime - start).TotalMinutes > 540 Then 'has afternoon break
                '    Me.tbWorkingMinutes.Text = CInt((endTime - start).TotalMinutes) - 60
                'ElseIf endTime.Hour = 12 Then 'no lunch time
                '    Me.tbWorkingMinutes.Text = CInt((endTime - start).TotalMinutes) - 15
                'Else 'no afternoon break
                '    Me.tbWorkingMinutes.Text = CInt((endTime - start).TotalMinutes) - 45
                'End If
                Me.tbWorkingMinutes.Text = dt.Rows(0)("WorkingInMinutes")
            End If
        Else
            dt = KPGeneral.WebRef_Local.GetTable("SELECT StationName,EmpRef FROM Assemblers WHERE AssemblerID=" & Me.assemblerID, "Assembler")
            Me.tbEmployeeNumber.Text = dt.Rows(0)("EmpRef").ToString
            Me.tbName.Text = dt.Rows(0)("StationName").ToString
            Me.tbShiftTime.Text = ""
            Me.tbWorkingMinutes.Text = ""
        End If
        dt = KPGeneral.WebRef_Local.GetTable("Select ISNULL(SUM(AssemblyPlannedTime),0) AS 'TotalPlanTime', COUNT(*) AS 'TotalCabinet' FROM tblCabinetLabel WHERE ScanUser='" _
                                              & Me.tbEmployeeNumber.Text & "' AND CONVERT(DATE,ScanDate)=CONVERT(DATE,'" & Me.performanceDate & "')", "Performance")
        If dt.Rows.Count > 0 Then
            Me.tbAPTTotal.Text = Convert.ToInt32(Convert.ToDouble(dt.Rows(0)("TotalPlanTime"))).ToString
            Me.tbTotalCabinets.Text = dt.Rows(0)("TotalCabinet").ToString
        Else
            Me.tbAPTTotal.Text = ""
            Me.tbTotalCabinets.Text = ""
        End If
        If Me.tbWorkingMinutes.Text <> "" AndAlso Me.tbAPTTotal.Text <> "" Then
            Dim performance As Double = CType(Me.tbAPTTotal.Text, Double) / CType(Me.tbWorkingMinutes.Text, Double) * 100
            Me.tbPerformance.Text = Convert.ToInt32(performance).ToString
        Else
            Me.tbPerformance.Text = ""
        End If
        dt = KPGeneral.KPDataSQL.SP_EXEC("usp_GetEmployeeTimeCardByDate", Me.tbEmployeeNumber.Text, Me.performanceDate).Tables(0)
        If dt.Rows.Count > 0 Then
            Me.tbClockIn.Text = dt.Rows(0)("ClockIN").ToString
            Me.tbClockOut.Text = dt.Rows(0)("ClockOUT").ToString
        Else
            Me.tbClockIn.Text = ""
            Me.tbClockOut.Text = ""
        End If
        Dim sqlStatement As String = "SELECT ScanTime,MASTERNUM,COMPANY,PROJECT,LOT,Cabinet_Name,tblCabinetLabel.AssemblyPlannedTime,'' AS AssignedClamp " _
                                    & "FROM PROJECTS INNER JOIN PURCHASERS ON PROJECTS.PROJNUM = PURCHASERS.PROJNUM " _
                                    & "INNER JOIN tblCabinetLabel ON PURCHASERS.CSID = tblCabinetLabel.CSID " _
                                    & "WHERE CONVERT(DATE,ScanDate)=CONVERT(DATE,'" & Me.performanceDate & "') AND ScanUser='" & Me.tbEmployeeNumber.Text _
                                    & "' ORDER BY ScanTime"
        dt = KPGeneral.WebRef_Local.GetTable(sqlStatement, "Cabinets")
        sqlStatement = "SELECT ClampName FROM Clamps INNER JOIN ClampDailySchedule S ON Clamps.ClampID=S.ClampID WHERE AssemblerID=" & Me.assemblerID _
                       & " AND ScheduleDate=CONVERT(DATE,'" & Me.performanceDate & "')"
        Dim temp As DataTable = KPGeneral.WebRef_Local.GetTable(sqlStatement, "Clamp")
        If temp.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                dr("AssignedClamp") = temp.Rows(0)(0)
            Next
        End If
        KPGeneral.SetDefaultGridSettings(Me.ugCabinetList)
        Me.ugCabinetList.DataSource = dt
        Me.ugCabinetList.DisplayLayout.Bands(0).Columns("COMPANY").Width = 180
        Me.ugCabinetList.DisplayLayout.Bands(0).Columns("PROJECT").Width = 250
        Me.ugCabinetList.DisplayLayout.Bands(0).Columns("ScanTime").Width = 150
        Me.ugCabinetList.DisplayLayout.Bands(0).Columns("ScanTime").Format = KPGeneral.DateTime12HourFormatString

    End Sub

    Private Sub btViewReport_Click(sender As Object, e As EventArgs) Handles btViewReport.Click

        If Me.performanceDate > Today Then
            MsgBox("No report")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim dsAssemblyDetail As New DataSet
        'Dim sqlStatement As String = "SELECT ScanTime,MASTERNUM,COMPANY,PROJECT,LOT,Cabinet_Name,tblCabinetLabel.AssemblyPlannedTime,'' AS AssignedClamp " _
        '                            & "FROM PROJECTS INNER JOIN PURCHASERS ON PROJECTS.PROJNUM = PURCHASERS.PROJNUM " _
        '                            & "INNER JOIN tblCabinetLabel ON PURCHASERS.CSID = tblCabinetLabel.CSID " _
        '                            & "WHERE CONVERT(DATE,ScanDate)=CONVERT(DATE,'" & Me.performanceDate & "') AND ScanUser='" & Me.tbEmployeeNumber.Text _
        '                            & "' ORDER BY ScanTime"
        'dsAssemblyDetail.Tables.Add(KPGeneral.WebRef_Local.GetTable(sqlStatement, "vw_rptAssemblerDailyPerformance").Copy)
        dsAssemblyDetail.Tables.Add(CType(Me.ugCabinetList.DataSource, DataTable).Copy)
        dsAssemblyDetail.Tables(0).TableName = "vw_rptAssemblerDailyPerformance"
        Dim sqlStatement As String = "SELECT TOP(1) * FROM vw_rptAssemblerDailyPerformance_Info WHERE AssemblerID=" & Me.assemblerID & " AND ScheduleDate=CONVERT(DATE,'" & Me.performanceDate & "')"
        Dim dt As DataTable = KPGeneral.WebRef_Local.GetTable(sqlStatement, "vw_rptAssemblerDailyPerformance_Info")
        If dt.Rows.Count > 0 Then
            dt.Rows(0)("APT") = Me.tbAPTTotal.Text
            dt.Rows(0)("WorkingInMinutes") = Me.tbWorkingMinutes.Text
            dt.Rows(0)("Performance") = Me.tbPerformance.Text
            If Me.tbClockIn.Text = "" Then
                dt.Rows(0)("ClockIN") = DBNull.Value
            Else
                dt.Rows(0)("ClockIN") = DateTime.Parse(Me.tbClockIn.Text)
            End If
            If Me.tbClockOut.Text = "" Then
                dt.Rows(0)("ClockOUT") = DBNull.Value
            Else
                dt.Rows(0)("ClockOUT") = DateTime.Parse(Me.tbClockOut.Text)
            End If
            sqlStatement = "SELECT * FROM vw_rptAssemblerDailyPerformance_StartTimeEndTime"
            Dim dtTime = KPGeneral.WebRef_Local.GetTable(sqlStatement, "vw_rptAssemblerDailyPerformance_StartTimeEndTime")
            dtTime.Rows(0)("StartTime") = CType(Today.ToShortDateString & " " & dt.Rows(0)("StartTime").ToString, DateTime)
            dtTime.Rows(0)("EndTime") = CType(Today.ToShortDateString & " " & dt.Rows(0)("EndTime").ToString, DateTime)
            dsAssemblyDetail.Tables.Add(dtTime.Copy)
        End If
        dsAssemblyDetail.Tables.Add(dt.Copy)
        Dim rptName As New rptAssemblerDailyPerformance
        rptName.SetDataSource(dsAssemblyDetail)
        Dim rpt As New RptViewer(1, rptName)
        Me.Cursor = Cursors.Default
        rpt.ShowDialog()
        rpt.Close()
        rpt.Dispose()

    End Sub
End Class