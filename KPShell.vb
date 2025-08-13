Imports Infragistics.Win.UltraWinToolbars
Imports System.Drawing.Printing

Public Class KPShell
    Dim RegularState As StateButtonTool
    Dim ServiceState As StateButtonTool
    Dim LayoutState As StateButtonTool
    Dim PricingState As StateButtonTool
    Dim ColoursState As StateButtonTool
    Dim FactoryState As StateButtonTool
    Dim DesignState As StateButtonTool
    Dim ForecastingState As StateButtonTool
    Dim FirstLogin As Boolean
    Public MDIChildrenInt As Integer

    Private m_PrintBitmap As Bitmap
    Private WithEvents m_PrintDocument As PrintDocument
    'Print Screen
    Private Declare Auto Function BitBlt Lib "gdi32.dll" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As System.Int32) As Boolean
    Private Const SRCCOPY As Integer = &HCC0020
    Private Declare Auto Function GetWindowDC Lib "user32" Alias "GetWindowDC" (ByVal hwnd As System.IntPtr) As System.IntPtr

    Dim LoginCancelled As Boolean
    Dim ToolbarSearched As Boolean = False

    Dim LoadedInstallerSchedule As Boolean = False

    Dim QuickAccessKey1 As String = ""
    Dim QuickAccessKey2 As String = ""
    Dim QuickAccessKey3 As String = ""
    Dim QuickAccessKey4 As String = ""

    Dim QuickAccessDisplay1 As String = ""
    Dim QuickAccessDisplay2 As String = ""
    Dim QuickAccessDisplay3 As String = ""
    Dim QuickAccessDisplay4 As String = ""

    Private Sub UltraExplorerBar1_GroupCollapsed(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.GroupEventArgs) Handles UltraExplorerBar1.GroupCollapsed
        If FirstLogin = False Then
            'KPGeneral.WebRef_Local.usp_UpdateUserGroupsExpanded(KPGeneral.User.UserProfile("UserLoginName"),
            'UltraExplorerBar1.Groups("Contracts").Expanded,
            'UltraExplorerBar1.Groups("Factory").Expanded,
            'UltraExplorerBar1.Groups("ReportingAlerts").Expanded,
            'UltraExplorerBar1.Groups("Product").Expanded,
            'UltraExplorerBar1.Groups("Miscellaneous").Expanded,
            'UltraExplorerBar1.Groups("Preferences").Expanded,
            'UltraExplorerBar1.Groups("Scheduling").Expanded,
            'UltraExplorerBar1.Groups("Service").Expanded,
            'UltraExplorerBar1.Groups("Sales").Expanded,
            'UltraExplorerBar1.Groups("WorkShop").Expanded,
            'UltraExplorerBar1.Groups("Mobile").Expanded,
            'UltraExplorerBar1.Groups("Purchasing").Expanded,
            'UltraExplorerBar1.Groups("Machinery").Expanded,
            'UltraExplorerBar1.Groups("Logistics").Expanded,
            'UltraExplorerBar1.Groups("Automation").Expanded,
            'UltraExplorerBar1.Groups("Accounting").Expanded,
            'UltraExplorerBar1.Groups("IT").Expanded,
            'UltraExplorerBar1.Groups("Assembly").Expanded,
            'UltraExplorerBar1.Groups("Doors").Expanded,
            'UltraExplorerBar1.Groups("Maintenance").Expanded,
            'UltraExplorerBar1.Groups("DOR").Expanded)
            KPGeneral.KPDataSQL.SP_EXEC("t_UpdateUpdateUserGroupsExpanded", KPGeneral.User.UserProfile("UserID"), KPGeneral.User.SecurityID(e.Group.Key), 0)
        End If
    End Sub
    Private Sub UltraExplorerBar1_GroupExpanded(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.GroupEventArgs) Handles UltraExplorerBar1.GroupExpanded
        If FirstLogin = False Then
            'KPGeneral.WebRef_Local.usp_UpdateUserGroupsExpanded(KPGeneral.User.UserProfile("UserLoginName"),
            'UltraExplorerBar1.Groups("Contracts").Expanded,
            'UltraExplorerBar1.Groups("Factory").Expanded,
            'UltraExplorerBar1.Groups("ReportingAlerts").Expanded,
            'UltraExplorerBar1.Groups("Product").Expanded,
            'UltraExplorerBar1.Groups("Miscellaneous").Expanded,
            'UltraExplorerBar1.Groups("Preferences").Expanded,
            'UltraExplorerBar1.Groups("Scheduling").Expanded,
            'UltraExplorerBar1.Groups("Service").Expanded,
            'UltraExplorerBar1.Groups("Sales").Expanded,
            'UltraExplorerBar1.Groups("WorkShop").Expanded,
            'UltraExplorerBar1.Groups("Mobile").Expanded,
            'UltraExplorerBar1.Groups("Purchasing").Expanded,
            'UltraExplorerBar1.Groups("Machinery").Expanded,
            'UltraExplorerBar1.Groups("Logistics").Expanded,
            'UltraExplorerBar1.Groups("Automation").Expanded,
            'UltraExplorerBar1.Groups("Accounting").Expanded,
            'UltraExplorerBar1.Groups("IT").Expanded,
            'UltraExplorerBar1.Groups("Assembly").Expanded,
            'UltraExplorerBar1.Groups("Doors").Expanded,
            'UltraExplorerBar1.Groups("Maintenance").Expanded,
            'UltraExplorerBar1.Groups("DOR").Expanded)
            KPGeneral.KPDataSQL.SP_EXEC("t_UpdateUpdateUserGroupsExpanded", KPGeneral.User.UserProfile("UserID"), KPGeneral.User.SecurityID(e.Group.Key), 1)
        End If
    End Sub

    ' UltraExplorerBar1 Group/Item keys
    ' Group
    '   - Item
    '
    ' Contracts
    '	- Orders
    '   - Builders
    '	- Projects
    '	- Takeoffs
    '	- ExtrasList
    '   - LayoutProgress
    '   - LayoutManager
    '   - RequiredLayouts
    '   - AdvancedSearch
    '   - AdvancedSearchMedia
    '   - MissingMeasurementVerify
    '   - PreProductionStatus
    '   - DealerOrders
    '   - ChangeOrders
    ' WorkShop
    '   - WorkShop_Parts2
    '   - PartsProperty
    '   - PartFamilyManager
    '   - WorkshopStations
    '   - WorkshopJobTemplate
    '   - InventoryResults
    ' Scheduling
    '   - MeasuringManager
    '   - Scheduling
    '   - ProductionBatch
    '   - ProductionGroup
    '   - WeeklySchedule
    '   - WeeklyScheduleGreg
    '	- RevisedOrders
    '   - PreProduction
    '   - Holiday
    '   - PreProductionBatch
    '   - RushTracker
    '   - ScheduleNotice
    '   - MeasurerWeeklySchedule
    '   - PostProductionStatus
    ' Mobile
    '   - MeasuringApp
    '   - MobileMeasuring
    '   - Service Mobile
    '   - ModelSketches
    '   - DIIUserManagement
    '   - DealerPortalUserManagement
    '   - DIIInstalls
    '   - ProjectManagers
    '   - RecentMedia
    '   - KitchenTrackerLiteAccess
    '   - AssignPSM
    ' Service
    '   - ServiceTimeLog
    '   - ServiceBooking
    '   - InspectionCompletion
    '   - ServicePO
    '   - ServiceStatus
    '   - ServicePartTracker
    ' Sales
    '   - SampleDoors
    '   - SalesProjectAssignment
    '	- SalesForecast
    '	- QuoteRegister
    '   - DesignStudioSales
    '   - SampleDoorInventory
    ' ReportingAlerts
    '	- Dashboard
    '	- ReportEngine
    '	- BOMReportBuilder
    '	- WatchList
    '	- Reminders	
    '   - InstantReports
    '   - TrendReports
    '   - TonyDashboard
    ' Product
    '	- SearchCatalogue
    '	- Gallery
    '   - CatalogueImages
    '   - DoorImages
    '   - DoorMatrix
    '   - ManageCounterTop
    '   - 2020Library
    '   - LibraryImages
    '   - ProductUpdates
    '   - NSPRequests
    ' Purchasing
    '   - ProductForecasting
    '   - HardwareForecasting
    '   - MaterialForecasting
    '   - DoorOrders
    '   - PurchaseRequests
    '   - OrderList
    '   - PurchasingAlerts
    '   - PurchasingRequest
    '   - PurchasingCalendar
    '   - DoorForecasting
    ' Miscellaneous
    '   - DocumentCleanup
    '	- Styles
    '	- Colours
    '	- CounterTops
    '	- Hardware
    '   - Rooms
    '   - InstallerInfo
    '	- EmployeeDirectory
    '   - WebMail
    '   - ShowroomScan
    '   - Regions
    '   - MissingFKWO
    '   - DriverInfo
    '   - OrderLocations
    '   - RecentCopierScans
    '   - MediaSlideshow
    '   - ManageDeficiencyReason
    ' Factory
    '   - KitchenTracker
    '   - DailyProduction
    '   - ProductionStatus
    '   - ProductionLineSnapshot
    '   - WeeklyShopStats
    '   - AssemblyLineSnapshot
    '   - DoorsReadySnapshot
    '   - InstallerSchedule
    '   - KitchenReady
    '   - FactoryDeficiency
    '   - Label4x6
    '   - BackPanels
    '   - Productivity
    '   - CuttingMilling
    '   - PlineScan
    '	- Custom
    '   - DrawerBoxSummary
    '   - PaintInfo
    '   - Wrapping
    '   - BOMForecast
    '   - PaintSchedule
    '   - PaintScheduleView
    '   - WrappingQueue
    '   - WrappingPrint
    '   - DoorBoxLocation
    '   - CounterTopProduction
    '   - TemperatureReadings
    '   - StockDoorOrder
    '   - ShopAttendance
    ' Machinery
    '   - PaintShopLogs
    '   - EdgeBander
    '   - MachineShopData
    '   - MaintenanceTickets
    '   - MachineStatus
    ' Logistics
    '   - CartLookup
    '   - LocationOfOrder
    '   - VehicleRouting
    '   - CartLocation
    '   - WarehouseTracker
    '   - Shipping
    '   - DriverScan
    '   - AccessoryLabels
    '   - AccessoryScan
    '   - AccessoriesChecked
    '   - FleetManagement
    '   - LoadingDockCheckIn
    '   - DeliveryLoads
    '   - PartsShipping
    ' Preferences
    '	- Profile
    '	- UserSecurity
    '   - KitQueues
    '   - InsightAdmin
    '   - Add2020File
    '   - DoorOrderAdmin
    '   - Kit2XML
    '   - Kit2BOM
    '   - WeeklyProductionNotes
    '   - FactoryAssignmentAdmin
    '   - UserPrinterSettings
    '   - AdvancedFunctions
    ' Automation
    '   - PantryLabels
    '   - NightlyReportEmail
    '   - DummyDoor
    '   - TandemBoxPrint
    '   - CustomCabinets
    '   - LayoutPrint
    '   - NeedLayout
    '   - OnDemandPrinting
    ' Accounting
    '   - Completions
    '   - DriverPay
    '   - InstallerPay
    '   - CutlerOrders
    '   - WestonOrders
    ' IT
    '   - PrinterInventory
    '   - ITLists
    '   - ComputerInventory
    '   - SoftwareLicenses
    '   - ComputerLookup
    '   - DevicePingLog
    '   - Phones
    '   - DomainInfo
    '   - MailingListEmails
    '   - UntangleChangeLog
    '   - Invoices
    '   - Vendors
    '   - ITDLLFiles
    '   - VendorDocuments
    '   - SequenceFormToSecurity
    '   - StoredProcedureLog
    ' Assembly
    '   - Label4x8
    '   - AssemblyStart
    '   - ServiceCabinets
    '   - OrdersPicked
    '   - AssignClamps
    '   - Clamps
    '   - Tandembox
    ' Doors
    '   - DoorsPicked
    '   - Hinge
    '   - RawDoor
    '   - PaintedDoor
    '   - DoorsOnDemand
    '   - DoorListJoin
    '   - DoorSummary
    '   - ForkliftDoorBoxes

    Public Function CheckMDIChildren(ByVal FormName As String) As Boolean
        ' Loop through all MDI Children to see if the form exists.
        Dim x As Integer
        If Me.MdiChildren.Length > 0 Then
            For x = 0 To Me.MdiChildren.Length - 1
                If Me.MdiChildren(x).Name = FormName Then
                    ' Form exists, set the child integer for recall later and return true
                    MDIChildrenInt = x
                    Return True
                End If
            Next
        End If

        ' Form not loaded yet.  Return false.
        Return False
    End Function
    Private Sub UltraExplorerBar1_ItemClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles UltraExplorerBar1.ItemClick
        Me.Cursor = Cursors.WaitCursor

        LoadForm(e.Item.Key)

        Me.Cursor = Cursors.Default
    End Sub
    Public Sub RemoteLoadForm(ByVal FormName As String)
        CheckFormNames(FormName)
        LoadForm(FormName)
    End Sub
    Public Sub LoadForm(ByVal FormName As String)
        Dim FormOpened As Boolean = False
        Dim isShowDialogue As Boolean = False

        Dim GroupKey As String
        Dim MatchKey As Boolean = False

        Dim frmName, FormNameFull, FormNameText As String

        Dim x, y As Integer
        For x = 0 To UltraExplorerBar1.Groups.Count - 1
            For y = 0 To UltraExplorerBar1.Groups(x).Items.Count - 1
                GroupKey = UltraExplorerBar1.Groups(x).Key.ToLower

                If UltraExplorerBar1.Groups(x).Items(y).Key.ToLower = FormName.ToLower Then
                    MatchKey = True
                    Exit For
                End If
            Next
            If MatchKey = True Then
                Exit For
            End If
        Next

        Dim ProcessForm As Boolean = True

        If MatchKey = True Then
            Dim dsFormInfo As New DataSet
            dsFormInfo = KPGeneral.WebRef_Local.usp_GetSequenceFormToSecurity_ByGroupAndItemKey(GroupKey, FormName)

            If dsFormInfo.Tables(0).Rows.Count > 0 Then
                If IsDBNull(dsFormInfo.Tables(0).Rows(0)("FormName")) = False Then
                    frmName = "SequenceERP." & dsFormInfo.Tables(0).Rows(0)("FormName")
                Else
                    MsgBox("This form doesn't have the full info needed.  Please speak to IT before continuing.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                    Exit Sub
                End If

                If IsDBNull(dsFormInfo.Tables(0).Rows(0)("ItemKey")) = False Then
                    FormNameFull = dsFormInfo.Tables(0).Rows(0)("ItemKey")
                Else
                    MsgBox("This form doesn't have the full info needed.  Please speak to IT before continuing.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                    Exit Sub
                End If

                If IsDBNull(dsFormInfo.Tables(0).Rows(0)("ItemText_Tab")) = False Then
                    FormNameText = dsFormInfo.Tables(0).Rows(0)("ItemText_Tab")
                Else
                    MsgBox("This form doesn't have the full info needed.  Please speak to IT before continuing.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                    Exit Sub
                End If

                If IsDBNull(dsFormInfo.Tables(0).Rows(0)("isShowDialogue")) = False Then
                    isShowDialogue = dsFormInfo.Tables(0).Rows(0)("isShowDialogue")
                End If

                Select Case FormName
                    Case "Reminders"
                        KPGeneral.RemindersPageNum = 1
                    Case "Productivity"
                        Password.txtPassword.Text = Nothing
                        Password.ShowDialog()

                        If KPGeneral.AccessPassword = "FKL" Then
                            KPGeneral.AccessPassword = Nothing
                        Else
                            KPGeneral.AccessPassword = Nothing
                            MsgBox("Incorrect password", MsgBoxStyle.Information, KPGeneral.ProgramName)
                            Exit Sub
                        End If
                    Case "ShopAttendance"
                        Password.txtPassword.Text = Nothing
                        Password.ShowDialog()

                        If KPGeneral.Encrypt_Pass(KPGeneral.AccessPassword) = KPGeneral.User.UserProfile("Password") Then
                            KPGeneral.AccessPassword = Nothing
                        Else
                            KPGeneral.AccessPassword = Nothing
                            MsgBox("Incorrect password", MsgBoxStyle.Information, KPGeneral.ProgramName)
                            Exit Sub
                        End If
                    Case "AdvancedSearch"
                        frmAdvancedSearchLayouts.MissingMeasurements = False
                    Case "Dashboard"
                        FormOpened = True
                        ProcessForm = False
                        LoadNormalDashboard()

                        'Case "KitchenTracker"
                        '    FormOpened = True
                        '    If CheckMDIChildren("KitchenTracker") = True Then
                        '        ' if the form is open, activate it.
                        '        Me.MdiChildren(MDIChildrenInt).Activate()
                        '    Else
                        '        ' form isn't open, open it.
                        '        Dim frmKitchenTracker As New frmLayout
                        '        frmKitchenTracker.MdiParent = Me
                        '        frmKitchenTracker.Show()
                        '        frmKitchenTracker.Name = "KitchenTracker"
                        '        frmKitchenTracker.Dock = DockStyle.Fill
                        '        frmKitchenTracker.Text = "Kitchen Tracker"
                        '    End If
                        '    Exit Sub
                End Select


                If ProcessForm = True Then
                    Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
                    Dim obj = myAssembly.GetType(frmName).InvokeMember(Nothing, Reflection.BindingFlags.CreateInstance, Nothing, Nothing, Nothing)
                    Dim frm As Form = CType(obj, System.Windows.Forms.Form)

                    ' Check to see if the form is already open
                    If CheckMDIChildren(FormNameFull) = True Then
                        ' if the form is open, activate it.
                        Me.MdiChildren(MDIChildrenInt).Activate()
                    Else
                        FormOpened = True

                        If isShowDialogue = False Then
                            ' form isn't open, open it.
                            frm.MdiParent = Me
                            frm.Show()
                            frm.Name = FormNameFull
                            frm.Dock = DockStyle.Fill
                            frm.Text = FormNameText
                        Else
                            frm.ShowDialog()
                        End If

                    End If
                End If

            Else
                ProcessManualForm(FormName)
            End If
        Else
            If CheckMDIChildren(FormName) = True Then
                ' if the form is open, activate it.
                Me.MdiChildren(MDIChildrenInt).Activate()
            Else
                ProcessManualForm(FormName)
            End If
        End If

        If ToolbarSearched = True Then
            SearchToolbar(False, FormName)
            ToolbarSearched = False
        End If

        If FormOpened = True Then
            KPGeneral.WebRef_Local.usp_FormProgramViewLog(FormName, KPGeneral.User.UserProfile("UserLoginName"))
        End If
    End Sub
    Private Sub ProcessManualForm(ByVal FormName As String)
        Dim frmName, FormNameFull, FormNameText As String
        Dim ProcessForm As Boolean = True
        Dim FormOpened As Boolean = False
        Dim isPopup As Boolean = False

        Select Case FormName
            Case "LayoutHome"
                frmName = "SequenceERP.frmLayoutHome"
                FormNameFull = "LayoutHome"
                FormNameText = "Layout Home"
            Case "SalesHome"
                frmName = "SequenceERP.frmSalesHome"
                FormNameFull = "SalesHome"
                FormNameText = "Sales Home"
            Case "DeliverySchedule"
                frmName = "SequenceERP.frmDeliverySchedule"
                FormNameFull = "DeliverySchedule"
                FormNameText = "Delivery Schedule"
            Case "ProductionCalendar"
                frmName = "SequenceERP.frmProductionCalendar"
                FormNameFull = "ProductionCalendar"
                FormNameText = "Production Calendar"
            Case "APTSchedule"
                frmName = "SequenceERP.frmAPTSchedule"
                FormNameFull = "APTSchedule"
                FormNameText = "APT Schedule"
                isPopup = True
        End Select

        If frmName Is Nothing = False Then
            If ProcessForm = True Then
                FormOpened = True
                Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
                Dim obj = myAssembly.GetType(frmName).InvokeMember(Nothing, Reflection.BindingFlags.CreateInstance, Nothing, Nothing, Nothing)
                Dim frm As Form = CType(obj, System.Windows.Forms.Form)

                ' form isn't open, open it.
                If isPopup = False Then
                    frm.MdiParent = Me
                End If

                Select Case FormName
                    Case "AdvancedSearch"
                        frmAdvancedSearchLayouts.MissingMeasurements = False
                End Select
                frm.Show()

                If isPopup = False Then
                    frm.Name = FormNameFull
                    frm.Dock = DockStyle.Fill
                    frm.Text = FormNameText
                End If

            End If

            If ToolbarSearched = True Then
                SearchToolbar(False, FormName)
                ToolbarSearched = False
            End If

            If FormOpened = True Then
                KPGeneral.WebRef_Local.usp_FormProgramViewLog(FormName, KPGeneral.User.UserProfile("UserLoginName"))
            End If
        End If

    End Sub
    Private Sub KPShell_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If LoginCancelled = False Then
            Dim UID As String
            UID = KPGeneral.User.UserProfile("UserLoginName")

            If UID.ToLower = "dereks" Or UID.ToLower = "kevinl" Then

            Else
                Dim mResult As MsgBoxResult
                mResult = MsgBox("Are you sure you wish to close Sequence?", MsgBoxStyle.YesNo, KPGeneral.ProgramName)

                If mResult = MsgBoxResult.No Then
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If
            End If

        End If

    End Sub
    Private Sub KPShell_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Register Syncfusion License
        'Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjM2MjgyOEAzMjMxMmUzMDJlMzBrenZuMWVkZHY3dmsyOURvNUkvSGFmdEp0K0VxTUJRdTBPWlArbGFMY2FNPQ==")
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc3NTk2N0AzMjMzMmUzMDJlMzBnOHozSXEySE9lK1ljd3U3S3lZWWIvWHNUNTdNUEh6WlJDZXlsU0xCN2FZPQ==")

        KPGeneral.isTestDB = DB.isTestDB
        KPGeneral.Category = "Regular"
        KPGeneral.ClickCount = 0

        StartupChecks.CheckFolders()
        KPGeneral.GenerateLocalMacAddressList()

        LoadProject(False)
    End Sub
    Public Sub LoadNormalDashboard()
        Me.Cursor = Cursors.WaitCursor
        'If CheckMDIChildren("Dashboard") = True Then
        '    Me.MdiChildren(MDIChildrenInt).Close()
        '    Dim frmDashBoard As New Dashboard
        '    frmDashBoard.MdiParent = Me
        '    frmDashBoard.Show()
        '    frmDashBoard.Dock = DockStyle.Fill
        '    'Dashboard.ReloadDashboard()
        '    'Me.MdiChildren(MDIChildrenInt).Activate()
        'Else
        Dim frmDashBoard As New Dashboard
        frmDashBoard.MdiParent = Me
        frmDashBoard.Show()
        frmDashBoard.Dock = DockStyle.Fill
        'End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadNormalReports()
        If CheckMDIChildren("Reminders") = True Then
            ' if the form is open, activate it.
            Me.MdiChildren(MDIChildrenInt).Activate()
        Else
            ' form isn't open, open it.
            KPGeneral.RemindersPageNum = 1
            Dim frmAlerts As New Alerts
            frmAlerts.MdiParent = Me
            frmAlerts.Show()
            frmAlerts.Name = "Reminders"
            frmAlerts.Dock = DockStyle.Fill
            frmAlerts.Text = "Reminders"
        End If
    End Sub
    'Private Sub ConfirmMacAddresses()
    'For Each nic As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
    '    If nic.GetPhysicalAddress.ToString.Length = 12 Then
    '        'dr = dsLocalMac.Tables(0).NewRow

    '        Dim mac1 As String
    '        mac1 = nic.GetPhysicalAddress.ToString
    '        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder(mac1)
    '        sb.Insert(2, "-")
    '        sb.Insert(5, "-")
    '        sb.Insert(8, "-")
    '        sb.Insert(11, "-")
    '        sb.Insert(14, "-")

    '        Dim MacAddress, Description, Hostname, AccessedIP As String

    '        MacAddress = sb.ToString
    '        Description = nic.Description
    '        Hostname = System.Net.Dns.GetHostName.ToString
    '        AccessedIP = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName.ToString).AddressList(0).ToString
    '        Dim x As Integer
    '        For x = 0 To System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName.ToString).AddressList.Length - 1
    '            If System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName.ToString).AddressList(x).ToString.Contains(":") = False Then
    '                AccessedIP = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName.ToString).AddressList(x).ToString
    '                Exit For
    '            End If
    '        Next

    '        KPGeneral.CurrentMacAddress = MacAddress
    '        KPGeneral.CurrentIPAddress = AccessedIP
    '        KPGeneral.CurrentHostName = Hostname

    '        Dim TotalMemory As String = System.Math.Round(My.Computer.Info.TotalPhysicalMemory / (1024 * 1024)) & " MB"

    '        'If AccessedIP.Contains(":") Then
    '        '    AccessedIP = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName.ToString).AddressList(1).ToString
    '        'End If

    '        KPGeneral.WebRef_Local.spKP_UpdateUserMac_LastAccessed(MacAddress, Description, KPGeneral.User.UserProfile("UserLoginName"), Hostname, AccessedIP,
    '                                                               Convert.ToString(System.Reflection.Assembly.GetExecutingAssembly.GetName.Version()), TotalMemory)
    '    End If
    '    'MessageBox.Show(String.Format("The MAC address of {0} is{1}{2}", nic.Description, Environment.NewLine, nic.GetPhysicalAddress()))
    'Next
    'End Sub
    Private Sub InitializeKPGeneralInfo()
        KPGeneral.dsSavedFiles.Tables.Clear()

        KPGeneral.dsSavedFiles.Tables.Add()
        KPGeneral.dsSavedFiles.Tables(0).Columns.Add("FilePath")
        KPGeneral.dsSavedFiles.Tables(0).Columns.Add("XMLPath")
        KPGeneral.dsSavedFiles.Tables(0).Columns.Add("Completed")
        KPGeneral.dsSavedFiles.Tables(0).Columns.Add("Room")
        KPGeneral.dsSavedFiles.Tables(0).Columns.Add("SendPath")
    End Sub
    Private Sub LoadProject(ByVal SkipLoginScreen As Boolean)
        Dim ContinueLoading As Boolean = False

        If SkipLoginScreen = True Then
            ContinueLoading = True
        Else
            If Login.ShowDialog = Windows.Forms.DialogResult.OK Then
                ContinueLoading = True
            End If
        End If

        If ContinueLoading = True Then

            'SecurityChecks.RefreshSecurityChecks()
            'StartupChecks.CheckShortcuts()

            LoadMenuFromDB()
            FormTimers.RefreshTimers()
            KPGeneral.CurrentHostName = System.Net.Dns.GetHostName.ToString() 'ConfirmMacAddresses()
            KPGeneral.KPDataSQL.SP_EXEC("spKP_UpdateUserMac_LastAccessed",
                                        DBNull.Value,
                                        DBNull.Value,
                                        KPGeneral.User.UserProfile("UserLoginName"),
                                        KPGeneral.CurrentHostName,
                                        System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName.ToString).AddressList(0).ToString,
                                        Convert.ToString(System.Reflection.Assembly.GetExecutingAssembly.GetName.Version()),
                                        System.Math.Round(My.Computer.Info.TotalPhysicalMemory / (1024 * 1024)) & " MB")
            Dim DLLFileCheck As Boolean = StartupChecks.CheckHostVersion

            If DLLFileCheck = False Then
                Dim FilesUpdated As Integer = StartupChecks.CheckDLL

                If FilesUpdated > 0 Then
                    MsgBox("There were some files that were updated that may affect the program.  Please close and re-open Sequence to make sure everything works correctly.", MsgBoxStyle.OkOnly, KPGeneral.ProgramName)
                Else

                End If

                KPGeneral.WebRef_Local.usp_InsertSequenceFileCheck(KPGeneral.CurrentHostName, Convert.ToString(System.Reflection.Assembly.GetExecutingAssembly.GetName.Version()), FilesUpdated)
            End If

            FirstLogin = True
            LoginCancelled = False
            KPGeneral.ProgramName = "Sequence ERP"
            KPGeneral.Category = "Regular"
            KPGeneral.ProductionDefsInstaller = False
            KPGeneral.dsFormNames = KPGeneral.WebRef_Local.usp_GetUserSecurityFormsByUserID(KPGeneral.User.UserProfile("UserLoginName"))

            InitializeKPGeneralInfo()

            StatusColours.RefreshStatusColours()

            RegularState = CType(UTM.Tools("btnRegular"), StateButtonTool)
            ServiceState = CType(UTM.Tools("btnService"), StateButtonTool)
            LayoutState = CType(UTM.Tools("btnLayout"), StateButtonTool)
            PricingState = CType(UTM.Tools("btnPricing"), StateButtonTool)
            ColoursState = CType(UTM.Tools("btnColours"), StateButtonTool)
            FactoryState = CType(UTM.Tools("btnFactory"), StateButtonTool)
            DesignState = CType(UTM.Tools("btnDesignStudio"), StateButtonTool)
            ForecastingState = CType(UTM.Tools("btnForecasting"), StateButtonTool)
            LoadFormLook()
            LoadSecurity()
            RegularState.InitializeChecked(True)

            If KPGeneral.User.UserProfile("UserLoginName").ToString.ToLower.Contains("loadingdock") Then
                UltraExplorerBar1.Visible = False
                LoadDiverScan()
                Me.WindowState = FormWindowState.Maximized
                UTMM.Enabled = False
            ElseIf KPGeneral.User.UserProfile("UserLoginName").ToString.ToLower = "wrapping" Then
                UltraExplorerBar1.Visible = False
                LoadWrapping(False)
                UTMM.Enabled = False
            ElseIf KPGeneral.User.UserProfile("UserLoginName").ToString.ToLower = "wrappingqueue" Then
                UltraExplorerBar1.Visible = False
                LoadWrapping(True)
                UTMM.Enabled = False
            ElseIf KPGeneral.User.UserProfile("UserLoginName").ToString.ToLower.Contains("pantryprint") Then
                'UltraExplorerBar1.Visible = False
                LoadPantryPrint()
                'UTMM.Enabled = False
            ElseIf KPGeneral.User.UserProfile("UserLoginName").ToString.ToLower.Contains("tandembox") Then
                'UltraExplorerBar1.Visible = False
                'LoadTandembotPrint()
                'UTMM.Enabled = False
            ElseIf KPGeneral.User.UserProfile("UserLoginName").ToString.ToLower.Contains("stockroom") Then
                ' UltraExplorerBar1.Visible = False
                LoadStockroom()
                UTMM.Enabled = False
            ElseIf KPGeneral.User.UserProfile("UserLoginName").ToString.ToLower.Contains("countertop") Then
                LoadForm("CounterTopProduction")
                UltraSplitter1.Collapsed = True
                Me.WindowState = FormWindowState.Maximized
            Else
                UltraExplorerBar1.Visible = True
                If IsDBNull(KPGeneral.User.UserProfile("Form1")) = False Then
                    If KPGeneral.User.UserProfile("Form1").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form1"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form1"))
                    End If
                Else
                    If KPGeneral.User.UserProfile("DashboardStart") = True Then
                        LoadNormalDashboard()
                    Else
                        LoadNormalReports()
                    End If
                End If

                If IsDBNull(KPGeneral.User.UserProfile("Form2")) = False Then
                    If KPGeneral.User.UserProfile("Form2").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form2"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form2"))
                    End If
                    'LoadForm(KPGeneral.UserProfile.Tables(0).Rows(0)("Form2"))
                Else

                End If
                If IsDBNull(KPGeneral.User.UserProfile("Form3")) = False Then
                    If KPGeneral.User.UserProfile("Form3").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form3"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form3"))
                    End If
                    'LoadForm(KPGeneral.UserProfile.Tables(0).Rows(0)("Form3"))
                Else

                End If
                If IsDBNull(KPGeneral.User.UserProfile("Form4")) = False Then
                    If KPGeneral.User.UserProfile("Form4").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form4"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form4"))
                    End If
                    'LoadForm(KPGeneral.UserProfile.Tables(0).Rows(0)("Form4"))
                Else

                End If
                If IsDBNull(KPGeneral.User.UserProfile("Form5")) = False Then
                    If KPGeneral.User.UserProfile("Form5").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form5"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form5"))
                    End If
                    'LoadForm(KPGeneral.UserProfile.Tables(0).Rows(0)("Form5"))
                Else

                End If
                If IsDBNull(KPGeneral.User.UserProfile("Form6")) = False Then
                    If KPGeneral.User.UserProfile("Form6").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form6"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form6"))
                    End If
                    'LoadForm(KPGeneral.UserProfile.Tables(0).Rows(0)("Form6"))
                Else

                End If
                If IsDBNull(KPGeneral.User.UserProfile("Form7")) = False Then
                    If KPGeneral.User.UserProfile("Form7").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form7"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form7"))
                    End If
                    'LoadForm(KPGeneral.UserProfile.Tables(0).Rows(0)("Form7"))
                Else

                End If
                If IsDBNull(KPGeneral.User.UserProfile("Form8")) = False Then
                    If KPGeneral.User.UserProfile("Form8").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form8"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form8"))
                    End If
                    'LoadForm(KPGeneral.UserProfile.Tables(0).Rows(0)("Form8"))
                Else

                End If
                If IsDBNull(KPGeneral.User.UserProfile("Form9")) = False Then
                    If KPGeneral.User.UserProfile("Form9").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form9"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form9"))
                    End If
                    'LoadForm(KPGeneral.UserProfile.Tables(0).Rows(0)("Form8"))
                Else

                End If
                If IsDBNull(KPGeneral.User.UserProfile("Form10")) = False Then
                    If KPGeneral.User.UserProfile("Form10").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form10"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form10"))
                    End If
                    'LoadForm(KPGeneral.UserProfile.Tables(0).Rows(0)("Form8"))
                Else

                End If
                If IsDBNull(KPGeneral.User.UserProfile("Form11")) = False Then
                    If KPGeneral.User.UserProfile("Form11").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form11"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form11"))
                    End If
                    'LoadForm(KPGeneral.UserProfile.Tables(0).Rows(0)("Form8"))
                Else

                End If
                If IsDBNull(KPGeneral.User.UserProfile("Form12")) = False Then
                    If KPGeneral.User.UserProfile("Form12").ToString.ToLower.Contains("dashboard") Then
                        AutoLoadOtherDashboard(KPGeneral.User.UserProfile("Form12"))
                    Else
                        LoadForm(KPGeneral.User.UserProfile("Form12"))
                    End If
                    'LoadForm(KPGeneral.UserProfile.Tables(0).Rows(0)("Form8"))
                Else

                End If
                UTMM.Enabled = True
            End If

            StyleProgressBars()

            If KPGeneral.isTestDB = True Then
                Me.Text = "Sequence ERP - TEST!!!!"
                UltraExplorerBar1.Appearance.BackColor = Color.LightSalmon
            Else
                Me.Text = "Sequence ERP"
            End If

            LoadHomeScreen()

            'TestLoadDynamic()

            FirstLogin = False

            StartupChecks.ClearColumnChooserGrids()
        Else
            LoginCancelled = True
            System.Windows.Forms.Application.Exit()
        End If
    End Sub
    Private Sub CheckFormNames(ByVal FormName As String)
        Dim x As Integer
        If KPGeneral.dsFormNames Is Nothing = False Then
            For x = 0 To KPGeneral.dsFormNames.Tables(0).Rows.Count - 1
                If KPGeneral.dsFormNames.Tables(0).Rows(x).RowState <> DataRowState.Deleted Then
                    If KPGeneral.dsFormNames.Tables(0).Rows(x)("FormName").ToString.ToLower = FormName.ToLower Then
                        KPGeneral.dsFormNames.Tables(0).Rows(x).Delete()
                        Exit Sub
                    End If
                End If
            Next
        End If

    End Sub
