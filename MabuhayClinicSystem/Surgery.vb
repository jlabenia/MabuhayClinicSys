Imports System.Data.SqlClient
Imports System.Globalization
Public Class Surgery
    '!COMMENT: PRIVATE VARIABLES
    Dim det As Date = CDate(Date.Now.ToShortDateString)
    Dim detofSurgery As Date = Nothing
    Dim charlieVictor As Integer = Nothing
    Dim charliePapa As Integer = Nothing
    Dim charlieDelta As Integer = Nothing
    Dim hasrecord As Boolean = Nothing
    '
    Dim intrfce As String = Nothing
    Dim btn As String = Nothing
    Dim actn As String = Nothing
    'END!
    '**********************************************************************************************************
    '!COMMENT: BUTTONS
    'i. UPDATE
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        updateSurgeryInfo()
    End Sub
    'ii. SAVE
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        saveNewSurgeryInfo()
    End Sub
    'iii. VIEW
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        captureUAview()
        Me.Close()
        DoctorDashboard.loadViewSurgery()
    End Sub
    'END!
    '**********************************************************************************************************
    '!COMMENT: EVENTS
    'i. Load
    Private Sub Surgery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureUAloadFrm()
        loadDoctorInfo()
        loadSurgeryInfo()
    End Sub
    'Form closing
    Private Sub Surgery_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DoctorDashboard.returnToDashboard()
    End Sub
    'Text changed (lastname)
    Private Sub txtLastname_TextChanged(sender As Object, e As EventArgs) Handles txtLastname.TextChanged
        clearPatientVitalInfo()
        clearSurgeryInfo()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        '
        If txtLastname.Text <> "" Then
            If rbtnVitalsigns.Checked = True Then
                'Search record within the past 8 days
                SearchPatientVitalSign()
                searchPatientSurgery()
            ElseIf rbtnDiagnosis.Checked = True Then
                SearchPatientDiagnosis()
            End If
        Else
            dgvPerson.DataSource = Nothing
            clearPatientVitalInfo()
            clearSurgeryInfo()
            loadSurgeryInfo()
        End If
    End Sub
    'DGV cell click (person)
    Private Sub dgvPerson_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPerson.CellClick
        Try
            clearPatientVitalInfo()
            clearSurgeryInfo()
            btnSave.Enabled = True
            btnUpdate.Enabled = False
            charliePapa = Nothing
            Dim romeo As Integer = Nothing
            If rbtnVitalsigns.Checked = True Then
                If dgvPerson.RowCount > 0 Then
                    romeo = dgvPerson.CurrentRow.Index
                    charlieVictor = dgvPerson.Item(0, romeo).Value
                    charliePapa = dgvPerson.Item(1, romeo).Value
                    populatePatientVitalSignsFields()
                End If
            End If
        Catch ex As Exception
            charliePapa = Nothing
            charlieVictor = Nothing
            clearPatientVitalInfo()
        End Try
    End Sub
    'DGV cell click (Surgery)
    Private Sub dgvSurgery_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSurgery.CellClick
        Try
            btnSave.Enabled = False
            btnUpdate.Enabled = True
            charlieVictor = Nothing
            Dim romeo As Integer = Nothing
            If dgvSurgery.RowCount > 0 Then
                romeo = dgvSurgery.CurrentRow.Index
                charlieVictor = dgvSurgery.Item(0, romeo).Value
                populateSuregeryFields()
            End If
        Catch
            clearPatientVitalInfo()
            clearSurgeryInfo()
            charlieVictor = Nothing
        End Try
    End Sub
    'Combo box selected value changed(doctor)
    Private Sub cmbxDoctorName_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbxDoctorName.SelectedValueChanged
        If dgvPerson.RowCount > 0 Or dgvSurgery.RowCount > 0 Then
            doctorSpecialization()
        End If
    End Sub
    'END!
    '**********************************************************************************************************
    '!COMMENT: METHODS
    ' Load person vital sign info
    Public Sub SearchPatientVitalSign()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select TV.VitalSignNo ,tp.PersonID as PatientID,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tp.AGE, tp.SEX as GENDER, " & _
                                    " tv.VS_DATE,CONCAT(tv.BODYTEMP,'-Normal:[', tv.BT_ISNORMAL,']') As BODY_TEMP, CONCAT(tv.BLOODPRESSURE,'-Normal:[', tv.BP_ISNORMAL,']') as BLOOD_PRESSURE, " & _
                                    " CONCAT(tv.RESPIRATION,'-Normal:[', tv.R_ISNORMAL,']') as RESPIRATION_RATE , CONCAT(tv.PULSERATE,'-Normal:[', tv.P_ISNORMAL,']')as PULSE_RATE , CONCAT(tv.O2SAT,'-Normal:[', tv.O2_ISNORMAL,']') as O2_SAT, tv.WEIGHT, tv.HIEGHT from tblVitalSigns as tv " & _
                                    " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Where CONCAT(tp.LASTNAME, ' ',tp.FIRSTNAME, ' ',tp.MIDDLENAME) like '' +@lname+ '%' And tv.VS_DATE = @det Order by PATIENT DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtLastname.Text)
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPerson.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'Load Person Diagnosis Info
    Public Sub SearchPatientDiagnosis()
        Dim detRange As Date = det.AddDays(-8)
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tp.PersonID as Patient_ID,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tp.AGE, tp.SEX as GENDER, " & _
                                    " td.DiagnosisID,td.D_DATE, td.DIAGNOSIS,td.TREATMENT,CONCAT(tdoc.FIRSTNAME,' ',tdoc.MIDDLENAME, ' ',tdoc.LASTNAME) as DOCTOR from tblDiagnosis as td " & _
