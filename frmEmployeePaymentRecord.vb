Imports System.Data.oledb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmEmployeePaymentRecord
    Dim rdr As oledbDataReader = Nothing
    Dim dtable As DataTable
    Dim con As oledbConnection = Nothing
    Dim adp As oledbDataAdapter
    Dim ds As DataSet
    Dim cmd As oledbCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\PayrollManagerDB.accdb;Persist Security Info=False;"

   

    Private Sub EmployeePaymentRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcombo()
    End Sub


    Private Sub button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button8.Click
        DataGridView1.DataSource = Nothing
        EmployeeName.Text = ""

    End Sub

    Private Sub button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button5.Click
        DateFrom.value = Today
        DateTo.value = Today
        DataGridView2.DataSource = Nothing

    End Sub

    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        DateFrom.value = Today
        DateTo.value = Today
        DataGridView2.DataSource = Nothing
        DataGridView1.DataSource = Nothing
        EmployeeName.Text = ""
    End Sub
    Sub fillcombo()

        Try
            
            Dim CN As New oledbConnection(cs)

            CN.Open()
            adp = New oledbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct  (employeename) FROM employeeRegistration,EmployeePayment where EmployeeRegistration.EmployeeID=Employeepayment.EmployeeID", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            EmployeeName.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                EmployeeName.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeName.SelectedIndexChanged
        Try

            con = New oledbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select (PaymentID) as [Payment ID],(DateFrom) as [Date From],(dateto) as [Date To],(EmployeeRegistration.employeeid) as [Employee ID],(Employeename) as [Employee Name],(designation) as [Designation],(department) as [Department],(EmployeePayment.salary) as [Salary],(presentdays) as [Prsesent Days],(advance) as [Advance],(deduction) as [Deduction],(overtime) as [Overtime],(overtimerate)as [Overtime Rate],(overtimeamount) as [Overtime Amount],(paymentdate) as [Payment Date],(modeofpayment) as [Payment Mode],(paymentmodedetails) as [Payment Mode Details],(netpay) as [Net Pay] from employeepayment,EmployeeRegistration where EmployeeRegistration.EmployeeID=EmployeePayment.EmployeeID and Employeename = '" & EmployeeName.Text & "'order by paymentdate", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "EmployeePayment")
            myDA.Fill(myDataSet, "EmployeeRegistration")
            DataGridView1.DataSource = myDataSet.Tables("EmployeePayment").DefaultView
            DataGridView1.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button4.Click
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select (PaymentID) as [Payment ID],(DateFrom) as [Date From],(dateto) as [Date To],(EmployeeRegistration.employeeid) as [Employee ID],(Employeename) as [Employee Name],(designation) as [Designation],(department) as [Department],(EmployeePayment.salary) as [Salary],(presentdays) as [Prsesent Days],(advance) as [Advance],(deduction) as [Deduction],(overtime) as [Overtime],(overtimerate)as [Overtime Rate],(overtimeamount) as [Overtime Amount],(paymentdate) as [Payment Date],(modeofpayment) as [Payment Mode],(paymentmodedetails) as [Payment Mode Details],(netpay) as [Net Pay]  from employeepayment,EmployeeRegistration where EmployeeRegistration.EmployeeID=EmployeePayment.EmployeeID and paymentdate between #" & DateFrom.Value & "# And #" & DateTo.Value & "# order by PaymentDate", con)

            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeePayment")
            myDA.Fill(myDataSet, "EmployeeRegistration")
            DataGridView2.DataSource = myDataSet.Tables("EmployeePayment").DefaultView
            DataGridView2.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button6.Click
        If DataGridView2.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application

        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = DataGridView2.RowCount - 1
            colsTotal = DataGridView2.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView2.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView2.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView1.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application

        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = DataGridView1.RowCount - 1
            colsTotal = DataGridView1.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView1.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView1.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Me.Hide()
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            frmEmployeePayment.PaymentID.Text = dr.Cells(0).Value.ToString()
            frmEmployeePayment.DateFrom.Text = dr.Cells(1).Value.ToString()
            frmEmployeePayment.DateTo.Text = dr.Cells(2).Value.ToString()
            frmEmployeePayment.EmployeeID.Text = dr.Cells(3).Value.ToString()
            frmEmployeePayment.EmployeeName.Text = dr.Cells(4).Value.ToString()
            frmEmployeePayment.Designation.Text = dr.Cells(5).Value.ToString()
            frmEmployeePayment.Department.Text = dr.Cells(6).Value.ToString()
            frmEmployeePayment.Salary.Text = dr.Cells(7).Value.ToString()
            frmEmployeePayment.PresentDays.Text = dr.Cells(8).Value.ToString()
            frmEmployeePayment.Advance.Text = dr.Cells(9).Value.ToString()
            frmEmployeePayment.Deduction.Text = dr.Cells(10).Value.ToString()
            frmEmployeePayment.Overtime.Text = dr.Cells(11).Value.ToString()
            frmEmployeePayment.OvertimeRate.Text = dr.Cells(12).Value.ToString()
            frmEmployeePayment.OvertimeAmount.Text = dr.Cells(13).Value.ToString()
            frmEmployeePayment.PaymentDate.Text = dr.Cells(14).Value.ToString()
            frmEmployeePayment.paymentmode.Text = dr.Cells(15).Value.ToString()
            frmEmployeePayment.PaymentModeDetails.Text = dr.Cells(16).Value.ToString()
            frmEmployeePayment.NetPay.Text = dr.Cells(17).Value.ToString()
            frmEmployeePayment.Save.Enabled = False
            frmEmployeePayment.Delete.Enabled = True
            frmEmployeePayment.Update_Record.Enabled = True
            frmEmployeePayment.btnSlip.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView2_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick
        Try
            Me.Hide()
            Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
            frmEmployeePayment.PaymentID.Text = dr.Cells(0).Value.ToString()
            frmEmployeePayment.DateFrom.Text = dr.Cells(1).Value.ToString()
            frmEmployeePayment.DateTo.Text = dr.Cells(2).Value.ToString()
            frmEmployeePayment.EmployeeID.Text = dr.Cells(3).Value.ToString()
            frmEmployeePayment.EmployeeName.Text = dr.Cells(4).Value.ToString()
            frmEmployeePayment.Designation.Text = dr.Cells(5).Value.ToString()
            frmEmployeePayment.Department.Text = dr.Cells(6).Value.ToString()
            frmEmployeePayment.Salary.Text = dr.Cells(7).Value.ToString()
            frmEmployeePayment.PresentDays.Text = dr.Cells(8).Value.ToString()
            frmEmployeePayment.Advance.Text = dr.Cells(9).Value.ToString()
            frmEmployeePayment.Deduction.Text = dr.Cells(10).Value.ToString()
            frmEmployeePayment.Overtime.Text = dr.Cells(11).Value.ToString()
            frmEmployeePayment.OvertimeRate.Text = dr.Cells(12).Value.ToString()
            frmEmployeePayment.OvertimeAmount.Text = dr.Cells(13).Value.ToString()
            frmEmployeePayment.PaymentDate.Text = dr.Cells(14).Value.ToString()
            frmEmployeePayment.paymentmode.Text = dr.Cells(15).Value.ToString()
            frmEmployeePayment.PaymentModeDetails.Text = dr.Cells(16).Value.ToString()
            frmEmployeePayment.NetPay.Text = dr.Cells(17).Value.ToString()
            frmEmployeePayment.Save.Enabled = False
            frmEmployeePayment.Delete.Enabled = True
            frmEmployeePayment.Update_Record.Enabled = True
            frmEmployeePayment.btnSlip.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class