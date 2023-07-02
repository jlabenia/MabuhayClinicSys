Imports System.Data.SqlClient
Public Class ViewSurgery
    '!COMMENT: PRIVATE VARIABLES
    Dim intrfce As String = Nothing
    Dim btn As String = Nothing
    Dim actn As String = Nothing
    'END!
    '**********************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        searchbyDateRange()
    End Sub
    'END!
    '**********************************************************************************
    '!COMMENT: EVENTS
    'i. Form load
    Private Sub ViewSurgery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureUAloadFrm()
        loadSurgery()
    End Sub
    'ii. Text changed
    Private Sub txtLastname_TextChanged(sender As Object, e As EventArgs) Handles txtLastname.TextChanged
        If txtLastname.Text <> "" Then
            searchByLastname()
        Else
            loadSurgery()
        End If
    End Sub
    'iii. Keypress
    Private Sub txtLastname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastname.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> vbBack And e.KeyChar <> "" Then
            e.Handled = True
        End If
    End Sub
    'iv. Form closing
    Private Sub ViewSurgery_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DoctorDashboard.loadAddsurgery()
    End Sub
    'END!
    '**********************************************************************************
    '!COMMENT: METHODS
    'i. Load surgery info
    Public Sub loadSurgery()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select top 100  ts.VitalSignsID,ts.Surgeryno, ts.DATEOFSURGERY as DATE, CONCAT(tp.FIRSTNAME,' ',tp.MIDDLENAME,' ', tp.LASTNAME) as PATIENT,ts.ROOM,ts.TYPEOFSURGERY,ts.OPRTN_STARTED,ts.OPRTN_ENDED,ts.PRE_OPRTN_DIAGNOSIS,ts.POST_OPRTN_DIAGNOSIS,ts.OPRTN_PERFORMED,ts.PRCDURE_IN_DETAIL,ts.REMARKS, CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME,' ', tdoc.LASTNAME) as DOCTOR from tblSurgery as ts " & _
" Inner join tblDoctor as tdoc On ts.DoctorID = tdoc.DoctorID " & _
" Inner Join tblVitalSigns as tv On ts.VitalSignsID = tv.VitalSignNo " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID " & _
" Order by ts.Surgeryno DESC;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvSurgery.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    'ii. Search by lastname
    Public Sub searchByLastname()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select top 100  ts.VitalSignsID,ts.Surgeryno, ts.DATEOFSURGERY as DATE, CONCAT(tp.FIRSTNAME,' ',tp.MIDDLENAME,' ', tp.LASTNAME) as PATIENT,ts.ROOM,ts.TYPEOFSURGERY,ts.OPRTN_STARTED,ts.OPRTN_ENDED,ts.PRE_OPRTN_DIAGNOSIS,ts.POST_OPRTN_DIAGNOSIS,ts.OPRTN_PERFORMED,ts.PRCDURE_IN_DETAIL,ts.REMARKS, CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME,' ', tdoc.LASTNAME) as DOCTOR from tblSurgery as ts " & _
" Inner join tblDoctor as tdoc On ts.DoctorID = tdoc.DoctorID " & _
" Inner Join tblVitalSigns as tv On ts.VitalSignsID = tv.VitalSignNo " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID " & _
" where CONCAT(tp.LASTNAME, ' ',tp.FIRSTNAME,' ',tp.MIDDLENAME) like '' +@lname+ '%'  Order by DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtLastname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvSurgery.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'iii. Search by date range
    Public Sub searchbyDateRange()
        Dim det1 As Date = CDate(dtpDate1.Text)
        Dim det2 As Date = CDate(dtpDate2.Text)
        '
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ts.VitalSignsID,ts.Surgeryno, ts.DATEOFSURGERY as DATE, CONCAT(tp.FIRSTNAME,' ',tp.MIDDLENAME,' ', tp.LASTNAME) as PATIENT,ts.ROOM,ts.TYPEOFSURGERY,ts.OPRTN_STARTED,ts.OPRTN_ENDED,ts.PRE_OPRTN_DIAGNOSIS,ts.POST_OPRTN_DIAGNOSIS,ts.OPRTN_PERFORMED,ts.PRCDURE_IN_DETAIL,ts.REMARKS, CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME,' ', tdoc.LASTNAME) as DOCTOR from tblSurgery as ts " & _
" Inner join tblDoctor as tdoc On ts.DoctorID = tdoc.DoctorID " & _
" Inner Join tblVitalSigns as tv On ts.VitalSignsID = tv.VitalSignNo " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID " & _
" where ts.DATEOFSURGERY =@det1 And ts.DATEOFSURGERY =@det2 Order by DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1 ", det1)
            cmd.Parameters.AddWithValue("@det2 ", det2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvSurgery.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
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
        intrfce = "View surgery"
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
    '**********************************************************************************
End Class