" Inner Join tblConsulatation as tc On td.ConsultationID = tc.ConsultationID " & _
" Inner Join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
" Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
" Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
" Where CONCAT(tp.LASTNAME, ' ',tp.FIRSTNAME, ' ',tp.MIDDLENAME) like '' +@lname+ '%' And td.D_DATE >=@detrange And td.D_DATE <= @det  Order by PATIENT DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtLastname.Text)
            cmd.Parameters.AddWithValue("@detrange", detRange)
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPerson.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'Populate patient info and its vital signs taken today
    Public Sub populatePatientVitalSignsFields()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tv.VitalSignNo ,tp.PersonID as PatientID,CONCAT(tp.FIRSTNAME, ' ',tp.MIDDLENAME, ' ',tp.LASTNAME) as PATIENT, tp.AGE, tp.SEX as GENDER, " & _
                                          " tv.VS_DATE,CONCAT(tv.BODYTEMP,'-Normal:[', tv.BT_ISNORMAL,']') As BODY_TEMP, CONCAT(tv.BLOODPRESSURE,'-Normal:[', tv.BP_ISNORMAL,']') as BLOOD_PRESSURE, " & _
                                          " CONCAT(tv.RESPIRATION,'-Normal:[', tv.R_ISNORMAL,']') as RESPIRATION_RATE , CONCAT(tv.PULSERATE,'-Normal:[', tv.P_ISNORMAL,']')as PULSE_RATE , CONCAT(tv.O2SAT,'-Normal:[', tv.O2_ISNORMAL,']') as O2_SAT, tv.WEIGHT, tv.HIEGHT from tblVitalSigns as tv " & _
                                          " Inner Join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                          " Where tv.VitalSignNo = @charlievictor ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@charlievictor", charlieVictor)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtPatientName.Text = dt.Rows(0).Item("PATIENT")
                txtAge.Text = dt.Rows(0).Item("AGE")
                txtGender.Text = dt.Rows(0).Item("GENDER")
                txtBP.Text = dt.Rows(0).Item("BLOOD_PRESSURE")
                txtRespiration.Text = dt.Rows(0).Item("RESPIRATION_RATE")
                txtPR.Text = dt.Rows(0).Item("PULSE_RATE")
                txtO2sata.Text = dt.Rows(0).Item("O2_SAT")
                txtBT.Text = dt.Rows(0).Item("BODY_TEMP")
                txtHeight.Text = dt.Rows(0).Item("HIEGHT")
                txtWeight.Text = dt.Rows(0).Item("WEIGHT")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'Load doctor info
    Public Sub loadDoctorInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select DoctorID, CONCAT(FIRSTNAME,' ', MIDDLENAME,' ', LASTNAME) as DOCTOR from tblDoctor;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            cmbxDoctorName.DataSource = Nothing
            cmbxDoctorName.DataSource = dt
            cmbxDoctorName.DisplayMember = "DOCTOR"
            cmbxDoctorName.ValueMember = "DoctorID"
            db.pubSqlCon.Close()
            da.Dispose()
            cmbxDoctorName.SelectedIndex = -1
        End Using
    End Sub
    'Populate doctor specialization
    Public Sub doctorSpecialization()
        Dim selectedItem As DataRowView = cmbxDoctorName.SelectedItem
        Dim id As String = selectedItem("DoctorID")
        charlieDelta = id
        '
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select DoctorID,SPECIALIZATION from tblDoctor where  DoctorID=@doctorid ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@doctorid", id)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtSpecialization.Text = dt.Rows(0).Item("SPECIALIZATION")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'Clear Patient vital signs
    Public Sub clearPatientVitalInfo()
        txtPatientName.Text = ""
        txtAge.Text = ""
        txtGender.Text = ""
        txtBT.Text = ""
        txtBP.Text = ""
        txtPR.Text = ""
        txtO2sata.Text = ""
        txtRespiration.Text = ""
        txtHeight.Text = ""
        txtWeight.Text = ""
        txtSpecialization.Text = ""
        charliePapa = Nothing
    End Sub
    'Clear patient's surgery info
    Public Sub clearSurgeryInfo()
        txtRoomName.Text = ""
        txttypeSurgery.Text = ""
        txtRemarks.Text = ""
        txtOptPerformed.Text = ""
        txtPreOptDiagnosis.Text = ""
        txtPostOptDiagnosis.Text = ""
        txtOptPerformed.Text = ""
        txtProcedureDetail.Text = ""
        cmbxHrStartOpt.SelectedIndex = -1
        cmbxMntStartOpt.SelectedIndex = -1
        cmbxHrEndOpt.SelectedIndex = -1
        cmbxMntEndOpt.SelectedIndex = -1
        charlieVictor = Nothing
    End Sub
    'Load surgery info
    Public Sub loadSurgeryInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select top 10  ts.VitalSignsID,ts.Surgeryno, ts.DATEOFSURGERY as DATE, CONCAT(tp.FIRSTNAME,' ',tp.MIDDLENAME,' ', tp.LASTNAME) as PATIENT,ts.ROOM,ts.TYPEOFSURGERY,ts.OPRTN_STARTED,ts.OPRTN_ENDED,ts.PRE_OPRTN_DIAGNOSIS,ts.POST_OPRTN_DIAGNOSIS,ts.REMARKS, CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME,' ', tdoc.LASTNAME) as DOCTOR from tblSurgery as ts " & _
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
    End Sub '//green code
    'Load surgery info using lastname
    Public Sub searchPatientSurgery()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select  ts.VitalSignsID,ts.Surgeryno, ts.DATEOFSURGERY as DATE, CONCAT(tp.FIRSTNAME,' ',tp.MIDDLENAME,' ', tp.LASTNAME) as PATIENT,ts.ROOM,ts.TYPEOFSURGERY,ts.OPRTN_STARTED,ts.OPRTN_ENDED,ts.PRE_OPRTN_DIAGNOSIS,ts.POST_OPRTN_DIAGNOSIS,ts.REMARKS, CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME,' ', tdoc.LASTNAME) as DOCTOR from tblSurgery as ts " & _
