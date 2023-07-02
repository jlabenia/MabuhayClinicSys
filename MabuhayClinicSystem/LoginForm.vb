Imports System.Data.SqlClient
Imports MabuhayClinicSystem.KonekDB
Imports MabuhayClinicSystem.Others
Imports System.Threading
Public Class LoginForm
    '!COMMENT: PRIVATE VARIABLES
    Dim loginFname As String = Nothing
    'END*!
    '************************************************************************************
    '!COMMENT: EVENTS
    'i.Enter
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        Dim db As New KonekDB
        db.FETCHDBINFO()
        If db.pubSqlCon.State = ConnectionState.Closed Then
            MsgBox("Connection to database is closed. Please contact programer.")
        Else
            lfLogin()
        End If
    End Sub '//green code
    'ii.Clear
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lfClear()
    End Sub '//green code
    'iii. View password
    Private Sub cboxView_CheckedChanged(sender As Object, e As EventArgs) Handles cboxView.CheckedChanged
        If cboxView.CheckState = CheckState.Checked Then
            txtPass.PasswordChar = "*"
        Else
            txtPass.PasswordChar = ""
        End If
    End Sub '//green code
    'iv.Change Password
    Private Sub linkChangePass_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkChangePass.LinkClicked
        lfChangePassword()
    End Sub '//green code
    'v.Remember password
    Private Sub cbxRemember_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRemember.CheckedChanged
        lfRememberUser()
    End Sub '//green code
    'END EVENTS!
    '*************************************************************************************
    '!COMMENT: EVENTS
    'i. When user enter a text on the username field
    Private Sub txtUname_Enter(sender As Object, e As EventArgs) Handles txtUname.Enter
        If txtUname.Text = "Username" Then
            txtUname.Text = ""
            txtUname.ForeColor = Color.Black
        End If
    End Sub '//green code
    'ii.When user leave the username field
    Private Sub txtUname_Leave(sender As Object, e As EventArgs) Handles txtUname.Leave
        If txtUname.Text = "" Then
            txtUname.Text = "Username"
            txtUname.ForeColor = Color.Gray
        End If
    End Sub '//green code
    'iii. When user enter a text on the password field
    Private Sub txtPass_Enter(sender As Object, e As EventArgs) Handles txtPass.Enter
        If txtPass.Text = "Password" Then
            txtPass.Text = ""
            txtPass.ForeColor = Color.Black
        End If
    End Sub '//green code
    'iv.When user leave the password field
    Private Sub txtPass_Leave(sender As Object, e As EventArgs) Handles txtPass.Leave
        If txtPass.Text = "" Then
            txtPass.Text = "Password"
            txtPass.ForeColor = Color.Gray
        End If
    End Sub '//green code
    'v.When form loads/open
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnEnter.Select()
        btnEnter.Focus()
        AcceptButton = btnEnter
        If My.Settings.rememberMe = True Then
            cbxRemember.CheckState = CheckState.Checked
            txtPass.Text = My.Settings.password
            txtUname.Text = My.Settings.username
            cboxView.CheckState = CheckState.Checked
        End If
    End Sub '//green code
    'vi. Closing event
    Private Sub LoginForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim answer As DialogResult = MessageBox.Show("Would you like to proceed closing this application?", "Closing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
            If cbxRemember.CheckState = CheckState.Unchecked Then
                My.Settings.Reset()
            End If
        End If
    End Sub '//green code
    'END OTHER EVENTS
    '*************************************************************************************
    '!COMMENT: METHODS
    'i.Clear Fields
    Public Sub lfClear()
        txtPass.Text = ""
        txtUname.Text = ""
        txtPass.Text = "Password"
        txtPass.ForeColor = Color.Gray
        txtUname.Text = "Username"
        txtUname.ForeColor = Color.Gray
    End Sub '//green code
    'ii.Login
    Public Sub lfLogin()
        Dim sqlDa = New SqlDataAdapter
        Dim sqlDt = New DataTable
        Dim sqlCmd = New SqlCommand
        Dim sqlStr As String = ""
        Dim db As New KonekDB
        db.FETCHDBINFO()
        sqlStr = "Select UserID, USERTYPE, USERNAME, PASSWORD From tblUserAccounts  Where USERNAME=@username And PASSWORD=@password;"
        With sqlCmd
            .Connection = db.pubSqlCon
            .CommandText = sqlStr
            .Parameters.Clear()
            .Parameters.AddWithValue("username", txtUname.Text)
            .Parameters.AddWithValue("password", txtPass.Text)
        End With
        sqlDa.SelectCommand = sqlCmd
        sqlDa.Fill(sqlDt)
        db.pubSqlCon.Close()
        'Check the user category
        If sqlDt.Rows.Count > 0 Then
            loginUserid = sqlDt.Rows(0).Item("UserID")
            loginUserType = sqlDt.Rows(0).Item("USERTYPE")
            loginUsername = sqlDt.Rows(0).Item("USERNAME")
            'NEXT: Check where does the login belong to (ADMIN, CLINIC PERSONNEL, DOCTOR)
            If loginUserType = "DOCTOR" Then
                'Code for doctor information
                getDoctorInfo()
                loginFname = doctorFname & " " & doctorMname & " " & doctorLname
                lfLogHistory(loginFname)
                lfRememberUser()
                lfClear()
                Me.Hide()
                DoctorDashboard.Show()
            ElseIf loginUserType = "USER" Then
                'Code for clinic personnel information
                getClinicPersonnelInfo()
                loginFname = cp_fname & " " & cp_mname & " " & cp_lname
                lfLogHistory(loginFname)
                lfRememberUser()
                lfClear()
                Me.Hide()
                UserDashboard.Show()
            ElseIf loginUserType = "ADMIN" Then
                getAdminInfo()
                loginFname = adminfirstname & " " & adminMiddlename & " " & adminLastname
                lfLogHistory(loginFname)
                lfRememberUser()
                lfClear()
                Me.Hide()
                AdminDashboard.Show()
            End If
            'NEXT: Else code means the username & password does not match resulting to "0" datatabl rows
        Else
            MessageBox.Show("Failed to logIn! Please check your inputs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        sqlDa.Dispose()
        sqlDt.Dispose()
        sqlCmd.Dispose()
    End Sub '//green code
    'iii. User login history
    Public Sub lfLogHistory(ByVal who As String)
        ''Capture login
        'Dim det As Date = CDate(Date.Now.ToShortDateString())
        'Dim taym As TimeSpan = Date.Now.TimeOfDay
        'Dim db As New KonekDB
        'db.FETCHDBINFO()
        ''Insert new record
        'Using cmd As New SqlCommand("Insert into tblLogHistory (UserID, FULLNAME,LOGIN_TIME,LOGIN_DATE,LOGOUT_TIME,LOGOUT_DATE) values (@userid, @fullname,@login_time,@login_date,@logout_time, @logout_date);", db.pubSqlCon)
        '    cmd.Parameters.Clear()
        '    cmd.Parameters.Add("@userid", System.Data.SqlDbType.Int).Value = loginUserid
        '    cmd.Parameters.Add("@fullname", System.Data.SqlDbType.VarChar).Value = who
        '    cmd.Parameters.Add("@login_time", System.Data.SqlDbType.Time).Value = taym
        '    cmd.Parameters.Add("@login_date", System.Data.SqlDbType.Date).Value = det
        '    cmd.Parameters.Add("@logout_time", System.Data.SqlDbType.Time).Value = DBNull.Value
        '    cmd.Parameters.Add("@logout_date", System.Data.SqlDbType.Date).Value = DBNull.Value
        '    cmd.ExecuteNonQuery()
        '    db.pubSqlCon.Close()
        '    cmd.Dispose()
        'End Using
        ''Get the current LogNo for later use
        'Using da As New SqlDataAdapter("Select MAX(LogNo) as num from tblLogHistory;", db.pubSqlCon)
        '    Dim dt As New DataTable
        '    dt.Rows.Clear()
        '    da.Fill(dt)
        '    If dt.Rows.Count > 0 Then
        '        logNo = dt.Rows(0).Item("num")
        '    End If
        '    db.pubSqlCon.Close()
        '    dt.Dispose()
        '    da.Dispose()
        'End Using
    End Sub '//green code

    'v. Admin Login history
    '//
    'CODE HERE
    '//
   
    'vi. Remember user
    Public Sub lfRememberUser()
        Try
            If cbxRemember.CheckState = CheckState.Checked Then
                My.Settings.username = txtUname.Text
                My.Settings.password = txtPass.Text
                My.Settings.rememberMe = True
                My.Settings.Save()
                My.Settings.Reload()
            Else
                My.Settings.Reset()
                cbxRemember.CheckState = CheckState.Unchecked
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub '//green code
    'vii. Get doctor info
    Public Sub getDoctorInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select DoctorID,LicensedNo,FIRSTNAME,MIDDLENAME,LASTNAME,AGE,SEX,B_DAY,B_MONTH,B_YEAR, ADDRESS,CONTACTNO,SPECIALIZATION from tblDoctor where DoctorID=@userid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@userid", loginUserid)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                doctorID = dt.Rows(0).Item("DoctorID")
                licensedNo = dt.Rows(0).Item("LicensedNo")
                doctorFname = dt.Rows(0).Item("FIRSTNAME")
                doctorMname = dt.Rows(0).Item("MIDDLENAME")
                doctorLname = dt.Rows(0).Item("LASTNAME")
                doctorgender = dt.Rows(0).Item("SEX")
                doctoraddress = dt.Rows(0).Item("ADDRESS")
                dr_contactNo = dt.Rows(0).Item("CONTACTNO")
                specialization = dt.Rows(0).Item("SPECIALIZATION")
                doctorAge = dt.Rows(0).Item("AGE")
                doctorBday = dt.Rows(0).Item("B_DAY")
                doctorMonth = dt.Rows(0).Item("B_MONTH")
                doctorYear = dt.Rows(0).Item("B_YEAR")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
            MessageBox.Show("Welcome " + doctorFname.ToString() & " " & doctorMname.ToString() & " " & doctorLname.ToString() & " !", "Login Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub '//Green code
    'viii. Get clinic personnel info
    Public Sub getClinicPersonnelInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd1 As New SqlCommand("Select UserID,ClinicPersonnelID,FIRSTNAME,MIDDLENAME,LASTNAME,DOB_DAY,DOB_MONTH,DOB_YEAR,AGE,GENDER,CONTACTNO,ADDRESS from tblClinicPersonnel where UserID =@userid;", db.pubSqlCon)
            cmd1.Parameters.Clear()
            cmd1.Parameters.AddWithValue("@userid", loginUserid)
            Dim da As New SqlDataAdapter(cmd1)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                c_personnel_id = dt.Rows(0).Item("ClinicPersonnelID")
                cp_fname = dt.Rows(0).Item("FIRSTNAME")
                cp_mname = dt.Rows(0).Item("MIDDLENAME")
                cp_lname = dt.Rows(0).Item("LASTNAME")
                cp_dobDay = dt.Rows(0).Item("DOB_DAY")
                cp_dobMonth = dt.Rows(0).Item("DOB_MONTH")
                cp_dobYear = dt.Rows(0).Item("DOB_YEAR")
                cp_Age = dt.Rows(0).Item("AGE")
                cp_gender = dt.Rows(0).Item("GENDER")
                cp_contactno = dt.Rows(0).Item("CONTACTNO")
                cp_address = dt.Rows(0).Item("ADDRESS")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd1.Dispose()
            MessageBox.Show("Welcome " + cp_fname.ToString() & " " & cp_mname.ToString() & " " & cp_lname.ToString() & " !", "Login Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub '//Green code
    'ix. Get admin info
    Public Sub getAdminInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd1 As New SqlCommand("Select UserID,ClinicPersonnelID,FIRSTNAME,MIDDLENAME,LASTNAME,DOB_DAY,DOB_MONTH,DOB_YEAR,AGE,GENDER,CONTACTNO,ADDRESS from tblClinicPersonnel where UserID =@userid;", db.pubSqlCon)
            cmd1.Parameters.Clear()
            cmd1.Parameters.AddWithValue("@userid", loginUserid)
            Dim da As New SqlDataAdapter(cmd1)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                adminid = dt.Rows(0).Item("ClinicPersonnelID")
                adminfirstname = dt.Rows(0).Item("FIRSTNAME")
                adminMiddlename = dt.Rows(0).Item("MIDDLENAME")
                adminLastname = dt.Rows(0).Item("LASTNAME")
                adminAge = dt.Rows(0).Item("AGE")
                admingender = dt.Rows(0).Item("GENDER")
                adminDOBday = dt.Rows(0).Item("DOB_DAY")
                adminDOBmonth = dt.Rows(0).Item("DOB_MONTH")
                adminDOByear = dt.Rows(0).Item("DOB_YEAR")
                admincontactnum = dt.Rows(0).Item("CONTACTNO")
                adminAddress = dt.Rows(0).Item("ADDRESS")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd1.Dispose()
            MessageBox.Show("Welcome " + "ADMIN " + adminfirstname.ToString() & " " & adminMiddlename.ToString() & " " & adminLastname.ToString() & " !", "Login Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub
    'x. Change password
    Public Sub lfChangePassword()
        Dim sqlDa = New SqlDataAdapter
        Dim sqlDt = New DataTable
        Dim sqlCmd = New SqlCommand
        Dim sqlStr As String = ""
        Dim db As New KonekDB
        db.FETCHDBINFO()
        sqlStr = "Select UserID, USERTYPE, USERNAME, PASSWORD From tblUserAccounts  Where USERNAME=@username And PASSWORD=@password;"
        With sqlCmd
            .Connection = db.pubSqlCon
            .CommandText = sqlStr
            .Parameters.Clear()
            .Parameters.AddWithValue("username", txtUname.Text)
            .Parameters.AddWithValue("password", txtPass.Text)
        End With
        sqlDa.SelectCommand = sqlCmd
        sqlDa.Fill(sqlDt)
        'Check the user category
        If sqlDt.Rows.Count > 0 Then
            loginUserid = sqlDt.Rows(0).Item("UserID")
            loginUserType = sqlDt.Rows(0).Item("USERTYPE")
            loginUsername = sqlDt.Rows(0).Item("USERNAME")
            'NEXT: Check where does the login belong to (ADMIN, CLINIC PERSONNEL, DOCTOR)
            If loginUserType = "DOCTOR" Then
                'Code for doctor information
                getDoctorInfo()
            ElseIf loginUserType = "USER" Then
                'Code for clinic personnel information
                getClinicPersonnelInfo()
            ElseIf loginUserType = "ADMIN" Then
                '//
                'ADMIN CODE HERE
                '//
            End If
            'NEXT: Else code means the username & password does not match resulting to "0" datatabl rows
            Me.Hide()
            ChangePasswordfrmvb.Show()
        Else
            MessageBox.Show("Failed to logIn! Please check your inputs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        sqlDa.Dispose()
        sqlDt.Dispose()
        sqlCmd.Dispose()
        db.pubSqlCon.Close()
    End Sub '//green code
    'END METHODS!
End Class
