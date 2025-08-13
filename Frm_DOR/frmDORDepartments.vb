Imports System.Security.Policy
Imports Infragistics.Win.UltraWinTabControl

Public Class frmDORDepartments
    Dim FormLoaded As Boolean = False
    Private Sub frmDORDepartments_Load(sender As Object, e As EventArgs) Handles Me.Load
        FormLoaded = False

        KPGeneral.SetDefaultGridSettings(ug_DORDepartments_Departments)
        KPGeneral.SetDefaultGridSettings(ug_DORDepartments_MappedDepartment)
        KPGeneral.SetDefaultGridSettings(ug_DORDepartments_MFDepartment)
        KPGeneral.SetDefaultGridSettings(ug_DORDepartments_UserList)
        KPGeneral.SetDefaultGridSettings(ug_DORDepartments_AccessDepartments)
        KPGeneral.SetDefaultGridSettings(ug_DORDepartments_MappedAccess)

        RefreshDepartments()

        FormLoaded = True
    End Sub
    Private Sub UltraTabControl1_ActiveTabChanged(sender As Object, e As ActiveTabChangedEventArgs) Handles UltraTabControl1.ActiveTabChanged
        If UltraTabControl1.ActiveTab.Index = 0 Then
            RefreshDepartments()
            RefreshMappedDepartment()
            RefreshMFDepartment()
        Else
            RefreshUserList()
            RefreshAccessDepartments()
            RefreshMappedAccess()
        End If
    End Sub

