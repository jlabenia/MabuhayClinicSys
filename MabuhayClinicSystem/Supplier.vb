Imports System.Data.SqlClient
Public Class Supplier
    '!COMMENT: PRIVATE VARIABLES
    Dim suppierID As Integer = Nothing
    Dim charlieSierraIndia As Integer = Nothing
    'END!
    '******************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim bolcountrycode As Boolean = IsEmpty(txtCountryCode)
        Dim bolPhoneNumber As Boolean = IsEmpty(txtPhoneNumber)
        Dim bolCompanyName As Boolean = IsEmpty(txtCompanyName)
        Dim bolCompanyAddress As Boolean = IsEmpty(txtCompanyAddress)
        Dim bolSupFullname As Boolean = IsEmpty(txtSupFullname)
        Dim bolAge As Boolean = IsEmpty(txtAge)
        '
        If bolcountrycode Then
            msgbBoxShw()
        ElseIf bolPhoneNumber Then
            msgbBoxShw()
        ElseIf bolCompanyName Then
            msgbBoxShw()
        ElseIf bolCompanyAddress Then
            msgbBoxShw()
        ElseIf bolSupFullname Then
            msgbBoxShw()
        ElseIf bolAge Then
            msgbBoxShw()
        Else
            If cmbxGender.SelectedIndex <= 0 Then
                msgbBoxShw()
            Else
                saveNewSupplier()
                loadNewRecord()
            End If
        End If
    End Sub
    '
    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        clearFields()
        charlieSierraIndia = Nothing
        loadSupplierInfo()
    End Sub
    '
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If charlieSierraIndia <> 0 Then
            Dim bolcountrycode As Boolean = IsEmpty(txtCountryCode)
            Dim bolPhoneNumber As Boolean = IsEmpty(txtPhoneNumber)
            Dim bolCompanyName As Boolean = IsEmpty(txtCompanyName)
            Dim bolCompanyAddress As Boolean = IsEmpty(txtCompanyAddress)
            Dim bolSupFullname As Boolean = IsEmpty(txtSupFullname)
            Dim bolAge As Boolean = IsEmpty(txtAge)
            '
            If bolcountrycode Then
                msgbBoxShw()
            ElseIf bolPhoneNumber Then
                msgbBoxShw()
            ElseIf bolCompanyName Then
                msgbBoxShw()
            ElseIf bolCompanyAddress Then
                msgbBoxShw()
            ElseIf bolSupFullname Then
                msgbBoxShw()
            ElseIf bolAge Then
                msgbBoxShw()
            Else
                If cmbxGender.SelectedIndex <= 0 Then
                    msgbBoxShw()
                Else
                    Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to update this record.", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If answer = Windows.Forms.DialogResult.Yes Then
                        updateSupplier()
                        loadUpdatedRecod()
                    Else
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub
    'END!
    '******************************************************************************
    '!COMMENT: EVENTS
    'i. load form
    Private Sub Supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadSupplierInfo()
    End Sub
    '
    Private Sub dgvSupplier_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSupplier.CellClick
        Try
            Dim romeo As Integer = Nothing
            btnSave.Enabled = False
            btnUpdate.Enabled = True
            charlieSierraIndia = Nothing
            If dgvSupplier.RowCount > 0 Then
                romeo = dgvSupplier.CurrentRow.Index
                charlieSierraIndia = dgvSupplier.Item(0, romeo).Value
                populatefields()
            End If
        Catch
            charlieSierraIndia = Nothing
            clearFields()
        End Try
    End Sub
    '
    Private Sub txtSearchSupplier_TextChanged(sender As Object, e As EventArgs) Handles txtSearchSupplier.TextChanged
        If txtSearchSupplier.Text <> "" Then
            searchSupplier()
        Else
            loadSupplierInfo()
        End If
    End Sub
    '
    Private Sub txtPhoneNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhoneNumber.KeyPress, txtAge.KeyPress
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSearchSupplier_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSupFullname.KeyPress, txtSearchSupplier.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> vbBack And e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub Supplier_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadManagePharmacy()
    End Sub
    'END!
    '******************************************************************************
    '!COMMENT: METHODS
    'i. Clear Fields
    Public Sub clearFields()
        txtSupplierCode.Text = ""
        txtCountryCode.Text = ""
        txtPhoneNumber.Text = ""
        txtCompanyName.Text = ""
        txtCompanyAddress.Text = ""
        txtSupFullname.Text = ""
        txtAge.Text = ""
        cmbxGender.SelectedIndex = -1
        txtSearchSupplier.Text = ""
    End Sub
    'ii. Load supplier
    Public Sub loadSupplierInfo()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using da As New SqlDataAdapter("Select top 100 SupplierID,SupplierCode,CountryCode,PhoneNumber,SupplierFullname,Gender,Age,CompanyName,CompanyAddress from tblSupplier;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvSupplier.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    'ii. Save new record
    Public Sub saveNewSupplier()
        Dim supplierCode As String = Nothing
        Dim yearnow As Integer = Date.Now.Year
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        'Get the SupplierCode
        Using da As New SqlDataAdapter("Select Max(SupplierID) as id from tblSupplier;", db.pubSqlCon)
            Dim dt As New DataTable
            Dim result As Integer = Nothing
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                result = dt.Rows(0).Item("id")
                supplierCode = result + 1
                suppierID = result + 1
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
        'Insert new record
        Using cmd As New SqlCommand("Insert into tblSupplier (SupplierCode,CountryCode,PhoneNumber,SupplierFullname,Gender,Age,CompanyName,CompanyAddress) values (@suppliercode, @countrycode,@phonenumber,@supplierFullname,@gender,@age,@companyName,@CompanyAddress);", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd.Parameters.Add("@suppliercode", SqlDbType.Text).Value = supplierCode & "-Sup" & yearnow.ToString()
            cmd.Parameters.Add("@countrycode", SqlDbType.VarChar).Value = txtCountryCode.Text
            cmd.Parameters.Add("@phonenumber", SqlDbType.VarChar).Value = txtPhoneNumber.Text
            cmd.Parameters.Add("@supplierFullname", SqlDbType.Text).Value = txtSupplierCode.Text
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = cmbxGender.Text
            cmd.Parameters.Add("@age", SqlDbType.SmallInt).Value = txtAge.Text
            cmd.Parameters.Add("@companyName", SqlDbType.Text).Value = txtCompanyName.Text
            cmd.Parameters.Add("@CompanyAddress", SqlDbType.Text).Value = txtCompanyAddress.Text
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("New record added!")
            clearFields()
        End Using
    End Sub
    '
    Public Sub loadNewRecord()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select SupplierID,SupplierCode,CountryCode,PhoneNumber,SupplierFullname,Gender,Age,CompanyName,CompanyAddress from tblSupplier where SupplierID=@suppliearid ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@suppliearid", suppierID)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvSupplier.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            suppierID = Nothing
        End Using
    End Sub
    '
    Public Sub populatefields()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select SupplierCode,CountryCode,PhoneNumber,SupplierFullname,Gender,Age,CompanyName,CompanyAddress from tblSupplier where SupplierID=@suppliearid ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@suppliearid", charlieSierraIndia)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtSupplierCode.Text = dt.Rows(0).Item("SupplierCode")
                txtCountryCode.Text = dt.Rows(0).Item("CountryCode")
                txtPhoneNumber.Text = dt.Rows(0).Item("PhoneNumber")
                txtCompanyName.Text = dt.Rows(0).Item("CompanyName")
                txtCompanyAddress.Text = dt.Rows(0).Item("CompanyAddress")
                txtSupFullname.Text = dt.Rows(0).Item("SupplierFullname")
                txtAge.Text = dt.Rows(0).Item("Age")
                cmbxGender.Text = dt.Rows(0).Item("Gender")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using

    End Sub
    '
    Public Sub updateSupplier()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Update tblSupplier Set SupplierCode=@suppliercode,CountryCode=@countrycode,PhoneNumber=@phonenumber,SupplierFullname=@fullname,Gender=@gender,Age=@age,CompanyName=@companyname,CompanyAddress=@companyaddress where SupplierID=@suppliearid ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@suppliearid", charlieSierraIndia)
            cmd.Parameters.AddWithValue("@suppliercode", txtSupplierCode.Text)
            cmd.Parameters.AddWithValue("@countrycode", txtCountryCode.Text)
            cmd.Parameters.AddWithValue("@phonenumber", txtPhoneNumber.Text)
            cmd.Parameters.AddWithValue("@fullname", txtSupFullname.Text)
            cmd.Parameters.AddWithValue("@gender", cmbxGender.Text)
            cmd.Parameters.AddWithValue("@age", txtAge.Text)
            cmd.Parameters.AddWithValue("@companyname", txtCompanyName.Text)
            cmd.Parameters.AddWithValue("@companyaddress", txtCompanyAddress.Text)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            clearFields()
            MsgBox("Update success!")
        End Using
    End Sub
    '
    Public Sub loadUpdatedRecod()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select SupplierID,SupplierCode,CountryCode,PhoneNumber,SupplierFullname,Gender,Age,CompanyName,CompanyAddress from tblSupplier where SupplierID=@suppliearid ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@suppliearid", charlieSierraIndia)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvSupplier.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            charlieSierraIndia = Nothing
        End Using
    End Sub
    '
    Public Sub searchSupplier()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select SupplierID,SupplierCode,CountryCode,PhoneNumber,SupplierFullname,Gender,Age,CompanyName,CompanyAddress from tblSupplier where SupplierFullname like '' +@fullname+ '%' order by SupplierFullname ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@fullname", txtSearchSupplier.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvSupplier.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Function IsEmpty(ByVal txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
    'END!
    '******************************************************************************
End Class