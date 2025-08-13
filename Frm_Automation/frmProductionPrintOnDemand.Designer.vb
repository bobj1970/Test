<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductionPrintOnDemand
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
        Me.ugProductionPrintOnDemand = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintLayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGridFilterUIProvider1 = New Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider(Me.components)
        CType(Me.ugProductionPrintOnDemand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ugProductionPrintOnDemand
        '
        Me.ugProductionPrintOnDemand.ContextMenuStrip = Me.ContextMenuStrip1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugProductionPrintOnDemand.DisplayLayout.Appearance = Appearance1
        Me.ugProductionPrintOnDemand.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductionPrintOnDemand.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductionPrintOnDemand.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductionPrintOnDemand.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugProductionPrintOnDemand.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductionPrintOnDemand.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductionPrintOnDemand.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugProductionPrintOnDemand.DisplayLayout.MaxColScrollRegions = 1
        Me.ugProductionPrintOnDemand.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.AllowMultiCellOperations = CType((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders), Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.CellPadding = 0
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugProductionPrintOnDemand.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugProductionPrintOnDemand.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugProductionPrintOnDemand.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugProductionPrintOnDemand.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugProductionPrintOnDemand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugProductionPrintOnDemand.Location = New System.Drawing.Point(0, 0)
        Me.ugProductionPrintOnDemand.Name = "ugProductionPrintOnDemand"
        Me.ugProductionPrintOnDemand.Size = New System.Drawing.Size(800, 450)
        Me.ugProductionPrintOnDemand.TabIndex = 5
        Me.ugProductionPrintOnDemand.Text = "UltraGrid1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.PrintLayoutToolStripMenuItem, Me.ColumnChooserToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 70)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'PrintLayoutToolStripMenuItem
        '
        Me.PrintLayoutToolStripMenuItem.Name = "PrintLayoutToolStripMenuItem"
        Me.PrintLayoutToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.PrintLayoutToolStripMenuItem.Text = "Print Layout"
        '
        'ColumnChooserToolStripMenuItem
        '
        Me.ColumnChooserToolStripMenuItem.Name = "ColumnChooserToolStripMenuItem"
        Me.ColumnChooserToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ColumnChooserToolStripMenuItem.Text = "Column Chooser"
        '
        'frmProductionPrintOnDemand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ugProductionPrintOnDemand)
        Me.Name = "frmProductionPrintOnDemand"
        Me.Text = "frmProductionPrintOnDemands"
        CType(Me.ugProductionPrintOnDemand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ugProductionPrintOnDemand As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintLayoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UltraGridFilterUIProvider1 As Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider
End Class