#Region " Security "
    Private Sub LoadOtherSecurity()
        UltraExplorerBar1.Visible = True

        Dim x, y As Integer
        For x = 0 To UltraExplorerBar1.Groups.Count - 1
            Dim GroupName As String = UltraExplorerBar1.Groups(x).Key

            Select Case GroupName
                Case "Contracts"
                    If KPGeneral.User.UserProfile("HideOrders") Then
                        UltraExplorerBar1.Groups(GroupName).Visible = False
                    Else
                        For y = 0 To UltraExplorerBar1.Groups(GroupName).Items.Count - 1
                            Dim ItemKey As String = UltraExplorerBar1.Groups(GroupName).Items(y).Key

                            Dim MatchItem As Boolean = False

                            Select Case ItemKey.ToLower
                                Case "orders"
                                    MatchItem = True
                                Case "projects"
                                    MatchItem = True
                                Case "advancedsearch"
                                    MatchItem = True
                            End Select

                            If MatchItem = True Then
                                UltraExplorerBar1.Groups(GroupName).Items(y).Visible = True
                            End If
                        Next

                        UltraExplorerBar1.Groups(GroupName).Visible = True
                    End If

                    For y = 0 To UltraExplorerBar1.Groups(GroupName).Items.Count - 1
                        Dim ItemKey As String = UltraExplorerBar1.Groups(GroupName).Items(y).Key

                        Dim MatchItem As Boolean = False

                        Select Case ItemKey.ToLower
                            Case "takeoffs"
                                MatchItem = True
                            Case "takeoffs_new"
                                MatchItem = True
                        End Select

                        If MatchItem = True Then
                            Dim Match As Boolean
                            If KPGeneral.User.UserProfile("Takeoffs_NewDesign") Or KPGeneral.User.UserProfile("Takeoffs") Or KPGeneral.User.UserProfile("Takeoffsro") Then
                                Match = True
                            Else
                                Match = False
                            End If

                            UltraExplorerBar1.Groups(GroupName).Items(y).Visible = Match

                            If KPGeneral.User.UserProfile("Takeoffs") = False And KPGeneral.User.UserProfile("Takeoffsro") = False Then
                                CheckFormNames(ItemKey)
                            End If
                        End If
                    Next
                Case "Preferences"
                    For y = 0 To UltraExplorerBar1.Groups(GroupName).Items.Count - 1
                        Dim ItemKey As String = UltraExplorerBar1.Groups(GroupName).Items(y).Key

                        Dim MatchItem As Boolean = False

                        Select Case ItemKey.ToLower
                            Case "usersecurity"
                                MatchItem = True
                            Case "kit2xml"
                                MatchItem = True
                            Case "kit2bom"
                                MatchItem = True
                            Case "kitqueues"
                                MatchItem = True
                            Case "add2020file"
                                MatchItem = True
                            Case "doororderadmin"
                                MatchItem = True
                            Case "profile"
                                MatchItem = True
                        End Select

                        'If MatchItem = True Then
                        '    UltraExplorerBar1.Groups(GroupName).Items(y).Visible = KPGeneral.User.IsAdmin
                        'End If
                        If KPGeneral.User.IsAdmin Then
                            UltraExplorerBar1.Groups(GroupName).Items(y).Visible = True
                        Else
                            UltraExplorerBar1.Groups(GroupName).Items(y).Visible = KPGeneral.User.UserProfile(ItemKey) Or MatchItem
                        End If
                    Next
            End Select


        Next
        UTM.Tools("btnQuoteRegistry").SharedProps.Enabled = KPGeneral.User.UserProfile("TakeOffs")
        'check to see if the user can select multi-dashboards
        UTM.Tools("mnuDashboardCategory").SharedProps.Visible = KPGeneral.User.UserProfile("MultiDash")
        UTM.Tools("mnuShowRoom").SharedProps.Visible = KPGeneral.User.UserProfile("PurchaseAgreement")
        UTM.Tools("btnNewContract").SharedProps.Enabled = KPGeneral.User.UserProfile("TakeOffs")
        UTM.Tools("btnnewpurchaseagreement").SharedProps.Enabled = KPGeneral.User.UserProfile("PurchaseAgreement")
        UTM.Tools("btnNewPrivateOrder").SharedProps.Enabled = KPGeneral.User.UserProfile("PurchaseAgreement")
        UTM.Tools("btnNewBuilder").SharedProps.Enabled = KPGeneral.User.UserProfile("BuilderInfoUpdate")
        If KPGeneral.User.IsAdmin Then
            UTM.Tools("btnNewProject").SharedProps.Enabled = True
            UTM.Tools("btnSystemColourViewer").SharedProps.Visible = True
            UTM.Tools("btnBuggyUpdate").SharedProps.Visible = True
        Else
            UTM.Tools("btnnewproject").SharedProps.Enabled = KPGeneral.User.UserProfile("NewContract")
            UTM.Tools("btnSystemColourViewer").SharedProps.Visible = False
            UTM.Tools("btnBuggyUpdate").SharedProps.Visible = False
        End If
        UTM.Tools("btnNewXKWizard").SharedProps.Enabled = KPGeneral.User.UserProfile("check25")
        UTM.Tools("btnDeliverySchedule").SharedProps.Enabled = KPGeneral.User.UserProfile("DeliverySchedule")
        UTM.Tools("btnAPTSchedule").SharedProps.Visible = KPGeneral.User.UserProfile("APTSchedule")
        UTM.Tools("btnProductionCalendar").SharedProps.Enabled = KPGeneral.User.UserProfile("ProductionCalendar")

    End Sub
    Private Sub CheckGroupSecurity(ByVal GroupName As String)
        Dim GroupCount As Integer = 0

        LoadedInstallerSchedule = False

        Dim dsGroup As New DataSet
        dsGroup = KPGeneral.WebRef_Local.usp_GetSequenceFormToSecurity_ByGroup(GroupName)

        Dim y As Integer
        For y = 0 To UltraExplorerBar1.Groups(GroupName).Items.Count - 1
            Dim ItemKey As String = UltraExplorerBar1.Groups(GroupName).Items(y).Key.ToLower
            Dim MatchedSecurity As Boolean = False

            Dim x As Integer
            For x = 0 To dsGroup.Tables(0).Rows.Count - 1
                Dim SQLColumnName, KPShellItemName, KPShellGroupName As String

                If IsDBNull(dsGroup.Tables(0).Rows(x)("SQLColumnName")) = False Then
                    SQLColumnName = dsGroup.Tables(0).Rows(x)("SQLColumnName")
                    If IsDBNull(dsGroup.Tables(0).Rows(x)("ItemKey")) = False Then
                        KPShellItemName = dsGroup.Tables(0).Rows(x)("ItemKey")
                        If IsDBNull(dsGroup.Tables(0).Rows(x)("GroupName")) = False Then
                            KPShellGroupName = dsGroup.Tables(0).Rows(x)("GroupName")
                            If SQLColumnName.Trim.Length > 0 And KPShellItemName.Trim.Length > 0 And KPShellGroupName.Trim.Length > 0 Then
                                If KPShellItemName.ToLower = ItemKey.ToLower Then
                                    MatchedSecurity = True
                                    If CheckItemSecurity(SQLColumnName, KPShellItemName, KPShellGroupName) = True Then
                                        GroupCount = GroupCount + 1
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next

            If MatchedSecurity = False Then
                UltraExplorerBar1.Groups(GroupName).Items(y).Visible = False
            End If
        Next



        Dim AdditionalGroupCounts As Integer = AdditionalGroupVisibleChecks(GroupName)

        GroupCount = GroupCount + AdditionalGroupCounts

        If GroupCount > 0 Then
            UltraExplorerBar1.Groups(GroupName).Visible = True
        Else
            UltraExplorerBar1.Groups(GroupName).Visible = False
        End If
    End Sub
    Function AdditionalGroupVisibleChecks(ByVal GroupName As String) As Integer
        Dim GroupCount As Integer = 0

        Select Case GroupName
            Case "Scheduling"
                Dim x As Integer
                For x = 0 To UltraExplorerBar1.Groups(GroupName).Items.Count - 1
                    Dim ItemKey As String = UltraExplorerBar1.Groups(GroupName).Items(x).Key

                    If ItemKey.ToLower = "weeklyschedulegreg" Then
                        If KPGeneral.User.IsAdmin Or KPGeneral.User.UserProfile("GroupIDFK") = "7" Then
                            UltraExplorerBar1.Groups(GroupName).Items(x).Visible = True
                            GroupCount = GroupCount + 1
                        Else
                            UltraExplorerBar1.Groups(GroupName).Items(x).Visible = False
                            CheckFormNames(ItemKey)
                        End If

                        Exit For
                    End If
                Next

            Case "Preferences"
                Dim x As Integer
                For x = 0 To UltraExplorerBar1.Groups(GroupName).Items.Count - 1
                    Dim ItemKey As String = UltraExplorerBar1.Groups(GroupName).Items(x).Key

                    If ItemKey.ToLower = "profile" Then
                        UltraExplorerBar1.Groups(GroupName).Items(x).Visible = True
                        GroupCount = GroupCount + 1
                        Exit For
                    End If
                Next
                'UltraExplorerBar1.Groups(GroupName).Items("Profile").Visible = True
                'GroupCount = GroupCount + 1
        End Select

        Return GroupCount
    End Function
    Function CheckItemSecurity(ByVal SQLColumnName As String, ByVal KPShellItemName As String, ByVal KPShellGroupName As String) As Boolean
        Dim HadSecurity As Boolean = False

        Dim Match As Boolean = CheckAlreadyLoadedVisibility(SQLColumnName, KPShellItemName, KPShellGroupName)

        If Match = False Then
            UltraExplorerBar1.Groups(KPShellGroupName).Items(KPShellItemName).Visible = KPGeneral.User.UserProfile(SQLColumnName)
            If KPGeneral.User.UserProfile(SQLColumnName) = False Then
                CheckFormNames(KPShellItemName)
            Else
                HadSecurity = True
            End If
            CheckSpecificScurity(SQLColumnName, KPShellItemName, KPShellGroupName, HadSecurity)
        End If

        Return HadSecurity
    End Function
    Function CheckAlreadyLoadedVisibility(ByVal SQLColumnName As String, ByVal KPShellItemName As String, ByVal KPShellGroupName As String) As Boolean
        Select Case KPShellGroupName
            Case "Factory"
                Select Case KPShellItemName
                    Case "InstallerSchedule"
                        Return LoadedInstallerSchedule
                End Select
        End Select

        Return False
    End Function
    Private Sub CheckSpecificScurity(ByVal SQLColumnName As String, ByVal KPShellItemName As String, ByVal KPShellGroupName As String, ByVal HadSecurity As Boolean)
        Select Case KPShellGroupName
            Case "Factory"
                Select Case KPShellItemName
                    Case "InstallerSchedule"
                        If LoadedInstallerSchedule = False Then
                            If HadSecurity = True Then
                                LoadedInstallerSchedule = True
                            End If
                        End If
                    Case "KitchenTracker"
                        UTM.Tools("btnKitchenTracker").SharedProps.Visible = HadSecurity
                End Select
        End Select
    End Sub


