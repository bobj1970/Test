Imports CrystalDecisions.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSendCompletionRequest
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
        Me.btnEmail = New Infragistics.Win.Misc.UltraButton()
        Me.cvCompletionRequest = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'btnEmail
        '
        Me.btnEmail.Location = New System.Drawing.Point(12, 12)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New System.Drawing.Size(75, 23)
        Me.btnEmail.TabIndex = 0
        Me.btnEmail.Text = "Email"
        '
        'cvCompletionRequest
        '
        Me.cvCompletionRequest.ActiveViewIndex = -1
        Me.cvCompletionRequest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cvCompletionRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cvCompletionRequest.Cursor = System.Windows.Forms.Cursors.Default
        Me.cvCompletionRequest.Location = New System.Drawing.Point(12, 41)
        Me.cvCompletionRequest.Name = "cvCompletionRequest"
        Me.cvCompletionRequest.SelectionFormula = ""
        Me.cvCompletionRequest.ShowGroupTreeButton = False
        Me.cvCompletionRequest.Size = New System.Drawing.Size(909, 549)
        Me.cvCompletionRequest.TabIndex = 2
        Me.cvCompletionRequest.ViewTimeSelectionFormula = ""
        '
        'frmSendCompletionRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 602)
        Me.Controls.Add(Me.cvCompletionRequest)
        Me.Controls.Add(Me.btnEmail)
        Me.Name = "frmSendCompletionRequest"
        Me.Text = "Send Completion Request"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnEmail As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cvCompletionRequest As CrystalReportViewer
End Class
