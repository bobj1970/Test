Public Class frmPickingWorkers
    Dim MaxPage As Integer
    Dim CurrentPage As Integer

    Dim dsPickerList As New DataSet

    Dim Picker1ID As String
    Dim Picker2ID As String
    Dim Picker3ID As String
    Dim Picker4ID As String
    Dim Picker5ID As String
    Dim Picker6ID As String
    Dim Picker7ID As String
    Dim Picker8ID As String
    Dim Picker9ID As String
    Dim Picker10ID As String

    Dim PickerIDIndex As Integer

    Dim CurrentPickerID As String
    Private Sub btnPrevPage_Click(sender As Object, e As EventArgs) Handles btnPrevPage.Click
        Me.Cursor = Cursors.WaitCursor
        If CurrentPage >= 2 Then
            CurrentPage = CurrentPage - 1
            'lblSlideNum.Text = PageNum & " / " & TotalPNum
            ShowPagePickers()
        Else

        End If
        CheckNextPrevButtons()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnNextPage_Click(sender As Object, e As EventArgs) Handles btnNextPage.Click
        Me.Cursor = Cursors.WaitCursor
        If CurrentPage < MaxPage Then
            CurrentPage = CurrentPage + 1
            'lblSlideNum.Text = PageNum & " / " & TotalPNum
            ShowPagePickers()
        ElseIf CurrentPage = MaxPage Then

        End If
        CheckNextPrevButtons()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ShowPagePickers()
        Dim x, y As Integer
        y = 0

        ClearPickerInfo()

        For x = 0 To dsPickerList.Tables(0).Rows.Count - 1

            If dsPickerList.Tables(0).Rows(x)("PageNum") = CurrentPage Then
                If y = 0 Then
                    btnPicker1.Text = dsPickerList.Tables(0).Rows(x)("StationName")
                    btnPicker1.Visible = True
                    Picker1ID = dsPickerList.Tables(0).Rows(x)("StationName")
                ElseIf y = 1 Then
                    btnPicker2.Text = dsPickerList.Tables(0).Rows(x)("StationName")
                    btnPicker2.Visible = True
                    Picker2ID = dsPickerList.Tables(0).Rows(x)("StationName")
                ElseIf y = 2 Then
                    btnPicker3.Text = dsPickerList.Tables(0).Rows(x)("StationName")
                    btnPicker3.Visible = True
                    Picker3ID = dsPickerList.Tables(0).Rows(x)("StationName")
                ElseIf y = 3 Then
                    btnPicker4.Text = dsPickerList.Tables(0).Rows(x)("StationName")
                    btnPicker4.Visible = True
                    Picker4ID = dsPickerList.Tables(0).Rows(x)("StationName")
                ElseIf y = 4 Then
                    btnPicker5.Text = dsPickerList.Tables(0).Rows(x)("StationName")
                    btnPicker5.Visible = True
                    Picker5ID = dsPickerList.Tables(0).Rows(x)("StationName")
                ElseIf y = 5 Then
                    btnPicker6.Text = dsPickerList.Tables(0).Rows(x)("StationName")
                    btnPicker6.Visible = True
                    Picker6ID = dsPickerList.Tables(0).Rows(x)("StationName")
                ElseIf y = 6 Then
                    btnPicker7.Text = dsPickerList.Tables(0).Rows(x)("StationName")
                    btnPicker7.Visible = True
                    Picker7ID = dsPickerList.Tables(0).Rows(x)("StationName")
                ElseIf y = 7 Then
                    btnPicker8.Text = dsPickerList.Tables(0).Rows(x)("StationName")
                    btnPicker8.Visible = True
                    Picker8ID = dsPickerList.Tables(0).Rows(x)("StationName")
                ElseIf y = 8 Then
                    btnPicker9.Text = dsPickerList.Tables(0).Rows(x)("StationName")
                    btnPicker9.Visible = True
                    Picker9ID = dsPickerList.Tables(0).Rows(x)("StationName")
                ElseIf y = 9 Then
                    btnPicker10.Text = dsPickerList.Tables(0).Rows(x)("StationName")
                    btnPicker10.Visible = True
                    Picker10ID = dsPickerList.Tables(0).Rows(x)("StationName")
                End If

                If y = 9 Then
                    Exit For
                Else
                    y = y + 1
                End If

            Else
                'ugWorkOrders.Rows(x).Hidden = True
            End If
        Next
    End Sub
    Private Sub ClearPickerInfo()
        btnPicker1.Text = ""
        btnPicker2.Text = ""
        btnPicker3.Text = ""
        btnPicker4.Text = ""
        btnPicker5.Text = ""
        btnPicker6.Text = ""
        btnPicker7.Text = ""
        btnPicker8.Text = ""
        btnPicker9.Text = ""
        btnPicker10.Text = ""

        btnPicker1.Visible = False
        btnPicker2.Visible = False
        btnPicker3.Visible = False
        btnPicker4.Visible = False
        btnPicker5.Visible = False
        btnPicker6.Visible = False
        btnPicker7.Visible = False
        btnPicker8.Visible = False
        btnPicker9.Visible = False
        btnPicker10.Visible = False
    End Sub
    Private Sub CheckNextPrevButtons()
        If CurrentPage > 0 Then
            If CurrentPage = 1 Then
                If MaxPage = 1 Then
                    btnNextPage.Enabled = False
                Else
                    btnNextPage.Enabled = True
                End If
                btnPrevPage.Enabled = False
            Else
                If CurrentPage = MaxPage Then
                    btnPrevPage.Enabled = True
                    btnNextPage.Enabled = False
                Else
                    btnPrevPage.Enabled = True
                    btnNextPage.Enabled = True
                End If
            End If
        End If

    End Sub
    Private Sub frmPickingWorkers_Load(sender As Object, e As EventArgs) Handles Me.Load
        CurrentPage = 1

        RefreshPickerList()

        CheckNextPrevButtons()
        ShowPagePickers()
    End Sub
    Private Sub RefreshPickerList()
        dsPickerList = KPGeneral.WebRef_Local.usp_GetActivePickers()

        dsPickerList.Tables(0).Columns.Add("PageNum")

        If dsPickerList.Tables(0).Rows.Count > 0 Then
            Dim x, iCount, pNum As Integer
            iCount = 0
            pNum = 1

            For x = 0 To dsPickerList.Tables(0).Rows.Count - 1
                If iCount <= 9 Then
                    dsPickerList.Tables(0).Rows(x)("PageNum") = pNum
                    If iCount = 9 Then
                        iCount = 0
                        If x < dsPickerList.Tables(0).Rows.Count - 1 Then
                            pNum = pNum + 1
                        End If
                    Else
                        iCount = iCount + 1
                    End If
                End If
            Next

            MaxPage = pNum
            'lblSlideNum.Text = PageNum & " / " & TotalPNum


        Else
            'lblSlideNum.Text = "0 / 0"
        End If
    End Sub
    Private Sub ShowSelectedMainButtons(ByVal CategoryID As Integer)
        PickerIDIndex = CategoryID

        Select Case CategoryID
            Case 1
                'btnPicker1.Appearance.BackColor = Color.LightSkyBlue
                'btnPicker1.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
                CurrentPickerID = Picker1ID
            Case 2
                'btnPicker2.Appearance.BackColor = Color.LightSkyBlue
                'btnPicker2.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
                CurrentPickerID = Picker2ID
            Case 3
                'btnPicker3.Appearance.BackColor = Color.LightSkyBlue
                'btnPicker3.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
                CurrentPickerID = Picker3ID
            Case 4
                'btnPicker4.Appearance.BackColor = Color.LightSkyBlue
                'btnPicker4.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
                CurrentPickerID = Picker4ID
            Case 5
                'btnPicker5.Appearance.BackColor = Color.LightSkyBlue
                'btnPicker5.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
                CurrentPickerID = Picker5ID
            Case 6
                'btnPicker6.Appearance.BackColor = Color.LightSkyBlue
                'btnPicker6.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
                CurrentPickerID = Picker6ID
            Case 7
                'btnPicker7.Appearance.BackColor = Color.LightSkyBlue
                'btnPicker7.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
                CurrentPickerID = Picker7ID
            Case 8
                'btnPicker8.Appearance.BackColor = Color.LightSkyBlue
                'btnPicker8.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
                CurrentPickerID = Picker8ID
            Case 9
                'btnPicker9.Appearance.BackColor = Color.LightSkyBlue
                'btnPicker9.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
                CurrentPickerID = Picker9ID
            Case 10
                'btnPicker10.Appearance.BackColor = Color.LightSkyBlue
                'btnPicker10.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
                CurrentPickerID = Picker10ID
        End Select

        frmOrdersPicked.PickerID = CurrentPickerID

        ugbMainSelected.Visible = True
        'Me.Close()
    End Sub
    Private Sub btnPicker1_Click(sender As Object, e As EventArgs) Handles btnPicker1.Click
        ShowSelectedMainButtons(1)
    End Sub
    Private Sub btnPicker2_Click(sender As Object, e As EventArgs) Handles btnPicker2.Click
        ShowSelectedMainButtons(2)
    End Sub
    Private Sub btnPicker3_Click(sender As Object, e As EventArgs) Handles btnPicker3.Click
        ShowSelectedMainButtons(3)
    End Sub
    Private Sub btnPicker4_Click(sender As Object, e As EventArgs) Handles btnPicker4.Click
        ShowSelectedMainButtons(4)
    End Sub
    Private Sub btnPicker5_Click(sender As Object, e As EventArgs) Handles btnPicker5.Click
        ShowSelectedMainButtons(5)
    End Sub
    Private Sub btnPicker6_Click(sender As Object, e As EventArgs) Handles btnPicker6.Click
        ShowSelectedMainButtons(6)
    End Sub
    Private Sub btnPicker7_Click(sender As Object, e As EventArgs) Handles btnPicker7.Click
        ShowSelectedMainButtons(7)
    End Sub
    Private Sub btnPicker8_Click(sender As Object, e As EventArgs) Handles btnPicker8.Click
        ShowSelectedMainButtons(8)
    End Sub
    Private Sub btnPicker9_Click(sender As Object, e As EventArgs) Handles btnPicker9.Click
        ShowSelectedMainButtons(9)
    End Sub
    Private Sub btnPicker10_Click(sender As Object, e As EventArgs) Handles btnPicker10.Click
        ShowSelectedMainButtons(10)
    End Sub
    Private Sub btnAllPartsPicked_Click(sender As Object, e As EventArgs) Handles btnAllPartsPicked.Click
        frmOrdersPicked.PartsDelayID = 0
        Me.Close()
    End Sub
    Private Sub btnMissingParts_Click(sender As Object, e As EventArgs) Handles btnMissingParts.Click
        ugbDelayReasons.Visible = True
    End Sub
    Private Sub SetDelayID(ByVal DelayID As Integer)
        frmOrdersPicked.PartsDelayID = DelayID
        Me.Close()
    End Sub
    Private Sub btnCustom_Click(sender As Object, e As EventArgs) Handles btnCustom.Click
        SetDelayID(1)
    End Sub
    Private Sub btnFinishing_Click(sender As Object, e As EventArgs) Handles btnFinishing.Click
        SetDelayID(2)
    End Sub
    Private Sub btnHardware_Click(sender As Object, e As EventArgs) Handles btnHardware.Click
        SetDelayID(3)
    End Sub
    Private Sub btnPanelProcessing_Click(sender As Object, e As EventArgs) Handles btnPanelProcessing.Click
        SetDelayID(4)
    End Sub
End Class