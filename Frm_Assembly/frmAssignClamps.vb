Imports Infragistics.Win.UltraWinGrid
Public Class frmAssignClamps
    Dim Clamp1 As Integer
    Dim Clamp2 As Integer
    Dim Lines As Integer
    Private Sub frmAssignClamps_Load(sender As Object, e As EventArgs) Handles Me.Load
        KPGeneral.SetDefaultGridSettings(ugAssignClamps2)
        KPGeneral.SetDefaultGridSettings(ugAssignClamps1)
        KPGeneral.SetDefaultGridSettings(ugAssignClampLines)

        ugAssignClampLines.DataSource = Nothing
        ugAssignClamps1.DataSource = Nothing
        ugAssignClamps2.DataSource = Nothing
    End Sub
    Private Sub RefreshClamps()
        Dim dsClamp1, dsClamp2, dsLines As New DataSet
        dsClamp1 = KPGeneral.WebRef_Local.usp_GetAssignedClampsByClampNumber(Clamp1)
        dsClamp2 = KPGeneral.WebRef_Local.usp_GetAssignedClampsByClampNumber(Clamp2)

        Dim dsClampInfo1, dsClampInfo2 As New DataSet
        dsClampInfo1 = KPGeneral.WebRef_Local.usp_GetAssignedClampsByClampNumber_BoxInfo(Clamp1)
        dsClampInfo2 = KPGeneral.WebRef_Local.usp_GetAssignedClampsByClampNumber_BoxInfo(Clamp2)

        lblClamp1.Text = "Clamp #" & Clamp1
        lblClamp2.Text = "Clamp #" & IIf(Clamp2 = -1, "", Clamp2)

        btnSendTo1.Text = "Send to Clamp #" & Clamp2
        btnSendTo2.Text = "Send to Clamp #" & Clamp1

        Dim LineID As Integer

        Select Case Lines
            Case 12
                LineID = 1
            Case 34
                LineID = 3
            Case 56
                LineID = 5
            Case 7
                LineID = 7
            Case 8
                LineID = 8
        End Select

        Dim TotalMin1 As Integer = 0
        Dim TotalMin2 As Integer = 0

        Dim z As Integer
        For z = 0 To dsClampInfo1.Tables(0).Rows.Count - 1
            If Not IsDBNull(dsClampInfo1.Tables(0).Rows(z)("APRem")) Then
                TotalMin1 = TotalMin1 + dsClampInfo1.Tables(0).Rows(z)("APRem")
            End If
        Next
        For z = 0 To dsClampInfo2.Tables(0).Rows.Count - 1
            If Not IsDBNull(dsClampInfo2.Tables(0).Rows(z)("APRem")) Then
                TotalMin2 = TotalMin2 + dsClampInfo2.Tables(0).Rows(z)("APRem")
            End If
        Next
        Dim StartText As String = "MIN REM: "

        lblMinRem1.Text = StartText & TotalMin1
        lblMinRem2.Text = StartText & TotalMin2

        dsLines = KPGeneral.WebRef_Local.usp_GetUnAssignedClampsByAssignedLine(LineID)

        ugAssignClampLines.DataSource = dsLines
        ugAssignClamps1.DataSource = dsClamp1
        ugAssignClamps2.DataSource = dsClamp2

        KPGeneral.RefreshGridFromLayout(ugAssignClampLines, Me.GetType.Name)
        KPGeneral.RefreshGridFromLayout(ugAssignClamps1, Me.GetType.Name)
        KPGeneral.RefreshGridFromLayout(ugAssignClamps2, Me.GetType.Name)

        ugAssignClampLines.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        ugAssignClampLines.DisplayLayout.Override.SelectTypeCol = SelectType.None
        ugAssignClamps1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        ugAssignClamps1.DisplayLayout.Override.SelectTypeCol = SelectType.None
        ugAssignClamps2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
        ugAssignClamps2.DisplayLayout.Override.SelectTypeCol = SelectType.None

        Dim x As Integer
        For x = 0 To ugAssignClampLines.Rows.Count - 1
            If ugAssignClampLines.Rows(x).Cells("WP").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ugAssignClampLines.Rows(x).Cells("WP").Appearance.BackColor = Color.YellowGreen
                ugAssignClampLines.Rows(x).Cells("PB").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ugAssignClampLines.Rows(x).Cells("WP").Appearance.BackColor = Color.Tomato
                ugAssignClampLines.Rows(x).Cells("WP").Appearance.ForeColor = Color.Tomato
            End If

            If ugAssignClampLines.Rows(x).Cells("PB").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ugAssignClampLines.Rows(x).Cells("PB").Appearance.BackColor = Color.YellowGreen
                ugAssignClampLines.Rows(x).Cells("PB").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ugAssignClampLines.Rows(x).Cells("PB").Appearance.BackColor = Color.Tomato
                ugAssignClampLines.Rows(x).Cells("PB").Appearance.ForeColor = Color.Tomato
            End If
        Next

        For x = 0 To ugAssignClamps1.Rows.Count - 1
            ColourRow(ugAssignClamps1, x)
        Next

        For x = 0 To ugAssignClamps2.Rows.Count - 1
            ColourRow(ugAssignClamps2, x)
        Next
    End Sub
    Private Sub ColourRow(ByVal uGrid As UltraGrid, ByVal RowIndex As Integer)
        If uGrid.Rows(RowIndex).Cells("WP").Text <> Nothing Then
            '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
            uGrid.Rows(RowIndex).Cells("WP").Appearance.BackColor = Color.YellowGreen
            uGrid.Rows(RowIndex).Cells("PB").Appearance.ForeColor = Color.YellowGreen
        Else
            '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
            uGrid.Rows(RowIndex).Cells("WP").Appearance.BackColor = Color.Tomato
            uGrid.Rows(RowIndex).Cells("WP").Appearance.ForeColor = Color.Tomato
        End If

        If uGrid.Rows(RowIndex).Cells("PB").Text <> Nothing Then
            '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
            uGrid.Rows(RowIndex).Cells("PB").Appearance.BackColor = Color.YellowGreen
            uGrid.Rows(RowIndex).Cells("PB").Appearance.ForeColor = Color.YellowGreen
        Else
            '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
            uGrid.Rows(RowIndex).Cells("PB").Appearance.BackColor = Color.Tomato
            uGrid.Rows(RowIndex).Cells("PB").Appearance.ForeColor = Color.Tomato
        End If
    End Sub
    Private Sub uoClamps_ValueChanged(sender As Object, e As EventArgs)
        'RefreshClamps()
    End Sub
    Private Sub ProcessScannedBarcode(ByVal Barcode As String, ByVal Clamp As Integer)
        Dim dsOrderInfo As New DataSet
        dsOrderInfo = KPGeneral.WebRef_Local.spKP_LotInfoByFK(Barcode)
        If dsOrderInfo.Tables(0).Rows.Count > 0 Then
            If IsDBNull(dsOrderInfo.Tables(0).Rows(0)("AssignedLine")) = False Then
                Dim AssignedLine As Integer = dsOrderInfo.Tables(0).Rows(0)("AssignedLine")
                Dim AppropriateLine As Integer

                If AssignedLine > 0 Then
                    If Clamp = 1 Or Clamp = 2 Then
                        AppropriateLine = 1
                    ElseIf Clamp = 3 Or Clamp = 4 Then
                        AppropriateLine = 3
                    ElseIf Clamp = 5 Or Clamp = 6 Then
                        AppropriateLine = 5
                    ElseIf Clamp = 7 Then
                        AppropriateLine = 7
                    End If

                    If AssignedLine = AppropriateLine Then
                        KPGeneral.WebRef_Local.usp_UpdateAssignedClamp(dsOrderInfo.Tables(0).Rows(0)("CSID"), Clamp)
                        KPGeneral.SystemHistory(dsOrderInfo.Tables(0).Rows(0)("CSID"), "frmAssignClamps", "ProcessScannedBarcode", KPGeneral.User.UserProfile("UserLoginName"))

                        If IsDBNull(dsOrderInfo.Tables(0).Rows(0)("RemainingCabinets")) = False Then
                            If dsOrderInfo.Tables(0).Rows(0)("RemainingCabinets") = 0 Then
                                MsgBox("The order has already been completed", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                            End If
                        End If

                        RefreshClamps()
                        ClearSelected()
                    Else
                        MsgBox("The order has not been assigned to the line that matches this clamp.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                    End If
                Else
                    MsgBox("The order has not been assigned a line yet.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                End If
            Else
                MsgBox("The order has not been assigned a line yet.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If

    End Sub
    Private Sub txtBarcode1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode1.KeyPress
        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                If Trim(txtBarcode1.Text) = Nothing Then
                    Exit Sub
                End If

                ProcessScannedBarcode(txtBarcode1.Text, Clamp1)

                txtBarcode1.Text = ""
                txtBarcode1.Focus()
            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub txtBarcode2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode2.KeyPress
        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                If Trim(txtBarcode2.Text) = Nothing Then
                    Exit Sub
                End If

                ProcessScannedBarcode(txtBarcode2.Text, Clamp2)

                txtBarcode2.Text = ""
                txtBarcode2.Focus()
            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub ShowSelectedMainButtons(ByVal LineID As Integer)
        'gbSecondButtons.Visible = True

        'CatID = CategoryID

        btnLine12.Appearance.ResetBackColor()
        btnLine12.Appearance.ResetThemedElementAlpha()
        btnLine34.Appearance.ResetBackColor()
        btnLine34.Appearance.ResetThemedElementAlpha()
        btnLine56.Appearance.ResetBackColor()
        btnLine56.Appearance.ResetThemedElementAlpha()
        btnLine7.Appearance.ResetBackColor()
        btnLine7.Appearance.ResetThemedElementAlpha()
        btnLine8.Appearance.ResetBackColor()
        btnLine8.Appearance.ResetThemedElementAlpha()
        Lines = LineID

        Select Case LineID
            Case 12
                Clamp1 = 1
                Clamp2 = 2
                btnLine12.Appearance.BackColor = Color.LightSkyBlue
                btnLine12.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 34
                Clamp1 = 3
                Clamp2 = 4
                btnLine34.Appearance.BackColor = Color.LightSkyBlue
                btnLine34.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 56
                Clamp1 = 5
                Clamp2 = 6
                btnLine56.Appearance.BackColor = Color.LightSkyBlue
                btnLine56.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 7
                Clamp1 = 7
                Clamp2 = -1
                btnLine7.Appearance.BackColor = Color.LightSkyBlue
                btnLine7.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 8
                Clamp1 = 8
                Clamp2 = -1
                btnLine8.Appearance.BackColor = Color.LightSkyBlue
                btnLine8.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        End Select

        RefreshClamps()
        ClearSelected()
    End Sub
    Private Sub btnLine12_Click(sender As Object, e As EventArgs) Handles btnLine12.Click
        ShowSelectedMainButtons(12)
    End Sub
    Private Sub btnLine34_Click(sender As Object, e As EventArgs) Handles btnLine34.Click
        ShowSelectedMainButtons(34)
    End Sub
    Private Sub btnLine56_Click(sender As Object, e As EventArgs) Handles btnLine56.Click
        ShowSelectedMainButtons(56)
    End Sub
    Private Sub btnLine7_Click(sender As Object, e As EventArgs) Handles btnLine7.Click
        ShowSelectedMainButtons(7)
    End Sub
    Private Sub MoveClamp(ByVal isUp As Boolean, ByVal uGrid As UltraGrid)
        If uGrid.ActiveRow.Index > -1 Then
            If uGrid.Selected.Rows.Count = 1 Then
                Dim CSID As Integer = uGrid.ActiveRow.Cells("CSID").Text

                KPGeneral.WebRef_Local.usp_MoveClampPriority(uGrid.ActiveRow.Cells("CSID").Text, isUp)
                RefreshClamps()
                ClearSelected()

                Dim x As Integer
                For x = 0 To uGrid.Rows.Count - 1
                    If uGrid.Rows(x).Cells("CSID").Text = CSID Then
                        uGrid.Rows(x).Selected = True
                        uGrid.Rows(x).Activate()
                    End If
                Next
            Else
                MsgBox("Please only select a single row to move.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If
    End Sub
    Private Sub ClearSelected()
        ugAssignClamps1.ActiveRow = Nothing
        ugAssignClamps1.Selected.Rows.Clear()
        ugAssignClamps2.ActiveRow = Nothing
        ugAssignClamps2.Selected.Rows.Clear()
        ugAssignClampLines.ActiveRow = Nothing
        ugAssignClampLines.Selected.Rows.Clear()
    End Sub
    Private Sub btnMoveUp1_Click(sender As Object, e As EventArgs) Handles btnMoveUp1.Click
        MoveClamp(True, ugAssignClamps1)
    End Sub
    Private Sub btnMoveUp2_Click(sender As Object, e As EventArgs) Handles btnMoveUp2.Click
        MoveClamp(True, ugAssignClamps2)
    End Sub
    Private Sub btnMoveDown1_Click(sender As Object, e As EventArgs) Handles btnMoveDown1.Click
        MoveClamp(False, ugAssignClamps1)
    End Sub
    Private Sub btnMoveDown2_Click(sender As Object, e As EventArgs) Handles btnMoveDown2.Click
        MoveClamp(False, ugAssignClamps2)
    End Sub
    Private Sub btnSendTo1_Click(sender As Object, e As EventArgs) Handles btnSendTo1.Click
        SendToClamp(Clamp2, ugAssignClamps1)
    End Sub
    Private Sub btnSendTo2_Click(sender As Object, e As EventArgs) Handles btnSendTo2.Click
        SendToClamp(Clamp1, ugAssignClamps2)
    End Sub
    Private Sub SendToClamp(ByVal Clamp As Integer, ByVal uGrid As UltraGrid)
        If uGrid.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To uGrid.Selected.Rows.Count - 1
                KPGeneral.WebRef_Local.usp_UpdateAssignedClamp(uGrid.Selected.Rows(x).Cells("CSID").Text, Clamp)
                KPGeneral.SystemHistory(uGrid.Selected.Rows(x).Cells("CSID").Text, "frmAssignClamps", "SendToClamp", KPGeneral.User.UserProfile("UserLoginName"))
            Next
            RefreshClamps()
            ClearSelected()
        Else
            MsgBox("Please select orders to send.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub ColumnChooser(ByVal uGrid As UltraGrid)
        KPGeneral.ColumnChooser(uGrid, Me.GetType.Name)
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
    Private Sub ColumnChooserToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem1.Click
        ColumnChooser(ugAssignClamps1)
    End Sub
    Private Sub CabinetStatusToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CabinetStatusToolStripMenuItem1.Click
        CabinetStatus(ugAssignClamps1)
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem1.Click
        KitchenTracker(ugAssignClamps1)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem2.Click
        ColumnChooser(ugAssignClamps2)
    End Sub
    Private Sub CabinetStatusToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CabinetStatusToolStripMenuItem2.Click
        CabinetStatus(ugAssignClamps2)
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem2.Click
        KitchenTracker(ugAssignClamps2)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem3.Click
        ColumnChooser(ugAssignClampLines)
    End Sub
    Private Sub CabinetStatusToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles CabinetStatusToolStripMenuItem3.Click
        CabinetStatus(ugAssignClampLines)
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem3.Click
        KitchenTracker(ugAssignClampLines)
    End Sub

    Private Sub SendToAnotherClampToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendToAnotherClampToolStripMenuItem.Click

        If Me.ugAssignClamps1.Selected.Rows.Count > 0 Then

            Try

                Dim clampID As Int16 = CType(InputBox("Please enter a clamp number(1-8):", "Clamp Number"), Int16)
                If clampID > 8 OrElse clampID < 1 Then
                    MsgBox("Please enter a valid clamp number. Clamp number should be an integer 1-8.")
                Else
                    If clampID <> Me.Clamp1 Then
                        Me.SendToClamp(clampID, Me.ugAssignClamps1)
                    End If

                End If

            Catch ex As Exception

                MsgBox("Please enter a valid clamp number. Clamp number should be an integer 1-8.")

            End Try

        Else
            MsgBox("Please select orders to send.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If

    End Sub

    Private Sub SendToAnotherClampToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SendToAnotherClampToolStripMenuItem1.Click

        If Me.ugAssignClamps2.Selected.Rows.Count > 0 Then

            Try

                Dim clampID As Int16 = CType(InputBox("Please enter a clamp number(1-8):", "Clamp Number"), Int16)
                If clampID > 8 OrElse clampID < 1 Then
                    MsgBox("Please enter a valid clamp number. Clamp number should be an integer 1-8.")
                Else
                    If clampID <> Me.Clamp2 Then
                        Me.SendToClamp(clampID, Me.ugAssignClamps2)
                    End If

                End If

            Catch ex As Exception

                MsgBox("Please enter a valid clamp number. Clamp number should be an integer 1-8.")

            End Try

        Else
            MsgBox("Please select orders to send.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If

    End Sub

    Private Sub btnLine8_Click(sender As Object, e As EventArgs) Handles btnLine8.Click
        ShowSelectedMainButtons(8)
    End Sub

End Class