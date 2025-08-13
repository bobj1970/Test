Public Class frmServiceOrderPrint
    Public _Parent As Form

    Private Sub frmServiceOrderPrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadOutstanding()
        LoadInProduction()

        KPGeneral.SetDefaultGridSettings(ugServiceOrderRecentScan)
        KPGeneral.SetDefaultGridSettings(ugServiceOrderToProduce)
    End Sub
    Private Sub LoadOutstanding()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetOutstandingServiceOrderCabinets()
        ugServiceOrderToProduce.DataSource = ds
        StyleOutstanding()
    End Sub
    Private Sub StyleOutstanding()
        ugServiceOrderToProduce.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ugServiceOrderToProduce.DisplayLayout.Bands(0).Columns("UBarcode").Hidden = True
        ugServiceOrderToProduce.DisplayLayout.Bands(0).Columns("LabelNo").Hidden = True

        KPGeneral.RefreshGridFromLayout(ugServiceOrderToProduce, Me.GetType.Name)
    End Sub
    Private Sub StyleInProduction()
        ugServiceOrderRecentScan.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ugServiceOrderRecentScan.DisplayLayout.Bands(0).Columns("UBarcode").Hidden = True
        ugServiceOrderRecentScan.DisplayLayout.Bands(0).Columns("LabelNo").Hidden = True
        ugServiceOrderRecentScan.DisplayLayout.Bands(0).Columns("scantime").Format = "MM/dd/yyyy - hh:mm tt"
        ugServiceOrderRecentScan.DisplayLayout.Bands(0).Columns("scantime").Width = 150
        ugServiceOrderRecentScan.DisplayLayout.Bands(0).Columns("WrapTime").Format = "hh:mm tt"
        ugServiceOrderRecentScan.DisplayLayout.Bands(0).Columns("WrapTime").Width = 100

        KPGeneral.RefreshGridFromLayout(ugServiceOrderRecentScan, Me.GetType.Name)
    End Sub
    Private Sub LoadInProduction()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetInProductionServiceOrderCabinets()
        ugServiceOrderRecentScan.DataSource = ds
        StyleInProduction()
    End Sub
    Private Sub PrintOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintOrdersToolStripMenuItem.Click
        Try
            If ugServiceOrderToProduce.Selected.Rows.Count > 0 Then

                KPGeneral.PrintZebraCabinetLabelByLabelNo(ugServiceOrderToProduce.ActiveRow.Cells("LabelNo").Value, ugServiceOrderToProduce.ActiveRow.Cells("CSID").Value, False)

                KPGeneral.WebRef_Local.usp_Cabients_IncrementPrintCounter_ByLabelNo(ugServiceOrderToProduce.ActiveRow.Cells("LabelNo").Value)

            End If
            LoadOutstanding()
            LoadInProduction()
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        LoadOutstanding()
    End Sub

    Private Sub RefreshToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem1.Click
        LoadInProduction()
    End Sub

    Private Sub PrinterOrdersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrinterOrdersToolStripMenuItem.Click
        Try
            If ugServiceOrderRecentScan.Selected.Rows.Count > 0 Then

                KPGeneral.PrintZebraCabinetLabelByLabelNo(ugServiceOrderRecentScan.ActiveRow.Cells("LabelNo").Value, ugServiceOrderRecentScan.ActiveRow.Cells("CSID").Value, False)

                'KPGeneral.WebRef_Local.usp_Cabients_IncrementPrintCounter_ByLabelNo(ugServiceOrderRecentScan.ActiveRow.Cells("LabelNo").Value)

            End If
            LoadOutstanding()
            LoadInProduction()
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub KitchenTrackerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem.Click
        If ugServiceOrderToProduce.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByCSID(ugServiceOrderToProduce.ActiveRow.Cells("CSID").Text)
        End If
    End Sub

    Private Sub KitchenTrackerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem1.Click
        If ugServiceOrderRecentScan.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByCSID(ugServiceOrderRecentScan.ActiveRow.Cells("CSID").Text)
        End If
    End Sub

    Private Sub ColumnChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem.Click
        KPGeneral.ColumnChooser(ugServiceOrderToProduce, Me.GetType.Name)
    End Sub

    Private Sub ColumnChooserToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem1.Click
        KPGeneral.ColumnChooser(ugServiceOrderRecentScan, Me.GetType.Name)
    End Sub

    Private Sub PrintYellowSheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintYellowSheetToolStripMenuItem.Click

        If ugServiceOrderToProduce.ActiveRow.Cells("PartRequestSource").Value = "Service" Then
            KPGeneral.PrintServicePartOrder(ugServiceOrderToProduce.ActiveRow.Cells("KeyNo").Value, ugServiceOrderToProduce.ActiveRow.Cells("Category").Value,
                                               ugServiceOrderToProduce.ActiveRow.Cells("SKNo").Value, ugServiceOrderToProduce.ActiveRow.Cells("CSID").Value, True, 1)

        Else
            KPGeneral.PrintServicePartOrder(ugServiceOrderToProduce.ActiveRow.Cells("KeyNo").Value, ugServiceOrderToProduce.ActiveRow.Cells("Category").Value,
                                               ugServiceOrderToProduce.ActiveRow.Cells("SKNo").Value, ugServiceOrderToProduce.ActiveRow.Cells("CSID").Value, True, 0)

        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If ugServiceOrderRecentScan.ActiveRow.Cells("PartRequestSource").Value = "Service" Then
            KPGeneral.PrintServicePartOrder(ugServiceOrderRecentScan.ActiveRow.Cells("KeyNo").Value, ugServiceOrderRecentScan.ActiveRow.Cells("Category").Value,
                                               ugServiceOrderRecentScan.ActiveRow.Cells("SKNo").Value, ugServiceOrderRecentScan.ActiveRow.Cells("CSID").Value, True, 1)

        Else
            KPGeneral.PrintServicePartOrder(ugServiceOrderRecentScan.ActiveRow.Cells("KeyNo").Value, ugServiceOrderRecentScan.ActiveRow.Cells("Category").Value,
                                               ugServiceOrderRecentScan.ActiveRow.Cells("SKNo").Value, ugServiceOrderRecentScan.ActiveRow.Cells("CSID").Value, True, 0)

        End If
    End Sub
End Class