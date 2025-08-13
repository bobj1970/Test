Imports Infragistics.Win.UltraWinGrid
Public Class frmClamps
    Dim ClampNum As Integer
    Private Sub frmClamps_Load(sender As Object, e As EventArgs) Handles Me.Load

        RefreshClamps()
        KPGeneral.SetDefaultGridSettings(ugClamp1)
        btnManageClamps.Visible = KPGeneral.User.UserProfile("ManageClampWorkers")
        ClearSelected()
    End Sub
    Private Sub RefreshClamps()

        Dim dt As New DataTable
        Dim labelText As String = ""

        Dim x As Integer

        For x = 1 To 8
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.usp_GetAssignedClampsByClampNumber_BoxInfo(x)
            If x = 1 Then
                dt = ds.Tables(0).Copy
            Else
                dt.Merge(ds.Tables(0))
            End If

            Dim TotalMin As Integer = 0

            Dim z As Integer
            For z = 0 To ds.Tables(0).Rows.Count - 1
                If Not IsDBNull(ds.Tables(0).Rows(z)("APRem")) Then
                    TotalMin = TotalMin + ds.Tables(0).Rows(z)("APRem")
                End If
            Next

            Dim TotalMinText As String = " - Total Minutes Remaining: " & TotalMin

            Dim MaxDate As DateTime
            Dim MaxDateString As String = ""

            If ds.Tables(0).Rows.Count > 0 Then
                Dim TempMaxDate As String = ds.Tables(0).Compute("Max(BoxDate)", "").ToString
                If TempMaxDate.Length > 0 Then
                    MaxDate = ds.Tables(0).Compute("Max(BoxDate)", "")
                    MaxDateString = Format(MaxDate, "ddd.MMM dd - h:mm tt")
                End If

            End If

            Dim StartText As String = "MIN REM: "
            Select Case x
                Case 1

                    lblMinRem1.Text = StartText & TotalMin
                    lblMax1.Text = MaxDateString
                Case 2
                    lblMinRem2.Text = StartText & TotalMin
                    lblMax2.Text = MaxDateString
                Case 3
                    lblMinRem3.Text = StartText & TotalMin
                    lblMax3.Text = MaxDateString
                Case 4
                    lblMinRem4.Text = StartText & TotalMin
                    lblMax4.Text = MaxDateString
                Case 5
                    lblMinRem5.Text = StartText & TotalMin
                    lblMax5.Text = MaxDateString
                Case 6
                    lblMinRem6.Text = StartText & TotalMin
                    lblMax6.Text = MaxDateString
                Case 7
                    lblMinRem7.Text = StartText & TotalMin
                    lblMax7.Text = MaxDateString
                Case 8
                    lblMinRem8.Text = StartText & TotalMin
                    lblMax8.Text = MaxDateString
            End Select

            If x = ClampNum Then
                Select Case ClampNum
                    Case 1
                        lblClampNum.Text = "Clamp # 1" & TotalMinText & " - Last Refreshed at " & Now
                    Case 2
                        lblClampNum.Text = "Clamp # 2" & TotalMinText & " - Last Refreshed at " & Now
                    Case 3
                        lblClampNum.Text = "Clamp # 3" & TotalMinText & " - Last Refreshed at " & Now
                    Case 4
                        lblClampNum.Text = "Clamp # 4" & TotalMinText & " - Last Refreshed at " & Now
                    Case 5
                        lblClampNum.Text = "Clamp # 5" & TotalMinText & " - Last Refreshed at " & Now
                    Case 6
                        lblClampNum.Text = "Clamp # 6" & TotalMinText & " - Last Refreshed at " & Now
                    Case 7
                        lblClampNum.Text = "Clamp # 7" & TotalMinText & " - Last Refreshed at " & Now
                    Case 8
                        lblClampNum.Text = "Clamp # 8" & TotalMinText & " - Last Refreshed at " & Now
                End Select
            ElseIf Me.ClampNum = 0 Then
                labelText = labelText & "Clamp " & x & TotalMinText & "   "
            End If

        Next

        If Me.ClampNum = 0 Then
            Dim temp As DataTable = dt.Clone
            For Each dr As DataRow In dt.Select("", "BoxDate")
                Dim drTemp As DataRow = temp.NewRow
                For Each c As DataColumn In dt.Columns
                    drTemp(c.ColumnName) = dr(c)
                Next
                temp.Rows.Add(drTemp)
            Next
            Me.ugClamp1.DataSource = temp
            Me.lblClampNum.Text = labelText & "- Last Refreshed at " & Now
        Else
            Me.ugClamp1.DataSource = KPGeneral.WebRef_Local.usp_GetAssignedClampsByClampNumber_BoxInfo(Me.ClampNum)
        End If

        ugClamp1.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        Me.ugClamp1.DisplayLayout.Bands(0).Override.HeaderClickAction = HeaderClickAction.SortSingle
        KPGeneral.RefreshGridFromLayout(ugClamp1, Me.GetType.Name)
        ugClamp1.DisplayLayout.Bands(0).Columns("BoxDate").Format = KPGeneral.DateTime12HourFormatString

        ugClamp1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        ugClamp1.DisplayLayout.Override.SelectTypeCol = SelectType.None

        Dim y As Integer
        For y = 0 To ugClamp1.Rows.Count - 1
            If ugClamp1.Rows(y).Cells("WP").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ugClamp1.Rows(y).Cells("WP").Appearance.BackColor = Color.YellowGreen
                ugClamp1.Rows(y).Cells("WP").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ugClamp1.Rows(y).Cells("WP").Appearance.BackColor = Color.Tomato
                ugClamp1.Rows(y).Cells("WP").Appearance.ForeColor = Color.Tomato
            End If

            If ugClamp1.Rows(y).Cells("BP").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ugClamp1.Rows(y).Cells("BP").Appearance.BackColor = Color.YellowGreen
                ugClamp1.Rows(y).Cells("BP").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ugClamp1.Rows(y).Cells("BP").Appearance.BackColor = Color.Tomato
                ugClamp1.Rows(y).Cells("BP").Appearance.ForeColor = Color.Tomato
            End If
        Next
        RefreshScannedToday()

    End Sub
    Private Sub RefreshScannedToday()

        ugClampCabinetScansToday.DataSource = KPGeneral.WebRef_Local.usp_AssembledTodayByAssignedClamp(Now.Date, ClampNum)
        ugClampCabinetScansToday.DisplayLayout.Bands(0).Columns("ScanTime").Format = "HH:mm:ss"
        ugClampCabinetScansToday.DisplayLayout.Bands(0).Columns("Company").Width = 150
        ugClampCabinetScansToday.DisplayLayout.Bands(0).Columns("Project").Width = 250
        ugClampCabinetScansToday.DisplayLayout.Bands(0).Columns("Lot").Width = 75
        ugClampCabinetScansToday.DisplayLayout.Bands(0).Columns("Company").Header.Caption = "Company"
        ugClampCabinetScansToday.DisplayLayout.Bands(0).Columns("Project").Header.Caption = "Project"
        ugClampCabinetScansToday.DisplayLayout.Bands(0).Columns("Lot").Header.Caption = "Lot"
        ugClampCabinetScansToday.DisplayLayout.Bands(0).Columns("scantime").Header.Caption = "Scan Time"
        ugClampCabinetScansToday.DisplayLayout.Bands(0).Columns("Cabinet_Name").Header.Caption = "Cabinet Name"

        lblTotalCabinetsToday.Text = "Total Cabinets: " & ugClampCabinetScansToday.Rows.Count


    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshClamps()

        ClearSelected()
    End Sub
    Private Sub ClearSelected()
        ugClamp1.ActiveRow = Nothing
        ugClamp1.Selected.Rows.Clear()
        ugClampCabinetScansToday.ActiveRow = Nothing
        ugClampCabinetScansToday.Selected.Rows.Clear()
    End Sub
    Private Sub CabinetStatus(ByVal uGrid As UltraGrid)
        If uGrid.ActiveRow IsNot Nothing AndAlso uGrid.ActiveRow.Index > -1 Then
            KPGeneral.ViewCabinetStatusByCSID(uGrid.ActiveRow.Cells("CSID").Text)
        End If
    End Sub
    Private Sub KitchenTracker(ByVal uGrid As UltraGrid)
        If uGrid.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByCSID(uGrid.ActiveRow.Cells("CSID").Text)
        End If
    End Sub
    Private Sub ColumnChooser(ByVal uGrid As UltraGrid)
        KPGeneral.ColumnChooser(uGrid, Me.GetType.Name)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem1.Click
        ColumnChooser(ugClamp1)
    End Sub
    Private Sub CabinetStatusToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CabinetStatusToolStripMenuItem1.Click
        CabinetStatus(ugClamp1)
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem1.Click
        KitchenTracker(ugClamp1)
    End Sub
    Private Sub MoveClamp(ByVal isUp As Boolean, ByVal uGrid As UltraGrid)
        If uGrid.ActiveRow.Index > -1 Then
            KPGeneral.WebRef_Local.usp_MoveClampPriority(uGrid.ActiveRow.Cells("CSID").Text, isUp)
            RefreshClamps()
            ClearSelected()
        End If
    End Sub
    Private Sub MoveUpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MoveUpToolStripMenuItem1.Click
        MoveClamp(True, ugClamp1)
    End Sub
    Private Sub MoveDownToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MoveDownToolStripMenuItem1.Click
        MoveClamp(False, ugClamp1)
    End Sub
    Private Sub ShowSelectedMainButtons(ByVal ClampID As Integer)
        'gbSecondButtons.Visible = True

        'CatID = CategoryID

        btnClamp1.Appearance.ResetBackColor()
        btnClamp1.Appearance.ResetThemedElementAlpha()
        btnClamp2.Appearance.ResetBackColor()
        btnClamp2.Appearance.ResetThemedElementAlpha()
        btnClamp3.Appearance.ResetBackColor()
        btnClamp3.Appearance.ResetThemedElementAlpha()
        btnClamp4.Appearance.ResetBackColor()
        btnClamp4.Appearance.ResetThemedElementAlpha()
        btnClamp5.Appearance.ResetBackColor()
        btnClamp5.Appearance.ResetThemedElementAlpha()
        btnClamp6.Appearance.ResetBackColor()
        btnClamp6.Appearance.ResetThemedElementAlpha()
        btnClamp7.Appearance.ResetBackColor()
        btnClamp7.Appearance.ResetThemedElementAlpha()
        btnClamp8.Appearance.ResetBackColor()
        btnClamp8.Appearance.ResetThemedElementAlpha()
        ClampNum = ClampID

        Select Case ClampID
            Case 1
                btnClamp1.Appearance.BackColor = Color.LightSkyBlue
                btnClamp1.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 2
                btnClamp2.Appearance.BackColor = Color.LightSkyBlue
                btnClamp2.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 3
                btnClamp3.Appearance.BackColor = Color.LightSkyBlue
                btnClamp3.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 4
                btnClamp4.Appearance.BackColor = Color.LightSkyBlue
                btnClamp4.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 5
                btnClamp5.Appearance.BackColor = Color.LightSkyBlue
                btnClamp5.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 6
                btnClamp6.Appearance.BackColor = Color.LightSkyBlue
                btnClamp6.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 7
                btnClamp7.Appearance.BackColor = Color.LightSkyBlue
                btnClamp7.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 8
                btnClamp8.Appearance.BackColor = Color.LightSkyBlue
                btnClamp8.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        End Select

        RefreshClamps()
        ClearSelected()
    End Sub

    Private Sub btnClamp1_Click(sender As Object, e As EventArgs) Handles btnClamp1.Click
        ShowSelectedMainButtons(1)
    End Sub
    Private Sub btnClamp2_Click(sender As Object, e As EventArgs) Handles btnClamp2.Click
        ShowSelectedMainButtons(2)
    End Sub
    Private Sub btnClamp3_Click(sender As Object, e As EventArgs) Handles btnClamp3.Click
        ShowSelectedMainButtons(3)
    End Sub
    Private Sub btnClamp4_Click(sender As Object, e As EventArgs) Handles btnClamp4.Click
        ShowSelectedMainButtons(4)
    End Sub
    Private Sub btnClamp5_Click(sender As Object, e As EventArgs) Handles btnClamp5.Click
        ShowSelectedMainButtons(5)
    End Sub
    Private Sub btnClamp6_Click(sender As Object, e As EventArgs) Handles btnClamp6.Click
        ShowSelectedMainButtons(6)
    End Sub
    Private Sub btnClamp7_Click(sender As Object, e As EventArgs) Handles btnClamp7.Click
        ShowSelectedMainButtons(7)
    End Sub
    Private Sub btnManageClamps_Click(sender As Object, e As EventArgs) Handles btnManageClamps.Click
        Dim frmTemp As New frmManageAssemblersAndClamps
        frmTemp.ShowDialog()
    End Sub

    Private Sub btShowAllClamps_Click(sender As Object, e As EventArgs) Handles btShowAllClamps.Click

        Me.ShowSelectedMainButtons(0)

    End Sub

    Private Sub btnClamp8_Click(sender As Object, e As EventArgs) Handles btnClamp8.Click
        ShowSelectedMainButtons(8)
    End Sub
End Class