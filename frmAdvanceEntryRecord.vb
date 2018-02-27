Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmAdvanceEntryRecord
    Dim rdr As oledbDataReader = Nothing
    Dim dtable As DataTable
    Dim con As oledbConnection = Nothing
    Dim adp As oledbDataAdapter
    Dim ds As DataSet
    Dim cmd As oledbCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\PayrollManagerDB.accdb;Persist Security Info=False;"

    Private Sub AdvanceEntryRecord_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        frmMainMenu.Show()
    End Sub
    Sub fillcombo()

        Try
            Dim CN As New oledbConnection(cs)
            CN.Open()
            adp = New oledbDataAdapter()
            adp.SelectCommand = New OleDbCommand("SELECT distinct (employeename) FROM Advanceentry,employeeRegistration where EmployeeRegistration.EmployeeID=AdvanceEntry.EmployeeID", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            EmployeeName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                EmployeeName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub AdvanceEntryRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcombo()
    End Sub

    Private Sub EmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeName.SelectedIndexChanged
        Try
            Total.Visible = True
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select (workingdate) as [Entry Date],(EmployeeRegistration.EmployeeID) as [Employee ID],(EmployeeName) as [EmployeeName],(Amount) as [Advance] from Advanceentry,employeeRegistration where EmployeeRegistration.EmployeeID=AdvanceEntry.EmployeeID and amount > 0 and  Employeename = '" & EmployeeName.Text & "'order by workingdate", con)
            Dim myDA As oledbDataAdapter = New oledbDataAdapter(cmd)

            Dim myDataSet As DataSet = New DataSet()

            myDA.Fill(myDataSet, "AdvanceEntry")
            myDA.Fill(myDataSet, "EmployeeRegistration")
            DataGridView1.DataSource = myDataSet.Tables("AdvanceEntry").DefaultView
            DataGridView1.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView
            Dim sum As Double = 0
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(3).Value

            Next
            TotalAdvance.Text = sum

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button8.Click
        DataGridView1.DataSource = Nothing
        EmployeeName.Text = ""
        Total.Visible = False
    End Sub

    Private Sub button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button4.Click
        Try
            GroupBox1.Visible = True
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select (workingdate) as [Entry Date],(EmployeeRegistration.EmployeeID) as [Employee ID],(EmployeeName) as [EmployeeName],(Amount) as [Advance] from Advanceentry,employeeRegistration where EmployeeRegistration.EmployeeID=AdvanceEntry.EmployeeID and amount > 0 and  WorkingDate between #" & DateFrom.Text & "# And #" & DateTo.Text & "#  order by workingdate", con)
            Dim myDA As oledbDataAdapter = New oledbDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "AdvanceEntry")
            myDA.Fill(myDataSet, "EmployeeRegistration")
            DataGridView2.DataSource = myDataSet.Tables("AdvanceEntry").DefaultView
            DataGridView2.DataSource = myDataSet.Tables("EmployeeRegistration").DefaultView
            Dim sum As Double = 0
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(3).Value
            Next
            TextBox1.Text = sum
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button5.Click
        DateFrom.value = Today
        DateTo.value = Today
        DataGridView2.DataSource = Nothing
        GroupBox1.Visible = False
    End Sub

    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        DateFrom.value = Today
        DateTo.value = Today
        DataGridView2.DataSource = Nothing
        GroupBox1.Visible = False
        DataGridView1.DataSource = Nothing
        EmployeeName.Text = ""
        Total.Visible = False
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
End Class