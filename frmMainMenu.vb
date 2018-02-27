Public Class frmMainMenu

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAboutBox1.Show()
    End Sub

  
    Private Sub NotePadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotePadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Notepad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

  
    Private Sub main_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripStatusLabel4.Text = Now
        ToolStripStatusLabel2.Text = frmlogin.UserName.Text
    End Sub

   
    Private Sub SystemInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemInfoToolStripMenuItem.Click
        frmSystemInfo.Show()
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeToolStripMenuItem.Click
        Me.Hide()
        frmEmployeesRecord.Show()
    End Sub



    Private Sub EmployeeAttendanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeAttendanceToolStripMenuItem.Click
        Me.Hide()
        frmEmployeeAttendanceRecord.Show()

    End Sub

    Private Sub AttendanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendanceToolStripMenuItem.Click
        Me.Hide()
        frmAttendance.Show()
        frmAttendance.Reset()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Start()
        ToolStripStatusLabel4.Text = Now
    End Sub

    Private Sub OverTimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverTimeToolStripMenuItem.Click
        Me.Hide()
        frmSearchByOverTime.Show()
    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        frmEmployeeAttendanceRecord.Show()
    End Sub

   
    Private Sub AdvanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceToolStripMenuItem.Click
        Me.Hide()
        frmAdvance.Show()
        frmAdvance.Reset()
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        Me.Hide()
        frmEmployeePayment.Show()
        frmEmployeePayment.Reset()
    End Sub

    Private Sub RegistrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem.Click
        Me.Hide()
        frmEmployee_registration.Show()
        frmEmployee_registration.Reset()
    End Sub


    Private Sub AdvanceEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceEntryToolStripMenuItem.Click
        Me.Hide()
        frmAdvanceEntryRecord.Show()
    End Sub

    Private Sub EmployeePaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeePaymentToolStripMenuItem.Click
        Me.Hide()
        frmEmployeePaymentRecord1.Show()
    End Sub

    Private Sub DeductionEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeductionEntryToolStripMenuItem.Click
        Me.Hide()
        frmDeductionEntryRecord.Show()
    End Sub


    Private Sub EmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesToolStripMenuItem.Click
        Me.Hide()
        frmEmployeeReport.Show()
    End Sub

    Private Sub AdvancePaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancePaymentToolStripMenuItem.Click
        Me.Hide()
        frmAdvanceEntryReport.Show()
    End Sub

    Private Sub AttendanceToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendanceToolStripMenuItem2.Click
        Me.Hide()
        frmAttendance.Show()
        frmAttendance.Reset()
    End Sub

    Private Sub EmployeeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeToolStripMenuItem1.Click
        Me.Hide()
        frmEmployee_registration.Show()
        frmEmployee_registration.Reset()
    End Sub

    Private Sub AdvanceEntryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceEntryToolStripMenuItem1.Click
        Me.Hide()
        frmAdvance.Show()
        frmAdvance.Reset()
    End Sub

    Private Sub PaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem1.Click
        Me.Hide()
        frmEmployeePayment.Show()
        frmEmployeePayment.Reset()
    End Sub

    Private Sub OvertimeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvertimeToolStripMenuItem1.Click
        Me.Hide()
        frmOverTimeReport.Show()
    End Sub

    Private Sub EmployeePaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeePaymentToolStripMenuItem1.Click
        Me.Hide()
        frmEmployeePaymentReport.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Hide()
        frmlogin.UserName.Text = ""
        frmlogin.Password.Text = ""
        frmlogin.ProgressBar1.Visible = False
        frmlogin.Show()
        frmlogin.UserName.Focus()
    End Sub

    Private Sub AttendanceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendanceToolStripMenuItem1.Click
        Me.Hide()
        frmAttendanceReport.Show()
    End Sub

    Private Sub SalarySlipsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalarySlipsToolStripMenuItem.Click
        Me.Hide()
        frmSalarySlipsReport.Show()
    End Sub
End Class