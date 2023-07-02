Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class OrderList
    '!COMMENT: PUBLIC VARIABLES
    Public transactionid As Integer = Nothing
    Public paymentid As Integer = Nothing
    'PRIVATE
    Dim totalItems As Integer = Nothing
    Dim documentLenght As Integer = 280 'see beginprint
    '
    Dim WithEvents PD As New PrintDocument
    Dim PDD As New PrintPreviewDialog
    '
    Dim localDatatable As New DataTable 'refer to getBilling Info
    'END!
    '*****************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        billing()
    End Sub
    'END!
    '*****************************************************************************
    '!COMMENT: EVENTS
    Private Sub OrderList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTransactionID.Text = transactionid
        txtPaymentID.Text = paymentid
        transactionid = Nothing
        paymentid = Nothing
        '
        customerOrderedList()
        totalOrders()
        loadCustomerPaymentInfo()
    End Sub
    '
    Private Sub OrderList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadTransactionAndPayment()
    End Sub
    'END!
    '*****************************************************************************
    '!COMMENT: METHODS
    Public Sub customerOrderedList()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select TransactionID, OrderListID,_Barcode,Itemname,UOM,Type,QTY,Price,Subtotal,PaymentID from tblOrderList " & _
" Where TransactionID = @transactionid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@transactionid", txtTransactionID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvOrderList.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub totalOrders()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select Count(OrderListID) as total from tblOrderList where TransactionID = @transactionid group by PaymentID;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@transactionid", txtTransactionID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtTotalOrders.Text = dt.Rows(0).Item("total")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub loadCustomerPaymentInfo()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select CustomerName,AmountDue,Tendered,Change from  tblPayment Where PaymentID = @paymentid; ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@paymentid", txtPaymentID.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtAmountDue.Text = dt.Rows(0).Item("AmountDue")
                txtTendered.Text = dt.Rows(0).Item("Tendered")
                txtChange.Text = dt.Rows(0).Item("Change")
                txtCustomerName.Text = dt.Rows(0).Item("CustomerName")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using

    End Sub
    '
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
        totalItems = Nothing
        documentLenght = 280
    End Sub
    '
    Public Sub getBillingInfo()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        'Count total Qty
        Using cmd1 As New SqlCommand("Select Sum(Qty) as total From tblOrderList Where PaymentID = @paymentid And TransactionID = @transactionid ;", db.pubSqlCon)
            cmd1.Parameters.Clear()
            cmd1.Parameters.AddWithValue("@paymentid", txtPaymentID.Text)
            cmd1.Parameters.AddWithValue("@transactionid", txtTransactionID.Text)
            Dim da As New SqlDataAdapter(cmd1)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                totalItems = dt.Rows(0).Item("total")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
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
            cmd.Parameters.AddWithValue("@paymentid", txtPaymentID.Text)
            cmd.Parameters.AddWithValue("@transactionid", txtTransactionID.Text)
            Dim da4 As New SqlDataAdapter(cmd)
            localDatatable.Rows.Clear()
            da4.Fill(localDatatable)
            db.pubSqlCon.Close()
            da4.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'END!
    '*****************************************************************************
End Class