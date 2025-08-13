<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uctrlForkliftDoorBoxes
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.btnComplete = New Infragistics.Win.Misc.UltraButton()
        Me.lblDLocation = New Infragistics.Win.Misc.UltraLabel()
        Me.lblBox = New Infragistics.Win.Misc.UltraLabel()
        Me.lblFK = New Infragistics.Win.Misc.UltraLabel()
        Me.lblForkliftNumber = New Infragistics.Win.Misc.UltraLabel()
        Me.SuspendLayout()
        '
        'btnComplete
        '
        Me.btnComplete.Location = New System.Drawing.Point(3, 90)
        Me.btnComplete.Name = "btnComplete"
        Me.btnComplete.Size = New System.Drawing.Size(285, 37)
        Me.btnComplete.TabIndex = 0
        Me.btnComplete.Text = "COMPLETE"
        '
        'lblDLocation
        '
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.SizeInPoints = 14.0!
        Appearance4.TextHAlignAsString = "Center"
        Me.lblDLocation.Appearance = Appearance4
        Me.lblDLocation.Location = New System.Drawing.Point(3, 3)
        Me.lblDLocation.Name = "lblDLocation"
        Me.lblDLocation.Size = New System.Drawing.Size(280, 23)
        Me.lblDLocation.TabIndex = 1
        Me.lblDLocation.Text = "Location"
        '
        'lblBox
        '
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.FontData.SizeInPoints = 14.0!
        Appearance5.TextHAlignAsString = "Center"
        Me.lblBox.Appearance = Appearance5
        Me.lblBox.Location = New System.Drawing.Point(3, 32)
        Me.lblBox.Name = "lblBox"
        Me.lblBox.Size = New System.Drawing.Size(280, 23)
        Me.lblBox.TabIndex = 2
        Me.lblBox.Text = "Box"
        '
        'lblFK
        '
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.SizeInPoints = 14.0!
        Appearance6.TextHAlignAsString = "Center"
        Me.lblFK.Appearance = Appearance6
        Me.lblFK.Location = New System.Drawing.Point(3, 61)
        Me.lblFK.Name = "lblFK"
        Me.lblFK.Size = New System.Drawing.Size(280, 23)
        Me.lblFK.TabIndex = 3
        Me.lblFK.Text = "FK"
        '
        'lblForkliftNumber
        '
        Me.lblForkliftNumber.Location = New System.Drawing.Point(285, 59)
        Me.lblForkliftNumber.Name = "lblForkliftNumber"
        Me.lblForkliftNumber.Size = New System.Drawing.Size(100, 23)
        Me.lblForkliftNumber.TabIndex = 4
        '
        'uctrlForkliftDoorBoxes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.lblForkliftNumber)
        Me.Controls.Add(Me.lblFK)
        Me.Controls.Add(Me.lblBox)
        Me.Controls.Add(Me.lblDLocation)
        Me.Controls.Add(Me.btnComplete)
        Me.Name = "uctrlForkliftDoorBoxes"
        Me.Size = New System.Drawing.Size(289, 130)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnComplete As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblDLocation As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblBox As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblFK As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblForkliftNumber As Infragistics.Win.Misc.UltraLabel
End Class
