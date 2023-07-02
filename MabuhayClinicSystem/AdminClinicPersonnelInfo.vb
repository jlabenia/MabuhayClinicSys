Imports System.Data.SqlClient
Public Class AdminClinicPersonnelInfo
    '!COMMENT: PRIVATE VARIABLES
    Dim charlie As Integer = Nothing
    Dim userid As Integer = Nothing ' reference for deletion
    'END!
    '**********************************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        btnAdd.Enabled = True
        btnUpdate.Enabled = False
        charlie = Nothing
        userid = Nothing
        clearFields()
        loadClinicPersonnelInfo()
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
        '
        Dim bolgender As Boolean = IscmbxEmpty(cmbxGender)
        Dim bolusertype As Boolean = IscmbxEmpty(cmbxUserType)
        Dim bolDOBday As Boolean = IscmbxEmpty(cmbxDOBday)
        Dim bolDOBmonth As Boolean = IscmbxEmpty(cmbxDOBmonth)
        Dim bolDOByear As Boolean = IscmbxEmpty(cmbxDOByear)
        '
        If bolfname Then
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim bolfname As Boolean = IstxtEmpty(txtFname)
        Dim bolmname As Boolean = IstxtEmpty(txtMname)
        Dim bollname As Boolean = IstxtEmpty(txtLname)
        Dim bolAge As Boolean = IstxtEmpty(txtAge)
        Dim bolAddress As Boolean = IstxtEmpty(txtAddress)
        Dim bolContact As Boolean = IstxtEmpty(txtContactNo)
        '
        Dim bolgender As Boolean = IscmbxEmpty(cmbxGender)
        Dim bolDOBday As Boolean = IscmbxEmpty(cmbxDOBday)
        Dim bolDOBmonth As Boolean = IscmbxEmpty(cmbxDOBmonth)
        Dim bolDOByear As Boolean = IscmbxEmpty(cmbxDOByear)
        '
        If bolfname Then
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
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If charlie <> 0 Then
            deleteRecord()
        Else
            MsgBox("Please select a record.")
        End If
    End Sub
    'END!
    '**********************************************************************************************
    '!COMMENT: EVENTS
    Private Sub AdminClinicPersonnelInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDOByear()
        loadClinicPersonnelInfo()
    End Sub
    '
    Private Sub dgvClinicPersonnel_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClinicPersonnel.CellClick
        Try
            Dim romeo As Integer = Nothing
            btnAdd.Enabled = False
            btnUpdate.Enabled = True
            If dgvClinicPersonnel.RowCount > 0 Then
                romeo = dgvClinicPersonnel.CurrentRow.Index
                charlie = dgvClinicPersonnel.Item(0, romeo).Value
                populateRecordsToFields()
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
        If cmbxDOByear.Text <> "" Then
            brthYear = CInt(cmbxDOByear.Text)
            age = yrToday - brthYear
            txtAge.Text = age.ToString()
        Else
            txtAge.Text = ""
        End If
    End Sub
    '
    Private Sub AdminClinicPersonnelInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadManageClinic()
    End Sub
    '
    Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactNo.KeyPress
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub txtFname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress, txtMname.KeyPress, txtLname.KeyPress, txtFname.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> " " And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text <> "" Then
            searchClinicPersonnel()
        Else
            loadClinicPersonnelInfo()
        End If
    End Sub
    '
    'END!
    '**********************************************************************************************
    '!COMMENT: METHODS
    '
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
    Public Sub saveNewRecord()
        Dim db As New KonekDB
        Dim userID As Integer = Nothing
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
                    userID = dt.Rows(0).Item("userid")
                End If
                dt.Dispose()
                da.Dispose()
            End Using
            db.pubSqlCon.Close()
            cmd.Dispose()
        End Using
        'Add new clinic personnel
        Using cmd1 As New SqlCommand("Insert into tblClinicPersonnel (UserID,FIRSTNAME,MIDDLENAME,LASTNAME,DOB_DAY,DOB_MONTH,DOB_YEAR,AGE,GENDER,ADDRESS,CONTACTNO) values (@userid,@fname,@mname,@lname,@day,@month,@year,@age,@gender,@address,@contactno)", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd1.Parameters.Clear()
            cmd1.Parameters.Add("@userid", SqlDbType.Int).Value = userID
            cmd1.Parameters.Add("@fname", SqlDbType.VarChar).Value = txtFname.Text
            cmd1.Parameters.Add("@mname", SqlDbType.VarChar).Value = txtMname.Text
            cmd1.Parameters.Add("@lname", SqlDbType.VarChar).Value = txtLname.Text
            cmd1.Parameters.Add("@day", SqlDbType.Int).Value = cmbxDOBday.Text
            cmd1.Parameters.Add("@month", SqlDbType.VarChar).Value = cmbxDOBmonth.Text
            cmd1.Parameters.Add("@year", SqlDbType.Int).Value = cmbxDOByear.Text
            cmd1.Parameters.Add("@age", SqlDbType.Int).Value = txtAge.Text
            cmd1.Parameters.Add("@gender", SqlDbType.VarChar).Value = cmbxGender.Text
            cmd1.Parameters.Add("@address", SqlDbType.Text).Value = txtAddress.Text
            cmd1.Parameters.Add("@contactno", SqlDbType.VarChar).Value = txtContactNo.Text
            cmd1.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd1.Dispose()
            MsgBox("New record added!")
            userID = Nothing
        End Using
    End Sub
    '
    Public Sub loadNewRecord()
        Dim clinicPersonID As Integer = Nothing
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Get current clinic personnel id
        Using da As New SqlDataAdapter("Select MAX(ClinicPersonnelID) as id from tblClinicPersonnel;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                clinicPersonID = dt.Rows(0).Item("id")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
        'Load clinic personnel info using clinic personnel id
        Using cmd As New SqlCommand("Select ClinicPersonnelID,CONCAT(FIRSTNAME,' ',MIDDLENAME,' ',LASTNAME) as FULLNAME,DOB_DAY,DOB_MONTH,DOB_YEAR,AGE,GENDER,ADDRESS,CONTACTNO from tblClinicPersonnel " & _
                                    " Where ClinicPersonnelID=@personelid;", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personelid", clinicPersonID)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvClinicPersonnel.DataSource = dt
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
        Using cmd As New SqlCommand("  Select tcp.FIRSTNAME,tcp.MIDDLENAME,tcp.LASTNAME,tcp.DOB_DAY,tcp.DOB_MONTH,tcp.DOB_YEAR,tcp.AGE,tcp.GENDER,tcp.ADDRESS,tcp.CONTACTNO,tuc.USERTYPE,tuc.USERNAME,tuc.PASSWORD from tblClinicPersonnel as tcp " & _
  " Inner Join tblUserAccounts as tuc On tcp.UserID = tuc.UserID " & _
  " Where tcp.ClinicPersonnelID=@clinicpersonid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@clinicpersonid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                readOnlyFields()
                '
                txtFname.Text = dt.Rows(0).Item("FIRSTNAME")
                txtMname.Text = dt.Rows(0).Item("MIDDLENAME")
                txtLname.Text = dt.Rows(0).Item("LASTNAME")
                txtAge.Text = dt.Rows(0).Item("AGE")
                txtAddress.Text = dt.Rows(0).Item("ADDRESS")
                txtContactNo.Text = dt.Rows(0).Item("CONTACTNO")
                txtPassword.Text = dt.Rows(0).Item("PASSWORD")
                txtUsername.Text = dt.Rows(0).Item("USERNAME")
                '
                cmbxGender.Text = dt.Rows(0).Item("GENDER")
                cmbxUserType.Text = dt.Rows(0).Item("USERTYPE")
                cmbxDOBday.Text = dt.Rows(0).Item("DOB_DAY")
                cmbxDOBmonth.Text = dt.Rows(0).Item("DOB_MONTH")
                cmbxDOByear.Text = dt.Rows(0).Item("DOB_YEAR")
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
        Using cmd As New SqlCommand("Update tblClinicPersonnel Set FIRSTNAME=@fname,MIDDLENAME=@mname,LASTNAME=@lname,DOB_DAY=@day,DOB_MONTH=@month,DOB_YEAR=@year,AGE=@age,GENDER=@gender,ADDRESS=@address,CONTACTNO=@contactno " & _
                                    " where ClinicPersonnelID=@personnelid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@fname", txtFname.Text)
            cmd.Parameters.AddWithValue("@mname", txtMname.Text)
            cmd.Parameters.AddWithValue("@lname", txtLname.Text)
            cmd.Parameters.AddWithValue("@day", cmbxDOBday.Text)
            cmd.Parameters.AddWithValue("@month", cmbxDOBmonth.Text)
            cmd.Parameters.AddWithValue("@year", cmbxDOByear.Text)
            cmd.Parameters.AddWithValue("@age", txtAge.Text)
            cmd.Parameters.AddWithValue("@gender", cmbxGender.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.Parameters.AddWithValue("@contactno", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@personnelid", charlie)
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
        Using cmd As New SqlCommand("Select ClinicPersonnelID,CONCAT(FIRSTNAME,' ',MIDDLENAME,' ',LASTNAME) as FULLNAME,DOB_DAY,DOB_MONTH,DOB_YEAR,AGE,GENDER,ADDRESS,CONTACTNO from tblClinicPersonnel " & _
                                   " Where ClinicPersonnelID=@personelid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personelid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvClinicPersonnel.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            charlie = Nothing
        End Using
    End Sub
    '
    Public Sub loadClinicPersonnelInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select ClinicPersonnelID,CONCAT(FIRSTNAME,' ',MIDDLENAME,' ',LASTNAME) as FULLNAME,DOB_DAY,DOB_MONTH,DOB_YEAR,AGE,GENDER,ADDRESS,CONTACTNO from tblClinicPersonnel order by ClinicPersonnelID ASC;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvClinicPersonnel.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
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
    Public Sub deleteRecord()
        Dim hasLogHistoryRecords As Boolean = False
        Dim hasUserActivty As Boolean = False
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Get user id
        Using cmd As New SqlCommand("Select tua.UserID from tblUserAccounts AS tua " & _
                                   " Inner Join tblClinicPersonnel as tcp On tua.UserID = tcp.UserID  " & _
 " Where tcp.ClinicPersonnelID =@personnelid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personnelid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                userid = dt.Rows(0).Item("UserID")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
        'Check if user has records of log history (boolean "has log history")
        Using cmd1 As New SqlCommand(" Select * from tblLogHistory where UserID = @userid;", db.pubSqlCon)
            cmd1.Parameters.Clear()
            cmd1.Parameters.AddWithValue("@userid", userid)
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
        'Check if user has user Activity
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
        'If user has no record for USER ACTIVITY & LOG HISTORY, proceed to delete else ask the user 
        If hasLogHistoryRecords = True Or hasUserActivty = True Then
            'Warning user has records!!
            Dim answer As DialogResult = MessageBox.Show("Warning! The Log history and User Activity records of this clinic personnel will be deleted." & vbCrLf & "Any changes cannot be undone." & vbCrLf & "Should you wish to proceed please click YES otherwise click NO.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
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
            'User is new!
            Dim answer1 As DialogResult = MessageBox.Show("Please confirm if you would want to delete this record.", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
    End Sub
    '
    Public Sub commandDelete()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("  Begin transaction; " & _
        " Delete tblLogHistory where UserID = @userid; " & _
        " Delete tblUserActivity Where UserID = @userid; " & _
        " Delete tblClinicPersonnel Where UserID=@userid And ClinicPersonnelID=@personnelid; " & _
        " Delete tblUserAccounts Where UserID = @userid; " & _
        " Commit;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@userid", userid)
            cmd.Parameters.AddWithValue("@personnelid", charlie)

            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            clearFields()
            loadClinicPersonnelInfo()
            charlie = Nothing
            userid = Nothing
            MsgBox("Record has been deleted!")
        End Using
    End Sub
    '
    Public Sub searchClinicPersonnel()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ClinicPersonnelID,CONCAT(LASTNAME, ', ',FIRSTNAME,' ',MIDDLENAME) as FULLNAME,DOB_DAY,DOB_MONTH,DOB_YEAR,AGE,GENDER,ADDRESS,CONTACTNO from tblClinicPersonnel " & _
                                   " Where CONCAT(LASTNAME, ' ',FIRSTNAME,' ',MIDDLENAME) like '' +@lname+ '%' order by FULLNAME;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtSearch.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvClinicPersonnel.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'END!
    '**********************************************************************************************
End Class