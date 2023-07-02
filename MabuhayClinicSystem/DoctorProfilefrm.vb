Imports System.Data.SqlClient
Public Class DoctorProfilefrm
    '!COMMENT:PRIVATE VARIABLES
    Dim intrfce As String = Nothing
    Dim btn As String = Nothing
    Dim actn As String = Nothing
    'END!
    '*************************************************************************************
    '!COMMENT: BUTTONS
    'i. UPDATE
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim answer As DialogResult = MessageBox.Show("Would you like to update your personal information?" & vbCrLf & vbCrLf & "Warning! you will need to login again after changes is made.", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = Windows.Forms.DialogResult.Yes Then
            captureUAupdate()
            updateDoctorInfo()
        End If
    End Sub
    'END!
    '*************************************************************************************
    '!COMMENT: EVENTS
    'i. Check box state changed
    Private Sub checkboxEdit_CheckStateChanged(sender As Object, e As EventArgs) Handles checkboxEdit.CheckStateChanged
        If checkboxEdit.CheckState = CheckState.Unchecked Then
            allowEdit()
        Else
            notAllowedEdit()
        End If
    End Sub
    'ii. Load form
    Private Sub DoctorProfilefrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureUAloadFrm()
        loadDoctorInfo()
        loadDOByear()
    End Sub
    'iii. Form closing
    Private Sub DoctorProfilefrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DoctorDashboard.returnToDashboard()
    End Sub
    'END!
    '*************************************************************************************
    '!COMMENT: METHODS
    'i. Load doctor info
    Public Sub loadDoctorInfo()
        txtLicensedno.Text = licensedNo
        txtSpecialization.Text = specialization
        txtFname.Text = doctorFname
        txtMiddleName.Text = doctorMname
        txtLname.Text = doctorLname
        txtAge.Text = doctorAge
        txtGender.Text = doctorgender
        txtcontactNo.Text = dr_contactNo
        dobDay.Text = doctorBday
        dobMonth.Text = doctorMonth
        dobYear.Text = doctorYear
        txtAddress.Text = doctoraddress
    End Sub
    'ii. Allow edit
    Public Sub allowEdit()
        txtLicensedno.ReadOnly = False
        txtSpecialization.ReadOnly = False
        txtFname.ReadOnly = False
        txtMiddleName.ReadOnly = False
        txtLname.ReadOnly = False
        txtAge.ReadOnly = False
        txtcontactNo.ReadOnly = False
        txtGender.DropDownStyle = ComboBoxStyle.DropDownList
        dobDay.DropDownStyle = ComboBoxStyle.DropDownList
        dobMonth.DropDownStyle = ComboBoxStyle.DropDownList
        dobYear.DropDownStyle = ComboBoxStyle.DropDownList
        dobYear.Text = doctorYear
        txtAddress.ReadOnly = False
        btnUpdate.Enabled = True
    End Sub
    'iii. Dis allow edit
    Public Sub notAllowedEdit()
        txtLicensedno.ReadOnly = True
        txtSpecialization.ReadOnly = True
        txtFname.ReadOnly = True
        txtMiddleName.ReadOnly = True
        txtLname.ReadOnly = True
        txtAge.ReadOnly = True
        txtcontactNo.ReadOnly = True
        txtGender.DropDownStyle = ComboBoxStyle.Simple
        dobDay.DropDownStyle = ComboBoxStyle.Simple
        dobMonth.DropDownStyle = ComboBoxStyle.Simple
        dobYear.DropDownStyle = ComboBoxStyle.Simple
        txtAddress.ReadOnly = True
        btnUpdate.Enabled = False
    End Sub
    'iv. s text field empty
    Public Function istxtFeildsEmpty(txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
    'v. Is combo box empty
    Public Function iscmbxEmpty(cmbx As ComboBox) As Boolean
        Return String.IsNullOrEmpty(cmbx.Text)
    End Function
    'vi. load combo box year
    Public Sub loadDOByear()
        Dim yr As Integer = Year(Today)
        For i As Integer = 1923 To yr
            dobYear.Items.Add(i)
        Next
    End Sub
    'vii. Update doctor info
    Public Sub updateDoctorInfo()
        Dim bolLicensed As Boolean = istxtFeildsEmpty(txtLicensedno)
        Dim bolSpecialization As Boolean = istxtFeildsEmpty(txtSpecialization)
        Dim bolFname As Boolean = istxtFeildsEmpty(txtFname)
        Dim bolMname As Boolean = istxtFeildsEmpty(txtMiddleName)
        Dim bolLname As Boolean = istxtFeildsEmpty(txtLname)
        Dim bolAge As Boolean = istxtFeildsEmpty(txtAge)
        Dim bolContactNo As Boolean = istxtFeildsEmpty(txtcontactNo)
        Dim bolDOBAddress As Boolean = istxtFeildsEmpty(txtAddress)
        '
        Dim bolDOBday As Boolean = iscmbxEmpty(dobDay)
        Dim bolDOBmonth As Boolean = iscmbxEmpty(dobMonth)
        Dim bolDOByear As Boolean = iscmbxEmpty(dobYear)
        Dim bolGender As Boolean = iscmbxEmpty(txtGender)
        '
        If bolLicensed Then
            msgbBoxShw()
        ElseIf bolSpecialization Then
            msgbBoxShw()
        ElseIf bolFname Then
            msgbBoxShw()
        ElseIf bolMname Then
            msgbBoxShw()
        ElseIf bolLname Then
            msgbBoxShw()
        ElseIf bolAge Then
            msgbBoxShw()
        ElseIf bolContactNo Then
            msgbBoxShw()
        ElseIf bolDOBAddress Then
            msgbBoxShw()
        ElseIf bolDOBday Then
            msgbBoxShw()
        ElseIf bolDOBmonth Then
            msgbBoxShw()
        ElseIf bolDOByear Then
            msgbBoxShw()
        ElseIf bolGender Then
            msgbBoxShw()
        Else
            If doctorID <> 0 Then
                Dim db As New KonekDB
                db.FETCHDBINFO()
                Using cmd As New SqlCommand("Update tblDoctor Set LicensedNo=@licensedno,FIRSTNAME=@fname,MIDDLENAME=@mname,LASTNAME=@lname,AGE=@age,SEX=@sex,B_DAY=@bday,B_MONTH=@bmonth,B_YEAR=@byear, ADDRESS=@address,CONTACTNO=@contactno,SPECIALIZATION=@specialization where DoctorID=@docid;", db.pubSqlCon)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@docid", doctorID)
                    cmd.Parameters.AddWithValue("@licensedno", txtLicensedno.Text)
                    cmd.Parameters.AddWithValue("@fname", txtFname.Text)
                    cmd.Parameters.AddWithValue("@mname", txtMiddleName.Text)
                    cmd.Parameters.AddWithValue("@lname", txtLname.Text)
                    cmd.Parameters.AddWithValue("@age", txtAge.Text)
                    cmd.Parameters.AddWithValue("@sex", txtGender.Text)
                    cmd.Parameters.AddWithValue("@bday", dobDay.Text)
                    cmd.Parameters.AddWithValue("@bmonth", dobMonth.Text)
                    cmd.Parameters.AddWithValue("@byear", dobYear.Text)
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                    '
                    cmd.Parameters.AddWithValue("@contactno", txtcontactNo.Text)
                    cmd.Parameters.AddWithValue("@specialization", txtSpecialization.Text)
                    cmd.ExecuteNonQuery()
                    db.pubSqlCon.Close()
                    cmd.Dispose()
                    MsgBox("Update successfully!")
                    MsgBox("This window will close." & vbCrLf & "Please login again to refresh the changes you made." & vbCrLf & vbCrLf & "Thank you.", MsgBoxStyle.Information)
                    Me.Close()
                    DoctorDashboard.Close()
                    reset_login_variables()
                    reset_doctor_variables()
                    LoginForm.Show()
                End Using
            End If
        End If
    End Sub
    '
    Public Sub UserActivity(ByVal intrfce As String, ByVal btn As String, ByVal actn As String)
        'Dim det As Date = CDate(Date.Now.ToShortDateString())
        'Dim tym As TimeSpan = Date.Now.TimeOfDay

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
        intrfce = "Doctor Information"
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
    Public Sub captureUAupdate()
        intrfce = "Doctor Information"
        btn = "Update"
        actn = "Update information of Doctor " & txtFname.Text & " " & txtMiddleName.Text & " " & txtLname.Text & "."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!
End Class