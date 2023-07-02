Imports System.Data.SqlClient
'Imports MabuhayClinicSystem.orderItems
Imports System.Drawing.Printing
Public Class PharmacyFrm
    '!COMMENT: VARIABLES
    Dim order As New List(Of orderItems)
    '
    Dim totalQTY As Integer = Nothing
    Dim totalAmount As Decimal = Nothing
    Dim sierraRomeo As Integer = Nothing
    Dim selectedRowsQty As String = Nothing
    Dim selectedRowsSubtotal As String = Nothing
    '
    Dim transactionNo As Integer = Nothing ' see order list method
    Dim paymentID As Integer = Nothing ' see order list method
    Dim totalItems As Integer = Nothing
    Dim documentLenght As Integer = 280 'see beginprint
    '
    Dim WithEvents PD As New PrintDocument
    Dim PDD As New PrintPreviewDialog
    '
    Dim localDatatable As New DataTable 'refer to getBilling Info

    'END!
    '**********************************************************************************************************
    '!COMMENT: BUTTONS
    'i. ENTER
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        If txtQty.Text <> "" Then
            '
            lblTotalQty.Text = ""
            lblTotalAmount.Text = ""
            '
            checkIfItemsExist()
            txtQty.Text = ""
        End If
    End Sub
    'ii. REMOVE
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim rowCountWithData As Integer = 0
        '
        For Each romeo As DataGridViewRow In DGVorderitems.Rows
            If Not romeo.IsNewRow Then
                Dim hasData As Boolean = False
                For Each charlie As DataGridViewCell In romeo.Cells
                    If Not String.IsNullOrEmpty(charlie.Value) Then
                        hasData = True
                        Exit For
                    End If
                Next
                If hasData Then
                    rowCountWithData += 1
                End If
            End If
        Next
        '
        If rowCountWithData >= 2 And sierraRomeo = 0 Then
            removeOrderItem()
        Else
            removeOrderItem()
        End If
    End Sub
    'iii. PAY
    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        If txtFullname.Text <> "" Then
            Dim intrfce As String = "Pharmacy"
            Dim btn As String = "Proceed to pay"
            Dim actn As String = "Click"
            '
            UserActivity(intrfce, btn, actn)
            amountDue = CDec(lblTotalAmount.Text)
            customerName = CStr(txtFullname.Text)
            'reset private variables
            intrfce = Nothing
            btn = Nothing
            actn = Nothing
            '
            PaymentFrm.Show()
        Else
            cmbxSearchCustomer.Select()
            cmbxSearchCustomer.Focus()
            msgbBoxShw()
        End If
    End Sub
    'END!
    '**********************************************************************************************************
    '!COMMENT: EVENTS
    'i.Form closing
    Private Sub PharmacyFrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        PaymentFrm.Close()
        UserDashboard.returntoUserDashboard()
        glblorderItemVarreset()
    End Sub
    'ii. Form Load
    Private Sub PharmacyFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim intrfce As String = "Pharmacy"
        Dim btn As String = "N/A"
        Dim actn As String = "Open"
        UserActivity(intrfce, btn, actn)
        SearchCustomer()
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'iii. text Changed
    Private Sub txtbarcode_TextChanged(sender As Object, e As EventArgs) Handles txtbarcode.TextChanged
        If rbtnBarcode.Checked = True Then
            searchBybarcode()
        ElseIf rbtnItemName.Checked = True Then
            SearchbyItem()
        Else
            txtbarcode.Text = ""
        End If
        '
        If txtbarcode.Text = "" Then
            pfClear()
        End If
    End Sub
    'iv. DGV Search item (click)
    Private Sub DGVSearchBrcdItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVSearchBrcdItem.CellClick
        If txtbarcode.Text <> "" Then
            pfClear()
            whenDGVsearchItem()
        Else
            DGVSearchBrcdItem.DataSource = Nothing
        End If
    End Sub
    'v. Keypress event
    Private Sub txtbarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarcode.KeyPress
        If rbtnBarcode.Checked = True Then
            If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        Else
            e.Handled = False
        End If
    End Sub
    'vi. Combo box search customer Selected Index changed
    Private Sub cmbxSearchCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbxSearchCustomer.SelectedIndexChanged
        If DGVorderitems.Columns.Count > 0 Then
            getCustomer()
        End If
    End Sub
    'vii. DGV Order item (click)
    Private Sub DGVorderitems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVorderitems.CellClick
        Dim romeo As Integer = Nothing
        If DGVorderitems.SelectedRows.Count > 0 Then
            Dim selectedIndex As Integer = DGVorderitems.SelectedRows(0).Index
            If selectedIndex >= 0 And selectedIndex < DGVorderitems.RowCount Then
                romeo = DGVorderitems.CurrentRow.Index
                '
                selectedRowsQty = DGVorderitems.Item(5, romeo).Value
                selectedRowsSubtotal = DGVorderitems.Item(7, romeo).Value
                sierraRomeo = selectedIndex
            End If
        End If
    End Sub
    'viii.Radio button Item name
    Private Sub rbtnItemName_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnItemName.CheckedChanged
        If rbtnItemName.Checked = True Then
            DGVSearchBrcdItem.DataSource = Nothing
            txtbarcode.Text = ""
        End If
    End Sub
    'ix. Radio button Barcode
    Private Sub rbtnBarcode_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnBarcode.CheckedChanged
        If rbtnBarcode.Checked = True Then
            DGVSearchBrcdItem.DataSource = Nothing
            txtbarcode.Text = ""
        End If
    End Sub
    'x. Form size change event
    Private Sub PharmacyFrm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            PaymentFrm.Close()
        End If
    End Sub
    'END!
    '**********************************************************************************************************
    '!COMMENT: METHOD
    'i.Search barcode
    Public Sub searchBybarcode()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select tid.Barcode,tid.ItemDetailsID as ItemNo, ti.ItemName,ti.TypeofItem,tid.UOM,CONCAT(tin.Remaining, ' pcs') as Remaining,tid.ExpirationDate,tsi.Purchased_In as _In,tid.UnitPrice,tin.Status,ti.GenericName,ti.Dosage,ti.ItemDescription from tblItemDetails as tid " & _
                                    " Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
                                    " Inner join tblItems as ti On tsi.ItemID = ti.ItemID " & _
                                    " Inner Join tblInventory as tin On tid.ItemDetailsID = tin.ItemDetailsID Where tid.Barcode = @barcode and tin.Status = 'Available' ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@barcode", txtbarcode.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            DGVSearchBrcdItem.DataSource = dt
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'ii. Search Item
    Public Sub SearchbyItem()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select tid.Barcode,tid.ItemDetailsID as ItemNo, ti.ItemName,ti.TypeofItem,tid.UOM,CONCAT(tin.Remaining, ' pcs') as Remaining,tid.ExpirationDate,tsi.Purchased_In as _In,tid.UnitPrice,tin.Status,ti.GenericName,ti.Dosage,ti.ItemDescription from tblItemDetails as tid " & _
                                    " Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
                                    " Inner join tblItems as ti On tsi.ItemID = ti.ItemID " & _
                                    " Inner Join tblInventory as tin On tid.ItemDetailsID = tin.ItemDetailsID Where ti.ItemName like '' +@itemname+ '%' And tin.Status = 'Available' Order by tid.Barcode ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemname", txtbarcode.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            DGVSearchBrcdItem.DataSource = dt
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'iii. Add new oredered item
    Public Sub addnewItem()
        'Pass value to class orderItems after assigning value to global variables.
        Dim newOrderItem As New orderItems()
        newOrderItem.BARCODE = _barcode
        newOrderItem.ITEMNO = _itemno
        newOrderItem.ITEMNAME = _itemName
        newOrderItem.UOM = _UOM
        newOrderItem.TYPE = _typeofitem
        newOrderItem.PRICE = _price
        newOrderItem.QTY = _qty
        newOrderItem.SUBTOTAL = _subtotal
        '
        order.Add(newOrderItem)
        DGVorderitems.DataSource = Nothing
        DGVorderitems.DataSource = order
    End Sub
    'iv. Clear fields
    Public Sub pfClear()
        'Clear txtFields
        txtQty.Text = ""
        txtDescription.Text = ""
        txtExpiryDate.Text = ""
        txtDosage.Text = ""
        txtGenericname.Text = ""
        'Clear value of DGV rows
        sierraRomeo = 0
        selectedRowsQty = ""
        selectedRowsSubtotal = ""
    End Sub
    'v. Load when DGV search item cell click
    Public Sub whenDGVsearchItem()
        Try
            Dim romeo As Integer = Nothing
            'Get the DGV rows value and pass to txtFeilds
            Dim subtotal As Decimal = Nothing
            Dim expiryDet As Date = Nothing
            Dim remaining As String = Nothing
            Dim inputQty As String = Nothing
            'Refer to While Loop
            Dim validInput As Boolean = False
            '
            If DGVSearchBrcdItem.Rows.Count > 0 Then
                romeo = DGVSearchBrcdItem.CurrentRow.Index
                'Pass value to orderlist class through global variables
                _barcode = DGVSearchBrcdItem.Item(0, romeo).Value
                _itemno = DGVSearchBrcdItem.Item(1, romeo).Value
                _itemName = DGVSearchBrcdItem.Item(2, romeo).Value
                _typeofitem = DGVSearchBrcdItem.Item(3, romeo).Value
                _UOM = DGVSearchBrcdItem.Item(4, romeo).Value
                _price = DGVSearchBrcdItem.Item(8, romeo).Value
                '
                remaining = DGVSearchBrcdItem.Item(5, romeo).Value
                'Pass DGV rows value to txtfields
                expiryDet = DGVSearchBrcdItem.Item(6, romeo).Value
                txtGenericname.Text = DGVSearchBrcdItem.Item(10, romeo).Value
                txtDosage.Text = DGVSearchBrcdItem.Item(11, romeo).Value
                txtDescription.Text = DGVSearchBrcdItem.Item(12, romeo).Value
                '
                txtExpiryDate.Text = expiryDet.ToString("D")
                'check if input is greater than the remaining item qty
                While Not validInput
                    inputQty = InputBox("Type many?", "Qty")
                    If IsNumeric(inputQty) Then
                        validInput = True
                        If inputQty > Val(remaining) Then
                            validInput = False
                        ElseIf inputQty < 1 Then
                            validInput = False
                        Else
                            txtQty.Text = inputQty
                            _qty = txtQty.Text
                        End If
                    Else
                        validInput = False
                    End If
                End While
                _qty = txtQty.Text
                subtotal = Convert.ToDecimal(CInt(_qty) * CDec(_price))
                _subtotal = subtotal.ToString
                '
                btnEnter.Select()
                btnEnter.Focus()
            End If
        Catch
            glblorderItemVarreset()
            pfClear()
        End Try
    End Sub
    'vi. Load customer fullname
    Public Sub SearchCustomer()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select personID, CONCAT(FIRSTNAME,' ' ,MIDDLENAME,' ',LASTNAME) as FULLNAME from tblperson order by FULLNAME ASC  ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@fname", cmbxSearchCustomer.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            cmbxSearchCustomer.DataSource = dt
            cmbxSearchCustomer.ValueMember = "FULLNAME"
            cmbxSearchCustomer.SelectedValue = " personID"
            da.Dispose()
            cmd.Dispose()
            db.pubSqlCon.Close()
        End Using
    End Sub
    'vii. Get customer
    Public Sub getCustomer()
        If cmbxSearchCustomer.SelectedIndex <> -1 Then
            Dim selectedItem As DataRowView = cmbxSearchCustomer.SelectedItem
            Dim i As String = selectedItem("FULLNAME")
            txtFullname.Text = i
        End If
    End Sub
    'viii. Removed item in orderItem
    Public Sub removeOrderItem()
        Dim secondItemList As List(Of orderItems) = CType(DGVorderitems.DataSource, List(Of orderItems))
        Dim newqtytotal As Integer = Nothing
        Dim newtotalAmount As Decimal = Nothing
        '
        order.RemoveAt(sierraRomeo)
        DGVorderitems.DataSource = Nothing
        DGVorderitems.DataSource = secondItemList
        '
        newqtytotal = CInt(lblTotalQty.Text) - CInt(selectedRowsQty)
        lblTotalQty.Text = ""
        lblTotalQty.Text = newqtytotal.ToString
        '
        newtotalAmount = CDec(lblTotalAmount.Text) - CDec(selectedRowsSubtotal)
        lblTotalAmount.Text = ""
        lblTotalAmount.Text = newtotalAmount.ToString("0.00")
        '
        newqtytotal = 0
        newtotalAmount = 0
        newqtytotal = Nothing
        newtotalAmount = Nothing
        '
        If DGVorderitems.Rows.Count = 0 Then
            totalQTY = 0
            totalAmount = 0
            totalQTY = Nothing
            totalAmount = Nothing
        End If
    End Sub
    'ix. Order list
    Public Sub saveOrderList()
        Dim db As New KonekDB
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        db.FETPHARMAINFO()
        'Get transaction id
        Using da As New SqlDataAdapter("Select Max(TransactionID)as transactionid from tblTransactions;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            transactionNo = dt.Rows(0).Item("transactionid")
            dt.Dispose()
            da.Dispose()
            db.pubSqlCon.Close()
        End Using
        'Get Payment id
        Using da As New SqlDataAdapter("Select Max(PaymentID) as paymentid from tblPayment;", db.pubSqlCon)
            db.pubSqlCon.Open()
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            paymentID = dt.Rows(0).Item("paymentid")
            dt.Dispose()
            da.Dispose()
            db.pubSqlCon.Close()
        End Using
        'Save new order list
        For Each romeo As DataGridViewRow In DGVorderitems.Rows
            Using cmd As New SqlCommand("Insert into tblOrderList (ItemDetailsID,_Barcode, Itemname,UOM,Type, Qty,Price,Subtotal,TransactionID,PaymentID) Values (@itemdetailsid,@barcode,@itemname,@uom,@type,@qty,@price,@subtotal,@transactionid,@paymentid);", db.pubSqlCon)
                db.pubSqlCon.Open()
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@barcode", System.Data.SqlDbType.VarChar).Value = romeo.Cells("BARCODE").Value
                cmd.Parameters.Add("@itemdetailsid", System.Data.SqlDbType.BigInt).Value = romeo.Cells("ITEMNO").Value
                cmd.Parameters.Add("@itemname", System.Data.SqlDbType.VarChar).Value = romeo.Cells("ITEMNAME").Value
                cmd.Parameters.Add("@uom", System.Data.SqlDbType.VarChar).Value = romeo.Cells("UOM").Value
                cmd.Parameters.Add("@type", System.Data.SqlDbType.VarChar).Value = romeo.Cells("TYPE").Value
                cmd.Parameters.Add("@qty", System.Data.SqlDbType.Int).Value = romeo.Cells("QTY").Value
                cmd.Parameters.Add("@price", System.Data.SqlDbType.Decimal).Value = romeo.Cells("PRICE").Value
                cmd.Parameters.Add("@subtotal", System.Data.SqlDbType.Decimal).Value = romeo.Cells("SUBTOTAL").Value
                cmd.Parameters.Add("@transactionid", System.Data.SqlDbType.BigInt).Value = transactionNo
                cmd.Parameters.Add("@paymentid", System.Data.SqlDbType.BigInt).Value = paymentID
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                db.pubSqlCon.Close()
            End Using
        Next
        'Clear txtFields
        pfClear()
        txtFullname.Text = ""
        cmbxSearchCustomer.SelectedIndex = -1
        lblTotalAmount.Text = ""
        lblTotalQty.Text = ""
        txtbarcode.Text = ""
        'Reset the DGV ordered items
        DGVorderitems.DataSource = Nothing
    End Sub
    'x. Check if the user input the same barcode.
    Public Sub checkIfItemsExist()
        Dim itemIndex As Integer = -1
        'Check item if already exist
        For i As Integer = 0 To order.Count - 1
            If order(i).BARCODE = _barcode Then
                itemIndex = i
                Exit For
            End If
        Next
        'If item exist, update quantity
        If itemIndex <> -1 Then
            order(itemIndex).QTY += _qty
            order(itemIndex).SUBTOTAL += _subtotal
        Else 'Otherwise add the new item to list
            addnewItem()
        End If
        'display the total qty & amount
        totalQTY = totalQTY + CInt(_qty)
        lblTotalQty.Text = totalQTY.ToString
        totalAmount = totalAmount + CDec(_subtotal)
        lblTotalAmount.Text = totalAmount.ToString("0.00")
        'reset
        _barcode = ""
        _qty = 0
        _barcode = Nothing
        _qty = Nothing
        DGVorderitems.DataSource = Nothing
        DGVorderitems.DataSource = order
    End Sub
    'xi. Update sql unit table
    Public Sub updateSqltblUnitOut()
        Dim db As New KonekDB
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        db.FETPHARMAINFO()
        'Get value from selected columns in tbl Orderlist having the same transaction id then store the data to data table
        Using cmd As New SqlCommand("Select OrderListID,ItemDetailsID,_Barcode,Qty from tblOrderList where TransactionID = @transactionid And PaymentID=@paymentid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@transactionid", transactionNo)
            cmd.Parameters.AddWithValue("@paymentid", paymentID)
            da.SelectCommand = cmd
            da.Fill(dt)
        'From data table, pass the data to tbl StockOut
            If dt.Rows.Count > 0 Then
                Using cmd2 As New SqlCommand("Insert into tblStockOut (UnitOutCode,ItemDetailsID,UnitSold,OrderListID) values (@unitoutcode,@itemdetailsid,@unitsold,@orderlistid);", db.pubSqlCon)
                    For Each rowValue As DataRow In dt.Rows
                        cmd2.Parameters.Clear()
                        cmd2.Parameters.Add("@unitoutcode", SqlDbType.Text).Value = "UO-" + rowValue("_Barcode").ToString()
                        cmd2.Parameters.Add("@itemdetailsid", SqlDbType.VarChar).Value = rowValue("ItemDetailsID").ToString()
                        cmd2.Parameters.Add("@unitsold", SqlDbType.Int).Value = rowValue("Qty").ToString()
                        cmd2.Parameters.Add("@orderlistid", SqlDbType.BigInt).Value = rowValue("OrderListID").ToString()
                        cmd2.ExecuteNonQuery()
                    Next
                    cmd2.Dispose()
                End Using
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'Update Remaining stock
    Public Sub updateInventory()
        '//The joker's algorithm
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Dim dt As New DataTable
        Using da1 As New SqlDataAdapter("select itemdetailsid from tblStockOut", db.pubSqlCon)
            dt.Rows.Clear()
            da1.Fill(dt)
            'the list of item details with reference of one transaction id is stored in data table
            If dt.Rows.Count > 0 Then
                Using cmd1 As New SqlCommand("Update tblInventory  Set StockOut = (Select SUM(UnitSold) as sold from tblStockOut where ItemDetailsID=@idetailsOne Group by ItemDetailsID) where ItemDetailsID=@idetailsTwo;", db.pubSqlCon)
                    For Each rowvalue As DataRow In dt.Rows
                        cmd1.Parameters.Clear()
                        cmd1.Parameters.AddWithValue("@idetailsOne", rowvalue("itemdetailsid").ToString())
                        cmd1.Parameters.AddWithValue("@idetailsTwo", rowvalue("itemdetailsid").ToString())
                        cmd1.ExecuteNonQuery()
                    Next
                    cmd1.Dispose()
                End Using
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
        End Using
    End Sub
    'Update StockStatus
    Public Sub updateStockStatus()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        'Subtract two columns to get the remaining value of an item
        Using cmd As New SqlCommand("Update tblInventory Set Remaining = Stockin - StockOut;", db.pubSqlCon)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            'Check if value of column is 0 or less 0, if true, update status to sold out
            Using cmd1 As New SqlCommand("Update tblInventory Set Status = 'Sold Out' where Remaining <= 0;", db.pubSqlCon)
                cmd1.ExecuteNonQuery()
                cmd1.Dispose()
            End Using
        End Using
        db.pubSqlCon.Close()
    End Sub
    'Clear the value of itemlist collection
    Public Sub clearItemList()
        order.Clear()
        order.TrimExcess()
        Dim ord As orderItems = New orderItems
        ord.clearOrderitemsProperty()
        totalQTY = Nothing
        totalAmount = Nothing
    End Sub
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
    'For Billing
    Private Sub PD_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PD.BeginPrint
        For i As Integer = 0 To localDatatable.Rows.Count - 1
            documentLenght += 30
        Next
        'Local
        Dim pageSetup As New PageSettings
        pageSetup.PaperSize = New PaperSize("Custom", 280, documentLenght)
        PD.DefaultPageSettings = pageSetup
    End Sub
    '
    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim det As Date = localDatatable.Rows(0).Item("DATE")
        Dim tym As String = localDatatable.Rows(0).Item("TIME").ToString()
        'Font formats
        Dim f8 As New Font("Courier New", 8, FontStyle.Regular)
        'Page margin
        Dim leftMargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centerMargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightMargin As Integer = PD.DefaultPageSettings.PaperSize.Width
        'Font alignment
        Dim rightAlign As New StringFormat
        Dim centerAlign As New StringFormat
        Dim leftAlign As New StringFormat
        rightAlign.Alignment = StringAlignment.Far
        centerAlign.Alignment = StringAlignment.Center
        leftAlign.Alignment = StringAlignment.Near
        'call System.Drawing.Printing.PrintEventsArgs
        Dim line1 As String = "----------------------------------------"
        e.Graphics.DrawString("Saint Franciss of Assissi", f8, Brushes.Black, centerMargin, 20, centerAlign)
        e.Graphics.DrawString("Mabuhay Clinic", f8, Brushes.Black, centerMargin, 30, centerAlign)
        e.Graphics.DrawString("Brgy. Bugko", f8, Brushes.Black, centerMargin, 40, centerAlign)
        e.Graphics.DrawString(" Mondragon Northern Samar", f8, Brushes.Black, centerMargin, 50, centerAlign)
        e.Graphics.DrawString("Billing Details:", f8, Brushes.Black, 0, 80, leftAlign)
        e.Graphics.DrawString("Date: " & det.ToShortDateString(), f8, Brushes.Black, 0, 90, leftAlign) '//Add here
        e.Graphics.DrawString("Time: " & tym, f8, Brushes.Black, rightMargin, 90, rightAlign) '//Add here
        e.Graphics.DrawString("Cashier: " & localDatatable.Rows(0).Item("COUNTER"), f8, Brushes.Black, 0, 100, leftAlign) '//Add here
        e.Graphics.DrawString("Customer Name: " & localDatatable.Rows(0).Item("CustomerName"), f8, Brushes.Black, 0, 110, leftAlign) '//Add here
        e.Graphics.DrawString("Payment ID: " & localDatatable.Rows(0).Item("PaymentID"), f8, Brushes.Black, 0, 120, leftAlign) '//Add here
        e.Graphics.DrawString("Transaction ID: " & localDatatable.Rows(0).Item("TransactionID"), f8, Brushes.Black, 0, 130, leftAlign) '//Add here
        e.Graphics.DrawString(line1, f8, Brushes.Black, 0, 140, leftAlign)
        e.Graphics.DrawString("QTY", f8, Brushes.Black, 0, 150, leftAlign)
        e.Graphics.DrawString("ITEM NAME", f8, Brushes.Black, 40, 150, leftAlign)
        e.Graphics.DrawString("PRICE", f8, Brushes.Black, 210, 150, rightAlign)
        e.Graphics.DrawString("SUBTOTAL", f8, Brushes.Black, rightMargin, 150, rightAlign)
        e.Graphics.DrawString(line1, f8, Brushes.Black, 0, 160, leftAlign)
        '
        Dim spaceNum As Integer = 180
        Dim uomSpce As Integer = 170
        Dim nxtLine As Integer = 190
        For i As Integer = 0 To localDatatable.Rows.Count - 1
            e.Graphics.DrawString(localDatatable.Rows(i).Item("UOM"), f8, Brushes.Black, 40, uomSpce, leftAlign)

            e.Graphics.DrawString(localDatatable.Rows(i).Item("Qty"), f8, Brushes.Black, 0, spaceNum, leftAlign)
            e.Graphics.DrawString(localDatatable.Rows(i).Item("Itemname") & " " & localDatatable.Rows(i).Item("Type"), f8, Brushes.Black, 40, spaceNum, leftAlign)
            e.Graphics.DrawString(localDatatable.Rows(i).Item("Price"), f8, Brushes.Black, 210, spaceNum, rightAlign)
            e.Graphics.DrawString(localDatatable.Rows(i).Item("Subtotal"), f8, Brushes.Black, rightMargin, spaceNum, rightAlign)
            uomSpce += 20
            spaceNum += 20
            nxtLine += 15
        Next
        e.Graphics.DrawString(line1, f8, Brushes.Black, 0, nxtLine, leftAlign)
        e.Graphics.DrawString("Total Qty:" & totalItems.ToString(), f8, Brushes.Black, 0, nxtLine + 10, leftAlign)
        e.Graphics.DrawString("Payment Details:", f8, Brushes.Black, 0, nxtLine + 40, leftAlign)
        e.Graphics.DrawString("Amount Due: ", f8, Brushes.Black, 0, nxtLine + 50, leftAlign)
        e.Graphics.DrawString(localDatatable.Rows(0).Item("AmountDue"), f8, Brushes.Black, rightMargin, nxtLine + 50, rightAlign)
        e.Graphics.DrawString("Tendered: ", f8, Brushes.Black, 0, nxtLine + 60, leftAlign)
        e.Graphics.DrawString(localDatatable.Rows(0).Item("Tendered"), f8, Brushes.Black, rightMargin, nxtLine + 60, rightAlign)
        e.Graphics.DrawString("Change: ", f8, Brushes.Black, 0, nxtLine + 70, leftAlign)
        e.Graphics.DrawString(localDatatable.Rows(0).Item("change"), f8, Brushes.Black, rightMargin, nxtLine + 70, rightAlign)
        e.Graphics.DrawString("Thank you! Come again.", f8, Brushes.Black, centerMargin, nxtLine + 90, centerAlign)
    End Sub
    '
    Public Sub billing()
        getBillingInfo()
        PDD.Document = PD
        PDD.ShowDialog()
        'PD.Print()
        'Clear
        localDatatable.Rows.Clear()
        localDatatable.Dispose()
        Dim transactionNo As Integer = Nothing
        Dim paymentID As Integer = Nothing
        Dim totalItems As Integer = Nothing
        Dim documentLenght As Integer = 280
    End Sub
    '
    Public Sub getBillingInfo()
        Dim localPaymentID As Integer = Nothing
        Dim localTransactionID As Integer = Nothing
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        'get current transaction id
        Using da1 As New SqlDataAdapter("Select MAX(TransactionID) as tid from tblTransactions;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da1.Fill(dt)
            If dt.Rows.Count > 0 Then
                localTransactionID = dt.Rows(0).Item("tid")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da1.Dispose()
        End Using
        'get current PaymentID
        Using da2 As New SqlDataAdapter("Select Max(PaymentID) as pid from tblPayment;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da2.Fill(dt)
            If dt.Rows.Count > 0 Then
                localPaymentID = dt.Rows(0).Item("pid")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da2.Dispose()
        End Using
        'Count total Qty
        Using cmd1 As New SqlCommand("Select Sum(Qty) as total From tblOrderList Where PaymentID = @paymentid And TransactionID = @transactionid ;", db.pubSqlCon)
            cmd1.Parameters.Clear()
            cmd1.Parameters.AddWithValue("@paymentid", localPaymentID)
            cmd1.Parameters.AddWithValue("@transactionid", localTransactionID)
            Dim da3 As New SqlDataAdapter(cmd1)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da3.Fill(dt)
            If dt.Rows.Count > 0 Then
                totalItems = dt.Rows(0).Item("total")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da3.Dispose()
            cmd1.Dispose()
        End Using
        'Get Billing info
        Using cmd As New SqlCommand("Select tor.UOM,tor.Itemname,tor.Type,Sum(tor.Qty) as Qty, tor.Price, Sum (tor.Subtotal) as Subtotal, tt.TransactionID, tt.Date, tt.Time,tp.PaymentID, tp.AmountDue,tp.Tendered,tp.change,tp.Counter,tp.CustomerName from tblOrderList as tor " & _
" Join tblPayment as tp On tor.PaymentID = tp.PaymentID " & _
" Join tblTransactions as tt On tor.TransactionID = tt.TransactionID " & _
" Where tp.PaymentID = @paymentid And tt.TransactionID = @transactionid  " & _
" Group by tor.UOM,tor.Itemname,tor.Type, tor.Price, tt.TransactionID, tt.Date, tt.Time,tp.PaymentID, tp.AmountDue,tp.Tendered,tp.change,tp.Counter,tp.CustomerName;", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@paymentid", localPaymentID)
            cmd.Parameters.AddWithValue("@transactionid", localTransactionID)
            Dim da4 As New SqlDataAdapter(cmd)
            localDatatable.Rows.Clear()
            da4.Fill(localDatatable)
            db.pubSqlCon.Close()
            da4.Dispose()
            cmd.Dispose()
            localPaymentID = Nothing
            localTransactionID = Nothing
        End Using
    End Sub
End Class
'

