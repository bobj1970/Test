Imports System.IO
Imports Infragistics.Win.UltraWinGrid

Public Class frmNeedLayout
    Dim LastUpdate As Integer
    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Long
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LastUpdate = LastUpdate + 1

        Dim PrintLayouts As Boolean = False

        If LastUpdate > 2000 Then
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

            If Now.Hour >= 11 Then
                If PrintLayouts = True Then
                    Try
                        GetOrders()
                        GetOrders_MeasuringFiles()
                        GetOrders_ScanFiles()
                        GetOrders_ColourCharts()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Me.Timer1.Stop()
                    End Try

                End If
            End If
        End If
    End Sub
    Private Sub RefreshOrders()

        ugOrders.DataSource = KPGeneral.WebRef_Local.spKP_GetAutomatedLayoutPDFByDate(Now.Date)
    End Sub
    Private Sub GetOrders()

        Cursor = Cursors.WaitCursor
        Dim ds As DataSet
        ds = KPGeneral.WebRef_Local.usp_getAutomatedLayoutsToConvertToPDF
        If ds.Tables(0).Rows.Count > 0 Then
            Me.lbCount.Text = "There are " & ds.Tables(0).Rows.Count & " layouts left to be converted."
            Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1
                Try
                    Dim CSID As Integer = ds.Tables(0).Rows(x)("CSID")

                    If CSID > 0 Then
                        Dim FilePath As String = KPGeneral.StartupPath & "\" & CSID & ".pdf"
                        If Me.CreateFileToEmail(CSID, FilePath) = True Then 'If KPGeneral.CreateFileToEmail(CSID, FilePath) = True Then
                            Dim fsImage As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
                            Dim bytImageData(fsImage.Length - 1) As Byte
                            fsImage.Read(bytImageData, 0, bytImageData.Length)
                            fsImage.Flush() 'clear buffer
                            fsImage.Close()

                            KPGeneral.WebRef_Local.usp_update_AutomatedLayoutPDF(ds.Tables(0).Rows(x)("CSID"), bytImageData)
                            KPGeneral.DeleteFileByFilePath(FilePath)
                            System.Threading.Thread.Sleep(2000) 'wait for system clean memory
                        End If
                    End If
                Catch ex As Exception

                End Try
            Next
        End If
        Cursor = Cursors.Default
        RefreshOrders()

    End Sub

    Private Function CreateFileToEmail(ByVal CSID As Integer, ByVal FilePath As String) As Boolean

        Me.PrintLayoutPage("Layout Email", CSID, "")
        If File.Exists(KPGeneral.TempDir & "LayoutReport.pdf") = True Then
            File.Copy(KPGeneral.TempDir & "LayoutReport.pdf", FilePath)
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub PrintLayoutPage(ByVal PrintSource As String, ByVal CSID As Integer, ByVal SideBarText As String)

        Dim HasLayoutPages As Boolean = False
        Dim LogID As Integer = 0
        Dim dsOrderInfo As DataSet = KPGeneral.WebRef_Local.spKP_LotInfoByCSID(CSID)
        CSID = dsOrderInfo.Tables(0).Rows(0)("CSID")
        Dim isDealer As Boolean
        Dim isXOrder As Boolean
        Dim isInvoiceOnly As Boolean = False
        isDealer = Convert.ToBoolean(dsOrderInfo.Tables(0).Rows(0)("isDealer"))
        If IsDBNull(dsOrderInfo.Tables(0).Rows(0)("Masternum")) Then
            isXOrder = False
        Else
            If dsOrderInfo.Tables(0).Rows(0)("Masternum").ToString.Contains("X") Then
                isXOrder = True
            Else
                isXOrder = False
            End If
        End If
        If IsDBNull(dsOrderInfo.Tables(0).Rows(0)("XInvoiceOnly")) = False Then
            isInvoiceOnly = dsOrderInfo.Tables(0).Rows(0)("XInvoiceOnly")
        End If

        If isDealer = True Or isXOrder Then
            Dim ds As DataSet = KPGeneral.WebRef_Local.usp_XK_getCabinetListByCSID(CSID)
            ds.Tables.Add(KPGeneral.WebRef_Local.usp_XK_GetOrderAccessoriesByCSID(CSID).Tables(0).Copy)
            ds.Tables.Add(KPGeneral.WebRef_Local.usp_XK_GetRoomInfoByCSID(CSID).Tables(0).Copy)
            ds.Tables.Add(KPGeneral.WebRef_Local.usp_XK_LotInfoByCSID(CSID).Tables(0).Copy)
            ds.Tables.Add(KPGeneral.WebRef_Local.usp_XK_GetDoorDrawerListByCSID(CSID).Tables(0).Copy)
            ds.Tables.Add(KPGeneral.WebRef_Local.usp_GetRoomLayoutPagesForLayoutByCSID(CSID).Tables(0).Copy)
            HasLayoutPages = True
            If ds.Tables(5).Rows.Count > 0 Then
                HasLayoutPages = True
            End If
            If isInvoiceOnly = False Then
                If HasLayoutPages = True Then
                    Dim rptName As New rptRoomLayout_Cutlist
                    rptName.SetDataSource(ds)
                    rptName.SetParameterValue("SideBar", SideBarText)
                    rptName.SetParameterValue("PrintSource", "Printed by " & PrintSource)
                    KPGeneral.DeleteFileByFilePath(KPGeneral.TempDir & "LayoutReport.pdf")
                    rptName.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, KPGeneral.TempDir & "LayoutReport.pdf")
                    rptName.Close()
                    rptName.Dispose()
                End If
            Else
                Dim dsInvoiceOnly As DataSet
                dsInvoiceOnly = KPGeneral.WebRef_Local.usp_GetRoomInfoForInvoiceOnlyByCSID(CSID)
                dsInvoiceOnly.Tables(0).TableName = "view_layout_page_design"
                Dim rptName As New rptRoomLayout_InvoiceOnly
                rptName.SetDataSource(dsInvoiceOnly)
                KPGeneral.DeleteFileByFilePath(KPGeneral.TempDir & "LayoutReport.pdf")
                rptName.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, KPGeneral.TempDir & "LayoutReport.pdf")
                rptName.Close()
                rptName.Dispose()
            End If
        Else
            Dim ds As DataSet = KPGeneral.WebRef_Local.usp_GetRoomLayoutPagesForLayoutByCSID(CSID)
            If ds.Tables(0).Rows.Count > 0 Then
                HasLayoutPages = True
            End If
            If HasLayoutPages = True Then
                Dim rptName As New rptRoomLayout
                rptName.SetDataSource(ds)
                rptName.SetParameterValue("SideBar", SideBarText)
                rptName.SetParameterValue("PrintSource", "Printed by " & PrintSource & " - " & Now.ToShortDateString)
                KPGeneral.DeleteFileByFilePath(KPGeneral.TempDir & "LayoutReport.pdf")
                rptName.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, KPGeneral.TempDir & "LayoutReport.pdf")
                rptName.Close()
                rptName.Dispose()
            End If
        End If

    End Sub
    Private Sub GetOrders_ScanFiles()
        Cursor = Cursors.WaitCursor

        Dim ds As DataSet
        'ds = KPGeneral.WebRef_Local.spKP_GetAutomatedLayoutPrintByDate(Now.Date)
        ds = KPGeneral.WebRef_Local.usp_getScanImageToConvertToPDF

        If ds IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
            Me.lbCount.Text = "There are " & ds.Tables(0).Rows.Count & " ScanImages left to be converted."
            Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1

                Dim ImageID As Integer = ds.Tables(0).Rows(x)("ImageID")

                If ImageID > 0 Then
                    Dim FilePath As String = KPGeneral.StartupPath & "\" & ImageID & ".pdf"

                    If KPGeneral.CreateScannedFileToConvertToPDF(ImageID, FilePath) = True Then
                        Dim fsImage As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
                        Dim bytImageData(fsImage.Length - 1) As Byte
                        fsImage.Read(bytImageData, 0, bytImageData.Length)
                        fsImage.Flush()
                        fsImage.Close()

                        KPGeneral.WebRef_Local.usp_UpdateScanImagePDFFile(ImageID, bytImageData)
                        KPGeneral.DeleteFileByFilePath(FilePath)

                        System.Threading.Thread.Sleep(2000) 'wait for system clean memory

                    End If
                End If
            Next
        End If

        Cursor = Cursors.Default

        RefreshOrders()
    End Sub
    Private Sub GetOrders_MeasuringFiles()
        Cursor = Cursors.WaitCursor
        Try

            Dim ds As DataSet
            'ds = KPGeneral.WebRef_Local.spKP_GetAutomatedLayoutPrintByDate(Now.Date)
            ds = KPGeneral.WebRef_Local.usp_getMeasuringToConvertToPDF

            If ds.Tables(0).Rows.Count > 0 Then
                Me.lbCount.Text = "There are " & ds.Tables(0).Rows.Count & " Measurings left to be converted."
                Dim x As Integer
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    Try
                        If x Mod 30 = 0 AndAlso x > 0 Then
                            System.Threading.Thread.Sleep(20000)
                        End If

                        Dim ImageID As Integer = ds.Tables(0).Rows(x)("MeasuringImageID")

                        If ImageID > 0 Then
                            Dim FilePath As String = KPGeneral.StartupPath & "\" & ImageID & ".pdf"

                            If KPGeneral.CreateMeasuringFileToConvertToPDF(ImageID, FilePath) = True Then
                                Dim fsImage As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
                                Dim bytImageData(fsImage.Length - 1) As Byte
                                fsImage.Read(bytImageData, 0, bytImageData.Length)
                                fsImage.Flush()
                                fsImage.Close()

                                KPGeneral.WebRef_Local.usp_UpdateMeasuringImagePDFFIle(ImageID, bytImageData)
                                KPGeneral.DeleteFileByFilePath(FilePath)

                                System.Threading.Thread.Sleep(10000) 'wait for system clean memory

                            End If
                        End If
                    Catch ex As Exception
                        'just pass the order when crashing
                    End Try
                Next
            End If
        Catch ex As OutOfMemoryException

            System.Threading.Thread.Sleep(60000)

        End Try

        Cursor = Cursors.Default
        RefreshOrders()
    End Sub
    Private Sub GetOrders_ColourCharts()
        Cursor = Cursors.WaitCursor

        Dim ds As DataSet
        'ds = KPGeneral.WebRef_Local.spKP_GetAutomatedLayoutPrintByDate(Now.Date)
        ds = KPGeneral.WebRef_Local.usp_getColourChartToConvertToPDF

        If ds.Tables(0).Rows.Count > 0 Then
            Me.lbCount.Text = "There are " & ds.Tables(0).Rows.Count & " Colour Charts left to be converted."
            Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1

                Dim ImageID As Integer = ds.Tables(0).Rows(x)("CSID")

                If ImageID > 0 Then
                    Dim FilePath As String = KPGeneral.StartupPath & "\" & ImageID & ".pdf"

                    If KPGeneral.CreateColourChartFileToConvertToPDF(ImageID, FilePath) = True Then
                        Dim fsImage As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
                        Dim bytImageData(fsImage.Length - 1) As Byte
                        fsImage.Read(bytImageData, 0, bytImageData.Length)
                        fsImage.Flush() 'clear buffer
                        fsImage.Close()

                        KPGeneral.WebRef_Local.usp_UpdateColourChartImagePDFFIle(ImageID, bytImageData)
                        KPGeneral.DeleteFileByFilePath(FilePath)

                        System.Threading.Thread.Sleep(2000) 'wait for system clean memory

                    End If
                End If
            Next
        End If

        Cursor = Cursors.Default

        RefreshOrders()
    End Sub

    Private Sub frmNeedLayout_Load(sender As Object, e As EventArgs) Handles Me.Load
        KPGeneral.SetDefaultGridSettings(ugOrders)
    End Sub

    Private Sub ugOrders_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugOrders.DoubleClickRow
        If ugOrders.ActiveRow.Index > -1 Then
            Dim ds As DataSet
            ds = KPGeneral.WebRef_Local.spKP_GetAutomatedLayoutPDFByCSID(ugOrders.ActiveRow.Cells("CSID").Text)

            Dim FilePath As String = KPGeneral.GetFileNameByCSIDFileAction(ugOrders.ActiveRow.Cells("CSID").Text, "Layout")

            If ds.Tables(0).Rows.Count > 0 Then
                KPGeneral.OpenFileFromStream(FilePath, ds.Tables(0).Rows(0)("LayoutFile"))

                'Dim ms() As Byte = ds.Tables(0).Rows(0)("LayoutFile")
                'Dim stmBLOBData As New MemoryStream(ms)

                'Dim PdfImage As New BinaryWriter(File.Create(FilePath))
                'PdfImage.Write(ms)
                'PdfImage.Close()
                'KPGeneral.ShellExecuteOpenFile(FilePath)
            End If
        End If
    End Sub

    Private Sub btStart_Click(sender As Object, e As EventArgs) Handles btStart.Click

        Try
            GetOrders()
            GetOrders_MeasuringFiles()
            GetOrders_ScanFiles()
            GetOrders_ColourCharts()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class