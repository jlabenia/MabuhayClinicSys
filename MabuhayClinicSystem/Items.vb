Imports System.Data.SqlClient
Public Class Items
    '!COMMENT:
    Dim result As Integer = Nothing
    Dim charlie As Integer = Nothing
    'END!
    '!COMMENT:  BUTTONS
    Private Sub btnDelet_Click(sender As Object, e As EventArgs) Handles btnDelet.Click
        If rbtnAll.Checked = True Then
            clearFields()
            Dim answer1 As DialogResult = MessageBox.Show("Warning! you are now going to delete all the items recorded in your database" & vbCrLf & "Any changes cannot be undone. Please confirm if you still want to continue.", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If answer1 = Windows.Forms.DialogResult.Yes Then
                Dim Inputbol As Boolean = False
                Dim InputValue As String = Nothing
                'Prompt the customer to type numbers
                InputValue = InputBox("To confirm that this is not a mistake, please type in numbers 1-9.", "Confirmation...")
                If IsNumeric(InputValue) Then
                    If InputValue = "123456789" Then
                        deleteAllItem()
                        clearFields()
                        loadItems()
                        rbtnSelectedItem.Checked = True
                        rbtnAll.Checked = False
                    Else
                        MsgBox("It seems like this is a mistake. Deletion aborted!")
                        rbtnSelectedItem.Checked = True
                        rbtnAll.Checked = False
                    End If
                Else
                    MsgBox("It seems like this is a mistake. Deletion aborted!")
                    rbtnSelectedItem.Checked = True
                    rbtnAll.Checked = False
                End If
            Else
                rbtnSelectedItem.Checked = True
                rbtnAll.Checked = False
            End If
        ElseIf rbtnSelectedItem.Checked = True Then
            If charlie <> 0 Then
                Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to delete this record.", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If answer = Windows.Forms.DialogResult.Yes Then
                    deleteOneItem()
                    clearFields()
                    loadItems()
                End If
            Else
                MsgBox("Please select an item.")
            End If
        End If
    End Sub
    '
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim bolitemname As Boolean = IsEmpty(txtItemName)
        Dim bolgenericName As Boolean = IsEmpty(txtGenericName)
        Dim boldosage As Boolean = IsEmpty(txtDosage)
        Dim bolDescription As Boolean = IsEmpty(txtDescription)
        '
        If bolitemname Then
            msgbBoxShw()
        ElseIf bolgenericName Then
            msgbBoxShw()
        ElseIf boldosage Then
            msgbBoxShw()
        ElseIf bolDescription Then
            msgbBoxShw()
        Else
            If cmbxTypeItem.SelectedIndex <= 0 Then
                msgbBoxShw()
            Else
                saveNewItem()
                clearFields()
            End If
        End If
    End Sub
    '
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If charlie <> 0 Then
                Dim bolitemname As Boolean = IsEmpty(txtItemName)
                Dim bolgenericName As Boolean = IsEmpty(txtGenericName)
                Dim boldosage As Boolean = IsEmpty(txtDosage)
                Dim bolDescription As Boolean = IsEmpty(txtDescription)
                '
                If bolitemname Then
                    msgbBoxShw()
                ElseIf bolgenericName Then
                    msgbBoxShw()
                ElseIf boldosage Then
                    msgbBoxShw()
                ElseIf bolDescription Then
                    msgbBoxShw()
                Else
                    If cmbxTypeItem.SelectedIndex <= 0 Then
                        msgbBoxShw()
                Else
                    Dim answer As DialogResult = MessageBox.Show("Please confirm if you woyld want to update this record.", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If answer = Windows.Forms.DialogResult.Yes Then
                        updateItem()
                    End If
                End If
            End If
        End If
    End Sub
    '
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearFields()
        loadItems()
    End Sub
    'END!
    '*********************************************************************************
    '!COMMENT: EVENTS
    'i. Form closing
    Private Sub Items_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadManagePharmacy()
    End Sub
    'ii. Form Laod
    Private Sub Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadItems()
    End Sub
    'iii.  DGV cell click
    Private Sub dgvItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellClick
        Try
            charlie = Nothing
            btnAdd.Enabled = False
            btnUpdate.Enabled = True
            Dim romeo As Integer = Nothing
            If dgvItems.RowCount > 0 Then
                romeo = dgvItems.CurrentRow.Index
                charlie = dgvItems.Item(0, romeo).Value
                populateFields()
            End If
        Catch
            clearFields()
        End Try
    End Sub
    'iv. text changed
    Private Sub txtSearchItem_TextChanged(sender As Object, e As EventArgs) Handles txtSearchItem.TextChanged
        If txtSearchItem.Text <> "" Then
            searchItem()
        Else
            loadItems()
        End If
    End Sub
    'v. Keypress
    Private Sub txtSearchItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchItem.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> " " And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    'END!
    '*********************************************************************************
    '!COMMENT: METHODS
    'i. Clear fields
    Public Sub clearFields()
        btnAdd.Enabled = True
        btnUpdate.Enabled = False
        charlie = Nothing
        cmbxTypeItem.SelectedIndex = 0
        txtItemCode.Text = ""
        txtItemName.Text = ""
        txtGenericName.Text = ""
        txtDescription.Text = ""
        txtDosage.Text = ""
    End Sub
    'ii. SAVE
    Public Sub saveNewItem()
        Dim year As Integer = CInt(Date.Now.Year)
        Dim month As Integer = CInt(Date.Now.Month)
        Dim currentItem As Integer = Nothing
        Dim itemcode As String = Nothing
        '
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using da As New SqlDataAdapter("Select MAX(ItemID) as item from tblItems", db.pubSqlCon)
            Dim count As Integer = Nothing
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                count = dt.Rows(0).Item("item")
                result = count + 1
                itemcode = result.ToString() & "-" & month.ToString() & "-" & year.ToString()
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
        Using cmd As New SqlCommand("Insert into tblItems (ItemCode, ItemName, GenericName, ItemDescription, Dosage, TypeofItem) values (@itemcode,@itemname,@genericname,@description,@dosage,@typeofitem); ", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd.Parameters.Add("@itemcode", SqlDbType.VarChar).Value = itemcode
            cmd.Parameters.Add("@itemname", SqlDbType.VarChar).Value = txtItemName.Text
            cmd.Parameters.Add("@genericname", SqlDbType.Text).Value = txtGenericName.Text
            cmd.Parameters.Add("@description", SqlDbType.Text).Value = txtDescription.Text
            cmd.Parameters.Add("@dosage", SqlDbType.Text).Value = txtDosage.Text
            cmd.Parameters.Add("@typeofitem", SqlDbType.VarChar).Value = cmbxTypeItem.Text
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("New record added!")
            MsgBox(result.ToString())
            loadNewItem()
        End Using
    End Sub
    'iii. Load DGV
    Public Sub loadItems()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using da As New SqlDataAdapter("Select top 100 ItemID,ItemCode, ItemName, GenericName, ItemDescription, Dosage, TypeofItem from tblItems order by ItemID ASC ;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvItems.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub loadNewItem()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select ItemID,ItemCode, ItemName, GenericName, ItemDescription, Dosage, TypeofItem from tblItems Where ItemID=@itemid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemid", result)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvItems.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            result = Nothing
        End Using
    End Sub
    '
    Public Sub populateFields()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select ItemCode, ItemName, GenericName, ItemDescription, Dosage, TypeofItem from tblItems Where ItemID=@itemid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtItemCode.Text = dt.Rows(0).Item("ItemCode")
                txtItemName.Text = dt.Rows(0).Item("ItemName")
                cmbxTypeItem.Text = dt.Rows(0).Item("TypeofItem")
                txtGenericName.Text = dt.Rows(0).Item("GenericName")
                txtDosage.Text = dt.Rows(0).Item("Dosage")
                txtDescription.Text = dt.Rows(0).Item("ItemDescription")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub updateItem()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Update tblItems Set ItemCode=@itemcode, ItemName=@itemname, GenericName=@genericname, ItemDescription=@description, Dosage=@dosage, TypeofItem =@typeitem Where ItemID=@itemid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemid", charlie)
            cmd.Parameters.AddWithValue("@itemcode", txtItemCode.Text)
            cmd.Parameters.AddWithValue("@itemname", txtItemName.Text)
            cmd.Parameters.AddWithValue("@genericname", txtGenericName.Text)
            cmd.Parameters.AddWithValue("@description", txtDescription.Text)
            cmd.Parameters.AddWithValue("@dosage", txtDosage.Text)
            cmd.Parameters.AddWithValue("@typeitem", cmbxTypeItem.Text)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Update successful!")
            loadUpdatedItem()
            clearFields()
        End Using
    End Sub
    '
    Public Sub loadUpdatedItem()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select ItemID,ItemCode, ItemName, GenericName, ItemDescription, Dosage, TypeofItem from tblItems Where ItemID=@itemid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvItems.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            charlie = Nothing
        End Using
    End Sub
    '
    Public Function IsEmpty(ByVal txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
    '
    Public Sub deleteOneItem()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Dim cmd As New SqlCommand("Delete from tblItems Where ItemID=@itemid;", db.pubSqlCon)
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@itemid", charlie)
        cmd.ExecuteNonQuery()
        db.pubSqlCon.Close()
        cmd.Dispose()
        MsgBox("Item deleted!")
    End Sub
    '
    Public Sub deleteAllItem()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Dim cmd As New SqlCommand("Delete from tblItems;", db.pubSqlCon)
        cmd.ExecuteNonQuery()
        db.pubSqlCon.Close()
        cmd.Dispose()
        MsgBox("Deleted all records!")
    End Sub
    '
    Public Sub searchItem()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select ItemID,ItemCode, ItemName, GenericName, ItemDescription, Dosage, TypeofItem from tblItems Where ItemName like '' +@itemname+ '%' order by ItemName DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemname", txtSearchItem.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvItems.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'END
End Class