Imports System.Net.Mail
Imports System.Drawing.Drawing2D
Imports Infragistics.Win.UltraWinGrid

Public Class frmAssemblyStart
    Inherits System.Windows.Forms.Form
    Private lvwColumnSorter1 As ListViewColumnSorter
    Friend WithEvents PrintCabinetLabelsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintCabinetLabelsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetAsTandemboxOrderdToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPantries As ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ColumnChooserToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SetPlannedDateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearPlannedDateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KitchenTrackerToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents PrintWhiteCopiesForPantryAssemblerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Dim dsSelectedOrders As New DataSet
    Public Shared CabinetDataset As New DataSet
    Dim PreviousLayout As New DataSet
    Dim PageNumber As Integer
    Dim CurrentCSID As Integer
    Friend WithEvents mnu_WeeklyLayouts_Doors As ContextMenuStrip
    Friend WithEvents mnu_WeeklyLayouts_Cabinets As ContextMenuStrip
    Friend WithEvents mnu_WeeklyLayouts_Accessories As ContextMenuStrip
    Friend WithEvents mnu_WeeklyLayouts_ChangeOrder As ContextMenuStrip
    Friend WithEvents mnu_WeeklyLayouts_LotList As ContextMenuStrip
    Friend WithEvents ColumnChooserToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents ColumnChooserToolStripMenuItem6 As ToolStripMenuItem
    Friend WithEvents UpdateFlagTypeToolStripMenuItem As ToolStripMenuItem
    Dim FirstLoaded As Boolean
    Public Shared FlagTypeID As Integer
    Public Shared FlagTypeName As String
    Friend WithEvents StartAssemblyForSelectedOrdersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents upServiceCabinets As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents upMainPanel As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents upWeeklyLayouts As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblAssemblyPartsOrderedOn As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnSetAssemblyPartsOrdered As Infragistics.Win.Misc.UltraButton
    Friend WithEvents uccWeeklyLayoutSiteRequest As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ug_AssemblyStart_AdvancedSearchLotList As UltraGrid
    Friend WithEvents btn_WeeklyLayouts_ColumnChooser As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblTotalRows As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents ugPantries As UltraGrid
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnViewTodayReport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lvOrders As UltraGrid
    Friend WithEvents Label19 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCount As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnPrintClampInfo7 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnPrintClampInfo6 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnPrintClampInfo5 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnPrintClampInfo4 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnPrintClampInfo3 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnPrintClampInfo2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnPrintClampInfo1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnViewClampDetail7 As Button
    Friend WithEvents btnViewClampDetail6 As Button
    Friend WithEvents btnViewClampDetail5 As Button
    Friend WithEvents btnViewClampDetail4 As Button
    Friend WithEvents btnViewClampDetail3 As Button
    Friend WithEvents btnViewClampDetail2 As Button
    Friend WithEvents btnViewClampDetail1 As Button
    Friend WithEvents lblClampDetail7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblClampDetail6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblClampDetail5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblClampDetail4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblClampDetail3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblClampDetail2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblClampDetail1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMax7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMax6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMax5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMax4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMax3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMax2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMax1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMinRem7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMinRem6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMinRem5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMinRem4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMinRem3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMinRem2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMinRem1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnClamp7 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnClamp6 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnClamp5 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnClamp4 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnClamp3 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnClamp2 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnClamp1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnManageClampHours As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnManageClamps As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents lblSelectedAPT_Top As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents lblSelectedOrders_Top As Label
    Friend WithEvents lblSelectedDoors_Top As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents upContainer As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents upUpperGrid As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents ugAssemblyStart As UltraGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents BtnRefresh As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents mniColumnChooser As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btManageAssemblersAndClamps As Infragistics.Win.Misc.UltraButton
    Friend WithEvents tsColomnChooser As ToolStripMenuItem
    Friend WithEvents btnPrintClampInfo8 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnViewClampDetail8 As Button
    Friend WithEvents lblClampDetail8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMax8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMinRem8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnClamp8 As Infragistics.Win.Misc.UltraButton
    Dim HasServiceOrders As Boolean = False
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        lvwColumnSorter1 = New ListViewColumnSorter

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripLV As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AssignLineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripLine As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AssignLine1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine5ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine6ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine7ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine8ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGridFilterUIProvider1 As Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ColumnChooserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine1ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine3ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine5ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine1ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine2ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine3ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine4ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine5ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine6ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine7ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignLine8ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintWhiteCopiesForPickersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPinkCopiesForDoorPickHingeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintTandemboxPagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintWhiteCopiesForPickersToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintPinkCopiesForDoorPickHingeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintTandemboxPagesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SetPlannedStartDateToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetFiltersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddSelectedToBottomGridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveFromAssemblyStartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KitchenTrackerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KitchenTrackerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssemblyStart))
        Me.mnu_WeeklyLayouts_Doors = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColumnChooserToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_WeeklyLayouts_Cabinets = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColumnChooserToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateFlagTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_WeeklyLayouts_Accessories = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColumnChooserToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AssignLine1ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine2ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine3ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine4ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine5ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine6ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine7ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine8ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddSelectedToBottomGridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintWhiteCopiesForPickersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPinkCopiesForDoorPickHingeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintTandemboxPagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintCabinetLabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.StartAssemblyForSelectedOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnChooserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetFiltersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFromAssemblyStartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KitchenTrackerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenuStripLine = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AssignLine1ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine3ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine5ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine5ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine6ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine7ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignLine8ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetPlannedStartDateToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintWhiteCopiesForPickersToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintPinkCopiesForDoorPickHingeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintTandemboxPagesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintCabinetLabelsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.KitchenTrackerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetAsTandemboxOrderdToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mniColumnChooser = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.UltraGridFilterUIProvider1 = New Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider(Me.components)
        Me.mnuPantries = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KitchenTrackerToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintWhiteCopiesForPantryAssemblerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsColomnChooser = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_WeeklyLayouts_LotList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColumnChooserToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColumnChooserToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetPlannedDateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearPlannedDateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_WeeklyLayouts_ChangeOrder = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColumnChooserToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripLV = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AssignLineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.upServiceCabinets = New Infragistics.Win.Misc.UltraPanel()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.upMainPanel = New Infragistics.Win.Misc.UltraPanel()
        Me.upWeeklyLayouts = New Infragistics.Win.Misc.UltraPanel()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.lblAssemblyPartsOrderedOn = New Infragistics.Win.Misc.UltraLabel()
        Me.btnSetAssemblyPartsOrdered = New Infragistics.Win.Misc.UltraButton()
        Me.uccWeeklyLayoutSiteRequest = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.ug_AssemblyStart_AdvancedSearchLotList = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btn_WeeklyLayouts_ColumnChooser = New Infragistics.Win.Misc.UltraButton()
        Me.lblTotalRows = New Infragistics.Win.Misc.UltraLabel()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.ugPantries = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnViewTodayReport = New Infragistics.Win.Misc.UltraButton()
        Me.lvOrders = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCount = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnPrintClampInfo8 = New Infragistics.Win.Misc.UltraButton()
        Me.btnViewClampDetail8 = New System.Windows.Forms.Button()
        Me.lblClampDetail8 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMax8 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMinRem8 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnClamp8 = New Infragistics.Win.Misc.UltraButton()
        Me.btManageAssemblersAndClamps = New Infragistics.Win.Misc.UltraButton()
        Me.btnPrintClampInfo7 = New Infragistics.Win.Misc.UltraButton()
        Me.btnPrintClampInfo6 = New Infragistics.Win.Misc.UltraButton()
        Me.btnPrintClampInfo5 = New Infragistics.Win.Misc.UltraButton()
        Me.btnPrintClampInfo4 = New Infragistics.Win.Misc.UltraButton()
        Me.btnPrintClampInfo3 = New Infragistics.Win.Misc.UltraButton()
        Me.btnPrintClampInfo2 = New Infragistics.Win.Misc.UltraButton()
        Me.btnPrintClampInfo1 = New Infragistics.Win.Misc.UltraButton()
        Me.btnViewClampDetail7 = New System.Windows.Forms.Button()
        Me.btnViewClampDetail6 = New System.Windows.Forms.Button()
        Me.btnViewClampDetail5 = New System.Windows.Forms.Button()
        Me.btnViewClampDetail4 = New System.Windows.Forms.Button()
        Me.btnViewClampDetail3 = New System.Windows.Forms.Button()
        Me.btnViewClampDetail2 = New System.Windows.Forms.Button()
        Me.btnViewClampDetail1 = New System.Windows.Forms.Button()
        Me.lblClampDetail7 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblClampDetail6 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblClampDetail5 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblClampDetail4 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblClampDetail3 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblClampDetail2 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblClampDetail1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMax7 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMax6 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMax5 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMax4 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMax3 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMax2 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMax1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMinRem7 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMinRem6 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMinRem5 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMinRem4 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMinRem3 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMinRem2 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMinRem1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnClamp7 = New Infragistics.Win.Misc.UltraButton()
        Me.btnClamp6 = New Infragistics.Win.Misc.UltraButton()
        Me.btnClamp5 = New Infragistics.Win.Misc.UltraButton()
        Me.btnClamp4 = New Infragistics.Win.Misc.UltraButton()
        Me.btnClamp3 = New Infragistics.Win.Misc.UltraButton()
        Me.btnClamp2 = New Infragistics.Win.Misc.UltraButton()
        Me.btnClamp1 = New Infragistics.Win.Misc.UltraButton()
        Me.btnManageClampHours = New Infragistics.Win.Misc.UltraButton()
        Me.btnManageClamps = New Infragistics.Win.Misc.UltraButton()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSelectedAPT_Top = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblSelectedOrders_Top = New System.Windows.Forms.Label()
        Me.lblSelectedDoors_Top = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.upContainer = New Infragistics.Win.Misc.UltraPanel()
        Me.upUpperGrid = New Infragistics.Win.Misc.UltraPanel()
        Me.ugAssemblyStart = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.mnu_WeeklyLayouts_Doors.SuspendLayout()
        Me.mnu_WeeklyLayouts_Cabinets.SuspendLayout()
        Me.mnu_WeeklyLayouts_Accessories.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStripLine.SuspendLayout()
        Me.mnuPantries.SuspendLayout()
        Me.mnu_WeeklyLayouts_LotList.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.mnu_WeeklyLayouts_ChangeOrder.SuspendLayout()
        Me.ContextMenuStripLV.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.upServiceCabinets.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.upMainPanel.ClientArea.SuspendLayout()
        Me.upMainPanel.SuspendLayout()
        Me.upWeeklyLayouts.ClientArea.SuspendLayout()
        Me.upWeeklyLayouts.SuspendLayout()
        CType(Me.uccWeeklyLayoutSiteRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ug_AssemblyStart_AdvancedSearchLotList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.ugPantries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.lvOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        Me.upContainer.ClientArea.SuspendLayout()
        Me.upContainer.SuspendLayout()
        Me.upUpperGrid.ClientArea.SuspendLayout()
        Me.upUpperGrid.SuspendLayout()
        CType(Me.ugAssemblyStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnu_WeeklyLayouts_Doors
        '
        Me.mnu_WeeklyLayouts_Doors.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnu_WeeklyLayouts_Doors.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColumnChooserToolStripMenuItem4})
        Me.mnu_WeeklyLayouts_Doors.Name = "ContextMenuStrip3"
        Me.mnu_WeeklyLayouts_Doors.Size = New System.Drawing.Size(165, 26)
        '
        'ColumnChooserToolStripMenuItem4
        '
        Me.ColumnChooserToolStripMenuItem4.Name = "ColumnChooserToolStripMenuItem4"
        Me.ColumnChooserToolStripMenuItem4.Size = New System.Drawing.Size(164, 22)
        Me.ColumnChooserToolStripMenuItem4.Text = "Column Chooser"
        '
        'mnu_WeeklyLayouts_Cabinets
        '
        Me.mnu_WeeklyLayouts_Cabinets.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnu_WeeklyLayouts_Cabinets.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColumnChooserToolStripMenuItem3, Me.UpdateFlagTypeToolStripMenuItem})
        Me.mnu_WeeklyLayouts_Cabinets.Name = "mnu_WeeklyLayouts_Cabinets"
        Me.mnu_WeeklyLayouts_Cabinets.Size = New System.Drawing.Size(165, 48)
        '
        'ColumnChooserToolStripMenuItem3
        '
        Me.ColumnChooserToolStripMenuItem3.Name = "ColumnChooserToolStripMenuItem3"
        Me.ColumnChooserToolStripMenuItem3.Size = New System.Drawing.Size(164, 22)
        Me.ColumnChooserToolStripMenuItem3.Text = "Column Chooser"
        '
        'UpdateFlagTypeToolStripMenuItem
        '
        Me.UpdateFlagTypeToolStripMenuItem.Name = "UpdateFlagTypeToolStripMenuItem"
        Me.UpdateFlagTypeToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.UpdateFlagTypeToolStripMenuItem.Text = "Update Flag Type"
        '
        'mnu_WeeklyLayouts_Accessories
        '
        Me.mnu_WeeklyLayouts_Accessories.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnu_WeeklyLayouts_Accessories.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColumnChooserToolStripMenuItem5})
        Me.mnu_WeeklyLayouts_Accessories.Name = "ContextMenuStrip3"
        Me.mnu_WeeklyLayouts_Accessories.Size = New System.Drawing.Size(165, 26)
        '
        'ColumnChooserToolStripMenuItem5
        '
        Me.ColumnChooserToolStripMenuItem5.Name = "ColumnChooserToolStripMenuItem5"
        Me.ColumnChooserToolStripMenuItem5.Size = New System.Drawing.Size(164, 22)
        Me.ColumnChooserToolStripMenuItem5.Text = "Column Chooser"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssignLine1ToolStripMenuItem2, Me.ToolStripMenuItem1, Me.AssignLine2ToolStripMenuItem1, Me.AssignLine3ToolStripMenuItem2, Me.ToolStripMenuItem2, Me.AssignLine4ToolStripMenuItem1, Me.AssignLine5ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.AssignLine6ToolStripMenuItem1, Me.AssignLine7ToolStripMenuItem1, Me.AssignLine8ToolStripMenuItem1, Me.AddSelectedToBottomGridToolStripMenuItem, Me.ToolStripSeparator1, Me.PrintWhiteCopiesForPickersToolStripMenuItem, Me.PrintPinkCopiesForDoorPickHingeToolStripMenuItem, Me.PrintTandemboxPagesToolStripMenuItem, Me.PrintCabinetLabelsToolStripMenuItem, Me.ToolStripSeparator2, Me.StartAssemblyForSelectedOrdersToolStripMenuItem, Me.ColumnChooserToolStripMenuItem, Me.ResetFiltersToolStripMenuItem, Me.RemoveFromAssemblyStartToolStripMenuItem, Me.KitchenTrackerToolStripMenuItem, Me.ToolStripSeparator4, Me.SetToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(307, 506)
        '
        'AssignLine1ToolStripMenuItem2
        '
        Me.AssignLine1ToolStripMenuItem2.Name = "AssignLine1ToolStripMenuItem2"
        Me.AssignLine1ToolStripMenuItem2.Size = New System.Drawing.Size(306, 22)
        Me.AssignLine1ToolStripMenuItem2.Text = "Assign line 1"
        Me.AssignLine1ToolStripMenuItem2.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(306, 22)
        Me.ToolStripMenuItem1.Text = "Assign line 1+2"
        Me.ToolStripMenuItem1.Visible = False
        '
        'AssignLine2ToolStripMenuItem1
        '
        Me.AssignLine2ToolStripMenuItem1.Name = "AssignLine2ToolStripMenuItem1"
        Me.AssignLine2ToolStripMenuItem1.Size = New System.Drawing.Size(306, 22)
        Me.AssignLine2ToolStripMenuItem1.Text = "Assign line 2"
        Me.AssignLine2ToolStripMenuItem1.Visible = False
        '
        'AssignLine3ToolStripMenuItem2
        '
        Me.AssignLine3ToolStripMenuItem2.Name = "AssignLine3ToolStripMenuItem2"
        Me.AssignLine3ToolStripMenuItem2.Size = New System.Drawing.Size(306, 22)
        Me.AssignLine3ToolStripMenuItem2.Text = "Assign line 3"
        Me.AssignLine3ToolStripMenuItem2.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(306, 22)
        Me.ToolStripMenuItem2.Text = "Assign line 3+4"
        Me.ToolStripMenuItem2.Visible = False
        '
        'AssignLine4ToolStripMenuItem1
        '
        Me.AssignLine4ToolStripMenuItem1.Name = "AssignLine4ToolStripMenuItem1"
        Me.AssignLine4ToolStripMenuItem1.Size = New System.Drawing.Size(306, 22)
        Me.AssignLine4ToolStripMenuItem1.Text = "Assign line 4"
        Me.AssignLine4ToolStripMenuItem1.Visible = False
        '
        'AssignLine5ToolStripMenuItem2
        '
        Me.AssignLine5ToolStripMenuItem2.Name = "AssignLine5ToolStripMenuItem2"
        Me.AssignLine5ToolStripMenuItem2.Size = New System.Drawing.Size(306, 22)
        Me.AssignLine5ToolStripMenuItem2.Text = "Assign line 5"
        Me.AssignLine5ToolStripMenuItem2.Visible = False
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(306, 22)
        Me.ToolStripMenuItem3.Text = "Assign line 5+6"
        Me.ToolStripMenuItem3.Visible = False
        '
        'AssignLine6ToolStripMenuItem1
        '
        Me.AssignLine6ToolStripMenuItem1.Name = "AssignLine6ToolStripMenuItem1"
        Me.AssignLine6ToolStripMenuItem1.Size = New System.Drawing.Size(306, 22)
        Me.AssignLine6ToolStripMenuItem1.Text = "Assign line 6"
        Me.AssignLine6ToolStripMenuItem1.Visible = False
        '
        'AssignLine7ToolStripMenuItem1
        '
        Me.AssignLine7ToolStripMenuItem1.Name = "AssignLine7ToolStripMenuItem1"
        Me.AssignLine7ToolStripMenuItem1.Size = New System.Drawing.Size(306, 22)
        Me.AssignLine7ToolStripMenuItem1.Text = "Assign line 7"
        Me.AssignLine7ToolStripMenuItem1.Visible = False
        '
        'AssignLine8ToolStripMenuItem1
        '
        Me.AssignLine8ToolStripMenuItem1.Name = "AssignLine8ToolStripMenuItem1"
        Me.AssignLine8ToolStripMenuItem1.Size = New System.Drawing.Size(306, 22)
        Me.AssignLine8ToolStripMenuItem1.Text = "Assign line 8"
        Me.AssignLine8ToolStripMenuItem1.Visible = False
        '
        'AddSelectedToBottomGridToolStripMenuItem
        '
        Me.AddSelectedToBottomGridToolStripMenuItem.Name = "AddSelectedToBottomGridToolStripMenuItem"
        Me.AddSelectedToBottomGridToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.AddSelectedToBottomGridToolStripMenuItem.Text = "Add Selected to Bottom Grid"
        Me.AddSelectedToBottomGridToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(303, 6)
        Me.ToolStripSeparator1.Visible = False
        '
        'PrintWhiteCopiesForPickersToolStripMenuItem
        '
        Me.PrintWhiteCopiesForPickersToolStripMenuItem.Name = "PrintWhiteCopiesForPickersToolStripMenuItem"
        Me.PrintWhiteCopiesForPickersToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.PrintWhiteCopiesForPickersToolStripMenuItem.Text = "Print White Copies for Pickers"
        Me.PrintWhiteCopiesForPickersToolStripMenuItem.Visible = False
        '
        'PrintPinkCopiesForDoorPickHingeToolStripMenuItem
        '
        Me.PrintPinkCopiesForDoorPickHingeToolStripMenuItem.Name = "PrintPinkCopiesForDoorPickHingeToolStripMenuItem"
        Me.PrintPinkCopiesForDoorPickHingeToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.PrintPinkCopiesForDoorPickHingeToolStripMenuItem.Text = "Print Pink Copies for Door Pick/Hinge"
        Me.PrintPinkCopiesForDoorPickHingeToolStripMenuItem.Visible = False
        '
        'PrintTandemboxPagesToolStripMenuItem
        '
        Me.PrintTandemboxPagesToolStripMenuItem.Name = "PrintTandemboxPagesToolStripMenuItem"
        Me.PrintTandemboxPagesToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.PrintTandemboxPagesToolStripMenuItem.Text = "Print Tandembox Pages"
        Me.PrintTandemboxPagesToolStripMenuItem.Visible = False
        '
        'PrintCabinetLabelsToolStripMenuItem
        '
        Me.PrintCabinetLabelsToolStripMenuItem.Name = "PrintCabinetLabelsToolStripMenuItem"
        Me.PrintCabinetLabelsToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.PrintCabinetLabelsToolStripMenuItem.Text = "Print Cabinet Labels"
        Me.PrintCabinetLabelsToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(303, 6)
        Me.ToolStripSeparator2.Visible = False
        '
        'StartAssemblyForSelectedOrdersToolStripMenuItem
        '
        Me.StartAssemblyForSelectedOrdersToolStripMenuItem.Name = "StartAssemblyForSelectedOrdersToolStripMenuItem"
        Me.StartAssemblyForSelectedOrdersToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.StartAssemblyForSelectedOrdersToolStripMenuItem.Text = "Start Assembly for Selected Orders"
        '
        'ColumnChooserToolStripMenuItem
        '
        Me.ColumnChooserToolStripMenuItem.Name = "ColumnChooserToolStripMenuItem"
        Me.ColumnChooserToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.ColumnChooserToolStripMenuItem.Text = "Column Chooser - Click to Save Grid Layout"
        '
        'ResetFiltersToolStripMenuItem
        '
        Me.ResetFiltersToolStripMenuItem.Name = "ResetFiltersToolStripMenuItem"
        Me.ResetFiltersToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.ResetFiltersToolStripMenuItem.Text = "Reset Filters"
        '
        'RemoveFromAssemblyStartToolStripMenuItem
        '
        Me.RemoveFromAssemblyStartToolStripMenuItem.Name = "RemoveFromAssemblyStartToolStripMenuItem"
        Me.RemoveFromAssemblyStartToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.RemoveFromAssemblyStartToolStripMenuItem.Text = "Remove From Assembly Start"
        Me.RemoveFromAssemblyStartToolStripMenuItem.Visible = False
        '
        'KitchenTrackerToolStripMenuItem
        '
        Me.KitchenTrackerToolStripMenuItem.Name = "KitchenTrackerToolStripMenuItem"
        Me.KitchenTrackerToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.KitchenTrackerToolStripMenuItem.Text = "Kitchen Tracker"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(303, 6)
        Me.ToolStripSeparator4.Visible = False
        '
        'SetToolStripMenuItem
        '
        Me.SetToolStripMenuItem.Name = "SetToolStripMenuItem"
        Me.SetToolStripMenuItem.Size = New System.Drawing.Size(306, 22)
        Me.SetToolStripMenuItem.Text = "Set as Tandembox Ordered"
        Me.SetToolStripMenuItem.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label2.Location = New System.Drawing.Point(579, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(367, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Assembly Start - Scanning Station"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkBlue
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1579, 31)
        Me.Panel1.TabIndex = 0
        '
        'ContextMenuStripLine
        '
        Me.ContextMenuStripLine.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStripLine.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssignLine1ToolStripMenuItem1, Me.AssignLine1ToolStripMenuItem, Me.AssignLine2ToolStripMenuItem, Me.AssignLine3ToolStripMenuItem1, Me.AssignLine3ToolStripMenuItem, Me.AssignLine4ToolStripMenuItem, Me.AssignLine5ToolStripMenuItem1, Me.AssignLine5ToolStripMenuItem, Me.AssignLine6ToolStripMenuItem, Me.AssignLine7ToolStripMenuItem, Me.AssignLine8ToolStripMenuItem, Me.SetPlannedStartDateToolStripMenuItem1, Me.ToolStripSeparator3, Me.PrintWhiteCopiesForPickersToolStripMenuItem1, Me.PrintPinkCopiesForDoorPickHingeToolStripMenuItem1, Me.PrintTandemboxPagesToolStripMenuItem1, Me.PrintCabinetLabelsToolStripMenuItem1, Me.KitchenTrackerToolStripMenuItem1, Me.SetAsTandemboxOrderdToolStripMenuItem, Me.ToolStripSeparator5, Me.mniColumnChooser})
        Me.ContextMenuStripLine.Name = "ContextMenuStripLine"
        Me.ContextMenuStripLine.Size = New System.Drawing.Size(310, 434)
        '
        'AssignLine1ToolStripMenuItem1
        '
        Me.AssignLine1ToolStripMenuItem1.Name = "AssignLine1ToolStripMenuItem1"
        Me.AssignLine1ToolStripMenuItem1.Size = New System.Drawing.Size(309, 22)
        Me.AssignLine1ToolStripMenuItem1.Text = "Assign line 1"
        Me.AssignLine1ToolStripMenuItem1.Visible = False
        '
        'AssignLine1ToolStripMenuItem
        '
        Me.AssignLine1ToolStripMenuItem.Name = "AssignLine1ToolStripMenuItem"
        Me.AssignLine1ToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.AssignLine1ToolStripMenuItem.Text = "Assign line 1+2"
        '
        'AssignLine2ToolStripMenuItem
        '
        Me.AssignLine2ToolStripMenuItem.Name = "AssignLine2ToolStripMenuItem"
        Me.AssignLine2ToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.AssignLine2ToolStripMenuItem.Text = "Assign line 2"
        Me.AssignLine2ToolStripMenuItem.Visible = False
        '
        'AssignLine3ToolStripMenuItem1
        '
        Me.AssignLine3ToolStripMenuItem1.Name = "AssignLine3ToolStripMenuItem1"
        Me.AssignLine3ToolStripMenuItem1.Size = New System.Drawing.Size(309, 22)
        Me.AssignLine3ToolStripMenuItem1.Text = "Assign line 3"
        Me.AssignLine3ToolStripMenuItem1.Visible = False
        '
        'AssignLine3ToolStripMenuItem
        '
        Me.AssignLine3ToolStripMenuItem.Name = "AssignLine3ToolStripMenuItem"
        Me.AssignLine3ToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.AssignLine3ToolStripMenuItem.Text = "Assign line 3+4"
        '
        'AssignLine4ToolStripMenuItem
        '
        Me.AssignLine4ToolStripMenuItem.Name = "AssignLine4ToolStripMenuItem"
        Me.AssignLine4ToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.AssignLine4ToolStripMenuItem.Text = "Assign line 4"
        Me.AssignLine4ToolStripMenuItem.Visible = False
        '
        'AssignLine5ToolStripMenuItem1
        '
        Me.AssignLine5ToolStripMenuItem1.Name = "AssignLine5ToolStripMenuItem1"
        Me.AssignLine5ToolStripMenuItem1.Size = New System.Drawing.Size(309, 22)
        Me.AssignLine5ToolStripMenuItem1.Text = "Assign line 5"
        Me.AssignLine5ToolStripMenuItem1.Visible = False
        '
        'AssignLine5ToolStripMenuItem
        '
        Me.AssignLine5ToolStripMenuItem.Name = "AssignLine5ToolStripMenuItem"
        Me.AssignLine5ToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.AssignLine5ToolStripMenuItem.Text = "Assign line 5+6"
        '
        'AssignLine6ToolStripMenuItem
        '
        Me.AssignLine6ToolStripMenuItem.Name = "AssignLine6ToolStripMenuItem"
        Me.AssignLine6ToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.AssignLine6ToolStripMenuItem.Text = "Assign line 6"
        Me.AssignLine6ToolStripMenuItem.Visible = False
        '
        'AssignLine7ToolStripMenuItem
        '
        Me.AssignLine7ToolStripMenuItem.Name = "AssignLine7ToolStripMenuItem"
        Me.AssignLine7ToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.AssignLine7ToolStripMenuItem.Text = "Assign line 7"
        '
        'AssignLine8ToolStripMenuItem
        '
        Me.AssignLine8ToolStripMenuItem.Name = "AssignLine8ToolStripMenuItem"
        Me.AssignLine8ToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.AssignLine8ToolStripMenuItem.Text = "Assign line 8"
        '
        'SetPlannedStartDateToolStripMenuItem1
        '
        Me.SetPlannedStartDateToolStripMenuItem1.Name = "SetPlannedStartDateToolStripMenuItem1"
        Me.SetPlannedStartDateToolStripMenuItem1.Size = New System.Drawing.Size(309, 22)
        Me.SetPlannedStartDateToolStripMenuItem1.Text = "Set Planned Start Date"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(306, 6)
        '
        'PrintWhiteCopiesForPickersToolStripMenuItem1
        '
        Me.PrintWhiteCopiesForPickersToolStripMenuItem1.Name = "PrintWhiteCopiesForPickersToolStripMenuItem1"
        Me.PrintWhiteCopiesForPickersToolStripMenuItem1.Size = New System.Drawing.Size(309, 22)
        Me.PrintWhiteCopiesForPickersToolStripMenuItem1.Text = "Print White Copies for Pickers"
        '
        'PrintPinkCopiesForDoorPickHingeToolStripMenuItem1
        '
        Me.PrintPinkCopiesForDoorPickHingeToolStripMenuItem1.Name = "PrintPinkCopiesForDoorPickHingeToolStripMenuItem1"
        Me.PrintPinkCopiesForDoorPickHingeToolStripMenuItem1.Size = New System.Drawing.Size(309, 22)
        Me.PrintPinkCopiesForDoorPickHingeToolStripMenuItem1.Text = "Print Pink Copies for Door Pick/Hinge"
        '
        'PrintTandemboxPagesToolStripMenuItem1
        '
        Me.PrintTandemboxPagesToolStripMenuItem1.Name = "PrintTandemboxPagesToolStripMenuItem1"
        Me.PrintTandemboxPagesToolStripMenuItem1.Size = New System.Drawing.Size(309, 22)
        Me.PrintTandemboxPagesToolStripMenuItem1.Text = "Print Tandembox Pages"
        '
        'PrintCabinetLabelsToolStripMenuItem1
        '
        Me.PrintCabinetLabelsToolStripMenuItem1.Name = "PrintCabinetLabelsToolStripMenuItem1"
        Me.PrintCabinetLabelsToolStripMenuItem1.Size = New System.Drawing.Size(309, 22)
        Me.PrintCabinetLabelsToolStripMenuItem1.Text = "Print Cabinet Labels"
        '
        'KitchenTrackerToolStripMenuItem1
        '
        Me.KitchenTrackerToolStripMenuItem1.Name = "KitchenTrackerToolStripMenuItem1"
        Me.KitchenTrackerToolStripMenuItem1.Size = New System.Drawing.Size(309, 22)
        Me.KitchenTrackerToolStripMenuItem1.Text = "Kitchen Tracker"
        '
        'SetAsTandemboxOrderdToolStripMenuItem
        '
        Me.SetAsTandemboxOrderdToolStripMenuItem.Name = "SetAsTandemboxOrderdToolStripMenuItem"
        Me.SetAsTandemboxOrderdToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.SetAsTandemboxOrderdToolStripMenuItem.Text = "Order Tandemboxes before Assembly Start"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(306, 6)
        '
        'mniColumnChooser
        '
        Me.mniColumnChooser.Name = "mniColumnChooser"
        Me.mniColumnChooser.Size = New System.Drawing.Size(309, 22)
        Me.mniColumnChooser.Text = "Column Chooser - Click to Save Grid Lalyout"
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(665, 91)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(272, 16)
        Me.lblDate.TabIndex = 0
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mnuPantries
        '
        Me.mnuPantries.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuPantries.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.KitchenTrackerToolStripMenuItem3, Me.PrintWhiteCopiesForPantryAssemblerToolStripMenuItem, Me.tsColomnChooser})
        Me.mnuPantries.Name = "mnuPantries"
        Me.mnuPantries.Size = New System.Drawing.Size(286, 92)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'KitchenTrackerToolStripMenuItem3
        '
        Me.KitchenTrackerToolStripMenuItem3.Name = "KitchenTrackerToolStripMenuItem3"
        Me.KitchenTrackerToolStripMenuItem3.Size = New System.Drawing.Size(285, 22)
        Me.KitchenTrackerToolStripMenuItem3.Text = "Kitchen Tracker"
        '
        'PrintWhiteCopiesForPantryAssemblerToolStripMenuItem
        '
        Me.PrintWhiteCopiesForPantryAssemblerToolStripMenuItem.Name = "PrintWhiteCopiesForPantryAssemblerToolStripMenuItem"
        Me.PrintWhiteCopiesForPantryAssemblerToolStripMenuItem.Size = New System.Drawing.Size(285, 22)
        Me.PrintWhiteCopiesForPantryAssemblerToolStripMenuItem.Text = "Print White Copies for Pantry Assembler"
        '
        'tsColomnChooser
        '
        Me.tsColomnChooser.Name = "tsColomnChooser"
        Me.tsColomnChooser.Size = New System.Drawing.Size(285, 22)
        Me.tsColomnChooser.Text = "Colomn Chooser"
        '
        'mnu_WeeklyLayouts_LotList
        '
        Me.mnu_WeeklyLayouts_LotList.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnu_WeeklyLayouts_LotList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColumnChooserToolStripMenuItem2})
        Me.mnu_WeeklyLayouts_LotList.Name = "mnu_WeeklyLayouts_LotList"
        Me.mnu_WeeklyLayouts_LotList.Size = New System.Drawing.Size(165, 26)
        '
        'ColumnChooserToolStripMenuItem2
        '
        Me.ColumnChooserToolStripMenuItem2.Name = "ColumnChooserToolStripMenuItem2"
        Me.ColumnChooserToolStripMenuItem2.Size = New System.Drawing.Size(164, 22)
        Me.ColumnChooserToolStripMenuItem2.Text = "Column Chooser"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColumnChooserToolStripMenuItem1, Me.SetPlannedDateToolStripMenuItem, Me.ClearPlannedDateToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(175, 70)
        '
        'ColumnChooserToolStripMenuItem1
        '
        Me.ColumnChooserToolStripMenuItem1.Name = "ColumnChooserToolStripMenuItem1"
        Me.ColumnChooserToolStripMenuItem1.Size = New System.Drawing.Size(174, 22)
        Me.ColumnChooserToolStripMenuItem1.Text = "Column Chooser"
        '
        'SetPlannedDateToolStripMenuItem
        '
        Me.SetPlannedDateToolStripMenuItem.Name = "SetPlannedDateToolStripMenuItem"
        Me.SetPlannedDateToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.SetPlannedDateToolStripMenuItem.Text = "Set Planned Date"
        '
        'ClearPlannedDateToolStripMenuItem
        '
        Me.ClearPlannedDateToolStripMenuItem.Name = "ClearPlannedDateToolStripMenuItem"
        Me.ClearPlannedDateToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ClearPlannedDateToolStripMenuItem.Text = "Clear Planned Date"
        '
        'mnu_WeeklyLayouts_ChangeOrder
        '
        Me.mnu_WeeklyLayouts_ChangeOrder.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnu_WeeklyLayouts_ChangeOrder.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColumnChooserToolStripMenuItem6})
        Me.mnu_WeeklyLayouts_ChangeOrder.Name = "ContextMenuStrip3"
        Me.mnu_WeeklyLayouts_ChangeOrder.Size = New System.Drawing.Size(165, 26)
        '
        'ColumnChooserToolStripMenuItem6
        '
        Me.ColumnChooserToolStripMenuItem6.Name = "ColumnChooserToolStripMenuItem6"
        Me.ColumnChooserToolStripMenuItem6.Size = New System.Drawing.Size(164, 22)
        Me.ColumnChooserToolStripMenuItem6.Text = "Column Chooser"
        '
        'ContextMenuStripLV
        '
        Me.ContextMenuStripLV.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStripLV.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssignLineToolStripMenuItem})
        Me.ContextMenuStripLV.Name = "ContextMenuStripLV"
        Me.ContextMenuStripLV.Size = New System.Drawing.Size(135, 26)
        '
        'AssignLineToolStripMenuItem
        '
        Me.AssignLineToolStripMenuItem.Name = "AssignLineToolStripMenuItem"
        Me.AssignLineToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.AssignLineToolStripMenuItem.Text = "Assign Line"
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.upServiceCabinets)
        Me.TabPage3.ForeColor = System.Drawing.Color.Black
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1571, 855)
        Me.TabPage3.TabIndex = 9
        Me.TabPage3.Text = "Service Cabinets"
        '
        'upServiceCabinets
        '
        Me.upServiceCabinets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upServiceCabinets.Location = New System.Drawing.Point(0, 0)
        Me.upServiceCabinets.Name = "upServiceCabinets"
        Me.upServiceCabinets.Size = New System.Drawing.Size(1571, 855)
        Me.upServiceCabinets.TabIndex = 0
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.upMainPanel)
        Me.TabPage8.Location = New System.Drawing.Point(4, 25)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(1571, 855)
        Me.TabPage8.TabIndex = 8
        Me.TabPage8.Text = "Weekly Layouts"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'upMainPanel
        '
        '
        'upMainPanel.ClientArea
        '
        Me.upMainPanel.ClientArea.Controls.Add(Me.upWeeklyLayouts)
        Me.upMainPanel.ClientArea.Controls.Add(Me.lblAssemblyPartsOrderedOn)
        Me.upMainPanel.ClientArea.Controls.Add(Me.btnSetAssemblyPartsOrdered)
        Me.upMainPanel.ClientArea.Controls.Add(Me.uccWeeklyLayoutSiteRequest)
        Me.upMainPanel.ClientArea.Controls.Add(Me.UltraLabel6)
        Me.upMainPanel.ClientArea.Controls.Add(Me.ug_AssemblyStart_AdvancedSearchLotList)
        Me.upMainPanel.ClientArea.Controls.Add(Me.btn_WeeklyLayouts_ColumnChooser)
        Me.upMainPanel.ClientArea.Controls.Add(Me.lblTotalRows)
        Me.upMainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upMainPanel.Location = New System.Drawing.Point(0, 0)
        Me.upMainPanel.Name = "upMainPanel"
        Me.upMainPanel.Size = New System.Drawing.Size(1571, 855)
        Me.upMainPanel.TabIndex = 255
        '
        'upWeeklyLayouts
        '
        Me.upWeeklyLayouts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.upWeeklyLayouts.AutoSize = True
        Me.upWeeklyLayouts.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        '
        'upWeeklyLayouts.ClientArea
        '
        Me.upWeeklyLayouts.ClientArea.Controls.Add(Me.CrystalReportViewer1)
        Me.upWeeklyLayouts.Location = New System.Drawing.Point(354, 0)
        Me.upWeeklyLayouts.Name = "upWeeklyLayouts"
        Me.upWeeklyLayouts.Size = New System.Drawing.Size(991, 853)
        Me.upWeeklyLayouts.TabIndex = 229
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.AutoScroll = True
        Me.CrystalReportViewer1.AutoSize = True
        Me.CrystalReportViewer1.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.CausesValidation = False
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.EnableDrillDown = False
        Me.CrystalReportViewer1.EnableToolTips = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowCopyButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(991, 853)
        Me.CrystalReportViewer1.TabIndex = 228
        Me.CrystalReportViewer1.TabStop = False
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.ToolPanelWidth = 10
        '
        'lblAssemblyPartsOrderedOn
        '
        Me.lblAssemblyPartsOrderedOn.Location = New System.Drawing.Point(6, 67)
        Me.lblAssemblyPartsOrderedOn.Name = "lblAssemblyPartsOrderedOn"
        Me.lblAssemblyPartsOrderedOn.Size = New System.Drawing.Size(331, 23)
        Me.lblAssemblyPartsOrderedOn.TabIndex = 228
        Me.lblAssemblyPartsOrderedOn.Text = "Assembly Parts Ordered Date:"
        '
        'btnSetAssemblyPartsOrdered
        '
        Me.btnSetAssemblyPartsOrdered.Location = New System.Drawing.Point(172, 35)
        Me.btnSetAssemblyPartsOrdered.Name = "btnSetAssemblyPartsOrdered"
        Me.btnSetAssemblyPartsOrdered.Size = New System.Drawing.Size(165, 23)
        Me.btnSetAssemblyPartsOrdered.TabIndex = 227
        Me.btnSetAssemblyPartsOrdered.Text = "Set Assembly Parts Ordered"
        '
        'uccWeeklyLayoutSiteRequest
        '
        Me.uccWeeklyLayoutSiteRequest.DateButtons.Add(DateButton1)
        Me.uccWeeklyLayoutSiteRequest.Location = New System.Drawing.Point(183, 6)
        Me.uccWeeklyLayoutSiteRequest.Name = "uccWeeklyLayoutSiteRequest"
        Me.uccWeeklyLayoutSiteRequest.NonAutoSizeHeight = 21
        Me.uccWeeklyLayoutSiteRequest.Size = New System.Drawing.Size(121, 21)
        Me.uccWeeklyLayoutSiteRequest.TabIndex = 224
        Me.uccWeeklyLayoutSiteRequest.Value = New Date(2017, 7, 26, 0, 0, 0, 0)
        '
        'UltraLabel6
        '
        Me.UltraLabel6.Location = New System.Drawing.Point(6, 9)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(171, 23)
        Me.UltraLabel6.TabIndex = 225
        Me.UltraLabel6.Text = "Production Received By Week:"
        '
        'ug_AssemblyStart_AdvancedSearchLotList
        '
        Me.ug_AssemblyStart_AdvancedSearchLotList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ug_AssemblyStart_AdvancedSearchLotList.ContextMenuStrip = Me.mnu_WeeklyLayouts_LotList
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Appearance = Appearance1
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.MaxColScrollRegions = 1
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.AllowMultiCellOperations = CType((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) _
            Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) _
            Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) _
            Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) _
            Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) _
            Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) _
            Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved), Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.SingleSummary
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.CellPadding = 0
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCellsAlwaysBelowDescription
        Appearance10.TextHAlignAsString = "Left"
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.Top Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.InGroupByRows), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
        Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance12.ForeColor = System.Drawing.Color.White
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.SummaryFooterCaptionAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ug_AssemblyStart_AdvancedSearchLotList.Location = New System.Drawing.Point(3, 96)
        Me.ug_AssemblyStart_AdvancedSearchLotList.Name = "ug_AssemblyStart_AdvancedSearchLotList"
        Me.ug_AssemblyStart_AdvancedSearchLotList.Size = New System.Drawing.Size(334, 751)
        Me.ug_AssemblyStart_AdvancedSearchLotList.TabIndex = 3
        Me.ug_AssemblyStart_AdvancedSearchLotList.Text = "LotList"
        '
        'btn_WeeklyLayouts_ColumnChooser
        '
        Me.btn_WeeklyLayouts_ColumnChooser.Location = New System.Drawing.Point(310, 6)
        Me.btn_WeeklyLayouts_ColumnChooser.Name = "btn_WeeklyLayouts_ColumnChooser"
        Me.btn_WeeklyLayouts_ColumnChooser.Size = New System.Drawing.Size(113, 23)
        Me.btn_WeeklyLayouts_ColumnChooser.TabIndex = 221
        Me.btn_WeeklyLayouts_ColumnChooser.Text = "Column Chooser"
        '
        'lblTotalRows
        '
        Me.lblTotalRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRows.Location = New System.Drawing.Point(8, 33)
        Me.lblTotalRows.Name = "lblTotalRows"
        Me.lblTotalRows.Size = New System.Drawing.Size(144, 23)
        Me.lblTotalRows.TabIndex = 222
        Me.lblTotalRows.Text = "UltraLabel1"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.ugPantries)
        Me.TabPage6.Location = New System.Drawing.Point(4, 25)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(1571, 855)
        Me.TabPage6.TabIndex = 6
        Me.TabPage6.Text = "Pantries"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'ugPantries
        '
        Me.ugPantries.ContextMenuStrip = Me.mnuPantries
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugPantries.DisplayLayout.Appearance = Appearance14
        Me.ugPantries.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugPantries.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPantries.DisplayLayout.GroupByBox.Appearance = Appearance15
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPantries.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance16
        Me.ugPantries.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugPantries.DisplayLayout.GroupByBox.Hidden = True
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance17.BackColor2 = System.Drawing.SystemColors.Control
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPantries.DisplayLayout.GroupByBox.PromptAppearance = Appearance17
        Me.ugPantries.DisplayLayout.MaxColScrollRegions = 1
        Me.ugPantries.DisplayLayout.MaxRowScrollRegions = 1
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugPantries.DisplayLayout.Override.ActiveCellAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.SystemColors.Highlight
        Appearance19.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugPantries.DisplayLayout.Override.ActiveRowAppearance = Appearance19
        Me.ugPantries.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugPantries.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugPantries.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugPantries.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugPantries.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugPantries.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Me.ugPantries.DisplayLayout.Override.CardAreaAppearance = Appearance20
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugPantries.DisplayLayout.Override.CellAppearance = Appearance21
        Me.ugPantries.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugPantries.DisplayLayout.Override.CellPadding = 0
        Appearance22.BackColor = System.Drawing.SystemColors.Control
        Appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance22.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPantries.DisplayLayout.Override.GroupByRowAppearance = Appearance22
        Appearance23.TextHAlignAsString = "Left"
        Me.ugPantries.DisplayLayout.Override.HeaderAppearance = Appearance23
        Me.ugPantries.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugPantries.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Me.ugPantries.DisplayLayout.Override.RowAppearance = Appearance24
        Me.ugPantries.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugPantries.DisplayLayout.Override.TemplateAddRowAppearance = Appearance25
        Me.ugPantries.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugPantries.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugPantries.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugPantries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugPantries.Location = New System.Drawing.Point(0, 0)
        Me.ugPantries.Name = "ugPantries"
        Me.ugPantries.Size = New System.Drawing.Size(1571, 855)
        Me.ugPantries.TabIndex = 2
        Me.ugPantries.Text = "UltraGrid1"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnViewTodayReport)
        Me.TabPage1.Controls.Add(Me.lvOrders)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtCount)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1571, 855)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Today's Orders"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnViewTodayReport
        '
        Me.btnViewTodayReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnViewTodayReport.Location = New System.Drawing.Point(761, 824)
        Me.btnViewTodayReport.Name = "btnViewTodayReport"
        Me.btnViewTodayReport.Size = New System.Drawing.Size(99, 23)
        Me.btnViewTodayReport.TabIndex = 37
        Me.btnViewTodayReport.Text = "View Report"
        '
        'lvOrders
        '
        Me.lvOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvOrders.ContextMenuStrip = Me.ContextMenuStripLine
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Appearance26.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.lvOrders.DisplayLayout.Appearance = Appearance26
        Me.lvOrders.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lvOrders.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvOrders.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance27.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance27.BorderColor = System.Drawing.SystemColors.Window
        Me.lvOrders.DisplayLayout.GroupByBox.Appearance = Appearance27
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lvOrders.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance28
        Me.lvOrders.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.lvOrders.DisplayLayout.GroupByBox.Hidden = True
        Appearance29.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance29.BackColor2 = System.Drawing.SystemColors.Control
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance29.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lvOrders.DisplayLayout.GroupByBox.PromptAppearance = Appearance29
        Me.lvOrders.DisplayLayout.MaxColScrollRegions = 1
        Me.lvOrders.DisplayLayout.MaxRowScrollRegions = 1
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lvOrders.DisplayLayout.Override.ActiveCellAppearance = Appearance30
        Appearance31.BackColor = System.Drawing.SystemColors.Highlight
        Appearance31.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lvOrders.DisplayLayout.Override.ActiveRowAppearance = Appearance31
        Me.lvOrders.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.lvOrders.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvOrders.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvOrders.DisplayLayout.Override.AllowMultiCellOperations = CType((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders), Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)
        Me.lvOrders.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.lvOrders.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.lvOrders.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.lvOrders.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.lvOrders.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Me.lvOrders.DisplayLayout.Override.CardAreaAppearance = Appearance32
        Appearance33.BorderColor = System.Drawing.Color.Silver
        Appearance33.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.lvOrders.DisplayLayout.Override.CellAppearance = Appearance33
        Me.lvOrders.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.lvOrders.DisplayLayout.Override.CellPadding = 0
        Me.lvOrders.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.lvOrders.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance34.BackColor = System.Drawing.SystemColors.Control
        Appearance34.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance34.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance34.BorderColor = System.Drawing.SystemColors.Window
        Me.lvOrders.DisplayLayout.Override.GroupByRowAppearance = Appearance34
        Appearance35.TextHAlignAsString = "Left"
        Me.lvOrders.DisplayLayout.Override.HeaderAppearance = Appearance35
        Me.lvOrders.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.lvOrders.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance36.BackColor = System.Drawing.SystemColors.Window
        Appearance36.BorderColor = System.Drawing.Color.Silver
        Me.lvOrders.DisplayLayout.Override.RowAppearance = Appearance36
        Me.lvOrders.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.lvOrders.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance37.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lvOrders.DisplayLayout.Override.TemplateAddRowAppearance = Appearance37
        Me.lvOrders.DisplayLayout.Override.TipStyleHeader = Infragistics.Win.UltraWinGrid.TipStyle.Show
        Me.lvOrders.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.lvOrders.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.lvOrders.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.lvOrders.GesturesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Me.lvOrders.Location = New System.Drawing.Point(3, 3)
        Me.lvOrders.Name = "lvOrders"
        Me.lvOrders.Size = New System.Drawing.Size(1565, 764)
        Me.lvOrders.TabIndex = 36
        Me.lvOrders.Text = "UltraGrid1"
        Me.lvOrders.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(1264, 770)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(296, 17)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "All Orders Started Today"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.Location = New System.Drawing.Point(198, 774)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(280, 14)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Scan Time = Time Assembly Started Today"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.Location = New System.Drawing.Point(198, 794)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(280, 14)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "PR = Parts Retrieved for Box Assembly"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.Location = New System.Drawing.Point(15, 814)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 14)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "H = Doors Hinged"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(15, 794)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 14)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "P = All Doors Painted"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(15, 774)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 14)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "R = All Raw Doors Pulled"
        '
        'txtCount
        '
        Me.txtCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCount.BackColor = System.Drawing.Color.Transparent
        Me.txtCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCount.ForeColor = System.Drawing.Color.Black
        Me.txtCount.Location = New System.Drawing.Point(1430, 791)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(133, 24)
        Me.txtCount.TabIndex = 2
        Me.txtCount.Text = "0"
        Me.txtCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(1261, 791)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 24)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Order Count:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnPrintClampInfo8)
        Me.TabPage2.Controls.Add(Me.btnViewClampDetail8)
        Me.TabPage2.Controls.Add(Me.lblClampDetail8)
        Me.TabPage2.Controls.Add(Me.lblMax8)
        Me.TabPage2.Controls.Add(Me.lblMinRem8)
        Me.TabPage2.Controls.Add(Me.btnClamp8)
        Me.TabPage2.Controls.Add(Me.btManageAssemblersAndClamps)
        Me.TabPage2.Controls.Add(Me.btnPrintClampInfo7)
        Me.TabPage2.Controls.Add(Me.btnPrintClampInfo6)
        Me.TabPage2.Controls.Add(Me.btnPrintClampInfo5)
        Me.TabPage2.Controls.Add(Me.btnPrintClampInfo4)
        Me.TabPage2.Controls.Add(Me.btnPrintClampInfo3)
        Me.TabPage2.Controls.Add(Me.btnPrintClampInfo2)
        Me.TabPage2.Controls.Add(Me.btnPrintClampInfo1)
        Me.TabPage2.Controls.Add(Me.btnViewClampDetail7)
        Me.TabPage2.Controls.Add(Me.btnViewClampDetail6)
        Me.TabPage2.Controls.Add(Me.btnViewClampDetail5)
        Me.TabPage2.Controls.Add(Me.btnViewClampDetail4)
        Me.TabPage2.Controls.Add(Me.btnViewClampDetail3)
        Me.TabPage2.Controls.Add(Me.btnViewClampDetail2)
        Me.TabPage2.Controls.Add(Me.btnViewClampDetail1)
        Me.TabPage2.Controls.Add(Me.lblClampDetail7)
        Me.TabPage2.Controls.Add(Me.lblClampDetail6)
        Me.TabPage2.Controls.Add(Me.lblClampDetail5)
        Me.TabPage2.Controls.Add(Me.lblClampDetail4)
        Me.TabPage2.Controls.Add(Me.lblClampDetail3)
        Me.TabPage2.Controls.Add(Me.lblClampDetail2)
        Me.TabPage2.Controls.Add(Me.lblClampDetail1)
        Me.TabPage2.Controls.Add(Me.lblMax7)
        Me.TabPage2.Controls.Add(Me.lblMax6)
        Me.TabPage2.Controls.Add(Me.lblMax5)
        Me.TabPage2.Controls.Add(Me.lblMax4)
        Me.TabPage2.Controls.Add(Me.lblMax3)
        Me.TabPage2.Controls.Add(Me.lblMax2)
        Me.TabPage2.Controls.Add(Me.lblMax1)
        Me.TabPage2.Controls.Add(Me.lblMinRem7)
        Me.TabPage2.Controls.Add(Me.lblMinRem6)
        Me.TabPage2.Controls.Add(Me.lblMinRem5)
        Me.TabPage2.Controls.Add(Me.lblMinRem4)
        Me.TabPage2.Controls.Add(Me.lblMinRem3)
        Me.TabPage2.Controls.Add(Me.lblMinRem2)
        Me.TabPage2.Controls.Add(Me.lblMinRem1)
        Me.TabPage2.Controls.Add(Me.btnClamp7)
        Me.TabPage2.Controls.Add(Me.btnClamp6)
        Me.TabPage2.Controls.Add(Me.btnClamp5)
        Me.TabPage2.Controls.Add(Me.btnClamp4)
        Me.TabPage2.Controls.Add(Me.btnClamp3)
        Me.TabPage2.Controls.Add(Me.btnClamp2)
        Me.TabPage2.Controls.Add(Me.btnClamp1)
        Me.TabPage2.Controls.Add(Me.btnManageClampHours)
        Me.TabPage2.Controls.Add(Me.btnManageClamps)
        Me.TabPage2.Controls.Add(Me.UltraPanel1)
        Me.TabPage2.Controls.Add(Me.txtSearch)
        Me.TabPage2.Controls.Add(Me.txtBarcode)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.upContainer)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.lblMessage)
        Me.TabPage2.Controls.Add(Me.BtnRefresh)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1571, 855)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Assembly Start"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnPrintClampInfo8
        '
        Appearance38.Image = Global.SequenceERP.My.Resources.Resources.print_32
        Me.btnPrintClampInfo8.Appearance = Appearance38
        Me.btnPrintClampInfo8.Location = New System.Drawing.Point(1501, 106)
        Me.btnPrintClampInfo8.Name = "btnPrintClampInfo8"
        Me.btnPrintClampInfo8.Size = New System.Drawing.Size(30, 23)
        Me.btnPrintClampInfo8.TabIndex = 97
        '
        'btnViewClampDetail8
        '
        Me.btnViewClampDetail8.BackColor = System.Drawing.Color.Gainsboro
        Me.btnViewClampDetail8.Location = New System.Drawing.Point(1391, 135)
        Me.btnViewClampDetail8.Name = "btnViewClampDetail8"
        Me.btnViewClampDetail8.Size = New System.Drawing.Size(119, 23)
        Me.btnViewClampDetail8.TabIndex = 96
        Me.btnViewClampDetail8.Text = "View Clamp Detail"
        Me.btnViewClampDetail8.UseVisualStyleBackColor = False
        '
        'lblClampDetail8
        '
        Me.lblClampDetail8.Location = New System.Drawing.Point(1391, 108)
        Me.lblClampDetail8.Name = "lblClampDetail8"
        Me.lblClampDetail8.Size = New System.Drawing.Size(140, 23)
        Me.lblClampDetail8.TabIndex = 95
        Me.lblClampDetail8.Text = "MIN REM:"
        '
        'lblMax8
        '
        Me.lblMax8.Location = New System.Drawing.Point(1391, 87)
        Me.lblMax8.Name = "lblMax8"
        Me.lblMax8.Size = New System.Drawing.Size(140, 23)
        Me.lblMax8.TabIndex = 94
        Me.lblMax8.Text = "MIN REM:"
        '
        'lblMinRem8
        '
        Me.lblMinRem8.Location = New System.Drawing.Point(1391, 68)
        Me.lblMinRem8.Name = "lblMinRem8"
        Me.lblMinRem8.Size = New System.Drawing.Size(140, 23)
        Me.lblMinRem8.TabIndex = 93
        Me.lblMinRem8.Text = "MIN REM:"
        '
        'btnClamp8
        '
        Me.btnClamp8.Location = New System.Drawing.Point(1391, 7)
        Me.btnClamp8.Name = "btnClamp8"
        Me.btnClamp8.Size = New System.Drawing.Size(140, 55)
        Me.btnClamp8.TabIndex = 92
        Me.btnClamp8.Text = "Clamp 8"
        '
        'btManageAssemblersAndClamps
        '
        Me.btManageAssemblersAndClamps.Location = New System.Drawing.Point(133, 151)
        Me.btManageAssemblersAndClamps.Name = "btManageAssemblersAndClamps"
        Me.btManageAssemblersAndClamps.Size = New System.Drawing.Size(201, 23)
        Me.btManageAssemblersAndClamps.TabIndex = 91
        Me.btManageAssemblersAndClamps.Text = "Manage Assemblers and Clamps"
        '
        'btnPrintClampInfo7
        '
        Appearance39.Image = Global.SequenceERP.My.Resources.Resources.print_32
        Me.btnPrintClampInfo7.Appearance = Appearance39
        Me.btnPrintClampInfo7.Location = New System.Drawing.Point(1355, 108)
        Me.btnPrintClampInfo7.Name = "btnPrintClampInfo7"
        Me.btnPrintClampInfo7.Size = New System.Drawing.Size(30, 23)
        Me.btnPrintClampInfo7.TabIndex = 90
        '
        'btnPrintClampInfo6
        '
        Appearance40.Image = Global.SequenceERP.My.Resources.Resources.print_32
        Me.btnPrintClampInfo6.Appearance = Appearance40
        Me.btnPrintClampInfo6.Location = New System.Drawing.Point(1209, 106)
        Me.btnPrintClampInfo6.Name = "btnPrintClampInfo6"
        Me.btnPrintClampInfo6.Size = New System.Drawing.Size(30, 23)
        Me.btnPrintClampInfo6.TabIndex = 89
        '
        'btnPrintClampInfo5
        '
        Appearance41.Image = Global.SequenceERP.My.Resources.Resources.print_32
        Me.btnPrintClampInfo5.Appearance = Appearance41
        Me.btnPrintClampInfo5.Location = New System.Drawing.Point(1063, 108)
        Me.btnPrintClampInfo5.Name = "btnPrintClampInfo5"
        Me.btnPrintClampInfo5.Size = New System.Drawing.Size(30, 23)
        Me.btnPrintClampInfo5.TabIndex = 88
        '
        'btnPrintClampInfo4
        '
        Appearance42.Image = Global.SequenceERP.My.Resources.Resources.print_32
        Me.btnPrintClampInfo4.Appearance = Appearance42
        Me.btnPrintClampInfo4.Location = New System.Drawing.Point(917, 108)
        Me.btnPrintClampInfo4.Name = "btnPrintClampInfo4"
        Me.btnPrintClampInfo4.Size = New System.Drawing.Size(30, 23)
        Me.btnPrintClampInfo4.TabIndex = 87
        '
        'btnPrintClampInfo3
        '
        Appearance43.Image = Global.SequenceERP.My.Resources.Resources.print_32
        Me.btnPrintClampInfo3.Appearance = Appearance43
        Me.btnPrintClampInfo3.Location = New System.Drawing.Point(771, 103)
        Me.btnPrintClampInfo3.Name = "btnPrintClampInfo3"
        Me.btnPrintClampInfo3.Size = New System.Drawing.Size(30, 23)
        Me.btnPrintClampInfo3.TabIndex = 86
        '
        'btnPrintClampInfo2
        '
        Appearance44.Image = Global.SequenceERP.My.Resources.Resources.print_32
        Me.btnPrintClampInfo2.Appearance = Appearance44
        Me.btnPrintClampInfo2.Location = New System.Drawing.Point(625, 103)
        Me.btnPrintClampInfo2.Name = "btnPrintClampInfo2"
        Me.btnPrintClampInfo2.Size = New System.Drawing.Size(30, 23)
        Me.btnPrintClampInfo2.TabIndex = 85
        '
        'btnPrintClampInfo1
        '
        Appearance45.Image = Global.SequenceERP.My.Resources.Resources.print_32
        Me.btnPrintClampInfo1.Appearance = Appearance45
        Me.btnPrintClampInfo1.Location = New System.Drawing.Point(478, 103)
        Me.btnPrintClampInfo1.Name = "btnPrintClampInfo1"
        Me.btnPrintClampInfo1.Size = New System.Drawing.Size(30, 23)
        Me.btnPrintClampInfo1.TabIndex = 84
        '
        'btnViewClampDetail7
        '
        Me.btnViewClampDetail7.BackColor = System.Drawing.Color.Gainsboro
        Me.btnViewClampDetail7.Location = New System.Drawing.Point(1245, 135)
        Me.btnViewClampDetail7.Name = "btnViewClampDetail7"
        Me.btnViewClampDetail7.Size = New System.Drawing.Size(119, 23)
        Me.btnViewClampDetail7.TabIndex = 83
        Me.btnViewClampDetail7.Text = "View Clamp Detail"
        Me.btnViewClampDetail7.UseVisualStyleBackColor = False
        '
        'btnViewClampDetail6
        '
        Me.btnViewClampDetail6.BackColor = System.Drawing.Color.Gainsboro
        Me.btnViewClampDetail6.Location = New System.Drawing.Point(1098, 135)
        Me.btnViewClampDetail6.Name = "btnViewClampDetail6"
        Me.btnViewClampDetail6.Size = New System.Drawing.Size(119, 23)
        Me.btnViewClampDetail6.TabIndex = 82
        Me.btnViewClampDetail6.Text = "View Clamp Detail"
        Me.btnViewClampDetail6.UseVisualStyleBackColor = False
        '
        'btnViewClampDetail5
        '
        Me.btnViewClampDetail5.BackColor = System.Drawing.Color.Gainsboro
        Me.btnViewClampDetail5.Location = New System.Drawing.Point(953, 135)
        Me.btnViewClampDetail5.Name = "btnViewClampDetail5"
        Me.btnViewClampDetail5.Size = New System.Drawing.Size(119, 23)
        Me.btnViewClampDetail5.TabIndex = 81
        Me.btnViewClampDetail5.Text = "View Clamp Detail"
        Me.btnViewClampDetail5.UseVisualStyleBackColor = False
        '
        'btnViewClampDetail4
        '
        Me.btnViewClampDetail4.BackColor = System.Drawing.Color.Gainsboro
        Me.btnViewClampDetail4.Location = New System.Drawing.Point(807, 135)
        Me.btnViewClampDetail4.Name = "btnViewClampDetail4"
        Me.btnViewClampDetail4.Size = New System.Drawing.Size(119, 23)
        Me.btnViewClampDetail4.TabIndex = 80
        Me.btnViewClampDetail4.Text = "View Clamp Detail"
        Me.btnViewClampDetail4.UseVisualStyleBackColor = False
        '
        'btnViewClampDetail3
        '
        Me.btnViewClampDetail3.BackColor = System.Drawing.Color.Gainsboro
        Me.btnViewClampDetail3.Location = New System.Drawing.Point(664, 135)
        Me.btnViewClampDetail3.Name = "btnViewClampDetail3"
        Me.btnViewClampDetail3.Size = New System.Drawing.Size(119, 23)
        Me.btnViewClampDetail3.TabIndex = 79
        Me.btnViewClampDetail3.Text = "View Clamp Detail"
        Me.btnViewClampDetail3.UseVisualStyleBackColor = False
        '
        'btnViewClampDetail2
        '
        Me.btnViewClampDetail2.BackColor = System.Drawing.Color.Gainsboro
        Me.btnViewClampDetail2.Location = New System.Drawing.Point(515, 135)
        Me.btnViewClampDetail2.Name = "btnViewClampDetail2"
        Me.btnViewClampDetail2.Size = New System.Drawing.Size(119, 23)
        Me.btnViewClampDetail2.TabIndex = 78
        Me.btnViewClampDetail2.Text = "View Clamp Detail"
        Me.btnViewClampDetail2.UseVisualStyleBackColor = False
        '
        'btnViewClampDetail1
        '
        Me.btnViewClampDetail1.BackColor = System.Drawing.Color.Gainsboro
        Me.btnViewClampDetail1.Location = New System.Drawing.Point(372, 135)
        Me.btnViewClampDetail1.Name = "btnViewClampDetail1"
        Me.btnViewClampDetail1.Size = New System.Drawing.Size(119, 23)
        Me.btnViewClampDetail1.TabIndex = 77
        Me.btnViewClampDetail1.Text = "View Clamp Detail"
        Me.btnViewClampDetail1.UseVisualStyleBackColor = False
        '
        'lblClampDetail7
        '
        Me.lblClampDetail7.Location = New System.Drawing.Point(1245, 108)
        Me.lblClampDetail7.Name = "lblClampDetail7"
        Me.lblClampDetail7.Size = New System.Drawing.Size(140, 23)
        Me.lblClampDetail7.TabIndex = 76
        Me.lblClampDetail7.Text = "MIN REM:"
        '
        'lblClampDetail6
        '
        Me.lblClampDetail6.Location = New System.Drawing.Point(1099, 108)
        Me.lblClampDetail6.Name = "lblClampDetail6"
        Me.lblClampDetail6.Size = New System.Drawing.Size(140, 23)
        Me.lblClampDetail6.TabIndex = 75
        Me.lblClampDetail6.Text = "MIN REM:"
        '
        'lblClampDetail5
        '
        Me.lblClampDetail5.Location = New System.Drawing.Point(953, 108)
        Me.lblClampDetail5.Name = "lblClampDetail5"
        Me.lblClampDetail5.Size = New System.Drawing.Size(140, 23)
        Me.lblClampDetail5.TabIndex = 74
        Me.lblClampDetail5.Text = "MIN REM:"
        '
        'lblClampDetail4
        '
        Me.lblClampDetail4.Location = New System.Drawing.Point(807, 108)
        Me.lblClampDetail4.Name = "lblClampDetail4"
        Me.lblClampDetail4.Size = New System.Drawing.Size(140, 23)
        Me.lblClampDetail4.TabIndex = 73
        Me.lblClampDetail4.Text = "MIN REM:"
        '
        'lblClampDetail3
        '
        Me.lblClampDetail3.Location = New System.Drawing.Point(661, 108)
        Me.lblClampDetail3.Name = "lblClampDetail3"
        Me.lblClampDetail3.Size = New System.Drawing.Size(140, 23)
        Me.lblClampDetail3.TabIndex = 72
        Me.lblClampDetail3.Text = "MIN REM:"
        '
        'lblClampDetail2
        '
        Me.lblClampDetail2.Location = New System.Drawing.Point(515, 108)
        Me.lblClampDetail2.Name = "lblClampDetail2"
        Me.lblClampDetail2.Size = New System.Drawing.Size(140, 23)
        Me.lblClampDetail2.TabIndex = 71
        Me.lblClampDetail2.Text = "MIN REM:"
        '
        'lblClampDetail1
        '
        Me.lblClampDetail1.Location = New System.Drawing.Point(368, 106)
        Me.lblClampDetail1.Name = "lblClampDetail1"
        Me.lblClampDetail1.Size = New System.Drawing.Size(140, 23)
        Me.lblClampDetail1.TabIndex = 70
        Me.lblClampDetail1.Text = "MIN REM:"
        '
        'lblMax7
        '
        Me.lblMax7.Location = New System.Drawing.Point(1245, 87)
        Me.lblMax7.Name = "lblMax7"
        Me.lblMax7.Size = New System.Drawing.Size(140, 23)
        Me.lblMax7.TabIndex = 69
        Me.lblMax7.Text = "MIN REM:"
        '
        'lblMax6
        '
        Me.lblMax6.Location = New System.Drawing.Point(1099, 87)
        Me.lblMax6.Name = "lblMax6"
        Me.lblMax6.Size = New System.Drawing.Size(140, 23)
        Me.lblMax6.TabIndex = 68
        Me.lblMax6.Text = "MIN REM:"
        '
        'lblMax5
        '
        Me.lblMax5.Location = New System.Drawing.Point(953, 87)
        Me.lblMax5.Name = "lblMax5"
        Me.lblMax5.Size = New System.Drawing.Size(140, 23)
        Me.lblMax5.TabIndex = 67
        Me.lblMax5.Text = "MIN REM:"
        '
        'lblMax4
        '
        Me.lblMax4.Location = New System.Drawing.Point(807, 87)
        Me.lblMax4.Name = "lblMax4"
        Me.lblMax4.Size = New System.Drawing.Size(140, 23)
        Me.lblMax4.TabIndex = 66
        Me.lblMax4.Text = "MIN REM:"
        '
        'lblMax3
        '
        Me.lblMax3.Location = New System.Drawing.Point(661, 87)
        Me.lblMax3.Name = "lblMax3"
        Me.lblMax3.Size = New System.Drawing.Size(140, 23)
        Me.lblMax3.TabIndex = 65
        Me.lblMax3.Text = "MIN REM:"
        '
        'lblMax2
        '
        Me.lblMax2.Location = New System.Drawing.Point(515, 87)
        Me.lblMax2.Name = "lblMax2"
        Me.lblMax2.Size = New System.Drawing.Size(140, 23)
        Me.lblMax2.TabIndex = 64
        Me.lblMax2.Text = "MIN REM:"
        '
        'lblMax1
        '
        Me.lblMax1.Location = New System.Drawing.Point(369, 87)
        Me.lblMax1.Name = "lblMax1"
        Me.lblMax1.Size = New System.Drawing.Size(140, 23)
        Me.lblMax1.TabIndex = 63
        Me.lblMax1.Text = "MIN REM:"
        '
        'lblMinRem7
        '
        Me.lblMinRem7.Location = New System.Drawing.Point(1245, 68)
        Me.lblMinRem7.Name = "lblMinRem7"
        Me.lblMinRem7.Size = New System.Drawing.Size(140, 23)
        Me.lblMinRem7.TabIndex = 62
        Me.lblMinRem7.Text = "MIN REM:"
        '
        'lblMinRem6
        '
        Me.lblMinRem6.Location = New System.Drawing.Point(1099, 68)
        Me.lblMinRem6.Name = "lblMinRem6"
        Me.lblMinRem6.Size = New System.Drawing.Size(140, 23)
        Me.lblMinRem6.TabIndex = 61
        Me.lblMinRem6.Text = "MIN REM:"
        '
        'lblMinRem5
        '
        Me.lblMinRem5.Location = New System.Drawing.Point(953, 68)
        Me.lblMinRem5.Name = "lblMinRem5"
        Me.lblMinRem5.Size = New System.Drawing.Size(140, 23)
        Me.lblMinRem5.TabIndex = 60
        Me.lblMinRem5.Text = "MIN REM:"
        '
        'lblMinRem4
        '
        Me.lblMinRem4.Location = New System.Drawing.Point(807, 68)
        Me.lblMinRem4.Name = "lblMinRem4"
        Me.lblMinRem4.Size = New System.Drawing.Size(140, 23)
        Me.lblMinRem4.TabIndex = 59
        Me.lblMinRem4.Text = "MIN REM:"
        '
        'lblMinRem3
        '
        Me.lblMinRem3.Location = New System.Drawing.Point(661, 68)
        Me.lblMinRem3.Name = "lblMinRem3"
        Me.lblMinRem3.Size = New System.Drawing.Size(140, 23)
        Me.lblMinRem3.TabIndex = 58
        Me.lblMinRem3.Text = "MIN REM:"
        '
        'lblMinRem2
        '
        Me.lblMinRem2.Location = New System.Drawing.Point(515, 68)
        Me.lblMinRem2.Name = "lblMinRem2"
        Me.lblMinRem2.Size = New System.Drawing.Size(140, 23)
        Me.lblMinRem2.TabIndex = 57
        Me.lblMinRem2.Text = "MIN REM:"
        '
        'lblMinRem1
        '
        Me.lblMinRem1.Location = New System.Drawing.Point(369, 68)
        Me.lblMinRem1.Name = "lblMinRem1"
        Me.lblMinRem1.Size = New System.Drawing.Size(140, 23)
        Me.lblMinRem1.TabIndex = 56
        Me.lblMinRem1.Text = "MIN REM:"
        '
        'btnClamp7
        '
        Me.btnClamp7.Location = New System.Drawing.Point(1245, 7)
        Me.btnClamp7.Name = "btnClamp7"
        Me.btnClamp7.Size = New System.Drawing.Size(140, 55)
        Me.btnClamp7.TabIndex = 55
        Me.btnClamp7.Text = "Clamp 7"
        '
        'btnClamp6
        '
        Me.btnClamp6.Location = New System.Drawing.Point(1099, 7)
        Me.btnClamp6.Name = "btnClamp6"
        Me.btnClamp6.Size = New System.Drawing.Size(140, 55)
        Me.btnClamp6.TabIndex = 54
        Me.btnClamp6.Text = "Clamp 6"
        '
        'btnClamp5
        '
        Me.btnClamp5.Location = New System.Drawing.Point(953, 7)
        Me.btnClamp5.Name = "btnClamp5"
        Me.btnClamp5.Size = New System.Drawing.Size(140, 55)
        Me.btnClamp5.TabIndex = 53
        Me.btnClamp5.Text = "Clamp 5"
        '
        'btnClamp4
        '
        Me.btnClamp4.Location = New System.Drawing.Point(807, 7)
        Me.btnClamp4.Name = "btnClamp4"
        Me.btnClamp4.Size = New System.Drawing.Size(140, 55)
        Me.btnClamp4.TabIndex = 52
        Me.btnClamp4.Text = "Clamp 4"
        '
        'btnClamp3
        '
        Me.btnClamp3.Location = New System.Drawing.Point(661, 7)
        Me.btnClamp3.Name = "btnClamp3"
        Me.btnClamp3.Size = New System.Drawing.Size(140, 55)
        Me.btnClamp3.TabIndex = 51
        Me.btnClamp3.Text = "Clamp 3"
        '
        'btnClamp2
        '
        Me.btnClamp2.Location = New System.Drawing.Point(515, 7)
        Me.btnClamp2.Name = "btnClamp2"
        Me.btnClamp2.Size = New System.Drawing.Size(140, 55)
        Me.btnClamp2.TabIndex = 50
        Me.btnClamp2.Text = "Clamp 2"
        '
        'btnClamp1
        '
        Me.btnClamp1.Location = New System.Drawing.Point(369, 7)
        Me.btnClamp1.Name = "btnClamp1"
        Me.btnClamp1.Size = New System.Drawing.Size(140, 55)
        Me.btnClamp1.TabIndex = 49
        Me.btnClamp1.Text = "Clamp 1"
        '
        'btnManageClampHours
        '
        Me.btnManageClampHours.Location = New System.Drawing.Point(228, 151)
        Me.btnManageClampHours.Name = "btnManageClampHours"
        Me.btnManageClampHours.Size = New System.Drawing.Size(134, 23)
        Me.btnManageClampHours.TabIndex = 48
        Me.btnManageClampHours.Text = "Manage Clamps Hours"
        Me.btnManageClampHours.Visible = False
        '
        'btnManageClamps
        '
        Me.btnManageClamps.Location = New System.Drawing.Point(116, 151)
        Me.btnManageClamps.Name = "btnManageClamps"
        Me.btnManageClamps.Size = New System.Drawing.Size(112, 23)
        Me.btnManageClamps.TabIndex = 47
        Me.btnManageClamps.Text = "Manage Clamps"
        Me.btnManageClamps.Visible = False
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label4)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lblSelectedAPT_Top)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label29)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label30)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lblSelectedOrders_Top)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lblSelectedDoors_Top)
        Me.UltraPanel1.Location = New System.Drawing.Point(16, 76)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(346, 69)
        Me.UltraPanel1.TabIndex = 46
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(235, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "APT"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSelectedAPT_Top
        '
        Me.lblSelectedAPT_Top.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectedAPT_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSelectedAPT_Top.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedAPT_Top.Location = New System.Drawing.Point(229, 5)
        Me.lblSelectedAPT_Top.Name = "lblSelectedAPT_Top"
        Me.lblSelectedAPT_Top.Size = New System.Drawing.Size(106, 45)
        Me.lblSelectedAPT_Top.TabIndex = 45
        Me.lblSelectedAPT_Top.Text = "0"
        Me.lblSelectedAPT_Top.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(120, 6)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(97, 16)
        Me.Label29.TabIndex = 44
        Me.Label29.Text = "Doors"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(8, 6)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(97, 16)
        Me.Label30.TabIndex = 42
        Me.Label30.Text = "Selected Orders"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSelectedOrders_Top
        '
        Me.lblSelectedOrders_Top.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectedOrders_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSelectedOrders_Top.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedOrders_Top.Location = New System.Drawing.Point(5, 5)
        Me.lblSelectedOrders_Top.Name = "lblSelectedOrders_Top"
        Me.lblSelectedOrders_Top.Size = New System.Drawing.Size(106, 45)
        Me.lblSelectedOrders_Top.TabIndex = 41
        Me.lblSelectedOrders_Top.Text = "0"
        Me.lblSelectedOrders_Top.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblSelectedDoors_Top
        '
        Me.lblSelectedDoors_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSelectedDoors_Top.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedDoors_Top.Location = New System.Drawing.Point(117, 5)
        Me.lblSelectedDoors_Top.Name = "lblSelectedDoors_Top"
        Me.lblSelectedDoors_Top.Size = New System.Drawing.Size(106, 45)
        Me.lblSelectedDoors_Top.TabIndex = 43
        Me.lblSelectedDoors_Top.Text = "0"
        Me.lblSelectedDoors_Top.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.White
        Me.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(136, 38)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(226, 32)
        Me.txtSearch.TabIndex = 45
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.Color.White
        Me.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(136, 0)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(226, 32)
        Me.txtBarcode.TabIndex = 1
        Me.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(25, 38)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(105, 24)
        Me.Label21.TabIndex = 44
        Me.Label21.Text = "Search Here:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'upContainer
        '
        Me.upContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        'upContainer.ClientArea
        '
        Me.upContainer.ClientArea.Controls.Add(Me.upUpperGrid)
        Me.upContainer.Location = New System.Drawing.Point(5, 180)
        Me.upContainer.Name = "upContainer"
        Me.upContainer.Size = New System.Drawing.Size(1563, 677)
        Me.upContainer.TabIndex = 41
        '
        'upUpperGrid
        '
        '
        'upUpperGrid.ClientArea
        '
        Me.upUpperGrid.ClientArea.Controls.Add(Me.ugAssemblyStart)
        Me.upUpperGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upUpperGrid.Location = New System.Drawing.Point(0, 0)
        Me.upUpperGrid.Name = "upUpperGrid"
        Me.upUpperGrid.Size = New System.Drawing.Size(1563, 677)
        Me.upUpperGrid.TabIndex = 40
        '
        'ugAssemblyStart
        '
        Me.ugAssemblyStart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugAssemblyStart.ContextMenuStrip = Me.ContextMenuStrip1
        Appearance46.BackColor = System.Drawing.SystemColors.Window
        Appearance46.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugAssemblyStart.DisplayLayout.Appearance = Appearance46
        Me.ugAssemblyStart.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugAssemblyStart.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugAssemblyStart.DisplayLayout.ColumnChooserEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance47.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance47.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance47.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAssemblyStart.DisplayLayout.GroupByBox.Appearance = Appearance47
        Appearance48.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAssemblyStart.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance48
        Me.ugAssemblyStart.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugAssemblyStart.DisplayLayout.GroupByBox.Hidden = True
        Appearance49.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance49.BackColor2 = System.Drawing.SystemColors.Control
        Appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance49.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAssemblyStart.DisplayLayout.GroupByBox.PromptAppearance = Appearance49
        Me.ugAssemblyStart.DisplayLayout.MaxColScrollRegions = 1
        Me.ugAssemblyStart.DisplayLayout.MaxRowScrollRegions = 1
        Appearance50.BackColor = System.Drawing.SystemColors.Window
        Appearance50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugAssemblyStart.DisplayLayout.Override.ActiveCellAppearance = Appearance50
        Appearance51.BackColor = System.Drawing.SystemColors.Highlight
        Appearance51.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugAssemblyStart.DisplayLayout.Override.ActiveRowAppearance = Appearance51
        Me.ugAssemblyStart.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugAssemblyStart.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugAssemblyStart.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugAssemblyStart.DisplayLayout.Override.AllowMultiCellOperations = CType((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy Or Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders), Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)
        Me.ugAssemblyStart.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugAssemblyStart.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[True]
        Me.ugAssemblyStart.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugAssemblyStart.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugAssemblyStart.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Me.ugAssemblyStart.DisplayLayout.Override.CardAreaAppearance = Appearance52
        Appearance53.BorderColor = System.Drawing.Color.Silver
        Appearance53.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugAssemblyStart.DisplayLayout.Override.CellAppearance = Appearance53
        Me.ugAssemblyStart.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugAssemblyStart.DisplayLayout.Override.CellPadding = 0
        Me.ugAssemblyStart.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.ugAssemblyStart.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance54.BackColor = System.Drawing.SystemColors.Control
        Appearance54.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance54.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance54.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAssemblyStart.DisplayLayout.Override.GroupByRowAppearance = Appearance54
        Appearance55.TextHAlignAsString = "Left"
        Me.ugAssemblyStart.DisplayLayout.Override.HeaderAppearance = Appearance55
        Me.ugAssemblyStart.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugAssemblyStart.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance56.BackColor = System.Drawing.SystemColors.Window
        Appearance56.BorderColor = System.Drawing.Color.Silver
        Me.ugAssemblyStart.DisplayLayout.Override.RowAppearance = Appearance56
        Me.ugAssemblyStart.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugAssemblyStart.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance57.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugAssemblyStart.DisplayLayout.Override.TemplateAddRowAppearance = Appearance57
        Me.ugAssemblyStart.DisplayLayout.Override.TipStyleHeader = Infragistics.Win.UltraWinGrid.TipStyle.Show
        Me.ugAssemblyStart.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugAssemblyStart.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugAssemblyStart.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugAssemblyStart.GesturesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugAssemblyStart.Location = New System.Drawing.Point(3, 3)
        Me.ugAssemblyStart.Name = "ugAssemblyStart"
        Me.ugAssemblyStart.Size = New System.Drawing.Size(1557, 676)
        Me.ugAssemblyStart.TabIndex = 37
        Me.ugAssemblyStart.Text = "UltraGrid1"
        Me.ugAssemblyStart.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Assign Here:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Tomato
        Me.lblMessage.Location = New System.Drawing.Point(367, 5)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(885, 25)
        Me.lblMessage.TabIndex = 4
        '
        'BtnRefresh
        '
        Me.BtnRefresh.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnRefresh.Location = New System.Drawing.Point(13, 151)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(97, 23)
        Me.BtnRefresh.TabIndex = 5
        Me.BtnRefresh.Text = "Refresh"
        Me.BtnRefresh.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(50, 3)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1579, 884)
        Me.TabControl1.TabIndex = 5
        '
        'frmAssemblyStart
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1579, 915)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAssemblyStart"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Kitchen Pro - Assembly Start"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnu_WeeklyLayouts_Doors.ResumeLayout(False)
        Me.mnu_WeeklyLayouts_Cabinets.ResumeLayout(False)
        Me.mnu_WeeklyLayouts_Accessories.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStripLine.ResumeLayout(False)
        Me.mnuPantries.ResumeLayout(False)
        Me.mnu_WeeklyLayouts_LotList.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.mnu_WeeklyLayouts_ChangeOrder.ResumeLayout(False)
        Me.ContextMenuStripLV.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.upServiceCabinets.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        Me.upMainPanel.ClientArea.ResumeLayout(False)
        Me.upMainPanel.ClientArea.PerformLayout()
        Me.upMainPanel.ResumeLayout(False)
        Me.upWeeklyLayouts.ClientArea.ResumeLayout(False)
        Me.upWeeklyLayouts.ClientArea.PerformLayout()
        Me.upWeeklyLayouts.ResumeLayout(False)
        Me.upWeeklyLayouts.PerformLayout()
        CType(Me.uccWeeklyLayoutSiteRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ug_AssemblyStart_AdvancedSearchLotList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.ugPantries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.lvOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ResumeLayout(False)
        Me.upContainer.ClientArea.ResumeLayout(False)
        Me.upContainer.ResumeLayout(False)
        Me.upUpperGrid.ClientArea.ResumeLayout(False)
        Me.upUpperGrid.ResumeLayout(False)
        CType(Me.ugAssemblyStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAssemblyStart_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim BaseRectangle As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim Gradient_Brush As New LinearGradientBrush(BaseRectangle, Color.White, Color.DarkBlue, LinearGradientMode.Vertical) 'Gradient Degree
        e.Graphics.FillRectangle(Gradient_Brush, BaseRectangle)
    End Sub

    Private Sub frmAssemblyStart_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    Private Sub frmAssemblyStart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            FirstLoaded = False
            CheckServiceCabinets()
            uccWeeklyLayoutSiteRequest.Text = Now.Date
            refreshLVReady()
            RefreshClamps()
            CreateLVSelectedTable()
            KPGeneral.SetDefaultGridSettings(ugAssemblyStart)
            'KPGeneral.SetDefaultGridSettings(ugPantries)
            KPGeneral.SetDefaultGridSettings(lvOrders)
            KPGeneral.SetDefaultGridSettings(ug_AssemblyStart_AdvancedSearchLotList)
            FirstLoaded = True
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try

    End Sub

    Private Sub frmAssemblyStart_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        Try
            If KPGeneral.User.UserProfile("MonitorUser") Then
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

    Private Sub AddRowToLVSelected(ByVal MasterNum As String, ByVal Company As String, ByVal Project As String, ByVal Lot As String, ByVal Phase As String,
                                   ByVal ESD As DateTime, ByVal TotalDoors As Integer, ByVal PrintCounter As Integer, ByVal AssignedLine As Integer,
                                   ByVal StartDate As DateTime, ByVal APT As Double, ByVal OnHold As Boolean)
        Dim dr As DataRow
        dr = dsSelectedOrders.Tables(0).NewRow
        dr.Item("MasterNum") = MasterNum
        dr.Item("Company") = Company
        dr.Item("Project") = Project
        dr.Item("Lot") = Lot
        dr.Item("Phase") = Phase
        dr.Item("ESD") = ESD
        dr.Item("TotalDoors") = TotalDoors
        dr.Item("PrintCounter") = PrintCounter
        dr.Item("AssignedLine") = AssignedLine
        dr.Item("StartDate") = StartDate
        dr.Item("APT") = APT
        dr.Item("OnHold") = OnHold
        dsSelectedOrders.Tables(0).Rows.Add(dr)
    End Sub
    Private Sub CheckPlannedStartDate()

    End Sub
    Private Sub ProcessOldBarcode()
        '        Try
        '            lblDate.Text = Now.ToLongDateString

        '            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
        '                e.Handled = True
        '                'Enter Pressed
        '                If Trim(txtBarcode.Text) = Nothing Then
        '                    lblMessage.Text = Nothing
        '                    Exit Sub
        '                End If
        '                'Cancelled Order (Rich Added - 09/06/06)
        '                txtBarcode.Text = KPGeneral.ParseBarcode(txtBarcode.Text)

        '                Dim dsOrderStatus As New DataSet

        '                dsOrderStatus = KPGeneral.WebRef_Local.spKP_OrderStatusByFK(txtBarcode.Text)

        '                If IsDBNull(dsOrderStatus.Tables(0).Rows(0)("AssemblyStartDate")) = False Then
        '                    MsgBox("This order has already been started", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
        '                    txtBarcode.Text = vbNullString
        '                    txtBarcode.Focus()
        '                    Exit Sub
        '                End If

        '                Dim dsCancelOrderCheck As New DataSet
        '                dsCancelOrderCheck = KPGeneral.WebRef_Local.spKP_LotInfoByFK(KPGeneral.ExtractMasterNum(Trim(txtBarcode.Text)))
        '                If dsCancelOrderCheck.Tables(0).Rows.Count > 0 Then
        '                    If dsCancelOrderCheck.Tables(0).Rows(0)("CancelOrder") = True Then
        '                        lblMessage.Text = "Order Cancelled!"
        '                        txtBarcode.Text = vbNullString
        '                        txtBarcode.Focus()
        '                        Exit Sub
        '                    End If
        '                    If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("OrderStatus")) = False Then
        '                        If Trim(dsCancelOrderCheck.Tables(0).Rows(0)("OrderStatus")) = "Pending" Then
        '                            lblMessage.Text = dsCancelOrderCheck.Tables(0).Rows(0)("MasterNum") & "Order Pending!"
        '                            MessageBox.Show("Order Is Pending, there is currently an issue being adressed by the accounting department. Continue with the production of the order and if you have any furthur questions contact your Administrator.")
        '                        End If
        '                    End If

        '                    Dim EDate As Date
        '                    EDate = Now.Date.AddDays(7)
        '                    If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("SiteRequest")) = False And IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("shipped")) = False Then
        '                        If dsCancelOrderCheck.Tables(0).Rows(0)("SiteRequest") > dsCancelOrderCheck.Tables(0).Rows(0)("shipped") Then
        '                            If dsCancelOrderCheck.Tables(0).Rows(0)("SiteRequest") > EDate Then
        '                                If MsgBox("This order has a site request date greater than 7 days. Do you still want to print labels and move the order to Assembly Start?", MsgBoxStyle.YesNo, "WARNING!! WARNING!! WARNING!!") = MsgBoxResult.No Then
        '                                    txtBarcode.Text = vbNullString
        '                                    txtBarcode.Focus()
        '                                    Exit Sub
        '                                End If
        '                            End If
        '                        Else
        '                            If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("shipped")) = False Then
        '                                If dsCancelOrderCheck.Tables(0).Rows(0)("shipped") > EDate Then
        '                                    If MsgBox("This order has a site request date greater than 7 days. Do you still want to print labels and move the order to Assembly Start?", MsgBoxStyle.YesNo, "WARNING!! WARNING!! WARNING!!") = MsgBoxResult.No Then
        '                                        txtBarcode.Text = vbNullString
        '                                        txtBarcode.Focus()
        '                                        Exit Sub
        '                                    End If
        '                                End If
        '                            End If
        '                        End If
        '                    Else

        '                        If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("shipped")) = False Then
        '                            If dsCancelOrderCheck.Tables(0).Rows(0)("shipped") > EDate Then
        '                                If MsgBox("This order has a site request date greater than 7 days. Do you still want to print labels and move the order to Assembly Start?", MsgBoxStyle.YesNo, "WARNING!! WARNING!! WARNING!!") = MsgBoxResult.No Then
        '                                    txtBarcode.Text = vbNullString
        '                                    txtBarcode.Focus()
        '                                    Exit Sub
        '                                End If
        '                            End If
        '                        End If

        '                    End If
        '                    Dim PGroupCheck As Boolean = False
        '                    If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("ProductionGroup")) = False Then
        '                        If dsCancelOrderCheck.Tables(0).Rows(0)("ProductionGroup").ToString.Length > 0 Then
        '                            PGroupCheck = False
        '                        Else
        '                            PGroupCheck = True
        '                        End If
        '                    Else
        '                        PGroupCheck = True
        '                    End If

        '                    If PGroupCheck = True Then
        '                        frmAssemblyStartProductionGroup.MasterNum = dsCancelOrderCheck.Tables(0).Rows(0)("MasterNum")
        '                        Dim dResult As DialogResult
        '                        dResult = frmAssemblyStartProductionGroup.ShowDialog
        '                        If dResult = Windows.Forms.DialogResult.OK Then

        '                        Else
        '                            txtBarcode.Text = vbNullString
        '                            txtBarcode.Focus()
        '                            Exit Sub
        '                        End If
        '                    End If
        '                Else
        '                    lblMessage.Text = "Input is not a VALID FK-NUMBER"
        '                    txtBarcode.Text = vbNullString
        '                    txtBarcode.Focus()
        '                    Exit Sub
        '                End If
        '                'End Cancelled Order
        '                Dim x, y As Integer
        '                Dim selection As Boolean
        '                selection = False


        '                For x = 0 To ugAssemblyStart.Rows.Count - 1
        '                    If Trim(ugAssemblyStart.Rows(x).Cells("MasterNum").Text) = Trim(txtBarcode.Text) Then
        '                        ugAssemblyStart.Rows(x).Selected = True
        '                        'lvReady.Items(x).EnsureVisible()
        '                        selection = True
        '                        For y = 0 To LVSelected.Rows.Count - 1
        '                            If Trim(LVSelected.Rows(y).Cells("MasterNum").Text) = Trim(ugAssemblyStart.Rows(x).Cells("MasterNum").Text) Then
        '                                LVSelected.Rows(y).Selected = True
        '                                LVSelected.Rows(y).Activate()
        '                                'LVSelected.Items(y).EnsureVisible()
        '                                MessageBox.Show("Order Already Selected")
        '                                txtBarcode.Text = vbNullString
        '                                txtBarcode.Focus()

        '                                'selection = False
        '                                'Exit For
        '                                Exit Sub
        '                            End If
        '                        Next
        '                        Exit For
        '                    End If
        '                Next


        '                Dim ESD As DateTime

        '                If IsDBNull(ugAssemblyStart.Rows(x).Cells("ESD")) Or ugAssemblyStart.Rows(x).Cells("ESD").Text = "" Then
        '                    ESD = Now
        '                Else
        '                    ESD = ugAssemblyStart.Rows(x).Cells("ESD").Text

        '                End If

        '                If selection = True Then


        '                    If Trim(ugAssemblyStart.Rows(x).Cells("Raw").Text) = "N" Or Trim(ugAssemblyStart.Rows(x).Cells("Painted").Text) = "N" Then
        '                        Dim result As Integer
        '                        result = MessageBox.Show("Doors are not Ready! Are you sure you would like to proceed?", "WARNING - Doors Not Ready", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '                        If result = 6 Then
        '                            Dim d, TDoors As Integer

        '                            Dim APT, TAPT As Double

        '                            If Trim(ugAssemblyStart.Rows(x).Cells("TotalDoors").Text) = "" Then
        '                                d = Int(LblDoorCount.Text) + 0 'do nothing
        '                                TDoors = 0
        '                            Else
        '                                d = Int(LblDoorCount.Text) + Int(Trim(ugAssemblyStart.Rows(x).Cells("TotalDoors").Text))
        '                                TDoors = Trim(ugAssemblyStart.Rows(x).Cells("TotalDoors").Text)
        '                            End If

        '                            LblDoorCount.Text = d

        '                            If IsDBNull(ugAssemblyStart.Rows(x).Cells("APT").Value) = False Then
        '                                APT = ugAssemblyStart.Rows(x).Cells("APT").Text
        '                                TAPT = Convert.ToDouble(lblAPTCount.Text) + Convert.ToDouble(ugAssemblyStart.Rows(x).Cells("APT").Text)
        '                            Else
        '                                TAPT = Convert.ToDouble(lblAPTCount.Text)
        '                                APT = "0"
        '                            End If

        '                            lblAPTCount.Text = TAPT

        '                            CheckPlannedStartDate()

        '                            AddRowToLVSelected(Trim(ugAssemblyStart.Rows(x).Cells("MasterNum").Text), Trim(ugAssemblyStart.Rows(x).Cells("Company").Text), Trim(ugAssemblyStart.Rows(x).Cells("Project").Text),
        '                                               Trim(ugAssemblyStart.Rows(x).Cells("Lot").Text), Trim(ugAssemblyStart.Rows(x).Cells("Phase").Text), Trim(ESD),
        '                                               TDoors, Trim(ugAssemblyStart.Rows(x).Cells("PrintCounter").Text), Trim(ugAssemblyStart.Rows(x).Cells("AssignedLine").Text), ucStartDate.Text, APT,
        '                                                ugAssemblyStart.Rows(x).Cells("OnHold").Value)

        '                        End If
        '                    ElseIf Trim(ugAssemblyStart.Rows(x).Cells("RAW").Text) = "Y" And Trim(ugAssemblyStart.Rows(x).Cells("Painted").Text) = "Y" Then

        '                        LblSelectedOrders.Text = LVSelected.Rows.Count

        '                        Dim d, TDoors As Integer
        '                        If Trim(ugAssemblyStart.Rows(x).Cells("TotalDoors").Text) = "" Then
        '                            d = Int(LblDoorCount.Text) + 0 'do nothing
        '                            TDoors = 0
        '                        Else
        '                            d = Int(LblDoorCount.Text) + Int(Trim(ugAssemblyStart.Rows(x).Cells("TotalDoors").Text))
        '                            TDoors = Trim(ugAssemblyStart.Rows(x).Cells("TotalDoors").Text)
        '                        End If

        '                        LblDoorCount.Text = d
        '                        Dim APT, TAPT As Double
        '                        If IsDBNull(ugAssemblyStart.Rows(x).Cells("APT").Value) = False Then
        '                            APT = ugAssemblyStart.Rows(x).Cells("APT").Text
        '                            TAPT = Convert.ToDouble(lblAPTCount.Text) + Convert.ToDouble(ugAssemblyStart.Rows(x).Cells("APT").Text)
        '                        Else
        '                            APT = "0"
        '                            TAPT = Convert.ToDouble(lblAPTCount.Text)
        '                        End If

        '                        lblAPTCount.Text = TAPT

        '                        CheckPlannedStartDate()

        '                        AddRowToLVSelected(Trim(ugAssemblyStart.Rows(x).Cells("MasterNum").Text), Trim(ugAssemblyStart.Rows(x).Cells("Company").Text), Trim(ugAssemblyStart.Rows(x).Cells("Project").Text),
        '                   Trim(ugAssemblyStart.Rows(x).Cells("Lot").Text), Trim(ugAssemblyStart.Rows(x).Cells("Phase").Text), Trim(ESD),
        '                   TDoors, Trim(ugAssemblyStart.Rows(x).Cells("PrintCounter").Text), Trim(ugAssemblyStart.Rows(x).Cells("AssignedLine").Text), ucStartDate.Text, APT,
        '                    ugAssemblyStart.Rows(x).Cells("OnHold").Value)
        '                    End If
        '                Else
        '                    Dim TDoors As Integer
        '                    lblMessage.Text = "Order NOT On List"

        '                    LblSelectedOrders.Text = LVSelected.Rows.Count


        '                    TDoors = "0"
        '                    Dim APT, TAPT As Double
        '                    If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("APT")) = False Then
        '                        APT = dsCancelOrderCheck.Tables(0).Rows(0)("APT")
        '                        TAPT = Convert.ToDouble(lblAPTCount.Text) + Convert.ToDouble(ugAssemblyStart.Rows(x).Cells("APT").Text)
        '                    Else
        '                        APT = "0"
        '                        TAPT = Convert.ToDouble(lblAPTCount.Text)
        '                    End If

        '                    lblAPTCount.Text = TAPT

        '                    CheckPlannedStartDate()

        '                    AddRowToLVSelected(Trim(ugAssemblyStart.Rows(x).Cells("MasterNum").Text), Trim(ugAssemblyStart.Rows(x).Cells("Company").Text), Trim(ugAssemblyStart.Rows(x).Cells("Project").Text),
        'Trim(ugAssemblyStart.Rows(x).Cells("Lot").Text), Trim(ugAssemblyStart.Rows(x).Cells("Phase").Text), Trim(ESD),
        'TDoors, Trim(ugAssemblyStart.Rows(x).Cells("PrintCounter").Text), Trim(ugAssemblyStart.Rows(x).Cells("AssignedLine").Text), ucStartDate.Text, APT,
        'ugAssemblyStart.Rows(x).Cells("OnHold").Value)
        '                End If


        '                txtBarcode.Text = vbNullString
        '                txtBarcode.Focus()

        '                LblSelectedOrders.Text = LVSelected.Rows.Count
        '                LVSelected.ContextMenuStrip = ContextMenuStripLine
        '            End If
        '        Catch ex As Exception
        '            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        '        End Try

    End Sub
    Sub txtBarcode_enter(ByVal o As [Object], ByVal e As KeyPressEventArgs) Handles txtBarcode.KeyPress

    End Sub
    Private Sub CreateLVSelectedTable()
        dsSelectedOrders.Tables.Add()
        dsSelectedOrders.Tables(0).Columns.Add("MasterNum")
        dsSelectedOrders.Tables(0).Columns.Add("Company")
        dsSelectedOrders.Tables(0).Columns.Add("Project")
        dsSelectedOrders.Tables(0).Columns.Add("Lot")
        dsSelectedOrders.Tables(0).Columns.Add("Phase")
        dsSelectedOrders.Tables(0).Columns.Add("ESD")
        dsSelectedOrders.Tables(0).Columns.Add("TotalDoors")
        dsSelectedOrders.Tables(0).Columns.Add("PrintCounter")
        dsSelectedOrders.Tables(0).Columns.Add("AssignedLine")
        dsSelectedOrders.Tables(0).Columns.Add("StartDate")
        dsSelectedOrders.Tables(0).Columns.Add("APT", System.Type.GetType("System.Double"))
        dsSelectedOrders.Tables(0).Columns.Add("Priority")
        dsSelectedOrders.Tables(0).Columns.Add("OnHold", System.Type.GetType("System.Boolean"))
    End Sub
    Private Sub refreshList()
        Try
            txtCount.Text = 0
            Dim ds As New DataSet
            'webservice for list 
            ds = KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_TodaysOrders()

            lvOrders.DataSource = ds

            If lvOrders.DisplayLayout.Bands(0).Columns.Count > 0 Then
                lvOrders.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
                lvOrders.DisplayLayout.Bands(0).Columns("CSID1").Hidden = True
                lvOrders.DisplayLayout.Bands(0).Columns("PH").Hidden = True
                lvOrders.DisplayLayout.Bands(0).Columns("BoxAssemblyStartDate").Hidden = True

                lvOrders.DisplayLayout.Bands(0).Columns("Painted").Header.Caption = "P"
                lvOrders.DisplayLayout.Bands(0).Columns("HingeDate").Header.Caption = "H"
                lvOrders.DisplayLayout.Bands(0).Columns("Raw").Header.Caption = "R"
                lvOrders.DisplayLayout.Bands(0).Columns("PickedUppers").Header.Caption = "PU"
                lvOrders.DisplayLayout.Bands(0).Columns("PickedBases").Header.Caption = "PB"
                lvOrders.DisplayLayout.Bands(0).Columns("AssignedLine").Header.Caption = "Line"
                lvOrders.DisplayLayout.Bands(0).Columns("AssemblyPlannedTime").Header.Caption = "Planned Time"
                lvOrders.DisplayLayout.Bands(0).Columns("ProductionGroup").Header.Caption = "PG"
                lvOrders.DisplayLayout.Bands(0).Columns("MASTER_NO").Header.Caption = "Order"

                lvOrders.DisplayLayout.Bands(0).Columns("Raw").Width = 50
                lvOrders.DisplayLayout.Bands(0).Columns("HingeDate").Width = 50
                lvOrders.DisplayLayout.Bands(0).Columns("Painted").Width = 50
                lvOrders.DisplayLayout.Bands(0).Columns("PickedUppers").Width = 50
                lvOrders.DisplayLayout.Bands(0).Columns("PickedBases").Width = 50

                lvOrders.DisplayLayout.Bands(0).Columns("SCAN_TIME").Format = "hh:mm tt"

                txtCount.Text = lvOrders.Rows.Count

                Dim x As Integer
                For x = 0 To lvOrders.Rows.Count - 1
                    If IsDBNull(lvOrders.Rows(x).Cells("OnHold").Value) = False Then
                        If lvOrders.Rows(x).Cells("OnHold").Value = True Then
                            lvOrders.Rows(x).Appearance.BackColor = Color.FromName(StatusColours.OnHold_BackColour)
                            lvOrders.Rows(x).Appearance.ForeColor = Color.FromName(StatusColours.OnHold_ForeColour)
                        End If
                    End If

                    If IsDBNull(lvOrders.Rows(x).Cells("Painted").Value) = False Then
                        lvOrders.Rows(x).Cells("Painted").Appearance.ForeColor = Color.YellowGreen
                        lvOrders.Rows(x).Cells("Painted").Appearance.BackColor = Color.YellowGreen
                    Else
                        lvOrders.Rows(x).Cells("Painted").Appearance.ForeColor = Color.Tomato
                        lvOrders.Rows(x).Cells("Painted").Appearance.BackColor = Color.Tomato
                    End If

                    If IsDBNull(lvOrders.Rows(x).Cells("Raw").Value) = False Then
                        lvOrders.Rows(x).Cells("Raw").Appearance.ForeColor = Color.YellowGreen
                        lvOrders.Rows(x).Cells("Raw").Appearance.BackColor = Color.YellowGreen
                    Else
                        lvOrders.Rows(x).Cells("Raw").Appearance.ForeColor = Color.Tomato
                        lvOrders.Rows(x).Cells("Raw").Appearance.BackColor = Color.Tomato
                    End If

                    If IsDBNull(lvOrders.Rows(x).Cells("HingeDate").Value) = False Then
                        lvOrders.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
                        lvOrders.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                    Else
                        lvOrders.Rows(x).Cells("HingeDate").Appearance.ForeColor = Color.Tomato
                        lvOrders.Rows(x).Cells("HingeDate").Appearance.BackColor = Color.Tomato
                    End If

                    If IsDBNull(lvOrders.Rows(x).Cells("PickedUppers").Value) = False Then
                        lvOrders.Rows(x).Cells("PickedUppers").Appearance.ForeColor = Color.YellowGreen
                        lvOrders.Rows(x).Cells("PickedUppers").Appearance.BackColor = Color.YellowGreen
                    Else
                        lvOrders.Rows(x).Cells("PickedUppers").Appearance.ForeColor = Color.Tomato
                        lvOrders.Rows(x).Cells("PickedUppers").Appearance.BackColor = Color.Tomato
                    End If

                    If IsDBNull(lvOrders.Rows(x).Cells("PickedBases").Value) = False Then
                        lvOrders.Rows(x).Cells("PickedBases").Appearance.ForeColor = Color.YellowGreen
                        lvOrders.Rows(x).Cells("PickedBases").Appearance.BackColor = Color.YellowGreen
                    Else
                        lvOrders.Rows(x).Cells("PickedBases").Appearance.ForeColor = Color.Tomato
                        lvOrders.Rows(x).Cells("PickedBases").Appearance.BackColor = Color.Tomato
                    End If
                Next
            End If
            KPGeneral.RefreshGridFromLayout(Me.lvOrders, Me.GetType.Name)

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Public Function isOdd(ByVal lngNumber As Long) As Boolean
        Dim blnOdd As Boolean = CLng(lngNumber) And 1
        Return blnOdd
    End Function

    Private Sub refreshLVReady()
        Try
            Dim ds As New DataSet
            'webservice for list 
            ds = KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_ReadyOrders("all")

            ds.Tables(0).Columns.Add("isSelected", System.Type.GetType("System.Boolean"))

            ugAssemblyStart.DataSource = ds

            Dim cCount As Integer

            For cCount = 0 To ugAssemblyStart.DisplayLayout.Bands(0).Columns.Count - 1
                If ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key = "isSelected" Then
                    ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).CellClickAction = CellClickAction.Edit
                Else
                    ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
                    ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).CellClickAction = CellClickAction.RowSelect
                End If

                If ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "masternum" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "company" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "project" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "lot" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "totaldoors" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "raw" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "painted" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "hingedate" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "ncomment" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "datediff" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "productiongroup" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "siterequest" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "assemblyplannedtime" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "classificationlevel" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "sc" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "c" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "v" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "f" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "w" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "p" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "s" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "doorspickeddate" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "dbox" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "dloc" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "db" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "driver" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "totalcabinets" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "cabinetlabelprinted" Or
                        ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Key.ToLower = "isselected" Then
                    ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Hidden = False
                Else
                    ugAssemblyStart.DisplayLayout.Bands(0).Columns(cCount).Hidden = True
                End If
            Next

            ugAssemblyStart.DisplayLayout.Bands(0).Columns("raw").Header.Caption = "R"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("hingedate").Header.Caption = "H"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("painted").Header.Caption = "F"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("classificationlevel").Header.Caption = "Class"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("productiongroup").Header.Caption = "PG"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("datediff").Header.Caption = "Days"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("totaldoors").Header.Caption = "Doors"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("ncomment").Header.Caption = "Comment"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("cabinetlabelprinted").Header.Caption = "CLP"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("assemblyplannedtime").Header.Caption = "APT"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("siterequest").Header.Caption = "SR"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("TotalCabinets").Header.Caption = "Cabs"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("DoorsPickedDate").Header.Caption = "DP"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("F").Header.Caption = "L"
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("SC").Header.Caption = "SC"

            ugAssemblyStart.DisplayLayout.Bands(0).Columns("painted").Width = 40
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("hingedate").Width = 40
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("raw").Width = 40
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("sc").Width = 40
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("c").Width = 40
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("v").Width = 40
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("f").Width = 40
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("w").Width = 40
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("p").Width = 40
            ugAssemblyStart.DisplayLayout.Bands(0).Columns("s").Width = 40

            KPGeneral.RefreshGridFromLayout(ugAssemblyStart, Me.GetType.Name)

            Dim x As Integer
            For x = 0 To ugAssemblyStart.Rows.Count - 1
                ugAssemblyStart.Rows(x).Cells("isSelected").Value = False

                ColourRows(ugAssemblyStart, x)
            Next
            ugAssemblyStart.DisplayLayout.Override.FilterUIProvider = UltraGridFilterUIProvider1
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub

    Private Sub ColourRows(ByVal uGrid As UltraGrid, ByVal RowIndex As Integer)
        uGrid.Rows(RowIndex).Appearance.BackColor = Color.White
        uGrid.Rows(RowIndex).Appearance.ForeColor = Color.Black

        If uGrid.Rows(RowIndex).Cells("isSelected").Value = True Then
            uGrid.Rows(RowIndex).Appearance.BackColor = SystemColors.Highlight
            uGrid.Rows(RowIndex).Appearance.ForeColor = SystemColors.HighlightText
        Else
            If IsDBNull(uGrid.Rows(RowIndex).Cells("OnHold").Value) = False Then
                If uGrid.Rows(RowIndex).Cells("OnHold").Value = True Then
                    uGrid.Rows(RowIndex).Appearance.BackColor = Color.FromName(StatusColours.OnHold_BackColour)
                    uGrid.Rows(RowIndex).Appearance.ForeColor = Color.FromName(StatusColours.OnHold_ForeColour)
                End If
            End If

            If IsDBNull(uGrid.Rows(RowIndex).Cells("Raw").Value) Then
                uGrid.Rows(RowIndex).Cells("Raw").Value = "Y"
                uGrid.Rows(RowIndex).Cells("Raw").Appearance.BackColor = Color.YellowGreen
                uGrid.Rows(RowIndex).Cells("Raw").Appearance.ForeColor = Color.YellowGreen
                '.Items(i).SubItems.Add("Y", color.yellowgreen, color.yellowgreen, Font)
            Else
                uGrid.Rows(RowIndex).Cells("Raw").Value = "N"
                uGrid.Rows(RowIndex).Cells("Raw").Appearance.BackColor = Color.Tomato
                uGrid.Rows(RowIndex).Cells("Raw").Appearance.ForeColor = Color.Tomato
                '.Items(i).SubItems.Add("N", Color.Tomato, Color.Tomato, Font)
            End If
            If IsDBNull(uGrid.Rows(RowIndex).Cells("Painted").Value) Then
                uGrid.Rows(RowIndex).Cells("Painted").Value = "Y"
                uGrid.Rows(RowIndex).Cells("Painted").Appearance.BackColor = Color.YellowGreen
                uGrid.Rows(RowIndex).Cells("Painted").Appearance.ForeColor = Color.YellowGreen
                '.Items(i).SubItems.Add("Y", color.yellowgreen, color.yellowgreen, Font)
            Else
                uGrid.Rows(RowIndex).Cells("Painted").Value = "N"
                uGrid.Rows(RowIndex).Cells("Painted").Appearance.BackColor = Color.Tomato
                uGrid.Rows(RowIndex).Cells("Painted").Appearance.ForeColor = Color.Tomato
            End If
            If IsDBNull(uGrid.Rows(RowIndex).Cells("HingeDate").Value) = False Then
                uGrid.Rows(RowIndex).Cells("HingeDate").Value = "Y"
                uGrid.Rows(RowIndex).Cells("HingeDate").Appearance.BackColor = Color.YellowGreen
                uGrid.Rows(RowIndex).Cells("HingeDate").Appearance.ForeColor = Color.YellowGreen
                '.Items(i).SubItems.Add("Y", color.yellowgreen, color.yellowgreen, Font)
            Else
                uGrid.Rows(RowIndex).Cells("HingeDate").Value = "N"
                uGrid.Rows(RowIndex).Cells("HingeDate").Appearance.BackColor = Color.Tomato
                uGrid.Rows(RowIndex).Cells("HingeDate").Appearance.ForeColor = Color.Tomato
            End If

            If uGrid.Rows(RowIndex).Cells("DoorsPickedDate").Text <> Nothing Then
                '                ugReady.Rows(x).Cells("HingeDate").Value = "Y"
                uGrid.Rows(RowIndex).Cells("DoorsPickedDate").Appearance.BackColor = Color.YellowGreen
                uGrid.Rows(RowIndex).Cells("DoorsPickedDate").Appearance.ForeColor = Color.YellowGreen
            Else
                '  ugReady.Rows(x).Cells("HingeDate").Value = "N"
                uGrid.Rows(RowIndex).Cells("DoorsPickedDate").Appearance.BackColor = Color.Tomato
                uGrid.Rows(RowIndex).Cells("DoorsPickedDate").Appearance.ForeColor = Color.Tomato
            End If

            If IsDBNull(uGrid.Rows(RowIndex).Cells("V").Value) = False Then
                If uGrid.Rows(RowIndex).Cells("V").Value = -1 Then
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "Y"
                    uGrid.Rows(RowIndex).Cells("V").Value = DBNull.Value
                    uGrid.Rows(RowIndex).Cells("V").Appearance.BackColor = Color.White
                    uGrid.Rows(RowIndex).Cells("V").Appearance.ForeColor = Color.White
                ElseIf uGrid.Rows(RowIndex).Cells("V").Value > 0 Then
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "N"
                    uGrid.Rows(RowIndex).Cells("V").Appearance.BackColor = Color.Tomato
                    uGrid.Rows(RowIndex).Cells("V").Appearance.ForeColor = Color.Black
                Else
                    uGrid.Rows(RowIndex).Cells("V").Appearance.BackColor = Color.YellowGreen
                    uGrid.Rows(RowIndex).Cells("V").Appearance.ForeColor = Color.Black
                End If
            Else
                uGrid.Rows(RowIndex).Cells("V").Appearance.BackColor = Color.White
                uGrid.Rows(RowIndex).Cells("V").Appearance.ForeColor = Color.White
            End If

            If IsDBNull(uGrid.Rows(RowIndex).Cells("C").Value) = False Then
                If uGrid.Rows(RowIndex).Cells("C").Value = -1 Then
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "Y"
                    uGrid.Rows(RowIndex).Cells("C").Value = DBNull.Value
                    uGrid.Rows(RowIndex).Cells("C").Appearance.BackColor = Color.White
                    uGrid.Rows(RowIndex).Cells("C").Appearance.ForeColor = Color.White
                ElseIf uGrid.Rows(RowIndex).Cells("C").Value > 0 Then
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "N"
                    uGrid.Rows(RowIndex).Cells("C").Appearance.BackColor = Color.Tomato
                    uGrid.Rows(RowIndex).Cells("C").Appearance.ForeColor = Color.Black
                Else
                    uGrid.Rows(RowIndex).Cells("C").Appearance.BackColor = Color.YellowGreen
                    uGrid.Rows(RowIndex).Cells("C").Appearance.ForeColor = Color.Black
                End If
            Else
                uGrid.Rows(RowIndex).Cells("C").Appearance.BackColor = Color.White
                uGrid.Rows(RowIndex).Cells("C").Appearance.ForeColor = Color.White
            End If

            If IsDBNull(uGrid.Rows(RowIndex).Cells("F").Value) = False Then
                If uGrid.Rows(RowIndex).Cells("F").Value = -1 Then
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "Y"
                    uGrid.Rows(RowIndex).Cells("F").Value = DBNull.Value
                    uGrid.Rows(RowIndex).Cells("F").Appearance.BackColor = Color.White
                    uGrid.Rows(RowIndex).Cells("F").Appearance.ForeColor = Color.White
                ElseIf uGrid.Rows(RowIndex).Cells("F").Value > 0 Then
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "N"
                    uGrid.Rows(RowIndex).Cells("F").Appearance.BackColor = Color.Tomato
                    uGrid.Rows(RowIndex).Cells("F").Appearance.ForeColor = Color.Black
                Else
                    uGrid.Rows(RowIndex).Cells("F").Appearance.BackColor = Color.YellowGreen
                    uGrid.Rows(RowIndex).Cells("F").Appearance.ForeColor = Color.Black
                End If
            Else
                uGrid.Rows(RowIndex).Cells("F").Appearance.BackColor = Color.White
                uGrid.Rows(RowIndex).Cells("F").Appearance.ForeColor = Color.White
            End If

            If IsDBNull(uGrid.Rows(RowIndex).Cells("W").Value) = False Then
                If uGrid.Rows(RowIndex).Cells("W").Value = -1 Then
                    uGrid.Rows(RowIndex).Cells("W").Value = DBNull.Value
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "Y"
                    uGrid.Rows(RowIndex).Cells("W").Appearance.BackColor = Color.White
                    uGrid.Rows(RowIndex).Cells("W").Appearance.ForeColor = Color.White
                ElseIf uGrid.Rows(RowIndex).Cells("W").Value > 0 Then
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "N"
                    uGrid.Rows(RowIndex).Cells("W").Appearance.BackColor = Color.Tomato
                    uGrid.Rows(RowIndex).Cells("W").Appearance.ForeColor = Color.Black
                Else
                    uGrid.Rows(RowIndex).Cells("W").Appearance.BackColor = Color.YellowGreen
                    uGrid.Rows(RowIndex).Cells("W").Appearance.ForeColor = Color.Black
                End If
            Else
                uGrid.Rows(RowIndex).Cells("W").Appearance.BackColor = Color.White
                uGrid.Rows(RowIndex).Cells("W").Appearance.ForeColor = Color.White
            End If

            If IsDBNull(uGrid.Rows(RowIndex).Cells("P").Value) = False Then
                If uGrid.Rows(RowIndex).Cells("P").Value = -1 Then
                    uGrid.Rows(RowIndex).Cells("P").Value = DBNull.Value
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "Y"
                    uGrid.Rows(RowIndex).Cells("P").Appearance.BackColor = Color.White
                    uGrid.Rows(RowIndex).Cells("P").Appearance.ForeColor = Color.White
                ElseIf uGrid.Rows(RowIndex).Cells("P").Value > 0 Then
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "N"
                    uGrid.Rows(RowIndex).Cells("P").Appearance.BackColor = Color.Tomato
                    uGrid.Rows(RowIndex).Cells("P").Appearance.ForeColor = Color.Black
                Else
                    uGrid.Rows(RowIndex).Cells("P").Appearance.BackColor = Color.YellowGreen
                    uGrid.Rows(RowIndex).Cells("P").Appearance.ForeColor = Color.Black
                End If
            Else
                uGrid.Rows(RowIndex).Cells("P").Appearance.BackColor = Color.White
                uGrid.Rows(RowIndex).Cells("P").Appearance.ForeColor = Color.White
            End If

            If IsDBNull(uGrid.Rows(RowIndex).Cells("S").Value) = False Then
                If uGrid.Rows(RowIndex).Cells("S").Value = -1 Then
                    uGrid.Rows(RowIndex).Cells("S").Value = DBNull.Value
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "Y"
                    uGrid.Rows(RowIndex).Cells("S").Appearance.BackColor = Color.White
                    uGrid.Rows(RowIndex).Cells("S").Appearance.ForeColor = Color.White
                ElseIf uGrid.Rows(RowIndex).Cells("S").Value > 0 Then
                    ' lvready.Rows(x).Cells("CabinetsCompleteDate").Value = "N"
                    uGrid.Rows(RowIndex).Cells("S").Appearance.BackColor = Color.Tomato
                    uGrid.Rows(RowIndex).Cells("S").Appearance.ForeColor = Color.Black
                Else
                    uGrid.Rows(RowIndex).Cells("S").Appearance.BackColor = Color.YellowGreen
                    uGrid.Rows(RowIndex).Cells("S").Appearance.ForeColor = Color.Black
                End If
            Else
                uGrid.Rows(RowIndex).Cells("S").Appearance.BackColor = Color.White
                uGrid.Rows(RowIndex).Cells("S").Appearance.ForeColor = Color.White
            End If
        End If
    End Sub
    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        refreshLVReady()
        RefreshClamps()

    End Sub

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dsSelectedOrders.Tables(0).Clear()
    End Sub

    Private Sub AssignLineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssignLineToolStripMenuItem.Click

    End Sub

    Private Sub AssignLine1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssignLine1ToolStripMenuItem.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(lvOrders.Selected.Rows(x).Cells("CSID").Text, 1)

                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If

    End Sub

    Private Sub AssignLine2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssignLine2ToolStripMenuItem.Click

        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(lvOrders.Selected.Rows(x).Cells("CSID").Text, 2)
                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If

    End Sub

    Private Sub AssignLine3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssignLine3ToolStripMenuItem.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(lvOrders.Selected.Rows(x).Cells("CSID").Text, 3)

                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If

    End Sub
    'Private Sub SendPanelEmails(ByVal CSID As Integer)
    '    Dim ds As New DataSet
    '    Dim dsLotInfo As New DataSet

    '    ds = KPGeneral.WebRef_Local.usp_GetAssemblyStartPanelEmailCount(CSID)
    '    dsLotInfo = KPGeneral.WebRef_Local.spKP_LotInfoByCSID(CSID)

    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Dim RawNeeded As Integer = 0
    '        Dim PaintNeeded As Integer = 0

    '        If IsDBNull(ds.Tables(0).Rows(0)("RawPanelCount")) = False Then
    '            RawNeeded = ds.Tables(0).Rows(0)("RawPanelCount")
    '        End If

    '        If IsDBNull(ds.Tables(0).Rows(0)("PaintPanelCount")) = False Then
    '            PaintNeeded = ds.Tables(0).Rows(0)("PaintPanelCount")
    '        End If


    '        Dim MasterNum As String = dsLotInfo.Tables(0).Rows(0)("MasterNum")

    '        Dim EBody, Subject As String

    '        If RawNeeded > 0 Then
    '            Subject = "Panels Needed - " & MasterNum

    '            EBody = "The order " & MasterNum & " has been marked as Assembly Start and there are panels needed that aren't complete yet.  Please look into this at your earliest convenience."

    '            Dim dsRequestEmails As New DataSet
    '            dsRequestEmails = KPGeneral.WebRef_Local.usp_GetRequestEmailsByRequestTypeAndCompany("Assembly Start - Panels Raw", "Frendel")

    '            If dsRequestEmails.Tables(0).Rows.Count > 0 Then
    '                Dim Message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(KPGeneral.User.UserProfile("UserLoginName").ToString & "@frendel.com", dsRequestEmails.Tables(0).Rows(0)("EmailAddress"))

    '                If dsRequestEmails.Tables(0).Rows.Count > 1 Then
    '                    Dim y As Integer
    '                    For y = 1 To dsRequestEmails.Tables(0).Rows.Count - 1
    '                        Message.CC.Add(dsRequestEmails.Tables(0).Rows(y)("EmailAddress"))
    '                    Next
    '                End If

    '                Message.IsBodyHtml = True

    '                Message.Subject = Subject
    '                Message.Body = EBody

    '                Try
    '                    Dim SmtpNewClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()
    '                    SmtpNewClient.Host = "mail.frendel.com"
    '                    'SmtpNewClient.Credentials = New System.Net.NetworkCredential("measuring@frendel.com", "onsite")
    '                    SmtpNewClient.Send(Message)

    '                Catch ehttp As System.Net.WebException
    '                    Console.WriteLine("0", ehttp.Message)
    '                    Console.WriteLine("Here is the full error message")
    '                    Console.Write("0", ehttp.ToString())
    '                End Try
    '            End If
    '        End If

    '        If PaintNeeded > 0 Then
    '            Subject = "Panels Needed - " & MasterNum

    '            EBody = "The order " & MasterNum & " has been marked as Assembly Start and there are panels needed that aren't complete yet.  Please look into this at your earliest convenience."

    '            Dim dsRequestEmails As New DataSet
    '            dsRequestEmails = KPGeneral.WebRef_Local.usp_GetRequestEmailsByRequestTypeAndCompany("Assembly Start - Panels Paint", "Frendel")

    '            If dsRequestEmails.Tables(0).Rows.Count > 0 Then
    '                Dim Message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(KPGeneral.User.UserProfile("UserLoginName").ToString & "@frendel.com", dsRequestEmails.Tables(0).Rows(0)("EmailAddress"))

    '                If dsRequestEmails.Tables(0).Rows.Count > 1 Then
    '                    Dim y As Integer
    '                    For y = 1 To dsRequestEmails.Tables(0).Rows.Count - 1
    '                        Message.CC.Add(dsRequestEmails.Tables(0).Rows(y)("EmailAddress"))
    '                    Next
    '                End If

    '                Message.IsBodyHtml = True

    '                Message.Subject = Subject
    '                Message.Body = EBody

    '                Try
    '                    Dim SmtpNewClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()
    '                    SmtpNewClient.Host = "mail.frendel.com"
    '                    'SmtpNewClient.Credentials = New System.Net.NetworkCredential("measuring@frendel.com", "onsite")
    '                    SmtpNewClient.Send(Message)

    '                Catch ehttp As System.Net.WebException
    '                    Console.WriteLine("0", ehttp.Message)
    '                    Console.WriteLine("Here is the full error message")
    '                    Console.Write("0", ehttp.ToString())
    '                End Try
    '            End If
    '        End If

    '    End If
    'End Sub
    'Sub sendEmail(ByVal ds As DataSet)

    '    Dim CSID As Integer = IIf(ds.Tables(0).Rows(0)("CSID") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("CSID"))
    '    Dim MasterNum As String = IIf(ds.Tables(0).Rows(0)("MASTERNUM") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("MASTERNUM"))
    '    Dim Company As String = IIf(ds.Tables(0).Rows(0)("COMPANY") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("COMPANY"))
    '    Dim Project As String = IIf(ds.Tables(0).Rows(0)("PROJECT") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("PROJECT"))
    '    Dim Lot As String = IIf(ds.Tables(0).Rows(0)("LOT") Is System.DBNull.Value, String.Empty, ds.Tables(0).Rows(0)("LOT"))
    '    Dim dsWatchList As DataSet = KPGeneral.WebRef_Local.usp_GetWatchList_byCSID(CSID)

    '    SendPanelEmails(CSID)

    '    For i As Integer = 0 To dsWatchList.Tables(0).Rows.Count - 1
    '        Dim UserEmail As String = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("UserEmail")), String.Empty, dsWatchList.Tables(0).Rows(i)("UserEmail"))

    '        If UserEmail.ToLower.Contains("gregd") Or UserEmail.ToLower.Contains("kristinad") Then
    '            UserEmail = "scheduling@frendel.com"
    '        End If

    '        Dim Notify As Boolean = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("NotifyAssemblyStarted")), String.Empty, dsWatchList.Tables(0).Rows(i)("NotifyAssemblyStarted"))
    '        'Dim CSID_IN_WatchList As Integer = IIf(IsDBNull(dsWatchList.Tables(0).Rows(i)("CSID")), String.Empty, dsWatchList.Tables(0).Rows(i)("CSID"))

    '        If Notify = True Then
    '            Dim value As AttachmentCollection
    '            Dim Message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("reports@frendel.com", UserEmail)
    '            Message.IsBodyHtml = True
    '            'Message.CC.Add([global].UserProfile.Tables(0).Rows(0)("UserID") & "@frendel.com")
    '            'Message.Bcc.Add("kevinl@frendel.com")
    '            Message.Subject = "Order# " & MasterNum & " - " & Company & " - " & Project & " - " & Lot & " - " & "has been assembled, Date: " & Now.ToString
    '            Message.Body = "Order#: " & MasterNum & " <br /> " _
    '                         & "Company: " & Company & " <br /> " _
    '                         & "Project: " & Project & " <br /> " _
    '                         & "Lot: " & Lot & " <br /> " _
    '                         & "has been assembled"
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
    Private Sub AssignLine4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssignLine4ToolStripMenuItem.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(lvOrders.Selected.Rows(x).Cells("CSID").Text, 4)
                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

    Private Sub AssignLine5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssignLine5ToolStripMenuItem.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(lvOrders.Selected.Rows(x).Cells("CSID").Text, 5)
                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

    Private Sub AssignLine6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssignLine6ToolStripMenuItem.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(lvOrders.Selected.Rows(x).Cells("CSID").Text, 6)
                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

    Private Sub AssignLine7ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssignLine7ToolStripMenuItem.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(lvOrders.Selected.Rows(x).Cells("CSID").Text, 7)
                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

    Private Sub AssignLine8ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssignLine8ToolStripMenuItem.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(lvOrders.Selected.Rows(x).Cells("CSID").Text, 8)
                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        'If TabControl1.SelectedIndex = 0 Then
        '    refreshLVReady()
        'ElseIf TabControl1.SelectedIndex = 1 Then
        '    refreshList()
        'ElseIf TabControl1.SelectedIndex = 2 Then
        '    refreshOustandingOrderList()
        If TabControl1.SelectedIndex = 2 Then
            RefreshPantreis()
        ElseIf TabControl1.SelectedIndex = 4 Then
            RefreshServiceCabinets()
        ElseIf TabControl1.SelectedIndex = 3 Then
            RefreshWeeklyLayouts()
        ElseIf TabControl1.SelectedIndex = 0 Then
            refreshLVReady()
        End If

        'End If
    End Sub
    Dim frmServiceCabinets As frmServiceOrderPrint
    Sub InitTabPage_ServiceCabinets()

        If upServiceCabinets.ClientArea.Controls.ContainsKey("frmServiceCabinets") Then
            upServiceCabinets.ClientArea.Controls.Remove(frmServiceCabinets)
            frmServiceCabinets.Dispose()
        End If

        frmServiceCabinets = New frmServiceOrderPrint

        frmServiceCabinets._Parent = Me

        frmServiceCabinets.TopLevel = False
        frmServiceCabinets.TopMost = True
        frmServiceCabinets.Dock = DockStyle.Fill
        'frmServiceCabinets.FillOrderChangeInfo()
        'frmMedia.FillLotFilesMedia()

        upServiceCabinets.ClientArea.Controls.Add(frmServiceCabinets)

        frmServiceCabinets.Show()

    End Sub
    Private Sub RefreshServiceCabinets()
        InitTabPage_ServiceCabinets()
    End Sub
    Private Sub ColumnChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem.Click
        KPGeneral.ColumnChooser(ugAssemblyStart, Me.GetType.Name)
    End Sub

    Private Sub AssignLine1ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AssignLine1ToolStripMenuItem1.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(lvOrders.Selected.Rows(x).Cells("CSID").Text, 1)

                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

    Private Sub AssignLine3ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AssignLine3ToolStripMenuItem1.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(lvOrders.Selected.Rows(x).Cells("CSID").Text, 3)

                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

    Private Sub AssignLine5ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AssignLine5ToolStripMenuItem1.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(lvOrders.Selected.Rows(x).Cells("CSID").Text, 5)

                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

    Private Sub AssignLineToAssemblyStart(ByVal LineNum As Integer)
        If ugAssemblyStart.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugAssemblyStart.Selected.Rows.Count - 1
                KPGeneral.WebRef_Local.spKPFactory_AssemblyStart_UpdateProductionLine(ugAssemblyStart.Selected.Rows(x).Cells("CSID").Text, LineNum)
                ugAssemblyStart.Selected.Rows(x).Cells("AssignedLine").Value = LineNum
            Next
            RefreshClamps()
        End If
    End Sub
    Private Sub AssignLine1ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AssignLine1ToolStripMenuItem2.Click
        AssignLineToAssemblyStart(1)
    End Sub
    Private Sub AssignLine2ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AssignLine2ToolStripMenuItem1.Click
        AssignLineToAssemblyStart(2)
    End Sub
    Private Sub AssignLine3ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AssignLine3ToolStripMenuItem2.Click
        AssignLineToAssemblyStart(3)
    End Sub
    Private Sub AssignLine4ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AssignLine4ToolStripMenuItem1.Click
        AssignLineToAssemblyStart(4)
    End Sub
    Private Sub AssignLine5ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AssignLine5ToolStripMenuItem2.Click
        AssignLineToAssemblyStart(5)
    End Sub
    Private Sub AssignLine6ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AssignLine6ToolStripMenuItem1.Click
        AssignLineToAssemblyStart(6)
    End Sub
    Private Sub AssignLine7ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AssignLine7ToolStripMenuItem1.Click
        AssignLineToAssemblyStart(7)
    End Sub
    Private Sub AssignLine8ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AssignLine8ToolStripMenuItem1.Click
        AssignLineToAssemblyStart(8)
    End Sub

    Private Sub PrintLayoutPage(ByVal Copies As Integer, ByVal CSID As Integer, OrderPrintType As Integer)
        KPGeneral.PrintLayoutPage("Assembly Start", CSID, KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(CSID, 0), True, False, Copies, OrderPrintType, False, False)
    End Sub
    Private Sub PrintWhiteCopiesForPickersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintWhiteCopiesForPickersToolStripMenuItem.Click
        If ugAssemblyStart.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugAssemblyStart.Selected.Rows.Count - 1
                PrintLayoutPage(2, ugAssemblyStart.Selected.Rows(x).Cells("CSID").Text, 2)
            Next
        End If
    End Sub
    Private Sub PrintPinkCopiesForDoorPickHingeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPinkCopiesForDoorPickHingeToolStripMenuItem.Click
        If ugAssemblyStart.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugAssemblyStart.Selected.Rows.Count - 1
                PrintLayoutPage(1, ugAssemblyStart.Selected.Rows(x).Cells("CSID").Text, 3)
            Next
        End If
    End Sub
    Private Sub PrintTandemboxPagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintTandemboxPagesToolStripMenuItem.Click
        If ugAssemblyStart.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugAssemblyStart.Selected.Rows.Count - 1
                PrintLayoutPage(1, ugAssemblyStart.Selected.Rows(x).Cells("CSID").Text, 5)
            Next
        End If
    End Sub

    Private Sub PrintWhiteCopiesForPickersToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintWhiteCopiesForPickersToolStripMenuItem1.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    PrintLayoutPage(2, lvOrders.Selected.Rows(x).Cells("CSID").Text, 2)
                Next
                'refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub
    Private Sub PrintPinkCopiesForDoorPickHingeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintPinkCopiesForDoorPickHingeToolStripMenuItem1.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    PrintLayoutPage(1, lvOrders.Selected.Rows(x).Cells("CSID").Text, 3)
                Next
                'refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub
    Private Sub PrintTandemboxPagesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintTandemboxPagesToolStripMenuItem1.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    PrintLayoutPage(1, lvOrders.Selected.Rows(x).Cells("CSID").Text, 5)
                Next
                'refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

    Private Sub ContextMenuStripLine_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripLine.Opening
        If TabControl1.SelectedIndex = 0 Then
            SetPlannedStartDateToolStripMenuItem1.Enabled = True
        Else
            SetPlannedStartDateToolStripMenuItem1.Enabled = False
        End If
    End Sub

    Private Sub ResetFiltersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetFiltersToolStripMenuItem.Click
        Dim band As Infragistics.Win.UltraWinGrid.UltraGridBand
        For Each band In ugAssemblyStart.DisplayLayout.Bands
            ' since all rows in a band have the same filters in RowFilterMode.AllRowsInBand this
            ' will clear the filters
            band.ColumnFilters.ClearAllFilters()
        Next
    End Sub

    Private Sub AddSelectedToBottomGridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddSelectedToBottomGridToolStripMenuItem.Click
        Dim x, y As Integer
        Dim selection As Boolean
        selection = False

        If ugAssemblyStart.Selected.Rows.Count > 0 Then
            'x = lvReady.Selected.Rows(0).Index
            For x = 0 To ugAssemblyStart.Selected.Rows.Count - 1


            Next
        End If
    End Sub

    Private Sub RemoveFromAssemblyStartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveFromAssemblyStartToolStripMenuItem.Click
        If ugAssemblyStart.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugAssemblyStart.Selected.Rows.Count - 1
                KPGeneral.WebRef_Local.usp_UpdateShowAssemblyStart(ugAssemblyStart.Selected.Rows(x).Cells("CSID").Text, False)
                'ugReady.Selected.Rows(x).Cells("ShowAssemblyStart").Value = True
            Next

            refreshLVReady()
        End If
    End Sub

    Private Sub btnViewTodayReport_Click(sender As Object, e As EventArgs) Handles btnViewTodayReport.Click
        'ReportsEngine.ReportOptions.FDate = Now.Date
        'ReportsEngine.ReportOptions.TDate = Now.Date
        'ReportsEngine.ReportOptions.PrintOption = 1
        ''ReportsEngine.ReportOptions.ReportName = "Lot Status"
        'ReportsEngine.SelectedReport(257)

        Dim ds As DataSet
        Dim x As Date
        x = Convert.ToDateTime(Now.Date)

        ds = KPGeneral.WebRef_Local.spKPTracking_AssemblyStart(x)
        ds.Tables.Add()
        ds.Tables(1).Columns.Add()
        Dim dr As DataRow
        dr = ds.Tables(1).NewRow
        dr.Item(0) = x
        ds.Tables(1).Rows.Add(dr)
        'ds.WriteXml("c:\xml\kpro.xml", XmlWriteMode.WriteSchema)
        Dim RptDoc2 As New rptProductionAssemblyStart
        RptDoc2.SetDataSource(ds)
        RptDoc2.PrintToPrinter(1, True, 0, 0) '(Copies,Collate,BeginPage,EndPage) if beginpage or endpage=0 then will print all
    End Sub
    Private Sub LoadKitchenTracker(ByVal CSID As Integer)
        KPGeneral.ViewKitchenTrackerByCSID(CSID)
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem.Click
        If ugAssemblyStart.ActiveRow.Index > -1 Then
            LoadKitchenTracker(ugAssemblyStart.ActiveRow.Cells("CSID").Text)
        End If
    End Sub

    Private Sub KitchenTrackerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem1.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.ActiveRow.Index > -1 Then
                LoadKitchenTracker(lvOrders.ActiveRow.Cells("CSID").Text)
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub


    Private Sub PrintCabinetLabels(ByVal MasterNum As String)
        Dim Match As Boolean = False
        Dim OrderLocked As Boolean = False

        Dim dsCSID, dsLabelInfo As New DataSet
        dsCSID = KPGeneral.WebRef_Local.getCSIDByMasterNo(MasterNum)

        Dim CSID As Integer

        CSID = dsCSID.Tables(0).Rows(0)("CSID")

        dsLabelInfo = KPGeneral.WebRef_Local.usp_getASsemblyCabinetLabelInfoByCSID(CSID)

        'If IsDBNull(ugProductionGroup.Selected.Rows(x).Cells("ProductionGroupPrintLocked").Value) = False Then
        '    OrderLocked = ugProductionGroup.Selected.Rows(x).Cells("ProductionGroupPrintLocked").Value
        'End If

        If dsLabelInfo.Tables(0).Rows.Count > 0 Then
            If OrderLocked = False Then
                If IsDBNull(dsLabelInfo.Tables(0).Rows(0)("CabinetLabelPrinted")) = False Then
                    If MsgBox("The order " & MasterNum & " has already been printed.  Do you wish to print again?", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.Yes Then
                        Match = True
                    End If
                Else
                    Match = True
                End If

                If Match = True Then

                    KPGeneral.WebRef_Local.spKPFactory_Labels_IncrementPrintCounter(CSID)
                    KPGeneral.PrintZebraCabinetLabelsByCSID_AssemblyStart(CSID)
                    'ugProductionGroup.Selected.Rows(x).Cells("CabinetLabelPrinted").Value = Now.Date
                End If
            Else
                MsgBox("The order - " & MasterNum & " - is locked from printing.  Please speak to Greg D about this.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
            End If
        End If

    End Sub

    Private Sub PrintCabinetLabelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintCabinetLabelsToolStripMenuItem.Click
        If ugAssemblyStart.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugAssemblyStart.Selected.Rows.Count - 1
                Dim AllowPrint As Boolean = True

                If IsDBNull(ugAssemblyStart.Selected.Rows(x).Cells("OnHold").Value) = False Then
                    If ugAssemblyStart.Selected.Rows(x).Cells("OnHold").Value = True Then
                        AllowPrint = False
                    End If
                End If

                If AllowPrint = True Then
                    PrintCabinetLabels(ugAssemblyStart.Selected.Rows(x).Cells("MasterNum").Text)
                End If
            Next
        End If
    End Sub

    Private Sub PrintCabinetLabelsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintCabinetLabelsToolStripMenuItem1.Click
        If TabControl1.SelectedIndex = 0 Then

        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    Dim AllowPrint As Boolean = True

                    If IsDBNull(lvOrders.Selected.Rows(x).Cells("OnHold").Value) = False Then
                        If lvOrders.Selected.Rows(x).Cells("OnHold").Value = True Then
                            AllowPrint = False
                        End If
                    End If

                    If AllowPrint = True Then
                        PrintCabinetLabels(lvOrders.Selected.Rows(x).Cells("MASTER_NO").Text)
                    End If

                Next
                'refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            ugAssemblyStart.Selected.Rows.Clear()
            ugAssemblyStart.ActiveRow = Nothing

            Dim band As Infragistics.Win.UltraWinGrid.UltraGridBand
            For Each band In ugAssemblyStart.DisplayLayout.Bands
                ' since all rows in a band have the same filters in RowFilterMode.AllRowsInBand this
                ' will clear the filters
                band.ColumnFilters.ClearAllFilters()
            Next

            Dim x As Integer
            For x = 0 To ugAssemblyStart.Rows.Count - 1
                If ugAssemblyStart.Rows(x).Cells("MasterNum").Text = txtSearch.Text Then
                    ugAssemblyStart.Rows(x).Selected = True
                    ugAssemblyStart.Rows(x).Activate()
                    Exit For
                End If
            Next

            txtSearch.Text = ""
        End If
    End Sub

    Private Sub SetAsTandemboxOrderdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAsTandemboxOrderdToolStripMenuItem.Click
        If TabControl1.SelectedIndex = 0 Then
            'If LVSelected.Selected.Rows.Count > 0 Then
            '    Dim x As Integer
            '    For x = 0 To LVSelected.Selected.Rows.Count - 1
            '        LVSelected.Selected.Rows(x).Cells("AssignedLine").Value = 1
            '    Next
            'End If
        ElseIf TabControl1.SelectedIndex = 1 Then
            If lvOrders.Selected.Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To lvOrders.Selected.Rows.Count - 1
                    KPGeneral.WebRef_Local.usp_UpdateTandemBoxOrderDate(lvOrders.Selected.Rows(x).Cells("CSID").Text)

                Next
                refreshList()
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then

        End If
    End Sub

    Private Sub SetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetToolStripMenuItem.Click
        If ugAssemblyStart.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugAssemblyStart.Selected.Rows.Count - 1
                KPGeneral.WebRef_Local.usp_UpdateTandemBoxOrderDate(ugAssemblyStart.Selected.Rows(x).Cells("CSID").Text)
                ugAssemblyStart.Selected.Rows(x).Cells("TBOD").Value = Now.Date
            Next
            RefreshClamps()
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshPantreis()
    End Sub
    Private Sub RefreshPantreis()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetPantryLabelsPrinted7days
        ugPantries.DataSource = ds
        KPGeneral.RefreshGridFromLayout(Me.ugPantries, Me.GetType.Name)
        Me.ugPantries.DisplayLayout.Override.FilterUIProvider = Me.UltraGridFilterUIProvider1
        Me.ugPantries.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        ugPantries.DisplayLayout.Bands(0).Columns("CSID").Hidden = True
        ugPantries.DisplayLayout.Bands(0).Columns("LabelNo").Hidden = True

        ugPantries.DisplayLayout.Bands(0).Columns("COMPANY").Width = 200
        ugPantries.DisplayLayout.Bands(0).Columns("PROJECT").Width = 250
        ugPantries.DisplayLayout.Bands(0).Columns("Lot").Width = 200
        ugPantries.DisplayLayout.Bands(0).Columns("PrintDate").Width = 175
        ugPantries.DisplayLayout.Bands(0).Columns("PrintDate").Format = KPGeneral.DateTime12HourFormatString
        Me.ugPantries.DisplayLayout.Bands(0).Columns("BoxDateExpected").Format = KPGeneral.DateTime12HourFormatString
    End Sub

    Private Sub CalculateSelected()
        Dim TotalDoors As Int32 = 0
        Dim TimePlanned As Double = 0
        Dim LoadCount As Int32 = 0
        Dim SelectedCount As Integer = 0
        Dim row As UltraGridRow
        For Each row In ugAssemblyStart.Rows
            If IsDBNull(row.Cells("isSelected").Value) = False Then
                If row.Cells("isSelected").Value = True Then
                    SelectedCount = SelectedCount + 1
                    If Not IsDBNull(row.Cells("TotalDoors").Value) Then
                        TotalDoors = TotalDoors + row.Cells("TotalDoors").Value
                        If Not IsDBNull(row.Cells("APT").Value) Then
                            TimePlanned = TimePlanned + row.Cells("APT").Value
                        End If
                    End If
                End If
            End If


        Next

        lblSelectedOrders_Top.Text = SelectedCount
        lblSelectedAPT_Top.Text = TimePlanned
        lblSelectedDoors_Top.Text = TotalDoors
    End Sub
    Private Sub KitchenTrackerToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles KitchenTrackerToolStripMenuItem3.Click
        If ugPantries.ActiveRow.Index > -1 Then
            LoadKitchenTracker(ugPantries.ActiveRow.Cells("CSID").Text)
        End If
    End Sub
    Private Sub PrintWhiteCopiesForPantryAssemblerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintWhiteCopiesForPantryAssemblerToolStripMenuItem.Click
        If ugPantries.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ugPantries.Selected.Rows.Count - 1
                PrintLayoutPage(1, ugPantries.Selected.Rows(x).Cells("CSID").Text, 2)
            Next
        End If
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        AssignLineToAssemblyStart(1)
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        AssignLineToAssemblyStart(3)
    End Sub
    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        AssignLineToAssemblyStart(5)
    End Sub
#Region " Weekly Layouts "
    Private Sub FindXKs()
        If ug_AssemblyStart_AdvancedSearchLotList.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ug_AssemblyStart_AdvancedSearchLotList.Rows.Count - 1
                If ug_AssemblyStart_AdvancedSearchLotList.Rows(x).Cells("MasterNum").Text.Contains("X") Then
                    ug_AssemblyStart_AdvancedSearchLotList.Rows(x).Appearance.BackColor = Color.GreenYellow
                Else
                    If ug_AssemblyStart_AdvancedSearchLotList.Rows(x).Appearance.BackColor.Name <> "Red" Then
                        ug_AssemblyStart_AdvancedSearchLotList.Rows(x).Appearance.BackColor = Color.White
                    End If
                End If

                If IsDBNull(ug_AssemblyStart_AdvancedSearchLotList.Rows(x).Cells("AssemblyPartsOrderedDate").Value) = False Then
                    If ug_AssemblyStart_AdvancedSearchLotList.Rows(x).Cells("AssemblyPartsOrderedDate").Value.ToString <> "" Then
                        ug_AssemblyStart_AdvancedSearchLotList.Rows(x).Appearance.BackColor = Color.LightSkyBlue
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub FindCancelOrder()
        Dim x As Integer
        If ug_AssemblyStart_AdvancedSearchLotList.Rows.Count > 0 Then
            For x = 0 To ug_AssemblyStart_AdvancedSearchLotList.Rows.Count - 1
                If ug_AssemblyStart_AdvancedSearchLotList.Rows(x).Cells("CancelOrder").Text = "True" Or ug_AssemblyStart_AdvancedSearchLotList.Rows(x).Cells("StatusType").Text = "Expired" Then
                    ug_AssemblyStart_AdvancedSearchLotList.Rows(x).Appearance.BackColor = Color.Red
                Else
                    ug_AssemblyStart_AdvancedSearchLotList.Rows(x).Appearance.BackColor = Color.White
                End If
            Next
        End If
    End Sub
    Private Function ConvertToBitmapAC(ByVal data() As Byte, ByVal offset As Integer) As Bitmap
        'Converts image bytes to bitmap (less OLE header (78 offset) for Access DB 
        Try
            Dim ms As New System.IO.MemoryStream
            ms.Write(data, offset, data.Length - offset)
            Return New Bitmap(ms)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function
    Private Function ConvertToBitmapVB(ByVal data() As Byte) As Bitmap
        'Converts image bytes to bitmap (RAW)
        Try
            Dim ms As New System.IO.MemoryStream
            ms.Write(data, 0, data.Length)
            Return New Bitmap(ms)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function
    Private Sub RefreshLayoutPage()
        Try
            PageNumber = 1

            Dim dsLayout As New DataSet
            dsLayout = KPGeneral.WebRef_Local.usp_GetRoomLayoutPagesByCSID(CurrentCSID)
            PreviousLayout = dsLayout.Copy

        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub LotList_AfterRowActivate(sender As Object, e As EventArgs) Handles ug_AssemblyStart_AdvancedSearchLotList.AfterRowActivate
        If ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Index > -1 Then
            CurrentCSID = ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Cells("CSID").Text

            CheckAssemblyPartsOrdered(ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Cells("CSID").Text)
            LoadCutlistReport(ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Cells("CSID").Text)
            ug_AssemblyStart_AdvancedSearchLotList.Focus()
            GC.Collect()

        End If
    End Sub
    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles btn_WeeklyLayouts_ColumnChooser.Click
        WeeklyLayoutLotListColumnChooser()
    End Sub
    Private Sub WeeklyLayoutLotListColumnChooser()
        KPGeneral.ColumnChooser(ug_AssemblyStart_AdvancedSearchLotList, Me.GetType.Name)

        Dim band As Infragistics.Win.UltraWinGrid.UltraGridBand
        For Each band In ug_AssemblyStart_AdvancedSearchLotList.DisplayLayout.Bands
            ' since all rows in a band have the same filters in RowFilterMode.AllRowsInBand this
            ' will clear the filters
            band.ColumnFilters.ClearAllFilters()
        Next
    End Sub
    Private Sub ShowInfo()

        Me.Cursor = Cursors.WaitCursor
        Try
            KPGeneral.rsOrderInfo = KPGeneral.WebRef_Local.spKP_LotInfoByCSID(ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Cells("CSID").Text).Copy

            If ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Index > -1 Then
                If ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Cells("Company").Text = "Frendel Kitchen & Bath Design Studio Inc." Then
                    Dim dsBarcode As New DataSet
                    dsBarcode = KPGeneral.WebRef_Local.usp_getDSBarcodeByCSID(ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Cells("CSID").Text)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error processing Lot Detail info")
        End Try

        Me.Cursor = Cursors.Default

        'MasterNo.Focus()
    End Sub
    Private Sub LoadMissingMeasurements()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetMissingMeasurementsToVerify

        ug_AssemblyStart_AdvancedSearchLotList.DataSource = ds

        lblTotalRows.Text = "Total Records: " & ug_AssemblyStart_AdvancedSearchLotList.Rows.Count
    End Sub
    Private Sub LoadAdvancedSearch()
        frmAdvancedSearch.ShowDialog()
        Me.Cursor = Cursors.WaitCursor
        ug_AssemblyStart_AdvancedSearchLotList.DataSource = KPGeneral.AdvancedSearch

        lblTotalRows.Text = "Total Records: " & ug_AssemblyStart_AdvancedSearchLotList.Rows.Count

        KPGeneral.RefreshGridFromLayout(ug_AssemblyStart_AdvancedSearchLotList, Me.GetType.Name)

        FindCancelOrder()
        FindXKs()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LotList_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles ug_AssemblyStart_AdvancedSearchLotList.AfterSelectChange
        'lblHighlight.Text = "Orders Highlighted = " & ug_AssemblyStart_AdvancedSearchLotList.Selected.Rows.Count
    End Sub
    Sub PrintLayoutPage(ByVal isLogLayout As Boolean, ByVal LogID As Integer)
        Try
            If ug_AssemblyStart_AdvancedSearchLotList.Rows.Count > 0 Then
                If ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Index > -1 Then
                    If isLogLayout = False Then
                        KPGeneral.PrintLayoutPage("Orders", ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Cells("CSID").Text, KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Cells("CSID").Text, 0), False, False, 0, 1, False, False)
                    Else
                        KPGeneral.PrintLayoutPage("Orders - Admin Log", LogID, KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(ug_AssemblyStart_AdvancedSearchLotList.ActiveRow.Cells("CSID").Text, 0), False, False, 0, 1, True, False)
                    End If

                End If
            End If
        Catch ex As Exception
            Call KPGeneral.oError.CheckError(System.Reflection.MethodBase.GetCurrentMethod.Name, ex)
        End Try
    End Sub
    Private Sub RefreshWeeklyLayouts()
        If FirstLoaded = True Then
            Me.Cursor = Cursors.WaitCursor
            Dim dsWeeklyLots As New DataSet
            dsWeeklyLots = KPGeneral.WebRef_Local.usp_GetWeeklyLayoutsProductionReceived_ByDate(uccWeeklyLayoutSiteRequest.Text)
            ug_AssemblyStart_AdvancedSearchLotList.DataSource = dsWeeklyLots

            lblTotalRows.Text = "Total Records: " & ug_AssemblyStart_AdvancedSearchLotList.Rows.Count

            KPGeneral.RefreshGridFromLayout(ug_AssemblyStart_AdvancedSearchLotList, Me.GetType.Name)

            FindCancelOrder()
            FindXKs()
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub uccWeeklyLayoutSiteRequest_TextChanged(sender As Object, e As EventArgs) Handles uccWeeklyLayoutSiteRequest.TextChanged
        RefreshWeeklyLayouts()
    End Sub
    Private Sub ColumnChooserToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ColumnChooserToolStripMenuItem2.Click
        WeeklyLayoutLotListColumnChooser()
    End Sub
    Private Sub btnSetAssemblyPartsOrdered_Click(sender As Object, e As EventArgs) Handles btnSetAssemblyPartsOrdered.Click
        If ug_AssemblyStart_AdvancedSearchLotList.Selected.Rows.Count > 0 Then
            Dim x As Integer
            For x = 0 To ug_AssemblyStart_AdvancedSearchLotList.Selected.Rows.Count - 1
                KPGeneral.WebRef_Local.usp_UpdateAssemblyPartsOrderedDate(ug_AssemblyStart_AdvancedSearchLotList.Selected.Rows(x).Cells("CSID").Text, KPGeneral.User.UserProfile("UserLoginName"))
                ug_AssemblyStart_AdvancedSearchLotList.Selected.Rows(x).Cells("AssemblyPartsOrderedBy").Value = KPGeneral.User.UserProfile("UserLoginName")
                ug_AssemblyStart_AdvancedSearchLotList.Selected.Rows(x).Cells("AssemblyPartsOrderedDate").Value = Now.Date
                ug_AssemblyStart_AdvancedSearchLotList.Selected.Rows(x).Appearance.BackColor = Color.LightSkyBlue
            Next

            lblAssemblyPartsOrderedOn.Text = "Assembly Parts Ordered Date: " & Now.Date
        End If
    End Sub
    Private Sub CheckAssemblyPartsOrdered(ByVal CSID As Integer)
        Dim AssemblyPartsOrderedDate As DateTime
        Dim ConvertedValue As String = ""


        Dim dsOrderInfo As New DataSet
        dsOrderInfo = KPGeneral.WebRef_Local.spKP_LotInfoByCSID(CSID)

        If IsDBNull(dsOrderInfo.Tables(0).Rows(0)("AssemblyPartsOrderedDate")) = False Then
            AssemblyPartsOrderedDate = dsOrderInfo.Tables(0).Rows(0)("AssemblyPartsOrderedDate")
            ConvertedValue = AssemblyPartsOrderedDate.Date
        End If

        lblAssemblyPartsOrderedOn.Text = "Assembly Parts Ordered Date: " & ConvertedValue
    End Sub
    Private Sub LoadCutlistReport(ByVal CSID As Integer)

        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.Dispose()
        CrystalReportViewer1 = Nothing


        CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()


        'CrystalReportViewer1
        '
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.AutoScroll = True
        Me.CrystalReportViewer1.AutoSize = True
        Me.CrystalReportViewer1.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.CrystalReportViewer1.CausesValidation = False
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.EnableDrillDown = False
        Me.CrystalReportViewer1.EnableToolTips = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowCopyButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1070, 853)
        Me.CrystalReportViewer1.TabIndex = 228
        Me.CrystalReportViewer1.TabStop = False
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.CrystalReportViewer1.ToolPanelWidth = 10

        Me.upWeeklyLayouts.ClientArea.Controls.Add(Me.CrystalReportViewer1)


        Dim isDealer As Boolean
        Dim isXOrder As Boolean

        Dim dtOrderInfo As DataTable = KPGeneral.WebRef_Local.GetTable("SELECT DISTINCT MASTERNUM, isdealer FROM PURCHASERS INNER JOIN PROJECTS ON PURCHASERS.PROJNUM = PROJECTS.PROJNUM WHERE CSID=" & CSID, "OrderInfo")

        If dtOrderInfo.Rows.Count > 0 Then

            isDealer = Convert.ToBoolean(dtOrderInfo.Rows(0)("isDealer"))

            If IsDBNull(dtOrderInfo.Rows(0)("Masternum")) Then
                isXOrder = False
            Else
                If dtOrderInfo.Rows(0)("Masternum").ToString.Contains("X") Then
                    isXOrder = True
                Else
                    isXOrder = False
                End If
            End If

        End If

        'dsOrderInfo = KPGeneral.WebRef_Local.spKP_LotInfoByCSID(CSID)

        'isDealer = Convert.ToBoolean(dsOrderInfo.Tables(0).Rows(0)("isDealer"))
        'If IsDBNull(dsOrderInfo.Tables(0).Rows(0)("Masternum")) Then
        '    isXOrder = False
        'Else
        '    If dsOrderInfo.Tables(0).Rows(0)("Masternum").ToString.Contains("X") Then
        '        isXOrder = True
        '    Else
        '        isXOrder = False
        '    End If
        'End If

        Dim ds As DataSet

        If isDealer = True Or isXOrder Then
            ds = KPGeneral.WebRef_Local.usp_XK_getCabinetListByCSID(CSID)
            ds.Tables.Add(KPGeneral.WebRef_Local.usp_XK_GetOrderAccessoriesByCSID(CSID).Tables(0).Copy)
            ds.Tables.Add(KPGeneral.WebRef_Local.usp_XK_GetRoomInfoByCSID(CSID).Tables(0).Copy)
            ds.Tables.Add(KPGeneral.WebRef_Local.usp_XK_LotInfoByCSID(CSID).Tables(0).Copy)
            ds.Tables.Add(KPGeneral.WebRef_Local.usp_XK_GetDoorDrawerListByCSID(CSID).Tables(0).Copy)
            ds.Tables.Add(KPGeneral.WebRef_Local.usp_GetRoomLayoutPagesForLayoutByCSID(CSID).Tables(0).Copy)

            Dim rptName As New rptRoomLayout_Cutlist
            rptName.SetDataSource(ds)
            rptName.SetParameterValue("SideBar", KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(CSID, 0))
            rptName.SetParameterValue("PrintSource", "Printed by Assembly Start")

            CrystalReportViewer1.ReportSource = rptName
        Else
            ds = KPGeneral.WebRef_Local.usp_GetRoomLayoutPagesForLayoutByCSID(CSID)

            Dim rptName As New rptRoomLayout
            rptName.SetDataSource(ds)
            rptName.SetParameterValue("SideBar", KPGeneral.WebRef_Local.usp_GetViewLayout_SideBarText(CSID, 0))
            rptName.SetParameterValue("PrintSource", "Printed by Assembly Start")

            CrystalReportViewer1.ReportSource = rptName
        End If

        For Each Ctrl As Control In Me.CrystalReportViewer1.Controls
            If Ctrl.Controls.Count > 0 Then
                If TypeName(Ctrl.Controls.Item(0)) = "TabControl" Then
                    Dim Ctrl2 As TabControl = Ctrl.Controls.Item(0)
                    If Ctrl2.Visible = True Then
                        Ctrl2.ItemSize = New Size(0, 1)
                        Ctrl2.SizeMode = TabSizeMode.Fixed
                        Ctrl2.Appearance = TabAppearance.Buttons
                    Else
                        Ctrl2.ItemSize = New Size(67, 18)
                        Ctrl2.SizeMode = TabSizeMode.Normal
                        Ctrl2.Appearance = TabAppearance.Normal
                    End If
                End If
            End If
        Next

        ug_AssemblyStart_AdvancedSearchLotList.Focus()


    End Sub



