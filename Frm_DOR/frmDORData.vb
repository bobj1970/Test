Public Class frmDORData

    Private Sub frmDORData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ds As DataSet = KPGeneral.KPDataSQL.SP_EXEC("usp_UpdateDORData")
        Me.ugDORData.DataSource = ds
        Me.ugDORData.DisplayLayout.Bands(0).Columns("DailyMetricID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Me.ugDORData.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.ugDORData.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.ugHoursDORData.DataSource = ds
        Me.ugHoursDORData.DisplayLayout.Bands(0).Columns("DailyMetricID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Me.ugHoursDORData.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.ugHoursDORData.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugDORData.DisplayLayout.Bands(0).Columns
            col.Hidden = col.Header.Caption.Contains("Hours")
        Next
        For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugHoursDORData.DisplayLayout.Bands(0).Columns
            col.Hidden = Not col.Header.Caption.Contains("Hours")
        Next
        Me.ugHoursDORData.DisplayLayout.Bands(0).Columns("DailyMetricID").Hidden = False
        Me.ugHoursDORData.DisplayLayout.Bands(0).Columns("DORDate").Hidden = False

    End Sub

    Private Sub btExportYes_Click(sender As Object, e As EventArgs) Handles btExportYes.Click

        Try
            With SaveFileDialog1
                .Reset()
                .FileName = "DORData.xls"
                .DefaultExt = "xls"
                .Filter = KPGeneral.ExcelFileFilter
                Select Case .ShowDialog
                    Case Windows.Forms.DialogResult.OK
                        If Me.tcDORData.ActiveTab.Key = "Hours" Then
                            Me.GExporter.Export(Me.ugHoursDORData, SaveFileDialog1.FileName)
                        Else
                            Me.GExporter.Export(Me.ugDORData, SaveFileDialog1.FileName)
                        End If

                        KPGeneral.oFiles(SaveFileDialog1.FileName)
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End With
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

    End Sub

    Private Sub ugDORData_AfterRowUpdate(sender As Object, e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles ugDORData.AfterRowUpdate, ugHoursDORData.AfterRowUpdate

        Dim id As Int32 = e.Row.Cells("DailyMetricID").Value
        KPGeneral.KPDataSQL.SP_EXEC("usp_UpdateDORData", id,
                                                         e.Row.Cells("DORDate").Value, e.Row.Cells("PP_SheetsCut").Value, e.Row.Cells("PP_PiecesDowelled").Value,
                                                         e.Row.Cells("PP_PiecesDrilled").Value, e.Row.Cells("PP_MetersEdgeBanded").Value, e.Row.Cells("PP_MetersSanded").Value,
                                                         e.Row.Cells("PP_PiecesCutToeKick").Value, e.Row.Cells("PP_PiecesGrooved").Value, e.Row.Cells("PP_DirectHours").Value,
                                                         e.Row.Cells("DR_RawDoorsPicked").Value, e.Row.Cells("DR_FinishedDoorsPicked").Value, e.Row.Cells("DR_DoorsRejected").Value,
                                                         e.Row.Cells("DR_DirectHours").Value, e.Row.Cells("FI_SquareMetresLine1").Value, e.Row.Cells("FI_SquareMetresLine2").Value,
                                                         e.Row.Cells("FI_SquareMetresLine3").Value, e.Row.Cells("FI_SquareMetresLine4").Value, e.Row.Cells("FI_NumberOfPaintsStains").Value,
                                                         e.Row.Cells("FI_DirectHours").Value, e.Row.Cells("AS_CabinetsBuilt").Value, e.Row.Cells("AS_CabinetBuildersEarnedMinutes").Value,
                                                         e.Row.Cells("AS_CabinetsWrapped").Value, e.Row.Cells("AS_DoorsHinged").Value, e.Row.Cells("AS_EdgeBander4").Value,
                                                         e.Row.Cells("AS_TotalFinishedKitchens").Value, e.Row.Cells("AS_DirectHours").Value, e.Row.Cells("DF_DeficienciesOpen").Value,
                                                         e.Row.Cells("DF_DeficienciesClosed").Value, e.Row.Cells("SH_AcessoriesPicked").Value, e.Row.Cells("SH_DirectHours").Value,
                                                         e.Row.Cells("CU_AccessoriesBuilt").Value, e.Row.Cells("CU_CabinetsBuilt").Value, e.Row.Cells("CU_PiecesBuilt").Value,
                                                         e.Row.Cells("CU_DirectHours").Value, e.Row.Cells("FT_SiteRequest").Value, e.Row.Cells("FT_OrdersShipped").Value,
                                                         e.Row.Cells("FT_ShippedWithDefects").Value, e.Row.Cells("CO_Vanity").Value, e.Row.Cells("CO_Kitchen").Value,
                                                         e.Row.Cells("CO_Bar").Value, e.Row.Cells("CO_Other").Value, e.Row.Cells("CO_Weston").Value,
                                                         e.Row.Cells("CO_DirectHours").Value)

    End Sub

    Private Sub btDorReport_Click(sender As Object, e As EventArgs) Handles btDorReport.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            ReportsEngine.ReportOptions.FDate = Me.dtpDate.Value
            Dim ds As DataSet = ReportDatasets.Report310()
            Dim rptName As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptName = New rptDORByDate
            If ds.Tables(0).Rows.Count > 0 Then
                rptName.SetDataSource(ds)
            Else
                MsgBox("This report will return no results.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
            Dim rpt As New RptViewer(1, rptName)
            rpt.Show()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btProductionHoursReport_Click(sender As Object, e As EventArgs) Handles btProductionHoursReport.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            ReportsEngine.ReportOptions.FDate = Me.dtpDate.Value
            ReportsEngine.ReportOptions.TDate = ReportsEngine.ReportOptions.FDate 'Today
            Dim ds As DataSet = ReportDatasets.Report296()
            Dim rptName As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptName = New rptProductionHoursWorkedByDept
            If ds.Tables(0).Rows.Count > 0 Then
                rptName.SetDataSource(ds)
            Else
                MsgBox("This report will return no results.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
            Dim rpt As New RptViewer(1, rptName)
            rpt.Show()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try

    End Sub

End Class