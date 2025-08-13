Imports System.IO

Public Class frmSendCompletionRequest
    Public Shared CompletionRequestID As Integer
    Private Sub frmSendCompletionRequest_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshPreview(False, True)

    End Sub
    Private Sub RefreshPreview(ByVal isFax As Boolean, ByVal isPreview As Boolean)
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetCompletionsRequestDetail_Report(CompletionRequestID)

        'ds.WriteXml("c:\xml\kpro.xml", XmlWriteMode.WriteSchema)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim rpt As New rptCompletionRequest
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("isFax", isFax)

            If isPreview = True Then
                cvCompletionRequest.ReportSource = rpt
            Else
                If isFax = True Then
                    rpt.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
                    rpt.Close()
                    rpt.Dispose()

                    KPGeneral.WebRef_Local.usp_InsertCompletionsRequestLog(CompletionRequestID, KPGeneral.User.UserProfile("UserLoginName"), 2)

                    Me.Close()
                Else
                    Dim dString As String = Now.Date
                    Dim eSubject As String = "Completion Request for " & ds.Tables(0).Rows(0)("Company") & " - " & ds.Tables(0).Rows(0)("Project")
                    Dim eBody As String = "Completion Request for " & ds.Tables(0).Rows(0)("Company") & " - " & ds.Tables(0).Rows(0)("Project")

                    Dim FName As String
                    FName = KPGeneral.StartupPath & "\TempReportEmail\Completion Request for " & ds.Tables(0).Rows(0)("Company") & " - " & ds.Tables(0).Rows(0)("Project") & ".pdf"
                    FName = FName.Replace("/", "_")
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, FName)
                    If Not DB.isTestDB Then
                        SendReportEmail(FName, eSubject, eBody, CompletionRequestID, ds.Tables(0).Rows(0)("UserID"))
                    End If
                    rpt.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
                    rpt.Close()
                    KPGeneral.WebRef_Local.usp_InsertCompletionsRequestLog(CompletionRequestID, KPGeneral.User.UserProfile("UserLoginName"), 1)
                    Me.Close()
                End If
            End If
        Else
            cvCompletionRequest.ReportSource = Nothing
        End If

    End Sub
    Private Sub SendReportEmail(ByVal FileName As String, ByVal eSubject As String, ByVal eBody As String, ByVal CompletionRequestID As Integer, ByVal eSender As String)

        Dim dsContacts As New DataSet
        dsContacts = KPGeneral.WebRef_Local.usp_GetCompletionsRequestContactsByCompletionRequestID(CompletionRequestID)
        If dsContacts.Tables(0).Rows.Count > 0 Then
            Dim Message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(eSender & "@frendel.com", dsContacts.Tables(0).Rows(0)("ContactEmail"))
            Message.IsBodyHtml = True
            If dsContacts.Tables(0).Rows.Count > 1 Then
                Dim x As Integer
                For x = 1 To dsContacts.Tables(0).Rows.Count - 1
                    Message.CC.Add(dsContacts.Tables(0).Rows(x)("ContactEmail"))
                Next
            End If
            Message.CC.Add(eSender & "@frendel.com")
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
        End If
        KPGeneral.DeleteFileByFilePath(FileName)

    End Sub
    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        RefreshPreview(False, False)
    End Sub

End Class