Public Class frmWorkshopJobPrinting

    Dim LastUpdate As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Me.LastUpdate += 1
        If Me.LastUpdate > 10 Then
            Me.LastUpdate = 0
            Me.PrintNewLabels()
        End If

    End Sub

    Private Sub frmWorkshopJobPrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.PrintNewLabels()
    End Sub

    Private Sub PrintNewLabels()

        Me.Timer1.Stop()
        Dim dt As DataTable = KPGeneral.KPDataSQL.SP_EXEC("usp_getUnprintWorkshopJob").Tables(0)
        For Each dr As DataRow In dt.Rows
            Dim LogID As Integer = dr("JobLogID")
            Me.lbMessage.Text = "Workshop Job " & LogID & " is printing."
            Dim rptName As New rptWorkshop_JobLabel
            Dim ds As DataSet = KPGeneral.KPDataSQL.SP_EXEC("t_GetWorkshopJobLoglabelByLogID", LogID)
            If ds.Tables.Count = 0 Then
                Return
            End If
            ds.Tables(0).TableName = "vw_Workshop_JobLoglabel"
            rptName.SetDataSource(ds)
            'rptName.SetDataSource(KPGeneral.WebRef_Local.GetTable("SELECT * FROM vw_Workshop_JobLoglabel WHERE JobLogID=" & LogID, "vw_Workshop_JobLoglabel"))
            rptName.PrintOptions.PrinterName = dr("PrinterName")
            rptName.PrintToPrinter(1, True, 1, 0)
            rptName.Close()
            rptName.Dispose()
            'KPGeneral.WebRef_Local.ExcuteSqlStatement("UPDATE Workshop_JobLogs SET PrintDate=GETDATE() WHERE JobLogID=" & LogID)
            KPGeneral.KPDataSQL.SP_EXEC("t_SetWorkshopJobLogPrintDate", LogID)
        Next
        Me.Timer1.Start()

    End Sub

End Class