Imports System.IO
Imports System.Reflection

Public Class Login

    Public Shared measurerID As Integer
    Public Shared measurerName As String

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Process_Login()
    End Sub

    Private Sub Login_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If Disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)

    End Sub

    Function VerifyTextboxes() As String

        If UID.Text.Trim.Length = 0 Then
            Return "You must enter a valid user name"
        End If
        If Passcode.Text.Trim.Length = 0 Then
            Return "You must enter a valid password"
        End If
        Return "valid"

    End Function

    Function VeryifyIPAddress() As String

        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_Login_verifyIPAddress(KPGeneral.IP)
        Dim Match As Boolean = False
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                Match = True
            End If
        End If
        If Match = False Then
            Return "The IP address that this device is currently using is not in the approved list.  Please speak to IT to rectify this."
        Else
            Return "valid"
        End If

    End Function

    Private Sub Process_Login()

        Try
            Dim ValidateText As String = VerifyTextboxes()
            If ValidateText = "valid" Then
                Dim ValidatedIPAddress As String = VeryifyIPAddress()
                If ValidatedIPAddress = "valid" Then
                    KPGeneral.encryptpwd = KPGeneral.Encrypt_Pass(Passcode.Text)
                    KPGeneral.User = New SequenceUser(UID.Text, KPGeneral.encryptpwd)
                    'Dim dsGPSComPort As New DataSet
                    'dsGPSComPort = KPGeneral.WebRef_Local.usp_GetToughpadGPSComPort(System.Environment.MachineName.ToString)
                    'If dsGPSComPort.Tables(0).Rows.Count > 0 Then
                    '    If IsDBNull(dsGPSComPort.Tables(0).Rows(0)("GPSComPort")) = False Then
                    '        KPGeneral.GPSComPort = dsGPSComPort.Tables(0).Rows(0)("GPSComPort")
                    '    End If
                    'End If
                    If Not IsDBNull(KPGeneral.User.UserProfile("MeasurerID")) Then
                        measurerID = KPGeneral.User.UserProfile("MeasurerID")
                        measurerName = KPGeneral.User.UserProfile("UserLoginName")
                    End If
                    ' [KPL] November 3, 2010 - Beta Flag
                    Dim AllMacAddressesValid As Boolean = True ' KPGeneral.CheckAllMacAddresses
                    If AllMacAddressesValid = True Then
                        Me.Dispose(True)
                        KPShell.Show()
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                        ''RaiseEvent Submission() 'if login sucessful

                        ReplaceImportVariablesFile()
                        'ListEmbeddedResources()

                        If Not DB.isTestDB Then
                            Dim CheckUpdate As New frmCheckUpdates
                            CheckUpdate.Show()
                            CheckUpdate.Hide()
                            CheckUpdate.Dispose()
                        End If

                    Else
                        MsgBox("This computer is not authorized to use this program.  Please speak to IT to get this resolved.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                    End If
                Else
                    MsgBox(ValidatedIPAddress, MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                End If
            Else
                MsgBox(ValidateText, MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, KPGeneral.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

        'old code commented by bob
        'Try
        '    Dim ValidateText As String = VerifyTextboxes()
        '    If ValidateText = "valid" Then
        '        Dim ValidatedIPAddress As String = VeryifyIPAddress()
        '        KPGeneral.encryptpwd = KPGeneral.Encrypt_Pass(Passcode.Text)
        '        KPGeneral.UserProfile = Nothing
        '        KPGeneral.UserProfile = KPGeneral.WebRef_Local.spKP_UserLogin(UID.Text, KPGeneral.Encrypt_Pass(Passcode.Text), KPGeneral.IP)
        '        If ValidatedIPAddress = "valid" Then
        '            If KPGeneral.UserProfile.Tables.Count > 1 Then
        '                Dim dsGPSComPort As New DataSet
        '                dsGPSComPort = KPGeneral.WebRef_Local.usp_GetToughpadGPSComPort(System.Environment.MachineName.ToString)
        '                If dsGPSComPort.Tables(0).Rows.Count > 0 Then
        '                    If IsDBNull(dsGPSComPort.Tables(0).Rows(0)("GPSComPort")) = False Then
        '                        KPGeneral.GPSComPort = dsGPSComPort.Tables(0).Rows(0)("GPSComPort")
        '                    End If
        '                End If
        '                KPGeneral.SessionID = KPGeneral.UserProfile.Tables(1).Rows(0)(0)
        '                If KPGeneral.UserProfile.Tables(0).Rows.Count > 0 And KPGeneral.SessionID <> Nothing Then
        '                    If Not IsDBNull(KPGeneral.UserProfile.Tables(0).Rows(0)("MeasurerID")) Then
        '                        measurerID = KPGeneral.UserProfile.Tables(0).Rows(0)("MeasurerID")
        '                        measurerName = KPGeneral.UserProfile.Tables(0).Rows(0)("UserID")
        '                    End If
        '                    ' [KPL] November 3, 2010 - Beta Flag
        '                    Dim AllMacAddressesValid As Boolean = KPGeneral.CheckAllMacAddresses
        '                    If AllMacAddressesValid = True Then
        '                        Me.Dispose(True)
        '                        KPShell.Show()
        '                        Me.DialogResult = Windows.Forms.DialogResult.OK
        '                        Me.Close()
        '                        ''RaiseEvent Submission() 'if login sucessful
        '                        If Not KPGeneral.TestVersion Then
        '                            Dim CheckUpdate As New frmCheckUpdates
        '                            CheckUpdate.Show()
        '                            CheckUpdate.Hide()
        '                            CheckUpdate.Dispose()
        '                        End If
        '                    Else
        '                        MsgBox("This computer is not authorized to use this program.  Please speak to IT to get this resolved.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        '                    End If
        '                Else
        '                    MessageBox.Show("There is no user information associated with that username/password combination.  Please make sure you have the correct information and try again.", KPGeneral.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '                End If
        '            Else
        '                MessageBox.Show("There is no user information associated with that username/password combination.  Please make sure you have the correct information and try again.", KPGeneral.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '            End If
        '        Else
        '            MsgBox(ValidatedIPAddress, MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        '        End If
        '    Else
        '        MsgBox(ValidateText, MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("There was a crash somewhere in the login process.  Please speak to IT about this and provide as much detail as possible.", KPGeneral.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        'End Try

    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If DB.isTestDB Then
            lblTestVersion.Visible = True
            lblTestVersionDate.Visible = True
            Me.BackColor = Color.Salmon
        End If
        WebServStat()
        lblVersion.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString
        If StartupChecks.CheckAlreadyRunning = False Then
            AutoEnterCredentials()
        End If

    End Sub

    Private Sub AutoEnterCredentials()

        Dim UserID, CompName As String
        UserID = System.Environment.UserName
        CompName = System.Environment.MachineName.ToString
        Dim dsComputerLoginInfo As New DataSet
        dsComputerLoginInfo = KPGeneral.WebRef_Local.usp_GetAutoLoginInfoByWindowsUserID_isComputer(CompName)
        Dim DecryptedPass As String = ""
        Dim SequenceUserID As String = ""
        Dim ProcessLogin As Boolean = False
        Dim FoundLogin As Boolean = False
        If dsComputerLoginInfo.Tables(0).Rows.Count > 0 Then
            FoundLogin = True
            If IsDBNull(dsComputerLoginInfo.Tables(0).Rows(0)("SequenceUserID")) = False Then
                SequenceUserID = dsComputerLoginInfo.Tables(0).Rows(0)("SequenceUserID")
            End If
            If IsDBNull(dsComputerLoginInfo.Tables(0).Rows(0)("UserPass")) = False Then
                DecryptedPass = KPGeneral.Encrypt_Pass(dsComputerLoginInfo.Tables(0).Rows(0)("UserPass"))
            End If
            If IsDBNull(dsComputerLoginInfo.Tables(0).Rows(0)("isProcessLogin")) = False Then
                If dsComputerLoginInfo.Tables(0).Rows(0)("isProcessLogin") = True Then
                    ProcessLogin = True
                End If
            End If
        Else
            Dim dsAutoLoginInfo As New DataSet
            dsAutoLoginInfo = KPGeneral.WebRef_Local.usp_GetAutoLoginInfoByWindowsUserID(UserID)
            If dsAutoLoginInfo.Tables(0).Rows.Count > 0 Then
                FoundLogin = True
                If IsDBNull(dsAutoLoginInfo.Tables(0).Rows(0)("SequenceUserID")) = False Then
                    SequenceUserID = dsAutoLoginInfo.Tables(0).Rows(0)("SequenceUserID")
                End If
                If IsDBNull(dsAutoLoginInfo.Tables(0).Rows(0)("UserPass")) = False Then
                    DecryptedPass = KPGeneral.Encrypt_Pass(dsAutoLoginInfo.Tables(0).Rows(0)("UserPass"))
                End If
                If IsDBNull(dsAutoLoginInfo.Tables(0).Rows(0)("isProcessLogin")) = False Then
                    If dsAutoLoginInfo.Tables(0).Rows(0)("isProcessLogin") = True Then
                        ProcessLogin = True
                    End If
                End If
            End If
        End If
        UID.Text = SequenceUserID.ToLower
        Passcode.Text = DecryptedPass
        If ProcessLogin = True Then
            Process_Login()
        Else
            If FoundLogin = True Then
                Passcode.Focus()
            Else
                UID.Focus()
            End If
        End If

    End Sub

    Private Sub WebServStat()

        KPGeneral.IP = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName.ToString).AddressList(0).ToString
        lblWSDetected.Text = "Wan IP: 192.168.3.1"
        Dim proc As Process
        Dim proc_cmd As String
        proc = New Process
        proc_cmd = "ipconfig"
        proc.StartInfo.FileName = proc_cmd
        proc.StartInfo.Arguments = " /all"
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        proc.Start()
        proc.WaitForExit(5)

    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ReplaceImportVariablesFile()
        Dim targetFolder As String = "C:\ProgramData\2020\Design\13\DB\Queue\"
        'Dim targetFolder As String = "C:\Users\digivertca\Downloads\testfile"
        Dim targetFile As String = Path.Combine(targetFolder, "ImportVariables.xml")
        Dim cutoffDate As New DateTime(2025, 1, 1)

        ' Check if the folder exists
        If Directory.Exists(targetFolder) Then
            ' Check if the file exists and if its last modified date is before Jan 1, 2025
            If File.Exists(targetFile) Then
                Dim lastModified As DateTime = File.GetLastWriteTime(targetFile)

                If lastModified < cutoffDate Then
                    Try
                        ' Get the embedded resource file
                        Dim resourceFile As String = "SequenceERP.ImportVariables.xml" ' Replace with actual resource name
                        Dim assembly As Assembly = assembly.GetExecutingAssembly()

                        Using stream As Stream = assembly.GetManifestResourceStream(resourceFile)
                            If stream IsNot Nothing Then
                                Using fileStream As FileStream = New FileStream(targetFile, FileMode.Create, FileAccess.Write)
                                    stream.CopyTo(fileStream)
                                End Using
                                MsgBox("20-20 Files have been updated.")
                                Console.WriteLine("File replaced successfully.")
                            Else
                                Console.WriteLine("Resource file not found.")
                            End If
                        End Using
                    Catch ex As Exception
                        Console.WriteLine("Error: " & ex.Message)
                    End Try
                Else
                    Console.WriteLine("File is already up-to-date. No replacement needed.")
                End If
            Else
                Console.WriteLine("File does not exist. No action taken.")
            End If
        Else
            Console.WriteLine("Target folder does not exist.")
        End If

    End Sub
    Private Sub ListEmbeddedResources()
        Dim assembly As Assembly = Assembly.GetExecutingAssembly()
        Dim resourceNames As String() = assembly.GetManifestResourceNames()

        Console.WriteLine("Embedded Resources:")
        For Each resource As String In resourceNames
            Console.WriteLine(resource)
        Next

    End Sub
End Class