" Inner join tblDoctor as tdoc On ts.DoctorID = tdoc.DoctorID " & _
" Inner Join tblVitalSigns as tv On ts.VitalSignsID = tv.VitalSignNo " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID " & _
" Where CONCAT(tp.LASTNAME, ' ',tp.FIRSTNAME,' ',tp.MIDDLENAME) like '' +@lname+ '%' Order by PATIENT DESC;", db.pubSqlCon)
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
    End Sub '//green code
    'Populate patient surgery info to fields
    Public Sub populateSuregeryFields()
        Dim db As New KonekDB
        Dim startOfOpt As String = Nothing
        Dim EndOfOpt As String = Nothing
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select  ts.VitalSignsID,ts.Surgeryno, ts.DATEOFSURGERY as DATE, CONCAT(tp.FIRSTNAME,' ',tp.MIDDLENAME,' ', tp.LASTNAME) as PATIENT, tp.AGE, tp.SEX as GENDER,ts.ROOM,ts.TYPEOFSURGERY,ts.OPRTN_STARTED,ts.OPRTN_ENDED,ts.PRE_OPRTN_DIAGNOSIS,ts.POST_OPRTN_DIAGNOSIS,ts.OPRTN_PERFORMED,ts.PRCDURE_IN_DETAIL, ts.REMARKS, " & _
" CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME,' ', tdoc.LASTNAME) as DOCTOR, tdoc.SPECIALIZATION, " & _
" CONCAT(tv.BODYTEMP,'-Normal:[', tv.BT_ISNORMAL,']') As BODY_TEMP, CONCAT(tv.BLOODPRESSURE,'-Normal:[', tv.BP_ISNORMAL,']') as BLOOD_PRESSURE, " & _
" CONCAT(tv.RESPIRATION,'-Normal:[', tv.R_ISNORMAL,']') as RESPIRATION_RATE , CONCAT(tv.PULSERATE,'-Normal:[', tv.P_ISNORMAL,']')as PULSE_RATE , CONCAT(tv.O2SAT,'-Normal:[', tv.O2_ISNORMAL,']') as O2_SAT, tv.WEIGHT, tv.HIEGHT from tblSurgery as ts  " & _
" Inner join tblDoctor as tdoc On ts.DoctorID = tdoc.DoctorID " & _
" Inner Join tblVitalSigns as tv On ts.VitalSignsID = tv.VitalSignNo  " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID Where ts.VitalSignsID=@vitalsignno", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@vitalsignno", charlieVictor)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                detofSurgery = dt.Rows(0).Item("DATE")
                txtPatientName.Text = dt.Rows(0).Item("PATIENT")
                txtAge.Text = dt.Rows(0).Item("AGE")
                txtGender.Text = dt.Rows(0).Item("GENDER")
                txtBT.Text = dt.Rows(0).Item("BODY_TEMP")
                txtBP.Text = dt.Rows(0).Item("BLOOD_PRESSURE")
                txtPR.Text = dt.Rows(0).Item("PULSE_RATE")
                txtO2sata.Text = dt.Rows(0).Item("O2_SAT")
                txtRespiration.Text = dt.Rows(0).Item("RESPIRATION_RATE")
                txtHeight.Text = dt.Rows(0).Item("HIEGHT")
                txtWeight.Text = dt.Rows(0).Item("WEIGHT")
                txtSpecialization.Text = dt.Rows(0).Item("SPECIALIZATION")
                cmbxDoctorName.Text = dt.Rows(0).Item("DOCTOR")
                '
                txtRoomName.Text = dt.Rows(0).Item("ROOM")
                txttypeSurgery.Text = dt.Rows(0).Item("TYPEOFSURGERY")
                txtRemarks.Text = dt.Rows(0).Item("REMARKS")
                txtOptPerformed.Text = dt.Rows(0).Item("OPRTN_PERFORMED")
                txtPreOptDiagnosis.Text = dt.Rows(0).Item("PRE_OPRTN_DIAGNOSIS")
                txtPostOptDiagnosis.Text = dt.Rows(0).Item("POST_OPRTN_DIAGNOSIS")
                txtOptPerformed.Text = dt.Rows(0).Item("OPRTN_PERFORMED")
                txtProcedureDetail.Text = dt.Rows(0).Item("PRCDURE_IN_DETAIL")
                startOfOpt = dt.Rows(0).Item("OPRTN_STARTED").ToString()
                EndOfOpt = dt.Rows(0).Item("OPRTN_ENDED").ToString()
                '
                cmbxHrStartOpt.Text = startOfOpt.Substring(0, 2).ToString()
                cmbxMntStartOpt.Text = startOfOpt.Substring(3, 2).ToString()
                cmbxHrEndOpt.Text = EndOfOpt.Substring(0, 2).ToString()
                cmbxMntEndOpt.Text = EndOfOpt.Substring(3, 2).ToString()
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub '//green code
    'Update 
    Public Sub updateSurgeryInfo()
        Dim bolpatientName As Boolean = isEmpty(txtPatientName)
        Dim bolAge As Boolean = isEmpty(txtAge)
        Dim bolgender As Boolean = isEmpty(txtGender)
        Dim bolbt As Boolean = isEmpty(txtBT)
        Dim bolbp As Boolean = isEmpty(txtBP)
        Dim bolpr As Boolean = isEmpty(txtPR)
        Dim bolo2sat As Boolean = isEmpty(txtO2sata)
        Dim bolrespRate As Boolean = isEmpty(txtRespiration)
        Dim bolheight As Boolean = isEmpty(txtHeight)
        Dim bolWeight As Boolean = isEmpty(txtWeight)
        Dim bolSpecialization As Boolean = isEmpty(txtSpecialization)
        '
        Dim bolroom As Boolean = isEmpty(txtRoomName)
        Dim bolseverity As Boolean = isEmpty(txttypeSurgery)
        Dim bolremarks As Boolean = isEmpty(txtRemarks)
        Dim boloptPerformed As Boolean = isEmpty(txtOptPerformed)
        Dim bolPreoptDiagnosis As Boolean = isEmpty(txtPreOptDiagnosis)
        Dim bolPostoptDiagnosis As Boolean = isEmpty(txtPostOptDiagnosis)
        Dim bolprocedureInDetails As Boolean = isEmpty(txtProcedureDetail)
        '
        If charlieVictor <> 0 Then
            If det = detofSurgery Then
                If cmbxHrStartOpt.Text = "" Then
                    msgbBoxShw()
                ElseIf cmbxMntStartOpt.Text = "" Then
                    msgbBoxShw()
                ElseIf cmbxHrEndOpt.Text = "" Then
                    msgbBoxShw()
                ElseIf cmbxMntEndOpt.Text = "" Then
                    msgbBoxShw()
                ElseIf bolpatientName Then
                    msgbBoxShw()
                Else
                    If bolpatientName Then
                        msgbBoxShw()
                    ElseIf bolAge Then
                        msgbBoxShw()
                    ElseIf bolgender Then
                        msgbBoxShw()
                    ElseIf bolbt Then
                        msgbBoxShw()
                    ElseIf bolbp Then
                        msgbBoxShw()
                    ElseIf bolpr Then
                        msgbBoxShw()
                    ElseIf bolo2sat Then
                        msgbBoxShw()
                    ElseIf bolrespRate Then
                        msgbBoxShw()
                    ElseIf bolheight Then
                        msgbBoxShw()
                    ElseIf bolWeight Then
                        msgbBoxShw()
                    ElseIf bolSpecialization Then
                        msgbBoxShw()
                    ElseIf bolroom Then
                        msgbBoxShw()
                    ElseIf bolseverity Then
                        msgbBoxShw()
                    ElseIf bolremarks Then
                        msgbBoxShw()
                    ElseIf boloptPerformed Then
                        msgbBoxShw()
                    ElseIf bolPreoptDiagnosis Then
                        msgbBoxShw()
                    ElseIf bolPostoptDiagnosis Then
                        msgbBoxShw()
                    ElseIf bolprocedureInDetails Then
                        msgbBoxShw()
                    Else
                        Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to updated this record.", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If answer = Windows.Forms.DialogResult.Yes Then
                            '
                            captureUAupdate()
                            commandUpdate()
                        Else
                            'If user chose "NO", exit this method
                            Exit Sub
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Security error! You may only update records that has the date today.", "Warning! duplicate records...", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub
    '
    Public Sub commandUpdate()
        Dim strtime As String = cmbxHrStartOpt.Text + ":" + cmbxMntStartOpt.Text
        Dim starttym As TimeSpan = TimeSpan.Parse(strtime)
        '
        Dim endtime As String = cmbxHrEndOpt.Text + ":" + cmbxMntEndOpt.Text
        Dim endtym As TimeSpan = TimeSpan.Parse(endtime)
        '
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Update tblSurgery Set DoctorID=@doctorid,ROOM=@room,TYPEOFSURGERY=@typeofSurgery,OPRTN_STARTED=@started,OPRTN_ENDED=@ended,PRE_OPRTN_DIAGNOSIS=@pre,POST_OPRTN_DIAGNOSIS=@post,OPRTN_PERFORMED=@performedOpt,PRCDURE_IN_DETAIL=@precedure,REMARKS=@remarks " & _
" Where VitalSignsID=@vitalsignsno;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@vitalsignsno", charlieVictor)
            cmd.Parameters.AddWithValue("@doctorid", charlieDelta)
            cmd.Parameters.AddWithValue("@room", txtRoomName.Text)
            cmd.Parameters.AddWithValue("@typeofSurgery", txttypeSurgery.Text)
            cmd.Parameters.AddWithValue("@started", starttym)
            cmd.Parameters.AddWithValue("@ended", endtym)
            cmd.Parameters.AddWithValue("@pre", txtPreOptDiagnosis.Text)
            cmd.Parameters.AddWithValue("@post", txtPostOptDiagnosis.Text)
            '
            cmd.Parameters.AddWithValue("@performedOpt", txtOptPerformed.Text)
            cmd.Parameters.AddWithValue("@precedure", txtProcedureDetail.Text)
            cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text)
            '
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            MsgBox("Update successful!")
            loadupdatedSurgeryInfo()
        End Using
    End Sub
    'Load updated suregry
    Public Sub loadupdatedSurgeryInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ts.VitalSignsID,ts.Surgeryno, ts.DATEOFSURGERY as DATE, CONCAT(tp.FIRSTNAME,' ',tp.MIDDLENAME,' ', tp.LASTNAME) as PATIENT,ts.ROOM,ts.TYPEOFSURGERY,ts.OPRTN_STARTED,ts.OPRTN_ENDED,ts.PRE_OPRTN_DIAGNOSIS,ts.POST_OPRTN_DIAGNOSIS,ts.REMARKS, CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME,' ', tdoc.LASTNAME) as DOCTOR from tblSurgery as ts " & _