#End Region
    Private Sub LoadSecurity()

        'Used to determine if showing the group Miscellaneous and/or factory
        CheckGroupSecurity("IT")
        CheckGroupSecurity("Service")
        CheckGroupSecurity("Scheduling")
        CheckGroupSecurity("Mobile")
        CheckGroupSecurity("Sales")
        CheckGroupSecurity("Purchasing")
        CheckGroupSecurity("WorkShop")
        CheckGroupSecurity("Machinery")
        CheckGroupSecurity("Logistics")
        CheckGroupSecurity("Automation")
        CheckGroupSecurity("Doors")
        CheckGroupSecurity("Assembly")
        CheckGroupSecurity("Accounting")
        CheckGroupSecurity("ReportingAlerts")
        CheckGroupSecurity("Product")
        CheckGroupSecurity("Miscellaneous")
        CheckGroupSecurity("Factory")
        CheckGroupSecurity("Contracts")
        CheckGroupSecurity("Preferences")
        CheckGroupSecurity("Maintenance")
        CheckGroupSecurity("DOR")
        CheckGroupSecurity("MRP")
        CheckGroupSecurity("Installation")
        CheckGroupSecurity("Inventory")
        CheckGroupSecurity("Settings")
        LoadOtherSecurity()

        RefreshQuickAccessData()
    End Sub
    Private Sub LoadFormLook()
        'check to see if the user has a view style set.  If not, set default, otherwise set what's in the database.
        If IsDBNull(KPGeneral.User.UserProfile("ExplorerBarViewStyle")) = False Then
            Dim EBarViewSetting As Integer
            EBarViewSetting = KPGeneral.User.UserProfile("ExplorerBarViewStyle")
            UltraExplorerBar1.ViewStyle = EBarViewSetting
        Else
            UltraExplorerBar1.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Default
        End If
        'check to see if the user has a behavior set.  If not, set default, otherwise set what's in the database.
        If IsDBNull(KPGeneral.User.UserProfile("ExplorerBarBehaviorStyle")) = False Then
            Dim EBarBehaviorSetting As Integer
            EBarBehaviorSetting = KPGeneral.User.UserProfile("ExplorerBarBehaviorStyle")
            'check if behavior is like Visual Studio.  If yes, change how the buttons work to default.  If no, use default.
            If EBarBehaviorSetting = 2 Or EBarBehaviorSetting = 4 Then
                UltraExplorerBar1.ItemSettings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Button
            Else
                UltraExplorerBar1.ItemSettings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Default
            End If
            UltraExplorerBar1.Style = EBarBehaviorSetting
        Else
            UltraExplorerBar1.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.ExplorerBar
        End If
        'check to see if the user has a tab style set.  If not, set default, otherwise set what's in the database.
        If IsDBNull(KPGeneral.User.UserProfile("TabStyle")) = False Then
            Dim TabNum As Integer
            TabNum = KPGeneral.User.UserProfile("TabStyle")
            UTMM.ViewStyle = TabNum
        Else
            UTMM.ViewStyle = Infragistics.Win.UltraWinTabbedMdi.ViewStyle.Default
        End If
        'check to see if the user wants large icons
        If KPGeneral.User.UserProfile("LargeMenuIcons") = True Then
            UltraExplorerBar1.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.LargeImagesWithTextBelow
        Else
            UltraExplorerBar1.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.Default
        End If
        'check to see which groups are expanded. need to modify bobj
        UltraExplorerBar1.Groups("Factory").Expanded = KPGeneral.User.UserProfile("Factory")
        UltraExplorerBar1.Groups("Contracts").Expanded = KPGeneral.User.UserProfile("Contracts")
        UltraExplorerBar1.Groups("ReportingAlerts").Expanded = KPGeneral.User.UserProfile("ReportingAlerts")
        UltraExplorerBar1.Groups("Product").Expanded = KPGeneral.User.UserProfile("Product")
        UltraExplorerBar1.Groups("Miscellaneous").Expanded = KPGeneral.User.UserProfile("Miscellaneous")
        UltraExplorerBar1.Groups("Preferences").Expanded = KPGeneral.User.UserProfile("Preferences")
        UltraExplorerBar1.Groups("Scheduling").Expanded = KPGeneral.User.UserProfile("Scheduling")
        UltraExplorerBar1.Groups("Service").Expanded = KPGeneral.User.UserProfile("Service")
        UltraExplorerBar1.Groups("Sales").Expanded = KPGeneral.User.UserProfile("Sales")
        UltraExplorerBar1.Groups("Workshop").Expanded = KPGeneral.User.UserProfile("Workshop")
        UltraExplorerBar1.Groups("Mobile").Expanded = KPGeneral.User.UserProfile("Mobile")
        UltraExplorerBar1.Groups("Purchasing").Expanded = KPGeneral.User.UserProfile("Purchasing")
        UltraExplorerBar1.Groups("Machinery").Expanded = KPGeneral.User.UserProfile("Machinery")
        UltraExplorerBar1.Groups("Logistics").Expanded = KPGeneral.User.UserProfile("Logistics")
        UltraExplorerBar1.Groups("Automation").Expanded = KPGeneral.User.UserProfile("Automation")
        UltraExplorerBar1.Groups("Accounting").Expanded = KPGeneral.User.UserProfile("Accounting")
        UltraExplorerBar1.Groups("IT").Expanded = KPGeneral.User.UserProfile("IT")
        UltraExplorerBar1.Groups("Assembly").Expanded = KPGeneral.User.UserProfile("Assembly")
        UltraExplorerBar1.Groups("Doors").Expanded = KPGeneral.User.UserProfile("Doors")
        UltraExplorerBar1.Groups("Maintenance").Expanded = KPGeneral.User.UserProfile("Maintenance")
        UltraExplorerBar1.Groups("DOR").Expanded = KPGeneral.User.UserProfile("DOR")
        UltraExplorerBar1.Groups("Installation").Expanded = KPGeneral.User.UserProfile("Installation")
        UltraExplorerBar1.Groups("Inventory").Expanded = KPGeneral.User.UserProfile("Inventory")
        UltraExplorerBar1.Groups("Settings").Expanded = KPGeneral.User.UserProfile("Settings")

    End Sub
    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UTM.ToolClick
        'check to see if any of the state buttons have been clicked.  If so, uncheck the previous state-button
        'and check the new one.  This is for the Dashboard categories (certain users only)
        Dim CategoryChange As Boolean = False

        Dim x As Integer
        For x = 0 To UTM.Tools.Count - 1
            If e.Tool.Key <> UTM.Tools(x).Key Then
                If UTM.Tools(x).UnderlyingTool.ToString.Contains("StateButtonTool") Then
                    If UTM.Tools(x).Key = "btnRegular" Then
                        RegularState.InitializeChecked(False)
                    ElseIf UTM.Tools(x).Key = "btnService" Then
                        ServiceState.InitializeChecked(False)
                    ElseIf UTM.Tools(x).Key = "btnLayout" Then
                        LayoutState.InitializeChecked(False)
                    ElseIf UTM.Tools(x).Key = "btnPricing" Then
                        PricingState.InitializeChecked(False)
                    ElseIf UTM.Tools(x).Key = "btnColours" Then
                        ColoursState.InitializeChecked(False)
                    ElseIf UTM.Tools(x).Key = "btnFactory" Then
                        FactoryState.InitializeChecked(False)
                    ElseIf UTM.Tools(x).Key = "btnDesignStudio" Then
                        DesignState.InitializeChecked(False)
                    ElseIf UTM.Tools(x).Key = "btnForecasting" Then
                        ForecastingState.InitializeChecked(False)
                    End If
                End If
            Else
                If UTM.Tools(x).UnderlyingTool.ToString.Contains("StateButtonTool") Then
                    If UTM.Tools(x).Key = "btnRegular" Then
                        RegularState.InitializeChecked(True)
                        KPGeneral.Category = "Regular"
                        CategoryChange = True
                    ElseIf UTM.Tools(x).Key = "btnService" Then
                        ServiceState.InitializeChecked(True)
                        KPGeneral.Category = "Service"
                        CategoryChange = True
                    ElseIf UTM.Tools(x).Key = "btnLayout" Then
                        LayoutState.InitializeChecked(True)
                        KPGeneral.Category = "Layout"
                        CategoryChange = True
                    ElseIf UTM.Tools(x).Key = "btnPricing" Then
                        PricingState.InitializeChecked(True)
                        KPGeneral.Category = "Pricing"
                        CategoryChange = True
                    ElseIf UTM.Tools(x).Key = "btnColours" Then
                        ColoursState.InitializeChecked(True)
                        KPGeneral.Category = "Colours"
                        CategoryChange = True
                    ElseIf UTM.Tools(x).Key = "btnFactory" Then
                        FactoryState.InitializeChecked(True)
                        KPGeneral.Category = "Factory"
                        CategoryChange = True
                    ElseIf UTM.Tools(x).Key = "btnDesignStudio" Then
                        DesignState.InitializeChecked(True)
                        KPGeneral.Category = "DesignStudio"
                        CategoryChange = True
                    ElseIf UTM.Tools(x).Key = "btnForecasting" Then
                        ForecastingState.InitializeChecked(True)
                        KPGeneral.Category = "Forecasting"
                        CategoryChange = True
                    End If
                End If
            End If
        Next

        If CategoryChange = True Then
            LoadNormalDashboard()
        End If
        Me.Cursor = Cursors.WaitCursor
        Select Case e.Tool.Key
            Case "btnLogout"
                CloseAllTabs()
                ClearAllGroups()
                Me.Hide()
                LoadProject(False)
            Case "btnCheckSecurity"
                CloseAllTabs()
                ClearAllGroups()
                RefreshUserProfile()
                LoadProject(True)
            Case "btnExit"
                Me.Close()
                'frmSalesForecast.ShowDialog()
                'TextTextParse()
            Case "btnNewContract"
                frmNewQuotation.ShowDialog()
            Case "btnSystemColourViewer"
                frmSystemColourSheet.Show()
            Case "btnBuggyUpdate"
                BuggyUpdate()
            Case "btnNewProject"
                frmNewProjectWizard.ShowDialog()

            Case "btnNewPurchaseAgreement"
                If KPGeneral.User.UserProfile("PurchaseAgreement") = True Then
                    Dim frm As New frmPurchaseAgreement(True, Nothing, False)
                    frm.ShowDialog()
                Else
                    MsgBox("You are NOT Authorized in this section !!", MsgBoxStyle.Exclamation, KPGeneral.ProgramName)
                End If
            Case "btnNewPrivateOrder"
                If KPGeneral.User.UserProfile("PurchaseAgreement") = True Then
                    Dim frm As New frmPrivateWizard(True, 0, False)
                    'Dim frm As New frmPrivateWizard(True, 0)

                    Dim DResult As DialogResult
                    DResult = frm.ShowDialog()

                    If DResult = Windows.Forms.DialogResult.OK Then
                        'If CheckMDIChildren("Orders") = True Then
                        '    ' if the form is open, activate it.
                        '    Orders.LoadOrder = True
                        '    Orders.QuickSearchString = "CSID" & KPGeneral.CSID
                        '    Me.MdiChildren(MDIChildrenInt).Activate()
                        '    Orders.StartQuickSearch()
                        'Else
                        ' form isn't open, open it.
                        Orders.LoadOrder = True
                        Orders.QuickSearchString = "CSID" & KPGeneral.CSID
                        Orders.ViewLayoutData = False
                        LoadForm("Orders")
                        Dim frmOrders As New Orders
                        frmOrders.MdiParent = Me
                        frmOrders.Show()
                        frmOrders.Name = "Orders"
                        frmOrders.Dock = DockStyle.Fill
                        frmOrders.Text = "Orders"
                        KPGeneral.WebRef_Local.usp_FormProgramViewLog("Private Wizard - Finish Order", KPGeneral.User.UserProfile("UserLoginName"))
                        'End If
                    End If

                Else
                    MsgBox("You are NOT Authorized in this section !!", MsgBoxStyle.Exclamation, KPGeneral.ProgramName)
                End If
            Case "btnNewBuilder"
                Dim frm As New frmNewBuilder
                frm.ShowDialog()
            Case "btnQuoteRegistry"
                Dim frm As New frmNewQuote
                frm.ShowDialog()
            Case "btnNewNon2020Order", "btnRetailPrivateOrder"
                'If KPGeneral.User.UserProfile("PurchaseAgreement") = True Then
                Dim frm As New frmDesignPurchaser(True, 0)
                frm.ShowDialog()
                'Else
                '    MsgBox("You are NOT Authorized in this section !!", MsgBoxStyle.Exclamation, KPGeneral.ProgramName)
                'End If
            Case "btnRetailPurchaseOrder"
                'If KPGeneral.User.UserProfile("PurchaseAgreement") = True Then
                Dim frm As New frmDesignQuote(True, 0)
                frm.ShowDialog()
                'Else
                '    MsgBox("You are NOT Authorized in this section !!", MsgBoxStyle.Exclamation, KPGeneral.ProgramName)
                'End If
            Case "btnCheckForUpdates"
                Dim frmCheckUpdates As New frmCheckUpdates
                frmCheckUpdates.Text = "Check Updates for " & Windows.Forms.Application.ProductName
                frmCheckUpdates.ShowDialog()
            Case "btnPrintScreen"
                ' Copy the form's image into a bitmap.
                m_PrintBitmap = GetDecoratedFormImage()

                Dim Letter As System.Drawing.Printing.PaperSize = New System.Drawing.Printing.PaperSize("Letter", 800, 1000)
                ' Make a PrintDocument and print.
                m_PrintDocument = New PrintDocument
                m_PrintDocument.OriginAtMargins = False
                m_PrintDocument.DefaultPageSettings.Landscape = True
                m_PrintDocument.DefaultPageSettings.PaperSize = Letter
                m_PrintDocument.Print()
            Case "btnNewXKWizard"
                If KPGeneral.User.UserProfile("check25") = True Then 'check25 = Add Lot
                    frmXKWizard.BypassXK = False
                    frmXKWizard.bypassCSID = 0
                    Dim frmXK As New frmXKWizard
                    frmXK.ShowDialog()
                Else
                    MsgBox("You are NOT Authorized in this section !!", MsgBoxStyle.Exclamation, KPGeneral.ProgramName)
                End If
            Case "btnProductionCalendar"
                LoadForm("ProductionCalendar")
            Case "btnDeliverySchedule"
                LoadForm("DeliverySchedule")
            Case "btnAPTSchedule"
                LoadForm("APTSchedule")
            Case "btnHOME"
                'KPGeneral.GetMemoryUsage()
                LoadHomeScreen()
            Case "btnDeleteCropperConfig"
                KPGeneral.DeleteCropperConfig()
            Case "btnSearchToolbar"
                SearchToolbar(True, "")
            Case "btnEmployeeDirectory"
                LoadForm("EmployeeDirectory")
            Case "btnKitchenTracker"
                LoadForm("KitchenTracker")
            Case "btnQuickAccess1"
                LoadQuickAccess(1)
            Case "btnQuickAccess2"
                LoadQuickAccess(2)
            Case "btnQuickAccess3"
                LoadQuickAccess(3)
            Case "btnQuickAccess4"
                LoadQuickAccess(4)
            Case "btnUpdateStatusColours"
                StatusColours.RefreshStatusColours()
        End Select
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub SearchToolbar(ByVal NewSearch As Boolean, ByVal FormClicked As String)
        Dim iBox As String = ""

        If NewSearch = True Then
            iBox = InputBox("Please enter text to search.  Leave blank or cancel to return to normal.", KPGeneral.ProgramName, "")
        End If

        Me.Cursor = Cursors.WaitCursor

        LoadFormLook()
        LoadSecurity()

        KPGeneral.WebRef_Local.usp_InsertMenuSearchLog(iBox, KPGeneral.User.UserProfile("UserLoginName"), FormClicked)

        Dim x, y As Integer
        If iBox.Trim.Length > 0 Then
            ToolbarSearched = True

            For x = 0 To UltraExplorerBar1.Groups.Count - 1
                For y = 0 To UltraExplorerBar1.Groups(x).Items.Count - 1
                    If UltraExplorerBar1.Groups(x).Items(y).Key.ToLower.Contains(iBox.Trim.ToLower) Or
                        UltraExplorerBar1.Groups(x).Items(y).Text.ToLower.Contains(iBox.Trim.ToLower) Then
                        If UltraExplorerBar1.Groups(x).Items(y).Visible = True Then
                            UltraExplorerBar1.Groups(x).Expanded = True
                        End If
                    Else
                        UltraExplorerBar1.Groups(x).Items(y).Visible = False
                    End If
                Next
            Next
        Else

        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub LoadHomeScreen()
        If IsDBNull(KPGeneral.User.UserProfile("HomeScreen")) = False Then
            Select Case KPGeneral.User.UserProfile("HomeScreen")
                Case "Layout"
                    LoadForm("LayoutHome")
                Case "Sales"
                    LoadForm("SalesHome")
                Case "LayoutSales"
                    LoadForm("LayoutHome")
                    LoadForm("SalesHome")
            End Select

        End If

    End Sub
    Private Sub CloseAllTabs()
        ' Loop through all MDI Children and close prior to log out.
        Dim f As Form
        For Each f In Me.MdiChildren
            f.Close()
        Next
    End Sub
    Private Sub StyleProgressBars()
        USBar.UseAppStyling = False
        USBar.UseOsThemes = Infragistics.Win.DefaultableBoolean.False

        USBar.Panels("PreProduction").ProgressBarInfo.Value = 0
        USBar.Panels("Production").ProgressBarInfo.Value = 0
        USBar.Panels("PostProduction").ProgressBarInfo.Value = 0

        USBar.Panels("PreProduction").ProgressBarInfo.FillAppearance.BackColor = Color.Red
        USBar.Panels("PreProduction").ProgressBarInfo.FillAppearance.BackColor2 = Color.Salmon
        USBar.Panels("PreProduction").ProgressBarInfo.Appearance.BackColor = Color.Transparent
        USBar.Panels("PreProduction").ProgressBarInfo.Appearance.BackColor2 = Color.Transparent
        USBar.Panels("PreProduction").ProgressBarInfo.Style = Infragistics.Win.UltraWinProgressBar.ProgressBarStyle.Continuous
        USBar.Panels("PreProduction").ProgressBarInfo.FillAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20

        USBar.Panels("Production").ProgressBarInfo.FillAppearance.BackColor = Color.Red
        USBar.Panels("Production").ProgressBarInfo.FillAppearance.BackColor2 = Color.Salmon
        USBar.Panels("Production").ProgressBarInfo.Appearance.BackColor = Color.Transparent
        USBar.Panels("Production").ProgressBarInfo.Appearance.BackColor2 = Color.Transparent
        USBar.Panels("Production").ProgressBarInfo.Style = Infragistics.Win.UltraWinProgressBar.ProgressBarStyle.Continuous
        USBar.Panels("Production").ProgressBarInfo.FillAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20

        USBar.Panels("PostProduction").ProgressBarInfo.FillAppearance.BackColor = Color.Red
        USBar.Panels("PostProduction").ProgressBarInfo.FillAppearance.BackColor2 = Color.Salmon
        USBar.Panels("PostProduction").ProgressBarInfo.Appearance.BackColor = Color.Transparent
        USBar.Panels("PostProduction").ProgressBarInfo.Appearance.BackColor2 = Color.Transparent
        USBar.Panels("PostProduction").ProgressBarInfo.Style = Infragistics.Win.UltraWinProgressBar.ProgressBarStyle.Continuous
        USBar.Panels("PostProduction").ProgressBarInfo.FillAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20
    End Sub

    Private Sub HideNavPaneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideNavPaneToolStripMenuItem.Click
        If UltraSplitter1.Collapsed = False Then
            UltraSplitter1.Collapsed = True
        End If
    End Sub
    Private Sub ShowNavPaneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowNavPaneToolStripMenuItem.Click
        If UltraSplitter1.Collapsed = True Then
            UltraSplitter1.Collapsed = False
        End If
    End Sub
    ' Get an image of the form plus its decoration (borders, title bar, etc).
    Private Function GetDecoratedFormImage() As Bitmap
        ' Get this form's Graphics object.
        Dim me_gr As Graphics = Me.CreateGraphics

        ' Make a Bitmap to hold the image.
        Dim bm As New Bitmap(Me.Width, Me.Height, me_gr)
        Dim bm_gr As Graphics = Graphics.FromImage(bm)
        Dim bm_hdc As IntPtr = bm_gr.GetHdc

        ' Get the form's hDC. We must do this after 
        ' creating the new Bitmap, which uses me_gr.
        Dim me_hdc As IntPtr = GetWindowDC(Me.Handle)

        ' BitBlt the form's image onto the Bitmap.
        BitBlt(bm_hdc, 0, 0, Me.Width, Me.Height,
            me_hdc, 0, 0, SRCCOPY)
        bm_gr.ReleaseHdc(bm_hdc)

        ' Return the result.
        Return bm
    End Function
    Private Sub BuggyUpdate()
        Dim FName As String
        FName = "C:\Buggy\TempScan.xml"
        ' FName2 = GetAppPath() & "Scan_" & Now.ToOADate.ToString & ".xml"
        If System.IO.File.Exists(FName) = True Then
            'lblmessage.Text = "RUNNING SYNC...PLEASE WAIT!"
            Dim dsTempLoad As New DataSet
            dsTempLoad.ReadXml(FName, XmlReadMode.ReadSchema)
            Dim ok As Boolean = True
            Dim x As Integer
            For x = 0 To dsTempLoad.Tables(0).Rows.Count - 1
                If IsDBNull(dsTempLoad.Tables(0).Rows(x)("barcode")) = False Then
                    If IsDBNull(dsTempLoad.Tables(0).Rows(x)("buggy")) = False Then
                        If dsTempLoad.Tables(0).Rows(x)("buggy").ToString.Length > 0 And dsTempLoad.Tables(0).Rows(x)("barcode").ToString.Length > 0 Then
                            If IsNumeric(dsTempLoad.Tables(0).Rows(x)("barcode")) = True Then
                                ok = KPGeneral.WebRef_Local.usp_UpdateCabinetLabelCartIDVerify(dsTempLoad.Tables(0).Rows(x)("barcode"), dsTempLoad.Tables(0).Rows(x)("buggy"))
                                'lblmessage.Text = "Sync - " & x
                                If Not ok Then Exit For
                            End If
                        End If
                    End If
                End If
            Next
            If ok Then
                ' dsTempLoad.WriteXml(FName2, System.Data.XmlWriteMode.WriteSchema)
                MsgBox("Sync Finished")

            End If
            'LastCheck = 0
        End If
    End Sub
    Private Sub LoadDiverScan()
        LoadForm("LoadingDockCheckIn")
    End Sub
    Private Sub LoadWrapping(ByVal isQueue As Boolean)
        If isQueue = True Then
            LoadForm("WrappingQueue")
        Else
            LoadForm("WrappingPrint")
        End If

    End Sub
    Private Sub LoadPantryPrint()
        LoadForm("PantryLabels")
    End Sub
    Private Sub LoadTandembotPrint()
        LoadForm("TandemBoxPrint")
    End Sub
    Private Sub LoadStockroom()
        LoadForm("StockRoomCheckout")
    End Sub

    Private Sub AutoLoadOtherDashboard(ByVal DashboardCombo As String)
        'KPGeneral.Category = DashboardCombo.Replace("Dashboard", "")
        KPGeneral.Category = DashboardCombo.Replace("Dashboard", KPGeneral.Category)
        LoadNormalDashboard()
    End Sub

    Private Sub LoadMenuFromDB()
        'Dim ds As New DataSet
        'ds = KPGeneral.WebRef_Local.usp_GetSequenceForms_Active_ByUserID(KPGeneral.User.UserProfile("UserLoginName"))
        Dim userID As Int32 = KPGeneral.User.UserProfile("UserID")
        Dim ds As DataSet = KPGeneral.KPDataSQL.SP_EXEC("t_GetSequenceForms_Active_ByUserID", userID, KPGeneral.User.IsAdmin)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim x As Integer

            For x = 0 To ds.Tables(0).Rows.Count - 1
                Dim GroupName, ItemKey, MenuText As String

                Dim Match As Boolean = True

                If IsDBNull(ds.Tables(0).Rows(x)("GroupName")) = False Then
                    GroupName = ds.Tables(0).Rows(x)("GroupName")

                    If IsDBNull(ds.Tables(0).Rows(x)("ItemKey")) = False Then
                        ItemKey = ds.Tables(0).Rows(x)("ItemKey")

                        If IsDBNull(ds.Tables(0).Rows(x)("ItemText_Menu")) = False Then
                            MenuText = ds.Tables(0).Rows(x)("ItemText_Menu")

                            Dim AlreadyLoaded As Boolean = CheckAlreadyLoaded(ItemKey, GroupName)

                            If AlreadyLoaded = False Then
                                UltraExplorerBar1.Groups(GroupName).Items.Add(ItemKey, MenuText)

                                If IsDBNull(ds.Tables(0).Rows(x)("ButtonImageLarge")) = False Then
                                    Dim bytImageData() As Byte = ds.Tables(0).Rows(x)("ButtonImageLarge")
                                    UltraExplorerBar1.Groups(GroupName).Items(ItemKey).Settings.AppearancesLarge.Appearance.Image = KPGeneral.ConvertToBitmapVB(bytImageData)
                                End If

                                If IsDBNull(ds.Tables(0).Rows(x)("ButtonImageSmall")) = False Then
                                    Dim bytImageData() As Byte = ds.Tables(0).Rows(x)("ButtonImageSmall")
                                    UltraExplorerBar1.Groups(GroupName).Items(ItemKey).Settings.AppearancesSmall.Appearance.Image = KPGeneral.ConvertToBitmapVB(bytImageData)
                                End If
                            End If

                        End If
                    End If

                End If
            Next
        End If
    End Sub
    Function CheckAlreadyLoaded(ByVal KPShellItemName As String, ByVal KPShellGroupName As String) As Boolean
        Dim GroupExists As Boolean = False
        Dim MenuItemExists As Boolean = False

        Dim x As Integer

        If UltraExplorerBar1.Groups.Count > 0 Then
            For x = 0 To UltraExplorerBar1.Groups.Count - 1
                If UltraExplorerBar1.Groups(x).Key = KPShellGroupName Then
                    GroupExists = True
                    Exit For
                End If
            Next
        End If

        If GroupExists = True Then
            If UltraExplorerBar1.Groups(KPShellGroupName).Items.Count > 0 Then
                For x = 0 To UltraExplorerBar1.Groups(KPShellGroupName).Items.Count - 1
                    If UltraExplorerBar1.Groups(KPShellGroupName).Items(x).Key = KPShellItemName Then
                        MenuItemExists = True
                        Exit For
                    End If
                Next
            End If
        End If

        Return MenuItemExists
    End Function
    Private Sub TestLoadDynamic()
        UltraExplorerBar1.Groups("IT").Items.Clear()

        'UltraExplorerBar1.Groups("IT").Items.Add("Test 123", "Test Button")
    End Sub
    Private Sub ClearAllGroups()
        Dim x As Integer
        For x = 0 To UltraExplorerBar1.Groups.Count - 1
            Dim GroupName As String = UltraExplorerBar1.Groups(x).Key
            UltraExplorerBar1.Groups(x).Items.Clear()
        Next
    End Sub
    Private Sub RefreshUserProfile()

        KPGeneral.User = New SequenceUser(KPGeneral.User.UserProfile("UserLoginName"), KPGeneral.User.UserProfile("Password"))
        'Dim dsUserSecurity As New DataSet
        'dsUserSecurity = KPGeneral.WebRef_Local.usp_GetUserSecurityLevels(KPGeneral.User.UserProfile("UserLoginName"))

        'KPGeneral.UserProfile = dsUserSecurity
    End Sub
    Private Sub LoadTestForm()
        'Dim excelTest As New frmColourChartDocumentSplitter
        'excelTest.ShowDialog()

    End Sub
    Private Sub LoadQuickAccess(ByVal QuickAccessNumber As Integer)
        Dim FormKey As String = ""
        Dim FormDisplay As String
        Dim ButtonKey As String

        Select Case QuickAccessNumber
            Case 1
                FormKey = QuickAccessKey1
                FormDisplay = QuickAccessDisplay1
                ButtonKey = "btnQuickAccess1"
            Case 2
                FormKey = QuickAccessKey2
                FormDisplay = QuickAccessDisplay2
                ButtonKey = "btnQuickAccess2"
            Case 3
                FormKey = QuickAccessKey3
                FormDisplay = QuickAccessDisplay3
                ButtonKey = "btnQuickAccess3"
            Case 4
                FormKey = QuickAccessKey4
                FormDisplay = QuickAccessDisplay4
                ButtonKey = "btnQuickAccess4"
        End Select

        If FormKey.Length > 0 Then
            LoadForm(FormKey)
        End If
    End Sub
    Private Sub UTM_BeforeToolbarListDropdown(sender As Object, e As BeforeToolbarListDropdownEventArgs) Handles UTM.BeforeToolbarListDropdown
        e.ShowCustomizeMenuItem = False

        If KPGeneral.User.UserProfile("QuickAccessButtons") Then
            mnuQuickAccess.Show(MousePosition.X, MousePosition.Y)
        End If
    End Sub
    Private Sub ModifyQuickAccessToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ModifyQuickAccessToolStripMenuItem.Click
        frmSequenceQuickAccess.ShowDialog()

        RefreshQuickAccessData()
    End Sub
    Private Sub RefreshQuickAccessData()
        Dim ds As New DataSet
        ds = KPGeneral.WebRef_Local.usp_GetUserQuickAccessButtonsByUserID(KPGeneral.User.UserProfile("UserLoginName"))

        ResetQuickAccessButton()

        Dim x As Integer
        For x = 0 To ds.Tables(0).Rows.Count - 1
            RefreshQuickAccessButton(ds.Tables(0).Rows(x)("QuickAccessButton"), ds.Tables(0).Rows(x)("SequenceFormID"))
        Next
    End Sub
    Private Sub ResetQuickAccessButton()
        Dim FormDisplay As String = "Quick Access"

        QuickAccessKey1 = 0
        QuickAccessKey2 = 0
        QuickAccessKey3 = 0
        QuickAccessKey4 = 0

        QuickAccessDisplay1 = ""
        QuickAccessDisplay2 = ""
        QuickAccessDisplay3 = ""
        QuickAccessDisplay4 = ""

        UTM.Tools("btnQuickAccess1").SharedProps.Caption = FormDisplay
        UTM.Tools("btnQuickAccess2").SharedProps.Caption = FormDisplay
        UTM.Tools("btnQuickAccess3").SharedProps.Caption = FormDisplay
        UTM.Tools("btnQuickAccess4").SharedProps.Caption = FormDisplay

        UTM.Tools("btnQuickAccess1").SharedProps.Visible = False
        UTM.Tools("btnQuickAccess2").SharedProps.Visible = False
        UTM.Tools("btnQuickAccess3").SharedProps.Visible = False
        UTM.Tools("btnQuickAccess4").SharedProps.Visible = False
    End Sub
    Private Sub RefreshQuickAccessButton(ByVal QuickAccessNumber As Integer, ByVal SequenceFormID As Integer)

        Dim FormDisplay As String = "Quick Access"
        Dim ButtonKey As String

        Dim dsQuickAccess As New DataSet
        dsQuickAccess = KPGeneral.WebRef_Local.usp_GetUserSecurityFormsByUserIDAndSequenceFormID(KPGeneral.User.UserProfile("UserLoginName"), SequenceFormID)

        Dim Match As Boolean = False

        If dsQuickAccess.Tables.Count > 0 Then
            If dsQuickAccess.Tables(0).Rows.Count > 0 Then
                Match = True

                FormDisplay = dsQuickAccess.Tables(0).Rows(0)("FormText")
            End If
        End If

        Select Case QuickAccessNumber
            Case 1
                ButtonKey = "btnQuickAccess1"
            Case 2
                ButtonKey = "btnQuickAccess2"
            Case 3
                ButtonKey = "btnQuickAccess3"
            Case 4
                ButtonKey = "btnQuickAccess4"
        End Select

        If Match = True Then
            Select Case QuickAccessNumber
                Case 1
                    QuickAccessKey1 = dsQuickAccess.Tables(0).Rows(0)("FormName")
                    QuickAccessDisplay1 = dsQuickAccess.Tables(0).Rows(0)("FormText")
                    UTM.Tools("btnQuickAccess1").SharedProps.Visible = KPGeneral.User.UserProfile("QuickAccessButtons")
                Case 2
                    QuickAccessKey2 = dsQuickAccess.Tables(0).Rows(0)("FormName")
                    QuickAccessDisplay2 = dsQuickAccess.Tables(0).Rows(0)("FormText")
                    UTM.Tools("btnQuickAccess2").SharedProps.Visible = KPGeneral.User.UserProfile("QuickAccessButtons")
                Case 3
                    QuickAccessKey3 = dsQuickAccess.Tables(0).Rows(0)("FormName")
                    QuickAccessDisplay3 = dsQuickAccess.Tables(0).Rows(0)("FormText")
                    UTM.Tools("btnQuickAccess3").SharedProps.Visible = KPGeneral.User.UserProfile("QuickAccessButtons")
                Case 4
                    QuickAccessKey4 = dsQuickAccess.Tables(0).Rows(0)("FormName")
                    QuickAccessDisplay4 = dsQuickAccess.Tables(0).Rows(0)("FormText")
                    UTM.Tools("btnQuickAccess4").SharedProps.Visible = KPGeneral.User.UserProfile("QuickAccessButtons")
            End Select
        End If

        UTM.Tools(ButtonKey).SharedProps.Caption = FormDisplay
    End Sub
End Class
