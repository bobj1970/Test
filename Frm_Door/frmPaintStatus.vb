Imports System.IO
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.SupportDialogs.FilterUIProvider
Imports System.Drawing.Printing
Imports System.Net.Mail

Public Class frmPaintStatus
    Inherits System.Windows.Forms.Form
    Dim GestureStartX As Integer
    Dim GestureStartY As Integer
    Dim GestureFinishX As Integer
    Dim GestureFinishY As Integer
    Dim DefaultFontSize As Integer
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnToggleSummary As System.Windows.Forms.Button
    Dim PrintFilter As String
    Friend WithEvents lblRefreshed As System.Windows.Forms.Label
    Dim GridSummary As Boolean
    Public Shared EmailAdd As String
    Public Shared EmailCC As String
    Public Shared EmailSubject As String
    Public Shared EmailBody As String
    Friend WithEvents btnExportToExcel As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents GExporter As ExcelExport.UltraGridExcelExporter
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ViewDoorListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewDoorStatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KitchenTrackerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewDoorListToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PrintDoorListsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents upMain As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraSplitter1 As Infragistics.Win.Misc.UltraSplitter
    Friend WithEvents upAddToSchedule As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnAddToSchedule As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblScheduleWorkCentre As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblScheduleDate As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents upScheduleDates As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnRefreshScheduleDates As Infragistics.Win.Misc.UltraButton
    Friend WithEvents uccWeekOf As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents upDay5 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents ug_PaintSchedule_Day5 As UltraGrid
    Friend WithEvents lblDay5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents upDay4 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents ug_PaintSchedule_Day4 As UltraGrid
    Friend WithEvents lblDay4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents upDay3 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents ug_PaintSchedule_Day3 As UltraGrid
    Friend WithEvents lblDay3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents upDay2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents ug_PaintSchedule_Day2 As UltraGrid
    Friend WithEvents lblDay2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents upDay1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents ug_PaintSchedule_Day1 As UltraGrid
    Friend WithEvents lblDay1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ucPaintLines As UltraCombo
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents mnuDay1 As ContextMenuStrip
    Friend WithEvents MoveUpToolStripMenuItem_Day1 As ToolStripMenuItem
    Friend WithEvents MoveDownToolStripMenuItem_Day1 As ToolStripMenuItem
    Friend WithEvents ViewOrdersToolStripMenuItem_Day1 As ToolStripMenuItem
    Friend WithEvents MoveNextDayToolStripMenuItem_Day1 As ToolStripMenuItem
    Friend WithEvents RemoveFromScheduleToolStripMenuItem_Day1 As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem_Day1 As ToolStripMenuItem
    Friend WithEvents MovePreviousDayToolStripMenuItem_Day1 As ToolStripMenuItem
    Friend WithEvents mnuDay5 As ContextMenuStrip
    Friend WithEvents MoveUpToolStripMenuItem_Day5 As ToolStripMenuItem
    Friend WithEvents MoveDownToolStripMenuItem_Day5 As ToolStripMenuItem
    Friend WithEvents ViewOrdersToolStripMenuItem_Day5 As ToolStripMenuItem
    Friend WithEvents MoveNextDayToolStripMenuItem_Day5 As ToolStripMenuItem
    Friend WithEvents MovePreviousDayToolStripMenuItem_Day5 As ToolStripMenuItem
    Friend WithEvents RemoveFromScheduleToolStripMenuItem_Day5 As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem_Day5 As ToolStripMenuItem
    Friend WithEvents mnuDay4 As ContextMenuStrip
    Friend WithEvents MoveUpToolStripMenuItem_Day4 As ToolStripMenuItem
    Friend WithEvents MoveDownToolStripMenuItem_Day4 As ToolStripMenuItem
    Friend WithEvents ViewOrdersToolStripMenuItem_Day4 As ToolStripMenuItem
    Friend WithEvents MoveNextDayToolStripMenuItem_Day4 As ToolStripMenuItem
    Friend WithEvents MovePreviousDayToolStripMenuItem_Day4 As ToolStripMenuItem
    Friend WithEvents RemoveFromScheduleToolStripMenuItem_Day4 As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem_Day4 As ToolStripMenuItem
    Friend WithEvents mnuDay3 As ContextMenuStrip
    Friend WithEvents MoveUpToolStripMenuItem_Day3 As ToolStripMenuItem
    Friend WithEvents MoveDownToolStripMenuItem_Day3 As ToolStripMenuItem
    Friend WithEvents ViewOrdersToolStripMenuItem_Day3 As ToolStripMenuItem
    Friend WithEvents MoveNextDayToolStripMenuItem_Day3 As ToolStripMenuItem
    Friend WithEvents MovePreviousDayToolStripMenuItem_Day3 As ToolStripMenuItem
    Friend WithEvents RemoveFromScheduleToolStripMenuItem_Day3 As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem_Day3 As ToolStripMenuItem
    Friend WithEvents mnuDay2 As ContextMenuStrip
    Friend WithEvents MoveUpToolStripMenuItem_Day2 As ToolStripMenuItem
    Friend WithEvents MoveDownToolStripMenuItem_Day2 As ToolStripMenuItem
    Friend WithEvents ViewOrdersToolStripMenuItem_Day2 As ToolStripMenuItem
    Friend WithEvents MoveNextDayToolStripMenuItem_Day2 As ToolStripMenuItem
    Friend WithEvents MovePreviousDayToolStripMenuItem_Day2 As ToolStripMenuItem
    Friend WithEvents RemoveFromScheduleToolStripMenuItem_Day2 As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem_Day2 As ToolStripMenuItem
    Dim SelectedDayNumber As Integer
    Dim FilterLoaded As Boolean = False

    Dim ScheduledWorkCenterBeginningText As String = "Work Centre: "
    Dim ScheduledDateBeginningText As String = "Date: "
    Dim Day1Date As DateTime
    Dim Day2Date As DateTime
    Dim Day3Date As DateTime
    Dim Day4Date As DateTime
    Friend WithEvents btnClearSelected As Infragistics.Win.Misc.UltraButton
    Dim Day5Date As DateTime

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents lblOrders As System.Windows.Forms.Label
    Friend WithEvents BtnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblShowing As System.Windows.Forms.Label
    Friend WithEvents ug_PaintStatus_DoorLists As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblHighlight As System.Windows.Forms.Label
    Friend WithEvents btnPrintSelected As System.Windows.Forms.Button
    Friend WithEvents ugFilters As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtFilterName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblFilterName As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtFilterDescription As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblFilterDescription As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnAddFilter As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnUpdateFilter As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnDeactivateFilter As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnLoadFilter As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnColumnChooser As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraGridFilterUIProvider1 As Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
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
        Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaintStatus))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.lblOrders = New System.Windows.Forms.Label()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.lblShowing = New System.Windows.Forms.Label()
        Me.ug_PaintStatus_DoorLists = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDoorListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewDoorListToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDoorListsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewDoorStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KitchenTrackerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGridFilterUIProvider1 = New Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider(Me.components)
        Me.lblHighlight = New System.Windows.Forms.Label()
        Me.btnPrintSelected = New System.Windows.Forms.Button()
        Me.ugFilters = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txtFilterName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblFilterName = New Infragistics.Win.Misc.UltraLabel()
        Me.txtFilterDescription = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblFilterDescription = New Infragistics.Win.Misc.UltraLabel()
        Me.btnAddFilter = New Infragistics.Win.Misc.UltraButton()
        Me.btnUpdateFilter = New Infragistics.Win.Misc.UltraButton()
        Me.btnDeactivateFilter = New Infragistics.Win.Misc.UltraButton()
        Me.btnLoadFilter = New Infragistics.Win.Misc.UltraButton()
        Me.btnColumnChooser = New Infragistics.Win.Misc.UltraButton()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        Me.lblRefreshed = New System.Windows.Forms.Label()
        Me.btnToggleSummary = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GExporter = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.upMain = New Infragistics.Win.Misc.UltraPanel()
        Me.UltraSplitter1 = New Infragistics.Win.Misc.UltraSplitter()
        Me.upAddToSchedule = New Infragistics.Win.Misc.UltraPanel()
        Me.btnAddToSchedule = New Infragistics.Win.Misc.UltraButton()
        Me.lblScheduleWorkCentre = New Infragistics.Win.Misc.UltraLabel()
        Me.lblScheduleDate = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.upScheduleDates = New Infragistics.Win.Misc.UltraPanel()
        Me.upDay5 = New Infragistics.Win.Misc.UltraPanel()
        Me.ug_PaintSchedule_Day5 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.mnuDay5 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MoveUpToolStripMenuItem_Day5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveDownToolStripMenuItem_Day5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewOrdersToolStripMenuItem_Day5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveNextDayToolStripMenuItem_Day5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovePreviousDayToolStripMenuItem_Day5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFromScheduleToolStripMenuItem_Day5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem_Day5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDay5 = New Infragistics.Win.Misc.UltraLabel()
        Me.upDay4 = New Infragistics.Win.Misc.UltraPanel()
        Me.ug_PaintSchedule_Day4 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.mnuDay4 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MoveUpToolStripMenuItem_Day4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveDownToolStripMenuItem_Day4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewOrdersToolStripMenuItem_Day4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveNextDayToolStripMenuItem_Day4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovePreviousDayToolStripMenuItem_Day4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFromScheduleToolStripMenuItem_Day4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem_Day4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDay4 = New Infragistics.Win.Misc.UltraLabel()
        Me.upDay3 = New Infragistics.Win.Misc.UltraPanel()
        Me.ug_PaintSchedule_Day3 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.mnuDay3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MoveUpToolStripMenuItem_Day3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveDownToolStripMenuItem_Day3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewOrdersToolStripMenuItem_Day3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveNextDayToolStripMenuItem_Day3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovePreviousDayToolStripMenuItem_Day3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFromScheduleToolStripMenuItem_Day3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem_Day3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDay3 = New Infragistics.Win.Misc.UltraLabel()
        Me.upDay2 = New Infragistics.Win.Misc.UltraPanel()
        Me.ug_PaintSchedule_Day2 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.mnuDay2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MoveUpToolStripMenuItem_Day2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveDownToolStripMenuItem_Day2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewOrdersToolStripMenuItem_Day2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveNextDayToolStripMenuItem_Day2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovePreviousDayToolStripMenuItem_Day2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFromScheduleToolStripMenuItem_Day2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem_Day2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDay2 = New Infragistics.Win.Misc.UltraLabel()
        Me.upDay1 = New Infragistics.Win.Misc.UltraPanel()
        Me.ug_PaintSchedule_Day1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.mnuDay1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MoveUpToolStripMenuItem_Day1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveDownToolStripMenuItem_Day1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewOrdersToolStripMenuItem_Day1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveNextDayToolStripMenuItem_Day1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovePreviousDayToolStripMenuItem_Day1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFromScheduleToolStripMenuItem_Day1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem_Day1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDay1 = New Infragistics.Win.Misc.UltraLabel()
        Me.uccWeekOf = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.ucPaintLines = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnRefreshScheduleDates = New Infragistics.Win.Misc.UltraButton()
        Me.btnClearSelected = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ug_PaintStatus_DoorLists, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ugFilters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilterName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilterDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        Me.upMain.ClientArea.SuspendLayout()
        Me.upMain.SuspendLayout()
        Me.upAddToSchedule.ClientArea.SuspendLayout()
        Me.upAddToSchedule.SuspendLayout()
        Me.upScheduleDates.ClientArea.SuspendLayout()
        Me.upScheduleDates.SuspendLayout()
        Me.upDay5.ClientArea.SuspendLayout()
        Me.upDay5.SuspendLayout()
        CType(Me.ug_PaintSchedule_Day5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuDay5.SuspendLayout()
        Me.upDay4.ClientArea.SuspendLayout()
        Me.upDay4.SuspendLayout()
        CType(Me.ug_PaintSchedule_Day4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuDay4.SuspendLayout()
        Me.upDay3.ClientArea.SuspendLayout()
        Me.upDay3.SuspendLayout()
        CType(Me.ug_PaintSchedule_Day3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuDay3.SuspendLayout()
        Me.upDay2.ClientArea.SuspendLayout()
        Me.upDay2.SuspendLayout()
        CType(Me.ug_PaintSchedule_Day2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuDay2.SuspendLayout()
        Me.upDay1.ClientArea.SuspendLayout()
        Me.upDay1.SuspendLayout()
        CType(Me.ug_PaintSchedule_Day1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuDay1.SuspendLayout()
        CType(Me.uccWeekOf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucPaintLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Search:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBarcode
        '
        Me.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcode.Location = New System.Drawing.Point(70, 5)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(240, 20)
        Me.txtBarcode.TabIndex = 3
        '
        'lblOrders
        '
        Me.lblOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrders.Location = New System.Drawing.Point(7, 26)
        Me.lblOrders.Name = "lblOrders"
        Me.lblOrders.Size = New System.Drawing.Size(528, 24)
        Me.lblOrders.TabIndex = 4
        Me.lblOrders.Text = "Orders In Production = 0"
        Me.lblOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.Location = New System.Drawing.Point(687, 2)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(136, 23)
        Me.BtnRefresh.TabIndex = 22
        Me.BtnRefresh.Text = "Refresh List"
        '
        'lblShowing
        '
        Me.lblShowing.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblShowing.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowing.Location = New System.Drawing.Point(449, 29)
        Me.lblShowing.Name = "lblShowing"
        Me.lblShowing.Size = New System.Drawing.Size(489, 18)
        Me.lblShowing.TabIndex = 33
        Me.lblShowing.Text = "Orders Showing = 0"
        Me.lblShowing.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ug_PaintStatus_DoorLists
        '
        Me.ug_PaintStatus_DoorLists.ContextMenuStrip = Me.ContextMenuStrip1
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Appearance = Appearance1
        Me.ug_PaintStatus_DoorLists.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_PaintStatus_DoorLists.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_PaintStatus_DoorLists.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintStatus_DoorLists.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintStatus_DoorLists.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ug_PaintStatus_DoorLists.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_PaintStatus_DoorLists.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintStatus_DoorLists.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ug_PaintStatus_DoorLists.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_PaintStatus_DoorLists.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.AllowMultiCellOperations = CType((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders), Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.CellPadding = 0
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ug_PaintStatus_DoorLists.DisplayLayout.Override.TipStyleHeader = Infragistics.Win.UltraWinGrid.TipStyle.Show
        Me.ug_PaintStatus_DoorLists.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_PaintStatus_DoorLists.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_PaintStatus_DoorLists.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_PaintStatus_DoorLists.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ug_PaintStatus_DoorLists.GesturesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Me.ug_PaintStatus_DoorLists.Location = New System.Drawing.Point(0, 0)
        Me.ug_PaintStatus_DoorLists.Name = "ug_PaintStatus_DoorLists"
        Me.ug_PaintStatus_DoorLists.Size = New System.Drawing.Size(955, 454)
        Me.ug_PaintStatus_DoorLists.TabIndex = 35
        Me.ug_PaintStatus_DoorLists.Text = "UltraGrid1"
        Me.ug_PaintStatus_DoorLists.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDoorListToolStripMenuItem, Me.ViewDoorListToolStripMenuItem1, Me.PrintDoorListsToolStripMenuItem, Me.ViewDoorStatusToolStripMenuItem, Me.KitchenTrackerToolStripMenuItem, Me.ViewOrderToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(228, 136)
        '
        'ViewDoorListToolStripMenuItem
        '
        Me.ViewDoorListToolStripMenuItem.Name = "ViewDoorListToolStripMenuItem"
        Me.ViewDoorListToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewDoorListToolStripMenuItem.Text = "View Door List - Whole Order"
        '
        'ViewDoorListToolStripMenuItem1
        '
        Me.ViewDoorListToolStripMenuItem1.Name = "ViewDoorListToolStripMenuItem1"
        Me.ViewDoorListToolStripMenuItem1.Size = New System.Drawing.Size(227, 22)
        Me.ViewDoorListToolStripMenuItem1.Text = "View Door List"
        '
        'PrintDoorListsToolStripMenuItem
        '
        Me.PrintDoorListsToolStripMenuItem.Name = "PrintDoorListsToolStripMenuItem"
        Me.PrintDoorListsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.PrintDoorListsToolStripMenuItem.Text = "Print Door Lists"
        '
        'ViewDoorStatusToolStripMenuItem
        '
        Me.ViewDoorStatusToolStripMenuItem.Name = "ViewDoorStatusToolStripMenuItem"
        Me.ViewDoorStatusToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewDoorStatusToolStripMenuItem.Text = "View Door Status"
        '
        'KitchenTrackerToolStripMenuItem
        '
        Me.KitchenTrackerToolStripMenuItem.Name = "KitchenTrackerToolStripMenuItem"
        Me.KitchenTrackerToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.KitchenTrackerToolStripMenuItem.Text = "Kitchen Tracker"
        '
        'ViewOrderToolStripMenuItem
        '
        Me.ViewOrderToolStripMenuItem.Name = "ViewOrderToolStripMenuItem"
        Me.ViewOrderToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ViewOrderToolStripMenuItem.Text = "View Order"
        '
        'UltraGridFilterUIProvider1
        '
        '
        'lblHighlight
        '
        Me.lblHighlight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHighlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHighlight.Location = New System.Drawing.Point(448, 53)
        Me.lblHighlight.Name = "lblHighlight"
        Me.lblHighlight.Size = New System.Drawing.Size(489, 18)
        Me.lblHighlight.TabIndex = 37
        Me.lblHighlight.Text = "Orders Highlighted = 0"
        Me.lblHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPrintSelected
        '
        Me.btnPrintSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintSelected.Location = New System.Drawing.Point(593, 2)
        Me.btnPrintSelected.Name = "btnPrintSelected"
        Me.btnPrintSelected.Size = New System.Drawing.Size(88, 23)
        Me.btnPrintSelected.TabIndex = 38
        Me.btnPrintSelected.Text = "Print Selected"
        '
        'ugFilters
        '
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugFilters.DisplayLayout.Appearance = Appearance13
        Me.ugFilters.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugFilters.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.ugFilters.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugFilters.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.ugFilters.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugFilters.DisplayLayout.GroupByBox.Hidden = True
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugFilters.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.ugFilters.DisplayLayout.MaxColScrollRegions = 1
        Me.ugFilters.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugFilters.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugFilters.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.ugFilters.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugFilters.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugFilters.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugFilters.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugFilters.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugFilters.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.ugFilters.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugFilters.DisplayLayout.Override.CellAppearance = Appearance20
        Me.ugFilters.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugFilters.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.ugFilters.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.ugFilters.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.ugFilters.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugFilters.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.ugFilters.DisplayLayout.Override.RowAppearance = Appearance23
        Me.ugFilters.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugFilters.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.ugFilters.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugFilters.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugFilters.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugFilters.Location = New System.Drawing.Point(10, 29)
        Me.ugFilters.Name = "ugFilters"
        Me.ugFilters.Size = New System.Drawing.Size(357, 140)
        Me.ugFilters.TabIndex = 39
        Me.ugFilters.Text = "UltraGrid1"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Location = New System.Drawing.Point(10, 13)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel1.TabIndex = 40
        Me.UltraLabel1.Text = "Filters"
        '
        'txtFilterName
        '
        Appearance25.BackColorDisabled = System.Drawing.Color.White
        Appearance25.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtFilterName.Appearance = Appearance25
        Me.txtFilterName.Location = New System.Drawing.Point(443, 29)
        Me.txtFilterName.Name = "txtFilterName"
        Me.txtFilterName.Size = New System.Drawing.Size(140, 21)
        Me.txtFilterName.TabIndex = 41
        '
        'lblFilterName
        '
        Me.lblFilterName.Location = New System.Drawing.Point(371, 33)
        Me.lblFilterName.Name = "lblFilterName"
        Me.lblFilterName.Size = New System.Drawing.Size(100, 23)
        Me.lblFilterName.TabIndex = 42
        Me.lblFilterName.Text = "Filter Name"
        '
        'txtFilterDescription
        '
        Appearance26.BackColorDisabled = System.Drawing.Color.White
        Appearance26.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtFilterDescription.Appearance = Appearance26
        Me.txtFilterDescription.Location = New System.Drawing.Point(443, 56)
        Me.txtFilterDescription.Multiline = True
        Me.txtFilterDescription.Name = "txtFilterDescription"
        Me.txtFilterDescription.Size = New System.Drawing.Size(242, 88)
        Me.txtFilterDescription.TabIndex = 43
        '
        'lblFilterDescription
        '
        Me.lblFilterDescription.Location = New System.Drawing.Point(371, 60)
        Me.lblFilterDescription.Name = "lblFilterDescription"
        Me.lblFilterDescription.Size = New System.Drawing.Size(66, 27)
        Me.lblFilterDescription.TabIndex = 44
        Me.lblFilterDescription.Text = "Filter Description"
        '
        'btnAddFilter
        '
        Me.btnAddFilter.Location = New System.Drawing.Point(691, 64)
        Me.btnAddFilter.Name = "btnAddFilter"
        Me.btnAddFilter.Size = New System.Drawing.Size(114, 23)
        Me.btnAddFilter.TabIndex = 45
        Me.btnAddFilter.Text = "Add Filter"
        '
        'btnUpdateFilter
        '
        Me.btnUpdateFilter.Location = New System.Drawing.Point(691, 91)
        Me.btnUpdateFilter.Name = "btnUpdateFilter"
        Me.btnUpdateFilter.Size = New System.Drawing.Size(114, 23)
        Me.btnUpdateFilter.TabIndex = 46
        Me.btnUpdateFilter.Text = "Update Filter"
        '
        'btnDeactivateFilter
        '
        Me.btnDeactivateFilter.Location = New System.Drawing.Point(691, 120)
        Me.btnDeactivateFilter.Name = "btnDeactivateFilter"
        Me.btnDeactivateFilter.Size = New System.Drawing.Size(114, 23)
        Me.btnDeactivateFilter.TabIndex = 47
        Me.btnDeactivateFilter.Text = "Deactivate Filter"
        '
        'btnLoadFilter
        '
        Me.btnLoadFilter.Location = New System.Drawing.Point(691, 36)
        Me.btnLoadFilter.Name = "btnLoadFilter"
        Me.btnLoadFilter.Size = New System.Drawing.Size(114, 23)
        Me.btnLoadFilter.TabIndex = 48
        Me.btnLoadFilter.Text = "Load Filter"
        '
        'btnColumnChooser
        '
        Me.btnColumnChooser.Location = New System.Drawing.Point(691, 146)
        Me.btnColumnChooser.Name = "btnColumnChooser"
        Me.btnColumnChooser.Size = New System.Drawing.Size(114, 23)
        Me.btnColumnChooser.TabIndex = 49
        Me.btnColumnChooser.Text = "Column Chooser"
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.ugFilters)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtFilterName)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnColumnChooser)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnLoadFilter)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lblFilterName)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnDeactivateFilter)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnUpdateFilter)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lblFilterDescription)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnAddFilter)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txtFilterDescription)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 472)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(955, 169)
        Me.UltraPanel1.TabIndex = 52
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportToExcel.Location = New System.Drawing.Point(377, 2)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(102, 23)
        Me.btnExportToExcel.TabIndex = 46
        Me.btnExportToExcel.Text = "Export to Excel"
        '
        'lblRefreshed
        '
        Me.lblRefreshed.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefreshed.Location = New System.Drawing.Point(7, 50)
        Me.lblRefreshed.Name = "lblRefreshed"
        Me.lblRefreshed.Size = New System.Drawing.Size(424, 24)
        Me.lblRefreshed.TabIndex = 41
        Me.lblRefreshed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnToggleSummary
        '
        Me.btnToggleSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnToggleSummary.Location = New System.Drawing.Point(485, 2)
        Me.btnToggleSummary.Name = "btnToggleSummary"
        Me.btnToggleSummary.Size = New System.Drawing.Size(102, 23)
        Me.btnToggleSummary.TabIndex = 40
        Me.btnToggleSummary.Text = "Toggle Summary"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(827, 2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(106, 23)
        Me.btnReset.TabIndex = 39
        Me.btnReset.Text = "Reset List"
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'upMain
        '
        Me.upMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        'upMain.ClientArea
        '
        Me.upMain.ClientArea.Controls.Add(Me.ug_PaintStatus_DoorLists)
        Me.upMain.ClientArea.Controls.Add(Me.UltraSplitter1)
        Me.upMain.ClientArea.Controls.Add(Me.UltraPanel1)
        Me.upMain.Location = New System.Drawing.Point(0, 77)
        Me.upMain.Name = "upMain"
        Me.upMain.Size = New System.Drawing.Size(955, 641)
        Me.upMain.TabIndex = 50
        '
        'UltraSplitter1
        '
        Me.UltraSplitter1.BackColor = System.Drawing.SystemColors.Control
        Me.UltraSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraSplitter1.Location = New System.Drawing.Point(0, 454)
        Me.UltraSplitter1.Name = "UltraSplitter1"
        Me.UltraSplitter1.RestoreExtent = 169
        Me.UltraSplitter1.Size = New System.Drawing.Size(955, 18)
        Me.UltraSplitter1.TabIndex = 54
        '
        'upAddToSchedule
        '
        Me.upAddToSchedule.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        'upAddToSchedule.ClientArea
        '
        Me.upAddToSchedule.ClientArea.Controls.Add(Me.btnAddToSchedule)
        Me.upAddToSchedule.ClientArea.Controls.Add(Me.lblScheduleWorkCentre)
        Me.upAddToSchedule.ClientArea.Controls.Add(Me.lblScheduleDate)
        Me.upAddToSchedule.ClientArea.Controls.Add(Me.UltraLabel2)
        Me.upAddToSchedule.Location = New System.Drawing.Point(961, 0)
        Me.upAddToSchedule.Name = "upAddToSchedule"
        Me.upAddToSchedule.Size = New System.Drawing.Size(395, 87)
        Me.upAddToSchedule.TabIndex = 51
        '
        'btnAddToSchedule
        '
        Me.btnAddToSchedule.Location = New System.Drawing.Point(3, 54)
        Me.btnAddToSchedule.Name = "btnAddToSchedule"
        Me.btnAddToSchedule.Size = New System.Drawing.Size(384, 23)
        Me.btnAddToSchedule.TabIndex = 4
        Me.btnAddToSchedule.Text = "Add highlighted to schedule"
        '
        'lblScheduleWorkCentre
        '
        Me.lblScheduleWorkCentre.Location = New System.Drawing.Point(211, 32)
        Me.lblScheduleWorkCentre.Name = "lblScheduleWorkCentre"
        Me.lblScheduleWorkCentre.Size = New System.Drawing.Size(176, 23)
        Me.lblScheduleWorkCentre.TabIndex = 3
        Me.lblScheduleWorkCentre.Text = "Work Centre: "
        '
        'lblScheduleDate
        '
        Me.lblScheduleDate.Location = New System.Drawing.Point(3, 31)
        Me.lblScheduleDate.Name = "lblScheduleDate"
        Me.lblScheduleDate.Size = New System.Drawing.Size(202, 23)
        Me.lblScheduleDate.TabIndex = 1
        Me.lblScheduleDate.Text = "Date: "
        '
        'UltraLabel2
        '
        Appearance27.TextHAlignAsString = "Center"
        Me.UltraLabel2.Appearance = Appearance27
        Me.UltraLabel2.Location = New System.Drawing.Point(3, 2)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(384, 23)
        Me.UltraLabel2.TabIndex = 0
        Me.UltraLabel2.Text = "Add to Schedule"
        '
        'upScheduleDates
        '
        Me.upScheduleDates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        'upScheduleDates.ClientArea
        '
        Me.upScheduleDates.ClientArea.Controls.Add(Me.btnClearSelected)
        Me.upScheduleDates.ClientArea.Controls.Add(Me.upDay5)
        Me.upScheduleDates.ClientArea.Controls.Add(Me.upDay4)
        Me.upScheduleDates.ClientArea.Controls.Add(Me.upDay3)
        Me.upScheduleDates.ClientArea.Controls.Add(Me.upDay2)
        Me.upScheduleDates.ClientArea.Controls.Add(Me.upDay1)
        Me.upScheduleDates.ClientArea.Controls.Add(Me.uccWeekOf)
        Me.upScheduleDates.ClientArea.Controls.Add(Me.UltraLabel4)
        Me.upScheduleDates.ClientArea.Controls.Add(Me.ucPaintLines)
        Me.upScheduleDates.ClientArea.Controls.Add(Me.UltraLabel3)
        Me.upScheduleDates.ClientArea.Controls.Add(Me.btnRefreshScheduleDates)
        Me.upScheduleDates.Location = New System.Drawing.Point(961, 93)
        Me.upScheduleDates.Name = "upScheduleDates"
        Me.upScheduleDates.Size = New System.Drawing.Size(395, 625)
        Me.upScheduleDates.TabIndex = 52
        '
        'upDay5
        '
        '
        'upDay5.ClientArea
        '
        Me.upDay5.ClientArea.Controls.Add(Me.ug_PaintSchedule_Day5)
        Me.upDay5.ClientArea.Controls.Add(Me.lblDay5)
        Me.upDay5.Location = New System.Drawing.Point(4, 503)
        Me.upDay5.Name = "upDay5"
        Me.upDay5.Size = New System.Drawing.Size(388, 112)
        Me.upDay5.TabIndex = 13
        '
        'ug_PaintSchedule_Day5
        '
        Me.ug_PaintSchedule_Day5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ug_PaintSchedule_Day5.ContextMenuStrip = Me.mnuDay5
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_PaintSchedule_Day5.DisplayLayout.Appearance = Appearance28
        Me.ug_PaintSchedule_Day5.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_PaintSchedule_Day5.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance29.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day5.DisplayLayout.GroupByBox.Appearance = Appearance29
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintSchedule_Day5.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance30
        Me.ug_PaintSchedule_Day5.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance31.BackColor2 = System.Drawing.SystemColors.Control
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintSchedule_Day5.DisplayLayout.GroupByBox.PromptAppearance = Appearance31
        Me.ug_PaintSchedule_Day5.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_PaintSchedule_Day5.DisplayLayout.MaxRowScrollRegions = 1
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.ActiveCellAppearance = Appearance32
        Appearance33.BackColor = System.Drawing.SystemColors.Highlight
        Appearance33.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.ActiveRowAppearance = Appearance33
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.CardAreaAppearance = Appearance34
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Appearance35.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.CellAppearance = Appearance35
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.CellPadding = 0
        Appearance36.BackColor = System.Drawing.SystemColors.Control
        Appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance36.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.GroupByRowAppearance = Appearance36
        Appearance37.TextHAlignAsString = "Left"
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.HeaderAppearance = Appearance37
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Appearance38.BorderColor = System.Drawing.Color.Silver
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.RowAppearance = Appearance38
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance39.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_PaintSchedule_Day5.DisplayLayout.Override.TemplateAddRowAppearance = Appearance39
        Me.ug_PaintSchedule_Day5.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_PaintSchedule_Day5.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_PaintSchedule_Day5.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_PaintSchedule_Day5.Location = New System.Drawing.Point(2, 18)
        Me.ug_PaintSchedule_Day5.Name = "ug_PaintSchedule_Day5"
        Me.ug_PaintSchedule_Day5.Size = New System.Drawing.Size(381, 87)
        Me.ug_PaintSchedule_Day5.TabIndex = 8
        Me.ug_PaintSchedule_Day5.Text = "UltraGrid5"
        '
        'mnuDay5
        '
        Me.mnuDay5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveUpToolStripMenuItem_Day5, Me.MoveDownToolStripMenuItem_Day5, Me.ViewOrdersToolStripMenuItem_Day5, Me.MoveNextDayToolStripMenuItem_Day5, Me.MovePreviousDayToolStripMenuItem_Day5, Me.RemoveFromScheduleToolStripMenuItem_Day5, Me.ColumnChooserToolStripMenuItem_Day5})
        Me.mnuDay5.Name = "mnuDay1"
        Me.mnuDay5.Size = New System.Drawing.Size(200, 158)
        '
        'MoveUpToolStripMenuItem_Day5
        '
        Me.MoveUpToolStripMenuItem_Day5.Image = Global.SequenceERP.My.Resources.Resources.up_32
        Me.MoveUpToolStripMenuItem_Day5.Name = "MoveUpToolStripMenuItem_Day5"
        Me.MoveUpToolStripMenuItem_Day5.Size = New System.Drawing.Size(199, 22)
        Me.MoveUpToolStripMenuItem_Day5.Text = "Move Up"
        '
        'MoveDownToolStripMenuItem_Day5
        '
        Me.MoveDownToolStripMenuItem_Day5.Image = Global.SequenceERP.My.Resources.Resources.down_32
        Me.MoveDownToolStripMenuItem_Day5.Name = "MoveDownToolStripMenuItem_Day5"
        Me.MoveDownToolStripMenuItem_Day5.Size = New System.Drawing.Size(199, 22)
        Me.MoveDownToolStripMenuItem_Day5.Text = "Move Down"
        '
        'ViewOrdersToolStripMenuItem_Day5
        '
        Me.ViewOrdersToolStripMenuItem_Day5.Name = "ViewOrdersToolStripMenuItem_Day5"
        Me.ViewOrdersToolStripMenuItem_Day5.Size = New System.Drawing.Size(199, 22)
        Me.ViewOrdersToolStripMenuItem_Day5.Text = "View Orders"
        '
        'MoveNextDayToolStripMenuItem_Day5
        '
        Me.MoveNextDayToolStripMenuItem_Day5.Image = Global.SequenceERP.My.Resources.Resources.down_32
        Me.MoveNextDayToolStripMenuItem_Day5.Name = "MoveNextDayToolStripMenuItem_Day5"
        Me.MoveNextDayToolStripMenuItem_Day5.Size = New System.Drawing.Size(199, 22)
        Me.MoveNextDayToolStripMenuItem_Day5.Text = "Move Next Day"
        '
        'MovePreviousDayToolStripMenuItem_Day5
        '
        Me.MovePreviousDayToolStripMenuItem_Day5.Image = Global.SequenceERP.My.Resources.Resources.up_32
        Me.MovePreviousDayToolStripMenuItem_Day5.Name = "MovePreviousDayToolStripMenuItem_Day5"
        Me.MovePreviousDayToolStripMenuItem_Day5.Size = New System.Drawing.Size(199, 22)
        Me.MovePreviousDayToolStripMenuItem_Day5.Text = "Move Previous Day"
        '
        'RemoveFromScheduleToolStripMenuItem_Day5
        '
        Me.RemoveFromScheduleToolStripMenuItem_Day5.Image = Global.SequenceERP.My.Resources.Resources.delete_32
        Me.RemoveFromScheduleToolStripMenuItem_Day5.Name = "RemoveFromScheduleToolStripMenuItem_Day5"
        Me.RemoveFromScheduleToolStripMenuItem_Day5.Size = New System.Drawing.Size(199, 22)
        Me.RemoveFromScheduleToolStripMenuItem_Day5.Text = "Remove From Schedule"
        '
        'ColumnChooserToolStripMenuItem_Day5
        '
        Me.ColumnChooserToolStripMenuItem_Day5.Name = "ColumnChooserToolStripMenuItem_Day5"
        Me.ColumnChooserToolStripMenuItem_Day5.Size = New System.Drawing.Size(199, 22)
        Me.ColumnChooserToolStripMenuItem_Day5.Text = "Column Chooser"
        '
        'lblDay5
        '
        Me.lblDay5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDay5.Location = New System.Drawing.Point(2, 3)
        Me.lblDay5.Name = "lblDay5"
        Me.lblDay5.Size = New System.Drawing.Size(381, 23)
        Me.lblDay5.TabIndex = 10
        Me.lblDay5.Text = "Day 5:"
        '
        'upDay4
        '
        '
        'upDay4.ClientArea
        '
        Me.upDay4.ClientArea.Controls.Add(Me.ug_PaintSchedule_Day4)
        Me.upDay4.ClientArea.Controls.Add(Me.lblDay4)
        Me.upDay4.Location = New System.Drawing.Point(4, 392)
        Me.upDay4.Name = "upDay4"
        Me.upDay4.Size = New System.Drawing.Size(388, 105)
        Me.upDay4.TabIndex = 12
        '
        'ug_PaintSchedule_Day4
        '
        Me.ug_PaintSchedule_Day4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ug_PaintSchedule_Day4.ContextMenuStrip = Me.mnuDay4
        Appearance40.BackColor = System.Drawing.SystemColors.Window
        Appearance40.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_PaintSchedule_Day4.DisplayLayout.Appearance = Appearance40
        Me.ug_PaintSchedule_Day4.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_PaintSchedule_Day4.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance41.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance41.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance41.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day4.DisplayLayout.GroupByBox.Appearance = Appearance41
        Appearance42.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintSchedule_Day4.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance42
        Me.ug_PaintSchedule_Day4.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance43.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance43.BackColor2 = System.Drawing.SystemColors.Control
        Appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance43.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintSchedule_Day4.DisplayLayout.GroupByBox.PromptAppearance = Appearance43
        Me.ug_PaintSchedule_Day4.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_PaintSchedule_Day4.DisplayLayout.MaxRowScrollRegions = 1
        Appearance44.BackColor = System.Drawing.SystemColors.Window
        Appearance44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.ActiveCellAppearance = Appearance44
        Appearance45.BackColor = System.Drawing.SystemColors.Highlight
        Appearance45.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.ActiveRowAppearance = Appearance45
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance46.BackColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.CardAreaAppearance = Appearance46
        Appearance47.BorderColor = System.Drawing.Color.Silver
        Appearance47.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.CellAppearance = Appearance47
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.CellPadding = 0
        Appearance48.BackColor = System.Drawing.SystemColors.Control
        Appearance48.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance48.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance48.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.GroupByRowAppearance = Appearance48
        Appearance49.TextHAlignAsString = "Left"
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.HeaderAppearance = Appearance49
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance50.BackColor = System.Drawing.SystemColors.Window
        Appearance50.BorderColor = System.Drawing.Color.Silver
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.RowAppearance = Appearance50
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance51.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_PaintSchedule_Day4.DisplayLayout.Override.TemplateAddRowAppearance = Appearance51
        Me.ug_PaintSchedule_Day4.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_PaintSchedule_Day4.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_PaintSchedule_Day4.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_PaintSchedule_Day4.Location = New System.Drawing.Point(2, 18)
        Me.ug_PaintSchedule_Day4.Name = "ug_PaintSchedule_Day4"
        Me.ug_PaintSchedule_Day4.Size = New System.Drawing.Size(381, 80)
        Me.ug_PaintSchedule_Day4.TabIndex = 8
        Me.ug_PaintSchedule_Day4.Text = "UltraGrid3"
        '
        'mnuDay4
        '
        Me.mnuDay4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveUpToolStripMenuItem_Day4, Me.MoveDownToolStripMenuItem_Day4, Me.ViewOrdersToolStripMenuItem_Day4, Me.MoveNextDayToolStripMenuItem_Day4, Me.MovePreviousDayToolStripMenuItem_Day4, Me.RemoveFromScheduleToolStripMenuItem_Day4, Me.ColumnChooserToolStripMenuItem_Day4})
        Me.mnuDay4.Name = "mnuDay1"
        Me.mnuDay4.Size = New System.Drawing.Size(200, 158)
        '
        'MoveUpToolStripMenuItem_Day4
        '
        Me.MoveUpToolStripMenuItem_Day4.Image = Global.SequenceERP.My.Resources.Resources.up_32
        Me.MoveUpToolStripMenuItem_Day4.Name = "MoveUpToolStripMenuItem_Day4"
        Me.MoveUpToolStripMenuItem_Day4.Size = New System.Drawing.Size(199, 22)
        Me.MoveUpToolStripMenuItem_Day4.Text = "Move Up"
        '
        'MoveDownToolStripMenuItem_Day4
        '
        Me.MoveDownToolStripMenuItem_Day4.Image = Global.SequenceERP.My.Resources.Resources.down_32
        Me.MoveDownToolStripMenuItem_Day4.Name = "MoveDownToolStripMenuItem_Day4"
        Me.MoveDownToolStripMenuItem_Day4.Size = New System.Drawing.Size(199, 22)
        Me.MoveDownToolStripMenuItem_Day4.Text = "Move Down"
        '
        'ViewOrdersToolStripMenuItem_Day4
        '
        Me.ViewOrdersToolStripMenuItem_Day4.Name = "ViewOrdersToolStripMenuItem_Day4"
        Me.ViewOrdersToolStripMenuItem_Day4.Size = New System.Drawing.Size(199, 22)
        Me.ViewOrdersToolStripMenuItem_Day4.Text = "View Orders"
        '
        'MoveNextDayToolStripMenuItem_Day4
        '
        Me.MoveNextDayToolStripMenuItem_Day4.Image = Global.SequenceERP.My.Resources.Resources.down_32
        Me.MoveNextDayToolStripMenuItem_Day4.Name = "MoveNextDayToolStripMenuItem_Day4"
        Me.MoveNextDayToolStripMenuItem_Day4.Size = New System.Drawing.Size(199, 22)
        Me.MoveNextDayToolStripMenuItem_Day4.Text = "Move Next Day"
        '
        'MovePreviousDayToolStripMenuItem_Day4
        '
        Me.MovePreviousDayToolStripMenuItem_Day4.Image = Global.SequenceERP.My.Resources.Resources.up_32
        Me.MovePreviousDayToolStripMenuItem_Day4.Name = "MovePreviousDayToolStripMenuItem_Day4"
        Me.MovePreviousDayToolStripMenuItem_Day4.Size = New System.Drawing.Size(199, 22)
        Me.MovePreviousDayToolStripMenuItem_Day4.Text = "Move Previous Day"
        '
        'RemoveFromScheduleToolStripMenuItem_Day4
        '
        Me.RemoveFromScheduleToolStripMenuItem_Day4.Image = Global.SequenceERP.My.Resources.Resources.delete_32
        Me.RemoveFromScheduleToolStripMenuItem_Day4.Name = "RemoveFromScheduleToolStripMenuItem_Day4"
        Me.RemoveFromScheduleToolStripMenuItem_Day4.Size = New System.Drawing.Size(199, 22)
        Me.RemoveFromScheduleToolStripMenuItem_Day4.Text = "Remove From Schedule"
        '
        'ColumnChooserToolStripMenuItem_Day4
        '
        Me.ColumnChooserToolStripMenuItem_Day4.Name = "ColumnChooserToolStripMenuItem_Day4"
        Me.ColumnChooserToolStripMenuItem_Day4.Size = New System.Drawing.Size(199, 22)
        Me.ColumnChooserToolStripMenuItem_Day4.Text = "Column Chooser"
        '
        'lblDay4
        '
        Me.lblDay4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDay4.Location = New System.Drawing.Point(2, 3)
        Me.lblDay4.Name = "lblDay4"
        Me.lblDay4.Size = New System.Drawing.Size(381, 23)
        Me.lblDay4.TabIndex = 10
        Me.lblDay4.Text = "Day 4:"
        '
        'upDay3
        '
        '
        'upDay3.ClientArea
        '
        Me.upDay3.ClientArea.Controls.Add(Me.ug_PaintSchedule_Day3)
        Me.upDay3.ClientArea.Controls.Add(Me.lblDay3)
        Me.upDay3.Location = New System.Drawing.Point(4, 281)
        Me.upDay3.Name = "upDay3"
        Me.upDay3.Size = New System.Drawing.Size(388, 105)
        Me.upDay3.TabIndex = 12
        '
        'ug_PaintSchedule_Day3
        '
        Me.ug_PaintSchedule_Day3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ug_PaintSchedule_Day3.ContextMenuStrip = Me.mnuDay3
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Appearance52.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_PaintSchedule_Day3.DisplayLayout.Appearance = Appearance52
        Me.ug_PaintSchedule_Day3.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_PaintSchedule_Day3.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance53.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance53.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day3.DisplayLayout.GroupByBox.Appearance = Appearance53
        Appearance54.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintSchedule_Day3.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance54
        Me.ug_PaintSchedule_Day3.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance55.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance55.BackColor2 = System.Drawing.SystemColors.Control
        Appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance55.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintSchedule_Day3.DisplayLayout.GroupByBox.PromptAppearance = Appearance55
        Me.ug_PaintSchedule_Day3.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_PaintSchedule_Day3.DisplayLayout.MaxRowScrollRegions = 1
        Appearance56.BackColor = System.Drawing.SystemColors.Window
        Appearance56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.ActiveCellAppearance = Appearance56
        Appearance57.BackColor = System.Drawing.SystemColors.Highlight
        Appearance57.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.ActiveRowAppearance = Appearance57
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance58.BackColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.CardAreaAppearance = Appearance58
        Appearance59.BorderColor = System.Drawing.Color.Silver
        Appearance59.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.CellAppearance = Appearance59
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.CellPadding = 0
        Appearance60.BackColor = System.Drawing.SystemColors.Control
        Appearance60.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance60.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance60.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.GroupByRowAppearance = Appearance60
        Appearance61.TextHAlignAsString = "Left"
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.HeaderAppearance = Appearance61
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance62.BackColor = System.Drawing.SystemColors.Window
        Appearance62.BorderColor = System.Drawing.Color.Silver
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.RowAppearance = Appearance62
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance63.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_PaintSchedule_Day3.DisplayLayout.Override.TemplateAddRowAppearance = Appearance63
        Me.ug_PaintSchedule_Day3.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_PaintSchedule_Day3.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_PaintSchedule_Day3.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_PaintSchedule_Day3.Location = New System.Drawing.Point(2, 18)
        Me.ug_PaintSchedule_Day3.Name = "ug_PaintSchedule_Day3"
        Me.ug_PaintSchedule_Day3.Size = New System.Drawing.Size(381, 80)
        Me.ug_PaintSchedule_Day3.TabIndex = 8
        Me.ug_PaintSchedule_Day3.Text = "UltraGrid2"
        '
        'mnuDay3
        '
        Me.mnuDay3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveUpToolStripMenuItem_Day3, Me.MoveDownToolStripMenuItem_Day3, Me.ViewOrdersToolStripMenuItem_Day3, Me.MoveNextDayToolStripMenuItem_Day3, Me.MovePreviousDayToolStripMenuItem_Day3, Me.RemoveFromScheduleToolStripMenuItem_Day3, Me.ColumnChooserToolStripMenuItem_Day3})
        Me.mnuDay3.Name = "mnuDay1"
        Me.mnuDay3.Size = New System.Drawing.Size(200, 158)
        '
        'MoveUpToolStripMenuItem_Day3
        '
        Me.MoveUpToolStripMenuItem_Day3.Image = Global.SequenceERP.My.Resources.Resources.up_32
        Me.MoveUpToolStripMenuItem_Day3.Name = "MoveUpToolStripMenuItem_Day3"
        Me.MoveUpToolStripMenuItem_Day3.Size = New System.Drawing.Size(199, 22)
        Me.MoveUpToolStripMenuItem_Day3.Text = "Move Up"
        '
        'MoveDownToolStripMenuItem_Day3
        '
        Me.MoveDownToolStripMenuItem_Day3.Image = Global.SequenceERP.My.Resources.Resources.down_32
        Me.MoveDownToolStripMenuItem_Day3.Name = "MoveDownToolStripMenuItem_Day3"
        Me.MoveDownToolStripMenuItem_Day3.Size = New System.Drawing.Size(199, 22)
        Me.MoveDownToolStripMenuItem_Day3.Text = "Move Down"
        '
        'ViewOrdersToolStripMenuItem_Day3
        '
        Me.ViewOrdersToolStripMenuItem_Day3.Name = "ViewOrdersToolStripMenuItem_Day3"
        Me.ViewOrdersToolStripMenuItem_Day3.Size = New System.Drawing.Size(199, 22)
        Me.ViewOrdersToolStripMenuItem_Day3.Text = "View Orders"
        '
        'MoveNextDayToolStripMenuItem_Day3
        '
        Me.MoveNextDayToolStripMenuItem_Day3.Image = Global.SequenceERP.My.Resources.Resources.down_32
        Me.MoveNextDayToolStripMenuItem_Day3.Name = "MoveNextDayToolStripMenuItem_Day3"
        Me.MoveNextDayToolStripMenuItem_Day3.Size = New System.Drawing.Size(199, 22)
        Me.MoveNextDayToolStripMenuItem_Day3.Text = "Move Next Day"
        '
        'MovePreviousDayToolStripMenuItem_Day3
        '
        Me.MovePreviousDayToolStripMenuItem_Day3.Image = Global.SequenceERP.My.Resources.Resources.up_32
        Me.MovePreviousDayToolStripMenuItem_Day3.Name = "MovePreviousDayToolStripMenuItem_Day3"
        Me.MovePreviousDayToolStripMenuItem_Day3.Size = New System.Drawing.Size(199, 22)
        Me.MovePreviousDayToolStripMenuItem_Day3.Text = "Move Previous Day"
        '
        'RemoveFromScheduleToolStripMenuItem_Day3
        '
        Me.RemoveFromScheduleToolStripMenuItem_Day3.Image = Global.SequenceERP.My.Resources.Resources.delete_32
        Me.RemoveFromScheduleToolStripMenuItem_Day3.Name = "RemoveFromScheduleToolStripMenuItem_Day3"
        Me.RemoveFromScheduleToolStripMenuItem_Day3.Size = New System.Drawing.Size(199, 22)
        Me.RemoveFromScheduleToolStripMenuItem_Day3.Text = "Remove From Schedule"
        '
        'ColumnChooserToolStripMenuItem_Day3
        '
        Me.ColumnChooserToolStripMenuItem_Day3.Name = "ColumnChooserToolStripMenuItem_Day3"
        Me.ColumnChooserToolStripMenuItem_Day3.Size = New System.Drawing.Size(199, 22)
        Me.ColumnChooserToolStripMenuItem_Day3.Text = "Column Chooser"
        '
        'lblDay3
        '
        Me.lblDay3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDay3.Location = New System.Drawing.Point(2, 3)
        Me.lblDay3.Name = "lblDay3"
        Me.lblDay3.Size = New System.Drawing.Size(381, 23)
        Me.lblDay3.TabIndex = 10
        Me.lblDay3.Text = "Day 3:"
        '
        'upDay2
        '
        '
        'upDay2.ClientArea
        '
        Me.upDay2.ClientArea.Controls.Add(Me.ug_PaintSchedule_Day2)
        Me.upDay2.ClientArea.Controls.Add(Me.lblDay2)
        Me.upDay2.Location = New System.Drawing.Point(4, 170)
        Me.upDay2.Name = "upDay2"
        Me.upDay2.Size = New System.Drawing.Size(388, 105)
        Me.upDay2.TabIndex = 12
        '
        'ug_PaintSchedule_Day2
        '
        Me.ug_PaintSchedule_Day2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ug_PaintSchedule_Day2.ContextMenuStrip = Me.mnuDay2
        Appearance64.BackColor = System.Drawing.SystemColors.Window
        Appearance64.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_PaintSchedule_Day2.DisplayLayout.Appearance = Appearance64
        Me.ug_PaintSchedule_Day2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_PaintSchedule_Day2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance65.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance65.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance65.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance65.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day2.DisplayLayout.GroupByBox.Appearance = Appearance65
        Appearance66.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintSchedule_Day2.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance66
        Me.ug_PaintSchedule_Day2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance67.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance67.BackColor2 = System.Drawing.SystemColors.Control
        Appearance67.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance67.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintSchedule_Day2.DisplayLayout.GroupByBox.PromptAppearance = Appearance67
        Me.ug_PaintSchedule_Day2.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_PaintSchedule_Day2.DisplayLayout.MaxRowScrollRegions = 1
        Appearance68.BackColor = System.Drawing.SystemColors.Window
        Appearance68.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.ActiveCellAppearance = Appearance68
        Appearance69.BackColor = System.Drawing.SystemColors.Highlight
        Appearance69.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.ActiveRowAppearance = Appearance69
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance70.BackColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.CardAreaAppearance = Appearance70
        Appearance71.BorderColor = System.Drawing.Color.Silver
        Appearance71.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.CellAppearance = Appearance71
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.CellPadding = 0
        Appearance72.BackColor = System.Drawing.SystemColors.Control
        Appearance72.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance72.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance72.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance72.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.GroupByRowAppearance = Appearance72
        Appearance73.TextHAlignAsString = "Left"
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.HeaderAppearance = Appearance73
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance74.BackColor = System.Drawing.SystemColors.Window
        Appearance74.BorderColor = System.Drawing.Color.Silver
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.RowAppearance = Appearance74
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance75.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_PaintSchedule_Day2.DisplayLayout.Override.TemplateAddRowAppearance = Appearance75
        Me.ug_PaintSchedule_Day2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_PaintSchedule_Day2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_PaintSchedule_Day2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_PaintSchedule_Day2.Location = New System.Drawing.Point(2, 18)
        Me.ug_PaintSchedule_Day2.Name = "ug_PaintSchedule_Day2"
        Me.ug_PaintSchedule_Day2.Size = New System.Drawing.Size(381, 80)
        Me.ug_PaintSchedule_Day2.TabIndex = 8
        Me.ug_PaintSchedule_Day2.Text = "UltraGrid1"
        '
        'mnuDay2
        '
        Me.mnuDay2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveUpToolStripMenuItem_Day2, Me.MoveDownToolStripMenuItem_Day2, Me.ViewOrdersToolStripMenuItem_Day2, Me.MoveNextDayToolStripMenuItem_Day2, Me.MovePreviousDayToolStripMenuItem_Day2, Me.RemoveFromScheduleToolStripMenuItem_Day2, Me.ColumnChooserToolStripMenuItem_Day2})
        Me.mnuDay2.Name = "mnuDay1"
        Me.mnuDay2.Size = New System.Drawing.Size(200, 158)
        '
        'MoveUpToolStripMenuItem_Day2
        '
        Me.MoveUpToolStripMenuItem_Day2.Image = Global.SequenceERP.My.Resources.Resources.up_32
        Me.MoveUpToolStripMenuItem_Day2.Name = "MoveUpToolStripMenuItem_Day2"
        Me.MoveUpToolStripMenuItem_Day2.Size = New System.Drawing.Size(199, 22)
        Me.MoveUpToolStripMenuItem_Day2.Text = "Move Up"
        '
        'MoveDownToolStripMenuItem_Day2
        '
        Me.MoveDownToolStripMenuItem_Day2.Image = Global.SequenceERP.My.Resources.Resources.down_32
        Me.MoveDownToolStripMenuItem_Day2.Name = "MoveDownToolStripMenuItem_Day2"
        Me.MoveDownToolStripMenuItem_Day2.Size = New System.Drawing.Size(199, 22)
        Me.MoveDownToolStripMenuItem_Day2.Text = "Move Down"
        '
        'ViewOrdersToolStripMenuItem_Day2
        '
        Me.ViewOrdersToolStripMenuItem_Day2.Name = "ViewOrdersToolStripMenuItem_Day2"
        Me.ViewOrdersToolStripMenuItem_Day2.Size = New System.Drawing.Size(199, 22)
        Me.ViewOrdersToolStripMenuItem_Day2.Text = "View Orders"
        '
        'MoveNextDayToolStripMenuItem_Day2
        '
        Me.MoveNextDayToolStripMenuItem_Day2.Image = Global.SequenceERP.My.Resources.Resources.down_32
        Me.MoveNextDayToolStripMenuItem_Day2.Name = "MoveNextDayToolStripMenuItem_Day2"
        Me.MoveNextDayToolStripMenuItem_Day2.Size = New System.Drawing.Size(199, 22)
        Me.MoveNextDayToolStripMenuItem_Day2.Text = "Move Next Day"
        '
        'MovePreviousDayToolStripMenuItem_Day2
        '
        Me.MovePreviousDayToolStripMenuItem_Day2.Image = Global.SequenceERP.My.Resources.Resources.up_32
        Me.MovePreviousDayToolStripMenuItem_Day2.Name = "MovePreviousDayToolStripMenuItem_Day2"
        Me.MovePreviousDayToolStripMenuItem_Day2.Size = New System.Drawing.Size(199, 22)
        Me.MovePreviousDayToolStripMenuItem_Day2.Text = "Move Previous Day"
        '
        'RemoveFromScheduleToolStripMenuItem_Day2
        '
        Me.RemoveFromScheduleToolStripMenuItem_Day2.Image = Global.SequenceERP.My.Resources.Resources.delete_32
        Me.RemoveFromScheduleToolStripMenuItem_Day2.Name = "RemoveFromScheduleToolStripMenuItem_Day2"
        Me.RemoveFromScheduleToolStripMenuItem_Day2.Size = New System.Drawing.Size(199, 22)
        Me.RemoveFromScheduleToolStripMenuItem_Day2.Text = "Remove From Schedule"
        '
        'ColumnChooserToolStripMenuItem_Day2
        '
        Me.ColumnChooserToolStripMenuItem_Day2.Name = "ColumnChooserToolStripMenuItem_Day2"
        Me.ColumnChooserToolStripMenuItem_Day2.Size = New System.Drawing.Size(199, 22)
        Me.ColumnChooserToolStripMenuItem_Day2.Text = "Column Chooser"
        '
        'lblDay2
        '
        Me.lblDay2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDay2.Location = New System.Drawing.Point(2, 3)
        Me.lblDay2.Name = "lblDay2"
        Me.lblDay2.Size = New System.Drawing.Size(381, 23)
        Me.lblDay2.TabIndex = 10
        Me.lblDay2.Text = "Day 2:"
        '
        'upDay1
        '
        '
        'upDay1.ClientArea
        '
        Me.upDay1.ClientArea.Controls.Add(Me.ug_PaintSchedule_Day1)
        Me.upDay1.ClientArea.Controls.Add(Me.lblDay1)
        Me.upDay1.Location = New System.Drawing.Point(4, 59)
        Me.upDay1.Name = "upDay1"
        Me.upDay1.Size = New System.Drawing.Size(388, 105)
        Me.upDay1.TabIndex = 11
        '
        'ug_PaintSchedule_Day1
        '
        Me.ug_PaintSchedule_Day1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ug_PaintSchedule_Day1.ContextMenuStrip = Me.mnuDay1
        Appearance76.BackColor = System.Drawing.SystemColors.Window
        Appearance76.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_PaintSchedule_Day1.DisplayLayout.Appearance = Appearance76
        Me.ug_PaintSchedule_Day1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_PaintSchedule_Day1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance77.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance77.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance77.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance77.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day1.DisplayLayout.GroupByBox.Appearance = Appearance77
        Appearance78.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintSchedule_Day1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance78
        Me.ug_PaintSchedule_Day1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance79.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance79.BackColor2 = System.Drawing.SystemColors.Control
        Appearance79.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance79.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_PaintSchedule_Day1.DisplayLayout.GroupByBox.PromptAppearance = Appearance79
        Me.ug_PaintSchedule_Day1.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_PaintSchedule_Day1.DisplayLayout.MaxRowScrollRegions = 1
        Appearance80.BackColor = System.Drawing.SystemColors.Window
        Appearance80.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.ActiveCellAppearance = Appearance80
        Appearance81.BackColor = System.Drawing.SystemColors.Highlight
        Appearance81.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.ActiveRowAppearance = Appearance81
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance82.BackColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.CardAreaAppearance = Appearance82
        Appearance83.BorderColor = System.Drawing.Color.Silver
        Appearance83.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.CellAppearance = Appearance83
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.CellPadding = 0
        Appearance84.BackColor = System.Drawing.SystemColors.Control
        Appearance84.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance84.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance84.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance84.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.GroupByRowAppearance = Appearance84
        Appearance85.TextHAlignAsString = "Left"
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.HeaderAppearance = Appearance85
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance86.BackColor = System.Drawing.SystemColors.Window
        Appearance86.BorderColor = System.Drawing.Color.Silver
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.RowAppearance = Appearance86
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance87.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_PaintSchedule_Day1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance87
        Me.ug_PaintSchedule_Day1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_PaintSchedule_Day1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_PaintSchedule_Day1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_PaintSchedule_Day1.Location = New System.Drawing.Point(2, 18)
        Me.ug_PaintSchedule_Day1.Name = "ug_PaintSchedule_Day1"
        Me.ug_PaintSchedule_Day1.Size = New System.Drawing.Size(381, 80)
        Me.ug_PaintSchedule_Day1.TabIndex = 8
        Me.ug_PaintSchedule_Day1.Text = "UltraGrid4"
        '
        'mnuDay1
        '
        Me.mnuDay1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveUpToolStripMenuItem_Day1, Me.MoveDownToolStripMenuItem_Day1, Me.ViewOrdersToolStripMenuItem_Day1, Me.MoveNextDayToolStripMenuItem_Day1, Me.MovePreviousDayToolStripMenuItem_Day1, Me.RemoveFromScheduleToolStripMenuItem_Day1, Me.ColumnChooserToolStripMenuItem_Day1})
        Me.mnuDay1.Name = "mnuDay1"
        Me.mnuDay1.Size = New System.Drawing.Size(200, 158)
        '
        'MoveUpToolStripMenuItem_Day1
        '
        Me.MoveUpToolStripMenuItem_Day1.Image = Global.SequenceERP.My.Resources.Resources.up_32
        Me.MoveUpToolStripMenuItem_Day1.Name = "MoveUpToolStripMenuItem_Day1"
        Me.MoveUpToolStripMenuItem_Day1.Size = New System.Drawing.Size(199, 22)
        Me.MoveUpToolStripMenuItem_Day1.Text = "Move Up"
        '
        'MoveDownToolStripMenuItem_Day1
        '
        Me.MoveDownToolStripMenuItem_Day1.Image = Global.SequenceERP.My.Resources.Resources.down_32
        Me.MoveDownToolStripMenuItem_Day1.Name = "MoveDownToolStripMenuItem_Day1"
        Me.MoveDownToolStripMenuItem_Day1.Size = New System.Drawing.Size(199, 22)
        Me.MoveDownToolStripMenuItem_Day1.Text = "Move Down"
        '
        'ViewOrdersToolStripMenuItem_Day1
        '
        Me.ViewOrdersToolStripMenuItem_Day1.Name = "ViewOrdersToolStripMenuItem_Day1"
        Me.ViewOrdersToolStripMenuItem_Day1.Size = New System.Drawing.Size(199, 22)
        Me.ViewOrdersToolStripMenuItem_Day1.Text = "View Orders"
        '
        'MoveNextDayToolStripMenuItem_Day1
        '
        Me.MoveNextDayToolStripMenuItem_Day1.Image = Global.SequenceERP.My.Resources.Resources.down_32
        Me.MoveNextDayToolStripMenuItem_Day1.Name = "MoveNextDayToolStripMenuItem_Day1"
        Me.MoveNextDayToolStripMenuItem_Day1.Size = New System.Drawing.Size(199, 22)
        Me.MoveNextDayToolStripMenuItem_Day1.Text = "Move Next Day"
        '
        'MovePreviousDayToolStripMenuItem_Day1
        '
        Me.MovePreviousDayToolStripMenuItem_Day1.Image = Global.SequenceERP.My.Resources.Resources.up_32
        Me.MovePreviousDayToolStripMenuItem_Day1.Name = "MovePreviousDayToolStripMenuItem_Day1"
        Me.MovePreviousDayToolStripMenuItem_Day1.Size = New System.Drawing.Size(199, 22)
        Me.MovePreviousDayToolStripMenuItem_Day1.Text = "Move Previous Day"
        '
        'RemoveFromScheduleToolStripMenuItem_Day1
        '
        Me.RemoveFromScheduleToolStripMenuItem_Day1.Image = Global.SequenceERP.My.Resources.Resources.delete_32
        Me.RemoveFromScheduleToolStripMenuItem_Day1.Name = "RemoveFromScheduleToolStripMenuItem_Day1"
        Me.RemoveFromScheduleToolStripMenuItem_Day1.Size = New System.Drawing.Size(199, 22)
        Me.RemoveFromScheduleToolStripMenuItem_Day1.Text = "Remove From Schedule"
        '
        'ColumnChooserToolStripMenuItem_Day1
        '
        Me.ColumnChooserToolStripMenuItem_Day1.Name = "ColumnChooserToolStripMenuItem_Day1"
        Me.ColumnChooserToolStripMenuItem_Day1.Size = New System.Drawing.Size(199, 22)
        Me.ColumnChooserToolStripMenuItem_Day1.Text = "Column Chooser"
        '
        'lblDay1
        '
        Me.lblDay1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDay1.Location = New System.Drawing.Point(2, 3)
        Me.lblDay1.Name = "lblDay1"
        Me.lblDay1.Size = New System.Drawing.Size(381, 23)
        Me.lblDay1.TabIndex = 10
        Me.lblDay1.Text = "Day 1:"
        '
        'uccWeekOf
        '
        Me.uccWeekOf.DateButtons.Add(DateButton1)
        Me.uccWeekOf.Location = New System.Drawing.Point(83, 3)
        Me.uccWeekOf.Name = "uccWeekOf"
        Me.uccWeekOf.NonAutoSizeHeight = 21
        Me.uccWeekOf.Size = New System.Drawing.Size(121, 21)
        Me.uccWeekOf.TabIndex = 0
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Location = New System.Drawing.Point(3, 7)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel4.TabIndex = 4
        Me.UltraLabel4.Text = "Week Of"
        '
        'ucPaintLines
        '
        Appearance88.BackColor = System.Drawing.SystemColors.Window
        Appearance88.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ucPaintLines.DisplayLayout.Appearance = Appearance88
        Me.ucPaintLines.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ucPaintLines.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance89.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance89.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance89.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance89.BorderColor = System.Drawing.SystemColors.Window
        Me.ucPaintLines.DisplayLayout.GroupByBox.Appearance = Appearance89
        Appearance90.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ucPaintLines.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance90
        Me.ucPaintLines.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance91.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance91.BackColor2 = System.Drawing.SystemColors.Control
        Appearance91.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance91.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ucPaintLines.DisplayLayout.GroupByBox.PromptAppearance = Appearance91
        Me.ucPaintLines.DisplayLayout.MaxColScrollRegions = 1
        Me.ucPaintLines.DisplayLayout.MaxRowScrollRegions = 1
        Appearance92.BackColor = System.Drawing.SystemColors.Window
        Appearance92.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ucPaintLines.DisplayLayout.Override.ActiveCellAppearance = Appearance92
        Appearance93.BackColor = System.Drawing.SystemColors.Highlight
        Appearance93.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ucPaintLines.DisplayLayout.Override.ActiveRowAppearance = Appearance93
        Me.ucPaintLines.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ucPaintLines.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance94.BackColor = System.Drawing.SystemColors.Window
        Me.ucPaintLines.DisplayLayout.Override.CardAreaAppearance = Appearance94
        Appearance95.BorderColor = System.Drawing.Color.Silver
        Appearance95.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ucPaintLines.DisplayLayout.Override.CellAppearance = Appearance95
        Me.ucPaintLines.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ucPaintLines.DisplayLayout.Override.CellPadding = 0
        Appearance96.BackColor = System.Drawing.SystemColors.Control
        Appearance96.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance96.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance96.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance96.BorderColor = System.Drawing.SystemColors.Window
        Me.ucPaintLines.DisplayLayout.Override.GroupByRowAppearance = Appearance96
        Appearance97.TextHAlignAsString = "Left"
        Me.ucPaintLines.DisplayLayout.Override.HeaderAppearance = Appearance97
        Me.ucPaintLines.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ucPaintLines.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance98.BackColor = System.Drawing.SystemColors.Window
        Appearance98.BorderColor = System.Drawing.Color.Silver
        Me.ucPaintLines.DisplayLayout.Override.RowAppearance = Appearance98
        Me.ucPaintLines.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance99.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ucPaintLines.DisplayLayout.Override.TemplateAddRowAppearance = Appearance99
        Me.ucPaintLines.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ucPaintLines.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ucPaintLines.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ucPaintLines.Location = New System.Drawing.Point(83, 30)
        Me.ucPaintLines.Name = "ucPaintLines"
        Me.ucPaintLines.Size = New System.Drawing.Size(231, 22)
        Me.ucPaintLines.TabIndex = 2
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Location = New System.Drawing.Point(3, 30)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(100, 23)
        Me.UltraLabel3.TabIndex = 3
        Me.UltraLabel3.Text = "Work Centre"
        '
        'btnRefreshScheduleDates
        '
        Me.btnRefreshScheduleDates.Location = New System.Drawing.Point(312, 3)
        Me.btnRefreshScheduleDates.Name = "btnRefreshScheduleDates"
        Me.btnRefreshScheduleDates.Size = New System.Drawing.Size(75, 23)
        Me.btnRefreshScheduleDates.TabIndex = 1
        Me.btnRefreshScheduleDates.Text = "Refresh"
        '
        'btnClearSelected
        '
        Me.btnClearSelected.Location = New System.Drawing.Point(211, 3)
        Me.btnClearSelected.Name = "btnClearSelected"
        Me.btnClearSelected.Size = New System.Drawing.Size(95, 23)
        Me.btnClearSelected.TabIndex = 14
        Me.btnClearSelected.Text = "Clear Selected"
        '
        'frmPaintStatus
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1360, 720)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.btnExportToExcel)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnToggleSummary)
        Me.Controls.Add(Me.lblRefreshed)
        Me.Controls.Add(Me.upScheduleDates)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.upAddToSchedule)
        Me.Controls.Add(Me.BtnRefresh)
        Me.Controls.Add(Me.upMain)
        Me.Controls.Add(Me.lblOrders)
        Me.Controls.Add(Me.btnPrintSelected)
        Me.Controls.Add(Me.lblShowing)
        Me.Controls.Add(Me.lblHighlight)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(791, 592)
        Me.Name = "frmPaintStatus"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Production Status"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ug_PaintStatus_DoorLists, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ugFilters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilterName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilterDescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        Me.upMain.ClientArea.ResumeLayout(False)
        Me.upMain.ResumeLayout(False)
        Me.upAddToSchedule.ClientArea.ResumeLayout(False)
        Me.upAddToSchedule.ResumeLayout(False)
        Me.upScheduleDates.ClientArea.ResumeLayout(False)
        Me.upScheduleDates.ClientArea.PerformLayout()
        Me.upScheduleDates.ResumeLayout(False)
        Me.upDay5.ClientArea.ResumeLayout(False)
        Me.upDay5.ResumeLayout(False)
        CType(Me.ug_PaintSchedule_Day5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuDay5.ResumeLayout(False)
        Me.upDay4.ClientArea.ResumeLayout(False)
        Me.upDay4.ResumeLayout(False)
        CType(Me.ug_PaintSchedule_Day4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuDay4.ResumeLayout(False)
        Me.upDay3.ClientArea.ResumeLayout(False)
        Me.upDay3.ResumeLayout(False)
        CType(Me.ug_PaintSchedule_Day3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuDay3.ResumeLayout(False)
        Me.upDay2.ClientArea.ResumeLayout(False)
        Me.upDay2.ResumeLayout(False)
        CType(Me.ug_PaintSchedule_Day2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuDay2.ResumeLayout(False)
        Me.upDay1.ClientArea.ResumeLayout(False)
        Me.upDay1.ResumeLayout(False)
        CType(Me.ug_PaintSchedule_Day1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuDay1.ResumeLayout(False)
        CType(Me.uccWeekOf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucPaintLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim ds As New DataSet
    Public Shared MissingReason As String
    'Private lvwColumnSorter2 As ListViewColumnSorter
    Private Sub FrmProductionStatus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            GridSummary = False

            KPGeneral.SetDefaultGridSettings(ug_PaintStatus_DoorLists)

            KPGeneral.SetDefaultGridSettings(ug_PaintSchedule_Day1)
            KPGeneral.SetDefaultGridSettings(ug_PaintSchedule_Day2)
            KPGeneral.SetDefaultGridSettings(ug_PaintSchedule_Day3)
            KPGeneral.SetDefaultGridSettings(ug_PaintSchedule_Day4)
            KPGeneral.SetDefaultGridSettings(ug_PaintSchedule_Day5)

            refreshLVReady()

            Me.Cursor = Cursors.Default

            FillSecurity()
            RefreshFilterList()

            Dim dsDefault As New DataSet
            dsDefault = KPGeneral.WebRef_Local.usp_GetPaintStatusFilterDefault
            If dsDefault.Tables(0).Rows.Count > 0 Then
                If IsDBNull(dsDefault.Tables(0).Rows(0)("FilterFile")) = False Then
                    LoadFilterDefault(dsDefault)
                End If
            End If
            DefaultFontSize = ug_PaintStatus_DoorLists.Font.SizeInPoints

            ug_PaintStatus_DoorLists.DisplayLayout.Override.TipStyleHeader = TipStyle.Show

            RefreshWorkCentreList()

            uccWeekOf.Text = Now.Date

            ProcessWeekOf()

            RefreshScheduleGrids()
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub ShowGridSummary()

        If GridSummary = True Then
            ug_PaintStatus_DoorLists.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.True
            ug_PaintStatus_DoorLists.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            ug_PaintStatus_DoorLists.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True
        Else
            ug_PaintStatus_DoorLists.DisplayLayout.Override.AllowRowSummaries = AllowRowSummaries.False
            ug_PaintStatus_DoorLists.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.None
            ug_PaintStatus_DoorLists.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        End If

    End Sub
    Private Sub HighlightAccelerated()
        If KPGeneral.User.UserProfile("ShowAcceleratedHighlights") Then
            Dim x As Integer
            For x = 0 To ug_PaintStatus_DoorLists.Rows.Count - 1
                If IsDBNull(ug_PaintStatus_DoorLists.Rows(x).Cells("FlagAccelerated").Value) = False Then
                    If ug_PaintStatus_DoorLists.Rows(x).Cells("FlagAccelerated").Value = True Then
                        ug_PaintStatus_DoorLists.Rows(x).Appearance.BackColor = Color.FromName(StatusColours.Accelerated_BackColour)
                        ug_PaintStatus_DoorLists.Rows(x).Appearance.ForeColor = Color.FromName(StatusColours.Accelerated_ForeColour)
                    End If
                End If
            Next
        End If


    End Sub
    Private Sub refreshLVReady()
        Try

            Me.Cursor = Cursors.WaitCursor
            StatusColours.RefreshStatusColours()
            'webservice for list 
            ug_PaintStatus_DoorLists.DataSource = Nothing
            Dim ds1 As New DataSet
            ds = KPGeneral.WebRef_Local.spKPFactory_PaintStatus_AllOrders()
            'ds1 = ds.Clone
            ds1 = ds.Copy

            lblOrders.Text = "Door Lists to Paint: " & ds.Tables(0).Rows.Count()
            lblOrders.Text = lblOrders.Text & " DL / " & ds.Tables(0).Compute("Sum(DoorCount)", "") & " doors / " & Math.Round(ds.Tables(0).Compute("Sum(SQM)", ""), 2, MidpointRounding.AwayFromZero) & " SQM"

            ug_PaintStatus_DoorLists.DataSource = ds1

            Dim x As Integer
            For x = 0 To ug_PaintStatus_DoorLists.Rows.Count - 1
                If IsDBNull(ug_PaintStatus_DoorLists.Rows(x).Cells("OnHold").Value) = False Then
                    If ug_PaintStatus_DoorLists.Rows(x).Cells("OnHold").Value = True Then
                        ug_PaintStatus_DoorLists.Rows(x).Appearance.BackColor = Color.FromName(StatusColours.OnHold_BackColour)
                        ug_PaintStatus_DoorLists.Rows(x).Appearance.ForeColor = Color.FromName(StatusColours.OnHold_ForeColour)
                    End If
                End If

                If IsDBNull(ug_PaintStatus_DoorLists.Rows(x).Cells("RawDate").Value) = False Then
                    ug_PaintStatus_DoorLists.Rows(x).Cells("RawDate").Appearance.BackColor = Color.YellowGreen
                    ug_PaintStatus_DoorLists.Rows(x).Cells("RawDate").Appearance.ForeColor = Color.YellowGreen
                Else
                    ug_PaintStatus_DoorLists.Rows(x).Cells("RawDate").Appearance.BackColor = Color.Tomato
                    ug_PaintStatus_DoorLists.Rows(x).Cells("RawDate").Appearance.ForeColor = Color.Tomato
                End If

                Dim ColourMatch As Boolean = False

                If IsDBNull(ug_PaintStatus_DoorLists.Rows(x).Cells("ColourMatch").Value) = True Then
                    ColourMatch = False
                Else
                    ColourMatch = ug_PaintStatus_DoorLists.Rows(x).Cells("ColourMatch").Value
                End If

                If ColourMatch = True Then
                    ug_PaintStatus_DoorLists.Rows(x).Cells("ColourMatch").Appearance.BackColor = Color.YellowGreen
                    ug_PaintStatus_DoorLists.Rows(x).Cells("ColourMatch").Appearance.ForeColor = Color.YellowGreen
                Else
                    ug_PaintStatus_DoorLists.Rows(x).Cells("ColourMatch").Appearance.BackColor = Color.Tomato
                    ug_PaintStatus_DoorLists.Rows(x).Cells("ColourMatch").Appearance.ForeColor = Color.Tomato
                End If

                If IsDBNull(ug_PaintStatus_DoorLists.Rows(x).Cells("AS").Value) = False Then
                    '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                    ug_PaintStatus_DoorLists.Rows(x).Cells("AS").Appearance.BackColor = Color.YellowGreen
                    ug_PaintStatus_DoorLists.Rows(x).Cells("AS").Appearance.ForeColor = Color.YellowGreen
                Else
                    '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                    ug_PaintStatus_DoorLists.Rows(x).Cells("AS").Appearance.BackColor = Color.Tomato
                    ug_PaintStatus_DoorLists.Rows(x).Cells("AS").Appearance.ForeColor = Color.Tomato
                End If
            Next

            RefreshSummaryInfo()

            'ugReady.DisplayLayout.Bands(0).Columns("ProdDef").Header.Caption = "OpenPDef"

            txtFilterName.Text = ""
            txtFilterDescription.Text = ""

            lblRefreshed.Text = "Refreshed On: " & Now

            'HighlightAccelerated()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub FillSecurity()
        Dim UpdateAllowed As Boolean = KPGeneral.User.UserProfile("ProductionStatusFilterUpdate")
        Dim SiteRequest As Boolean = KPGeneral.User.UserProfile("SchedulingPage")

        btnToggleSummary.Visible = True

        txtFilterName.Visible = UpdateAllowed
        txtFilterDescription.Visible = UpdateAllowed
        btnAddFilter.Visible = UpdateAllowed
        btnDeactivateFilter.Visible = UpdateAllowed
        btnUpdateFilter.Visible = UpdateAllowed
        btnColumnChooser.Visible = UpdateAllowed
        lblFilterDescription.Visible = UpdateAllowed
        lblFilterName.Visible = UpdateAllowed

        If UpdateAllowed = True Then
            ug_PaintStatus_DoorLists.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.True
        Else
            ug_PaintStatus_DoorLists.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.False
        End If

        Dim UID As String
        UID = KPGeneral.User.UserProfile("UserLoginName")
    End Sub
    Private Sub RefreshWorkCentreList()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_PaintStatus_GetLinesForSchedule

        ucPaintLines.DataSource = ds

        ucPaintLines.DisplayLayout.Bands(0).ColHeadersVisible = False
        ucPaintLines.DisplayLayout.Bands(0).Columns("LineID").Hidden = True
        ucPaintLines.ValueMember = "LineID"
        ucPaintLines.DisplayMember = "LineName"
    End Sub
    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        RefreshWithFilter()
    End Sub
    Private Sub RefreshWithFilter()
        RefreshList()

        If FilterLoaded = True Then
            If ugFilters.ActiveRow.Index > -1 Then
                If IsDBNull(ugFilters.ActiveRow.Cells("FilterFile").Value) = False Then
                    LoadFilter(ugFilters, ugFilters.ActiveRow.Index)
                End If
            End If
        End If
    End Sub
    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        Try
            Dim x, c As Integer
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then

                c = 0
                c = ug_PaintStatus_DoorLists.Rows.Count
                'For x = 0 To c - 1
                '    'LVReady.Items.Item(LVReady.SelectedIndices(0)).Selected = False
                'Next
                Dim SearchResult As String
                SearchResult = KPGeneral.ParseBarcode(txtBarcode.Text)

                If SearchResult <> "0" Then
                    For x = 0 To ug_PaintStatus_DoorLists.Rows.Count - 1
                        If Trim(ug_PaintStatus_DoorLists.Rows(x).Cells("MASTERNUM").Text) = Trim(SearchResult) Then
                            ug_PaintStatus_DoorLists.Rows(x).Selected = True
                            ug_PaintStatus_DoorLists.Rows(x).Activate()
                        End If
                    Next
                    txtBarcode.Text = ""
                Else
                    For x = 0 To ug_PaintStatus_DoorLists.Rows.Count - 1
                        If ug_PaintStatus_DoorLists.Rows(x).Cells("COMPANY").Text.ToLower.StartsWith(Trim(txtBarcode.Text.ToLower & e.KeyChar.ToString.ToLower)) = True Then
                            ug_PaintStatus_DoorLists.Rows(x).Activate()
                            Exit For
                        End If
                    Next

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub LVReady_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles LVReady.ColumnClick
    '    Try
    '        ' Determine if the clicked column is already the column that is
    '        ' being sorted.
    '        If (e.Column = lvwColumnSorter2.SortColumn) Then
    '            ' Reverse the current sort direction for this column.
    '            If (lvwColumnSorter2.Order = SortOrder.Ascending) Then
    '                lvwColumnSorter2.Order = SortOrder.Descending
    '            Else
    '                lvwColumnSorter2.Order = SortOrder.Ascending
    '            End If
    '        Else
    '            ' Set the column number that is to be sorted; default to ascending.
    '            lvwColumnSorter2.SortColumn = e.Column
    '            lvwColumnSorter2.Order = SortOrder.Ascending
    '        End If

    '        ' Perform the sort with these new sort options.
    '        LVReady.Sort()
    '    Catch ex As Exception
    '        Call global.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
    '    End Try
    'End Sub
    Private Sub ugReady_AfterCellActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ug_PaintStatus_DoorLists.AfterCellActivate

    End Sub
    Private Sub ugReady_AfterRowFilterChanged(sender As Object, e As Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs) Handles ug_PaintStatus_DoorLists.AfterRowFilterChanged
        RefreshSummaryInfo()
    End Sub
    Private Sub ugReady_AfterSelectChange(sender As Object, e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles ug_PaintStatus_DoorLists.AfterSelectChange
        RefreshHighlightInfo()
    End Sub
    Private Sub ugReady_BeforeCellActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles ug_PaintStatus_DoorLists.BeforeCellActivate

    End Sub
    Private Sub btnPrintSelected_Click(sender As Object, e As EventArgs) Handles btnPrintSelected.Click

        If ug_PaintStatus_DoorLists.Selected.Rows.Count > 0 Then
            'StyleRevisedOrdersPrint()
            'StyleGridPrintSelected()
            UltraGridPrintDocument1.Grid = ug_PaintStatus_DoorLists
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
    Private Sub ugReady_GestureCompleted(sender As Object, e As Infragistics.Win.Touch.GestureCompletedEventArgs) Handles ug_PaintStatus_DoorLists.GestureCompleted
        If e.Gesture = Infragistics.Win.Touch.Gesture.Zoom Then
            GestureFinishX = e.Location.X
            GestureFinishY = e.Location.Y

            If GestureFinishX < GestureStartX And GestureFinishY < GestureStartY Then
                ResizeMainGrid(False)
            ElseIf GestureFinishX < GestureStartX And GestureFinishY > GestureStartY Then
                ResizeMainGrid(False)
            ElseIf GestureFinishX > GestureStartX And GestureFinishY < GestureStartY Then
                ResizeMainGrid(True)
            Else
                ResizeMainGrid(True)
            End If
        End If
    End Sub
    Private Sub ugReady_GestureStarting(sender As Object, e As Infragistics.Win.Touch.GestureStartingEventArgs) Handles ug_PaintStatus_DoorLists.GestureStarting
        If e.Gesture = Infragistics.Win.Touch.Gesture.Zoom Then
            GestureStartX = e.Location.X
            GestureStartY = e.Location.Y
        End If
    End Sub
    Private Sub ugReady_InitializePrint(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelablePrintEventArgs) Handles ug_PaintStatus_DoorLists.InitializePrint
        e.DefaultLogicalPageLayoutInfo.PageHeader = "Paint Status - " & PrintFilter & " filter"

        e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center

        e.DefaultLogicalPageLayoutInfo.PageFooter = "Printed on " & Now & vbTab & "Page <#> of <##>"
        e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 20
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    End Sub
    Private Sub ugReady_InitializePrintPreview(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelablePrintPreviewEventArgs) Handles ug_PaintStatus_DoorLists.InitializePrintPreview
        e.DefaultLogicalPageLayoutInfo.PageHeader = "Paint Status - " & PrintFilter

        e.DefaultLogicalPageLayoutInfo.PageHeaderHeight = 40
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.FontData.SizeInPoints = 14
        e.DefaultLogicalPageLayoutInfo.PageHeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center

        e.DefaultLogicalPageLayoutInfo.PageFooter = "Printed on " & Now & vbTab & "Page <#> of <##>"
        e.DefaultLogicalPageLayoutInfo.PageFooterHeight = 20
        e.DefaultLogicalPageLayoutInfo.PageFooterAppearance.TextHAlign = Infragistics.Win.HAlign.Right
    End Sub
    Private Sub ugReady_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles ug_PaintStatus_DoorLists.InitializeRow
        If e.Row.Band.Layout.IsPrintLayout Or e.Row.Band.Layout.IsExportLayout Then
            'since the ultragrid doesn't carry the selected state of a row to the print or export you have to find the real row that is
            'being displayed to the user
            Dim realGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Me.ug_PaintStatus_DoorLists.GetRowFromPrintRow(e.Row)
            'hide the row that is being used for printing/exporting so it doesn't show up
            e.Row.Hidden = Not realGridRow.Selected
        End If
    End Sub
    Private Sub btnAddFilter_Click(sender As Object, e As EventArgs) Handles btnAddFilter.Click
        Dim FilterValidate As String
        FilterValidate = CheckFilters(False)

        If FilterValidate.ToLower = "valid" Then
            Dim gridname As String
            Dim gridschema As Infragistics.Win.UltraWinGrid.UltraGridDisplayLayout

            gridname = ug_PaintStatus_DoorLists.Name()
            gridschema = ug_PaintStatus_DoorLists.DisplayLayout

            Dim FilePath As String
            FilePath = KPGeneral.StartupPath.ToString & "\" & gridname & ".xml"

            gridschema.SaveAsXml(FilePath)

            Dim fsCabFile As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
            Dim bytCabData(fsCabFile.Length - 1) As Byte
            fsCabFile.Read(bytCabData, 0, bytCabData.Length)
            fsCabFile.Close()

            KPGeneral.WebRef_Local.usp_InsertPaintStatusFilter(txtFilterName.Text, txtFilterDescription.Text, KPGeneral.User.UserProfile("UserLoginName"), bytCabData)

            RefreshFilterList()
        Else
            MsgBox(FilterValidate, MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If


    End Sub
    Private Sub btnUpdateFilter_Click(sender As Object, e As EventArgs) Handles btnUpdateFilter.Click
        If ugFilters.ActiveRow.Index > -1 Then
            If ugFilters.ActiveRow.Cells("FilterCreatedBy").Text.ToLower = KPGeneral.User.UserProfile("UserLoginName").ToString.ToLower Then
                If MsgBox("Are you sure you wish to update this filter?", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.Yes Then
                    Dim FilterValidate As String
                    FilterValidate = CheckFilters(True)

                    If FilterValidate.ToLower = "valid" Then
                        Dim gridname As String
                        Dim gridschema As Infragistics.Win.UltraWinGrid.UltraGridDisplayLayout

                        gridname = ug_PaintStatus_DoorLists.Name()
                        gridschema = ug_PaintStatus_DoorLists.DisplayLayout

                        Dim FilePath As String
                        FilePath = KPGeneral.StartupPath.ToString & "\" & gridname & ".xml"

                        gridschema.SaveAsXml(FilePath)

                        Dim fsCabFile As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
                        Dim bytCabData(fsCabFile.Length - 1) As Byte
                        fsCabFile.Read(bytCabData, 0, bytCabData.Length)
                        fsCabFile.Close()

                        KPGeneral.WebRef_Local.usp_UpdatePaintStatusFilter(txtFilterName.Text, txtFilterDescription.Text, KPGeneral.User.UserProfile("UserLoginName"), bytCabData, ugFilters.ActiveRow.Cells("FilterID").Text)

                        RefreshFilterList()
                    Else
                        MsgBox(FilterValidate, MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                    End If
                End If

            Else
                MsgBox("You cannot update this filter.  Please speak to " & ugFilters.ActiveRow.Cells("FilterCreatedBy").Text & " to update it.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If


        End If
    End Sub
    Private Sub btnDeactivateFilter_Click(sender As Object, e As EventArgs) Handles btnDeactivateFilter.Click
        If ugFilters.ActiveRow.Index > -1 Then
            If ugFilters.ActiveRow.Cells("FilterCreatedBy").Text.ToLower = KPGeneral.User.UserProfile("UserLoginName").ToString.ToLower Then
                If MsgBox("Are you sure you wish to deactivate this filter?", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.Yes Then
                    KPGeneral.WebRef_Local.usp_DeactivatePaintStatusFilter(KPGeneral.User.UserProfile("UserLoginName"), ugFilters.ActiveRow.Cells("FilterID").Text)
                    RefreshFilterList()
                End If
            Else
                MsgBox("You cannot deactivate this filter.  Please speak to " & ugFilters.ActiveRow.Cells("FilterCreatedBy").Text & " to deactivate it.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If
    End Sub
    Function CheckFilters(ByVal Update As Boolean) As String
        If txtFilterName.Text.Length = 0 Then
            Return "You must have a filter name."
        End If

        If txtFilterDescription.Text.Length = 0 Then
            Return "You must have a filter description."
        End If

        If Update = False Then
            Dim x As Integer
            For x = 0 To ugFilters.Rows.Count - 1
                If ugFilters.Rows(x).Cells("FilterName").Text.ToLower.Trim = txtFilterName.Text.ToLower.Trim Then
                    Return "You must have a unique filter name."
                End If
            Next
        End If


        Return "Valid"
    End Function
    Private Sub RefreshFilterList()
        Dim ds As New DataSet

        If KPGeneral.User.IsAdmin Then
            ds = KPGeneral.WebRef_Local.usp_GetPaintStatusFilterAdmin
        Else
            ds = KPGeneral.WebRef_Local.usp_GetPaintStatusFilter
        End If

        ugFilters.DataSource = ds

        ugFilters.DisplayLayout.Bands(0).Columns("FilterID").Hidden = True
        ugFilters.DisplayLayout.Bands(0).Columns("FilterFile").Hidden = True

        ugFilters.DisplayLayout.Bands(0).Columns("FilterDescription").Width = 200
    End Sub
    Private Sub btnLoadFilter_Click(sender As Object, e As EventArgs) Handles btnLoadFilter.Click
        If ugFilters.ActiveRow.Index > -1 Then
            If IsDBNull(ugFilters.ActiveRow.Cells("FilterFile").Value) = False Then
                FilterLoaded = True

                LoadFilter(ugFilters, ugFilters.ActiveRow.Index)
            End If
        End If
    End Sub
    Private Sub LoadFilter(ByVal UGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal ARow As Integer)
        txtFilterName.Text = UGrid.Rows(ARow).Cells("FilterName").Text
        PrintFilter = UGrid.Rows(ARow).Cells("FilterName").Text
        txtFilterDescription.Text = UGrid.Rows(ARow).Cells("FilterDescription").Text

        Dim gridname As String
        Dim gridschema As Infragistics.Win.UltraWinGrid.UltraGridDisplayLayout

        gridname = ug_PaintStatus_DoorLists.Name()

        Dim FilePath As String
        FilePath = KPGeneral.StartupPath.ToString & "\" & gridname & ".xml"

        Dim ms() As Byte = UGrid.Rows(ARow).Cells("FilterFile").Value
        Dim stmBLOBData As New MemoryStream(ms)

        Dim PdfImage As New BinaryWriter(File.Create(FilePath))
        PdfImage.Write(ms)
        PdfImage.Close()

        ug_PaintStatus_DoorLists.DisplayLayout.LoadFromXml(FilePath)

        RefreshSummaryInfo()

        Dim x As Integer
        For x = 0 To ug_PaintStatus_DoorLists.Rows.FilterRow.Cells.Count - 1
            If IsDBNull(ug_PaintStatus_DoorLists.Rows.FilterRow.Cells(x).Value) = False Then
                If ug_PaintStatus_DoorLists.Rows.FilterRow.Cells(x).Value.ToString.ToLower.Contains("custom") Then
                    If ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).Columns(x).DataType.Name.ToLower.Contains("date") Then

                    End If
                End If
            End If

        Next


        ug_PaintStatus_DoorLists.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        ug_PaintStatus_DoorLists.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        ug_PaintStatus_DoorLists.DisplayLayout.Override.TipStyleHeader = TipStyle.Show
    End Sub
    Private Sub LoadFilterDefault(ByVal dsDefault As DataSet)
        txtFilterName.Text = "Default"
        PrintFilter = "Default"
        txtFilterDescription.Text = "Default"

        Dim gridname As String
        Dim gridschema As Infragistics.Win.UltraWinGrid.UltraGridDisplayLayout

        gridname = ug_PaintStatus_DoorLists.Name()

        Dim FilePath As String
        FilePath = KPGeneral.StartupPath.ToString & "\" & gridname & ".xml"

        Dim ms() As Byte = dsDefault.Tables(0).Rows(0)("FilterFile")
        Dim stmBLOBData As New MemoryStream(ms)

        Dim PdfImage As New BinaryWriter(File.Create(FilePath))
        PdfImage.Write(ms)
        PdfImage.Close()

        ug_PaintStatus_DoorLists.DisplayLayout.LoadFromXml(FilePath)

        RefreshSummaryInfo()

        'ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).Columns("ProdDef").Header.Caption = "OpenPDef"

        Dim x As Integer
        For x = 0 To ug_PaintStatus_DoorLists.Rows.FilterRow.Cells.Count - 1
            If IsDBNull(ug_PaintStatus_DoorLists.Rows.FilterRow.Cells(x).Value) = False Then
                If ug_PaintStatus_DoorLists.Rows.FilterRow.Cells(x).Value.ToString.ToLower.Contains("custom") Then
                    If ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).Columns(x).DataType.Name.ToLower.Contains("date") Then
                        Dim FDate, TDate As Date
                        If Now.Date.DayOfWeek = DayOfWeek.Monday Then
                            FDate = Now.Date.AddDays(-7)
                            TDate = Now.Date.AddDays(13)
                        ElseIf Now.Date.DayOfWeek = DayOfWeek.Tuesday Then
                            FDate = Now.Date.AddDays(-8)
                            TDate = Now.Date.AddDays(12)
                        ElseIf Now.Date.DayOfWeek = DayOfWeek.Wednesday Then
                            FDate = Now.Date.AddDays(-9)
                            TDate = Now.Date.AddDays(11)
                        ElseIf Now.Date.DayOfWeek = DayOfWeek.Thursday Then
                            FDate = Now.Date.AddDays(-10)
                            TDate = Now.Date.AddDays(10)
                        ElseIf Now.Date.DayOfWeek = DayOfWeek.Friday Then
                            FDate = Now.Date.AddDays(-11)
                            TDate = Now.Date.AddDays(9)
                        ElseIf Now.Date.DayOfWeek = DayOfWeek.Saturday Then
                            FDate = Now.Date.AddDays(-12)
                            TDate = Now.Date.AddDays(8)
                        End If

                        ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).ColumnFilters(x).FilterConditions.Clear()

                        Dim filter As New FilterCondition(FilterComparisionOperator.GreaterThanOrEqualTo, FDate)
                        ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).ColumnFilters(x).FilterConditions.Add(filter)

                        filter = New FilterCondition(FilterComparisionOperator.LessThanOrEqualTo, TDate)
                        ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).ColumnFilters(x).FilterConditions.Add(filter)

                        ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).ColumnFilters(x).LogicalOperator = FilterLogicalOperator.And
                    End If
                End If
            End If

        Next


        ug_PaintStatus_DoorLists.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        ug_PaintStatus_DoorLists.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
    End Sub
    Private Sub ugFilters_AfterRowActivate(sender As Object, e As EventArgs) Handles ugFilters.AfterRowActivate
        If ugFilters.ActiveRow.Index > -1 Then

        End If
    End Sub
    Private Sub btnColumnChooser_Click(sender As Object, e As EventArgs) Handles btnColumnChooser.Click
        ug_PaintStatus_DoorLists.ShowColumnChooser()
    End Sub
    Private Sub UltraGridFilterUIProvider1_BeforeMenuPopulate(sender As Object, e As Infragistics.Win.SupportDialogs.FilterUIProvider.BeforeMenuPopulateEventArgs) Handles UltraGridFilterUIProvider1.BeforeMenuPopulate
        e.MenuItems.Clear()

        If ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).Columns(e.ColumnFilter.Column.ToString).DataType.Name.ToLower.Contains("date") Then
            Dim MiscTool As New FilterButtonTool
            MiscTool.DisplayText = "Last/Current/Next"

            e.MenuItems.Add(MiscTool)
        End If


    End Sub
    Private Sub UltraGridFilterUIProvider1_ButtonToolClick(sender As Object, e As Infragistics.Win.SupportDialogs.FilterUIProvider.ButtonToolClickEventArgs) Handles UltraGridFilterUIProvider1.ButtonToolClick
        If ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).Columns(e.ColumnFilter.Column.ToString).DataType.Name.ToLower.Contains("date") Then
            If e.Tool.DisplayText = "Last/Current/Next" Then
                Dim FDate, TDate As Date
                If Now.Date.DayOfWeek = DayOfWeek.Monday Then
                    FDate = Now.Date.AddDays(-7)
                    TDate = Now.Date.AddDays(13)
                ElseIf Now.Date.DayOfWeek = DayOfWeek.Tuesday Then
                    FDate = Now.Date.AddDays(-8)
                    TDate = Now.Date.AddDays(12)
                ElseIf Now.Date.DayOfWeek = DayOfWeek.Wednesday Then
                    FDate = Now.Date.AddDays(-9)
                    TDate = Now.Date.AddDays(11)
                ElseIf Now.Date.DayOfWeek = DayOfWeek.Thursday Then
                    FDate = Now.Date.AddDays(-10)
                    TDate = Now.Date.AddDays(10)
                ElseIf Now.Date.DayOfWeek = DayOfWeek.Friday Then
                    FDate = Now.Date.AddDays(-11)
                    TDate = Now.Date.AddDays(9)
                ElseIf Now.Date.DayOfWeek = DayOfWeek.Saturday Then
                    FDate = Now.Date.AddDays(-12)
                    TDate = Now.Date.AddDays(8)
                End If

                ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).ColumnFilters(e.ColumnFilter.Column.ToString).FilterConditions.Clear()

                Dim filter As New FilterCondition(FilterComparisionOperator.GreaterThanOrEqualTo, FDate)
                ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).ColumnFilters(e.ColumnFilter.Column.ToString).FilterConditions.Add(filter)

                filter = New FilterCondition(FilterComparisionOperator.LessThanOrEqualTo, TDate)
                ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).ColumnFilters(e.ColumnFilter.Column.ToString).FilterConditions.Add(filter)

                ug_PaintStatus_DoorLists.DisplayLayout.Bands(0).ColumnFilters(e.ColumnFilter.Column.ToString).LogicalOperator = FilterLogicalOperator.And

                ug_PaintStatus_DoorLists.Rows.FilterRow.Cells(e.ColumnFilter.Column.ToString).Value = "Last/Current/Next"
            End If
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
    Private Sub ResizeMainGrid(ByVal IsZoom As Boolean)
        If IsZoom = True Then
            ug_PaintStatus_DoorLists.DisplayLayout.Appearance.FontData.SizeInPoints = ug_PaintStatus_DoorLists.DisplayLayout.Appearance.FontData.SizeInPoints + 5
        Else
            If (ug_PaintStatus_DoorLists.DisplayLayout.Appearance.FontData.SizeInPoints - 5) >= DefaultFontSize Then
                ug_PaintStatus_DoorLists.DisplayLayout.Appearance.FontData.SizeInPoints = ug_PaintStatus_DoorLists.DisplayLayout.Appearance.FontData.SizeInPoints - 5
            Else
                ug_PaintStatus_DoorLists.DisplayLayout.Appearance.FontData.SizeInPoints = DefaultFontSize
            End If
        End If

    End Sub
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        refreshLVReady()

        Dim dsDefault As New DataSet
        dsDefault = KPGeneral.WebRef_Local.usp_GetPaintStatusFilterDefault
        If dsDefault.Tables(0).Rows.Count > 0 Then
            If IsDBNull(dsDefault.Tables(0).Rows(0)("FilterFile")) = False Then
                LoadFilterDefault(dsDefault)
            End If
        End If
    End Sub
    Private Sub btnToggleSummary_Click(sender As Object, e As EventArgs) Handles btnToggleSummary.Click
        If GridSummary = False Then
            GridSummary = True
        Else
            GridSummary = False
        End If

        ShowGridSummary()
    End Sub
    Private Sub RefreshList()
        Dim gridschema As Infragistics.Win.UltraWinGrid.UltraGridDisplayLayout
        gridschema = ug_PaintStatus_DoorLists.DisplayLayout
        gridschema.SaveAsXml(KPGeneral.StartupPath.ToString & "\" & ug_PaintStatus_DoorLists.Name & ".xml")

        refreshLVReady()

        KPGeneral.RefreshGridFromLayout(ug_PaintStatus_DoorLists, Me.GetType.Name)

        ug_PaintStatus_DoorLists.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        ug_PaintStatus_DoorLists.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        ug_PaintStatus_DoorLists.DisplayLayout.Override.TipStyleHeader = TipStyle.Show
    End Sub
    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        Try
            With SaveFileDialog1
                Dim fname As String
                fname = "Paint Status.xls"
                .Reset()
                .FileName = fname
                .DefaultExt = "xls"
                .Filter = KPGeneral.ExcelFileFilter
                Select Case .ShowDialog
                    Case Windows.Forms.DialogResult.OK
                        ug_PaintStatus_DoorLists.Selected.Rows.AddRange(CType(ug_PaintStatus_DoorLists.Rows.All, UltraGridRow()))

                        Me.GExporter.Export(ug_PaintStatus_DoorLists, SaveFileDialog1.FileName)
                        KPGeneral.oFiles(SaveFileDialog1.FileName)

                        ug_PaintStatus_DoorLists.Selected.Rows.Clear()
                        ug_PaintStatus_DoorLists.ActiveRow = Nothing
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End With


        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub ViewDoorListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDoorListToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

        Try
            If ug_PaintStatus_DoorLists.Selected.Rows.Count > 0 Then
                Dim dsDoorList As New DataSet
                dsDoorList = KPGeneral.CreateDoorListXML(ug_PaintStatus_DoorLists.Selected.Rows(0).Cells("CSID").Text, Nothing, Nothing, -1, Nothing)

                Dim rptName As New RptNewDoorList
                rptName.SetDataSource(dsDoorList)
                Dim rpt As New RptViewer(1, rptName)

                rpt.ShowDialog()
            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ViewDoorStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDoorStatusToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

        Try
            If ug_PaintStatus_DoorLists.Selected.Rows.Count > 0 Then
                KPGeneral.ViewDoorStatusByCSID(ug_PaintStatus_DoorLists.Selected.Rows(0).Cells("CSID").Text)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem.Click
        If ug_PaintStatus_DoorLists.Selected.Rows.Count > 1 Then
            MessageBox.Show("Cannot Track Selection. Please Highlight just ONE item")
        ElseIf ug_PaintStatus_DoorLists.Selected.Rows.Count = 1 Then
            KPGeneral.ViewKitchenTrackerByCSID(ug_PaintStatus_DoorLists.Selected.Rows(0).Cells("CSID").Text)
        End If
    End Sub
    Private Sub ViewOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewOrderToolStripMenuItem.Click
        If ug_PaintStatus_DoorLists.ActiveRow.Index > -1 Then
            KPGeneral.ViewOrderByMasterNum(ug_PaintStatus_DoorLists.ActiveRow.Cells("MasterNum").Text, "Production Status - View Order", False)
        End If
    End Sub
    Private Sub RefreshSummaryInfo()
        Dim TotalDoors As Int32 = 0
        Dim TotalSQM As Double = 0
        Dim row As UltraGridRow

        For Each row In ug_PaintStatus_DoorLists.Rows.GetFilteredInNonGroupByRows
            If Not IsDBNull(row.Cells("DoorCount").Value) Then
                TotalDoors = TotalDoors + row.Cells("DoorCount").Value
            End If
            If Not IsDBNull(row.Cells("SQM").Value) Then
                TotalSQM = TotalSQM + row.Cells("SQM").Value
            End If
        Next

        lblShowing.Text = "Shown: " & ug_PaintStatus_DoorLists.Rows.FilteredInRowCount & " DL \ " & TotalDoors & " Doors \ " & Math.Round(TotalSQM, 2, MidpointRounding.AwayFromZero) & " SQM"
    End Sub
    Private Sub RefreshHighlightInfo()
        Dim TotalDoors As Int32 = 0
        Dim TotalSQM As Double = 0
        Dim row As UltraGridRow

        For Each row In ug_PaintStatus_DoorLists.Selected.Rows
            If Not IsDBNull(row.Cells("DoorCount").Value) Then
                TotalDoors = TotalDoors + row.Cells("DoorCount").Value
            End If
            If Not IsDBNull(row.Cells("SQM").Value) Then
                TotalSQM = TotalSQM + row.Cells("SQM").Value
            End If
        Next

        lblHighlight.Text = "Highlighted: " & ug_PaintStatus_DoorLists.Selected.Rows.Count & " DL \ " & TotalDoors & " Doors \ " & Math.Round(TotalSQM, 2, MidpointRounding.AwayFromZero) & " SQM"
    End Sub

    Private Sub ViewDoorListToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewDoorListToolStripMenuItem1.Click
        Me.Cursor = Cursors.WaitCursor

        Try
            If ug_PaintStatus_DoorLists.Selected.Rows.Count > 0 Then
                Dim dsDoorList As New DataSet
                dsDoorList = KPGeneral.CreateDoorListBySumID(ug_PaintStatus_DoorLists.Selected.Rows(0).Cells("SumID").Text)

                Dim rptName As New RptDoorsOnDemand_Summary_DoorList
                rptName.SetDataSource(dsDoorList)
                Dim rpt As New RptViewer(1, rptName)

                rpt.ShowDialog()
            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PrintDoorListsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintDoorListsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

        Try
            If ug_PaintStatus_DoorLists.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To ug_PaintStatus_DoorLists.Selected.Rows.Count - 1
                    Dim dsDoorList As New DataSet
                    dsDoorList = KPGeneral.CreateDoorListBySumID(ug_PaintStatus_DoorLists.Selected.Rows(x).Cells("SumID").Text)

                    Dim rptName As New RptDoorsOnDemand_Summary_DoorList
                    rptName.SetDataSource(dsDoorList)
                    rptName.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
                    rptName.Close()
                    rptName.Dispose()
                Next


            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

        Me.Cursor = Cursors.Default
    End Sub




    Private Sub ucPaintLines_TextChanged(sender As Object, e As EventArgs) Handles ucPaintLines.TextChanged
        If ucPaintLines.IsItemInList = True Then
            lblScheduleWorkCentre.Text = ScheduledWorkCenterBeginningText & ucPaintLines.Text
        Else
            lblScheduleWorkCentre.Text = ScheduledWorkCenterBeginningText
        End If

        RefreshScheduleGrids()
    End Sub
    Private Sub SelectDayOfWeek(ByVal DayNumber As Integer)
        ResetDayLabels()

        SelectedDayNumber = DayNumber

        Select Case DayNumber
            Case 0
                lblScheduleDate.Text = ScheduledDateBeginningText
            Case 1
                lblScheduleDate.Text = ScheduledDateBeginningText & Day1Date.Date.ToLongDateString
                lblDay1.Appearance.BackColor = Color.LightSkyBlue
                lblDay1.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 2
                lblScheduleDate.Text = ScheduledDateBeginningText & Day2Date.Date.ToLongDateString
                lblDay2.Appearance.BackColor = Color.LightSkyBlue
                lblDay2.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 3
                lblScheduleDate.Text = ScheduledDateBeginningText & Day3Date.Date.ToLongDateString
                lblDay3.Appearance.BackColor = Color.LightSkyBlue
                lblDay3.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 4
                lblScheduleDate.Text = ScheduledDateBeginningText & Day4Date.Date.ToLongDateString
                lblDay4.Appearance.BackColor = Color.LightSkyBlue
                lblDay4.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            Case 5
                lblScheduleDate.Text = ScheduledDateBeginningText & Day5Date.Date.ToLongDateString
                lblDay5.Appearance.BackColor = Color.LightSkyBlue
                lblDay5.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        End Select
    End Sub
    Private Sub lblDay1_Click(sender As Object, e As EventArgs) Handles lblDay1.Click
        SelectDayOfWeek(1)
    End Sub
    Private Sub lblDay2_Click(sender As Object, e As EventArgs) Handles lblDay2.Click
        SelectDayOfWeek(2)
    End Sub
    Private Sub lblDay3_Click(sender As Object, e As EventArgs) Handles lblDay3.Click
        SelectDayOfWeek(3)
    End Sub
    Private Sub lblDay4_Click(sender As Object, e As EventArgs) Handles lblDay4.Click
        SelectDayOfWeek(4)
    End Sub
    Private Sub lblDay5_Click(sender As Object, e As EventArgs) Handles lblDay5.Click
        SelectDayOfWeek(5)
    End Sub
    Private Sub ResetDayLabels()
        lblDay1.Appearance.ResetBackColor()
        lblDay1.Appearance.ResetThemedElementAlpha()
        lblDay2.Appearance.ResetBackColor()
        lblDay2.Appearance.ResetThemedElementAlpha()
        lblDay3.Appearance.ResetBackColor()
        lblDay3.Appearance.ResetThemedElementAlpha()
        lblDay4.Appearance.ResetBackColor()
        lblDay4.Appearance.ResetThemedElementAlpha()
        lblDay5.Appearance.ResetBackColor()
        lblDay5.Appearance.ResetThemedElementAlpha()

        lblScheduleDate.Text = ScheduledDateBeginningText
    End Sub
    Private Sub ProcessWeekOf()
        ResetDayLabels()

        Dim isMonday As Boolean = False

        Dim SDate As DateTime

        SDate = uccWeekOf.Text

        If SDate.DayOfWeek = DayOfWeek.Monday Then
            isMonday = True
        End If

        If isMonday = False Then
            Select Case SDate.DayOfWeek
                Case DayOfWeek.Tuesday
                    uccWeekOf.Text = SDate.Date.AddDays(-1)
                Case DayOfWeek.Wednesday
                    uccWeekOf.Text = SDate.Date.AddDays(-2)
                Case DayOfWeek.Thursday
                    uccWeekOf.Text = SDate.Date.AddDays(-3)
                Case DayOfWeek.Friday
                    uccWeekOf.Text = SDate.Date.AddDays(-4)
                Case DayOfWeek.Saturday
                    uccWeekOf.Text = SDate.Date.AddDays(-5)
                Case DayOfWeek.Sunday
                    uccWeekOf.Text = SDate.Date.AddDays(-6)
            End Select
        Else
            RefreshScheduleGrids()
        End If
    End Sub
    Private Sub uccWeekOf_TextChanged(sender As Object, e As EventArgs) Handles uccWeekOf.TextChanged
        ProcessWeekOf()
    End Sub
    Private Sub RefreshScheduleGrids()
        Dim SDate As DateTime
        SDate = uccWeekOf.Text

        Day1Date = SDate
        Day2Date = SDate.Date.AddDays(1)
        Day3Date = SDate.Date.AddDays(2)
        Day4Date = SDate.Date.AddDays(3)
        Day5Date = SDate.Date.AddDays(4)

        ug_PaintSchedule_Day1.DataSource = Nothing
        ug_PaintSchedule_Day2.DataSource = Nothing
        ug_PaintSchedule_Day3.DataSource = Nothing
        ug_PaintSchedule_Day4.DataSource = Nothing
        ug_PaintSchedule_Day5.DataSource = Nothing

        If ucPaintLines.IsItemInList = True Then
            RefreshSpecificDayGrid(Day1Date, ug_PaintSchedule_Day1)
            RefreshSpecificDayGrid(Day2Date, ug_PaintSchedule_Day2)
            RefreshSpecificDayGrid(Day3Date, ug_PaintSchedule_Day3)
            RefreshSpecificDayGrid(Day4Date, ug_PaintSchedule_Day4)
            RefreshSpecificDayGrid(Day5Date, ug_PaintSchedule_Day5)

            RefreshFromLayoutChooserByGrid(ug_PaintSchedule_Day1)
            RefreshFromLayoutChooserByGrid(ug_PaintSchedule_Day2)
            RefreshFromLayoutChooserByGrid(ug_PaintSchedule_Day3)
            RefreshFromLayoutChooserByGrid(ug_PaintSchedule_Day4)
            RefreshFromLayoutChooserByGrid(ug_PaintSchedule_Day5)
        End If

        lblDay1.Text = "Day 1: " & Day1Date.DayOfWeek.ToString & " - " & Day1Date.Date & " (" & GetSQMFromGrid(ug_PaintSchedule_Day1) & " SQM)"
        lblDay2.Text = "Day 2: " & Day2Date.DayOfWeek.ToString & " - " & Day2Date.Date & " (" & GetSQMFromGrid(ug_PaintSchedule_Day2) & " SQM)"
        lblDay3.Text = "Day 3: " & Day3Date.DayOfWeek.ToString & " - " & Day3Date.Date & " (" & GetSQMFromGrid(ug_PaintSchedule_Day3) & " SQM)"
        lblDay4.Text = "Day 4: " & Day4Date.DayOfWeek.ToString & " - " & Day4Date.Date & " (" & GetSQMFromGrid(ug_PaintSchedule_Day4) & " SQM)"
        lblDay5.Text = "Day 5: " & Day5Date.DayOfWeek.ToString & " - " & Day5Date.Date & " (" & GetSQMFromGrid(ug_PaintSchedule_Day5) & " SQM)"
    End Sub
    Private Sub RefreshSpecificDayGrid(ByVal ScheduleDate As DateTime, ByVal uGrid As UltraGrid)
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.spKPFactory_PaintStatus_ScheduledColoursByLineAndDate(ucPaintLines.Value, ScheduleDate)

        uGrid.DataSource = ds
    End Sub
    Function GetSQMFromGrid(ByVal uGrid As UltraGrid) As Double
        Dim x As Integer

        Dim TotalSQM As Double

        For x = 0 To uGrid.Rows.Count - 1
            If Not IsDBNull(uGrid.Rows(x).Cells("SQM").Value) Then
                TotalSQM = TotalSQM + uGrid.Rows(x).Cells("SQM").Value
            End If
        Next

        Return TotalSQM
    End Function
    Private Sub btnRefreshScheduleDates_Click(sender As Object, e As EventArgs) Handles btnRefreshScheduleDates.Click
        RefreshScheduleGrids()

        KPGeneral.ClearGridRowSelections(ug_PaintSchedule_Day1)
        KPGeneral.ClearGridRowSelections(ug_PaintSchedule_Day2)
        KPGeneral.ClearGridRowSelections(ug_PaintSchedule_Day3)
        KPGeneral.ClearGridRowSelections(ug_PaintSchedule_Day4)
        KPGeneral.ClearGridRowSelections(ug_PaintSchedule_Day5)
    End Sub
    Private Sub btnAddToSchedule_Click(sender As Object, e As EventArgs) Handles btnAddToSchedule.Click
        If SelectedDayNumber > 0 Then
            If ucPaintLines.IsItemInList = True Then
                If ug_PaintStatus_DoorLists.Selected.Rows.Count > 0 Then
                    Dim ErrorCount As Integer = 0

                    Dim x As Integer
                    For x = 0 To ug_PaintStatus_DoorLists.Selected.Rows.Count - 1
                        Dim PaintScheduleID As Integer

                        Dim ScheduledDate As DateTime

                        Select Case SelectedDayNumber
                            Case 1
                                ScheduledDate = Day1Date
                            Case 2
                                ScheduledDate = Day2Date
                            Case 3
                                ScheduledDate = Day3Date
                            Case 4
                                ScheduledDate = Day4Date
                            Case 5
                                ScheduledDate = Day5Date
                        End Select

                        PaintScheduleID = KPGeneral.WebRef_Local.spKPFactory_PaintStatus_AddDoorSummaryToSchedule(ug_PaintStatus_DoorLists.Selected.Rows(x).Cells("SumID").Text,
                                                                                                                  ug_PaintStatus_DoorLists.Selected.Rows(x).Cells("Colour").Text,
                                                                                                                  ucPaintLines.Value, ScheduledDate, KPGeneral.User.UserProfile("UserLoginName"))

                        If PaintScheduleID > 0 Then
                            ug_PaintStatus_DoorLists.Selected.Rows(x).Cells("PaintScheduleID").Value = PaintScheduleID
                            ug_PaintStatus_DoorLists.Selected.Rows(x).Cells("PaintScheduleDate").Value = ScheduledDate.Date
                            ug_PaintStatus_DoorLists.Selected.Rows(x).Cells("WorkCentre").Value = ucPaintLines.Text
                        Else
                            ErrorCount = ErrorCount + 1
                        End If

                    Next

                    If ErrorCount > 0 Then
                        MsgBox("There was an issue putting some of the selected colours into the specific date.  Please review the PaintScheduleID/PaintScheduleDate columns to verify which ones had issues.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                    Else
                        MsgBox("All selected entered successfully.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                    End If

                    RefreshScheduleGrids()
                Else
                    MsgBox("Please select valid door lists to add to the schedule.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                End If
            Else
                MsgBox("Please select a valid work centre to schedule to.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        Else
            MsgBox("Please select a valid day of the week to schedule on.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
    End Sub
    Private Sub ColumnChooserByGrid(ByVal uGrid As UltraGrid)
        KPGeneral.ColumnChooser(uGrid, Me.GetType.Name)
    End Sub
    Private Sub RefreshFromLayoutChooserByGrid(ByVal uGrid As UltraGrid)
        KPGeneral.RefreshGridFromLayout(uGrid, Me.GetType.Name)
    End Sub

#Region " Schedule Menu Clicks "
    Private Sub ColumnChooserToolStripMenuItem_Day1_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem_Day1.Click
        ColumnChooserByGrid(ug_PaintSchedule_Day1)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem_Day2_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem_Day2.Click
        ColumnChooserByGrid(ug_PaintSchedule_Day2)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem_Day3_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem_Day3.Click
        ColumnChooserByGrid(ug_PaintSchedule_Day3)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem_Day4_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem_Day4.Click
        ColumnChooserByGrid(ug_PaintSchedule_Day4)
    End Sub
    Private Sub ColumnChooserToolStripMenuItem_Day5_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem_Day5.Click
        ColumnChooserByGrid(ug_PaintSchedule_Day5)
    End Sub
    Private Sub RemoveFromScheduleToolStripMenuItem_Day1_Click(sender As Object, e As EventArgs) Handles RemoveFromScheduleToolStripMenuItem_Day1.Click
        RemoveFromScheduleByGrid(ug_PaintSchedule_Day1)
    End Sub
    Private Sub RemoveFromScheduleToolStripMenuItem_Day2_Click(sender As Object, e As EventArgs) Handles RemoveFromScheduleToolStripMenuItem_Day2.Click
        RemoveFromScheduleByGrid(ug_PaintSchedule_Day2)
    End Sub
    Private Sub RemoveFromScheduleToolStripMenuItem_Day3_Click(sender As Object, e As EventArgs) Handles RemoveFromScheduleToolStripMenuItem_Day3.Click
        RemoveFromScheduleByGrid(ug_PaintSchedule_Day3)
    End Sub
    Private Sub RemoveFromScheduleToolStripMenuItem_Day4_Click(sender As Object, e As EventArgs) Handles RemoveFromScheduleToolStripMenuItem_Day4.Click
        RemoveFromScheduleByGrid(ug_PaintSchedule_Day4)
    End Sub
    Private Sub RemoveFromScheduleToolStripMenuItem_Day5_Click(sender As Object, e As EventArgs) Handles RemoveFromScheduleToolStripMenuItem_Day5.Click
        RemoveFromScheduleByGrid(ug_PaintSchedule_Day5)
    End Sub
    Private Sub MovePreviousDayToolStripMenuItem_Day1_Click(sender As Object, e As EventArgs) Handles MovePreviousDayToolStripMenuItem_Day1.Click
        MoveDateByGrid(ug_PaintSchedule_Day1, False, True)
    End Sub
    Private Sub MovePreviousDayToolStripMenuItem_Day2_Click(sender As Object, e As EventArgs) Handles MovePreviousDayToolStripMenuItem_Day2.Click
        MoveDateByGrid(ug_PaintSchedule_Day2, False, False)
    End Sub
    Private Sub MovePreviousDayToolStripMenuItem_Day3_Click(sender As Object, e As EventArgs) Handles MovePreviousDayToolStripMenuItem_Day3.Click
        MoveDateByGrid(ug_PaintSchedule_Day3, False, False)
    End Sub
    Private Sub MovePreviousDayToolStripMenuItem_Day4_Click(sender As Object, e As EventArgs) Handles MovePreviousDayToolStripMenuItem_Day4.Click
        MoveDateByGrid(ug_PaintSchedule_Day4, False, False)
    End Sub
    Private Sub MovePreviousDayToolStripMenuItem_Day5_Click(sender As Object, e As EventArgs) Handles MovePreviousDayToolStripMenuItem_Day5.Click
        MoveDateByGrid(ug_PaintSchedule_Day5, False, False)
    End Sub
    Private Sub MoveNextDayToolStripMenuItem_Day1_Click(sender As Object, e As EventArgs) Handles MoveNextDayToolStripMenuItem_Day1.Click
        MoveDateByGrid(ug_PaintSchedule_Day1, True, False)
    End Sub
    Private Sub MoveNextDayToolStripMenuItem_Day2_Click(sender As Object, e As EventArgs) Handles MoveNextDayToolStripMenuItem_Day2.Click
        MoveDateByGrid(ug_PaintSchedule_Day2, True, False)
    End Sub
    Private Sub MoveNextDayToolStripMenuItem_Day3_Click(sender As Object, e As EventArgs) Handles MoveNextDayToolStripMenuItem_Day3.Click
        MoveDateByGrid(ug_PaintSchedule_Day3, True, False)
    End Sub
    Private Sub MoveNextDayToolStripMenuItem_Day4_Click(sender As Object, e As EventArgs) Handles MoveNextDayToolStripMenuItem_Day4.Click
        MoveDateByGrid(ug_PaintSchedule_Day4, True, False)
    End Sub
    Private Sub MoveNextDayToolStripMenuItem_Day5_Click(sender As Object, e As EventArgs) Handles MoveNextDayToolStripMenuItem_Day5.Click
        MoveDateByGrid(ug_PaintSchedule_Day5, True, True)
    End Sub
    Private Sub ViewOrdersToolStripMenuItem_Day1_Click(sender As Object, e As EventArgs) Handles ViewOrdersToolStripMenuItem_Day1.Click
        ViewOrdersByGrid(ug_PaintSchedule_Day1)
    End Sub
    Private Sub ViewOrdersToolStripMenuItem_Day2_Click(sender As Object, e As EventArgs) Handles ViewOrdersToolStripMenuItem_Day2.Click
        ViewOrdersByGrid(ug_PaintSchedule_Day2)
    End Sub
    Private Sub ViewOrdersToolStripMenuItem_Day3_Click(sender As Object, e As EventArgs) Handles ViewOrdersToolStripMenuItem_Day3.Click
        ViewOrdersByGrid(ug_PaintSchedule_Day3)
    End Sub
    Private Sub ViewOrdersToolStripMenuItem_Day4_Click(sender As Object, e As EventArgs) Handles ViewOrdersToolStripMenuItem_Day4.Click
        ViewOrdersByGrid(ug_PaintSchedule_Day4)
    End Sub
    Private Sub ViewOrdersToolStripMenuItem_Day5_Click(sender As Object, e As EventArgs) Handles ViewOrdersToolStripMenuItem_Day5.Click
        ViewOrdersByGrid(ug_PaintSchedule_Day5)
    End Sub
    Private Sub MoveUpToolStripMenuItem_Day1_Click(sender As Object, e As EventArgs) Handles MoveUpToolStripMenuItem_Day1.Click
        ChangeOrderByGrid(ug_PaintSchedule_Day1, True)
    End Sub
    Private Sub MoveUpToolStripMenuItem_Day2_Click(sender As Object, e As EventArgs) Handles MoveUpToolStripMenuItem_Day2.Click
        ChangeOrderByGrid(ug_PaintSchedule_Day2, True)
    End Sub
    Private Sub MoveUpToolStripMenuItem_Day3_Click(sender As Object, e As EventArgs) Handles MoveUpToolStripMenuItem_Day3.Click
        ChangeOrderByGrid(ug_PaintSchedule_Day3, True)
    End Sub
    Private Sub MoveUpToolStripMenuItem_Day4_Click(sender As Object, e As EventArgs) Handles MoveUpToolStripMenuItem_Day4.Click
        ChangeOrderByGrid(ug_PaintSchedule_Day4, True)
    End Sub
    Private Sub MoveUpToolStripMenuItem_Day5_Click(sender As Object, e As EventArgs) Handles MoveUpToolStripMenuItem_Day5.Click
        ChangeOrderByGrid(ug_PaintSchedule_Day5, True)
    End Sub
    Private Sub MoveDownToolStripMenuItem_Day1_Click(sender As Object, e As EventArgs) Handles MoveDownToolStripMenuItem_Day1.Click
        ChangeOrderByGrid(ug_PaintSchedule_Day1, False)
    End Sub
    Private Sub MoveDownToolStripMenuItem_Day2_Click(sender As Object, e As EventArgs) Handles MoveDownToolStripMenuItem_Day2.Click
        ChangeOrderByGrid(ug_PaintSchedule_Day2, False)
    End Sub
    Private Sub MoveDownToolStripMenuItem_Day3_Click(sender As Object, e As EventArgs) Handles MoveDownToolStripMenuItem_Day3.Click
        ChangeOrderByGrid(ug_PaintSchedule_Day3, False)
    End Sub
    Private Sub MoveDownToolStripMenuItem_Day4_Click(sender As Object, e As EventArgs) Handles MoveDownToolStripMenuItem_Day4.Click
        ChangeOrderByGrid(ug_PaintSchedule_Day4, False)
    End Sub
    Private Sub MoveDownToolStripMenuItem_Day5_Click(sender As Object, e As EventArgs) Handles MoveDownToolStripMenuItem_Day5.Click
        ChangeOrderByGrid(ug_PaintSchedule_Day5, False)
    End Sub
#End Region

    Private Sub RemoveFromScheduleByGrid(ByVal uGrid As UltraGrid)
        If uGrid.Selected.Rows.Count > 0 Then
            If MsgBox("Are you sure you wish to remove the selected colours from the schedule?  This will also refresh the orders grid.", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.Yes Then
                Dim x As Integer
                For x = 0 To uGrid.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_PaintStatus_RemoveFromScheduleByPaintScheduleID(uGrid.Selected.Rows(x).Cells("PaintScheduleID").Text, KPGeneral.User.UserProfile("UserLoginName"))
                Next

                RefreshScheduleGrids()

                RefreshWithFilter()
            End If
        End If
    End Sub
    Private Sub MoveDateByGrid(ByVal uGrid As UltraGrid, ByVal isMoveNext As Boolean, ByVal IncludeOtherWarning As Boolean)
        If uGrid.Selected.Rows.Count > 0 Then
            Dim MessageStart As String = "Are you sure you wish to move the selected orders"

            Dim MessageMiddle, MessageEnd As String

            If isMoveNext = True Then
                MessageMiddle = " forward to the next weekday?  This will also refresh the orders grid."
            Else
                MessageMiddle = " back to the previous weekday?  This will also refresh the orders grid."
            End If

            If IncludeOtherWarning = True Then
                If isMoveNext = True Then
                    MessageEnd = "  Please note, this will move the selected orders to the Monday of the following week!"
                Else
                    MessageEnd = "  Please note, this will move the selected orders to the Friday of the previous week!"
                End If
            Else
                MessageEnd = ""
            End If

            Dim FinalMessage As String = MessageStart & MessageMiddle & MessageEnd

            If MsgBox(FinalMessage, MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.Yes Then
                Dim x As Integer
                For x = 0 To uGrid.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_PaintStatus_MoveScheduleDateByPaintScheduleID(uGrid.Selected.Rows(x).Cells("PaintScheduleID").Text, KPGeneral.User.UserProfile("UserLoginName"), isMoveNext)
                Next

                RefreshScheduleGrids()

                RefreshWithFilter()
            End If
        End If
    End Sub
    Private Sub ViewOrdersByGrid(ByVal uGrid As UltraGrid)
        If uGrid.ActiveRow.Index > -1 Then
            frmSiteRequestChangeLog.CSID = uGrid.ActiveRow.Cells("PaintScheduleID").Text
            frmSiteRequestChangeLog.FormText = "Paint Status Scheduled Orders"
            frmSiteRequestChangeLog.ShowDialog()
        End If
    End Sub
    Private Sub ChangeOrderByGrid(ByVal uGrid As UltraGrid, ByVal isMoveUp As Boolean)
        Dim SelectedRows As Integer = uGrid.Selected.Rows.Count

        If SelectedRows = 1 Then

        ElseIf SelectedRows > 1 Then
            MsgBox("You must select a single row only before trying to change the order.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        ElseIf SelectedRows = 0 Then
            MsgBox("You must select a single row before trying to change the order.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        End If
        If uGrid.Selected.Rows.Count > 0 Then
            Dim PaintScheduleID As Integer = uGrid.ActiveRow.Cells("PaintScheduleID").Text

            KPGeneral.WebRef_Local.spKPFactory_PaintStatus_MoveScheduleOrderByPaintScheduleID(PaintScheduleID, KPGeneral.User.UserProfile("UserLoginName"), isMoveUp)

            RefreshScheduleGrids()

            Dim x As Integer
            For x = 0 To uGrid.Rows.Count - 1
                If uGrid.Rows(x).Cells("PaintScheduleID").Text = PaintScheduleID Then
                    uGrid.Rows(x).Selected = True
                    uGrid.Rows(x).Activate()
                End If
            Next
        End If
    End Sub
    Private Sub btnClearSelected_Click(sender As Object, e As EventArgs) Handles btnClearSelected.Click
        KPGeneral.ClearGridRowSelections(ug_PaintSchedule_Day1)
        KPGeneral.ClearGridRowSelections(ug_PaintSchedule_Day2)
        KPGeneral.ClearGridRowSelections(ug_PaintSchedule_Day3)
        KPGeneral.ClearGridRowSelections(ug_PaintSchedule_Day4)
        KPGeneral.ClearGridRowSelections(ug_PaintSchedule_Day5)
    End Sub
End Class


