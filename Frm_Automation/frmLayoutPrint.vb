Imports System.IO
Public Class frmLayoutPrint
    Dim LastUpdate As Integer
    Dim SentWeeklyEmail As Boolean
    Dim FirstLoad As Boolean
    Private Sub frmCutlerOrders_Load(sender As Object, e As EventArgs) Handles Me.Load
        SentWeeklyEmail = False
        FirstLoad = True
        'GetWeeklyEmail()

        KPGeneral.SetDefaultGridSettings(ugOrders)
    End Sub
    Private Sub RefreshOrders()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.spKP_GetAutomatedLayoutPrintByDate(Now.Date)

        ugOrders.DataSource = ds
    End Sub
    Private Sub GetOrders()
        Dim ds As New DataSet
        'ds = KPGeneral.WebRef_Local.spKP_GetAutomatedLayoutPrintByDate(Now.Date)
        ds = KPGeneral.WebRef_Local.usp_getAutomatedLayoutsToPrint

        If ds.Tables(0).Rows.Count > 0 Then

            ugOrders.DataSource = ds
            ugOrders.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
            ugOrders.DisplayLayout.Bands(0).Columns("MasterNum").Width = 150
            ugOrders.DisplayLayout.Bands(0).Columns("ExpectedShip").Width = 150
            ugOrders.DisplayLayout.Bands(0).Columns("Company").Width = 200
            ugOrders.DisplayLayout.Bands(0).Columns("Project").Width = 250
            ugOrders.DisplayLayout.Bands(0).Columns("Lot").Width = 200

            Dim PrinterName As String = ""
            PrinterName = KPGeneral.GetUserPrinterNameByReportSource("LayoutWhite")

            'Dim pd As New System.Drawing.Printing.PrintDocument
            'Dim PrinterSettings1 As New Printing.PrinterSettings
            'Dim PageSettings1 As New Printing.PageSettings

            'PrinterSettings1.PrinterName = PrinterName
            'PrinterSettings1.Copies = 1
            'PrinterSettings1.Collate = True
            'PrinterSettings1.DefaultPageSettings.Landscape = True
            'PrinterSettings1.DefaultPageSettings.Margins.Bottom = 25
            'PrinterSettings1.DefaultPageSettings.Margins.Left = 25
            'PrinterSettings1.DefaultPageSettings.Margins.Right = 25
            'PrinterSettings1.DefaultPageSettings.Margins.Top = 25

            'pd.PrinterSettings = PrinterSettings1

            Dim c_pdSetup As New System.Drawing.Printing.PrintDocument
            Dim pSize As New System.Drawing.Printing.PaperSize

            'pSize.Width = 850
            'pSize.Height = 1400
            pSize.PaperName = "Legal"
            pSize.RawKind = System.Drawing.Printing.PaperKind.Legal

            c_pdSetup.DefaultPageSettings.Landscape = True
            c_pdSetup.DefaultPageSettings.Margins.Bottom = 25
            c_pdSetup.DefaultPageSettings.Margins.Left = 25
            c_pdSetup.DefaultPageSettings.Margins.Right = 25
            c_pdSetup.DefaultPageSettings.Margins.Top = 25
            c_pdSetup.PrinterSettings.PrinterName = PrinterName

            Dim x As Integer
            For x = 0 To c_pdSetup.DefaultPageSettings.PrinterSettings.PaperSizes.Count - 1
                If c_pdSetup.DefaultPageSettings.PrinterSettings.PaperSizes.Item(x).Kind = Printing.PaperKind.Legal Then
                    c_pdSetup.DefaultPageSettings.PaperSize = c_pdSetup.DefaultPageSettings.PrinterSettings.PaperSizes.Item(x)
                    Exit For
                End If
            Next

            If PrinterName.Length > 0 Then
                ugOrders.Print(ugOrders.DisplayLayout, c_pdSetup)
            Else
                ugOrders.Print()
            End If

            'Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1
                KPGeneral.PrintLayoutPage("Automated Layout Print", ds.Tables(0).Rows(x)("CSID"), KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(ds.Tables(0).Rows(x)("CSID"), 0), True, False, 1, 2, False, False)
                KPGeneral.WebRef_Local.usp_update_AutomatedLayoutPrintDate(ds.Tables(0).Rows(x)("CSID"))
            Next
        End If

        RefreshOrders()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            LastUpdate = LastUpdate + 1

            Dim PrintLayouts As Boolean = False

            If FirstLoad = True Then
                If LastUpdate > 30 Then
                    FirstLoad = False
                    GetOrders()

                End If
            End If

            If LastUpdate > 300 Then
                LastUpdate = 0
                If Now.DayOfWeek = DayOfWeek.Tuesday Then
                    PrintLayouts = True
                ElseIf Now.DayOfWeek = DayOfWeek.Wednesday Then
                    PrintLayouts = True
                ElseIf Now.DayOfWeek = DayOfWeek.Thursday Then
                    PrintLayouts = True
                ElseIf Now.DayOfWeek = DayOfWeek.Friday Then
                    PrintLayouts = True
                Else
                    PrintLayouts = False
                End If

                If Now.Hour >= 17 Then
                    If PrintLayouts = True Then
                        GetOrders()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Timer1.Stop()
        End Try

    End Sub

End Class