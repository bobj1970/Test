Imports System.IO
Imports System.Net
Imports System.Net.Mail

Public Class ucWebStatus
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Dim SmtpMail As Object

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents pbWebStatus As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pbWebStatus = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'pbWebStatus
        '
        Me.pbWebStatus.BackColor = System.Drawing.Color.Transparent
        Me.pbWebStatus.Location = New System.Drawing.Point(0, 0)
        Me.pbWebStatus.Name = "pbWebStatus"
        Me.pbWebStatus.Size = New System.Drawing.Size(20, 20)
        Me.pbWebStatus.TabIndex = 0
        Me.pbWebStatus.TabStop = False
        '
        'ucWebStatus
        '
        Me.BackColor = System.Drawing.Color.DarkBlue
        Me.Controls.Add(Me.pbWebStatus)
        Me.Name = "ucWebStatus"
        Me.Size = New System.Drawing.Size(20, 20)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim ServOn As Boolean = True
    Dim start_time As DateTime
    Dim stop_time As DateTime
    Dim elapsed_time As TimeSpan
    Dim calling_app As String
    Dim StatusImgOff As New Bitmap(Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(System.Windows.Forms.Application.ProductName & "." & "off.gif"))
    Dim StatusImgOn As New Bitmap(Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(System.Windows.Forms.Application.ProductName & "." & "on.gif"))

    'Gets the WebServ state as True/False
    Public Function WebServFound(ByVal sender As Object) As Boolean
        calling_app = Mid(sender.GetType.AssemblyQualifiedName.ToString, 1, InStr(sender.GetType.AssemblyQualifiedName.ToString, ", Culture") - 1)
        WebServAvailable()
        Return ServOn
    End Function

    'Returns WebServ state as Image on User Control - Green = On / Flashing Red = Off
    Private Sub WebServAvailable()
        Dim req As HttpWebRequest
        Dim res As HttpWebResponse
        Try
            req = CType(WebRequest.Create("http://ws.frendel.com/KPWebServ/KitchenPro/KProManagmentSys.asmx"), HttpWebRequest)
            req.KeepAlive = False
            res = CType(req.GetResponse(), HttpWebResponse)
            req.Abort()

            If res.StatusCode = HttpStatusCode.OK Then
                If ServOn = False Then 'If server was not previously available, then do this
                    stop_time = Now
                    elapsed_time = stop_time.Subtract(start_time)
                    SendAlert()
                End If
                ServOn = True
                pbWebStatus.Image = StatusImgOn
            End If

        Catch weberrt As WebException
            If ServOn = True Then
                ServOn = False
                start_time = Now
            End If
            pbWebStatus.Image = StatusImgOff

        Catch except As Exception
            If ServOn = True Then
                ServOn = False
                start_time = Now
            End If
            pbWebStatus.Image = StatusImgOff

        End Try
    End Sub

    'Send Email Alert
    Private Sub SendAlert()
        Try
            Dim ipEntry As IPHostEntry = Dns.GetHostByName(Environment.MachineName)
            Dim IpAddr As IPAddress() = ipEntry.AddressList
            'Format the body text
            Dim msgBody As String = Trim(System.Environment.MachineName) & " - IP: " & IpAddr(0).ToString() & " experienced temporary downtime." & vbCrLf & calling_app & vbCrLf _
            & "Downtime - Hours: " & elapsed_time.TotalHours.ToString("00") & " / Minutes: " & elapsed_time.TotalMinutes.ToString("00") & " / Seconds: " & elapsed_time.TotalSeconds.ToString("00") & vbCrLf _
            & "Connection Lost: " & start_time & vbCrLf _
            & "Connection Re-Established: " & stop_time
            Email("technology@frendel.com", "technology@frendel.com", "Warehouse Alert - Connection lost on " & Trim(System.Environment.MachineName), msgBody)
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

    End Sub

    'Email using smtp mail server - Reference: System.Web.dll
    Private Sub Email(ByVal msgFrom As String, ByVal msgTo As String, ByVal msgSubject As String, ByVal msgBody As String, Optional ByVal msgBcc As String = vbNullString)
        Try
            Dim Msg As MailMessage = New MailMessage(msgFrom, msgTo, msgBcc, msgBody)
            Msg.Subject = msgSubject
            Msg.Priority = MailPriority.High

            SmtpMail.SmtpServer = "mail.frendel.com"
            SmtpMail.Send(Msg)
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

    End Sub

End Class
