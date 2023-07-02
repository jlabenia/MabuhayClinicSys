Imports System.Data.SqlClient
Public Class ItemDetails
    '!COMMENT: PRIVATE VARIABLES
    Dim charlieSierraIndia As Integer = Nothing
    Dim charlieIndia As Integer = Nothing
    '
    Dim newitemdetailsid As Integer = Nothing
    Dim stockIn_quantity As Integer = Nothing
    'END!
    '**********************************************************************************
    '!COMMENT: BUTTONS
    'i. SAVE
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim boltxtStockID As Boolean = IsEmpty(txtStockid)
        Dim boltxtStockCode As Boolean = IsEmpty(txtStockInCode)
        Dim bolUOM As Boolean = IsEmpty(txtuomQty)
        Dim bolPcs As Boolean = IsEmpty(txtPcs)
        Dim bolunitprice As Boolean = IsEmpty(txtUnitprice)
        Dim bolbarcode As Boolean = IsEmpty(txtBarcode)
        '
        Dim det As Date = dtpExpDate.Value
        Dim detNow As Date = CDate(Date.Now.ToShortDateString)
        '
        If charlieSierraIndia <> 0 Then
            If boltxtStockID Then
                msgbBoxShw()
            ElseIf boltxtStockCode Then
                msgbBoxShw()
            ElseIf bolUOM Then
                msgbBoxShw()
            ElseIf bolPcs Then
                msgbBoxShw()
            ElseIf bolunitprice Then
                msgbBoxShw()
            ElseIf bolbarcode Then
                msgbBoxShw()
            Else
                If cmbxUOM.SelectedIndex <= 0 Then
                    msgbBoxShw()
                Else
                    If det > detNow Then
                        SaveNewRecord()
                        loadNewRecord()
                        loadtotalPcs()
                        loadTotalValue()
                    Else
                        MsgBox("Warning! Please check your date. Kindly select an expiration date ahead of date today.", MsgBoxStyle.Exclamation)
                    End If
                End If
            End If
        End If
    End Sub
    'ii. UPDATE
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If charlieIndia <> 0 Then
            Dim boltxtStockID As Boolean = IsEmpty(txtStockid)
            Dim boltxtStockCode As Boolean = IsEmpty(txtStockInCode)
            Dim bolUOM As Boolean = IsEmpty(txtuomQty)
            Dim bolPcs As Boolean = IsEmpty(txtPcs)
            Dim bolunitprice As Boolean = IsEmpty(txtUnitprice)
            Dim bolbarcode As Boolean = IsEmpty(txtBarcode)
            '
            Dim det As Date = dtpExpDate.Value
            Dim detNow As Date = CDate(Date.Now.ToShortDateString)
            '
            If charlieSierraIndia <> 0 Then
                If boltxtStockID Then
                    msgbBoxShw()
                ElseIf boltxtStockCode Then
                    msgbBoxShw()
                ElseIf bolUOM Then
                    msgbBoxShw()
                ElseIf bolPcs Then
                    msgbBoxShw()
                ElseIf bolunitprice Then
                    msgbBoxShw()
                ElseIf bolbarcode Then
                    msgbBoxShw()
                Else
                    If cmbxUOM.SelectedIndex <= 0 Then
                        msgbBoxShw()
                    Else
                        If det > detNow Then
                            Dim answer As DialogResult = MessageBox.Show("Please confirm if you would want to update this record.", "Updating....", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If answer = Windows.Forms.DialogResult.Yes Then
                                updateItemdetails()
                                clearfields()
                                loadUpdatedItemDetails()
                            End If
                        Else
                            MsgBox("Warning! Please check your date. Kindly select an expiration date ahead of date today.", MsgBoxStyle.Exclamation)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    '
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearfields()
        charlieSierraIndia = Nothing
        charlieIndia = Nothing
        txtSearchitem.Text = ""
        txtStockid.Text = ""
        loadItemdetailsInfo()
    End Sub
    'END!
    '**********************************************************************************
    '!COMMENT:EVENTS
    Private Sub ItemDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadItemdetailsInfo()
    End Sub
    Private Sub txtSearchitem_TextChanged(sender As Object, e As EventArgs) Handles txtSearchitem.TextChanged
        If txtSearchitem.Text <> "" Then
            SearchItem()
        Else
            dgvStockin.DataSource = Nothing
            txtTotalpcs.Text = ""
            txtTotalValue.Text = ""
            loadItemdetailsInfo()
        End If
    End Sub
    '
    Private Sub dgvStockin_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStockin.CellClick
        Try
            Dim romeo As Integer = Nothing
            btnAdd.Enabled = True
            btnUpdate.Enabled = False
            charlieSierraIndia = Nothing
            If dgvStockin.RowCount > 0 Then
                romeo = dgvStockin.CurrentRow.Index
                charlieSierraIndia = dgvStockin.Item(0, romeo).Value
                populateStockinFields()
                loadNewRecord()
                If dgvItemDetails.RowCount > 1 Then
                    loadTotalValue()
                    loadtotalPcs()
                Else
                    txtTotalpcs.Text = ""
                    txtTotalValue.Text = ""
                End If
            End If
        Catch
            charlieSierraIndia = Nothing
        End Try
    End Sub
    '
    Private Sub dgvItemDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItemDetails.CellClick
        Try
            Dim romeo As Integer = Nothing
            btnAdd.Enabled = False
            btnUpdate.Enabled = True
            charlieIndia = Nothing
            If dgvItemDetails.RowCount > 0 Then
                romeo = dgvItemDetails.CurrentRow.Index
                charlieIndia = dgvItemDetails.Item(0, romeo).Value
                populateItemdetailstoFields()
                loadtotalPcs()
                loadTotalValue()
            End If
        Catch
            charlieIndia = Nothing
        End Try
    End Sub
    '
    Private Sub txtSearchitem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchitem.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> " " And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub txtSearchStockinID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtuomQty.KeyPress, txtSearchStockinID.KeyPress
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub txtUnitprice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitprice.KeyPress
        If Char.IsDigit(e.KeyChar) = False And e.KeyChar <> "." And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
        If e.KeyChar = "." And CType(sender, TextBox).Text.IndexOf(".") > -1 Then
            e.Handled = True
        End If
    End Sub
    '
    Private Sub txtSearchStockinID_TextChanged(sender As Object, e As EventArgs) Handles txtSearchStockinID.TextChanged
        If txtSearchStockinID.Text <> "" Then
            SearchByStockinID()
        Else
            loadItemdetailsInfo()
        End If
    End Sub
    '
    Private Sub ItemDetails_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadManagePharmacy()
    End Sub
    '
    'END!
    '**********************************************************************************
    '!COMMENT: METHODS
    '

    Public Sub SearchItem()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select top 10 tsi.StockInID,tsi.StockInCode,tsi.DatePurchased,ti.ItemName,ti.TypeofItem,Purchased_In,tsi.QTY,tsi.PcsPerUnit,tsi.TotalPcs,tsi.TotalAmountPaid,ts.SupplierFullname from tblStockIn  as tsi " & _
 " Inner join tblSupplier as ts On tsi.SupplierID = ts.SupplierID " & _
 " Inner Join tblItems as ti On tsi.ItemID = ti.ItemID " & _
 " Where ti.ItemName like '' +@itemname+ '%' order by ti.ItemName ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemname", txtSearchitem.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvStockin.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub populateStockinFields()
        Dim pcsString As String = Nothing
        Dim db As New KonekDB
        Dim priceofItem As Double = Nothing
        Dim totalpcs As Integer = Nothing
        Dim totalAmountpaid As Double = Nothing
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select StockInID, StockInCode,PcsPerUnit,TotalPcs, TotalAmountPaid,QTY from tblStockIn where StockInID =@stockinid; ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stockinid", charlieSierraIndia)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtStockid.Text = dt.Rows(0).Item("StockInID")
                txtStockInCode.Text = dt.Rows(0).Item("StockInCode")
                totalpcs = dt.Rows(0).Item("TotalPcs")
                totalAmountpaid = dt.Rows(0).Item("TotalAmountPaid")
                priceofItem = CDbl(totalAmountpaid / totalpcs)
                txtUnitprice.Text = priceofItem.ToString("N3")
                pcsString = dt.Rows(0).Item("PcsPerUnit")
                If pcsString = "0" Then
                    txtPcs.Text = "1"
                Else
                    txtPcs.Text = pcsString
                End If
                stockIn_quantity = dt.Rows(0).Item("QTY")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Function IsEmpty(ByVal txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
    '
    Public Sub SaveNewRecord()
        Dim det As Date = dtpExpDate.Value
        Dim itemdetailsID As Integer = Nothing
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Insert into tblItemDetails (StockInID,Barcode,UOM,ExpirationDate,UnitPrice,Pcs) values (@stockinid,@barcode,@uom,@expdate,@unitprice,@pcs);", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@stockinid", SqlDbType.BigInt).Value = txtStockid.Text
            cmd.Parameters.Add("@barcode", SqlDbType.Text).Value = txtBarcode.Text
            cmd.Parameters.Add("@uom", SqlDbType.VarChar).Value = txtuomQty.Text & cmbxUOM.Text
            cmd.Parameters.Add("@expdate", SqlDbType.Date).Value = det
            cmd.Parameters.Add("@unitprice", SqlDbType.Decimal).Value = txtUnitprice.Text
            cmd.Parameters.Add("@pcs", SqlDbType.Int).Value = txtPcs.Text
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("New record added!")
        End Using
        'Get the current itemdetailsID
        Using da As New SqlDataAdapter("Select MAX (ItemDetailsID) as id from tblItemDetails;", db.pubSqlCon)
            db.pubSqlCon.Open()
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                itemdetailsID = dt.Rows(0).Item("id")
                newitemdetailsid = itemdetailsID
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
        'Insert new record into table stock out in DB (Inventory)
        Using cmd As New SqlCommand("Insert into tblInventory (ItemDetailsID,StockOutCode,Stockin,StockOut,Remaining,Status) Values (@itemdetailsid,@stockoutcode,@stockin,@stockout,@remaining,@status);", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@stockoutcode", SqlDbType.Text).Value = "SO_" & txtBarcode.Text
            cmd.Parameters.Add("@itemdetailsid", SqlDbType.BigInt).Value = itemdetailsID
            cmd.Parameters.Add("@stockin", SqlDbType.Int).Value = txtPcs.Text
            cmd.Parameters.Add("@stockout", SqlDbType.Int).Value = 0
            cmd.Parameters.Add("@remaining", SqlDbType.Int).Value = txtPcs.Text
            cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "Available"
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            txtBarcode.Text = ""
        End Using
    End Sub
    '
    Public Sub loadNewRecord()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand(" Select tid.ItemDetailsID,tsi.StockInID,tid.Barcode, ti.ItemName,ti.TypeofItem,tid.UOM,tid.ExpirationDate,tid.UnitPrice,tid.Pcs from tblItemDetails as tid " & _
 " Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
 " Inner join tblItems as ti On tsi.ItemID = ti.ItemID " & _
 " Where tsi.StockInID = @stockinID  order by tid.ItemDetailsID ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stockinID", txtStockid.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvItemDetails.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub loadTotalValue()
        Dim itemvalue As Double = Nothing
        Dim unitprice As Double = Nothing
        Dim totalpcs As Integer = Nothing
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand(" Select SUM(Pcs) as result from tblItemDetails where StockInID = @stockinid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stockinid", txtStockid.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                totalpcs = dt.Rows(0).Item("result")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
        '
        Using cmd As New SqlCommand(" Select UnitPrice from tblItemDetails where StockInID = @stockinid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stockinid", txtStockid.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                unitprice = dt.Rows(0).Item("UnitPrice")
                itemvalue = unitprice * totalpcs
                txtTotalValue.Text = itemvalue.ToString("N2")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using

    End Sub
    '
    Public Sub loadtotalPcs()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand(" Select  COUNT(Pcs) as result from tblItemDetails where StockInID = @stockinid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stockinid", txtStockid.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtTotalpcs.Text = dt.Rows(0).Item("result")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub populateItemdetailstoFields()
        Dim uomDigit As String = Nothing
        Dim uomLetter As String = Nothing
        Dim uom As String = Nothing
        Dim uomcmbx As String = Nothing
        Dim uomtxtbox As String = Nothing
        '
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand(" Select tid.ItemDetailsID, tid.StockInID,tsi.StockInCode ,tid.Barcode, tid.UOM, tid.ExpirationDate, tid.UnitPrice, tid.Pcs from tblItemDetails as tid " & _
 " Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
 " Where tid.ItemDetailsID=@itemdetailsid ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemdetailsid", charlieIndia)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtItemDetailsID.Text = dt.Rows(0).Item("ItemDetailsID")
                txtStockid.Text = dt.Rows(0).Item("StockInID")
                txtStockInCode.Text = dt.Rows(0).Item("StockInCode")
                txtBarcode.Text = dt.Rows(0).Item("Barcode")
                txtPcs.Text = dt.Rows(0).Item("Pcs")
                txtUnitprice.Text = dt.Rows(0).Item("UnitPrice")
                dtpExpDate.Text = dt.Rows(0).Item("ExpirationDate")
                uom = dt.Rows(0).Item("UOM")
                'check if uom contains letter or number
                For Each lettr As Char In uom
                    If Char.IsLetter(lettr) Then
                        uomcmbx = uomcmbx + lettr
                    End If
                    If Char.IsNumber(lettr) Then
                        uomtxtbox = uomtxtbox + lettr
                    End If
                Next
                '
                txtuomQty.Text = uomtxtbox
                cmbxUOM.Text = uomcmbx
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub updateItemdetails()
        Dim det As Date = CDate(dtpExpDate.Value)
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Update tblItemDetails set StockInID=@stockinID,Barcode=@barcode,UOM=@uom,ExpirationDate=@expdate,UnitPrice=@unitprice,Pcs=@pcs where ItemDetailsID=@itemdetailsID;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stockinID", txtStockid.Text)
            cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@uom", txtuomQty.Text & cmbxUOM.Text)
            cmd.Parameters.AddWithValue("@expdate", det)
            cmd.Parameters.AddWithValue("@unitprice", txtUnitprice.Text)
            cmd.Parameters.AddWithValue("@pcs", txtPcs.Text)
            cmd.Parameters.AddWithValue("@itemdetailsID", charlieIndia)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Update succesful!")
        End Using
    End Sub
    '
    Public Sub loadUpdatedItemDetails()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select tid.ItemDetailsID,tsi.StockInID,tsi.DatePurchased,tid.Barcode, ti.ItemName,ti.TypeofItem,tid.UOM,tid.ExpirationDate,tid.UnitPrice,tid.Pcs from tblItemDetails as tid " & _
" Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
" Inner join tblItems as ti On tsi.ItemID = ti.ItemID " & _
" where tid.ItemDetailsID =@itemdetailsid; ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemdetailsid", charlieIndia)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvItemDetails.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            charlieIndia = Nothing
        End Using
    End Sub
    '
    Public Sub clearfields()
        txtItemDetailsID.Text = ""
        txtStockid.Text = ""
        txtStockInCode.Text = ""
        txtBarcode.Text = ""
        txtPcs.Text = ""
        txtUnitprice.Text = ""
        txtuomQty.Text = ""
        txtTotalpcs.Text = ""
        txtTotalValue.Text = ""
        cmbxUOM.SelectedIndex = -1
        dtpExpDate.Value = CDate(Date.Now.ToShortDateString)
        btnAdd.Enabled = True
        btnUpdate.Enabled = False
    End Sub
    '
    Public Sub loadItemdetailsInfo()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using da As New SqlDataAdapter(" Select top 100 tid.ItemDetailsID,tsi.StockInID,tsi.DatePurchased, ti.ItemName,ti.TypeofItem,tid.Barcode,tid.UOM,tid.ExpirationDate,tid.UnitPrice,tid.Pcs from tblItemDetails as tid " & _
 " Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
 " Inner join tblItems as ti On tsi.ItemID = ti.ItemID order by tid.ItemDetailsID DESC;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvItemDetails.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub SearchByStockinID()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select tid.ItemDetailsID,tsi.StockInID,tsi.DatePurchased, ti.ItemName,ti.TypeofItem,tid.Barcode,tid.UOM,tid.ExpirationDate,tid.UnitPrice,tid.Pcs from tblItemDetails as tid " & _
 " Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
 " Inner join tblItems as ti On tsi.ItemID = ti.ItemID  " & _
 " where tsi.StockInID like '' +@stockinID+ '%' order by tid.ItemDetailsID DESC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stockinID", txtSearchStockinID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvItemDetails.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub

    'END!
    '**********************************************************************************
End Class