Imports System.Data.SqlClient
Public Class ProfileFrm
    '!COMMENT: BUTTONS
    'i.  Update
    Private Sub upibtnUpdate_Click(sender As Object, e As EventArgs) Handles upibtnUpdate.Click
        Dim answer As DialogResult = MessageBox.Show("Would you like to update your personal information?" & vbCrLf & vbCrLf & "Warning! you will need to login again after changes is made.", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = Windows.Forms.DialogResult.Yes Then
            captureUAupdate()
            updateClinicPersonnelInfo()
        End If
        'End If
    End Sub '//green code
    'END!
    '*************************************************************************************
    '!COMMENT: EVENTS
    'i. Form closing
    Private Sub ProfileFrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        UserDashboard.returntoUserDashboard()
    End Sub
    'ii. Form load
    Private Sub ProfileFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureUALoadFrm()
        loadDOBday()
        loadDOByear()
        loadUserInfo()
        restrictEditFeilds()
    End Sub '//green code
    'iii. Combo box Year index changed
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles upiDOByear.SelectedIndexChanged
        Dim dobYear As Integer = Nothing
        Dim yr As Integer = Year(Today)
        If upiDOByear.Text = Nothing Then
            upiAge.Text = ""
        Else
            dobYear = CInt(upiDOByear.Text)
            upiAge.Text = yr - dobYear
        End If
    End Sub
    'iv. Combo box Checkbox checked change
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles upiCheckbox.CheckedChanged
        If upiCheckbox.CheckState = CheckState.Checked Then
            allowEditFields()
        Else
            loadUserInfo()
            restrictEditFeilds()
        End If
    End Sub
    'v. Contact number (Allow numbers only)
    Private Sub upiCnum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles upiCnum.KeyPress
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    'vi. Txtfields (Allow letters only)
    Private Sub upiFname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles upiMname.KeyPress, upiLname.KeyPress, upiFname.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    'END
    '*************************************************************************************
    '!COMMENTS: METHODS
    Public Sub loadUserInfo()
        upiFname.Text = cp_fname
        upiMname.Text = cp_mname
        upiLname.Text = cp_lname
        upiAge.Text = cp_Age
        upiGender.Text = cp_gender
        upiDOBday.Text = cp_dobDay
        upiDOBMonth.Text = cp_dobMonth
        upiDOByear.Text = cp_dobYear
        upiAddress.Text = cp_address
        upiCnum.Text = cp_contactno
    End Sub
    'ii. Update Clinic Personnel
    Public Sub updateClinicPersonnelInfo()
        Dim bolFname As Boolean = istxtFeildsEmpty(upiFname)
        Dim bolmname As Boolean = istxtFeildsEmpty(upiMname)
        Dim bollname As Boolean = istxtFeildsEmpty(upiLname)
        Dim bolCnum As Boolean = istxtFeildsEmpty(upiCnum)
        Dim bolAddress As Boolean = istxtFeildsEmpty(upiAddress)
        Dim bolGender As Boolean = iscmbxEmpty(upiGender)
        Dim bolday As Boolean = iscmbxEmpty(upiDOBday)
        Dim bolMnth As Boolean = iscmbxEmpty(upiDOBMonth)
        Dim bolYr As Boolean = iscmbxEmpty(upiDOByear)
        If bolFname Then
            msgbBoxShw()
        ElseIf bolmname Then
            msgbBoxShw()
        ElseIf bollname Then
            msgbBoxShw()
        ElseIf bolCnum Then
            msgbBoxShw()
        ElseIf bolAddress Then
            msgbBoxShw()
        ElseIf bolGender Then
            msgbBoxShw()
        ElseIf bolday Then
            msgbBoxShw()
        ElseIf bolMnth Then
            msgbBoxShw()
        ElseIf bolYr Then
            msgbBoxShw()
        Else
            Dim db As New KonekDB
            db.FETCHDBINFO()
            Using cmd As New SqlCommand("Update tblClinicPersonnel set FIRSTNAME=@fname,MIDDLENAME=@mname,LASTNAME=@lname,DOB_DAY=@day,DOB_MONTH=@mnth,DOB_YEAR=@year,AGE=@age,GENDER=@gender,ADDRESS=@address,CONTACTNO=@contact where ClinicPersonnelID=@personelid;  ", db.pubSqlCon)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@personelid", c_personnel_id)
                cmd.Parameters.AddWithValue("@fname", upiFname.Text)
                cmd.Parameters.AddWithValue("@mname", upiMname.Text)
                cmd.Parameters.AddWithValue("@lname", upiLname.Text)
                cmd.Parameters.AddWithValue("@day", upiDOBday.Text)
                cmd.Parameters.AddWithValue("@mnth", upiDOBMonth.Text)
                cmd.Parameters.AddWithValue("@year", upiDOByear.Text)
                cmd.Parameters.AddWithValue("@age", upiAge.Text)
                cmd.Parameters.AddWithValue("@gender", upiGender.Text)
                cmd.Parameters.AddWithValue("@address", upiAddress.Text)
                cmd.Parameters.AddWithValue("@contact", upiCnum.Text)
                cmd.ExecuteNonQuery()
                db.pubSqlCon.Close()
                cmd.Dispose()
                MsgBox("Record has been successfully updated!")
                MsgBox("This window will close." & vbCrLf & "Please login again to refresh the changes you made." & vbCrLf & vbCrLf & "Thank you.", MsgBoxStyle.Information)
                Me.Close()
                UserDashboard.Close()
                reset_login_variables()
                reset_doctor_variables()
                LoginForm.Show()
            End Using
        End If
    End Sub
    'vi. Load DOB day
    Public Sub loadDOBday()
        For i As Integer = 1 To 32
            upiDOBday.Items.Add(i)
        Next
    End Sub
    'vii. Load DOB year
    Public Sub loadDOByear()
        Dim yr As Integer = Year(Today)
        For i As Integer = 1923 To yr
            upiDOByear.Items.Add(i)
        Next
    End Sub
    'viii. Allow edit fields
    Public Sub restrictEditFeilds()
        upibtnUpdate.Enabled = False
        '
        upiFname.ReadOnly = True
        upiMname.ReadOnly = True
        upiLname.ReadOnly = True
        upiCnum.ReadOnly = True
        upiAge.ReadOnly = True
        upiAddress.ReadOnly = True
        '
        upiGender.DropDownStyle = ComboBoxStyle.Simple
        upiDOBday.DropDownStyle = ComboBoxStyle.Simple
        upiDOBMonth.DropDownStyle = ComboBoxStyle.Simple
        upiDOByear.DropDownStyle = ComboBoxStyle.Simple
    End Sub
    'ix. Enable fields
    Public Sub allowEditFields()
        upibtnUpdate.Enabled = True
        '
        upiFname.ReadOnly = False
        upiMname.ReadOnly = False
        upiLname.ReadOnly = False
        upiCnum.ReadOnly = False
        upiAge.ReadOnly = False
        upiAddress.ReadOnly = False
        '
        upiGender.DropDownStyle = ComboBoxStyle.DropDownList
        upiDOBday.DropDownStyle = ComboBoxStyle.DropDownList
        upiDOBMonth.DropDownStyle = ComboBoxStyle.DropDownList
        upiDOByear.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    'x. Is field empty
    Public Function istxtFeildsEmpty(txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
    'xii. Is combo box empty
    Public Function iscmbxEmpty(cmbx As ComboBox) As Boolean
        Return String.IsNullOrEmpty(cmbx.Text)
    End Function
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
    '
    Public Sub captureUALoadFrm()
        Dim intrfce As String = "User Profile form"
        Dim btn As String = "N/A"
        Dim actn As String = "Open"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAupdate()
        Dim intrfce As String = "User Profile form"
        Dim btn As String = "Update"
        Dim actn As String = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!
End Class