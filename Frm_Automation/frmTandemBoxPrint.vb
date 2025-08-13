Imports Infragistics.Win.UltraWinTabControl

Public Class frmTandemBoxPrint
    Dim LastUpdate As Integer


    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            LastUpdate = LastUpdate + 1
            If LastUpdate > 60 Then
                LastUpdate = 0
                PrintNewLabels()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Timer1.Stop()
        End Try

    End Sub
    Private Sub PrintNewLabels()

        If KPGeneral.User.UserProfile("AutomationViewOnly") = False Then
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.usp_GetTandemboxLabelsToPrintByCSID

            Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1
                KPGeneral.PrintZebraTandemboxLabelByCSID4x6(ds.Tables(0).Rows(x)("CSID"), True)

                KPGeneral.WebRef_Local.usp_UpdateTandemBoxPrintDate(ds.Tables(0).Rows(x)("CSID"))
            Next
        End If
        GetPrintedLabels()

    End Sub
    Private Sub frmPantryLabels_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            GetPrintedLabels()
            PrintNewLabels()
            KPGeneral.SetDefaultGridSettings(ugPrintedToday)
            KPGeneral.SetDefaultGridSettings(ugRecentPrints)
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Timer1.Stop()
        End Try

    End Sub
    Private Sub GetPrintedLabels()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetTandemboxLabelsPrintedToday

        ugPrintedToday.DataSource = ds

        ugPrintedToday.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ugPrintedToday.DisplayLayout.Bands(0).Columns("LabelNo").Hidden = True
    End Sub
    Private Sub btnReprint_Click(sender As Object, e As EventArgs) Handles btnReprint.Click
        'If ugPrintedToday.ActiveRow.Index > -1 Then
        '    KPGeneral.PrintZebraTandemboxLabelByLabelNo4x6(ugPrintedToday.ActiveRow.Cells("LabelNo").Text, ugPrintedToday.ActiveRow.Cells("CSID").Text)
        'End If
    End Sub
    Private Sub GetRecentOrders()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetTandemboxLabelsRecentlyPrinted

        ugRecentPrints.DataSource = ds

        ugRecentPrints.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ugRecentPrints.DisplayLayout.Bands(0).Columns("Company").Width = 200
        ugRecentPrints.DisplayLayout.Bands(0).Columns("Project").Width = 200
        ugRecentPrints.DisplayLayout.Bands(0).Columns("Lot").Width = 150
        ugRecentPrints.DisplayLayout.Bands(0).Columns("TBS").Width = 150
        ugRecentPrints.DisplayLayout.Bands(0).Columns("TBC").Width = 150
        ugRecentPrints.DisplayLayout.Bands(0).Columns("TBS").Format = KPGeneral.DateTime12HourFormatString
        ugRecentPrints.DisplayLayout.Bands(0).Columns("TBC").Format = KPGeneral.DateTime12HourFormatString
        'ugPrintedToday.DisplayLayout.Bands(0).Columns("LabelNo").Hidden = True
    End Sub
    Private Sub UltraTabControl1_ActiveTabChanged(sender As Object, e As ActiveTabChangedEventArgs) Handles UltraTabControl1.ActiveTabChanged
        If UltraTabControl1.ActiveTab.Index = 0 Then
            GetPrintedLabels()
        Else
            GetRecentOrders()
        End If
    End Sub
    Private Sub PrintLayoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintLayoutToolStripMenuItem.Click
        If ugRecentPrints.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugRecentPrints.Selected.Rows.Count - 1
                PrintLayoutPage(1, ugRecentPrints.Selected.Rows(x).Cells("CSID").Text)
            Next
        End If
    End Sub
    Private Sub ReprintTandemboxLabelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReprintTandemboxLabelsToolStripMenuItem.Click
        If ugRecentPrints.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugRecentPrints.Selected.Rows.Count - 1
                KPGeneral.PrintZebraTandemboxLabelByCSID4x6(ugRecentPrints.Selected.Rows(x).Cells("CSID").Text, True)
                KPGeneral.WebRef_Local.usp_UpdateTandemBoxPrintDate(ugRecentPrints.Selected.Rows(x).Cells("CSID").Text)
            Next
        End If
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem.Click
        If ugRecentPrints.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByCSID(ugRecentPrints.ActiveRow.Cells("CSID").Text)
        End If
    End Sub
    Private Sub PrintLayoutPage(ByVal Copies As Integer, ByVal CSID As Integer)
        KPGeneral.PrintLayoutPage("Tandembox", CSID, KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(CSID, 0), True, False, Copies, 15, False, False)
    End Sub
End Class