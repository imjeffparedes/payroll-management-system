Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Public Class frmEmployee_registration
    Dim rdr As oledbDataReader = Nothing
    Dim dtable As New DataTable
    Dim con As oledbConnection = Nothing
    Dim adp As oledbDataAdapter
    Dim ds As DataSet
    Dim cmd As oledbCommand = Nothing
    Dim dt As New DataTable

    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\PayrollManagerDB.accdb;Persist Security Info=False;"

    Private Sub Employee_registration_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMainMenu.Show()
    End Sub
    Public Sub AutoGenerate()
        EmployeeID.Text = "E-" & GetUniqueKey(6)
    End Sub
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
    Sub Reset()
        EmployeeID.Text = ""
        EmployeeName.Text = ""
        Address.Text = ""
        MobileNo.Text = ""
        Email.Text = ""
        Designation.Text = ""
        Department.Text = ""
        DateOfJoining.Text = Today
        Salary.Text = ""
        BloodGroup.Text = ""
        BasicWorkingTime.Text = ""
        Update_Record.Enabled = False
        Delete.Enabled = False
        Save.Enabled = True
        EmployeeName.Focus()
    End Sub


    Private Sub NewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewRecord.Click
        Reset()
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
      
        If Len(Trim(EmployeeName.Text)) = 0 Then
            MessageBox.Show("Please enter employee name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EmployeeName.Focus()
            Exit Sub
        End If
        If Len(Trim(Address.Text)) = 0 Then
            MessageBox.Show("Please enter address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Address.Focus()
            Exit Sub
        End If
        If Len(Trim(MobileNo.Text)) = 0 Then
            MessageBox.Show("Please enter mobile no.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MobileNo.Focus()
            Exit Sub
        End If
        If Len(Trim(Department.Text)) = 0 Then
            MessageBox.Show("Please enter department", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Department.Focus()
            Exit Sub
        End If
        If Len(Trim(Designation.Text)) = 0 Then
            MessageBox.Show("Please enter designation", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Designation.Focus()
            Exit Sub
        End If
        If Len(Trim(Salary.Text)) = 0 Then
            MessageBox.Show("Please enter basic Salary", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Salary.Focus()
            Exit Sub
        End If
        If Len(Trim(BasicWorkingTime.Text)) = 0 Then
            MessageBox.Show("Please enter basic working time", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            BasicWorkingTime.Focus()
            Exit Sub
        End If
        Try
            AutoGenerate()
                con = New OleDbConnection(cs)
                con.Open()

                Dim cb As String = "insert into employeeregistration(employeeid,employeename,address,mobileno,email,bloodgroup,department,designation,dateofjoining,salary,basicworkingtime) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"

                cmd = New oledbCommand(cb)

                cmd.Connection = con

                cmd.Parameters.Add(New oledbParameter("@d1", oledbType.Varchar, 30, "employeeid"))

                cmd.Parameters.Add(New oledbParameter("@d2", oledbType.VarChar, 100, "employeename"))

                cmd.Parameters.Add(New oledbParameter("@d3", oledbType.VarChar, 200, "address"))

                cmd.Parameters.Add(New oledbParameter("@d4", oledbType.Varchar, 10, "mobileno"))

                cmd.Parameters.Add(New oledbParameter("@d5", oledbType.Varchar, 60, "email"))

                cmd.Parameters.Add(New oledbParameter("@d6", oledbType.Varchar, 10, "bloodgroup"))

                cmd.Parameters.Add(New oledbParameter("@d7", oledbType.Varchar, 60, "department"))

                cmd.Parameters.Add(New oledbParameter("@d8", oledbType.Varchar, 60, "designation"))

                cmd.Parameters.Add(New oledbParameter("@d9", oledbType.Varchar, 30, "dateofjoining"))

                cmd.Parameters.Add(New oledbParameter("@d10", oledbType.Varchar, 10, "salary"))

                cmd.Parameters.Add(New oledbParameter("@d11", oledbType.Varchar, 10, "basicworkingtime"))

                cmd.Parameters("@d1").Value = EmployeeID.Text

                cmd.Parameters("@d2").Value = EmployeeName.Text

                cmd.Parameters("@d3").Value = Address.Text

                cmd.Parameters("@d4").Value = MobileNo.Text

                cmd.Parameters("@d5").Value = Email.Text
                cmd.Parameters("@d6").Value = BloodGroup.Text

                cmd.Parameters("@d7").Value = Department.Text

                cmd.Parameters("@d8").Value = Designation.Text

                cmd.Parameters("@d9").Value = DateOfJoining.Text

                cmd.Parameters("@d10").Value = Salary.Text


                cmd.Parameters("@d11").Value = BasicWorkingTime.Text
                cmd.ExecuteReader()
                MessageBox.Show("Successfully saved", "Employee Profile", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Save.Enabled = False
                Filldepartment()
                FillDesignation()

                EmployeeID.Focus()

                con.Close()
         
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
   
    Sub Filldepartment()
        Try
            
            Dim CN As New oledbConnection(cs)

            CN.Open()
            adp = New oledbDataAdapter()
            adp.SelectCommand = New oledbCommand("SELECT distinct (department) FROM employeeregistration", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            Department.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                Department.Items.Add(drow(0).ToString())

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillDesignation()
        Try
          
            Dim CN As New oledbConnection(cs)

            CN.Open()
            adp = New oledbDataAdapter()
            adp.SelectCommand = New oledbCommand("SELECT distinct (designation) FROM employeeregistration", CN)
            ds = New DataSet("ds")

            adp.Fill(ds)
            dtable = ds.Tables(0)
            Designation.Items.Clear()

            For Each drow As DataRow In dtable.Rows
                Designation.Items.Add(drow(0).ToString())

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Employee_registration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Filldepartment()
        FillDesignation()
    End Sub

    Private Sub Salary_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Salary.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.Salary.Text
            Dim selectionStart = Me.Salary.SelectionStart
            Dim selectionLength = Me.Salary.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub Department_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Department.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'space accepted
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then

            e.Handled = False
        End If
    End Sub

    Private Sub Designation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Designation.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'space accepted
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then

            e.Handled = False
        End If
    End Sub

    Private Sub EmployeeID_Format(ByVal sender As Object, ByVal e As System.Windows.Forms.ListControlConvertEventArgs)
        If e.DesiredType Is GetType(String) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub


    Private Sub Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update_Record.Click
        Try
            If Len(Trim(EmployeeID.Text)) = 0 Then
                MessageBox.Show("Please select employee id", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                EmployeeID.Focus()
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()

            Dim cb As String = "Update Employeeregistration set employeename='" & EmployeeName.Text & "',address='" & Address.Text & "',mobileno='" & MobileNo.Text & "',email='" & Email.Text & "',bloodgroup='" & BloodGroup.Text & "',department='" & Department.Text & "',designation='" & Designation.Text & "',dateofjoining='" & DateOfJoining.Text & "',salary='" & Salary.Text & "',basicworkingtime='" & BasicWorkingTime.Text & "' where employeeid='" & EmployeeID.Text & "'"

            cmd = New oledbCommand(cb)

            cmd.Connection = con

            If MessageBox.Show("Are you sure want to update the record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                cmd.ExecuteReader()
                MessageBox.Show("Successfully updated", "Employee Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Filldepartment()
                FillDesignation()

                EmployeeID.Focus()
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

    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        Try

            If MsgBox("Do you really want to delete this record?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                delete_records()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub delete_records()


        Try
           
            con = New oledbConnection(cs)

            con.Open()
            Dim ct As String = "select EmployeeID from employeeattendance where EmployeeID=@find"


            cmd = New oledbCommand(ct)

            cmd.Connection = con
            cmd.Parameters.Add(New oledbParameter("@find", oledbType.Varchar, 30, "EmployeeID"))


            cmd.Parameters("@find").Value = EmployeeID.Text


            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Reset()
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
          
            con = New OleDbConnection(cs)

            con.Open()
            Dim ct2 As String = "select EmployeeID from employeepayment where EmployeeID=@find"


            cmd = New oledbCommand(ct2)

            cmd.Connection = con
            cmd.Parameters.Add(New oledbParameter("@find", oledbType.Varchar, 30, "EmployeeID"))


            cmd.Parameters("@find").Value = EmployeeID.Text


            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Reset()



                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If

            con = New OleDbConnection(cs)

            con.Open()
            Dim ct1 As String = "select EmployeeID from advanceentry where EmployeeID=@find"


            cmd = New OleDbCommand(ct1)

            cmd.Connection = con
            cmd.Parameters.Add(New OleDbParameter("@find", OleDbType.VarChar, 30, "EmployeeID"))


            cmd.Parameters("@find").Value = EmployeeID.Text


            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Reset()



                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If

            Dim RowsAffected As Integer = 0

            con = New OleDbConnection(cs)

            con.Open()


            Dim cq As String = "delete from employeeregistration where EmployeeID=@DELETE1;"


            cmd = New OleDbCommand(cq)

            cmd.Connection = con

            cmd.Parameters.Add(New OleDbParameter("@DELETE1", OleDbType.VarChar, 30, "EmployeeID"))


            cmd.Parameters("@DELETE1").Value = Trim(EmployeeID.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then

                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Filldepartment()
                FillDesignation()
                Reset()
                EmployeeID.Focus()
                Update_Record.Enabled = False
                Delete.Enabled = False
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

    Private Sub Department_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Department.TextChanged
        Dim selectionStart As Integer = Me.Department.SelectionStart

        Me.Department.Text = Me.Department.Text.ToUpper()
        Me.Department.SelectionStart = selectionStart
    End Sub

    Private Sub Designation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Designation.TextChanged
        Dim selectionStart As Integer = Me.Designation.SelectionStart

        Me.Designation.Text = Me.Designation.Text.ToUpper()
        Me.Designation.SelectionStart = selectionStart
    End Sub


    Private Sub EmployeeName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EmployeeName.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'space accepted
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then

            e.Handled = False
        End If
    End Sub

    Private Sub Email_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Email.Validating
        Dim rEMail As New System.Text.RegularExpressions.Regex("^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
        If Email.Text.Length > 0 Then
            If Not rEMail.IsMatch(Email.Text) Then
                MessageBox.Show("invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Email.SelectAll()
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub EmployeeID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim selectionStart As Integer = Me.EmployeeID.SelectionStart

        Me.EmployeeID.Text = Me.EmployeeID.Text.ToUpper()
        Me.EmployeeID.SelectionStart = selectionStart
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmEmployeesRecord1.DataGridView1.DataSource = Nothing
        frmEmployeesRecord1.EmployeeName.Text = ""
        frmEmployeesRecord1.DataGridView2.DataSource = Nothing
        frmEmployeesRecord1.DateFrom.value = Today
        frmEmployeesRecord1.DateTo.value = Today
        frmEmployeesRecord1.DataGridView3.DataSource = Nothing
        frmEmployeesRecord1.ShowDialog()
    End Sub
End Class