#Region " Departments "
    Private Sub RefreshDepartments()
        Dim dsDepartments As New DataSet
        dsDepartments = KPGeneral.WebRef_Local.usp_DOR_getDepartments

        ug_DORDepartments_Departments.DataSource = dsDepartments

        KPGeneral.RefreshGridFromLayout(ug_DORDepartments_Departments, Me.GetType.Name)
    End Sub
    Private Sub RefreshMappedDepartment()
        If FormLoaded = True Then
            If ug_DORDepartments_Departments.ActiveRow Is Nothing = False Then
                If ug_DORDepartments_Departments.ActiveRow.Index > -1 Then
                    Dim dsMappedDepartments As New DataSet
                    dsMappedDepartments = KPGeneral.WebRef_Local.usp_DOR_getMappedDepartmentsByDepartmentID(ug_DORDepartments_Departments.ActiveRow.Cells("DepartmentID").Text)

                    ug_DORDepartments_MappedDepartment.DataSource = dsMappedDepartments

                    KPGeneral.RefreshGridFromLayout(ug_DORDepartments_MappedDepartment, Me.GetType.Name)
                End If
            End If
        End If
    End Sub
    Private Sub RefreshMFDepartment()
        Dim dsMFDepartments As New DataSet
        dsMFDepartments = KPGeneral.WebRef_Local.usp_DOR_getMFDepartmentsNotAssigned

        ug_DORDepartments_MFDepartment.DataSource = dsMFDepartments

        KPGeneral.RefreshGridFromLayout(ug_DORDepartments_MFDepartment, Me.GetType.Name)
    End Sub
    Private Sub btnRefreshDepartmentMap_Click(sender As Object, e As EventArgs) Handles btnRefreshDepartmentMap.Click
        RefreshMappedDepartment()
        RefreshMFDepartment()
    End Sub
    Private Sub btnAddDepartment_Click(sender As Object, e As EventArgs) Handles btnAddDepartment.Click
        If ug_DORDepartments_Departments.ActiveRow.Index > -1 Then
            If ug_DORDepartments_MFDepartment.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To ug_DORDepartments_MFDepartment.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.usp_DOR_AddDepartmentMapping(ug_DORDepartments_Departments.ActiveRow.Cells("DepartmentID").Text,
                                                                        ug_DORDepartments_MFDepartment.Selected.Rows(x).Cells("DEPARTMENT").Text, KPGeneral.User.UserProfile("UserLoginName"))
                Next

                RefreshMFDepartment()
                RefreshMappedDepartment()
            Else
                MsgBox("Please select at least 1 TMS department to add to the selected DOR department.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        Else
            MsgBox("Please select a department from the list.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub btnRemoveDepartment_Click(sender As Object, e As EventArgs) Handles btnRemoveDepartment.Click
        If ug_DORDepartments_MappedDepartment.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ug_DORDepartments_MappedDepartment.Selected.Rows.Count - 1
                KPGeneral.WebRef_Local.usp_DOR_RemoveDepartmentMappingByMappingID(ug_DORDepartments_MappedDepartment.ActiveRow.Cells("Department_MF_MappingID").Text)
            Next

            RefreshMFDepartment()
            RefreshMappedDepartment()
        Else
            MsgBox("Please select at least 1 mapped department to add to remove from the selected department.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub btnAddDORDepartment_Click(sender As Object, e As EventArgs) Handles btnAddDORDepartment.Click
        UpdateDepartmentList(True)
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshDepartments()
    End Sub
    Private Sub ColumnChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem.Click
        KPGeneral.ColumnChooser(ug_DORDepartments_Departments, Me.GetType.Name)
    End Sub
    Private Sub UpdateDepartmentNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateDepartmentNameToolStripMenuItem.Click
        UpdateDepartmentList(False)
    End Sub
    Private Sub UpdateDepartmentList(ByVal isNew As Boolean)
        Dim DepartmentID As Integer
        Dim OldDepartmentName As String

        If isNew = True Then
            DepartmentID = 0
            OldDepartmentName = ""
        Else
            If ug_DORDepartments_Departments.ActiveRow.Index > -1 Then
                DepartmentID = ug_DORDepartments_Departments.ActiveRow.Cells("DepartmentID").Text
                OldDepartmentName = ug_DORDepartments_Departments.ActiveRow.Cells("DepartmentName").Text
            Else
                MsgBox("Please select a valid department from the list to update.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                Exit Sub
            End If
        End If



        Dim IBox As String
        IBox = InputBox("Please enter a sub department name.", KPGeneral.ProgramName, OldDepartmentName)
        If IBox.Trim.Length > 0 Then
            Dim DepartmentVerification As String = VerifyDepartmentName(IBox.Trim)

            If DepartmentVerification = "valid" Then
                KPGeneral.WebRef_Local.usp_DOR_AddDepartment(DepartmentID, IBox.Trim)

                RefreshDepartments()
            Else
                MsgBox(DepartmentVerification, MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If
    End Sub
    Function VerifyDepartmentName(ByVal NewDepartmentName As String) As String
        Dim x As Integer
        For x = 0 To ug_DORDepartments_Departments.Rows.Count - 1
            If NewDepartmentName.Trim.ToLower = ug_DORDepartments_Departments.Rows(x).Cells("DepartmentName").Text.Trim.ToLower Then
                Return "The department name entered already exists.  Please enter a unique name."
            End If
        Next

        Return "valid"
    End Function
    Private Sub ColumnChooserToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem1.Click
        KPGeneral.ColumnChooser(ug_DORDepartments_MFDepartment, Me.GetType.Name)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem2.Click
        KPGeneral.ColumnChooser(ug_DORDepartments_MappedDepartment, Me.GetType.Name)
    End Sub
    Private Sub ug_DORDepartments_Departments_AfterRowActivate(sender As Object, e As EventArgs) Handles ug_DORDepartments_Departments.AfterRowActivate
        RefreshMFDepartment()
        RefreshMappedDepartment()
    End Sub
#End Region
#Region " User Access "
    Private Sub RefreshUserList()
        Dim dsUserList As New DataSet
        dsUserList = KPGeneral.WebRef_Local.usp_DOR_getUserList

        ug_DORDepartments_UserList.DataSource = dsUserList

        KPGeneral.RefreshGridFromLayout(ug_DORDepartments_UserList, Me.GetType.Name)
    End Sub
    Private Sub RefreshAccessDepartments()
        Dim dsDepartments As New DataSet
        dsDepartments = KPGeneral.WebRef_Local.usp_DOR_getDepartments

        ug_DORDepartments_AccessDepartments.DataSource = dsDepartments

        KPGeneral.RefreshGridFromLayout(ug_DORDepartments_AccessDepartments, Me.GetType.Name)
    End Sub
    Private Sub RefreshMappedAccess()
        If FormLoaded = True Then
            If ug_DORDepartments_UserList.ActiveRow Is Nothing = False Then
                If ug_DORDepartments_UserList.ActiveRow.Index > -1 Then
                    Dim dsMappedAccess As New DataSet
                    dsMappedAccess = KPGeneral.WebRef_Local.usp_DOR_getMappedAccessByUserID(ug_DORDepartments_UserList.ActiveRow.Cells("UserID").Text)

                    ug_DORDepartments_MappedAccess.DataSource = dsMappedAccess

                    KPGeneral.RefreshGridFromLayout(ug_DORDepartments_MappedAccess, Me.GetType.Name)
                End If
            End If
        End If
    End Sub
    Private Sub RefreshUserAccessLists()
        If FormLoaded = True Then
            If ug_DORDepartments_UserList.ActiveRow.Index > -1 Then
                RefreshAccessDepartments()
                RefreshMappedAccess()
                CheckUserAccess()
            End If
        End If
    End Sub
    Private Sub btnRefreshUserAccess_Click(sender As Object, e As EventArgs) Handles btnRefreshUserAccess.Click
        RefreshUserAccessLists()
    End Sub
    Private Sub btnAddUserAccess_Click(sender As Object, e As EventArgs) Handles btnAddUserAccess.Click
        If ug_DORDepartments_UserList.ActiveRow.Index > -1 Then
            If ug_DORDepartments_AccessDepartments.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To ug_DORDepartments_AccessDepartments.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.usp_DOR_AddUserAccess(ug_DORDepartments_AccessDepartments.Selected.Rows(x).Cells("DepartmentID").Text,
                                                                        ug_DORDepartments_UserList.ActiveRow.Cells("UserID").Text, KPGeneral.User.UserProfile("UserLoginName"))
                Next

                RefreshUserAccessLists()
            Else
                MsgBox("Please select at least 1 department to add to the selected user.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        Else
            MsgBox("Please select a user from the list.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub btnRemoveUserAccess_Click(sender As Object, e As EventArgs) Handles btnRemoveUserAccess.Click
        If ug_DORDepartments_MappedAccess.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ug_DORDepartments_MappedAccess.Selected.Rows.Count - 1
                KPGeneral.WebRef_Local.usp_DOR_RemoveUserAccessByAccessID(ug_DORDepartments_MappedAccess.ActiveRow.Cells("DepartmentUserAccessID").Text)
            Next

            RefreshUserAccessLists()
        Else
            MsgBox("Please select at least 1 mapped department to add to remove from the selected department.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub ColumnChooserToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem3.Click
        KPGeneral.ColumnChooser(ug_DORDepartments_UserList, Me.GetType.Name)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem4.Click
        KPGeneral.ColumnChooser(ug_DORDepartments_AccessDepartments, Me.GetType.Name)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem5.Click
        KPGeneral.ColumnChooser(ug_DORDepartments_MappedAccess, Me.GetType.Name)
    End Sub
    Private Sub ug_DORDepartments_UserList_AfterRowActivate(sender As Object, e As EventArgs) Handles ug_DORDepartments_UserList.AfterRowActivate
        RefreshUserAccessLists()
    End Sub
    Private Sub CheckUserAccess()
        Dim x, y As Integer

        For x = 0 To ug_DORDepartments_AccessDepartments.Rows.Count - 1
            For y = 0 To ug_DORDepartments_MappedAccess.Rows.Count - 1
                If ug_DORDepartments_AccessDepartments.Rows(x).Cells("DepartmentID").Text = ug_DORDepartments_MappedAccess.Rows(y).Cells("DepartmentID").Text Then
                    ug_DORDepartments_AccessDepartments.Rows(y).Hidden = True
                    Exit For
                End If
            Next
        Next
    End Sub
#End Region



End Class