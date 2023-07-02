Imports System.Data.SqlClient
Public Class UserActivity
    '!COMMENT: PRIVATE VARIABLES
    Dim totalRcrd As Integer = Nothing
    'END!
    '**********************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnDelet_Click(sender As Object, e As EventArgs) Handles btnDelet.Click
        txtSearch.Text = ""
        deleteByDateRange()
    End Sub
    '
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        txtSearch.Text = ""
        searchByDaterange()
    End Sub
    'END!
    '**********************************************************************************
    '!COMMENT: EVENTS
    Private Sub UserActivity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadUserActivityToday()
    End Sub
    '
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = "" Then
            loadUserActivityToday()
        Else
            searchByLastname()
        End If
    End Sub
    '
    Private Sub UserActivity_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.returntoAdminDashboard()
    End Sub
    'END!
    '**********************************************************************************
    '!COMMENT: METHODS
    Public Sub loadUserActivityToday()
        Dim det As Date = CDate(Date.Now.ToShortDateString())
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select UserActivityNo, UserID, FULLNAME,UA_DATE,UA_TIME,INTERFACE,BUTTON,ACTION from tblUserActivity where UA_DATE=@today order by UserActivityNo ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@today", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                dgvUserActivity.DataSource = dt
            Else
                dgvUserActivity.DataSource = dt
                dgvUserActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End If
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchByLastname()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select UserActivityNo, UserID, FULLNAME,UA_DATE,UA_TIME,INTERFACE,BUTTON,ACTION from tblUserActivity where FULLNAME like '' +@fname+ '%' Order by UA_DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@fname", txtSearch.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvUserActivity.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchByDaterange()
        Dim det1 As Date = CDate(SearchDtp1.Value.ToShortDateString())
        Dim det2 As Date = CDate(SearchDtp2.Value.ToShortDateString())
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select UserActivityNo, UserID, FULLNAME,UA_DATE,UA_TIME,INTERFACE,BUTTON,ACTION from tblUserActivity where UA_DATE between @det1 and @det2 Order by UA_DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", det1)
            cmd.Parameters.AddWithValue("@det2", det2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvUserActivity.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub deleteByDateRange()
        Dim answer = MessageBox.Show("Warning! you are now going to delete all User Activity records in your database from [" & DeleteDtp1.Value.ToShortDateString() & "] to [" & DeleteDtp2.Value.ToShortDateString() & "]." & vbCrLf & vbCrLf & "Any changes cannot be undone." & vbCrLf & vbCrLf & "Please confirm if you still want to continue.", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If answer = Windows.Forms.DialogResult.Yes Then
            'Prompt the customer to type numbers
            Dim InputValue As String = Nothing
            InputValue = InputBox("To confirm that this is not a mistake, please type in numbers 1-9.", "Confirmation...")
            If IsNumeric(InputValue) Then
                If InputValue = "123456789" Then
                    totalRecords()
                    commandDelete()
                    MsgBox("You have deleted a total of " & totalRcrd.ToString() & " records.")
                    loadUserActivityToday()
                    totalRcrd = Nothing
                Else
                    MsgBox("It seems like this is a mistake. Deletion aborted!")
                    Exit Sub
                End If
            Else
                MsgBox("It seems like this is a mistake. Deletion aborted!")
                Exit Sub
            End If
        Else
            Exit Sub
        End If
    End Sub
    '
    Public Sub commandDelete()
        Dim det1 As Date = CDate(DeleteDtp1.Value.ToShortDateString())
        Dim det2 As Date = CDate(DeleteDtp2.Value.ToShortDateString())
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand(" Begin transaction; " & _
                                    " Delete tblUserActivity where UA_DATE between @det1 and @det2; " & _
                                    " Commit; ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", det1)
            cmd.Parameters.AddWithValue("@det2", det2)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Delete successful!")
        End Using
    End Sub
    '
    Public Sub totalRecords()
        Dim det1 As Date = CDate(DeleteDtp1.Value.ToShortDateString())
        Dim det2 As Date = CDate(DeleteDtp2.Value.ToShortDateString())
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand(" Select Count(UserActivityNo) as total from tblUserActivity  where UA_DATE between @det1 and @det2;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", det1)
            cmd.Parameters.AddWithValue("@det2", det2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                totalRcrd = dt.Rows(0).Item("total")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'END!
    '**********************************************************************************
End Class