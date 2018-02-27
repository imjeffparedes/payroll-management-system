Imports System.Data.oledb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmAttendanceReport
    Dim rdr As oledbDataReader = Nothing
    Dim dtable As DataTable
    Dim con As oledbConnection = Nothing
    Dim adp As oledbDataAdapter
    Dim ds As DataSet
    Dim cmd As oledbCommand = Nothing
    Dim dt As New DataTable
    Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\PayrollManagerDB.accdb;Persist Security Info=False;"
    Private Sub frmAttendanceReport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        frmMainMenu.Show()
    End Sub

    Private Sub frmAttendanceReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button4.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptAttendance() 'The report you created.
            Dim myConnection As oledbConnection
            Dim MyCommand As New oledbCommand()
            Dim myDA As New oledbDataAdapter()
            Dim myDS As New PayrollManagerDBDataSet 'The DataSet you created.
            myConnection = New OleDbConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "select EmployeeRegistration.EmployeeID,EmployeeName from EmployeeAttendance,EmployeeRegistration where EmployeeRegistration.EmployeeID=EmployeeAttendance.EmployeeID and WorkingDate between #" & DateFrom.Text & "# And #" & DateTo.Text & "#  and Status = 'P'  order by EmployeeName "
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "EmployeeAttendance")
            myDA.Fill(myDS, "EmployeeRegistration")
            rpt.SetDataSource(myDS)
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("select count(status) from employeeattendance where WorkingDate between #" & DateFrom.Text & "# And #" & DateTo.Text & "#   group by EmployeeID ", con)
            rdr = cmd.ExecuteReader()

            If (rdr.Read()) Then

                Label1.Text = rdr.GetInt32(0).ToString()
            End If
            If ((rdr Is Nothing)) Then

                rdr.Close()
            End If
            If (con.State = ConnectionState.Open) Then

                con.Close()
            End If
            rpt.SetParameterValue("variable", DateFrom.Value)
            rpt.SetParameterValue("variable1", DateTo.Value)
            rpt.SetParameterValue("variable2", Label1.Text)
            CrystalReportViewer1.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button5.Click
        CrystalReportViewer1.ReportSource = Nothing
        DateFrom.value = Today
        DateTo.value = Today
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class