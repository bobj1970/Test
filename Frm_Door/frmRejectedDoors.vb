Public Class frmRejectedDoors
    Dim TDate As Date
    Dim FDate As Date
    Private Sub frmRejectedDoors_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshRejected()

        RefreshReasons()
        FillcbWoodType()

        txtQty.Text = Nothing
        cbReason.Text = Nothing
    End Sub
    Private Sub RefreshRejected()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.spKPFactory_RejectedDoorsCurrentDay_Species(Date.Now, "Service")
        ugRejected.DataSource = ds
        ugRejected.DisplayLayout.Bands(0).Columns("ID").Hidden = True
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim WoodType, reason, dept As String
        Dim qty As Integer

        dept = KPGeneral.User.UserProfile("UserLoginName")

        If cbWoodType.IsItemInList = True Then
            If cbWoodType.Text.Length > 0 Then
                WoodType = cbWoodType.Text
            Else
                WoodType = "N/A"
            End If
        Else
            MsgBox("Please enter a valid species/wood type.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Exit Sub
        End If

        If txtQty.Text.Length > 0 Then
            If IsNumeric(txtQty.Text) Then
                qty = txtQty.Text
            Else
                MsgBox("Please enter a valid number for qty", MsgBoxStyle.OkOnly, "KPFactory")
                Exit Sub
            End If

        Else
            MsgBox("Please enter a valid qty and try again", MsgBoxStyle.OkOnly, "KPFactory")
            Exit Sub
        End If

        If cbReason.Text.Length > 0 Then
            reason = cbReason.Text
        Else
            MsgBox("Please select a valid reason and try again", MsgBoxStyle.OkOnly, "KPFactory")
            Exit Sub
        End If

        KPGeneral.WebRef_Local.spKPFactory_InsertRejectedDoors_Species(dept, WoodType, qty, reason, "Service")

        RefreshRejected()

        'cbColour.DataSource = Nothing
        cbWoodType.Text = Nothing
        txtQty.Text = Nothing
        cbReason.Text = Nothing
    End Sub
    Private Sub btnViewReport_Click(sender As Object, e As EventArgs) Handles btnViewReport.Click
        FDate = dtFDate.Value
        TDate = dtTDate.Value

        ReportsEngine.ReportOptions.FDate = FDate
        ReportsEngine.ReportOptions.TDate = TDate
        ReportsEngine.ReportOptions.PrintOption = 1
        ReportsEngine.SelectedReport(135)

    End Sub
    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        Dim AllowedInput As Boolean = False

        AllowedInput = InputValidation.InputNumericOnly(e.KeyChar)

        If AllowedInput = False Then
            e.Handled = True
        End If
    End Sub
    Private Sub FillcbWoodType()

        Dim dsWoodType As New DataSet
        dsWoodType = KPGeneral.WebRef_Local.usp_getDoorSpecies

        cbWoodType.DataSource = dsWoodType


        Dim y As Integer
        For y = 0 To cbWoodType.DisplayLayout.Bands(0).Columns.Count - 1
            If cbWoodType.DisplayLayout.Bands(0).Columns(y).Header.Caption <> "Species" Then
                cbWoodType.DisplayLayout.Bands(0).Columns(y).Hidden = True
            Else
                cbWoodType.DisplayLayout.Bands(0).Columns(y).Hidden = False
            End If
        Next

        cbWoodType.DisplayLayout.Bands(0).Columns("Species").Width = cbWoodType.Width
        cbWoodType.DisplayMember = "Species"

    End Sub
    Private Sub RefreshReasons()
        Dim dsReason As New DataSet
        dsReason = KPGeneral.WebRef_Local.usp_GetDoorOrderReasonList()
        cbReason.DataSource = dsReason.Tables(0)
        cbReason.DisplayMember = "OrderReason"
        cbReason.ValueMember = "ID"
        cbReason.DisplayLayout.Bands(0).Columns("ID").Hidden = True
    End Sub
End Class