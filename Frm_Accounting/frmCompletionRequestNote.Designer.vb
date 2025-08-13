<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompletionRequestNote
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
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.txtNote = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSave.Location = New System.Drawing.Point(0, 363)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(528, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save Note"
        '
        'txtNote
        '
        Me.txtNote.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtNote.Location = New System.Drawing.Point(0, 0)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(528, 357)
        Me.txtNote.TabIndex = 1
        '
        'frmCompletionRequestNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 386)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "frmCompletionRequestNote"
        Me.Text = "Completion Request Note"
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtNote As Infragistics.Win.UltraWinEditors.UltraTextEditor
End Class
