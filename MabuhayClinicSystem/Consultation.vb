Imports System.Data.SqlClient
Public Class Consultation
    '!COMMENT: VARIABLES
    Dim charlieVictor As Integer = Nothing '//green code
    Dim charlieCharlie As Integer = Nothing '// green variable
    Dim det As Date = CDate(Date.Now.ToShortDateString) '//green code
    Dim checkdet As String = Nothing '//green code
    '
    Dim intrfce As String = Nothing
    Dim btn As String = Nothing
    Dim actn As String = Nothing
    '
    'END!
    '****************************************************************************************
    '!COMMENT: BUTTON
    'i.SAVE
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        saveConsultation()
    End Sub
    'ii. UPDATE
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        updateConsultation()
    End Sub
    'iii. VIEW
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Me.Close()
        DoctorDashboard.loadViewConsultation()
    End Sub
    'iv. APPOINTMENT
    Private Sub btnAppointment_Click(sender As Object, e As EventArgs) Handles btnAppointment.Click
        captureUAappointment()
        Me.Close()
        DoctorDashboard.loadAddappointment()
    End Sub
    'v.
    Private Sub btnPrescription_Click(sender As Object, e As EventArgs) Handles btnPrescription.Click
        captureUAprescription()
        PrescriptionFrm.txtLname.Text = txtFullname.Text
        Me.Close()
        DoctorDashboard.loadPrescription()
    End Sub
    'END!
    '****************************************************************************************
    '!COMMENT: EVENTS
    'i.Form load
    Private Sub Consultation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureUAloadFrm()
        loadConsultationRecord()
    End Sub '//green code
    'ii. Search Last anme text change
    Private Sub txtSearchLname_TextChanged(sender As Object, e As EventArgs) Handles txtSearchLname.TextChanged
        If txtSearchLname.Text <> "" Then
            SearchPatientInfo()
            searchConsultation()
        Else
            dgvPatientInfo.DataSource = Nothing
            loadConsultationRecord()
            consClear()
        End If
    End Sub '//green code
    'iii. DGV patient info cell click
    Private Sub dgvPatientInfo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPatientInfo.CellClick
        Try
            btnSave.Enabled = True
            btnUpdate.Enabled = False
            charlieVictor = 0
            charlieVictor = Nothing
            consClear()
            Dim romeo As Integer = Nothing
            If dgvPatientInfo.RowCount > 0 Then
                romeo = dgvPatientInfo.CurrentRow.Index
                charlieVictor = dgvPatientInfo.Item(0, romeo).Value
            End If
            If charlieVictor <> "0" Or IsNothing(charlieVictor) = False Then
                populatetxtFields()
            End If
        Catch
            charlieVictor = 0
            charlieVictor = Nothing
            consClear()
            loadConsultationRecord()
        End Try
    End Sub '//green code
    'iv. DGV consultation cell click
    Private Sub dgvConsultationRecords_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsultationRecords.CellClick
        Try
            consClear()
            charlieCharlie = 0
            charlieCharlie = Nothing
            checkdet = Nothing
            Dim romeo As Integer = Nothing
            If dgvConsultationRecords.RowCount > 0 Then
                romeo = dgvConsultationRecords.CurrentRow.Index
                charlieCharlie = dgvConsultationRecords(0, romeo).Value
                btnUpdate.Enabled = True
                btnSave.Enabled = False
                '
                fromConsultationtoTxtFields()
            End If
        Catch
            charlieCharlie = 0
            charlieCharlie = Nothing
            checkdet = Nothing
            consClear()
        End Try
    End Sub '//green code
    'v. Form closing
    Private Sub Consultation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DoctorDashboard.returnToDashboard()
    End Sub
    'vi. Key press
    Private Sub txtSearchLname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchLname.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> vbBack AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub
    'END!
    '****************************************************************************************
    '!COMMENT: METHODS
    'i. Clear fields
    Public Sub consClear()
        txtFullname.Text = ""
        txtGender.Text = ""
        txtAge.Text = ""
        txtAddress.Text = ""
        txtBodyTemp.Text = ""
        txtRespRate.Text = ""
        txtBloodPressre.Text = ""
        txtPulseRate.Text = ""
        txtO2Sat.Text = ""
        txtHeight.Text = ""
        txtWeight.Text = ""
        txtStatus.Text = ""
        txtChiefComplain.Text = ""
        txtTreatment.Text = ""
    End Sub '//green code
    'ii. Search Patient info by Lastname
    Public Sub SearchPatientInfo()
        Dim db As New KonekDB
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tv.VitalSignNo, CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tp.AGE,tp.SEX as GENDER,CONCAT(tp.BARANGAY,' ',tp.MUNICIPALITY,' ',tp.PROVINCE) as ADDRESS, " & _
                                    " tv.STATUS,CONCAT(tv.BODYTEMP,'-Normal:[', tv.BT_ISNORMAL,']') As BODY_TEMP, CONCAT(tv.BLOODPRESSURE,'-Normal:[', tv.BP_ISNORMAL,']') as BLOOD_PRESSURE , CONCAT(tv.RESPIRATION,'-Normal:[', tv.R_ISNORMAL,']') as RESPIRATION_RATE , " & _
                                    " CONCAT(tv.PULSERATE,'-Normal:[', tv.P_ISNORMAL,']')as PULSE_RATE , CONCAT(tv.O2SAT,'-Normal:[', tv.O2_ISNORMAL,']') as O2_SAT, tv.WEIGHT, tv.HIEGHT, tv.VS_DATE from tblVitalSigns as tv " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Where CONCAT(tp.LASTNAME,' ',tp.FIRSTNAME, ' ',tp.MIDDLENAME) like '' +@lname+ '%' and tv.VS_DATE =@det;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtSearchLname.Text)
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientInfo.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub '//green code
    'iii. Populate Fields
    Public Sub populatetxtFields()
        Dim db As New KonekDB
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tv.VitalSignNo, CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tp.AGE,tp.SEX as GENDER,CONCAT(tp.BARANGAY,' ',tp.MUNICIPALITY,' ',tp.PROVINCE) as ADDRESS, " & _
                                     " tv.STATUS,CONCAT(tv.BODYTEMP,'-Normal:[', tv.BT_ISNORMAL,']') As BODY_TEMP, CONCAT(tv.BLOODPRESSURE,'-Normal:[', tv.BP_ISNORMAL,']') as BLOOD_PRESSURE , CONCAT(tv.RESPIRATION,'-Normal:[', tv.R_ISNORMAL,']') as RESPIRATION_RATE , " & _
                                     " CONCAT(tv.PULSERATE,'-Normal:[', tv.P_ISNORMAL,']')as PULSE_RATE , CONCAT(tv.O2SAT,'-Normal:[', tv.O2_ISNORMAL,']') as O2_SAT, tv.WEIGHT, tv.HIEGHT, tv.VS_DATE from tblVitalSigns as tv " & _
                                     " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                     " Where tv.VitalSignNo =@vitalsignsno and tv.VS_DATE =@det;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@vitalsignsno", charlieVictor)
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtFullname.Text = dt.Rows(0).Item("PATIENT")
                txtGender.Text = dt.Rows(0).Item("GENDER")
                txtAge.Text = dt.Rows(0).Item("AGE").ToString
                txtAddress.Text = dt.Rows(0).Item("ADDRESS")
                txtBodyTemp.Text = dt.Rows(0).Item("BODY_TEMP")
                txtRespRate.Text = dt.Rows(0).Item("RESPIRATION_RATE")
                txtBloodPressre.Text = dt.Rows(0).Item("BLOOD_PRESSURE")
                txtPulseRate.Text = dt.Rows(0).Item("PULSE_RATE")
                txtO2Sat.Text = dt.Rows(0).Item("O2_SAT")
                txtHeight.Text = dt.Rows(0).Item("HIEGHT")
                txtWeight.Text = dt.Rows(0).Item("WEIGHT")
                txtStatus.Text = dt.Rows(0).Item("STATUS")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub '//green code
    'iv. Function reference for checking fields if empty
    Public Function IsEmpty(ByVal txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function '//green code
    'v. Check field if empty else 
    Public Sub saveConsultation()
        Dim bolfullname As Boolean = IsEmpty(txtFullname)
        Dim bolgender As Boolean = IsEmpty(txtGender)
        Dim bolage As Boolean = IsEmpty(txtAge)
        Dim bolAddress As Boolean = IsEmpty(txtAddress)
        Dim bolbodyTemp As Boolean = IsEmpty(txtBodyTemp)
        Dim bolresprate As Boolean = IsEmpty(txtRespRate)
        Dim bolBloodPressure As Boolean = IsEmpty(txtBloodPressre)
        Dim bolpulserate As Boolean = IsEmpty(txtPulseRate)
        Dim bolo2sat As Boolean = IsEmpty(txtO2Sat)
        Dim bolheight As Boolean = IsEmpty(txtHeight)
        Dim bolweight As Boolean = IsEmpty(txtWeight)
        Dim bolChiefComp As Boolean = IsEmpty(txtChiefComplain)
        Dim boltreatment As Boolean = IsEmpty(txtTreatment)
        '
        If bolfullname Then
            msgbBoxShw()
        ElseIf bolgender Then
            msgbBoxShw()
        ElseIf bolage Then
            msgbBoxShw()
        ElseIf bolAddress Then
            msgbBoxShw()
        ElseIf bolbodyTemp Then
            msgbBoxShw()
        ElseIf bolresprate Then
            msgbBoxShw()
        ElseIf bolBloodPressure Then
            msgbBoxShw()
        ElseIf bolpulserate Then
            msgbBoxShw()
        ElseIf bolo2sat Then
            msgbBoxShw()
        ElseIf bolheight Then
            msgbBoxShw()
        ElseIf bolweight Then
            msgbBoxShw()
        ElseIf bolChiefComp Then
            msgbBoxShw()
        ElseIf boltreatment Then
            msgbBoxShw()
        Else
            Try
                If charlieVictor <> "0" Or IsNothing(charlieVictor) = False Then
                    captureUAsave() ' Capture user activity
                    Dim db As New KonekDB
                    db.FETCHDBINFO()
                    Using cmd As New SqlCommand("Insert tblConsulatation (ConsultationID,DoctorID,CHIEFCOMPLAIN,PLANORTREATMENT,C_DATE) values (@consultationid,@doctorid,@cheifcomplain,@treatment,@det);", db.pubSqlCon)
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@consultationid", System.Data.SqlDbType.Int).Value = charlieVictor
                        cmd.Parameters.Add("@doctorid", System.Data.SqlDbType.Int).Value = doctorID
                        cmd.Parameters.Add("@cheifcomplain", System.Data.SqlDbType.VarChar).Value = txtChiefComplain.Text
                        cmd.Parameters.Add("@treatment", System.Data.SqlDbType.VarChar).Value = txtTreatment.Text
                        cmd.Parameters.Add("@det", System.Data.SqlDbType.Date).Value = det
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        db.pubSqlCon.Close()
                        MsgBox("New record has been saved!")
                        displayNewConsultation()
                        consClear()
                    End Using
                End If
            Catch
                MsgBox("The record VITAL SIGN NO [" & charlieVictor & "]" & " = CONSULTATION NO. [" & charlieVictor & "]" & " is already on record." & vbCrLf & "Please select a unique record. Thank you.", MsgBoxStyle.MsgBoxHelp)
                Exit Sub
            End Try
        End If
    End Sub '//green code
    'vi. Search Medical record using Lastname
    Public Sub displayNewConsultation()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tc.ConsultationID, tc.C_DATE, CONCAT(tp.FIRSTNAME,' ', tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tc.CHIEFCOMPLAIN,tc.PLANORTREATMENT,CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME, ' ',tdoc.LASTNAME) AS DOCTOR from tblConsulatation as tc " & _
" Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
" Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID where tc.ConsultationID = @consultationid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@consultationid", charlieVictor)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvConsultationRecords.DataSource = dt
            da.Dispose()
            cmd.Dispose()
            db.pubSqlCon.Close()
            charlieVictor = 0
            charlieVictor = Nothing
        End Using
    End Sub '//green code
    'vii. Populate Consultation record
    Public Sub loadConsultationRecord()
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
            dgvConsultationRecords.DataSource = dt
            da.Dispose()
            cmd.Dispose()
            db.pubSqlCon.Close()
        End Using
    End Sub '//green code
    'viii. Search consultation by Lastname
    Public Sub searchConsultation()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tc.ConsultationID, tc.C_DATE, CONCAT(tp.FIRSTNAME,' ', tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tc.CHIEFCOMPLAIN,tc.PLANORTREATMENT,CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME, ' ',tdoc.LASTNAME) AS DOCTOR from tblConsulatation as tc " & _
" Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
" Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID Where CONCAT(tp.LASTNAME,' ',tp.FIRSTNAME, ' ',tp.MIDDLENAME) like '' +@lname+ '%' Order by tc.C_DATE DESC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtSearchLname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvConsultationRecords.DataSource = dt
            da.Dispose()
            cmd.Dispose()
            db.pubSqlCon.Close()
        End Using
    End Sub '//green code
    'x. Populate data from consultation to txt fields
    Public Sub fromConsultationtoTxtFields()
        Dim db As New KonekDB
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tc.ConsultationID,tc.C_DATE,tdoc.DoctorID, CONCAT(tp.FIRSTNAME,' ' ,tp.MIDDLENAME,' ' ,tp.LASTNAME) as PATIENT, tp.AGE,tp.SEX as GENDER, " & _
                                    " CONCAT(tp.BARANGAY,' ',tp.MUNICIPALITY,' ',tp.PROVINCE) as ADDRESS,tv.STATUS,CONCAT(tv.BODYTEMP,'-Normal:[', tv.BT_ISNORMAL,']') As BODY_TEMP, " & _
                                    " CONCAT(tv.BLOODPRESSURE,'-Normal:[', tv.BP_ISNORMAL,']') as BLOOD_PRESSURE , CONCAT(tv.RESPIRATION,'-Normal:[', tv.R_ISNORMAL,']') as RESPIRATION_RATE , " & _
                                    " CONCAT(tv.PULSERATE,'-Normal:[', tv.P_ISNORMAL,']')as PULSE_RATE , CONCAT(tv.O2SAT,'-Normal:[', tv.O2_ISNORMAL,']') as O2_SAT, tv.WEIGHT, tv.HIEGHT,tv.VS_DATE,tc.CHIEFCOMPLAIN,tc.PLANORTREATMENT,tc.C_DATE from tblConsulatation as tc " & _
" Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
" Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID Where tc.ConsultationID =@consultationid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@consultationid ", charlieCharlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                checkdet = CStr(dt.Rows(0).Item("C_DATE"))
                txtFullname.Text = dt.Rows(0).Item("PATIENT").ToString
                txtGender.Text = dt.Rows(0).Item("GENDER").ToString
                txtAge.Text = dt.Rows(0).Item("AGE").ToString
                txtAddress.Text = dt.Rows(0).Item("ADDRESS").ToString
                txtBodyTemp.Text = dt.Rows(0).Item("BODY_TEMP").ToString
                txtRespRate.Text = dt.Rows(0).Item("RESPIRATION_RATE").ToString
                txtBloodPressre.Text = dt.Rows(0).Item("BLOOD_PRESSURE").ToString
                txtPulseRate.Text = dt.Rows(0).Item("PULSE_RATE").ToString
                txtO2Sat.Text = dt.Rows(0).Item("O2_SAT").ToString
                txtHeight.Text = dt.Rows(0).Item("HIEGHT").ToString
                txtWeight.Text = dt.Rows(0).Item("WEIGHT").ToString
                txtStatus.Text = dt.Rows(0).Item("STATUS").ToString
                txtChiefComplain.Text = dt.Rows(0).Item("CHIEFCOMPLAIN").ToString
                txtTreatment.Text = dt.Rows(0).Item("PLANORTREATMENT").ToString
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub '//green code
    'xi. Update patient record
    Public Sub updateConsultation()
        Dim bolfullname As Boolean = IsEmpty(txtFullname)
        Dim bolgender As Boolean = IsEmpty(txtGender)
        Dim bolage As Boolean = IsEmpty(txtAge)
        Dim bolAddress As Boolean = IsEmpty(txtAddress)
        Dim bolbodyTemp As Boolean = IsEmpty(txtBodyTemp)
        Dim bolresprate As Boolean = IsEmpty(txtRespRate)
        Dim bolBloodPressure As Boolean = IsEmpty(txtBloodPressre)
        Dim bolpulserate As Boolean = IsEmpty(txtPulseRate)
        Dim bolo2sat As Boolean = IsEmpty(txtO2Sat)
        Dim bolheight As Boolean = IsEmpty(txtHeight)
        Dim bolweight As Boolean = IsEmpty(txtWeight)
        Dim bolChiefComp As Boolean = IsEmpty(txtChiefComplain)
        Dim boltreatment As Boolean = IsEmpty(txtTreatment)
        '
        If bolfullname Then
            msgbBoxShw()
        ElseIf bolgender Then
            msgbBoxShw()
        ElseIf bolage Then
            msgbBoxShw()
        ElseIf bolAddress Then
            msgbBoxShw()
        ElseIf bolbodyTemp Then
            msgbBoxShw()
        ElseIf bolresprate Then
            msgbBoxShw()
        ElseIf bolBloodPressure Then
            msgbBoxShw()
        ElseIf bolpulserate Then
            msgbBoxShw()
        ElseIf bolo2sat Then
            msgbBoxShw()
        ElseIf bolheight Then
            msgbBoxShw()
        ElseIf bolweight Then
            msgbBoxShw()
        ElseIf bolChiefComp Then
            msgbBoxShw()
        ElseIf boltreatment Then
            msgbBoxShw()
        Else
            If charlieCharlie <> "0" Or IsNothing(charlieCharlie) = False Then
                'Ensure that when comparing date, both variables is in string 
                Dim detToday As String = det.ToShortDateString.ToString()
                If checkdet = detToday Then
                    captureUAupdate() ' Capture user activity
                    Dim db As New KonekDB
                    db.FETCHDBINFO()
                    Using cmd As New SqlCommand("Update tblConsulatation Set CHIEFCOMPLAIN=@cheifcomplain,PLANORTREATMENT=@treatment where ConsultationID=@consultationid;", db.pubSqlCon)
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@consultationid", charlieCharlie)
                        cmd.Parameters.AddWithValue("@cheifcomplain", txtChiefComplain.Text)
                        cmd.Parameters.AddWithValue("@treatment", txtTreatment.Text)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        db.pubSqlCon.Close()
                        'reset column consultation for next use
                        charlieCharlie = 0
                        charlieCharlie = Nothing
                        MsgBox("Record has been updated!")
                        'displayNewConsultation()
                        consClear()
                    End Using
                Else
                    MessageBox.Show("Security error! Please note that only admin can update records in the past days, weeks, month or year.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub '//green code
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
        intrfce = "Consultation"
        btn = "N/A"
        actn = "Open"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'ii. Save
    Public Sub captureUAsave()
        intrfce = "Consultation"
        btn = "Save"
        actn = "Save new consultation of " & txtFullname.TabIndex & "."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'iii. Update
    Public Sub captureUAupdate()
        intrfce = "Consultation"
        btn = "Update"
        actn = "Update consultation of " & txtFullname.TabIndex & "."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'iv. Appointment
    Public Sub captureUAappointment()
        intrfce = "Consultation"
        btn = "Appointment"
        actn = "Click"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAprescription()
        intrfce = "Consultation"
        btn = "Prescription"
        actn = "Click"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!
End Class