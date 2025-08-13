Public Class frmManageClamps
    Private Sub frmManageClamps_Load(sender As Object, e As EventArgs) Handles Me.Load
        KPGeneral.SetDefaultGridSettings(ug_ManageClamps_WorkerList)
        KPGeneral.SetGridRowFilterSettings(ug_ManageClamps_WorkerList)

        AddHandlers()

        RefreshWorkerList()
    End Sub
    Private Sub RefreshWorkerList()

        ug_ManageClamps_WorkerList.DataSource = KPGeneral.WebRef_Local.usp_GetActiveClampWorkers().Tables(0)

        KPGeneral.RefreshGridFromLayout(ug_ManageClamps_WorkerList, Me.GetType.Name)

        ug_ManageClamps_WorkerList.DisplayLayout.Bands(0).Columns("AssemblyLineNumber").Header.Caption = "Clamp Number"
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshWorkerList()
    End Sub
    Private Sub btnClearInfo_Click(sender As Object, e As EventArgs) Handles btnClearInfo.Click
        ClearInfo()
    End Sub
    Private Sub btnAddWorker_Click(sender As Object, e As EventArgs) Handles btnAddWorker.Click
        UpdateInfo(0)
    End Sub
    Private Sub btnUpdateWorker_Click(sender As Object, e As EventArgs) Handles btnUpdateWorker.Click
        If ug_ManageClamps_WorkerList.ActiveRow.Index > -1 Then
            UpdateInfo(ug_ManageClamps_WorkerList.ActiveRow.Cells("ID").Text)
        End If
    End Sub
    Private Sub ColumnChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem.Click
        KPGeneral.ColumnChooser(ug_ManageClamps_WorkerList, Me.GetType.Name)
    End Sub
    Private Sub SetObsoleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetObsoleteToolStripMenuItem.Click
        ChangeWorkerActive(False)
    End Sub
    Private Sub ReactivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReactivateToolStripMenuItem.Click
        ChangeWorkerActive(True)
    End Sub
    Private Sub ChangeWorkerActive(ByVal isActive As Boolean)
        If ug_ManageClamps_WorkerList.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ug_ManageClamps_WorkerList.Selected.Rows.Count - 1
                KPGeneral.WebRef_Local.usp_UpdateClampWorkersActive(ug_ManageClamps_WorkerList.Selected.Rows(x).Cells("ID").Text, isActive)

                Dim isObsolete As Boolean
                If isActive = True Then
                    isObsolete = False
                Else
                    isObsolete = True
                End If

                ug_ManageClamps_WorkerList.Selected.Rows(x).Cells("isActive").Value = isActive
                ug_ManageClamps_WorkerList.Selected.Rows(x).Cells("isObsolete").Value = isObsolete
            Next
        End If
    End Sub
    Protected Sub txtKeyPressValidation(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim AllowedInput As Boolean = False

        AllowedInput = InputValidation.InputNumericOnly(e.KeyChar)

        If AllowedInput = False Then
            e.Handled = True
        End If
    End Sub
    Private Sub AddHandlers()
        AddHandler txtAvgDailyProduction.KeyPress, AddressOf txtKeyPressValidation
        AddHandler txtAvgPerformance.KeyPress, AddressOf txtKeyPressValidation
        AddHandler txtLineNumber.KeyPress, AddressOf txtKeyPressValidation
        AddHandler txtEmpRef.KeyPress, AddressOf txtKeyPressValidation
        AddHandler tbPassword.KeyPress, AddressOf txtKeyPressValidation
    End Sub
    Private Sub UpdateInfo(ByVal WorkerID As Integer)
        Dim ValidateText As String = VerifyTextBoxes(WorkerID)

        If ValidateText = "valid" Then
            KPGeneral.WebRef_Local.usp_UpdateActiveClampWorkers(WorkerID, txtEmpRef.Text.Trim, txtLineNumber.Text.Trim, txtStationName.Text.Trim,
                                                                txtAvgDailyProduction.Text.Trim, txtAvgPerformance.Text.Trim, Me.tbPassword.Text)

            RefreshWorkerList()
        Else
            MsgBox(ValidateText, MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub ug_ManageClamps_WorkerList_AfterRowActivate(sender As Object, e As EventArgs) Handles ug_ManageClamps_WorkerList.AfterRowActivate
        If ug_ManageClamps_WorkerList.ActiveRow.Index > -1 Then
            If IsDBNull(ug_ManageClamps_WorkerList.ActiveRow.Cells("StationName").Value) = False Then
                txtStationName.Text = ug_ManageClamps_WorkerList.ActiveRow.Cells("StationName").Text
            Else
                txtStationName.Text = ""
            End If

            If IsDBNull(ug_ManageClamps_WorkerList.ActiveRow.Cells("EmpRef").Value) = False Then
                txtEmpRef.Text = ug_ManageClamps_WorkerList.ActiveRow.Cells("EmpRef").Text
            Else
                txtEmpRef.Text = ""
            End If

            If IsDBNull(ug_ManageClamps_WorkerList.ActiveRow.Cells("AssemblyLineNumber").Value) = False Then
                txtLineNumber.Text = ug_ManageClamps_WorkerList.ActiveRow.Cells("AssemblyLineNumber").Text
            Else
                txtLineNumber.Text = ""
            End If

            If IsDBNull(ug_ManageClamps_WorkerList.ActiveRow.Cells("AverageDailyProduction").Value) = False Then
                txtAvgDailyProduction.Text = ug_ManageClamps_WorkerList.ActiveRow.Cells("AverageDailyProduction").Text
            Else
                txtAvgDailyProduction.Text = ""
            End If

            If IsDBNull(ug_ManageClamps_WorkerList.ActiveRow.Cells("AveragePerformance").Value) = False Then
                txtAvgPerformance.Text = ug_ManageClamps_WorkerList.ActiveRow.Cells("AveragePerformance").Text
            Else
                txtAvgPerformance.Text = ""
            End If

            If IsDBNull(ug_ManageClamps_WorkerList.ActiveRow.Cells("Password").Value) = False Then
                Me.tbPassword.Text = ug_ManageClamps_WorkerList.ActiveRow.Cells("Password").Text
            Else
                Me.tbPassword.Text = ""
            End If

            Me.btnAddWorker.Enabled = False
            Me.btnUpdateWorker.Enabled = True

        End If

    End Sub
    Function VerifyTextBoxes(ByVal WorkerID As String) As String
        If txtStationName.Text.Trim.Length = 0 Then
            Return "You must enter a valid station name."
        End If

        Dim stationName As String = Me.txtStationName.Text.Trim.ToLower()

        For i As Int16 = 0 To Me.ug_ManageClamps_WorkerList.Rows.Count - 1

            If Me.ug_ManageClamps_WorkerList.Rows(i).Cells("StationName").Text.Trim.ToLower() = stationName Then

                If WorkerID = 0 Then
                    Return "This station name already exists as a different number.  Please input a different one."
                ElseIf WorkerID <> Me.ug_ManageClamps_WorkerList.Rows(i).Cells("ID").Text Then
                    Return "This station name already exists as a different number.  Please update the original."
                End If

            End If
        Next

        If txtEmpRef.Text.Trim.Length <> 4 Then
            Return "You must enter a valid employee #.  Valid employee numbers are 4 digits long."
        End If

        If txtLineNumber.Text.Length = 0 Then
            Return "You must enter a valid line number."
        End If

        If txtAvgDailyProduction.Text.Length = 0 Then
            Return "You must enter a valid daily production number."
        End If

        If txtAvgPerformance.Text.Length = 0 Then
            Return "You must enter a valid average performance number."
        End If

        If Me.tbPassword.Text.Trim.Length <> 4 Then
            Return "You must enter a valid password.  Valid password are 4 digits long."
        End If

        Return "valid"
    End Function
    Private Sub ClearInfo()
        txtAvgDailyProduction.Text = ""
        txtEmpRef.Text = ""
        txtLineNumber.Text = ""
        txtStationName.Text = ""
        Me.txtAvgPerformance.Text = ""
        Me.tbPassword.Text = ""
        ug_ManageClamps_WorkerList.Selected.Rows.Clear()
        ug_ManageClamps_WorkerList.ActiveRow = Nothing
        Me.btnAddWorker.Enabled = True
        Me.btnUpdateWorker.Enabled = False

    End Sub
End Class