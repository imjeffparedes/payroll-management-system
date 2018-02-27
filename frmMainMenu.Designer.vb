<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMenu))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DataEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttendanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchRecordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeAttendanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeePaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvanceEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeductionEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvancePaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeePaymentToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttendanceToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OvertimeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotePadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.EmployeeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttendanceToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvanceEntryToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SalarySlipsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataEntryToolStripMenuItem, Me.SearchRecordsToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(820, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DataEntryToolStripMenuItem
        '
        Me.DataEntryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrationToolStripMenuItem, Me.AttendanceToolStripMenuItem, Me.AdvanceToolStripMenuItem, Me.PaymentToolStripMenuItem})
        Me.DataEntryToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataEntryToolStripMenuItem.Name = "DataEntryToolStripMenuItem"
        Me.DataEntryToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.DataEntryToolStripMenuItem.Text = "Employee"
        '
        'RegistrationToolStripMenuItem
        '
        Me.RegistrationToolStripMenuItem.Name = "RegistrationToolStripMenuItem"
        Me.RegistrationToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.RegistrationToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.RegistrationToolStripMenuItem.Text = "Profile Entry"
        '
        'AttendanceToolStripMenuItem
        '
        Me.AttendanceToolStripMenuItem.Name = "AttendanceToolStripMenuItem"
        Me.AttendanceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AttendanceToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.AttendanceToolStripMenuItem.Text = "Attendance"
        '
        'AdvanceToolStripMenuItem
        '
        Me.AdvanceToolStripMenuItem.Name = "AdvanceToolStripMenuItem"
        Me.AdvanceToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AdvanceToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.AdvanceToolStripMenuItem.Text = "Advance Entry"
        '
        'PaymentToolStripMenuItem
        '
        Me.PaymentToolStripMenuItem.Name = "PaymentToolStripMenuItem"
        Me.PaymentToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PaymentToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.PaymentToolStripMenuItem.Text = "Payment"
        '
        'SearchRecordsToolStripMenuItem
        '
        Me.SearchRecordsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmployeeToolStripMenuItem, Me.EmployeeAttendanceToolStripMenuItem, Me.OverTimeToolStripMenuItem, Me.EmployeePaymentToolStripMenuItem, Me.AdvanceEntryToolStripMenuItem, Me.DeductionEntryToolStripMenuItem})
        Me.SearchRecordsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchRecordsToolStripMenuItem.Name = "SearchRecordsToolStripMenuItem"
        Me.SearchRecordsToolStripMenuItem.Size = New System.Drawing.Size(99, 20)
        Me.SearchRecordsToolStripMenuItem.Text = "Search Records"
        '
        'EmployeeToolStripMenuItem
        '
        Me.EmployeeToolStripMenuItem.Name = "EmployeeToolStripMenuItem"
        Me.EmployeeToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.EmployeeToolStripMenuItem.Text = "Employee Registration"
        '
        'EmployeeAttendanceToolStripMenuItem
        '
        Me.EmployeeAttendanceToolStripMenuItem.Name = "EmployeeAttendanceToolStripMenuItem"
        Me.EmployeeAttendanceToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.EmployeeAttendanceToolStripMenuItem.Text = "Employee Attendance"
        '
        'OverTimeToolStripMenuItem
        '
        Me.OverTimeToolStripMenuItem.Name = "OverTimeToolStripMenuItem"
        Me.OverTimeToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.OverTimeToolStripMenuItem.Text = "Over Time"
        '
        'EmployeePaymentToolStripMenuItem
        '
        Me.EmployeePaymentToolStripMenuItem.Name = "EmployeePaymentToolStripMenuItem"
        Me.EmployeePaymentToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.EmployeePaymentToolStripMenuItem.Text = "Employee Payment"
        '
        'AdvanceEntryToolStripMenuItem
        '
        Me.AdvanceEntryToolStripMenuItem.Name = "AdvanceEntryToolStripMenuItem"
        Me.AdvanceEntryToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.AdvanceEntryToolStripMenuItem.Text = "Advance Entry"
        '
        'DeductionEntryToolStripMenuItem
        '
        Me.DeductionEntryToolStripMenuItem.Name = "DeductionEntryToolStripMenuItem"
        Me.DeductionEntryToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.DeductionEntryToolStripMenuItem.Text = "Deduction"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmployeesToolStripMenuItem, Me.AdvancePaymentToolStripMenuItem, Me.EmployeePaymentToolStripMenuItem1, Me.AttendanceToolStripMenuItem1, Me.OvertimeToolStripMenuItem1, Me.SalarySlipsToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'EmployeesToolStripMenuItem
        '
        Me.EmployeesToolStripMenuItem.Name = "EmployeesToolStripMenuItem"
        Me.EmployeesToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.EmployeesToolStripMenuItem.Text = "Employees"
        '
        'AdvancePaymentToolStripMenuItem
        '
        Me.AdvancePaymentToolStripMenuItem.Name = "AdvancePaymentToolStripMenuItem"
        Me.AdvancePaymentToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AdvancePaymentToolStripMenuItem.Text = "Advance Entry"
        '
        'EmployeePaymentToolStripMenuItem1
        '
        Me.EmployeePaymentToolStripMenuItem1.Name = "EmployeePaymentToolStripMenuItem1"
        Me.EmployeePaymentToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.EmployeePaymentToolStripMenuItem1.Text = "Employee Payment"
        '
        'AttendanceToolStripMenuItem1
        '
        Me.AttendanceToolStripMenuItem1.Name = "AttendanceToolStripMenuItem1"
        Me.AttendanceToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.AttendanceToolStripMenuItem1.Text = "Attendance"
        '
        'OvertimeToolStripMenuItem1
        '
        Me.OvertimeToolStripMenuItem1.Name = "OvertimeToolStripMenuItem1"
        Me.OvertimeToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.OvertimeToolStripMenuItem1.Text = "Over Time"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotePadToolStripMenuItem, Me.CalculatorToolStripMenuItem, Me.SystemInfoToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'NotePadToolStripMenuItem
        '
        Me.NotePadToolStripMenuItem.Name = "NotePadToolStripMenuItem"
        Me.NotePadToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NotePadToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.NotePadToolStripMenuItem.Text = "Note Pad"
        '
        'CalculatorToolStripMenuItem
        '
        Me.CalculatorToolStripMenuItem.Name = "CalculatorToolStripMenuItem"
        Me.CalculatorToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CalculatorToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CalculatorToolStripMenuItem.Text = "Calculator"
        '
        'SystemInfoToolStripMenuItem
        '
        Me.SystemInfoToolStripMenuItem.Name = "SystemInfoToolStripMenuItem"
        Me.SystemInfoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SystemInfoToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SystemInfoToolStripMenuItem.Text = "System Info"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 551)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(820, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(86, 17)
        Me.ToolStripStatusLabel1.Text = "Logged in As :"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Image = Global.Payroll_Manager.My.Resources.Resources.images51
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(145, 17)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(429, 17)
        Me.ToolStripStatusLabel3.Spring = True
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel4.Image = Global.Payroll_Manager.My.Resources.Resources.time_1920x12001
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(145, 17)
        Me.ToolStripStatusLabel4.Text = "ToolStripStatusLabel4"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmployeeToolStripMenuItem1, Me.AttendanceToolStripMenuItem2, Me.PaymentToolStripMenuItem1, Me.AdvanceEntryToolStripMenuItem1, Me.LogoutToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 24)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(820, 77)
        Me.MenuStrip2.TabIndex = 7
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'EmployeeToolStripMenuItem1
        '
        Me.EmployeeToolStripMenuItem1.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmployeeToolStripMenuItem1.Image = Global.Payroll_Manager.My.Resources.Resources.employeesIcon2001
        Me.EmployeeToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EmployeeToolStripMenuItem1.Name = "EmployeeToolStripMenuItem1"
        Me.EmployeeToolStripMenuItem1.Size = New System.Drawing.Size(92, 73)
        Me.EmployeeToolStripMenuItem1.Text = "Employee"
        Me.EmployeeToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'AttendanceToolStripMenuItem2
        '
        Me.AttendanceToolStripMenuItem2.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AttendanceToolStripMenuItem2.Image = Global.Payroll_Manager.My.Resources.Resources.images_6
        Me.AttendanceToolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AttendanceToolStripMenuItem2.Name = "AttendanceToolStripMenuItem2"
        Me.AttendanceToolStripMenuItem2.Size = New System.Drawing.Size(107, 73)
        Me.AttendanceToolStripMenuItem2.Text = "Attendance"
        Me.AttendanceToolStripMenuItem2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PaymentToolStripMenuItem1
        '
        Me.PaymentToolStripMenuItem1.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaymentToolStripMenuItem1.Image = Global.Payroll_Manager.My.Resources.Resources.images_5
        Me.PaymentToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PaymentToolStripMenuItem1.Name = "PaymentToolStripMenuItem1"
        Me.PaymentToolStripMenuItem1.Size = New System.Drawing.Size(86, 73)
        Me.PaymentToolStripMenuItem1.Text = "Payment"
        Me.PaymentToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'AdvanceEntryToolStripMenuItem1
        '
        Me.AdvanceEntryToolStripMenuItem1.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvanceEntryToolStripMenuItem1.Image = Global.Payroll_Manager.My.Resources.Resources.images_3
        Me.AdvanceEntryToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AdvanceEntryToolStripMenuItem1.Name = "AdvanceEntryToolStripMenuItem1"
        Me.AdvanceEntryToolStripMenuItem1.Size = New System.Drawing.Size(129, 73)
        Me.AdvanceEntryToolStripMenuItem1.Text = "Advance Entry"
        Me.AdvanceEntryToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogoutToolStripMenuItem.Image = Global.Payroll_Manager.My.Resources.Resources.logout
        Me.LogoutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(70, 73)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        Me.LogoutToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Payroll_Manager.My.Resources.Resources.payroll3
        Me.PictureBox1.Location = New System.Drawing.Point(0, 104)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(820, 444)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'SalarySlipsToolStripMenuItem
        '
        Me.SalarySlipsToolStripMenuItem.Name = "SalarySlipsToolStripMenuItem"
        Me.SalarySlipsToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.SalarySlipsToolStripMenuItem.Text = "Salary Slips"
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(820, 573)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Menu"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DataEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AttendanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdvanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchRecordsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotePadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CalculatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeeAttendanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OverTimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeePaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdvanceEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeductionEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdvancePaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeePaymentToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AttendanceToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents EmployeeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AttendanceToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdvanceEntryToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OvertimeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SalarySlipsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
