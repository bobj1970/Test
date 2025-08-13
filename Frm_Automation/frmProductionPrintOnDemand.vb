Public Class frmProductionPrintOnDemand
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshProductionOnDemand()
    End Sub
    Private Sub PrintLayoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintLayoutToolStripMenuItem.Click
        If ugProductionPrintOnDemand.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugProductionPrintOnDemand.Selected.Rows.Count - 1
                KPGeneral.PrintLayoutPage("On Demand Printing", ugProductionPrintOnDemand.Selected.Rows(x).Cells("CSID").Text, KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(ugProductionPrintOnDemand.Selected.Rows(x).Cells("CSID").Text, 0), True, False, 1, 14, False, False)
            Next
        End If
    End Sub
    Private Sub ColumnChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem.Click
        KPGeneral.ColumnChooser(ugProductionPrintOnDemand, Me.GetType.Name)
    End Sub
    Private Sub RefreshProductionOnDemand()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetProductionPrintOnDemand()

        ugProductionPrintOnDemand.DataSource = ds

        KPGeneral.RefreshGridFromLayout(ugProductionPrintOnDemand, Me.GetType.Name)
    End Sub
    Private Sub frmProductionPrintOnDemand_Load(sender As Object, e As EventArgs) Handles Me.Load
        KPGeneral.SetDefaultGridSettings(ugProductionPrintOnDemand)
        KPGeneral.SetGridRowFilterSettings(ugProductionPrintOnDemand)

        ugProductionPrintOnDemand.DisplayLayout.Override.FilterUIProvider = UltraGridFilterUIProvider1

        RefreshProductionOnDemand()
    End Sub
End Class