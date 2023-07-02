Imports System.Data.SqlClient
Imports System.Text.RegularExpressions 'Class for text formatting
Public Class AdminUserAccount
    '!COMMENT: PRIVATE VARIABLES
    Dim charlie As Integer = Nothing
    Dim InputValue As String = Nothing
    'END!
    '**************************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If charlie <> 0 Then
            If txtAccountID.Text = "" Then
                msgbBoxShw()
            ElseIf txtPassword.Text = "" Then
                msgbBoxShw()
            ElseIf txtUsername.Text = "" Then
                msgbBoxShw()
            ElseIf cmbxUsertype.Text = "" Then
                msgbBoxShw()
            Else
                Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to update this record.", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If answer = Windows.Forms.DialogResult.Yes Then
                    updateLogin()
                    clearFields()
                    loadUpdatedInfo()
                Else
                    Exit Sub
                End If
            End If
        Else
            MsgBox("Please select an item.")
        End If
    End Sub
    '
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearFields()
        charlie = Nothing
        loadAll()
    End Sub
    'END!
    '**************************************************************************************
    '!COMMENT: EVENTS
    '
    Private Sub AdminUserAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadAll()
    End Sub
    '
    Private Sub AdminUserAccount_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.returntoAdminDashboard()
    End Sub
    '
    Private Sub RadioButtons_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnUser.CheckedChanged, rbtnDoctor.CheckedChanged, rbtnAdmin.CheckedChanged
        If rbtnAll.Checked = True Then
            loadAll()
        ElseIf rbtnAdmin.Checked = True Then
            loadAdmin()
        ElseIf rbtnDoctor.Checked = True Then
            loadDoctor()
        ElseIf rbtnUser.Checked = True Then
            loadUsers()
        End If
    End Sub
    '
    Private Sub txtSearchUser_TextChanged(sender As Object, e As EventArgs) Handles txtSearchUser.TextChanged
        rbtnAll.Checked = True
        If txtSearchUser.Text <> "" Then
            searchUser()
        Else
            loadAll()
        End If
    End Sub
    '
    Private Sub dgvUserAccounts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUserAccounts.CellClick
        Try
            Dim romeo As Integer = Nothing
            charlie = Nothing
            If dgvUserAccounts.RowCount > 0 Then
                romeo = dgvUserAccounts.CurrentRow.Index
                charlie = dgvUserAccounts.Item(0, romeo).Value
                populateFields()
            End If
        Catch
            charlie = Nothing
            clearFields()
        End Try
    End Sub
    'END!
    '**************************************************************************************
    '!COMMENT: METHODS
    Public Sub loadAll()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select ta.UserID as AccountID,CONCAT(tc.FIRSTNAME,' ', tc.MIDDLENAME,' ',tc.LASTNAME) as FULLNAME,tc.GENDER,ta.USERTYPE,ta.USERNAME,ta.PASSWORD from tblUserAccounts as ta " & _
                                    " Inner join tblClinicPersonnel as tc On ta.UserID = tc.UserID " & _
                                    " Union " & _
                                    " Select ta.UserID as AccountID,CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME,' ',tdoc.LASTNAME) as FULLNAME,tdoc.SEX as GENDER,ta.USERTYPE,ta.USERNAME,ta.PASSWORD from tblUserAccounts as ta " & _
                                    " Inner join tblDoctor as tdoc On ta.UserID = tdoc.DoctorID;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvUserAccounts.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub loadAdmin()
       Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ta.UserID as AccountID,CONCAT(tc.FIRSTNAME,' ', tc.MIDDLENAME,' ',tc.LASTNAME) as FULLNAME,tc.GENDER,ta.USERTYPE,ta.USERNAME,ta.PASSWORD from tblUserAccounts as ta " & _
                                    " Inner join tblClinicPersonnel as tc On ta.UserID = tc.UserID " & _
                                    " Where ta.USERTYPE=@usertype Order by ta.UserID ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@usertype", "ADMIN")
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvUserAccounts.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub loadUsers()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ta.UserID as AccountID,CONCAT(tc.FIRSTNAME,' ', tc.MIDDLENAME,' ',tc.LASTNAME) as FULLNAME,tc.GENDER,ta.USERTYPE,ta.USERNAME,ta.PASSWORD from tblUserAccounts as ta " & _
                                    " Inner join tblClinicPersonnel as tc On ta.UserID = tc.UserID " & _
                                    " Where ta.USERTYPE=@usertype Order by ta.UserID ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@usertype", "USER")
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvUserAccounts.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub loadDoctor()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ta.UserID as AccountID,CONCAT(tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME,' ',tdoc.LASTNAME) as FULLNAME,tdoc.SEX as GENDER,ta.USERTYPE,ta.USERNAME,ta.PASSWORD from tblUserAccounts as ta " & _
                                        " Inner join tblDoctor as tdoc On ta.UserID = tdoc.DoctorID " & _
                                        " Where ta.USERTYPE=@usertype Order by ta.UserID ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@usertype", "DOCTOR")
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvUserAccounts.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub searchUser()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ta.UserID as AccountID,CONCAT(tc.LASTNAME, ', ',tc.FIRSTNAME,' ', tc.MIDDLENAME) as FULLNAME,ta.USERTYPE,ta.USERNAME,ta.PASSWORD from tblUserAccounts as ta " & _
                                    " Inner join tblClinicPersonnel as tc On ta.UserID = tc.UserID " & _
                                    " Where CONCAT(tc.LASTNAME, ', ',tc.FIRSTNAME,' ', tc.MIDDLENAME) like '' +@lname+ '%' " & _
                                    " Union " & _
                                    " Select ta.UserID as AccountID,CONCAT(tdoc.LASTNAME, ', ',tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME) as FULLNAME,ta.USERTYPE,ta.USERNAME,ta.PASSWORD from tblUserAccounts as ta  " & _
                                    " Inner join tblDoctor as tdoc On ta.UserID = tdoc.DoctorID " & _
                                    " Where CONCAT(tdoc.LASTNAME, ', ',tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME) like '' +@lname+ '%' ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtSearchUser.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvUserAccounts.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub clearFields()
        txtAccountID.Text = ""
        txtFname.Text = ""
        txtGender.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        cmbxUsertype.SelectedIndex = -1
        cboxBlockUser.CheckState = CheckState.Unchecked
    End Sub
    '
    Public Sub populateFields()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ta.UserID as AccountID,CONCAT(tc.LASTNAME, ', ',tc.FIRSTNAME,' ', tc.MIDDLENAME) as FULLNAME, tc.GENDER,ta.USERTYPE,ta.USERNAME,ta.PASSWORD from tblUserAccounts as ta " & _
                                    " Inner join tblClinicPersonnel as tc On ta.UserID = tc.UserID " & _
                                    " Where ta.UserID=@userid " & _
                                    " Union " & _
                                    " Select ta.UserID as AccountID,CONCAT(tdoc.LASTNAME, ', ',tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME) as FULLNAME, tdoc.SEX as GENDER,ta.USERTYPE,ta.USERNAME,ta.PASSWORD from tblUserAccounts as ta  " & _
                                    " Inner join tblDoctor as tdoc On ta.UserID = tdoc.DoctorID " & _
                                    " Where ta.UserID=@userid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@userid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtAccountID.Text = dt.Rows(0).Item("AccountID")
                txtFname.Text = dt.Rows(0).Item("FULLNAME")
                txtGender.Text = dt.Rows(0).Item("GENDER")
                txtUsername.Text = dt.Rows(0).Item("USERNAME")
                txtPassword.Text = dt.Rows(0).Item("PASSWORD")
                cmbxUsertype.Text = dt.Rows(0).Item("USERTYPE")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub updateLogin()
         Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Update tblUserAccounts Set USERTYPE=@utype,USERNAME=@uname,PASSWORD=@pass Where UserID=@userid", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@utype", cmbxUsertype.Text)
            cmd.Parameters.AddWithValue("@uname", txtUsername.Text)
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text)
            cmd.Parameters.AddWithValue("@userid", charlie)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Update successfully!")
        End Using
    End Sub
    '
    Public Sub loadUpdatedInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ta.UserID as AccountID,CONCAT(tc.LASTNAME, ', ',tc.FIRSTNAME,' ', tc.MIDDLENAME) as FULLNAME, tc.GENDER,ta.USERTYPE,ta.USERNAME,ta.PASSWORD from tblUserAccounts as ta " & _
                                    " Inner join tblClinicPersonnel as tc On ta.UserID = tc.UserID " & _
                                    " Where ta.UserID=@userid " & _
                                    " Union " & _
                                    " Select ta.UserID as AccountID,CONCAT(tdoc.LASTNAME, ', ',tdoc.FIRSTNAME,' ', tdoc.MIDDLENAME) as FULLNAME, tdoc.SEX as GENDER,ta.USERTYPE,ta.USERNAME,ta.PASSWORD from tblUserAccounts as ta  " & _
                                    " Inner join tblDoctor as tdoc On ta.UserID = tdoc.DoctorID " & _
                                    " Where ta.UserID=@userid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@userid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvUserAccounts.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            charlie = Nothing
        End Using
    End Sub
    '
    Public Sub blockedAccount()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Update tblUserAccounts Set USERTYPE=@utype,USERNAME=@uname,PASSWORD=@pass Where UserID=@userid", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@utype", "Blocked_" & cmbxUsertype.Text)
            cmd.Parameters.AddWithValue("@uname", InputValue & "_" & txtUsername.Text)
            cmd.Parameters.AddWithValue("@pass", InputValue & "_" & txtPassword.Text)
            cmd.Parameters.AddWithValue("@userid", charlie)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Account blocked!")
        End Using
    End Sub
    'END!
    '**************************************************************************************

    Private Sub cboxBlockUser_CheckedChanged(sender As Object, e As EventArgs) Handles cboxBlockUser.CheckedChanged
        If cboxBlockUser.CheckState = CheckState.Checked Then
            If charlie <> 0 Then
                'Ask if admin want to block account
                Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to block this login account temporarily." & vbCrLf & vbCrLf & "Click YES to proceed otherwise click NO." & vbCrLf & vbCrLf & "Note: once blocked this person will not be able to access the system.", "Your confirmation...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                'If yes. Proceed. Else, cancel.
                If answer = Windows.Forms.DialogResult.Yes Then
                    InputValue = InputBox("Please type in 5 letters without space.", "Blocking account...")
                    'check if input is not empty
                    If InputValue <> "" Then
                        'check if input is text only
                        If Regex.IsMatch(InputValue, "^[a-zA-Z]+$") = True Then
                            'check length of input. Use "Len" length function to determine the length of characters input
                            If Len(InputValue) = 5 Then
                                blockedAccount()
                                loadUpdatedInfo()
                            Else
                                MsgBox("Failed! Your input exceeds or less the required charcters. Exiting...", MsgBoxStyle.Exclamation)
                                cboxBlockUser.CheckState = CheckState.Unchecked
                            End If
                        Else
                            MsgBox("Failed! Your input must be letters ONLY. Exiting...", MsgBoxStyle.Exclamation)
                            cboxBlockUser.CheckState = CheckState.Unchecked
                        End If
                    Else
                        MsgBox("Failed! Your input is empty. Exiting...", MsgBoxStyle.Exclamation)
                        cboxBlockUser.CheckState = CheckState.Unchecked
                    End If
                End If ' ending of answer if-else
            Else
                MsgBox("Please select an item.")
                cboxBlockUser.CheckState = CheckState.Unchecked
            End If ' ending of charlie if -else
            'Reset value to Nothing
            InputValue = Nothing
        End If
    End Sub
End Class

           