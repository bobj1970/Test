<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPantryDelayPopup
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
        Me.ugbDelayReasons = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnPanelProcessing = New Infragistics.Win.Misc.UltraButton()
        Me.btnHardware = New Infragistics.Win.Misc.UltraButton()
        Me.btnFinishing = New Infragistics.Win.Misc.UltraButton()
        Me.btnCustom = New Infragistics.Win.Misc.UltraButton()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        CType(Me.ugbDelayReasons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ugbDelayReasons.SuspendLayout()
        Me.SuspendLayout()
        '
        'ugbDelayReasons
        '
        Me.ugbDelayReasons.Controls.Add(Me.btnPanelProcessing)
        Me.ugbDelayReasons.Controls.Add(Me.btnHardware)
        Me.ugbDelayReasons.Controls.Add(Me.btnFinishing)
        Me.ugbDelayReasons.Controls.Add(Me.btnCustom)
        Me.ugbDelayReasons.Controls.Add(Me.UltraLabel4)
        Me.ugbDelayReasons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugbDelayReasons.Location = New System.Drawing.Point(0, 0)
        Me.ugbDelayReasons.Name = "ugbDelayReasons"
        Me.ugbDelayReasons.Size = New System.Drawing.Size(616, 145)
        Me.ugbDelayReasons.TabIndex = 31
        '
        'btnPanelProcessing
        '
        Me.btnPanelProcessing.Location = New System.Drawing.Point(448, 55)
        Me.btnPanelProcessing.Name = "btnPanelProcessing"
        Me.btnPanelProcessing.Size = New System.Drawing.Size(140, 55)
        Me.btnPanelProcessing.TabIndex = 34
        Me.btnPanelProcessing.Text = "Panel Processing"
        '
        'btnHardware
        '
        Me.btnHardware.Location = New System.Drawing.Point(302, 55)
        Me.btnHardware.Name = "btnHardware"
        Me.btnHardware.Size = New System.Drawing.Size(140, 55)
        Me.btnHardware.TabIndex = 33
        Me.btnHardware.Text = "Hardware"
        '
        'btnFinishing
        '
        Me.btnFinishing.Location = New System.Drawing.Point(156, 55)
        Me.btnFinishing.Name = "btnFinishing"
        Me.btnFinishing.Size = New System.Drawing.Size(140, 55)
        Me.btnFinishing.TabIndex = 32
        Me.btnFinishing.Text = "Finishing"
        '
        'btnCustom
        '
        Me.btnCustom.Location = New System.Drawing.Point(10, 55)
        Me.btnCustom.Name = "btnCustom"
        Me.btnCustom.Size = New System.Drawing.Size(140, 55)
        Me.btnCustom.TabIndex = 31
        Me.btnCustom.Text = "Custom"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(6, 6)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(427, 43)
        Me.UltraLabel4.TabIndex = 30
        Me.UltraLabel4.Text = "Select reason for delay"
        '
        'frmPantryDelayPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 145)
        Me.Controls.Add(Me.ugbDelayReasons)
        Me.Name = "frmPantryDelayPopup"
        Me.Text = "Pantry Delay"
        CType(Me.ugbDelayReasons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ugbDelayReasons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ugbDelayReasons As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnPanelProcessing As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnHardware As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnFinishing As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCustom As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
End Class
