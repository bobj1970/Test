Public Class frmAssemblyLineLabels

    Dim LastUpdate As Integer


    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            LastUpdate = LastUpdate + 1

            If LastUpdate > 10 Then
                LastUpdate = 0
                PrintNewLabels()
            End If
        Catch ex As Exception
            Me.Timer1.Stop()
        End Try

    End Sub

    Private Sub PrintNewLabels()
        If KPGeneral.User.UserProfile("AutomationViewOnly") = False Then
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.usp_GetAssemblyLineLabelsToPrint

            Timer1.Stop()

            Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1
                KPGeneral.PrintDymoCabinetLabelByLabelNoForAssemblyLine4x2(ds.Tables(0).Rows(x)("LabelNo"), ds.Tables(0).Rows(x)("CSID"), "frmAssemblyLine", "Top Rail Labels", False)

                KPGeneral.WebRef_Local.usp_UpdateAssemblyLineLabelsPrintDate(ds.Tables(0).Rows(x)("LabelNo"))
            Next

            Timer1.Start()
        End If

        GetPrintedLabels()
    End Sub

    Private Sub GetPrintedLabels()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetAssemblyLineLabelsPrintedToday

        ugPrintedToday.DataSource = ds

        'ugPrintedToday.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        'ugPrintedToday.DisplayLayout.Bands(0).Columns("LabelNo").Hidden = True
    End Sub
End Class