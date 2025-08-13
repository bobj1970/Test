Public Class frmCreateCompletion
    Dim ProjectFirstLoad As Boolean
    Dim selectedProject As String
    Dim ProjNum As Integer
    Dim ProjName As String
    Public Shared Builder As String
    Public Shared Project As String


    Private Sub btnCreateCompletion_Click(sender As Object, e As EventArgs) Handles btnCreateCompletion.Click
        If ugContacts.Rows.Count > 0 Then
            If ugContacts.Selected.Rows.Count > 0 Then
                Dim CompletionRequestID As Integer = KPGeneral.WebRef_Local.usp_AddCompletionRequest(cmbProjects.ActiveRow.Cells("ProjNum").Text, KPGeneral.User.UserProfile("UserLoginName"))

                If CompletionRequestID > 0 Then
                    Dim x As Integer
                    For x = 0 To ugContacts.Selected.Rows.Count - 1
                        Dim ContactID As Integer
                        Dim ContactName, ContactEmail, ContactFax As String

                        ContactID = ugContacts.Selected.Rows(x).Cells("ContactID").Text

                        If IsDBNull(ugContacts.Selected.Rows(x).Cells("ContactName").Value) = False Then
                            ContactName = ugContacts.Selected.Rows(x).Cells("ContactName").Text
                        Else
                            ContactName = ""
                        End If

                        If IsDBNull(ugContacts.Selected.Rows(x).Cells("ContactEmail").Value) = False Then
                            ContactEmail = ugContacts.Selected.Rows(x).Cells("ContactEmail").Text
                        Else
                            ContactEmail = ""
                        End If

                        If IsDBNull(ugContacts.Selected.Rows(x).Cells("ContactFax").Value) = False Then
                            ContactFax = ugContacts.Selected.Rows(x).Cells("ContactFax").Text
                        Else
                            ContactFax = ""
                        End If

                        KPGeneral.WebRef_Local.usp_AddCompletionRequestContacts(CompletionRequestID, ContactID, ContactName, ContactEmail, ContactFax)
                    Next

                    Me.Close()
                Else
                    MsgBox("There was an issue creating this completion request.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                End If
            Else
                MsgBox("There is no contact selected.  Please select at least one before continuing", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        Else
            MsgBox("There are no project contacts for Completions.  Please add and select at least one before continuing.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub btnModifyContacts_Click(sender As Object, e As EventArgs) Handles btnModifyContacts.Click
        If cmbProjects.IsItemInList = True Then
            frmLayoutContacts.ProjNum = cmbProjects.ActiveRow.Cells("ProjNum").Text
            frmLayoutContacts.CSID = 0
            frmLayoutContacts.FromForm = "Completions"
            frmLayoutContacts.ShowDialog()

            RefreshProjectContacts()
        End If
    End Sub
    Private Sub frmCreateCompletion_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmbBuilder.Text = ""
        cmbProjects.Text = ""
        ugContacts.DataSource = Nothing

        cmbBuilder.Enabled = True
        cmbProjects.Enabled = False

        fillBuilderList()

        If Builder.Length > 0 Then
            cmbBuilder.Text = Builder

            My.Computer.Keyboard.SendKeys("{ENTER}")

            'ProjectFirstLoad = True
            'fillProjectList(cmbBuilder.Text)
            'cmbProjects.Enabled = True
            'cmbProjects.Focus()

            If Project.Length > 0 Then
                cmbProjects.Text = Project

                My.Computer.Keyboard.SendKeys("{ENTER}")
                'If cmbProjects.IsItemInList = True Then
                '    ProjectFirstLoad = False
                '    'KPGeneral.ProjectNo = cmbProjects.ActiveRow.Cells("PROJNUM").Text
                '    selectedProject = cmbProjects.ActiveRow.Index
                '    cmbProjects.Value = cmbProjects.Rows(selectedProject).Cells("Project").Text

                '    ProjNum = cmbProjects.ActiveRow.Cells("PROJNUM").Text
                '    ProjName = cmbBuilder.Text & "\" & cmbProjects.Text

                '    RefreshProjectContacts()
                'End If

            End If
        End If

        KPGeneral.SetDefaultGridSettings(ugContacts)
    End Sub
    Private Sub cmbBuilder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBuilder.Click
        cmbProjects.Text = Nothing
        cmbProjects.Enabled = False
    End Sub
    Private Sub cmbBuilder_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBuilder.Enter
        cmbProjects.Enabled = False
        fillBuilderList()
        cmbBuilder.DisplayLayout.Bands(0).ColHeadersVisible = False
        cmbBuilder.DisplayLayout.Bands(0).Columns("BUILDER").Width = 236
        cmbBuilder.DisplayLayout.Bands(0).Columns("BUILDERNO").Hidden = True
        cmbBuilder.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        cmbBuilder.ValueMember = "BUILDER"
        cmbBuilder.Textbox.SelectAll()
    End Sub
    Private Sub cmbBuilder_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBuilder.GotFocus
        cmbProjects.Enabled = False
    End Sub
    Private Sub cmbBuilder_ItemNotInList(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs) Handles cmbBuilder.ItemNotInList
        If cmbBuilder.Text.Length = 0 Then
            e.RetainFocus = False
        Else
            e.RetainFocus = True
        End If
    End Sub
    Private Sub cmbBuilder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbBuilder.KeyDown
        Try
            If cmbBuilder.IsItemInList = True Then
                If e.KeyData.Equals(System.Windows.Forms.Keys.Enter) Or e.KeyData.Equals(System.Windows.Forms.Keys.Tab) Then
                    ProjectFirstLoad = True
                    fillProjectList(cmbBuilder.Text)
                    cmbProjects.Enabled = True
                    cmbProjects.Focus()
                End If
            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

    End Sub
    Sub fillProjectList(ByVal Builder As String)
        Try
            Dim dsproject As New DataSet
            dsproject = KPGeneral.WebRef_Local.spKP_ProjectList(Builder)
            cmbProjects.DataSource = dsproject

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub cmbProjects_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProjects.Click
    End Sub
    Private Sub cmbProjects_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProjects.Enter
        'cmbLots.Enabled = False
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.spKP_ProjectList(cmbBuilder.Text)
        cmbProjects.DataSource = ds
        cmbProjects.DisplayLayout.Bands(0).ColHeadersVisible = False
        cmbProjects.DisplayLayout.Bands(0).Columns("PROJNUM").Hidden = True
        cmbProjects.DisplayLayout.Bands(0).Columns("PROJECT").Width = 236
        cmbProjects.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        cmbProjects.ValueMember = "PROJECT"
        cmbProjects.Textbox.SelectAll()
    End Sub
    Private Sub cmbProjects_ItemNotInList(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs) Handles cmbProjects.ItemNotInList
        If ProjectFirstLoad = True Then
            e.RetainFocus = True
            ProjectFirstLoad = False
        Else
            If cmbProjects.Text.Length = 0 Then
                e.RetainFocus = False
            Else
                e.RetainFocus = True
            End If
        End If

    End Sub
    Private Sub cmbProjects_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProjects.KeyDown
        Try
            If cmbProjects.IsItemInList = True Then
                ' ProjectList.KeyActionMappings.Contains()
                If e.KeyData.Equals(System.Windows.Forms.Keys.Enter) Or e.KeyData.Equals(System.Windows.Forms.Keys.Tab) Then
                    ProjectFirstLoad = False
                    'KPGeneral.ProjectNo = cmbProjects.ActiveRow.Cells("PROJNUM").Text
                    selectedProject = cmbProjects.ActiveRow.Index
                    cmbProjects.Value = cmbProjects.Rows(selectedProject).Cells("Project").Text

                    ProjNum = cmbProjects.ActiveRow.Cells("PROJNUM").Text
                    ProjName = cmbBuilder.Text & "\" & cmbProjects.Text

                    RefreshProjectContacts()
                End If
            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Sub fillBuilderList()
        Try
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.spKP_getBuilderListFromtblBuilder() 'global.webref_local.spKP_CompanyList(global.SessionID, "%")
            cmbBuilder.DataSource = ds
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub RefreshProjectContacts()
        Dim dsProjectsContact As New DataSet

        dsProjectsContact = KPGeneral.WebRef_Local.KPU_GetProjectsContactLayout_ByProjectNo_Completions(ProjNum)

        ugContacts.DataSource = dsProjectsContact

        ugContacts.DisplayLayout.Bands(0).Columns("ContactType").Hidden = True
        ugContacts.DisplayLayout.Bands(0).Columns("ContactID").Hidden = True
        ugContacts.DisplayLayout.Bands(0).Columns("ProjectsContactTypeID").Hidden = True
        ugContacts.DisplayLayout.Bands(0).Columns("ProjNum").Hidden = True
        ugContacts.DisplayLayout.Bands(0).Columns("SuperContactID").Hidden = True
    End Sub

    Private Sub cmbBuilder_ValueChanged(sender As Object, e As EventArgs) Handles cmbBuilder.ValueChanged
        If cmbBuilder.IsItemInList = True Then
            'If e.KeyData.Equals(System.Windows.Forms.Keys.Enter) Or e.KeyData.Equals(System.Windows.Forms.Keys.Tab) Then
            ProjectFirstLoad = True
                fillProjectList(cmbBuilder.Text)
                cmbProjects.Enabled = True
            'cmbProjects.Focus()
        End If
        'End If
    End Sub
    Private Sub cmbProjects_ValueChanged(sender As Object, e As EventArgs) Handles cmbProjects.ValueChanged
        If cmbProjects.IsItemInList = True Then
            ' ProjectList.KeyActionMappings.Contains()
            'If e.KeyData.Equals(System.Windows.Forms.Keys.Enter) Or e.KeyData.Equals(System.Windows.Forms.Keys.Tab) Then
            ProjectFirstLoad = False
                'KPGeneral.ProjectNo = cmbProjects.ActiveRow.Cells("PROJNUM").Text
                selectedProject = cmbProjects.ActiveRow.Index
                cmbProjects.Value = cmbProjects.Rows(selectedProject).Cells("Project").Text

                ProjNum = cmbProjects.ActiveRow.Cells("PROJNUM").Text
                ProjName = cmbBuilder.Text & "\" & cmbProjects.Text

                RefreshProjectContacts()
            'End If
        End If
    End Sub
End Class