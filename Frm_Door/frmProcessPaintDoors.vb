Imports System.Drawing.Drawing2D
Imports System.Net.Mail
Imports Pabo.Calendar

Public Class frmProcessPaintDoors
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents txtTotalDoors As System.Windows.Forms.TextBox
    Friend WithEvents lblDoorSummaryColour As System.Windows.Forms.Label
    Friend WithEvents lblScan As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lvScan As System.Windows.Forms.ListView
    Friend WithEvents lblClickScan As System.Windows.Forms.Label
    Friend WithEvents lblErrorMsg As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lvOrderDetail As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvStyle As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvOrderList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMissingDoors As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LogMissingDoorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents DoorScan As System.Windows.Forms.TabPage
    Friend WithEvents Missing As System.Windows.Forms.TabPage
    Friend WithEvents ugMissingDoors As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents mngClearMissingDoors As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CloseItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuColour As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrintOrderListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PrintBatchListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Needed As System.Windows.Forms.TabPage
    Friend WithEvents ugDoorsNeeded As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewDoorStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Dim PauseRefresh As Integer
    Friend WithEvents Schedule As System.Windows.Forms.TabPage
    Friend WithEvents ugSchedule As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents mnuSchedule As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGridFilterUIProvider1 As Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider
    Friend WithEvents MonthCalendar2 As Pabo.Calendar.MonthCalendar
    Friend WithEvents MonthCalendar1 As Pabo.Calendar.MonthCalendar
    Friend WithEvents UltraButton1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnToday As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSelectedDate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSelectedDoors As System.Windows.Forms.TextBox
    Friend WithEvents txtSelectedOrders As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public Shared AssignedPaintDate As DateTime
    Dim LoadCalendarInfo As Boolean = False
    Dim db As New DB
    Dim dsMonth1 As DataSet
    Dim dsMonth2 As DataSet
    Dim dsHoliday1 As DataSet
    Dim dsHoliday2 As DataSet
    Friend WithEvents ScheduleForPaintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCalendar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewOrdersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearSelectedScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents uoCCI As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents Timer2 As Timer
    Dim FormLoaded As Boolean = False
    Dim T As Integer


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcessPaintDoors))
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
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtTotalDoors = New System.Windows.Forms.TextBox()
        Me.lblDoorSummaryColour = New System.Windows.Forms.Label()
        Me.lblScan = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lvScan = New System.Windows.Forms.ListView()
        Me.lblClickScan = New System.Windows.Forms.Label()
        Me.lblErrorMsg = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lvOrderDetail = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.lvStyle = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvOrderList = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuColour = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrintOrderListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintBatchListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMissingDoors = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LogMissingDoorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.DoorScan = New System.Windows.Forms.TabPage()
        Me.uoCCI = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
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
        Me.Schedule = New System.Windows.Forms.TabPage()
        Me.UltraButton1 = New Infragistics.Win.Misc.UltraButton()
        Me.btnToday = New Infragistics.Win.Misc.UltraButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSelectedDate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSelectedDoors = New System.Windows.Forms.TextBox()
        Me.txtSelectedOrders = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MonthCalendar2 = New Pabo.Calendar.MonthCalendar()
        Me.mnuCalendar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonthCalendar1 = New Pabo.Calendar.MonthCalendar()
        Me.ugSchedule = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.mnuSchedule = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScheduleForPaintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearSelectedScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGridFilterUIProvider1 = New Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.mnuColour.SuspendLayout()
        Me.mnuMissingDoors.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.DoorScan.SuspendLayout()
        CType(Me.uoCCI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Missing.SuspendLayout()
        CType(Me.ugMissingDoors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mngClearMissingDoors.SuspendLayout()
        Me.Needed.SuspendLayout()
        CType(Me.ugDoorsNeeded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.Schedule.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.mnuCalendar.SuspendLayout()
        CType(Me.ugSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuSchedule.SuspendLayout()
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
        'txtTotalDoors
        '
        Me.txtTotalDoors.BackColor = System.Drawing.Color.White
        Me.txtTotalDoors.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDoors.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDoors.Location = New System.Drawing.Point(980, -5)
        Me.txtTotalDoors.Name = "txtTotalDoors"
        Me.txtTotalDoors.ReadOnly = True
        Me.txtTotalDoors.Size = New System.Drawing.Size(104, 39)
        Me.txtTotalDoors.TabIndex = 34
        Me.txtTotalDoors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDoorSummaryColour
        '
        Me.lblDoorSummaryColour.BackColor = System.Drawing.Color.Gainsboro
        Me.lblDoorSummaryColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDoorSummaryColour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoorSummaryColour.Location = New System.Drawing.Point(6, 304)
        Me.lblDoorSummaryColour.Name = "lblDoorSummaryColour"
        Me.lblDoorSummaryColour.Size = New System.Drawing.Size(1032, 24)
        Me.lblDoorSummaryColour.TabIndex = 32
        Me.lblDoorSummaryColour.Text = "ORDER SUMMARIES"
        Me.lblDoorSummaryColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblScan
        '
        Me.lblScan.BackColor = System.Drawing.Color.Gainsboro
        Me.lblScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScan.Location = New System.Drawing.Point(6, 36)
        Me.lblScan.Name = "lblScan"
        Me.lblScan.Size = New System.Drawing.Size(1032, 23)
        Me.lblScan.TabIndex = 31
        Me.lblScan.Text = "DOORS PAINTED/FINISHED TODAY"
        Me.lblScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.Gainsboro
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(8, 38)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(88, 19)
        Me.btnRefresh.TabIndex = 30
        Me.btnRefresh.Text = "Refresh List"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'lvScan
        '
        Me.lvScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvScan.FullRowSelect = True
        Me.lvScan.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvScan.HideSelection = False
        Me.lvScan.Location = New System.Drawing.Point(6, 60)
        Me.lvScan.MultiSelect = False
        Me.lvScan.Name = "lvScan"
        Me.lvScan.Size = New System.Drawing.Size(1032, 244)
        Me.lvScan.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lvScan.TabIndex = 28
        Me.lvScan.UseCompatibleStateImageBehavior = False
        Me.lvScan.View = System.Windows.Forms.View.Details
        '
        'lblClickScan
        '
        Me.lblClickScan.BackColor = System.Drawing.Color.Transparent
        Me.lblClickScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClickScan.Location = New System.Drawing.Point(42, 12)
        Me.lblClickScan.Name = "lblClickScan"
        Me.lblClickScan.Size = New System.Drawing.Size(144, 12)
        Me.lblClickScan.TabIndex = 27
        Me.lblClickScan.Text = "CLICK HERE TO SCAN"
        '
        'lblErrorMsg
        '
        Me.lblErrorMsg.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorMsg.Location = New System.Drawing.Point(490, 8)
        Me.lblErrorMsg.Name = "lblErrorMsg"
        Me.lblErrorMsg.Size = New System.Drawing.Size(208, 23)
        Me.lblErrorMsg.TabIndex = 26
        '
        'txtBarcode
        '
        Me.txtBarcode.CausesValidation = False
        Me.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(185, 8)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(288, 20)
        Me.txtBarcode.TabIndex = 1
        Me.txtBarcode.WordWrap = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.DarkBlue
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1271, 32)
        Me.lblTitle.TabIndex = 37
        Me.lblTitle.Text = "DOORS COMPLETED"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lvOrderDetail
        '
        Me.lvOrderDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvOrderDetail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader6, Me.ColumnHeader8, Me.ColumnHeader12, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader21})
        Me.lvOrderDetail.ContextMenu = Me.ContextMenu1
        Me.lvOrderDetail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvOrderDetail.GridLines = True
        Me.lvOrderDetail.HideSelection = False
        Me.lvOrderDetail.Location = New System.Drawing.Point(1044, 36)
        Me.lvOrderDetail.Name = "lvOrderDetail"
        Me.lvOrderDetail.Size = New System.Drawing.Size(436, 518)
        Me.lvOrderDetail.TabIndex = 41
        Me.lvOrderDetail.UseCompatibleStateImageBehavior = False
        Me.lvOrderDetail.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = ""
        Me.ColumnHeader7.Width = 136
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "R"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 30
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "P"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 30
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "H"
        Me.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader12.Width = 30
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "EXP Ship"
        Me.ColumnHeader18.Width = 75
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Site Request"
        Me.ColumnHeader19.Width = 94
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = ""
        Me.ColumnHeader21.Width = 0
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem1, Me.MenuItem3, Me.MenuItem4, Me.MenuItem5, Me.MenuItem6})
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Kitchen Tracker"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.Text = "View Door List"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "-"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.Text = "Copy Barcode"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 4
        Me.MenuItem5.Text = "Mark as Complete"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 5
        Me.MenuItem6.Text = "Add to Schedule"
        '
        'lvStyle
        '
        Me.lvStyle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvStyle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader10})
        Me.lvStyle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvStyle.GridLines = True
        Me.lvStyle.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvStyle.HideSelection = False
        Me.lvStyle.Location = New System.Drawing.Point(492, 328)
        Me.lvStyle.Name = "lvStyle"
        Me.lvStyle.Size = New System.Drawing.Size(352, 226)
        Me.lvStyle.TabIndex = 43
        Me.lvStyle.UseCompatibleStateImageBehavior = False
        Me.lvStyle.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Style"
        Me.ColumnHeader5.Width = 141
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "#DL"
        Me.ColumnHeader15.Width = 44
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "QTY"
        Me.ColumnHeader16.Width = 57
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "SQM"
        Me.ColumnHeader17.Width = 70
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = ""
        Me.ColumnHeader10.Width = 24
        '
        'lvOrderList
        '
        Me.lvOrderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvOrderList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader1, Me.ColumnHeader11, Me.ColumnHeader4, Me.ColumnHeader9, Me.ColumnHeader20})
        Me.lvOrderList.ContextMenuStrip = Me.mnuColour
        Me.lvOrderList.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvOrderList.GridLines = True
        Me.lvOrderList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvOrderList.HideSelection = False
        Me.lvOrderList.Location = New System.Drawing.Point(6, 328)
        Me.lvOrderList.Name = "lvOrderList"
        Me.lvOrderList.Size = New System.Drawing.Size(490, 226)
        Me.lvOrderList.TabIndex = 42
        Me.lvOrderList.UseCompatibleStateImageBehavior = False
        Me.lvOrderList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Colour"
        Me.ColumnHeader2.Width = 170
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "#ST"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 40
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "#DL"
        Me.ColumnHeader13.Width = 45
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "SQM"
        Me.ColumnHeader14.Width = 70
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Batch Week"
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader11.Width = 89
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "BID"
        Me.ColumnHeader4.Width = 50
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = ""
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Width = 0
        '
        'mnuColour
        '
        Me.mnuColour.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintOrderListToolStripMenuItem, Me.PrintBatchListToolStripMenuItem})
        Me.mnuColour.Name = "mnuColour"
        Me.mnuColour.Size = New System.Drawing.Size(163, 48)
        '
        'PrintOrderListToolStripMenuItem
        '
        Me.PrintOrderListToolStripMenuItem.Name = "PrintOrderListToolStripMenuItem"
        Me.PrintOrderListToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.PrintOrderListToolStripMenuItem.Text = "Print Order List"
        '
        'PrintBatchListToolStripMenuItem
        '
        Me.PrintBatchListToolStripMenuItem.Name = "PrintBatchListToolStripMenuItem"
        Me.PrintBatchListToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.PrintBatchListToolStripMenuItem.Text = "Print Batch BOM"
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
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.DoorScan)
        Me.TabControl1.Controls.Add(Me.Missing)
        Me.TabControl1.Controls.Add(Me.Needed)
        Me.TabControl1.Controls.Add(Me.Schedule)
        Me.TabControl1.Location = New System.Drawing.Point(4, 35)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1496, 586)
        Me.TabControl1.TabIndex = 44
        '
        'DoorScan
        '
        Me.DoorScan.Controls.Add(Me.uoCCI)
        Me.DoorScan.Controls.Add(Me.txtBarcode)
        Me.DoorScan.Controls.Add(Me.lblClickScan)
        Me.DoorScan.Controls.Add(Me.lvStyle)
        Me.DoorScan.Controls.Add(Me.lblErrorMsg)
        Me.DoorScan.Controls.Add(Me.lvOrderList)
        Me.DoorScan.Controls.Add(Me.lvScan)
        Me.DoorScan.Controls.Add(Me.lvOrderDetail)
        Me.DoorScan.Controls.Add(Me.btnRefresh)
        Me.DoorScan.Controls.Add(Me.lblDoorSummaryColour)
        Me.DoorScan.Controls.Add(Me.lblScan)
        Me.DoorScan.Location = New System.Drawing.Point(4, 22)
        Me.DoorScan.Name = "DoorScan"
        Me.DoorScan.Padding = New System.Windows.Forms.Padding(3)
        Me.DoorScan.Size = New System.Drawing.Size(1488, 560)
        Me.DoorScan.TabIndex = 0
        Me.DoorScan.Text = "Door Scan"
        Me.DoorScan.UseVisualStyleBackColor = True
        '
        'uoCCI
        '
        Appearance1.FontData.SizeInPoints = 12.0!
        Me.uoCCI.Appearance = Appearance1
        Me.uoCCI.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uoCCI.Location = New System.Drawing.Point(625, 3)
        Me.uoCCI.Name = "uoCCI"
        Me.uoCCI.Size = New System.Drawing.Size(798, 27)
        Me.uoCCI.TabIndex = 44
        '
        'Missing
        '
        Me.Missing.Controls.Add(Me.ugMissingDoors)
        Me.Missing.Location = New System.Drawing.Point(4, 22)
        Me.Missing.Name = "Missing"
        Me.Missing.Padding = New System.Windows.Forms.Padding(3)
        Me.Missing.Size = New System.Drawing.Size(1488, 560)
        Me.Missing.TabIndex = 1
        Me.Missing.Text = "Missing Doors"
        Me.Missing.UseVisualStyleBackColor = True
        '
        'ugMissingDoors
        '
        Me.ugMissingDoors.ContextMenuStrip = Me.mngClearMissingDoors
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugMissingDoors.DisplayLayout.Appearance = Appearance2
        Me.ugMissingDoors.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugMissingDoors.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.ugMissingDoors.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugMissingDoors.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.ugMissingDoors.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugMissingDoors.DisplayLayout.GroupByBox.Hidden = True
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugMissingDoors.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.ugMissingDoors.DisplayLayout.MaxColScrollRegions = 1
        Me.ugMissingDoors.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugMissingDoors.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugMissingDoors.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.ugMissingDoors.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugMissingDoors.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugMissingDoors.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugMissingDoors.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugMissingDoors.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugMissingDoors.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugMissingDoors.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.ugMissingDoors.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugMissingDoors.DisplayLayout.Override.CellAppearance = Appearance9
        Me.ugMissingDoors.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugMissingDoors.DisplayLayout.Override.CellPadding = 0
        Me.ugMissingDoors.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugMissingDoors.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.ugMissingDoors.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugMissingDoors.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugMissingDoors.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugMissingDoors.DisplayLayout.Override.RowAppearance = Appearance12
        Me.ugMissingDoors.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugMissingDoors.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugMissingDoors.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugMissingDoors.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugMissingDoors.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugMissingDoors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugMissingDoors.Location = New System.Drawing.Point(3, 3)
        Me.ugMissingDoors.Name = "ugMissingDoors"
        Me.ugMissingDoors.Size = New System.Drawing.Size(1482, 554)
        Me.ugMissingDoors.TabIndex = 1
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
        Me.Needed.Size = New System.Drawing.Size(1488, 560)
        Me.Needed.TabIndex = 2
        Me.Needed.Text = "Doors Needed"
        Me.Needed.UseVisualStyleBackColor = True
        '
        'ugDoorsNeeded
        '
        Me.ugDoorsNeeded.ContextMenuStrip = Me.ContextMenuStrip3
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDoorsNeeded.DisplayLayout.Appearance = Appearance14
        Me.ugDoorsNeeded.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDoorsNeeded.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDoorsNeeded.DisplayLayout.GroupByBox.Appearance = Appearance15
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDoorsNeeded.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance16
        Me.ugDoorsNeeded.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDoorsNeeded.DisplayLayout.GroupByBox.Hidden = True
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance17.BackColor2 = System.Drawing.SystemColors.Control
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDoorsNeeded.DisplayLayout.GroupByBox.PromptAppearance = Appearance17
        Me.ugDoorsNeeded.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDoorsNeeded.DisplayLayout.MaxRowScrollRegions = 1
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDoorsNeeded.DisplayLayout.Override.ActiveCellAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.SystemColors.Highlight
        Appearance19.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDoorsNeeded.DisplayLayout.Override.ActiveRowAppearance = Appearance19
        Me.ugDoorsNeeded.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDoorsNeeded.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDoorsNeeded.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDoorsNeeded.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDoorsNeeded.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDoorsNeeded.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDoorsNeeded.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Me.ugDoorsNeeded.DisplayLayout.Override.CardAreaAppearance = Appearance20
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDoorsNeeded.DisplayLayout.Override.CellAppearance = Appearance21
        Me.ugDoorsNeeded.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugDoorsNeeded.DisplayLayout.Override.CellPadding = 0
        Me.ugDoorsNeeded.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance22.BackColor = System.Drawing.SystemColors.Control
        Appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance22.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDoorsNeeded.DisplayLayout.Override.GroupByRowAppearance = Appearance22
        Appearance23.TextHAlignAsString = "Left"
        Me.ugDoorsNeeded.DisplayLayout.Override.HeaderAppearance = Appearance23
        Me.ugDoorsNeeded.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDoorsNeeded.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Me.ugDoorsNeeded.DisplayLayout.Override.RowAppearance = Appearance24
        Me.ugDoorsNeeded.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDoorsNeeded.DisplayLayout.Override.TemplateAddRowAppearance = Appearance25
        Me.ugDoorsNeeded.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDoorsNeeded.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDoorsNeeded.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDoorsNeeded.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDoorsNeeded.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDoorsNeeded.Location = New System.Drawing.Point(0, 0)
        Me.ugDoorsNeeded.Name = "ugDoorsNeeded"
        Me.ugDoorsNeeded.Size = New System.Drawing.Size(1488, 560)
        Me.ugDoorsNeeded.TabIndex = 26
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
        'Schedule
        '
        Me.Schedule.Controls.Add(Me.UltraButton1)
        Me.Schedule.Controls.Add(Me.btnToday)
        Me.Schedule.Controls.Add(Me.GroupBox1)
        Me.Schedule.Controls.Add(Me.MonthCalendar2)
        Me.Schedule.Controls.Add(Me.MonthCalendar1)
        Me.Schedule.Controls.Add(Me.ugSchedule)
        Me.Schedule.Location = New System.Drawing.Point(4, 22)
        Me.Schedule.Name = "Schedule"
        Me.Schedule.Size = New System.Drawing.Size(1488, 560)
        Me.Schedule.TabIndex = 3
        Me.Schedule.Text = "Schedule"
        Me.Schedule.UseVisualStyleBackColor = True
        '
        'UltraButton1
        '
        Me.UltraButton1.Location = New System.Drawing.Point(1001, 154)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(75, 23)
        Me.UltraButton1.TabIndex = 21
        Me.UltraButton1.Text = "Refresh"
        '
        'btnToday
        '
        Me.btnToday.Location = New System.Drawing.Point(902, 154)
        Me.btnToday.Name = "btnToday"
        Me.btnToday.Size = New System.Drawing.Size(75, 23)
        Me.btnToday.TabIndex = 20
        Me.btnToday.Text = "Today"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSelectedDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSelectedDoors)
        Me.GroupBox1.Controls.Add(Me.txtSelectedOrders)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(902, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 135)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selection Results"
        '
        'txtSelectedDate
        '
        Me.txtSelectedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectedDate.Location = New System.Drawing.Point(7, 104)
        Me.txtSelectedDate.Name = "txtSelectedDate"
        Me.txtSelectedDate.ReadOnly = True
        Me.txtSelectedDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSelectedDate.Size = New System.Drawing.Size(153, 26)
        Me.txtSelectedDate.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Selected Date"
        '
        'txtSelectedDoors
        '
        Me.txtSelectedDoors.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectedDoors.Location = New System.Drawing.Point(115, 45)
        Me.txtSelectedDoors.Name = "txtSelectedDoors"
        Me.txtSelectedDoors.Size = New System.Drawing.Size(53, 29)
        Me.txtSelectedDoors.TabIndex = 3
        '
        'txtSelectedOrders
        '
        Me.txtSelectedOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectedOrders.Location = New System.Drawing.Point(115, 16)
        Me.txtSelectedOrders.Name = "txtSelectedOrders"
        Me.txtSelectedOrders.Size = New System.Drawing.Size(53, 29)
        Me.txtSelectedOrders.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Selected Doors:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Selected Orders:"
        '
        'MonthCalendar2
        '
        Me.MonthCalendar2.ActiveMonth.Month = 7
        Me.MonthCalendar2.ActiveMonth.Year = 2010
        Me.MonthCalendar2.ContextMenuStrip = Me.mnuCalendar
        Me.MonthCalendar2.Culture = New System.Globalization.CultureInfo("en-US")
        Me.MonthCalendar2.FirstDayOfWeek = 2
        Me.MonthCalendar2.Footer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MonthCalendar2.Header.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MonthCalendar2.Header.MonthSelectors = False
        Me.MonthCalendar2.Header.TextColor = System.Drawing.Color.White
        Me.MonthCalendar2.ImageList = Nothing
        Me.MonthCalendar2.Location = New System.Drawing.Point(448, 3)
        Me.MonthCalendar2.MaxDate = New Date(2020, 7, 9, 12, 35, 49, 604)
        Me.MonthCalendar2.MinDate = New Date(2000, 7, 9, 12, 35, 49, 604)
        Me.MonthCalendar2.Month.BackgroundImage = Nothing
        Me.MonthCalendar2.Month.BorderStyles.Normal = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.MonthCalendar2.Month.Colors.Days.Text = System.Drawing.Color.Blue
        Me.MonthCalendar2.Month.Colors.Weekend.BackColor1 = System.Drawing.Color.Red
        Me.MonthCalendar2.Month.Colors.Weekend.Saturday = False
        Me.MonthCalendar2.Month.DateAlign = Pabo.Calendar.mcItemAlign.TopRight
        Me.MonthCalendar2.Month.DateFont = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthCalendar2.Month.TextAlign = Pabo.Calendar.mcItemAlign.BottomCenter
        Me.MonthCalendar2.Month.TextFont = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthCalendar2.Name = "MonthCalendar2"
        Me.MonthCalendar2.SelectionMode = Pabo.Calendar.mcSelectionMode.One
        Me.MonthCalendar2.Size = New System.Drawing.Size(438, 366)
        Me.MonthCalendar2.TabIndex = 3
        Me.MonthCalendar2.Weekdays.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthCalendar2.Weeknumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'mnuCalendar
        '
        Me.mnuCalendar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewOrdersToolStripMenuItem})
        Me.mnuCalendar.Name = "mnuCalendar"
        Me.mnuCalendar.Size = New System.Drawing.Size(138, 26)
        '
        'ViewOrdersToolStripMenuItem
        '
        Me.ViewOrdersToolStripMenuItem.Name = "ViewOrdersToolStripMenuItem"
        Me.ViewOrdersToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ViewOrdersToolStripMenuItem.Text = "View Orders"
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.ActiveMonth.Month = 7
        Me.MonthCalendar1.ActiveMonth.Year = 2010
        Me.MonthCalendar1.ContextMenuStrip = Me.mnuCalendar
        Me.MonthCalendar1.Culture = New System.Globalization.CultureInfo("en-US")
        Me.MonthCalendar1.FirstDayOfWeek = 2
        Me.MonthCalendar1.Footer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MonthCalendar1.Header.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MonthCalendar1.Header.TextColor = System.Drawing.Color.White
        Me.MonthCalendar1.ImageList = Nothing
        Me.MonthCalendar1.Location = New System.Drawing.Point(4, 3)
        Me.MonthCalendar1.MaxDate = New Date(2020, 7, 9, 12, 35, 49, 604)
        Me.MonthCalendar1.MinDate = New Date(2000, 7, 9, 12, 35, 49, 604)
        Me.MonthCalendar1.Month.BackgroundImage = Nothing
        Me.MonthCalendar1.Month.BorderStyles.Normal = System.Windows.Forms.ButtonBorderStyle.Solid
        Me.MonthCalendar1.Month.Colors.Days.Text = System.Drawing.Color.Blue
        Me.MonthCalendar1.Month.Colors.Weekend.BackColor1 = System.Drawing.Color.Red
        Me.MonthCalendar1.Month.Colors.Weekend.Saturday = False
        Me.MonthCalendar1.Month.DateAlign = Pabo.Calendar.mcItemAlign.TopRight
        Me.MonthCalendar1.Month.DateFont = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthCalendar1.Month.TextFont = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.SelectionMode = Pabo.Calendar.mcSelectionMode.One
        Me.MonthCalendar1.Size = New System.Drawing.Size(438, 366)
        Me.MonthCalendar1.TabIndex = 2
        Me.MonthCalendar1.Weekdays.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthCalendar1.Weeknumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'ugSchedule
        '
        Me.ugSchedule.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugSchedule.ContextMenuStrip = Me.mnuSchedule
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Appearance26.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugSchedule.DisplayLayout.Appearance = Appearance26
        Me.ugSchedule.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugSchedule.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance27.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance27.BorderColor = System.Drawing.SystemColors.Window
        Me.ugSchedule.DisplayLayout.GroupByBox.Appearance = Appearance27
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugSchedule.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance28
        Me.ugSchedule.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugSchedule.DisplayLayout.GroupByBox.Hidden = True
        Appearance29.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance29.BackColor2 = System.Drawing.SystemColors.Control
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance29.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugSchedule.DisplayLayout.GroupByBox.PromptAppearance = Appearance29
        Me.ugSchedule.DisplayLayout.MaxColScrollRegions = 1
        Me.ugSchedule.DisplayLayout.MaxRowScrollRegions = 1
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugSchedule.DisplayLayout.Override.ActiveCellAppearance = Appearance30
        Appearance31.BackColor = System.Drawing.SystemColors.Highlight
        Appearance31.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugSchedule.DisplayLayout.Override.ActiveRowAppearance = Appearance31
        Me.ugSchedule.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugSchedule.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugSchedule.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugSchedule.DisplayLayout.Override.AllowMultiCellOperations = CType((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders), Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)
        Me.ugSchedule.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugSchedule.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugSchedule.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugSchedule.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Me.ugSchedule.DisplayLayout.Override.CardAreaAppearance = Appearance32
        Appearance33.BorderColor = System.Drawing.Color.Silver
        Appearance33.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugSchedule.DisplayLayout.Override.CellAppearance = Appearance33
        Me.ugSchedule.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugSchedule.DisplayLayout.Override.CellPadding = 0
        Me.ugSchedule.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.ugSchedule.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance34.BackColor = System.Drawing.SystemColors.Control
        Appearance34.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance34.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance34.BorderColor = System.Drawing.SystemColors.Window
        Me.ugSchedule.DisplayLayout.Override.GroupByRowAppearance = Appearance34
        Appearance35.TextHAlignAsString = "Left"
        Me.ugSchedule.DisplayLayout.Override.HeaderAppearance = Appearance35
        Me.ugSchedule.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugSchedule.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance36.BackColor = System.Drawing.SystemColors.Window
        Appearance36.BorderColor = System.Drawing.Color.Silver
        Me.ugSchedule.DisplayLayout.Override.RowAppearance = Appearance36
        Me.ugSchedule.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance37.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugSchedule.DisplayLayout.Override.TemplateAddRowAppearance = Appearance37
        Me.ugSchedule.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugSchedule.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugSchedule.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugSchedule.Location = New System.Drawing.Point(0, 375)
        Me.ugSchedule.Name = "ugSchedule"
        Me.ugSchedule.Size = New System.Drawing.Size(1488, 185)
        Me.ugSchedule.TabIndex = 0
        Me.ugSchedule.Text = "UltraGrid1"
        '
        'mnuSchedule
        '
        Me.mnuSchedule.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.PrintToolStripMenuItem1, Me.ScheduleForPaintToolStripMenuItem, Me.ClearSelectedScheduleToolStripMenuItem})
        Me.mnuSchedule.Name = "mnuSchedule"
        Me.mnuSchedule.Size = New System.Drawing.Size(200, 92)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'PrintToolStripMenuItem1
        '
        Me.PrintToolStripMenuItem1.Name = "PrintToolStripMenuItem1"
        Me.PrintToolStripMenuItem1.Size = New System.Drawing.Size(199, 22)
        Me.PrintToolStripMenuItem1.Text = "Print"
        '
        'ScheduleForPaintToolStripMenuItem
        '
        Me.ScheduleForPaintToolStripMenuItem.Name = "ScheduleForPaintToolStripMenuItem"
        Me.ScheduleForPaintToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ScheduleForPaintToolStripMenuItem.Text = "Schedule For Paint"
        '
        'ClearSelectedScheduleToolStripMenuItem
        '
        Me.ClearSelectedScheduleToolStripMenuItem.Name = "ClearSelectedScheduleToolStripMenuItem"
        Me.ClearSelectedScheduleToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ClearSelectedScheduleToolStripMenuItem.Text = "Clear Selected Schedule"
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
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'frmProcessPaintDoors
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1500, 633)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtTotalDoors)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProcessPaintDoors"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Painted Doors "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuColour.ResumeLayout(False)
        Me.mnuMissingDoors.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.DoorScan.ResumeLayout(False)
        Me.DoorScan.PerformLayout()
        CType(Me.uoCCI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Missing.ResumeLayout(False)
        CType(Me.ugMissingDoors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mngClearMissingDoors.ResumeLayout(False)
        Me.Needed.ResumeLayout(False)
        CType(Me.ugDoorsNeeded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.Schedule.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.mnuCalendar.ResumeLayout(False)
        CType(Me.ugSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuSchedule.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmProcessPaintDoors_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim BaseRectangle As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim Gradient_Brush As New LinearGradientBrush(BaseRectangle, Color.White, Color.DarkBlue, LinearGradientMode.Vertical) 'Gradient Degree
        e.Graphics.FillRectangle(Gradient_Brush, BaseRectangle)
    End Sub

    Private Sub frmProcessPaintDoors_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    Private Sub frmProcessPaintDoors_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        If KPGeneral.User.UserProfile("MonitorUser ") Then
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
        Fill_lvScan(KPGeneral.WebRef_Local.spKPFactory_PaintedDoors_CompletedList(Now.Date)) 'WebService
        'Fill_lvDoorsOnFloor(global.WebRef_KPFactory.spKPFactory_PaintedDoors_FloorSummary(global.SessionID)) 'WebService
        GetTotalDoors()
        'End If
        txtBarcode.Focus()
    End Sub

    Private Sub Fill_lvScan(ByVal dsScan As DataSet)
        Try
            lvScan.Clear()
            With lvScan.Columns
                .Add("", 35, HorizontalAlignment.Left) 'Spacer for Image
                .Add("Barcode", 180, HorizontalAlignment.Left)
                .Add("Style", 170, HorizontalAlignment.Left)
                .Add("Colour", 188, HorizontalAlignment.Left)
                .Add("Scan Time", 100, HorizontalAlignment.Right)
                .Add("Paint Line", 75, HorizontalAlignment.Left)
                .Add("Log ID", 75, HorizontalAlignment.Left)
                .Add("Paint Type", 188, HorizontalAlignment.Left)
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
                    .Items(i).SubItems.Add(Convert.ToString(dsScan.Tables(0).Rows(i)("Style")).Trim) '2
                    .Items(i).SubItems.Add(Convert.ToString(dsScan.Tables(0).Rows(i)("Colour")).Trim) '3
                    .Items(i).SubItems.Add(Convert.ToString(Strings.Mid(dsScan.Tables(0).Rows(i)("PaintTime").ToString, InStr(dsScan.Tables(0).Rows(i)("PaintTime").ToString, " ") + 1).Trim)) '4
                    .Items(i).SubItems.Add(Convert.ToString(dsScan.Tables(0).Rows(i)("LineNumber")).Trim) '5
                    .Items(i).SubItems.Add(Convert.ToString(dsScan.Tables(0).Rows(i)("LineLogID")).Trim) '6
                    .Items(i).SubItems.Add(Convert.ToString(dsScan.Tables(0).Rows(i)("PaintType")).Trim) '7

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

                    ' 6/17/2009 - Service Door Tracking
                    If Not IsDBNull(dsScan.Tables(0).Rows(i)("isService")) Then

                        If dsScan.Tables(0).Rows(i)("isService") = "1" Then
                            .Items.Item(i).BackColor = Color.Yellow
                        End If

                    End If


                Next
                lvScan.ContextMenuStrip = mnuMissingDoors
            End With
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

    End Sub

    Public Function isOdd(ByVal lngNumber As Long) As Boolean
        Dim blnOdd As Boolean = CLng(lngNumber) And 1
        Return blnOdd
    End Function

    Private Sub GetTotalDoors()
        Try
            txtTotalDoors.Text = KPGeneral.WebRef_Local.spKPFactory_PaintedDoors_CompletedCount(Now.Date) 'WebService
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Public Sub txtBarcode_enter(ByVal o As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                If uoCCI.CheckedIndex > -1 Then
                    e.Handled = True
                    'Enter Pressed
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
                            lblErrorMsg.Text = "Input is not a VALID FK-NUMBER"
                            txtBarcode.Text = vbNullString
                            txtBarcode.Focus()
                            Exit Sub
                        End If


                        Dim d As DataSet
                        d = KPGeneral.WebRef_Local.spKP_DoorStatusbyBarcode(dsCancelOrderCheck.Tables(0).Rows(0).Item("CSID"), BarCode, SumID)
                        Dim Style, Colour As String
                        Style = d.Tables(0).Rows(0).Item("SCode")
                        Colour = d.Tables(0).Rows(0).Item("DisplayCode")
                        If IsDBNull(d.Tables(0).Rows(0).Item("PaintDate")) = False Then ' Already Scanned
                            MessageBox.Show("Painted On " & Convert.ToDateTime(d.Tables(0).Rows(0)("PaintDate")).Date & " : " & Convert.ToDateTime(d.Tables(0).Rows(0)("PaintTime")).TimeOfDay.ToString)
                        Else
                            KPGeneral.WebRef_Local.spKPFactory_PaintedDoors_UpdateScan_AddWarehouse(Now, BarCode, SumID, uoCCI.Text)
                            KPGeneral.WebRef_Local.usp__WatchList_SendDoorsPaintedEmail(dsCancelOrderCheck.Tables(0).Rows(0).Item("CSID"), Style, Colour)
                            lblErrorMsg.Text = "OK"
                        End If

                        RefreshList()
                    End If
                    txtBarcode.Text = vbNullString
                    txtBarcode.Focus()

                    PauseRefresh = 0
                    Timer1.Start()

                    lvStyle.Items.Clear()
                    lvOrderDetail.Items.Clear()
                Else
                    MsgBox("You must select a paint type.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                End If

            End If

            'End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

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
    '        Dim Notify As Boolean = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("NotifyPaintedDoors")), String.Empty, dsWatchList.Tables(0).Rows(i)("NotifyPaintedDoors"))
    '        'Dim CSID_IN_WatchList As Integer = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("CSID")), String.Empty, dsWatchList.Tables(0).Rows(i)("CSID"))

    '        If Notify = True Then
    '            Dim value As AttachmentCollection
    '            Dim Message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("reports@frendel.com", UserEmail)
    '            Message.IsBodyHtml = True
    '            'Message.CC.Add([global].UserProfile.Tables(0).Rows(0)("UserID") & "@frendel.com")
    '            'Message.Bcc.Add("kevinl@frendel.com")
    '            Message.Subject = "Order# " & MasterNum & " - " & Company & " - " & Project & " - " & Lot & " - " & "Doors painted, Date: " & Now.ToString
    '            Message.Body = "Order#: " & MasterNum & " <br /> " _
    '                         & "Company: " & Company & " <br /> " _
    '                         & "Project: " & Project & " <br /> " _
    '                         & "Lot: " & Lot & " <br /> " _
    '                         & "Style: " & Style & " <br /> " _
    '                         & "Colour: " & Colour & " <br /> " _
    '                         & "has been painted"
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

    Private Sub frmProcessPaintDoors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MonthCalendar1.MaxDate = KPGeneral.CalendarMaxDate
        MonthCalendar2.MaxDate = KPGeneral.CalendarMaxDate
        fillColourList()
        MonthCalendar1.SelectDate(Now)
        LoadCalendarInfo = True
        FormatCalendar(MonthCalendar1.ActiveMonth.Month, MonthCalendar1.ActiveMonth.Year)
        LoadCalendarInfo = False
        Dim dt As DataTable = KPGeneral.KPDataSQL.SP_EXEC("t_GetDoorPaintType").Tables(0)
        For Each r As DataRow In dt.Rows
            Me.uoCCI.Items.Add(r(0))
        Next
        KPGeneral.SetDefaultGridSettings(ugDoorsNeeded)
        KPGeneral.SetDefaultGridSettings(ugMissingDoors)
        KPGeneral.SetDefaultGridSettings(ugSchedule)

        FormLoaded = True
    End Sub
    Sub fillColourList()
        Try

            lvOrderList.Items.Clear()
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.spKP_PaintDoorOrderList()
            Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1
                lvOrderList.Items.Add(ds.Tables(0).Rows(x)("MaterialColour"))
                lvOrderList.Items(x).UseItemStyleForSubItems = False
                lvOrderList.Items(x).SubItems.Add(ds.Tables(0).Rows(x)("TotalSummary"))
                lvOrderList.Items(x).SubItems.Add(ds.Tables(0).Rows(x)("TotalDoorList"))
                lvOrderList.Items(x).SubItems.Add(ds.Tables(0).Rows(x)("SQM"))
                lvOrderList.Items(x).SubItems.Add(ds.Tables(0).Rows(x)("Priority"))

                lvOrderList.Items(x).SubItems.Add(Strings.FormatDateTime(ds.Tables(0).Rows(x)("StartDate"), DateFormat.ShortDate))
                lvOrderList.Items(x).SubItems.Add(ds.Tables(0).Rows(x)("NewBatchID"))
                If IsDBNull(ds.Tables(0).Rows(x)("Painted")) = True Then
                    lvOrderList.Items(x).SubItems.Add("", Color.Black, Color.Green, Font)
                Else
                    lvOrderList.Items(x).SubItems.Add("", Color.Black, Color.Red, Font)
                End If
                lvOrderList.Items(x).SubItems.Add(ds.Tables(0).Rows(x)("BatchID"))
                Select Case Trim(ds.Tables(0).Rows(x)("WeekColour"))
                    Case "Orange"
                        lvOrderList.Items(x).BackColor = Color.Gold
                        lvOrderList.Items(x).SubItems(1).BackColor = Color.Gold
                        lvOrderList.Items(x).SubItems(2).BackColor = Color.Gold
                        lvOrderList.Items(x).SubItems(3).BackColor = Color.Gold
                        lvOrderList.Items(x).SubItems(4).BackColor = Color.Gold
                        lvOrderList.Items(x).SubItems(5).BackColor = Color.Gold
                        lvOrderList.Items(x).SubItems(6).BackColor = Color.Gold
                    Case "Green"
                        lvOrderList.Items(x).BackColor = Color.LightGreen
                        lvOrderList.Items(x).SubItems(1).BackColor = Color.LightGreen
                        lvOrderList.Items(x).SubItems(2).BackColor = Color.LightGreen
                        lvOrderList.Items(x).SubItems(3).BackColor = Color.LightGreen
                        lvOrderList.Items(x).SubItems(4).BackColor = Color.LightGreen
                        lvOrderList.Items(x).SubItems(5).BackColor = Color.LightGreen
                        lvOrderList.Items(x).SubItems(6).BackColor = Color.LightGreen
                    Case "Pink"
                        lvOrderList.Items(x).BackColor = Color.Salmon
                        lvOrderList.Items(x).SubItems(1).BackColor = Color.Salmon
                        lvOrderList.Items(x).SubItems(2).BackColor = Color.Salmon
                        lvOrderList.Items(x).SubItems(3).BackColor = Color.Salmon
                        lvOrderList.Items(x).SubItems(4).BackColor = Color.Salmon
                        lvOrderList.Items(x).SubItems(5).BackColor = Color.Salmon
                        lvOrderList.Items(x).SubItems(6).BackColor = Color.Salmon
                    Case "Blue"
                        lvOrderList.Items(x).BackColor = Color.LightBlue
                        lvOrderList.Items(x).SubItems(1).BackColor = Color.LightBlue
                        lvOrderList.Items(x).SubItems(2).BackColor = Color.LightBlue
                        lvOrderList.Items(x).SubItems(3).BackColor = Color.LightBlue
                        lvOrderList.Items(x).SubItems(4).BackColor = Color.LightBlue
                        lvOrderList.Items(x).SubItems(5).BackColor = Color.LightBlue
                        lvOrderList.Items(x).SubItems(6).BackColor = Color.LightBlue
                    Case "Purple"
                        lvOrderList.Items(x).BackColor = Color.Violet
                        lvOrderList.Items(x).SubItems(1).BackColor = Color.Violet
                        lvOrderList.Items(x).SubItems(2).BackColor = Color.Violet
                        lvOrderList.Items(x).SubItems(3).BackColor = Color.Violet
                        lvOrderList.Items(x).SubItems(4).BackColor = Color.Violet
                        lvOrderList.Items(x).SubItems(5).BackColor = Color.Violet
                        lvOrderList.Items(x).SubItems(6).BackColor = Color.Violet
                End Select
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub fillStyleList()
        Try
            If lvOrderList.SelectedIndices.Count > 0 Then
                lvStyle.Items.Clear()
                Dim ds As New DataSet
                ds = KPGeneral.WebRef_Local.spKP_PaintDoorOrderListByStyle(lvOrderList.SelectedItems.Item(0).SubItems(8).Text, lvOrderList.SelectedItems.Item(0).SubItems(4).Text)
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
                ds = KPGeneral.WebRef_Local.spKP_PaintDoorOrderList_Detail(lvOrderList.SelectedItems.Item(0).SubItems(8).Text, lvOrderList.SelectedItems.Item(0).SubItems(4).Text, Trim(lvStyle.SelectedItems.Item(0).SubItems(0).Text))
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
                    If IsDBNull(ds.Tables(0).Rows(x)("HingeDate")) = False Then
                        lvOrderDetail.Items(x).SubItems.Add("", Color.Black, Color.Green, Font)
                    Else
                        lvOrderDetail.Items(x).SubItems.Add("", Color.Black, Color.Red, Font)
                    End If
                    If IsDBNull(ds.Tables(0).Rows(x)("Shipped")) = False Then
                        lvOrderDetail.Items(x).SubItems.Add(Trim(ds.Tables(0).Rows(x)("Shipped")))
                    Else
                        lvOrderDetail.Items(x).SubItems.Add("")
                    End If
                    If IsDBNull(ds.Tables(0).Rows(x)("SiteRequest")) = False Then
                        lvOrderDetail.Items(x).SubItems.Add(Trim(ds.Tables(0).Rows(x)("SiteRequest")))
                    Else
                        lvOrderDetail.Items(x).SubItems.Add("")
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
        ds = KPGeneral.WebRef_Local.spKP_PaintDoorOrderList_getInfo(Barcode)
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
                KPGeneral.WebRef_Local.spKP_PaintDoorOrderList_getNotDone(tBatchID, tPriority) 'WebService
                Exit For
            End If
        Next
    End Sub


    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        If lvOrderDetail.SelectedIndices.Count > 0 Then
            KPGeneral.ViewKitchenTrackerByMasterNum(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(0)).Text)
        Else
            MessageBox.Show("Invalid Selection: Cannot Display Door List.")
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        If lvOrderDetail.SelectedIndices.Count > 0 Then
            Dim x As String
            x = Trim(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(0)).Text)
            Clipboard.SetDataObject(x)
        Else
            MessageBox.Show("Invalid Selection: Cannot Copy Barcode")
        End If
    End Sub

    Private Sub lvOrderDetail_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvOrderDetail.SelectedIndexChanged

    End Sub

    Private Sub LogMissingDoorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogMissingDoorsToolStripMenuItem.Click
        Try
            Dim frm As New frmPaintMissingDoors(lvScan.SelectedItems(0).SubItems(1).Text, "Paint")
            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MenuItem5_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem5.Click
        If uoCCI.CheckedIndex > -1 Then
            Dim i As Integer

            For i = 0 To lvOrderDetail.SelectedIndices.Count - 1

                KPGeneral.WebRef_Local.spKPFactory_PaintedDoors_UpdateScan_AddWarehouse(Now, Trim(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(i)).Text), Trim(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(i)).SubItems(6).Text), uoCCI.Text)

            Next

            RefreshList()

            fillColourList()
            lvStyle.Items.Clear()
            lvOrderDetail.Items.Clear()
        Else
            MsgBox("You must select a paint type.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If

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
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Name = "DoorScan" Then
            fillColourList()
        ElseIf TabControl1.SelectedTab.Name = "Missing" Then
            RefreshMissingList()
        ElseIf TabControl1.SelectedTab.Name = "Needed" Then
            RefreshDoorsNeeded()
        ElseIf TabControl1.SelectedTab.Name = "Schedule" Then

            RefreshSchedule()
        End If
    End Sub

    Private Sub PrintOrderListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintOrderListToolStripMenuItem.Click
        If lvOrderList.SelectedIndices.Count > 0 Then
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.spKP_DoorOrderList_Detail_ForReport(lvOrderList.SelectedItems.Item(0).SubItems(8).Text, lvOrderList.SelectedItems.Item(0).SubItems(4).Text)

            ds.Tables.Add("Info")

            ds.Tables("Info").Columns.Add("Colour", System.Type.GetType("System.String"))
            ds.Tables("Info").Columns.Add("BatchWeek", System.Type.GetType("System.DateTime"))

            Dim dr As DataRow
            dr = ds.Tables("Info").NewRow
            dr.Item("Colour") = lvOrderList.SelectedItems.Item(0).SubItems(0).Text
            dr.Item("BatchWeek") = lvOrderList.SelectedItems.Item(0).SubItems(5).Text
            ds.Tables("Info").Rows.Add(dr)

            'dsStyle.Tables.Add(dsTime.Tables("Info").Copy)

            'ds.WriteXml("c:\XML\kpro.xml", XmlWriteMode.WriteSchema)

            Dim rptName As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptName = New rptRawPaintOrders
            rptName.SetDataSource(ds)
            Dim rpt As New RptViewer(1, rptName)
            rpt.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        End If
    End Sub

    Private Sub MenuItem1_Click_1(sender As Object, e As EventArgs) Handles MenuItem1.Click
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
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PauseRefresh = PauseRefresh + 1
        If PauseRefresh > 10 Then
            fillColourList()
            Timer1.Stop()
        End If
    End Sub

    Private Sub PrintBatchListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintBatchListToolStripMenuItem.Click
        If lvOrderList.SelectedIndices.Count > 0 Then
            Dim dsBOM As New DataSet
            dsBOM = KPGeneral.WebRef_Local.usp_ViewBatchBOMCabinetPartsByBatchID(lvOrderList.SelectedItems.Item(0).SubItems(8).Text)

            dsBOM.Tables.Add("ExpectShip")
            dsBOM.Tables("ExpectShip").Columns.Add("FDate")
            dsBOM.Tables("ExpectShip").Columns.Add("TDate")
            dsBOM.Tables("ExpectShip").Columns.Add("WeekColour")
            dsBOM.Tables("ExpectShip").Columns.Add("BatchID")

            Dim sDate As DateTime
            sDate = dsBOM.Tables(1).Rows(0)("StartDate")

            Dim dr As DataRow
            dr = dsBOM.Tables("ExpectShip").NewRow
            dr.Item("FDate") = dsBOM.Tables(1).Rows(0)("StartDate")
            dr.Item("TDate") = sDate.AddDays(5)
            dr.Item("WeekColour") = dsBOM.Tables(1).Rows(0)("WeekColour")
            dr.Item("BatchID") = dsBOM.Tables(1).Rows(0)("BatchID")

            dsBOM.Tables("ExpectShip").Rows.Add(dr)
            'dsBOM.Tables.Add(KPGeneral.WebRef_Local.usp_XK_GetRoomInfoByCSID(LotList.ActiveRow.Cells("CSID").Text).Tables(0).Copy)
            'dsBOM.Tables.Add(KPGeneral.WebRef_Local.usp_XK_LotInfoByCSID(LotList.ActiveRow.Cells("CSID").Text).Tables(0).Copy)
            ' dsBOM.WriteXml("c:\XML\BOM.xml", XmlWriteMode.WriteSchema)

            Dim rptName As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptName = New rptBOMBatch
            rptName.SetDataSource(dsBOM)
            Dim rpt As New RptViewer(1, rptName)
            rpt.ShowDialog()
            rpt.Close()
            rpt.Dispose()

            'Dim rptName As New rptBOMBatch
            'rptName.SetDataSource(dsBOM)

            'rptName.PrintOptions.PrinterName = cmbPrinterAccessoryLabels.Text
            'rptName.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
            'rptName.PrintToPrinter(1, True, 0, 0)
            'rptName.Close()
            'rptName.Dispose()
        End If

    End Sub
    Private Sub RefreshDoorsNeeded()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_SiteRequest_Batch_DoorsPicked_NotPainted

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

    Private Sub MenuItem6_Click(sender As Object, e As EventArgs) Handles MenuItem6.Click
        Dim i As Integer
        AssignedPaintDate = Nothing
        frmShippingCalendar.FromPaint = True
        If frmShippingCalendar.ShowDialog() = Windows.Forms.DialogResult.OK Then

            For i = 0 To lvOrderDetail.SelectedIndices.Count - 1

                KPGeneral.WebRef_Local.spKPFactory_PaintedDoors_UpdateSchedule(AssignedPaintDate, Trim(lvOrderDetail.Items(lvOrderDetail.SelectedIndices(i)).Text), KPGeneral.User.UserProfile("UserLoginName"))

            Next
        End If


    End Sub
    Private Sub RefreshSchedule()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.spKPFactory_PaintedDoors_ViewSchedule

        ugSchedule.DataSource = ds

        ugSchedule.DisplayLayout.Bands(0).Columns("Company").Width = 200
        ugSchedule.DisplayLayout.Bands(0).Columns("Project").Width = 200
        ugSchedule.DisplayLayout.Bands(0).Columns("Lot").Width = 150
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshSchedule()
    End Sub

    Private Sub PrintToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem1.Click
        If ugSchedule.Selected.Rows.Count > 0 Then
            'StyleRevisedOrdersPrint()
            'StyleGridPrintSelected()
            UltraGridPrintDocument1.Grid = ugSchedule
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

    Private Sub ugSchedule_AfterSelectChange(sender As Object, e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles ugSchedule.AfterSelectChange
        CheckBlockedDays()
    End Sub
    Private Sub ugReady_InitializePrintPreview(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelablePrintPreviewEventArgs) Handles ugSchedule.InitializePrintPreview
        e.DefaultLogicalPageLayoutInfo.PageHeader = "Painted Door Schedule"

        e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center

        e.DefaultLogicalPageLayoutInfo.PageFooter = "Printed on " & Now & vbTab & "Page <#> of <##>"
        e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 20
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    End Sub

    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles btnToday.Click
        Me.Cursor = Cursors.WaitCursor
        MonthCalendar1.SelectDate(Now)
        LoadCalendarInfo = True
        FormatCalendar(MonthCalendar1.ActiveMonth.Month, MonthCalendar1.ActiveMonth.Year)
        CheckBlockedDays()
        LoadCalendarInfo = False
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FormatCalendar(ByVal month As Integer, ByVal year As Integer)
        If LoadCalendarInfo = True Then


            Dim count As Integer = 0

            Dim month2 As Integer
            Dim year2 As Integer

            Dim month3 As Integer
            Dim year3 As Integer

            MonthCalendar1.Dates.Clear()

            MonthCalendar2.Month.Colors.Disabled.Text = Color.Black
            MonthCalendar1.Month.Colors.Disabled.Text = Color.Black
            MonthCalendar1.Month.Colors.Disabled.Date = Color.Gray
            MonthCalendar2.Month.Colors.Disabled.Date = Color.Gray

            dsHoliday1 = db.spKP_HolidaybyMonth(month, year)

            Dim dh1(dsHoliday1.Tables(0).Rows.Count - 1) As DateItem

            For count = 0 To dsHoliday1.Tables(0).Rows.Count - 1

                dh1(count) = New DateItem()

                dh1(count).Date = Convert.ToDateTime(dsHoliday1.Tables(0).Rows(count)("Shipped"))
                dh1(count).BackColor1 = Color.Red
                dh1(count).Enabled = False
                dh1(count).Text = dsHoliday1.Tables(0).Rows(count)("nTotal")

                If dsHoliday1.Tables(0).Rows(count)("nTotal").ToString.ToLower = "catch up" Or dsHoliday1.Tables(0).Rows(count)("nTotal").ToString.ToLower = "blocked" Then

                Else

                    'dh1(count).Text = dsHoliday1.Tables(0).Rows(count)("nTotal")

                End If


            Next

            MonthCalendar1.AddDateInfo(dh1)
            'dsMonth1 = db.usp_GetScheduling_MonthTotalCounts(month, year)
            dsMonth1 = db.usp_GetPaintSchedulingDoorForecast_MonthTotalCounts(month, year)

            Dim d(dsMonth1.Tables(0).Rows.Count - 1) As DateItem

            For count = 0 To dsMonth1.Tables(0).Rows.Count - 1

                d(count) = New DateItem()

                d(count).Date = Convert.ToDateTime(dsMonth1.Tables(0).Rows(count)("DateDay"))
                If Convert.ToDateTime(dsMonth1.Tables(0).Rows(count)("DateDay")).DayOfWeek = DayOfWeek.Saturday Then
                    d(count).TextColor = Color.Blue
                    d(count).BackColor1 = Color.Yellow
                Else
                    d(count).BackColor1 = Color.White
                    d(count).TextColor = Color.Blue
                End If

                d(count).Text = dsMonth1.Tables(0).Rows(count)("TotalDoors")

                If (dsMonth1.Tables(0).Rows(count)("DateDay")).DayOfWeek = DayOfWeek.Friday Then
                    If (dsMonth1.Tables(0).Rows(count)("TotalDoors") >= db.BuilderFriday) Then
                        d(count).BackColor1 = Color.Red
                    ElseIf dsMonth1.Tables(0).Rows(count)("TotalDoors") >= db.BuilderFridaySoftMax Then
                        d(count).BackColor1 = Color.OrangeRed
                    End If
                Else
                    If (dsMonth1.Tables(0).Rows(count)("TotalDoors") >= db.BuilderNonFridayPerDay) Or ((dsMonth1.Tables(0).Rows(count)("TotalDoors") >= db.SaturdayMax) And ((dsMonth1.Tables(0).Rows(count)("DateDay")).DayOfWeek = DayOfWeek.Saturday)) Then
                        d(count).BackColor1 = Color.Red
                    ElseIf dsMonth1.Tables(0).Rows(count)("TotalDoors") >= db.NonFridaySoftMax Then
                        d(count).BackColor1 = Color.OrangeRed
                    End If
                End If


                Dim y As Integer
                For y = 0 To MonthCalendar1.Dates.Count - 1
                    If MonthCalendar1.Dates(y).Date = d(count).Date Then
                        d(count).Enabled = False
                        'd2(count).TextColor = Color.Black
                    End If
                Next
            Next


            MonthCalendar1.AddDateInfo(d)


            ' Automaticaly change date for calendar 2
            If month = 12 Then
                month2 = 1
                year2 = year + 1
            Else
                month2 = month + 1
                year2 = year
            End If

            MonthCalendar2.Dates.Clear()
            MonthCalendar2.ActiveMonth.Month = month2
            MonthCalendar2.ActiveMonth.Year = year2


            dsHoliday2 = db.spKP_HolidaybyMonth(month2, year2)

            Dim dh2(dsHoliday2.Tables(0).Rows.Count - 1) As DateItem

            For count = 0 To dsHoliday2.Tables(0).Rows.Count - 1

                dh2(count) = New DateItem()
                dh2(count).BackColor1 = Color.Red
                dh2(count).Date = Convert.ToDateTime(dsHoliday2.Tables(0).Rows(count)("Shipped"))
                dh2(count).Enabled = False
                dh2(count).Text = dsHoliday2.Tables(0).Rows(count)("nTotal")

                If dsHoliday2.Tables(0).Rows(count)("nTotal").ToString.ToLower = "catch up" Or dsHoliday2.Tables(0).Rows(count)("nTotal").ToString.ToLower = "blocked" Then

                Else

                    'dh2(count).Text = dsHoliday2.Tables(0).Rows(count)("nTotal")

                End If

            Next

            MonthCalendar2.AddDateInfo(dh2)

            dsMonth2 = db.usp_GetPaintSchedulingDoorForecast_MonthTotalCounts(month2, year2)
            'dsMonth2 = db.usp_GetScheduling_MonthTotalCounts(month2, year2)

            Dim d2(dsMonth2.Tables(0).Rows.Count - 1) As DateItem

            For count = 0 To dsMonth2.Tables(0).Rows.Count - 1

                d2(count) = New DateItem()

                d2(count).Date = Convert.ToDateTime(dsMonth2.Tables(0).Rows(count)("DateDay"))
                If Convert.ToDateTime(dsMonth2.Tables(0).Rows(count)("DateDay")).DayOfWeek = DayOfWeek.Saturday Then
                    d2(count).TextColor = Color.Blue
                    d2(count).BackColor1 = Color.Yellow
                Else
                    d2(count).BackColor1 = Color.White
                    d2(count).TextColor = Color.Blue
                End If
                d2(count).Text = dsMonth2.Tables(0).Rows(count)("TotalDoors")

                If (dsMonth2.Tables(0).Rows(count)("DateDay")).DayOfWeek = DayOfWeek.Friday Then
                    If (dsMonth2.Tables(0).Rows(count)("TotalDoors") >= db.BuilderFriday) Then
                        d2(count).BackColor1 = Color.Red
                    ElseIf dsMonth2.Tables(0).Rows(count)("TotalDoors") >= db.BuilderFridaySoftMax Then
                        d2(count).BackColor1 = Color.OrangeRed
                    End If
                Else
                    If (dsMonth2.Tables(0).Rows(count)("TotalDoors") >= db.BuilderNonFridayPerDay) Or ((dsMonth2.Tables(0).Rows(count)("TotalDoors") >= db.SaturdayMax) And ((dsMonth2.Tables(0).Rows(count)("DateDay")).DayOfWeek = DayOfWeek.Saturday)) Then
                        d2(count).BackColor1 = Color.Red
                    ElseIf dsMonth2.Tables(0).Rows(count)("TotalDoors") >= db.NonFridaySoftMax Then
                        d2(count).BackColor1 = Color.OrangeRed
                    End If
                End If

                'If (dsMonth2.Tables(0).Rows(count)("TotalDoors") >= db.HardDoorMax) Or ((dsMonth2.Tables(0).Rows(count)("TotalDoors") >= db.SaturdayMax) And ((dsMonth2.Tables(0).Rows(count)("DateDay")).DayOfWeek = DayOfWeek.Saturday)) Then
                '    d2(count).BackColor1 = Color.Red
                'ElseIf dsMonth2.Tables(0).Rows(count)("TotalDoors") >= db.SoftDoorMax Then
                '    d2(count).BackColor1 = Color.OrangeRed
                'End If
                Dim x As Integer
                For x = 0 To MonthCalendar2.Dates.Count - 1
                    If MonthCalendar2.Dates(x).Date = d2(count).Date Then
                        d2(count).Enabled = False
                        'd2(count).TextColor = Color.Black
                    End If
                Next
            Next

            MonthCalendar2.AddDateInfo(d2)

            ' Automaticaly change date for calendar 3
            If month2 = 12 Then
                month3 = 1
                year3 = year + 1
            Else
                month3 = month2 + 1
                If month2 = 1 Then
                    year3 = year + 1
                Else
                    year3 = year
                End If

            End If

        End If
    End Sub
    Private Sub UpdateDoorCounts()
        Dim totalDoors As Integer = 0
        Dim totalOrders As Integer = 0

        Dim i As Integer
        If ugSchedule.Rows.Count > 0 Then
            For i = 0 To ugSchedule.Selected.Rows.Count - 1
                totalDoors = totalDoors + ugSchedule.Selected.Rows(i).Cells("DoorCount").Value
                totalOrders = totalOrders + 1
            Next

            txtSelectedOrders.Text = totalOrders
            txtSelectedDoors.Text = totalDoors

            FormatCalendar(MonthCalendar1.ActiveMonth.Month, MonthCalendar1.ActiveMonth.Year)

            'BlockOffDaysForScheduling(totalDoors)

        End If

    End Sub

    Private Sub CheckBlockedDays()
        If ugSchedule.Selected.Rows.Count > 0 Then

            UpdateDoorCounts()
            BlockOffDays2()
            ugSchedule.ActiveRow = Nothing
        Else
            Clear()
        End If

        If MonthCalendar1.SelectedDates.Count > 0 Then
            If txtSelectedDate.Text.Length > 0 Then
                If MonthCalendar1.SelectedDates(0).Date.ToShortDateString = txtSelectedDate.Text Then
                    Dim x As Integer
                    For x = 0 To MonthCalendar1.Dates.Count - 1
                        If MonthCalendar1.Dates(x).Date = MonthCalendar1.SelectedDates(0).Date Then
                            If MonthCalendar1.Dates(x).Enabled = False Then
                                txtSelectedDate.Text = ""
                                MonthCalendar1.ClearSelection()
                                Exit For
                            End If
                        End If
                    Next
                Else
                    txtSelectedDate.Text = ""
                    MonthCalendar1.ClearSelection()
                    Exit Sub
                End If
            Else
                txtSelectedDate.Text = ""
                MonthCalendar1.ClearSelection()
                Exit Sub
            End If
        End If

        If MonthCalendar2.SelectedDates.Count > 0 Then
            If txtSelectedDate.Text.Length > 0 Then
                If MonthCalendar2.SelectedDates(0).Date.ToShortDateString = txtSelectedDate.Text Then
                    Dim x As Integer
                    For x = 0 To MonthCalendar2.Dates.Count - 1
                        If MonthCalendar2.Dates(x).Date = MonthCalendar2.SelectedDates(0).Date Then
                            If MonthCalendar2.Dates(x).Enabled = False Then
                                txtSelectedDate.Text = ""
                                MonthCalendar2.ClearSelection()
                                Exit For
                            End If
                        End If
                    Next
                Else
                    txtSelectedDate.Text = ""
                    MonthCalendar2.ClearSelection()
                    Exit Sub
                End If
            Else
                txtSelectedDate.Text = ""
                MonthCalendar2.ClearSelection()
                Exit Sub
            End If
        End If

    End Sub
    Private Sub BlockOffDays2()
        Dim dadd, dday As Integer
        dadd = 1
        'If Now.Date.DayOfWeek = DayOfWeek.Monday Then
        '    dadd = dday + 6
        'ElseIf Now.Date.DayOfWeek = DayOfWeek.Tuesday Then
        '    dadd = dday + 5
        'ElseIf Now.Date.DayOfWeek = DayOfWeek.Wednesday Then
        '    dadd = dday + 4
        'ElseIf Now.Date.DayOfWeek = DayOfWeek.Thursday Then
        '    dadd = dday + 3
        'ElseIf Now.Date.DayOfWeek = DayOfWeek.Friday Then
        '    dadd = dday + 2
        'ElseIf Now.Date.DayOfWeek = DayOfWeek.Saturday Then
        '    dadd = dday + 1
        'End If

        Dim mdate As DateTime
        If dadd > 0 Then
            mdate = Now.Date.AddDays(dadd - 1)
            For i As Integer = 0 To MonthCalendar1.Dates.Count - 1

                Try
                    If MonthCalendar1.Dates(i).Date < mdate Then
                        MonthCalendar1.Dates.Item(i).Enabled = False
                    End If

                Catch ex As Exception
                    MonthCalendar1.Dates.Item(i).Enabled = False
                End Try

            Next

            For j As Integer = 0 To MonthCalendar2.Dates.Count - 1

                Try
                    If MonthCalendar2.Dates(j).Date < mdate Then
                        MonthCalendar2.Dates.Item(j).Enabled = False
                    End If

                Catch ex As Exception
                    MonthCalendar2.Dates.Item(j).Enabled = False
                End Try

            Next


            MonthCalendar1.Refresh()
            MonthCalendar2.Refresh()
        End If


    End Sub
    Private Sub Clear()
        FormatCalendar(MonthCalendar1.ActiveMonth.Month, MonthCalendar1.ActiveMonth.Year)

        MonthCalendar1.Refresh()
        MonthCalendar2.Refresh()
        MonthCalendar1.ClearSelection()
        MonthCalendar2.ClearSelection()

        txtSelectedOrders.Text = ""
        txtSelectedDoors.Text = ""
        txtSelectedDate.Text = ""

        ugSchedule.ActiveRow = Nothing
        ugSchedule.Selected.Rows.Clear()
    End Sub
    Private Sub MonthCalendar1_DaySelected(ByVal sender As Object, ByVal e As Pabo.Calendar.DaySelectedEventArgs) Handles MonthCalendar1.DaySelected
        If MonthCalendar1.SelectedDates(0).Month = MonthCalendar1.ActiveMonth.Month Then
            If MonthCalendar1.SelectedDates(0).DayOfWeek = DayOfWeek.Sunday Then
                'WeekDoorTotal(MonthCalendar1.SelectedDates(0).Date.AddDays(-1))
                txtSelectedDate.Text = ""
                'ScheduleToolStripMenuItem.Enabled = False
                MonthCalendar1.ClearSelection()
            Else
                'WeekDoorTotal(MonthCalendar1.SelectedDates(0).Date)
                txtSelectedDate.Text = MonthCalendar1.SelectedDates.Item(0).Date
                'ScheduleToolStripMenuItem.Enabled = True
                MonthCalendar2.ClearSelection()
            End If
        Else
            'txtWeekDoors.Text = ""
            txtSelectedDate.Text = ""
            'ScheduleToolStripMenuItem.Enabled = False
            MonthCalendar1.ClearSelection()
        End If


    End Sub
    Private Sub MonthCalendar1_MonthChanged(ByVal sender As Object, ByVal e As Pabo.Calendar.MonthChangedEventArgs) Handles MonthCalendar1.MonthChanged
        If FormLoaded = True Then
            LoadCalendarInfo = True
            FormatCalendar(e.Month, e.Year)
            LoadCalendarInfo = False
            'ScheduleToolStripMenuItem.Enabled = False
            If (txtSelectedDoors.Text <> "") Then
                'BlockOffDaysForScheduling(CInt(txtSelectedDoors.Text))
                BlockOffDays2()
            End If
        End If
    End Sub
    Private Sub MonthCalendar2_DaySelected(ByVal sender As Object, ByVal e As Pabo.Calendar.DaySelectedEventArgs) Handles MonthCalendar2.DaySelected

        If MonthCalendar2.SelectedDates(0).Month = MonthCalendar2.ActiveMonth.Month Then
            If MonthCalendar2.SelectedDates(0).DayOfWeek = DayOfWeek.Sunday Then
                'WeekDoorTotal(MonthCalendar2.SelectedDates(0).Date.AddDays(-1))
                txtSelectedDate.Text = ""
                'ScheduleToolStripMenuItem.Enabled = False
                MonthCalendar2.ClearSelection()
            Else
                'WeekDoorTotal(MonthCalendar2.SelectedDates(0).Date)
                txtSelectedDate.Text = MonthCalendar2.SelectedDates.Item(0).Date
                'ScheduleToolStripMenuItem.Enabled = True
                MonthCalendar1.ClearSelection()
            End If
        Else
            'txtWeekDoors.Text = ""
            txtSelectedDate.Text = ""
            'ScheduleToolStripMenuItem.Enabled = False
            MonthCalendar2.ClearSelection()
        End If
    End Sub
    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        RefreshSchedule()
    End Sub
    Private Sub ScheduleForPaintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScheduleForPaintToolStripMenuItem.Click
        If ugSchedule.Selected.Rows.Count > 0 Then
            If txtSelectedDate.Text.Trim.Length > 0 Then
                Dim x As Integer
                For x = 0 To ugSchedule.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_PaintedDoors_UpdateSchedule(txtSelectedDate.Text, ugSchedule.Selected.Rows(x).Cells("Barcode").Text, KPGeneral.User.UserProfile("UserLoginName"))
                    ugSchedule.Selected.Rows(x).Cells("ScheduledDate").Value = txtSelectedDate.Text
                Next
                LoadCalendarInfo = True
                FormatCalendar(MonthCalendar1.ActiveMonth.Month, MonthCalendar1.ActiveMonth.Year)
                LoadCalendarInfo = False
                'RefreshSchedule()
            End If
        End If
    End Sub

    Private Sub ViewOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewOrdersToolStripMenuItem.Click
        If txtSelectedDate.Text = "" Or txtSelectedDate.Text Is Nothing Then
            frmViewOrders.FDate = "1/1/0001"
            frmViewOrders.FromPaint = True
            frmViewOrders.ShowDialog()
        Else
            ' Schedule each item
            frmViewOrders.FDate = txtSelectedDate.Text
            frmViewOrders.FromPaint = True
            frmViewOrders.ShowDialog()

        End If
    End Sub

    Private Sub ClearSelectedScheduleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearSelectedScheduleToolStripMenuItem.Click
        If ugSchedule.Selected.Rows.Count > 0 Then
            If txtSelectedDate.Text.Trim.Length > 0 Then
                Dim x As Integer
                For x = 0 To ugSchedule.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_PaintedDoors_UpdateSchedule(#1/1/9999#, ugSchedule.Selected.Rows(x).Cells("Barcode").Text, KPGeneral.User.UserProfile("UserLoginName"))
                    ugSchedule.Selected.Rows(x).Cells("ScheduledDate").Value = ""
                Next
                LoadCalendarInfo = True
                FormatCalendar(MonthCalendar1.ActiveMonth.Month, MonthCalendar1.ActiveMonth.Year)
                LoadCalendarInfo = False
                'RefreshSchedule()
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        T = T + 1
        If T > 1800 Then
            uoCCI.CheckedIndex = -1
            T = 0
        End If
    End Sub
End Class