Imports System.IO
Imports Infragistics.Win.UltraWinGrid
Imports Syncfusion.Pdf.Parsing

Public Class frmWestonOrders

    Private Sub frmCutlerOrders_Load(sender As Object, e As EventArgs) Handles Me.Load

        KPGeneral.SetDefaultGridSettings(ugOrders)
        Me.ugOrders.DataSource = KPGeneral.WebRef_Local.getOutstandingWestonOrders
        KPGeneral.RefreshGridFromLayout(Me.ugOrders, Me.GetType.Name)
        Me.ugOrders.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.ugOrders.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.ugOrderForEmail.DataSource = KPGeneral.WebRef_Local.usp_get_outstanding_weston_orders_ForEmail
        KPGeneral.RefreshGridFromLayout(Me.ugOrderForEmail, Me.GetType.Name)
        Me.ugOrderForEmail.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.ugOrderForEmail.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.ugRequestedOrder.DataSource = KPGeneral.KPDataSQL.SP_EXEC("t_GetSendSummarytoWestonOrders")
        KPGeneral.RefreshGridFromLayout(Me.ugRequestedOrder, Me.GetType.Name)
        Me.ugRequestedOrder.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.ugRequestedOrder.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.btSendRequestList.Enabled = Me.ugOrderForEmail.Rows.Count > 0
        ug_CounterTopProduction_Received.DataSource = KPGeneral.WebRef_Local.usp_GetWestonReceivedOrders
        KPGeneral.RefreshGridFromLayout(ug_CounterTopProduction_Received, Me.GetType.Name)
        ugRecentlyScanned.DataSource = KPGeneral.WebRef_Local.usp_CounterTopsRecentlyScanned
        ugRecentlyScanned.DisplayLayout.Bands(0).Columns("Company").Width = 200
        ugRecentlyScanned.DisplayLayout.Bands(0).Columns("Project").Width = 250
        ugRecentlyScanned.DisplayLayout.Bands(0).Columns("Lot").Width = 150
        Me.ShowTotalNotOrderedOrder()
        Me.ShowTotalOrderedOrder()
        Me.ShowTotalRequestOrder()

    End Sub

    Private Sub tsmGeneratePDF_Click(sender As Object, e As EventArgs) Handles tsmGeneratePDF.Click

        If Me.ugOrders.Selected.Rows.Count = 0 Then
            MsgBox("Please select at least one order.")
        Else
            Try
                Dim filePath As String = ""
                If Me.FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
                    filePath = Me.FolderBrowserDialog1.SelectedPath
                Else
                    Exit Sub
                End If
                Me.Cursor = Cursors.WaitCursor
                Dim count As Int16 = ugOrders.Selected.Rows.Count - 1
                'Creates a string array of source files to be merged
                'Dim source(count) As String
                For i As Int16 = 0 To count
                    Dim csid As String = Me.ugOrders.Selected.Rows(i).Cells("CSID").Value
                    Dim ds As New DataSet
                    ds.Tables.Add(KPGeneral.WebRef_Local.spKP_LotInfoByCSID(csid).Tables(0).Copy)
                    ds.Tables.Add(KPGeneral.WebRef_Local.spKP_RoomInfo(csid).Tables(0).Copy)
                    ds.Tables.Add(KPGeneral.WebRef_Local.spKPCT_getItemsByCSID(csid).Tables(0).Copy)
                    ds.Tables.Add(KPGeneral.WebRef_Local.spKPCT_getAllItemDetailsByCSID(csid).Tables(0).Copy)
                    Dim FileName As String = filePath + "\" + Me.ugOrders.Selected.Rows(i).Cells("MASTERNUM").Value.ToString + " - Countertops.pdf"
                    'source(i) = csid.ToString + " - Countertops.pdf"
                    Dim rptname As New RptCounterTop_Weston
                    rptname.SetDataSource(ds)
                    rptname.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, FileName)
                    If File.Exists(FileName) = True Then
                        KPGeneral.SaveImage(FileName, Me.ugOrders.Selected.Rows(i).Cells("MasterNum").Value, "SO", Me.ugOrders.Selected.Rows(i).Cells("MasterNum").Value, "PDF")
                    End If
                    KPGeneral.WebRef_Local.spKP_InsertLotComment(csid, KPGeneral.User.UserProfile("UserLoginName"), KPGeneral.User.UserProfile("Department"), "Counter Tops Automatically ordered from Weston.", 16)
                    KPGeneral.WebRef_Local.spKP_InsertAutomatedOrderLog(csid, KPGeneral.User.UserProfile("UserLoginName"), "Weston")
                    KPGeneral.WebRef_Local.setWeston_order_date(csid)
                    Dim x As Integer
                    For x = 1 To 1000000

                    Next
                Next
                Me.ugOrders.DataSource = KPGeneral.WebRef_Local.getOutstandingWestonOrders
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
            End Try
        End If

    End Sub

    Private Sub tsmSendRequestList_Click(sender As Object, e As EventArgs) Handles tsmSendRequestList.Click

        If Me.ugOrderForEmail.Rows.Count > 0 Then
            Me.SendRequestList()
        End If

    End Sub

    Private Sub btSendRequestList_Click(sender As Object, e As EventArgs) Handles btSendRequestList.Click
        Me.SendRequestList()
    End Sub

    Private Sub SendRequestList()

        Try
            If Me.ugOrderForEmail.Selected.Rows.Count = 0 Then
                MsgBox("Please select rows to send.")
                Exit Sub
            End If
            If MsgBox("Are you ready to send the Weston Email?", vbYesNo) = vbYes Then
                Dim EBody, Subject As String
                Me.Cursor = Cursors.WaitCursor
                Subject = "Upcoming Weston Tops Needed"
                EBody = "The following orders are required to be shipped to Frendel no later then the Friday before the earliest SRD shown below. <BR>" &
                    "If you have any questions or concerns please reach out to any of the following contacts.<BR>" &
                    "Slavko – Warehouse Supervisor – SlavkoS@Frendel.com <BR>" &
                    "Arlind – Countertop Lead – ArlindF@Frendel.com <BR>" &
                    "Rob D – VP of Operations – RobertD@Frendel.com <BR>" &
                "<br><br><table border = 1 cellpadding=""10""><tr><td>MasterNum</td><td>OrderPriority</td><td>ThisWeek</td><td>LastWeek</td><td>CTT" &
                "</td><td>CTTF</td><td>CTTW</td><td>CTWR</td><td>Builder</td><td>Project</td><td>Lot</td><td>SRD</td></tr>"
                Me.ugOrderForEmail.Selected.Rows.Sort()
                For Each gr As UltraGridRow In Me.ugOrderForEmail.Selected.Rows
                    Dim MasterNum, ThisWeek, LastWeek, OrderPriority, CTT, CTTF, CTTW, CTWR, builder, project, lot, SRD As String
                    If IsDBNull(gr.Cells("MasterNum").Value) = False Then
                        MasterNum = gr.Cells("MasterNum").Value
                    Else
                        MasterNum = ""
                    End If
                    If IsDBNull(gr.Cells("OrderPriority").Value) = False Then
                        OrderPriority = gr.Cells("OrderPriority").Value
                    Else
                        OrderPriority = ""
                    End If
                    If IsDBNull(gr.Cells("ThisWeek").Value) = False Then
                        ThisWeek = gr.Cells("ThisWeek").Value
                    Else
                        ThisWeek = ""
                    End If
                    If IsDBNull(gr.Cells("LastWeek").Value) = False Then
                        LastWeek = gr.Cells("LastWeek").Value
                    Else
                        LastWeek = ""
                    End If
                    If MasterNum.Length = 0 Then
                        If IsDBNull(gr.Cells("CTop_Total").Value) = False Then
                            CTTW = gr.Cells("CTop_Total").Value
                        Else
                            CTTW = ""
                        End If
                        If IsDBNull(gr.Cells("CTop_Receive").Value) = False Then
                            CTWR = gr.Cells("CTop_Receive").Value
                        Else
                            CTWR = ""
                        End If
                        CTT = ""
                        CTTF = ""
                    Else
                        Dim dt As DataSet = KPGeneral.KPDataSQL.SP_EXEC("t_GetCounterTopsCount", MasterNum)
                        If dt.Tables(0).Rows.Count = 1 Then
                            CTT = dt.Tables(0).Rows(0)(0).ToString
                            CTTF = dt.Tables(1).Rows(0)(0).ToString
                            CTWR = dt.Tables(2).Rows(0)(0).ToString
                            CTTW = dt.Tables(3).Rows(0)(0).ToString
                        Else
                            If IsDBNull(gr.Cells("CTop_Total").Value) = False Then
                                CTTW = gr.Cells("CTop_Total").Value
                            Else
                                CTTW = ""
                            End If
                            If IsDBNull(gr.Cells("CTop_Receive").Value) = False Then
                                CTWR = gr.Cells("CTop_Receive").Value
                            Else
                                CTWR = ""
                            End If
                            CTT = ""
                            CTTF = ""
                        End If
                    End If
                    If IsDBNull(gr.Cells("COMPANY").Value) = False Then
                        builder = gr.Cells("COMPANY").Value
                    Else
                        builder = ""
                    End If
                    If IsDBNull(gr.Cells("project").Value) = False Then
                        project = gr.Cells("project").Value
                    Else
                        project = ""
                    End If
                    If IsDBNull(gr.Cells("LOT").Value) = False Then
                        lot = gr.Cells("LOT").Value
                    Else
                        lot = ""
                    End If
                    If IsDBNull(gr.Cells("SiteRequest").Value) = False Then
                        SRD = gr.Cells("SiteRequest").Value
                    Else
                        SRD = ""
                    End If
                    EBody = EBody & "<tr><td>" & MasterNum & "</td><td>" & OrderPriority & "</td><td>" & ThisWeek & "</td><td>" & LastWeek & "</td><td>" & CTT _
                        & "</td><td>" & CTTF & "</td><td>" & CTTW & "</td><td>" & CTWR & "</td><td>" & builder & "</td><td>" & project & "</td><td>" & lot _
                        & "</td><td>" & SRD & "</td></tr>"
                    'insert order to tblCounterTopEmailRequest
                    KPGeneral.WebRef_Local.usp_InsertCounterTopEmailRequest(MasterNum, IIf(IsNumeric(OrderPriority), OrderPriority, 2))
                    KPGeneral.KPDataSQL.SP_EXEC("t_SendSummarytoWeston", MasterNum)
                Next
                If Not DB.isTestDB Then
                    Dim Message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("ArlindF@frendel.com", "ArlindF@frendel.com")
                    'Message.CC.Add("kevinl@frendel.com")
                    'Message.CC.Add("slavkos@frendel.com")
                    Message.CC.Add("robertd@frendel.com")
                    'Message.CC.Add("samd@frendel.com")
                    'Message.CC.Add("olae@frendel.com")
                    Message.IsBodyHtml = True
                    Message.Subject = Subject
                    Message.Body = EBody
                    Dim SmtpNewClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()
                    SmtpNewClient.Host = "mail.frendel.com"
                    SmtpNewClient.Send(Message)
                End If
            End If
            Me.ugOrderForEmail.DataSource = KPGeneral.WebRef_Local.usp_get_outstanding_weston_orders_ForEmail
            Me.ugRequestedOrder.DataSource = KPGeneral.KPDataSQL.SP_EXEC("t_GetSendSummarytoWestonOrders")
            Me.Cursor = DefaultCursor
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

    End Sub

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click

        Try
            If Me.ugOrderForEmail.Selected.Rows.Count = 0 Then
                MsgBox("Please select rows to export.")
            Else
                Me.Cursor = Cursors.WaitCursor
                With SaveFileDialog1
                    Dim fname As String
                    fname = "Weston Orders - Request List.xlsx"
                    .Reset()
                    .FileName = fname
                    .DefaultExt = "xlsx"
                    .Filter = KPGeneral.ExcelFileFilter
                    Select Case .ShowDialog
                        Case Windows.Forms.DialogResult.OK
                            For Each gr As UltraGridRow In Me.ugOrderForEmail.Rows
                                gr.Hidden = True
                            Next
                            For Each gr As UltraGridRow In Me.ugOrderForEmail.Selected.Rows
                                gr.Hidden = False
                            Next
                            Me.ugOrderForEmail.Selected.Rows.AddRange(CType(Me.ugOrderForEmail.Rows.All, UltraGridRow()))
                            Me.GExporter.Export(Me.ugOrderForEmail, SaveFileDialog1.FileName)
                            For Each gr As UltraGridRow In Me.ugOrderForEmail.Rows
                                gr.Hidden = False
                            Next
                            KPGeneral.oFiles(SaveFileDialog1.FileName)
                            Me.ugOrderForEmail.Selected.Rows.Clear()
                        Case Windows.Forms.DialogResult.Cancel
                            Exit Sub
                    End Select
                End With
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

    End Sub

    Private Sub tsColumnChooser_Click(sender As Object, e As EventArgs) Handles tsColumnChooser.Click
        KPGeneral.ColumnChooser(Me.ugOrderForEmail, Me.GetType.Name)
    End Sub

    Private Sub tsKitchenTracker_Click(sender As Object, e As EventArgs) Handles tsKitchenTracker.Click
        KPGeneral.ViewKitchenTrackerByMasterNum(Me.ugOrderForEmail.ActiveRow.Cells("MASTERNUM").Text)
    End Sub

    Private Sub tsmColumnChooser_Click(sender As Object, e As EventArgs) Handles tsmColumnChooser.Click
        KPGeneral.ColumnChooser(Me.ugOrders, Me.GetType.Name)
    End Sub

    Private Sub tsmKitchenTracker_Click(sender As Object, e As EventArgs) Handles tsmKitchenTracker.Click
        KPGeneral.ViewKitchenTrackerByMasterNum(Me.ugOrders.ActiveRow.Cells("MASTERNUM").Text)
    End Sub

    Private Sub tsSetLocation_Click(sender As Object, e As EventArgs) Handles tsSetLocation.Click

        If ug_CounterTopProduction_Received.Selected.Rows.Count > 0 Then
            Dim iBox As String
            iBox = InputBox("Please enter a location for the selected counter tops.", KPGeneral.ProgramName, "")
            If iBox.Length > 0 Then
                Dim x As Integer
                For x = 0 To ug_CounterTopProduction_Received.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.usp_UpdateCounterTopLocation_ByBarcode(ug_CounterTopProduction_Received.Selected.Rows(x).Cells("barcode").Text, iBox)
                    ug_CounterTopProduction_Received.Selected.Rows(x).Cells("location").Value = iBox
                Next
            End If
        End If

    End Sub

    Private Sub ColumnChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem.Click
        KPGeneral.ColumnChooser(Me.ug_CounterTopProduction_Received, Me.GetType.Name)
    End Sub

    Private Sub txtReceived_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReceived.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            KPGeneral.WebRef_Local.usp_UpdateCounterTopCompleteDate_ByBarcode(txtReceived.Text, "")
            txtReceived.Text = ""
            ug_CounterTopProduction_Received.DataSource = KPGeneral.WebRef_Local.usp_GetWestonReceivedOrders
        End If

    End Sub

    Private Sub ugOrderForEmail_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles ugOrderForEmail.AfterSelectChange

        Dim totalOrders As Int32 = 0
        Dim totalCT As Int32 = 0
        For Each row As UltraGridRow In ugOrderForEmail.Selected.Rows
            totalOrders = totalOrders + 1
            totalCT = totalCT + KPGeneral.KPDataSQL.SP_EXEC("t_GetTotalWestonCT", 0, row.Cells("MASTERNUM").Value).Tables(0).Rows(0)(0)
        Next
        Me.lbSelectedTotalOrderedOrder.Text = "Total Selected Orders: " & totalOrders
        Me.lbSelectedTotalOrderedCT.Text = "Total Weston Countertops: " & totalCT

    End Sub

    Private Sub ugOrderForEmail_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugOrderForEmail.AfterRowFilterChanged
        Me.ShowTotalOrderedOrder()
    End Sub

    Private Sub ugOrders_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugOrders.AfterRowFilterChanged
        Me.ShowTotalNotOrderedOrder()
    End Sub

    Private Sub ugOrders_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles ugOrders.AfterSelectChange

        Dim totalOrders As Int32 = 0
        Dim totalCT As Int32 = 0
        For Each row As UltraGridRow In ugOrders.Selected.Rows
            totalOrders = totalOrders + 1
            totalCT = totalCT + KPGeneral.KPDataSQL.SP_EXEC("t_GetTotalWestonCT", row.Cells("CSID").Value, "").Tables(0).Rows(0)(0)
        Next
        Me.lbSelectedTotalNotOrderedOrder.Text = "Total Selected Orders: " & totalOrders
        Me.lbSelectedNotOrderedCT.Text = "Total Weston Countertops: " & totalCT

    End Sub

    Private Sub ugRequestedOrder_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugRequestedOrder.AfterRowFilterChanged
        Me.ShowTotalRequestOrder()
    End Sub

    Private Sub ugRequestedOrder_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles ugRequestedOrder.AfterSelectChange

        Dim totalOrders As Int32 = 0
        Dim totalCT As Int32 = 0
        For Each row As UltraGridRow In ugRequestedOrder.Selected.Rows
            totalOrders = totalOrders + 1
            totalCT = totalCT + KPGeneral.KPDataSQL.SP_EXEC("t_GetTotalWestonCT", 0, row.Cells("MASTERNUM").Value).Tables(0).Rows(0)(0)
        Next
        Me.lbTotalSelectedReuestOrder.Text = "Total Selected Orders: " & totalOrders
        Me.lbTotalSelectedRequestWestonCT.Text = "Total Selected Weston Countertops: " & totalCT

    End Sub

    Private Sub ShowTotalNotOrderedOrder()

        Dim totalOrders As Int32 = 0
        Dim totalCT As Int32 = 0
        For Each row As UltraGridRow In ugOrders.Rows.GetFilteredInNonGroupByRows
            totalOrders = totalOrders + 1
            totalCT = totalCT + KPGeneral.KPDataSQL.SP_EXEC("t_GetTotalWestonCT", row.Cells("CSID").Value, "").Tables(0).Rows(0)(0)
        Next
        Me.lbTotalNotOrderedOrder.Text = "Total Orders: " & totalOrders
        Me.lbSelectedTotalNotOrderedOrder.Text = "Total Selected Orders: "
        Me.lbTotalNotOrderedCT.Text = "Total Weston Countertops: " & totalCT
        Me.lbSelectedNotOrderedCT.Text = "Total Selected Weston Countertops: "

    End Sub

    Private Sub ShowTotalOrderedOrder()

        Dim totalOrders As Int32 = 0
        Dim totalCT As Int32 = 0
        For Each row As UltraGridRow In ugOrderForEmail.Rows.GetFilteredInNonGroupByRows
            totalOrders = totalOrders + 1
            totalCT = totalCT + KPGeneral.KPDataSQL.SP_EXEC("t_GetTotalWestonCT", 0, row.Cells("MASTERNUM").Value).Tables(0).Rows(0)(0)
        Next
        Me.lbTotalOrderedOrder.Text = "Total Orders: " & totalOrders
        Me.lbSelectedTotalOrderedOrder.Text = "Total Selected Orders: "
        Me.lbTotalOrderedWestonCT.Text = "Total Weston Countertops: " & totalCT
        Me.lbSelectedTotalOrderedCT.Text = "Total Selected Weston Countertops: "

    End Sub

    Private Sub ShowTotalRequestOrder()

        Dim totalOrders As Int32 = 0
        Dim totalCT As Int32 = 0
        For Each row As UltraGridRow In ugRequestedOrder.Rows.GetFilteredInNonGroupByRows
            totalOrders = totalOrders + 1
            totalCT = totalCT + KPGeneral.KPDataSQL.SP_EXEC("t_GetTotalWestonCT", 0, row.Cells("MASTERNUM").Value).Tables(0).Rows(0)(0)
        Next
        Me.lbTotalRequestOrder.Text = "Total Orders: " & totalOrders
        Me.lbTotalSelectedReuestOrder.Text = "Total Selected Orders: "
        Me.lbTotalRequestWestonCT.Text = "Total Weston Countertops: " & totalCT
        Me.lbTotalSelectedRequestWestonCT.Text = "Total Selected Weston Countertops: "

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles tsmKitchenTrack.Click
        KPGeneral.ViewKitchenTrackerByMasterNum(Me.ugRequestedOrder.ActiveRow.Cells("MASTERNUM").Text)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        KPGeneral.ColumnChooser(Me.ugRequestedOrder, Me.GetType.Name)
    End Sub

    Private Sub tsmGeneratePDFOnly_Click(sender As Object, e As EventArgs) Handles tsmGeneratePDFOnly.Click
        Me.GeneratePDF(ugOrderForEmail)
    End Sub

    Private Sub GeneratePDF(ByRef ug As UltraGrid)

        If ug.Selected.Rows.Count = 0 Then
            MsgBox("Please select at least one order.")
        Else
            Try
                Dim filePath As String = ""
                If Me.FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
                    filePath = Me.FolderBrowserDialog1.SelectedPath
                Else
                    Exit Sub
                End If
                Me.Cursor = Cursors.WaitCursor
                For i As Int16 = 0 To ug.Selected.Rows.Count - 1
                    Dim masterNum As String = ug.Selected.Rows(i).Cells("MASTERNUM").Value.ToString
                    Dim dt As DataTable = KPGeneral.KPDataSQL.SP_EXEC("t_GetPDFByMasterNum", masterNum).Tables(0)
                    If dt.Rows.Count = 1 Then
                        Dim FileName As String = filePath + "\" + masterNum + " - Countertops.pdf"
                        Dim ms() As Byte = dt.Rows(0)("FileImage")
                        Dim loadedDocument As New PdfLoadedDocument(ms)
                        loadedDocument.Save(FileName)
                        loadedDocument.Close()
                    End If
                Next
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
            End Try
        End If

    End Sub

    Private Sub tsmGenerateRequestedPDF_Click(sender As Object, e As EventArgs) Handles tsmGenerateRequestedPDF.Click
        Me.GeneratePDF(ugRequestedOrder)
    End Sub

    Private Sub tsmRemoveFromList_Click(sender As Object, e As EventArgs) Handles tsmRemoveFromList.Click

        Try
            For Each gr As UltraGridRow In Me.ugOrderForEmail.Selected.Rows
                KPGeneral.KPDataSQL.SP_EXEC("t_RemoveWestonOrderFromList", gr.Cells("MASTERNUM").Value)
            Next
            Me.ugOrderForEmail.DataSource = KPGeneral.WebRef_Local.usp_get_outstanding_weston_orders_ForEmail
            KPGeneral.RefreshGridFromLayout(Me.ugOrderForEmail, Me.GetType.Name)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class