Imports System.Data.SqlClient
Public Class labandradtests
    '!COMMENT: PRIVATE VARIABLES
    Dim charlie As Integer = Nothing
    Dim charlie2nd As Integer = Nothing
    'END!
    '******************************************************************************************
    '!COMMENT: BUTTONS
    'i. CLEAR
    Private Sub alrbtnClear_Click_1(sender As Object, e As EventArgs) Handles alrbtnClear.Click
        lrclearfields()
    End Sub
    'ii. UPDATE
    Private Sub alrbtnUpdate_Click_1(sender As Object, e As EventArgs) Handles alrbtnUpdate.Click
        If alrConsultationNo.Text = "" Then
            MessageBox.Show("Please do not leave the consultation field empty!", "Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf alrcmbxTyptest.Text = "" Then
            MessageBox.Show("Please do not leave test result field empty!", "Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to update this record.", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.Yes Then
                updaterecord()
                lrclearfields()
                loadUpdatedRecord()
            End If
        End If
    End Sub
    'iii. SAVE
    Private Sub alrbtnSAVE_Click_1(sender As Object, e As EventArgs) Handles alrbtnSAVE.Click
        If alrConsultationNo.Text = "" Then
            MessageBox.Show("Please select a record from consultation details.", "Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf alrcmbxTyptest.Text = "" Then
            MessageBox.Show("Please do not leave test result field empty!", "Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            insertnewrcrd()
            loadlabandrad()
        End If
    End Sub
    'END!
    '******************************************************************************************
    '!COMMENT: EVENTS
    'i. textbox search appointment
    Private Sub alrSearchAppConsul_TextChanged_1(sender As Object, e As EventArgs) Handles alrSearchAppConsul.TextChanged
        If alrSearchAppConsul.Text <> "" Then
            lrclearfields()
            searchappoinment()
            searchconsultation()
        Else
            lrclearfields()
            Dim dt0, dt1 As New DataTable
            alrDGVappointment.DataSource = dt0
            alrDGVConsultation.DataSource = dt1
            dt0.Dispose()
            dt1.Dispose()
        End If
    End Sub '//green code
    'ii. textbox search lab and rad
    Private Sub alrSearchLabRad_TextChanged_1(sender As Object, e As EventArgs) Handles alrSearchLabRad.TextChanged
        If alrSearchLabRad.Text <> "" Then
            searchtestbylastname()
        Else
            lrclearfields()
            loadlabandrad()
        End If
    End Sub '//green code
    'iii. appointment dgv cellclick
    Private Sub alrDGVappointment_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles alrDGVappointment.CellClick
        getcolumnposition(alrDGVappointment)
        populatefieldsfrmappnmtn()
    End Sub '//green code
    'iv. consultation dgv cellclick
    Private Sub alrDGVConsultation_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles alrDGVConsultation.CellClick
        getcolumnposition(alrDGVConsultation)
        populatefieldsfrmcnsltn()
        loadlabandrad()
    End Sub
    'v. laboratory and radiology test result cellclick
    Private Sub alrDGVlabndrad_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles alrDGVlabndrad.CellClick
        Try
            Dim romeo As Integer = Nothing
            lrclearfields()
            alrbtnSAVE.Enabled = False
            alrbtnUpdate.Enabled = True
            If alrDGVlabndrad.Rows.Count > 0 Then
                romeo = alrDGVlabndrad.CurrentRow.Index
                charlie2nd = alrDGVlabndrad.Item(0, romeo).Value
                populatefieldsfromtstrslts()
            End If
        Catch
            charlie2nd = 0
            charlie2nd = Nothing
            lrclearfields()
        End Try
    End Sub '// green code
    'vi. form closing
    Private Sub labandradtests_formclosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        UserDashboard.returntoUserDashboard()
    End Sub
    'vii.form Load
    Private Sub labandradtests_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim intrfce As String = "Add laboratory and radiology"
        Dim btn As String = "N/A"
        Dim actn As String = "Open"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!
    '******************************************************************************************
    '!COMMENT: METHODS
    'i. clear fields
    Public Sub lrclearfields()
        alrlblAppointNo.Text = ""
        alrlblDate.Text = ""
        alrlblDoctor.Text = ""
        alrlblNote.Text = ""
        alrlblPatientName.Text = ""
        alrConsultationNo.Text = ""
        alrcmbxTyptest.Text = ""
        alrCnsltnDate.Text = ""
        alrbtnUpdate.Enabled = False
        alrbtnSAVE.Enabled = True
        charlie = Nothing
    End Sub
    'ii. search appointment
    Public Sub searchappoinment()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select  AppointmentID,A_DATE, CONCAT(FIRSTNAME, ' ', MIDDLENAME, ' ',LASTNAME) as PATIENT,SEX from tblAppointment as ta " & _
                                    " Inner Join tblPerson as tp on tp.personid = ta.personid " & _
                                    " Where CONCAT(LASTNAME,' ',FIRSTNAME, ' ', MIDDLENAME) like '' + @lastname + '%' Order by A_DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lastname", alrSearchAppConsul.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            alrDGVappointment.DataSource = dt
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'iii. search consultation
    Public Sub searchconsultation()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select  tc.ConsultationID, tc.C_DATE ,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, CONCAT(tdoc.FIRSTNAME, ' ',tdoc.MIDDLENAME, ' ', tdoc.LASTNAME) as DOCTOR  from tblConsulatation as tc " & _
                                    " Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner join tblPerson as tp on tv.PersonID = tp.PersonID  " & _
                                    " Inner join tbldoctor as tdoc on tc.DoctorID = tdoc.DoctorID " & _
                                    " Where CONCAT(tp.LASTNAME, ' ',tp.FIRSTNAME, ' ',tp.MIDDLENAME) like '' + @lastname + '%' order by tc.C_DATE ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lastname", alrSearchAppConsul.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            alrDGVConsultation.DataSource = dt
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'iv. load laboratory and radiology
    Public Sub loadlabandrad()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ttr.TestResultNo,tc.ConsultationID,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT,ttr.TYPEOFLABEXAM,ttr.DATE as DATE_TAKEN from tblTestResult as ttr " & _
                                    " Inner Join tblConsulatation as tc On ttr.ConsultationID = tc.ConsultationID " & _
                                    " Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Where tc.ConsultationID =@consultationid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@consultationid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            alrDGVlabndrad.DataSource = dt
            da.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub '//green code
    'v. get coloumn position
    Public Sub getcolumnposition(ByVal dgv As DataGridView)
        Try
            Dim romeo As Integer = Nothing
            If dgv.Rows.Count > 0 Then
                romeo = dgv.CurrentRow.Index
                charlie = dgv.Item(0, romeo).Value
            End If
        Catch
            charlie = 0
            charlie = Nothing
            lrclearfields()
        End Try
    End Sub
    'vi. populate txt fields from appointment
    Public Sub populatefieldsfrmappnmtn()
        Dim db As New KonekDB
        Dim det As Date = Nothing
        Dim tym As TimeSpan = Nothing
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select AppointmentID, A_DATE, A_TIME, NOTE from tblappointment where AppointmentID=@appointmentid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@appointmentid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                alrlblAppointNo.Text = dt.Rows(0).Item("AppointmentID")
                det = dt.Rows(0).Item("A_DATE")
                tym = dt.Rows(0).Item("A_TIME")
                alrlblDate.Text = det.ToLongDateString() + " " + tym.ToString()
                alrlblNote.Text = dt.Rows(0).Item("NOTE")
            End If
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
        charlie = 0
        charlie = Nothing
    End Sub
    'vii. populate txt fields from consultation
    Public Sub populatefieldsfrmcnsltn()
        Dim db As New KonekDB
        Dim det1 As Date = Nothing
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tc.ConsultationID,CONCAT(tdoc.FIRSTNAME, ' ',tdoc.MIDDLENAME, ' ', tdoc.LASTNAME) as DOCTOR ,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tc.C_DATE from tblConsulatation as tc " & _
" Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
" Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
" Where tc.ConsultationID = @consultationid ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@consultationid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                alrConsultationNo.Text = dt.Rows(0).Item("ConsultationID")
                alrlblDoctor.Text = dt.Rows(0).Item("DOCTOR")
                alrlblPatientName.Text = dt.Rows(0).Item("PATIENT")
                det1 = dt.Rows(0).Item("C_DATE")
                alrCnsltnDate.Text = det1.ToString("D")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub '//green code
    'viii. populate txt fields from test result
    Public Sub populatefieldsfromtstrslts()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ttr.TestResultNo,tc.ConsultationID,tc.C_DATE ,CONCAT(tdoc.FIRSTNAME, ' ',tdoc.MIDDLENAME, ' ', tdoc.LASTNAME) as DOCTOR ,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT,ttr.TYPEOFLABEXAM, ttr.DATE as DATE_TAKEN from tblTestResult as ttr " & _
" Inner join tblConsulatation as tc On ttr.ConsultationID = tc.ConsultationID " & _
" Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID  " & _
" Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo  " & _
" Inner Join tblPerson as tp On tv.PersonID = tp.PersonID  " & _
" Where ttr.TestResultNo =@testresultno;  ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@testresultno", charlie2nd)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                alrConsultationNo.Text = dt.Rows(0).Item("ConsultationID")
                alrlblDoctor.Text = dt.Rows(0).Item("DOCTOR")
                alrlblPatientName.Text = dt.Rows(0).Item("PATIENT")
                alrCnsltnDate.Text = dt.Rows(0).Item("C_DATE")
                alrcmbxTyptest.Text = dt.Rows(0).Item("TYPEOFLABEXAM")
                alrdtp.Value = dt.Rows(0).Item("DATE_TAKEN")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'ix. insert new record
    Public Sub insertnewrcrd()
        'Capture user Activity
        Dim intrfce As String = "Add laboratory and radiology"
        Dim btn As String = "Save"
        Dim actn As String = "Add new record of " & alrcmbxTyptest.Text & " test with consultation ID " & alrConsultationNo.Text & "."
        '
        Dim db As New KonekDB
        Dim det As Date = Nothing
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("insert into tbltestresult (consultationid,typeoflabexam,date) values (@consultationid,@typeoftest,@datetaken);", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@consultationid", System.Data.SqlDbType.Int).Value = CInt(alrConsultationNo.Text)
            cmd.Parameters.Add("@typeoftest", System.Data.SqlDbType.VarChar).Value = alrcmbxTyptest.Text
            det = CDate(alrdtp.Text)
            cmd.Parameters.Add("@datetaken", System.Data.SqlDbType.Date).Value = det
            cmd.Dispose()
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            MsgBox("New record added!")
        End Using
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
        alrcmbxTyptest.Text = ""
    End Sub
    'x. update record
    Public Sub updaterecord()
        Dim db As New KonekDB
        Dim det As Date = Nothing
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Update tbltestresult Set ConsultationID=@consultation,TYPEOFLABEXAM=@testresult,DATE=@det Where TestResultNo=@testresultid; ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@testresultid", charlie2nd)
            cmd.Parameters.AddWithValue("@consultation", alrConsultationNo.Text)
            cmd.Parameters.AddWithValue("@testresult", alrcmbxTyptest.Text)
            det = CDate(alrdtp.Value.ToShortDateString)
            cmd.Parameters.AddWithValue("@det", det)
            cmd.ExecuteNonQuery()
            MsgBox("Update successful!")
            cmd.Dispose()
            db.pubSqlCon.Close()
        End Using
        '
        Dim intrfce As String = "Add laboratory and radiology"
        Dim btn As String = "Update"
        Dim actn As String = "Update record of test result id " & charlie2nd.ToString() & " with consultation ID " & alrConsultationNo.Text & "."
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'xi. search record of laboratory asn radiology test
    Public Sub searchtestbylastname()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ttr.TestResultNo,tc.ConsultationID,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT,ttr.TYPEOFLABEXAM,ttr.DATE as DATE_TAKEN from tblTestResult as ttr " & _
                                    " Inner Join tblConsulatation as tc On ttr.ConsultationID = tc.ConsultationID " & _
                                    " Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Where CONCAT(tp.LASTNAME, ' ',tp.FIRSTNAME, ' ',tp.MIDDLENAME) like '' +@lastname+ '%' Order by PATIENT ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lastname", alrSearchLabRad.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            alrDGVlabndrad.DataSource = dt
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub '//green code
    'xii.
    Public Sub loadUpdatedRecord()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ttr.TestResultNo,tc.ConsultationID,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT,ttr.TYPEOFLABEXAM,ttr.DATE as DATE_TAKEN from tblTestResult as ttr " & _
                                    " Inner Join tblConsulatation as tc On ttr.ConsultationID = tc.ConsultationID " & _
                                    " Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Where ttr.TestResultNo =@testresultno;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@testresultno", charlie2nd)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            alrDGVlabndrad.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    Public Sub UserActivity(ByVal intrfce As String, ByVal btn As String, ByVal actn As String)
        'Dim det As Date = CDate(Date.Now.ToShortDateString())
        'Dim tym As TimeSpan = Date.Now.TimeOfDay
        ''
        'Dim db As New KonekDB
        'db.FETCHDBINFO()
        'Using cmd As New SqlCommand("Insert into tblUserActivity (UserID,FULLNAME,UA_DATE,UA_TIME,INTERFACE,BUTTON,ACTION) values (@userid,@fullname,@det,@tym,@interface,@button,@action);", db.pubSqlCon)
        '    cmd.Parameters.Clear()
        '    cmd.Parameters.Add("@userid", SqlDbType.Int).Value = loginUserid
        '    cmd.Parameters.Add("@fullname", SqlDbType.Text).Value = cp_fname & " " & cp_mname & " " & cp_lname
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
End Class