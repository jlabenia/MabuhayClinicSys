Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class VitalSigns
    '!COMMENT: PUBLIC VARIABLES
    Public patient_personID As Integer = Nothing ' received the person id from add patient form
    Dim checkdeyt As Date = CDate(Date.Now.ToShortDateString)
    Dim charlie As Integer = Nothing
    Dim charlie2 As Integer = Nothing 'get the person id for loading updated vs records
    'END!
    '*********************************************************************************************************
    '!COMMENT: BUTTONS
    'i. SAVE
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles vsbtnSave.Click
        Dim bolfname As Boolean = islblEmpty(vslblFname)
        Dim bolage As Boolean = islblEmpty(vslblAge)
        Dim bolgender As Boolean = islblEmpty(vslblGender)
        '
        Dim bolbodytemp As Boolean = istxtEmpty(vstxtbxBT)
        Dim bolbp As Boolean = istxtEmpty(vstxtbxBP)
        Dim bolpr As Boolean = istxtEmpty(vstxtbxPR)
        Dim bolresp As Boolean = istxtEmpty(vstxtbxResp)
        Dim bolo2sat As Boolean = istxtEmpty(vstxtO2sat)
        Dim bolweight As Boolean = istxtEmpty(vstxtbxWeight)
        Dim bolheight As Boolean = istxtEmpty(vstxtbxHeight)
        '
        Dim bolcmbxbt As Boolean = iscmbxEmpty(vscmbxBT)
        Dim bolcmbxbp As Boolean = iscmbxEmpty(vscmbxBP)
        Dim bolcmbxpr As Boolean = iscmbxEmpty(vscmbxPR)
        Dim bolcmbxresp As Boolean = iscmbxEmpty(vscmbxResp)
        Dim bolcmbxo2sat As Boolean = iscmbxEmpty(vscmbxO2sat)
        If bolfname Then
            msgbBoxShw()
        ElseIf bolage Then
            msgbBoxShw()
        ElseIf bolgender Then
            msgbBoxShw()
        ElseIf bolbodytemp Then
            msgbBoxShw()
        ElseIf bolbp Then
            msgbBoxShw()
        ElseIf bolpr Then
            msgbBoxShw()
        ElseIf bolresp Then
            msgbBoxShw()
        ElseIf bolo2sat Then
            msgbBoxShw()
        ElseIf bolweight Then
            msgbBoxShw()
        ElseIf bolheight Then
            msgbBoxShw()
        ElseIf bolcmbxbt Then
            msgbBoxShw()
        ElseIf bolcmbxbp Then
            msgbBoxShw()
        ElseIf bolpr Then
            msgbBoxShw()
        ElseIf bolcmbxresp Then
            msgbBoxShw()
        ElseIf bolcmbxo2sat Then
            msgbBoxShw()
        Else
            insertNewVitalSigns()
            loadNewVitalSignsPtntRcrd()
        End If

    End Sub
    'ii. UPDATE
    Private Sub Update_Click(sender As Object, e As EventArgs) Handles vsbtnUpdate.Click
        Dim bolfname As Boolean = islblEmpty(vslblFname)
        Dim bolage As Boolean = islblEmpty(vslblAge)
        Dim bolgender As Boolean = islblEmpty(vslblGender)
        '
        Dim bolbodytemp As Boolean = istxtEmpty(vstxtbxBT)
        Dim bolbp As Boolean = istxtEmpty(vstxtbxBP)
        Dim bolpr As Boolean = istxtEmpty(vstxtbxPR)
        Dim bolresp As Boolean = istxtEmpty(vstxtbxResp)
        Dim bolo2sat As Boolean = istxtEmpty(vstxtO2sat)
        Dim bolweight As Boolean = istxtEmpty(vstxtbxWeight)
        Dim bolheight As Boolean = istxtEmpty(vstxtbxHeight)
        '
        Dim bolcmbxbt As Boolean = iscmbxEmpty(vscmbxBT)
        Dim bolcmbxbp As Boolean = iscmbxEmpty(vscmbxBP)
        Dim bolcmbxpr As Boolean = iscmbxEmpty(vscmbxPR)
        Dim bolcmbxresp As Boolean = iscmbxEmpty(vscmbxResp)
        Dim bolcmbxo2sat As Boolean = iscmbxEmpty(vscmbxO2sat)
        If bolfname Then
            msgbBoxShw()
        ElseIf bolage Then
            msgbBoxShw()
        ElseIf bolgender Then
            msgbBoxShw()
        ElseIf bolbodytemp Then
            msgbBoxShw()
        ElseIf bolbp Then
            msgbBoxShw()
        ElseIf bolpr Then
            msgbBoxShw()
        ElseIf bolresp Then
            msgbBoxShw()
        ElseIf bolo2sat Then
            msgbBoxShw()
        ElseIf bolweight Then
            msgbBoxShw()
        ElseIf bolheight Then
            msgbBoxShw()
        ElseIf bolcmbxbt Then
            msgbBoxShw()
        ElseIf bolcmbxbp Then
            msgbBoxShw()
        ElseIf bolpr Then
            msgbBoxShw()
        ElseIf bolcmbxresp Then
            msgbBoxShw()
        ElseIf bolcmbxo2sat Then
            msgbBoxShw()
        Else
            If charlie2 <> 0 Then
                updateVitalsignsRcrd()
            Else
                Exit Sub
            End If
        End If
    End Sub
    'END!
    '*********************************************************************************************************
    '!COMMENT: EVENTS
    'i. DGV cell click
    Private Sub vsDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles vsDGV.CellClick
        Try
            clearFields()
            vsbtnSave.Enabled = False
            vsbtnUpdate.Enabled = True
            Dim romeo As Integer = Nothing
            If vsDGV.Rows.Count > 0 Then
                romeo = vsDGV.CurrentRow.Index
                charlie = vsDGV.Item(0, romeo).Value
                charlie2 = vsDGV.Item(1, romeo).Value
            End If
            populateFields()
        Catch ex As Exception
            clearFields()
            loadVitalSigns()
        End Try
    End Sub
    'ii. Form load
    Private Sub VitalSigns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim intrfce As String = "Add Vital Signs"
        Dim btn As String = "N/A"
        Dim actn As String = "Open"
        loadVitalSigns()
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub '//For review
    'iii. Form Closing
    Private Sub VitalSigns_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        UserDashboard.returntoUserDashboard()
    End Sub '//for review
    'iv. Search by Lastname
    Private Sub vstxtbxSrchLname_TextChanged(sender As Object, e As EventArgs) Handles vstxtbxSrchLname.TextChanged
        If vstxtbxSrchLname.Text <> "" Then
            searchbyLastname()
        Else
            loadVitalSigns()
        End If
    End Sub
    '
    Private Sub IsDecimal(sender As Object, e As KeyPressEventArgs) Handles vstxtbxWeight.KeyPress, vstxtbxHeight.KeyPress, vstxtbxBT.KeyPress
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> "." And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
        '
        If e.KeyChar = "." And CType(sender, TextBox).Text.IndexOf(".") > -1 Then
            e.Handled = True
        End If
    End Sub

    Private Sub vstxtbxBP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles vstxtbxBP.KeyPress
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> "/" And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
        '
        If e.KeyChar = "/" And CType(sender, TextBox).Text.IndexOf("/") > -1 Then
            e.Handled = True
        End If
    End Sub
    'END!
    '*********************************************************************************************************
    '!COMMENTS: METHODS
    'i. Paste patient info
    Public Sub pastePatientInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()

        Using cmd As New SqlCommand("Select PersonID, CONCAT(FIRSTNAME, ' ',MIDDLENAME, ' ', LASTNAME) as Fullname, AGE, SEX from  tblPerson where PersonID =  @personid; ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", txtpersonID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                vslblFname.Text = dt.Rows(0).Item("Fullname")
                vslblAge.Text = dt.Rows(0).Item("AGE")
                vslblGender.Text = dt.Rows(0).Item("SEX")
            End If
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub '// fpr review
    'ii. Load New Vital signs patient's record
    Public Sub loadNewVitalSignsPtntRcrd()
        Dim vitalsignNo As Integer = Nothing
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Get the current Vitalsign no
        Using da As New SqlDataAdapter("Select MAX(VitalSignNo) as id from tblVitalSigns;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                vitalsignNo = dt.Rows(0).Item("id")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
        'Load the new record
        Using cmd As New SqlCommand("Select tv.VitalSignNo,tp.PersonID,tv.STATUS,tv.VS_DATE as DATE,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', tp.LASTNAME) as FULLNAME, tp.AGE, tp.SEX, CONCAT(tv.BODYTEMP,' - [Normal: ',tv.BT_ISNORMAL,']') as BODY_TEMP, CONCAT(tv.BLOODPRESSURE,' - [Normal: ',tv.BP_ISNORMAL,']') AS BLOOD_PRESSURE, CONCAT(tv.RESPIRATION,' - [Normal: ',tv.R_ISNORMAL,']') as RESPIRATION_RATE, CONCAT(tv.PULSERATE,' - [Normal: ',tv.P_ISNORMAL,']') as PULSERATE, CONCAT(tv.O2SAT,' - [Normal: ',tv.O2_ISNORMAL,']') as O2_SAT, tv.WEIGHT, tv.HIEGHT  from tblVitalSigns as tv " & _
                                    " Inner join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Where tv.VitalSignNo =@vnum; ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@vnum", vitalsignNo)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            vsDGV.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            vitalsignNo = Nothing
        End Using
    End Sub '//for review
    'iii. Load vital signs info
    Public Sub loadVitalSigns()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select tv.VitalSignNo,tp.PersonID,tv.STATUS,tv.VS_DATE as DATE,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', tp.LASTNAME) as FULLNAME, tp.AGE, tp.SEX, CONCAT(tv.BODYTEMP,' - [Normal: ',tv.BT_ISNORMAL,']') as BODY_TEMP, CONCAT(tv.BLOODPRESSURE,' - [Normal: ',tv.BP_ISNORMAL,']') AS BLOOD_PRESSURE, CONCAT(tv.RESPIRATION,' - [Normal: ',tv.R_ISNORMAL,']') as RESPIRATION_RATE, CONCAT(tv.PULSERATE,' - [Normal: ',tv.P_ISNORMAL,']') as PULSERATE, CONCAT(tv.O2SAT,' - [Normal: ',tv.O2_ISNORMAL,']') as O2_SAT, tv.WEIGHT, tv.HIEGHT  from tblVitalSigns as tv Inner join tblPerson as tp On tv.PersonID = tp.PersonID ORDER by DATE DESC; ", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            vsDGV.DataSource = dt
            da.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'iv. Is text fields empty
    Public Function istxtEmpty(txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
    'v. Is combo box empty
    Public Function iscmbxEmpty(cmbx As ComboBox) As Boolean
        Return String.IsNullOrEmpty(cmbx.Text)
    End Function
    'vi. Is lbl empty
    Public Function islblEmpty(lbl As Label) As Boolean
        Return String.IsNullOrEmpty(lbl.Text)
    End Function
    'vii. Insert new vital signs
    Public Sub insertNewVitalSigns()
        'Capture user activity
        Dim intrfce As String = "Add Vital Signs"
        Dim btn As String = "Save"
        Dim actn As String = "Add new vital signs of patient " & vslblFname.Text & "."
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
        'Insert new record
        Dim db As New KonekDB
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Insert into tblVitalSigns (PersonID,STATUS,BODYTEMP,BT_ISNORMAL,BLOODPRESSURE,BP_ISNORMAL,RESPIRATION,R_ISNORMAL,PULSERATE,P_ISNORMAL,O2SAT,O2_ISNORMAL,WEIGHT,HIEGHT,VS_DATE) values (@personid,@status,@bodytemp,@bodytempisnormal,@bloodpressure,@bpisnormal,@respiration,@respisnormal,@pulserate,@pulseisnormal,@o2sat,@o2isnormal,@weight,@height,@det);", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@personid", SqlDbType.Int).Value = txtpersonID.Text
            If vsrbRegular.Checked = True Then
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "Regular"
            Else
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "Appointment"
            End If
            cmd.Parameters.Add("@bodytemp", SqlDbType.VarChar).Value = vstxtbxBT.Text + "°C"
            cmd.Parameters.Add("bodytempisnormal", SqlDbType.VarChar).Value = vscmbxBT.Text
            cmd.Parameters.Add("@bloodpressure", SqlDbType.VarChar).Value = vstxtbxBP.Text + "mmHg"
            cmd.Parameters.Add("@bpisnormal", SqlDbType.VarChar).Value = vscmbxBP.Text
            cmd.Parameters.Add("@respiration", SqlDbType.VarChar).Value = vstxtbxResp.Text + "bpm"
            cmd.Parameters.Add("@respisnormal", SqlDbType.VarChar).Value = vscmbxResp.Text
            cmd.Parameters.Add("@pulserate", SqlDbType.VarChar).Value = vstxtbxPR.Text + "bpm"
            cmd.Parameters.Add("@pulseisnormal", SqlDbType.VarChar).Value = vscmbxResp.Text
            cmd.Parameters.Add("@o2sat", SqlDbType.VarChar).Value = vstxtO2sat.Text + "%"
            cmd.Parameters.Add("@o2isnormal", SqlDbType.VarChar).Value = vscmbxO2sat.Text
            cmd.Parameters.Add("@weight", SqlDbType.VarChar).Value = vstxtbxWeight.Text + "kg"
            cmd.Parameters.Add("@height", SqlDbType.VarChar).Value = vstxtbxHeight.Text + "cm"
            cmd.Parameters.Add("@det", SqlDbType.Date).Value = det
            cmd.ExecuteNonQuery()
            MsgBox("New record has been added!", MsgBoxStyle.OkOnly)
            cmd.Dispose()
        End Using
        vsbtnSave.Enabled = False
        db.pubSqlCon.Close()
        clearFields()
    End Sub '// for review
    'viii. Populate txt fields
    Public Sub populateFields()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tv.VitalSignNo, CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', tp.LASTNAME) as FULLNAME,tp.AGE, tp.SEX,tv.STATUS, " & _
                                    " tv.BODYTEMP,tv.BT_ISNORMAL,tv.BLOODPRESSURE,tv.BP_ISNORMAL,tv.RESPIRATION,tv.R_ISNORMAL,tv.PULSERATE,tv.P_ISNORMAL, " & _
                                    " tv.O2SAT,tv.O2_ISNORMAL, tv.WEIGHT, tv.HIEGHT from tblVitalSigns as tv " & _
                                    " Inner join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Where tv.VitalSignNo =@charlie", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@charlie", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("STATUS") = "Regular" Then
                    vsrbRegular.Checked = True
                    vsrbAppointment.Checked = False
                ElseIf dt.Rows(0).Item("STATUS") = "Appointment" Then
                    vsrbAppointment.Checked = True
                    vsrbRegular.Checked = False
                End If
                vslblFname.Text = dt.Rows(0).Item("FULLNAME")
                vslblAge.Text = dt.Rows(0).Item("AGE")
                vslblGender.Text = dt.Rows(0).Item("SEX")
                '
                vstxtbxBP.Text = dt.Rows(0).Item("BLOODPRESSURE")
                vstxtbxBT.Text = dt.Rows(0).Item("BODYTEMP")
                vstxtbxPR.Text = dt.Rows(0).Item("PULSERATE")
                vstxtbxResp.Text = dt.Rows(0).Item("RESPIRATION")
                vstxtO2sat.Text = dt.Rows(0).Item("O2SAT")
                vstxtbxWeight.Text = dt.Rows(0).Item("WEIGHT")
                vstxtbxHeight.Text = dt.Rows(0).Item("HIEGHT")
                '
                vscmbxBP.Text = dt.Rows(0).Item("BP_ISNORMAL")
                vscmbxBT.Text = dt.Rows(0).Item("BT_ISNORMAL")
                vscmbxPR.Text = dt.Rows(0).Item("P_ISNORMAL")
                vscmbxResp.Text = dt.Rows(0).Item("R_ISNORMAL")
                vscmbxO2sat.Text = dt.Rows(0).Item("O2_ISNORMAL")
            End If
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'ix. Update vital signs 
    Public Sub updateVitalsignsRcrd()
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        Dim vsdet As Date = Nothing
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Get vital signs date (confirm if date is today)
        Using cmd2 As New SqlCommand("Select * from tblVitalSigns where VS_DATE= @det and VitalSignNo =@charlie ", db.pubSqlCon)
            cmd2.Parameters.Clear()
            cmd2.Parameters.AddWithValue("@det", det)
            cmd2.Parameters.AddWithValue("@charlie", charlie)
            Dim da As New SqlDataAdapter(cmd2)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                vsdet = dt.Rows(0).Item("VS_DATE")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd2.Dispose()
        End Using
        'Update
        Using cmd As New SqlCommand("Update tblVitalsigns set STATUS=@status,BODYTEMP=@bodytemp,BT_ISNORMAL=@btnormal,BLOODPRESSURE=@bloodpressure,BP_ISNORMAL=@bpnormal,RESPIRATION=@respiration, " & _
                                    " R_ISNORMAL=@respnormal,PULSERATE=@pulserate,P_ISNORMAL=@pulsenormal,O2SAT=@o2sat,O2_ISNORMAL=@o2normal,WEIGHT=@weight,HIEGHT=@height " & _
                                    " Where VitalSignNo =@charlie;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@charlie", charlie)
            '
            If vsdet = det Then
                If vsrbRegular.Checked = True Then
                    cmd.Parameters.AddWithValue("@status", "Regular")
                Else
                    cmd.Parameters.AddWithValue("@status", "Appointment")
                End If
                'The following code will check if textbox already contains "mmHg,°C,bpm,%,kg,cm"
                If isContainsmmHg(vstxtbxBP) Then
                    cmd.Parameters.AddWithValue("@bloodpressure", vstxtbxBP.Text)
                Else
                    cmd.Parameters.AddWithValue("@bloodpressure", vstxtbxBP.Text + "mmHg")
                End If
                '
                If isContainsC(vstxtbxBT) Then
                    cmd.Parameters.AddWithValue("@bodytemp", vstxtbxBT.Text)
                Else
                    cmd.Parameters.AddWithValue("@bodytemp", vstxtbxBT.Text + "°C")
                End If
                '
                If isContainsbpm(vstxtbxPR) Then
                    cmd.Parameters.AddWithValue("@pulserate", vstxtbxPR.Text)
                Else
                    cmd.Parameters.AddWithValue("@pulserate", vstxtbxPR.Text + "bpm")
                End If
                '
                If isContainsbpm(vstxtbxResp) Then
                    cmd.Parameters.AddWithValue("@respiration", vstxtbxResp.Text)
                Else
                    cmd.Parameters.AddWithValue("@respiration", vstxtbxResp.Text + "bpm")
                End If
                '
                If isContainsprcnt(vstxtO2sat) Then
                    cmd.Parameters.AddWithValue("@o2sat", vstxtO2sat.Text)
                Else
                    cmd.Parameters.AddWithValue("@o2sat", vstxtO2sat.Text + "%")
                End If
                '
                If isContainskg(vstxtbxWeight) Then
                    cmd.Parameters.AddWithValue("@weight", vstxtbxWeight.Text)
                Else
                    cmd.Parameters.AddWithValue("@weight", vstxtbxWeight.Text + "kg")
                End If
                '
                If isContainscm(vstxtbxHeight) Then
                    cmd.Parameters.AddWithValue("@height", vstxtbxHeight.Text)
                Else
                    cmd.Parameters.AddWithValue("@height", vstxtbxHeight.Text + "cm")
                End If
                '
                cmd.Parameters.AddWithValue("@bpnormal", vscmbxBP.Text)
                cmd.Parameters.AddWithValue("@btnormal", vscmbxBT.Text)
                cmd.Parameters.AddWithValue("@pulsenormal", vscmbxPR.Text)
                cmd.Parameters.AddWithValue("@respnormal", vscmbxResp.Text)
                cmd.Parameters.AddWithValue("@o2normal", vscmbxO2sat.Text)
                '
                Dim answer As DialogResult = MsgBox("Please confirm if you want to update the record.", MsgBoxStyle.YesNo)
                If answer = Windows.Forms.DialogResult.Yes Then
                    cmd.ExecuteNonQuery()
                    MsgBox("Update successful!")
                    loadUpdatedVitalSignsRcrd()
                    '
                    'Capture user activity
                    Dim intrfce As String = "Add Vital Signs"
                    Dim btn As String = "Update"
                    Dim actn As String = "Update vital signs of patient " & vslblFname.Text & "."
                    UserActivity(intrfce, btn, actn)
                    'reset private variables
                    intrfce = Nothing
                    btn = Nothing
                    actn = Nothing
                    '
                End If
            Else
                MessageBox.Show("Security restriction!" + vbCrLf + "Note: You can only update records with date today [" + checkdeyt.ToString("D") + "].", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            cmd.Dispose()
            db.pubSqlCon.Close()
            clearFields()
        End Using
    End Sub
    'x. Load updated vital signs record
    Public Sub loadUpdatedVitalSignsRcrd()
        Dim db As New KonekDB
        Dim lclPersonID = Nothing
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tv.VitalSignNo,tp.PersonID,tv.STATUS,tv.VS_DATE as DATE,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', tp.LASTNAME) as FULLNAME, tp.AGE, tp.SEX, " & _
                                    " CONCAT(tv.BODYTEMP,' - [Normal: ',tv.BT_ISNORMAL,']') as BODY_TEMP, CONCAT(tv.BLOODPRESSURE,' - [Normal: ',tv.BP_ISNORMAL,']') AS BLOOD_PRESSURE, " & _
                                    " CONCAT(tv.RESPIRATION,' - [Normal: ',tv.R_ISNORMAL,']') as RESPIRATION_RATE, CONCAT(tv.PULSERATE,' - [Normal: ',tv.P_ISNORMAL,']') as PULSERATE, " & _
                                    " CONCAT(tv.O2SAT,' - [Normal: ',tv.O2_ISNORMAL,']') as O2_SAT, tv.WEIGHT, tv.HIEGHT  from tblVitalSigns as tv " & _
                                    " Inner join tblPerson as tp On tv.PersonID = tp.PersonID where tv.VitalSignNo = @vnum; ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@vnum", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            vsDGV.DataSource = dt
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
        charlie = Nothing
        charlie2 = Nothing
    End Sub
    'xi. Does contain (bpm,mmHg,kg,cm)
    'a.
    Public Function isContainsmmHg(txtbox As TextBox) As Boolean
        Dim word As String = "mmHg"
        Return Regex.IsMatch(txtbox.Text, word)
    End Function
    'b.
    Public Function isContainsC(txtbox As TextBox) As Boolean
        Dim word As String = "°C"
        Return Regex.IsMatch(txtbox.Text, word)
    End Function
    'c.
    Public Function isContainsbpm(txtbox As TextBox) As Boolean
        Dim word As String = "bpm"
        Return Regex.IsMatch(txtbox.Text, word)
    End Function
    'd
    Public Function isContainsprcnt(txtbox As TextBox) As Boolean
        Dim word As String = "%"
        Return Regex.IsMatch(txtbox.Text, word)
    End Function
    'e.
    Public Function isContainskg(txtbox As TextBox) As Boolean
        Dim word As String = "kg"
        Return Regex.IsMatch(txtbox.Text, word)
    End Function
    'f.
    Public Function isContainscm(txtbox As TextBox) As Boolean
        Dim word As String = "cm"
        Return Regex.IsMatch(txtbox.Text, word)
    End Function
    'xii. Search record by lastname
    Public Sub searchbyLastname()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tv.VitalSignNo,tp.PersonID,tv.STATUS,tv.VS_DATE as DATE,CONCAT(tp.LASTNAME, ', ', tp.FIRSTNAME, ', ',tp.MIDDLENAME) as FULLNAME,tp.AGE, tp.SEX, " & _
                                    " CONCAT(tv.BODYTEMP,' - [Normal: ',tv.BT_ISNORMAL,']') as BODY_TEMP, CONCAT(tv.BLOODPRESSURE,' - [Normal: ',tv.BP_ISNORMAL,']') AS BLOOD_PRESSURE, " & _
                                    " CONCAT(tv.RESPIRATION,' - [Normal: ',tv.R_ISNORMAL,']') as RESPIRATION_RATE, CONCAT(tv.PULSERATE,' - [Normal: ',tv.P_ISNORMAL,']') as PULSERATE, " & _
                                    " CONCAT(tv.O2SAT,' - [Normal: ',tv.O2_ISNORMAL,']') as O2_SAT, tv.WEIGHT, tv.HIEGHT  from tblVitalSigns as tv " & _
                                    " Inner join tblPerson as tp On tv.PersonID = tp.PersonID " & _
                                    " Where CONCAT(tp.LASTNAME, ', ', tp.FIRSTNAME, ', ',tp.MIDDLENAME) like '' +@lastname+ '%' ORDER by DATE DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lastname", vstxtbxSrchLname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            vsDGV.DataSource = dt
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'xiii. Clear fields
    Public Sub clearFields()
        vslblFname.Text = ""
        vslblAge.Text = ""
        vslblGender.Text = ""
        '
        vstxtbxBP.Text = ""
        vstxtbxBT.Text = ""
        vstxtbxPR.Text = ""
        vstxtbxResp.Text = ""
        vstxtO2sat.Text = ""
        vstxtbxWeight.Text = ""
        vstxtbxHeight.Text = ""
        '
        vscmbxBP.Text = ""
        vscmbxBT.Text = ""
        vscmbxPR.Text = ""
        vscmbxResp.Text = ""
        vscmbxO2sat.Text = ""
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
End Class