Imports System.Data.SqlClient
Public Class ViewDiagnosis
    '!COMMENT: PRIVATE VARIABLES
    Dim det As Date = CDate(Date.Now.ToShortDateString)
    '
    Dim intrfce As String = Nothing
    Dim btn As String = Nothing
    Dim actn As String = Nothing
    'END!
    '*********************************************************************************************************
    '!COMMENT: BUTTONS
    'i. ENTER
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        captureUAsearchByDate()
        searchBetweendates()
    End Sub
    'ii. PRINT
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        captureUAprint()
    End Sub
    'END!
    '*********************************************************************************************************
    '!COMMENT: EVENTS
    'i. Form Closing
    Private Sub ViewDiagnosis_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DoctorDashboard.loadAddDiagnosis()
    End Sub
    'ii. View Diagnosis
    Private Sub ViewDiagnosis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureUAloadFrm()
        loaddiagnosis()
    End Sub
    'iii. Lastname text change
    Private Sub txtLastname_TextChanged(sender As Object, e As EventArgs) Handles txtLastname.TextChanged
        If txtLastname.Text <> "" Then
            searchByLastname()
        Else
            loaddiagnosis()
        End If
    End Sub
    'Key press
    Private Sub txtLastname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastname.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> vbBack AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub
    'END!
    '*********************************************************************************************************
    '!COMMENT: METHODS
    'i. Load diagnosis
    Public Sub loaddiagnosis()
        Dim result As Date = Nothing
        Dim lastweek As Date = Nothing
        'Count the number of days and subtract by 1 until 7
        For count As Integer = 1 To 7
            result = det.AddDays(-count)
            lastweek = result.ToShortDateString.ToString()
        Next
        'Retrieve diagnosis records of for the past 7 days only
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select td.ConsultationID,td.DiagnosisID,td.D_DATE,CONCAT(tp.FIRSTNAME,' ',tp.MIDDLENAME,' ',tp.LASTNAME) as PATIENT, " & _
                                    " tp.AGE,tp.SEX,td.DiagnosisID,td.DIAGNOSIS,td.TREATMENT from tblDiagnosis as td " & _
                                    " Inner join tblVitalSigns as tv On tv.VitalSignNo = td.ConsultationID " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID Where td.D_DATE >=@lastweek And  td.D_DATE <= @dettoday Order by td.D_DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lastweek", lastweek)
            cmd.Parameters.AddWithValue("@dettoday", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvDiagnosis.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'ii. Search Diagnosis by Lastname
    Public Sub searchByLastname()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select td.ConsultationID,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', LASTNAME) as PATIENT, td.DiagnosisID ,td.D_DATE, td.DIAGNOSIS, td.TREATMENT from tblDiagnosis as td " & _
        " Inner Join tblVitalSigns as tv On td.ConsultationID = tv.VitalSignNo " & _
        " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
        " Where CONCAT(tp.LASTNAME, ' ', tp.FIRSTNAME, ' ', tp.MIDDLENAME) like '' +@lastname+ '%'  Order by td.D_DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lastname", txtLastname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvDiagnosis.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            'capture user activity
            captureUAsearch()
        End Using
    End Sub
    'iii. Search by date range
    Public Sub searchBetweendates()
        Dim det1 As Date = CDate(dtpDate1.Text)
        Dim det2 As Date = CDate(dtpDate2.Text)
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select td.ConsultationID,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', LASTNAME) as PATIENT, td.DiagnosisID ,td.D_DATE, td.DIAGNOSIS, td.TREATMENT from tblDiagnosis as td " & _
        " Inner Join tblVitalSigns as tv On td.ConsultationID = tv.VitalSignNo " & _
        " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
        " Where td.D_DATE >=@det1 And td.D_DATE <=@det2 Order by td.D_DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", det1)
            cmd.Parameters.AddWithValue("@det2", det2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvDiagnosis.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    Public Sub UserActivity(ByVal intrfce As String, ByVal btn As String, ByVal actn As String)
        Dim det As Date = CDate(Date.Now.ToShortDateString())
        Dim tym As TimeSpan = Date.Now.TimeOfDay
        '
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Insert into tblUserActivity (UserID,FULLNAME,UA_DATE,UA_TIME,INTERFACE,BUTTON,ACTION) values (@userid,@fullname,@det,@tym,@interface,@button,@action);", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = loginUserid
            cmd.Parameters.Add("@fullname", SqlDbType.Text).Value = doctorFname & " " & doctorMname & " " & doctorLname
            cmd.Parameters.Add("@det", SqlDbType.Date).Value = det
            cmd.Parameters.Add("@tym", SqlDbType.Time).Value = tym
            cmd.Parameters.Add("@interface", SqlDbType.Text).Value = intrfce
            cmd.Parameters.Add("@button", SqlDbType.Text).Value = btn
            cmd.Parameters.Add("@action", SqlDbType.Text).Value = actn
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
        End Using
    End Sub
    'END!
    '************************************************************************************************
    '!COMMENT:USER ACTIVITY METHODS
    'i. Load form
    Public Sub captureUAloadFrm()
        intrfce = "View Diagnosis"
        btn = "N/A"
        actn = "Open"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAsearch()
        intrfce = "View Diagnosis"
        btn = "N/A"
        actn = "Search for [" & txtLastname.Text & "]."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAsearchByDate()
        intrfce = "View Diagnosis"
        btn = "Enter"
        actn = "Search from " & dtpDate1.Value.ToShortDateString() & " to " & dtpDate2.Value.ToShortDateString() & "."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAprint()
        intrfce = "View Diagnosis"
        btn = "Print"
        actn = "Click"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!
    '*********************************************************************************************************

End Class