#End Region
    Private Sub CheckServiceCabinets()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetOutstandingServiceOrderCabinets()

        If ds.Tables(0).Rows.Count > 0 Then
            HasServiceOrders = True
        Else
            HasServiceOrders = False
        End If
    End Sub
    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem
        e.Graphics.FillRectangle(New SolidBrush(SystemColors.Control), e.Bounds)

        Select Case e.Index
            Case 4
                If HasServiceOrders = True Then
                    e.Graphics.FillRectangle(New SolidBrush(Color.Yellow), e.Bounds)
                End If
        End Select

        Dim paddedBounds As Rectangle = e.Bounds
        paddedBounds.Inflate(-2, -2)
        e.Graphics.DrawString(TabControl1.TabPages(e.Index).Text, Me.Font, SystemBrushes.MenuText, paddedBounds)
    End Sub

    Private Sub btnViewClampDetail1_Click(sender As Object, e As EventArgs) Handles btnViewClampDetail1.Click
        KPGeneral.ViewClampDetail(1)
    End Sub
    Private Sub btnViewClampDetail2_Click(sender As Object, e As EventArgs) Handles btnViewClampDetail2.Click
        KPGeneral.ViewClampDetail(2)
    End Sub
    Private Sub btnViewClampDetail3_Click(sender As Object, e As EventArgs) Handles btnViewClampDetail3.Click
        KPGeneral.ViewClampDetail(3)
    End Sub
    Private Sub btnViewClampDetail4_Click(sender As Object, e As EventArgs) Handles btnViewClampDetail4.Click
        KPGeneral.ViewClampDetail(4)
    End Sub
    Private Sub btnViewClampDetail5_Click(sender As Object, e As EventArgs) Handles btnViewClampDetail5.Click
        KPGeneral.ViewClampDetail(5)
    End Sub
    Private Sub btnViewClampDetail6_Click(sender As Object, e As EventArgs) Handles btnViewClampDetail6.Click
        KPGeneral.ViewClampDetail(6)
    End Sub
    Private Sub btnViewClampDetail7_Click(sender As Object, e As EventArgs) Handles btnViewClampDetail7.Click
        KPGeneral.ViewClampDetail(7)
    End Sub
    Private Sub RefreshClamps()
        Dim x As Integer
        For x = 1 To 8
            Dim ds As New DataSet
            ds = KPGeneral.WebRef_Local.usp_GetAssignedClampsByClampNumber_BoxInfo(x)

            Dim SetGrid As Boolean = False

            Dim TotalMin As Integer = 0

            Dim PerformancePercent As Integer = 0

            Dim z As Integer
            For z = 0 To ds.Tables(0).Rows.Count - 1
                If Not IsDBNull(ds.Tables(0).Rows(z)("APRem")) Then
                    TotalMin = TotalMin + ds.Tables(0).Rows(z)("APRem")
                End If
            Next

            Dim TotalMinText As String = " - Total Minutes Remaining: " & TotalMin

            Dim MaxDate As DateTime
            Dim MaxDateString As String = ""

            If ds.Tables(0).Rows.Count > 0 Then
                Dim TempMaxDate As String = ds.Tables(0).Compute("Max(BoxDate)", "").ToString
                If TempMaxDate.Length > 0 Then
                    MaxDate = ds.Tables(0).Compute("Max(BoxDate)", "")
                    MaxDateString = Format(MaxDate, "ddd.MMM dd - h:mm tt")
                End If

            End If

            If ds.Tables.Count > 2 Then
                If ds.Tables(2).Rows.Count > 0 Then
                    If IsDBNull(ds.Tables(2).Rows(0)("PerformancePercentNew")) = False Then
                        PerformancePercent = ds.Tables(2).Rows(0)("PerformancePercentNew") 'ds.Tables(1).Rows(0)("PerformancePercent") 
                    End If
                End If
            End If

            Dim PerformancePercentString As String = "Current Day: " & PerformancePercent & "%"

            Dim StartText As String = "MIN REM: "
            Select Case x
                Case 1
                    lblMinRem1.Text = StartText & TotalMin
                    lblMax1.Text = MaxDateString
                    lblClampDetail1.Text = PerformancePercentString
                Case 2
                    lblMinRem2.Text = StartText & TotalMin
                    lblMax2.Text = MaxDateString
                    lblClampDetail2.Text = PerformancePercentString
                Case 3
                    lblMinRem3.Text = StartText & TotalMin
                    lblMax3.Text = MaxDateString
                    lblClampDetail3.Text = PerformancePercentString
                Case 4
                    lblMinRem4.Text = StartText & TotalMin
                    lblMax4.Text = MaxDateString
                    lblClampDetail4.Text = PerformancePercentString
                Case 5
                    lblMinRem5.Text = StartText & TotalMin
                    lblMax5.Text = MaxDateString
                    lblClampDetail5.Text = PerformancePercentString
                Case 6
                    lblMinRem6.Text = StartText & TotalMin
                    lblMax6.Text = MaxDateString
                    lblClampDetail6.Text = PerformancePercentString
                Case 7
                    lblMinRem7.Text = StartText & TotalMin
                    lblMax7.Text = MaxDateString
                    lblClampDetail7.Text = PerformancePercentString
                Case 8
                    lblMinRem8.Text = StartText & TotalMin
                    lblMax8.Text = MaxDateString
                    lblClampDetail8.Text = PerformancePercentString
            End Select

        Next
    End Sub
    Private Sub PrintClampInfo(ByVal ClampNum As Integer)

        Me.Cursor = Cursors.WaitCursor
        Dim dsAssemblyDetail As New DataSet
        Dim sqlStatement As String = "SELECT * FROM vw_rptAssemblerDailyPerformance_Info WHERE ClampID=" & ClampNum & " And ScheduleDate=CONVERT(DATE,'" & Today & "')"
        Dim dt As DataTable = KPGeneral.WebRef_Local.GetTable(sqlStatement, "vw_rptAssemblerDailyPerformance_Info")
        If dt.Rows.Count = 0 Then
            MsgBox("No report")
            Exit Sub
        End If

        sqlStatement = "SELECT ScanTime,MASTERNUM,COMPANY,PROJECT,LOT,Cabinet_Name,tblCabinetLabel.AssemblyPlannedTime,'" & dt.Rows(0)("ClampName").ToString & "' AS AssignedClamp " _
                      & "FROM PROJECTS INNER JOIN PURCHASERS ON PROJECTS.PROJNUM = PURCHASERS.PROJNUM INNER JOIN tblCabinetLabel ON PURCHASERS.CSID = tblCabinetLabel.CSID " _
                      & "WHERE CONVERT(DATE,ScanDate)=CONVERT(DATE,'" & Today & "') AND ScanUser='" & dt.Rows(0)("EmpRef").ToString & "' ORDER BY ScanTime"
        dsAssemblyDetail.Tables.Add(KPGeneral.WebRef_Local.GetTable(sqlStatement, "vw_rptAssemblerDailyPerformance").Copy)

        Dim temp As DataTable = KPGeneral.WebRef_Local.GetTable("Select ISNULL(SUM(AssemblyPlannedTime),0) AS 'TotalPlanTime' FROM tblCabinetLabel " _
                                              & "WHERE ScanUser='" & dt.Rows(0)("EmpRef").ToString & "' AND CONVERT(DATE,ScanDate)=CONVERT(DATE,'" & Today & "') ", "Performance")
        If temp.Rows.Count > 0 Then
            dt.Rows(0)("APT") = Convert.ToInt32(Convert.ToDouble(temp.Rows(0)("TotalPlanTime")))
        Else
            dt.Rows(0)("APT") = 0
        End If

        Dim t1130 As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 11, 45, 1)
        Dim t915 As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 9, 15, 1)
        Dim t230 As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, 14, 30, 1)
        Dim start As DateTime = CType(Today.ToShortDateString & " " & dt.Rows(0)("StartTime").ToString, DateTime)
        Dim endTime As DateTime = CType(Today.ToShortDateString & " " & dt.Rows(0)("EndTime").ToString, DateTime)
        Dim totalMinutes As Int16 = (endTime - start).TotalMinutes
        If Now < t915 Then
            If totalMinutes > CInt((Now - start).TotalMinutes) Then
                dt.Rows(0)("WorkingInMinutes") = CInt((Now - start).TotalMinutes)
            Else
                dt.Rows(0)("WorkingInMinutes") = totalMinutes
            End If
        ElseIf Now < t915.AddMinutes(15) Then 'morning break
            If totalMinutes - 15 > CInt((t915 - start).TotalMinutes) Then
                dt.Rows(0)("WorkingInMinutes") = CInt((t915 - start).TotalMinutes)
            Else
                dt.Rows(0)("WorkingInMinutes") = totalMinutes - 15
            End If
        ElseIf Now < t1130 Then
            If totalMinutes > CInt((Now - start).TotalMinutes) Then
                dt.Rows(0)("WorkingInMinutes") = CInt((Now - start).TotalMinutes) - 15
            Else
                dt.Rows(0)("WorkingInMinutes") = totalMinutes - 15
            End If
        ElseIf Now < t1130.AddMinutes(30) Then 'lunch time
            If endTime.Hour = 12 Then 'no lunch time
                dt.Rows(0)("WorkingInMinutes") = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 15, dt.Rows(0)("WorkingInMinutes"))
            Else
                dt.Rows(0)("WorkingInMinutes") = CInt((t1130 - start).TotalMinutes) - 15
            End If
        Else
            If endTime.Hour = 12 Then 'no lunch time
                dt.Rows(0)("WorkingInMinutes") = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 15, CInt((endTime - start).TotalMinutes) - 15)
            Else ' work after 12
                If Now < t230 Then
                    dt.Rows(0)("WorkingInMinutes") = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                ElseIf Now < t230.AddMinutes(15) Then
                    If (endTime - start).TotalMinutes > 540 Then
                        dt.Rows(0)("WorkingInMinutes") = IIf(endTime > Now, CInt((t230 - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                    Else
                        dt.Rows(0)("WorkingInMinutes") = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                    End If
                Else
                    If (endTime - start).TotalMinutes > 540 Then
                        dt.Rows(0)("WorkingInMinutes") = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 60, CInt((endTime - start).TotalMinutes) - 60)
                    Else
                        dt.Rows(0)("WorkingInMinutes") = IIf(endTime > Now, CInt((Now - start).TotalMinutes) - 45, CInt((endTime - start).TotalMinutes) - 45)
                    End If
                End If
            End If
        End If

        dt.Rows(0)("Performance") = Convert.ToInt32(100 * Convert.ToDouble(dt.Rows(0)("APT")) / Convert.ToDouble(dt.Rows(0)("WorkingInMinutes")))
        temp = KPGeneral.KPDataSQL.SP_EXEC("usp_GetEmployeeTimeCardByDate", dt.Rows(0)("EmpRef").ToString, Today).Tables(0)
        If temp.Rows.Count > 0 Then
            dt.Rows(0)("ClockIN") = temp.Rows(0)("ClockIN")
            dt.Rows(0)("ClockOUT") = temp.Rows(0)("ClockOUT")
        Else
            dt.Rows(0)("ClockIN") = DBNull.Value
            dt.Rows(0)("ClockOUT") = DBNull.Value
        End If
        dsAssemblyDetail.Tables.Add(dt.Copy)
        Dim dtStartEndTime As New DataTable
        dtStartEndTime.TableName = "vw_rptAssemblerDailyPerformance_StartTimeEndTime"
        dtStartEndTime.Columns.Add("StartTime", System.Type.GetType("System.DateTime"))
        dtStartEndTime.Columns.Add("EndTime", System.Type.GetType("System.DateTime"))
        Dim dr As DataRow = dtStartEndTime.NewRow
        dr("StartTime") = start
        dr("EndTime") = endTime
        dtStartEndTime.Rows.Add(dr)
        dsAssemblyDetail.Tables.Add(dtStartEndTime)
        dsAssemblyDetail.WriteXml("c:\xml\kpro.xml", XmlWriteMode.WriteSchema)
        Dim rptName As New rptAssemblerDailyPerformance
        rptName.SetDataSource(dsAssemblyDetail)
        Dim rpt As New RptViewer(1, rptName)
        Me.Cursor = Cursors.Default
        rpt.ShowDialog()
        rpt.Close()
        rpt.Dispose()
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub btnPrintClampInfo1_Click(sender As Object, e As EventArgs) Handles btnPrintClampInfo1.Click
        PrintClampInfo(1)
    End Sub
    Private Sub btnPrintClampInfo2_Click(sender As Object, e As EventArgs) Handles btnPrintClampInfo2.Click
        PrintClampInfo(2)
    End Sub
    Private Sub btnPrintClampInfo3_Click(sender As Object, e As EventArgs) Handles btnPrintClampInfo3.Click
        PrintClampInfo(3)
    End Sub
    Private Sub btnPrintClampInfo4_Click(sender As Object, e As EventArgs) Handles btnPrintClampInfo4.Click
        PrintClampInfo(4)
    End Sub
    Private Sub btnPrintClampInfo5_Click(sender As Object, e As EventArgs) Handles btnPrintClampInfo5.Click
        PrintClampInfo(5)
    End Sub
    Private Sub btnPrintClampInfo6_Click(sender As Object, e As EventArgs) Handles btnPrintClampInfo6.Click
        PrintClampInfo(6)
    End Sub
    Private Sub btnPrintClampInfo7_Click(sender As Object, e As EventArgs) Handles btnPrintClampInfo7.Click
        PrintClampInfo(7)
    End Sub
    Private Sub btnManageClamps_Click(sender As Object, e As EventArgs) Handles btnManageClamps.Click
        Dim ManageClamps As New frmManageClamps
        ManageClamps.ShowDialog()
    End Sub
    Private Sub btnManageClampHours_Click(sender As Object, e As EventArgs) Handles btnManageClampHours.Click
        Dim ManageClampHours As New frmManageClampShifts
        ManageClampHours.ShowDialog()
    End Sub
    Private Sub StartAssemblyForSelectedOrdersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartAssemblyForSelectedOrdersToolStripMenuItem.Click
        If ugAssemblyStart.Rows.Count > 0 Then

            frmAssemblyStartPopUp.CSIDString = ""
            Dim CSIDString As String = ""
            Dim x As Integer
            For x = 0 To ugAssemblyStart.Rows.Count - 1
                If IsDBNull(ugAssemblyStart.Rows(x).Cells("isSelected").Value) = False Then
                    If ugAssemblyStart.Rows(x).Cells("isSelected").Value = True Then
                        Dim PreCheckValid As Boolean = PreChecks(ugAssemblyStart.Rows(x).Cells("MasterNum").Text,
                                                                 ugAssemblyStart.Rows(x).Cells("RAW").Text,
                                                                 ugAssemblyStart.Rows(x).Cells("Painted").Text)

                        If PreCheckValid = True Then
                            If x = ugAssemblyStart.Rows.Count - 1 Then
                                CSIDString = CSIDString & ugAssemblyStart.Rows(x).Cells("CSID").Text
                            Else
                                CSIDString = CSIDString & ugAssemblyStart.Rows(x).Cells("CSID").Text & ", "
                            End If
                        End If
                    End If
                End If

            Next

            If CSIDString.Trim.Length > 0 Then
                If CSIDString.Trim.EndsWith(",") Then
                    CSIDString = CSIDString.Trim.Remove(CSIDString.LastIndexOf(","), 1)
                End If

                frmAssemblyStartPopUp.CSIDString = CSIDString.Trim
                frmAssemblyStartPopUp.ShowDialog()

                refreshLVReady()
                RefreshClamps()
            End If
        End If
    End Sub
    Function PreChecks(ByVal MasterNum As String, ByVal RAW As String, ByVal PAINT As String) As Boolean
        Dim dsCancelOrderCheck As New DataSet
        dsCancelOrderCheck = KPGeneral.WebRef_Local.spKP_LotInfoByFK(KPGeneral.ExtractMasterNum(Trim(MasterNum)))

        If dsCancelOrderCheck.Tables(0).Rows.Count > 0 Then
            Dim Builder, Project, Lot As String

            Builder = dsCancelOrderCheck.Tables(0).Rows(0)("COMPANY")
            Project = dsCancelOrderCheck.Tables(0).Rows(0)("PROJECT")
            Lot = dsCancelOrderCheck.Tables(0).Rows(0)("LOT")

            Dim LotString As String = MasterNum & " - " & Builder & " / " & Project & " / " & Lot
            Dim EDate As Date
            EDate = Now.Date.AddDays(7)
            If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("SiteRequest")) = False And IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("shipped")) = False Then
                If dsCancelOrderCheck.Tables(0).Rows(0)("SiteRequest") > dsCancelOrderCheck.Tables(0).Rows(0)("shipped") Then
                    If dsCancelOrderCheck.Tables(0).Rows(0)("SiteRequest") > EDate Then
                        If MsgBox("This order ( " & LotString & " ) is more than 7 days out.  Are you sure you wish to start it?", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.No Then
                            Return False
                        End If
                    End If
                    'Else
                    '    If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("shipped")) = False Then
                    '        If dsCancelOrderCheck.Tables(0).Rows(0)("shipped") > EDate Then
                    '            If MsgBox("This order ( " & LotString & " ) is more than 7 days out.  Are you sure you wish to start it?", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.No Then
                    '                Return False
                    '            End If
                    '        End If
                    '    End If

                End If
            Else
                If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("shipped")) = False Then
                    If dsCancelOrderCheck.Tables(0).Rows(0)("shipped") > EDate Then
                        If MsgBox("This order ( " & LotString & " ) is more than 7 days out.  Are you sure you wish to start it?", MsgBoxStyle.YesNo, KPGeneral.ProgramName) = MsgBoxResult.No Then
                            Return False
                        End If
                    End If
                End If
            End If

            Dim PaintInfo As Integer = 0
            Dim RawInfo As Integer = 0

            If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("Raw")) = False Then
                RawInfo = dsCancelOrderCheck.Tables(0).Rows(0)("Raw")
            End If

            If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("Paint")) = False Then
                PaintInfo = dsCancelOrderCheck.Tables(0).Rows(0)("Paint")
            End If

            If RawInfo > 0 Or PaintInfo > 0 Then
                Dim result As Integer
                result = MessageBox.Show("Doors are not Ready ( " & LotString & " )! Are you sure you would like to proceed?", "WARNING - Doors Not Ready", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If result <> 6 Then
                    Return False
                End If
            End If

            If IsDBNull(dsCancelOrderCheck.Tables(0).Rows(0)("OnHold")) = False Then
                If dsCancelOrderCheck.Tables(0).Rows(0)("OnHold") = True Then
                    Return False
                End If
            End If
        End If



        Return True
    End Function

    Private Sub mniColumnChooser_Click(sender As Object, e As EventArgs) Handles mniColumnChooser.Click

        KPGeneral.ColumnChooser(Me.lvOrders, Me.GetType.Name)

    End Sub

    Private Sub btManageAssemblersAndClamps_Click(sender As Object, e As EventArgs) Handles btManageAssemblersAndClamps.Click

        Dim frmTemp As New frmManageAssemblersAndClamps
        frmTemp.ShowDialog()

    End Sub

    Private Sub tsColomnChooser_Click(sender As Object, e As EventArgs) Handles tsColomnChooser.Click
        KPGeneral.ColumnChooser(Me.ugPantries, Me.GetType.Name)
    End Sub

    Private Sub btnViewClampDetail8_Click(sender As Object, e As EventArgs) Handles btnViewClampDetail8.Click
        KPGeneral.ViewClampDetail(8)
    End Sub

    Private Sub btnPrintClampInfo8_Click(sender As Object, e As EventArgs) Handles btnPrintClampInfo8.Click
        PrintClampInfo(8)
    End Sub

    Private Sub ugAssemblyStart_MouseClick(sender As Object, e As MouseEventArgs) Handles ugAssemblyStart.MouseClick

        If e.Button = MouseButtons.Left Then
            Dim element As Infragistics.Win.UIElement = Me.ugAssemblyStart.DisplayLayout.UIElement.LastElementEntered
            If element Is Nothing Then
                Return
            End If
            Dim cell As UltraGridCell = TryCast(element.GetContext(GetType(UltraGridCell)), UltraGridCell)
            If cell Is Nothing Then
                Return
            End If
            Dim row As UltraGridRow = cell.Row
            If row IsNot Nothing AndAlso row.Index > -1 Then
                row.Cells("isSelected").Value = Not row.Cells("isSelected").Value
                ColourRows(ugAssemblyStart, row.Index)
                CalculateSelected()
            End If
        End If

    End Sub

End Class

