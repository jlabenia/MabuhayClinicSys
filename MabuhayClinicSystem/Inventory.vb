Imports System.Data.SqlClient
Public Class Inventory
    '!COMMENT: PRIVATE VARIABLES
    'END!
    '*******************************************************************************************************
    '!COMMENT: BUTTONS
    'i.
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        searchExpByDateRange()
    End Sub
    'END!
    '*******************************************************************************************************
    '!COMMENT: EVENTS
    'i.
    Private Sub Inventory_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadManagePharmacy()
    End Sub
    'ii.
    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadInventoryInfo()
    End Sub
    'iii.
    Private Sub txtSearchitemname_TextChanged(sender As Object, e As EventArgs) Handles txtSearchitemname.TextChanged
        txtSearchBarcode.Text = ""
        If rbtnAll.Checked = True Then
            searchbyItemnameAll()
        ElseIf rbtnAvailable.Checked = True Then
            searchbyItemnameAvailable()
        ElseIf rbtnSoldOut.Checked = True Then
            searchbyItemnameSoldout()
        End If
    End Sub
    'iv. 
    Private Sub txtSearchBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBarcode.TextChanged
        txtSearchitemname.Text = ""
        If rbtnAll.Checked = True Then
            searchBarcodeAll()
        ElseIf rbtnAvailable.Checked = True Then
            searchBarcodeAvailble()
        ElseIf rbtnSoldOut.Checked = True Then
            searchBarcodeSoldout()
        End If
    End Sub
    'v.
    Private Sub rbtnAll_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSoldOut.CheckedChanged, rbtnAvailable.CheckedChanged, rbtnAll.CheckedChanged
        txtSearchBarcode.Text = ""
        txtSearchitemname.Text = ""
        If rbtnAll.Checked = True Then
            loadInventoryInfo()
        ElseIf rbtnAvailable.Checked = True Then
            loadInventoryAvailable()
        ElseIf rbtnSoldOut.Checked = True Then
            loadInventorySoldOut()
        End If
    End Sub
    'END!
    '*******************************************************************************************************
    '!COMMENT: METHODS
    'i. Load inventory infp
    Public Sub loadInventoryInfo()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using da As New SqlDataAdapter("Select top 100 ti.StockOutID,ti.StockOutCode,ti.ItemDetailsID,tid.Barcode,tim.ItemName,tim.TypeofItem,ti.Stockin,ti.StockOut,ti.Remaining,ti.Status,tid.ExpirationDate from tblInventory as ti " & _
" Inner join tblItemDetails as tid On ti.ItemDetailsID = tid.ItemDetailsID " & _
" Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
" Inner join tblItems as tim On tsi.ItemID = tim.ItemID;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvInventory.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    'ii.
    Public Sub loadInventoryAvailable()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using da As New SqlDataAdapter("Select top 100 ti.StockOutID,ti.StockOutCode,ti.ItemDetailsID,tid.Barcode,tim.ItemName,tim.TypeofItem,ti.Stockin,ti.StockOut,ti.Remaining,ti.Status,tid.ExpirationDate from tblInventory as ti " & _
" Inner join tblItemDetails as tid On ti.ItemDetailsID = tid.ItemDetailsID " & _
" Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
" Inner join tblItems as tim On tsi.ItemID = tim.ItemID where ti.Status='Available' order by ti.StockOutID ASC ;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvInventory.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    'iii.
    Public Sub loadInventorySoldOut()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using da As New SqlDataAdapter("Select top 100 ti.StockOutID,ti.StockOutCode,ti.ItemDetailsID,tid.Barcode,tim.ItemName,tim.TypeofItem,ti.Stockin,ti.StockOut,ti.Remaining,ti.Status,tid.ExpirationDate from tblInventory as ti " & _
" Inner join tblItemDetails as tid On ti.ItemDetailsID = tid.ItemDetailsID " & _
" Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
" Inner join tblItems as tim On tsi.ItemID = tim.ItemID where ti.Status='Sold Out' order by ti.StockOutID ASC ;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvInventory.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    'iv.
    Public Sub searchbyItemnameAll()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select top 100 ti.StockOutID,ti.StockOutCode,ti.ItemDetailsID,tid.Barcode,tim.ItemName,tim.TypeofItem,ti.Stockin,ti.StockOut,ti.Remaining,ti.Status,tid.ExpirationDate from tblInventory as ti " & _
" Inner join tblItemDetails as tid On ti.ItemDetailsID = tid.ItemDetailsID " & _
" Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
" Inner join tblItems as tim On tsi.ItemID = tim.ItemID where tim.ItemName like '' +@itemname+ '%' order by tim.ItemName ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemname", txtSearchitemname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvInventory.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'v.
    Public Sub searchbyItemnameAvailable()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select top 100 ti.StockOutID,ti.StockOutCode,ti.ItemDetailsID,tid.Barcode,tim.ItemName,tim.TypeofItem,ti.Stockin,ti.StockOut,ti.Remaining,ti.Status,tid.ExpirationDate from tblInventory as ti " & _
" Inner join tblItemDetails as tid On ti.ItemDetailsID = tid.ItemDetailsID " & _
" Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
" Inner join tblItems as tim On tsi.ItemID = tim.ItemID where tim.ItemName like '' +@itemname+ '%' And ti.Status= 'Available' order by tim.ItemName ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemname", txtSearchitemname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvInventory.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'vi.
    Public Sub searchbyItemnameSoldout()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select top 100 ti.StockOutID,ti.StockOutCode,ti.ItemDetailsID,tid.Barcode,tim.ItemName,tim.TypeofItem,ti.Stockin,ti.StockOut,ti.Remaining,ti.Status,tid.ExpirationDate from tblInventory as ti " & _
" Inner join tblItemDetails as tid On ti.ItemDetailsID = tid.ItemDetailsID " & _
" Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
" Inner join tblItems as tim On tsi.ItemID = tim.ItemID where tim.ItemName like '' +@itemname+ '%' And ti.Status='Sold out' order by tim.ItemName ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemname", txtSearchitemname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvInventory.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'v.
    Public Sub searchBarcodeAll()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select top 100 ti.StockOutID,ti.StockOutCode,ti.ItemDetailsID,tid.Barcode,tim.ItemName,tim.TypeofItem,ti.Stockin,ti.StockOut,ti.Remaining,ti.Status,tid.ExpirationDate from tblInventory as ti " & _
" Inner join tblItemDetails as tid On ti.ItemDetailsID = tid.ItemDetailsID " & _
" Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
" Inner join tblItems as tim On tsi.ItemID = tim.ItemID where tid.Barcode like '' +@barcode+ '%' order by tid.Barcode ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@barcode", txtSearchBarcode.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvInventory.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'vi.
    Public Sub searchBarcodeAvailble()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select top 100 ti.StockOutID,ti.StockOutCode,ti.ItemDetailsID,tid.Barcode,tim.ItemName,tim.TypeofItem,ti.Stockin,ti.StockOut,ti.Remaining,ti.Status,tid.ExpirationDate from tblInventory as ti " & _
" Inner join tblItemDetails as tid On ti.ItemDetailsID = tid.ItemDetailsID " & _
" Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
" Inner join tblItems as tim On tsi.ItemID = tim.ItemID where tid.Barcode like '' +@barcode+ '%' And ti.Status= 'Available'  order by tid.Barcode ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@barcode", txtSearchBarcode.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvInventory.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'vii.
    Public Sub searchBarcodeSoldout()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select top 100 ti.StockOutID,ti.StockOutCode,ti.ItemDetailsID,tid.Barcode,tim.ItemName,tim.TypeofItem,ti.Stockin,ti.StockOut,ti.Remaining,ti.Status,tid.ExpirationDate from tblInventory as ti " & _
" Inner join tblItemDetails as tid On ti.ItemDetailsID = tid.ItemDetailsID " & _
" Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
" Inner join tblItems as tim On tsi.ItemID = tim.ItemID where tid.Barcode like '' +@barcode+ '%' And ti.Status= 'Sold Out'  order by tid.Barcode ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@barcode", txtSearchBarcode.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvInventory.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'viii.
    Public Sub searchExpByDateRange()
        Dim dtp1 As Date = dtpExpFrom.Value
        Dim dtp2 As Date = dtpExpTo.Value
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select top 100 ti.StockOutID,ti.StockOutCode,ti.ItemDetailsID,tid.Barcode,tim.ItemName,tim.TypeofItem,ti.Stockin,ti.StockOut,ti.Remaining,ti.Status,tid.ExpirationDate from tblInventory as ti " & _
" Inner join tblItemDetails as tid On ti.ItemDetailsID = tid.ItemDetailsID " & _
" Inner join tblStockIn as tsi On tid.StockInID = tsi.StockInID " & _
" Inner join tblItems as tim On tsi.ItemID = tim.ItemID where tid.ExpirationDate>=@det1 And tid.ExpirationDate <=@det2 And ti.Status= 'Available'  order by tid.ExpirationDate DESC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", dtp1)
            cmd.Parameters.AddWithValue("@det2", dtp2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvInventory.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'END!
End Class