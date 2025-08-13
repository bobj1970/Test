Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.Mail
Imports Infragistics.Win.UltraWinGrid

Public Class frmDoorsOnDemand

    Inherits System.Windows.Forms.Form
    Dim TDate As Date
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents KitchenTrackerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyBarcodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Dim FDate As Date
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents lvOrderList As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridFilterUIProvider1 As Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider
    Friend WithEvents lvStyle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lvOrderDetail As Infragistics.Win.UltraWinGrid.UltraGrid
    Dim dsBatchDoorList As New DataSet
    Friend WithEvents PrintSelectedDoorListAndSummarizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblDoorListsShown As Label
    Friend WithEvents lblDoorListsSelected As Label
    Friend WithEvents lblDoorsShown As Label
    Friend WithEvents lblDoorsSelected As Label
    Friend WithEvents uccTarget As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnClearFilter As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnApplyFilter As Infragistics.Win.Misc.UltraButton
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ugRecentlyPrinted As UltraGrid
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ReprintSelectedSummaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReprintSelectedDoorListsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ugDOMAStockOrders As UltraGrid
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Rejected As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ugRejected As UltraGrid
    Friend WithEvents btnViewReport As Button
    Friend WithEvents dtTDate As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents dtFDate As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents cbReason As UltraCombo
    Friend WithEvents cbWoodType As UltraCombo
    Friend WithEvents btnAdd As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label5 As Label
    Dim PauseRefresh As Integer

    Dim BatchHasDoors As Boolean
    Dim BatchHasDoorsService As Boolean
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
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Assembled As System.Windows.Forms.TabPage
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDoorsOnDemand))
        Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
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
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Assembled = New System.Windows.Forms.TabPage()
        Me.btnClearFilter = New Infragistics.Win.Misc.UltraButton()
        Me.btnApplyFilter = New Infragistics.Win.Misc.UltraButton()
        Me.uccTarget = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblDoorListsShown = New System.Windows.Forms.Label()
        Me.lblDoorListsSelected = New System.Windows.Forms.Label()
        Me.lblDoorsShown = New System.Windows.Forms.Label()
        Me.lblDoorsSelected = New System.Windows.Forms.Label()
        Me.lvOrderDetail = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KitchenTrackerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyBarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintSelectedDoorListAndSummarizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGridFilterUIProvider1 = New Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider(Me.components)
        Me.lvStyle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lvOrderList = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Rejected = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ugRejected = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnViewReport = New System.Windows.Forms.Button()
        Me.dtTDate = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtFDate = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbReason = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.cbWoodType = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ugRecentlyPrinted = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ReprintSelectedSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReprintSelectedDoorListsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ugDOMAStockOrders = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.TabControl1.SuspendLayout()
        Me.Assembled.SuspendLayout()
        CType(Me.uccTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lvOrderDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.lvStyle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lvOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Rejected.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ugRejected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbReason, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbWoodType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.ugRecentlyPrinted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.ugDOMAStockOrders, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.txtTotalDoors.Location = New System.Drawing.Point(914, 0)
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
        Me.Label2.Size = New System.Drawing.Size(873, 24)
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
        Me.lvDoorsOnFloor.HideSelection = False
        Me.lvDoorsOnFloor.Location = New System.Drawing.Point(554, -9)
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
        Me.lvScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvScan.FullRowSelect = True
        Me.lvScan.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvScan.HideSelection = False
        Me.lvScan.Location = New System.Drawing.Point(0, 57)
        Me.lvScan.MultiSelect = False
        Me.lvScan.Name = "lvScan"
        Me.lvScan.Size = New System.Drawing.Size(873, 246)
        Me.lvScan.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lvScan.TabIndex = 11
        Me.lvScan.UseCompatibleStateImageBehavior = False
        Me.lvScan.View = System.Windows.Forms.View.Details
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.DarkBlue
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(1500, 32)
        Me.lblTitle.TabIndex = 38
        Me.lblTitle.Text = "DOORS ON DEMAND"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Assembled)
        Me.TabControl1.Controls.Add(Me.Rejected)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1500, 601)
        Me.TabControl1.TabIndex = 45
        '
        'Assembled
        '
        Me.Assembled.Controls.Add(Me.btnClearFilter)
        Me.Assembled.Controls.Add(Me.btnApplyFilter)
        Me.Assembled.Controls.Add(Me.uccTarget)
        Me.Assembled.Controls.Add(Me.UltraLabel1)
        Me.Assembled.Controls.Add(Me.lblDoorListsShown)
        Me.Assembled.Controls.Add(Me.lblDoorListsSelected)
        Me.Assembled.Controls.Add(Me.lblDoorsShown)
        Me.Assembled.Controls.Add(Me.lblDoorsSelected)
        Me.Assembled.Controls.Add(Me.lvOrderDetail)
        Me.Assembled.Controls.Add(Me.lvStyle)
        Me.Assembled.Controls.Add(Me.lvOrderList)
        Me.Assembled.Controls.Add(Me.Label4)
        Me.Assembled.Controls.Add(Me.lvScan)
        Me.Assembled.Controls.Add(Me.btnRefresh)
        Me.Assembled.Controls.Add(Me.lvDoorsOnFloor)
        Me.Assembled.Controls.Add(Me.txtTotalDoors)
        Me.Assembled.Controls.Add(Me.txtBarcode)
        Me.Assembled.Controls.Add(Me.Label1)
        Me.Assembled.Controls.Add(Me.lblErrorMsg)
        Me.Assembled.Controls.Add(Me.Label2)
        Me.Assembled.Location = New System.Drawing.Point(4, 22)
        Me.Assembled.Name = "Assembled"
        Me.Assembled.Padding = New System.Windows.Forms.Padding(3)
        Me.Assembled.Size = New System.Drawing.Size(1492, 575)
        Me.Assembled.TabIndex = 0
        Me.Assembled.Text = "Assembled"
        Me.Assembled.UseVisualStyleBackColor = True
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearFilter.Location = New System.Drawing.Point(891, 32)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnClearFilter.TabIndex = 55
        Me.btnClearFilter.Text = "Clear Filter"
        '
        'btnApplyFilter
        '
        Me.btnApplyFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApplyFilter.Location = New System.Drawing.Point(972, 30)
        Me.btnApplyFilter.Name = "btnApplyFilter"
        Me.btnApplyFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnApplyFilter.TabIndex = 54
        Me.btnApplyFilter.Text = "Apply Filter"
        '
        'uccTarget
        '
        Me.uccTarget.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uccTarget.DateButtons.Add(DateButton1)
        Me.uccTarget.Location = New System.Drawing.Point(926, 2)
        Me.uccTarget.Name = "uccTarget"
        Me.uccTarget.NonAutoSizeHeight = 21
        Me.uccTarget.Size = New System.Drawing.Size(121, 21)
        Me.uccTarget.TabIndex = 52
        Me.uccTarget.Value = New Date(2020, 7, 30, 0, 0, 0, 0)
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel1.Location = New System.Drawing.Point(840, 2)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 53
        Me.UltraLabel1.Text = "Target Date"
        '
        'lblDoorListsShown
        '
        Me.lblDoorListsShown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDoorListsShown.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoorListsShown.Location = New System.Drawing.Point(962, 6)
        Me.lblDoorListsShown.Name = "lblDoorListsShown"
        Me.lblDoorListsShown.Size = New System.Drawing.Size(267, 18)
        Me.lblDoorListsShown.TabIndex = 51
        Me.lblDoorListsShown.Text = "Door Lists Shown = 0"
        Me.lblDoorListsShown.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDoorListsSelected
        '
        Me.lblDoorListsSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDoorListsSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoorListsSelected.Location = New System.Drawing.Point(962, 29)
        Me.lblDoorListsSelected.Name = "lblDoorListsSelected"
        Me.lblDoorListsSelected.Size = New System.Drawing.Size(267, 18)
        Me.lblDoorListsSelected.TabIndex = 50
        Me.lblDoorListsSelected.Text = "Door Lists Selected = 0"
        Me.lblDoorListsSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDoorsShown
        '
        Me.lblDoorsShown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDoorsShown.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoorsShown.Location = New System.Drawing.Point(1219, 6)
        Me.lblDoorsShown.Name = "lblDoorsShown"
        Me.lblDoorsShown.Size = New System.Drawing.Size(267, 18)
        Me.lblDoorsShown.TabIndex = 48
        Me.lblDoorsShown.Text = "Total Doors Shown = 0"
        Me.lblDoorsShown.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDoorsSelected
        '
        Me.lblDoorsSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDoorsSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoorsSelected.Location = New System.Drawing.Point(1218, 30)
        Me.lblDoorsSelected.Name = "lblDoorsSelected"
        Me.lblDoorsSelected.Size = New System.Drawing.Size(267, 18)
        Me.lblDoorsSelected.TabIndex = 49
        Me.lblDoorsSelected.Text = "Total Doors Selected = 0"
        Me.lblDoorsSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lvOrderDetail
        '
        Me.lvOrderDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvOrderDetail.ContextMenuStrip = Me.ContextMenuStrip1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.lvOrderDetail.DisplayLayout.Appearance = Appearance1
        Me.lvOrderDetail.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lvOrderDetail.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.lvOrderDetail.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lvOrderDetail.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.lvOrderDetail.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lvOrderDetail.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lvOrderDetail.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.lvOrderDetail.DisplayLayout.MaxColScrollRegions = 1
        Me.lvOrderDetail.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lvOrderDetail.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lvOrderDetail.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.lvOrderDetail.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.lvOrderDetail.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvOrderDetail.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvOrderDetail.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.lvOrderDetail.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvOrderDetail.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.lvOrderDetail.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.lvOrderDetail.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.lvOrderDetail.DisplayLayout.Override.CellAppearance = Appearance8
        Me.lvOrderDetail.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.lvOrderDetail.DisplayLayout.Override.CellPadding = 0
        Me.lvOrderDetail.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.lvOrderDetail.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.lvOrderDetail.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.lvOrderDetail.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.lvOrderDetail.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.lvOrderDetail.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.lvOrderDetail.DisplayLayout.Override.RowAppearance = Appearance11
        Me.lvOrderDetail.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lvOrderDetail.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.lvOrderDetail.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.lvOrderDetail.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.lvOrderDetail.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.lvOrderDetail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvOrderDetail.Location = New System.Drawing.Point(879, 59)
        Me.lvOrderDetail.Name = "lvOrderDetail"
        Me.lvOrderDetail.Size = New System.Drawing.Size(607, 508)
        Me.lvOrderDetail.TabIndex = 47
        Me.lvOrderDetail.Text = "UltraGrid1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KitchenTrackerToolStripMenuItem, Me.ToolStripSeparator1, Me.CopyBarcodeToolStripMenuItem, Me.RefreshListToolStripMenuItem, Me.PrintSelectedDoorListAndSummarizeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(282, 98)
        '
        'KitchenTrackerToolStripMenuItem
        '
        Me.KitchenTrackerToolStripMenuItem.Name = "KitchenTrackerToolStripMenuItem"
        Me.KitchenTrackerToolStripMenuItem.Size = New System.Drawing.Size(281, 22)
        Me.KitchenTrackerToolStripMenuItem.Text = "Kitchen Tracker"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(278, 6)
        '
        'CopyBarcodeToolStripMenuItem
        '
        Me.CopyBarcodeToolStripMenuItem.Name = "CopyBarcodeToolStripMenuItem"
        Me.CopyBarcodeToolStripMenuItem.Size = New System.Drawing.Size(281, 22)
        Me.CopyBarcodeToolStripMenuItem.Text = "Copy Barcode"
        '
        'RefreshListToolStripMenuItem
        '
        Me.RefreshListToolStripMenuItem.Name = "RefreshListToolStripMenuItem"
        Me.RefreshListToolStripMenuItem.Size = New System.Drawing.Size(281, 22)
        Me.RefreshListToolStripMenuItem.Text = "Refresh List"
        '
        'PrintSelectedDoorListAndSummarizeToolStripMenuItem
        '
        Me.PrintSelectedDoorListAndSummarizeToolStripMenuItem.Name = "PrintSelectedDoorListAndSummarizeToolStripMenuItem"
        Me.PrintSelectedDoorListAndSummarizeToolStripMenuItem.Size = New System.Drawing.Size(281, 22)
        Me.PrintSelectedDoorListAndSummarizeToolStripMenuItem.Text = "Print Selected Door List and Summarize"
        '
        'lvStyle
        '
        Me.lvStyle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.lvStyle.DisplayLayout.Appearance = Appearance13
        Me.lvStyle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lvStyle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.lvStyle.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lvStyle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.lvStyle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lvStyle.DisplayLayout.GroupByBox.Hidden = True
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lvStyle.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.lvStyle.DisplayLayout.MaxColScrollRegions = 1
        Me.lvStyle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lvStyle.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lvStyle.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.lvStyle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.lvStyle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvStyle.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvStyle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.lvStyle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvStyle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.lvStyle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.lvStyle.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.lvStyle.DisplayLayout.Override.CellAppearance = Appearance20
        Me.lvStyle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.lvStyle.DisplayLayout.Override.CellPadding = 0
        Me.lvStyle.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.lvStyle.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.lvStyle.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.lvStyle.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.lvStyle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.lvStyle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.lvStyle.DisplayLayout.Override.RowAppearance = Appearance23
        Me.lvStyle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvStyle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lvStyle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.lvStyle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.lvStyle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.lvStyle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.lvStyle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvStyle.Location = New System.Drawing.Point(508, 326)
        Me.lvStyle.Name = "lvStyle"
        Me.lvStyle.Size = New System.Drawing.Size(365, 242)
        Me.lvStyle.TabIndex = 46
        Me.lvStyle.Text = "UltraGrid1"
        '
        'lvOrderList
        '
        Me.lvOrderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.lvOrderList.DisplayLayout.Appearance = Appearance25
        Me.lvOrderList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lvOrderList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.lvOrderList.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lvOrderList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.lvOrderList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lvOrderList.DisplayLayout.GroupByBox.Hidden = True
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lvOrderList.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.lvOrderList.DisplayLayout.MaxColScrollRegions = 1
        Me.lvOrderList.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lvOrderList.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lvOrderList.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.lvOrderList.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.lvOrderList.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvOrderList.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvOrderList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.lvOrderList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvOrderList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.lvOrderList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.lvOrderList.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.lvOrderList.DisplayLayout.Override.CellAppearance = Appearance32
        Me.lvOrderList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.lvOrderList.DisplayLayout.Override.CellPadding = 0
        Me.lvOrderList.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.lvOrderList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.lvOrderList.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.lvOrderList.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.lvOrderList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.lvOrderList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.lvOrderList.DisplayLayout.Override.RowAppearance = Appearance35
        Me.lvOrderList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvOrderList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lvOrderList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.lvOrderList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.lvOrderList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.lvOrderList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.lvOrderList.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvOrderList.Location = New System.Drawing.Point(1, 326)
        Me.lvOrderList.Name = "lvOrderList"
        Me.lvOrderList.Size = New System.Drawing.Size(501, 242)
        Me.lvOrderList.TabIndex = 45
        Me.lvOrderList.Text = "UltraGrid1"
        '
        'Rejected
        '
        Me.Rejected.Controls.Add(Me.SplitContainer1)
        Me.Rejected.Location = New System.Drawing.Point(4, 22)
        Me.Rejected.Name = "Rejected"
        Me.Rejected.Size = New System.Drawing.Size(1242, 491)
        Me.Rejected.TabIndex = 3
        Me.Rejected.Tag = ""
        Me.Rejected.Text = "Rejected"
        Me.Rejected.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ugRejected)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnViewReport)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dtTDate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dtFDate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cbReason)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cbWoodType)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnAdd)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtQty)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Size = New System.Drawing.Size(1242, 491)
        Me.SplitContainer1.SplitterDistance = 280
        Me.SplitContainer1.TabIndex = 3
        '
        'ugRejected
        '
        Appearance37.BackColor = System.Drawing.SystemColors.Window
        Appearance37.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugRejected.DisplayLayout.Appearance = Appearance37
        Me.ugRejected.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugRejected.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance38.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRejected.DisplayLayout.GroupByBox.Appearance = Appearance38
        Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRejected.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance39
        Me.ugRejected.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugRejected.DisplayLayout.GroupByBox.Hidden = True
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance40.BackColor2 = System.Drawing.SystemColors.Control
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRejected.DisplayLayout.GroupByBox.PromptAppearance = Appearance40
        Me.ugRejected.DisplayLayout.MaxColScrollRegions = 1
        Me.ugRejected.DisplayLayout.MaxRowScrollRegions = 1
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Appearance41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugRejected.DisplayLayout.Override.ActiveCellAppearance = Appearance41
        Appearance42.BackColor = System.Drawing.SystemColors.Highlight
        Appearance42.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugRejected.DisplayLayout.Override.ActiveRowAppearance = Appearance42
        Me.ugRejected.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugRejected.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugRejected.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugRejected.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugRejected.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugRejected.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Me.ugRejected.DisplayLayout.Override.CardAreaAppearance = Appearance43
        Appearance44.BorderColor = System.Drawing.Color.Silver
        Appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugRejected.DisplayLayout.Override.CellAppearance = Appearance44
        Me.ugRejected.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugRejected.DisplayLayout.Override.CellPadding = 0
        Appearance45.BackColor = System.Drawing.SystemColors.Control
        Appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance45.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRejected.DisplayLayout.Override.GroupByRowAppearance = Appearance45
        Appearance46.TextHAlignAsString = "Left"
        Me.ugRejected.DisplayLayout.Override.HeaderAppearance = Appearance46
        Me.ugRejected.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugRejected.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Appearance47.BorderColor = System.Drawing.Color.Silver
        Me.ugRejected.DisplayLayout.Override.RowAppearance = Appearance47
        Me.ugRejected.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance48.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugRejected.DisplayLayout.Override.TemplateAddRowAppearance = Appearance48
        Me.ugRejected.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugRejected.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugRejected.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugRejected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugRejected.Location = New System.Drawing.Point(0, 0)
        Me.ugRejected.Name = "ugRejected"
        Me.ugRejected.Size = New System.Drawing.Size(1242, 280)
        Me.ugRejected.TabIndex = 1
        Me.ugRejected.Text = "UltraGrid1"
        '
        'btnViewReport
        '
        Me.btnViewReport.Location = New System.Drawing.Point(745, 65)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(110, 23)
        Me.btnViewReport.TabIndex = 43
        Me.btnViewReport.Text = "VIEW REPORT"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'dtTDate
        '
        Me.dtTDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTDate.Location = New System.Drawing.Point(628, 97)
        Me.dtTDate.Name = "dtTDate"
        Me.dtTDate.Size = New System.Drawing.Size(104, 22)
        Me.dtTDate.TabIndex = 40
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(588, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 21)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "To:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtFDate
        '
        Me.dtFDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFDate.Location = New System.Drawing.Point(628, 65)
        Me.dtFDate.Name = "dtFDate"
        Me.dtFDate.Size = New System.Drawing.Size(104, 22)
        Me.dtFDate.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(580, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 21)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "From:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbReason
        '
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cbReason.DisplayLayout.Appearance = Appearance49
        Me.cbReason.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cbReason.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance50.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance50.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance50.BorderColor = System.Drawing.SystemColors.Window
        Me.cbReason.DisplayLayout.GroupByBox.Appearance = Appearance50
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cbReason.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance51
        Me.cbReason.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance52.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance52.BackColor2 = System.Drawing.SystemColors.Control
        Appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance52.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cbReason.DisplayLayout.GroupByBox.PromptAppearance = Appearance52
        Me.cbReason.DisplayLayout.MaxColScrollRegions = 1
        Me.cbReason.DisplayLayout.MaxRowScrollRegions = 1
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbReason.DisplayLayout.Override.ActiveCellAppearance = Appearance53
        Appearance54.BackColor = System.Drawing.SystemColors.Highlight
        Appearance54.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cbReason.DisplayLayout.Override.ActiveRowAppearance = Appearance54
        Me.cbReason.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cbReason.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Me.cbReason.DisplayLayout.Override.CardAreaAppearance = Appearance55
        Appearance56.BorderColor = System.Drawing.Color.Silver
        Appearance56.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cbReason.DisplayLayout.Override.CellAppearance = Appearance56
        Me.cbReason.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cbReason.DisplayLayout.Override.CellPadding = 0
        Appearance57.BackColor = System.Drawing.SystemColors.Control
        Appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance57.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance57.BorderColor = System.Drawing.SystemColors.Window
        Me.cbReason.DisplayLayout.Override.GroupByRowAppearance = Appearance57
        Appearance58.TextHAlignAsString = "Left"
        Me.cbReason.DisplayLayout.Override.HeaderAppearance = Appearance58
        Me.cbReason.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cbReason.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance59.BackColor = System.Drawing.SystemColors.Window
        Appearance59.BorderColor = System.Drawing.Color.Silver
        Me.cbReason.DisplayLayout.Override.RowAppearance = Appearance59
        Me.cbReason.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance60.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbReason.DisplayLayout.Override.TemplateAddRowAppearance = Appearance60
        Me.cbReason.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cbReason.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cbReason.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cbReason.Location = New System.Drawing.Point(609, 29)
        Me.cbReason.Name = "cbReason"
        Me.cbReason.Size = New System.Drawing.Size(125, 22)
        Me.cbReason.TabIndex = 15
        '
        'cbWoodType
        '
        Appearance61.BackColor = System.Drawing.SystemColors.Window
        Appearance61.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cbWoodType.DisplayLayout.Appearance = Appearance61
        Me.cbWoodType.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cbWoodType.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance62.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance62.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance62.BorderColor = System.Drawing.SystemColors.Window
        Me.cbWoodType.DisplayLayout.GroupByBox.Appearance = Appearance62
        Appearance63.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cbWoodType.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance63
        Me.cbWoodType.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance64.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance64.BackColor2 = System.Drawing.SystemColors.Control
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance64.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cbWoodType.DisplayLayout.GroupByBox.PromptAppearance = Appearance64
        Me.cbWoodType.DisplayLayout.MaxColScrollRegions = 1
        Me.cbWoodType.DisplayLayout.MaxRowScrollRegions = 1
        Appearance65.BackColor = System.Drawing.SystemColors.Window
        Appearance65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbWoodType.DisplayLayout.Override.ActiveCellAppearance = Appearance65
        Appearance66.BackColor = System.Drawing.SystemColors.Highlight
        Appearance66.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cbWoodType.DisplayLayout.Override.ActiveRowAppearance = Appearance66
        Me.cbWoodType.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cbWoodType.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance67.BackColor = System.Drawing.SystemColors.Window
        Me.cbWoodType.DisplayLayout.Override.CardAreaAppearance = Appearance67
        Appearance68.BorderColor = System.Drawing.Color.Silver
        Appearance68.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cbWoodType.DisplayLayout.Override.CellAppearance = Appearance68
        Me.cbWoodType.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cbWoodType.DisplayLayout.Override.CellPadding = 0
        Appearance69.BackColor = System.Drawing.SystemColors.Control
        Appearance69.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance69.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance69.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance69.BorderColor = System.Drawing.SystemColors.Window
        Me.cbWoodType.DisplayLayout.Override.GroupByRowAppearance = Appearance69
        Appearance70.TextHAlignAsString = "Left"
        Me.cbWoodType.DisplayLayout.Override.HeaderAppearance = Appearance70
        Me.cbWoodType.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cbWoodType.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance71.BackColor = System.Drawing.SystemColors.Window
        Appearance71.BorderColor = System.Drawing.Color.Silver
        Me.cbWoodType.DisplayLayout.Override.RowAppearance = Appearance71
        Me.cbWoodType.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance72.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbWoodType.DisplayLayout.Override.TemplateAddRowAppearance = Appearance72
        Me.cbWoodType.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cbWoodType.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cbWoodType.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cbWoodType.Location = New System.Drawing.Point(364, 29)
        Me.cbWoodType.Name = "cbWoodType"
        Me.cbWoodType.Size = New System.Drawing.Size(125, 22)
        Me.cbWoodType.TabIndex = 14
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(745, 29)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(110, 23)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(633, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 17)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Reason"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(529, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 17)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Qty"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(495, 31)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(108, 20)
        Me.txtQty.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(337, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 17)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Species/Wood Type"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ugRecentlyPrinted)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1242, 491)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "Recently Printed"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ugRecentlyPrinted
        '
        Me.ugRecentlyPrinted.ContextMenuStrip = Me.ContextMenuStrip2
        Appearance73.BackColor = System.Drawing.SystemColors.Window
        Appearance73.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugRecentlyPrinted.DisplayLayout.Appearance = Appearance73
        Me.ugRecentlyPrinted.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugRecentlyPrinted.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance74.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance74.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance74.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance74.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRecentlyPrinted.DisplayLayout.GroupByBox.Appearance = Appearance74
        Appearance75.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRecentlyPrinted.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance75
        Me.ugRecentlyPrinted.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugRecentlyPrinted.DisplayLayout.GroupByBox.Hidden = True
        Appearance76.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance76.BackColor2 = System.Drawing.SystemColors.Control
        Appearance76.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance76.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRecentlyPrinted.DisplayLayout.GroupByBox.PromptAppearance = Appearance76
        Me.ugRecentlyPrinted.DisplayLayout.MaxColScrollRegions = 1
        Me.ugRecentlyPrinted.DisplayLayout.MaxRowScrollRegions = 1
        Appearance77.BackColor = System.Drawing.SystemColors.Window
        Appearance77.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugRecentlyPrinted.DisplayLayout.Override.ActiveCellAppearance = Appearance77
        Appearance78.BackColor = System.Drawing.SystemColors.Highlight
        Appearance78.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugRecentlyPrinted.DisplayLayout.Override.ActiveRowAppearance = Appearance78
        Me.ugRecentlyPrinted.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugRecentlyPrinted.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugRecentlyPrinted.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugRecentlyPrinted.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugRecentlyPrinted.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugRecentlyPrinted.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugRecentlyPrinted.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance79.BackColor = System.Drawing.SystemColors.Window
        Me.ugRecentlyPrinted.DisplayLayout.Override.CardAreaAppearance = Appearance79
        Appearance80.BorderColor = System.Drawing.Color.Silver
        Appearance80.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugRecentlyPrinted.DisplayLayout.Override.CellAppearance = Appearance80
        Me.ugRecentlyPrinted.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugRecentlyPrinted.DisplayLayout.Override.CellPadding = 0
        Me.ugRecentlyPrinted.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.ugRecentlyPrinted.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance81.BackColor = System.Drawing.SystemColors.Control
        Appearance81.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance81.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance81.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRecentlyPrinted.DisplayLayout.Override.GroupByRowAppearance = Appearance81
        Appearance82.TextHAlignAsString = "Left"
        Me.ugRecentlyPrinted.DisplayLayout.Override.HeaderAppearance = Appearance82
        Me.ugRecentlyPrinted.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugRecentlyPrinted.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance83.BackColor = System.Drawing.SystemColors.Window
        Appearance83.BorderColor = System.Drawing.Color.Silver
        Me.ugRecentlyPrinted.DisplayLayout.Override.RowAppearance = Appearance83
        Me.ugRecentlyPrinted.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance84.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugRecentlyPrinted.DisplayLayout.Override.TemplateAddRowAppearance = Appearance84
        Me.ugRecentlyPrinted.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugRecentlyPrinted.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugRecentlyPrinted.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugRecentlyPrinted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugRecentlyPrinted.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugRecentlyPrinted.Location = New System.Drawing.Point(0, 0)
        Me.ugRecentlyPrinted.Name = "ugRecentlyPrinted"
        Me.ugRecentlyPrinted.Size = New System.Drawing.Size(1242, 491)
        Me.ugRecentlyPrinted.TabIndex = 48
        Me.ugRecentlyPrinted.Text = "UltraGrid1"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReprintSelectedSummaryToolStripMenuItem, Me.ReprintSelectedDoorListsToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(215, 48)
        '
        'ReprintSelectedSummaryToolStripMenuItem
        '
        Me.ReprintSelectedSummaryToolStripMenuItem.Name = "ReprintSelectedSummaryToolStripMenuItem"
        Me.ReprintSelectedSummaryToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ReprintSelectedSummaryToolStripMenuItem.Text = "Reprint Selected Summary"
        '
        'ReprintSelectedDoorListsToolStripMenuItem
        '
        Me.ReprintSelectedDoorListsToolStripMenuItem.Name = "ReprintSelectedDoorListsToolStripMenuItem"
        Me.ReprintSelectedDoorListsToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ReprintSelectedDoorListsToolStripMenuItem.Text = "Reprint Selected Door Lists"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ugDOMAStockOrders)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1242, 491)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "DOMA Stock Orders"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ugDOMAStockOrders
        '
        Me.ugDOMAStockOrders.ContextMenuStrip = Me.ContextMenuStrip3
        Appearance85.BackColor = System.Drawing.SystemColors.Window
        Appearance85.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDOMAStockOrders.DisplayLayout.Appearance = Appearance85
        Me.ugDOMAStockOrders.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDOMAStockOrders.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance86.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance86.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance86.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance86.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDOMAStockOrders.DisplayLayout.GroupByBox.Appearance = Appearance86
        Appearance87.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDOMAStockOrders.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance87
        Me.ugDOMAStockOrders.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDOMAStockOrders.DisplayLayout.GroupByBox.Hidden = True
        Appearance88.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance88.BackColor2 = System.Drawing.SystemColors.Control
        Appearance88.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance88.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDOMAStockOrders.DisplayLayout.GroupByBox.PromptAppearance = Appearance88
        Me.ugDOMAStockOrders.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDOMAStockOrders.DisplayLayout.MaxRowScrollRegions = 1
        Appearance89.BackColor = System.Drawing.SystemColors.Window
        Appearance89.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDOMAStockOrders.DisplayLayout.Override.ActiveCellAppearance = Appearance89
        Appearance90.BackColor = System.Drawing.SystemColors.Highlight
        Appearance90.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDOMAStockOrders.DisplayLayout.Override.ActiveRowAppearance = Appearance90
        Me.ugDOMAStockOrders.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDOMAStockOrders.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDOMAStockOrders.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDOMAStockOrders.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDOMAStockOrders.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDOMAStockOrders.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDOMAStockOrders.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance91.BackColor = System.Drawing.SystemColors.Window
        Me.ugDOMAStockOrders.DisplayLayout.Override.CardAreaAppearance = Appearance91
        Appearance92.BorderColor = System.Drawing.Color.Silver
        Appearance92.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDOMAStockOrders.DisplayLayout.Override.CellAppearance = Appearance92
        Me.ugDOMAStockOrders.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugDOMAStockOrders.DisplayLayout.Override.CellPadding = 0
        Me.ugDOMAStockOrders.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.ugDOMAStockOrders.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance93.BackColor = System.Drawing.SystemColors.Control
        Appearance93.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance93.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance93.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance93.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDOMAStockOrders.DisplayLayout.Override.GroupByRowAppearance = Appearance93
        Appearance94.TextHAlignAsString = "Left"
        Me.ugDOMAStockOrders.DisplayLayout.Override.HeaderAppearance = Appearance94
        Me.ugDOMAStockOrders.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDOMAStockOrders.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance95.BackColor = System.Drawing.SystemColors.Window
        Appearance95.BorderColor = System.Drawing.Color.Silver
        Me.ugDOMAStockOrders.DisplayLayout.Override.RowAppearance = Appearance95
        Me.ugDOMAStockOrders.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance96.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDOMAStockOrders.DisplayLayout.Override.TemplateAddRowAppearance = Appearance96
        Me.ugDOMAStockOrders.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDOMAStockOrders.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDOMAStockOrders.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDOMAStockOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDOMAStockOrders.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDOMAStockOrders.Location = New System.Drawing.Point(0, 0)
        Me.ugDOMAStockOrders.Name = "ugDOMAStockOrders"
        Me.ugDOMAStockOrders.Size = New System.Drawing.Size(1242, 491)
        Me.ugDOMAStockOrders.TabIndex = 49
        Me.ugDOMAStockOrders.Text = "UltraGrid1"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(114, 26)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmDoorsOnDemand
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1500, 633)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDoorsOnDemand"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Doors on Demand"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.Assembled.ResumeLayout(False)
        Me.Assembled.PerformLayout()
        CType(Me.uccTarget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lvOrderDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.lvStyle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lvOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Rejected.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ugRejected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbReason, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbWoodType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.ugRecentlyPrinted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.ugDOMAStockOrders, System.ComponentModel.ISupportInitialize).EndInit()
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
                        KPGeneral.WebRef_Local.usp__WatchList_SendRawDoorsEmail(dsCancelOrderCheck.Tables(0).Rows(0).Item("CSID"), Style, Colour)
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


                'lvStyle.Items.Clear()
                'lvOrderDetail.Items.Clear()
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

            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.spKP_RawDoorOrderList_New()

            lvOrderList.DataSource = ds


            lvOrderList.DisplayLayout.Bands(0).Columns("TS").Header.ToolTipText = "Total Styles"
            lvOrderList.DisplayLayout.Bands(0).Columns("TS").Header.Caption = "#ST"
            lvOrderList.DisplayLayout.Bands(0).Columns("TDL").Header.ToolTipText = "Total Door Lists"
            lvOrderList.DisplayLayout.Bands(0).Columns("TDL").Header.ToolTipText = "#DL"
            lvOrderList.DisplayLayout.Bands(0).Columns("Note").Header.ToolTipText = "Glazing or Customer Sample"
            lvOrderList.DisplayLayout.Bands(0).Columns("SQM").Header.ToolTipText = "Square Meters"
            lvOrderList.DisplayLayout.Bands(0).Columns("LP_DPL").Header.ToolTipText = "Last Printed Door List"
            lvOrderList.DisplayLayout.Bands(0).Columns("ENP_SRD").Header.ToolTipText = "Earliest Not Printed Site Request Date"
            lvOrderList.DisplayLayout.Bands(0).Columns("MaterialColour").Header.Caption = "Colour"

            lvOrderList.DisplayLayout.Bands(0).Columns("RefSample").Hidden = True
            lvOrderList.DisplayLayout.Bands(0).Columns("Colour").Hidden = True
            lvOrderList.DisplayLayout.Bands(0).Columns("Glazing").Hidden = True

            lvOrderList.DisplayLayout.Bands(0).Columns("MaterialColour").Width = 140
            lvOrderList.DisplayLayout.Bands(0).Columns("Note").Width = 70
            lvOrderList.DisplayLayout.Bands(0).Columns("TS").Width = 30
            lvOrderList.DisplayLayout.Bands(0).Columns("TDL").Width = 30
            lvOrderList.DisplayLayout.Bands(0).Columns("SQM").Width = 50
            lvOrderList.DisplayLayout.Bands(0).Columns("SQM").Format = "#"
            lvOrderList.DisplayLayout.Bands(0).Columns("LP_DPL").Width = 75
            lvOrderList.DisplayLayout.Bands(0).Columns("ENP_SRD").Width = 75

            lvOrderList.DisplayLayout.Bands(0).Columns("MaterialColour").Header.VisiblePosition = 1
            lvOrderList.DisplayLayout.Bands(0).Columns("Note").Header.VisiblePosition = 2
            lvOrderList.DisplayLayout.Bands(0).Columns("TS").Header.VisiblePosition = 3
            lvOrderList.DisplayLayout.Bands(0).Columns("TDL").Header.VisiblePosition = 4
            lvOrderList.DisplayLayout.Bands(0).Columns("SQM").Header.VisiblePosition = 5
            lvOrderList.DisplayLayout.Bands(0).Columns("LP_DPL").Header.VisiblePosition = 7
            lvOrderList.DisplayLayout.Bands(0).Columns("ENP_SRD").Header.VisiblePosition = 6


            CheckTargetDates()

            lvStyle.DataSource = Nothing
            lvOrderDetail.DataSource = Nothing

            lvOrderList.Selected.Rows.Clear()
            lvOrderList.ActiveRow = Nothing
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Sub fillStyleList()
        Try
            If lvOrderList.ActiveRow.Index > -1 Then

                Dim RefSample As String

                If lvOrderList.ActiveRow.Cells("RefSample").Text <> "" Then
                    RefSample = 1
                Else
                    RefSample = 0
                End If

                Dim ds As New DataSet
                ds = KPGeneral.WebRef_Local.spKP_RawDoorOrderListByStyle_New(lvOrderList.ActiveRow.Cells("MaterialColour").Text, lvOrderList.ActiveRow.Cells("Glazing").Text, RefSample)

                lvStyle.DataSource = ds

                lvStyle.DisplayLayout.Bands(0).Columns("Style").Header.ToolTipText = "Door Style"
                lvStyle.DisplayLayout.Bands(0).Columns("TDL").Header.ToolTipText = "Total Door Lists"
                lvStyle.DisplayLayout.Bands(0).Columns("TDL").Header.Caption = "#DL"
                lvStyle.DisplayLayout.Bands(0).Columns("Note").Header.ToolTipText = "Glazing or Customer Sample"
                lvStyle.DisplayLayout.Bands(0).Columns("SQM").Header.ToolTipText = "Square Meters"
                lvStyle.DisplayLayout.Bands(0).Columns("ENP_SRD").Header.ToolTipText = "Earliest Not Printed Site Request Date"


                lvStyle.DisplayLayout.Bands(0).Columns("RefSample").Hidden = True
                lvStyle.DisplayLayout.Bands(0).Columns("Glazing").Hidden = True

                lvStyle.DisplayLayout.Bands(0).Columns("Style").Width = 125
                lvStyle.DisplayLayout.Bands(0).Columns("Note").Width = 75
                lvStyle.DisplayLayout.Bands(0).Columns("Done").Width = 15
                lvStyle.DisplayLayout.Bands(0).Columns("TDL").Width = 40
                lvStyle.DisplayLayout.Bands(0).Columns("SQM").Width = 45
                lvStyle.DisplayLayout.Bands(0).Columns("SQM").Format = "#"
                lvStyle.DisplayLayout.Bands(0).Columns("ENP_SRD").Width = 75


                lvStyle.DisplayLayout.Bands(0).Columns("Style").Header.VisiblePosition = 1
                lvStyle.DisplayLayout.Bands(0).Columns("Note").Header.VisiblePosition = 2
                lvStyle.DisplayLayout.Bands(0).Columns("TDL").Header.VisiblePosition = 3
                lvStyle.DisplayLayout.Bands(0).Columns("SQM").Header.VisiblePosition = 4
                lvStyle.DisplayLayout.Bands(0).Columns("ENP_SRD").Header.VisiblePosition = 5
                lvStyle.DisplayLayout.Bands(0).Columns("Done").Header.VisiblePosition = 6


                Dim x As Integer
                For x = 0 To lvStyle.Rows.Count - 1

                    If lvStyle.Rows(x).Cells("Done").Value = lvStyle.Rows(x).Cells("TDL").Value Then
                        lvStyle.Rows(x).Cells("Done").Appearance.BackColor = Color.Green
                        lvStyle.Rows(x).Cells("Done").Appearance.ForeColor = Color.Green
                        'lvStyle.Items(x).SubItems.Add("", Color.Black, Color.Green, Font)
                    Else
                        lvStyle.Rows(x).Cells("Done").Appearance.BackColor = Color.Red
                        lvStyle.Rows(x).Cells("Done").Appearance.ForeColor = Color.Red
                        'lvStyle.Items(x).SubItems.Add("", Color.Black, Color.Red, Font)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lvOrderList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fillStyleList()


    End Sub

    Private Sub lvStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fillOrderDetail()


    End Sub
    Sub fillOrderDetail()
        Try
            If lvStyle.ActiveRow.Index > -1 Then

                Dim RefSample As String

                If lvStyle.ActiveRow.Cells("RefSample").Text <> "" Then
                    RefSample = 1
                Else
                    RefSample = 0
                End If

                Dim ds As New DataSet
                ds = KPGeneral.WebRef_Local.spKP_RawDoorOrderList_Detail_New(lvOrderList.ActiveRow.Cells("MaterialColour").Text, lvStyle.ActiveRow.Cells("Style").Text, lvStyle.ActiveRow.Cells("Glazing").Text, RefSample)

                lvOrderDetail.DataSource = ds
                lvOrderDetail.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
                lvOrderDetail.DisplayLayout.Bands(0).Columns("SumID").Hidden = True
                lvOrderDetail.DisplayLayout.Bands(0).Columns("DoorsOnDemandSummaryID").Hidden = True

                lvOrderDetail.DisplayLayout.Bands(0).Columns("SiteRequest").Header.Caption = "SRD"
                lvOrderDetail.DisplayLayout.Bands(0).Columns("TotalDoors").Header.Caption = "DC"
                lvOrderDetail.DisplayLayout.Bands(0).Columns("ClassificationLevel").Header.Caption = "CL"


                lblDoorListsShown.Text = "Door Lists Shown: " & lvOrderDetail.Rows.Count

                lvOrderDetail.DisplayLayout.Bands(0).Columns("Schedule").Header.VisiblePosition = 1
                lvOrderDetail.DisplayLayout.Bands(0).Columns("SiteRequest").Header.VisiblePosition = 2
                lvOrderDetail.DisplayLayout.Bands(0).Columns("ClassificationLevel").Header.VisiblePosition = 3
                lvOrderDetail.DisplayLayout.Bands(0).Columns("MASTERNUM").Header.VisiblePosition = 4
                lvOrderDetail.DisplayLayout.Bands(0).Columns("COMPANY").Header.VisiblePosition = 5
                lvOrderDetail.DisplayLayout.Bands(0).Columns("PROJECT").Header.VisiblePosition = 6
                lvOrderDetail.DisplayLayout.Bands(0).Columns("LOT").Header.VisiblePosition = 7
                lvOrderDetail.DisplayLayout.Bands(0).Columns("TotalDoors").Header.VisiblePosition = 8
                lvOrderDetail.DisplayLayout.Bands(0).Columns("DLP").Header.VisiblePosition = 9
                lvOrderDetail.DisplayLayout.Bands(0).Columns("R").Header.VisiblePosition = 10
                lvOrderDetail.DisplayLayout.Bands(0).Columns("F").Header.VisiblePosition = 11

                Dim TotalDoorCount As Integer = 0

                Dim x As Integer
                For x = 0 To lvOrderDetail.Rows.Count - 1
                    If IsDBNull(lvOrderDetail.Rows(x).Cells("R").Value) = False Then
                        lvOrderDetail.Rows(x).Cells("R").Appearance.BackColor = Color.Green
                        lvOrderDetail.Rows(x).Cells("R").Appearance.ForeColor = Color.White
                    Else
                        lvOrderDetail.Rows(x).Cells("R").Appearance.BackColor = Color.Red
                        lvOrderDetail.Rows(x).Cells("R").Appearance.ForeColor = Color.Red
                    End If
                    If IsDBNull(lvOrderDetail.Rows(x).Cells("F").Value) = False Then
                        lvOrderDetail.Rows(x).Cells("F").Appearance.BackColor = Color.Green
                        lvOrderDetail.Rows(x).Cells("F").Appearance.ForeColor = Color.Green
                    Else
                        lvOrderDetail.Rows(x).Cells("F").Appearance.BackColor = Color.Red
                        lvOrderDetail.Rows(x).Cells("F").Appearance.ForeColor = Color.Red
                    End If
                    If IsDBNull(lvOrderDetail.Rows(x).Cells("DLP").Value) = False Then
                        lvOrderDetail.Rows(x).Cells("DLP").Appearance.BackColor = Color.Green
                        lvOrderDetail.Rows(x).Cells("DLP").Appearance.ForeColor = Color.White
                    Else
                        lvOrderDetail.Rows(x).Cells("DLP").Appearance.BackColor = Color.Red
                        lvOrderDetail.Rows(x).Cells("DLP").Appearance.ForeColor = Color.Red
                    End If

                    If Not IsDBNull(lvOrderDetail.Rows(x).Cells("TotalDoors").Value) Then
                        TotalDoorCount = TotalDoorCount + lvOrderDetail.Rows(x).Cells("TotalDoors").Value
                    End If

                Next

                lvOrderDetail.DisplayLayout.Bands(0).Columns("Schedule").Width = 85
                lvOrderDetail.DisplayLayout.Bands(0).Columns("SiteRequest").Width = 85
                lvOrderDetail.DisplayLayout.Bands(0).Columns("ClassificationLevel").Width = 40
                lvOrderDetail.DisplayLayout.Bands(0).Columns("COMPANY").Width = 150
                lvOrderDetail.DisplayLayout.Bands(0).Columns("PROJECT").Width = 150
                lvOrderDetail.DisplayLayout.Bands(0).Columns("LOT").Width = 100

                lvOrderDetail.DisplayLayout.Bands(0).Columns("R").Width = 75
                lvOrderDetail.DisplayLayout.Bands(0).Columns("F").Width = 35
                lvOrderDetail.DisplayLayout.Bands(0).Columns("TotalDoors").Width = 35
                lvOrderDetail.DisplayLayout.Bands(0).Columns("DLP").Width = 75

                lblDoorsShown.Text = "Total Doors Shown: " & TotalDoorCount

                lvOrderDetail.DisplayLayout.Bands(0).Columns("Schedule").Header.ToolTipText = "Site Request Date or Expected Ship Date"
                lvOrderDetail.DisplayLayout.Bands(0).Columns("R").Header.ToolTipText = "Raw Finished"
                lvOrderDetail.DisplayLayout.Bands(0).Columns("F").Header.ToolTipText = "Paint Finished"
                lvOrderDetail.DisplayLayout.Bands(0).Columns("TotalDoors").Header.ToolTipText = "Door Count"
                lvOrderDetail.DisplayLayout.Bands(0).Columns("DLP").Header.ToolTipText = "Door List Printed"

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmProcessScanAssembly_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillColourList()

        KPGeneral.SetDefaultGridSettings(ugDOMAStockOrders)
        KPGeneral.SetDefaultGridSettings(ugRecentlyPrinted)
        KPGeneral.SetDefaultGridSettings(lvOrderDetail)
        KPGeneral.SetDefaultGridSettings(lvOrderList)
        KPGeneral.SetDefaultGridSettings(lvStyle)

        uccTarget.Value = DateAdd(DateInterval.Day, 21, Now.Date)

    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If lvOrderDetail.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByMasterNum(lvOrderDetail.ActiveRow.Cells("MasterNum").Text)
        Else
            MessageBox.Show("Invalid Selection: Cannot Display Door List.")
        End If
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        If lvOrderDetail.ActiveRow.Index > -1 Then
            Dim x As String
            x = Trim(lvOrderDetail.ActiveRow.Cells("MasterNum").Text)
            Clipboard.SetDataObject(x)
        Else
            MessageBox.Show("Invalid Selection: Cannot Copy Barcode")
        End If
    End Sub

    Private Sub LogMissingDoorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm As New frmPaintMissingDoors(lvScan.SelectedItems(0).SubItems(1).Text, "RAW")
            frm.ShowDialog()

            'RefreshMissingList()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Name = "Assembled" Then
            fillColourList()
        ElseIf TabControl1.SelectedTab.Text = "Recently Printed" Then
            RefreshRecentlyPrinted()
        ElseIf TabControl1.SelectedTab.Text = "DOMA Stock Orders" Then
            RefreshDomaOrders()
        ElseIf TabControl1.SelectedTab.Name = "Rejected" Then
            FillcbWoodType()

            Dim dsReason As New DataSet
            dsReason = KPGeneral.WebRef_Local.usp_GetDoorOrderReasonList()
            cbReason.DataSource = dsReason.Tables(0)
            cbReason.DisplayMember = "OrderReason"
            cbReason.ValueMember = "ID"
            cbReason.DisplayLayout.Bands(0).Columns("ID").Hidden = True

            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.spKPFactory_RejectedDoorsCurrentDay_Species(Date.Now, "Production")
            ugRejected.DataSource = ds
            ugRejected.DisplayLayout.Bands(0).Columns("ID").Hidden = True

            'cbColour.DataSource = Nothing
            'cbColour.Text = Nothing
            txtQty.Text = Nothing
            cbReason.Text = Nothing
        End If
    End Sub
    Private Sub FillcbWoodType()

        Dim dsWoodType As New DataSet
        dsWoodType = KPGeneral.WebRef_Local.usp_getDoorSpecies

        cbWoodType.DataSource = dsWoodType


        Dim y As Integer
        For y = 0 To cbWoodType.DisplayLayout.Bands(0).Columns.Count - 1
            If cbWoodType.DisplayLayout.Bands(0).Columns(y).Header.Caption <> "Species" Then
                cbWoodType.DisplayLayout.Bands(0).Columns(y).Hidden = True
            Else
                cbWoodType.DisplayLayout.Bands(0).Columns(y).Hidden = False
            End If
        Next

        cbWoodType.DisplayLayout.Bands(0).Columns("Species").Width = cbWoodType.Width
        cbWoodType.DisplayMember = "Species"

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
    Private Sub ugDoorsNeeded_InitializePrint(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs)
        e.DefaultLogicalPageLayoutInfo.PageHeader = "Doors Needed"

        e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center

        e.DefaultLogicalPageLayoutInfo.PageFooter = "Printed on " & Now & vbTab & "Page <#> of <##>"
        e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 20
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    End Sub
    Private Sub ugDoorsNeeded_InitializePrintPreview(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelablePrintPreviewEventArgs)
        e.DefaultLogicalPageLayoutInfo.PageHeader = "Doors Needed"

        e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center

        e.DefaultLogicalPageLayoutInfo.PageFooter = "Printed on " & Now & vbTab & "Page <#> of <##>"
        e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 20
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    End Sub

    Private Sub lvOrderList_AfterRowActivate(sender As Object, e As EventArgs) Handles lvOrderList.AfterRowActivate
        fillStyleList()
        CheckTargetDates()

        lvOrderDetail.DataSource = Nothing

        lvStyle.Selected.Rows.Clear()
        lvStyle.ActiveRow = Nothing
        'lvOrderDetail.Items.Clear()
    End Sub

    Private Sub lvStyle_AfterRowActivate(sender As Object, e As EventArgs) Handles lvStyle.AfterRowActivate
        fillOrderDetail()
        CheckTargetDates()

        lvOrderDetail.Selected.Rows.Clear()
        lvOrderDetail.ActiveRow = Nothing
    End Sub


    Private Sub PrintDoorSummary()
        Try
            'dsBatchDoorList.WriteXml("c:\xml\doorlist.xml", XmlWriteMode.WriteSchema)

            Dim RptDoc As New RptDoorsOnDemand_Summary 'RptDoorlistSummary
            RptDoc.SetDataSource(dsBatchDoorList)
            'RptDoc.PrintOptions.PrinterName = tx
            RptDoc.PrintOptions.PaperSource = CrystalDecisions.[Shared].PaperSource.Auto
            RptDoc.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
            RptDoc.Close()
            RptDoc.Dispose()

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub PrintDoorSummary_Service()
        Try
            'dsBatchDoorList.WriteXml("c:\xml\doorlist.xml", XmlWriteMode.WriteSchema)

            Dim RptDoc As New RptDoorsOnDemand_Summary_Service 'RptDoorlistSummary
            RptDoc.SetDataSource(dsBatchDoorList)
            'RptDoc.PrintOptions.PrinterName = tx
            RptDoc.PrintOptions.PaperSource = CrystalDecisions.[Shared].PaperSource.Auto
            RptDoc.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
            RptDoc.Close()
            RptDoc.Dispose()

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub PrintDoorSummaryDoorLists()
        Try
            ' dsBatchDoorList.WriteXml("c:\xml\doorlist.xml", XmlWriteMode.WriteSchema)

            Dim RptDoc As New RptDoorsOnDemand_Summary_DoorList 'RptDoorlistSummary
            RptDoc.SetDataSource(dsBatchDoorList)
            'RptDoc.PrintOptions.PrinterName = tx
            RptDoc.PrintOptions.PaperSource = CrystalDecisions.[Shared].PaperSource.Auto
            RptDoc.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
            RptDoc.Close()
            RptDoc.Dispose()

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub PrintDoorSummaryDoorLists_Service()
        Try
            'dsBatchDoorList.WriteXml("c:\xml\doorlist.xml", XmlWriteMode.WriteSchema)

            Dim RptDoc As New RptDoorsOnDemand_Summary_DoorList_Service 'RptDoorlistSummary
            RptDoc.SetDataSource(dsBatchDoorList)
            'RptDoc.PrintOptions.PrinterName = tx
            RptDoc.PrintOptions.PaperSource = CrystalDecisions.[Shared].PaperSource.Auto
            RptDoc.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
            RptDoc.Close()
            RptDoc.Dispose()

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub filldsBatchDoorList(ByVal CurrentBatchNum As Integer)
        Try
            Dim dsDDR As New DataSet
            Dim tempDS As New DataSet
            Dim dr As DataRow
            ' =================================
            Dim dtDDR As New DataTable
            Dim dtDrawerDrawerList As New DataTable("spKP_GetDoorDrawerList")
            Dim dtSpecialDoor As New DataTable("SpecialDoor")
            Dim dtSpecialDrawer As New DataTable("SpecialDrawer")
            Dim dtSpecialDoorCuts As New DataTable("spKP_getDoorDrawerListSpecialDoorCuts")
            Dim dtRoomInfo As New DataTable("MNRoomInfo")

            dsDDR.Tables.Add(dtDrawerDrawerList)
            dsDDR.Tables.Add(dtSpecialDoor)
            dsDDR.Tables.Add(dtSpecialDrawer)
            dsDDR.Tables.Add(dtSpecialDoorCuts)
            dsDDR.Tables.Add(dtRoomInfo)
            ' =================================
            ' Get the start and end week
            tempDS.Tables.Add()
            tempDS.Tables(0).Columns.Add("FDate", System.Type.GetType("System.DateTime"))
            tempDS.Tables(0).Columns.Add("TDate", System.Type.GetType("System.DateTime"))
            tempDS.Tables(0).Columns.Add("PO", System.Type.GetType("System.String"))
            dr = tempDS.Tables(0).NewRow
            dr.Item(0) = Now.Date
            dr.Item(1) = Now.Date
            tempDS.Tables(0).Rows.Add(dr)
            ' Get Door Drawer List Main
            ' ========================================================
            Dim rsDoor As New DataSet
            rsDoor = KPGeneral.WebRef_Local.spKPBatch_GetDoorDrawerList_DoorsOnDemand(CurrentBatchNum)

            If rsDoor.Tables(0).Rows.Count > 0 Then
                BatchHasDoors = True
            Else
                BatchHasDoors = False
            End If

            tempDS.Tables.Add(rsDoor.Tables(0).Copy)
            'tempDS.Tables(0).Rows(0)("PO") = rsDoor.Tables(0).Rows(0)("OrderRefNo")
            tempDS.Tables(0).Rows(0)("PO") = ""
            ' Get Special Door Sizes
            ' ========================================================
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_getDoorDrawerListSpecialCutImage_DoorsOnDemand(CurrentBatchNum).Tables(0).Copy)
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_getDoorDrawerListSpecialCutImageData_DoorsOnDemand(CurrentBatchNum).Tables(0).Copy)
            ' Get All Room Info 
            ' ========================================================
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_GetRoomInfo_DoorsOnDemand(CurrentBatchNum).Tables(0).Copy)
            ' Create the xml file /// pass to ds
            tempDS.Tables("RoomInfo").TableName = "MNRoomInfo"
            tempDS.Tables.Add(dtDDR)
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_BOM_DoorsOnDemand(CurrentBatchNum).Tables(0).Copy)

            dsBatchDoorList.Tables.Clear()
            dsBatchDoorList = tempDS.Copy
            tempDS.WriteXml("c:\xml\doorlist.xml", XmlWriteMode.WriteSchema)
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub filldsBatchDoorList_Service(ByVal CurrentBatchNum As Integer)
        Try
            Dim dsDDR As New DataSet
            Dim tempDS As New DataSet
            Dim dr As DataRow
            ' =================================
            Dim dtDDR As New DataTable
            Dim dtDrawerDrawerList As New DataTable("spKP_GetDoorDrawerList")
            Dim dtSpecialDoor As New DataTable("SpecialDoor")
            Dim dtSpecialDrawer As New DataTable("SpecialDrawer")
            Dim dtSpecialDoorCuts As New DataTable("spKP_getDoorDrawerListSpecialDoorCuts")
            Dim dtRoomInfo As New DataTable("MNRoomInfo")

            dsDDR.Tables.Add(dtDrawerDrawerList)
            dsDDR.Tables.Add(dtSpecialDoor)
            dsDDR.Tables.Add(dtSpecialDrawer)
            dsDDR.Tables.Add(dtSpecialDoorCuts)
            dsDDR.Tables.Add(dtRoomInfo)
            ' =================================
            ' Get the start and end week
            tempDS.Tables.Add()
            tempDS.Tables(0).Columns.Add("FDate", System.Type.GetType("System.DateTime"))
            tempDS.Tables(0).Columns.Add("TDate", System.Type.GetType("System.DateTime"))
            tempDS.Tables(0).Columns.Add("PO", System.Type.GetType("System.String"))
            dr = tempDS.Tables(0).NewRow
            dr.Item(0) = Now.Date
            dr.Item(1) = Now.Date
            tempDS.Tables(0).Rows.Add(dr)
            ' Get Door Drawer List Main
            ' ========================================================
            Dim rsDoor As New DataSet
            rsDoor = KPGeneral.WebRef_Local.spKPBatch_GetDoorDrawerList_DoorsOnDemand_Service(CurrentBatchNum)

            If rsDoor.Tables(0).Rows.Count > 0 Then
                BatchHasDoorsService = True
            Else
                BatchHasDoorsService = False
            End If

            tempDS.Tables.Add(rsDoor.Tables(0).Copy)
            'tempDS.Tables(0).Rows(0)("PO") = rsDoor.Tables(0).Rows(0)("OrderRefNo")
            tempDS.Tables(0).Rows(0)("PO") = ""
            ' Get Special Door Sizes
            ' ========================================================
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_getDoorDrawerListSpecialCutImage_DoorsOnDemand_Service(CurrentBatchNum).Tables(0).Copy)
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_getDoorDrawerListSpecialCutImageData_DoorsOnDemand_Service(CurrentBatchNum).Tables(0).Copy)
            ' Get All Room Info 
            ' ========================================================
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_GetRoomInfo_DoorsOnDemand_Service(CurrentBatchNum).Tables(0).Copy)
            ' Create the xml file /// pass to ds
            tempDS.Tables("RoomInfo").TableName = "MNRoomInfo"
            tempDS.Tables.Add(dtDDR)
            tempDS.Tables.Add(KPGeneral.WebRef_Local.spKPBatch_BOM_DoorsOnDemand_Service(CurrentBatchNum).Tables(0).Copy)

            dsBatchDoorList.Tables.Clear()
            dsBatchDoorList = tempDS.Copy
            tempDS.WriteXml("c:\xml\doorlist.xml", XmlWriteMode.WriteSchema)
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub RefreshListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshListToolStripMenuItem.Click
        fillOrderDetail()
    End Sub

    Private Sub CopyBarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyBarcodeToolStripMenuItem.Click
        If lvOrderDetail.ActiveRow.Index > -1 Then
            Dim x As String
            x = Trim(lvOrderDetail.ActiveRow.Cells("MasterNum").Text)
            Clipboard.SetDataObject(x)
        Else
            MessageBox.Show("Invalid Selection: Cannot Copy Barcode")
        End If
    End Sub

    Private Sub KitchenTrackerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem.Click
        If lvOrderDetail.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByCSID(lvOrderDetail.ActiveRow.Cells("CSID").Text)
        Else
            MessageBox.Show("Invalid Selection: Cannot Display Door List.")
        End If
    End Sub

    Private Sub PrintSelectedDoorListAndSummarizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintSelectedDoorListAndSummarizeToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If lvOrderDetail.Selected.Rows.Count > 0 Then

            Dim RefSample As String

            If lvOrderList.ActiveRow.Cells("RefSample").Text <> "" Then
                RefSample = 1
            Else
                RefSample = 0
            End If

            Dim CurrentBatchNum As Integer = KPGeneral.WebRef_Local.usp_InsertDoorsOnDemandSummary(KPGeneral.User.UserProfile("UserLoginName"), lvStyle.ActiveRow.Cells("Style").Text, lvOrderList.ActiveRow.Cells("Colour").Text, lvOrderList.ActiveRow.Cells("Glazing").Text, RefSample, lvOrderList.ActiveRow.Cells("MaterialColour").Text)

            If CurrentBatchNum < 0 Then
                MsgBox("There was an issue getting the latest batch number.  Please speak to IT.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                Exit Sub
            End If

            Dim x As Integer
            For x = 0 To lvOrderDetail.Selected.Rows.Count - 1
                If lvOrderDetail.Selected.Rows(x).Cells("DLP").Text <> "" Then
                    MsgBox("The following order has already been printed and will be ignored: " + lvOrderDetail.Selected.Rows(x).Cells("MASTERNUM").Text)
                Else
                    KPGeneral.WebRef_Local.usp_Update_DoorDrawerListStatus_DOD_SummaryID(lvOrderDetail.Selected.Rows(x).Cells("SUMID").Text, CurrentBatchNum)
                End If

            Next

            filldsBatchDoorList(CurrentBatchNum)

            If BatchHasDoors = True Then
                If lvOrderDetail.Selected.Rows.Count > 1 Then
                    PrintDoorSummary()
                End If

                PrintDoorSummaryDoorLists()
            End If


            filldsBatchDoorList_Service(CurrentBatchNum)

            If BatchHasDoorsService = True Then

                Dim i As Integer

                If lvOrderDetail.Selected.Rows.Count > 1 Then

                    For i = 0 To lvOrderDetail.Selected.Rows.Count - 1
                        KPGeneral.PrintServicePartOrder(lvOrderDetail.Selected.Rows(0).Cells("KeyNo").Text, "Door", lvOrderDetail.Selected.Rows(0).Cells("SNo").Text, lvOrderDetail.Selected.Rows(0).Cells("CSID").Text, False, True)
                    Next

                    ' PrintDoorSummary_Service()

                End If

            End If

            'KPGeneral.PrintServicePartOrder(dg_DoorStatus_DoorList.Selected.Rows(0).Cells("KeyNo").Text, "Door", dg_DoorStatus_DoorList.Selected.Rows(0).Cells("SNo").Text, dg_DoorStatus_DoorList.Selected.Rows(0).Cells("CSID").Text, True, True)
            ' PrintDoorSummaryDoorLists_Service()
        End If



        fillOrderDetail()

            CheckTargetDates()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lvOrderDetail_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles lvOrderDetail.AfterSelectChange
        Dim TotalDoors As Integer = 0
        Dim row As UltraGridRow
        For Each row In lvOrderDetail.Selected.Rows
            If Not IsDBNull(row.Cells("TotalDoors").Value) Then
                TotalDoors = TotalDoors + row.Cells("TotalDoors").Value
            End If
        Next

        lblDoorsSelected.Text = "Total Doors Selected: " & TotalDoors
        lblDoorListsSelected.Text = "Door Lists Selected:  " & lvOrderDetail.Selected.Rows.Count
    End Sub

    Private Sub btnApplyFilter_Click(sender As Object, e As EventArgs) Handles btnApplyFilter.Click
        If lvOrderDetail.DataSource Is Nothing = False Then
            lvOrderDetail.DisplayLayout.Bands(0).ColumnFilters("SiteRequest").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.LessThanOrEqualTo, uccTarget.Text)
            lvOrderDetail.DisplayLayout.Bands(0).ColumnFilters("SiteRequest").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, DBNull.Value)
        End If
        If lvStyle.DataSource Is Nothing = False Then
            lvStyle.DisplayLayout.Bands(0).ColumnFilters("ENP_SRD").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.LessThanOrEqualTo, uccTarget.Text)
            lvStyle.DisplayLayout.Bands(0).ColumnFilters("ENP_SRD").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, DBNull.Value)
        End If
        If lvOrderList.DataSource Is Nothing = False Then
            lvOrderList.DisplayLayout.Bands(0).ColumnFilters("ENP_SRD").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.LessThanOrEqualTo, uccTarget.Text)
            lvOrderList.DisplayLayout.Bands(0).ColumnFilters("ENP_SRD").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, DBNull.Value)
        End If
    End Sub
    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        Dim band As Infragistics.Win.UltraWinGrid.UltraGridBand
        For Each band In lvOrderList.DisplayLayout.Bands
            ' since all rows in a band have the same filters in RowFilterMode.AllRowsInBand this
            ' will clear the filters
            band.ColumnFilters.ClearAllFilters()
        Next

        For Each band In lvStyle.DisplayLayout.Bands
            ' since all rows in a band have the same filters in RowFilterMode.AllRowsInBand this
            ' will clear the filters
            band.ColumnFilters.ClearAllFilters()
        Next

        For Each band In lvOrderDetail.DisplayLayout.Bands
            ' since all rows in a band have the same filters in RowFilterMode.AllRowsInBand this
            ' will clear the filters
            band.ColumnFilters.ClearAllFilters()
        Next
    End Sub
    Private Sub CheckTargetDates()
        Dim x As Integer
        For x = 0 To lvOrderList.Rows.Count - 1
            If IsDBNull(lvOrderList.Rows(x).Cells("ENP_SRD").Value) = False Then
                If lvOrderList.Rows(x).Cells("ENP_SRD").Value <= uccTarget.Text Then
                    lvOrderList.Rows(x).Appearance.BackColor = Color.YellowGreen
                Else
                    lvOrderList.Rows(x).Appearance.BackColor = Color.White
                End If
            End If
        Next

        For x = 0 To lvStyle.Rows.Count - 1
            If IsDBNull(lvStyle.Rows(x).Cells("ENP_SRD").Value) = False Then
                If lvStyle.Rows(x).Cells("ENP_SRD").Value <= uccTarget.Text Then
                    lvStyle.Rows(x).Appearance.BackColor = Color.YellowGreen
                Else
                    lvStyle.Rows(x).Appearance.BackColor = Color.White
                End If
            End If
        Next

        For x = 0 To lvOrderDetail.Rows.Count - 1
            If IsDBNull(lvOrderDetail.Rows(x).Cells("SiteRequest").Value) = False Then
                If lvOrderDetail.Rows(x).Cells("SiteRequest").Value <= uccTarget.Text Then
                    If IsDBNull(lvOrderDetail.Rows(x).Cells("DLP").Value) = True Then
                        lvOrderDetail.Rows(x).Appearance.BackColor = Color.YellowGreen
                    Else
                        lvOrderDetail.Rows(x).Appearance.BackColor = Color.White
                    End If

                Else
                    lvOrderDetail.Rows(x).Appearance.BackColor = Color.White
                End If
            End If
        Next

        For x = 0 To lvOrderDetail.Rows.Count - 1
            If IsDBNull(lvOrderDetail.Rows(x).Cells("OnHold").Value) = False Then
                If lvOrderDetail.Rows(x).Cells("OnHold").Value = True Then
                    lvOrderDetail.Rows(x).Appearance.BackColor = Color.FromName(StatusColours.OnHold_BackColour)
                    lvOrderDetail.Rows(x).Appearance.ForeColor = Color.FromName(StatusColours.OnHold_ForeColour)
                End If
            End If

            If IsDBNull(lvOrderDetail.Rows(x).Cells("SNo").Value) = False Then
                If lvOrderDetail.Rows(x).Cells("SNo").Text.ToLower.StartsWith("p") Then
                    lvOrderDetail.Rows(x).Appearance.BackColor = Color.LightBlue
                    lvOrderDetail.Rows(x).Appearance.ForeColor = Color.Black
                Else
                    lvOrderDetail.Rows(x).Appearance.BackColor = Color.Yellow
                    lvOrderDetail.Rows(x).Appearance.ForeColor = Color.Black
                End If
            End If
        Next

    End Sub
    Private Sub uccTarget_TextChanged(sender As Object, e As EventArgs) Handles uccTarget.TextChanged
        CheckTargetDates()
    End Sub

    Private Sub lvOrderList_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles lvOrderList.AfterSelectChange
        lvOrderList.Selected.Rows.Clear()
    End Sub
    Private Sub lvStyle_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles lvStyle.AfterSelectChange
        lvStyle.Selected.Rows.Clear()
    End Sub
    Private Sub ReprintSelectedSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReprintSelectedSummaryToolStripMenuItem.Click
        ReprintInfo(True)
    End Sub
    Private Sub ReprintSelectedDoorListsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReprintSelectedDoorListsToolStripMenuItem.Click
        ReprintInfo(False)
    End Sub
    Private Sub RefreshRecentlyPrinted()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.spKPBatch_GetDoorDrawerList_RecentlyPrinted()

        ugRecentlyPrinted.DataSource = ds

        ugRecentlyPrinted.DisplayLayout.Bands(0).Columns("DoorsOnDemandSummaryID").Header.Caption = "SummaryID"
    End Sub
    Private Sub ReprintInfo(ByVal Summary As Boolean)
        Me.Cursor = Cursors.WaitCursor

        Dim CurrentBatchNum As Integer

        If ugRecentlyPrinted.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugRecentlyPrinted.Selected.Rows.Count - 1
                CurrentBatchNum = ugRecentlyPrinted.Selected.Rows(x).Cells("DoorsOnDemandSummaryID").Text

                'CurrentBatchNum = 6509

                filldsBatchDoorList(CurrentBatchNum)

                If BatchHasDoors = True Then
                    If Summary = True Then
                        PrintDoorSummary()
                    Else
                        PrintDoorSummaryDoorLists()
                    End If
                End If

                filldsBatchDoorList_Service(CurrentBatchNum)

                If BatchHasDoorsService = True Then
                    If Summary = True Then
                        PrintDoorSummary_Service()
                    Else
                        PrintDoorSummaryDoorLists_Service()
                    End If
                End If

            Next
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub RefreshDomaOrders()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.spKPBatch_GetDOMAStockOrders()

        ugDOMAStockOrders.DataSource = ds

        ugDOMAStockOrders.DisplayLayout.Bands(0).Columns("Style").Width = 250
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshDomaOrders()
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim WoodType, reason, dept As String
        Dim qty As Integer

        dept = KPGeneral.User.UserProfile("UserLoginName")

        If cbWoodType.IsItemInList = True Then
            If cbWoodType.Text.Length > 0 Then
                WoodType = cbWoodType.Text
            Else
                WoodType = "N/A"
            End If
        Else
            MsgBox("Please enter a valid species/wood type.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            Exit Sub
        End If

        If txtQty.Text.Length > 0 Then
            If IsNumeric(txtQty.Text) Then
                qty = txtQty.Text
            Else
                MsgBox("Please enter a valid number for qty", MsgBoxStyle.OkOnly, "KPFactory")
                Exit Sub
            End If

        Else
            MsgBox("Please enter a valid qty and try again", MsgBoxStyle.OkOnly, "KPFactory")
            Exit Sub
        End If

        If cbReason.Text.Length > 0 Then
            reason = cbReason.Text
        Else
            MsgBox("Please select a valid reason and try again", MsgBoxStyle.OkOnly, "KPFactory")
            Exit Sub
        End If

        KPGeneral.WebRef_Local.spKPFactory_InsertRejectedDoors_Species(dept, WoodType, qty, reason, "Production")

        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.spKPFactory_RejectedDoorsCurrentDay_Species(Date.Now, "Production")
        ugRejected.DataSource = ds
        ugRejected.DisplayLayout.Bands(0).Columns("ID").Hidden = True

        'cbColour.DataSource = Nothing
        cbWoodType.Text = Nothing
        txtQty.Text = Nothing
        cbReason.Text = Nothing
    End Sub

    Private Sub btnViewReport_Click(sender As Object, e As EventArgs) Handles btnViewReport.Click
        FDate = dtFDate.Value
        TDate = dtTDate.Value

        ReportsEngine.ReportOptions.FDate = FDate
        ReportsEngine.ReportOptions.TDate = TDate
        ReportsEngine.ReportOptions.PrintOption = 1
        ReportsEngine.SelectedReport(135)

        'Dim reportNumber As Integer = 135
        'Dim rptName As New rptRejectedDoors
        'Call Report135()
        'Dim rpt As New RptViewer(1, rptName)
        'rpt.ShowDialog()
        'rpt.Dispose()
    End Sub

    Private Sub MenuItem2_Click(sender As Object, e As EventArgs) Handles MenuItem2.Click

    End Sub
End Class

