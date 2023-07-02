Imports System.Data.SqlClient
Public Class AddPatientRecord
    '!COMMENT: VARIABLES
    Dim hasrecord As Boolean = Nothing
    Dim charliePerson As Integer = Nothing
    Dim charlieToken As String = Nothing
    Dim personname As String = Nothing
    Dim charlieApntmntLname As String = Nothing
    Dim patientStatus As String = Nothing ' get the status (either regular/appintment)
    'END!
    '******************************************************************************************
    '!COMMENT: BUTTONS
    'i. ADD
    Private Sub apibtnAdd_Click(sender As Object, e As EventArgs) Handles apibtnAdd.Click
        Dim bolfname As Boolean = IsPatienttxtFieldsEmpty(apitxtbxFname)
        Dim bolmname As Boolean = IsPatienttxtFieldsEmpty(apitxtbxMname)
        Dim bolLname As Boolean = IsPatienttxtFieldsEmpty(apitxtbxLname)
        Dim bolContactNum As Boolean = IsPatienttxtFieldsEmpty(apitxtbxCnumber)
        Dim bolAge As Boolean = IsPatienttxtFieldsEmpty(apitxtbxAge)
        Dim bolBrgy As Boolean = IsPatienttxtFieldsEmpty(apitxtbxBrgy)
        Dim bolMncplty As Boolean = IsPatienttxtFieldsEmpty(apitxtMncplty)
        Dim bolProvnce As Boolean = IsPatienttxtFieldsEmpty(apitxtbxPrvnce)
        '
        Dim bolDay As Boolean = IsPatientcmbFieldsEmpty(apicmbxDay)
        Dim bolMonth As Boolean = IsPatientcmbFieldsEmpty(apicmbxMonth)
        Dim bolYear As Boolean = IsPatientcmbFieldsEmpty(apicmbxYear)
            If bolfname Then
                msgbBoxShw()
            ElseIf bolmname Then
                msgbBoxShw()
            ElseIf bolLname Then
                msgbBoxShw()
            ElseIf bolContactNum Then
                msgbBoxShw()
            ElseIf bolAge Then
                msgbBoxShw()
            ElseIf bolBrgy Then
                msgbBoxShw()
            ElseIf bolMncplty Then
                msgbBoxShw()
            ElseIf bolProvnce Then
                msgbBoxShw()
            ElseIf bolDay Then
                msgbBoxShw()
            ElseIf bolMonth Then
                msgbBoxShw()
            ElseIf bolYear Then
                msgbBoxShw()
            Else
                toNormalLetter()
                loadProperty()
                insertNewRecord()
                loadNewRecord()
            End If
    End Sub
    'ii. UPDATE
    Private Sub apibtnUpdate_Click(sender As Object, e As EventArgs) Handles apibtnUpdate.Click
        Dim bolfname As Boolean = IsPatienttxtFieldsEmpty(apitxtbxFname)
        Dim bolmname As Boolean = IsPatienttxtFieldsEmpty(apitxtbxMname)
        Dim bolLname As Boolean = IsPatienttxtFieldsEmpty(apitxtbxLname)
        Dim bolContactNum As Boolean = IsPatienttxtFieldsEmpty(apitxtbxCnumber)
        Dim bolAge As Boolean = IsPatienttxtFieldsEmpty(apitxtbxAge)
        Dim bolBrgy As Boolean = IsPatienttxtFieldsEmpty(apitxtbxBrgy)
        Dim bolMncplty As Boolean = IsPatienttxtFieldsEmpty(apitxtMncplty)
        Dim bolProvnce As Boolean = IsPatienttxtFieldsEmpty(apitxtbxPrvnce)
        '
        Dim bolDay As Boolean = IsPatientcmbFieldsEmpty(apicmbxDay)
        Dim bolMonth As Boolean = IsPatientcmbFieldsEmpty(apicmbxMonth)
        Dim bolYear As Boolean = IsPatientcmbFieldsEmpty(apicmbxYear)
        '
        If bolfname Then
            msgbBoxShw()
        ElseIf bolmname Then
            msgbBoxShw()
        ElseIf bolLname Then
            msgbBoxShw()
        ElseIf bolContactNum Then
            msgbBoxShw()
        ElseIf bolAge Then
            msgbBoxShw()
        ElseIf bolBrgy Then
            msgbBoxShw()
        ElseIf bolMncplty Then
            msgbBoxShw()
        ElseIf bolProvnce Then
            msgbBoxShw()
        ElseIf bolDay Then
            msgbBoxShw()
        ElseIf bolMonth Then
            msgbBoxShw()
        ElseIf bolYear Then
            msgbBoxShw()
        Else
            toNormalLetter()
            loadProperty()
            Dim answer As DialogResult = MessageBox.Show("Do you want to update the record?" + vbCrLf + "Click 'YES' to proceed. Otherwise, click 'NO'.", "Waiting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.Yes Then
                updateRecord()
                apiSrchLnameQA.Text = ""
                loadUpdatedRecord()
                charliePerson = Nothing
                apibtnAdd.Enabled = True
                apibtnUpdate.Enabled = False
                apibtnNext.Enabled = False
            End If
        End If

    End Sub
    'ii. NEXT
    Private Sub apibtnNext_Click(sender As Object, e As EventArgs) Handles apibtnNext.Click
        'Capture user activity
        Dim intrfce As String = "Add patient record"
        Dim btn As String = "Next"
        Dim actn As String = "Call patient " & apitxtbxFname.Text & " " & apitxtbxMname.Text & " " & apitxtbxLname.Text & " to record his/her vital signs."
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
        '
        Me.Close()
        UserDashboard.enterVitalsign()
        VitalSigns.txtpersonID.Text = charliePerson ' Transfer person id fromo here to there
        If String.IsNullOrEmpty(patientStatus) = True Then
            VitalSigns.vsrbRegular.Checked = True
        Else
            If patientStatus = "Regular" Then
                VitalSigns.vsrbRegular.Checked = True
            ElseIf patientStatus = "Appointment" Then
                VitalSigns.vsrbAppointment.Checked = True
            End If
        End If
        VitalSigns.pastePatientInfo()
        VitalSigns.vsbtnSave.Enabled = True
        AcceptButton = VitalSigns.vsbtnSave
        VitalSigns.vsbtnUpdate.Enabled = False
    End Sub
    'END!
    '******************************************************************************************
    '!COMMENT: EVENTS
    'i. Load form
    Private Sub AddPatientRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim intrfce As String = "Add patient record"
        Dim btn As String = "N/A"
        Dim actn As String = "Open"
        loadQueToday()
        loadDOByear()
        apiSrchLnameQA.Select()
        apiSrchLnameQA.Focus()
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'Search Textbox Changed (Que & Appointment)
    Private Sub apiSrchLnameQA_TextChanged(sender As Object, e As EventArgs) Handles apiSrchLnameQA.TextChanged
        getPatientRcrd()
        If apirbQue.Checked = True Then
            'Read new code
            If apiSrchLnameQA.Text = "" Then
                loadQueToday()
                apiClear()
            Else
                getQueInfo()
            End If
        ElseIf apirbAppointmnt.Checked = True Then
            'Read new code
            If apiSrchLnameQA.Text = "" Then
                apiClear()
                loadAppointmentToday()
            Else
                getAppointmntInfo()
            End If
        End If
        '
        apiSearchLname.Text = apiSrchLnameQA.Text
    End Sub
    'iii.DGV Cell click (Patient DGV)
    Private Sub apiDGVpatientInfo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles apiDGVpatientInfo.CellClick
        apibtnUpdate.Enabled = True
        apibtnNext.Enabled = True
        apibtnAdd.Enabled = False
        getColumnPositionPerson(apiDGVpatientInfo)
        pastePatientInfo()
    End Sub
    'iv. DGV Cell click (Que & Appointment)
    Private Sub apiDGVqa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles apiDGVqa.CellClick
        apiClear()
        If apirbQue.Checked = True Then
            getColumnPositionQue(apiDGVqa)
            pasteQueInfo()
            'check if person on queue has record
            If hasrecord = True Then
                apibtnAdd.Enabled = False
                apibtnUpdate.Enabled = True
            Else
                apibtnAdd.Enabled = True
                apibtnUpdate.Enabled = False
            End If
        ElseIf apirbAppointmnt.Checked = True Then
            apiClear()
            getColumnPositionAppnmnt(apiDGVqa)
            pastePatientInfo()
        End If
    End Sub
    'vi. Radio button Que & Appointment (checked)
    Private Sub queANDappointment_Click(sender As Object, e As EventArgs) Handles apirbQue.Click, apirbAppointmnt.Click
        apiClear()
        If apirbQue.Checked = True Then
            apibtnAdd.Enabled = True
            apibtnUpdate.Enabled = False
            apibtnNext.Enabled = False
            loadQueToday()
        Else
            apiSrchLnameQA.Text = ""
        End If
        If apirbAppointmnt.Checked = True Then
            apibtnAdd.Enabled = False
            apibtnNext.Enabled = True
            apibtnUpdate.Enabled = True
            loadAppointmentToday()
        Else
            apiSrchLnameQA.Text = ""
        End If
    End Sub
    'FORM CLOSING
    Private Sub AddPatientRecord_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        UserDashboard.returntoUserDashboard()
    End Sub
    ' Year selected index changed
    Private Sub apicmbxYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles apicmbxYear.SelectedIndexChanged
        Dim age As Integer = 0
        Dim brthYear As Integer = 0
        Dim yrToday As Integer = CInt(Date.Now.Year.ToString)
        If apicmbxYear.Text <> "" Then
            brthYear = CInt(apicmbxYear.Text)
            age = yrToday - brthYear
            apitxtbxAge.Text = age.ToString
        Else
            apitxtbxAge.Text = ""
        End If
    End Sub
    'Is letter
    Private Sub IsLetter(sender As Object, e As KeyPressEventArgs) Handles apitxtMncplty.KeyPress, apitxtbxPrvnce.KeyPress, apitxtbxMname.KeyPress, apitxtbxLname.KeyPress, apitxtbxFname.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> vbBack And e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub
    'Is number
    Private Sub IsNumber(sender As Object, e As KeyPressEventArgs) Handles apitxtbxCnumber.KeyPress
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub apiSrchLnameQA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles apiSrchLnameQA.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> " " And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    'END!
    '******************************************************************************************
    '!COMMENT: METHODS
    'i. CLEAR FIELDS
    Public Sub apiClear()
        apitxtbxFname.Text = ""
        apitxtbxMname.Text = ""
        apitxtbxLname.Text = ""
        apitxtbxAge.Text = ""
        apitxtbxCnumber.Text = ""
        apitxtbxBrgy.Text = ""
        apitxtMncplty.Text = ""
        apitxtbxPrvnce.Text = ""
        apicmbxDay.Text = ""
        apicmbxMonth.Text = ""
        apicmbxYear.Text = ""
        apiSearchLname.Text = ""
    End Sub
    'ii. GET QUEUE INFO
    Public Sub getQueInfo()
        Dim db As New KonekDB
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select QDATE,TOKENNUMBER as TOKEN,CONCAT(LASTNAME,', ',FIRSTNAME,' ',MIDDLENAME) as NAME, GENDER, CONCAT(BARANGAY, ' ', MUNICIPALITY, ' ',PROVINCE) as ADDRESS from tblQue " & _
                                    " Where CONCAT(LASTNAME, ', ',FIRSTNAME, ' ', MIDDLENAME) like '' +@lname+ '%' and QDATE = @det order by NAME ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", apiSrchLnameQA.Text)
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            apiDGVqa.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'iii. GET APPOINMENT INFO
    Public Sub getAppointmntInfo()
        Dim db As New KonekDB
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ta.A_DATE,tp.PersonID,CONCAT(tp.LASTNAME,', ',tp.FIRSTNAME, ' ', tp.MIDDLENAME) as NAME, tp.SEX as GENDER, CONCAT(tp.BARANGAY, ' ', tp.MUNICIPALITY, ' ',tp.PROVINCE) as ADDRESS from tblAppointment as ta " & _
                                    " Inner join tblPerson as tp On ta.PersonID = tp.PersonID " & _
                                    " Where CONCAT(tp.LASTNAME,', ',tp.FIRSTNAME, ' ', tp.MIDDLENAME) like '' + @lname + '%' and A_DATE = @det order by NAME ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", apiSrchLnameQA.Text)
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            apiDGVqa.DataSource = dt
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'iv. GET PATIENT RECORD
    Public Sub getPatientRcrd()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select PersonID,CONCAT(LASTNAME, ', ',FIRSTNAME, ' ', MIDDLENAME) as NAME, SEX as GENDER, AGE, CONCAT(DAY, ' ', MONTH, ' ', YEAR)as DOB,CONTACTNO, CONCAT(BARANGAY, ' ', MUNICIPALITY, ' ',PROVINCE) as ADDRESS from tblPerson where CONCAT(LASTNAME, ', ',FIRSTNAME, ' ', MIDDLENAME) like '' + @lname + '%' order by NAME ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", apiSrchLnameQA.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                hasrecord = True
            Else
                hasrecord = False
            End If
            apiDGVpatientInfo.DataSource = dt
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'v. Cell click (PatientInfo)
    Public Sub getColumnPositionPerson(ByVal dgv As DataGridView)
        Try
            Dim romeo As Integer = Nothing
            If dgv.Rows.Count > 0 Then
                romeo = dgv.CurrentRow.Index
                charliePerson = dgv.Item(0, romeo).Value
            End If
        Catch
            apiClear()
        End Try
    End Sub
    'vi. Cell click (Que & Appointment)
    ''a.
    Public Sub getColumnPositionQue(ByVal dgv As DataGridView)
        Try
            Dim romeo As Integer = Nothing
            If dgv.Rows.Count > 0 Then
                romeo = dgv.CurrentRow.Index
                charlieToken = dgv.Item(1, romeo).Value
                personname = dgv.Item(2, romeo).Value
                apiSrchLnameQA.Text = personname
                personname = Nothing
                patientStatus = ""
                patientStatus = "Regular"
            End If
        Catch
            'Do nothing
        End Try
    End Sub
    ''b.
    Public Sub getColumnPositionAppnmnt(ByVal dgv As DataGridView)
        Try
            Dim romeo As Integer = Nothing
            If dgv.Rows.Count > 0 Then
                romeo = dgv.CurrentRow.Index
                charliePerson = dgv.Item(3, romeo).Value
                personname = dgv.Item(4, romeo).Value
                apiSrchLnameQA.Text = personname
                personname = Nothing
                patientStatus = ""
                patientStatus = "Appointment"
            End If
        Catch
            'Do nothing
        End Try
    End Sub
    'vii. Paste Patient info to text fields
    Public Sub pastePatientInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select * from tblPerson where PersonID =@personid", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", charliePerson)
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                apitxtbxFname.Text = dt.Rows(0).Item("FIRSTNAME")
                apitxtbxMname.Text = dt.Rows(0).Item("MIDDLENAME")
                apitxtbxLname.Text = dt.Rows(0).Item("LASTNAME")
                apitxtbxAge.Text = dt.Rows(0).Item("AGE")
                apitxtbxBrgy.Text = dt.Rows(0).Item("BARANGAY")
                apitxtMncplty.Text = dt.Rows(0).Item("MUNICIPALITY")
                apitxtbxPrvnce.Text = dt.Rows(0).Item("PROVINCE")
                apitxtbxCnumber.Text = dt.Rows(0).Item("CONTACTNO")
                If dt.Rows(0).Item("SEX") = "Male" Then
                    apirbMale.Checked = True
                    apirbFemale.Checked = False
                Else
                    apirbFemale.Checked = True
                    apirbMale.Checked = False
                End If
                apicmbxDay.Text = dt.Rows(0).Item("DAY")
                apicmbxMonth.Text = dt.Rows(0).Item("MONTH")
                apicmbxYear.Text = dt.Rows(0).Item("YEAR")
                da.Dispose()
                cmd.Dispose()
            End If
            db.pubSqlCon.Close()
        End Using
    End Sub '//for review
    'viii. Paste Que info to text fields
    Public Sub pasteQueInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Next code: Asses if token is DBnull
        Try
            Using cmd As New SqlCommand("Select * from tblQue where TOKENNUMBER =@token", db.pubSqlCon)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@token", charlieToken)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    apitxtbxFname.Text = dt.Rows(0).Item("FIRSTNAME")
                    apitxtbxMname.Text = dt.Rows(0).Item("MIDDLENAME")
                    apitxtbxLname.Text = dt.Rows(0).Item("LASTNAME")
                    apitxtbxBrgy.Text = dt.Rows(0).Item("BARANGAY")
                    apitxtMncplty.Text = dt.Rows(0).Item("MUNICIPALITY")
                    apitxtbxPrvnce.Text = dt.Rows(0).Item("PROVINCE")
                    If dt.Rows(0).Item("GENDER") = "Male" Then
                        apirbMale.Checked = True
                        apirbFemale.Checked = False
                    Else
                        apirbFemale.Checked = True
                        apirbMale.Checked = False
                    End If
                    da.Dispose()
                    cmd.Dispose()
                End If
            End Using
        Catch
            'Do nothing
        Finally
            charlieToken = ""
            charlieToken = Nothing
            db.pubSqlCon.Close()
        End Try
    End Sub
    'ix.  Is textbox fields empty?
    Public Function IsPatienttxtFieldsEmpty(txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
    'xi. Is combo box fields empty?
    Public Function IsPatientcmbFieldsEmpty(cmbBox As ComboBox) As Boolean
        Return String.IsNullOrEmpty(cmbBox.Text)
    End Function
    'xii. Insert New patient record
    Public Sub insertNewRecord()
        'Capture user activity
        Dim intrfce As String = "Add patient record"
        Dim btn As String = "Add"
        Dim actn As String = "Add new record of patient " & apitxtbxFname.Text & " " & apitxtbxMname.Text & " " & apitxtbxLname.Text & "."
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
        'Insert new recrod
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Insert into tblPerson (FIRSTNAME, MIDDLENAME, LASTNAME, AGE, DAY, MONTH, YEAR, SEX, BARANGAY, MUNICIPALITY, PROVINCE, CONTACTNO) values (@fname, @mname, @lname, @age, @day,@month, @year, @sex, @barangay, @municipality, @province, @contactno); ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@fname", System.Data.SqlDbType.VarChar).Value = apitxtbxFname.Text
            cmd.Parameters.Add("@mname", System.Data.SqlDbType.VarChar).Value = apitxtbxMname.Text
            cmd.Parameters.Add("@lname", System.Data.SqlDbType.VarChar).Value = apitxtbxLname.Text
            cmd.Parameters.Add("@age", System.Data.SqlDbType.Int).Value = apitxtbxAge.Text
            cmd.Parameters.Add("@contactno", System.Data.SqlDbType.NChar).Value = apitxtbxCnumber.Text
            cmd.Parameters.Add("@barangay", System.Data.SqlDbType.VarChar).Value = apitxtbxBrgy.Text
            cmd.Parameters.Add("@municipality", System.Data.SqlDbType.VarChar).Value = apitxtMncplty.Text
            cmd.Parameters.Add("@province", System.Data.SqlDbType.VarChar).Value = apitxtbxPrvnce.Text
            cmd.Parameters.Add("@day", System.Data.SqlDbType.Int).Value = apicmbxDay.Text
            cmd.Parameters.Add("@month", System.Data.SqlDbType.VarChar).Value = apicmbxMonth.Text
            cmd.Parameters.Add("@year", System.Data.SqlDbType.Int).Value = apicmbxYear.Text
            If apirbMale.Checked = True Then
                cmd.Parameters.Add("@sex", System.Data.SqlDbType.VarChar).Value = "Male"
            Else
                cmd.Parameters.Add("@sex", System.Data.SqlDbType.VarChar).Value = "Female"
            End If
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            apiClear()
            MessageBox.Show("Data has been saved!", "Saving...", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub
    'xii. Update record
    Public Sub updateRecord()
        'Capture user activity
        Dim intrfce As String = "Add patient record"
        Dim btn As String = "Update"
        Dim actn As String = "Update record of patient " & apitxtbxFname.Text & " " & apitxtbxMname.Text & " " & apitxtbxLname.Text & "."
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
        'Update record
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Update tblPerson Set FIRSTNAME=@fname, MIDDLENAME=@mname, LASTNAME=@lname, AGE=@age, DAY=@day, MONTH=@month, YEAR=@year, SEX=@sex, BARANGAY=@brgy, MUNICIPALITY=@municipality, PROVINCE=@province, CONTACTNO=@contactno Where PersonID=@personid; ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", charliePerson)
            cmd.Parameters.AddWithValue("@fname", apitxtbxFname.Text)
            cmd.Parameters.AddWithValue("@mname", apitxtbxMname.Text)
            cmd.Parameters.AddWithValue("@lname", apitxtbxLname.Text)
            cmd.Parameters.AddWithValue("@age", apitxtbxAge.Text)
            cmd.Parameters.AddWithValue("@day", apicmbxDay.Text)
            cmd.Parameters.AddWithValue("@month", apicmbxMonth.Text)
            cmd.Parameters.AddWithValue("@year", apicmbxYear.Text)
            If apirbMale.Checked = True Then
                cmd.Parameters.AddWithValue("@sex", "Male")
            Else
                cmd.Parameters.AddWithValue("@sex", "Female")
            End If
            cmd.Parameters.AddWithValue("@brgy", apitxtbxBrgy.Text)
            cmd.Parameters.AddWithValue("@municipality", apitxtMncplty.Text)
            cmd.Parameters.AddWithValue("@province", apitxtbxPrvnce.Text)
            cmd.Parameters.AddWithValue("@contactno", apitxtbxCnumber.Text)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            apiClear()
            MsgBox("Successfully updated!")
        End Using
    End Sub '//for review
    'xiv. Load Property
    Public Sub loadProperty()
        '
        ProprtyFname = apitxtbxFname.Text
        apitxtbxFname.Text = ProprtyFname
        _fname = ""
        _fname = Nothing
        '
        ProprtyMname = apitxtbxMname.Text
        apitxtbxMname.Text = ProprtyMname
        _mname = ""
        _mname = Nothing
        '
        ProprtyLname = apitxtbxLname.Text
        apitxtbxLname.Text = ProprtyLname
        _lname = ""
        _lname = Nothing
        '
        ProprtyBrgy = apitxtbxBrgy.Text
        apitxtbxBrgy.Text = ProprtyBrgy
        _brgy = ""
        _brgy = Nothing
        '
        ProprtyMunicipality = apitxtMncplty.Text
        apitxtMncplty.Text = ProprtyMunicipality
        _municpalty = ""
        _municpalty = Nothing
        '
        ProprtyProvince = apitxtbxPrvnce.Text
        apitxtbxPrvnce.Text = ProprtyProvince
        _province = ""
        _province = Nothing
    End Sub
    'xvii. Load to normal letter
    Public Sub toNormalLetter()
        apitxtbxFname.CharacterCasing = CharacterCasing.Normal
        apitxtbxMname.CharacterCasing = CharacterCasing.Normal
        apitxtbxLname.CharacterCasing = CharacterCasing.Normal
        apitxtbxBrgy.CharacterCasing = CharacterCasing.Normal
        apitxtMncplty.CharacterCasing = CharacterCasing.Normal
        apitxtbxPrvnce.CharacterCasing = CharacterCasing.Normal
    End Sub
    'xvii.  Load year combo box
    Public Sub loadDOByear()
        Dim yr As Integer = Year(Today)
        For i As Integer = 1923 To yr
            apicmbxYear.Items.Add(i)
        Next
    End Sub
    'xviii.
    Public Sub loadQueToday()
        Dim db As New KonekDB
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select QDATE,TOKENNUMBER as TOKEN,CONCAT(LASTNAME, ', ',FIRSTNAME, ' ', MIDDLENAME) as NAME, GENDER, CONCAT(BARANGAY, ' ', MUNICIPALITY, ' ',PROVINCE) as ADDRESS from tblQue where QDATE =@det  order by TOKEN ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            apiDGVqa.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'xix.
    Public Sub loadAppointmentToday()
        Dim db As New KonekDB
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ta.A_DATE,ta.A_TIME,TOKEN,tp.PersonID,CONCAT(tp.LASTNAME,', ',tp.FIRSTNAME, ' ', tp.MIDDLENAME) as NAME, tp.SEX as GENDER, CONCAT(tp.BARANGAY, ' ', tp.MUNICIPALITY, ' ',tp.PROVINCE) as ADDRESS from tblAppointment as ta " & _
                                    " Inner join tblPerson as tp On ta.PersonID = tp.PersonID " & _
                                    " Where A_DATE = @det order by TOKEN ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            apiDGVqa.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub loadNewRecord()
        Dim personid As Integer = Nothing
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Get the current personid
        Using da As New SqlDataAdapter("Select MAX(PersonID) as personid from tblPerson;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                personid = dt.Rows(0).Item("personid")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
        'Load dgv using the patient id above
        Using cmd As New SqlCommand("Select PersonID, LASTNAME,CONCAT(FIRSTNAME, ' ', MIDDLENAME) as NAME, SEX as GENDER, AGE, CONCAT(DAY, ' ', MONTH, ' ', YEAR)as DOB,CONTACTNO, CONCAT(BARANGAY, ' ', MUNICIPALITY, ' ',PROVINCE) as ADDRESS from tblPerson where PersonID=@personid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", personid)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            apiDGVpatientInfo.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub loadUpdatedRecord()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select PersonID,CONCAT(LASTNAME, ', ',FIRSTNAME, ' ', MIDDLENAME) as NAME, SEX as GENDER, AGE, CONCAT(DAY, ' ', MONTH, ' ', YEAR)as DOB,CONTACTNO, CONCAT(BARANGAY, ' ', MUNICIPALITY, ' ',PROVINCE) as ADDRESS from tblPerson where PersonID=@personid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", charliePerson)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            apiDGVpatientInfo.DataSource = dt
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
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
    '******************************************************************************************
End Class