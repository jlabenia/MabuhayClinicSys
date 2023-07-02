Imports System.Data.SqlClient
Public Class ChangePasswordfrmvb
    '!COMMENT: PRIVATE VARIABLES
    Dim password As Integer = Nothing
    Dim username As String = Nothing
    Dim usertype As String = Nothing
    'END!
    '!COMMENT: EVENTS
    'i. Exit button
    Private Sub cpfrmbtnExit_Click(sender As Object, e As EventArgs) Handles cpfrmbtnExit.Click
        cpfrmClearMthd()
        Me.Close() '[call form closing event]
    End Sub '//green code
    'ii. Form closing
    Private Sub ChangePasswordfrmvb_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        cpfrmClearMthd()
        Dim newfrm As Form = New LoginForm
        newfrm.Show()
        My.Settings.rememberMe = False
    End Sub '//green code
    'iii. Load form
    Private Sub ChangePasswordfrmvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        password = loginUserid
        username = loginUsername
        usertype = loginUserType
        loginUserid = Nothing
        loginUsername = Nothing
        loginUserType = Nothing
        If usertype = "USER" Then
            cpfrmtxtFname.Text = cp_fname + " " + cp_mname + " " + cp_lname
            cpfrmtxtUser.Text = "User"
            cpfrmtxtUsername.Text = username
            AcceptButton = cpfrmbtnSave
        ElseIf usertype = "DOCTOR" Then
            cpfrmtxtFname.Text = doctorFname + " " + doctorMname + " " + doctorLname
            cpfrmtxtUser.Text = "Doctor"
            cpfrmtxtUsername.Text = username
            AcceptButton = cpfrmbtnSave
        ElseIf usertype = "ADMIN" Then
            'cpfrmtxtFname.Text = miscFname
            'cpfrmtxtUser.Text = miscUser
            'cpfrmtxtUsername.Text = miscUsername
            'AcceptButton = cpfrmbtnSave
        End If
    End Sub '//green code
    'iv. Save button
    Private Sub cpfrmbtnSave_Click(sender As Object, e As EventArgs) Handles cpfrmbtnSave.Click
        If cpfrmtxtNewPassword.Text = "" Or cpfrmtxtCnfrmPassword.Text = "" Then
            MessageBox.Show("Please don't leave field empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If cpfrmtxtCnfrmPassword.Text = cpfrmtxtNewPassword.Text Then
                cpfrmSaveMthd()
                cpfrmClearMthd()
                Me.Close()  '[call form closing event]
            Else
                MsgBox("Password does not match!")
            End If
        End If
    End Sub '//green code
    'END EVENTS!
    '*********************************************************************************************
    '!COMMENT: METHODS
    'i. Clear 
    Public Sub cpfrmClearMthd()
        cpfrmtxtFname.Text = ""
        cpfrmtxtUser.Text = ""
        cpfrmtxtUsername.Text = ""
        reset_cp_variables()
        reset_doctor_variables()
        reset_login_variables()
        password = Nothing
        username = Nothing
        usertype = Nothing
    End Sub '//green code
    'ii.Save
    Public Sub cpfrmSaveMthd()
        Dim db As New KonekDB
        Dim cmd As New SqlCommand("Update tblUserAccounts Set PASSWORD=@password Where UserID = @userid")
        db.FETCHDBINFO()
        cmd.Connection = db.pubSqlCon
        cmd.Parameters.AddWithValue("@userid", password)
        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = cpfrmtxtCnfrmPassword.Text.ToString()
        cmd.ExecuteNonQuery()
        MsgBox("Update success!")
        db.pubSqlCon.Close()
        cmd.Dispose()
    End Sub '//green code
    'END METHODS!
End Class