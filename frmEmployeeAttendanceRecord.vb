Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.oledb
Public Class frmEmployeeAttendanceRecord
    Dim rdr As oledbDataReader = Nothing
    Dim dtable As DataTable
    Dim con As oledbConnection = Nothing
    Dim adp As oledbDataAdapter
    Dim ds As DataSet
    Dim cmd As oledbCommand = Nothing
    Dim dt As New DataTable

    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\PayrollManagerDB.accdb;Persist Security Info=False;"

    Sub fillcombo()

        Try
           
            Dim CN As New oledbConnection(cs)

            CN.Open()
            adp = New oledbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct (employeeid) FROM employeeattendance", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            EmployeeID.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                EmployeeID.Items.Add(drow(0).ToString())
                'DocName.SelectedIndex = -1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EmployeeAttendanceRecord_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        frmMainMenu.Show()
    End Sub
    Private Sub EmployeeAttendanceRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcombo()
        DataGridView2.DataSource = GetData()
    End Sub


    Private Sub button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button4.Click
        Try
            If Len(Trim(EmployeeID.Text)) = 0 Then
                MessageBox.Show("Please select employee id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                EmployeeID.Focus()
                Exit Sub
            End If
            Total.Visible = True
            con = New oledbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select (WorkingDate) as [Working Date],(Status) as [Status], (InTime) as [In Time],(OutTime) as [Out Time],(Overtime) as [Overtime] from employeeAttendance where WorkingDate between #" & DateFrom.Text & "# And #" & DateTo.Text & "# and EmployeeId='" & EmployeeID.Text & "' order by workingdate", con)

            Dim myDA As oledbDataAdapter = New oledbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "EmployeeAttendance")

            DataGridView1.DataSource = myDataSet.Tables("EmployeeAttendance").DefaultView


            Me.DataGridView1.Columns("overtime").DefaultCellStyle.Format = "HH:mm:ss"
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

            Me.TotalOvertime.Text = sp.ToString()

            con.Close()

            con.Open()

            Dim cp As String = "select count(status) from employeeattendance where WorkingDate between #" & DateFrom.Text & "# And #" & DateTo.Text & "# and status='P' and  employeeid=@find "

            cmd = New oledbCommand(cp)
            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@find", OleDbType.VarChar, 30, "employeeid"))
            cmd.Parameters("@find").Value = Trim(EmployeeID.Text)

            Dim result = cmd.ExecuteScalar()

            TextBox2.Text = Convert.ToString(result)



            If con.State = ConnectionState.Open Then
                con.Close()
            End If



            con.Open()


            Dim cp1 As String = "select count(status) from employeeattendance where WorkingDate between #" & DateFrom.Text & "# And #" & DateTo.Text & "# and  employeeid=@find "

            cmd = New oledbCommand(cp1)
            cmd.Connection = con

            cmd.Parameters.Add(New oledbParameter("@find", oledbType.Varchar, 30, "employeeid"))
            cmd.Parameters("@find").Value = Trim(EmployeeID.Text)

            Dim result1 = cmd.ExecuteScalar()

            TextBox1.Text = Convert.ToString(result1)



            If con.State = ConnectionState.Open Then
                con.Close()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button5.Click
        DataGridView1.DataSource = Nothing
        Total.Visible = False
        EmployeeID.Text = ""
        EmployeeName.Text = ""
        DateFrom.value = Today
        DateTo.value = Today
    End Sub

    Private Sub EmployeeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeID.SelectedIndexChanged
        Try

            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "select employeename from employeeattendance,EmployeeRegistration where EmployeeRegistration.EmployeeID=EmployeeAttendance.EmployeeID and EmployeeRegistration.employeeid=@find"
            cmd = New oledbCommand(ct)
            cmd.Connection = con
            cmd.Parameters.Add(New oledbParameter("@find", oledbType.Varchar, 30, "employeeid"))
            cmd.Parameters("@find").Value = Trim(EmployeeID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then

                EmployeeName.Text = Trim(rdr.GetString(0))

            End If

            If Not rdr Is Nothing Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

      Private ReadOnly Property Connection() As oledbConnection
        Get
            Dim ConnectionToFetch As New OleDbConnection(cs)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property
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

    Private Sub DataGridView2_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
            Me.EmployeeName.Text = dr.Cells(0).Value.ToString()
            Me.EmployeeID.Text = dr.Cells(1).Value.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button6.Click
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
End Class