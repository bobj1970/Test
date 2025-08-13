<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmForkliftDoorBoxes
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
        Me.upUserControls = New Infragistics.Win.Misc.UltraPanel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.upUserControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'upUserControls
        '
        Me.upUserControls.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.upUserControls.Location = New System.Drawing.Point(0, 41)
        Me.upUserControls.Name = "upUserControls"
        Me.upUserControls.Size = New System.Drawing.Size(800, 409)
        Me.upUserControls.TabIndex = 0
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 16.0!
        Appearance1.TextHAlignAsString = "Center"
        Me.UltraLabel1.Appearance = Appearance1
        Me.UltraLabel1.Location = New System.Drawing.Point(0, 1)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(800, 35)
        Me.UltraLabel1.TabIndex = 1
        Me.UltraLabel1.Text = "DOOR BOXES REQUIRED"
        '
        'frmForkliftDoorBoxes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.UltraLabel1)
        Me.Controls.Add(Me.upUserControls)
        Me.Name = "frmForkliftDoorBoxes"
        Me.Text = "frmForkliftDoorBoxes"
        Me.upUserControls.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents upUserControls As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
End Class
