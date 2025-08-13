<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdersPicked
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ugOrdersPicked = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClearBaseDelayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearUpperDelayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KitchenTrackerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeePerformanceForBasePickerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeePerformanceForUpperPickerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnUpper = New Infragistics.Win.Misc.UltraButton()
        Me.btnBase = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtOrderCount = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.ugOrdersPicked, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1001, 34)
        Me.Panel1.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(280, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(397, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Orders Picked"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(196, 40)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(329, 32)
        Me.txtBarcode.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 24)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Click And Scan Here:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(365, 22)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Orders Picked Today"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(650, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 24)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Order Count:"
        '
        'ugOrdersPicked
        '
        Me.ugOrdersPicked.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugOrdersPicked.ContextMenuStrip = Me.ContextMenuStrip1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugOrdersPicked.DisplayLayout.Appearance = Appearance1
        Me.ugOrdersPicked.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugOrdersPicked.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugOrdersPicked.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugOrdersPicked.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugOrdersPicked.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugOrdersPicked.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugOrdersPicked.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugOrdersPicked.DisplayLayout.MaxColScrollRegions = 1
        Me.ugOrdersPicked.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugOrdersPicked.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugOrdersPicked.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugOrdersPicked.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugOrdersPicked.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugOrdersPicked.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugOrdersPicked.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugOrdersPicked.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugOrdersPicked.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugOrdersPicked.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugOrdersPicked.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugOrdersPicked.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugOrdersPicked.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugOrdersPicked.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugOrdersPicked.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugOrdersPicked.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugOrdersPicked.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugOrdersPicked.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugOrdersPicked.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugOrdersPicked.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugOrdersPicked.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugOrdersPicked.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugOrdersPicked.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugOrdersPicked.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugOrdersPicked.Location = New System.Drawing.Point(12, 143)
        Me.ugOrdersPicked.Name = "ugOrdersPicked"
        Me.ugOrdersPicked.Size = New System.Drawing.Size(981, 316)
        Me.ugOrdersPicked.TabIndex = 25
        Me.ugOrdersPicked.Text = "UltraGrid1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearBaseDelayToolStripMenuItem, Me.ClearUpperDelayToolStripMenuItem, Me.ColumnChooserToolStripMenuItem, Me.KitchenTrackerToolStripMenuItem, Me.EmployeePerformanceForBasePickerToolStripMenuItem, Me.EmployeePerformanceForUpperPickerToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(286, 136)
        '
        'ClearBaseDelayToolStripMenuItem
        '
        Me.ClearBaseDelayToolStripMenuItem.Name = "ClearBaseDelayToolStripMenuItem"
        Me.ClearBaseDelayToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.ClearBaseDelayToolStripMenuItem.Text = "Clear Base Delay"
        '
        'ClearUpperDelayToolStripMenuItem
        '
        Me.ClearUpperDelayToolStripMenuItem.Name = "ClearUpperDelayToolStripMenuItem"
        Me.ClearUpperDelayToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.ClearUpperDelayToolStripMenuItem.Text = "Clear Upper Delay"
        '
        'ColumnChooserToolStripMenuItem
        '
        Me.ColumnChooserToolStripMenuItem.Name = "ColumnChooserToolStripMenuItem"
        Me.ColumnChooserToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.ColumnChooserToolStripMenuItem.Text = "Column Chooser"
        '
        'KitchenTrackerToolStripMenuItem
        '
        Me.KitchenTrackerToolStripMenuItem.Name = "KitchenTrackerToolStripMenuItem"
        Me.KitchenTrackerToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.KitchenTrackerToolStripMenuItem.Text = "Kitchen Tracker"
        '
        'EmployeePerformanceForBasePickerToolStripMenuItem
        '
        Me.EmployeePerformanceForBasePickerToolStripMenuItem.Name = "EmployeePerformanceForBasePickerToolStripMenuItem"
        Me.EmployeePerformanceForBasePickerToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.EmployeePerformanceForBasePickerToolStripMenuItem.Text = "Employee Performance for Base Picker"
        '
        'EmployeePerformanceForUpperPickerToolStripMenuItem
        '
        Me.EmployeePerformanceForUpperPickerToolStripMenuItem.Name = "EmployeePerformanceForUpperPickerToolStripMenuItem"
        Me.EmployeePerformanceForUpperPickerToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.EmployeePerformanceForUpperPickerToolStripMenuItem.Text = "Employee Performance for Upper Picker"
        '
        'btnUpper
        '
        Me.btnUpper.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpper.Location = New System.Drawing.Point(545, 44)
        Me.btnUpper.Name = "btnUpper"
        Me.btnUpper.Size = New System.Drawing.Size(132, 45)
        Me.btnUpper.TabIndex = 26
        Me.btnUpper.Text = "UPPER"
        '
        'btnBase
        '
        Me.btnBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBase.Location = New System.Drawing.Point(686, 44)
        Me.btnBase.Name = "btnBase"
        Me.btnBase.Size = New System.Drawing.Size(132, 45)
        Me.btnBase.TabIndex = 27
        Me.btnBase.Text = "BASE"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(824, 44)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(132, 45)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "CANCEL"
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(12, 75)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(357, 37)
        Me.lblMessage.TabIndex = 29
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'txtOrderCount
        '
        Me.txtOrderCount.BackColor = System.Drawing.Color.Transparent
        Me.txtOrderCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderCount.ForeColor = System.Drawing.Color.Black
        Me.txtOrderCount.Location = New System.Drawing.Point(802, 116)
        Me.txtOrderCount.Name = "txtOrderCount"
        Me.txtOrderCount.Size = New System.Drawing.Size(128, 24)
        Me.txtOrderCount.TabIndex = 30
        '
        'frmOrdersPicked
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 471)
        Me.Controls.Add(Me.txtOrderCount)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnBase)
        Me.Controls.Add(Me.btnUpper)
        Me.Controls.Add(Me.ugOrdersPicked)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmOrdersPicked"
        Me.Text = "frmOrdersPicked"
        Me.Panel1.ResumeLayout(False)
        CType(Me.ugOrdersPicked, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ugOrdersPicked As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnUpper As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnBase As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtOrderCount As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ClearBaseDelayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearUpperDelayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KitchenTrackerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeePerformanceForBasePickerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeePerformanceForUpperPickerToolStripMenuItem As ToolStripMenuItem
End Class
