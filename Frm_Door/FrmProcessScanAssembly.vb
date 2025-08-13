Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.Mail

Public Class frmProcessScanAssembly
    Inherits System.Windows.Forms.Form
    Dim TDate As Date
    Friend WithEvents nosum As System.Windows.Forms.TabPage
    Friend WithEvents ugNoSum As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents KitchenTrackerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyBarcodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents Missing As System.Windows.Forms.TabPage
    Friend WithEvents ugMissingDoors As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents mngClearMissingDoors As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CloseItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuColour As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrintOrderListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Dim FDate As Date
    Friend WithEvents Needed As System.Windows.Forms.TabPage
    Friend WithEvents ugDoorsNeeded As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewDoorStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Dim PauseRefresh As Integer
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblErrorMsg As System.Windows.Forms.Label
    Friend WithEvents txtTotalDoors As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents lvDoorsOnFloor As System.Windows.Forms.ListView
    Friend WithEvents lvScan As System.Windows.Forms.ListView
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lvStyle As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrderDetail As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrderList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMissingDoors As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LogMissingDoorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Assembled As System.Windows.Forms.TabPage
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcessScanAssembly))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblErrorMsg = New System.Windows.Forms.Label()
        Me.txtTotalDoors = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.lvDoorsOnFloor = New System.Windows.Forms.ListView()
        Me.lvScan = New System.Windows.Forms.ListView()
        Me.mnuMissingDoors = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LogMissingDoorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lvStyle = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrderDetail = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.lvOrderList = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuColour = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrintOrderListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Assembled = New System.Windows.Forms.TabPage()
        Me.nosum = New System.Windows.Forms.TabPage()
        Me.ugNoSum = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KitchenTrackerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyBarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Missing = New System.Windows.Forms.TabPage()
        Me.ugMissingDoors = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.mngClearMissingDoors = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CloseItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Needed = New System.Windows.Forms.TabPage()
        Me.ugDoorsNeeded = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDoorStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuMissingDoors.SuspendLayout()
        Me.mnuColour.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Assembled.SuspendLayout()
        Me.nosum.SuspendLayout()
        CType(Me.ugNoSum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Missing.SuspendLayout()
        CType(Me.ugMissingDoors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mngClearMissingDoors.SuspendLayout()
        Me.Needed.SuspendLayout()
        CType(Me.ugDoorsNeeded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 14)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "CLICK HERE TO SCAN"
        '
        'lblErrorMsg
        '
        Me.lblErrorMsg.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorMsg.Location = New System.Drawing.Point(434, 0)
        Me.lblErrorMsg.Name = "lblErrorMsg"
        Me.lblErrorMsg.Size = New System.Drawing.Size(545, 23)
        Me.lblErrorMsg.TabIndex = 19
        '
        'txtTotalDoors
        '
        Me.txtTotalDoors.BackColor = System.Drawing.Color.White
        Me.txtTotalDoors.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalDoors.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDoors.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDoors.Location = New System.Drawing.Point(1224, 24)
        Me.txtTotalDoors.Name = "txtTotalDoors"
        Me.txtTotalDoors.ReadOnly = True
        Me.txtTotalDoors.Size = New System.Drawing.Size(104, 32)
        Me.txtTotalDoors.TabIndex = 18
        Me.txtTotalDoors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 303)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1018, 24)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "UPCOMING SUMMARIES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1018, 23)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "DOORS ASSEMBLED TODAY"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(2, 35)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 19)
        Me.btnRefresh.TabIndex = 14
        Me.btnRefresh.Text = "Refresh List"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'txtBarcode
        '
        Me.txtBarcode.CausesValidation = False
        Me.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(154, 6)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(288, 20)
        Me.txtBarcode.TabIndex = 1
        Me.txtBarcode.WordWrap = False
        '
        'lvDoorsOnFloor
        '
        Me.lvDoorsOnFloor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDoorsOnFloor.FullRowSelect = True
        Me.lvDoorsOnFloor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvDoorsOnFloor.Location = New System.Drawing.Point(704, -9)
        Me.lvDoorsOnFloor.MultiSelect = False
        Me.lvDoorsOnFloor.Name = "lvDoorsOnFloor"
        Me.lvDoorsOnFloor.Size = New System.Drawing.Size(120, 32)
        Me.lvDoorsOnFloor.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lvDoorsOnFloor.TabIndex = 12
        Me.lvDoorsOnFloor.UseCompatibleStateImageBehavior = False
        Me.lvDoorsOnFloor.View = System.Windows.Forms.View.Details
        Me.lvDoorsOnFloor.Visible = False
        '
        'lvScan
        '
        Me.lvScan.ContextMenuStrip = Me.mnuMissingDoors
        Me.lvScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvScan.FullRowSelect = True
        Me.lvScan.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvScan.Location = New System.Drawing.Point(0, 57)
        Me.lvScan.MultiSelect = False
        Me.lvScan.Name = "lvScan"
        Me.lvScan.Size = New System.Drawing.Size(1018, 246)
        Me.lvScan.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lvScan.TabIndex = 11
        Me.lvScan.UseCompatibleStateImageBehavior = False
        Me.lvScan.View = System.Windows.Forms.View.Details
        '
        'mnuMissingDoors
        '
        Me.mnuMissingDoors.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogMissingDoorsToolStripMenuItem})
        Me.mnuMissingDoors.Name = "mnuMissingDoors"
        Me.mnuMissingDoors.Size = New System.Drawing.Size(180, 26)
        '
        'LogMissingDoorsToolStripMenuItem
        '
        Me.LogMissingDoorsToolStripMenuItem.Name = "LogMissingDoorsToolStripMenuItem"
        Me.LogMissingDoorsToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.LogMissingDoorsToolStripMenuItem.Text = "Log missing door(s)"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.DarkBlue
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1344, 32)
        Me.lblTitle.TabIndex = 38
        Me.lblTitle.Text = "RAW DOOR SCAN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lvStyle
        '
        Me.lvStyle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvStyle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader6})
        Me.lvStyle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvStyle.GridLines = True
        Me.lvStyle.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvStyle.HideSelection = False
        Me.lvStyle.Location = New System.Drawing.Point(508, 324)
        Me.lvStyle.Name = "lvStyle"
        Me.lvStyle.Size = New System.Drawing.Size(510, 245)
        Me.lvStyle.TabIndex = 44
        Me.lvStyle.UseCompatibleStateImageBehavior = False
        Me.lvStyle.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Style"
        Me.ColumnHeader5.Width = 275
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "#DL"
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "QTY"
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "SQM"
        Me.ColumnHeader15.Width = 70
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = ""
        Me.ColumnHeader6.Width = 22
        '
        'lvOrderDetail
        '
        Me.lvOrderDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvOrderDetail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader10, Me.ColumnHeader16})
        Me.lvOrderDetail.ContextMenu = Me.ContextMenu1
        Me.lvOrderDetail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvOrderDetail.GridLines = True
        Me.lvOrderDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvOrderDetail.HideSelection = False
        Me.lvOrderDetail.Location = New System.Drawing.Point(1024, 57)
        Me.lvOrderDetail.Name = "lvOrderDetail"
        Me.lvOrderDetail.Size = New System.Drawing.Size(304, 515)
        Me.lvOrderDetail.TabIndex = 43
        Me.lvOrderDetail.UseCompatibleStateImageBehavior = False
        Me.lvOrderDetail.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = ""
        Me.ColumnHeader7.Width = 211
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "R"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 30
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "P"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader10.Width = 30
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem4, Me.MenuItem3, Me.MenuItem5})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Kitchen Tracker"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "View Door List"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "-"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 3
        Me.MenuItem3.Text = "Copy Barcode"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 4
        Me.MenuItem5.Text = "Mark as Complete"
        '
        'lvOrderList
        '
        Me.lvOrderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvOrderList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader1, Me.ColumnHeader9, Me.ColumnHeader4})
        Me.lvOrderList.ContextMenuStrip = Me.mnuColour
        Me.lvOrderList.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvOrderList.GridLines = True
        Me.lvOrderList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvOrderList.HideSelection = False
        Me.lvOrderList.Location = New System.Drawing.Point(3, 327)
        Me.lvOrderList.Name = "lvOrderList"
        Me.lvOrderList.Size = New System.Drawing.Size(499, 245)
        Me.lvOrderList.TabIndex = 42
        Me.lvOrderList.UseCompatibleStateImageBehavior = False
        Me.lvOrderList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Colour"
        Me.ColumnHeader2.Width = 172
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "#ST"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 40
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "#DT"
        Me.ColumnHeader11.Width = 50
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "SQM"
        Me.ColumnHeader12.Width = 70
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Batch Week"
        Me.ColumnHeader9.Width = 89
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "BID"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 70
        '
        'mnuColour
        '
        Me.mnuColour.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintOrderListToolStripMenuItem})
        Me.mnuColour.Name = "mnuColour"
        Me.mnuColour.Size = New System.Drawing.Size(154, 26)
        '
        'PrintOrderListToolStripMenuItem
        '
        Me.PrintOrderListToolStripMenuItem.Name = "PrintOrderListToolStripMenuItem"
        Me.PrintOrderListToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.PrintOrderListToolStripMenuItem.Text = "Print Order List"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Assembled)
        Me.TabControl1.Controls.Add(Me.nosum)
        Me.TabControl1.Controls.Add(Me.Missing)
        Me.TabControl1.Controls.Add(Me.Needed)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1344, 601)
        Me.TabControl1.TabIndex = 45
        '
        'Assembled
        '
        Me.Assembled.Controls.Add(Me.Label4)
        Me.Assembled.Controls.Add(Me.lvScan)
        Me.Assembled.Controls.Add(Me.btnRefresh)
        Me.Assembled.Controls.Add(Me.lvDoorsOnFloor)
        Me.Assembled.Controls.Add(Me.lvStyle)
        Me.Assembled.Controls.Add(Me.txtTotalDoors)
        Me.Assembled.Controls.Add(Me.lvOrderDetail)
        Me.Assembled.Controls.Add(Me.txtBarcode)
        Me.Assembled.Controls.Add(Me.lvOrderList)
        Me.Assembled.Controls.Add(Me.Label1)
        Me.Assembled.Controls.Add(Me.lblErrorMsg)
        Me.Assembled.Controls.Add(Me.Label2)
        Me.Assembled.Location = New System.Drawing.Point(4, 22)
        Me.Assembled.Name = "Assembled"
        Me.Assembled.Padding = New System.Windows.Forms.Padding(3)
        Me.Assembled.Size = New System.Drawing.Size(1336, 575)
        Me.Assembled.TabIndex = 0
        Me.Assembled.Text = "Assembled"
        Me.Assembled.UseVisualStyleBackColor = True
        '
        'nosum
        '
        Me.nosum.Controls.Add(Me.ugNoSum)
        Me.nosum.Location = New System.Drawing.Point(4, 22)
        Me.nosum.Name = "nosum"
        Me.nosum.Padding = New System.Windows.Forms.Padding(3)
        Me.nosum.Size = New System.Drawing.Size(1336, 575)
        Me.nosum.TabIndex = 2
        Me.nosum.Text = "Remaining Door Lists - No Summaries"
        Me.nosum.UseVisualStyleBackColor = True
        '
        'ugNoSum
        '
        Me.ugNoSum.ContextMenuStrip = Me.ContextMenuStrip1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugNoSum.DisplayLayout.Appearance = Appearance1
        Me.ugNoSum.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugNoSum.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugNoSum.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugNoSum.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugNoSum.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugNoSum.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugNoSum.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugNoSum.DisplayLayout.MaxColScrollRegions = 1
        Me.ugNoSum.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugNoSum.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugNoSum.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugNoSum.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugNoSum.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugNoSum.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugNoSum.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugNoSum.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugNoSum.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugNoSum.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugNoSum.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugNoSum.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugNoSum.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugNoSum.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugNoSum.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugNoSum.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugNoSum.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugNoSum.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugNoSum.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugNoSum.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugNoSum.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugNoSum.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugNoSum.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugNoSum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugNoSum.Location = New System.Drawing.Point(3, 3)
        Me.ugNoSum.Name = "ugNoSum"
        Me.ugNoSum.Size = New System.Drawing.Size(1330, 569)
        Me.ugNoSum.TabIndex = 2
        Me.ugNoSum.Text = "UltraGrid1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KitchenTrackerToolStripMenuItem, Me.ToolStripSeparator1, Me.CopyBarcodeToolStripMenuItem, Me.RefreshListToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(156, 76)
        '
        'KitchenTrackerToolStripMenuItem
        '
        Me.KitchenTrackerToolStripMenuItem.Name = "KitchenTrackerToolStripMenuItem"
        Me.KitchenTrackerToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.KitchenTrackerToolStripMenuItem.Text = "Kitchen Tracker"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(152, 6)
        '
        'CopyBarcodeToolStripMenuItem
        '
        Me.CopyBarcodeToolStripMenuItem.Name = "CopyBarcodeToolStripMenuItem"
        Me.CopyBarcodeToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.CopyBarcodeToolStripMenuItem.Text = "Copy Barcode"
        '
        'RefreshListToolStripMenuItem
        '
        Me.RefreshListToolStripMenuItem.Name = "RefreshListToolStripMenuItem"
        Me.RefreshListToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.RefreshListToolStripMenuItem.Text = "Refresh List"
        '
        'Missing
        '
        Me.Missing.Controls.Add(Me.ugMissingDoors)
        Me.Missing.Location = New System.Drawing.Point(4, 22)
        Me.Missing.Name = "Missing"
        Me.Missing.Size = New System.Drawing.Size(1336, 575)
        Me.Missing.TabIndex = 3
        Me.Missing.Text = "Missing Doors"
        Me.Missing.UseVisualStyleBackColor = True
        '
        'ugMissingDoors
        '
        Me.ugMissingDoors.ContextMenuStrip = Me.mngClearMissingDoors
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugMissingDoors.DisplayLayout.Appearance = Appearance13
        Me.ugMissingDoors.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugMissingDoors.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.ugMissingDoors.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugMissingDoors.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.ugMissingDoors.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugMissingDoors.DisplayLayout.GroupByBox.Hidden = True
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugMissingDoors.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.ugMissingDoors.DisplayLayout.MaxColScrollRegions = 1
        Me.ugMissingDoors.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugMissingDoors.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugMissingDoors.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.ugMissingDoors.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugMissingDoors.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugMissingDoors.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugMissingDoors.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugMissingDoors.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugMissingDoors.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugMissingDoors.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.ugMissingDoors.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugMissingDoors.DisplayLayout.Override.CellAppearance = Appearance20
        Me.ugMissingDoors.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugMissingDoors.DisplayLayout.Override.CellPadding = 0
        Me.ugMissingDoors.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.ugMissingDoors.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.ugMissingDoors.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.ugMissingDoors.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugMissingDoors.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.ugMissingDoors.DisplayLayout.Override.RowAppearance = Appearance23
        Me.ugMissingDoors.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugMissingDoors.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.ugMissingDoors.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugMissingDoors.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugMissingDoors.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugMissingDoors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugMissingDoors.Location = New System.Drawing.Point(0, 0)
        Me.ugMissingDoors.Name = "ugMissingDoors"
        Me.ugMissingDoors.Size = New System.Drawing.Size(1336, 575)
        Me.ugMissingDoors.TabIndex = 0
        Me.ugMissingDoors.Text = "UltraGrid1"
        '
        'mngClearMissingDoors
        '
        Me.mngClearMissingDoors.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseItemToolStripMenuItem})
        Me.mngClearMissingDoors.Name = "mngClearMissingDoors"
        Me.mngClearMissingDoors.Size = New System.Drawing.Size(131, 26)
        '
        'CloseItemToolStripMenuItem
        '
        Me.CloseItemToolStripMenuItem.Name = "CloseItemToolStripMenuItem"
        Me.CloseItemToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.CloseItemToolStripMenuItem.Text = "Close Item"
        '
        'Needed
        '
        Me.Needed.Controls.Add(Me.ugDoorsNeeded)
        Me.Needed.Location = New System.Drawing.Point(4, 22)
        Me.Needed.Name = "Needed"
        Me.Needed.Size = New System.Drawing.Size(1336, 575)
        Me.Needed.TabIndex = 4
        Me.Needed.Text = "Doors Needed"
        Me.Needed.UseVisualStyleBackColor = True
        '
        'ugDoorsNeeded
        '
        Me.ugDoorsNeeded.ContextMenuStrip = Me.ContextMenuStrip3
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDoorsNeeded.DisplayLayout.Appearance = Appearance25
        Me.ugDoorsNeeded.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDoorsNeeded.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDoorsNeeded.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDoorsNeeded.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.ugDoorsNeeded.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDoorsNeeded.DisplayLayout.GroupByBox.Hidden = True
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDoorsNeeded.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.ugDoorsNeeded.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDoorsNeeded.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDoorsNeeded.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDoorsNeeded.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.ugDoorsNeeded.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDoorsNeeded.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDoorsNeeded.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDoorsNeeded.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDoorsNeeded.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDoorsNeeded.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDoorsNeeded.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.ugDoorsNeeded.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDoorsNeeded.DisplayLayout.Override.CellAppearance = Appearance32
        Me.ugDoorsNeeded.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugDoorsNeeded.DisplayLayout.Override.CellPadding = 0
        Me.ugDoorsNeeded.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDoorsNeeded.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.ugDoorsNeeded.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.ugDoorsNeeded.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDoorsNeeded.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.ugDoorsNeeded.DisplayLayout.Override.RowAppearance = Appearance35
        Me.ugDoorsNeeded.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDoorsNeeded.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.ugDoorsNeeded.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDoorsNeeded.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDoorsNeeded.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDoorsNeeded.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDoorsNeeded.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDoorsNeeded.Location = New System.Drawing.Point(0, 0)
        Me.ugDoorsNeeded.Name = "ugDoorsNeeded"
        Me.ugDoorsNeeded.Size = New System.Drawing.Size(1336, 575)
        Me.ugDoorsNeeded.TabIndex = 25
        Me.ugDoorsNeeded.Text = "UltraGrid1"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDoorStatusToolStripMenuItem, Me.ToolStripMenuItem1, Me.PrintToolStripMenuItem})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(164, 70)
        '
        'ViewDoorStatusToolStripMenuItem
        '
        Me.ViewDoorStatusToolStripMenuItem.Name = "ViewDoorStatusToolStripMenuItem"
        Me.ViewDoorStatusToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ViewDoorStatusToolStripMenuItem.Text = "View Door Status"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(163, 22)
        Me.ToolStripMenuItem1.Text = "Kitchen Tracker"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = ""
        Me.ColumnHeader16.Width = 0
        '
        'frmProcessScanAssembly
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1344, 633)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProcessScanAssembly"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Raw Door Scan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuMissingDoors.ResumeLayout(False)
        Me.mnuColour.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.Assembled.ResumeLayout(False)
        Me.Assembled.PerformLayout()
        Me.nosum.ResumeLayout(False)
        CType(Me.ugNoSum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Missing.ResumeLayout(False)
        CType(Me.ugMissingDoors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mngClearMissingDoors.ResumeLayout(False)
        Me.Needed.ResumeLayout(False)
        CType(Me.ugDoorsNeeded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Private Sub frmProcessScanAssembly_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
    '    Dim BaseRectangle As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
    '    Dim Gradient_Brush As New LinearGradientBrush(BaseRectangle, Color.White, Color.DarkBlue, LinearGradientMode.Vertical) 'Gradient Degree
    '    e.Graphics.FillRectangle(Gradient_Brush, BaseRectangle)
    'End Sub

    Private Sub frmProcessScanAssembly_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    Private Sub frmProcessScanAssembly_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        If KPGeneral.User.UserProfile("MonitorUser") Then
            txtBarcode.Enabled = False
        Else
            txtBarcode.Enabled = True
        End If
        RefreshList()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshList()
    End Sub

    Private Sub RefreshList()

        'If UcWebStatus1.WebServFound(Me) = True Then
        Fill_lvScan(KPGeneral.WebRef_Local.spKPFactory_RawDoors_CompletedList(Now.Date)) 'WebService
        Fill_lvDoorsOnFloor(KPGeneral.WebRef_Local.spKPFactory_RawDoors_Upcoming()) 'WebService
        GetTotalDoors()
        'End If

        txtBarcode.Focus()
    End Sub

    Private Sub Fill_lvScan(ByVal dsScan As DataSet)
        Try
            lvScan.Clear()
            With lvScan.Columns
                .Add("", 35, HorizontalAlignment.Left) 'Spacer for Image
                .Add("Barcode", 178, HorizontalAlignment.Left)
                .Add("BID", 35, HorizontalAlignment.Left)
                .Add("Style", 180, HorizontalAlignment.Left)
                .Add("Colour", 180, HorizontalAlignment.Left)
                .Add("Scan Time", 85, HorizontalAlignment.Left)
            End With

            With lvScan
                .SmallImageList = ImageList1
                Dim RowNum As Long = 0
                Dim i As Integer = 0
                ' Loop through array
                For i = 0 To dsScan.Tables(0).Rows.Count - 1
                    .Items.Add("") 'Spacer for Image

                    'Alternate Row
                    If isOdd(RowNum) = True Then
                        .Items.Item(i).BackColor = Color.AliceBlue
                        .Items.Item(i).ForeColor = Color.Black
                    Else
                        .Items.Item(i).BackColor = Color.White
                        .Items.Item(i).ForeColor = Color.Black
                    End If

                    .Items(i).ImageIndex = 0 'Barcode Image
                    .Items(i).SubItems.Add(Convert.ToString(dsScan.Tables(0).Rows(i)("Barcode")).Trim) '1
                    .Items(i).SubItems.Add(Convert.ToString(dsScan.Tables(0).Rows(i)("BatchID")).Trim) '1
                    .Items(i).SubItems.Add(Convert.ToString(dsScan.Tables(0).Rows(i)("Style")).Trim) '2
                    .Items(i).SubItems.Add(Convert.ToString(dsScan.Tables(0).Rows(i)("Colour")).Trim) '3
                    .Items(i).SubItems.Add(Convert.ToString(Strings.Mid(dsScan.Tables(0).Rows(i)("RawTime").ToString, InStr(dsScan.Tables(0).Rows(i)("RawTime").ToString, " ") + 1).Trim)) '4

                    RowNum = RowNum + 1

                    If IsDBNull(dsScan.Tables(0).Rows(i)("WeekColour")) = False Then
                        Select Case Trim(dsScan.Tables(0).Rows(i)("WeekColour"))
                            Case "Orange"
                                .Items.Item(i).BackColor = Color.Gold
                            Case "Green"
                                .Items.Item(i).BackColor = Color.LightGreen
                            Case "Pink"
                                .Items.Item(i).BackColor = Color.Salmon
                            Case "Blue"
                                .Items.Item(i).BackColor = Color.LightBlue
                            Case "Purple"
                                .Items.Item(i).BackColor = Color.Violet
                        End Select

                    Else
                        .Items.Item(i).BackColor = Color.White
                    End If

                    ' 4/30/2009 - Service Door Tracking
                    If Not IsDBNull(dsScan.Tables(0).Rows(i)("isService")) Then

                        If dsScan.Tables(0).Rows(i)("isService") = "1" Then
                            .Items.Item(i).BackColor = Color.Yellow
                        End If

                    End If

                Next
            End With
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

    End Sub

    Private Sub Fill_lvDoorsOnFloor(ByVal dsDoorsOnFloor As DataSet)
        Try
            lvDoorsOnFloor.Clear()
            With lvDoorsOnFloor.Columns
                .Add("", 35, HorizontalAlignment.Left) 'Spacer for Image
                .Add("Wood Type", 100, HorizontalAlignment.Left)
                .Add("Style", 325, HorizontalAlignment.Left)
                .Add("Colour", 325, HorizontalAlignment.Left)
                .Add("Door Count", 100, HorizontalAlignment.Left)
            End With

            With lvDoorsOnFloor
                .SmallImageList = ImageList1
                Dim i As Integer = 0
                Dim RowNum As Long = 0
                ' Loop through array
                For i = 0 To dsDoorsOnFloor.Tables(0).Rows.Count - 1
                    .Items.Add("") 'Spacer for Image

                    'Alternate Row Colour
                    If isOdd(RowNum) = True Then
                        .Items.Item(i).BackColor = Color.AliceBlue
                        .Items.Item(i).ForeColor = Color.Black
                    Else
                        .Items.Item(i).BackColor = Color.White
                        .Items.Item(i).ForeColor = Color.Black
                    End If

                    If dsDoorsOnFloor.Tables(0).Rows(i)("WoodType") = "Maple" Then
                        .Items(i).ImageIndex = 1 'Maple Leaf Image
                    ElseIf dsDoorsOnFloor.Tables(0).Rows(i)("WoodType") = "Oak" Then
                        .Items(i).ImageIndex = 2 'Oak Leaf Image
                    End If

                    .Items(i).SubItems.Add(Convert.ToString(dsDoorsOnFloor.Tables(0).Rows(i)("WoodType")).Trim) '1
                    .Items(i).SubItems.Add(Convert.ToString(dsDoorsOnFloor.Tables(0).Rows(i)("Style")).Trim) '2
                    .Items(i).SubItems.Add(Convert.ToString(dsDoorsOnFloor.Tables(0).Rows(i)("Colour")).Trim) '3
                    .Items(i).SubItems.Add(Convert.ToString(dsDoorsOnFloor.Tables(0).Rows(i)("DoorCount")).Trim) '4

                    RowNum = RowNum + 1

                Next
            End With
        Catch ex As Exception

        End Try

    End Sub

    Public Function isOdd(ByVal lngNumber As Long) As Boolean
        Dim blnOdd As Boolean = CLng(lngNumber) And 1
        Return blnOdd
    End Function

    Private Sub GetTotalDoors()
        Try
            txtTotalDoors.Text = KPGeneral.WebRef_Local.spKPFactory_RawDoors_CompletedCount(Now.Date) 'WebService
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Public Sub txtBarcode_enter(ByVal o As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        Try
            Dim summary As String = ""
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                e.Handled = True
                'Enter Pressed
                Me.Cursor = Cursors.WaitCursor
                'If UcWebStatus1.WebServFound(Me) = True Then
                Dim BarcodeExist As Boolean = False
                Dim BarCode As String
                BarCode = txtBarcode.Text

                Dim SumID As Integer = BarCode.Remove(0, BarCode.LastIndexOf("-") + 1)

                If txtBarcode.Text.StartsWith("DL") Then
                    Dim dsBarcode As New DataSet
                    dsBarcode = KPGeneral.WebRef_Local.spKPFactory_VerifyDoorListSumID(SumID)
                    If dsBarcode.Tables.Count > 0 Then
                        BarcodeExist = True
                        BarCode = dsBarcode.Tables(0).Rows(0)("Barcode")
                    Else
                        BarcodeExist = False
                    End If
                Else
                    BarcodeExist = KPGeneral.WebRef_Local.spKPFactory_VerifyDoorListBarcode(BarCode) 'WebService
                End If

                If BarcodeExist = True Then
                    summary = Strings.UCase(BarCode)
                    'Cancelled Order (Rich Added - 09/06/06)
                    Dim dsCancelOrderCheck As New DataSet
                    dsCancelOrderCheck = KPGeneral.WebRef_Local.spKP_LotInfoByFK(KPGeneral.ExtractMasterNum(Trim(BarCode)).Replace("S", "F"))
                    If dsCancelOrderCheck.Tables(0).Rows.Count > 0 Then
                        If dsCancelOrderCheck.Tables(0).Rows(0)("CancelOrder") = True Then
                            lblErrorMsg.Text = "Order Cancelled!"
                            txtBarcode.Text = vbNullString
                            txtBarcode.Focus()
                            Exit Sub
                        End If
                    Else
                        lblErrorMsg.Text = summary + " is not a VALID Input"
                        txtBarcode.Text = vbNullString
                        txtBarcode.Focus()
                        Exit Sub
                    End If
                    'End Cancelled Order
                    'Door Scanned Warning

                    Dim d As DataSet
                    d = KPGeneral.WebRef_Local.spKP_DoorStatusbyBarcode(dsCancelOrderCheck.Tables(0).Rows(0).Item("CSID"), summary, SumID)
                    Dim Style, Colour As String
                    Style = d.Tables(0).Rows(0).Item("SCode")
                    Colour = d.Tables(0).Rows(0).Item("DisplayCode")
                    If IsDBNull(d.Tables(0).Rows(0).Item("RawDate")) = False Then ' Already Scanned
                        MessageBox.Show("Doors Picked On " & Convert.ToDateTime(d.Tables(0).Rows(0)("RawDate")).Date & " : " & Convert.ToDateTime(d.Tables(0).Rows(0)("RawTime")).TimeOfDay.ToString)
                    Else
                        KPGeneral.WebRef_Local.spKPFactory_RawDoors_UpdateScan_AddWarehouse(Now, BarCode, SumID)
                        ' KPGeneral.WebRef_Local.usp__WatchList_SendDoorsPaintedEmail(dsCancelOrderCheck.Tables(0).Rows(0).Item("CSID"), Style, Colour)
                        lblErrorMsg.Text = "OK"
                        'd = global.WebRef_KPro.spKP_DoorStatusbyBarcode(global.SessionID, dsCancelOrderCheck.Tables(0).Rows(0).Item("CSID"), summary)
                    End If
                    'lblErrorMsg.Text = summary + "     Scanned: " + Convert.ToDateTime(d.Tables(0).Rows(0).Item("RawDate")).ToShortDateString + "     [" + Convert.ToDateTime(d.Tables(0).Rows(0).Item("Rawtime")).ToShortTimeString + "]"

                    RefreshList()
                End If
                'End If
                txtBarcode.Text = vbNullString
                txtBarcode.Focus()

                PauseRefresh = 0
                Timer1.Start()

                lvStyle.Items.Clear()
                lvOrderDetail.Items.Clear()
            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'Sub sendEmail(ByVal ds As DataSet, ByVal Style As String, ByVal Colour As String)
    '    Dim CSID As Integer = IIf(ds.Tables(0).Rows(0)("CSID") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("CSID"))
    '    Dim MasterNum As String = IIf(ds.Tables(0).Rows(0)("MASTERNUM") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("MASTERNUM"))
    '    Dim Company As String = IIf(ds.Tables(0).Rows(0)("COMPANY") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("COMPANY"))
    '    Dim Project As String = IIf(ds.Tables(0).Rows(0)("PROJECT") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("PROJECT"))
    '    Dim Lot As String = IIf(ds.Tables(0).Rows(0)("LOT") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("LOT"))
    '    Dim dsWatchList As DataSet = KPGeneral.WebRef_Local.usp_GetWatchList_byCSID(CSID)

    '    For i As Integer = 0 To dsWatchList.Tables(0).Rows.Count - 1
    '        Dim UserEmail As String = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("UserEmail")), String.Empty, dsWatchList.Tables(0).Rows(i)("UserEmail"))
    '        Dim Notify As Boolean = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("NotifyRawDoors")), String.Empty, dsWatchList.Tables(0).Rows(i)("NotifyRawDoors"))
    '        'Dim CSID_IN_WatchList As Integer = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("CSID")), String.Empty, dsWatchList.Tables(0).Rows(i)("CSID"))

    '        If Notify = True Then
    '            Dim value As AttachmentCollection
    '            Dim Message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("reports@frendel.com", UserEmail)
    '            Message.IsBodyHtml = True
    '            'Message.CC.Add([global].UserProfile.Tables(0).Rows(0)("UserID") & "@frendel.com")
    '            'Message.Bcc.Add("kevinl@frendel.com")
    '            Message.Subject = "Order# " & MasterNum & " - " & Company & " - " & Project & " - " & Lot & " - " & "raw doors, Date: " & Now.ToString
    '            Message.Body = "Order#: " & MasterNum & " <br /> " _
    '                         & "Company: " & Company & " <br /> " _
    '                         & "Project: " & Project & " <br /> " _
    '                         & "Lot: " & Lot & " <br /> " _
    '                         & "Style: " & Style & " <br /> " _
    '                         & "Colour: " & Colour & " <br /> " _
    '                         & "has raw doors"
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

    Private Sub txtBarcode_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.Leave
        'txtBarcode.Focus()
    End Sub
    Sub fillColourList()
        Try
            lvOrderList.Items.Clear()
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.spKP_RawDoorOrderList()
            Dim x, y As Integer
            y = 0
            For x = 0 To ds.Tables(0).Rows.Count - 1

                lvOrderList.Items.Add(ds.Tables(0).Rows(x)("MaterialColour"))
                lvOrderList.Items(y).UseItemStyleForSubItems = False
                lvOrderList.Items(y).SubItems.Add(ds.Tables(0).Rows(x)("TotalSummary"))
                lvOrderList.Items(y).SubItems.Add(ds.Tables(0).Rows(x)("TotalDoorList"))
                lvOrderList.Items(y).SubItems.Add(ds.Tables(0).Rows(x)("SQM"))
                lvOrderList.Items(y).SubItems.Add(ds.Tables(0).Rows(x)("Priority"))
                lvOrderList.Items(y).SubItems.Add(Strings.FormatDateTime(ds.Tables(0).Rows(x)("StartDate"), DateFormat.ShortDate))
                lvOrderList.Items(y).SubItems.Add(ds.Tables(0).Rows(x)("NewBatchID"))
                lvOrderList.Items(y).SubItems.Add(ds.Tables(0).Rows(x)("BatchID"))
                'If IsDBNull(ds.Tables(0).Rows(x)("Painted")) = True Then
                '    lvOrderList.Items(y).SubItems.Add("", Color.Black, Color.Green, Font)
                'Else
                '    lvOrderList.Items(y).SubItems.Add("", Color.Black, Color.Red, Font)
                'End If
                Select Case Trim(ds.Tables(0).Rows(x)("WeekColour"))
                    Case "Orange"
                        lvOrderList.Items(y).BackColor = Color.Gold
                        lvOrderList.Items(y).SubItems(1).BackColor = Color.Gold
                        lvOrderList.Items(y).SubItems(2).BackColor = Color.Gold
                        lvOrderList.Items(y).SubItems(3).BackColor = Color.Gold
                        lvOrderList.Items(y).SubItems(4).BackColor = Color.Gold
                        lvOrderList.Items(y).SubItems(5).BackColor = Color.Gold
                        lvOrderList.Items(y).SubItems(6).BackColor = Color.Gold
                    Case "Green"
                        lvOrderList.Items(y).BackColor = Color.LightGreen
                        lvOrderList.Items(y).SubItems(1).BackColor = Color.LightGreen
                        lvOrderList.Items(y).SubItems(2).BackColor = Color.LightGreen
                        lvOrderList.Items(y).SubItems(3).BackColor = Color.LightGreen
                        lvOrderList.Items(y).SubItems(4).BackColor = Color.LightGreen
                        lvOrderList.Items(y).SubItems(5).BackColor = Color.LightGreen
                        lvOrderList.Items(y).SubItems(6).BackColor = Color.LightGreen
                    Case "Pink"
                        lvOrderList.Items(y).BackColor = Color.Salmon
                        lvOrderList.Items(y).SubItems(1).BackColor = Color.Salmon
                        lvOrderList.Items(y).SubItems(2).BackColor = Color.Salmon
                        lvOrderList.Items(y).SubItems(3).BackColor = Color.Salmon
                        lvOrderList.Items(y).SubItems(4).BackColor = Color.Salmon
                        lvOrderList.Items(y).SubItems(5).BackColor = Color.Salmon
                        lvOrderList.Items(y).SubItems(6).BackColor = Color.Salmon
                    Case "Blue"
                        lvOrderList.Items(y).BackColor = Color.LightBlue
                        lvOrderList.Items(y).SubItems(1).BackColor = Color.LightBlue
                        lvOrderList.Items(y).SubItems(2).BackColor = Color.LightBlue
                        lvOrderList.Items(y).SubItems(3).BackColor = Color.LightBlue
                        lvOrderList.Items(y).SubItems(4).BackColor = Color.LightBlue
                        lvOrderList.Items(y).SubItems(5).BackColor = Color.LightBlue
                        lvOrderList.Items(y).SubItems(6).BackColor = Color.LightBlue
                    Case "Purple"
                        lvOrderList.Items(y).BackColor = Color.Violet
                        lvOrderList.Items(y).SubItems(1).BackColor = Color.Violet
                        lvOrderList.Items(y).SubItems(2).BackColor = Color.Violet
                        lvOrderList.Items(y).SubItems(3).BackColor = Color.Violet
                        lvOrderList.Items(y).SubItems(4).BackColor = Color.Violet
                        lvOrderList.Items(y).SubItems(5).BackColor = Color.Violet
                        lvOrderList.Items(y).SubItems(6).BackColor = Color.Violet
                End Select

                'If IsDBNull(ds.Tables(0).Rows(x)("Painted")) = True Then
                '    lvOrderList.Items(y).Remove()
                '    y = y - 1
                'End If
                y = y + 1
            Next
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Sub fillStyleList()
        Try
            If lvOrderList.SelectedIndices.Count > 0 Then
                lvStyle.Items.Clear()
                Dim ds As New DataSet
                ds = KPGeneral.WebRef_Local.spKP_RawDoorOrderListByStyle(lvOrderList.SelectedItems.Item(0).SubItems(7).Text, lvOrderList.SelectedItems.Item(0).SubItems(4).Text)
                Dim x As Integer
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    Dim lstitem As New ListViewItem
                    lstitem.Text = ds.Tables(0).Rows(x)("Style")
                    'If IsDBNull(ds.Tables(0).Rows(x)("Glazing")) = False Then
                    '    lstitem.SubItems.Add(ds.Tables(0).Rows(x)("Glazing"))
                    'Else
                    '    lstitem.SubItems.Add("")
                    'End If
                    lvStyle.Items.Add(lstitem)
                    lvStyle.Items(x).UseItemStyleForSubItems = False
                    lvStyle.Items(x).SubItems.Add(ds.Tables(0).Rows(x)("TotalDoorList"))
                    lvStyle.Items(x).SubItems.Add(ds.Tables(0).Rows(x)("DoorQuantity"))
                    lvStyle.Items(x).SubItems.Add(ds.Tables(0).Rows(x)("SQM"))
                    If ds.Tables(0).Rows(x)("Done") = 1 Then
                        lvStyle.Items(x).SubItems.Add("", Color.Black, Color.Green, Font)
                    Else
                        lvStyle.Items(x).SubItems.Add("", Color.Black, Color.Red, Font)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lvOrderList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvOrderList.SelectedIndexChanged
        fillStyleList()
        lvOrderDetail.Items.Clear()
    End Sub

    Private Sub lvStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvStyle.SelectedIndexChanged
        fillOrderDetail()
    End Sub
    Sub fillOrderDetail()
        Try
            If lvStyle.SelectedIndices.Count > 0 Then
                lvOrderDetail.Items.Clear()
                Dim ds As New DataSet
                ds = KPGeneral.WebRef_Local.spKP_RawDoorOrderList_Detail(lvOrderList.SelectedItems.Item(0).SubItems(7).Text, lvOrderList.SelectedItems.Item(0).SubItems(4).Text, Trim(lvStyle.SelectedItems.Item(0).SubItems(0).Text))
                Dim x As Integer
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    lvOrderDetail.Items.Add(Trim(ds.Tables(0).Rows(x)("Barcode")))
                    If isOdd(x) = True Then
                        lvOrderDetail.Items.Item(x).BackColor = Color.AliceBlue
                        lvOrderDetail.Items.Item(x).ForeColor = Color.Black
                    Else
                        lvOrderDetail.Items.Item(x).BackColor = Color.White
                        lvOrderDetail.Items.Item(x).ForeColor = Color.Black
                    End If
                    lvOrderDetail.Items(x).UseItemStyleForSubItems = False
                    If IsDBNull(ds.Tables(0).Rows(x)("RawDate")) = False Then
                        lvOrderDetail.Items(x).SubItems.Add("", Color.Black, Color.Green, Font)
                    Else
                        lvOrderDetail.Items(x).SubItems.Add("", Color.Black, Color.Red, Font)
                    End If
                    If IsDBNull(ds.Tables(0).Rows(x)("PaintDate")) = False Then
                        lvOrderDetail.Items(x).SubItems.Add("", Color.Black, Color.Green, Font)
                    Else
                        lvOrderDetail.Items(x).SubItems.Add("", Color.Black, Color.Red, Font)
                    End If
                    lvOrderDetail.Items(x).SubItems.Add(Trim(ds.Tables(0).Rows(x)("SumID")))
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub selectedOrder(ByVal Barcode As String)
        Dim tBatchID, tPriority As Integer
        If lvOrderList.SelectedIndices.Count > 0 Then
            lvOrderList.Items(lvOrderList.FocusedItem.Index).Selected = False
        End If
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.spKP_RawDoorOrderList_getInfo(Barcode)
        Dim x As Integer
        For x = 0 To lvOrderList.Items.Count - 1
            If ds.Tables(0).Rows(0)("BatchID") = Int(lvOrderList.Items(x).SubItems(4).Text) And ds.Tables(0).Rows(0)("Priority") = Int(lvOrderList.Items(x).SubItems(2).Text) Then
                lvOrderList.Items(x).Selected() = True
                lvOrderList.Items(x).EnsureVisible()
                lvOrderList.Select()
                tBatchID = ds.Tables(0).Rows(0)("BatchID")
                tPriority = ds.Tables(0).Rows(0)("Priority")
                Exit For
            End If
        Next
        If lvStyle.SelectedIndices.Count > 0 Then
            lvStyle.Items(lvStyle.FocusedItem.Index).Selected = False
        End If
        For x = 0 To lvStyle.Items.Count - 1
            If ds.Tables(0).Rows(0)("Style") = lvStyle.Items(x).Text Then
                lvStyle.Items(x).Selected() = True
                lvStyle.Items(x).EnsureVisible()
                lvStyle.Select()
                Exit For
            End If
        Next
        If lvOrderDetail.SelectedIndices.Count > 0 Then
            lvOrderDetail.Items(lvOrderDetail.FocusedItem.Index).Selected = False
        End If
        For x = 0 To lvOrderDetail.Items.Count - 1
            If Barcode = lvOrderDetail.Items(x).Text Then
                lvOrderDetail.Items(x).Selected() = True
                lvOrderDetail.Items(x).EnsureVisible()
                lvOrderDetail.Select()
                lvOrderDetail.Items(x).SubItems(1).BackColor = Color.Green
                KPGeneral.WebRef_Local.spKP_RawDoorOrderList_getNotDone(tBatchID, tPriority) 'WebService
                Exit For
            End If
        Next
    End Sub

    Private Sub frmProcessScanAssembly_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillColourList()

        KPGeneral.SetDefaultGridSettings(ugDoorsNeeded)
        KPGeneral.SetDefaultGridSettings(ugMissingDoors)
        KPGeneral.SetDefaultGridSettings(ugNoSum)
        '   KPGeneral.SetDefaultGridSettings(ugRejected)
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvOrderDetail.SelectedIndices.Count > 0 Then
            Dim ncsid As Integer
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.spKP_LotInfoByFK(KPGeneral.ExtractMasterNum(Trim(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(0)).Text)))
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    ncsid = ds.Tables(0).Rows(0)("CSID")
                    KPGeneral.CreateDoorListXML(Convert.ToInt32(ncsid), Nothing, Nothing, -1, Nothing)

                    Dim rptName As New RptDoorList
                    Dim rpt As New RptViewer(1, rptName)
                    rpt.ShowDialog()
                Else
                    MessageBox.Show("Unable to load Door List: Contact Administrator.")
                End If
            Else
                MessageBox.Show("Unable to load Door List: Contact Administrator.")
            End If
        Else
            MessageBox.Show("Invalid Selection: Cannot Display Door List.")
        End If
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If lvOrderDetail.SelectedIndices.Count > 0 Then
            KPGeneral.ViewKitchenTrackerByMasterNum(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(0)).Text)
        Else
            MessageBox.Show("Invalid Selection: Cannot Display Door List.")
        End If
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        If lvOrderDetail.SelectedIndices.Count > 0 Then
            Dim x As String
            x = Trim(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(0)).Text)
            Clipboard.SetDataObject(x)
        Else
            MessageBox.Show("Invalid Selection: Cannot Copy Barcode")
        End If
    End Sub

    Private Sub LogMissingDoorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogMissingDoorsToolStripMenuItem.Click
        Try
            Dim frm As New frmPaintMissingDoors(lvScan.SelectedItems(0).SubItems(1).Text, "RAW")
            frm.ShowDialog()

            'RefreshMissingList()
        Catch ex As Exception

        End Try
    End Sub


    'Private Sub FillcbColour()

    '    Dim dscolour As New DataSet
    '    dscolour = KPGeneral.WebRef_Local.spKP_getAllColoursPaintShop

    '    cbColour.DataSource = dscolour


    '    Dim y As Integer
    '    For y = 0 To cbColour.DisplayLayout.Bands(0).Columns.Count - 1
    '        If cbColour.DisplayLayout.Bands(0).Columns(y).Header.Caption <> "Color" Then
    '            cbColour.DisplayLayout.Bands(0).Columns(y).Hidden = True
    '        Else
    '            cbColour.DisplayLayout.Bands(0).Columns(y).Hidden = False
    '        End If
    '    Next

    '    cbColour.DisplayLayout.Bands(0).Columns("Color").Width = cbColour.Width
    '    cbColour.DisplayMember = "Color"

    'End Sub



    'Private Sub cbColour_ItemNotInList(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs)
    '    If cbColour.Text.Length = 0 Then
    '        e.RetainFocus = False
    '    Else
    '        e.RetainFocus = True
    '    End If
    'End Sub

    'Private Sub cbReason_ItemNotInList(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs)
    '    If cbReason.Text.Length = 0 Then
    '        e.RetainFocus = False
    '    Else
    '        e.RetainFocus = True
    '    End If
    'End Sub

    'Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
    '    If TabControl1.SelectedTab.Name = "Assembled" Then
    '        fillColourList()
    '    ElseIf TabControl1.SelectedTab.Name = "Rejected" Then
    '        FillcbColour()

    '        Dim dsReason As New DataSet
    '        dsReason = KPGeneral.WebRef_Local.usp_GetDoorOrderReasonList()
    '        cbReason.DataSource = dsReason.Tables(0)
    '        cbReason.DisplayMember = "OrderReason"
    '        cbReason.ValueMember = "ID"
    '        cbReason.DisplayLayout.Bands(0).Columns("ID").Hidden = True

    '        Dim ds As New DataSet
    '        ds = KPGeneral.WebRef_Local.spKPFactory_RejectedDoorsCurrentDay(Date.Now)
    '        ugRejected.DataSource = ds
    '        ugRejected.DisplayLayout.Bands(0).Columns("ID").Hidden = True

    '        'cbColour.DataSource = Nothing
    '        'cbColour.Text = Nothing
    '        txtQty.Text = Nothing
    '        cbReason.Text = Nothing
    '    ElseIf TabControl1.SelectedTab.Name = "nosum" Then
    '        FillUGNoSum()
    '    ElseIf TabControl1.SelectedTab.Name = "Missing" Then
    '        RefreshMissingList()
    '    ElseIf TabControl1.SelectedTab.Name = "Needed" Then
    '        RefreshDoorsNeeded()
    '    End If
    'End Sub


    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim colour, reason, dept As String
    '    Dim qty As Integer

    '    dept = KPGeneral.User.UserProfile("UserLoginName")

    '    If cbColour.Text.Length > 0 Then
    '        colour = cbColour.Text
    '    Else
    '        colour = "N/A"
    '    End If

    '    If txtQty.Text.Length > 0 Then
    '        If IsNumeric(txtQty.Text) Then
    '            qty = txtQty.Text
    '        Else
    '            MsgBox("Please enter a valid number for qty", MsgBoxStyle.OkOnly, "KPFactory")
    '            Exit Sub
    '        End If

    '    Else
    '        MsgBox("Please enter a valid qty and try again", MsgBoxStyle.OkOnly, "KPFactory")
    '        Exit Sub
    '    End If

    '    If cbReason.Text.Length > 0 Then
    '        reason = cbReason.Text
    '    Else
    '        MsgBox("Please select a valid reason and try again", MsgBoxStyle.OkOnly, "KPFactory")
    '        Exit Sub
    '    End If

    '    KPGeneral.WebRef_Local.spKPFactory_InsertRejectedDoors(dept, colour, qty, reason)

    '    Dim ds As New DataSet
    '    ds = KPGeneral.WebRef_Local.spKPFactory_RejectedDoorsCurrentDay(Date.Now)
    '    ugRejected.DataSource = ds
    '    ugRejected.DisplayLayout.Bands(0).Columns("ID").Hidden = True

    '    'cbColour.DataSource = Nothing
    '    cbColour.Text = Nothing
    '    txtQty.Text = Nothing
    '    cbReason.Text = Nothing
    'End Sub

    'Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FDate = dtFDate.Value
    '    TDate = dtTDate.Value

    '    'Dim reportNumber As Integer = 135
    '    'Dim rptName As New rptRejectedDoors
    '    'Call Report135()
    '    'Dim rpt As New RptViewer(1, rptName)
    '    'rpt.ShowDialog()
    '    'rpt.Dispose()

    '    ReportsEngine.ReportOptions.FDate = FDate
    '    ReportsEngine.ReportOptions.TDate = TDate
    '    ReportsEngine.ReportOptions.PrintOption = 1
    '    ReportsEngine.SelectedReport(135)
    'End Sub
    Private Sub Report135()
        Try
            Dim dsrejected As New DataSet
            dsrejected = KPGeneral.WebRef_Local.spKP_GetRejectedDoorsByDateRange(FDate.Date, TDate.Date)

            Dim dsTime As New DataSet
            Dim dr1 As DataRow
            dsTime.Tables.Add("Time")
            dsTime.Tables("Time").Columns.Add("FromDate", System.Type.GetType("System.DateTime"))
            dsTime.Tables("Time").Columns.Add("ToDate", System.Type.GetType("System.DateTime"))
            dr1 = dsTime.Tables("Time").NewRow
            dr1.Item("FromDate") = FDate.Date
            dr1.Item("ToDate") = TDate.Date
            dsTime.Tables("Time").Rows.Add(dr1)
            dsrejected.Tables.Add(dsTime.Tables("Time").Copy)
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub FillUGNoSum()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.spKP_RawDoorOrderListNoSummary()
        ugNoSum.DataSource = ds
        ugNoSum.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        ugNoSum.DisplayLayout.Bands(0).Columns("SumID").Hidden = True
        ugNoSum.DisplayLayout.Bands(0).Columns("CSID").Hidden = True

        ugNoSum.DisplayLayout.Bands(0).Columns("Barcode").Header.VisiblePosition = 0
        ugNoSum.DisplayLayout.Bands(0).Columns("Style").Header.VisiblePosition = 1
        ugNoSum.DisplayLayout.Bands(0).Columns("Colour").Header.VisiblePosition = 2
        ugNoSum.DisplayLayout.Bands(0).Columns("DoorCount").Header.VisiblePosition = 3


        ugNoSum.DisplayLayout.Bands(0).Columns("Barcode").Width = 200
        ugNoSum.DisplayLayout.Bands(0).Columns("Style").Width = 200
        ugNoSum.DisplayLayout.Bands(0).Columns("Colour").Width = 200
    End Sub

    Private Sub ViewDoorListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ugNoSum.ActiveRow.Index > -1 Then
            Dim ncsid As Integer
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.spKP_LotInfoByFK(KPGeneral.ExtractMasterNum(Trim(ugNoSum.ActiveRow.Cells("Barcode").Text)))
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    ncsid = ds.Tables(0).Rows(0)("CSID")
                    Dim dsDoorList As New DataSet
                    dsDoorList = KPGeneral.CreateDoorListXML(Convert.ToInt32(ncsid), Nothing, Nothing, -1, Nothing)

                    Dim rptName As New RptNewDoorList
                    rptName.SetDataSource(dsDoorList)
                    Dim rpt As New RptViewer(1, rptName)
                    rpt.ShowDialog()
                Else
                    MessageBox.Show("Unable to load Door List: Contact Administrator.")
                End If
            Else
                MessageBox.Show("Unable to load Door List: Contact Administrator.")
            End If
        Else
            MessageBox.Show("Invalid Selection: Cannot Display Door List.")
        End If
    End Sub

    Private Sub KitchenTrackerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KitchenTrackerToolStripMenuItem.Click
        If ugNoSum.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByMasterNum(ugNoSum.ActiveRow.Cells("Barcode").Text)
        Else
            MessageBox.Show("Invalid Selection: Cannot Display Kitchen Tracker.")
        End If
    End Sub

    Private Sub CopyBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyBarcodeToolStripMenuItem.Click
        If ugNoSum.ActiveRow.Index > -1 Then
            Dim x As String
            x = Trim(ugNoSum.ActiveRow.Cells("Barcode").Text)
            Clipboard.SetDataObject(x)
        Else
            MessageBox.Show("Invalid Selection: Cannot Copy Barcode")
        End If
    End Sub

    Private Sub RefreshListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshListToolStripMenuItem.Click
        FillUGNoSum()
    End Sub


    Private Sub MenuItem5_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem5.Click

        Dim i As Integer

        For i = 0 To lvOrderDetail.SelectedIndices.Count - 1

            KPGeneral.WebRef_Local.spKPFactory_RawDoors_UpdateScan_AddWarehouse(Now, Trim(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(i)).Text), Trim(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(i)).SubItems(3).Text))

        Next

        RefreshList()

        fillColourList()
        lvStyle.Items.Clear()
        lvOrderDetail.Items.Clear()
    End Sub
    Private Sub RefreshMissingList()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetDoorMissingList

        ugMissingDoors.DataSource = ds

        ugMissingDoors.DisplayLayout.Bands(0).Columns("DoorMissingListID").Hidden = True
    End Sub
    Private Sub CloseItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseItemToolStripMenuItem.Click
        If ugMissingDoors.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugMissingDoors.Selected.Rows.Count - 1
                KPGeneral.WebRef_Local.usp_UpdateDoorMissingList(KPGeneral.User.UserProfile("UserLoginName"), ugMissingDoors.Selected.Rows(x).Cells("DoorMissingListID").Text)
            Next

            RefreshMissingList()
        End If
    End Sub

    Private Sub PrintOrderListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintOrderListToolStripMenuItem.Click
        If lvOrderList.SelectedIndices.Count > 0 Then
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.spKP_DoorOrderList_Detail_ForReport(lvOrderList.SelectedItems.Item(0).SubItems(7).Text, lvOrderList.SelectedItems.Item(0).SubItems(4).Text)

            ds.Tables.Add("Info")

            ds.Tables("Info").Columns.Add("Colour", System.Type.GetType("System.String"))
            ds.Tables("Info").Columns.Add("BatchWeek", System.Type.GetType("System.DateTime"))

            Dim dr As DataRow
            dr = ds.Tables("Info").NewRow
            dr.Item("Colour") = lvOrderList.SelectedItems.Item(0).SubItems(0).Text
            dr.Item("BatchWeek") = lvOrderList.SelectedItems.Item(0).SubItems(5).Text
            ds.Tables("Info").Rows.Add(dr)

            'dsStyle.Tables.Add(dsTime.Tables("Info").Copy)

            '    ds.WriteXml("c:\XML\kpro.xml", XmlWriteMode.WriteSchema)

            Dim rptName As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptName = New rptRawPaintOrders
            rptName.SetDataSource(ds)
            Dim rpt As New RptViewer(1, rptName)
            rpt.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        End If
    End Sub
    Public Shared Function CreateDoorListXML(ByVal CSID As Integer, ByVal Type As String, ByVal SKNo As String, ByVal SampleID As Integer) As DataSet

        Dim dsDDR As DataSet
        Dim tempDS As New DataSet

        Try

            ' Get Door Drawer List Main
            ' ========================================================
            dsDDR = New DataSet
            dsDDR = KPGeneral.WebRef_Local.spKP_GetDoorDrawerList(CSID, SKNo)

            tempDS.Tables.Add(dsDDR.Tables(0).Copy)
            dsDDR.Dispose()

            dsDDR = New DataSet
            dsDDR = KPGeneral.WebRef_Local.spKP_getDoorDrawerListSpecialCutImage(CSID, SKNo)
            tempDS.Tables.Add(dsDDR.Tables(0).Copy)
            dsDDR.Dispose()
            '' Get Special Door Sizes
            '' ========================================================
            'dsDDR = New DataSet
            'dsDDR = global.WebRef_KPro.spKP_GetDoorDrawerListSpecialDoor(global.SessionID, CSID, SKNo)

            'tempDS.Tables.Add(dsDDR.Tables(0).Copy)
            'dsDDR.Dispose()


            '' Get Special Drawer Sizes
            '' ========================================================
            'dsDDR = New DataSet
            'dsDDR = global.WebRef_KPro.spKP_GetDoorDrawerListSpecialDrawer(global.SessionID, CSID, SKNo)

            'tempDS.Tables.Add(dsDDR.Tables(0).Copy)
            'dsDDR.Dispose()


            '' Get Special Door Cuts
            '' ========================================================
            'dsDDR = New DataSet
            'dsDDR = global.WebRef_KPro.spKP_GetDoorDrawerListSpecialCuts(global.SessionID, CSID, SKNo)

            'tempDS.Tables.Add(dsDDR.Tables(0).Copy)
            'dsDDR.Dispose()

            ' Get Room Info
            ' ========================================================
            Dim dsRoomInfo As New DataSet
            dsRoomInfo = KPGeneral.WebRef_Local.spKP_RoomInfo(CSID)
            If SKNo = Nothing Then
                tempDS.Tables.Add(dsRoomInfo.Tables(0).Copy)
            Else
                Dim dtRoom As New DataTable
                dtRoom = dsRoomInfo.Tables(0).Copy
                Dim xt As Integer
                For xt = 0 To dtRoom.Rows.Count
                    If tempDS.Tables(0).Rows.Count > 0 Then
                        If dtRoom.Rows.Count > xt Then
                            If dtRoom.Rows(xt)("Rooms") <> tempDS.Tables(0).Rows(0)("Room") Or dtRoom.Rows(xt)("Style") <> tempDS.Tables(0).Rows(0)("Style") Then
                                dtRoom.Rows.RemoveAt(xt)
                                xt = xt - 1
                            End If
                        End If
                    Else
                        If dtRoom.Rows(xt)("Rooms") <> tempDS.Tables(0).Rows(1)("Room") Or dtRoom.Rows(xt)("Style") <> tempDS.Tables(0).Rows(0)("Style") Then
                            dtRoom.Rows.RemoveAt(xt)
                            xt = xt - 1
                        End If
                    End If
                Next
                tempDS.Tables.Add(dtRoom)

                Dim dsDeficiency As New DataSet
                dsDeficiency = KPGeneral.WebRef_Local.usp_GetPartsInfoForDoorListBySKNo(SKNo)

                tempDS.Tables.Add(dsDeficiency.Tables(0).Copy)

                Dim dsDoorReason As New DataSet
                dsDoorReason = KPGeneral.WebRef_Local.usp_GetDoorReasonsForDoorListBySKNo(SKNo)

                tempDS.Tables.Add(dsDoorReason.Tables(0).Copy)

            End If


            Dim dt As New DataTable
            Dim dr As DataRow
            dt.Columns.Add("SKNo", System.Type.GetType("System.String"))
            dt.Columns.Add("PONo", System.Type.GetType("System.String"))

            dr = dt.NewRow
            dr(0) = SKNo
            If tempDS.Tables(0).Rows.Count > 0 Then
                dr(1) = tempDS.Tables(0).Rows(0)("OrderRefNo")
            End If
            dt.Rows.Add(dr)
            tempDS.Tables.Add(dt.Copy)
            Return tempDS

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
        Return Nothing
    End Function

    Private Sub MenuItem2_Click_1(sender As Object, e As EventArgs) Handles MenuItem2.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim x As String
            x = KPGeneral.ExtractMasterNum(Trim(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(0)).Text))

            Dim bSplit() As String = Split(Trim(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(0)).Text), "-")

            Dim StyleCode As String
            Dim ColourCode As String

            StyleCode = bSplit(bSplit.Length - 2)
            ColourCode = bSplit(bSplit.Length - 1)

            Dim dsCSID As New DataSet
            dsCSID = KPGeneral.WebRef_Local.getCSIDByMasterNo(x)

            If dsCSID.Tables(0).Rows.Count > 0 Then
                'Dim rptName As New RptNewDoorList
                Dim rptName As New RptNewDoorListNew
                rptName.SetDataSource(CreateDoorListXML(dsCSID.Tables(0).Rows(0)("CSID"), Nothing, Nothing, -1))
                'rptName.SetDataSource(DoorListDS)
                rptName.SetParameterValue("StyleShortCode", StyleCode)
                rptName.SetParameterValue("ColourShortCode", ColourCode)

                Dim rpt As New RptViewer(1, rptName)
                rpt.ShowDialog()
                rpt.Close()
                rpt.Dispose()
            End If


        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PauseRefresh = PauseRefresh + 1
        If PauseRefresh > 10 Then
            fillColourList()
            Timer1.Stop()
        End If
    End Sub
    Private Sub RefreshDoorsNeeded()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_SiteRequest_Batch_DoorsPicked_NotRaw

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

    Private Sub ViewDoorStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDoorStatusToolStripMenuItem.Click
        If ugDoorsNeeded.ActiveRow Is Nothing Then
            Return
        End If

        If ugDoorsNeeded.ActiveRow.Index > -1 Then
            KPGeneral.ViewDoorStatusByCSID(ugDoorsNeeded.ActiveRow.Cells("CSID").Text)
        Else
            MsgBox("Please select a row to view", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
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
End Class
