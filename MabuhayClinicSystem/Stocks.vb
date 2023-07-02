Imports System.Data.SqlClient
Public Class Stocks
    '!COMMENT: PRIVATE VARIABLES
    Dim supplierID As Integer = Nothing
    Dim itemid As Integer = Nothing
    Dim stockid As Integer = Nothing
    Dim charlieSierra As Integer = Nothing
    'END!
    '***********************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        clearFields()
        loadStocks()
    End Sub
    '
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        saveNewStocks()
        loadNewStock()
    End Sub
    '
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If charlieSierra <> 0 Then
            Dim bolqty As Boolean = isFieldEmpty(txtQuantity)
            Dim bolpcsperUnit As Boolean = isFieldEmpty(txtPiecesPerUnit)
            Dim boltotalPcs As Boolean = isFieldEmpty(txtTotalPcs)
            Dim bolamountPaid As Boolean = isFieldEmpty(txtTotalAmountPaid)
            '
            Dim bolsupplier As Boolean = isComboboxEmpty(cmbxSupplier)
            Dim bolitem As Boolean = isComboboxEmpty(cmbxItemName)
            Dim bolPurchasedIn As Boolean = isComboboxEmpty(cmbxPurchasedIn)
            '
            If bolsupplier Then
                msgbBoxShw()
            ElseIf bolitem Then
                msgbBoxShw()
            ElseIf bolPurchasedIn Then
                msgbBoxShw()
            ElseIf bolqty Then
                msgbBoxShw()
            ElseIf bolpcsperUnit Then
                msgbBoxShw()
            ElseIf boltotalPcs Then
                msgbBoxShw()
            ElseIf bolamountPaid Then
                msgbBoxShw()
            Else
                Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to update this record.", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If answer = Windows.Forms.DialogResult.Yes Then
                    updateStocks()
                    loadupdatedStocks()
                End If
            End If
        End If
    End Sub
    '
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        searchStockbyDate()
    End Sub
    'END!
    '***********************************************************************************
    '!COMMENT: EVENTS
    'i. Form closing
    Private Sub Stocks_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadManagePharmacy()
    End Sub
    'ii. Form load
    Private Sub Stocks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadStocks()
    End Sub
    ' Key Press (Is letter)
    Private Sub Isletter(sender As Object, e As KeyPressEventArgs) Handles txtSuppliername.KeyPress, txtSearchItemname.KeyPress, txtItemName.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> " " And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    'Key press (Is number)
    Private Sub IsNumber(sender As Object, e As KeyPressEventArgs) Handles txtTotalPcs.KeyPress, txtQuantity.KeyPress, txtPiecesPerUnit.KeyPress
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    'Key press (Is decimal)
    Private Sub IsDecimal(sender As Object, e As KeyPressEventArgs) Handles txtTotalAmountPaid.KeyPress
        If Char.IsDigit(e.KeyChar) = False And e.KeyChar <> vbBack And e.KeyChar <> "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And CType(sender, TextBox).Text.IndexOf(".") > -1 Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub txtSuppliername_TextChanged(sender As Object, e As EventArgs) Handles txtSuppliername.TextChanged
        loadSupplierInfo()
    End Sub
    '
    Private Sub cmbxSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxSupplier.SelectedIndexChanged
        loadSupplierCode()
    End Sub
    '
    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged
        loadItems()
    End Sub
    '
    Private Sub cmbxItemName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxItemName.SelectedIndexChanged
        loadItemCode()
    End Sub
    '
    Private Sub DGVstocks_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVstocks.CellClick
        Try
            charlieSierra = Nothing
            btnSave.Enabled = False
            btnUpdate.Enabled = True
            Dim romeo As Integer = Nothing
            If DGVstocks.RowCount > 0 Then
                romeo = DGVstocks.CurrentRow.Index
                charlieSierra = DGVstocks.Item(0, romeo).Value
                populateStockstoField()
            End If
        Catch
            charlieSierra = Nothing
            clearFields()
        End Try
    End Sub
    '
    Private Sub txtSearchItemname_TextChanged(sender As Object, e As EventArgs) Handles txtSearchItemname.TextChanged
        searchStocksbyItemName()
    End Sub
    'END!
    '***********************************************************************************
    '!COMMENT: METHODS
    'Clear fileds
    Public Sub clearFields()
        txtSuppliername.Text = ""
        cmbxSupplier.SelectedIndex = -1
        txtSupplierCode.Text = ""
        '
        txtItemName.Text = ""
        cmbxItemName.SelectedIndex = -1
        txtItemCode.Text = ""
        '
        txtStockInCode.Text = ""
        cmbxPurchasedIn.SelectedIndex = -1

        txtQuantity.Text = ""
        txtPiecesPerUnit.Text = ""
        txtTotalPcs.Text = ""
        txtTotalAmountPaid.Text = ""
        '
        dtpDatePurchased.Value = Date.Now.ToShortDateString
        '
        txtSearchItemname.Text = ""
        dtpSearchPurchasedDate.Value = Date.Now.ToShortDateString
        '
    End Sub
    '
    Public Sub loadSupplierInfo()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select SupplierID, SupplierCode, SupplierFullname from tblSupplier where SupplierFullname like '' +@sname+ '%' order by SupplierFullname ASC; ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@sname", txtSuppliername.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            cmbxSupplier.DataSource = Nothing
            cmbxSupplier.DataSource = dt
            cmbxSupplier.ValueMember = "SupplierID"
            cmbxSupplier.DisplayMember = "SupplierFullname"
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub loadSupplierCode()
        If cmbxSupplier.Text = "" Then
        Else
            Dim selectedItem As DataRowView = cmbxSupplier.SelectedItem
            txtSupplierCode.Text = selectedItem("SupplierCode")
            supplierID = selectedItem("SupplierID")
        End If
    End Sub
    '
    Public Sub loadItems()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select ItemID, ItemCode, ItemName from tblItems where ItemName like '' +@itemName+ '%' order by ItemName ASC; ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemName", txtItemName.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            cmbxItemName.DataSource = Nothing
            cmbxItemName.DataSource = dt
            cmbxItemName.ValueMember = "ItemID"
            cmbxItemName.DisplayMember = "ItemName"
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub loadItemCode()
        If cmbxItemName.Text = "" Then
            '//
        Else
            Dim selectedItem As DataRowView = cmbxItemName.SelectedItem
            txtItemCode.Text = selectedItem("ItemCode")
            itemid = selectedItem("ItemID")
        End If
    End Sub
    '
    Public Function isFieldEmpty(ByVal txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
    '
    Public Function isComboboxEmpty(ByVal cmbx As ComboBox) As Boolean
        Return String.IsNullOrEmpty(cmbx.Text)
    End Function
    '
    Public Sub saveNewStocks()
        Dim bolqty As Boolean = isFieldEmpty(txtQuantity)
        Dim bolpcsperUnit As Boolean = isFieldEmpty(txtPiecesPerUnit)
        Dim boltotalPcs As Boolean = isFieldEmpty(txtTotalPcs)
        Dim bolamountPaid As Boolean = isFieldEmpty(txtTotalAmountPaid)
        '
        Dim bolsupplier As Boolean = isComboboxEmpty(cmbxSupplier)
        Dim bolitem As Boolean = isComboboxEmpty(cmbxItemName)
        Dim bolPurchasedIn As Boolean = isComboboxEmpty(cmbxPurchasedIn)
        '
        If bolsupplier Then
            msgbBoxShw()
        ElseIf bolitem Then
            msgbBoxShw()
        ElseIf bolPurchasedIn Then
            msgbBoxShw()
        ElseIf bolqty Then
            msgbBoxShw()
        ElseIf bolpcsperUnit Then
            msgbBoxShw()
        ElseIf boltotalPcs Then
            msgbBoxShw()
        ElseIf bolamountPaid Then
            msgbBoxShw()
        Else
            'If fields not empty and combo box not empty
            Dim s_id As Integer = Nothing
            Dim result As Integer = Nothing
            Dim yearNow As Integer = Date.Now.Year
            '
            Dim db As New KonekDB
            db.FETPHARMAINFO()
            'Get the current stockid
            Using da As New SqlDataAdapter("Select MAX(StockInID) as stockid from tblStockIn;", db.pubSqlCon)
                Dim dt As New DataTable
                dt.Rows.Clear()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).IsNull("stockid") Then
                        s_id = 1
                        stockid = s_id
                    Else
                        result = Val(dt.Rows(0).Item("stockid"))
                        s_id = result + 1
                        stockid = s_id
                    End If
                End If
                db.pubSqlCon.Close()
                dt.Dispose()
                da.Dispose()
            End Using
            'Insert new record on database
            Using cmd As New SqlCommand("Insert into tblStockIn (StockInCode, SupplierID, ItemID, Purchased_In, QTY, PcsPerUnit, TotalPcs, DatePurchased,TotalAmountPaid) values (@stockcode,@supplierid,@itemid,@purchasedIn,@qty,@pcsperunit,@totalpcs,@datepurchased,@totalamountpaid)", db.pubSqlCon)
                db.pubSqlCon.Open()
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@stockcode", SqlDbType.VarChar).Value = s_id.ToString() & "-S" & yearNow.ToString()
                cmd.Parameters.Add("@supplierid", SqlDbType.Int).Value = supplierID
                cmd.Parameters.Add("@itemid", SqlDbType.BigInt).Value = itemid
                cmd.Parameters.Add("@purchasedIn", SqlDbType.VarChar).Value = cmbxPurchasedIn.Text
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = txtQuantity.Text
                cmd.Parameters.Add("@pcsperunit", SqlDbType.Int).Value = txtPiecesPerUnit.Text
                cmd.Parameters.Add("@totalpcs", SqlDbType.Int).Value = txtTotalPcs.Text
                cmd.Parameters.Add("@datepurchased", SqlDbType.Date).Value = dtpDatePurchased.Value
                cmd.Parameters.Add("@totalamountpaid", SqlDbType.Decimal).Value = txtTotalAmountPaid.Text
                cmd.ExecuteNonQuery()
                MsgBox("New stock added!")
                db.pubSqlCon.Close()
                clearFields()
            End Using
        End If
    End Sub
    '
    Public Sub loadNewStock()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select StockInID, StockInCode,SupplierID,ItemID,Purchased_In,QTY,PcsPerUnit,TotalPcs,DatePurchased,TotalAmountPaid from tblStockIn where StockInID=@stockid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stockid", stockid)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            DGVstocks.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            stockid = Nothing
        End Using
    End Sub
    '
    Public Sub loadStocks()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using da As New SqlDataAdapter("Select top 100 StockInID, StockInCode,SupplierID,ItemID,Purchased_In,QTY,PcsPerUnit,TotalPcs,DatePurchased,TotalAmountPaid from tblStockIn order by StockInID DESC;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            DGVstocks.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub populateStockstoField()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select ti.ItemName, ts.SupplierFullname,tsi.StockInCode,tsi.Purchased_In,tsi.QTY,tsi.PcsPerUnit,tsi.TotalPcs,tsi.DatePurchased,tsi.TotalAmountPaid from tblStockIn as tsi " & _
" Inner join tblSupplier as ts On tsi.SupplierID = ts.SupplierID " & _
" Inner Join tblItems as ti On tsi.ItemID = ti.ItemID where StockInID=@stockid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stockid", charlieSierra)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtItemName.Text = dt.Rows(0).Item("ItemName")
                txtSuppliername.Text = dt.Rows(0).Item("SupplierFullname")
                txtStockInCode.Text = dt.Rows(0).Item("StockInCode")
                cmbxPurchasedIn.Text = dt.Rows(0).Item("Purchased_In")
                txtQuantity.Text = dt.Rows(0).Item("QTY")
                txtPiecesPerUnit.Text = dt.Rows(0).Item("PcsPerUnit")
                txtTotalPcs.Text = dt.Rows(0).Item("TotalPcs")
                txtTotalAmountPaid.Text = dt.Rows(0).Item("TotalAmountPaid")
                dtpDatePurchased.Text = dt.Rows(0).Item("DatePurchased")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub updateStocks()
            Dim db As New KonekDB
            db.FETPHARMAINFO()
            Using cmd As New SqlCommand("Update tblStockIn Set StockInCode=@stockcode,SupplierID=@supplierid,ItemID=@itemid,Purchased_In=@purchasedIn,QTY=@qty,PcsPerUnit=@pcsperUnit,TotalPcs=@totalpcs,DatePurchased=@datepurchased,TotalAmountPaid=@totalamountpaid  where StockInID=@stockid;", db.pubSqlCon)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@stockid", charlieSierra)
                cmd.Parameters.AddWithValue("@stockcode", txtStockInCode.Text)
                cmd.Parameters.AddWithValue("@supplierid", supplierID)
                cmd.Parameters.AddWithValue("@itemid", itemid)
                cmd.Parameters.AddWithValue("@purchasedIn", cmbxPurchasedIn.Text)
                cmd.Parameters.AddWithValue("@qty", txtQuantity.Text)
                cmd.Parameters.AddWithValue("@pcsperUnit", txtPiecesPerUnit.Text)
                cmd.Parameters.AddWithValue("@totalpcs", txtTotalPcs.Text)
                cmd.Parameters.AddWithValue("@datepurchased", dtpDatePurchased.Value)
                cmd.Parameters.AddWithValue("@totalamountpaid", txtTotalAmountPaid.Text)
                cmd.ExecuteNonQuery()
                db.pubSqlCon.Close()
                cmd.Dispose()
                MsgBox("Update successful")
                clearFields()
            End Using
    End Sub
    '
    Public Sub loadupdatedStocks()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select StockInID, StockInCode,SupplierID,ItemID,Purchased_In,QTY,PcsPerUnit,TotalPcs,DatePurchased,TotalAmountPaid from tblStockIn where StockInID=@stockid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stockid", charlieSierra)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            DGVstocks.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            charlieSierra = Nothing
        End Using
    End Sub
    '
    Public Sub searchStocksbyItemName()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select tsi.StockInID,tsi.StockInCode,ts.SupplierFullname,ti.ItemName,tsi.Purchased_In,tsi.QTY,tsi.PcsPerUnit,tsi.TotalPcs,tsi.DatePurchased,tsi.TotalAmountPaid from tblStockIn as tsi " & _
 " Inner join tblSupplier as ts On tsi.SupplierID = ts.SupplierID " & _
 " Inner Join tblItems as ti On tsi.ItemID = ti.ItemID where ti.ItemName like '' +@itemname+ '%' order by ti.ItemName ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemname", txtSearchItemname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            DGVstocks.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchStockbyDate()
        Dim det As Date = CDate(dtpSearchPurchasedDate.Text)
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select tsi.StockInID,tsi.StockInCode,ts.SupplierFullname,ti.ItemName,tsi.Purchased_In,tsi.QTY,tsi.PcsPerUnit,tsi.TotalPcs,tsi.DatePurchased,tsi.TotalAmountPaid from tblStockIn as tsi " & _
" Inner join tblSupplier as ts On tsi.SupplierID = ts.SupplierID " & _
" Inner Join tblItems as ti On tsi.ItemID = ti.ItemID  where tsi.DatePurchased=@date;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@date", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            DGVstocks.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'END!
    '***********************************************************************************

End Class