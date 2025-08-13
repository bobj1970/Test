Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports System.IO
Public Class frmDrawerboxAssembly
    Dim GridSummary As Boolean
    Dim T As Integer

    Private Sub frmTandemBox_Load(sender As Object, e As EventArgs) Handles Me.Load

        KPGeneral.SetDefaultGridSettings(ug_DrawerboxAssembly_CompletedToday)
        KPGeneral.SetDefaultGridSettings(ug_DrawerboxAssembly_Others)
        KPGeneral.SetDefaultGridSettings(ug_DrawerboxAssembly_PriorityInAssembly)
        KPGeneral.SetDefaultGridSettings(ug_DrawerboxAssembly_MetaboxDemand)

        KPGeneral.SetGridRowFilterSettings(ug_DrawerboxAssembly_CompletedToday)
        KPGeneral.SetGridRowFilterSettings(ug_DrawerboxAssembly_Others)
        KPGeneral.SetGridRowFilterSettings(ug_DrawerboxAssembly_PriorityInAssembly)
        KPGeneral.SetGridRowFilterSettings(ug_DrawerboxAssembly_MetaboxDemand)

        ug_DrawerboxAssembly_CompletedToday.DisplayLayout.Override.FilterUIProvider = UltraGridFilterUIProvider1
        ug_DrawerboxAssembly_Others.DisplayLayout.Override.FilterUIProvider = UltraGridFilterUIProvider1
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Override.FilterUIProvider = UltraGridFilterUIProvider1
        ug_DrawerboxAssembly_MetaboxDemand.DisplayLayout.Override.FilterUIProvider = UltraGridFilterUIProvider1

        'KPGeneral.SetDisableGridColumnSorting(ug_DrawerboxAssembly_CompletedToday)
        'KPGeneral.SetDisableGridColumnSorting(ug_DrawerboxAssembly_Others)
        'KPGeneral.SetDisableGridColumnSorting(ug_DrawerboxAssembly_PriorityInAssembly)
        'KPGeneral.SetDisableGridColumnSorting(ug_DrawerboxAssembly_MetaboxDemand)

        GridSummary = False
        RefreshAll()
        Me.dtFrom.DateTime = Today
        Me.dtTo.DateTime = Today.AddDays(15)

    End Sub
    Private Sub RefreshAll()
        RefreshPriority()
        RefreshOthers()
        RefreshCompletedToday()
    End Sub
    Private Sub RefreshCompletedToday()
        'Dim dsCompleted As New DataSet
        'dsCompleted = KPGeneral.WebRef_Local.spKPFactory_Tandembox_CompletedToday

        ug_DrawerboxAssembly_CompletedToday.DataSource = KPGeneral.KPDataSQL.SP_EXEC("t_Tandembox_CompletedToday") 'dsCompleted
        ug_DrawerboxAssembly_CompletedToday.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ug_DrawerboxAssembly_CompletedToday.DisplayLayout.Bands(0).Columns("MasterNum").Width = 100
        ug_DrawerboxAssembly_CompletedToday.DisplayLayout.Bands(0).Columns("Company").Width = 250
        ug_DrawerboxAssembly_CompletedToday.DisplayLayout.Bands(0).Columns("Project").Width = 250
        ug_DrawerboxAssembly_CompletedToday.DisplayLayout.Bands(0).Columns("Lot").Width = 150
        ug_DrawerboxAssembly_CompletedToday.DisplayLayout.Bands(0).Columns("TandemboxCompleteDate").Width = 100
        ug_DrawerboxAssembly_CompletedToday.DisplayLayout.Bands(0).Columns("TandemboxCompleteDate").Format = KPGeneral.DateTime12HourFormatString
        Dim drawerCount As Int32 = 0
        For Each r As UltraGridRow In Me.ug_DrawerboxAssembly_CompletedToday.Rows
            drawerCount = drawerCount + r.Cells("Drawer").Value
        Next
        KPGeneral.RefreshGridFromLayout(ug_DrawerboxAssembly_CompletedToday, Me.GetType.Name)
        lblToday.Text = "Completed Today - (" & ug_DrawerboxAssembly_CompletedToday.Rows.Count & " orders / " & drawerCount & " Drawers)"
    End Sub
    Private Sub RefreshOthers()
        'Dim dsOthers As New DataSet
        'dsOthers = KPGeneral.WebRef_Local.spKPFactory_Tandembox_Others

        ug_DrawerboxAssembly_Others.DataSource = KPGeneral.KPDataSQL.SP_EXEC("t_Tandembox_Others")
        Dim drawerCount As Int32 = 0
        Dim x As Integer
        For x = 0 To ug_DrawerboxAssembly_Others.Rows.Count - 1
            If ug_DrawerboxAssembly_Others.Rows(x).Cells("ProdDef").Value > 0 Then
                ug_DrawerboxAssembly_Others.Rows(x).Appearance.BackColor = Color.LightSalmon
            End If

            If IsDBNull(ug_DrawerboxAssembly_Others.Rows(x).Cells("OnHold").Value) = False Then
                If ug_DrawerboxAssembly_Others.Rows(x).Cells("OnHold").Value = True Then
                    ug_DrawerboxAssembly_Others.Rows(x).Appearance.BackColor = Color.FromName(StatusColours.OnHold_BackColour)
                    ug_DrawerboxAssembly_Others.Rows(x).Appearance.ForeColor = Color.FromName(StatusColours.OnHold_ForeColour)
                End If
            End If

            If ug_DrawerboxAssembly_Others.Rows(x).Cells("HingeDate").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_Others.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_Others.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_DrawerboxAssembly_Others.Rows(x).Cells("DoorsPickedDate").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_Others.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_Others.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_DrawerboxAssembly_Others.Rows(x).Cells("PB").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("PB").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_Others.Rows(x).Cells("PB").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("PB").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_Others.Rows(x).Cells("PB").Appearance.ForeColor = Color.Tomato
            End If

            If ug_DrawerboxAssembly_Others.Rows(x).Cells("PU").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("PU").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_Others.Rows(x).Cells("PU").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("PU").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_Others.Rows(x).Cells("PU").Appearance.ForeColor = Color.Tomato
            End If


            If ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Text <> Nothing Then
                ' ugReady.Rows(x).Cells("AssemblyStartDate").Value = "Y"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
            Else
                ' ugReady.Rows(x).Cells("AssemblyStartDate").Value = "N"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_DrawerboxAssembly_Others.Rows(x).Cells("CabinetsCompleteDate").Text <> Nothing Then
                ' ugReady.Rows(x).Cells("CabinetsCompleteDate").Value = "Y"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("CabinetsCompleteDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_Others.Rows(x).Cells("CabinetsCompleteDate").Appearance.ForeColor = Color.YellowGreen
            Else
                ' ugReady.Rows(x).Cells("CabinetsCompleteDate").Value = "N"
                ug_DrawerboxAssembly_Others.Rows(x).Cells("CabinetsCompleteDate").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_Others.Rows(x).Cells("CabinetsCompleteDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_DrawerboxAssembly_Others.Rows(x).Cells("OrderSTatus").Text = Nothing = False Then
                If Trim(ug_DrawerboxAssembly_Others.Rows(x).Cells("OrderSTatus").Text) = "Pending" Then
                    ug_DrawerboxAssembly_Others.Rows(x).Cells("Lot").Appearance.BackColor = Color.Orange
                ElseIf Trim(ug_DrawerboxAssembly_Others.Rows(x).Cells("OrderSTatus").Text) = "Cancel" Then
                    ug_DrawerboxAssembly_Others.Rows(x).Cells("Lot").Appearance.BackColor = Color.Tomato
                    ug_DrawerboxAssembly_Others.Rows(x).Cells("Lot").Appearance.ForeColor = Color.White
                Else

                End If
            Else
                ug_DrawerboxAssembly_Others.Rows(x).Cells("OrderSTatus").Value = ""
            End If


            If IsDBNull(ug_DrawerboxAssembly_Others.Rows(x).Cells("TotalDoors").Value) = True Then
                ug_DrawerboxAssembly_Others.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_Others.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
                ug_DrawerboxAssembly_Others.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_Others.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
                If IsDBNull(ug_DrawerboxAssembly_Others.Rows(x).Cells("TotalCabinets").Value) = True Then
                    ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                    ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                Else
                    If ug_DrawerboxAssembly_Others.Rows(x).Cells("TotalCabinets").Value = 0 Then
                        ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                        ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                    End If
                End If
            Else
                If ug_DrawerboxAssembly_Others.Rows(x).Cells("TotalDoors").Value = 0 Then
                    ug_DrawerboxAssembly_Others.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                    ug_DrawerboxAssembly_Others.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
                    ug_DrawerboxAssembly_Others.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                    ug_DrawerboxAssembly_Others.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
                    If IsDBNull(ug_DrawerboxAssembly_Others.Rows(x).Cells("TotalCabinets").Value) = True Then
                        ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                        ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                    Else
                        If ug_DrawerboxAssembly_Others.Rows(x).Cells("TotalCabinets").Value = 0 Then
                            ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                            ug_DrawerboxAssembly_Others.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                        End If
                    End If
                End If
            End If
            drawerCount = drawerCount + ug_DrawerboxAssembly_Others.Rows(x).Cells("Drawer").Value
        Next

        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        KPGeneral.RefreshGridFromLayout(ug_DrawerboxAssembly_Others, Me.GetType.Name)
        LoadFilter(112, ug_DrawerboxAssembly_Others)
        StyleOthersGrid()

        lblOther.Text = "Others on Shop Floor - (" & ug_DrawerboxAssembly_Others.Rows.Count & " orders / " & drawerCount & " Drawers)"
    End Sub
    Private Sub RefreshPriority()
        Dim dsPriority As New DataSet
        dsPriority = KPGeneral.KPDataSQL.SP_EXEC("t_TandemboxPriorityAssemblyStarted") 'KPGeneral.WebRef_Local.spKPFactory_Tandembox_PriorityAssemblyStarted

        ug_DrawerboxAssembly_PriorityInAssembly.DataSource = dsPriority
        Dim drawerCount As Int32 = 0
        Dim x As Integer
        For x = 0 To ug_DrawerboxAssembly_PriorityInAssembly.Rows.Count - 1
            If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("ProdDef").Value > 0 Then
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Appearance.BackColor = Color.LightSalmon
            End If

            If IsDBNull(ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("OnHold").Value) = False Then
                If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("OnHold").Value = True Then
                    ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Appearance.BackColor = Color.FromName(StatusColours.OnHold_BackColour)
                    ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Appearance.ForeColor = Color.FromName(StatusColours.OnHold_ForeColour)
                End If
            End If

            If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("HingeDate").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("DoorsPickedDate").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("PB").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("PB").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("PB").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("PB").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("PB").Appearance.ForeColor = Color.Tomato
            End If

            If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("PU").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("PU").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("PU").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("PU").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("PU").Appearance.ForeColor = Color.Tomato
            End If


            If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Text <> Nothing Then
                ' ugReady.Rows(x).Cells("AssemblyStartDate").Value = "Y"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
            Else
                ' ugReady.Rows(x).Cells("AssemblyStartDate").Value = "N"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("CabinetsCompleteDate").Text <> Nothing Then
                ' ugReady.Rows(x).Cells("CabinetsCompleteDate").Value = "Y"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("CabinetsCompleteDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("CabinetsCompleteDate").Appearance.ForeColor = Color.YellowGreen
            Else
                ' ugReady.Rows(x).Cells("CabinetsCompleteDate").Value = "N"
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("CabinetsCompleteDate").Appearance.BackColor = Color.Tomato
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("CabinetsCompleteDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("OrderSTatus").Text = Nothing = False Then
                If Trim(ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("OrderSTatus").Text) = "Pending" Then
                    ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("Lot").Appearance.BackColor = Color.Orange
                ElseIf Trim(ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("OrderSTatus").Text) = "Cancel" Then
                    ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("Lot").Appearance.BackColor = Color.Tomato
                    ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("Lot").Appearance.ForeColor = Color.White
                Else

                End If
            Else
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("OrderSTatus").Value = ""
            End If


            If IsDBNull(ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("TotalDoors").Value) = True Then
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
                If IsDBNull(ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("TotalCabinets").Value) = True Then
                    ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                    ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                Else
                    If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("TotalCabinets").Value = 0 Then
                        ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                        ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                    End If
                End If
            Else
                If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("TotalDoors").Value = 0 Then
                    ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                    ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
                    ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                    ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
                    If IsDBNull(ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("TotalCabinets").Value) = True Then
                        ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                        ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                    Else
                        If ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("TotalCabinets").Value = 0 Then
                            ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                            ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                        End If
                    End If
                End If
            End If
            drawerCount = drawerCount + ug_DrawerboxAssembly_PriorityInAssembly.Rows(x).Cells("Drawer").Value
        Next
        ''lblShowing.Text = "Orders Showing = " & ugReady.Rows.Count

        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("CSID").Hidden = True

        KPGeneral.RefreshGridFromLayout(ug_DrawerboxAssembly_PriorityInAssembly, Me.GetType.Name)
        Me.ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
        StylePriorityGrid()

        lblPriority.Text = "Priority - Assembly Started - (" & ug_DrawerboxAssembly_PriorityInAssembly.Rows.Count & " orders / " & drawerCount & " Drawers)"
    End Sub
    Private Sub StylePriorityGrid()
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("Shipper").Header.Caption = "Driver"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("ClassificationLevel").Header.Caption = "Class"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("PROJECT").Header.Caption = "Project"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("LOT").Header.Caption = "Lot"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("MASTERNUM").Header.Caption = "MasterNum"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("AssemblyStartDate").Header.Caption = "AS"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("HingeDate").Header.Caption = "H"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("DoorsPickedDate").Header.Caption = "DP"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("CabinetsCompleteDate").Header.Caption = "PLC"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("TotalCabinetsAssembled").Header.Caption = "A"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("TotalCabinets").Header.Caption = "Cabs"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("TotalDoors").Header.Caption = "Doors"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("COMPANY").Header.Caption = "Company"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("PU").Header.Caption = "WP"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("PB").Header.Caption = "BP"
        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Bands(0).Columns("BoxDateExpected").Format = KPGeneral.DateTime12HourFormatString

        If GridSummary = True Then
            ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.True
            ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True
        Else
            ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.False
            ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.None
            ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False
        End If

        ug_DrawerboxAssembly_PriorityInAssembly.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    End Sub
    Private Sub StyleOthersGrid()
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("Shipper").Header.Caption = "Driver"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("ClassificationLevel").Header.Caption = "Class"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("PROJECT").Header.Caption = "Project"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("LOT").Header.Caption = "Lot"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("MASTERNUM").Header.Caption = "MasterNum"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("AssemblyStartDate").Header.Caption = "AS"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("HingeDate").Header.Caption = "H"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("DoorsPickedDate").Header.Caption = "DP"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("CabinetsCompleteDate").Header.Caption = "PLC"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("TotalCabinetsAssembled").Header.Caption = "A"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("TotalCabinets").Header.Caption = "Cabs"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("TotalDoors").Header.Caption = "Doors"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("COMPANY").Header.Caption = "Company"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("PU").Header.Caption = "WP"
        ug_DrawerboxAssembly_Others.DisplayLayout.Bands(0).Columns("PB").Header.Caption = "BP"

        If GridSummary = True Then
            ug_DrawerboxAssembly_Others.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.True
            ug_DrawerboxAssembly_Others.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            ug_DrawerboxAssembly_Others.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True
        Else
            ug_DrawerboxAssembly_Others.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.False
            ug_DrawerboxAssembly_Others.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.None
            ug_DrawerboxAssembly_Others.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False
        End If

        ug_DrawerboxAssembly_Others.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    End Sub
    Private Sub LoadFilter(ByVal FilterID As Integer, ByVal uGrid As UltraGrid)
        Dim dsFilters As New DataSet

        dsFilters = KPGeneral.WebRef_Local.usp_GetProductionStatusFilter

        'txtFilterName.Text = UGrid.Rows(ARow).Cells("FilterName").Text
        'PrintFilter = UGrid.Rows(ARow).Cells("FilterName").Text
        'txtFilterDescription.Text = UGrid.Rows(ARow).Cells("FilterDescription").Text

        Dim gridname As String

        gridname = uGrid.Name()

        Dim FilePath As String
        FilePath = KPGeneral.StartupPath.ToString & "\" & gridname & ".xml"

        Dim FilterRow As Integer

        Dim y As Integer
        For y = 0 To dsFilters.Tables(0).Rows.Count - 1
            If dsFilters.Tables(0).Rows(y)("FilterID") = 112 Then
                FilterRow = y
                Exit For
            End If
        Next

        If FilterRow > 0 Then
            Dim ms() As Byte = dsFilters.Tables(0).Rows(FilterRow)("FilterFile")
            Dim stmBLOBData As New MemoryStream(ms)

            Dim PdfImage As New BinaryWriter(File.Create(FilePath))
            PdfImage.Write(ms)
            PdfImage.Close()

            KPGeneral.RefreshGridFromLayout(uGrid, Me.GetType.Name, FilePath)
            'uGrid.DisplayLayout.LoadFromXml(FilePath)

            Dim TotalDoors As Int32 = 0
            Dim TimePlanned As Int32 = 0
            Dim LoadCount As Int32 = 0
            Dim row As UltraGridRow
            For Each row In uGrid.Rows.GetFilteredInNonGroupByRows
                If Not IsDBNull(row.Cells("TotalDoors").Value) Then
                    TotalDoors = TotalDoors + row.Cells("TotalDoors").Value
                End If
                'If Not IsDBNull(row.Cells("APT").Value) Then
                '    TimePlanned = TimePlanned + row.Cells("APT").Value
                'End If
                'If Not IsDBNull(row.Cells("LoadCount").Value) Then
                '    LoadCount = LoadCount + row.Cells("LoadCount").Value
                'End If
            Next

            'lblShowing.Text = "Orders Showing = " & ugReady.Rows.FilteredInRowCount & " \ " & TotalDoors & " Doors"
            uGrid.DisplayLayout.Bands(0).Columns("ProdDef").Header.Caption = "OpenPDef"
            'lblPlannedTimeShown.Text = "Planned Time Shown: " & TimePlanned
            'lblLoadTimeShown.Text = "Load Count Shown: " & LoadCount

            Dim x As Integer
            For x = 0 To uGrid.Rows.FilterRow.Cells.Count - 1
                If IsDBNull(uGrid.Rows.FilterRow.Cells(x).Value) = False Then
                    If uGrid.Rows.FilterRow.Cells(x).Value.ToString.ToLower.Contains("custom") Then
                        If uGrid.DisplayLayout.Bands(0).Columns(x).DataType.Name.ToLower.Contains("date") Then
                            'Dim FDate, TDate As Date
                            'If Now.Date.DayOfWeek = DayOfWeek.Monday Then
                            '    FDate = Now.Date.AddDays(-7)
                            '    TDate = Now.Date.AddDays(13)
                            'ElseIf Now.Date.DayOfWeek = DayOfWeek.Tuesday Then
                            '    FDate = Now.Date.AddDays(-8)
                            '    TDate = Now.Date.AddDays(12)
                            'ElseIf Now.Date.DayOfWeek = DayOfWeek.Wednesday Then
                            '    FDate = Now.Date.AddDays(-9)
                            '    TDate = Now.Date.AddDays(11)
                            'ElseIf Now.Date.DayOfWeek = DayOfWeek.Thursday Then
                            '    FDate = Now.Date.AddDays(-10)
                            '    TDate = Now.Date.AddDays(10)
                            'ElseIf Now.Date.DayOfWeek = DayOfWeek.Friday Then
                            '    FDate = Now.Date.AddDays(-11)
                            '    TDate = Now.Date.AddDays(9)
                            'ElseIf Now.Date.DayOfWeek = DayOfWeek.Saturday Then
                            '    FDate = Now.Date.AddDays(-12)
                            '    TDate = Now.Date.AddDays(8)
                            'End If

                            'ugReady.DisplayLayout.Bands(0).ColumnFilters(x).FilterConditions.Clear()

                            'Dim filter As New FilterCondition(FilterComparisionOperator.GreaterThanOrEqualTo, FDate)
                            'ugReady.DisplayLayout.Bands(0).ColumnFilters(x).FilterConditions.Add(filter)

                            'filter = New FilterCondition(FilterComparisionOperator.LessThanOrEqualTo, TDate)
                            'ugReady.DisplayLayout.Bands(0).ColumnFilters(x).FilterConditions.Add(filter)

                            'ugReady.DisplayLayout.Bands(0).ColumnFilters(x).LogicalOperator = FilterLogicalOperator.And
                        End If
                    End If
                End If

            Next
        End If

        uGrid.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        uGrid.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        uGrid.DisplayLayout.Override.TipStyleHeader = TipStyle.Show

    End Sub
    Private Sub btnStartNext_Click(sender As Object, e As EventArgs) Handles btnStartNext.Click
        Dim PrintedTandembox As Boolean = False

        Do While PrintedTandembox = False
            If PrintedTandembox = False Then
                If ug_DrawerboxAssembly_PriorityInAssembly.Rows.Count > 0 Then
                    StartTandemboxOrder(ug_DrawerboxAssembly_PriorityInAssembly.Rows(0).Cells("CSID").Text)
                    PrintedTandembox = True
                End If
            End If

            If PrintedTandembox = False Then
                If ug_DrawerboxAssembly_Others.Rows.Count > 0 Then
                    StartTandemboxOrder(ug_DrawerboxAssembly_Others.Rows(0).Cells("CSID").Text)
                    PrintedTandembox = True
                End If
            End If
        Loop

        RefreshAll()
    End Sub
    Private Sub PrintLayoutPage(ByVal Copies As Integer, ByVal CSID As Integer)
        KPGeneral.PrintLayoutPage("Tandembox", CSID, KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(CSID, 0), True, False, Copies, 15, False, False)
    End Sub
    Sub txtBarcode_enter(ByVal o As [Object], ByVal e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                e.Handled = True
                'If UcWebStatus1.WebServFound(Me) = True Then
                'Enter Pressed
                If Trim(txtBarcode.Text) = Nothing Then
                    lblMessage.Text = Nothing
                    Exit Sub
                End If

                Dim ds As DataSet
                ds = KPGeneral.WebRef_Local.spKP_LotInfoByFK(Trim(txtBarcode.Text))

                If ds.Tables(0).Rows.Count > 0 Then
                    'Start Cancelled Order (Rich Added - 09/06/06)
                    If ds.Tables(0).Rows(0)("CancelOrder") = True Then
                        lblMessage.Text = "Order Cancelled!"
                        txtBarcode.Text = Nothing
                        txtBarcode.Focus()
                        Exit Sub
                    End If
                    lblMessage.Text = Nothing

                    If IsDBNull(ds.Tables(0).Rows(0)("OrderStatus")) = False Then
                        If Trim(ds.Tables(0).Rows(0)("OrderStatus")) = "Pending" Then
                            lblMessage.Text = ds.Tables(0).Rows(0)("Masternum") & "Order Pending!"
                            MessageBox.Show("Please hold the last order you scanned. Please Contact your supervisor/manager to resolve the PENDING status of the last Order.")
                            'txtBarcode.Text = vbNullString
                            'txtBarcode.Focus()
                        End If
                    End If

                    'End Cancelled Order

                    'This web service checks if order is already scanned: if not scanned...
                    '                                                       updates status table and inserts into warehouse table 
                    '                                                       and returns true else it returns flase


                    'DefectDoors(ds.Tables(0).Rows(0)("CSID"))
                    If KPGeneral.WebRef_Local.usp_UpdateTandemBoxCompleteDate(ds.Tables(0).Rows(0)("CSID")) = False Then
                        lblMessage.Text = "Order Already Scanned!"
                    Else

                        RefreshCompletedToday()
                    End If
                Else
                    lblMessage.Text = "Input is not a VALID FK-NUMBER"
                End If


                txtBarcode.Text = vbNullString
                txtBarcode.Focus()
            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try


    End Sub
    Private Sub LoadKitchenTrackerByCSID(ByVal CSID As Integer)
        KPGeneral.ViewKitchenTrackerByCSID(CSID)
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem.Click
        If ug_DrawerboxAssembly_PriorityInAssembly.ActiveRow.Index > -1 Then
            LoadKitchenTrackerByCSID(ug_DrawerboxAssembly_PriorityInAssembly.ActiveRow.Cells("CSID").Text)
        End If
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem2.Click
        If ug_DrawerboxAssembly_Others.ActiveRow.Index > -1 Then
            LoadKitchenTrackerByCSID(ug_DrawerboxAssembly_Others.ActiveRow.Cells("CSID").Text)
        End If
    End Sub
    Private Sub StartTandemboxOrder(ByVal CSID As Integer)
        KPGeneral.PrintZebraTandemboxLabelByCSID4x6(CSID, True)
        KPGeneral.WebRef_Local.usp_UpdateTandemBoxPrintDate(CSID)
        PrintLayoutPage(1, CSID)
    End Sub
    Private Sub StartTandemboxOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartTandemboxOrderToolStripMenuItem.Click
        If ug_DrawerboxAssembly_PriorityInAssembly.ActiveRow.Index > -1 Then
            StartTandemboxOrder(ug_DrawerboxAssembly_PriorityInAssembly.ActiveRow.Cells("CSID").Text)
            RefreshAll()
        End If
    End Sub
    Private Sub PrintLayoutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If ugRecentPrints.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugRecentPrints.Selected.Rows.Count - 1
                PrintLayoutPage(1, ugRecentPrints.Selected.Rows(x).Cells("CSID").Text)
            Next
        End If
    End Sub
    Private Sub ReprintTandemboxLabelsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If ugRecentPrints.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugRecentPrints.Selected.Rows.Count - 1
                KPGeneral.PrintZebraTandemboxLabelByCSID4x6(ugRecentPrints.Selected.Rows(x).Cells("CSID").Text, True)
                KPGeneral.WebRef_Local.usp_UpdateTandemBoxPrintDate(ugRecentPrints.Selected.Rows(x).Cells("CSID").Text)
            Next
        End If
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles tsmKitchenTrackerR.Click
        If ugRecentPrints.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByCSID(ugRecentPrints.ActiveRow.Cells("CSID").Text)
        End If
    End Sub
    Private Sub GetRecentOrders()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetTandemboxLabelsRecentlyPrinted

        ugRecentPrints.DataSource = ds

        ugRecentPrints.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ugRecentPrints.DisplayLayout.Bands(0).Columns("Company").Width = 200
        ugRecentPrints.DisplayLayout.Bands(0).Columns("Project").Width = 200
        ugRecentPrints.DisplayLayout.Bands(0).Columns("Lot").Width = 150
        ugRecentPrints.DisplayLayout.Bands(0).Columns("TBS").Width = 150
        ugRecentPrints.DisplayLayout.Bands(0).Columns("TBC").Width = 150
        ugRecentPrints.DisplayLayout.Bands(0).Columns("TBS").Format = KPGeneral.DateTime12HourFormatString
        ugRecentPrints.DisplayLayout.Bands(0).Columns("TBC").Format = KPGeneral.DateTime12HourFormatString
        KPGeneral.RefreshGridFromLayout(ugRecentPrints, Me.GetType.Name)
        'ugPrintedToday.DisplayLayout.Bands(0).Columns("LabelNo").Hidden = True
    End Sub
    Private Sub UltraTabControl1_ActiveTabChanged(sender As Object, e As ActiveTabChangedEventArgs) Handles UltraTabControl1.ActiveTabChanged
        If UltraTabControl1.ActiveTab.Index = 0 Then
            RefreshAll()
        ElseIf UltraTabControl1.ActiveTab.Index = 1 Then
            GetRecentOrders()
        Else
            RefreshMetaboxDemand()
        End If
    End Sub

    Private Sub PrintLayoutToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles PrintLayoutToolStripMenuItem.Click
        If ugRecentPrints.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugRecentPrints.Selected.Rows.Count - 1
                PrintLayoutPage(1, ugRecentPrints.Selected.Rows(x).Cells("CSID").Text)
            Next
        End If
    End Sub

    Private Sub ReprintTandemboxLabelsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReprintTandemboxLabelsToolStripMenuItem.Click
        If ugRecentPrints.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugRecentPrints.Selected.Rows.Count - 1
                KPGeneral.PrintZebraTandemboxLabelByCSID4x6(ugRecentPrints.Selected.Rows(x).Cells("CSID").Text, True)
                KPGeneral.WebRef_Local.usp_UpdateTandemBoxPrintDate(ugRecentPrints.Selected.Rows(x).Cells("CSID").Text)
            Next
        End If
    End Sub

    Private Sub ColumnChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem.Click
        KPGeneral.ColumnChooser(ug_DrawerboxAssembly_PriorityInAssembly, Me.GetType.Name)
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        T = T + 1
        If T > 600 Then
            RefreshAll()
            T = 0
        End If
    End Sub

    Private Sub ColumnChooserToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem1.Click
        KPGeneral.ColumnChooser(ug_DrawerboxAssembly_MetaboxDemand, Me.GetType.Name)
    End Sub
    Private Sub RefreshMetaboxDemand()

        ug_DrawerboxAssembly_MetaboxDemand.DataSource = KPGeneral.KPDataSQL.SP_EXEC("t_GetMetaboxOrdersDemandByDate", dtFrom.DateTime, dtTo.DateTime.AddDays(1))
        KPGeneral.RefreshGridFromLayout(ug_DrawerboxAssembly_MetaboxDemand, Me.GetType.Name)

    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshMetaboxDemand()
    End Sub
    Private Sub PrintGridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintGridToolStripMenuItem.Click
        'StyleRevisedOrdersPrint()
        'StyleGridPrintSelected()
        UltraGridPrintDocument1.Grid = ug_DrawerboxAssembly_MetaboxDemand
        'UltraGridPrintDocument1.DefaultPageSettings.PaperSize.PaperName = "Legal"
        UltraGridPrintDocument1.DefaultPageSettings.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Legal

        UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
        UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 25
        UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 25
        UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 25
        UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 25

        Dim c_pdSetup As New System.Drawing.Printing.PrintDocument
        Dim pSize As New System.Drawing.Printing.PaperSize

        'pSize.Width = 850
        'pSize.Height = 1400
        pSize.PaperName = "Legal"
        pSize.RawKind = System.Drawing.Printing.PaperKind.Legal

        c_pdSetup.DefaultPageSettings.Landscape = True
        c_pdSetup.DefaultPageSettings.Margins.Bottom = 25
        c_pdSetup.DefaultPageSettings.Margins.Left = 25
        c_pdSetup.DefaultPageSettings.Margins.Right = 25
        c_pdSetup.DefaultPageSettings.Margins.Top = 25
        'c_pdSetup.DefaultPageSettings.PaperSize = pSize
        Dim x As Integer
        For x = 0 To c_pdSetup.DefaultPageSettings.PrinterSettings.PaperSizes.Count - 1
            If c_pdSetup.DefaultPageSettings.PrinterSettings.PaperSizes.Item(x).Kind = Printing.PaperKind.Legal Then
                c_pdSetup.DefaultPageSettings.PaperSize = c_pdSetup.DefaultPageSettings.PrinterSettings.PaperSizes.Item(x)
                Exit For
            End If
        Next

        For x = 0 To UltraGridPrintDocument1.PrinterSettings.PaperSizes.Count - 1
            If UltraGridPrintDocument1.PrinterSettings.PaperSizes.Item(x).Kind = Printing.PaperKind.Legal Then
                UltraGridPrintDocument1.DefaultPageSettings.PaperSize = UltraGridPrintDocument1.PrinterSettings.PaperSizes.Item(x)
                Exit For
            End If
        Next

        UltraGridPrintDocument1.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 14
        UltraGridPrintDocument1.Header.TextLeft = "Metaboxes Needed for Orders in Assembly from " & dtFrom.DateTime & " to " & dtTo.DateTime
        UltraGridPrintDocument1.Footer.TextRight = "Page [Page #] of [Total Pages]"
        UltraGridPrintDocument1.Footer.TextLeft = "Printed on " & Now

        UltraPrintPreviewDialog1.Document = UltraGridPrintDocument1
        UltraPrintPreviewDialog1.ShowDialog()
        'ugReady.PrintPreview(ugReady.DisplayLayout, c_pdSetup)

        'ugStyleVsColour.Print(ugStyleVsColour.DisplayLayout, c_pdSetup)
        'StyleGrid()

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ugDoorsNeeded_InitializePrintPreview(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelablePrintPreviewEventArgs) Handles ug_DrawerboxAssembly_MetaboxDemand.InitializePrintPreview
        e.DefaultLogicalPageLayoutInfo.PageHeader = "Metaboxes Needed for Orders in Assembly"

        e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center

        e.DefaultLogicalPageLayoutInfo.PageFooter = "Printed on " & Now & vbTab & "Page <#> of <##>"
        e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 20
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    End Sub

    Private Sub tsmStartTandemboxOrderOthers_Click(sender As Object, e As EventArgs) Handles tsmStartTandemboxOrderOthers.Click
        If ug_DrawerboxAssembly_Others.ActiveRow IsNot Nothing AndAlso ug_DrawerboxAssembly_Others.ActiveRow.Index > -1 Then
            StartTandemboxOrder(ug_DrawerboxAssembly_Others.ActiveRow.Cells("CSID").Text)
            RefreshAll()
        End If
    End Sub

    Private Sub ug_DrawerboxAssembly_CompletedToday_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles ug_DrawerboxAssembly_CompletedToday.AfterSelectChange

        Dim drawerCount As Int16 = 0
        For Each r As UltraGridRow In Me.ug_DrawerboxAssembly_CompletedToday.Selected.Rows
            drawerCount = drawerCount + r.Cells("Drawer").Value
        Next
        Me.lbCompletedHighlighted.Text = "Highlighted - " & drawerCount & " Drawers"

    End Sub

    Private Sub ug_DrawerboxAssembly_Others_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles ug_DrawerboxAssembly_Others.AfterSelectChange

        Dim drawerCount As Int16 = 0
        For Each r As UltraGridRow In Me.ug_DrawerboxAssembly_Others.Selected.Rows
            drawerCount = drawerCount + r.Cells("Drawer").Value
        Next
        Me.lbOtherHighlighted.Text = "Highlighted - " & drawerCount & " Drawers"

    End Sub

    Private Sub ug_DrawerboxAssembly_PriorityInAssembly_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles ug_DrawerboxAssembly_PriorityInAssembly.AfterSelectChange

        Dim drawerCount As Int16 = 0
        For Each r As UltraGridRow In Me.ug_DrawerboxAssembly_PriorityInAssembly.Selected.Rows
            drawerCount = drawerCount + r.Cells("Drawer").Value
        Next
        Me.lbPriorityHighlighted.Text = "Highlighted - " & drawerCount & " Drawers"

    End Sub

    Private Sub tsmViewTandemboxLabels_Click(sender As Object, e As EventArgs) Handles tsmViewTandemboxLabels.Click

        If ug_DrawerboxAssembly_PriorityInAssembly.ActiveRow IsNot Nothing AndAlso ug_DrawerboxAssembly_PriorityInAssembly.ActiveRow.Index > -1 Then
            KPGeneral.PrintZebraTandemboxLabelByCSID4x6(ug_DrawerboxAssembly_PriorityInAssembly.ActiveRow.Cells("CSID").Text, False)
        End If

    End Sub

    Private Sub tsmViewTandemboxLabelsO_Click(sender As Object, e As EventArgs) Handles tsmViewTandemboxLabelsO.Click

        If ug_DrawerboxAssembly_Others.ActiveRow IsNot Nothing AndAlso ug_DrawerboxAssembly_Others.ActiveRow.Index > -1 Then
            KPGeneral.PrintZebraTandemboxLabelByCSID4x6(ug_DrawerboxAssembly_Others.ActiveRow.Cells("CSID").Text, False)
        End If

    End Sub

    Private Sub tsmViewTandemboxLabelsT_Click(sender As Object, e As EventArgs) Handles tsmViewTandemboxLabelsT.Click

        If ug_DrawerboxAssembly_CompletedToday.ActiveRow IsNot Nothing AndAlso ug_DrawerboxAssembly_CompletedToday.ActiveRow.Index > -1 Then
            KPGeneral.PrintZebraTandemboxLabelByCSID4x6(ug_DrawerboxAssembly_CompletedToday.ActiveRow.Cells("CSID").Text, False)
        End If

    End Sub

    Private Sub tsmColumnChooserO_Click(sender As Object, e As EventArgs) Handles tsmColumnChooserO.Click
        KPGeneral.ColumnChooser(Me.ug_DrawerboxAssembly_Others, Me.GetType.Name)
    End Sub

    Private Sub tsmColumnChooserT_Click(sender As Object, e As EventArgs) Handles tsmColumnChooserT.Click
        KPGeneral.ColumnChooser(Me.ug_DrawerboxAssembly_CompletedToday, Me.GetType.Name)
    End Sub

    Private Sub tsmColumnChooserR_Click(sender As Object, e As EventArgs) Handles tsmColumnChooserR.Click
        KPGeneral.ColumnChooser(Me.ugRecentPrints, Me.GetType.Name)
    End Sub

    Private Sub tsmViewTandemboxLabelsR_Click(sender As Object, e As EventArgs) Handles tsmViewTandemboxLabelsR.Click

        If ugRecentPrints.ActiveRow IsNot Nothing AndAlso ugRecentPrints.ActiveRow.Index > -1 Then
            KPGeneral.PrintZebraTandemboxLabelByCSID4x6(ugRecentPrints.ActiveRow.Cells("CSID").Text, False)
        End If

    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        RefreshMetaboxDemand()
    End Sub

End Class