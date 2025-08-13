<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDORDepartmentHours
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.uccSelDate = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.ucDepartments = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblTotalHours = New Infragistics.Win.Misc.UltraLabel()
        Me.ug_DORDepartmentHours_Department = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.mnuDepartment = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColumnChooserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerifyHoursToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitHoursToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ug_DORDepartmentHours_SplitHours = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.mnuSplitHours = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColumnChooserToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.uccSelDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucDepartments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ug_DORDepartmentHours_Department, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuDepartment.SuspendLayout()
        CType(Me.ug_DORDepartmentHours_SplitHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuSplitHours.SuspendLayout()
        Me.SuspendLayout()
        '
        'uccSelDate
        '
        Me.uccSelDate.DateButtons.Add(DateButton1)
        Me.uccSelDate.Location = New System.Drawing.Point(48, 9)
        Me.uccSelDate.Name = "uccSelDate"
        Me.uccSelDate.NonAutoSizeHeight = 21
        Me.uccSelDate.Size = New System.Drawing.Size(121, 21)
        Me.uccSelDate.TabIndex = 0
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 12)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 1
        Me.UltraLabel1.Text = "Date"
        '
        'ucDepartments
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ucDepartments.DisplayLayout.Appearance = Appearance1
        Me.ucDepartments.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ucDepartments.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ucDepartments.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ucDepartments.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ucDepartments.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ucDepartments.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ucDepartments.DisplayLayout.MaxColScrollRegions = 1
        Me.ucDepartments.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ucDepartments.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ucDepartments.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ucDepartments.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ucDepartments.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ucDepartments.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ucDepartments.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ucDepartments.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ucDepartments.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ucDepartments.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ucDepartments.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ucDepartments.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ucDepartments.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ucDepartments.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ucDepartments.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ucDepartments.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ucDepartments.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ucDepartments.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ucDepartments.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ucDepartments.Location = New System.Drawing.Point(83, 52)
        Me.ucDepartments.Name = "ucDepartments"
        Me.ucDepartments.Size = New System.Drawing.Size(243, 22)
        Me.ucDepartments.TabIndex = 2
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(12, 52)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel2.TabIndex = 3
        Me.UltraLabel2.Text = "Department"
        '
        'lblTotalHours
        '
        Me.lblTotalHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.TextHAlignAsString = "Right"
        Me.lblTotalHours.Appearance = Appearance13
        Me.lblTotalHours.Location = New System.Drawing.Point(583, 52)
        Me.lblTotalHours.Name = "lblTotalHours"
        Me.lblTotalHours.Size = New System.Drawing.Size(205, 23)
        Me.lblTotalHours.TabIndex = 4
        Me.lblTotalHours.Text = "Total Hours for DOR:"
        '
        'ug_DORDepartmentHours_Department
        '
        Me.ug_DORDepartmentHours_Department.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ug_DORDepartmentHours_Department.ContextMenuStrip = Me.mnuDepartment
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Appearance = Appearance14
        Me.ug_DORDepartmentHours_Department.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_DORDepartmentHours_Department.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_DORDepartmentHours_Department.DisplayLayout.GroupByBox.Appearance = Appearance15
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_DORDepartmentHours_Department.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance16
        Me.ug_DORDepartmentHours_Department.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance17.BackColor2 = System.Drawing.SystemColors.Control
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_DORDepartmentHours_Department.DisplayLayout.GroupByBox.PromptAppearance = Appearance17
        Me.ug_DORDepartmentHours_Department.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_DORDepartmentHours_Department.DisplayLayout.MaxRowScrollRegions = 1
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.ActiveCellAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.SystemColors.Highlight
        Appearance19.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.ActiveRowAppearance = Appearance19
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.CardAreaAppearance = Appearance20
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.CellAppearance = Appearance21
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.CellPadding = 0
        Appearance22.BackColor = System.Drawing.SystemColors.Control
        Appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance22.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.GroupByRowAppearance = Appearance22
        Appearance23.TextHAlignAsString = "Left"
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.HeaderAppearance = Appearance23
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.RowAppearance = Appearance24
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_DORDepartmentHours_Department.DisplayLayout.Override.TemplateAddRowAppearance = Appearance25
        Me.ug_DORDepartmentHours_Department.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_DORDepartmentHours_Department.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_DORDepartmentHours_Department.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_DORDepartmentHours_Department.Location = New System.Drawing.Point(12, 81)
        Me.ug_DORDepartmentHours_Department.Name = "ug_DORDepartmentHours_Department"
        Me.ug_DORDepartmentHours_Department.Size = New System.Drawing.Size(776, 171)
        Me.ug_DORDepartmentHours_Department.TabIndex = 5
        Me.ug_DORDepartmentHours_Department.Text = "UltraGrid1"
        '
        'mnuDepartment
        '
        Me.mnuDepartment.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColumnChooserToolStripMenuItem, Me.VerifyHoursToolStripMenuItem, Me.SplitHoursToolStripMenuItem})
        Me.mnuDepartment.Name = "mnuDepartment"
        Me.mnuDepartment.Size = New System.Drawing.Size(165, 70)
        '
        'ColumnChooserToolStripMenuItem
        '
        Me.ColumnChooserToolStripMenuItem.Name = "ColumnChooserToolStripMenuItem"
        Me.ColumnChooserToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ColumnChooserToolStripMenuItem.Text = "Column Chooser"
        '
        'VerifyHoursToolStripMenuItem
        '
        Me.VerifyHoursToolStripMenuItem.Name = "VerifyHoursToolStripMenuItem"
        Me.VerifyHoursToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.VerifyHoursToolStripMenuItem.Text = "Verify Hours"
        '
        'SplitHoursToolStripMenuItem
        '
        Me.SplitHoursToolStripMenuItem.Name = "SplitHoursToolStripMenuItem"
        Me.SplitHoursToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SplitHoursToolStripMenuItem.Text = "Split Hours"
        '
        'ug_DORDepartmentHours_SplitHours
        '
        Me.ug_DORDepartmentHours_SplitHours.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ug_DORDepartmentHours_SplitHours.ContextMenuStrip = Me.mnuSplitHours
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Appearance26.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Appearance = Appearance26
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance27.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance27.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.GroupByBox.Appearance = Appearance27
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance28
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance29.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance29.BackColor2 = System.Drawing.SystemColors.Control
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance29.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.GroupByBox.PromptAppearance = Appearance29
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.MaxRowScrollRegions = 1
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.ActiveCellAppearance = Appearance30
        Appearance31.BackColor = System.Drawing.SystemColors.Highlight
        Appearance31.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.ActiveRowAppearance = Appearance31
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.CardAreaAppearance = Appearance32
        Appearance33.BorderColor = System.Drawing.Color.Silver
        Appearance33.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.CellAppearance = Appearance33
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.CellPadding = 0
        Appearance34.BackColor = System.Drawing.SystemColors.Control
        Appearance34.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance34.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance34.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.GroupByRowAppearance = Appearance34
        Appearance35.TextHAlignAsString = "Left"
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.HeaderAppearance = Appearance35
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance36.BackColor = System.Drawing.SystemColors.Window
        Appearance36.BorderColor = System.Drawing.Color.Silver
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.RowAppearance = Appearance36
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance37.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.Override.TemplateAddRowAppearance = Appearance37
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_DORDepartmentHours_SplitHours.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_DORDepartmentHours_SplitHours.Location = New System.Drawing.Point(12, 276)
        Me.ug_DORDepartmentHours_SplitHours.Name = "ug_DORDepartmentHours_SplitHours"
        Me.ug_DORDepartmentHours_SplitHours.Size = New System.Drawing.Size(776, 171)
        Me.ug_DORDepartmentHours_SplitHours.TabIndex = 6
        Me.ug_DORDepartmentHours_SplitHours.Text = "UltraGrid1"
        '
        'mnuSplitHours
        '
        Me.mnuSplitHours.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColumnChooserToolStripMenuItem1})
        Me.mnuSplitHours.Name = "ContextMenuStrip1"
        Me.mnuSplitHours.Size = New System.Drawing.Size(165, 26)
        '
        'ColumnChooserToolStripMenuItem1
        '
        Me.ColumnChooserToolStripMenuItem1.Name = "ColumnChooserToolStripMenuItem1"
        Me.ColumnChooserToolStripMenuItem1.Size = New System.Drawing.Size(164, 22)
        Me.ColumnChooserToolStripMenuItem1.Text = "Column Chooser"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel3.Location = New System.Drawing.Point(12, 258)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel3.TabIndex = 7
        Me.UltraLabel3.Text = "Split Hours"
        '
        'frmDORDepartmentHours
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ug_DORDepartmentHours_SplitHours)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.ug_DORDepartmentHours_Department)
        Me.Controls.Add(Me.lblTotalHours)
        Me.Controls.Add(Me.ucDepartments)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.uccSelDate)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Name = "frmDORDepartmentHours"
        Me.Text = "frmDORDepartmentHours"
        CType(Me.uccSelDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucDepartments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ug_DORDepartmentHours_Department, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuDepartment.ResumeLayout(False)
        CType(Me.ug_DORDepartmentHours_SplitHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuSplitHours.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents uccSelDate As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ucDepartments As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblTotalHours As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ug_DORDepartmentHours_Department As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ug_DORDepartmentHours_SplitHours As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents mnuDepartment As ContextMenuStrip
    Friend WithEvents ColumnChooserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerifyHoursToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitHoursToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuSplitHours As ContextMenuStrip
    Friend WithEvents ColumnChooserToolStripMenuItem1 As ToolStripMenuItem
End Class
