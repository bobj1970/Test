<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesForecast
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DateInterval1 As Infragistics.Win.UltraWinSchedule.DateInterval = New Infragistics.Win.UltraWinSchedule.DateInterval()
        Dim DateInterval2 As Infragistics.Win.UltraWinSchedule.DateInterval = New Infragistics.Win.UltraWinSchedule.DateInterval()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[True])
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ugForecast = New Infragistics.Win.UltraWinGanttView.UltraGanttView()
        Me.ugSalesPerson = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraSplitter1 = New Infragistics.Win.Misc.UltraSplitter()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        CType(Me.ugForecast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugSalesPerson, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ugForecast
        '
        Me.ugForecast.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Constraint).Visible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Constraint).VisiblePosition = 6
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.ConstraintDateTime).Visible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.ConstraintDateTime).VisiblePosition = 7
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Dependencies).Visible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Dependencies).VisiblePosition = 4
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Deadline).Visible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Deadline).VisiblePosition = 8
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Duration).Visible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Duration).VisiblePosition = 4
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.EndDateTime).Visible = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.EndDateTime).VisiblePosition = 3
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Milestone).Visible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Milestone).VisiblePosition = 9
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Name).Visible = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Name).VisiblePosition = 0
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Name).Width = 300
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Notes).Text = "# of Units"
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Notes).Visible = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Notes).VisiblePosition = 1
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.PercentComplete).Visible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.PercentComplete).VisiblePosition = 11
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Resources).Visible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.Resources).VisiblePosition = 5
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.StartDateTime).Visible = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.StartDateTime).VisiblePosition = 2
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.RowNumber).Visible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugForecast.GridSettings.ColumnSettings.GetValue(Infragistics.Win.UltraWinSchedule.TaskField.RowNumber).VisiblePosition = 12
        Me.ugForecast.Location = New System.Drawing.Point(0, 0)
        Me.ugForecast.Name = "ugForecast"
        Me.ugForecast.Size = New System.Drawing.Size(658, 503)
        Me.ugForecast.TabIndex = 0
        Me.ugForecast.Text = "UltraGanttView1"
        DateInterval1.IntervalUnits = Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Years
        Me.ugForecast.TimelineSettings.AdditionalIntervals.Add(DateInterval1)
        Me.ugForecast.TimelineSettings.ColumnAutoSizing = Infragistics.Win.UltraWinSchedule.TimelineViewColumnAutoSizing.AllVisibleIntervals
        DateInterval2.IntervalUnits = Infragistics.Win.UltraWinSchedule.DateIntervalUnits.Months
        Me.ugForecast.TimelineSettings.PrimaryInterval = DateInterval2
        UltraToolTipInfo1.Enabled = Infragistics.Win.DefaultableBoolean.[True]
        Me.UltraToolTipManager1.SetUltraToolTip(Me.ugForecast, UltraToolTipInfo1)
        Me.ugForecast.VerticalSplitterMinimumResizeWidth = 10
        '
        'ugSalesPerson
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugSalesPerson.DisplayLayout.Appearance = Appearance1
        Me.ugSalesPerson.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugSalesPerson.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugSalesPerson.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugSalesPerson.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.ugSalesPerson.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugSalesPerson.DisplayLayout.GroupByBox.Hidden = True
        Appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance3.BackColor2 = System.Drawing.SystemColors.Control
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugSalesPerson.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Me.ugSalesPerson.DisplayLayout.MaxColScrollRegions = 1
        Me.ugSalesPerson.DisplayLayout.MaxRowScrollRegions = 1
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugSalesPerson.DisplayLayout.Override.ActiveCellAppearance = Appearance9
        Appearance5.BackColor = System.Drawing.SystemColors.Highlight
        Appearance5.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugSalesPerson.DisplayLayout.Override.ActiveRowAppearance = Appearance5
        Me.ugSalesPerson.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugSalesPerson.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Me.ugSalesPerson.DisplayLayout.Override.CardAreaAppearance = Appearance12
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugSalesPerson.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugSalesPerson.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugSalesPerson.DisplayLayout.Override.CellPadding = 0
        Appearance6.BackColor = System.Drawing.SystemColors.Control
        Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.BorderColor = System.Drawing.SystemColors.Window
        Me.ugSalesPerson.DisplayLayout.Override.GroupByRowAppearance = Appearance6
        Appearance7.TextHAlignAsString = "Left"
        Me.ugSalesPerson.DisplayLayout.Override.HeaderAppearance = Appearance7
        Me.ugSalesPerson.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugSalesPerson.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Me.ugSalesPerson.DisplayLayout.Override.RowAppearance = Appearance10
        Me.ugSalesPerson.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugSalesPerson.DisplayLayout.Override.TemplateAddRowAppearance = Appearance11
        Me.ugSalesPerson.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugSalesPerson.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugSalesPerson.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugSalesPerson.Dock = System.Windows.Forms.DockStyle.Right
        Me.ugSalesPerson.Location = New System.Drawing.Point(673, 0)
        Me.ugSalesPerson.Name = "ugSalesPerson"
        Me.ugSalesPerson.Size = New System.Drawing.Size(208, 503)
        Me.ugSalesPerson.TabIndex = 0
        Me.ugSalesPerson.Text = "UltraGrid1"
        '
        'UltraSplitter1
        '
        Me.UltraSplitter1.BackColor = System.Drawing.SystemColors.Control
        Me.UltraSplitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.UltraSplitter1.Location = New System.Drawing.Point(658, 0)
        Me.UltraSplitter1.Name = "UltraSplitter1"
        Me.UltraSplitter1.RestoreExtent = 208
        Me.UltraSplitter1.Size = New System.Drawing.Size(15, 503)
        Me.UltraSplitter1.TabIndex = 2
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'frmSalesForecast
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 503)
        Me.Controls.Add(Me.ugForecast)
        Me.Controls.Add(Me.UltraSplitter1)
        Me.Controls.Add(Me.ugSalesPerson)
        Me.Name = "frmSalesForecast"
        Me.Text = "Form1"
        CType(Me.ugForecast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugSalesPerson, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ugForecast As Infragistics.Win.UltraWinGanttView.UltraGanttView
    Friend WithEvents ugSalesPerson As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraSplitter1 As Infragistics.Win.Misc.UltraSplitter
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager

End Class
