Imports System.Data.SqlClient
Public Class TransactionAndPayment

    '!COMMENT: PRIVATE VARIABLES
    Dim det As Date = CDate(Date.Now.ToShortDateString())
    Dim charlie1 As Integer = Nothing
    Dim charlie2 As Integer = Nothing
    'END!
    '******************************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        searchBetweenDates()
        totalsalesFromandTodate()
        totalTransactionsFromandTodate()
    End Sub
    'END!
    '******************************************************************************************
    '!COMMENT: EVENTS
    Private Sub TransactionAndPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadTransactionAndPaymentInfo()
        loadTotalSalesToday()
        loadTotalTransactionToday()
    End Sub
    '
    Private Sub TransactionAndPayment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.loadManagePharmacy()
    End Sub
    '
    Private Sub dgvPaymentsAndTransactions_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPaymentsAndTransactions.CellClick
        Try
            Dim romeo As Integer = Nothing
            charlie1 = Nothing
            If dgvPaymentsAndTransactions.RowCount > 0 Then
                romeo = dgvPaymentsAndTransactions.CurrentRow.Index
                charlie1 = dgvPaymentsAndTransactions.Item(0, romeo).Value
                charlie2 = dgvPaymentsAndTransactions.Item(1, romeo).Value
                OrderList.transactionid = charlie1
                OrderList.paymentid = charlie2
                Dim Answer As DialogResult = MessageBox.Show("Would you like to see the list of order using this transaction id?", "Confirmation...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If Answer = Windows.Forms.DialogResult.Yes Then
                    Me.Close()
                    AdminDashboard.loadOrderList()
                Else
                    OrderList.transactionid = Nothing
                    OrderList.paymentid = Nothing
                End If
            End If
        Catch
            charlie1 = Nothing
            charlie2 = Nothing
        End Try
    End Sub
    'END!
    '******************************************************************************************
    '!COMMENT: METHODS
    '
    Public Sub loadTransactionAndPaymentInfo()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select Distinct(tol.TransactionID),tol.PaymentID,tt.Date,tt.Time,tp.CustomerName,tp.Counter,tp.AmountDue,tp.Tendered,tp.Change from  tblOrderList as tol " & _
" Inner join tblTransactions as tt On tol.TransactionID=tt.TransactionID " & _
" Inner join tblPayment as tp On tol.PaymentID = tp.PaymentID " & _
" Where tt.Date =@det order by tt.Date ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPaymentsAndTransactions.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub loadTotalSalesToday()
        Dim result As String = Nothing
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select SUM(AmountDue)as sales from tblPayment as tp " & _
" Inner Join tblOrderList as tol On tp.PaymentID=tol.PaymentID " & _
" Inner Join tblTransactions as tt On tol.TransactionID=tt.TransactionID " & _
" Where tt.Date =@det group by tt.Date;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                result = dt.Rows(0).Item("sales").ToString()
                If String.IsNullOrEmpty(result) = True Then
                    txtTotalSales.Text = 0
                Else
                    txtTotalSales.Text = result
                End If
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub loadTotalTransactionToday()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select Count (tt.TransactionID) as total from tblTransactions as tt Where tt.Date =@det;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtTotalTransactions.Text = dt.Rows(0).Item("total").ToString()
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchBetweenDates()
        Dim dtp1 As Date = CDate(dtpExpFrom.Text)
        Dim dtp2 As Date = CDate(dtpExpTo.Text)
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select Distinct(tol.TransactionID),tol.PaymentID,tt.Date,tt.Time,tp.CustomerName,tp.Counter,tp.AmountDue,tp.Tendered,tp.Change from  tblOrderList as tol " & _
" Inner join tblTransactions as tt On tol.TransactionID=tt.TransactionID " & _
" Inner join tblPayment as tp On tol.PaymentID = tp.PaymentID " & _
" Where tt.Date between @det1 And @det2  order by tt.Date ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", dtp1)
            cmd.Parameters.AddWithValue("@det2", dtp2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPaymentsAndTransactions.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub totalsalesFromandTodate()
        Dim dtp1 As Date = CDate(dtpExpFrom.Text)
        Dim dtp2 As Date = CDate(dtpExpTo.Text)
        Dim result As String = Nothing
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select SUM(AmountDue)as sales from tblPayment as tp " & _
" Inner Join tblOrderList as tol On tp.PaymentID=tol.PaymentID " & _
" Inner Join tblTransactions as tt On tol.TransactionID=tt.TransactionID " & _
" Where tt.Date between @det1 And @det2;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", dtp1)
            cmd.Parameters.AddWithValue("@det2", dtp2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                result = dt.Rows(0).Item("sales").ToString()
                If String.IsNullOrEmpty(result) = True Then
                    txtTotalSales.Text = 0
                Else
                    txtTotalSales.Text = result
                End If
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub totalTransactionsFromandTodate()
        Dim dtp1 As Date = CDate(dtpExpFrom.Text)
        Dim dtp2 As Date = CDate(dtpExpTo.Text)
        Dim result As String = Nothing
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select Count (tt.TransactionID) as total from tblTransactions as tt Where tt.Date between @det1 And @det2;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", dtp1)
            cmd.Parameters.AddWithValue("@det2", dtp2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtTotalTransactions.Text = dt.Rows(0).Item("total").ToString()
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    'END!
    '******************************************************************************************
End Class