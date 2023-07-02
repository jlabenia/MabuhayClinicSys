Imports System.Data.SqlClient
Public Class AdminPatientRecords
    '!COMMENT: PRIVATE VARIABLES
    Dim charlie As Integer = Nothing
    Dim totalrecords As Integer = Nothing 'refer to method  checkDateRangedPreDelete()
    Dim hasAppointment As Boolean = Nothing
    Dim hasVitalSigns As Boolean = Nothing
    Dim hasConsultation As Boolean = Nothing
    Dim hasSurgery As Boolean = Nothing
    Dim hasDiagnosis As Boolean = Nothing
    Dim hasTestResults As Boolean = Nothing
    Dim hasRecords As Boolean = Nothing ' Check if there is records to be deleted. Proceed if YES otherwise do nothing
    'END!
    '***************************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim bolFname As Boolean = IstxtEmpty(txtFname)
        Dim bolMname As Boolean = IstxtEmpty(txtMname)
        Dim bollname As Boolean = IstxtEmpty(txtLname)
        Dim bolContact As Boolean = IstxtEmpty(txtContactNo)
        Dim bolAge As Boolean = IstxtEmpty(txtAge)
        Dim bolBrgy As Boolean = IstxtEmpty(txtBarangay)
        Dim bolMuncipality As Boolean = IstxtEmpty(txtMunicipality)
        Dim bolProvince As Boolean = IstxtEmpty(txtProvince)
        '
        Dim bolgender As Boolean = IscmbxEmpty(cmbxGender)
        Dim bolDOBday As Boolean = IscmbxEmpty(cmbxDOBday)
        Dim bolDOBmonth As Boolean = IscmbxEmpty(cmbxDOBmonth)
        Dim bolDOByear As Boolean = IscmbxEmpty(cmbxDOByear)
        '
        If bolFname Then
            msgbBoxShw()
        ElseIf bolMname Then
            msgbBoxShw()
        ElseIf bollname Then
            msgbBoxShw()
        ElseIf bolContact Then
            msgbBoxShw()
        ElseIf bolAge Then
            msgbBoxShw()
        ElseIf bolBrgy Then
            msgbBoxShw()
        ElseIf bolMuncipality Then
            msgbBoxShw()
        ElseIf bolProvince Then
            msgbBoxShw()
        ElseIf bolgender Then
            msgbBoxShw()
        ElseIf bolDOBday Then
            msgbBoxShw()
        ElseIf bolDOBmonth Then
            msgbBoxShw()
        ElseIf bolDOByear Then
            msgbBoxShw()
        Else
            saveNewRecord()
            clearFields()
            loadNewRecord()
        End If
    End Sub
    '
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearFields()
        loadPersonInfo()
        charlie = Nothing
    End Sub
    '
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim bolPatientID As Boolean = IstxtEmpty(txtPatientID)
        Dim bolFname As Boolean = IstxtEmpty(txtFname)
        Dim bolMname As Boolean = IstxtEmpty(txtMname)
        Dim bollname As Boolean = IstxtEmpty(txtLname)
        Dim bolContact As Boolean = IstxtEmpty(txtContactNo)
        Dim bolAge As Boolean = IstxtEmpty(txtAge)
        Dim bolBrgy As Boolean = IstxtEmpty(txtBarangay)
        Dim bolMuncipality As Boolean = IstxtEmpty(txtMunicipality)
        Dim bolProvince As Boolean = IstxtEmpty(txtProvince)
        '
        Dim bolgender As Boolean = IscmbxEmpty(cmbxGender)
        Dim bolDOBday As Boolean = IscmbxEmpty(cmbxDOBday)
        Dim bolDOBmonth As Boolean = IscmbxEmpty(cmbxDOBmonth)
        Dim bolDOByear As Boolean = IscmbxEmpty(cmbxDOByear)
        '
        If bolPatientID Then
            msgbBoxShw()
        ElseIf bolFname Then
            msgbBoxShw()
        ElseIf bolMname Then
            msgbBoxShw()
        ElseIf bollname Then
            msgbBoxShw()
        ElseIf bolContact Then
            msgbBoxShw()
        ElseIf bolAge Then
            msgbBoxShw()
            msgbBoxShw()
        ElseIf bolBrgy Then
            msgbBoxShw()
        ElseIf bolMuncipality Then
            msgbBoxShw()
        ElseIf bolProvince Then
            msgbBoxShw()
        ElseIf bolgender Then
            msgbBoxShw()
        ElseIf bolDOBday Then
            msgbBoxShw()
        ElseIf bolDOBmonth Then
            msgbBoxShw()
        ElseIf bolDOByear Then
            msgbBoxShw()
        Else
            Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to update this record.", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.Yes Then
                updateRecord()
                loadUpdatedRecord()
                clearFields()
            Else
                Exit Sub
            End If
        End If
    End Sub
    '
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Me.Close()
        AdminDashboard.load_ViewPatient()
    End Sub
    '
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        commandDelete()
    End Sub
    'END!
    '***************************************************************************************
    '!COMMENT: EVENTS
    Private Sub AdminPatientRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPersonInfo()
        loadDOByear()
    End Sub
    '
    Private Sub txtSearchLname_TextChanged(sender As Object, e As EventArgs) Handles txtSearchLname.TextChanged
        rbtnPatientInfo.Checked = True
        If txtSearchLname.Text <> "" Then
            searchPersonByLastname()
        Else
            clearFields()
            loadPersonInfo()
        End If
    End Sub
    '
    Private Sub cmbxDOByear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxDOByear.SelectedIndexChanged
        Dim yrToday As Integer = CInt(Year(Now))
        Dim age As Integer = 0
        Dim brthYear As Integer = 0
        '
        If cmbxDOByear.Text <> "" Then
            brthYear = CInt(cmbxDOByear.Text)
            age = yrToday - brthYear
            txtAge.Text = age.ToString()
        Else
            txtAge.Text = ""
        End If
    End Sub
    '
    Private Sub RadioButtons_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTestResults.CheckedChanged, rbtnSurgery.CheckedChanged, rbtnPatientInfo.CheckedChanged, rbtnDiagnosis.CheckedChanged, rbtnConsultation.CheckedChanged, rbtnAppointment.CheckedChanged, rbtnVitalSigns.CheckedChanged
        '
        If rbtnAppointment.Checked = True Then
            If txtPatientID.Text <> "" Then
                searchAppointmentByPersonID()
            End If
        ElseIf rbtnVitalSigns.Checked = True Then
            If txtPatientID.Text <> "" Then
                searchVitalSignsBypersonID()
            End If
        ElseIf rbtnSurgery.Checked = True Then
            If txtPatientID.Text <> "" Then
                searchSurgeryByPersonID()
            End If
        ElseIf rbtnConsultation.Checked = True Then
            If txtPatientID.Text <> "" Then
                searchConsultationByPersonID()
            End If
        ElseIf rbtnDiagnosis.Checked = True Then
            If txtPatientID.Text <> "" Then
                searchDiagnosisByPersonID()
            End If
        ElseIf rbtnTestResults.Checked = True Then
            If txtPatientID.Text <> "" Then
                searchTestResultByPersonID()
            End If
        End If
        '
        If rbtnPatientInfo.Checked = True Then
            If txtPatientID.Text <> "" Then
                searchPersonByPersonID()
            End If
        End If
    End Sub
    '
    Private Sub rbtnSelectedDet_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSelectedDet.CheckedChanged
        charlie = Nothing
        txtSearchLname.Text = ""
        clearFields()
    End Sub
    '
    Private Sub LettersOnly(sender As Object, e As KeyPressEventArgs) Handles txtSearchLname.KeyPress, txtProvince.KeyPress, txtMunicipality.KeyPress, txtMname.KeyPress, txtLname.KeyPress, txtFname.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> " " And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub NumbersOnly(sender As Object, e As KeyPressEventArgs) Handles txtContactNo.KeyPress
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub dgvPatientRecords_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPatientRecords.CellClick
        Try
            Dim romeo As Integer = Nothing
            charlie = Nothing
            rbtnSelectedItem.Checked = True
            If dgvPatientRecords.RowCount > 0 Then
                romeo = dgvPatientRecords.CurrentRow.Index
                charlie = dgvPatientRecords.Item(0, romeo).Value
                If rbtnPatientInfo.Checked = True Then
                    btnAdd.Enabled = False
                    btnUpdate.Enabled = True
                    populateFields()
                End If
            End If
        Catch
            clearFields()
            charlie = Nothing
        End Try
    End Sub
    '
    Private Sub AdminPatientRecords_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadManageClinic()
    End Sub
    'END!
    '***************************************************************************************
    '!COMMENT: METHODS
    '
    Public Sub loadDOByear()
        Dim yearNow As Integer = CInt(Year(Today))
        For i As Integer = 1923 To yearNow
            cmbxDOByear.Items.Add(i)
        Next
    End Sub
    '
    Public Sub clearFields()
        btnAdd.Enabled = True
        btnUpdate.Enabled = False
        rbtnPatientInfo.Checked = True
        txtPatientID.Text = ""
        txtFname.Text = ""
        txtLname.Text = ""
        txtMname.Text = ""
        txtContactNo.Text = ""
        txtAge.Text = ""
        txtBarangay.Text = ""
        txtMunicipality.Text = ""
        txtProvince.Text = ""
        txtSearchLname.Text = ""
        cmbxGender.SelectedIndex = -1
        cmbxDOBday.SelectedIndex = -1
        cmbxDOBmonth.SelectedIndex = -1
        cmbxDOByear.SelectedIndex = -1
    End Sub
    '
    Public Sub loadPersonInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select top 100 PersonID as PatientID,CONCAT(FIRSTNAME, ' ',MIDDLENAME, ' ',LASTNAME) as FULLNAME,CONCAT(DAY,'-',MONTH,'-',YEAR) as BIRTHDATE,AGE, SEX as GENDER,CONTACTNO, CONCAT(BARANGAY, ', ',MUNICIPALITY, ' ',PROVINCE) as ADDRESS from tblPerson order by PersonID DESC;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientRecords.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub populateFields()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select PersonID,FIRSTNAME, MIDDLENAME,LASTNAME,DAY,MONTH,YEAR,AGE, SEX,CONTACTNO, BARANGAY,MUNICIPALITY,PROVINCE from tblPerson where PersonID=@personid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtPatientID.Text = dt.Rows(0).Item("PersonID")
                txtFname.Text = dt.Rows(0).Item("FIRSTNAME")
                txtLname.Text = dt.Rows(0).Item("LASTNAME")
                txtMname.Text = dt.Rows(0).Item("MIDDLENAME")
                txtContactNo.Text = dt.Rows(0).Item("CONTACTNO")
                txtAge.Text = dt.Rows(0).Item("AGE")
                txtBarangay.Text = dt.Rows(0).Item("BARANGAY")
                txtMunicipality.Text = dt.Rows(0).Item("MUNICIPALITY")
                txtProvince.Text = dt.Rows(0).Item("PROVINCE")

                cmbxGender.Text = dt.Rows(0).Item("SEX")
                cmbxDOBday.Text = dt.Rows(0).Item("DAY")
                cmbxDOBmonth.Text = dt.Rows(0).Item("MONTH")
                cmbxDOByear.Text = dt.Rows(0).Item("YEAR")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub updateRecord()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Update tblPerson set FIRSTNAME=@fname, MIDDLENAME=@mname,LASTNAME=@lname,DAY=@day,MONTH=@month,YEAR=@year,AGE=@age, SEX=@sex,CONTACTNO=@contactno, BARANGAY=@brgy,MUNICIPALITY=@municipality,PROVINCE=@province where PersonID=@personid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@fname", txtFname.Text)
            cmd.Parameters.AddWithValue("@mname", txtMname.Text)
            cmd.Parameters.AddWithValue("@lname", txtLname.Text)
            cmd.Parameters.AddWithValue("@day", cmbxDOBday.Text)
            cmd.Parameters.AddWithValue("@month", cmbxDOBmonth.Text)
            cmd.Parameters.AddWithValue("@year", cmbxDOByear.Text)
            cmd.Parameters.AddWithValue("@age", txtAge.Text)
            cmd.Parameters.AddWithValue("@sex", cmbxGender.Text)
            cmd.Parameters.AddWithValue("@contactno", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@brgy", txtBarangay.Text)
            cmd.Parameters.AddWithValue("@municipality", txtMunicipality.Text)
            cmd.Parameters.AddWithValue("@province", txtProvince.Text)
            cmd.Parameters.AddWithValue("@personid", charlie)
            cmd.ExecuteNonQuery()
            MsgBox("Update successful!")
        End Using
    End Sub
    '
    Public Sub loadUpdatedRecord()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select PersonID as PatientID,CONCAT(FIRSTNAME, ' ',MIDDLENAME, ' ',LASTNAME) as FULLNAME,CONCAT(DAY,'-',MONTH,'-',YEAR) as BIRTHDATE,AGE, SEX as GENDER,CONTACTNO, CONCAT(BARANGAY, ', ',MUNICIPALITY, ' ',PROVINCE) as ADDRESS from tblPerson where PersonID=@personid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientRecords.DataSource = dt
            charlie = Nothing
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub saveNewRecord()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Insert into tblPerson (FIRSTNAME,MIDDLENAME,LASTNAME,AGE,DAY ,MONTH,YEAR,SEX,CONTACTNO,BARANGAY,MUNICIPALITY,PROVINCE) values (@fname,@mname,@lname,@age,@day,@month,@year,@sex,@contactno,@brgy,@municipality,@province);", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@fname", SqlDbType.Text).Value = txtFname.Text
            cmd.Parameters.Add("@mname", SqlDbType.Text).Value = txtMname.Text
            cmd.Parameters.Add("@lname", SqlDbType.Text).Value = txtLname.Text
            cmd.Parameters.Add("@age", SqlDbType.Int).Value = txtAge.Text
            cmd.Parameters.Add("@day", SqlDbType.Int).Value = cmbxDOBday.Text
            cmd.Parameters.Add("@month", SqlDbType.VarChar).Value = cmbxDOBmonth.Text
            cmd.Parameters.Add("@year", SqlDbType.Int).Value = cmbxDOByear.Text
            cmd.Parameters.Add("@sex", SqlDbType.VarChar).Value = cmbxGender.Text
            cmd.Parameters.Add("@contactno", SqlDbType.VarChar).Value = txtContactNo.Text
            cmd.Parameters.Add("@brgy", SqlDbType.Text).Value = "Brgy. " & txtBarangay.Text
            cmd.Parameters.Add("@municipality", SqlDbType.Text).Value = txtMunicipality.Text
            cmd.Parameters.Add("@province", SqlDbType.Text).Value = txtProvince.Text
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("New record added!")
        End Using
    End Sub
    '
    Public Sub loadNewRecord()
        Dim personid As Integer = Nothing
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Get current person id
        Using da As New SqlDataAdapter("Select MAX(PersonID) as id from tblPerson;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                personid = dt.Rows(0).Item("id")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
        'load new records
        Using cmd As New SqlCommand("Select PersonID as PatientID,CONCAT(FIRSTNAME, ' ',MIDDLENAME, ' ',LASTNAME) as FULLNAME,CONCAT(DAY,'-',MONTH,'-',YEAR) as BIRTHDATE,AGE, SEX as GENDER,CONTACTNO, CONCAT(BARANGAY, ', ',MUNICIPALITY, ' ',PROVINCE) as ADDRESS from tblPerson where PersonID=@personid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", personid)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientRecords.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchAppointmentByPersonID()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select PersonID as PatientID,AppointmentID,TOKEN,A_DATE,A_TIME,NOTE from tblAppointment where PersonID=@personid order by A_DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", txtPatientID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientRecords.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchVitalSignsBypersonID()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select PersonID as PatientID,VitalSignNo,VS_DATE as DATE,STATUS,CONCAT(BODYTEMP,' - [Normal: ',BT_ISNORMAL,']') as BODY_TEMP, CONCAT(BLOODPRESSURE,' - [Normal: ',BP_ISNORMAL,']') AS BLOOD_PRESSURE, CONCAT(RESPIRATION,' - [Normal: ',R_ISNORMAL,']') as RESPIRATION_RATE, CONCAT(PULSERATE,' - [Normal: ',P_ISNORMAL,']') as PULSERATE, CONCAT(O2SAT,' - [Normal: ',O2_ISNORMAL,']') as O2_SAT, WEIGHT, HIEGHT  from tblVitalSigns " & _
                                    " Where PersonID = @personid order by DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", txtPatientID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientRecords.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchSurgeryByPersonID()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tp.PersonID as PatientID,ts.SurgeryNo,tv.VitalSignNo,CONCAT(tdoc.FIRSTNAME,' ',tdoc.MIDDLENAME,' ', tdoc.LASTNAME) as DOCTOR, ts.ROOM, ts.DATEOFSURGERY, ts.TYPEOFSURGERY, ts.OPRTN_STARTED,ts.OPRTN_ENDED,ts.PRE_OPRTN_DIAGNOSIS,ts.POST_OPRTN_DIAGNOSIS,ts.OPRTN_PERFORMED,ts.PRCDURE_IN_DETAIL,ts.REMARKS from tblSurgery as ts " & _
                                    " Inner join tblVitalSigns as tv ON ts.VitalSignsID= tv.VitalSignNo " & _
                                    " Inner join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Inner join tblDoctor as tdoc on ts.DoctorID = tdoc.DoctorID" & _
                                    " Where tp.PersonID = @personid order by ts.DATEOFSURGERY DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", txtPatientID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientRecords.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchConsultationByPersonID()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tp.PersonID as PatientID,tv.VitalSignNo,tc.ConsultationID,tc.C_DATE,CONCAT(tdoc.FIRSTNAME,' ',tdoc.MIDDLENAME,' ', tdoc.LASTNAME) as DOCTOR, tc.CHIEFCOMPLAIN,tc.PLANORTREATMENT from tblConsulatation as tc " & _
                                    " Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner join tblPerson as tp on tv.PersonID =tp.PersonID " & _
                                    " Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
                                    " Where tp.PersonID = @personid order by tc.C_DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", txtPatientID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientRecords.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchDiagnosisByPersonID()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tp.PersonID as PatientID,td.DiagnosisID,tc.ConsultationID,td.D_DATE,CONCAT(tdoc.FIRSTNAME,' ',tdoc.MIDDLENAME,' ', tdoc.LASTNAME) as DOCTOR,td.DIAGNOSIS,td.TREATMENT from tblDiagnosis as td " & _
                                    " Inner join tblConsulatation as tc On td.ConsultationID = tc.ConsultationID " & _
                                    " Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner join tblPerson as tp on tv.PersonID =tp.PersonID " & _
                                    " Inner join tblDoctor as tdoc On tc.DoctorID = tdoc.DoctorID " & _
                                    " Where tp.PersonID = @personid order by td.D_DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", txtPatientID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientRecords.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchTestResultByPersonID()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tp.PersonID as PatientID,ttr.TestResultNo,tc.ConsultationID,ttr.DATE,ttr.TYPEOFLABEXAM,ttr.RESULT from tblTestResult as ttr " & _
                                    " Inner join tblConsulatation as tc On ttr.ConsultationID = tc.ConsultationID " & _
                                    " Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " Inner join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Where tp.PersonID = @personid order by ttr.DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", txtPatientID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientRecords.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchPersonByPersonID()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select PersonID as PatientID,CONCAT(FIRSTNAME, ' ',MIDDLENAME, ' ',LASTNAME) as FULLNAME,CONCAT(DAY,'-',MONTH,'-',YEAR) as BIRTHDATE,AGE, SEX as GENDER,CONTACTNO, CONCAT(BARANGAY, ', ',MUNICIPALITY, ' ',PROVINCE) as ADDRESS from tblPerson where PersonID=@personid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", txtPatientID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientRecords.DataSource = dt
            charlie = Nothing
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchPersonByLastname()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select PersonID as PatientID,CONCAT(LASTNAME, ', ',FIRSTNAME, ' ',MIDDLENAME) as FULLNAME,CONCAT(DAY,'-',MONTH,'-',YEAR) as BIRTHDATE,AGE, SEX as GENDER,CONTACTNO, CONCAT(BARANGAY, ', ',MUNICIPALITY, ' ',PROVINCE) as ADDRESS from tblPerson " & _
                                    " where CONCAT(LASTNAME, ' ',FIRSTNAME, ' ',MIDDLENAME) like '' +@lname+ '%' order by FULLNAME ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtSearchLname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatientRecords.DataSource = dt
            charlie = Nothing
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Function IstxtEmpty(ByVal txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
    '
    Public Function IscmbxEmpty(cmbx As ComboBox) As Boolean
        Return String.IsNullOrEmpty(cmbx.Text)
    End Function
    '
    Public Sub deleteSelectedItem()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Begin transaction; " & _
                                    " Delete from tblPerson " & _
                                    " Where PersonID = @personid " & _
                                    " Commit transaction;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", charlie)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            charlie = Nothing
            MsgBox("Delete successful!")
            clearFields()
            loadPersonInfo()
        End Using
    End Sub
    '
    Public Sub deleteDateRange()
        Dim db As New KonekDB
        Dim det1 As Date = CDate(dtp1.Text)
        Dim det2 As Date = CDate(dtp2.Text)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Begin transaction; " & _
                                    " Delete tp from tblPerson tp " & _
                                    " Inner join tblVitalSigns tv On tp.PersonID = tv.PersonID " & _
                                    " Where tv.VS_DATE between @det1 And @det2; " & _
                                    " Commit transaction;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", det1)
            cmd.Parameters.AddWithValue("@det2", det2)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            charlie = Nothing
            MsgBox("Delete successful!")
            clearFields()
            loadPersonInfo()
        End Using
    End Sub

    Public Sub checkRecordPreDelete()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Check if patient has records on Appointment
        Using cmd As New SqlCommand("Select PersonID from tblAppointment where PersonID = @personid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                hasAppointment = True
            Else
                hasAppointment = False
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
        '
        'Check if patient has records on VitalSigns
        Using cmd1 As New SqlCommand("Select PersonID from tblVitalSigns where PersonID = @personid;", db.pubSqlCon)
            cmd1.Parameters.Clear()
            cmd1.Parameters.AddWithValue("@personid", charlie)
            Dim da As New SqlDataAdapter(cmd1)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                hasVitalSigns = True
            Else
                hasVitalSigns = False
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd1.Dispose()
        End Using
        '
        'Check if patient has records on  Surgery
        Using cmd2 As New SqlCommand("Select tv.PersonID  from tblSurgery as ts " & _
                                    " Inner Join tblVitalSigns as tv On ts.VitalSignsID = tv.VitalSignNo " & _
                                    " where tv.PersonID = @personid;", db.pubSqlCon)
            cmd2.Parameters.Clear()
            cmd2.Parameters.AddWithValue("@personid", charlie)
            Dim da As New SqlDataAdapter(cmd2)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                hasSurgery = True
            Else
                hasSurgery = False
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd2.Dispose()
        End Using
        '
        'Check if patient has records on  Consultation
        Using cmd3 As New SqlCommand("Select tv.PersonID from tblConsulatation as tc " & _
                                    " Inner join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo " & _
                                    " where tv.PersonID = @personid;", db.pubSqlCon)
            cmd3.Parameters.Clear()
            cmd3.Parameters.AddWithValue("@personid", charlie)
            Dim da As New SqlDataAdapter(cmd3)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                hasConsultation = True
            Else
                hasConsultation = False
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd3.Dispose()
        End Using
        '
        'Check if patient has records on  Diagnosis
        Using cmd4 As New SqlCommand("Select tv.PersonID  from tblDiagnosis as td " & _
                                    " Inner join tblConsulatation as tc On td.ConsultationID = tc.ConsultationID " & _
                                    " Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo  " & _
                                    " where tv.PersonID = @personid;", db.pubSqlCon)
            cmd4.Parameters.Clear()
            cmd4.Parameters.AddWithValue("@personid", charlie)
            Dim da As New SqlDataAdapter(cmd4)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                hasDiagnosis = True
            Else
                hasDiagnosis = False
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd4.Dispose()
        End Using
        '
        'Check if patient has records on  TestResults
        Using cmd4 As New SqlCommand("Select tv.PersonID  from tblTestResult as ttr " & _
" Inner join tblConsulatation as tc On ttr.ConsultationID = tc.ConsultationID " & _
" Inner Join tblVitalSigns as tv On tc.ConsultationID = tv.VitalSignNo  " & _
" where tv.PersonID = @personid;", db.pubSqlCon)
            cmd4.Parameters.Clear()
            cmd4.Parameters.AddWithValue("@personid", charlie)
            Dim da As New SqlDataAdapter(cmd4)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                hasTestResults = True
            Else
                hasTestResults = False
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd4.Dispose()
        End Using
    End Sub
    '
    Public Sub checkDateRangedPreDelete()
        Dim db As New KonekDB
        Dim det1 As Date = CDate(dtp1.Text)
        Dim det2 As Date = CDate(dtp2.Text)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select Count(VitalSignNo) as totalrecord from tblVitalSigns Where VS_DATE between @det1 And @det2;", db.pubSqlCon)
            cmd.Parameters.AddWithValue("@det1", det1)
            cmd.Parameters.AddWithValue("@det2", det2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                totalrecords = dt.Rows(0).Item("totalrecord")
                'Check if selected date by admin has record or not
                If totalrecords = 0 Then
                    hasRecords = False
                Else
                    hasRecords = True
                End If
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub commandDelete()
        Dim InputValue As String = Nothing
        If rbtnSelectedItem.Checked = True Then
            If charlie <> "0" Then
                checkRecordPreDelete()
                'Check if patient has medical records and appointment records. If YES prompt a question else proceed
                If hasAppointment = True Or hasVitalSigns = True Or hasConsultation = True Or hasSurgery = True Or hasDiagnosis = True Or hasTestResults = True Then
                    Dim answer As DialogResult = MessageBox.Show("Warning!! You are going to delete the patient's information and medical records." & vbCrLf & vbCrLf & "Any changes cannot be undone." & vbCrLf & vbCrLf & "Should you want to proceed click YES otherwise click NO.", "Warning! data loss may occur.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    'Check if answer is YES
                    If answer = Windows.Forms.DialogResult.Yes Then
                        'Prompt admin to type security code
                        InputValue = InputBox("To confirm that this is not a mistake, please type in numbers 1-9.", "Confirmation...")
                        If IsNumeric(InputValue) Then
                            If InputValue = "123456789" Then
                                '
                                deleteSelectedItem()
                                '
                                MsgBox("All records associated with this patient has been deleted!")
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
                    End If 'end answer if-else
                Else
                    'Patient is new!
                    Dim answer1 As DialogResult = MessageBox.Show("This patient is new. No medical records in our system associated with this patient." & vbCrLf & vbCrLf & "Please confirm if you would want to delete this petient's record." & vbCrLf & vbCrLf & "Note: Any changes canot be undone. Click YES to proceed otherwise click NO.", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If answer1 = Windows.Forms.DialogResult.Yes Then
                        'Prompt admin to type security code
                        InputValue = InputBox("To confirm that this is not a mistake, please type in numbers 1-9.", "Confirmation...")
                        If IsNumeric(InputValue) Then
                            If InputValue = "123456789" Then
                                '
                                deleteSelectedItem()
                                '
                                MsgBox("Patient's personal information has been deleted!")
                            Else
                                MsgBox("It seems like this is a mistake. Deletion aborted!")
                                Exit Sub
                            End If
                        Else
                            MsgBox("It seems like this is a mistake. Deletion aborted!")
                            Exit Sub
                        End If
                    End If
                End If 'Ending if-else of hasboolean methods
            Else
                MsgBox("Please select a record.")
            End If 'Ending  charlie = 0 ef-else
            '
        ElseIf rbtnSelectedDet.Checked = True Then
            Dim lastVisit As Date = CDate(dtp2.Text)
            checkDateRangedPreDelete()
            'Check if there is records from the dates selected
            If hasRecords = True Then
                MsgBox(hasRecords.ToString())
                'Warning!! All record will be deleted
                Dim answer1 As DialogResult = MessageBox.Show("Warning!! You are going to delete a total of [" & totalrecords.ToString & "] patient's medical records which last visit was on " & lastVisit.ToLongDateString.ToString() & "." & vbCrLf & vbCrLf & "Any changes cannot be undone." & vbCrLf & vbCrLf & "Should you want to proceed click YES otherwise click NO.", "Warning! data loss may occur.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If answer1 = Windows.Forms.DialogResult.Yes Then
                    'Prompt admin to type security code
                    InputValue = InputBox("To confirm that this is not a mistake, please type in numbers 1-9.", "Confirmation...")
                    If IsNumeric(InputValue) Then
                        If InputValue = "123456789" Then
                            '
                            deleteDateRange()
                            '
                            MsgBox("A total of " & totalrecords.ToString() & " of patient's medical record was deleted.")
                            totalrecords = Nothing
                        Else
                            MsgBox("It seems like this is a mistake. Deletion aborted!")
                            Exit Sub
                        End If
                    Else
                        MsgBox("It seems like this is a mistake. Deletion aborted!")
                        Exit Sub
                    End If
                Else
                    MsgBox("Deletion aborted.")
                    Exit Sub
                End If
            Else
                MsgBox("No record found from the date you selected.")
            End If
            End If ' End of else-if
    End Sub
    'END!
    '***************************************************************************************
End Class