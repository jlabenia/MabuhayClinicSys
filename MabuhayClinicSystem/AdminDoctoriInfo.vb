Imports System.Data.SqlClient
Public Class AdminDoctoriInfo
    '!COMMENT: PRIVATE VARIABLES
    Dim charlie As Integer = Nothing
    'END!
    '*************************************************************************************
    '!COMMENT: BUTTONS

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        btnAdd.Enabled = True
        btnUpdate.Enabled = False
        charlie = Nothing
        clearFields()
        loadDoctorInfo()
    End Sub
    '
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim bolfname As Boolean = IstxtEmpty(txtFname)
        Dim bolmname As Boolean = IstxtEmpty(txtMname)
        Dim bollname As Boolean = IstxtEmpty(txtLname)
        Dim bolAge As Boolean = IstxtEmpty(txtAge)
        Dim bolAddress As Boolean = IstxtEmpty(txtAddress)
        Dim bolContact As Boolean = IstxtEmpty(txtContactNo)
        Dim bolpassword As Boolean = IstxtEmpty(txtPassword)
        Dim bolusername As Boolean = IstxtEmpty(txtUsername)
        Dim bollicensed As Boolean = IstxtEmpty(txtLicensedNo)
        Dim bolspecialization As Boolean = IstxtEmpty(txtSpecilization)
        '
        Dim bolgender As Boolean = IscmbxEmpty(cmbxGender)
        Dim bolusertype As Boolean = IscmbxEmpty(cmbxUserType)
        Dim bolDOBday As Boolean = IscmbxEmpty(cmbxDOBday)
        Dim bolDOBmonth As Boolean = IscmbxEmpty(cmbxDOBmonth)
        Dim bolDOByear As Boolean = IscmbxEmpty(cmbxDOByear)
        '
        If bollicensed Then
            msgbBoxShw()
        ElseIf bolfname Then
            msgbBoxShw()
        ElseIf bolmname Then
            msgbBoxShw()
        ElseIf bollname Then
            msgbBoxShw()
        ElseIf bolAge Then
            msgbBoxShw()
        ElseIf bolAddress Then
            msgbBoxShw()
        ElseIf bolContact Then
            msgbBoxShw()
        ElseIf bolpassword Then
            msgbBoxShw()
        ElseIf bolusername Then
            msgbBoxShw()
        ElseIf bolspecialization Then
            msgbBoxShw()
        ElseIf bolgender Then
            msgbBoxShw()
        ElseIf bolusertype Then
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
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim bolfname As Boolean = IstxtEmpty(txtFname)
        Dim bolmname As Boolean = IstxtEmpty(txtMname)
        Dim bollname As Boolean = IstxtEmpty(txtLname)
        Dim bolAge As Boolean = IstxtEmpty(txtAge)
        Dim bolAddress As Boolean = IstxtEmpty(txtAddress)
        Dim bolContact As Boolean = IstxtEmpty(txtContactNo)
        Dim bollicensed As Boolean = IstxtEmpty(txtLicensedNo)
        Dim bolspecialization As Boolean = IstxtEmpty(txtSpecilization)
        '
        Dim bolgender As Boolean = IscmbxEmpty(cmbxGender)
        Dim bolDOBday As Boolean = IscmbxEmpty(cmbxDOBday)
        Dim bolDOBmonth As Boolean = IscmbxEmpty(cmbxDOBmonth)
        Dim bolDOByear As Boolean = IscmbxEmpty(cmbxDOByear)
        '
        If charlie <> 0 Then
            If bollicensed Then
                msgbBoxShw()
            ElseIf bolfname Then
                msgbBoxShw()
            ElseIf bolmname Then
                msgbBoxShw()
            ElseIf bollname Then
                msgbBoxShw()
            ElseIf bolAge Then
                msgbBoxShw()
            ElseIf bolAddress Then
                msgbBoxShw()
            ElseIf bolContact Then
                msgbBoxShw()
            ElseIf bolspecialization Then
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
                Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to update this record." & vbCrLf & "Click YES to confitm otherwise click NO.", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If answer = Windows.Forms.DialogResult.Yes Then
                    updateRecord()
                    clearFields()
                    loadUpdateRecord()
                    btnAdd.Enabled = True
                    btnUpdate.Enabled = False
                Else
                    Exit Sub
                End If
            End If
        End If
    End Sub
    '
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If charlie <> 0 Then
            deleteRecord()
        Else
            MsgBox("Please select a record.")
        End If
    End Sub
    'END!
    '*************************************************************************************
    '!COMMENT: EVENTS
    Private Sub AdminDoctoriInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDoctorInfo()
        loadDOByear()
    End Sub
    '
    Private Sub AdminDoctoriInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadManageClinic()
    End Sub
    '
    Private Sub dgvDoctor_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDoctor.CellClick
        Try
            Dim romeo As Integer = Nothing
            charlie = Nothing
            If dgvDoctor.RowCount > 0 Then
                romeo = dgvDoctor.CurrentRow.Index
                charlie = dgvDoctor.Item(0, romeo).Value
                populateRecordsToFields()
                btnAdd.Enabled = False
                btnUpdate.Enabled = True
            End If
        Catch
            charlie = Nothing
            clearFields()
        End Try
    End Sub
    '
    Private Sub cmbxDOByear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxDOByear.SelectedIndexChanged
        Dim age As Integer = 0
        Dim brthYear As Integer = 0
        Dim yrToday As Integer = CInt(Year(Today))
        '
        If cmbxDOByear.Text <> "" Then
            brthYear = CInt(cmbxDOByear.Text)
            age = yrToday - brthYear
            txtAge.Text = age.ToString()
        Else
            txtAge.Text = ""
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text <> "" Then
            searchDoctor()
        Else
            loadDoctorInfo()
        End If
    End Sub '//For review
    '
    Private Sub LetterOnly(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress, txtMname.KeyPress, txtLname.KeyPress, txtFname.KeyPress
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
    'END!
    '*************************************************************************************
    '!COMMENT: METHODS
    Public Sub clearFields()
        txtPassword.PasswordChar = Nothing
        txtUsername.PasswordChar = Nothing
        txtFname.Text = ""
        txtMname.Text = ""
        txtLname.Text = ""
        txtAge.Text = ""
        txtAddress.Text = ""
        txtContactNo.Text = ""
        txtSearch.Text = ""
        txtPassword.Text = ""
        txtUsername.Text = ""
        txtSpecilization.Text = ""
        txtLicensedNo.Text = ""
        '
        cmbxGender.SelectedIndex = -1
        cmbxUserType.SelectedIndex = -1
        cmbxDOBday.SelectedIndex = -1
        cmbxDOBmonth.SelectedIndex = -1
        cmbxDOByear.SelectedIndex = -1
    End Sub
    '
    Public Sub readOnlyFields()
        txtUsername.PasswordChar = "*"
        txtPassword.PasswordChar = "*"
    End Sub
    '
    Public Sub loadDoctorInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select DoctorID,LicensedNo,CONCAT(FIRSTNAME,' ',MIDDLENAME,' ',LASTNAME) as FULLNAME,SPECIALIZATION,B_DAY,B_MONTH,B_YEAR,AGE,SEX as GENDER,CONTACTNO,ADDRESS from tblDoctor order by DoctorID ASC;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvDoctor.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub saveNewRecord()
        Dim db As New KonekDB
        Dim doctorID As Integer = Nothing 'serves as USERID for login
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Insert into tblUserAccounts (USERTYPE,USERNAME,PASSWORD) values (@usertype,@username,@password);", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@usertype", SqlDbType.VarChar).Value = cmbxUserType.Text
            cmd.Parameters.Add("@username", SqlDbType.Text).Value = txtUsername.Text
            cmd.Parameters.Add("@password", SqlDbType.Text).Value = txtPassword.Text
            cmd.ExecuteNonQuery()
            'Get the current login id
            Using da As New SqlDataAdapter("Select MAX(UserID) as userid from tblUserAccounts;", db.pubSqlCon)
                Dim dt As New DataTable
                dt.Rows.Clear()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    DoctorID = dt.Rows(0).Item("userid")
                End If
                dt.Dispose()
                da.Dispose()
            End Using
            db.pubSqlCon.Close()
            cmd.Dispose()
        End Using
        'Add new doctor record. Note: DoctorID serves as a Primary key for this table & Foreign key for table UserAccounts instead of using UserID. Furthermore, LicensedNo serves as a candidate key or refer to as unique key(but not primary key)
        Using cmd1 As New SqlCommand("Insert into tblDoctor (DoctorID,LicensedNo,FIRSTNAME,MIDDLENAME,LASTNAME,SEX,AGE,B_DAY,B_MONTH,B_YEAR,ADDRESS,CONTACTNO,SPECIALIZATION) values (@doctorid,@licensedno,@fname,@mname,@lname,@sex,@age,@day,@month,@year,@address,@contactno,@specialization);", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd1.Parameters.Clear()
            cmd1.Parameters.Add("@doctorid", SqlDbType.Int).Value = doctorID
            cmd1.Parameters.Add("@licensedno", SqlDbType.Text).Value = txtLicensedNo.Text
            cmd1.Parameters.Add("@fname", SqlDbType.VarChar).Value = txtFname.Text
            cmd1.Parameters.Add("@mname", SqlDbType.VarChar).Value = txtMname.Text
            cmd1.Parameters.Add("@lname", SqlDbType.VarChar).Value = txtLname.Text
            cmd1.Parameters.Add("@sex", SqlDbType.VarChar).Value = cmbxGender.Text
            cmd1.Parameters.Add("@age", SqlDbType.Int).Value = txtAge.Text
            cmd1.Parameters.Add("@day", SqlDbType.Int).Value = cmbxDOBday.Text
            cmd1.Parameters.Add("@month", SqlDbType.VarChar).Value = cmbxDOBmonth.Text
            cmd1.Parameters.Add("@year", SqlDbType.Int).Value = cmbxDOByear.Text
            cmd1.Parameters.Add("@address", SqlDbType.Text).Value = txtAddress.Text
            cmd1.Parameters.Add("@contactno", SqlDbType.VarChar).Value = txtContactNo.Text
            cmd1.Parameters.Add("@specialization", SqlDbType.Text).Value = txtSpecilization.Text
            cmd1.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd1.Dispose()
            MsgBox("New record added!")
            doctorID = Nothing
        End Using
    End Sub
    '
    Public Sub loadNewRecord()
        Dim doctorID As Integer = Nothing
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Get current doctor id
        Using da As New SqlDataAdapter("Select MAX(DoctorID) as id from tblDoctor;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                doctorID = dt.Rows(0).Item("id")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
        'Load new record of doctor using doctor id
        Using cmd As New SqlCommand("Select DoctorID,LicensedNo,CONCAT(FIRSTNAME,' ',MIDDLENAME,' ',LASTNAME) as FULLNAME,SPECIALIZATION,B_DAY,B_MONTH,B_YEAR,AGE,SEX as GENDER,CONTACTNO,ADDRESS from tblDoctor " & _
                                    " Where DoctorID=@doctorid;", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@doctorid", doctorID)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvDoctor.DataSource = dt
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
    Public Function IscmbxEmpty(ByVal cmbx As ComboBox) As Boolean
        Return String.IsNullOrEmpty(cmbx.Text)
    End Function
    '
    Public Sub populateRecordsToFields()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tdoc.DoctorID,tdoc.LicensedNo,tdoc.FIRSTNAME,tdoc.MIDDLENAME,tdoc.LASTNAME,tdoc.SPECIALIZATION,tdoc.B_DAY,tdoc.B_MONTH,tdoc.B_YEAR,tdoc.AGE,tdoc.SEX,tdoc.CONTACTNO,tdoc.ADDRESS,tua.USERTYPE,tua.PASSWORD,tua.USERNAME from tblDoctor as tdoc " & _
" Inner Join tblUserAccounts as tua On tdoc.DoctorID = tua.UserID " & _
" Where tdoc.DoctorID=@doctorid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@doctorid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                readOnlyFields()
                '
                txtLicensedNo.Text = dt.Rows(0).Item("LicensedNo")
                txtSpecilization.Text = dt.Rows(0).Item("SPECIALIZATION")
                txtFname.Text = dt.Rows(0).Item("FIRSTNAME")
                txtMname.Text = dt.Rows(0).Item("MIDDLENAME")
                txtLname.Text = dt.Rows(0).Item("LASTNAME")
                txtAge.Text = dt.Rows(0).Item("AGE")
                txtAddress.Text = dt.Rows(0).Item("ADDRESS")
                txtContactNo.Text = dt.Rows(0).Item("CONTACTNO")
                txtPassword.Text = dt.Rows(0).Item("PASSWORD")
                txtUsername.Text = dt.Rows(0).Item("USERNAME")
                '
                cmbxGender.Text = dt.Rows(0).Item("SEX")
                cmbxUserType.Text = dt.Rows(0).Item("USERTYPE")
                cmbxDOBday.Text = dt.Rows(0).Item("B_DAY")
                cmbxDOBmonth.Text = dt.Rows(0).Item("B_MONTH")
                cmbxDOByear.Text = dt.Rows(0).Item("B_YEAR")
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
        Using cmd As New SqlCommand("Update tblDoctor Set LicensedNo=@licensedno,FIRSTNAME=@fname,MIDDLENAME=@mname,LASTNAME=@lname,SEX=@sex,AGE=@age,B_DAY=@day,B_MONTH=@month,B_YEAR=@year,ADDRESS=@address,CONTACTNO=@contactno,SPECIALIZATION=@specialization " & _
                                    " where DoctorID=@doctorid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@licensedno", txtLicensedNo.Text)
            cmd.Parameters.AddWithValue("@specialization", txtSpecilization.Text)
            cmd.Parameters.AddWithValue("@fname", txtFname.Text)
            cmd.Parameters.AddWithValue("@mname", txtMname.Text)
            cmd.Parameters.AddWithValue("@lname", txtLname.Text)
            cmd.Parameters.AddWithValue("@day", cmbxDOBday.Text)
            cmd.Parameters.AddWithValue("@month", cmbxDOBmonth.Text)
            cmd.Parameters.AddWithValue("@year", cmbxDOByear.Text)
            cmd.Parameters.AddWithValue("@age", txtAge.Text)
            cmd.Parameters.AddWithValue("@sex", cmbxGender.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@contactno", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@doctorid", charlie)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Update successful!")
        End Using
    End Sub
    '
    Public Sub loadUpdateRecord()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select DoctorID,LicensedNo,CONCAT(FIRSTNAME,' ',MIDDLENAME,' ',LASTNAME) as FULLNAME,SPECIALIZATION,B_DAY,B_MONTH,B_YEAR,AGE,SEX as GENDER,CONTACTNO,ADDRESS from tblDoctor " & _
                                    " Where DoctorID=@doctorid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@doctorid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvDoctor.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            charlie = Nothing
        End Using
    End Sub
    '
    Public Sub loadDOByear()
        Dim yearNow As Integer = CInt(Year(Today))
        For i As Integer = 1923 To yearNow
            cmbxDOByear.Items.Add(i)
        Next
    End Sub
    '
    Public Sub searchDoctor()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select DoctorID,LicensedNo,CONCAT(LASTNAME,', ',FIRSTNAME,' ',MIDDLENAME) as FULLNAME,SPECIALIZATION,B_DAY,B_MONTH,B_YEAR,AGE,SEX as GENDER,CONTACTNO,ADDRESS from tblDoctor " & _
                                  " Where CONCAT(LASTNAME,' ',FIRSTNAME,' ',MIDDLENAME) like '' +@lname+ '%' order by FULLNAME  ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtSearch.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvDoctor.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub deleteRecord()
        Dim hasLogHistoryRecords As Boolean = False
        Dim hasUserActivty As Boolean = False
        Dim hasConsultation As Boolean = False
        Dim hasSurgery As Boolean = False
        '
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Check if doctor has records of log history (boolean "has log history")
        Using cmd1 As New SqlCommand(" Select * from tblLogHistory where UserID = @userid;", db.pubSqlCon)
            cmd1.Parameters.Clear()
            cmd1.Parameters.AddWithValue("@userid", charlie)
            Dim da As New SqlDataAdapter(cmd1)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                hasLogHistoryRecords = True
            Else
                hasLogHistoryRecords = False
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd1.Dispose()
        End Using
        'Check if doctor has user Activity
        Using cmd2 As New SqlCommand("Select * from tblUserActivity where UserID=@userid;", db.pubSqlCon)
            cmd2.Parameters.Clear()
            cmd2.Parameters.AddWithValue("@userid", charlie)
            Dim da As New SqlDataAdapter(cmd2)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                hasUserActivty = True
            Else
                hasUserActivty = False               
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd2.Dispose()
        End Using
        'Check if doctor has records of consultation
        Using cmd3 As New SqlCommand("Select * from tblConsulatation where DoctorID=@docID;", db.pubSqlCon)
            cmd3.Parameters.Clear()
            cmd3.Parameters.AddWithValue("@docID", charlie)
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
        'Check if doctor has record of surgery
        Using cmd4 As New SqlCommand("Select * from tblSurgery where DoctorID=@docID;", db.pubSqlCon)
            cmd4.Parameters.Clear()
            cmd4.Parameters.AddWithValue("@docID", charlie)
            Dim da As New SqlDataAdapter(cmd4)
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
            cmd4.Dispose()
        End Using

        'If doctor has no record for USER ACTIVITY & LOG HISTORY, proceed to delete else ask the user 
        If hasConsultation = True Or hasSurgery = True Then
            'Warning doctor has records of patient!!
            MessageBox.Show("Security error! You cannot proceed to delete because this doctor has records of patient treated." & vbCrLf & vbCrLf & "Delete first the patient's record associated with this doctor before you proceed in deleting this doctor record." & vbCrLf & vbCrLf & "Aborting deletion...", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        Else
            If hasLogHistoryRecords = True Or hasUserActivty = True Then
                'Warning doctor has log history and user activity records!!
                Dim answer As DialogResult = MessageBox.Show("Warning! The Log history and User Activity records of this doctor will be deleted." & vbCrLf & vbCrLf & "Any changes cannot be undone." & vbCrLf & vbCrLf & "Should you wish to proceed please click YES otherwise click NO.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If answer = Windows.Forms.DialogResult.Yes Then
                    Dim Inputvalue As String = Nothing
                    Inputvalue = InputBox("To confirm that this is not a mistake, please type in numbers 1-9.", "Confirmation...")
                    If IsNumeric(Inputvalue) Then
                        If Inputvalue = "123456789" Then
                            commandDelete()
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
                    'answer if-else
                End If
            Else
                'doctor is new!
                Dim answer1 As DialogResult = MessageBox.Show("Record is new!" & vbCrLf & "Please confirm if you would want to delete this record.", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If answer1 = Windows.Forms.DialogResult.Yes Then
                    Dim Inputvalue As String = Nothing
                    Inputvalue = InputBox("To confirm that this is not a mistake, please type in numbers 1-9.", "Confirmation...")
                    If IsNumeric(Inputvalue) Then
                        If Inputvalue = "123456789" Then
                            commandDelete()
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
                    'answer1 if-else
                End If
            End If
            'first line of if-else
        End If
    End Sub '//Warning! records can be deleted if and only if doctor info is new and have not done any activity such as login, saving patient information etc.
    '
    Public Sub commandDelete()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Begin transaction; " & _
        " Delete tblLogHistory where UserID = @userid; " & _
        " Delete tblUserActivity Where UserID = @userid; " & _
        " Delete tblDoctor Where DoctorID=@docID; " & _
        " Delete tblUserAccounts Where UserID = @userid; " & _
        " Commit;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@userid", charlie)
            cmd.Parameters.AddWithValue("@docID", charlie)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            clearFields()
            loadDoctorInfo()
            charlie = Nothing
            MsgBox("Record has been deleted!")
        End Using
    End Sub
    'END!
    '*************************************************************************************
End Class