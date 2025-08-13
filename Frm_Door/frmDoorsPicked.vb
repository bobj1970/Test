Imports System.Net.Mail
Public Class frmDoorsPicked
    Dim T As Integer
    Private lvwColumnSorter1 As ListViewColumnSorter
    Public Shared CompleteDoorIssue As Boolean
    Dim MasterNum As String

    Private Sub frmDoorsPicked_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            lvwColumnSorter1 = New ListViewColumnSorter
            lvDoorsPicked.ListViewItemSorter = lvwColumnSorter1

            refreshList()
            refreshToPick()

            KPGeneral.SetDefaultGridSettings(ugToPick)
            KPGeneral.SetDefaultGridSettings(ugDoorsNeeded)

            ShowPerformanceStatsToolStripMenuItem.Visible = KPGeneral.User.UserProfile("ShopEmployeePerformanceTracker")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtBarcode_Enter(ByVal o As [Object], ByVal e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        Try
            lblDate.Text = Now.ToLongDateString
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                e.Handled = True
                If Trim(txtBarcode.Text) = Nothing Then
                    lblMessage.Text = Nothing
                    Exit Sub
                End If

                Dim ds As DataSet
                ds = KPGeneral.WebRef_Local.spKP_LotInfoByFK(Trim(txtBarcode.Text))

                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0)("CancelOrder") = True Then
                        lblMessage.Text = "Order Cancelled!"
                        txtBarcode.Text = Nothing
                        txtBarcode.Focus()
                        Exit Sub
                    End If
                    lblMessage.Text = Nothing

                    Dim IBox As String
                    Dim DoorEmployee As Integer
                    IBox = InputBox("Please enter the 'Door Picked User ID' of the person who completed this order.", KPGeneral.ProgramName, "")
                    If IsNumeric(IBox) Then
                        DoorEmployee = CType(IBox, Integer)
                    Else
                        MsgBox("That user ID is not valid.  Please enter a correct user ID", MsgBoxStyle.OkOnly, "KPFactory")
                        txtBarcode.Text = vbNullString
                        txtBarcode.Focus()
                        Exit Sub
                    End If


                    'Dim Bin As String
                    'Bin = InputBox("Please enter the Bin ID for this order", KPGeneral.ProgramName, "")

                    'If Bin.Length > 0 Then
                    '    Dim FString As String
                    '    Dim substrings() As String = Bin.Split("+")
                    '    Dim x As Integer
                    '    For x = 0 To substrings.Length - 1
                    '        If x = 0 Then
                    '            FString = substrings(x).PadLeft(3, "0")
                    '        Else
                    '            FString = FString + "+" + substrings(x).PadLeft(3, "0")
                    '        End If
                    '    Next
                    '    Bin = FString
                    '    'refreshList()
                    'Else
                    '    'Dim mResult As MsgBoxResult
                    '    'mResult = MsgBox("You have entered nothing for the Bin Location.  Click YES to make the bin location blank, click NO to not change anything.", MsgBoxStyle.YesNo, KPGeneral.ProgramName)
                    '    'If mResult = MsgBoxResult.Yes Then
                    '    '    KPGeneral.WebRef_Local.spKPFactory_DoorPicked_UpdateBinLocation(lvDoorsPicked.SelectedItems(0).SubItems(12).Text, Bin)
                    '    '    refreshList()
                    '    'End If
                    'End If

                    If IsDBNull(ds.Tables(0).Rows(0)("OrderStatus")) = False Then
                        If Trim(ds.Tables(0).Rows(0)("OrderStatus")) = "Pending" Then
                            lblMessage.Text = ds.Tables(0).Rows(0)("Masternum") & "Order Pending!"
                            MessageBox.Show("Please hold the last order you scanned. Please Contact your supervisor/manager to resolve the PENDING status of the last Order.")
                        End If
                    End If

                    Dim PGroupSet As Boolean = False

                    If IsDBNull(ds.Tables(0).Rows(0)("isDealer")) = False Then
                        If ds.Tables(0).Rows(0)("isDealer") = False Then
                            If ds.Tables(0).Rows(0)("COMPANY") <> "Frendel Kitchen & Bath Design Studio Inc." Then
                                PGroupSet = True
                            End If
                        End If
                    End If

                    If KPGeneral.WebRef_Local.spKPFactory_DoorPicked(Now(), Trim(txtBarcode.Text), ds.Tables(0).Rows(0)("CSID"), KPGeneral.User.UserProfile("UserLoginName"), DoorEmployee, 0) = False Then
                        lblMessage.Text = "Order Already Scanned!"
                    Else
                        frmDoorBoxUpdate.CSID = ds.Tables(0).Rows(0)("CSID")
                        frmDoorBoxUpdate.FromHinge = False
                        frmDoorBoxUpdate.ShowDialog()
                        'SetBinLocation(Bin)
                        If PGroupSet = True Then
                            'SetProductionGroup(ds.Tables(0).Rows(0)("CSID"))
                        End If

                        Dim dsDummyDoors As New DataSet
                        dsDummyDoors = KPGeneral.WebRef_Local.usp_GetDummyDoorLabelsToPrintByCSID(ds.Tables(0).Rows(0)("CSID"))

                        Dim x As Integer
                        For x = 0 To dsDummyDoors.Tables(0).Rows.Count - 1
                            KPGeneral.PrintZebraCabinetLabelByLabelNoForWrapping4x6(dsDummyDoors.Tables(0).Rows(x)("LabelNo"), dsDummyDoors.Tables(0).Rows(x)("CSID"), "frmDoorsPicked", "txtBarcode Keypress", False)

                            KPGeneral.WebRef_Local.usp_UpdatePantryLabelsPrintDate_DummyDoors(dsDummyDoors.Tables(0).Rows(x)("LabelNo"))
                        Next

                        DefectDoors(ds.Tables(0).Rows(0)("CSID"))
                        'sendEmail(ds)
                        refreshList()
                    End If
                Else
                    lblMessage.Text = "Input is not a VALID FK-NUMBER"
                End If
                txtBarcode.Text = vbNullString
                txtBarcode.Focus()
            End If

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub SetBinLocation(ByVal Bin As String)
        If Bin.Length > 0 Then
            Dim FString As String
            Dim substrings() As String = Bin.Split("+")
            Dim x As Integer
            For x = 0 To substrings.Length - 1
                KPGeneral.WebRef_Local.usp_UpdateDoorBoxLocation(substrings(x).PadLeft(3, "0"), "2", KPGeneral.User.UserProfile("UserLoginName"))
                'If x = 0 Then
                '    FString = substrings(x).PadLeft(3, "0")
                'Else
                '    FString = FString + "+" + substrings(x).PadLeft(3, "0")
                'End If
            Next
        End If

    End Sub
    Private Sub SetProductionGroup(ByVal CSID As Integer)
        Dim PGroup As String = "x116"
        'Dim ds As New DataSet
        'ds = KPGeneral.WebRef_Local.spAPP_getCSIDByMasterNo_CMP(Trim(txtBarcode.Text))
        'If ds.Tables(0).Rows.Count > 0 Then
        'Dim csid As Integer
        'csid = ds.Tables(0).Rows(0)("CSID")
        KPGeneral.WebRef_Local.usp_UpdateProductionGroup(csid, PGroup)
        KPGeneral.WebRef_Local.usp_InsertProductionGroupHistory(PGroup, CSID, KPGeneral.User.UserProfile("UserLoginName"))
        Dim OldNum As String
        OldNum = PGroup
        Dim ds1 As New DataSet
        ds1 = KPGeneral.WebRef_Local.usp_GetProductionGroups()
        'ucGroupNum.DataSource = ds1
        'ucGroupNum.Text = OldNum
        'RefreshGroupInfo()
        'txtBarcode.Text = ""

        Dim DSPGroup As New DataSet

        DSPGroup = KPGeneral.WebRef_Local.usp_getInfoByProductionGroup(PGroup)
        Dim x As Integer
        For x = 0 To DSPGroup.Tables(0).Rows.Count - 1
            If DSPGroup.Tables(0).Rows(x)("CSID") = csid Then
                If IsDBNull(DSPGroup.Tables(0).Rows(x)("Priority")) = True Then
                    KPGeneral.WebRef_Local.usp_UpdateProductionGroupPriority(csid, DSPGroup.Tables(0).Rows.Count)
                    Exit For
                End If
            End If
        Next
        'End If
    End Sub
    'Sub sendEmail(ByVal ds As DataSet)
    '    Dim CSID As Integer = IIf(ds.Tables(0).Rows(0)("CSID") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("CSID"))
    '    Dim MasterNum As String = IIf(ds.Tables(0).Rows(0)("MASTERNUM") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("MASTERNUM"))
    '    Dim Company As String = IIf(ds.Tables(0).Rows(0)("COMPANY") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("COMPANY"))
    '    Dim Project As String = IIf(ds.Tables(0).Rows(0)("PROJECT") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("PROJECT"))
    '    Dim Lot As String = IIf(ds.Tables(0).Rows(0)("LOT") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("LOT"))
    '    Dim dsWatchList As DataSet = KPGeneral.WebRef_Local.usp_GetWatchList_byCSID(CSID)

    '    For i As Integer = 0 To dsWatchList.Tables(0).Rows.Count - 1
    '        Dim UserEmail As String = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("UserEmail")), String.Empty, dsWatchList.Tables(0).Rows(i)("UserEmail"))

    '        If UserEmail.ToLower.Contains("gregd") Or UserEmail.ToLower.Contains("kristinad") Then
    '            UserEmail = "scheduling@frendel.com"
    '        End If

    '        Dim Notify As Boolean = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("NotifyDoorsPicked")), String.Empty, dsWatchList.Tables(0).Rows(i)("NotifyDoorsPicked"))
    '        'Dim CSID_IN_WatchList As Integer = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("CSID")), String.Empty, dsWatchList.Tables(0).Rows(i)("CSID"))

    '        If Notify = True Then
    '            Dim value As AttachmentCollection
    '            Dim Message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("reports@frendel.com", UserEmail)
    '            Message.IsBodyHtml = True
    '            'Message.CC.Add([global].UserProfile.Tables(0).Rows(0)("UserID") & "@frendel.com")
    '            'Message.Bcc.Add("kevinl@frendel.com")
    '            Message.Subject = "Order# " & MasterNum & " - " & Company & " - " & Project & " - " & Lot & " - " & "Doors picked, Date: " & Now.ToString
    '            Message.Body = "Order#: " & MasterNum & " <br /> " _
    '                         & "Company: " & Company & " <br /> " _
    '                         & "Project: " & Project & " <br /> " _
    '                         & "Lot: " & Lot & " <br /> " _
    '                         & "has been picked"
    '            value = Message.Attachments

    '            Try
    '                Dim SmtpNewClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()
    '                SmtpNewClient.Host = "mail.frendel.com"
    '                SmtpNewClient.Send(Message)
    '            Catch ehttp As System.Net.WebException
    '                Console.WriteLine("0", ehttp.Message)
    '                Console.WriteLine("Here is the full error message")
    '                Console.Write("0", ehttp.ToString())
    '            End Try
    '            Message.Attachments.Dispose()
    '            value.Dispose()
    '        End If
    '    Next

    'End Sub
    Private Sub DefectDoors(ByVal CSID As Integer)
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetProductionOpenDoorsDef(CSID)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1
                frmMissingDoorPrompt.Status = ds.Tables(0).Rows(x)("OrderReason")
                frmMissingDoorPrompt.MasterNum = ds.Tables(0).Rows(x)("Masternum")
                frmMissingDoorPrompt.Style = ds.Tables(0).Rows(x)("style")
                frmMissingDoorPrompt.Colour = ds.Tables(0).Rows(x)("colour")
                frmMissingDoorPrompt.FormLocation = "Picked"
                frmMissingDoorPrompt.DoorHeight = ds.Tables(0).Rows(x)("Height")
                frmMissingDoorPrompt.DoorWidth = ds.Tables(0).Rows(x)("Width")
                frmMissingDoorPrompt.TotalDef = ds.Tables(0).Rows.Count
                frmMissingDoorPrompt.CurrentDef = x + 1

                CompleteDoorIssue = False

                frmMissingDoorPrompt.ShowDialog()

                If CompleteDoorIssue = True Then
                    KPGeneral.WebRef_Local.usp_UpdateProductionDefClosedDate(ds.Tables(0).Rows(x)("KeyNo"), KPGeneral.User.UserProfile("UserLoginName"))
                End If

            Next

        End If
    End Sub

    Private Sub refreshList()
        Try
            txtDoorCount.Text = 0
            Dim ds As New DataSet
            Dim ds1 As New DataSet
            ds = KPGeneral.WebRef_Local.spKPFactory_DoorPicked_TodaysOrders()
            ds1 = KPGeneral.WebRef_Local.spKPFactory_DoorPicked_TodaysOrdersEmployeeCount()

            lvDoorsPicked.Clear()
            With lvDoorsPicked.Columns
                .Add("ORDER", 110, HorizontalAlignment.Left)
                .Add("Company", 180, HorizontalAlignment.Left)
                .Add("Project", 240, HorizontalAlignment.Left)
                .Add("Lot", 130, HorizontalAlignment.Left)
                .Add("Phase", 85, HorizontalAlignment.Left)

                .Add("R", 30, HorizontalAlignment.Center)
                .Add("P", 30, HorizontalAlignment.Center)
                .Add("Bin", 50, HorizontalAlignment.Left)
                .Add("AS", 33, HorizontalAlignment.Center)
                .Add("TOPD", 33, HorizontalAlignment.Center)
                .Add("Scan Time", 90, HorizontalAlignment.Left)
                .Add("DE", 30, HorizontalAlignment.Center)
                .Add("CSID", 0, HorizontalAlignment.Center)
            End With

            lvOrderEmployee.Clear()
            With lvOrderEmployee.Columns
                .Add("Employee", 100, HorizontalAlignment.Left)
                .Add("Total Doors", 100, HorizontalAlignment.Left)
            End With
            With lvOrderEmployee
                Dim z As Integer = 0
                Dim RowNumb As Long = 0
                For z = 0 To ds1.Tables(0).Rows.Count - 1
                    If IsDBNull(ds1.Tables(0).Rows(z)("DoorPickedEmployee")) = False Then
                        .Items.Add(ds1.Tables(0).Rows(z)("DoorPickedEmployee"))
                    Else
                        .Items.Add("0")
                    End If
                    '.Items.Add(ds1.Tables(0).Rows(z)("DoorPickedEmployee"))
                    .Items(z).SubItems.Add(ds1.Tables(0).Rows(z)("TotalDoors"))
                Next
            End With

            With lvDoorsPicked
                Dim i As Integer = 0
                Dim RowNum As Long = 0
                ' Loop through array
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    'Alternate Row Colour
                    .Items.Add(Trim(Convert.ToString(ds.Tables(0).Rows(i)("Master_NO")))) '1
                    'If isOdd(RowNum) = True Then
                    '    .Items.Item(i).BackColor = Color.LightCyan
                    '    .Items.Item(i).ForeColor = Color.Black
                    'Else
                    '    .Items.Item(i).BackColor = Color.White
                    '    .Items.Item(i).ForeColor = Color.Black
                    'End If

                    Dim z As String
                    If IsDBNull(ds.Tables(0).Rows(i)("PH")) Then
                        z = ""
                    Else
                        z = ds.Tables(0).Rows(i)("PH")
                    End If
                    .Items(i).UseItemStyleForSubItems = False
                    .Items(i).SubItems.Add(Convert.ToString(ds.Tables(0).Rows(i)("Company"))) '2
                    .Items(i).SubItems.Add(Convert.ToString(ds.Tables(0).Rows(i)("Project"))) '2
                    .Items(i).SubItems.Add(Convert.ToString(ds.Tables(0).Rows(i)("Lot"))) '2
                    .Items(i).SubItems.Add(Convert.ToString(z)) '2

                    If IsDBNull(ds.Tables(0).Rows(i)("Raw")) Then
                        .Items(i).SubItems.Add("", Color.Black, Color.Green, Font)
                    Else
                        .Items(i).SubItems.Add("", Color.Black, Color.Red, Font)
                    End If
                    If IsDBNull(ds.Tables(0).Rows(i)("Painted")) Then
                        .Items(i).SubItems.Add("", Color.Black, Color.Green, Font)
                    Else
                        .Items(i).SubItems.Add("", Color.Black, Color.Red, Font)
                    End If



                    .Items(i).SubItems.Add(ds.Tables(0).Rows(i)("DoorsBin"))

                    If IsDBNull(ds.Tables(0).Rows(i)("AssemblyStartDate")) = False Then
                        .Items(i).SubItems.Add("", Color.Black, Color.Green, Font)
                    Else
                        .Items(i).SubItems.Add("", Color.Black, Color.Red, Font)
                    End If
                    'If IsDBNull(ds.Tables(0).Rows(i)("BoxAssemblyStartDate")) = False Then
                    '    .Items(i).SubItems.Add("", Color.Black, Color.Green, Font)
                    'Else
                    '    .Items(i).SubItems.Add("", Color.Black, Color.Red, Font)
                    'End If
                    .Items(i).SubItems.Add(Convert.ToString(ds.Tables(0).Rows(i)("ProdDef")))
                    .Items(i).SubItems.Add(Convert.ToString(Strings.Mid(ds.Tables(0).Rows(i)("SCAN_TIME").ToString, InStr(ds.Tables(0).Rows(i)("SCAN_TIME").ToString, " ") + 1).Trim)) '2
                    If IsDBNull(ds.Tables(0).Rows(i)("DoorPickedEmployee")) = False Then
                        .Items(i).SubItems.Add(Convert.ToString(ds.Tables(0).Rows(i)("DoorPickedEmployee")))
                    Else
                        .Items(i).SubItems.Add("0")
                    End If
                    .Items(i).SubItems.Add(Convert.ToString(ds.Tables(0).Rows(i)("CSID")))

                    Dim y As Integer
                    If ds.Tables(0).Rows(i)("ProdDef") > 0 Then
                        For y = 0 To .Items(i).SubItems.Count - 1
                            If y <> 5 And y <> 6 And y <> 8 Then
                                .Items(i).SubItems(y).BackColor = Color.LightSalmon
                            End If
                        Next
                    End If

                    RowNum = RowNum + 1

                Next
                If IsDBNull(ds.Tables(0).Compute("SUM(TotalDoors)", "")) Then
                    txtDoorCount.Text = 0
                Else
                    txtDoorCount.Text = ds.Tables(0).Compute("SUM(TotalDoors)", "")
                End If
            End With
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub refreshToPick()
        Dim ds2 As New DataSet
        ds2 = KPGeneral.WebRef_Local.usp_PickSnapShot()

        ugToPick.DataSource = ds2
        Dim x As Integer
        For x = 0 To ugToPick.Rows.Count - 1
            If IsDBNull(ugToPick.Rows(x).Cells("HingeDate").Value) = False Then
                ugToPick.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.Green
                ugToPick.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.Green
            Else
                ugToPick.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.Red
            End If
            If IsDBNull(ugToPick.Rows(x).Cells("DoorsPickedDate").Value) = False Then
                ugToPick.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.Green
                ugToPick.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.Green
            Else
                ugToPick.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.Red
            End If
        Next
        If ugToPick.DisplayLayout.Bands(0).Columns.Count > 0 Then
            ugToPick.DisplayLayout.Bands(0).Columns("TotalCabinetsRemaining").Header.Caption = "TR"
            ugToPick.DisplayLayout.Bands(0).Columns("TotalCabinetsRemaining").Width = 40
            ugToPick.DisplayLayout.Bands(0).Columns("HingeDate").Width = 30
            ugToPick.DisplayLayout.Bands(0).Columns("DoorsPickedDate").Width = 30
            ugToPick.DisplayLayout.Bands(0).Columns("Company").Width = 250
            ugToPick.DisplayLayout.Bands(0).Columns("Project").Width = 250
            ugToPick.DisplayLayout.Bands(0).Columns("TotalCabinets").Header.Caption = "TC"
            ugToPick.DisplayLayout.Bands(0).Columns("HingeDate").Header.Caption = "H"
            ugToPick.DisplayLayout.Bands(0).Columns("DoorsPickedDate").Header.Caption = "P"
            ugToPick.DisplayLayout.Bands(0).Columns("AssignedLine").Header.Caption = "LN"
            ugToPick.DisplayLayout.Bands(0).Columns("AssignedLine").Width = 35
            ugToPick.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
            ugToPick.DisplayLayout.Bands(0).Columns("Masternum").Hidden = False
            ugToPick.DisplayLayout.Bands(0).Columns("TotalPercent").Hidden = True
        End If
        ugToPick.ActiveRow = Nothing
    End Sub

    Private Sub lvDoorsPicked_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDoorsPicked.ColumnClick
        Try
            ' Determine if the clicked column is already the column that is
            ' being sorted.
            If (e.Column = lvwColumnSorter1.SortColumn) Then
                ' Reverse the current sort direction for this column.
                If (lvwColumnSorter1.Order = System.Windows.Forms.SortOrder.Ascending) Then
                    lvwColumnSorter1.Order = System.Windows.Forms.SortOrder.Descending
                Else
                    lvwColumnSorter1.Order = System.Windows.Forms.SortOrder.Ascending
                End If
            Else
                ' Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter1.SortColumn = e.Column
                lvwColumnSorter1.Order = System.Windows.Forms.SortOrder.Ascending
            End If

            ' Perform the sort with these new sort options.
            lvDoorsPicked.Sort()

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            T = T + 1
            If T > 300 Then
                refreshToPick()
                T = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Timer1.Stop()
        End Try

    End Sub

    Private Sub KitchenTrackerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KitchenTrackerToolStripMenuItem.Click
        If ugToPick.ActiveRow Is Nothing Then
            Return
        End If

        If ugToPick.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByCSID(ugToPick.ActiveRow.Cells("CSID").Text)
        Else
            MsgBox("Please select a row to view", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub

    Private Sub ProductionDefsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionDefsToolStripMenuItem.Click
        If lvDoorsPicked.SelectedItems.Count > 0 Then
            If lvDoorsPicked.SelectedItems(0).SubItems(11).Text.Length > 0 Then
                frmProductionDefs.CSID = lvDoorsPicked.SelectedItems(0).SubItems(12).Text
                frmProductionDefs.MNum = lvDoorsPicked.SelectedItems(0).SubItems(0).Text
                frmProductionDefs.Project = lvDoorsPicked.SelectedItems(0).SubItems(2).Text
                frmProductionDefs.Company = lvDoorsPicked.SelectedItems(0).SubItems(1).Text
                frmProductionDefs.Lot = lvDoorsPicked.SelectedItems(0).SubItems(3).Text
                frmProductionDefs.ViewOnly = False
                frmProductionDefs.ShowDialog()
            Else
                MsgBox("This order doesn't have a CSID.  You can not view this order.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If
    End Sub

    Private Sub SpecifyBinLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpecifyBinLocationToolStripMenuItem.Click
        If lvDoorsPicked.SelectedItems.Count > 0 Then
            If lvDoorsPicked.SelectedItems(0).SubItems(12).Text.Length > 0 Then

                frmDoorBoxUpdate.CSID = lvDoorsPicked.SelectedItems(0).SubItems(12).Text
                frmDoorBoxUpdate.FromHinge = False
                frmDoorBoxUpdate.ShowDialog()

                'Dim Bin As String
                'Bin = InputBox("Please enter the Bin ID for this order", KPGeneral.ProgramName, "")

                'If Bin.Length > 0 Then
                '    Dim FString As String
                '    Dim substrings() As String = Bin.Split("+")
                '    Dim x As Integer
                '    For x = 0 To substrings.Length - 1
                '        If x = 0 Then
                '            FString = substrings(x).PadLeft(3, "0")
                '        Else
                '            FString = FString + "+" + substrings(x).PadLeft(3, "0")
                '        End If
                '    Next
                '    KPGeneral.WebRef_Local.spKPFactory_DoorPicked_UpdateBinLocation(lvDoorsPicked.SelectedItems(0).SubItems(12).Text, FString)
                '    refreshList()
                'Else
                '    Dim mResult As MsgBoxResult
                '    mResult = MsgBox("You have entered nothing for the Bin Location.  Click YES to make the bin location blank, click NO to not change anything.", MsgBoxStyle.YesNo, KPGeneral.ProgramName)
                '    If mResult = MsgBoxResult.Yes Then
                '        KPGeneral.WebRef_Local.spKPFactory_DoorPicked_UpdateBinLocation(lvDoorsPicked.SelectedItems(0).SubItems(12).Text, Bin)
                '        refreshList()
                '    End If
                'End If
            Else
                MsgBox("This order doesn't have a CSID.  You can not change the bin location", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        Try
            If TabControl1.SelectedIndex = 0 Then
                refreshList()
                refreshToPick()
            Else
                RefreshDoorsNeeded()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub RefreshDoorsNeeded()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_SiteRequest_Batch_DoorsPicked

        ugDoorsNeeded.DataSource = ds

        ugDoorsNeeded.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ugDoorsNeeded.DisplayLayout.Bands(0).Columns("WeekColour").Hidden = True

        Dim x As Integer
        For x = 0 To ugDoorsNeeded.Rows.Count - 1
            If IsDBNull(ugDoorsNeeded.Rows(x).Cells("WeekColour").Value) = False Then
                If ugDoorsNeeded.Rows(x).Cells("WeekColour").Text.Length > 0 Then
                    ugDoorsNeeded.Rows(x).Appearance.BackColor = Color.White

                    Select Case ugDoorsNeeded.Rows(x).Cells("WeekColour").Text

                        Case "Orange"
                            ugDoorsNeeded.Rows(x).Appearance.BackColor = Color.FromArgb(252, 212, 36)
                        Case "Green"
                            ugDoorsNeeded.Rows(x).Appearance.BackColor = Color.FromArgb(145, 203, 130)
                        Case "Pink"
                            ugDoorsNeeded.Rows(x).Appearance.BackColor = Color.FromArgb(249, 183, 181)
                        Case "Blue"
                            ugDoorsNeeded.Rows(x).Appearance.BackColor = Color.FromArgb(137, 186, 191)
                        Case "Purple"
                            ugDoorsNeeded.Rows(x).Appearance.BackColor = Color.FromArgb(168, 152, 192)

                    End Select
                Else
                    ugDoorsNeeded.Rows(x).Appearance.BackColor = Color.White
                End If
            Else
                ugDoorsNeeded.Rows(x).Appearance.BackColor = Color.White
            End If
        Next
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If ugDoorsNeeded.ActiveRow Is Nothing Then
            Return
        End If

        If ugDoorsNeeded.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByCSID(ugDoorsNeeded.ActiveRow.Cells("CSID").Text)
        Else
            MsgBox("Please select a row to view", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub ViewDoorStatusToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ViewDoorStatusToolStripMenuItem.Click
        If ugDoorsNeeded.ActiveRow Is Nothing Then
            Return
        End If

        If ugDoorsNeeded.ActiveRow.Index > -1 Then
            KPGeneral.ViewDoorStatusByCSID(ugDoorsNeeded.ActiveRow.Cells("CSID").Text)
        Else
            MsgBox("Please select a row to view", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub UltraPrintPreviewDialog1_Printing(sender As Object, e As Infragistics.Win.Printing.PrintingEventArgs) Handles UltraPrintPreviewDialog1.Printing
        Dim DResult As DialogResult
        DResult = PrintDialog1.ShowDialog

        If DResult = Windows.Forms.DialogResult.Cancel Then
            e.Cancel = True
        Else
            UltraGridPrintDocument1.PrinterSettings.PrinterName = PrintDialog1.PrinterSettings.PrinterName
        End If
        'e.Cancel = PrintDialog1.ShowDialog()

    End Sub
    Private Sub ugDoorsNeeded_InitializePrint(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs) Handles ugDoorsNeeded.InitializePrint
        e.DefaultLogicalPageLayoutInfo.PageHeader = "Doors Needed"

        e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center

        e.DefaultLogicalPageLayoutInfo.PageFooter = "Printed on " & Now & vbTab & "Page <#> of <##>"
        e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 20
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    End Sub
    Private Sub ugDoorsNeeded_InitializePrintPreview(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelablePrintPreviewEventArgs) Handles ugDoorsNeeded.InitializePrintPreview
        e.DefaultLogicalPageLayoutInfo.PageHeader = "Doors Needed"

        e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center

        e.DefaultLogicalPageLayoutInfo.PageFooter = "Printed on " & Now & vbTab & "Page <#> of <##>"
        e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 20
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        If ugDoorsNeeded.Selected.Rows.Count > 0 Then
            'StyleRevisedOrdersPrint()
            'StyleGridPrintSelected()
            UltraGridPrintDocument1.Grid = ugDoorsNeeded
            'UltraGridPrintDocument1.DefaultPageSettings.PaperSize.PaperName = "Legal"
            UltraGridPrintDocument1.DefaultPageSettings.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Legal

            UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 25
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 25
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 25
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 25

            Dim c_pdSetup As New System.Drawing.Printing.PrintDocument
            Dim pSize As New System.Drawing.Printing.PaperSize

            'pSize.Width = 850
            'pSize.Height = 1400
            pSize.PaperName = "Legal"
            pSize.RawKind = System.Drawing.Printing.PaperKind.Legal

            c_pdSetup.DefaultPageSettings.Landscape = True
            c_pdSetup.DefaultPageSettings.Margins.Bottom = 25
            c_pdSetup.DefaultPageSettings.Margins.Left = 25
            c_pdSetup.DefaultPageSettings.Margins.Right = 25
            c_pdSetup.DefaultPageSettings.Margins.Top = 25
            'c_pdSetup.DefaultPageSettings.PaperSize = pSize
            Dim x As Integer
            For x = 0 To c_pdSetup.DefaultPageSettings.PrinterSettings.PaperSizes.Count - 1
                If c_pdSetup.DefaultPageSettings.PrinterSettings.PaperSizes.Item(x).Kind = Printing.PaperKind.Legal Then
                    c_pdSetup.DefaultPageSettings.PaperSize = c_pdSetup.DefaultPageSettings.PrinterSettings.PaperSizes.Item(x)
                    Exit For
                End If
            Next

            For x = 0 To UltraGridPrintDocument1.PrinterSettings.PaperSizes.Count - 1
                If UltraGridPrintDocument1.PrinterSettings.PaperSizes.Item(x).Kind = Printing.PaperKind.Legal Then
                    UltraGridPrintDocument1.DefaultPageSettings.PaperSize = UltraGridPrintDocument1.PrinterSettings.PaperSizes.Item(x)
                    Exit For
                End If
            Next
            UltraPrintPreviewDialog1.Document = UltraGridPrintDocument1
            UltraPrintPreviewDialog1.ShowDialog()
            'ugReady.PrintPreview(ugReady.DisplayLayout, c_pdSetup)

            'ugStyleVsColour.Print(ugStyleVsColour.DisplayLayout, c_pdSetup)
            'StyleGrid()

            Me.Cursor = Cursors.Default
        Else
            MsgBox("Please select some rows to print.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub

    Private Sub ShowPerformanceStatsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowPerformanceStatsToolStripMenuItem.Click
        If lvOrderEmployee.SelectedItems.Count > 0 Then
            If lvOrderEmployee.SelectedItems(0).SubItems(0).Text.Length > 0 Then
                Dim PerformanceTracker As New frmEmployeePerformanceTracker
                PerformanceTracker.EmployeeInfo = lvOrderEmployee.SelectedItems(0).SubItems(0).Text
                PerformanceTracker.FromLocation = "Doors Picked"
                PerformanceTracker.ShowDialog()
            End If
        End If
    End Sub
End Class