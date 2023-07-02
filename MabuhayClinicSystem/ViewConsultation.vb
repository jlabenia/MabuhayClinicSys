Imports System.Data.SqlClient
Public Class ViewConsultation
    '!COMMENT: VARIABLES
    'END!
    '*************************************************************************************
    '!COMMENT: BUTTONs
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        SearchBetweenDates()
    End Sub '//green code
    'END!
    '*************************************************************************************
    '!COMMENT: EVENTS
    'i. Form closing
    Private Sub ViewConsultation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DoctorDashboard.loadAddConsultation()
    End Sub '//green code
    'ii. Load Consultation
    Private Sub ViewConsultation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadConsultation()
    End Sub '//green code
    'iii. Text changed
    Private Sub txtFullname_TextChanged(sender As Object, e As EventArgs) Handles txtFullname.TextChanged
        If txtFullname.Text <> "" Then
            SearchByFullname()
        Else
            loadConsultation()
        End If
    End Sub '//green code
    'iv. Keypress (Allow letters only)
    Private Sub txtFullname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFullname.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> vbBack AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub '//green code
    'END!
    '*************************************************************************************
    '!COMMENT: METHODS
    'i. Load consultation records range from past 7 days
    Public Sub loadConsultation()
        'Get date last week
        Dim det_tody As Date = CDate(Date.Now.ToShortDateString)
        Dim det_lastweek As Date = Nothing
        For countDay As Integer = 1 To 7
            'Count the days backward by subtracting current day by 1 until 7
            det_lastweek = det_tody.AddDays(-countDay).ToShortDateString
        Next
        '
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tc.ConsultationID, tc.C_DATE, CONCAT(tp.FIRSTNAME,' ', tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tc.CHIEFCOMPLAIN,tc.PLANORTREATMENT,CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME, ' ',tdoc.LASTNAME) AS DOCTOR from tblConsulatation as tc " & _
" Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
" Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID Where tc.C_DATE >= @lastweek  And tc.C_DATE <= @detnow  Order by tc.C_DATE DESC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lastweek", det_lastweek)
            cmd.Parameters.AddWithValue("@detnow ", det_tody)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvViewConsultation.DataSource = dt
            da.Dispose()
            db.pubSqlCon.Close()
        End Using
    End Sub '//green code
    'ii. Search between two date range
    Public Sub SearchBetweenDates()
        Dim db As New KonekDB
        Dim det1 As Date = CDate(dtpDate1.Text)
        Dim det2 As Date = CDate(dtpDate2.Text)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tc.ConsultationID, tc.C_DATE, CONCAT(tp.FIRSTNAME,' ', tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tc.CHIEFCOMPLAIN,tc.PLANORTREATMENT,CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME, ' ',tdoc.LASTNAME) AS DOCTOR from tblConsulatation as tc " & _
" Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
" Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID Where tc.C_DATE >= @dtp1 And tc.C_DATE <=@dtp2  Order by tc.C_DATE ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@dtp1", det1)
            cmd.Parameters.AddWithValue("@dtp2", det2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvViewConsultation.DataSource = dt
            da.Dispose()
            db.pubSqlCon.Close()
        End Using
    End Sub '//green code
    'iii. Search by fullname
    Public Sub SearchByFullname()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tc.ConsultationID, tc.C_DATE, CONCAT(tp.FIRSTNAME,' ', tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tc.CHIEFCOMPLAIN,tc.PLANORTREATMENT,CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME, ' ',tdoc.LASTNAME) AS DOCTOR from tblConsulatation as tc " & _
" Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
" Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID Where CONCAT(tp.FIRSTNAME,' ' ,tp.MIDDLENAME,' ' ,tp.LASTNAME) like '' +@fullname+ '%'  Order by tc.C_DATE ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@fullname", txtFullname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvViewConsultation.DataSource = dt
            da.Dispose()
            db.pubSqlCon.Close()
        End Using
    End Sub '//green code
    'END!
End Class