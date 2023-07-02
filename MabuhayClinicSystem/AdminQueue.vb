Imports System.Data.SqlClient
Public Class AdminQue
    '!COMMENT: PRIVATE VARIABLES
    Dim det As Date = CDate(Date.Now.ToShortDateString().ToString())
    Dim allQueueRecords As Integer = Nothing
    'END!
    '*****************************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        loadQueBetweenDates()
        countTotalQue()
        txtTotal.Text = "0"
    End Sub
    '
    Private Sub btnDelet_Click(sender As Object, e As EventArgs) Handles btnDelet.Click
        If rdbtnSelectedDet.Checked = True Then
            Dim dtp1 As Date = CDate(dtpExpFrom.Text)
            Dim dtp2 As Date = CDate(dtpExpTo.Text)
            Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to delete records from [" & dtp1.ToString & "] to [" & dtp2.ToString() & "]." & vbCrLf & "Click YES to confirm otherwise click NO.", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.Yes Then
                Dim InputValue As String = Nothing
                'Prompt the customer to type numbers
                InputValue = InputBox("To confirm that this is not a mistake, please type in numbers 1-9.", "Confirmation...")
                If IsNumeric(InputValue) Then
                    If InputValue = "123456789" Then
                        deleteQue()
                        loadQueToday()
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
            'Radio button All is clicked
        ElseIf rbtnAll.Checked = True Then
            MessageBox.Show("Warning! You are going to delete all queue records and reset the queue number to 0.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim answer1 As DialogResult = MessageBox.Show("Please confirm if you would want to delete all records of Queue." & vbCrLf & "Click YES to confirm otherwise click NO.", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer1 = Windows.Forms.DialogResult.Yes Then
                Dim InputValue1 As String = Nothing
                'Prompt the customer to type numbers
                InputValue1 = InputBox("To confirm that this is not a mistake, please type in numbers 1-9.", "Confirmation...")
                If IsNumeric(InputValue1) Then
                    If InputValue1 = "123456789" Then
                        deleteAllQueu()
                        loadQueToday()
                        MsgBox("You have successfully deleted a total of " & allQueueRecords.ToString & " queue records.")
                        allQueueRecords = Nothing
                    Else
                        MsgBox("It seems like this is a mistake. Deletion aborted!")
                        Exit Sub
                    End If
                Else
                    MsgBox("It seems like this is a mistake. Deletion aborted!")
                    Exit Sub
                End If
            End If
        End If
       
    End Sub
    'END!
    '*****************************************************************************************
    '!COMMENT: EVENTS
    '
    Private Sub AdminQueue_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    '
    Private Sub AdminQueue_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadManageClinic()
    End Sub
    'END!
    '*****************************************************************************************
    '!COMMENT: METHODS
    '
    Public Sub loadQueToday()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select QNUM, QDATE,TOKENNUMBER as TOKEN, FIRSTNAME,MIDDLENAME,LASTNAME,BARANGAY,MUNICIPALITY,PROVINCE,GENDER from tblQue " & _
" Where QDATE = @det order by TOKEN ASC ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvQueue.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub loadQueBetweenDates()
        Dim dtp1 As Date = CDate(dtpExpFrom.Text)
        Dim dtp2 As Date = CDate(dtpExpTo.Text)
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select QNUM, QDATE,TOKENNUMBER as TOKEN, FIRSTNAME,MIDDLENAME,LASTNAME,BARANGAY,MUNICIPALITY,PROVINCE,GENDER from tblQue " & _
" Where QDATE between @det1 and @det2 order by QDATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", dtp1)
            cmd.Parameters.AddWithValue("@det2", dtp2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvQueue.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub deleteQue()
        Dim dtp1 As Date = CDate(dtpExpFrom.Text)
        Dim dtp2 As Date = CDate(dtpExpTo.Text)
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Delete from tblQue Where QDATE between @det1 and @det2;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", dtp1)
            cmd.Parameters.AddWithValue("@det2", dtp2)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Successfully Deleted!")
        End Using
    End Sub
    '
    Public Sub deleteAllQueu()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Delete from tblQue;", db.pubSqlCon)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Successfully Deleted!")
        End Using
        '
        Try
            Using cmd1 As New SqlCommand("DBCC CHECKIDENT ('tblQue' ,RESEED,0);", db.pubSqlCon)
                db.pubSqlCon.Open()
                cmd1.ExecuteNonQuery()
                cmd1.Dispose()
                db.pubSqlCon.Close()
            End Using
        Catch
            MsgBox("Unable to reset the Queue number to 0.")
        Finally
            db.pubSqlCon.Close()
        End Try
    End Sub
    '
    Public Sub countAllQue()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select Count(QNUM) as total from tblQue;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                allQueueRecords = dt.Rows(0).Item("total")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub countTotalQue()
        Dim dtp1 As Date = CDate(dtpExpFrom.Text)
        Dim dtp2 As Date = CDate(dtpExpTo.Text)
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select Count(QNUM) as total from tblQue " & _
" Where QDATE between @det1 and @det2;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", dtp1)
            cmd.Parameters.AddWithValue("@det2", dtp2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtTotal.Text = dt.Rows(0).Item("total")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub countTotalQueToday()
        Dim dtp1 As Date = CDate(dtpExpFrom.Text)
        Dim dtp2 As Date = CDate(dtpExpTo.Text)
        Dim result As String = Nothing
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select Count(QNUM) as total from tblQue " & _
" Where QDATE =@det;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                result = dt.Rows(0).Item("total")
                If String.IsNullOrEmpty(result) Then
                    txtTotal.Text = "0"
                Else
                    txtTotal.Text = result
                End If
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'END!
    '*****************************************************************************************
End Class