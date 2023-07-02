Imports System.Data.SqlClient
Public Class AdminAppointment
    '!COMMENT: PRIVATE VARIABLES
    Dim det As Date = CDate(Date.Now.ToShortDateString.ToString())
    Dim allAppontmentRecords As Integer = Nothing

    'END!
    '********************************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnDelet_Click(sender As Object, e As EventArgs) Handles btnDelet.Click
        If rdbtnSelectedDet.Checked = True Then
            Dim dtp1 As Date = CDate(dtpExpFrom.Text)
            Dim dtp2 As Date = CDate(dtpExpTo.Text)
            Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to delete records from [" & dtp1.ToString & "] to [" & dtp2.ToString() & "]." & vbCrLf & "Click YES to confirm otherwise click NO.", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.Yes Then
                Dim Inputvalue As String = Nothing
                Inputvalue = InputBox("To confirm that this is not a mistake, please type in numbers 1-9.", "Confirmation...")
                If IsNumeric(Inputvalue) Then
                    If Inputvalue = "123456789" Then
                        deleteAppointment()
                        loadAppointmentToday()
                        txtTotal.Text = 0
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
        ElseIf rbtnAll.Checked = True Then
            MessageBox.Show("Warning! You are going to delete all appointment records and reset the appointment number to 0.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim answer1 As DialogResult = MessageBox.Show("Please confirm if you would want to delete all records of appointment." & vbCrLf & "Click YES to confirm otherwise click NO.", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer1 = Windows.Forms.DialogResult.Yes Then
                Dim InputValue1 As String = Nothing
                'Prompt the customer to type numbers
                InputValue1 = InputBox("To confirm that this is not a mistake, please type in numbers 1-9.", "Confirmation...")
                If IsNumeric(InputValue1) Then
                    If InputValue1 = "123456789" Then
                        deleteAllAppointment()
                        MsgBox("You have successfully deleted a total of " & allAppontmentRecords.ToString & " appointment records.")
                        allAppontmentRecords = Nothing
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
    '
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        searchBetweenDates()
        totalAppointmentBetweenDates()
    End Sub
    'END!
    '********************************************************************************************
    '!COMMENT: EVENTS
    Private Sub AdminAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadAppointmentToday()
        totalAppointmentToday()
    End Sub
    '
    Private Sub AdminAppointment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadManageClinic()
    End Sub
    '
    'END!
    '********************************************************************************************
    '!COMMENT: METHODS
    '
    Public Sub loadAppointmentToday()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select AppointmentID, A_DATE, TOKEN, CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENTNAME, tp.AGE,tp.SEX,CONCAT(tp.BARANGAY, ' ', tp.MUNICIPALITY, ' ', tp.PROVINCE) as ADDRESS, ta.NOTE  from tblAppointment ta " & _
" Inner Join tblPerson as tp On ta.PersonID = tp.PersonID " & _
" Where A_DATE=@det order by TOKEN ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvAppointment.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchBetweenDates()
        Dim dtp1 As Date = CDate(dtpExpFrom.Text)
        Dim dtp2 As Date = CDate(dtpExpTo.Text)
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select AppointmentID, A_DATE, TOKEN, CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENTNAME, tp.AGE,tp.SEX,CONCAT(tp.BARANGAY, ' ', tp.MUNICIPALITY, ' ', tp.PROVINCE) as ADDRESS, ta.NOTE  from tblAppointment ta " & _
" Inner Join tblPerson as tp On ta.PersonID = tp.PersonID " & _
" Where A_DATE between @det1 and @det2 order by A_DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", dtp1)
            cmd.Parameters.AddWithValue("@det2", dtp2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvAppointment.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub totalAppointmentToday()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select Count(AppointmentID) as total from tblAppointment " & _
" Where A_DATE=@det group by A_DATE;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
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
    Public Sub totalAppointmentBetweenDates()
        Dim dtp1 As Date = CDate(dtpExpFrom.Text)
        Dim dtp2 As Date = CDate(dtpExpTo.Text)
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select Count(AppointmentID) as total from tblAppointment " & _
" Where A_DATE between @det1 and @det2;", db.pubSqlCon)
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
            dt.Dispose()
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub deleteAppointment()
        Dim dtp1 As Date = CDate(dtpExpFrom.Text)
        Dim dtp2 As Date = CDate(dtpExpTo.Text)
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Delete from tblAppointment Where A_DATE between @det1 and @det2;", db.pubSqlCon)
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
    Public Sub deleteAllAppointment()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Delete from tblAppointment;", db.pubSqlCon)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Successfully Deleted!")
        End Using
        '
        Try
            Using cmd1 As New SqlCommand("DBCC CHECKIDENT ('tblAppointment' ,RESEED,0);", db.pubSqlCon)
                db.pubSqlCon.Open()
                cmd1.ExecuteNonQuery()
                cmd1.Dispose()
                db.pubSqlCon.Close()
            End Using
        Catch
            MsgBox("Unable to reset the appointment number to 0.")
        Finally
            db.pubSqlCon.Close()
        End Try
    End Sub
    '
    Public Sub countAllAppRecord()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select Count(AppointmentID) as total from tblQue;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                allAppontmentRecords = dt.Rows(0).Item("total")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
    End Sub
    'END!
    '********************************************************************************************
End Class