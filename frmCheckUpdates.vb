Imports System.IO
Imports System.Drawing.Drawing2D

Public Class frmCheckUpdates
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pbDownload As System.Windows.Forms.PictureBox
    Friend WithEvents lnkChangeLog As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkUpdateNow As System.Windows.Forms.LinkLabel
    Friend WithEvents lblVersionAvail As System.Windows.Forms.Label
    Friend WithEvents lblLatestNum As System.Windows.Forms.Label
    Friend WithEvents lblLatestVer As System.Windows.Forms.Label
    Friend WithEvents lblCurrentNum As System.Windows.Forms.Label
    Friend WithEvents lblCurrentVer As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCheckUpdates))
        Me.pbDownload = New System.Windows.Forms.PictureBox
        Me.lnkChangeLog = New System.Windows.Forms.LinkLabel
        Me.lnkUpdateNow = New System.Windows.Forms.LinkLabel
        Me.lblVersionAvail = New System.Windows.Forms.Label
        Me.lblLatestNum = New System.Windows.Forms.Label
        Me.lblLatestVer = New System.Windows.Forms.Label
        Me.lblCurrentNum = New System.Windows.Forms.Label
        Me.lblCurrentVer = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'pbDownload
        '
        Me.pbDownload.BackColor = System.Drawing.Color.Transparent
        Me.pbDownload.Image = CType(resources.GetObject("pbDownload.Image"), System.Drawing.Image)
        Me.pbDownload.Location = New System.Drawing.Point(288, 56)
        Me.pbDownload.Name = "pbDownload"
        Me.pbDownload.Size = New System.Drawing.Size(32, 32)
        Me.pbDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbDownload.TabIndex = 24
        Me.pbDownload.TabStop = False
        Me.pbDownload.Visible = False
        '
        'lnkChangeLog
        '
        Me.lnkChangeLog.BackColor = System.Drawing.Color.Transparent
        Me.lnkChangeLog.Location = New System.Drawing.Point(216, 40)
        Me.lnkChangeLog.Name = "lnkChangeLog"
        Me.lnkChangeLog.Size = New System.Drawing.Size(72, 23)
        Me.lnkChangeLog.TabIndex = 23
        Me.lnkChangeLog.TabStop = True
        Me.lnkChangeLog.Text = "Change Log"
        Me.lnkChangeLog.Visible = False
        '
        'lnkUpdateNow
        '
        Me.lnkUpdateNow.BackColor = System.Drawing.Color.Transparent
        Me.lnkUpdateNow.Location = New System.Drawing.Point(216, 72)
        Me.lnkUpdateNow.Name = "lnkUpdateNow"
        Me.lnkUpdateNow.Size = New System.Drawing.Size(72, 23)
        Me.lnkUpdateNow.TabIndex = 22
        Me.lnkUpdateNow.TabStop = True
        Me.lnkUpdateNow.Text = "Update Now"
        Me.lnkUpdateNow.Visible = False
        '
        'lblVersionAvail
        '
        Me.lblVersionAvail.BackColor = System.Drawing.Color.Transparent
        Me.lblVersionAvail.Location = New System.Drawing.Point(8, 72)
        Me.lblVersionAvail.Name = "lblVersionAvail"
        Me.lblVersionAvail.Size = New System.Drawing.Size(208, 23)
        Me.lblVersionAvail.TabIndex = 21
        Me.lblVersionAvail.Text = "No New Updates Currently Available"
        '
        'lblLatestNum
        '
        Me.lblLatestNum.BackColor = System.Drawing.Color.Transparent
        Me.lblLatestNum.ForeColor = System.Drawing.Color.Blue
        Me.lblLatestNum.Location = New System.Drawing.Point(120, 40)
        Me.lblLatestNum.Name = "lblLatestNum"
        Me.lblLatestNum.Size = New System.Drawing.Size(96, 23)
        Me.lblLatestNum.TabIndex = 20
        '
        'lblLatestVer
        '
        Me.lblLatestVer.BackColor = System.Drawing.Color.Transparent
        Me.lblLatestVer.Location = New System.Drawing.Point(8, 40)
        Me.lblLatestVer.Name = "lblLatestVer"
        Me.lblLatestVer.TabIndex = 19
        Me.lblLatestVer.Text = "Latest Version:"
        '
        'lblCurrentNum
        '
        Me.lblCurrentNum.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentNum.ForeColor = System.Drawing.Color.Red
        Me.lblCurrentNum.Location = New System.Drawing.Point(120, 8)
        Me.lblCurrentNum.Name = "lblCurrentNum"
        Me.lblCurrentNum.Size = New System.Drawing.Size(96, 23)
        Me.lblCurrentNum.TabIndex = 18
        '
        'lblCurrentVer
        '
        Me.lblCurrentVer.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentVer.Location = New System.Drawing.Point(8, 8)
        Me.lblCurrentVer.Name = "lblCurrentVer"
        Me.lblCurrentVer.TabIndex = 17
        Me.lblCurrentVer.Text = "Current Version:"
        '
        'frmCheckUpdates
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(328, 94)
        Me.Controls.Add(Me.pbDownload)
        Me.Controls.Add(Me.lnkChangeLog)
        Me.Controls.Add(Me.lnkUpdateNow)
        Me.Controls.Add(Me.lblVersionAvail)
        Me.Controls.Add(Me.lblLatestNum)
        Me.Controls.Add(Me.lblLatestVer)
        Me.Controls.Add(Me.lblCurrentNum)
        Me.Controls.Add(Me.lblCurrentVer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCheckUpdates"
        Me.Text = "Check Updates"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dsLatestUpdateInfo As New DataSet

    Private Sub frmChkUpdates_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim BaseRectangle As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim Gradient_Brush As New LinearGradientBrush(BaseRectangle, Color.White, Color.DarkSlateBlue, 45) 'Gradient Degree
        e.Graphics.FillRectangle(Gradient_Brush, BaseRectangle)
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    Private Sub frmChkUpdates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'UpdateMode()  'Debug (Update On)
        CheckUpdates()
    End Sub

    Public Shared Sub GetResources()

        'Try
        '    If File.Exists(Application.StartupPath & "\KPUpdater.exe") = False Then
        '        'Get KPUpdater.exe from Application's Embedded Resource
        '        Dim fs As New FileStream(Application.StartupPath & "\KPUpdater.exe", FileMode.CreateNew, FileAccess.Write)

        '        Dim br As New BinaryReader(Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(Application.ProductName & ".KPUpdater.exe"))
        '        Dim bw As New BinaryWriter(fs)

        '        Dim byteRead As Byte
        '        Dim i As Integer
        '        For i = 0 To br.BaseStream.Length() - 1
        '            byteRead = br.ReadByte
        '            bw.Write(byteRead)
        '        Next
        '        br.Close()
        '        bw.Close()
        '        fs.Close()
        '    Else
        '        Exit Sub
        '    End If

        'Catch ex As Exception
        '    MsgBox("Cannot get Required Resources." & vbCrLf & _
        '    ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try

    End Sub

    Private Function GetAssemblyTitleAttribute() As System.Reflection.AssemblyTitleAttribute
        Try
            Dim asm As System.Reflection.Assembly
            ' <Assembly: AssemblyTitle("My Assembly Title")> 
            Dim titleAttr As System.Reflection.AssemblyTitleAttribute
            ' Get the current executing Assembly 
            asm = System.Reflection.Assembly.GetExecutingAssembly
            ' Get the Title Attribute 
            titleAttr = asm.GetCustomAttributes(GetType(System.Reflection.AssemblyTitleAttribute), False)(0)
            Return titleAttr

        Catch ex As Exception
            MsgBox("Cannot get Assembly Info." & vbCrLf & _
            ex.Message, MsgBoxStyle.Information, "Error")
            Return Nothing
        End Try

    End Function

    Private Sub CheckUpdates()
        Try
            If KPGeneral.isTestDB = False Then
                dsLatestUpdateInfo.Clear()
                lblCurrentNum.Text = Convert.ToString(System.Reflection.Assembly.GetExecutingAssembly.GetName.Version())

                dsLatestUpdateInfo = KPGeneral.WebRef_Local.LatestSoftwareUpdateInfo(GetAssemblyTitleAttribute.Title) 'GetAssemblyTitleAttribute Function
                If dsLatestUpdateInfo.Tables(0).Rows.Count > 0 Then
                    If dsLatestUpdateInfo.Tables(0).Rows(0)("SWVersion") <> Nothing Then
                        lblLatestNum.Text = dsLatestUpdateInfo.Tables(0).Rows(0)("SWVersion")
                        If lblLatestNum.Text > lblCurrentNum.Text Then
                            'UpdateMode()
                            'Dim Updater As New frmUpdater
                            'Updater.Show()
                            StartUpdate(System.Windows.Forms.Application.ProductName.Trim, KPGeneral.StartupPath.Trim, dsLatestUpdateInfo.Tables(0).Rows(0)("SWID"))
                        End If
                    Else
                        lblLatestNum.Text = "Unavailable"
                    End If
                Else
                    lblLatestNum.Text = "Unavailable"
                End If
            End If

        Catch ex As Exception
            MsgBox("Cannot get Update Info." & vbCrLf & _
            ex.Message, MsgBoxStyle.Information, "Error")
        End Try

    End Sub

    Private Sub lnkChangeLog_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkChangeLog.LinkClicked
        Try
            MsgBox( _
            "Version: " & dsLatestUpdateInfo.Tables(0).Rows(0)("SWVersion") & vbCrLf & _
            "Release Date: " & dsLatestUpdateInfo.Tables(0).Rows(0)("SWReleaseDate") & vbCrLf & _
            "Update Notes: " & dsLatestUpdateInfo.Tables(0).Rows(0)("SWUpdateNotes") & vbCrLf & _
            "Known Bugs: " & dsLatestUpdateInfo.Tables(0).Rows(0)("SWKnownBugs"), _
            MsgBoxStyle.Information, "Change Log")
        Catch ex As Exception
            MsgBox("Cannot get Change Log info." & vbCrLf & _
            ex.Message, MsgBoxStyle.Information, "Error")
        End Try

    End Sub

    Private Sub UpdateMode()
        lblVersionAvail.Text = "New Version Available for Update"
        lnkUpdateNow.Visible = True
        pbDownload.Visible = True
        lnkChangeLog.Visible = True
    End Sub

    Private Sub StartUpdate(ByVal SWName As String, ByVal SWStartupPath As String, ByVal SWID As Integer)

        'GetResources()

        Try

            'MsgBox(ChrW(34) & SWName & ChrW(34) & " " & ChrW(34) & SWStartupPath & ChrW(34) & " " & ChrW(34) & SWID & ChrW(34)) 'debug

            If File.Exists(KPGeneral.StartupPath & "\KPUpdater.exe") = True Then
                Dim KPUpdater As New Process
                KPUpdater.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                KPUpdater.StartInfo.CreateNoWindow = True
                KPUpdater.StartInfo.WorkingDirectory = KPGeneral.StartupPath
                KPUpdater.StartInfo.FileName = "KPUpdater.exe"
                KPUpdater.StartInfo.Arguments = ChrW(34) & SWName & ChrW(34) & " " & ChrW(34) & SWStartupPath & ChrW(34) & " " & ChrW(34) & SWID & ChrW(34)
                KPUpdater.Start()
                KPUpdater.Dispose()
                Me.Close()
            Else
                MsgBox("Required files does not exist or has been moved", MsgBoxStyle.Critical, "Error Extracting Update")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("Cannot extract Update Data." & vbCrLf & _
            ex.Message, MsgBoxStyle.Information, "Error")
        End Try

    End Sub

    Private Sub lnkUpdateNow_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkUpdateNow.LinkClicked
        Try
            If System.Windows.Forms.Application.ProductName.Trim = GetAssemblyTitleAttribute.Title Then
                StartUpdate(System.Windows.Forms.Application.ProductName.Trim, KPGeneral.StartupPath.Trim, dsLatestUpdateInfo.Tables(0).Rows(0)("SWID"))
            Else
                MsgBox("Assembly info does not match." & vbCrLf & _
                "Please contact your Software Developer." _
                , MsgBoxStyle.Information, "Error")
            End If
        Catch ex As Exception
            MsgBox("Cannot start Update." & vbCrLf & _
            ex.Message, MsgBoxStyle.Information, "Error")
        End Try
    End Sub

End Class
