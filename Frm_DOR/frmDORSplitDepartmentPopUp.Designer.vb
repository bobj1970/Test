<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDORSplitDepartmentPopUp
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
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.ucDepartments = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtHoursSplit = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnSaveSplitHours = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ucDepartments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHoursSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(12, 12)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 0
        Me.UltraLabel1.Text = "Department"
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
        Me.ucDepartments.Location = New System.Drawing.Point(79, 7)
        Me.ucDepartments.Name = "ucDepartments"
        Me.ucDepartments.Size = New System.Drawing.Size(207, 22)
        Me.ucDepartments.TabIndex = 1
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Location = New System.Drawing.Point(292, 12)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel2.TabIndex = 2
        Me.UltraLabel2.Text = "Hours Split"
        '
        'txtHoursSplit
        '
        Me.txtHoursSplit.Location = New System.Drawing.Point(361, 8)
        Me.txtHoursSplit.Name = "txtHoursSplit"
        Me.txtHoursSplit.Size = New System.Drawing.Size(100, 21)
        Me.txtHoursSplit.TabIndex = 3
        '
        'btnSaveSplitHours
        '
        Me.btnSaveSplitHours.Location = New System.Drawing.Point(12, 37)
        Me.btnSaveSplitHours.Name = "btnSaveSplitHours"
        Me.btnSaveSplitHours.Size = New System.Drawing.Size(496, 23)
        Me.btnSaveSplitHours.TabIndex = 4
        Me.btnSaveSplitHours.Text = "Save Split Hours"
        '
        'frmDORSplitDepartmentPopUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 62)
        Me.Controls.Add(Me.btnSaveSplitHours)
        Me.Controls.Add(Me.txtHoursSplit)
        Me.Controls.Add(Me.UltraLabel2)
        Me.Controls.Add(Me.ucDepartments)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Name = "frmDORSplitDepartmentPopUp"
        Me.Text = "DOR Split Department"
        CType(Me.ucDepartments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHoursSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ucDepartments As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtHoursSplit As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnSaveSplitHours As Infragistics.Win.Misc.UltraButton
End Class
