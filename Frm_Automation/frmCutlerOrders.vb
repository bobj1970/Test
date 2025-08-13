Imports System.IO
Public Class frmCutlerOrders
    Dim LastUpdate As Integer
    Private Sub frmCutlerOrders_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            GetOrders()
            KPGeneral.SetDefaultGridSettings(ugOrders)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub RefreshOrders()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.spKP_GetAutomatedOrderLogByDateAndCompany(Now.Date, "Cutler")

        ugOrders.DataSource = ds
    End Sub
    Private Sub GetOrders()
        Dim dsOrders As New DataSet
        dsOrders = KPGeneral.WebRef_Local.getOutstandingCutlerOrders

        Dim x As Integer
        For x = 0 To dsOrders.Tables(0).Rows.Count - 1
            GetDoorList(dsOrders.Tables(0).Rows(x)("Masternum"), dsOrders.Tables(0).Rows(x)("Style"), dsOrders.Tables(0).Rows(x)("Colour"), dsOrders.Tables(0).Rows(x)("SumID"))
            KPGeneral.WebRef_Local.setDoorOrderDateCutlerBySumID(CInt(dsOrders.Tables(0).Rows(x)("SumID")))
        Next

        RefreshOrders()
    End Sub
    Sub GetDoorList(ByVal MasterNum As String, ByVal StyleShortCode As String, ByVal ColourShotCode As String, SumID As Integer)

        Dim rptName As New RptDoorListByStyleColour
        Dim dsOrderStatus As DataSet = KPGeneral.WebRef_Local.spKP_OrderStatusByFK(MasterNum)
        If dsOrderStatus.Tables(0).Rows.Count > 0 Then
            Dim FilePath As String = KPGeneral.StartupPath + "\" + CStr(SumID) + ".pdf"
            Dim CSID As Integer = dsOrderStatus.Tables(0).Rows(0)("CSID")
            Dim ds As New DataSet
            ds = KPGeneral.CreateDoorListXML(Convert.ToInt32(CSID), Nothing, Nothing, -1, -1)
            rptName.SetDataSource(ds)
            rptName.SetParameterValue("CompanyName", "Cutler")
            rptName.SetParameterValue("StyleShortCode", StyleShortCode)
            rptName.SetParameterValue("ColourShortCode", ColourShotCode)
            'rptName.PrintToPrinter(1, True, 0, 0)
            'rptName.Close()
            'rptName.Dispose()
            rptName.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, FilePath)
            If Not DB.isTestDB Then
                Dim Message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("samp@frendel.com", "Melissa@cutlergroup.com")
                Message.IsBodyHtml = False
                Message.CC.Add("sales@cutlergroup.com, samp@frendel.com, sequencenotifications@frendel.com")
                Message.Subject = "Frendel Kitchens Limited - Door Order - PO# " + CStr(SumID)
                Message.Body = "Door Order - PO# " + CStr(SumID)
                Message.Body = Message.Body + vbCrLf + "FK:" + MasterNum
                Message.Body = Message.Body + vbCrLf + "Style:" + StyleShortCode
                Message.Body = Message.Body + vbCrLf + "Colour:" + ColourShotCode
                Message.Body = Message.Body + vbCrLf + vbCrLf + "Thank you,"
                Message.Body = Message.Body + vbCrLf + vbCrLf + "Sam Pantusa"
                Message.Body = Message.Body + vbCrLf + vbCrLf + vbCrLf + vbCrLf
                Message.Body = Message.Body + vbCrLf + "Builder:" + dsOrderStatus.Tables(0).Rows(0)("Company").ToString
                Message.Body = Message.Body + vbCrLf + "Project:" + dsOrderStatus.Tables(0).Rows(0)("Project").ToString
                Message.Body = Message.Body + vbCrLf + "Lot:" + dsOrderStatus.Tables(0).Rows(0)("Lot").ToString
                Dim value As Net.Mail.AttachmentCollection
                value = Message.Attachments
                If File.Exists(FilePath) = True Then
                    Dim nValue As Net.Mail.Attachment = New Net.Mail.Attachment(FilePath)
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
            If File.Exists(FilePath) = True Then
                If KPGeneral.SaveImage(FilePath, MasterNum, "SO", MasterNum, "PDF") = True Then
                    KPGeneral.DeleteFileByFilePath(FilePath)
                End If
            End If
            KPGeneral.WebRef_Local.spKP_InsertLotComment(dsOrderStatus.Tables(0).Rows(0)("CSID"), KPGeneral.User.UserProfile("UserLoginName"), KPGeneral.User.UserProfile("Department"), "Doors automatically ordered from Cutler.", 16)
            KPGeneral.WebRef_Local.spKP_InsertAutomatedOrderLog(dsOrderStatus.Tables(0).Rows(0)("CSID"), KPGeneral.User.UserProfile("UserLoginName"), "Cutler")
        End If

    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            LastUpdate = LastUpdate + 1

            If LastUpdate > 300 Then
                LastUpdate = 0
                If Now.Hour >= 17 Then
                    GetOrders()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Timer1.Stop()
        End Try

    End Sub

End Class