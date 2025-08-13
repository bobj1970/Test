Imports Infragistics.Win.UltraWinGrid
Public Class frmClampDetails
    Public Shared ClampNum As Integer
    Private Sub RefreshScannedToday()

        Dim ds, dsActive As New DataSet
        ds = KPGeneral.WebRef_Local.usp_AssembledTodayByAssignedClamp(Now.Date, ClampNum)

        ugClampCabinetScansToday.DataSource = ds
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
    Private Sub RefreshClampDetail()
        Me.Text = "Clamp Detail - Clamp #" & ClampNum

        Dim uGrid As UltraGrid

        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetAssignedClampsByClampNumber_BoxInfo(ClampNum)

        uGrid = ugClamp1

        Dim SetGrid As Boolean = False

        SetGrid = True

        If SetGrid = True Then
            uGrid.DataSource = ds
            uGrid.DisplayLayout.Bands(0).Columns("CSID").Hidden = True

            KPGeneral.RefreshGridFromLayout(uGrid, Me.GetType.Name)
            uGrid.DisplayLayout.Bands(0).Columns("BoxDate").Format = KPGeneral.DateTime12HourFormatString

            uGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
            uGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None

            Dim y As Integer
            For y = 0 To uGrid.Rows.Count - 1
                If uGrid.Rows(y).Cells("WP").Text <> Nothing Then
                    '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                    uGrid.Rows(y).Cells("WP").Appearance.BackColor = Color.YellowGreen
                    uGrid.Rows(y).Cells("WP").Appearance.ForeColor = Color.YellowGreen
                Else
                    '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                    uGrid.Rows(y).Cells("WP").Appearance.BackColor = Color.Tomato
                    uGrid.Rows(y).Cells("WP").Appearance.ForeColor = Color.Tomato
                End If

                If uGrid.Rows(y).Cells("BP").Text <> Nothing Then
                    '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                    uGrid.Rows(y).Cells("BP").Appearance.BackColor = Color.YellowGreen
                    uGrid.Rows(y).Cells("BP").Appearance.ForeColor = Color.YellowGreen
                Else
                    '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                    uGrid.Rows(y).Cells("BP").Appearance.BackColor = Color.Tomato
                    uGrid.Rows(y).Cells("BP").Appearance.ForeColor = Color.Tomato
                End If
            Next
        End If

        uGrid.ActiveRow = Nothing
        uGrid.Selected.Rows.Clear()
    End Sub
    Private Sub frmClampDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshClampDetail()
        RefreshScannedToday()
    End Sub

    Private Sub CabinetStatus(ByVal uGrid As UltraGrid)
        If uGrid.ActiveRow.Index > -1 Then
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

    Private Sub MoveClamp(ByVal isUp As Boolean, ByVal uGrid As UltraGrid)
        If uGrid.ActiveRow.Index > -1 Then
            KPGeneral.WebRef_Local.usp_MoveClampPriority(uGrid.ActiveRow.Cells("CSID").Text, isUp)
            RefreshClampDetail()
            RefreshScannedToday()
        End If
    End Sub
    Private Sub MoveUpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MoveUpToolStripMenuItem1.Click
        MoveClamp(True, ugClamp1)
    End Sub
    Private Sub MoveDownToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MoveDownToolStripMenuItem1.Click
        MoveClamp(False, ugClamp1)
    End Sub

    Private Sub CabinetStatusToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CabinetStatusToolStripMenuItem1.Click
        CabinetStatus(ugClamp1)
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem1.Click
        KitchenTracker(ugClamp1)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem1.Click
        ColumnChooser(ugClamp1)
    End Sub

    Private Sub ToolStripMoveClamp1_Click(sender As Object, e As EventArgs) Handles ToolStripMoveClamp1.Click
        SendToClamp(1)
    End Sub

    Private Sub SendToClamp(ByVal Clamp As Integer)
        If ugClamp1.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugClamp1.Selected.Rows.Count - 1
                KPGeneral.WebRef_Local.usp_UpdateAssignedClamp(ugClamp1.Selected.Rows(x).Cells("CSID").Text, Clamp)
                KPGeneral.SystemHistory(ugClamp1.Selected.Rows(x).Cells("CSID").Text, "frmAssignClamps", "SendToClamp", KPGeneral.User.UserProfile("UserLoginName"))
            Next
            RefreshClampDetail()

        Else
            MsgBox("Please select orders to send.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub

    Private Sub ToolStripMoveClamp2_Click(sender As Object, e As EventArgs) Handles ToolStripMoveClamp2.Click
        SendToClamp(2)
    End Sub

    Private Sub ToolStripMoveClamp3_Click(sender As Object, e As EventArgs) Handles ToolStripMoveClamp3.Click
        SendToClamp(3)
    End Sub

    Private Sub ToolStripMoveClamp4_Click(sender As Object, e As EventArgs) Handles ToolStripMoveClamp4.Click
        SendToClamp(4)
    End Sub

    Private Sub ToolStripMoveClamp5_Click(sender As Object, e As EventArgs) Handles ToolStripMoveClamp5.Click
        SendToClamp(5)
    End Sub

    Private Sub ToolStripMoveClamp6_Click(sender As Object, e As EventArgs) Handles ToolStripMoveClamp6.Click
        SendToClamp(6)
    End Sub

    Private Sub ToolStripMoveClamp7_Click(sender As Object, e As EventArgs) Handles ToolStripMoveClamp7.Click
        SendToClamp(7)
    End Sub
End Class