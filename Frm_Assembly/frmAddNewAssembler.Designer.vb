<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddNewAssembler
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
        Me.tbTargetPercentage = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.cbDefaultClampNumber = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.tbPassword = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lbPassword = New Infragistics.Win.Misc.UltraLabel()
        Me.btnAddWorker = New Infragistics.Win.Misc.UltraButton()
        Me.tbAvgPerformance = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.tbStationName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.tbEmpRef = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.btCancel = New Infragistics.Win.Misc.UltraButton()
        CType(Me.tbTargetPercentage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDefaultClampNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAvgPerformance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbStationName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEmpRef, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbTargetPercentage
        '
        Me.tbTargetPercentage.Location = New System.Drawing.Point(163, 120)
        Me.tbTargetPercentage.Name = "tbTargetPercentage"
        Me.tbTargetPercentage.Size = New System.Drawing.Size(211, 21)
        Me.tbTargetPercentage.TabIndex = 46
        '
        'UltraLabel7
        '
        Me.UltraLabel7.Location = New System.Drawing.Point(22, 124)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(124, 23)
        Me.UltraLabel7.TabIndex = 47
        Me.UltraLabel7.Text = "Target Percentage"
        '
        'cbDefaultClampNumber
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cbDefaultClampNumber.DisplayLayout.Appearance = Appearance1
        Me.cbDefaultClampNumber.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cbDefaultClampNumber.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.cbDefaultClampNumber.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cbDefaultClampNumber.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.cbDefaultClampNumber.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cbDefaultClampNumber.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.cbDefaultClampNumber.DisplayLayout.MaxColScrollRegions = 1
        Me.cbDefaultClampNumber.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbDefaultClampNumber.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cbDefaultClampNumber.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.cbDefaultClampNumber.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cbDefaultClampNumber.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.cbDefaultClampNumber.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cbDefaultClampNumber.DisplayLayout.Override.CellAppearance = Appearance8
        Me.cbDefaultClampNumber.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cbDefaultClampNumber.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.cbDefaultClampNumber.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.cbDefaultClampNumber.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.cbDefaultClampNumber.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cbDefaultClampNumber.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.cbDefaultClampNumber.DisplayLayout.Override.RowAppearance = Appearance11
        Me.cbDefaultClampNumber.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbDefaultClampNumber.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.cbDefaultClampNumber.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cbDefaultClampNumber.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cbDefaultClampNumber.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cbDefaultClampNumber.Location = New System.Drawing.Point(163, 155)
        Me.cbDefaultClampNumber.Name = "cbDefaultClampNumber"
        Me.cbDefaultClampNumber.Size = New System.Drawing.Size(211, 22)
        Me.cbDefaultClampNumber.TabIndex = 38
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(163, 190)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.Size = New System.Drawing.Size(211, 21)
        Me.tbPassword.TabIndex = 39
        '
        'lbPassword
        '
        Me.lbPassword.Location = New System.Drawing.Point(22, 194)
        Me.lbPassword.Name = "lbPassword"
        Me.lbPassword.Size = New System.Drawing.Size(100, 23)
        Me.lbPassword.TabIndex = 45
        Me.lbPassword.Text = "Password"
        '
        'btnAddWorker
        '
        Me.btnAddWorker.Location = New System.Drawing.Point(163, 232)
        Me.btnAddWorker.Name = "btnAddWorker"
        Me.btnAddWorker.Size = New System.Drawing.Size(95, 27)
        Me.btnAddWorker.TabIndex = 40
        Me.btnAddWorker.Text = "Add Assembler"
        '
        'tbAvgPerformance
        '
        Me.tbAvgPerformance.Location = New System.Drawing.Point(163, 85)
        Me.tbAvgPerformance.Name = "tbAvgPerformance"
        Me.tbAvgPerformance.Size = New System.Drawing.Size(211, 21)
        Me.tbAvgPerformance.TabIndex = 37
        '
        'tbStationName
        '
        Me.tbStationName.Location = New System.Drawing.Point(163, 15)
        Me.tbStationName.Name = "tbStationName"
        Me.tbStationName.Size = New System.Drawing.Size(211, 21)
        Me.tbStationName.TabIndex = 35
        '
        'tbEmpRef
        '
        Me.tbEmpRef.Location = New System.Drawing.Point(163, 50)
        Me.tbEmpRef.Name = "tbEmpRef"
        Me.tbEmpRef.Size = New System.Drawing.Size(211, 21)
        Me.tbEmpRef.TabIndex = 36
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Location = New System.Drawing.Point(22, 89)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(124, 23)
        Me.UltraLabel5.TabIndex = 44
        Me.UltraLabel5.Text = "Avg Daily Performance"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(22, 157)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(124, 23)
        Me.UltraLabel4.TabIndex = 43
        Me.UltraLabel4.Text = "Default Clamp Number"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(22, 20)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 41
        Me.UltraLabel1.Text = "Station Name"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(22, 53)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel2.TabIndex = 42
        Me.UltraLabel2.Text = "Employee #"
        '
        'btCancel
        '
        Me.btCancel.Location = New System.Drawing.Point(281, 232)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(93, 27)
        Me.btCancel.TabIndex = 48
        Me.btCancel.Text = "Cancel"
        '
        'frmAddNewAssembler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 300)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.tbTargetPercentage)
        Me.Controls.Add(Me.UltraLabel7)
        Me.Controls.Add(Me.cbDefaultClampNumber)
        Me.Controls.Add(Me.tbPassword)
        Me.Controls.Add(Me.lbPassword)
        Me.Controls.Add(Me.btnAddWorker)
        Me.Controls.Add(Me.tbAvgPerformance)
        Me.Controls.Add(Me.tbStationName)
        Me.Controls.Add(Me.tbEmpRef)
        Me.Controls.Add(Me.UltraLabel5)
        Me.Controls.Add(Me.UltraLabel4)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Name = "frmAddNewAssembler"
        Me.Text = "Add New Assembler"
        CType(Me.tbTargetPercentage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDefaultClampNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAvgPerformance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbStationName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEmpRef, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbTargetPercentage As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cbDefaultClampNumber As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents tbPassword As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lbPassword As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnAddWorker As Infragistics.Win.Misc.UltraButton
    Friend WithEvents tbAvgPerformance As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents tbStationName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents tbEmpRef As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btCancel As Infragistics.Win.Misc.UltraButton
End Class