" Inner join tblDoctor as tdoc On ts.DoctorID = tdoc.DoctorID " & _
" Inner Join tblVitalSigns as tv On ts.VitalSignsID = tv.VitalSignNo " & _
" Inner join tblPerson as tp On tv.PersonID = tp.PersonID " & _
" Where ts.VitalSignsID = @vitalsignsno;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@vitalsignsno", charlieVictor)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvSurgery.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            clearPatientVitalInfo()
            clearSurgeryInfo()
        End Using
    End Sub
    'Check for existing records
    Public Sub checkIfHasrecords()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select VitalSignsID from tblSurgery where VitalSignsID = @vitalsignsid; ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@vitalsignsid", charlieVictor)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                hasrecord = True
            Else
                hasrecord = False
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'Save
    Public Sub saveNewSurgeryInfo()
        Dim bolpatientName As Boolean = isEmpty(txtPatientName)
        Dim bolAge As Boolean = isEmpty(txtAge)
        Dim bolgender As Boolean = isEmpty(txtGender)
        Dim bolbt As Boolean = isEmpty(txtBT)
        Dim bolbp As Boolean = isEmpty(txtBP)
        Dim bolpr As Boolean = isEmpty(txtPR)
        Dim bolo2sat As Boolean = isEmpty(txtO2sata)
        Dim bolrespRate As Boolean = isEmpty(txtRespiration)
        Dim bolheight As Boolean = isEmpty(txtHeight)
        Dim bolWeight As Boolean = isEmpty(txtWeight)
        Dim bolSpecialization As Boolean = isEmpty(txtSpecialization)
        '
        Dim bolroom As Boolean = isEmpty(txtRoomName)
        Dim bolseverity As Boolean = isEmpty(txttypeSurgery)
        Dim bolremarks As Boolean = isEmpty(txtRemarks)
        Dim boloptPerformed As Boolean = isEmpty(txtOptPerformed)
        Dim bolPreoptDiagnosis As Boolean = isEmpty(txtPreOptDiagnosis)
        Dim bolPostoptDiagnosis As Boolean = isEmpty(txtPostOptDiagnosis)
        Dim bolprocedureInDetails As Boolean = isEmpty(txtProcedureDetail)
        '
        If charlieVictor <> 0 Then
            checkIfHasrecords() ' checj if there is an existing record. Otherwise, proceed.
            If hasrecord = False Then
                If cmbxHrStartOpt.Text = "" Then
                    msgbBoxShw()
                ElseIf cmbxMntStartOpt.Text = "" Then
                    msgbBoxShw()
                ElseIf cmbxHrEndOpt.Text = "" Then
                    msgbBoxShw()
                ElseIf cmbxMntEndOpt.Text = "" Then
                    msgbBoxShw()
                ElseIf bolpatientName Then
                    msgbBoxShw()
                Else
                    If bolpatientName Then
                        msgbBoxShw()
                    ElseIf bolAge Then
                        msgbBoxShw()
                    ElseIf bolgender Then
                        msgbBoxShw()
                    ElseIf bolbt Then
                        msgbBoxShw()
                    ElseIf bolbp Then
                        msgbBoxShw()
                    ElseIf bolpr Then
                        msgbBoxShw()
                    ElseIf bolo2sat Then
                        msgbBoxShw()
                    ElseIf bolrespRate Then
                        msgbBoxShw()
                    ElseIf bolheight Then
                        msgbBoxShw()
                    ElseIf bolWeight Then
                        msgbBoxShw()
                    ElseIf bolSpecialization Then
                        msgbBoxShw()
                    ElseIf bolroom Then
                        msgbBoxShw()
                    ElseIf bolseverity Then
                        msgbBoxShw()
                    ElseIf bolremarks Then
                        msgbBoxShw()
                    ElseIf boloptPerformed Then
                        msgbBoxShw()
                    ElseIf bolPreoptDiagnosis Then
                        msgbBoxShw()
                    ElseIf bolPostoptDiagnosis Then
                        msgbBoxShw()
                    ElseIf bolprocedureInDetails Then
                        msgbBoxShw()
                    Else
                        captureUAsave()
                        commandSave()
                    End If
                End If
            Else
                MsgBox("Security error! This has already been recorded. Please select a unique record", MsgBoxStyle.Exclamation)
                'Duplicate record.Exit
                Exit Sub
            End If
        End If
    End Sub
    '
    Public Sub commandSave()
        Dim strtime As String = cmbxHrStartOpt.Text + ":" + cmbxMntStartOpt.Text
        Dim starttym As TimeSpan = TimeSpan.Parse(strtime)
        '
        Dim endtime As String = cmbxHrEndOpt.Text + ":" + cmbxMntEndOpt.Text
        Dim endtym As TimeSpan = TimeSpan.Parse(endtime)
        '
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Insert into tblSurgery (VitalSignsID,DoctorID,ROOM,DATEOFSURGERY,TYPEOFSURGERY,OPRTN_STARTED,OPRTN_ENDED,PRE_OPRTN_DIAGNOSIS,POST_OPRTN_DIAGNOSIS,OPRTN_PERFORMED,PRCDURE_IN_DETAIL,REMARKS) values (@vitalsignno,@doctorid,@room,@date,@type,@started,@ended,@pre,@post,@performed,@procedure,@remarks);", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@vitalsignno", SqlDbType.Int).Value = charlieVictor
            cmd.Parameters.Add("@doctorid", SqlDbType.Int).Value = charlieDelta
            cmd.Parameters.Add("@room", SqlDbType.VarChar).Value = txtRoomName.Text
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = det
            cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = txttypeSurgery.Text
            '
            cmd.Parameters.Add("@started", SqlDbType.Time).Value = starttym
            cmd.Parameters.Add("@ended", SqlDbType.Time).Value = endtym
            '
            cmd.Parameters.Add("@pre", SqlDbType.VarChar).Value = txtPreOptDiagnosis.Text
            cmd.Parameters.Add("@post", SqlDbType.VarChar).Value = txtPostOptDiagnosis.Text
            cmd.Parameters.Add("@performed", SqlDbType.VarChar).Value = txtOptPerformed.Text
            cmd.Parameters.Add("@procedure", SqlDbType.VarChar).Value = txtProcedureDetail.Text
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar).Value = txtRemarks.Text
            cmd.ExecuteNonQuery()
            MsgBox("New record added!")
            loadupdatedSurgeryInfo()
        End Using
    End Sub
    'Is field empty
    Public Function isEmpty(ByVal txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
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
        intrfce = "Add Surgery"
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
    Public Sub captureUAsave()
        intrfce = "Add Surgery"
        btn = "Save"
        actn = "Add new record of surgery of patient " & txtPatientName.Text & "."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAupdate()
        intrfce = "Add Surgery"
        btn = "Update"
        actn = "Update new record of surgery of patient " & txtPatientName.Text & "."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAview()
        intrfce = "Add Surgery"
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
    '**********************************************************************************************************
End Class