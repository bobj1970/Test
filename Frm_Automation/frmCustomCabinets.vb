Imports System.Drawing.Printing
Public Class frmCustomCabinets
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
            ds = KPGeneral.WebRef_Local.usp_GetCustomCabinetLabelsToPrint

            Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1
                KPGeneral.PrintZebraCabinetLabelByLabelNoForWrapping4x6(ds.Tables(0).Rows(x)("LabelNo"), ds.Tables(0).Rows(x)("CSID"), "frmCustomCabinets", "Print New Labels", False)

                KPGeneral.WebRef_Local.usp_UpdatePantryLabelsPrintDate(ds.Tables(0).Rows(x)("LabelNo"))
            Next

            Dim dsAccessories As New DataSet
            dsAccessories = KPGeneral.WebRef_Local.usp_GetCustomAccessoriesLabelsToPrint

            Dim y As Integer
            For y = 0 To dsAccessories.Tables(0).Rows.Count - 1
                PrintAccessories(dsAccessories.Tables(0).Rows(y)("OrderAccessoriesID"))

                KPGeneral.WebRef_Local.usp_UpdateCustomAccessoryPrintDate(dsAccessories.Tables(0).Rows(y)("OrderAccessoriesID"))
            Next
        End If

        GetPrintedLabels()
    End Sub
    Private Sub frmPantryLabels_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetPrintedLabels()
        PrintNewLabels()

        KPGeneral.SetDefaultGridSettings(ugPrintedToday)
    End Sub
    Private Sub GetPrintedLabels()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetCustomCabinetLabelsPrintedToday

        ugPrintedToday.DataSource = ds

        ugPrintedToday.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ugPrintedToday.DisplayLayout.Bands(0).Columns("LabelNo").Hidden = True
        ugPrintedToday.DisplayLayout.Bands(0).Columns("SingleLabelPrintDate").Hidden = True
    End Sub

    Private Sub btnReprint_Click(sender As Object, e As EventArgs) Handles btnReprint.Click
        If ugPrintedToday.ActiveRow.Index > -1 Then
            If ugPrintedToday.ActiveRow.Cells("PrintType").Text = "Cabinet" Then
                KPGeneral.PrintZebraCabinetLabelByLabelNoForWrapping4x6(ugPrintedToday.ActiveRow.Cells("LabelNo").Text, ugPrintedToday.ActiveRow.Cells("CSID").Text, "frmCustomCabinets", "btnReprint", False)
            Else
                PrintAccessories(ugPrintedToday.ActiveRow.Cells("LabelNo").Text)
            End If

        End If
    End Sub
    Private Sub PrintAccessories(ByVal OrderAccessoryID As Integer)
        KPGeneral.PrintZebraAccessoryLabelByAccessoryID4x6(OrderAccessoryID)
    End Sub
End Class