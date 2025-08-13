Public Class frmDoorListSummary
    Dim dsScanList As New DataSet
    Dim dsStyleColour As New DataSet
    Dim dsbatchdoorlist As New DataSet

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        dgScanList.DataSource = Nothing
        dgScanList.Rows.Clear()
    End Sub

    Private Sub BtnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRun.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer
            Dim Style = Nothing, Colour, Glazing, RefSample, RecessedHardware As String
            KPGeneral.WebRef_Local.spKP_delDoorListStatusSummaryBatch()
            Dim z As Integer
            For z = 0 To dgScanList.Rows.Count - 1
                KPGeneral.WebRef_Local.spKP_InsertDoorListStatusSummaryBatch(dgScanList.Rows(z).Cells(0).Value)
            Next
            Dim dsstylecoloursummary As New DataSet
            dsstylecoloursummary = KPGeneral.WebRef_Local.spKPBatch_GetStylesOrderListDoorListStatusSummaryBatch()

            filldsBatchDoorList()

            If Not chkStyleOnly.Checked Then

                For i = 0 To dsstylecoloursummary.Tables(0).Rows.Count - 1
                    If IsDBNull(dsstylecoloursummary.Tables(0).Rows(i)("Style")) Then
                        Style = ""
                    Else
                        Style = dsstylecoloursummary.Tables(0).Rows(i)("Style")
                    End If

                    If IsDBNull(dsstylecoloursummary.Tables(0).Rows(i)("Colour")) Then
                        Colour = ""
                    Else
                        Colour = dsstylecoloursummary.Tables(0).Rows(i)("Colour")
                    End If

                    If IsDBNull(dsstylecoloursummary.Tables(0).Rows(i)("Glazing")) Then
                        Glazing = ""
                    Else
                        Glazing = dsstylecoloursummary.Tables(0).Rows(i)("Glazing")
                    End If
                    RefSample = dsstylecoloursummary.Tables(0).Rows(i)("RefSample")
                    RecessedHardware = dsstylecoloursummary.Tables(0).Rows(i)("RecessedHardware")

                    ' Print Door Summary?
                    PrintDoorSummary(Style, Colour, Glazing, RefSample, RecessedHardware, Nothing)
                    ' Print Door Orders?
                    'PrintDoorList(Style, Colour, Glazing, RefSample, Nothing)
                    ' Update progress bar
                    'ProgressBar.Value = ProgressBar.Value + 1
                Next
            End If

            ' Print Door Style?
            If chkStyleOnly.Checked Then PrintDoorSummaryStyleBatch()

            'ProgressBar.Value = 0
            dsScanList.Clear()
            dgScanList.DataSource = Nothing

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub FKNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FKNo.KeyPress
        Try
            Dim i As Integer
            Dim summary As String = ""
            Dim DoorListSummaryID As Integer
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                e.Handled = True
                'Enter Pressed
                Me.Cursor = Cursors.WaitCursor
                'If UcWebStatus1.WebServFound(Me) = True Then

                Dim barcode As String
                barcode = FKNo.Text

                If FKNo.Text.StartsWith("DL") Then
                    Dim dBarcode As New DataSet
                    dBarcode = KPGeneral.WebRef_Local.spKPFactory_VerifyDoorListSumID(barcode.Remove(0, barcode.LastIndexOf("-") + 1))
                    If dBarcode.Tables.Count > 0 Then
                        DoorListSummaryID = dBarcode.Tables(0).Rows(0)("SumID")
                        barcode = dBarcode.Tables(0).Rows(0)("Barcode")
                    Else
                        DoorListSummaryID = 0
                    End If
                Else
                    DoorListSummaryID = KPGeneral.WebRef_Local.spKPFactory_VerifyDoorListBarcodeGetSummaryID(FKNo.Text) 'WebService
                End If

                If DoorListSummaryID > 0 Then
                    summary = Strings.UCase(barcode)
                    'Cancelled Order (Rich Added - 09/06/06)
                    Dim dsCancelOrderCheck As New DataSet
                    dsCancelOrderCheck = KPGeneral.WebRef_Local.spKP_LotInfoByFK(KPGeneral.ExtractMasterNum(Trim(barcode)).Replace("S", "F"))
                    If dsCancelOrderCheck.Tables(0).Rows.Count > 0 Then
                        If dsCancelOrderCheck.Tables(0).Rows(0)("CancelOrder") = True Then
                            MessageBox.Show("Order Cancelled!")
                            'myWav.WinWav.PlayWavResource("warning.wav")
                            'voice.Speak("Order Cancelled")
                            FKNo.Text = vbNullString
                            FKNo.Focus()
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Else
                        'myWav.WinWav.PlayWavResource("warning.wav")
                        MessageBox.Show(summary + " is not a VALID Input")
                        Me.Cursor = Cursors.Default
                        FKNo.Text = vbNullString
                        FKNo.Focus()
                        Exit Sub
                    End If
                    'End Cancelled Order
                    'Door Scanned Warning

                    ' [global].WebRef_KPFactory.spKPFactory_RawDoors_UpdateScan_AddWarehouse([global].SessionID, Now, txtBarcode.Text)

                    ' Lookup duplicate scan
                    For i = 0 To dgScanList.Rows.Count - 1

                        If dgScanList.Rows(i).Cells(1).Value.ToString.ToUpper = barcode.ToUpper Then
                            MsgBox("The barcode is already in the list")
                            FKNo.Text = vbNullString
                            FKNo.Focus()
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Next

                    ' If no duplicate exists then add it.
                    dgScanList.Rows.Add(DoorListSummaryID, barcode)

                End If

                FKNo.Text = vbNullString
                FKNo.Focus()

            End If
            'End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

 
    Private Sub filldsBatchDoorList()
        Try
            Dim dsDDR As New DataSet
            Dim tempDS As New DataSet
            Dim dr As DataRow
            ' =================================
            Dim dtDDR As New DataTable
            Dim dtDrawerDrawerList As New DataTable("spKP_GetDoorDrawerList")
            Dim dtSpecialDoor As New DataTable("SpecialDoor")
            Dim dtSpecialDrawer As New DataTable("SpecialDrawer")
            Dim dtSpecialDoorCuts As New DataTable("spKP_getDoorDrawerListSpecialDoorCuts")
            Dim dtRoomInfo As New DataTable("MNRoomInfo")

            dsDDR.Tables.Add(dtDrawerDrawerList)
            dsDDR.Tables.Add(dtSpecialDoor)
            dsDDR.Tables.Add(dtSpecialDrawer)
            dsDDR.Tables.Add(dtSpecialDoorCuts)
            dsDDR.Tables.Add(dtRoomInfo)
            ' =================================
            ' Get the start and end week
            tempDS.Tables.Add()
            tempDS.Tables(0).Columns.Add("FDate", System.Type.GetType("System.DateTime"))
            tempDS.Tables(0).Columns.Add("TDate", System.Type.GetType("System.DateTime"))
            tempDS.Tables(0).Columns.Add("PO", System.Type.GetType("System.String"))
            dr = tempDS.Tables(0).NewRow
            dr.Item(0) = Now.Date
            dr.Item(1) = Now.Date
            tempDS.Tables(0).Rows.Add(dr)
            ' Get Door Drawer List Main
            ' ========================================================
            Dim rsDoor As New DataSet
            rsDoor = KPGeneral.WebRef_Local.spKPBatch_GetDoorDrawerListDoorSummaryBySummaryId()
            tempDS.Tables.Add(rsDoor.Tables(0).Copy)
            'tempDS.Tables(0).Rows(0)("PO") = rsDoor.Tables(0).Rows(0)("OrderRefNo")
            tempDS.Tables(0).Rows(0)("PO") = ""
            ' Get Special Door Sizes
            ' ========================================================
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_getDoorDrawerListSpecialCutImage3().Tables(0).Copy)
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_getDoorDrawerListSpecialCutImageData3().Tables(0).Copy)
            ' Get All Room Info 
            ' ========================================================
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_GetRoomInfo3().Tables(0).Copy)
            ' Create the xml file /// pass to ds
            tempDS.Tables("RoomInfo").TableName = "MNRoomInfo"
            tempDS.Tables.Add(dtDDR)
            dsbatchdoorlist.Tables.Clear()
            dsbatchdoorlist = tempDS.Copy
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub PrintDoorSummary(ByVal Style As String, ByVal Colour As String, ByVal Glazing As String, ByVal RefSample As String, RecessedHardware As Boolean, ByVal PrinterName As String)
        Try
            Dim RptDoc As New RptBatchDoorListStyleColourDoorListJoin 'RptDoorlistSummary
            RptDoc.SetDataSource(dsbatchdoorlist)
            RptDoc.SetParameterValue("ParameterMatch", RefSample & Style & Colour & Glazing & RecessedHardware)

            Dim rpt As New RptViewer(1, RptDoc)
            rpt.ShowDialog()
            rpt.Close()
            rpt.Dispose()

            'RptDoc.PrintOptions.PaperSource = CrystalDecisions.[Shared].PaperSource.Auto
            'RptDoc.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
            'RptDoc.Close()
            'RptDoc.Dispose()

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub PrintDoorSummaryPanelSaw(ByVal Style As String, ByVal Colour As String, ByVal Glazing As String, ByVal RefSample As String, RecessedHardware As Boolean, ByVal PrinterName As String)
        Try
            Dim tx As String
            Dim RptDoc As New RptBatchDoorListStyleColourSummaryPanelSaw 'RptDoorlistSummary
            RptDoc.SetDataSource(dsbatchdoorlist)
            RptDoc.SetParameterValue("ParameterMatch", RefSample & Style & Colour & Glazing & RecessedHardware)

            'Dim rpt As New RptViewer(1, RptDoc)
            'rpt.ShowDialog()
            'rpt.Close()
            'rpt.Dispose()

            RptDoc.PrintOptions.PaperSource = CrystalDecisions.[Shared].PaperSource.Auto
            RptDoc.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
            RptDoc.Close()
            RptDoc.Dispose()

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub PrintDoorSummaryStyleBatch()
        Try
            Dim RptDoc As New RptBatchDoorListStyleSummaryBatch 'RptDoorlistSummary
            RptDoc.SetDataSource(dsbatchdoorlist)

            Dim rpt As New RptViewer(1, RptDoc)
            rpt.ShowDialog()
            rpt.Close()
            rpt.Dispose()

            'RptDoc.PrintOptions.PaperSource = CrystalDecisions.[Shared].PaperSource.Auto
            'RptDoc.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
            'RptDoc.Close()
            'RptDoc.Dispose()

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub PrintDoorsStyleSummary(ByVal Style As String, ByVal PrinterName As String)
        Try
            Dim RptDoc As New RptBatchDoorListStyle 'RptDoorlistSummaryStyle
            RptDoc.SetDataSource(dsbatchdoorlist)
            RptDoc.PrintOptions.PaperSource = CrystalDecisions.[Shared].PaperSource.Auto
            RptDoc.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
            RptDoc.Close()
            RptDoc.Dispose()


        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub PrintDoorList(ByVal Style As String, ByVal Colour As String, ByVal Glazing As String, ByVal RefSample As String, ByVal PrinterName As String)
        Dim dsDDR As DataSet
        Dim tempDS As New DataSet
        Try
            ' Get Door Drawer List Main
            ' ========================================================
            dsDDR = New DataSet
            dsDDR = KPGeneral.WebRef_Local.spKPBatch_getSortDoorDrawerList2(Style, Colour, Glazing)
            tempDS.Tables.Add(dsDDR.Tables(0).Copy)
            dsDDR.Dispose()
            dsDDR = New DataSet
            dsDDR = KPGeneral.WebRef_Local.spKPBatch_getSortDoorDrawerListSpecialCutImage2(Style, Colour, Glazing)
            tempDS.Tables.Add(dsDDR.Tables(0).Copy)
            dsDDR.Dispose()
            ' Get Room Info
            ' ========================================================
            Dim dsRoomInfo As New DataSet
            dsRoomInfo = KPGeneral.WebRef_Local.spKPBatch_getSortRoomInfo2(Style, Colour, Glazing)
            tempDS.Tables.Add(dsRoomInfo.Tables(0).Copy)
            Dim dt As New DataTable
            Dim dr As DataRow
            dt.Columns.Add("SKNo", System.Type.GetType("System.String"))
            dt.Columns.Add("PONo", System.Type.GetType("System.String"))
            dr = dt.NewRow
            dr(0) = DBNull.Value
            If tempDS.Tables(0).Rows.Count > 0 Then
                dr(1) = ""
            End If
            dt.Rows.Add(dr)
            tempDS.Tables.Add(dt.Copy)
            ' Create the xml file

            Dim RptDoc As New RptBatchDoorList
            RptDoc.SetDataSource(tempDS)
            RptDoc.PrintOptions.PaperSource = CrystalDecisions.[Shared].PaperSource.Auto
            RptDoc.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
            RptDoc.Close()
            RptDoc.Dispose()

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer
            Dim Style = Nothing, Colour, Glazing, RefSample, RecessedHardware As String
            KPGeneral.WebRef_Local.spKP_delDoorListStatusSummaryBatch()
            Dim z As Integer
            For z = 0 To ugAdvancedSearch.Rows.Count - 1
                If ugAdvancedSearch.Rows(z).IsFilteredOut = False Then
                    KPGeneral.WebRef_Local.spKP_InsertDoorListStatusSummaryBatch(ugAdvancedSearch.Rows(z).Cells("SumID").Value)
                End If
            Next
            Dim dsstylecoloursummary As New DataSet

            If chkPanelSaw.Checked Then
                dsstylecoloursummary = KPGeneral.WebRef_Local.spKPBatch_GetStylesOrderListDoorListStatusSummaryPanelSaw()
            Else
                dsstylecoloursummary = KPGeneral.WebRef_Local.spKPBatch_GetStylesOrderListDoorListStatusSummaryBatch()
            End If


            filldsBatchDoorList()

            If Not chkStyleOnly.Checked And Not chkPanelSaw.Checked Then

                For i = 0 To dsstylecoloursummary.Tables(0).Rows.Count - 1
                    If IsDBNull(dsstylecoloursummary.Tables(0).Rows(i)("Style")) Then
                        Style = ""
                    Else
                        Style = dsstylecoloursummary.Tables(0).Rows(i)("Style")
                    End If

                    If IsDBNull(dsstylecoloursummary.Tables(0).Rows(i)("Colour")) Then
                        Colour = ""
                    Else
                        Colour = dsstylecoloursummary.Tables(0).Rows(i)("Colour")
                    End If

                    If IsDBNull(dsstylecoloursummary.Tables(0).Rows(i)("Glazing")) Then
                        Glazing = ""
                    Else
                        Glazing = dsstylecoloursummary.Tables(0).Rows(i)("Glazing")
                    End If
                    RefSample = dsstylecoloursummary.Tables(0).Rows(i)("RefSample")
                    RecessedHardware = dsstylecoloursummary.Tables(0).Rows(i)("RecessedHardware")

                    ' Print Door Summary?
                    PrintDoorSummary(Style, Colour, Glazing, RefSample, RecessedHardware, Nothing)
                    ' Print Door Orders?
                    'PrintDoorList(Style, Colour, Glazing, RefSample, Nothing)
                    ' Update progress bar
                    'ProgressBar.Value = ProgressBar.Value + 1
                Next

            ElseIf chkPanelSaw.Checked Then
                'if panel saw then ignore recessed hardware

                For i = 0 To dsstylecoloursummary.Tables(0).Rows.Count - 1


                    If IsDBNull(dsstylecoloursummary.Tables(0).Rows(i)("Style")) Then
                        Style = ""
                    Else
                        Style = dsstylecoloursummary.Tables(0).Rows(i)("Style")
                        If Style.ToString.ToUpper.Contains("SLAB") Then Style = "SLAB"
                    End If

                    If IsDBNull(dsstylecoloursummary.Tables(0).Rows(i)("Colour")) Then
                        Colour = ""
                    Else
                        Colour = dsstylecoloursummary.Tables(0).Rows(i)("Colour")
                    End If

                    If IsDBNull(dsstylecoloursummary.Tables(0).Rows(i)("Glazing")) Then
                        Glazing = ""
                    Else
                        Glazing = dsstylecoloursummary.Tables(0).Rows(i)("Glazing")
                    End If
                    RefSample = dsstylecoloursummary.Tables(0).Rows(i)("RefSample")

                    RecessedHardware = False
                    ' Print Door Summary?
                    PrintDoorSummaryPanelSaw(Style, Colour, Glazing, RefSample, RecessedHardware, Nothing)
                    ' Print Door Orders?
                    'PrintDoorList(Style, Colour, Glazing, RefSample, Nothing)
                    ' Update progress bar
                    'ProgressBar.Value = ProgressBar.Value + 1
                Next

            End If

            ' Print Door Style?
            If chkStyleOnlyAdvanced.Checked Then PrintDoorSummaryStyleBatch()

            'ProgressBar.Value = 0
            dsScanList.Clear()
            dgScanList.DataSource = Nothing

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        RefreshAdvancedSearch()
    End Sub
    Private Sub ResetFiltersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetFiltersToolStripMenuItem.Click
        Dim band As Infragistics.Win.UltraWinGrid.UltraGridBand
        For Each band In ugAdvancedSearch.DisplayLayout.Bands
            ' since all rows in a band have the same filters in RowFilterMode.AllRowsInBand this
            ' will clear the filters
            band.ColumnFilters.ClearAllFilters()
        Next
    End Sub
    Private Sub RefreshAdvancedSearch()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetDoorListAdvancedSearch()

        ugAdvancedSearch.DataSource = ds

        If ugAdvancedSearch.DisplayLayout.Bands(0).Columns.Count > 0 Then
            ugAdvancedSearch.DisplayLayout.Bands(0).Columns("Company").Width = 200
            ugAdvancedSearch.DisplayLayout.Bands(0).Columns("Project").Width = 250
            ugAdvancedSearch.DisplayLayout.Bands(0).Columns("Lot").Width = 200
            ugAdvancedSearch.DisplayLayout.Bands(0).Columns("Style").Width = 200
            ugAdvancedSearch.DisplayLayout.Bands(0).Columns("Colour").Width = 200
            ugAdvancedSearch.DisplayLayout.Bands(0).Columns("SumID").Hidden = True
        End If
    End Sub
    Private Sub frmDoorListSummary_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshAdvancedSearch()

        KPGeneral.SetDefaultGridSettings(ugAdvancedSearch)
    End Sub
End Class
