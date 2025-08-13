Imports System.IO

Public Class frmNightlyReportEmails
    Dim TTick As Integer
    Dim CurrentDate As DateTime
    Dim SentEmail As Boolean

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            TTick = TTick + 1
            If TTick > 300 Then
                TTick = 0
                If CurrentDate = Now.Date Then
                    If Now.DayOfWeek <> DayOfWeek.Saturday And Now.DayOfWeek <> DayOfWeek.Sunday Then
                        If Now.Hour >= 16 Then
                            If SentEmail = False AndAlso Not DB.isTestDB Then
                                SendReportEmails()

                                SentEmail = True
                            End If
                        End If
                    End If

                Else
                    CurrentDate = Now.Date
                    SentEmail = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Timer1.Stop()
        End Try

    End Sub
    Private Sub SendReportEmails()
        If SentEmail = False Then
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.usp_GetNightlyReportsToEmail

            If ds.Tables(0).Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(x)("SecurityCount") > 0 Then
                        Dim dString As String = Now.Date
                        Dim eSubject As String = ds.Tables(0).Rows(x)("ReportName") & " - " & dString.Replace("/", "-")
                        Dim eBody As String = ds.Tables(0).Rows(x)("ReportName") & " for " & dString.Replace("/", "-")

                        ReportsEngine.ReportOptions.FDate = Now.Date
                        ReportsEngine.ReportOptions.PrintOption = 5
                        ReportsEngine.ReportOptions.FilePath = KPGeneral.StartupPath & "\TempReportEmail\" & ds.Tables(0).Rows(x)("ReportName") & " - " & dString.Replace("/", "-") & ".pdf"
                        ReportsEngine.ReportOptions.FileExt = "PDF"
                        ReportsEngine.SelectedReport(ds.Tables(0).Rows(x)("ReportNum"))

                        SendReportEmail(KPGeneral.StartupPath & "\TempReportEmail\" & ds.Tables(0).Rows(x)("ReportName") & " - " & dString.Replace("/", "-") & ".pdf",
                                        ds.Tables(0).Rows(x)("EmailUser") & "@frendel.com", eSubject, eBody)

                        KPGeneral.WebRef_Local.usp_InsertNightlyReportsToEmailLog(ds.Tables(0).Rows(x)("ReportNum"), ds.Tables(0).Rows(x)("EmailUser"))
                    End If
                Next
            End If

            GetSentReportLog()
            SentEmail = True
        End If


    End Sub
    Private Sub SendReportEmail(ByVal FileName As String, ByVal ToEmail As String, ByVal eSubject As String, ByVal eBody As String)
        Dim Message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(KPGeneral.User.UserProfile("UserLoginName") & "@frendel.com", ToEmail)
        Message.IsBodyHtml = True

        Message.Subject = eSubject
        Message.Body = eBody

        Dim value As Net.Mail.AttachmentCollection
        value = Message.Attachments
        If File.Exists(FileName) = True Then
            Dim nValue As Net.Mail.Attachment = New Net.Mail.Attachment(FileName)
            Message.Attachments.Add(nValue)
        End If
        Try
            Dim SmtpNewClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()
            SmtpNewClient.Host = "mail.frendel.com"
            SmtpNewClient.Send(Message)

        Catch ehttp As System.Net.WebException
            Console.WriteLine("0", ehttp.Message)
            Console.WriteLine("Here is the full error message")
            Console.Write("0", ehttp.ToString())
        End Try
        Message.Attachments.Dispose()
        value.Dispose()
        ReportsEngine.ReportOptions.EmailAdd = Nothing
        KPGeneral.DeleteFileByFilePath(FileName)
    End Sub
    Private Sub frmNightlyReportEmails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentDate = Now.Date
        SentEmail = False
        'SendReportEmails()

        GetSentReportLog()

        KPGeneral.SetDefaultGridSettings(ugReportLog)
    End Sub
    Private Sub GetSentReportLog()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetNightlyReportsToEmailLog

        ugReportLog.DataSource = ds
    End Sub
End Class