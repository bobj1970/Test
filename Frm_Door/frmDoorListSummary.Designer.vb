<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDoorListSummary
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
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.BtnRun = New Infragistics.Win.Misc.UltraButton()
        Me.chkStyleOnly = New System.Windows.Forms.CheckBox()
        Me.btnClear = New Infragistics.Win.Misc.UltraButton()
        Me.dgScanList = New System.Windows.Forms.DataGridView()
        Me.SumID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FKNo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.chkStyleOnlyAdvanced = New System.Windows.Forms.CheckBox()
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
        Me.ugAdvancedSearch = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetFiltersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGridFilterUIProvider1 = New Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteSelectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.chkPanelSaw = New System.Windows.Forms.CheckBox()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.dgScanList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FKNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.ugAdvancedSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl1.Controls.Add(Me.BtnRun)
        Me.UltraTabPageControl1.Controls.Add(Me.chkStyleOnly)
        Me.UltraTabPageControl1.Controls.Add(Me.btnClear)
        Me.UltraTabPageControl1.Controls.Add(Me.dgScanList)
        Me.UltraTabPageControl1.Controls.Add(Me.FKNo)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(984, 607)
        '
        'UltraLabel1
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance1
        Me.UltraLabel1.Location = New System.Drawing.Point(3, 3)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(83, 21)
        Me.UltraLabel1.TabIndex = 8
        Me.UltraLabel1.Text = "Order Number:"
        '
        'BtnRun
        '
        Me.BtnRun.Location = New System.Drawing.Point(351, 2)
        Me.BtnRun.Name = "BtnRun"
        Me.BtnRun.Size = New System.Drawing.Size(124, 23)
        Me.BtnRun.TabIndex = 10
        Me.BtnRun.Text = "Print Batch"
        '
        'chkStyleOnly
        '
        Me.chkStyleOnly.AutoSize = True
        Me.chkStyleOnly.BackColor = System.Drawing.Color.Transparent
        Me.chkStyleOnly.Location = New System.Drawing.Point(603, 45)
        Me.chkStyleOnly.Name = "chkStyleOnly"
        Me.chkStyleOnly.Size = New System.Drawing.Size(73, 17)
        Me.chkStyleOnly.TabIndex = 14
        Me.chkStyleOnly.Text = "Style Only"
        Me.chkStyleOnly.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(270, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        '
        'dgScanList
        '
        Me.dgScanList.AllowUserToAddRows = False
        Me.dgScanList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgScanList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SumID, Me.Barcode})
        Me.dgScanList.Location = New System.Drawing.Point(3, 45)
        Me.dgScanList.Name = "dgScanList"
        Me.dgScanList.ReadOnly = True
        Me.dgScanList.Size = New System.Drawing.Size(575, 438)
        Me.dgScanList.TabIndex = 13
        '
        'SumID
        '
        Me.SumID.HeaderText = "SumID"
        Me.SumID.Name = "SumID"
        Me.SumID.ReadOnly = True
        Me.SumID.Visible = False
        Me.SumID.Width = 200
        '
        'Barcode
        '
        Me.Barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Barcode.HeaderText = "Barcode"
        Me.Barcode.Name = "Barcode"
        Me.Barcode.ReadOnly = True
        '
        'FKNo
        '
        Me.FKNo.Location = New System.Drawing.Point(92, 3)
        Me.FKNo.Name = "FKNo"
        Me.FKNo.Size = New System.Drawing.Size(172, 21)
        Me.FKNo.TabIndex = 9
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.chkPanelSaw)
        Me.UltraTabPageControl2.Controls.Add(Me.chkStyleOnlyAdvanced)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraButton1)
        Me.UltraTabPageControl2.Controls.Add(Me.ugAdvancedSearch)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(984, 607)
        '
        'chkStyleOnlyAdvanced
        '
        Me.chkStyleOnlyAdvanced.AutoSize = True
        Me.chkStyleOnlyAdvanced.BackColor = System.Drawing.Color.Transparent
        Me.chkStyleOnlyAdvanced.Location = New System.Drawing.Point(245, 11)
        Me.chkStyleOnlyAdvanced.Name = "chkStyleOnlyAdvanced"
        Me.chkStyleOnlyAdvanced.Size = New System.Drawing.Size(73, 17)
        Me.chkStyleOnlyAdvanced.TabIndex = 16
        Me.chkStyleOnlyAdvanced.Text = "Style Only"
        Me.chkStyleOnlyAdvanced.UseVisualStyleBackColor = False
        '
        'UltraButton1
        '
        Me.UltraButton1.Location = New System.Drawing.Point(12, 5)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(196, 23)
        Me.UltraButton1.TabIndex = 15
        Me.UltraButton1.Text = "Generate Door Summary"
        '
        'ugAdvancedSearch
        '
        Me.ugAdvancedSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugAdvancedSearch.ContextMenuStrip = Me.ContextMenuStrip2
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugAdvancedSearch.DisplayLayout.Appearance = Appearance2
        Me.ugAdvancedSearch.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugAdvancedSearch.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAdvancedSearch.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAdvancedSearch.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.ugAdvancedSearch.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugAdvancedSearch.DisplayLayout.GroupByBox.Hidden = True
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAdvancedSearch.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.ugAdvancedSearch.DisplayLayout.MaxColScrollRegions = 1
        Me.ugAdvancedSearch.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugAdvancedSearch.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugAdvancedSearch.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.ugAdvancedSearch.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugAdvancedSearch.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugAdvancedSearch.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugAdvancedSearch.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugAdvancedSearch.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugAdvancedSearch.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugAdvancedSearch.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.ugAdvancedSearch.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugAdvancedSearch.DisplayLayout.Override.CellAppearance = Appearance9
        Me.ugAdvancedSearch.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugAdvancedSearch.DisplayLayout.Override.CellPadding = 0
        Me.ugAdvancedSearch.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.ugAdvancedSearch.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.ugAdvancedSearch.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAdvancedSearch.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.ugAdvancedSearch.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugAdvancedSearch.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugAdvancedSearch.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugAdvancedSearch.DisplayLayout.Override.RowAppearance = Appearance12
        Me.ugAdvancedSearch.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugAdvancedSearch.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugAdvancedSearch.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugAdvancedSearch.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugAdvancedSearch.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugAdvancedSearch.Location = New System.Drawing.Point(3, 34)
        Me.ugAdvancedSearch.Name = "ugAdvancedSearch"
        Me.ugAdvancedSearch.Size = New System.Drawing.Size(978, 568)
        Me.ugAdvancedSearch.TabIndex = 14
        Me.ugAdvancedSearch.Text = "UltraGrid1"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ResetFiltersToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(137, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.ToolStripMenuItem1.Text = "Refresh"
        '
        'ResetFiltersToolStripMenuItem
        '
        Me.ResetFiltersToolStripMenuItem.Name = "ResetFiltersToolStripMenuItem"
        Me.ResetFiltersToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ResetFiltersToolStripMenuItem.Text = "Reset Filters"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteSelectedToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(155, 26)
        '
        'DeleteSelectedToolStripMenuItem
        '
        Me.DeleteSelectedToolStripMenuItem.Name = "DeleteSelectedToolStripMenuItem"
        Me.DeleteSelectedToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.DeleteSelectedToolStripMenuItem.Text = "Delete Selected"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(988, 633)
        Me.UltraTabControl1.TabIndex = 15
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Scan Orders"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Advanced Search"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(984, 607)
        '
        'chkPanelSaw
        '
        Me.chkPanelSaw.AutoSize = True
        Me.chkPanelSaw.BackColor = System.Drawing.Color.Transparent
        Me.chkPanelSaw.Location = New System.Drawing.Point(342, 11)
        Me.chkPanelSaw.Name = "chkPanelSaw"
        Me.chkPanelSaw.Size = New System.Drawing.Size(315, 17)
        Me.chkPanelSaw.TabIndex = 17
        Me.chkPanelSaw.Text = "Group Styles for Panel Saw - This igores Recessed Hardware"
        Me.chkPanelSaw.UseVisualStyleBackColor = False
        '
        'frmDoorListSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 633)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDoorListSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmDoorSummary"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.dgScanList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FKNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.ugAdvancedSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents FKNo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnClear As Infragistics.Win.Misc.UltraButton
    Friend WithEvents BtnRun As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteSelectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgScanList As System.Windows.Forms.DataGridView
    Friend WithEvents SumID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkStyleOnly As System.Windows.Forms.CheckBox
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ugAdvancedSearch As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridFilterUIProvider1 As Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetFiltersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkStyleOnlyAdvanced As System.Windows.Forms.CheckBox
    Friend WithEvents chkPanelSaw As CheckBox
End Class
