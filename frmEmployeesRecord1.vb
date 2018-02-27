Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Public Class frmEmployeesRecord1
    Dim rdr As oledbDataReader = Nothing
    Dim dtable As DataTable
    Dim con As oledbConnection = Nothing
    Dim adp As oledbDataAdapter
    Dim ds As DataSet
    Dim cmd As oledbCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\PayrollManagerDB.accdb;Persist Security Info=False;"


    Private Sub button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button8.Click
        DataGridView1.DataSource = Nothing
        EmployeeName.Text = ""
    End Sub
    Sub exportExcel()
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

    Private Sub EmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeName.SelectedIndexChanged
        Try
            con = New oledbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select (EmployeeID) as [Employee ID], (EmployeeName) as [Employee Name],(Address) as [Address],(MobileNo) as [Mobile No],(Email) as [Email],(BloodGroup) as [Blood Group],(Department) as [Department],(Designation) as [Designation],(DateOfJoining) as [Date Of Joining],(Salary) as [Basic Salary],(BasicWorkingTime) as [Basic Working Time] from employeeregistration where Employeename = '" & EmployeeName.Text & "'", con)
            Dim myDA As oledbDataAdapter = New oledbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeeRegistration")

            DataGridView1.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button6.Click

        exportExcel()
    End Sub
    Sub fillcombo()

        Try

            Dim CN As New oledbConnection(cs)

            CN.Open()
            adp = New oledbDataAdapter()
            adp.SelectCommand = New oledbCommand("SELECT distinct  (employeename) FROM employeeregistration", CN)
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

  
    Private Sub EmployeesRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcombo()
    End Sub


    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        DataGridView1.DataSource = Nothing
        EmployeeName.Text = ""
        DataGridView2.DataSource = Nothing
        DateFrom.value = Today
        DateTo.value = Today
        DataGridView3.DataSource = Nothing
    End Sub

    Private Sub button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button5.Click
        DataGridView2.DataSource = Nothing
        DateFrom.value = Today
        DateTo.value = Today
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
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

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        DataGridView3.DataSource = Nothing
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView3.RowCount = Nothing Then
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

            rowsTotal = DataGridView3.RowCount - 1
            colsTotal = DataGridView3.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView3.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView3.Rows(I).Cells(j).Value
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

    Private Sub button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button4.Click
        Try
            con = New oledbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select (EmployeeID) as [Employee ID], (EmployeeName) as [Employee Name],(Address) as [Address],(MobileNo) as [Mobile No],(Email) as [Email],(BloodGroup) as [Blood Group],(Department) as [Department],(Designation) as [Designation],(DateOfJoining) as [Date Of Joining],(Salary) as [Basic Salary],(BasicWorkingTime) as [Basic Working Time] from employeeregistration where DateOfJoining between #" & DateFrom.value & "# And #" & DateTo.value & "# order by dateofjoining", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeeRegistration")

            DataGridView2.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView



            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            con = New oledbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select (EmployeeID) as [Employee ID], (EmployeeName) as [Employee Name],(Address) as [Address],(MobileNo) as [Mobile No],(Email) as [Email],(BloodGroup) as [Blood Group],(Department) as [Department],(Designation) as [Designation],(DateOfJoining) as [Date Of Joining],(Salary) as [Basic Salary],(BasicWorkingTime) as [Basic Working Time] from employeeregistration order by EmployeeName,dateofjoining ", con)
            Dim myDA As oledbDataAdapter = New oledbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeeRegistration")

            DataGridView3.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView



            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmEmployee_registration.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmEmployee_registration.EmployeeID.Text = dr.Cells(0).Value.ToString()
            frmEmployee_registration.EmployeeName.Text = dr.Cells(1).Value.ToString()
            frmEmployee_registration.Address.Text = dr.Cells(2).Value.ToString()
            frmEmployee_registration.MobileNo.Text = dr.Cells(3).Value.ToString()
            frmEmployee_registration.Email.Text = dr.Cells(4).Value.ToString()
            frmEmployee_registration.BloodGroup.Text = dr.Cells(5).Value.ToString()
            frmEmployee_registration.Department.Text = dr.Cells(6).Value.ToString()
            frmEmployee_registration.Designation.Text = dr.Cells(7).Value.ToString()
            frmEmployee_registration.DateOfJoining.Text = dr.Cells(8).Value.ToString()
            frmEmployee_registration.Salary.Text = dr.Cells(9).Value.ToString()
            frmEmployee_registration.BasicWorkingTime.Text = dr.Cells(10).Value.ToString()
            frmEmployee_registration.Update_Record.Enabled = True
            frmEmployee_registration.Delete.Enabled = True
            frmEmployee_registration.Save.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView2_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
            Me.Hide()
            frmEmployee_registration.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmEmployee_registration.EmployeeID.Text = dr.Cells(0).Value.ToString()
            frmEmployee_registration.EmployeeName.Text = dr.Cells(1).Value.ToString()
            frmEmployee_registration.Address.Text = dr.Cells(2).Value.ToString()
            frmEmployee_registration.MobileNo.Text = dr.Cells(3).Value.ToString()
            frmEmployee_registration.Email.Text = dr.Cells(4).Value.ToString()
            frmEmployee_registration.BloodGroup.Text = dr.Cells(5).Value.ToString()
            frmEmployee_registration.Department.Text = dr.Cells(6).Value.ToString()
            frmEmployee_registration.Designation.Text = dr.Cells(7).Value.ToString()
            frmEmployee_registration.DateOfJoining.Text = dr.Cells(8).Value.ToString()
            frmEmployee_registration.Salary.Text = dr.Cells(9).Value.ToString()
            frmEmployee_registration.BasicWorkingTime.Text = dr.Cells(10).Value.ToString()
            frmEmployee_registration.Update_Record.Enabled = True
            frmEmployee_registration.Delete.Enabled = True
            frmEmployee_registration.Save.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView3_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView3.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
            Me.Hide()
            frmEmployee_registration.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmEmployee_registration.EmployeeID.Text = dr.Cells(0).Value.ToString()
            frmEmployee_registration.EmployeeName.Text = dr.Cells(1).Value.ToString()
            frmEmployee_registration.Address.Text = dr.Cells(2).Value.ToString()
            frmEmployee_registration.MobileNo.Text = dr.Cells(3).Value.ToString()
            frmEmployee_registration.Email.Text = dr.Cells(4).Value.ToString()
            frmEmployee_registration.BloodGroup.Text = dr.Cells(5).Value.ToString()
            frmEmployee_registration.Department.Text = dr.Cells(6).Value.ToString()
            frmEmployee_registration.Designation.Text = dr.Cells(7).Value.ToString()
            frmEmployee_registration.DateOfJoining.Text = dr.Cells(8).Value.ToString()
            frmEmployee_registration.Salary.Text = dr.Cells(9).Value.ToString()
            frmEmployee_registration.BasicWorkingTime.Text = dr.Cells(10).Value.ToString()
            frmEmployee_registration.Update_Record.Enabled = True
            frmEmployee_registration.Delete.Enabled = True
            frmEmployee_registration.Save.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub txtEmployee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmployee.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select (EmployeeID) as [Employee ID], (EmployeeName) as [Employee Name],(Address) as [Address],(MobileNo) as [Mobile No],(Email) as [Email],(BloodGroup) as [Blood Group],(Department) as [Department],(Designation) as [Designation],(DateOfJoining) as [Date Of Joining],(Salary) as [Basic Salary],(BasicWorkingTime) as [Basic Working Time] from employeeregistration where Employeename like '" & EmployeeName.Text & "%' order by EmployeeName", con)
            Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeeRegistration")

            DataGridView1.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class