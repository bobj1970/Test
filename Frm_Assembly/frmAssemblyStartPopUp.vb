Imports System.ComponentModel
Imports Infragistics.Win.UltraWinGanttView
Imports Infragistics.Win.UltraWinGrid
Imports Newtonsoft.Json.Converters
Imports Syncfusion.Windows.Forms.Tools.Win32API

Public Class frmAssemblyStartPopUp
    Public Shared CSIDString As String

    Dim Line12Selected As Boolean
    Dim Line34Selected As Boolean
    Dim Line56Selected As Boolean
    Dim Line7Selected As Boolean
    Dim Line8Selected As Boolean
    Dim APT1 As Integer
    Dim APT3 As Integer
    Dim APT5 As Integer
    Dim APT7 As Integer
    Dim APT2 As Integer
    Dim APT4 As Integer
    Dim APT6 As Integer
    Dim APT8 As Integer
    Dim APT1_ToAdd As Integer
    Dim APT3_ToAdd As Integer
    Dim APT5_ToAdd As Integer
    Dim APT7_ToAdd As Integer
    Dim APT2_ToAdd As Integer
    Dim APT4_ToAdd As Integer
    Dim APT6_ToAdd As Integer
    Dim APT8_ToAdd As Integer
    Dim Max1Date As DateTime
    Dim Max3Date As DateTime
    Dim Max5Date As DateTime
    Dim Max7Date As DateTime
    Dim Max2Date As DateTime
    Dim Max4Date As DateTime
    Dim Max6Date As DateTime
    Dim Max8Date As DateTime

    Private Sub refreshLVReady()
        Try
            Dim ds As New DataSet
            'webservice for list 
            ds = KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_ReadyOrders(CSIDString)

            ds.Tables(0).Columns.Add("ProjectedLine")
            ds.Tables(0).Columns.Add("ProjectedClamp")
            ds.Tables(0).Columns.Add("EXPDate", GetType(DateTime))

            ug_AssemblyStartPopUp_AssemblyStart.DataSource = ds

            Dim cCount As Integer

            For cCount = 0 To ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns.Count - 1
                If ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "masternum" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "company" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "project" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "lot" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "totaldoors" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "raw" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "painted" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "hingedate" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "ncomment" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "datediff" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "productiongroup" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "siterequest" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "assemblyplannedtime" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "classificationlevel" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "sc" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "c" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "v" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "f" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "w" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "p" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "s" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "doorspickeddate" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "dbox" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "dloc" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "db" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "driver" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "totalcabinets" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "expdate" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "projectedline" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "buildorder" Or
                        ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "projectedclamp" Then
                    ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Hidden = False
                Else
                    ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Hidden = True
                End If
            Next

            'PGeneral.RefreshGridFromLayout(ug_AssemblyStartPopUp_AssemblyStart, Me.GetType.Name)

            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns("projectedline").Header.VisiblePosition = 1
            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns("ProjectedClamp").Header.VisiblePosition = 2
            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns("assemblyplannedtime").Header.VisiblePosition = 3
            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns("BuildOrder").Header.VisiblePosition = 4
            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns("EXPDate").Header.VisiblePosition = 5
            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns("Company").Width = 200
            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns("Project").Width = 250
            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns("EXPDate").Format = "ddd.MMM dd - h:mm tt"
            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns("EXPDate").Width = 150
            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Override.FilterUIProvider = UltraGridFilterUIProvider1
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub frmAssemblyStartPopUp_Load(sender As Object, e As EventArgs) Handles Me.Load
        uProgress.Value = 0
        KPGeneral.SetDefaultGridSettings(ug_AssemblyStartPopUp_AssemblyStart)

        Me.Max1Date = DateTime.MinValue
        Me.Max2Date = DateTime.MinValue
        Me.Max3Date = DateTime.MinValue
        Me.Max4Date = DateTime.MinValue
        Me.Max5Date = DateTime.MinValue
        Me.Max6Date = DateTime.MinValue
        Me.Max7Date = DateTime.MinValue
        Me.Max8Date = DateTime.MinValue
        Line12Selected = False
        Line34Selected = False
        Line56Selected = False
        Line7Selected = False
        Line8Selected = False
        refreshLVReady()
        RefreshAPTs()
        RefreshClamps()
        SetButtonSelectedLook()

        APT1_ToAdd = 0
        APT2_ToAdd = 0
        APT3_ToAdd = 0
        APT4_ToAdd = 0
        APT5_ToAdd = 0
        APT6_ToAdd = 0
        APT7_ToAdd = 0
        APT8_ToAdd = 0
        lblProjNewMin12.Text = ""
        lblProjNewMin34.Text = ""
        lblProjNewMin56.Text = ""
        lblProjNewMin7.Text = ""
        lblProjNewMin8.Text = ""
        lblProj12.Text = ""
        lblProj34.Text = ""
        lblProj56.Text = ""
        lblProj7.Text = ""
        lblProj8.Text = ""

    End Sub
    Private Sub RefreshAPTs()
        Dim TimePlanned As Double = 0
        Dim row As UltraGridRow
        For Each row In ug_AssemblyStartPopUp_AssemblyStart.Rows
            If Not IsDBNull(row.Cells("APT").Value) Then
                TimePlanned = TimePlanned + row.Cells("APT").Value
            End If
        Next

        lblSelectedAPT_Top.Text = "APT" & vbNewLine & TimePlanned
    End Sub
    Private Sub RefreshClamps()

        For x As Int16 = 1 To 8

            Dim ds As DataSet = KPGeneral.WebRef_Local.usp_GetAssignedClampsByClampNumber_BoxInfo(x)
            Dim SetGrid As Boolean = False
            Dim TotalMin As Integer = 0

            For z As Int16 = 0 To ds.Tables(0).Rows.Count - 1
                If Not IsDBNull(ds.Tables(0).Rows(z)("APRem")) Then
                    TotalMin = TotalMin + ds.Tables(0).Rows(z)("APRem")
                End If
            Next

            Dim MaxDate As DateTime

            If ds.Tables(0).Rows.Count > 0 Then
                Dim TempMaxDate As String = ds.Tables(0).Compute("Max(BoxDate)", "").ToString
                If TempMaxDate.Length > 0 Then
                    MaxDate = ds.Tables(0).Compute("Max(BoxDate)", "")
                End If
            End If

            Select Case x
                Case 1
                    Me.APT1 = TotalMin
                    Me.Max1Date = MaxDate
                Case 2
                    Me.APT2 = TotalMin
                    Me.Max2Date = MaxDate
                Case 3
                    Me.APT3 = TotalMin
                    Me.Max3Date = MaxDate
                Case 4
                    Me.APT4 = TotalMin
                    Me.Max4Date = MaxDate
                Case 5
                    Me.APT5 = TotalMin
                    Me.Max5Date = MaxDate
                Case 6
                    Me.APT6 = TotalMin
                    Me.Max6Date = MaxDate
                Case 7
                    Me.APT7 = TotalMin
                    Me.Max7Date = MaxDate
                Case 8
                    Me.APT8 = TotalMin
                    Me.Max8Date = MaxDate
            End Select

        Next
        APT1_ToAdd = 0
        APT2_ToAdd = 0
        APT3_ToAdd = 0
        APT4_ToAdd = 0
        APT5_ToAdd = 0
        APT6_ToAdd = 0
        APT7_ToAdd = 0
        APT8_ToAdd = 0
        lblMinRem12.Text = "MIN REM: " & Me.APT1 & " / " & Me.APT2
        lblMax12.Text = Format(Me.Max1Date, "ddd.MMM dd - h:mm tt") & vbNewLine & Format(Me.Max2Date, "ddd.MMM dd - h:mm tt")
        lblProj12.Text = ""
        lblProjNewMin12.Text = ""
        lblMinRem34.Text = "MIN REM: " & Me.APT3 & " / " & Me.APT4
        lblMax34.Text = Format(Me.Max3Date, "ddd.MMM dd - h:mm tt") & vbNewLine & Format(Me.Max4Date, "ddd.MMM dd - h:mm tt")
        lblProj34.Text = ""
        lblProjNewMin34.Text = ""
        lblMinRem56.Text = "MIN REM: " & Me.APT5 & " / " & Me.APT6
        lblMax56.Text = Format(Me.Max5Date, "ddd.MMM dd - h:mm tt") & vbNewLine & Format(Me.Max6Date, "ddd.MMM dd - h:mm tt")
        lblProj56.Text = ""
        lblProjNewMin56.Text = ""
        lblMinRem7.Text = "MIN REM: " & Me.APT7
        lblMax7.Text = Format(Me.Max7Date, "ddd.MMM dd - h:mm tt")
        lblProj7.Text = ""
        lblProjNewMin7.Text = ""
        lblMinRem8.Text = "MIN REM: " & Me.APT8
        lblMax8.Text = Format(Me.Max8Date, "ddd.MMM dd - h:mm tt")
        lblProj8.Text = ""
        lblProjNewMin8.Text = ""

    End Sub
    Private Sub SwapSelected(ByVal LineNumbers As Integer)

        Select Case LineNumbers
            Case 12
                Line12Selected = Not Line12Selected
            Case 34
                Line34Selected = Not Line34Selected
            Case 56
                Line56Selected = Not Line56Selected
            Case 7
                Line7Selected = Not Line7Selected
            Case 8
                Line8Selected = Not Line8Selected
        End Select

        SetButtonSelectedLook()
        Me.RefreshClamps()
        Me.AssignOrderToClamp()

    End Sub
    Private Sub ResetButtonLook(ByVal btn As Infragistics.Win.Misc.UltraButton)
        btn.Appearance.ResetBackColor()
        btn.Appearance.ResetThemedElementAlpha()
    End Sub
    Private Sub SetButtonLook(ByVal btn As Infragistics.Win.Misc.UltraButton)
        btn.Appearance.BackColor = Color.LightSkyBlue
        btn.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    End Sub
    Private Sub SetButtonSelectedLook()
        ResetButtonLook(btnLine12)
        ResetButtonLook(btnLine34)
        ResetButtonLook(btnLine56)
        ResetButtonLook(btnLine7)
        ResetButtonLook(btnLine8)
        If Line12Selected = True Then
            SetButtonLook(btnLine12)
        End If

        If Line34Selected = True Then
            SetButtonLook(btnLine34)
        End If

        If Line56Selected = True Then
            SetButtonLook(btnLine56)
        End If

        If Line7Selected = True Then
            SetButtonLook(btnLine7)
        End If
        If Line8Selected = True Then
            SetButtonLook(btnLine8)
        End If

    End Sub
    Private Sub btnLine12_Click(sender As Object, e As EventArgs) Handles btnLine12.Click
        SwapSelected(12)
    End Sub
    Private Sub btnLine34_Click(sender As Object, e As EventArgs) Handles btnLine34.Click
        SwapSelected(34)
    End Sub
    Private Sub btnLine56_Click(sender As Object, e As EventArgs) Handles btnLine56.Click
        SwapSelected(56)
    End Sub
    Private Sub btnLine7_Click(sender As Object, e As EventArgs) Handles btnLine7.Click
        SwapSelected(7)
    End Sub

    Private Sub AssignOrderToClamp()

        For i As Int16 = 0 To ug_AssemblyStartPopUp_AssemblyStart.Rows.Count - 1
            Dim tempDate As DateTime
            Dim selectedClampNum As Int16 = 0
            Dim totalWorkingInMinutes As Int32 = 0
            Dim totalWorkingInMinutes1 As Int32 = 0
            Dim projectAPT As Double = Convert.ToDouble(Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("AssemblyPlannedTime").Value)
            If Me.Line12Selected Then
                totalWorkingInMinutes = Me.GetSheduleWorkingMinutes(1, Me.Max1Date)
                totalWorkingInMinutes1 = Me.GetSheduleWorkingMinutes(2, Me.Max2Date)
                If totalWorkingInMinutes >= projectAPT AndAlso totalWorkingInMinutes1 >= projectAPT Then
                    If Me.Max1Date <= Me.Max2Date Then
                        tempDate = Me.Max1Date
                        selectedClampNum = 1
                    Else
                        tempDate = Me.Max2Date
                        selectedClampNum = 2
                    End If
                ElseIf totalWorkingInMinutes >= projectAPT Then
                    tempDate = Me.Max1Date
                    selectedClampNum = 1
                ElseIf totalWorkingInMinutes1 >= projectAPT Then
                    tempDate = Me.Max2Date
                    selectedClampNum = 2
                End If
            End If

            If Me.Line34Selected Then
                totalWorkingInMinutes = Me.GetSheduleWorkingMinutes(3, Me.Max3Date)
                totalWorkingInMinutes1 = Me.GetSheduleWorkingMinutes(4, Me.Max4Date)
                If totalWorkingInMinutes >= projectAPT AndAlso totalWorkingInMinutes1 >= projectAPT Then
                    If selectedClampNum = 0 Then
                        If Me.Max3Date <= Me.Max4Date Then
                            tempDate = Me.Max3Date
                            selectedClampNum = 3
                        Else
                            tempDate = Me.Max4Date
                            selectedClampNum = 4
                        End If
                    Else
                        If tempDate > Me.Max3Date Then
                            tempDate = Me.Max3Date
                            selectedClampNum = 3
                        End If
                        If tempDate > Me.Max4Date Then
                            tempDate = Me.Max4Date
                            selectedClampNum = 4
                        End If
                    End If
                ElseIf totalWorkingInMinutes >= projectAPT Then
                    If selectedClampNum = 0 Then
                        tempDate = Me.Max3Date
                        selectedClampNum = 3
                    Else
                        If tempDate > Me.Max3Date Then
                            tempDate = Me.Max3Date
                            selectedClampNum = 3
                        End If
                    End If
                ElseIf totalWorkingInMinutes1 >= projectAPT Then
                    If selectedClampNum = 0 Then
                        tempDate = Me.Max4Date
                        selectedClampNum = 4
                    Else
                        If tempDate > Me.Max4Date Then
                            tempDate = Me.Max4Date
                            selectedClampNum = 4
                        End If
                    End If
                End If
            End If

            If Me.Line56Selected Then
                totalWorkingInMinutes = Me.GetSheduleWorkingMinutes(5, Me.Max5Date)
                totalWorkingInMinutes1 = Me.GetSheduleWorkingMinutes(6, Me.Max6Date)
                If totalWorkingInMinutes >= projectAPT AndAlso totalWorkingInMinutes1 >= projectAPT Then
                    If selectedClampNum = 0 Then
                        If Me.Max5Date <= Me.Max6Date Then
                            tempDate = Me.Max5Date
                            selectedClampNum = 5
                        Else
                            tempDate = Me.Max6Date
                            selectedClampNum = 6
                        End If
                    Else
                        If tempDate > Me.Max5Date Then
                            tempDate = Me.Max5Date
                            selectedClampNum = 5
                        End If
                        If tempDate > Me.Max6Date Then
                            tempDate = Me.Max6Date
                            selectedClampNum = 6
                        End If
                    End If
                ElseIf totalWorkingInMinutes >= projectAPT Then
                    If selectedClampNum = 0 Then
                        tempDate = Me.Max5Date
                        selectedClampNum = 5
                    Else
                        If tempDate > Me.Max5Date Then
                            tempDate = Me.Max5Date
                            selectedClampNum = 5
                        End If
                    End If
                ElseIf totalWorkingInMinutes1 >= projectAPT Then
                    If selectedClampNum = 0 Then
                        tempDate = Me.Max6Date
                        selectedClampNum = 6
                    Else
                        If tempDate > Me.Max6Date Then
                            tempDate = Me.Max6Date
                            selectedClampNum = 6
                        End If
                    End If
                End If
            End If

            If Me.Line7Selected Then
                totalWorkingInMinutes = Me.GetSheduleWorkingMinutes(7, Me.Max7Date)
                If totalWorkingInMinutes >= projectAPT Then
                    If selectedClampNum = 0 Then
                        tempDate = Me.Max7Date
                        selectedClampNum = 7
                    ElseIf tempDate > Me.Max7Date Then
                        tempDate = Me.Max7Date
                        selectedClampNum = 7
                    End If
                End If
            End If
            If Me.Line8Selected Then
                totalWorkingInMinutes = Me.GetSheduleWorkingMinutes(8, Me.Max8Date)
                If totalWorkingInMinutes >= projectAPT Then
                    If selectedClampNum = 0 Then
                        tempDate = Me.Max8Date
                        selectedClampNum = 8
                    ElseIf tempDate > Me.Max8Date Then
                        tempDate = Me.Max8Date
                        selectedClampNum = 8
                    End If
                End If
            End If
            Select Case selectedClampNum
                Case 0
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedLine").Value = DBNull.Value
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedClamp").Value = DBNull.Value
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("EXPDate").Value = DBNull.Value
                Case 1
                    Me.Max1Date = Me.GetExpDateTime(Me.Max1Date, projectAPT, 1)
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedLine").Value = 12
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedClamp").Value = 1
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("EXPDate").Value = Me.Max1Date
                    Me.APT1_ToAdd += projectAPT
                    Me.APT1 += projectAPT
                Case 2
                    Me.Max2Date = Me.GetExpDateTime(Me.Max2Date, projectAPT, 2)
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedLine").Value = 12
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedClamp").Value = 2
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("EXPDate").Value = Me.Max2Date
                    Me.APT2_ToAdd += projectAPT
                    Me.APT2 += projectAPT
                Case 3
                    Me.Max3Date = Me.GetExpDateTime(Me.Max3Date, projectAPT, 3)
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedLine").Value = 34
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedClamp").Value = 3
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("EXPDate").Value = Me.Max3Date
                    Me.APT3_ToAdd += projectAPT
                    Me.APT3 += projectAPT
                Case 4
                    Me.Max4Date = Me.GetExpDateTime(Me.Max4Date, projectAPT, 4)
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedLine").Value = 34
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedClamp").Value = 4
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("EXPDate").Value = Me.Max4Date
                    Me.APT4_ToAdd += projectAPT
                    Me.APT4 += projectAPT
                Case 5
                    Me.Max5Date = Me.GetExpDateTime(Me.Max5Date, projectAPT, 5)
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedLine").Value = 56
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedClamp").Value = 5
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("EXPDate").Value = Me.Max5Date
                    Me.APT5_ToAdd += projectAPT
                    Me.APT5 += projectAPT
                Case 6
                    Me.Max6Date = Me.GetExpDateTime(Me.Max6Date, projectAPT, 6)
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedLine").Value = 56
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedClamp").Value = 6
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("EXPDate").Value = Me.Max6Date
                    Me.APT6_ToAdd += projectAPT
                    Me.APT6 += projectAPT
                Case 7
                    Me.Max7Date = Me.GetExpDateTime(Me.Max7Date, projectAPT, 7)
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedLine").Value = 7
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedClamp").Value = 7
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("EXPDate").Value = Me.Max7Date
                    Me.APT7_ToAdd += projectAPT
                    Me.APT7 += projectAPT
                Case 8
                    Me.Max8Date = Me.GetExpDateTime(Me.Max8Date, projectAPT, 8)
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedLine").Value = 8
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("ProjectedClamp").Value = 8
                    Me.ug_AssemblyStartPopUp_AssemblyStart.Rows(i).Cells("EXPDate").Value = Me.Max8Date
                    Me.APT8_ToAdd += projectAPT
                    Me.APT8 += projectAPT
            End Select
        Next

        If Me.Line12Selected AndAlso (Me.APT1_ToAdd > 0 OrElse Me.APT2_ToAdd > 0) Then
            lblMinRem12.Text = "MIN REM: " & Me.APT1 & " / " & Me.APT2
            lblProj12.Text = Format(Me.Max1Date, "ddd.MMM dd - h:mm tt") & vbNewLine & Format(Me.Max2Date, "ddd.MMM dd - h:mm tt")
            lblProjNewMin12.Text = "MIN ADD: " & Me.APT1_ToAdd & " / " & Me.APT2_ToAdd
        End If
        If Me.Line34Selected AndAlso (Me.APT3_ToAdd > 0 OrElse Me.APT4_ToAdd > 0) Then
            lblMinRem34.Text = "MIN REM: " & Me.APT3 & " / " & Me.APT4
            lblProj34.Text = Format(Me.Max3Date, "ddd.MMM dd - h:mm tt") & vbNewLine & Format(Me.Max4Date, "ddd.MMM dd - h:mm tt")
            lblProjNewMin34.Text = "MIN ADD: " & Me.APT3_ToAdd & " / " & Me.APT4_ToAdd
        End If
        If Me.Line56Selected AndAlso (Me.APT5_ToAdd > 0 OrElse Me.APT6_ToAdd > 0) Then
            lblMinRem56.Text = "MIN REM: " & Me.APT5 & " / " & Me.APT6
            lblProj56.Text = Format(Me.Max5Date, "ddd.MMM dd - h:mm tt") & vbNewLine & Format(Me.Max6Date, "ddd.MMM dd - h:mm tt")
            lblProjNewMin56.Text = "MIN ADD: " & Me.APT5_ToAdd & " / " & Me.APT6_ToAdd
        End If
        If Me.Line7Selected AndAlso Me.APT7_ToAdd > 0 Then
            lblMinRem7.Text = "MIN REM: " & Me.APT7
            lblProj7.Text = Format(Me.Max7Date, "ddd.MMM dd - h:mm tt")
            lblProjNewMin7.Text = "MIN ADD: " & Me.APT7_ToAdd
        End If
        If Me.Line8Selected AndAlso Me.APT8_ToAdd > 0 Then
            lblMinRem8.Text = "MIN REM: " & Me.APT8
            lblProj8.Text = Format(Me.Max8Date, "ddd.MMM dd - h:mm tt")
            lblProjNewMin8.Text = "MIN ADD: " & Me.APT8_ToAdd
        End If

    End Sub

    Function GetSheduleWorkingMinutes(ByVal clampNum As Int16, ByVal beginDateTime As DateTime) As Int32

        Dim retVal As Int32 = 0
        If beginDateTime < Now Then
            beginDateTime = Now
        End If
        Dim scheduleTable As DataTable = KPGeneral.WebRef_Local.GetTable("SELECT ScheduleDate,StartTime,EndTime,WorkingInMinutes FROM ClampDailySchedule WHERE IsDeleted=0 And ClampID=" & clampNum _
                                                                       & " And ScheduleDate=CONVERT(DATE,'" & beginDateTime.Date & "') ORDER BY ScheduleDate", "Shift")
        If scheduleTable.Rows.Count = 1 Then
            Dim start As DateTime = CType(CType(scheduleTable.Rows(0)("ScheduleDate").ToString, Date) & " " & scheduleTable.Rows(0)("StartTime").ToString, DateTime)
            Dim endTime As DateTime = CType(CType(scheduleTable.Rows(0)("ScheduleDate").ToString, Date) & " " & scheduleTable.Rows(0)("EndTime").ToString, DateTime)
            If beginDateTime < start Then
                retVal = Convert.ToInt32(scheduleTable.Rows(0)("WorkingInMinutes").ToString)
            ElseIf beginDateTime <= endTime Then
                If (beginDateTime.Hour = 12 AndAlso beginDateTime.Minute >= 15) OrElse beginDateTime.Hour > 12 Then
                    retVal = (endTime - beginDateTime).TotalMinutes
                ElseIf (beginDateTime.Hour = 11 AndAlso beginDateTime.Minute >= 45) OrElse (beginDateTime.Hour = 12 AndAlso beginDateTime.Minute < 15) Then 'lunch time
                    retVal = (endTime - New DateTime(start.Year, start.Month, start.Day, 12, 15, 0)).TotalMinutes
                Else
                    If beginDateTime >= New DateTime(start.Year, start.Month, start.Day, 11, 45, 0) Then
                        retVal = Convert.ToInt32(scheduleTable.Rows(0)("WorkingInMinutes").ToString) - (beginDateTime - start).TotalMinutes
                    End If
                End If
            End If
        End If
        scheduleTable = KPGeneral.WebRef_Local.GetTable("SELECT SUM(WorkingInMinutes) AS TotalWorkingMinutes FROM ClampDailySchedule WHERE IsDeleted=0 And ClampID=" & clampNum _
                                                       & " And ScheduleDate>CONVERT(DATE,'" & beginDateTime.Date & "')", "Shift")
        If IsDBNull(scheduleTable.Rows(0)("TotalWorkingMinutes")) Then
            Return retVal
        Else
            Return retVal + Convert.ToInt32(scheduleTable.Rows(0)("TotalWorkingMinutes").ToString)
        End If
    End Function

    Function GetExpDateTime(ByVal beginDateTime As DateTime, ByVal APT As Int16, ByVal clampNum As Int16) As DateTime

        If beginDateTime < Now Then
            beginDateTime = Now
        End If

        Dim scheduleTable As DataTable = KPGeneral.WebRef_Local.GetTable("SELECT ScheduleDate,StartTime,EndTime FROM ClampDailySchedule WHERE IsDeleted=0 And ClampID=" & clampNum _
                                                                       & " And ScheduleDate>=CONVERT(DATE,'" & beginDateTime.Date & "') ORDER BY ScheduleDate", "Shift")

        For i As Int16 = 0 To scheduleTable.Rows.Count - 1
            Dim start As DateTime = CType(CType(scheduleTable.Rows(i)("ScheduleDate").ToString, Date) & " " & scheduleTable.Rows(i)("StartTime").ToString, DateTime)
            Dim endTime As DateTime = CType(CType(scheduleTable.Rows(i)("ScheduleDate").ToString, Date) & " " & scheduleTable.Rows(i)("EndTime").ToString, DateTime)
            If beginDateTime < start Then
                beginDateTime = start.AddMinutes(APT)
                If beginDateTime >= New DateTime(start.Year, start.Month, start.Day, 11, 45, 0) Then
                    beginDateTime = beginDateTime.AddMinutes(30)
                End If
            ElseIf beginDateTime <= endTime Then
                If (beginDateTime.Hour = 12 AndAlso beginDateTime.Minute >= 15) OrElse beginDateTime.Hour > 12 Then
                    beginDateTime = beginDateTime.AddMinutes(APT)
                ElseIf (beginDateTime.Hour = 11 AndAlso beginDateTime.Minute >= 45) OrElse (beginDateTime.Hour = 12 AndAlso beginDateTime.Minute < 15) Then 'lunch time
                    beginDateTime = (New DateTime(start.Year, start.Month, start.Day, 12, 15, 0)).AddMinutes(APT)
                Else
                    beginDateTime = beginDateTime.AddMinutes(APT)
                    If beginDateTime >= New DateTime(start.Year, start.Month, start.Day, 11, 45, 0) Then
                        beginDateTime = beginDateTime.AddMinutes(30)
                    End If
                End If
            End If

            If beginDateTime > endTime Then
                APT = (beginDateTime - endTime).TotalMinutes
                beginDateTime = endTime
            Else
                Return beginDateTime
            End If
        Next

        Return beginDateTime

    End Function

    Function CheckThereAreProjectedLines() As Boolean
        Dim LineCount As Integer = 0

        If ug_AssemblyStartPopUp_AssemblyStart.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ug_AssemblyStartPopUp_AssemblyStart.Rows.Count - 1
                If IsDBNull(ug_AssemblyStartPopUp_AssemblyStart.Rows(x).Cells("ProjectedLine").Value) = False Then
                    If ug_AssemblyStartPopUp_AssemblyStart.Rows(x).Cells("ProjectedLine").Text.Trim.Length > 0 Then
                        LineCount = LineCount + 1
                    End If
                End If
            Next
        End If

        If LineCount = ug_AssemblyStartPopUp_AssemblyStart.Rows.Count Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub BtnStartAssembly_Click(sender As Object, e As EventArgs) Handles BtnStartAssembly.Click
        KPGeneral.SetWaitCursor()

        uProgress.Value = 0

        Dim TotalSteps As Integer = 0

        TotalSteps = ug_AssemblyStartPopUp_AssemblyStart.Rows.Count ' Stored Proc to add each lot summary detail info to the DB

        TotalSteps = TotalSteps + 28 'Additional steps are Create Summary, Print Summary, Process Prints (3 prints per line x 4 lines) , Print Labels (Upper + Base x 7 lines)

        uProgress.Step = 100 / TotalSteps

        Dim isProjectedLines As Boolean = CheckThereAreProjectedLines()

        Dim AssemblySummaryID As Integer = 0

        If isProjectedLines = True Then
            AssemblySummaryID = KPGeneral.WebRef_Local.usp_AddAssemblySummary(KPGeneral.User.UserProfile("UserLoginName"))

            SetProgress()


            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns("ProjectedClamp").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            ug_AssemblyStartPopUp_AssemblyStart.DisplayLayout.Bands(0).Columns("EXPDate").SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending

            If AssemblySummaryID > 0 Then
                If ug_AssemblyStartPopUp_AssemblyStart.Rows.Count > 0 Then
                    Dim x As Integer
                    For x = 0 To ug_AssemblyStartPopUp_AssemblyStart.Rows.Count - 1
                        UpdateDBInfo(ug_AssemblyStartPopUp_AssemblyStart, x, AssemblySummaryID)

                        SetProgress()
                    Next

                    KPGeneral.PrintAssemblySummaryReport(AssemblySummaryID, False)

                    SetProgress()
                End If
            End If

            'ProcessAssemblyStart(AssemblySummaryID)
            'AssemblySummaryID = 5

            If AssemblySummaryID > 0 Then
                ProcessPrints(AssemblySummaryID, 12)
                ProcessPrints(AssemblySummaryID, 34)
                ProcessPrints(AssemblySummaryID, 56)
                ProcessPrints(AssemblySummaryID, 7)
                ProcessPrints(AssemblySummaryID, 8)
                Dim x As Integer
                For x = 1 To 8
                    PrintLabels(AssemblySummaryID, x)
                Next
            End If

            FinishSync()

            KPGeneral.SetDefaultCursor()
            Me.Close()
        Else
            KPGeneral.SetDefaultCursor()
            MsgBox("Some lines don't have projected line info.  Please make sure all lines have the proper info and try again.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If



    End Sub

    Private Sub PrintLabels(ByVal AssemblySummaryID As Integer, ByVal ClampNum As Integer)
        Dim dsSummaryBase As New DataSet
        dsSummaryBase = KPGeneral.WebRef_Local.usp_Cabinets_GetLabelSummary_ByAssemblySummaryID_Clamp_isUpper(AssemblySummaryID, ClampNum, False)

        If dsSummaryBase.Tables(0).Rows.Count > 0 Then
            KPGeneral.PrintZebraCabinetLabelsSummary_ByAssemblySummaryID_Clamp_isUpper(AssemblySummaryID, ClampNum, False)

            Threading.Thread.Sleep(5000)

            Dim x As Integer
            For x = 0 To dsSummaryBase.Tables(0).Rows.Count - 1
                InsertPringLog(dsSummaryBase.Tables(0).Rows(x)("CSID"), AssemblySummaryID, "Base Detail - " & ClampNum.ToString)

                KPGeneral.PrintZebraCabinetLabelsDetail_ByAssemblySummaryID_isUpper(dsSummaryBase.Tables(0).Rows(x)("CSID"), False)
            Next
        End If

        SetProgress()

        Dim dsSummaryUpper As New DataSet
        dsSummaryUpper = KPGeneral.WebRef_Local.usp_Cabinets_GetLabelSummary_ByAssemblySummaryID_Clamp_isUpper(AssemblySummaryID, ClampNum, True)

        If dsSummaryUpper.Tables(0).Rows.Count > 0 Then
            KPGeneral.PrintZebraCabinetLabelsSummary_ByAssemblySummaryID_Clamp_isUpper(AssemblySummaryID, ClampNum, True)

            Threading.Thread.Sleep(5000)

            Dim x As Integer
            For x = 0 To dsSummaryBase.Tables(0).Rows.Count - 1
                InsertPringLog(dsSummaryUpper.Tables(0).Rows(x)("CSID"), AssemblySummaryID, "Upper Detail - " & ClampNum.ToString)

                KPGeneral.PrintZebraCabinetLabelsDetail_ByAssemblySummaryID_isUpper(dsSummaryUpper.Tables(0).Rows(x)("CSID"), True)
            Next
        End If

        SetProgress()
    End Sub
    Private Sub InsertPringLog(ByVal CSID As Integer, ByVal AssemblyID As Integer, ByVal PrintAction As String)
        KPGeneral.WebRef_Local.usp_AddAssemblyStartPrintLog(CSID, AssemblyID, PrintAction)
    End Sub
    Private Sub ProcessPrints(ByVal AssemblySummaryID As Integer, ByVal LinePair As Integer)
        Dim dsLine As New DataSet
        dsLine = KPGeneral.WebRef_Local.usp_GetgAssemblySummariesDetailsByAssemblySummaryIDAndLinePair(AssemblySummaryID, LinePair)

        If dsLine.Tables(0).Rows.Count > 0 Then
            Dim x, y As Integer
            For y = 1 To 2
                For x = 0 To dsLine.Tables(0).Rows.Count - 1
                    Dim CSID As Integer = dsLine.Tables(0).Rows(x)("CSID")

                    Dim PrintAction As String = ""

                    If y < 3 Then
                        'Just started, do prints
                        'White Copies
                        PrintAction = "Print Layout - " & LinePair & " - White copies"
                        KPGeneral.PrintLayoutPage("Assembly Start", CSID, KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(CSID, 0), True, False, 1, 2, False, False)
                        'ElseIf LinePair = "56" And y = 1 Then
                        '    'White Copies
                        '    PrintAction = "Print Layout - " & LinePair & " - White copies"
                        '    KPGeneral.PrintLayoutPage("Assembly Start", CSID, KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(CSID, 0), True, False, 1, 2, False, False)
                    End If

                    If y = 3 Then
                        'Pink Copies
                        PrintAction = "Print Layout - " & LinePair & " - Pink copies"
                        KPGeneral.PrintLayoutPage("Assembly Start", CSID, KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(CSID, 0), True, False, 1, 3, False, False)
                    End If

                    InsertPringLog(CSID, AssemblySummaryID, PrintAction)
                Next

                SetProgress()
            Next

        End If


    End Sub

    Function CheckPreAssemblyStart(ByVal MasterNum As String) As Boolean
        Dim dsOrderStatus As New DataSet

        dsOrderStatus = KPGeneral.WebRef_Local.spKP_OrderStatusByFK(Trim(MasterNum))

        Dim AssemblyStarted As Boolean = False

        If IsDBNull(dsOrderStatus.Tables(0).Rows(0)("AssemblyStartDate")) = False Then
            Return False
        End If

        Return True
    End Function
    Private Sub UpdateDBInfo(ByVal uGrid As UltraGrid, ByVal RowIndex As Integer, ByVal AssemblySummaryID As Integer)
        If IsDBNull(uGrid.Rows(RowIndex).Cells("ProjectedLine").Value) = False Then
            KPGeneral.WebRef_Local.usp_AddAssemblySummaryDetails(AssemblySummaryID, uGrid.Rows(RowIndex).Cells("CSID").Text,
                    uGrid.Rows(RowIndex).Cells("ProjectedLine").Text, uGrid.Rows(RowIndex).Cells("ProjectedClamp").Text, uGrid.Rows(RowIndex).Cells("EXPDate").Value)

            Dim OrderCancelled As Boolean = False

            Dim MasterNum As String = uGrid.Rows(RowIndex).Cells("MasterNum").Text
            Dim CSID As Integer = uGrid.Rows(RowIndex).Cells("CSID").Text

            Dim PreCheckAssemblyStart As Boolean = CheckPreAssemblyStart(MasterNum)

            ''remove on final release
            'PreCheckAssemblyStart = True

            If PreCheckAssemblyStart = True Then
                Dim dsLabels As New DataSet
                Dim ds As DataSet
                ds = KPGeneral.WebRef_Local.spKP_LotInfoByFK(Trim(ug_AssemblyStartPopUp_AssemblyStart.Rows(RowIndex).Cells("MasterNum").Text))

                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0)("CancelOrder") = True Then
                        OrderCancelled = True
                    End If

                    If OrderCancelled = False Then
                        KPGeneral.WebRef_Local.usp_UpdateAssignedClamp(ds.Tables(0).Rows(0)("CSID"), uGrid.Rows(RowIndex).Cells("ProjectedClamp").Value)
                        KPGeneral.SystemHistory(ds.Tables(0).Rows(0)("CSID"), "AssemblyStartPopUp", "StartAssembly", KPGeneral.User.UserProfile("UserLoginName"))

                        If KPGeneral.WebRef_Local.spKPFactory_AssemblyStart(Now.Date, Trim(MasterNum), ds.Tables(0).Rows(0)("CSID"), uGrid.Rows(RowIndex).Cells("ProjectedLine").Text) = False Then
                            'Already Started
                        Else

                        End If

                    End If

                Else

                End If
            End If
        End If


    End Sub

    Private Sub PrintCabinetLabels(ByVal MasterNum As String)
        Dim Match As Boolean = False
        Dim OrderLocked As Boolean = False

        Dim dsCSID, dsLabelInfo As New DataSet
        dsCSID = KPGeneral.WebRef_Local.getCSIDByMasterNo(MasterNum)

        Dim CSID As Integer

        CSID = dsCSID.Tables(0).Rows(0)("CSID")

        dsLabelInfo = KPGeneral.WebRef_Local.usp_getASsemblyCabinetLabelInfoByCSID(CSID)

        'If IsDBNull(ugProductionGroup.Selected.Rows(x).Cells("ProductionGroupPrintLocked").Value) = False Then
        '    OrderLocked = ugProductionGroup.Selected.Rows(x).Cells("ProductionGroupPrintLocked").Value
        'End If

        If dsLabelInfo.Tables(0).Rows.Count > 0 Then
            If OrderLocked = False Then
                If IsDBNull(dsLabelInfo.Tables(0).Rows(0)("CabinetLabelPrinted")) = False Then
                    If MsgBox("The order " & MasterNum & " has already been printed.  Do you wish to print again?", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.Yes Then
                        Match = True
                    End If
                Else
                    Match = True
                End If

                If Match = True Then

                    KPGeneral.WebRef_Local.spKPFactory_Labels_IncrementPrintCounter(CSID)
                    KPGeneral.PrintZebraCabinetLabelsByCSID_AssemblyStart(CSID)
                    'ugProductionGroup.Selected.Rows(x).Cells("CabinetLabelPrinted").Value = Now.Date
                End If
            Else
                MsgBox("The order - " & MasterNum & " - is locked from printing.  Please speak to Greg D about this.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If

    End Sub
    Private Sub SetProgress()
        Me.BeginInvoke(Sub() Me.uProgress.PerformStep())
    End Sub
    Private Sub FinishSync()
        Me.BeginInvoke(Sub() Me.uProgress.Value = 100)
        Me.BeginInvoke(Sub() Me.Cursor = Cursors.Default)
    End Sub

    Private Sub btnLine8_Click(sender As Object, e As EventArgs) Handles btnLine8.Click
        SwapSelected(8)
    End Sub
End Class