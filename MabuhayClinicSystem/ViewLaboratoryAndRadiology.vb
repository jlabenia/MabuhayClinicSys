Imports System.Data.SqlClient
Public Class ViewLaboratoryAndRadiology
    '!COMMENT: PRIVATE VARIABLES
    Dim intrfce As String = Nothing
    Dim btn As String = Nothing
    Dim actn As String = Nothing
    'END!
    '*************************************************************************************************
    '!COMMENT: BUTTONS
    'END!
    '*************************************************************************************************
    '!COMMENT:EVENTS
    'i. Load form
    Private Sub ViewLaboratoryAndRadiology_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureUAloadFrm()
        loadTestResults()
    End Sub
    'ii. Text change (consultation id)
    Private Sub txtConsultationId_TextChanged(sender As Object, e As EventArgs) Handles txtConsultationId.TextChanged
        txtlastname.Text = ""
        If txtConsultationId.Text <> "" Then
            searchByConsltationID()
        Else
            loadTestResults()
        End If
    End Sub
    'iii. Text change (Lastname)
    Private Sub txtlastname_TextChanged(sender As Object, e As EventArgs) Handles txtlastname.TextChanged
        txtConsultationId.Text = ""
        If txtlastname.Text <> "" Then
            searchByLastname()
        Else
            loadTestResults()
        End If
    End Sub
    'iv. Key press (consultation id)
    Private Sub txtConsultationId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConsultationId.KeyPress
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    'v. Key press (Lastname)
    Private Sub txtlastname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtlastname.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> vbBack And e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub
    'vi. Form closing
    Private Sub ViewLaboratoryAndRadiology_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DoctorDashboard.returnToDashboard()
    End Sub
    'END!
    '*************************************************************************************************
    '!COMMENT:METHODS
    'i. Load test results
    Public Sub loadTestResults()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("SELECT Top 50 ttr.TestResultNo,ttr.ConsultationID,ttr.DATE as DATE_TEST_TAKEN,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT,ttr.TYPEOFLABEXAM,ttr.RESULT, CONCAT(tdoc.FIRSTNAME, ' ',tdoc.MIDDLENAME, ' ',tdoc.LASTNAME) as DOCTOR  from tblTestResult as ttr " & _
" Inner Join tblConsulatation as tc On ttr.ConsultationID = tc.ConsultationID " & _
" Inner Join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner join tblVitalSigns AS tv On tv.VitalSignNo = tc.ConsultationID " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID Order by ttr.ConsultationID Desc;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvLabAndRad.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    'ii. Search by Consultation id
    Public Sub searchByConsltationID()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("SELECT ttr.TestResultNo,ttr.ConsultationID,ttr.DATE as DATE_TEST_TAKEN,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT,ttr.TYPEOFLABEXAM,ttr.RESULT, CONCAT(tdoc.FIRSTNAME, ' ',tdoc.MIDDLENAME, ' ',tdoc.LASTNAME) as DOCTOR  from tblTestResult as ttr " & _
" Inner Join tblConsulatation as tc On ttr.ConsultationID = tc.ConsultationID " & _
" Inner Join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner join tblVitalSigns AS tv On tv.VitalSignNo = tc.ConsultationID " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID where ttr.ConsultationID=@consultationid Order by DATE_TEST_TAKEN Desc;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@consultationid", txtConsultationId.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvLabAndRad.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'iii. Search by Lastname
    Public Sub searchByLastname()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("SELECT ttr.TestResultNo,ttr.ConsultationID,ttr.DATE as DATE_TEST_TAKEN,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT,ttr.TYPEOFLABEXAM,ttr.RESULT, CONCAT(tdoc.FIRSTNAME, ' ',tdoc.MIDDLENAME, ' ',tdoc.LASTNAME) as DOCTOR  from tblTestResult as ttr " & _
" Inner Join tblConsulatation as tc On ttr.ConsultationID = tc.ConsultationID " & _
" Inner Join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner join tblVitalSigns AS tv On tv.VitalSignNo = tc.ConsultationID " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID " & _
" Where CONCAT(tp.LASTNAME, ' ',tp.FIRSTNAME, ' ',tp.MIDDLENAME) like '' +@lastname+ '%' Order by DATE_TEST_TAKEN Desc;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lastname", txtlastname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvLabAndRad.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub UserActivity(ByVal intrfce As String, ByVal btn As String, ByVal actn As String)
        'Dim det As Date = CDate(Date.Now.ToShortDateString())
        'Dim tym As TimeSpan = Date.Now.TimeOfDay
        ''
        'Dim db As New KonekDB
        'db.FETCHDBINFO()
        'Using cmd As New SqlCommand("Insert into tblUserActivity (UserID,FULLNAME,UA_DATE,UA_TIME,INTERFACE,BUTTON,ACTION) values (@userid,@fullname,@det,@tym,@interface,@button,@action);", db.pubSqlCon)
        '    cmd.Parameters.Clear()
        '    cmd.Parameters.Add("@userid", SqlDbType.Int).Value = loginUserid
        '    cmd.Parameters.Add("@fullname", SqlDbType.Text).Value = doctorFname & " " & doctorMname & " " & doctorLname
        '    cmd.Parameters.Add("@det", SqlDbType.Date).Value = det
        '    cmd.Parameters.Add("@tym", SqlDbType.Time).Value = tym
        '    cmd.Parameters.Add("@interface", SqlDbType.Text).Value = intrfce
        '    cmd.Parameters.Add("@button", SqlDbType.Text).Value = btn
        '    cmd.Parameters.Add("@action", SqlDbType.Text).Value = actn
        '    cmd.ExecuteNonQuery()
        '    db.pubSqlCon.Close()
        'End Using
    End Sub
    'END!
    '************************************************************************************************
    '!COMMENT:USER ACTIVITY METHODS
    'i. Load form
    Public Sub captureUAloadFrm()
        intrfce = "View laboratory and radiology"
        btn = "N/A"
        actn = "Open"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!
    '*************************************************************************************************
End Class