Imports Infragistics.Win.UltraWinGrid
Public Class frmOrdersPicked
    Dim T As Integer
    Public Shared PickerID As String
    Public Shared PartsDelayID As Integer
    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If Trim(txtBarcode.Text) = Nothing Then
                lblMessage.Text = Nothing
                Exit Sub
            End If

            txtBarcode.Enabled = False
            btnBase.Visible = True
            btnUpper.Visible = True
            btnCancel.Visible = True

        End If
    End Sub
    Private Sub ResetItems()
        txtBarcode.Text = ""
        txtBarcode.Enabled = True
        btnBase.Visible = False
        btnUpper.Visible = False
        btnCancel.Visible = False
    End Sub
    Private Sub ScanOrderPicked(ByVal Upper As Boolean)

        Try
            PartsDelayID = 0

            Dim ds As DataSet
            ds = KPGeneral.WebRef_Local.spKP_LotInfoByFK(Trim(txtBarcode.Text))

            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0)("CancelOrder") = True Then
                    lblMessage.Text = "Order Cancelled!"
                    Exit Sub
                End If
                lblMessage.Text = Nothing
                PickerID = ""
                Dim PickingWorkers As New frmPickingWorkers
                PickingWorkers.ShowDialog()
                If PickerID.Trim.Length = 0 Then
                    MsgBox("No picker was selected.  Please select a valid picker from the window.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                    Exit Sub
                End If
                Dim DoorEmployee As String
                DoorEmployee = PickerID.Trim

                If IsDBNull(ds.Tables(0).Rows(0)("OrderStatus")) = False Then
                    If Trim(ds.Tables(0).Rows(0)("OrderStatus")) = "Pending" Then
                        lblMessage.Text = ds.Tables(0).Rows(0)("Masternum") & "Order Pending!"
                        MessageBox.Show("Please hold the last order you scanned. Please Contact your supervisor/manager to resolve the PENDING status of the last Order.")
                    End If
                End If

                Dim PGroupSet As Boolean = False

                If IsDBNull(ds.Tables(0).Rows(0)("isDealer")) = False Then
                    If ds.Tables(0).Rows(0)("isDealer") = False Then
                        If ds.Tables(0).Rows(0)("COMPANY") <> "Frendel Kitchen & Bath Design Studio Inc." Then
                            PGroupSet = True
                        End If
                    End If
                End If

                If IsDBNull(ds.Tables(0).Rows(0)("AssemblyStartDate")) = False Then
                    Dim ReDidPartsDelay As Boolean = False

                    If PartsDelayID > 0 Then
                        SetDelay(ds.Tables(0).Rows(0)("CSID"), Upper)
                        ReDidPartsDelay = True
                    End If

                    If KPGeneral.WebRef_Local.spKPFactory_OrderPicked(Upper, ds.Tables(0).Rows(0)("CSID"), DoorEmployee) = False Then
                        If ReDidPartsDelay = False Then
                            If Upper = True Then
                                lblMessage.Text = "Upper Already Scanned!"
                            Else
                                lblMessage.Text = "Base Already Scanned!"
                            End If
                        End If
                    Else
                        RefreshOrdersPicked()
                        ResetItems()
                    End If
                Else
                    MsgBox("Assembly not started yet.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                End If
            Else
                lblMessage.Text = "Input is not a VALID FK-NUMBER"
                ResetItems()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub RefreshOrdersPicked()

        Try
            Dim dsOrdersPicked As New DataSet
            dsOrdersPicked = KPGeneral.WebRef_Local.usp_GetOrdersPickedToday
            dsOrdersPicked.Tables(0).Columns.Add("PickedComplete")
            ugOrdersPicked.DataSource = dsOrdersPicked
            ugOrdersPicked.DisplayLayout.Bands(0).Columns("PickedUppers").Format = KPGeneral.DateTime12HourFormatString
            ugOrdersPicked.DisplayLayout.Bands(0).Columns("PickedBases").Format = KPGeneral.DateTime12HourFormatString
            ugOrdersPicked.DisplayLayout.Bands(0).Columns("PickedBases").Width = 200
            ugOrdersPicked.DisplayLayout.Bands(0).Columns("PickedUppers").Width = 200
            ugOrdersPicked.DisplayLayout.Bands(0).Columns("Company").Width = 200
            ugOrdersPicked.DisplayLayout.Bands(0).Columns("Project").Width = 200
            ugOrdersPicked.DisplayLayout.Bands(0).Columns("PBE").Width = 75
            ugOrdersPicked.DisplayLayout.Bands(0).Columns("PUE").Width = 75

            ugOrdersPicked.DisplayLayout.Bands(0).Columns("CSID").Hidden = True

            Dim x As Integer
            For x = 0 To ugOrdersPicked.Rows.Count - 1
                ColourRow(ugOrdersPicked, x)
            Next

            txtOrderCount.Text = ugOrdersPicked.Rows.Count

            ugOrdersPicked.ActiveRow = Nothing
            ugOrdersPicked.Selected.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub frmOrdersPicked_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            ResetItems()
            RefreshOrdersPicked()
            KPGeneral.SetDefaultGridSettings(ugOrdersPicked)
            ugOrdersPicked.ActiveRow = Nothing
            ugOrdersPicked.Selected.Rows.Clear()
            EmployeePerformanceForBasePickerToolStripMenuItem.Visible = KPGeneral.User.UserProfile("ShopEmployeePerformanceTracker")
            EmployeePerformanceForUpperPickerToolStripMenuItem.Visible = KPGeneral.User.UserProfile("ShopEmployeePerformanceTracker")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ResetItems()
    End Sub
    Private Sub btnBase_Click(sender As Object, e As EventArgs) Handles btnBase.Click
        ScanOrderPicked(False)
    End Sub
    Private Sub btnUpper_Click(sender As Object, e As EventArgs) Handles btnUpper.Click
        ScanOrderPicked(True)
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            T = T + 1
            If T > 300 Then
                RefreshOrdersPicked()
                T = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Timer1.Stop()
        End Try

    End Sub
    Private Sub ColourRow(ByVal uGrid As UltraGrid, ByVal RowIndex As Integer)
        Dim dsDelayPartInfo As New DataSet
        dsDelayPartInfo = KPGeneral.WebRef_Local.usp_GetDelayDueToPartsByCSID(uGrid.Rows(RowIndex).Cells("CSID").Text)

        If dsDelayPartInfo.Tables(0).Rows.Count > 0 Then
            If IsDBNull(dsDelayPartInfo.Tables(0).Rows(0)("DelayPartsBase")) = False Then
                If dsDelayPartInfo.Tables(0).Rows(0)("DelayPartsBase") = True Then
                    uGrid.Rows(RowIndex).Cells("PickedBases").Appearance.BackColor = Color.Khaki
                    uGrid.Rows(RowIndex).Cells("PickedBases").Appearance.ForeColor = Color.Black
                Else
                    uGrid.Rows(RowIndex).Cells("PickedBases").Appearance.BackColor = Color.White
                    uGrid.Rows(RowIndex).Cells("PickedBases").Appearance.ForeColor = Color.Black
                End If
            Else
                uGrid.Rows(RowIndex).Cells("PickedBases").Appearance.BackColor = Color.White
                uGrid.Rows(RowIndex).Cells("PickedBases").Appearance.ForeColor = Color.Black
            End If

            If IsDBNull(dsDelayPartInfo.Tables(0).Rows(0)("DelayPartsUpper")) = False Then
                If dsDelayPartInfo.Tables(0).Rows(0)("DelayPartsUpper") = True Then
                    uGrid.Rows(RowIndex).Cells("PickedUppers").Appearance.BackColor = Color.Khaki
                    uGrid.Rows(RowIndex).Cells("PickedUppers").Appearance.ForeColor = Color.Black
                Else
                    uGrid.Rows(RowIndex).Cells("PickedUppers").Appearance.BackColor = Color.White
                    uGrid.Rows(RowIndex).Cells("PickedUppers").Appearance.ForeColor = Color.Black
                End If
            Else
                uGrid.Rows(RowIndex).Cells("PickedUppers").Appearance.BackColor = Color.White
                uGrid.Rows(RowIndex).Cells("PickedUppers").Appearance.ForeColor = Color.Black
            End If
        End If

        Dim isBaseNull As Boolean = False
        Dim isUpperNull As Boolean = False
        Dim isComplete As Boolean = False

        If IsDBNull(uGrid.Rows(RowIndex).Cells("PickedUppers").Value) = True Then
            isUpperNull = True
        End If
        If IsDBNull(uGrid.Rows(RowIndex).Cells("PickedBases").Value) = True Then
            isBaseNull = True
        End If

        If isBaseNull = False And isUpperNull = False Then
            isComplete = True
        End If

        If isComplete = False Then
            uGrid.Rows(RowIndex).Cells("PickedComplete").Appearance.BackColor = Color.Red
        Else
            uGrid.Rows(RowIndex).Cells("PickedComplete").Appearance.BackColor = Color.Green
        End If
    End Sub
    Private Sub SetDelay(ByVal CSID As Integer, ByVal isUpper As Boolean)
        KPGeneral.WebRef_Local.usp_SetDelayDueToParts(CSID, PartsDelayID, isUpper)
    End Sub
    Private Sub ClearDelay(ByVal uGrid As UltraGrid, ByVal isUpper As Boolean)
        If (uGrid.ActiveRow Is Nothing) = False Then
            If uGrid.ActiveRow.Index > -1 Then
                If MsgBox("Are you sure you wish to clear the delay?", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.Yes Then
                    KPGeneral.WebRef_Local.usp_ClearDelayDueToParts(uGrid.ActiveRow.Cells("CSID").Text, isUpper)

                    ColourRow(uGrid, uGrid.ActiveRow.Index)
                End If
            End If
        End If

    End Sub
    Private Sub ClearBaseDelayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearBaseDelayToolStripMenuItem.Click
        ClearDelay(ugOrdersPicked, False)
    End Sub
    Private Sub ClearUpperDelayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearUpperDelayToolStripMenuItem.Click
        ClearDelay(ugOrdersPicked, True)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem.Click
        KPGeneral.ColumnChooser(ugOrdersPicked, Me.GetType.Name)
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem.Click
        If (ugOrdersPicked.ActiveRow Is Nothing) = False Then
            If ugOrdersPicked.ActiveRow.Index > -1 Then
                KPGeneral.ViewKitchenTrackerByCSID(ugOrdersPicked.ActiveRow.Cells("CSID").Text)
            End If
        End If

    End Sub

    Private Sub EmployeePerformanceForBasePickerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeePerformanceForBasePickerToolStripMenuItem.Click
        ViewPerformance(False)
    End Sub
    Private Sub EmployeePerformanceForUpperPickerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeePerformanceForUpperPickerToolStripMenuItem.Click
        ViewPerformance(True)
    End Sub
    Private Sub ViewPerformance(ByVal isUpper As Boolean)
        Dim LocationString, EmployeeInfo As String

        EmployeeInfo = ""

        If isUpper = False Then
            LocationString = "Picker - Base"

            If IsDBNull(ugOrdersPicked.ActiveRow.Cells("PBE").Value) = False Then
                EmployeeInfo = ugOrdersPicked.ActiveRow.Cells("PBE").Text
            End If
        Else
            LocationString = "Picker - Upper"

            If IsDBNull(ugOrdersPicked.ActiveRow.Cells("PUE").Value) = False Then
                EmployeeInfo = ugOrdersPicked.ActiveRow.Cells("PUE").Text
            End If
        End If

        If ugOrdersPicked.ActiveRow.Index > -1 Then
            Dim PerformanceTracker As New frmEmployeePerformanceTracker
            PerformanceTracker.EmployeeInfo = EmployeeInfo
            PerformanceTracker.FromLocation = LocationString
            PerformanceTracker.ShowDialog()
        End If
    End Sub
End Class