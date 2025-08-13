Public Class frmOvenPanels
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
            ds = KPGeneral.WebRef_Local.usp_GetOvenPanelsToPrint

            Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1
                Dim BackPanelLabel As New DataSet

                Dim OrderAccessoriesID As Integer = ds.Tables(0).Rows(x)("OrderAccessoriesID")

                BackPanelLabel = KPGeneral.WebRef_Local.usp_getOvenPanelByAccessoryID(OrderAccessoriesID)
                BackPanelLabel.Tables(0).TableName = "Table1"
                'BackPanelLabel.WriteXml("c:\xml\backpanel.xml", XmlWriteMode.WriteSchema)

                KPGeneral.DymoPrintOP(BackPanelLabel)

                KPGeneral.WebRef_Local.usp_UpdateOvenPanelLabelsPrintDate(ds.Tables(0).Rows(x)("OrderAccessoriesID"))
            Next
        End If

        GetPrintedLabels()
    End Sub
    Private Sub frmPantryLabels_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            GetPrintedLabels()
            PrintNewLabels()
            KPGeneral.SetDefaultGridSettings(ugPrintedToday)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub GetPrintedLabels()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetOvenPanelLabelsPrintedToday

        ugPrintedToday.DataSource = ds

        ugPrintedToday.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ugPrintedToday.DisplayLayout.Bands(0).Columns("OrderAccessoriesID").Hidden = True
    End Sub
    Private Sub btnReprint_Click(sender As Object, e As EventArgs) Handles btnReprint.Click
        If ugPrintedToday.ActiveRow.Index > -1 Then
            Dim BackPanelLabel As New DataSet

            Dim OrderAccessoriesID As Integer = ugPrintedToday.ActiveRow.Cells("OrderAccessoriesID").Text

            BackPanelLabel = KPGeneral.WebRef_Local.usp_getOvenPanelByAccessoryID(OrderAccessoriesID)
            BackPanelLabel.Tables(0).TableName = "Table1"
            'BackPanelLabel.WriteXml("c:\xml\backpanel.xml", XmlWriteMode.WriteSchema)
            KPGeneral.DymoPrintOP(BackPanelLabel)
        End If
    End Sub
End Class