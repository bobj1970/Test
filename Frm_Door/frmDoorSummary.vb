Public Class frmDoorSummary
    Dim dsScanList As New DataSet
    Dim dsStyleColour As New DataSet
    Dim dsbatchdoorlist As New DataSet

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        dsScanList.Clear()
        dgScanList.DataSource = Nothing
    End Sub

    Private Sub BtnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRun.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim i As Integer
            Dim Style = Nothing, Colour, Glazing, RefSample As String
            KPGeneral.WebRef_Local.spKP_delBatchDoorSummary()
            Dim z As Integer
            For z = 0 To dgScanList.Rows.Count - 1
                KPGeneral.WebRef_Local.spKP_InsertBatchDoorSummary(dgScanList.Rows(z).Cells("CSID").Text)
            Next
            Dim dsstylecoloursummary As New DataSet
            dsstylecoloursummary = KPGeneral.WebRef_Local.spKPBatch_GetStylesOrderListDoorSummary()

            filldsBatchDoorList()

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
                ' Print Door Summary?
                'PrintDoorSummary(Style, Colour, Glazing, RefSample, Nothing)
                ' Print Door Orders?
                'PrintDoorList(Style, Colour, Glazing, RefSample, Nothing)
                ' Update progress bar
                'ProgressBar.Value = ProgressBar.Value + 1
            Next
            ' Print Door Style?
            PrintDoorsStyleSummary(Style, Nothing)
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
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                Dim ds As New DataSet
                Dim dr As DataRow

                FKNo.Text = KPGeneral.ParseBarcode(FKNo.Text)

                ds = KPGeneral.WebRef_Local.spKP_LotInfoByFK(FKNo.Text)

                Dim addFlag As Boolean = True
                If ds.Tables(0).Rows.Count = 0 Then
                    addFlag = False
                End If
                Dim x As Integer
                For x = 0 To dgScanList.Rows.Count - 1
                    If dgScanList.Rows(x).Cells("MASTERNUM").Text = FKNo.Text Then
                        addFlag = False
                        Exit For
                    End If
                Next

                If addFlag = True And IsDBNull(ds.Tables(0).Rows(0)("Shipped")) = False Then
                    If dsScanList.Tables.Count = 0 Then
                        dsScanList.Tables.Add()
                        dsScanList.Tables(0).Columns.Add("CSID")
                        dsScanList.Tables(0).Columns.Add("OrderRefNo")
                        dsScanList.Tables(0).Columns.Add("HasPO")
                        dsScanList.Tables(0).Columns.Add("Company")
                        dsScanList.Tables(0).Columns.Add("Project")
                        dsScanList.Tables(0).Columns.Add("Lot")
                        dsScanList.Tables(0).Columns.Add("PHASE")
                        dsScanList.Tables(0).Columns.Add("MASTERNUM")
                        dsScanList.Tables(0).Columns.Add("ProductionR")
                        dsScanList.Tables(0).Columns.Add("BatchScan")
                    End If
                    dr = dsScanList.Tables(0).NewRow
                    dr.Item("CSID") = ds.Tables(0).Rows(0)("CSID")
                    dr.Item("OrderRefNo") = ds.Tables(0).Rows(0)("OrderRefNo")

                    If IsDBNull(ds.Tables(0).Rows(0)("OrderRefNo")) = False Then
                        dr.Item("HasPO") = True
                    Else
                        dr.Item("HasPO") = False
                    End If
                    dr.Item("Company") = ds.Tables(0).Rows(0)("COMPANY")
                    dr.Item("Project") = ds.Tables(0).Rows(0)("PROJECT")
                    dr.Item("Lot") = ds.Tables(0).Rows(0)("LOT")
                    If IsDBNull(ds.Tables(0).Rows(0)("PHASE")) = False Then
                        dr.Item("Phase") = ds.Tables(0).Rows(0)("PHASE")
                    Else
                        dr.Item("Phase") = ""
                    End If
                    If IsDBNull(ds.Tables(0).Rows(0)("MASTERNUM")) = False Then
                        dr.Item("Masternum") = ds.Tables(0).Rows(0)("MASTERNUM")
                    Else
                        dr.Item("Masternum") = ""
                    End If
                    If IsDBNull(ds.Tables(0).Rows(0)("ProductionR")) = False Then
                        dr.Item("ProductionR") = ds.Tables(0).Rows(0)("ProductionR")
                    Else
                        dr.Item("ProductionR") = DBNull.Value
                    End If
                    If IsDBNull(ds.Tables(0).Rows(0)("BatchScan")) = False Then
                        dr.Item("BatchScan") = ds.Tables(0).Rows(0)("BatchScan")
                    Else
                        dr.Item("BatchScan") = Now.Date
                    End If

                    dsScanList.Tables(0).Rows.Add(dr)
                    dgScanList.DataSource = dsScanList
                    dgScanList.Rows(dgScanList.Rows.Count - 1).Activate()
                    'loadTabInfo(eTab.SelectedTab.Text)
                Else
                    MsgBox("This Order is NOT Schedule Yet OR already on the list !!", MsgBoxStyle.Information, "KP Vault")
                End If
                FKNo.Text = Nothing
                StyleList()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP Vault")
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub frmDoorSummary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dsStyleColour.Tables.Add()
        dsStyleColour.Tables(0).Columns.Add("Style")
        dsStyleColour.Tables(0).Columns.Add("Colour")
        dsStyleColour.Tables(0).Columns.Add("Glazing")
        dsStyleColour.Tables(0).Columns.Add("RefSample")

        KPGeneral.SetDefaultGridSettings(dgScanList)
    End Sub
    Private Sub StyleList()
        dgScanList.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        dgScanList.DisplayLayout.Bands(0).Columns("OrderRefNo").Hidden = True
        dgScanList.DisplayLayout.Bands(0).Columns("HasPO").Hidden = True
        dgScanList.DisplayLayout.Bands(0).Columns("Company").Hidden = False
        dgScanList.DisplayLayout.Bands(0).Columns("Project").Hidden = False
        dgScanList.DisplayLayout.Bands(0).Columns("Lot").Hidden = False
        dgScanList.DisplayLayout.Bands(0).Columns("Phase").Hidden = False
        dgScanList.DisplayLayout.Bands(0).Columns("MasterNum").Hidden = False
        dgScanList.DisplayLayout.Bands(0).Columns("ProductionR").Hidden = True
        dgScanList.DisplayLayout.Bands(0).Columns("BatchScan").Hidden = True

        dgScanList.DisplayLayout.Bands(0).Columns("MasterNum").Header.VisiblePosition = 0
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
            rsDoor = KPGeneral.WebRef_Local.spKPBatch_GetDoorDrawerListDoorSummary()
            tempDS.Tables.Add(rsDoor.Tables(0).Copy)
            'tempDS.Tables(0).Rows(0)("PO") = rsDoor.Tables(0).Rows(0)("OrderRefNo")
            tempDS.Tables(0).Rows(0)("PO") = ""
            ' Get Special Door Sizes
            ' ========================================================
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_getDoorDrawerListSpecialCutImage2().Tables(0).Copy)
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_getDoorDrawerListSpecialCutImageData2().Tables(0).Copy)
            ' Get All Room Info 
            ' ========================================================
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_GetRoomInfo2().Tables(0).Copy)
            ' Create the xml file /// pass to ds
            tempDS.Tables("RoomInfo").TableName = "MNRoomInfo"
            tempDS.Tables.Add(dtDDR)
            dsBatchDoorList.Tables.Clear()
            dsBatchDoorList = tempDS.Copy
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub PrintDoorSummary(ByVal Style As String, ByVal Colour As String, ByVal Glazing As String, ByVal RefSample As String, ByVal PrinterName As String)
        Try
            Dim tx As String
            Dim RptDoc As New RptBatchDoorListStyleColour 'RptDoorlistSummary
            RptDoc.SetDataSource(dsbatchdoorlist)
            RptDoc.SetParameterValue("ParameterMatch", RefSample & Style & Colour & Glazing)
            RptDoc.PrintOptions.PaperSource = CrystalDecisions.[Shared].PaperSource.Auto
            RptDoc.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
            RptDoc.Close()
            RptDoc.Dispose()

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

    Private Sub DeleteSelectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSelectedToolStripMenuItem.Click
        If dgScanList.ActiveRow.Index > -1 Then
            dsScanList.Tables(0).Rows(dgScanList.ActiveRow.Index).Delete()
            dgScanList.DataSource = dsScanList
        End If
    End Sub

End Class