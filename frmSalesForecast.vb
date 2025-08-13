Public Class frmSalesForecast

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If ugForecast.CalendarInfo.Tasks.Count > 0 Then
            ugForecast.CalendarInfo.Tasks.Clear()
        End If
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetNewProjectForecast()

        Dim x As Integer
        For x = 0 To ds.Tables(0).Rows.Count - 1
            Dim SDate, EDate As Date
            Dim TSpan As TimeSpan
            Dim ProjName As String

            SDate = ds.Tables(0).Rows(x)("ProjectStartDate")
            If IsDBNull(ds.Tables(0).Rows(x)("ProjectCompletion")) = False Then
                EDate = ds.Tables(0).Rows(x)("ProjectCompletion")
            Else
                EDate = Now.Date.AddYears(10)
            End If

            Dim tspan1 As TimeSpan
            tspan1 = SDate - EDate
            If tspan1.Days = 0 Then
                TSpan = SDate - (EDate.AddDays(1))
            Else
                TSpan = SDate - EDate
            End If


            ProjName = ds.Tables(0).Rows(x)("Builder") & " / " & ds.Tables(0).Rows(x)("ProjectName") & " / " & ds.Tables(0).Rows(x)("Region")
            ugForecast.CalendarInfo.Tasks.Add(SDate, TSpan.Duration, ProjName)
            If IsDBNull(ds.Tables(0).Rows(x)("GanttViewColour")) = False Then
                ugForecast.CalendarInfo.Tasks(x).TimelineSettings.BarSettings.BarAppearance.BackColor = System.Drawing.Color.FromName(ds.Tables(0).Rows(x)("GanttViewColour"))
                ugForecast.CalendarInfo.Tasks(x).TimelineSettings.BarSettings.BarAppearance.BackColor2 = System.Drawing.Color.FromName(ds.Tables(0).Rows(x)("GanttViewColour"))
            End If
            If IsDBNull(ds.Tables(0).Rows(x)("NumberOfUnits")) = False Then
                ugForecast.CalendarInfo.Tasks(x).Notes = ds.Tables(0).Rows(x)("NumberOfUnits")
            Else
                ugForecast.CalendarInfo.Tasks(x).Notes = ""
            End If


        Next

        Dim dsSales As New DataSet
        dsSales = KPGeneral.WebRef_Local.usp_GetActiveSalesPersonColours()

        ugSalesPerson.DataSource = dsSales

        ugSalesPerson.DisplayLayout.Bands(0).Columns("SalesNo").Hidden = True
        ugSalesPerson.DisplayLayout.Bands(0).Columns("SalesName").Hidden = False
        ugSalesPerson.DisplayLayout.Bands(0).Columns("isActive").Hidden = True
        ugSalesPerson.DisplayLayout.Bands(0).Columns("GanttViewColour").Hidden = False
        ugSalesPerson.DisplayLayout.Bands(0).Columns("UserID").Hidden = True

        Dim y As Integer
        For y = 0 To ugSalesPerson.Rows.Count - 1
            ugSalesPerson.Rows(y).Appearance.BackColor = Color.White
            ugSalesPerson.Rows(y).Cells("GanttViewColour").Appearance.BackColor = System.Drawing.Color.FromName(ugSalesPerson.Rows(y).Cells("GanttViewColour").Text)
            ugSalesPerson.Rows(y).Cells("GanttViewColour").Appearance.ForeColor = System.Drawing.Color.FromName(ugSalesPerson.Rows(y).Cells("GanttViewColour").Text)
        Next

        KPGeneral.SetDefaultGridSettings(ugSalesPerson)

        ugSalesPerson.ActiveRow = Nothing
        ugSalesPerson.Selected.Rows.Clear()

        'ugForecast.CalendarLook.
    End Sub

    Private Sub ugForecast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ugForecast.Click

    End Sub

    Private Sub ugForecast_TimelineColumnHeaderInitializing(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.ColumnHeaderInitializingEventArgs) Handles ugForecast.TimelineColumnHeaderInitializing

    End Sub

    Private Sub ugForecast_TimelineColumnHeaderToolTipDisplaying(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinSchedule.ColumnHeaderToolTipDisplayingEventArgs) Handles ugForecast.TimelineColumnHeaderToolTipDisplaying
        UltraToolTipManager1.ShowToolTip(ugForecast)
        Dim ds As New DataSet
        Dim SDate, EDate As Date
        SDate = e.HeaderElement.DateTimeRange.StartDateTime.Date
        EDate = e.HeaderElement.DateTimeRange.EndDateTime.Date
        ds = KPGeneral.WebRef_Local.usp_GetNewProjectForecastCountDateRange(SDate, EDate)
        If ds.Tables(0).Rows.Count > 0 Then
            UltraToolTipManager1.ToolTipTitle = "There are " & ds.Tables(0).Rows.Count & " projects forecast between " & e.HeaderElement.DateTimeRange.ToString
        End If

        UltraToolTipManager1.HideToolTip()

    End Sub
End Class
