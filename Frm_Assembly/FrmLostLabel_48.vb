Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient
Imports System.Data.DataViewManager
Imports System.Data
Imports System
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Collections
Imports System.Windows.Forms
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Diagnostics
Imports System.Reflection.MethodBase
Imports SpeechLib
Imports CrystalDecisions.ReportAppServer.CommonControls

Public Class FrmLostLabel_48
    Inherits System.Windows.Forms.Form
    Private lvwColumnSorter1 As ListViewColumnSorter

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        lvwColumnSorter1 = New ListViewColumnSorter
        lvCabinetList.ListViewItemSorter = lvwColumnSorter1
    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents lvCabinetList As System.Windows.Forms.ListView
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblLot As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblPhase As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lvCabinetList = New System.Windows.Forms.ListView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.lblProject = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblPhase = New System.Windows.Forms.Label()
        Me.lblLot = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(988, 34)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "4 X 8 Edition"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label2.Location = New System.Drawing.Point(577, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(397, 29)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Warehouse - Lost Label Printer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(11, 57)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(308, 29)
        Me.txtBarcode.TabIndex = 1
        Me.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(325, 59)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(322, 23)
        Me.lblMessage.TabIndex = 17
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvCabinetList
        '
        Me.lvCabinetList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCabinetList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCabinetList.FullRowSelect = True
        Me.lvCabinetList.HideSelection = False
        Me.lvCabinetList.Location = New System.Drawing.Point(11, 120)
        Me.lvCabinetList.Name = "lvCabinetList"
        Me.lvCabinetList.Size = New System.Drawing.Size(966, 501)
        Me.lvCabinetList.TabIndex = 0
        Me.lvCabinetList.TabStop = False
        Me.lvCabinetList.UseCompatibleStateImageBehavior = False
        Me.lvCabinetList.View = System.Windows.Forms.View.Details
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(10, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(308, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Enter FK Number"
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.DarkBlue
        Me.BtnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPrint.Enabled = False
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.White
        Me.BtnPrint.Location = New System.Drawing.Point(741, 45)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(235, 41)
        Me.BtnPrint.TabIndex = 2
        Me.BtnPrint.Text = "Print Selected Barcode"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'lblProject
        '
        Me.lblProject.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProject.Location = New System.Drawing.Point(272, 0)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(289, 24)
        Me.lblProject.TabIndex = 18
        Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompany
        '
        Me.lblCompany.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(0, 0)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(272, 24)
        Me.lblCompany.TabIndex = 19
        Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblPhase)
        Me.Panel2.Controls.Add(Me.lblLot)
        Me.Panel2.Controls.Add(Me.lblProject)
        Me.Panel2.Controls.Add(Me.lblCompany)
        Me.Panel2.Location = New System.Drawing.Point(11, 93)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(966, 24)
        Me.Panel2.TabIndex = 20
        '
        'lblPhase
        '
        Me.lblPhase.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPhase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhase.Location = New System.Drawing.Point(841, 0)
        Me.lblPhase.Name = "lblPhase"
        Me.lblPhase.Size = New System.Drawing.Size(125, 24)
        Me.lblPhase.TabIndex = 21
        Me.lblPhase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLot
        '
        Me.lblLot.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLot.Location = New System.Drawing.Point(561, 0)
        Me.lblLot.Name = "lblLot"
        Me.lblLot.Size = New System.Drawing.Size(280, 24)
        Me.lblLot.TabIndex = 20
        Me.lblLot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkBlue
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(605, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 41)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Print All"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'FrmLostLabel_48
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(988, 633)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.lvCabinetList)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmLostLabel_48"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrmLostLabel_48"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmLostLabel_48_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim BaseRectangle As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim Gradient_Brush As New LinearGradientBrush(BaseRectangle, Color.White, Color.DarkBlue, LinearGradientMode.Vertical) 'Gradient Degree
        e.Graphics.FillRectangle(Gradient_Brush, BaseRectangle)
    End Sub

    Private Sub FrmLostLabel_48_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    Private Sub FrmLostLabel_48_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            txtBarcode.Focus()
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Sub txtBarcode_enter(ByVal o As [Object], ByVal e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                e.Handled = True
                'Enter Pressed
                Dim ds As New DataSet
                Dim dsLot As New DataSet

                lblCompany.Text = ""
                lblProject.Text = ""
                lblLot.Text = ""
                lblPhase.Text = ""
                lblMessage.Text = ""

                'dsLot = global.WebRef_KPro.spKP_LotInfoByFK(global.SessionID, Trim(txtBarcode.Text))
                If txtBarcode.Text.ToLower.StartsWith("c") Then
                    PrintLabelByCBarcode(txtBarcode.Text)
                Else
                    txtBarcode.Text = KPGeneral.ParseBarcode(txtBarcode.Text)

                    dsLot = KPGeneral.WebRef_Local.spKPFactory_Labels_GetLabelListByBarcode(Trim(txtBarcode.Text))
                    txtBarcode.Text = Nothing
                    If dsLot.Tables.Count > 0 Then
                        If dsLot.Tables(0).Rows.Count > 0 Then
                            If KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_StatusIsStart(dsLot.Tables(0).Rows(0)("CSID")) Then
                                Dim dsOrderStatus As New DataSet
                                dsOrderStatus = KPGeneral.WebRef_Local.spKP_OrderStatusByCSID(dsLot.Tables(0).Rows(0)("CSID"))

                                Dim PrintLocked As Boolean = False

                                If IsDBNull(dsOrderStatus.Tables(0).Rows(0)("ProductionGroupPrintLocked")) = False Then
                                    PrintLocked = dsOrderStatus.Tables(0).Rows(0)("ProductionGroupPrintLocked")
                                Else
                                    PrintLocked = False
                                End If

                                If PrintLocked = False Then
                                    If dsOrderStatus.Tables(0).Rows.Count > 0 Then
                                        'ds = global.WebRef_KPFactory.spKPFactory_Labels_GetLabelListByCSID(global.SessionID, dsLot.Tables(0).Rows(0)("CSID"))
                                        'If ds.Tables.Count > 0 Then
                                        lblCompany.Text = "Company: " & Convert.ToString(dsLot.Tables(0).Rows(0)("Company"))
                                        lblProject.Text = "Project: " & Convert.ToString(dsLot.Tables(0).Rows(0)("Project"))
                                        lblLot.Text = "Lot: " & Convert.ToString(dsLot.Tables(0).Rows(0)("Lot"))
                                        If IsDBNull(dsLot.Tables(0).Rows(0)("Phase")) = False Then
                                            lblPhase.Text = "Phase: " & Convert.ToString(dsLot.Tables(0).Rows(0)("Phase"))
                                        End If
                                        FillCabinetList(dsLot.Tables(0))
                                        BtnPrint.Enabled = True
                                        Button1.Enabled = True
                                    End If
                                Else
                                    MessageBox.Show("Order is locked from printing labels!  Please speak to the scheduling department.")
                                    lvCabinetList.Clear()
                                    BtnPrint.Enabled = False
                                    Button1.Enabled = False
                                End If


                            Else
                                MessageBox.Show("Assembly Not Started!")
                                lvCabinetList.Clear()
                                BtnPrint.Enabled = False
                                Button1.Enabled = False
                            End If
                        Else
                            lblMessage.Text = "Invalid FK Number"

                            lvCabinetList.Clear()
                            BtnPrint.Enabled = False
                            Button1.Enabled = False
                        End If
                    Else
                        lblMessage.Text = "Error Loading Cabinet List"

                        lvCabinetList.Clear()
                        BtnPrint.Enabled = False
                        Button1.Enabled = False
                    End If
                    ''Else
                    'lblMessage.Text = "Invalid Barcode"
                    'voice.Speak("In Valid BarCode")
                    'lvCabinetList.Clear()
                    ''End If
                End If

                txtBarcode.Text = Nothing
                txtBarcode.Focus()
            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If lvCabinetList.SelectedIndices.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvCabinetList.SelectedIndices.Count - 1
                    KPGeneral.WebRef_Local.spKP_InsertSystemHistory(CInt(lvCabinetList.Items(x).SubItems(7).Text), "Label 4x8", "Print Single - " & CInt(lvCabinetList.SelectedItems.Item(x).SubItems(6).Text), KPGeneral.User.UserProfile("UserLoginName"))
                    KPGeneral.PrintZebraCabinetLabelByLabelNo(CInt(lvCabinetList.SelectedItems.Item(x).SubItems(6).Text), CInt(lvCabinetList.SelectedItems.Item(x).SubItems(7).Text), False)

                    KPGeneral.WebRef_Local.usp_Cabients_IncrementPrintCounter_ByLabelNo(CInt(lvCabinetList.SelectedItems.Item(x).SubItems(6).Text))
                Next
                txtBarcode.Focus()
            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub FillCabinetList(ByVal tbl As DataTable)
        Try
            lvCabinetList.Clear()
            With lvCabinetList.Columns
                .Add("Barcode", 200, HorizontalAlignment.Left)
                .Add("Cabinet Name", 200, HorizontalAlignment.Left)
                .Add("Room", 200, HorizontalAlignment.Left)
                .Add("Left Finish", 180, HorizontalAlignment.Left)
                .Add("Right Finish", 180, HorizontalAlignment.Left)
                .Add("Cabinet Number", 150, HorizontalAlignment.Left)
                .Add("LabelNo", 0, HorizontalAlignment.Left)
                .Add("CSID", 0, HorizontalAlignment.Left)
            End With

            With lvCabinetList
                Dim i As Integer = 0
                Dim RowNum As Long = 0
                ' Loop through array
                For i = 0 To tbl.Rows.Count - 1
                    'Alternate Row Colour
                    .Items.Add(Trim(Convert.ToString(tbl.Rows(i)("UBARCODE")))) '0
                    If isOdd(RowNum) = True Then
                        .Items.Item(i).BackColor = Color.LightCyan
                        .Items.Item(i).ForeColor = Color.Black
                    Else
                        .Items.Item(i).BackColor = Color.White
                        .Items.Item(i).ForeColor = Color.Black
                    End If

                    Dim p, lf, rf As String
                    If IsDBNull(tbl.Rows(i)("Phase")) Then
                        p = ""
                    Else
                        p = tbl.Rows(i)("Phase")
                    End If
                    If IsDBNull(tbl.Rows(i)("LFINISH")) Then
                        lf = ""
                    Else
                        lf = Trim(tbl.Rows(i)("LFINISH"))
                    End If
                    If IsDBNull(tbl.Rows(i)("RFINISH")) Then
                        rf = ""
                    Else
                        rf = Trim(tbl.Rows(i)("RFINISH"))
                    End If

                    .Items(i).SubItems.Add(Convert.ToString(tbl.Rows(i)("CABINET_NAME"))) '1
                    .Items(i).SubItems.Add(Convert.ToString(tbl.Rows(i)("ROOM_NAME"))) '1
                    .Items(i).SubItems.Add(Convert.ToString(lf)) '2
                    .Items(i).SubItems.Add(Convert.ToString(rf)) '3
                    .Items(i).SubItems.Add(Convert.ToString(tbl.Rows(i)("NOOFCAB")))  '4
                    .Items(i).SubItems.Add(Convert.ToString(tbl.Rows(i)("LabelNo")))  '5
                    .Items(i).SubItems.Add(Convert.ToString(tbl.Rows(i)("CSID")))  '6

                    RowNum = RowNum + 1
                Next
            End With
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Public Function isOdd(ByVal lngNumber As Long) As Boolean
        Dim blnOdd As Boolean = CLng(lngNumber) And 1
        Return blnOdd
    End Function
    Private Sub FrmLostLabel_48_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        Try

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub lvCabinetList_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCabinetList.ColumnClick
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
            lvCabinetList.Sort()
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lvCabinetList.Items.Count > 0 Then
            Dim x As Integer
            KPGeneral.WebRef_Local.spKP_InsertSystemHistory(CInt(lvCabinetList.Items(0).SubItems(7).Text), "Label 4x8", "Print All", KPGeneral.User.UserProfile("UserLoginName"))

            For x = 0 To lvCabinetList.Items.Count - 1

                KPGeneral.PrintZebraCabinetLabelByLabelNo(CInt(lvCabinetList.Items(x).SubItems(6).Text), CInt(lvCabinetList.Items(x).SubItems(7).Text), False)

                KPGeneral.WebRef_Local.usp_Cabients_IncrementPrintCounter_ByLabelNo(CInt(lvCabinetList.Items(x).SubItems(6).Text))
            Next


            txtBarcode.Focus()
        End If
    End Sub
    Private Sub PrintLabelByCBarcode(ByVal Label As String)
        Dim LabelString As String
        If txtBarcode.Text.ToLower.StartsWith("cab") Then
            LabelString = Label.ToLower.Replace("ab", "")
        Else
            LabelString = Label
        End If

        Dim MasterNum As String
        MasterNum = KPGeneral.WebRef_Local.usp_GetMasterNumByBarcode(LabelString)

        If MasterNum.Length > 0 Then
            Dim dsCSID As New DataSet
            dsCSID = KPGeneral.WebRef_Local.getCSIDByMasterNo(MasterNum)

            Dim CSID As Integer
            If dsCSID.Tables(0).Rows.Count > 0 Then
                CSID = dsCSID.Tables(0).Rows(0)("CSID")

                Dim LabelNo As String = LabelString.ToLower.Replace("c", "")

                KPGeneral.PrintZebraCabinetLabelByLabelNo(LabelNo, CSID, False)
            End If
        End If
    End Sub
End Class
