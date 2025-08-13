Imports Infragistics.Win.UltraWinGrid
Public Class frmPantryLabels
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
            ds = KPGeneral.WebRef_Local.usp_GetPantryLabelsToPrint

            Timer1.Stop()

            Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1
                KPGeneral.PrintZebraCabinetLabelByLabelNoForWrapping4x6(ds.Tables(0).Rows(x)("LabelNo"), ds.Tables(0).Rows(x)("CSID"), "frmPantryLabels", "Print New Labels", False)

                KPGeneral.WebRef_Local.usp_UpdatePantryLabelsPrintDate(ds.Tables(0).Rows(x)("LabelNo"))
            Next

            Timer1.Start()

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
        ds = KPGeneral.WebRef_Local.usp_GetPantryLabelsPrintedToday

        ugPrintedToday.DataSource = ds

        ugPrintedToday.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ugPrintedToday.DisplayLayout.Bands(0).Columns("LabelNo").Hidden = True
    End Sub

    Private Sub btnReprint_Click(sender As Object, e As EventArgs) Handles btnReprint.Click
        If ugPrintedToday.ActiveRow.Index > -1 Then
            KPGeneral.PrintZebraCabinetLabelByLabelNoForWrapping4x6(ugPrintedToday.ActiveRow.Cells("LabelNo").Text, ugPrintedToday.ActiveRow.Cells("CSID").Text, "frmPantryLabels", "btnReprint", False)
        End If
    End Sub
    Private Sub SetPantryPartsDelayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetPantryPartsDelayToolStripMenuItem.Click
        If ugPrintedToday.ActiveRow.Index > -1 Then
            frmPantryDelayPopup.CSID = ugPrintedToday.ActiveRow.Cells("CSID").Text
            frmPantryDelayPopup.ShowDialog()

            GetPrintedLabels()
        End If
    End Sub
    Private Sub ClearPantryPartsDelayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearPantryPartsDelayToolStripMenuItem.Click
        ClearDelay(ugPrintedToday)
    End Sub
    Private Sub ClearDelay(ByVal uGrid As UltraGrid)
        If (uGrid.ActiveRow Is Nothing) = False Then
            If uGrid.ActiveRow.Index > -1 Then
                If MsgBox("Are you sure you wish to clear the delay?", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.Yes Then
                    KPGeneral.WebRef_Local.usp_ClearPantryDelayDueToParts(uGrid.ActiveRow.Cells("CSID").Text)

                    GetPrintedLabels()
                End If
            End If
        End If

    End Sub
End Class