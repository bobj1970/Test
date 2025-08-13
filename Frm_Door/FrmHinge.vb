Imports System.Drawing.Drawing2D
'Imports System.Data.SqlClient
'Imports System.Data.DataViewManager
'Imports System.Data
'Imports System
'Imports System.Drawing
'Imports System.Drawing.Text
'Imports System.Collections
'Imports System.Windows.Forms
Imports System.IO
'Imports System.IO.IsolatedStorage
'Imports System.Diagnostics
'Imports System.Reflection.MethodBase
Imports System.Net.Mail
Imports Infragistics.Win.UltraWinGrid
'Imports Infragistics.Win.SupportDialogs.FilterUIProvider
'Imports CrystalDecisions.ReportAppServer.CommonControls

Public Class frmHinge
    Inherits System.Windows.Forms.Form
    Friend WithEvents lvOrderEmployee As System.Windows.Forms.ListView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents KitchenTrackerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductionDefsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Dim T As Integer
    Friend WithEvents AssignBoxNumbersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGridFilterUIProvider1 As Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ugReadyHinge As UltraGrid
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents txtDoorCount As Label
    Friend WithEvents ug_Hinge_LowPriority As UltraGrid
    Friend WithEvents mnuLowPriority As ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KitchenTrackerToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ug_Hinge_CompletedToday As UltraGrid
    Friend WithEvents ColumnChooserToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents KitchenTrackerToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents mnuCompletedToday As ContextMenuStrip
    Friend WithEvents AdjustColumnHeadersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdjustColumnHeadersToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents mnuEmployeeStats As ContextMenuStrip
    Friend WithEvents ShowPerformanceStatsToolStripMenuItem As ToolStripMenuItem
    Public Shared CompleteDoorIssue As Boolean

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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UcWebStatus1 As ucWebStatus
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Dim GridSummary As Boolean
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHinge))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mnuCompletedToday = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ProductionDefsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignBoxNumbersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.KitchenTrackerToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvOrderEmployee = New System.Windows.Forms.ListView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KitchenTrackerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdjustColumnHeadersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.UltraGridFilterUIProvider1 = New Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider(Me.components)
        Me.ugReadyHinge = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ug_Hinge_CompletedToday = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtDoorCount = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ug_Hinge_LowPriority = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.mnuLowPriority = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KitchenTrackerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdjustColumnHeadersToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEmployeeStats = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowPerformanceStatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCompletedToday.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ugReadyHinge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ug_Hinge_CompletedToday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.ug_Hinge_LowPriority, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuLowPriority.SuspendLayout()
        Me.mnuEmployeeStats.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(472, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 24)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Door Count:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mnuCompletedToday
        '
        Me.mnuCompletedToday.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductionDefsToolStripMenuItem, Me.AssignBoxNumbersToolStripMenuItem, Me.ColumnChooserToolStripMenuItem3, Me.KitchenTrackerToolStripMenuItem3})
        Me.mnuCompletedToday.Name = "ContextMenuStrip2"
        Me.mnuCompletedToday.Size = New System.Drawing.Size(185, 92)
        '
        'ProductionDefsToolStripMenuItem
        '
        Me.ProductionDefsToolStripMenuItem.Name = "ProductionDefsToolStripMenuItem"
        Me.ProductionDefsToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ProductionDefsToolStripMenuItem.Text = "Production Defs"
        '
        'AssignBoxNumbersToolStripMenuItem
        '
        Me.AssignBoxNumbersToolStripMenuItem.Name = "AssignBoxNumbersToolStripMenuItem"
        Me.AssignBoxNumbersToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.AssignBoxNumbersToolStripMenuItem.Text = "Assign Box Numbers"
        '
        'ColumnChooserToolStripMenuItem3
        '
        Me.ColumnChooserToolStripMenuItem3.Name = "ColumnChooserToolStripMenuItem3"
        Me.ColumnChooserToolStripMenuItem3.Size = New System.Drawing.Size(184, 22)
        Me.ColumnChooserToolStripMenuItem3.Text = "Column Chooser"
        '
        'KitchenTrackerToolStripMenuItem3
        '
        Me.KitchenTrackerToolStripMenuItem3.Name = "KitchenTrackerToolStripMenuItem3"
        Me.KitchenTrackerToolStripMenuItem3.Size = New System.Drawing.Size(184, 22)
        Me.KitchenTrackerToolStripMenuItem3.Text = "Kitchen Tracker"
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(212, 3)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(254, 22)
        Me.lblDate.TabIndex = 17
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(365, 22)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Orders Hinged Today"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(534, 38)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(832, 37)
        Me.lblMessage.TabIndex = 16
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(198, 37)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(329, 32)
        Me.txtBarcode.TabIndex = 15
        Me.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 24)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Click And Scan Here:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkBlue
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1371, 34)
        Me.Panel1.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label2.Location = New System.Drawing.Point(280, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(397, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Hinge Department - Scanning Station"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lvOrderEmployee
        '
        Me.lvOrderEmployee.ContextMenuStrip = Me.mnuEmployeeStats
        Me.lvOrderEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvOrderEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvOrderEmployee.FullRowSelect = True
        Me.lvOrderEmployee.GridLines = True
        Me.lvOrderEmployee.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvOrderEmployee.HideSelection = False
        Me.lvOrderEmployee.Location = New System.Drawing.Point(0, 0)
        Me.lvOrderEmployee.MultiSelect = False
        Me.lvOrderEmployee.Name = "lvOrderEmployee"
        Me.lvOrderEmployee.Size = New System.Drawing.Size(351, 325)
        Me.lvOrderEmployee.TabIndex = 22
        Me.lvOrderEmployee.TabStop = False
        Me.lvOrderEmployee.UseCompatibleStateImageBehavior = False
        Me.lvOrderEmployee.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KitchenTrackerToolStripMenuItem, Me.ColumnChooserToolStripMenuItem1, Me.AdjustColumnHeadersToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(201, 70)
        '
        'KitchenTrackerToolStripMenuItem
        '
        Me.KitchenTrackerToolStripMenuItem.Name = "KitchenTrackerToolStripMenuItem"
        Me.KitchenTrackerToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.KitchenTrackerToolStripMenuItem.Text = "Kitchen Tracker"
        '
        'ColumnChooserToolStripMenuItem1
        '
        Me.ColumnChooserToolStripMenuItem1.Name = "ColumnChooserToolStripMenuItem1"
        Me.ColumnChooserToolStripMenuItem1.Size = New System.Drawing.Size(200, 22)
        Me.ColumnChooserToolStripMenuItem1.Text = "Column Chooser"
        '
        'AdjustColumnHeadersToolStripMenuItem
        '
        Me.AdjustColumnHeadersToolStripMenuItem.Name = "AdjustColumnHeadersToolStripMenuItem"
        Me.AdjustColumnHeadersToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.AdjustColumnHeadersToolStripMenuItem.Text = "Adjust Column Headers"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'ugReadyHinge
        '
        Me.ugReadyHinge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugReadyHinge.ContextMenuStrip = Me.ContextMenuStrip1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugReadyHinge.DisplayLayout.Appearance = Appearance1
        Me.ugReadyHinge.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugReadyHinge.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugReadyHinge.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugReadyHinge.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugReadyHinge.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugReadyHinge.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugReadyHinge.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugReadyHinge.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugReadyHinge.DisplayLayout.MaxColScrollRegions = 1
        Me.ugReadyHinge.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugReadyHinge.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugReadyHinge.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugReadyHinge.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugReadyHinge.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugReadyHinge.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugReadyHinge.DisplayLayout.Override.AllowMultiCellOperations = CType((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders), Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)
        Me.ugReadyHinge.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugReadyHinge.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.ugReadyHinge.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugReadyHinge.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugReadyHinge.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugReadyHinge.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugReadyHinge.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugReadyHinge.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugReadyHinge.DisplayLayout.Override.CellPadding = 0
        Me.ugReadyHinge.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.ugReadyHinge.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugReadyHinge.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugReadyHinge.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugReadyHinge.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugReadyHinge.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugReadyHinge.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugReadyHinge.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugReadyHinge.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugReadyHinge.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugReadyHinge.DisplayLayout.Override.TipStyleHeader = Infragistics.Win.UltraWinGrid.TipStyle.Show
        Me.ugReadyHinge.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugReadyHinge.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugReadyHinge.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugReadyHinge.GesturesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugReadyHinge.Location = New System.Drawing.Point(0, 0)
        Me.ugReadyHinge.Name = "ugReadyHinge"
        Me.ugReadyHinge.Size = New System.Drawing.Size(1371, 194)
        Me.ugReadyHinge.TabIndex = 37
        Me.ugReadyHinge.Text = "UltraGrid1"
        Me.ugReadyHinge.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ug_Hinge_CompletedToday)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDoorCount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvOrderEmployee)
        Me.SplitContainer1.Size = New System.Drawing.Size(1371, 325)
        Me.SplitContainer1.SplitterDistance = 1016
        Me.SplitContainer1.TabIndex = 38
        '
        'ug_Hinge_CompletedToday
        '
        Me.ug_Hinge_CompletedToday.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ug_Hinge_CompletedToday.ContextMenuStrip = Me.mnuCompletedToday
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_Hinge_CompletedToday.DisplayLayout.Appearance = Appearance13
        Me.ug_Hinge_CompletedToday.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_Hinge_CompletedToday.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_Hinge_CompletedToday.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_Hinge_CompletedToday.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.ug_Hinge_CompletedToday.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_Hinge_CompletedToday.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.ug_Hinge_CompletedToday.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_Hinge_CompletedToday.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.CellAppearance = Appearance20
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.RowAppearance = Appearance23
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_Hinge_CompletedToday.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.ug_Hinge_CompletedToday.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_Hinge_CompletedToday.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_Hinge_CompletedToday.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_Hinge_CompletedToday.Location = New System.Drawing.Point(3, 34)
        Me.ug_Hinge_CompletedToday.Name = "ug_Hinge_CompletedToday"
        Me.ug_Hinge_CompletedToday.Size = New System.Drawing.Size(1010, 288)
        Me.ug_Hinge_CompletedToday.TabIndex = 23
        Me.ug_Hinge_CompletedToday.Text = "UltraGrid1"
        '
        'txtDoorCount
        '
        Me.txtDoorCount.BackColor = System.Drawing.Color.Transparent
        Me.txtDoorCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDoorCount.ForeColor = System.Drawing.Color.Black
        Me.txtDoorCount.Location = New System.Drawing.Point(646, 7)
        Me.txtDoorCount.Name = "txtDoorCount"
        Me.txtDoorCount.Size = New System.Drawing.Size(168, 24)
        Me.txtDoorCount.TabIndex = 22
        Me.txtDoorCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 75)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ug_Hinge_LowPriority)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ugReadyHinge)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1371, 655)
        Me.SplitContainer2.SplitterDistance = 326
        Me.SplitContainer2.TabIndex = 39
        '
        'ug_Hinge_LowPriority
        '
        Me.ug_Hinge_LowPriority.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ug_Hinge_LowPriority.ContextMenuStrip = Me.mnuLowPriority
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_Hinge_LowPriority.DisplayLayout.Appearance = Appearance25
        Me.ug_Hinge_LowPriority.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_Hinge_LowPriority.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_Hinge_LowPriority.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_Hinge_LowPriority.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_Hinge_LowPriority.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.ug_Hinge_LowPriority.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_Hinge_LowPriority.DisplayLayout.GroupByBox.Hidden = True
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_Hinge_LowPriority.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.ug_Hinge_LowPriority.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_Hinge_LowPriority.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.AllowMultiCellOperations = CType((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders), Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.CellAppearance = Appearance32
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.CellPadding = 0
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.RowAppearance = Appearance35
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.ug_Hinge_LowPriority.DisplayLayout.Override.TipStyleHeader = Infragistics.Win.UltraWinGrid.TipStyle.Show
        Me.ug_Hinge_LowPriority.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_Hinge_LowPriority.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_Hinge_LowPriority.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_Hinge_LowPriority.GesturesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Me.ug_Hinge_LowPriority.Location = New System.Drawing.Point(0, 200)
        Me.ug_Hinge_LowPriority.Name = "ug_Hinge_LowPriority"
        Me.ug_Hinge_LowPriority.Size = New System.Drawing.Size(1371, 123)
        Me.ug_Hinge_LowPriority.TabIndex = 38
        Me.ug_Hinge_LowPriority.Text = "UltraGrid1"
        Me.ug_Hinge_LowPriority.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange
        '
        'mnuLowPriority
        '
        Me.mnuLowPriority.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.ColumnChooserToolStripMenuItem, Me.KitchenTrackerToolStripMenuItem1, Me.AdjustColumnHeadersToolStripMenuItem1})
        Me.mnuLowPriority.Name = "mnuLowPriority"
        Me.mnuLowPriority.Size = New System.Drawing.Size(201, 92)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ColumnChooserToolStripMenuItem
        '
        Me.ColumnChooserToolStripMenuItem.Name = "ColumnChooserToolStripMenuItem"
        Me.ColumnChooserToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.ColumnChooserToolStripMenuItem.Text = "Column Chooser"
        '
        'KitchenTrackerToolStripMenuItem1
        '
        Me.KitchenTrackerToolStripMenuItem1.Name = "KitchenTrackerToolStripMenuItem1"
        Me.KitchenTrackerToolStripMenuItem1.Size = New System.Drawing.Size(200, 22)
        Me.KitchenTrackerToolStripMenuItem1.Text = "Kitchen Tracker"
        '
        'AdjustColumnHeadersToolStripMenuItem1
        '
        Me.AdjustColumnHeadersToolStripMenuItem1.Name = "AdjustColumnHeadersToolStripMenuItem1"
        Me.AdjustColumnHeadersToolStripMenuItem1.Size = New System.Drawing.Size(200, 22)
        Me.AdjustColumnHeadersToolStripMenuItem1.Text = "Adjust Column Headers"
        '
        'mnuEmployeeStats
        '
        Me.mnuEmployeeStats.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowPerformanceStatsToolStripMenuItem})
        Me.mnuEmployeeStats.Name = "mnuEmployeeStats"
        Me.mnuEmployeeStats.Size = New System.Drawing.Size(203, 48)
        '
        'ShowPerformanceStatsToolStripMenuItem
        '
        Me.ShowPerformanceStatsToolStripMenuItem.Name = "ShowPerformanceStatsToolStripMenuItem"
        Me.ShowPerformanceStatsToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.ShowPerformanceStatsToolStripMenuItem.Text = "Show Performance Stats"
        '
        'frmHinge
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1371, 732)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHinge"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Hinge Deptartment"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuCompletedToday.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ugReadyHinge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ug_Hinge_CompletedToday, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.ug_Hinge_LowPriority, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuLowPriority.ResumeLayout(False)
        Me.mnuEmployeeStats.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmHinge_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim BaseRectangle As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim Gradient_Brush As New LinearGradientBrush(BaseRectangle, Color.White, Color.DarkBlue, LinearGradientMode.Vertical) 'Gradient Degree
        e.Graphics.FillRectangle(Gradient_Brush, BaseRectangle)
    End Sub

    Private Sub frmHinge_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    Private Sub frmHinge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            refreshList()
            refreshLVReady()
            RefreshLowPriority()

            KPGeneral.SetDefaultGridSettings(ugReadyHinge)
            KPGeneral.SetDefaultGridSettings(ug_Hinge_LowPriority)
            KPGeneral.SetDefaultGridSettings(ug_Hinge_CompletedToday)

            AdjustColumnHeadersToolStripMenuItem.Visible = KPGeneral.User.UserProfile("SetGridTooltips")
            AdjustColumnHeadersToolStripMenuItem1.Visible = KPGeneral.User.UserProfile("SetGridTooltips")
            ShowPerformanceStatsToolStripMenuItem.Visible = KPGeneral.User.UserProfile("ShopEmployeePerformanceTracker")
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub frmHinge_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        Try
            If KPGeneral.User.UserProfile("MonitorUser ") Then
                txtBarcode.Enabled = False
            Else
                txtBarcode.Enabled = True
            End If
            lblDate.Text = Now.ToLongDateString
            refreshList()
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Sub txtBarcode_enter(ByVal o As [Object], ByVal e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        Try
            lblDate.Text = Now.ToLongDateString
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                e.Handled = True
                'If UcWebStatus1.WebServFound(Me) = True Then
                'Enter Pressed
                If Trim(txtBarcode.Text) = Nothing Then
                    lblMessage.Text = Nothing
                    Exit Sub
                End If

                Dim ds As DataSet
                ds = KPGeneral.WebRef_Local.spKP_LotInfoByFK(Trim(txtBarcode.Text))

                If ds.Tables(0).Rows.Count > 0 Then
                    'Start Cancelled Order (Rich Added - 09/06/06)
                    If ds.Tables(0).Rows(0)("CancelOrder") = True Then
                        lblMessage.Text = "Order Cancelled!"
                        txtBarcode.Text = Nothing
                        txtBarcode.Focus()
                        Exit Sub
                    End If
                    lblMessage.Text = Nothing

                    Dim IBox As String
                    Dim HingeEmployee As Integer
                    IBox = InputBox("Please enter the 'Hinge User ID' of the person who completed this order.", "KPFactory", "")
                    If IsNumeric(IBox) Then
                        HingeEmployee = CType(IBox, Integer)
                    Else
                        MsgBox("That user ID is not valid.  Please enter a correct user ID", MsgBoxStyle.OkOnly, "KPFactory")
                        txtBarcode.Text = vbNullString
                        txtBarcode.Focus()
                        Exit Sub
                    End If

                    If IsDBNull(ds.Tables(0).Rows(0)("OrderStatus")) = False Then
                        If Trim(ds.Tables(0).Rows(0)("OrderStatus")) = "Pending" Then
                            lblMessage.Text = ds.Tables(0).Rows(0)("Masternum") & "Order Pending!"
                            MessageBox.Show("Please hold the last order you scanned. Please Contact your supervisor/manager to resolve the PENDING status of the last Order.")
                            'txtBarcode.Text = vbNullString
                            'txtBarcode.Focus()
                        End If
                    End If

                    Dim HasChangeOrder As Boolean = False
                    If IsDBNull(ds.Tables(0).Rows(0)("ChangeOrderCount")) = False Then
                        If ds.Tables(0).Rows(0)("ChangeOrderCount") > 0 Then
                            HasChangeOrder = True
                        End If
                    End If

                    If HasChangeOrder = True Then
                        MsgBox("There has been a change order for this order. Please make sure you are working off the correct layout.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                        'KPGeneral.PrintLayoutPage("Hinge", ds.Tables(0).Rows(0)("CSID"),
                        '            KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(ds.Tables(0).Rows(0)("CSID"), 0), True, False, 1, 7, False, False)
                    End If

                    'End Cancelled Order

                    'This web service checks if order is already scanned: if not scanned...
                    '                                                       updates status table and inserts into warehouse table 
                    '                                                       and returns true else it returns flase


                    'DefectDoors(ds.Tables(0).Rows(0)("CSID"))
                    If KPGeneral.WebRef_Local.spKPFactory_Hinge_WithEmployee(Now(), Trim(txtBarcode.Text), ds.Tables(0).Rows(0)("CSID"), KPGeneral.User.UserProfile("UserLoginName"), HingeEmployee) = False Then
                        lblMessage.Text = "Order Already Scanned!"
                    Else
                        frmDoorBoxUpdate.CSID = ds.Tables(0).Rows(0)("CSID")
                        frmDoorBoxUpdate.FromHinge = True
                        frmDoorBoxUpdate.ShowDialog()

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
    'Sub sendEmail(ByVal ds As DataSet)
    '    Dim CSID As Integer = IIf(ds.Tables(0).Rows(0)("CSID") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("CSID"))
    '    Dim MasterNum As String = IIf(ds.Tables(0).Rows(0)("MASTERNUM") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("MASTERNUM"))
    '    Dim Company As String = IIf(ds.Tables(0).Rows(0)("COMPANY") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("COMPANY"))
    '    Dim Project As String = IIf(ds.Tables(0).Rows(0)("PROJECT") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("PROJECT"))
    '    Dim Lot As String = IIf(ds.Tables(0).Rows(0)("LOT") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("LOT"))
    '    Dim dsWatchList As DataSet = KPGeneral.WebRef_Local.usp_GetWatchList_byCSID(CSID)

    '    For i As Integer = 0 To dsWatchList.Tables(0).Rows.Count - 1
    '        Dim UserEmail As String = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("UserEmail")), String.Empty, dsWatchList.Tables(0).Rows(i)("UserEmail"))
    '        Dim Notify As Boolean = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("NotifyDoorsHinged")), String.Empty, dsWatchList.Tables(0).Rows(i)("NotifyDoorsHinged"))
    '        'Dim CSID_IN_WatchList As Integer = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("CSID")), String.Empty, dsWatchList.Tables(0).Rows(i)("CSID"))

    '        If Notify = True Then
    '            Dim value As AttachmentCollection
    '            Dim Message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("reports@frendel.com", UserEmail)
    '            Message.IsBodyHtml = True
    '            'Message.CC.Add([global].UserProfile.Tables(0).Rows(0)("UserID") & "@frendel.com")
    '            'Message.Bcc.Add("kevinl@frendel.com")
    '            Message.Subject = "Order# " & MasterNum & " - " & Company & " - " & Project & " - " & Lot & " - " & "Doors hinged, Date: " & Now.ToString
    '            Message.Body = "Order#: " & MasterNum & " <br /> " _
    '                         & "Company: " & Company & " <br /> " _
    '                         & "Project: " & Project & " <br /> " _
    '                         & "Lot: " & Lot & " <br /> " _
    '                         & "has been hinged"
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
                frmMissingDoorPrompt.FormLocation = "Hinge"
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
    Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
        'txtBarcode.Focus()
    End Sub

    Private Sub refreshList()
        'If UcWebStatus1.WebServFound(Me) = True Then
        Try
            'refreshLVReady()

            txtDoorCount.Text = 0
            Dim ds, ds1 As New DataSet
            'webservice for list 
            ds = KPGeneral.WebRef_Local.spKPFactory_Hinge_TodaysOrders()
            ds1 = KPGeneral.WebRef_Local.spKPFactory_Hinge_TodaysOrdersEmployeeCount()

            lvOrderEmployee.Clear()
            With lvOrderEmployee.Columns
                .Add("Employee", 100, HorizontalAlignment.Left)
                .Add("Total Doors", 100, HorizontalAlignment.Left)
            End With
            With lvOrderEmployee
                Dim z As Integer = 0
                Dim RowNumb As Long = 0
                For z = 0 To ds1.Tables(0).Rows.Count - 1
                    .Items.Add(ds1.Tables(0).Rows(z)("HingeEmployee"))
                    .Items(z).SubItems.Add(ds1.Tables(0).Rows(z)("TotalDoors"))
                Next
            End With

            lvOrderEmployee.Sorting = Windows.Forms.SortOrder.Ascending

            ug_Hinge_CompletedToday.DataSource = ds

            If ug_Hinge_CompletedToday.Rows.Count > 0 Then
                KPGeneral.RefreshGridFromLayout(ug_Hinge_CompletedToday, Me.GetType.Name)
                Me.ug_Hinge_CompletedToday.DisplayLayout.Bands(0).Columns("BoxDateExpected").Style = ColumnStyle.DateTime
                Dim x As Integer
                For x = 0 To ug_Hinge_CompletedToday.Rows.Count - 1
                    If IsDBNull(ug_Hinge_CompletedToday.Rows(x).Cells("ProdDef").Value) = False Then
                        If ug_Hinge_CompletedToday.Rows(x).Cells("ProdDef").Value > 0 Then
                            ug_Hinge_CompletedToday.Rows(x).Appearance.BackColor = Color.LightSalmon
                        End If
                    End If

                    If IsDBNull(ug_Hinge_CompletedToday.Rows(x).Cells("Raw").Value) = True Then
                        ug_Hinge_CompletedToday.Rows(x).Cells("Raw").Appearance.ForeColor = Color.Green
                        ug_Hinge_CompletedToday.Rows(x).Cells("Raw").Appearance.BackColor = Color.Green
                    Else
                        ug_Hinge_CompletedToday.Rows(x).Cells("Raw").Appearance.ForeColor = Color.Red
                        ug_Hinge_CompletedToday.Rows(x).Cells("Raw").Appearance.BackColor = Color.Red
                    End If

                    If IsDBNull(ug_Hinge_CompletedToday.Rows(x).Cells("Painted").Value) = True Then
                        ug_Hinge_CompletedToday.Rows(x).Cells("Painted").Appearance.ForeColor = Color.Green
                        ug_Hinge_CompletedToday.Rows(x).Cells("Painted").Appearance.BackColor = Color.Green
                    Else
                        ug_Hinge_CompletedToday.Rows(x).Cells("Painted").Appearance.ForeColor = Color.Red
                        ug_Hinge_CompletedToday.Rows(x).Cells("Painted").Appearance.BackColor = Color.Red
                    End If

                    If IsDBNull(ug_Hinge_CompletedToday.Rows(x).Cells("AssemblyStartDate").Value) = False Then
                        ug_Hinge_CompletedToday.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.Green
                        ug_Hinge_CompletedToday.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.Green
                    Else
                        ug_Hinge_CompletedToday.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.Red
                        ug_Hinge_CompletedToday.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.Red
                    End If
                Next

                ug_Hinge_CompletedToday.DisplayLayout.Bands(0).Columns("Scan_Time").Format = KPGeneral.Time12HourFormatString
            End If


            If IsDBNull(ds.Tables(0).Compute("SUM(TotalDoors)", "")) Then
                txtDoorCount.Text = 0
            Else
                txtDoorCount.Text = ds.Tables(0).Compute("SUM(TotalDoors)", "")
            End If

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
        'End If

    End Sub

    Public Function isOdd(ByVal lngNumber As Long) As Boolean
        Dim blnOdd As Boolean = CLng(lngNumber) And 1
        Return blnOdd
    End Function

    Private Sub refreshLVReady()
        'Try
        Dim ds As New DataSet
        'webservice for list 
        'ds = KPGeneral.WebRef_Local.spKPFactory_Hinging_ReadyOrders()

        Me.Cursor = Cursors.WaitCursor
        'webservice for list 
        ugReadyHinge.DataSource = Nothing
        Dim ds1 As New DataSet
        ds = KPGeneral.WebRef_Local.spKPFactory_ProductionStatus_AllOrders_Hinge()
        'ds1 = ds.Clone
        ds1 = ds.Copy

        ugReadyHinge.DataSource = ds1

        StyleGrid()

        KPGeneral.RefreshGridFromLayout(ugReadyHinge, Me.GetType.Name)

        Dim x As Integer
        For x = 0 To ugReadyHinge.Rows.Count - 1
            If ugReadyHinge.Rows(x).Cells("ProdDef").Value > 0 Then
                ugReadyHinge.Rows(x).Appearance.BackColor = Color.LightSalmon
            End If

            If IsDBNull(ugReadyHinge.Rows(x).Cells("OnHold").Value) = False Then
                If ugReadyHinge.Rows(x).Cells("OnHold").Value = True Then
                    ugReadyHinge.Rows(x).Appearance.BackColor = Color.FromName(StatusColours.OnHold_BackColour)
                    ugReadyHinge.Rows(x).Appearance.ForeColor = Color.FromName(StatusColours.OnHold_ForeColour)
                End If
            End If

            If ugReadyHinge.Rows(x).Cells("HingeDate").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ugReadyHinge.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                ugReadyHinge.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ugReadyHinge.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.Tomato
                ugReadyHinge.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.Tomato
            End If

            If ugReadyHinge.Rows(x).Cells("DoorsPickedDate").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ugReadyHinge.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                ugReadyHinge.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ugReadyHinge.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.Tomato
                ugReadyHinge.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.Tomato
            End If

            If ugReadyHinge.Rows(x).Cells("PB").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ugReadyHinge.Rows(x).Cells("PB").Appearance.BackColor = Color.YellowGreen
                ugReadyHinge.Rows(x).Cells("PB").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ugReadyHinge.Rows(x).Cells("PB").Appearance.BackColor = Color.Tomato
                ugReadyHinge.Rows(x).Cells("PB").Appearance.ForeColor = Color.Tomato
            End If

            If ugReadyHinge.Rows(x).Cells("PU").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ugReadyHinge.Rows(x).Cells("PU").Appearance.BackColor = Color.YellowGreen
                ugReadyHinge.Rows(x).Cells("PU").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ugReadyHinge.Rows(x).Cells("PU").Appearance.BackColor = Color.Tomato
                ugReadyHinge.Rows(x).Cells("PU").Appearance.ForeColor = Color.Tomato
            End If


            If ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Text <> Nothing Then
                ' ugReady.Rows(x).Cells("AssemblyStartDate").Value = "Y"
                ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
            Else
                ' ugReady.Rows(x).Cells("AssemblyStartDate").Value = "N"
                ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.Tomato
                ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.Tomato
            End If

            If ugReadyHinge.Rows(x).Cells("CabinetsCompleteDate").Text <> Nothing Then
                ' ugReady.Rows(x).Cells("CabinetsCompleteDate").Value = "Y"
                ugReadyHinge.Rows(x).Cells("CabinetsCompleteDate").Appearance.BackColor = Color.YellowGreen
                ugReadyHinge.Rows(x).Cells("CabinetsCompleteDate").Appearance.ForeColor = Color.YellowGreen
            Else
                ' ugReady.Rows(x).Cells("CabinetsCompleteDate").Value = "N"
                ugReadyHinge.Rows(x).Cells("CabinetsCompleteDate").Appearance.BackColor = Color.Tomato
                ugReadyHinge.Rows(x).Cells("CabinetsCompleteDate").Appearance.ForeColor = Color.Tomato
            End If

            If ugReadyHinge.Rows(x).Cells("OrderSTatus").Text = Nothing = False Then
                If Trim(ugReadyHinge.Rows(x).Cells("OrderSTatus").Text) = "Pending" Then
                    ugReadyHinge.Rows(x).Cells("Lot").Appearance.BackColor = Color.Orange
                ElseIf Trim(ugReadyHinge.Rows(x).Cells("OrderSTatus").Text) = "Cancel" Then
                    ugReadyHinge.Rows(x).Cells("Lot").Appearance.BackColor = Color.Tomato
                    ugReadyHinge.Rows(x).Cells("Lot").Appearance.ForeColor = Color.White
                Else

                End If
            Else
                ugReadyHinge.Rows(x).Cells("OrderSTatus").Value = ""
            End If


            If IsDBNull(ugReadyHinge.Rows(x).Cells("TotalDoors").Value) = True Then
                ugReadyHinge.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                ugReadyHinge.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
                ugReadyHinge.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                ugReadyHinge.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
                If IsDBNull(ugReadyHinge.Rows(x).Cells("TotalCabinets").Value) = True Then
                    ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                    ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                Else
                    If ugReadyHinge.Rows(x).Cells("TotalCabinets").Value = 0 Then
                        ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                        ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                    End If
                End If
            Else
                If ugReadyHinge.Rows(x).Cells("TotalDoors").Value = 0 Then
                    ugReadyHinge.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                    ugReadyHinge.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
                    ugReadyHinge.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                    ugReadyHinge.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
                    If IsDBNull(ugReadyHinge.Rows(x).Cells("TotalCabinets").Value) = True Then
                        ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                        ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                    Else
                        If ugReadyHinge.Rows(x).Cells("TotalCabinets").Value = 0 Then
                            ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                            ugReadyHinge.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                        End If
                    End If
                End If
            End If
        Next
        ''lblShowing.Text = "Orders Showing = " & ugReady.Rows.Count
        Me.ugReadyHinge.DisplayLayout.Bands(0).Columns("BoxDateExpected").Style = ColumnStyle.DateTime
        Me.Cursor = Cursors.Default
        'Catch ex As Exception
        '    Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        'End Try


    End Sub
    Private Sub StyleGrid()
        HeaderToolTips()
        KPGeneral.RefreshGridTooltips(ugReadyHinge, Me.GetType.Name)
        ugReadyHinge.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    End Sub

    Private Sub LoadFilter(ByVal FilterID As Integer, ByVal UGrid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim dsFilters As New DataSet

        dsFilters = KPGeneral.WebRef_Local.usp_GetProductionStatusFilter

        UGrid.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1

        'txtFilterName.Text = UGrid.Rows(ARow).Cells("FilterName").Text
        'PrintFilter = UGrid.Rows(ARow).Cells("FilterName").Text
        'txtFilterDescription.Text = UGrid.Rows(ARow).Cells("FilterDescription").Text

        Dim gridname As String
        Dim gridschema As Infragistics.Win.UltraWinGrid.UltraGridDisplayLayout

        gridname = UGrid.Name()

        Dim FilePath As String
        FilePath = KPGeneral.StartupPath.ToString & "\" & gridname & ".xml"

        Dim FilterRow As Integer

        Dim y As Integer
        For y = 0 To dsFilters.Tables(0).Rows.Count - 1
            If dsFilters.Tables(0).Rows(y)("FilterID") = 112 Then
                FilterRow = y
                Exit For
            End If
        Next

        If FilterRow > 0 Then
            Dim ms() As Byte = dsFilters.Tables(0).Rows(FilterRow)("FilterFile")
            Dim stmBLOBData As New MemoryStream(ms)

            Dim PdfImage As New BinaryWriter(File.Create(FilePath))
            PdfImage.Write(ms)
            PdfImage.Close()

            UGrid.DisplayLayout.LoadFromXml(FilePath)

            Dim TotalDoors As Int32 = 0
            Dim TimePlanned As Int32 = 0
            Dim LoadCount As Int32 = 0
            Dim row As UltraGridRow
            For Each row In UGrid.Rows.GetFilteredInNonGroupByRows
                If Not IsDBNull(row.Cells("TotalDoors").Value) Then
                    TotalDoors = TotalDoors + row.Cells("TotalDoors").Value
                End If
                'If Not IsDBNull(row.Cells("APT").Value) Then
                '    TimePlanned = TimePlanned + row.Cells("APT").Value
                'End If
                'If Not IsDBNull(row.Cells("LoadCount").Value) Then
                '    LoadCount = LoadCount + row.Cells("LoadCount").Value
                'End If
            Next

            'lblShowing.Text = "Orders Showing = " & ugReady.Rows.FilteredInRowCount & " \ " & TotalDoors & " Doors"
            UGrid.DisplayLayout.Bands(0).Columns("ProdDef").Header.Caption = "OpenPDef"
            'lblPlannedTimeShown.Text = "Planned Time Shown: " & TimePlanned
            'lblLoadTimeShown.Text = "Load Count Shown: " & LoadCount

        End If



        UGrid.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        UGrid.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        UGrid.DisplayLayout.Override.TipStyleHeader = TipStyle.Show
        HeaderToolTips()
        KPGeneral.RefreshGridTooltips(ugReadyHinge, Me.GetType.Name)
    End Sub
    Private Sub HeaderToolTips()
        'ugReady.DisplayLayout.Bands(0).Columns("F").Header.Caption = "L"
        'ugReady.DisplayLayout.Bands(0).Columns("SC").Header.Caption = "SC"
        'ugReady.DisplayLayout.Bands(0).Columns("TotalCustomParts").Header.Caption = "TCP"
        'ugReady.DisplayLayout.Bands(0).Columns("TotalCustomPartsRemaining").Header.Caption = "TCPR"
        'ugReady.DisplayLayout.Bands(0).Columns("SiteRequestEntered").Header.Caption = "SRENT"
        'ugReady.DisplayLayout.Bands(0).Columns("SiteRequest").Header.Caption = "SRD"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("Shipper").Header.Caption = "Driver"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("ClassificationLevel").Header.Caption = "Class"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("PROJECT").Header.Caption = "Project"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("LOT").Header.Caption = "Lot"
        'ugReady.DisplayLayout.Bands(0).Columns("PHASE").Header.Caption = "Phase"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("MASTERNUM").Header.Caption = "MasterNum"
        'ugReady.DisplayLayout.Bands(0).Columns("ESD").Header.Caption = "ESD"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("AssemblyStartDate").Header.Caption = "AS"
        'ugReady.DisplayLayout.Bands(0).Columns("nComment").Header.Caption = "Comment"
        'ugReady.DisplayLayout.Bands(0).Columns("ProductionR").Header.Caption = "PRD"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("HingeDate").Header.Caption = "H"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("DoorsPickedDate").Header.Caption = "DP"
        'ugReady.DisplayLayout.Bands(0).Columns("BoxAssemblyStartDate").Header.Caption = "PR"
        'ugReady.DisplayLayout.Bands(0).Columns("RequestDate").Header.Caption = "Firm Ship"
        'ugReady.DisplayLayout.Bands(0).Columns("DateDiff").Header.Caption = "Late"
        'ugReady.DisplayLayout.Bands(0).Columns("Painted").Header.Caption = "F"
        'ugReady.DisplayLayout.Bands(0).Columns("Raw").Header.Caption = "R"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("CabinetsCompleteDate").Header.Caption = "PLC"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("TotalCabinetsAssembled").Header.Caption = "A"
        'ugReady.DisplayLayout.Bands(0).Columns("TotalCabinetsWrapped").Header.Caption = "W"
        'ugReady.DisplayLayout.Bands(0).Columns("ProductionGroup").Header.Caption = "PG"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("TotalCabinets").Header.Caption = "Cabs"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("TotalDoors").Header.Caption = "Doors"
        'ugReady.DisplayLayout.Bands(0).Columns("OrderStatus").Header.Caption = "Status"
        'ugReady.DisplayLayout.Bands(0).Columns("ProdDef").Header.Caption = "OPD"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("COMPANY").Header.Caption = "Company"
        'ugReady.DisplayLayout.Bands(0).Columns("CabinetLabelPrinted").Header.Caption = "CLP"
        'ugReady.DisplayLayout.Bands(0).Columns("BatchID").Header.Caption = "BID"
        'ugReady.DisplayLayout.Bands(0).Columns("HouseStatus").Header.Caption = "LotST"
        'ugReady.DisplayLayout.Bands(0).Columns("HouseStatusUpdated").Header.Caption = "LotSTE"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("PU").Header.Caption = "WP"
        ugReadyHinge.DisplayLayout.Bands(0).Columns("PB").Header.Caption = "BP"

        'ugReady.DisplayLayout.Bands(0).Columns("CSID").Header.ToolTipText = "Unique value assigned to every order"
        'ugReady.DisplayLayout.Bands(0).Columns("COMPANY").Header.ToolTipText = "The name of the Builder"
        'ugReady.DisplayLayout.Bands(0).Columns("PROJECT").Header.ToolTipText = "The name of the Project"
        'ugReady.DisplayLayout.Bands(0).Columns("LOT").Header.ToolTipText = "The Lot number/name"
        'ugReady.DisplayLayout.Bands(0).Columns("PHASE").Header.ToolTipText = "The Phase of the Project"
        'ugReady.DisplayLayout.Bands(0).Columns("Region").Header.ToolTipText = "The region of the project"
        'ugReady.DisplayLayout.Bands(0).Columns("Geo").Header.ToolTipText = "The region of the project"
        'ugReady.DisplayLayout.Bands(0).Columns("ClassificationLevel").Header.ToolTipText = "The Classification of the Project"
        'ugReady.DisplayLayout.Bands(0).Columns("MASTERNUM").Header.ToolTipText = "The visible order number"
        'ugReady.DisplayLayout.Bands(0).Columns("ESD").Header.ToolTipText = "The Expected Ship date"
        'ugReady.DisplayLayout.Bands(0).Columns("AssemblyStartDate").Header.ToolTipText = "The Assembly Start date"
        'ugReady.DisplayLayout.Bands(0).Columns("nComment").Header.ToolTipText = "The quick comment used to specify Rush/Ready/On Schedule/etc"
        'ugReady.DisplayLayout.Bands(0).Columns("ProductionR").Header.ToolTipText = "The Production Received date"
        'ugReady.DisplayLayout.Bands(0).Columns("HingeDate").Header.ToolTipText = "The Hinge date"
        'ugReady.DisplayLayout.Bands(0).Columns("BoxAssemblyStartDate").Header.ToolTipText = "Box Assembly Start Date"
        'ugReady.DisplayLayout.Bands(0).Columns("PrintCounter").Header.ToolTipText = "The number of times Assembly Start printed the order"
        'ugReady.DisplayLayout.Bands(0).Columns("RequestDate").Header.ToolTipText = "The Firm Ship date"
        'ugReady.DisplayLayout.Bands(0).Columns("DateDiff").Header.ToolTipText = "The days difference between today as the Request Date"
        'ugReady.DisplayLayout.Bands(0).Columns("Painted").Header.ToolTipText = "Whether all doors have been painted/finished"
        'ugReady.DisplayLayout.Bands(0).Columns("Raw").Header.ToolTipText = "Whether all doors are done Raw"
        'ugReady.DisplayLayout.Bands(0).Columns("CabinetsCompleteDate").Header.ToolTipText = "The date the cabinets are all finished"
        'ugReady.DisplayLayout.Bands(0).Columns("ARemain").Header.ToolTipText = "The number of cabinets left to assemble"
        'ugReady.DisplayLayout.Bands(0).Columns("TotalCabinetsAssembled").Header.ToolTipText = "Total cabinets assembled"
        'ugReady.DisplayLayout.Bands(0).Columns("TotalCabinetsWrapped").Header.ToolTipText = "Total Cabinets Wrapped"
        'ugReady.DisplayLayout.Bands(0).Columns("Lead").Header.ToolTipText = "The days difference between Production Received and Firm Ship date"
        'ugReady.DisplayLayout.Bands(0).Columns("WRemain").Header.ToolTipText = "Cabinets left to wrap"
        'ugReady.DisplayLayout.Bands(0).Columns("TotalCabinets").Header.ToolTipText = "Total number of Cabinets"
        'ugReady.DisplayLayout.Bands(0).Columns("TotalDoors").Header.ToolTipText = "Total number of Doors"
        'ugReady.DisplayLayout.Bands(0).Columns("OrderStatus").Header.ToolTipText = "Order Status"
        'ugReady.DisplayLayout.Bands(0).Columns("Shipper").Header.ToolTipText = "The Driver to ship the order"
        'ugReady.DisplayLayout.Bands(0).Columns("SiteRequest").Header.ToolTipText = "The Site Request date"
        'ugReady.DisplayLayout.Bands(0).Columns("TotalPDef").Header.ToolTipText = "Total number of Productin Deficiencies"
        'ugReady.DisplayLayout.Bands(0).Columns("ProdDef").Header.ToolTipText = "Total number of OPEN Productin Deficiencies"
        'ugReady.DisplayLayout.Bands(0).Columns("CabRemain").Header.ToolTipText = "The number of cabinets remaining"
        'ugReady.DisplayLayout.Bands(0).Columns("RemainingCabinets").Header.ToolTipText = "The list of remaining cabinets"
        'ugReady.DisplayLayout.Bands(0).Columns("Measuring").Header.ToolTipText = "The date the order was measured"
        'ugReady.DisplayLayout.Bands(0).Columns("DoorsPickedDate").Header.ToolTipText = "The Doors Picked"
        'ugReady.DisplayLayout.Bands(0).Columns("ProductionGroup").Header.ToolTipText = "The Production Group number"
        'ugReady.DisplayLayout.Bands(0).Columns("SiteRequestEntered").Header.ToolTipText = "The date the site request was entered on"
        'ugReady.DisplayLayout.Bands(0).Columns("TotalCustomParts").Header.ToolTipText = "The number of total custom parts"
        'ugReady.DisplayLayout.Bands(0).Columns("TotalCustomPartsRemaining").Header.ToolTipText = "The number of custom parts left to assemble"
        'ugReady.DisplayLayout.Bands(0).Columns("BatchID").Header.ToolTipText = "The batch week number"
        'ugReady.DisplayLayout.Bands(0).Columns("sr_salesperson").Header.ToolTipText = "The sales person from the showroom"
        'ugReady.DisplayLayout.Bands(0).Columns("AC").Header.ToolTipText = "The accessories checked date"
        'ugReady.DisplayLayout.Bands(0).Columns("AP").Header.ToolTipText = "The accessories picked date"
        'ugReady.DisplayLayout.Bands(0).Columns("Acc Comment").Header.ToolTipText = "The accessories comment"
        'ugReady.DisplayLayout.Bands(0).Columns("SC").Header.ToolTipText = "# of different styles and colour"
        'ugReady.DisplayLayout.Bands(0).Columns("C").Header.ToolTipText = "# of Cutler styles and colours"
        'ugReady.DisplayLayout.Bands(0).Columns("V").Header.ToolTipText = "# of Venlam styles and colours"
        'ugReady.DisplayLayout.Bands(0).Columns("F").Header.ToolTipText = "# of slab doors from frendel"
        'ugReady.DisplayLayout.Bands(0).Columns("W").Header.ToolTipText = "# of SC for stain/paint (Doma)"
        'ugReady.DisplayLayout.Bands(0).Columns("E").Header.ToolTipText = "# of Euro Doors (Annex or Trinity)"
        'ugReady.DisplayLayout.Bands(0).Columns("P").Header.ToolTipText = "# of SC for paint"
        'ugReady.DisplayLayout.Bands(0).Columns("S").Header.ToolTipText = "# of SC for stain"
        'ugReady.DisplayLayout.Bands(0).Columns("CartIDs").Header.ToolTipText = "The carts the cabinets are on"
        'ugReady.DisplayLayout.Bands(0).Columns("Defect").Header.ToolTipText = ""
        'ugReady.DisplayLayout.Bands(0).Columns("AssemblyRequest").Header.ToolTipText = "The estimated date to start assembly"
        'ugReady.DisplayLayout.Bands(0).Columns("Measurer").Header.ToolTipText = "The person who measured the lot"
        'ugReady.DisplayLayout.Bands(0).Columns("CabinetLabelPrinted").Header.ToolTipText = "The date the cabinet labels were printed on"
        'ugReady.DisplayLayout.Bands(0).Columns("Forecast").Header.ToolTipText = "The original expected ship/site request date"
        'ugReady.DisplayLayout.Bands(0).Columns("ProductionGroupPrintLocked").Header.ToolTipText = "Whether the order is locked from printing in Production Group"
        'ugReady.DisplayLayout.Bands(0).Columns("TodaysDate").Header.ToolTipText = "Todays Date.  Used to help filter some columns."
        'ugReady.DisplayLayout.Bands(0).Columns("TruckETA").Header.ToolTipText = "The date the truck is scheduled to be at the site."
        'ugReady.DisplayLayout.Bands(0).Columns("PCRecievedOn").Header.ToolTipText = "The date the Production Copies are received by scheduling after Doors Picked"
        'ugReady.DisplayLayout.Bands(0).Columns("HouseStatus").Header.ToolTipText = "The status of the lot after it is assigned a production group"
        'ugReady.DisplayLayout.Bands(0).Columns("HouseStatusUpdated").Header.ToolTipText = "The date the lot status was updated on"
        'ugReady.DisplayLayout.Bands(0).Columns("PB").Header.ToolTipText = "The date the bases were picked ready to assemble"
        'ugReady.DisplayLayout.Bands(0).Columns("PU").Header.ToolTipText = "The date the uppers were picked ready to assemble"
        'ugReady.DisplayLayout.Bands(0).Columns("APS").Header.ToolTipText = "The date the accessories picking has started"
        'ugReady.DisplayLayout.Bands(0).Columns("APF").Header.ToolTipText = "The date the accessories picking has finished"
        'ugReady.DisplayLayout.Bands(0).Columns("OrderLocation").Header.ToolTipText = "The location of the order"
        'ugReady.DisplayLayout.Bands(0).Columns("APT").Header.ToolTipText = "The assembly planned time for the order"
        'ugReady.DisplayLayout.Bands(0).Columns("DBox").Header.ToolTipText = "The door boxes for the order"
        'ugReady.DisplayLayout.Bands(0).Columns("DLoc").Header.ToolTipText = "The locations of the door boxes for the order"
        'ugReady.DisplayLayout.Bands(0).Columns("MCLT").Header.ToolTipText = "Measuring + Condition Time + Lead Time"
        'ugReady.DisplayLayout.Bands(0).Columns("DB").Header.ToolTipText = "Drawer Boxes for the order"
        'ugReady.DisplayLayout.Bands(0).Columns("DeliveryLoadID").Header.ToolTipText = "The Load ID the order is planned to go out on"
        'ugReady.DisplayLayout.Bands(0).Columns("DeliveryDate").Header.ToolTipText = "The delivery date the load is planned to go out on"
        'ugReady.DisplayLayout.Bands(0).Columns("ShowAssemblyStart").Header.ToolTipText = "Determines if the order will show in Assembly Start"
        'ugReady.DisplayLayout.Bands(0).Columns("TBOD").Header.ToolTipText = "The date the Tandembox was ordered"
        'ugReady.DisplayLayout.Bands(0).Columns("TLT").Header.ToolTipText = "Total Lead Time - Number of weeks between expected ship date and layout done."
        'ugReady.DisplayLayout.Bands(0).Columns("StyleColour").Header.ToolTipText = "All the missing style/colours for the order.  Only lists distinct values."
        'ugReady.DisplayLayout.Bands(0).Columns("CTT").Header.ToolTipText = "Total Countertops for the order"
        'ugReady.DisplayLayout.Bands(0).Columns("CTS").Header.ToolTipText = "Total Countertop started"
        'ugReady.DisplayLayout.Bands(0).Columns("CTB").Header.ToolTipText = "Total Countertops built"
        'ugReady.DisplayLayout.Bands(0).Columns("FinishedStyleColour").Header.ToolTipText = "All the finished style/colours for the order.  Only lists distinct values."
        'ugReady.DisplayLayout.Bands(0).Columns("CommentEO").Header.ToolTipText = "The date the comment was entered on"
        'ugReady.DisplayLayout.Bands(0).Columns("PT").Header.ToolTipText = "Difference, in weeks, between Production Received and Site Request Date"
        'ugReady.DisplayLayout.Bands(0).Columns("MLT").Header.ToolTipText = "Difference, in weeks, between Measuring and Site Request Date"

        ShowGridSummary()

    End Sub
    Private Sub ShowGridSummary()

        If GridSummary = True Then
            ugReadyHinge.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.True
            ugReadyHinge.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            ugReadyHinge.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True
        Else
            ugReadyHinge.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.False
            ugReadyHinge.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.None
            ugReadyHinge.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            T = T + 1
            If T > 300 Then
                refreshLVReady()
                RefreshLowPriority()
                T = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Timer1.Stop()
        End Try

    End Sub

    Private Sub KitchenTrackerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KitchenTrackerToolStripMenuItem.Click
        If ugReadyHinge.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByMasterNum(ugReadyHinge.ActiveRow.Cells("MasterNum").Text)
        Else
            MsgBox("Please select a row to view", MsgBoxStyle.OkOnly, "KP Factory")
        End If
    End Sub

    Private Sub ProductionDefsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionDefsToolStripMenuItem.Click
        If ug_Hinge_CompletedToday.ActiveRow.Index > -1 Then
            If IsDBNull(ug_Hinge_CompletedToday.ActiveRow.Cells("CSID").Value) = False Then
                frmProductionDefs.CSID = ug_Hinge_CompletedToday.ActiveRow.Cells("CSID").Text
                frmProductionDefs.MNum = ug_Hinge_CompletedToday.ActiveRow.Cells("Master_No").Text
                frmProductionDefs.Project = ug_Hinge_CompletedToday.ActiveRow.Cells("Project").Text
                frmProductionDefs.Company = ug_Hinge_CompletedToday.ActiveRow.Cells("Company").Text
                frmProductionDefs.Lot = ug_Hinge_CompletedToday.ActiveRow.Cells("Lot").Text
                frmProductionDefs.ViewOnly = False
                frmProductionDefs.ShowDialog()
            Else
                MsgBox("This order doesn't have a CSID.  You can not view this order.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If
    End Sub

    Private Sub AssignBoxNumbersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignBoxNumbersToolStripMenuItem.Click
        If ug_Hinge_CompletedToday.ActiveRow.Index > -1 Then
            If IsDBNull(ug_Hinge_CompletedToday.ActiveRow.Cells("CSID").Value) = False Then
                frmDoorBoxUpdate.CSID = ug_Hinge_CompletedToday.ActiveRow.Cells("CSID").Text
                frmDoorBoxUpdate.FromHinge = True
                frmDoorBoxUpdate.ShowDialog()
            Else
                MsgBox("This order doesn't have a CSID.  You can not view this order.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub RefreshLowPriority()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_Hinge_GetLowPriorityOrders()

        ug_Hinge_LowPriority.DataSource = ds

        Dim x As Integer
        For x = 0 To ug_Hinge_LowPriority.Rows.Count - 1
            If ug_Hinge_LowPriority.Rows(x).Cells("ProdDef").Value > 0 Then
                ug_Hinge_LowPriority.Rows(x).Appearance.BackColor = Color.LightSalmon
            End If

            If IsDBNull(ug_Hinge_LowPriority.Rows(x).Cells("OnHold").Value) = False Then
                If ug_Hinge_LowPriority.Rows(x).Cells("OnHold").Value = True Then
                    ug_Hinge_LowPriority.Rows(x).Appearance.BackColor = Color.FromName(StatusColours.OnHold_BackColour)
                    ug_Hinge_LowPriority.Rows(x).Appearance.ForeColor = Color.FromName(StatusColours.OnHold_ForeColour)
                End If
            End If

            If ug_Hinge_LowPriority.Rows(x).Cells("HingeDate").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_Hinge_LowPriority.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                ug_Hinge_LowPriority.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_Hinge_LowPriority.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.Tomato
                ug_Hinge_LowPriority.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_Hinge_LowPriority.Rows(x).Cells("DoorsPickedDate").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_Hinge_LowPriority.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                ug_Hinge_LowPriority.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_Hinge_LowPriority.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.Tomato
                ug_Hinge_LowPriority.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_Hinge_LowPriority.Rows(x).Cells("PB").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_Hinge_LowPriority.Rows(x).Cells("PB").Appearance.BackColor = Color.YellowGreen
                ug_Hinge_LowPriority.Rows(x).Cells("PB").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_Hinge_LowPriority.Rows(x).Cells("PB").Appearance.BackColor = Color.Tomato
                ug_Hinge_LowPriority.Rows(x).Cells("PB").Appearance.ForeColor = Color.Tomato
            End If

            If ug_Hinge_LowPriority.Rows(x).Cells("PU").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                ug_Hinge_LowPriority.Rows(x).Cells("PU").Appearance.BackColor = Color.YellowGreen
                ug_Hinge_LowPriority.Rows(x).Cells("PU").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                ug_Hinge_LowPriority.Rows(x).Cells("PU").Appearance.BackColor = Color.Tomato
                ug_Hinge_LowPriority.Rows(x).Cells("PU").Appearance.ForeColor = Color.Tomato
            End If


            If ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Text <> Nothing Then
                ' ugReady.Rows(x).Cells("AssemblyStartDate").Value = "Y"
                ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
            Else
                ' ugReady.Rows(x).Cells("AssemblyStartDate").Value = "N"
                ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.Tomato
                ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_Hinge_LowPriority.Rows(x).Cells("CabinetsCompleteDate").Text <> Nothing Then
                ' ugReady.Rows(x).Cells("CabinetsCompleteDate").Value = "Y"
                ug_Hinge_LowPriority.Rows(x).Cells("CabinetsCompleteDate").Appearance.BackColor = Color.YellowGreen
                ug_Hinge_LowPriority.Rows(x).Cells("CabinetsCompleteDate").Appearance.ForeColor = Color.YellowGreen
            Else
                ' ugReady.Rows(x).Cells("CabinetsCompleteDate").Value = "N"
                ug_Hinge_LowPriority.Rows(x).Cells("CabinetsCompleteDate").Appearance.BackColor = Color.Tomato
                ug_Hinge_LowPriority.Rows(x).Cells("CabinetsCompleteDate").Appearance.ForeColor = Color.Tomato
            End If

            If ug_Hinge_LowPriority.Rows(x).Cells("OrderSTatus").Text = Nothing = False Then
                If Trim(ug_Hinge_LowPriority.Rows(x).Cells("OrderSTatus").Text) = "Pending" Then
                    ug_Hinge_LowPriority.Rows(x).Cells("Lot").Appearance.BackColor = Color.Orange
                ElseIf Trim(ug_Hinge_LowPriority.Rows(x).Cells("OrderSTatus").Text) = "Cancel" Then
                    ug_Hinge_LowPriority.Rows(x).Cells("Lot").Appearance.BackColor = Color.Tomato
                    ug_Hinge_LowPriority.Rows(x).Cells("Lot").Appearance.ForeColor = Color.White
                Else

                End If
            Else
                ug_Hinge_LowPriority.Rows(x).Cells("OrderSTatus").Value = ""
            End If


            If IsDBNull(ug_Hinge_LowPriority.Rows(x).Cells("TotalDoors").Value) = True Then
                ug_Hinge_LowPriority.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                ug_Hinge_LowPriority.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
                ug_Hinge_LowPriority.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                ug_Hinge_LowPriority.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
                If IsDBNull(ug_Hinge_LowPriority.Rows(x).Cells("TotalCabinets").Value) = True Then
                    ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                    ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                Else
                    If ug_Hinge_LowPriority.Rows(x).Cells("TotalCabinets").Value = 0 Then
                        ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                        ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                    End If
                End If
            Else
                If ug_Hinge_LowPriority.Rows(x).Cells("TotalDoors").Value = 0 Then
                    ug_Hinge_LowPriority.Rows(x).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                    ug_Hinge_LowPriority.Rows(x).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
                    ug_Hinge_LowPriority.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                    ug_Hinge_LowPriority.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
                    If IsDBNull(ug_Hinge_LowPriority.Rows(x).Cells("TotalCabinets").Value) = True Then
                        ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                        ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                    Else
                        If ug_Hinge_LowPriority.Rows(x).Cells("TotalCabinets").Value = 0 Then
                            ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.BackColor = Color.YellowGreen
                            ug_Hinge_LowPriority.Rows(x).Cells("AssemblyStartDate").Appearance.ForeColor = Color.YellowGreen
                        End If
                    End If
                End If
            End If
        Next

        'LoadFilter(112, ug_Hinge_LowPriority)

        Dim band As Infragistics.Win.UltraWinGrid.UltraGridBand
        For Each band In ug_Hinge_LowPriority.DisplayLayout.Bands
            ' since all rows in a band have the same filters in RowFilterMode.AllRowsInBand this
            ' will clear the filters
            band.ColumnFilters.ClearAllFilters()
        Next

        KPGeneral.RefreshGridFromLayout(ug_Hinge_LowPriority, Me.GetType.Name)
        KPGeneral.RefreshGridTooltips(ug_Hinge_LowPriority, Me.GetType.Name)
        Me.ug_Hinge_LowPriority.DisplayLayout.Bands(0).Columns("BoxDateExpected").Style = ColumnStyle.DateTime
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshLowPriority()
    End Sub
    Private Sub ColumnChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem.Click
        KPGeneral.ColumnChooser(ug_Hinge_LowPriority, Me.GetType.Name)
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem1.Click
        If ug_Hinge_LowPriority.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByMasterNum(ug_Hinge_LowPriority.ActiveRow.Cells("MasterNum").Text)
        Else
            MsgBox("Please select a row to view", MsgBoxStyle.OkOnly, "KP Factory")
        End If
    End Sub

    Private Sub ColumnChooserToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem1.Click
        KPGeneral.ColumnChooser(ugReadyHinge, Me.GetType.Name)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem3.Click
        KPGeneral.ColumnChooser(ug_Hinge_CompletedToday, Me.GetType.Name)
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem3.Click
        If ug_Hinge_CompletedToday.ActiveRow.Index > -1 Then
            KPGeneral.ViewKitchenTrackerByCSID(ug_Hinge_CompletedToday.ActiveRow.Cells("CSID").Text)
        End If
    End Sub

    Private Sub AdjustColumnHeadersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdjustColumnHeadersToolStripMenuItem.Click
        KPGeneral.CustomizeGridTooltips(ugReadyHinge, Me.GetType.Name)
        KPGeneral.RefreshGridTooltips(ugReadyHinge, Me.GetType.Name)
    End Sub
    Private Sub AdjustColumnHeadersToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdjustColumnHeadersToolStripMenuItem1.Click
        KPGeneral.CustomizeGridTooltips(ug_Hinge_LowPriority, Me.GetType.Name)
        KPGeneral.RefreshGridTooltips(ug_Hinge_LowPriority, Me.GetType.Name)
    End Sub
    Private Sub ShowPerformanceStatsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ShowPerformanceStatsToolStripMenuItem.Click
        If lvOrderEmployee.SelectedItems.Count > 0 Then
            If lvOrderEmployee.SelectedItems(0).SubItems(0).Text.Length > 0 Then
                Dim PerformanceTracker As New frmEmployeePerformanceTracker
                PerformanceTracker.EmployeeInfo = lvOrderEmployee.SelectedItems(0).SubItems(0).Text
                PerformanceTracker.FromLocation = "Hinge"
                PerformanceTracker.ShowDialog()
            End If
        End If

    End Sub
End Class
