Imports System.Data.SqlClient
Public Class Diagnosis
    '!COMMENT: VARIABLES
    Dim charlieCharlie As Integer = Nothing '//green code
    Dim charlieDelta As Integer = Nothing '//green code
    Dim charlieTangoRomeo As Integer = Nothing '//green code
    Dim det As Date = CDate(Date.Now.ToShortDateString) '//green code
    Dim checkdet As String = Nothing '//green code
    Dim hasDeltaRecord As Boolean = Nothing
    '
    Dim intrfce As String = Nothing
    Dim btn As String = Nothing
    Dim actn As String = Nothing
    'END!
    '*****************************************************************************************
    '!COMMENT: BUTTONS
    'i. UPDATE
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If charlieDelta <> 0 Then
            'Check if date equals today. If not UPDATION is not allowed.
            Dim detNow As String = det.ToShortDateString.ToString
            If detNow = checkdet Then
                Dim answer As DialogResult = MsgBox("Please confirm if you would want to update this record.", MsgBoxStyle.YesNo)
                If answer = Windows.Forms.DialogResult.Yes Then
                    captureUAupdate()
                    updateDiagnosis()
                    loadUpdatedRecords()
                    cleardataFrmConsltation()
                    cleardataFrmTestResult()
                End If
            Else
                MessageBox.Show("Security error! You can only update records with date today.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub
    'ii. VIEW
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        captureUAview()
        Me.Close()
        DoctorDashboard.loadViewDiagnosis()
    End Sub
    'ii. UPDATE TEST RESULT
    Private Sub btnUpdateTest_Click(sender As Object, e As EventArgs) Handles btnUpdateTest.Click
       Dim detNow As String = det.ToShortDateString.ToString
        If detNow = checkdet Then
            Dim answer As DialogResult = MsgBox("Please confirm if you would want to update record.", MsgBoxStyle.YesNo)
            If answer = Windows.Forms.DialogResult.Yes Then
                captureUAupdateTest()
                updateTestResults()
                loadUpdatedTestResults()
            End If
        Else
            MessageBox.Show("Security error! You can only update records with date today.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
    'iv. SAVE
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If charlieCharlie <> 0 Then
            checkBeforeSaving() ' check if this patient has already diagnosis using consultation number
            If hasDeltaRecord = False Then
                If txtDiagnosis.Text = "" Then
                    msgbBoxShw()
                ElseIf txtTreatment.Text = "" Then
                    msgbBoxShw()
                Else
                    captureUAsave()
                    InsertNewDiagnosis()
                    loadNewRecord()
                End If
            Else
                MessageBox.Show("This record with consultation number [" & charlieCharlie & "]" & " has already a diagnosis record." & vbCrLf & vbCrLf & "Please select a unique record. Thank you.", "Warning! Duplicate record...", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub
    'v. PRESCRIPTION
    Private Sub btnPrescription_Click(sender As Object, e As EventArgs) Handles btnPrescription.Click
        captureUAprescription()
        PrescriptionFrm.txtLname.Text = txtfullname.Text
        Me.Close()
        DoctorDashboard.loadPrescription()
    End Sub
    'END!
    '*****************************************************************************************
    '!COMMENT: EVENTS
    'i. Load diagnosis
    Private Sub Diagnosis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureUAloadfrm()
        loadConsultation()
        loadDiagnosis()
    End Sub
    'ii. Last name text changed
    Private Sub txtLastname_TextChanged(sender As Object, e As EventArgs) Handles txtLastname.TextChanged
        If txtLastname.Text <> "" Then
            searchConsultation()
            searchDiagnosis()
        Else
            charlieDelta = Nothing
            cleardataFrmConsltation()
            cleardataFrmTestResult()
            loadConsultation()
            loadDiagnosis()
        End If
    End Sub
    'iii. DGV cell click (consultation)
    Private Sub dgvConsultation_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsultation.CellClick
        Try
            btnSave.Enabled = True
            btnUpdate.Enabled = False
            charlieCharlie = Nothing
            charlieDelta = Nothing
            cleardataFrmConsltation()
            Dim romeo As Integer = Nothing
            If dgvConsultation.RowCount > 0 Then
                romeo = dgvConsultation.CurrentRow.Index
                charlieCharlie = dgvConsultation.Item(0, romeo).Value
                consultationToFields()
                loadTestResults()
            End If
        Catch
            charlieCharlie = 0
            charlieCharlie = Nothing
            cleardataFrmConsltation()
            cleardataFrmTestResult()
        End Try
    End Sub
    'iv. DGV cell click (test results)
    Private Sub dgvTestResult_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTestResult.CellClick
        Try
            charlieTangoRomeo = Nothing
            Dim romeo As Integer = Nothing
            If dgvTestResult.RowCount > 0 Then
                romeo = dgvTestResult.CurrentRow.Index
                charlieTangoRomeo = dgvTestResult.Item(0, romeo).Value
                fromTestResultsToFeilds()
            End If
        Catch
            cleardataFrmTestResult()
        End Try
    End Sub
    'v. DGV cell click (diagnosis)
    Private Sub dgvDiagnosis_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDiagnosis.CellClick
        Try
            charlieCharlie = Nothing
            charlieDelta = Nothing
            btnSave.Enabled = False
            btnUpdate.Enabled = True
            Dim romeo As Integer = Nothing
            If dgvDiagnosis.RowCount > 0 Then
                romeo = dgvDiagnosis.CurrentRow.Index
                charlieDelta = dgvDiagnosis.Item(0, romeo).Value
                diagnosisToFields()
            End If
        Catch
            cleardataFrmConsltation()
            cleardataFrmTestResult()
            charlieDelta = Nothing
            charlieCharlie = Nothing
            checkdet = Nothing
            btnSave.Enabled = True
            btnUpdate.Enabled = False
        End Try
    End Sub
    'vi. Form closing
    Private Sub Diagnosis_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DoctorDashboard.returnToDashboard()
    End Sub
    'vii. Key press
    Private Sub txtLastname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastname.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> vbBack AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub
    'END!
    '*****************************************************************************************
    '!COMMENT:METHODS
    'i. Load (Consultation)
    Public Sub loadConsultation()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tc.ConsultationID, tc.C_DATE, CONCAT(tp.FIRSTNAME,' ', tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tc.CHIEFCOMPLAIN,tc.PLANORTREATMENT,CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME, ' ',tdoc.LASTNAME) AS DOCTOR from tblConsulatation as tc " & _
                                    " Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
                                    " Inner join tblPerson as tp On tv.PersonID = tp.PersonID where C_DATE = @det Order by PATIENT ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvConsultation.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub '//green code
    'ii. Load (Diagnosis)
    Public Sub loadDiagnosis()
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
        Using cmd As New SqlCommand(" Select td.DiagnosisID,tc.ConsultationID,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME,' ',tp.LASTNAME) as PATIENT, td.D_DATE,td.DIAGNOSIS,td.TREATMENT,CONCAT(tdoc.FIRSTNAME, ' ',tdoc.MIDDLENAME,' ',tdoc.LASTNAME) as DOCTOR from tblDiagnosis as td " & _
                                    " Inner join tblConsulatation as tc On td.ConsultationID =tc.ConsultationID " & _
                                    " Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Inner Join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
                                    " Where td.D_DATE Between @lastweek And @dettoday Order by td.D_DATE DESC;", db.pubSqlCon)
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
    End Sub '//green code
    'iii. Check if hasrecord
    Public Sub checkBeforeSaving()
        Dim diagnosisNo As Integer = Nothing
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Check if customer alreay has record
        Using cmd As New SqlCommand("Select DiagnosisID from tblDiagnosis Where ConsultationID = @consultation;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@consultation", txtConsultattionID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                hasDeltaRecord = True
            Else
                hasDeltaRecord = False
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub '//green code
    'iv. Save new record
    Public Sub InsertNewDiagnosis()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Insert into tblDiagnosis (ConsultationID, D_DATE, DIAGNOSIS,TREATMENT) Values (@consultationid,@date,@diagnosis,@treatment);", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@consultationid", SqlDbType.Int).Value = txtConsultattionID.Text
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = det
            cmd.Parameters.Add("@diagnosis", SqlDbType.VarChar).Value = txtDiagnosis.Text
            cmd.Parameters.Add("@treatment", SqlDbType.VarChar).Value = txtTreatment.Text
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("New record added!")
        End Using
    End Sub '// green code
    'v. Load new record
    Public Sub loadNewRecord()
        Dim diagnosisNo As Integer = Nothing
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Get the current Diagnosis id for next use
        Using da As New SqlDataAdapter("Select MAX(DiagnosisID) as id from tblDiagnosis;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                diagnosisNo = dt.Rows(0).Item("id")
            End If
            dt.Dispose()
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
        'Populate new record 
        Using cmd As New SqlCommand(" Select td.DiagnosisID,tc.ConsultationID,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME,' ',tp.LASTNAME) as PATIENT, td.D_DATE,td.DIAGNOSIS,td.TREATMENT,CONCAT(tdoc.FIRSTNAME, ' ',tdoc.MIDDLENAME,' ',tdoc.LASTNAME) as DOCTOR from tblDiagnosis as td " & _
                                    " Inner join tblConsulatation as tc On td.ConsultationID =tc.ConsultationID " & _
                                    " Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Inner Join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
                                    " Where td.DiagnosisID=@id;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@id", diagnosisNo)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvDiagnosis.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            '
            charlieCharlie = Nothing
            cleardataFrmConsltation()
            cleardataFrmTestResult()
        End Using
    End Sub '//green code
    'vi. Load (test result)
    Public Sub loadTestResults()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select TestResultNo as TEST_NO,TYPEOFLABEXAM,RESULT,DATE from tblTestResult where ConsultationID =@consultationid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@consultationid", charlieCharlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvTestResult.DataSource = dt
            da.Dispose()
            db.pubSqlCon.Close()
        End Using
    End Sub '//green code
    'v. Update (test results)
    Public Sub updateTestResults()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Update tblTestResult Set RESULT=@result from tblTestResult where TestResultNo =@testno;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@testno", txtTestresultNo.Text)
            cmd.Parameters.AddWithValue("@result", txtTestResult.Text)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Record updated!")
            cleardataFrmTestResult()
            loadTestResults()
        End Using
    End Sub
    'vi. Load (updated test results)
    Public Sub loadUpdatedTestResults()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select TestResultNo as TEST_NO,TYPEOFLABEXAM,RESULT,DATE from tblTestResult where TestResultNo =@testno;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@testno", charlieTangoRomeo)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvTestResult.DataSource = dt
            da.Dispose()
            db.pubSqlCon.Close()
            charlieTangoRomeo = Nothing
        End Using
    End Sub '//green code
    'vii. Search (consultation)
    Public Sub searchConsultation()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tc.ConsultationID, tc.C_DATE, CONCAT(tp.FIRSTNAME,' ', tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tc.CHIEFCOMPLAIN,tc.PLANORTREATMENT,CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME, ' ',tdoc.LASTNAME) AS DOCTOR from tblConsulatation as tc " & _
" Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
" Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID Where CONCAT(tp.LASTNAME,' ',tp.FIRSTNAME, ' ',tp.MIDDLENAME) like '' +@lname+ '%' Order by tc.C_DATE DESC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtLastname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvConsultation.DataSource = dt
            da.Dispose()
            cmd.Dispose()
            db.pubSqlCon.Close()
        End Using
    End Sub '//green code
    'viii. Search (diagnosis)
    Public Sub searchDiagnosis()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand(" Select td.DiagnosisID,tc.ConsultationID,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME,' ',tp.LASTNAME) as PATIENT, td.D_DATE,td.DIAGNOSIS,td.TREATMENT,CONCAT(tdoc.FIRSTNAME, ' ',tdoc.MIDDLENAME,' ',tdoc.LASTNAME) as DOCTOR from tblDiagnosis as td " & _
                                    " Inner join tblConsulatation as tc On td.ConsultationID =tc.ConsultationID " & _
                                    " Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Inner Join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
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
        End Using
    End Sub '//green code
    'ix. Update (diagnosis)
    Public Sub updateDiagnosis()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Update tblDiagnosis Set DIAGNOSIS=@diagnosis, TREATMENT=@treatment Where DiagnosisID=@diagnosisid;", db.pubSqlCon)
            cmd.Parameters.AddWithValue("@diagnosis", txtDiagnosis.Text)
            cmd.Parameters.AddWithValue("@treatment", txtTreatment.Text)
            cmd.Parameters.AddWithValue("@diagnosisid", charlieDelta)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Update success!")
        End Using
    End Sub '//green code
    'x. Load (Updated records)
    Public Sub loadUpdatedRecords()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand(" Select td.DiagnosisID,tc.ConsultationID,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME,' ',tp.LASTNAME) as PATIENT, td.D_DATE,td.DIAGNOSIS,td.TREATMENT,CONCAT(tdoc.FIRSTNAME, ' ',tdoc.MIDDLENAME,' ',tdoc.LASTNAME) as DOCTOR from tblDiagnosis as td " & _
                                    " Inner join tblConsulatation as tc On td.ConsultationID =tc.ConsultationID " & _
                                    " Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Inner Join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
                                    " Where td.DiagnosisID=@id;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@id", charlieDelta)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvDiagnosis.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            charlieDelta = Nothing
            checkdet = Nothing
        End Using
    End Sub '// green code
    'xi. Populate fields (Consultation)
    Public Sub consultationToFields()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Populate consulatation value to txt feilds
        Using cmd As New SqlCommand(" Select tc.ConsultationID,tc.C_DATE,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', tp.LASTNAME) as PATIENT,tp.AGE,tp.SEX as GENDER  from tblConsulatation as tc " & _
                                    " Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Where tc.ConsultationID =@consultationid ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@consultationid", charlieCharlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtConsultattionID.Text = dt.Rows(0).Item("ConsultationID")
                txtfullname.Text = dt.Rows(0).Item("PATIENT")
                txtAge.Text = dt.Rows(0).Item("AGE")
                txtGender.Text = dt.Rows(0).Item("GENDER")
                checkdet = dt.Rows(0).Item("C_DATE")
            End If
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
        '
        'Populate dgv test results
        Using cmd1 As New SqlCommand("Select ttr.TestResultNo,ttr.TYPEOFLABEXAM,ttr.RESULT,ttr.DATE from tblTestResult as ttr Where  ttr.ConsultationID=@consultationid;", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd1.Parameters.Clear()
            cmd1.Parameters.AddWithValue("@consultationid", charlieCharlie)
            Dim da As New SqlDataAdapter(cmd1)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvTestResult.DataSource = dt
            da.Dispose()
            db.pubSqlCon.Close()
        End Using
    End Sub '//green code
    'xii. Populate fields (Diagnosis)
    Public Sub diagnosisToFields()
        Dim db As New KonekDB
        Dim consultationid As Integer = Nothing
        db.FETCHDBINFO()
        'Populate diagnosis value on txt fields
        Using cmd As New SqlCommand("Select td.ConsultationID,CONCAT(tp.FIRSTNAME,' ',tp.MIDDLENAME,' ',tp.LASTNAME) as PATIENT, tp.AGE,tp.SEX as GENDER, td.DIAGNOSIS,td.TREATMENT,td.D_DATE from tblDiagnosis as td " & _
                                    " Inner join tblVitalSigns as tv On td.ConsultationID = tv.VitalSignNo  " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Where td.DiagnosisID = @diagnosisid", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@diagnosisid", charlieDelta)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtConsultattionID.Text = dt.Rows(0).Item("ConsultationID")
                txtfullname.Text = dt.Rows(0).Item("PATIENT")
                txtAge.Text = dt.Rows(0).Item("AGE")
                txtGender.Text = dt.Rows(0).Item("GENDER")
                txtDiagnosis.Text = dt.Rows(0).Item("DIAGNOSIS")
                txtTreatment.Text = dt.Rows(0).Item("TREATMENT")
                checkdet = dt.Rows(0).Item("D_DATE")
            End If
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            dt.Dispose()
        End Using
        'Populate dgv test results
        Using cmd1 As New SqlCommand("Select ttr.TestResultNo as TEST_NO,ttr.TYPEOFLABEXAM,ttr.RESULT,ttr.DATE from tblTestResult as ttr Where  ttr.ConsultationID=@consultationid;", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd1.Parameters.Clear()
            cmd1.Parameters.AddWithValue("@consultationid", txtConsultattionID.Text)
            Dim da As New SqlDataAdapter(cmd1)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvTestResult.DataSource = dt
            da.Dispose()
            db.pubSqlCon.Close()
        End Using
    End Sub '//green code
    'xii. Populate fields (Test results)
    Public Sub fromTestResultsToFeilds()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand(" Select TestResultNo as TEST_NO,TYPEOFLABEXAM,RESULT,DATE from tblTestResult where TestResultNo = @testresultno;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@testresultno", charlieTangoRomeo)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtTestresultNo.Text = dt.Rows(0).Item("TEST_NO")
                txtTypeOftest.Text = dt.Rows(0).Item("TYPEOFLABEXAM")
                'check if null
                If IsDBNull(dt.Rows(0).Item("RESULT")) = True Then
                    txtTestResult.Text = ""
                Else
                    txtTestResult.Text = dt.Rows(0).Item("RESULT")
                End If
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using

    End Sub '//green code
    'xiii. Clear fields (consultation fields)
    Public Sub cleardataFrmConsltation()
        txtConsultattionID.Text = ""
        txtfullname.Text = ""
        txtAge.Text = ""
        txtGender.Text = ""
        txtDiagnosis.Text = ""
        txtTreatment.Text = ""
        charlieCharlie = Nothing
        '
        checkdet = Nothing
        '
        dgvTestResult.DataSource = Nothing
    End Sub
    'xiv. Clear fields (Test results)
    Public Sub cleardataFrmTestResult()
        txtTestresultNo.Text = ""
        txtTypeOftest.Text = ""
        txtTestResult.Text = ""
        'charlieTango = 0
        'charlieTango = Nothing
    End Sub
    'xv. User Activity
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
    Public Sub captureUAloadfrm()
        intrfce = "Diagnosis"
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
    Public Sub captureUAupdateTest()
        intrfce = "Diagnosis"
        btn = "Update"
        actn = "Update result of test result number " & txtTestresultNo.Text & "."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAsave()
        intrfce = "Diagnosis"
        btn = "Save"
        actn = "Save new diagnosis record of " & txtfullname.Text & "."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAupdate()
        intrfce = "Diagnosis"
        btn = "Update"
        actn = "Update diagnosis record of " & txtfullname.Text & " with consultation id " & txtConsultattionID.Text & "."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAprescription()
        intrfce = "Diagnosis"
        btn = "Prescription"
        actn = "Click"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAview()
        intrfce = "Diagnosis"
        btn = "View"
        actn = "Click"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!
    '****************************************************************************************

End Class