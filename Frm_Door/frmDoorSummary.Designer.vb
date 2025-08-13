<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDoorSummary
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
        Me.components = New System.ComponentModel.Container
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.FKNo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnClear = New Infragistics.Win.Misc.UltraButton
        Me.BtnRun = New Infragistics.Win.Misc.UltraButton
        Me.dgScanList = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.FKNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgScanList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraLabel1
        '
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance1
        Me.UltraLabel1.Location = New System.Drawing.Point(6, 3)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(83, 21)
        Me.UltraLabel1.TabIndex = 8
        Me.UltraLabel1.Text = "Order Number:"
        '
        'FKNo
        '
        Me.FKNo.Location = New System.Drawing.Point(95, 3)
        Me.FKNo.Name = "FKNo"
        Me.FKNo.Size = New System.Drawing.Size(172, 21)
        Me.FKNo.TabIndex = 9
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(273, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        '
        'BtnRun
        '
        Me.BtnRun.Location = New System.Drawing.Point(354, 2)
        Me.BtnRun.Name = "BtnRun"
        Me.BtnRun.Size = New System.Drawing.Size(124, 23)
        Me.BtnRun.TabIndex = 10
        Me.BtnRun.Text = "Print Batch"
        '
        'dgScanList
        '
        Me.dgScanList.ContextMenuStrip = Me.ContextMenuStrip1
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgScanList.DisplayLayout.Appearance = Appearance2
        Me.dgScanList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgScanList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.dgScanList.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgScanList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.dgScanList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgScanList.DisplayLayout.GroupByBox.Hidden = True
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgScanList.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.dgScanList.DisplayLayout.MaxColScrollRegions = 1
        Me.dgScanList.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgScanList.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgScanList.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.dgScanList.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgScanList.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgScanList.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgScanList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgScanList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgScanList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgScanList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.dgScanList.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgScanList.DisplayLayout.Override.CellAppearance = Appearance9
        Me.dgScanList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.dgScanList.DisplayLayout.Override.CellPadding = 0
        Me.dgScanList.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dgScanList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.dgScanList.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.dgScanList.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.dgScanList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgScanList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.dgScanList.DisplayLayout.Override.RowAppearance = Appearance12
        Me.dgScanList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgScanList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.dgScanList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgScanList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgScanList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgScanList.Location = New System.Drawing.Point(6, 30)
        Me.dgScanList.Name = "dgScanList"
        Me.dgScanList.Size = New System.Drawing.Size(521, 423)
        Me.dgScanList.TabIndex = 11
        Me.dgScanList.Text = "UltraGrid1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteSelectedToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 26)
        '
        'DeleteSelectedToolStripMenuItem
        '
        Me.DeleteSelectedToolStripMenuItem.Name = "DeleteSelectedToolStripMenuItem"
        Me.DeleteSelectedToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.DeleteSelectedToolStripMenuItem.Text = "Delete Selected"
        '
        'frmDoorSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 633)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.FKNo)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.BtnRun)
        Me.Controls.Add(Me.dgScanList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDoorSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmDoorSummary"
        CType(Me.FKNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgScanList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents FKNo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnClear As Infragistics.Win.Misc.UltraButton
    Friend WithEvents BtnRun As Infragistics.Win.Misc.UltraButton
    Friend WithEvents dgScanList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
