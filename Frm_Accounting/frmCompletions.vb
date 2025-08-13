Imports Infragistics.Win.UltraWinTabControl

Public Class frmCompletions
    Public Shared CompletionNote As String
    Public Shared CompletionRooms As String
    Private Sub frmCompletions_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshOutstandingCompletions()
        RefreshReadyCompletions()

        KPGeneral.SetDefaultGridSettings(ugCompletionRequests)
        KPGeneral.SetDefaultGridSettings(ugOutstandingCompletions)
        KPGeneral.SetDefaultGridSettings(ugRequestDetails)
        KPGeneral.SetDefaultGridSettings(ugSentRequestDetails)
        KPGeneral.SetDefaultGridSettings(ugSentRequestLog)
        KPGeneral.SetDefaultGridSettings(ugSentRequests)
    End Sub
    Private Sub RefreshOutstandingCompletions()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetOutstandingCompletions

        ugOutstandingCompletions.DataSource = ds

        ugOutstandingCompletions.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ugOutstandingCompletions.DisplayLayout.Bands(0).Columns("ProjNum").Hidden = True
        ugOutstandingCompletions.DisplayLayout.Bands(0).Columns("Company").Width = 200
        ugOutstandingCompletions.DisplayLayout.Bands(0).Columns("Project").Width = 200
        ugOutstandingCompletions.DisplayLayout.Bands(0).Columns("Lot").Width = 200
        ugOutstandingCompletions.DisplayLayout.Bands(0).Columns("CompletionRequestID").Header.Caption = "CRID"
        ugOutstandingCompletions.DisplayLayout.Bands(0).Columns("CompletionRequestID").Width = 75

        Dim x As Integer
        For x = 0 To ugOutstandingCompletions.Rows.Count - 1
            If IsDBNull(ugOutstandingCompletions.Rows(x).Cells("CompletionRequestID").Value) = False Then
                ugOutstandingCompletions.Rows(x).Appearance.BackColor = Color.YellowGreen
            Else
                ugOutstandingCompletions.Rows(x).Appearance.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub RefreshReadyCompletions()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetCompletionsReadyToBeSent

        ugCompletionRequests.DataSource = ds

        ugCompletionRequests.DisplayLayout.Bands(0).Columns("ProjNum").Hidden = True
        ugCompletionRequests.DisplayLayout.Bands(0).Columns("CompletionRequestID").Header.Caption = "CRID"
        ugCompletionRequests.DisplayLayout.Bands(0).Columns("Company").Width = 200
        ugCompletionRequests.DisplayLayout.Bands(0).Columns("Project").Width = 200
    End Sub
    Private Sub AddToCompletionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToCompletionToolStripMenuItem.Click
        AddLot()

    End Sub
    Private Sub RefreshCompletionRequestDetail()
        If ugCompletionRequests.ActiveRow.Index > -1 Then
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.usp_GetCompletionsRequestDetail(ugCompletionRequests.ActiveRow.Cells("CompletionRequestID").Text)

            ugRequestDetails.DataSource = ds

            ugRequestDetails.DisplayLayout.Bands(0).Columns("CompletionRequestOrdersID").Hidden = True
            ugRequestDetails.DisplayLayout.Bands(0).Columns("CompletionRequestID").Hidden = True
            ugRequestDetails.DisplayLayout.Bands(0).Columns("CSID").Hidden = True

            ugRequestDetails.DisplayLayout.Bands(0).Columns("Lot").Width = 200
        End If

    End Sub
    Private Sub ugCompletionRequests_AfterRowActivate(sender As Object, e As EventArgs) Handles ugCompletionRequests.AfterRowActivate
        RefreshCompletionRequestDetail()
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshOutstandingCompletions()
    End Sub
    Private Sub RefreshToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem1.Click
        Dim CompletionRequestID As Integer = 0

        If ugCompletionRequests.ActiveRow.Index > -1 Then
            CompletionRequestID = ugCompletionRequests.ActiveRow.Cells("CompletionRequestID").Text
        End If

        RefreshReadyCompletions()

        If CompletionRequestID > 0 Then
            Dim y As Integer
            For y = 0 To ugCompletionRequests.Rows.Count - 1
                If ugCompletionRequests.Rows(y).Cells("CompletionRequestID").Value = CompletionRequestID Then
                    ugCompletionRequests.Rows(y).Selected = True
                    ugCompletionRequests.Rows(y).Activate()
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub SendRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendRequestToolStripMenuItem.Click
        If ugCompletionRequests.Selected.Rows.Count > 1 Then
            MsgBox("Please select only a single request to send.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        Else
            If ugCompletionRequests.ActiveRow.Index > -1 Then
                frmSendCompletionRequest.CompletionRequestID = ugCompletionRequests.ActiveRow.Cells("CompletionRequestID").Text
                frmSendCompletionRequest.ShowDialog()

                RefreshReadyCompletions()
            Else
                MsgBox("Please select a valid request to send.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If
    End Sub

    Private Sub btnCreateCompletion_Click(sender As Object, e As EventArgs) Handles btnCreateCompletion.Click
        frmCreateCompletion.Builder = ""
        frmCreateCompletion.Project = ""
        frmCreateCompletion.ShowDialog()

        RefreshReadyCompletions()
    End Sub

    Private Sub UltraTabControl1_SelectedTabChanged(sender As Object, e As SelectedTabChangedEventArgs) Handles UltraTabControl1.SelectedTabChanged
        If UltraTabControl1.SelectedTab.Index = 0 Then
            RefreshOutstandingCompletions()
            RefreshReadyCompletions()
        Else
            RefreshSentRequests()
        End If
    End Sub

    Private Sub RefreshSentRequests()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetCompletionsReadyAlreadySent

        ugSentRequests.DataSource = ds

        ugSentRequests.DisplayLayout.Bands(0).Columns("ProjNum").Hidden = True
        ugSentRequests.DisplayLayout.Bands(0).Columns("CompletionRequestID").Header.Caption = "CRID"
        ugSentRequests.DisplayLayout.Bands(0).Columns("Company").Width = 200
        ugSentRequests.DisplayLayout.Bands(0).Columns("Project").Width = 200
    End Sub

    Private Sub ugSentRequests_AfterRowActivate(sender As Object, e As EventArgs) Handles ugSentRequests.AfterRowActivate
        If ugSentRequests.ActiveRow.Index > -1 Then
            RefreshSentDetails()
            RefreshSentLogs()
        End If
    End Sub
    Private Sub RefreshSentDetails()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetCompletionsRequestDetail(ugSentRequests.ActiveRow.Cells("CompletionRequestID").Text)

        ugSentRequestDetails.DataSource = ds

        ugSentRequestDetails.DisplayLayout.Bands(0).Columns("CompletionRequestOrdersID").Hidden = True
        ugSentRequestDetails.DisplayLayout.Bands(0).Columns("CompletionRequestID").Hidden = True
        ugSentRequestDetails.DisplayLayout.Bands(0).Columns("CSID").Hidden = True

        ugSentRequestDetails.DisplayLayout.Bands(0).Columns("Lot").Width = 200
    End Sub
    Private Sub RefreshSentLogs()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetCompletionsRequestLog(ugSentRequests.ActiveRow.Cells("CompletionRequestID").Text)

        ugSentRequestLog.DataSource = ds

        ugSentRequestLog.DisplayLayout.Bands(0).Columns("CompletionRequestLogID").Hidden = True
        ugSentRequestLog.DisplayLayout.Bands(0).Columns("CompletionRequestID").Hidden = True

        ugSentRequestLog.DisplayLayout.Bands(0).Columns("DateRequested").Format = KPGeneral.DateTime12HourFormatString
        ugSentRequestLog.DisplayLayout.Bands(0).Columns("DateRequested").Width = 200
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim CRID As Integer
        If ugSentRequests.ActiveRow.Index > -1 Then
            CRID = ugSentRequests.ActiveRow.Cells("CompletionRequestID").Text

            RefreshSentRequests()

            Dim x As Integer
            For x = 0 To ugSentRequests.Rows.Count - 1
                If ugSentRequests.Rows(x).Cells("CompletionRequestID").Value = CRID Then
                    ugSentRequests.Rows(x).Selected = True
                    ugSentRequests.Rows(x).Activate()

                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If ugSentRequests.Selected.Rows.Count > 1 Then
            MsgBox("Please select only a single request to send.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        Else
            If ugSentRequests.ActiveRow.Index > -1 Then
                Dim CRID As Integer
                CRID = ugSentRequests.ActiveRow.Cells("CompletionRequestID").Text
                frmSendCompletionRequest.CompletionRequestID = CRID
                frmSendCompletionRequest.ShowDialog()

                RefreshSentRequests()

                Dim x As Integer
                For x = 0 To ugSentRequests.Rows.Count - 1
                    If ugSentRequests.Rows(x).Cells("CompletionRequestID").Value = CRID Then
                        ugSentRequests.Rows(x).Selected = True
                        ugSentRequests.Rows(x).Activate()

                        Exit For
                    End If
                Next
            Else
                MsgBox("Please select a valid request to send.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If
    End Sub

    Private Sub AddNoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNoteToolStripMenuItem.Click
        ChangeNote(False, False)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        ChangeNote(False, True)

    End Sub

    Private Sub btnAddLot_Click(sender As Object, e As EventArgs) Handles btnAddLot.Click
        AddLot()
    End Sub

    Private Sub btnRemoveLot_Click(sender As Object, e As EventArgs) Handles btnRemoveLot.Click
        If ugRequestDetails.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugRequestDetails.Selected.Rows.Count - 1
                KPGeneral.WebRef_Local.usp_RemoveCompletionRequestOrders(ugRequestDetails.Selected.Rows(x).Cells("CompletionRequestID").Text, ugRequestDetails.Selected.Rows(x).Cells("CSID").Text)

                Dim y As Integer

                For y = 0 To ugOutstandingCompletions.Rows.Count - 1
                    If ugOutstandingCompletions.Rows(y).Cells("CSID").Text = ugRequestDetails.Selected.Rows(x).Cells("CSID").Text Then
                        ugOutstandingCompletions.Rows(y).Appearance.BackColor = Color.White
                        ugOutstandingCompletions.Rows(y).Cells("CompletionRequestID").Value = DBNull.Value
                    End If
                Next
            Next

            RefreshCompletionRequestDetail()
        Else
            MsgBox("Please select some lots to remove from the request.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub AddLot()
        If ugCompletionRequests.Selected.Rows.Count > 1 Then
            MsgBox("Please select only a single completion request to add the selected orders to.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        Else
            If ugCompletionRequests.ActiveRow.Index > -1 Then
                If ugOutstandingCompletions.Selected.Rows.Count > 0 Then
                    Dim x As Integer

                    Dim CompletionRequestID, OrderCount As Integer
                    CompletionRequestID = ugCompletionRequests.ActiveRow.Cells("CompletionRequestID").Text

                    If IsDBNull(ugCompletionRequests.ActiveRow.Cells("OrderCount").Value) = False Then
                        OrderCount = ugCompletionRequests.ActiveRow.Cells("OrderCount").Value
                    Else
                        OrderCount = 0
                    End If

                    For x = 0 To ugOutstandingCompletions.Selected.Rows.Count - 1


                        If ugOutstandingCompletions.Selected.Rows(x).Cells("ProjNum").Text.Trim = ugCompletionRequests.ActiveRow.Cells("ProjNum").Text.Trim Then
                            KPGeneral.WebRef_Local.usp_AddCompletionRequestOrders(CompletionRequestID, ugOutstandingCompletions.Selected.Rows(x).Cells("CSID").Text)
                            ugOutstandingCompletions.Selected.Rows(x).Appearance.BackColor = Color.YellowGreen
                            ugOutstandingCompletions.Selected.Rows(x).Cells("CompletionRequestID").Value = CompletionRequestID
                            OrderCount = OrderCount + 1
                        End If


                    Next

                    RefreshReadyCompletions()

                    Dim y As Integer
                    For y = 0 To ugCompletionRequests.Rows.Count - 1
                        If ugCompletionRequests.Rows(y).Cells("CompletionRequestID").Value = CompletionRequestID Then
                            ugCompletionRequests.Rows(y).Selected = True
                            ugCompletionRequests.Rows(y).Activate()
                            Exit For
                        End If
                    Next

                Else
                    MsgBox("Please select some orders to add to the selected completion request.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                End If
            Else
                MsgBox("Please select a valid completion request to add the selected orders to.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If
    End Sub

    Private Sub ChooseRoomsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChooseRoomsToolStripMenuItem.Click
        AddRooms(False, False)


    End Sub
    Private Sub ClearNoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearNoteToolStripMenuItem.Click
        ChangeNote(True, False)
    End Sub
    Private Sub ChangeNote(ByVal isClear As Boolean, ByVal AlreadySent As Boolean)
        Dim PreviousNote As String = ""

        Dim Match As Boolean = False

        If AlreadySent = False Then
            If ugRequestDetails.Selected.Rows.Count > 1 Then
                MsgBox("Please select only a single order to add a note to.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Else
                If ugRequestDetails.ActiveRow.Index > -1 Then
                    Match = True
                Else
                    MsgBox("Please select a valid order to add a note to.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                End If
            End If
        Else
            If ugSentRequestDetails.Selected.Rows.Count > 1 Then
                MsgBox("Please select only a single order to add a note to.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Else
                If ugSentRequestDetails.ActiveRow.Index > -1 Then
                    Match = True
                Else
                    MsgBox("Please select a valid order to add a note to.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                End If
            End If
        End If

        If Match = True Then
            If AlreadySent = False Then
                PreviousNote = ugRequestDetails.ActiveRow.Cells("OrderNote").Text
            Else
                PreviousNote = ugSentRequestDetails.ActiveRow.Cells("OrderNote").Text
            End If



            If isClear = False Then
                frmCompletionRequestNote.CompletionNote = PreviousNote
                If frmCompletionRequestNote.ShowDialog() = DialogResult.OK Then

                    If CompletionNote.Length > 0 Then
                        If AlreadySent = False Then
                            KPGeneral.WebRef_Local.usp_UpdateCompletionRequestOrderNoteByCompletionRequestOrdersID(ugRequestDetails.ActiveRow.Cells("CompletionRequestOrdersID").Text, CompletionNote)
                            ugRequestDetails.ActiveRow.Cells("OrderNote").Value = CompletionNote
                        Else
                            KPGeneral.WebRef_Local.usp_UpdateCompletionRequestOrderNoteByCompletionRequestOrdersID(ugSentRequestDetails.ActiveRow.Cells("CompletionRequestOrdersID").Text, CompletionNote)
                            ugSentRequestDetails.ActiveRow.Cells("OrderNote").Value = CompletionNote
                        End If

                    End If
                End If

            Else
                    If AlreadySent = False Then
                        KPGeneral.WebRef_Local.usp_UpdateCompletionRequestOrderNoteByCompletionRequestOrdersID(ugRequestDetails.ActiveRow.Cells("CompletionRequestOrdersID").Text, "")
                        ugRequestDetails.ActiveRow.Cells("OrderNote").Value = ""
                    Else
                        KPGeneral.WebRef_Local.usp_UpdateCompletionRequestOrderNoteByCompletionRequestOrdersID(ugSentRequestDetails.ActiveRow.Cells("CompletionRequestOrdersID").Text, "")
                        ugSentRequestDetails.ActiveRow.Cells("OrderNote").Value = ""
                    End If
                End If

            End If


    End Sub
    Private Sub AddRooms(ByVal isClear As Boolean, ByVal AlreadySent As Boolean)
        Dim Match As Boolean = False

        If AlreadySent = False Then
            If ugRequestDetails.Selected.Rows.Count > 1 Then
                MsgBox("Please select only a single order to add rooms to.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Else
                If ugRequestDetails.ActiveRow.Index > -1 Then
                    Match = True
                Else
                    MsgBox("Please select a valid order to add rooms to.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                End If
            End If
        Else
            If ugSentRequestDetails.Selected.Rows.Count > 1 Then
                MsgBox("Please select only a single order to add rooms to.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Else
                If ugSentRequestDetails.ActiveRow.Index > -1 Then
                    Match = True
                Else
                    MsgBox("Please select a valid order to add rooms to.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                End If
            End If
        End If

        If Match = True Then
            If isClear = False Then
                Dim PreviousCSID As Integer

                If AlreadySent = False Then
                    PreviousCSID = ugRequestDetails.ActiveRow.Cells("CSID").Text
                Else
                    PreviousCSID = ugSentRequestDetails.ActiveRow.Cells("CSID").Text
                End If

                CompletionRooms = ""
                    frmRoomChange.FormLocation = "Completions"
                frmRoomChange.CSID = PreviousCSID


                If frmRoomChange.ShowDialog = DialogResult.OK Then
                        If CompletionRooms.Length > 0 Then
                            If AlreadySent = False Then
                                KPGeneral.WebRef_Local.usp_UpdateCompletionRequestOrdeRoomsByCompletionRequestOrdersID(ugRequestDetails.ActiveRow.Cells("CompletionRequestOrdersID").Text, CompletionRooms)
                                ugRequestDetails.ActiveRow.Cells("OrderRooms").Value = CompletionRooms
                            Else
                                KPGeneral.WebRef_Local.usp_UpdateCompletionRequestOrdeRoomsByCompletionRequestOrdersID(ugSentRequestDetails.ActiveRow.Cells("CompletionRequestOrdersID").Text, CompletionRooms)
                                ugSentRequestDetails.ActiveRow.Cells("OrderRooms").Value = CompletionRooms
                            End If

                        End If
                    End If

            Else
                If AlreadySent = False Then
                    KPGeneral.WebRef_Local.usp_UpdateCompletionRequestOrdeRoomsByCompletionRequestOrdersID(ugRequestDetails.ActiveRow.Cells("CompletionRequestOrdersID").Text, "")
                    ugRequestDetails.ActiveRow.Cells("OrderRooms").Value = ""
                Else
                    KPGeneral.WebRef_Local.usp_UpdateCompletionRequestOrdeRoomsByCompletionRequestOrdersID(ugSentRequestDetails.ActiveRow.Cells("CompletionRequestOrdersID").Text, "")
                    ugSentRequestDetails.ActiveRow.Cells("OrderRooms").Value = ""
                End If

            End If
        End If
    End Sub
    Private Sub ClearRoomsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearRoomsToolStripMenuItem.Click
        AddRooms(True, False)

    End Sub
    Private Sub ClearNoteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClearNoteToolStripMenuItem1.Click
        ChangeNote(True, True)
    End Sub

    Private Sub AddRoomsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddRoomsToolStripMenuItem.Click
        AddRooms(False, True)
    End Sub

    Private Sub ClearRoomsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClearRoomsToolStripMenuItem1.Click
        AddRooms(True, True)
    End Sub

    Private Sub DeleteRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRequestToolStripMenuItem.Click
        If ugCompletionRequests.Selected.Rows.Count > 0 Then
            If MsgBox("Are you sure you wish to delete the selected requests?", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.Yes Then

                Dim x As Integer
                For x = 0 To ugCompletionRequests.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.usp_DeleteCompletionRequest(ugCompletionRequests.Selected.Rows(x).Cells("CompletionRequestID").Text)
                Next

                RefreshReadyCompletions()
            Else

            End If
        End If
    End Sub

    Private Sub CreateNewCompletionRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateNewCompletionRequestToolStripMenuItem.Click
        If ugOutstandingCompletions.ActiveRow.Index > -1 Then
            If ugOutstandingCompletions.Selected.Rows.Count > 1 Then
                MsgBox("Please only select a single row to create a new completion request.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Else
                frmCreateCompletion.Builder = ugOutstandingCompletions.ActiveRow.Cells("Company").Text
                frmCreateCompletion.Project = ugOutstandingCompletions.ActiveRow.Cells("Project").Text
                frmCreateCompletion.ShowDialog()

                RefreshReadyCompletions()
            End If
        End If
    End Sub
End Class