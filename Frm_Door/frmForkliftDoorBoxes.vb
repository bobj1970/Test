Public Class frmForkliftDoorBoxes
    Dim ForkliftControlCount As Integer = 12

    'Declare Possible User Controls
    Friend WithEvents ForkliftControl1 As New uctrlForkliftDoorBoxes
    Friend WithEvents ForkliftControl2 As New uctrlForkliftDoorBoxes
    Friend WithEvents ForkliftControl3 As New uctrlForkliftDoorBoxes
    Friend WithEvents ForkliftControl4 As New uctrlForkliftDoorBoxes
    Friend WithEvents ForkliftControl5 As New uctrlForkliftDoorBoxes
    Friend WithEvents ForkliftControl6 As New uctrlForkliftDoorBoxes
    Friend WithEvents ForkliftControl7 As New uctrlForkliftDoorBoxes
    Friend WithEvents ForkliftControl8 As New uctrlForkliftDoorBoxes
    Friend WithEvents ForkliftControl9 As New uctrlForkliftDoorBoxes
    Friend WithEvents ForkliftControl10 As New uctrlForkliftDoorBoxes
    Friend WithEvents ForkliftControl11 As New uctrlForkliftDoorBoxes
    Friend WithEvents ForkliftControl12 As New uctrlForkliftDoorBoxes
    Private Sub RefreshForklifts()
        upUserControls.ClientArea.Controls.Clear()

        KPGeneral.SetWaitCursor()

        Dim dsForkliftDoorBoxes As New DataSet
        dsForkliftDoorBoxes = KPGeneral.WebRef_Local.spKPFactory_ForkliftDoorBoxes

        Dim sHorizontal, sVertical, uWidth, uHeight, HPadding, ItemCount As Integer

        ItemCount = 0

        uWidth = 290
        uHeight = 130

        HPadding = 5

        sHorizontal = HPadding
        sVertical = 0

        Dim x As Integer
        For x = 0 To dsForkliftDoorBoxes.Tables(0).Rows.Count - 1
            If ItemCount > 0 Then
                If ItemCount = 4 Then
                    ItemCount = 0
                    sHorizontal = HPadding
                    sVertical = sVertical + uHeight
                Else
                    sHorizontal = sHorizontal + uWidth
                End If
            End If

            Select Case x
                Case 0
                    ForkliftControl1.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl1.lblForkliftNumber.Text = x
                    ForkliftControl1.Name = "ForkliftControl1"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl1)
                Case 1
                    ForkliftControl2.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl2.lblForkliftNumber.Text = x
                    ForkliftControl2.Name = "ForkliftControl2"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl2)
                Case 2
                    ForkliftControl3.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl3.lblForkliftNumber.Text = x
                    ForkliftControl3.Name = "ForkliftControl3"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl3)
                Case 3
                    ForkliftControl4.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl4.lblForkliftNumber.Text = x
                    ForkliftControl4.Name = "ForkliftControl4"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl4)
                Case 4
                    ForkliftControl5.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl5.lblForkliftNumber.Text = x
                    ForkliftControl5.Name = "ForkliftControl5"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl5)
                Case 5
                    ForkliftControl6.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl6.lblForkliftNumber.Text = x
                    ForkliftControl6.Name = "ForkliftControl6"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl6)
                Case 6
                    ForkliftControl7.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl7.lblForkliftNumber.Text = x
                    ForkliftControl7.Name = "ForkliftControl7"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl7)
                Case 7
                    ForkliftControl8.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl8.lblForkliftNumber.Text = x
                    ForkliftControl8.Name = "ForkliftControl8"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl8)
                Case 8
                    ForkliftControl9.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl9.lblForkliftNumber.Text = x
                    ForkliftControl9.Name = "ForkliftControl9"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl9)
                Case 9
                    ForkliftControl10.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl10.lblForkliftNumber.Text = x
                    ForkliftControl10.Name = "ForkliftControl10"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl10)
                Case 10
                    ForkliftControl11.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl11.lblForkliftNumber.Text = x
                    ForkliftControl11.Name = "ForkliftControl11"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl11)
                Case 11
                    ForkliftControl12.Location = New System.Drawing.Point(sHorizontal, sVertical)
                    ForkliftControl12.lblForkliftNumber.Text = x
                    ForkliftControl12.Name = "ForkliftControl12"
                    upUserControls.ClientArea.Controls.Add(ForkliftControl12)
            End Select

            Dim DLoc, DBox, MASTERNUM As String

            If IsDBNull(dsForkliftDoorBoxes.Tables(0).Rows(x)("DLoc")) = False Then
                DLoc = dsForkliftDoorBoxes.Tables(0).Rows(x)("DLoc").ToString
            Else
                DLoc = ""
            End If

            If IsDBNull(dsForkliftDoorBoxes.Tables(0).Rows(x)("DBox")) = False Then
                DBox = "Box " & dsForkliftDoorBoxes.Tables(0).Rows(x)("DBox").ToString
            Else
                DBox = "Box "
            End If

            If IsDBNull(dsForkliftDoorBoxes.Tables(0).Rows(x)("MASTERNUM")) = False Then
                MASTERNUM = dsForkliftDoorBoxes.Tables(0).Rows(x)("MASTERNUM").ToString
            Else
                MASTERNUM = ""
            End If

            AddForkliftInfo(x + 1, DLoc, DBox, MASTERNUM)

            ItemCount = ItemCount + 1
        Next

        KPGeneral.SetDefaultCursor()
    End Sub
    Function GetForkliftDLocationLabel(ByVal ForkliftControlID As Integer) As Infragistics.Win.Misc.UltraLabel
        Select Case ForkliftControlID
            Case 1
                Return ForkliftControl1.lblDLocation
            Case 2
                Return ForkliftControl2.lblDLocation
            Case 3
                Return ForkliftControl3.lblDLocation
            Case 4
                Return ForkliftControl4.lblDLocation
            Case 5
                Return ForkliftControl5.lblDLocation
            Case 6
                Return ForkliftControl6.lblDLocation
            Case 7
                Return ForkliftControl7.lblDLocation
            Case 8
                Return ForkliftControl8.lblDLocation
            Case 9
                Return ForkliftControl9.lblDLocation
            Case 10
                Return ForkliftControl10.lblDLocation
            Case 11
                Return ForkliftControl11.lblDLocation
            Case 12
                Return ForkliftControl12.lblDLocation
        End Select
    End Function
    Function GetForkliftBoxLabel(ByVal ForkliftControlID As Integer) As Infragistics.Win.Misc.UltraLabel
        Select Case ForkliftControlID
            Case 1
                Return ForkliftControl1.lblBox
            Case 2
                Return ForkliftControl2.lblBox
            Case 3
                Return ForkliftControl3.lblBox
            Case 4
                Return ForkliftControl4.lblBox
            Case 5
                Return ForkliftControl5.lblBox
            Case 6
                Return ForkliftControl6.lblBox
            Case 7
                Return ForkliftControl7.lblBox
            Case 8
                Return ForkliftControl8.lblBox
            Case 9
                Return ForkliftControl9.lblBox
            Case 10
                Return ForkliftControl10.lblBox
            Case 11
                Return ForkliftControl11.lblBox
            Case 12
                Return ForkliftControl12.lblBox
        End Select
    End Function
    Function GetForkliftFKLabel(ByVal ForkliftControlID As Integer) As Infragistics.Win.Misc.UltraLabel
        Select Case ForkliftControlID
            Case 1
                Return ForkliftControl1.lblFK
            Case 2
                Return ForkliftControl2.lblFK
            Case 3
                Return ForkliftControl3.lblFK
            Case 4
                Return ForkliftControl4.lblFK
            Case 5
                Return ForkliftControl5.lblFK
            Case 6
                Return ForkliftControl6.lblFK
            Case 7
                Return ForkliftControl7.lblFK
            Case 8
                Return ForkliftControl8.lblFK
            Case 9
                Return ForkliftControl9.lblFK
            Case 10
                Return ForkliftControl10.lblFK
            Case 11
                Return ForkliftControl11.lblFK
            Case 12
                Return ForkliftControl12.lblFK
        End Select
    End Function
    Function GetForkliftCompleteButton(ByVal ForkliftControlID As Integer) As Infragistics.Win.Misc.UltraButton
        Select Case ForkliftControlID
            Case 1
                Return ForkliftControl1.btnComplete
            Case 2
                Return ForkliftControl2.btnComplete
            Case 3
                Return ForkliftControl3.btnComplete
            Case 4
                Return ForkliftControl4.btnComplete
            Case 5
                Return ForkliftControl5.btnComplete
            Case 6
                Return ForkliftControl6.btnComplete
            Case 7
                Return ForkliftControl7.btnComplete
            Case 8
                Return ForkliftControl8.btnComplete
            Case 9
                Return ForkliftControl9.btnComplete
            Case 10
                Return ForkliftControl10.btnComplete
            Case 11
                Return ForkliftControl11.btnComplete
            Case 12
                Return ForkliftControl12.btnComplete
        End Select
    End Function
    Private Sub AddForkliftInfo(ByVal ForkliftControlID As Integer, ByVal DLocation As String, ByVal Box As String, ByVal FK As String)
        Dim lblDLocation As Infragistics.Win.Misc.UltraLabel
        Dim lblBox As Infragistics.Win.Misc.UltraLabel
        Dim lblFK As Infragistics.Win.Misc.UltraLabel
        Dim btnComplete As Infragistics.Win.Misc.UltraButton

        If ForkliftControlID <= ForkliftControlCount Then
            lblDLocation = GetForkliftDLocationLabel(ForkliftControlID)
            lblBox = GetForkliftBoxLabel(ForkliftControlID)
            lblFK = GetForkliftFKLabel(ForkliftControlID)

            lblDLocation.Text = DLocation
            lblBox.Text = Box
            lblFK.Text = FK
        End If

    End Sub
    Private Sub frmForkliftDoorBoxes_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshForklifts()
    End Sub
    Private Sub AddForkliftHandlers()
        Dim x As Integer
        For x = 1 To ForkliftControlCount
            Dim btnComplete As Infragistics.Win.Misc.UltraButton

            btnComplete = GetForkliftCompleteButton(x)

            AddHandler btnComplete.Click, AddressOf btnCompleteClick
        Next
    End Sub
    Protected Sub btnCompleteClick(sender As Object, e As EventArgs)
        Dim senderParent As String = getNewDoorParentControlName(sender)

        'Select Case senderParent
        '    Case "NewDoorControl1"
        '        ResetNewDoorInfo(1)
        '    Case "NewDoorControl2"
        '        ResetNewDoorInfo(2)
        '    Case "NewDoorControl3"
        '        ResetNewDoorInfo(3)
        '    Case "NewDoorControl4"
        '        ResetNewDoorInfo(4)
        '    Case "NewDoorControl5"
        '        ResetNewDoorInfo(5)
        'End Select

    End Sub
    Function getNewDoorParentControlName(sender As Object) As String
        Dim ctl As Control = CType(sender, Control)

        If ctl.Parent.Name.ToString.StartsWith("ForkliftControl") Then
            Return ctl.Parent.Name.ToString
        ElseIf ctl.Parent.Parent.Name.ToString.StartsWith("ForkliftControl") Then
            Return ctl.Parent.Parent.Name.ToString
        Else
            Return ctl.Parent.Parent.Parent.Name.ToString()
        End If

    End Function
End Class