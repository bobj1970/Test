<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageClamps
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
        Me.txtStationName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtEmpRef = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAvgDailyProduction = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.ug_ManageClamps_WorkerList = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetObsoleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReactivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClearInfo = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddWorker = New Infragistics.Win.Misc.UltraButton()
        Me.btnUpdateWorker = New Infragistics.Win.Misc.UltraButton()
        Me.txtLineNumber = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtAvgPerformance = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.tbPassword = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lbPassword = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.txtStationName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAvgDailyProduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ug_ManageClamps_WorkerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.txtLineNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAvgPerformance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtStationName
        '
        Me.txtStationName.Location = New System.Drawing.Point(127, 8)
        Me.txtStationName.Name = "txtStationName"
        Me.txtStationName.Size = New System.Drawing.Size(237, 21)
        Me.txtStationName.TabIndex = 0
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 12)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 1
        Me.UltraLabel1.Text = "Station Name"
        '
        'txtEmpRef
        '
        Me.txtEmpRef.Location = New System.Drawing.Point(127, 35)
        Me.txtEmpRef.Name = "txtEmpRef"
        Me.txtEmpRef.Size = New System.Drawing.Size(237, 21)
        Me.txtEmpRef.TabIndex = 1
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(12, 39)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel2.TabIndex = 3
        Me.UltraLabel2.Text = "Employee #"
        '
        'txtAvgDailyProduction
        '
        Me.txtAvgDailyProduction.Location = New System.Drawing.Point(127, 62)
        Me.txtAvgDailyProduction.Name = "txtAvgDailyProduction"
        Me.txtAvgDailyProduction.Size = New System.Drawing.Size(237, 21)
        Me.txtAvgDailyProduction.TabIndex = 2
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(12, 66)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(121, 23)
        Me.UltraLabel3.TabIndex = 5
        Me.UltraLabel3.Text = "Avg Daily Production"
        '
        'ug_ManageClamps_WorkerList
        '
        Me.ug_ManageClamps_WorkerList.ContextMenuStrip = Me.ContextMenuStrip1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Appearance = Appearance1
        Me.ug_ManageClamps_WorkerList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_ManageClamps_WorkerList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_ManageClamps_WorkerList.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_ManageClamps_WorkerList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ug_ManageClamps_WorkerList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_ManageClamps_WorkerList.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ug_ManageClamps_WorkerList.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_ManageClamps_WorkerList.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_ManageClamps_WorkerList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ug_ManageClamps_WorkerList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_ManageClamps_WorkerList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_ManageClamps_WorkerList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_ManageClamps_WorkerList.Location = New System.Drawing.Point(12, 195)
        Me.ug_ManageClamps_WorkerList.Name = "ug_ManageClamps_WorkerList"
        Me.ug_ManageClamps_WorkerList.Size = New System.Drawing.Size(1029, 348)
        Me.ug_ManageClamps_WorkerList.TabIndex = 6
        Me.ug_ManageClamps_WorkerList.Text = "UltraGrid1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.ColumnChooserToolStripMenuItem, Me.SetObsoleteToolStripMenuItem, Me.ReactivateToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 92)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ColumnChooserToolStripMenuItem
        '
        Me.ColumnChooserToolStripMenuItem.Name = "ColumnChooserToolStripMenuItem"
        Me.ColumnChooserToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ColumnChooserToolStripMenuItem.Text = "Column Chooser"
        '
        'SetObsoleteToolStripMenuItem
        '
        Me.SetObsoleteToolStripMenuItem.Name = "SetObsoleteToolStripMenuItem"
        Me.SetObsoleteToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SetObsoleteToolStripMenuItem.Text = "Set Obsolete"
        '
        'ReactivateToolStripMenuItem
        '
        Me.ReactivateToolStripMenuItem.Name = "ReactivateToolStripMenuItem"
        Me.ReactivateToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ReactivateToolStripMenuItem.Text = "Reactivate"
        '
        'btnClearInfo
        '
        Me.btnClearInfo.Location = New System.Drawing.Point(394, 8)
        Me.btnClearInfo.Name = "btnClearInfo"
        Me.btnClearInfo.Size = New System.Drawing.Size(104, 23)
        Me.btnClearInfo.TabIndex = 8
        Me.btnClearInfo.Text = "Clear Info"
        '
        'btnAddWorker
        '
        Me.btnAddWorker.Location = New System.Drawing.Point(394, 39)
        Me.btnAddWorker.Name = "btnAddWorker"
        Me.btnAddWorker.Size = New System.Drawing.Size(104, 23)
        Me.btnAddWorker.TabIndex = 6
        Me.btnAddWorker.Text = "Add Worker"
        '
        'btnUpdateWorker
        '
        Me.btnUpdateWorker.Location = New System.Drawing.Point(394, 68)
        Me.btnUpdateWorker.Name = "btnUpdateWorker"
        Me.btnUpdateWorker.Size = New System.Drawing.Size(104, 23)
        Me.btnUpdateWorker.TabIndex = 7
        Me.btnUpdateWorker.Text = "Update Worker"
        '
        'txtLineNumber
        '
        Me.txtLineNumber.Location = New System.Drawing.Point(127, 122)
        Me.txtLineNumber.Name = "txtLineNumber"
        Me.txtLineNumber.Size = New System.Drawing.Size(237, 21)
        Me.txtLineNumber.TabIndex = 4
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(12, 126)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel4.TabIndex = 12
        Me.UltraLabel4.Text = "Clamp Number"
        '
        'txtAvgPerformance
        '
        Me.txtAvgPerformance.Location = New System.Drawing.Point(127, 89)
        Me.txtAvgPerformance.Name = "txtAvgPerformance"
        Me.txtAvgPerformance.Size = New System.Drawing.Size(237, 21)
        Me.txtAvgPerformance.TabIndex = 3
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Location = New System.Drawing.Point(12, 93)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(121, 23)
        Me.UltraLabel5.TabIndex = 14
        Me.UltraLabel5.Text = "Avg Performance"
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(127, 149)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.Size = New System.Drawing.Size(237, 21)
        Me.tbPassword.TabIndex = 5
        '
        'lbPassword
        '
        Me.lbPassword.Location = New System.Drawing.Point(12, 153)
        Me.lbPassword.Name = "lbPassword"
        Me.lbPassword.Size = New System.Drawing.Size(100, 23)
        Me.lbPassword.TabIndex = 16
        Me.lbPassword.Text = "Password"
        '
        'frmManageClamps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1066, 555)
        Me.Controls.Add(Me.tbPassword)
        Me.Controls.Add(Me.lbPassword)
        Me.Controls.Add(Me.txtAvgPerformance)
        Me.Controls.Add(Me.UltraLabel5)
        Me.Controls.Add(Me.txtLineNumber)
        Me.Controls.Add(Me.UltraLabel4)
        Me.Controls.Add(Me.btnUpdateWorker)
        Me.Controls.Add(Me.btnAddWorker)
        Me.Controls.Add(Me.btnClearInfo)
        Me.Controls.Add(Me.ug_ManageClamps_WorkerList)
        Me.Controls.Add(Me.txtAvgDailyProduction)
        Me.Controls.Add(Me.UltraLabel3)
        Me.Controls.Add(Me.txtEmpRef)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.txtStationName)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Name = "frmManageClamps"
        Me.Text = "Manage Clamps"
        CType(Me.txtStationName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAvgDailyProduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ug_ManageClamps_WorkerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.txtLineNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAvgPerformance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtStationName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtEmpRef As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAvgDailyProduction As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ug_ManageClamps_WorkerList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetObsoleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReactivateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnClearInfo As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddWorker As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnUpdateWorker As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtLineNumber As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAvgPerformance As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents tbPassword As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lbPassword As Infragistics.Win.Misc.UltraLabel
End Class
