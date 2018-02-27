Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Public Class frmEmployeePayment
    Dim rdr As oledbDataReader = Nothing
    Dim dtable As DataTable
    Dim con As oledbConnection = Nothing
    Dim adp As oledbDataAdapter
    Dim ds As DataSet
    Dim cmd As oledbCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\PayrollManagerDB.accdb;Persist Security Info=False;"
    Private ReadOnly Property Connection() As OleDbConnection
        Get
            Dim ConnectionToFetch As New OleDbConnection(cs)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property
    Public Shared Function GetUniqueKey(ByVal maxSize As Integer) As String
        Dim chars As Char() = New Char(61) {}
        chars = "123456789".ToCharArray()
        Dim data As Byte() = New Byte(0) {}
        Dim crypto As New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)
        data = New Byte(maxSize - 1) {}
        crypto.GetNonZeroBytes(data)
        Dim result As New StringBuilder(maxSize)
        For Each b As Byte In data
            result.Append(chars(b Mod (chars.Length)))
        Next
        Return result.ToString()
    End Function
    Public Sub AutoGenerate()
        PaymentID.Text = "SP-" & GetUniqueKey(9)
    End Sub
    Public Function GetData() As DataView
        Dim SelectQry = "SELECT (EmployeeName) as [Employee Name],(EmployeeID) as [Employee ID] FROM EmployeeRegistration order by employeename"
        Dim SampleSource As New DataSet
        Dim TableView As DataView
        Try
            Dim SampleCommand As New oledbCommand()
            Dim SampleDataAdapter = New oledbDataAdapter()
            SampleCommand.CommandText = SelectQry
            SampleCommand.Connection = Connection
            SampleDataAdapter.SelectCommand = SampleCommand
            SampleDataAdapter.Fill(SampleSource)
            TableView = SampleSource.Tables(0).DefaultView
        Catch ex As Exception
            Throw ex
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return TableView
    End Function

    Private Sub EmployeePayment_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        frmMainMenu.Show()
    End Sub
    Private Sub EmployeePayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetData()
        fillcombo()
    End Sub
    Sub fillcombo()

        Try
           
            Dim CN As New oledbConnection(cs)

            CN.Open()
            adp = New oledbDataAdapter()
            adp.SelectCommand = New oledbCommand("SELECT distinct  (employeeid) FROM employeeregistration", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            EmployeeID.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                EmployeeID.Items.Add(drow(0).ToString())

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EmployeeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeID.SelectedIndexChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "select employeename,salary,designation,department from employeeregistration where employeeid=@find"

            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@find", OleDbType.VarChar, 30, "employeeid"))
            cmd.Parameters("@find").Value = Trim(EmployeeID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                EmployeeName.Text = Trim(rdr.GetString(0))
                BasicSalary.Text = Trim(rdr.GetInt32(1))
                Designation.Text = Trim(rdr.GetString(2))
                Department.Text = Trim(rdr.GetString(3))
            End If

            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            con.Close()
            con.Open()
            Dim cp As String = "select count(status) from employeeattendance where WorkingDate between #" & DateFrom.Value & "# And #" & DateTo.Value & "# and status='P' and  employeeid=@find "
            cmd = New OleDbCommand(cp)
            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@find", OleDbType.VarChar, 30, "employeeid"))
            cmd.Parameters("@find").Value = Trim(EmployeeID.Text)
            Dim result = cmd.ExecuteScalar()
            PresentDays.Text = Convert.ToString(result)

            Salary.Text = CInt((Val(BasicSalary.Text) * Val(PresentDays.Text)) / 30)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Open()
            Dim cp1 As String = "select sum(amount)-sum(deduction) from advanceentry where employeeid=@find"

            cmd = New OleDbCommand(cp1)
            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@find", OleDbType.VarChar, 30, "employeeid"))
            cmd.Parameters("@find").Value = Trim(EmployeeID.Text)
            Dim result1 = cmd.ExecuteScalar()
            Advance.Text = Convert.ToString(result1)
            If Advance.Text = Nothing Then
                Advance.Text = 0
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd = New OleDbCommand("select (Overtime) as [Overtime] from employeeAttendance where WorkingDate between #" & DateFrom.Value & "# And #" & DateTo.Value & "# and EmployeeId='" & EmployeeID.Text & "'", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeeAttendance")

            Dim sumHour As Integer = 0

            Dim sumMinute As Integer = 0

            Dim sumSecond As Integer = 0

            For Each dr As DataRow In myDataSet.Tables("EmployeeAttendance").Rows

                Dim tim As TimeSpan = TimeSpan.Parse(dr("Overtime").ToString())


                sumHour += tim.Hours

                sumMinute += tim.Minutes

                sumSecond += tim.Seconds

            Next



            Dim sp As New TimeSpan(sumHour, sumMinute, sumSecond)

            Me.Overtime.Text = sp.ToString()

            con.Close()


            Deduction.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        DateFrom.value = Today
        DateTo.value = Today
        EmployeeID.Text = ""
        EmployeeName.Text = ""
        Designation.Text = ""
        Department.Text = ""
        Salary.Text = ""
        PresentDays.Text = ""
        Advance.Text = ""
        Deduction.Text = ""
        Overtime.Text = ""
        OvertimeRate.Text = ""
        OvertimeAmount.Text = ""
        PaymentDate.Text = Today
        paymentmode.Text = ""
        PaymentModeDetails.Text = ""
        NetPay.Text = ""
        PaymentID.Text = ""
        Save.Enabled = True
        Delete.Enabled = False
        Update_Record.Enabled = False
        btnSlip.Enabled = False
    End Sub
    Private Sub NewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewRecord.Click
        Reset()
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvertimeAmount.TextChanged
        NetPay.Text = CInt(Val(Salary.Text) + Val(OvertimeAmount.Text) - Val(Deduction.Text))
    End Sub

    Private Sub OvertimeRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OvertimeRate.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True

        End If
    End Sub

    Private Sub OvertimeRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvertimeRate.TextChanged
        Dim ts As TimeSpan
        If TimeSpan.TryParse(Overtime.Text, ts) Then
            Dim rate As Integer
            If Integer.TryParse(OvertimeRate.Text, rate) Then
                OvertimeAmount.Text = CInt((ts.TotalMinutes * rate) / 60)
            End If

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlip.Click
        If Me.EmployeeID.Text = "" Then
            MessageBox.Show("Please select employee id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.EmployeeID.Focus()
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Timer1.Enabled = True
        frmSalarySlip.Show()
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        Try
            If Len(Trim(EmployeeID.Text)) = 0 Then
                MessageBox.Show("Please select employee id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                EmployeeID.Focus()
                Exit Sub
            End If

            If Len(Trim(OvertimeRate.Text)) = 0 Then
                MessageBox.Show("Please enter overtime rate", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                OvertimeRate.Focus()
                Exit Sub
            End If
            If Len(Trim(paymentmode.Text)) = 0 Then
                MessageBox.Show("Please select payment mode", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                paymentmode.Focus()
                Exit Sub
            End If
            If OvertimeAmount.Text = Nothing Then
                OvertimeAmount.Text = 0
            End If
            If Advance.Text = Nothing Then
                Advance.Text = 0
            End If
            If Val(Advance.Text) < Val(Deduction.Text) Then
                MessageBox.Show("You can not deduct amount more than advance amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Deduction.Focus()
                Exit Sub
            End If
            If Val(NetPay.Text) < 0 Then
                MessageBox.Show("net pay should be more than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "select employeeid,paymentdate from employeepayment where employeeid='" & EmployeeID.Text & "' and paymentdate= #" & PaymentDate.Text & "#"

            cmd = New OleDbCommand(ct)
            cmd.Connection = con

            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Employee is already paid today", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                EmployeeID.Focus()
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If

            Else
                con = New OleDbConnection(cs)
                con.Open()
                AutoGenerate()
                Dim cb As String = "insert into employeepayment(PaymentID,DateFrom,DateTo,EmployeeID,PresentDays,Salary,Advance,Deduction,OverTime,OverTimeRate,OverTimeAmount,PaymentDate,ModeOfPayment,PaymentModeDetails,Netpay) values('" & PaymentID.Text & "','" & DateFrom.Text & "','" & DateTo.Text & "','" & EmployeeID.Text & "'," & PresentDays.Text & "," & Salary.Text & "," & Advance.Text & "," & Deduction.Text & ",'" & Overtime.Text & "'," & OvertimeRate.Text & "," & OvertimeAmount.Text & ",'" & PaymentDate.Text & "','" & paymentmode.Text & "','" & PaymentModeDetails.Text & "'," & NetPay.Text & ")"
                cmd = New OleDbCommand(cb)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                con.Close()
                con = New OleDbConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into advanceentry(workingdate,employeeid,amount,deduction) VALUES (@d1,@d2,@d3,@d4)"

                cmd = New OleDbCommand(cb1)

                cmd.Connection = con

                cmd.Parameters.Add(New OleDbParameter("@d1", OleDbType.VarChar, 30, "workingdate"))
                cmd.Parameters.Add(New OleDbParameter("@d2", OleDbType.VarChar, 30, "employeeid"))
                cmd.Parameters.Add(New OleDbParameter("@d3", OleDbType.Integer, 10, "amount"))
                cmd.Parameters.Add(New OleDbParameter("@d4", OleDbType.Integer, 10, "deduction"))
                cmd.Parameters("@d1").Value = PaymentDate.Text
                cmd.Parameters("@d2").Value = EmployeeID.Text
                cmd.Parameters("@d3").Value = 0
                cmd.Parameters("@d4").Value = CInt(Deduction.Text)
                cmd.ExecuteReader()
                Save.Enabled = False
                btnSlip.Enabled = True
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Deduction_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Deduction.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then

            e.Handled = True

        End If
    End Sub

    Private Sub Deduction_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Deduction.TextChanged
        NetPay.Text = Val(Salary.Text) + Val(OvertimeAmount.Text) - Val(Deduction.Text)
    End Sub

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Try

            If MessageBox.Show("Do you really want to delete the records?" & vbCrLf & "You can not restore the records" & vbCrLf & "It will delete all the records permanently" & vbCrLf & "related to selected employee", "Payment Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                delete_records()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub delete_records()
        Try
            Dim RowsAffected As Integer = 0
            con = New OleDbConnection(cs)

            con.Open()
            Dim cq As String = "delete from employeepayment where PaymentID=@DELETE1;"
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@DELETE1", OleDbType.VarChar, 30, "PaymentID"))
            cmd.Parameters("@DELETE1").Value = Trim(PaymentID.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                If con.State = ConnectionState.Open Then

                    con.Close()
                End If

                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Update_Record_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update_Record.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()

            Dim cb As String = "update employeepayment set datefrom=#" & DateFrom.Value & "#,dateto=#" & DateTo.Value & "#,employeeid='" & EmployeeID.Text & "',presentdays=" & PresentDays.Text & ",advance=" & Advance.Text & ",deduction=" & Deduction.Text & ",overtime='" & Overtime.Text & "',overtimerate=" & OvertimeRate.Text & ",overtimeamount=" & OvertimeAmount.Text & ",paymentdate=#" & PaymentDate.Text & "#,modeofpayment='" & paymentmode.Text & "',paymentmodedetails='" & PaymentModeDetails.Text & "',netpay=" & NetPay.Text & " where PaymentID='" & PaymentID.Text & "'"

            cmd = New oledbCommand(cb)

            cmd.Connection = con

            If MessageBox.Show("Are you sure want to update the record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Update_Record.Enabled = False

            End If

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmEmployeePaymentRecord.DateFrom.Value = Today
        frmEmployeePaymentRecord.DateTo.Value = Today
        frmEmployeePaymentRecord.DataGridView2.DataSource = Nothing
        frmEmployeePaymentRecord.DataGridView1.DataSource = Nothing
        frmEmployeePaymentRecord.EmployeeName.Text = ""
        frmEmployeePaymentRecord.fillcombo()
        frmEmployeePaymentRecord.Show()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.EmployeeID.Text = dr.Cells(1).Value.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class