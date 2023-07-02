Imports System.Data.SqlClient
Public Class PaymentFrm
    '!COMMENT: VARIABLES
    Dim pfamountDue As Decimal = Nothing
    Dim pfcustomerName As String = Nothing
    'END!
    '**********************************************************************************
    '!COMMENT: BUTTON
    'i.ENTER
    Private Sub pfbtnEnter_Click(sender As Object, e As EventArgs) Handles pfbtnEnter.Click
        'Add record of Payment and transactions
        If pfcheckbxAmnt.CheckState = CheckState.Checked Then
            If pftxtTendered.Text <> "" Then
                UserClickEnter() 'user activity
                insertPaymentandTransactions()
                pfclear()
                PharmacyFrm.saveOrderList()
                PharmacyFrm.updateSqltblUnitOut()
                PharmacyFrm.updateInventory()
                PharmacyFrm.updateStockStatus()
                glblorderItemVarreset()
                PharmacyFrm.clearItemList()
                PharmacyFrm.DGVSearchBrcdItem.DataSource = Nothing
                PharmacyFrm.billing()
                Me.Close()
            End If
        ElseIf pfcheckbxAmnt.CheckState = CheckState.Unchecked Then
            If pftxtTendered.Text <> "" Then
                UserClickEnter() 'user activity
                insertPaymentandTransactions()
                pfclear()
                PharmacyFrm.saveOrderList()
                PharmacyFrm.updateSqltblUnitOut()
                PharmacyFrm.updateInventory()
                PharmacyFrm.updateStockStatus()
                glblorderItemVarreset()
                PharmacyFrm.clearItemList()
                PharmacyFrm.DGVSearchBrcdItem.DataSource = Nothing
                PharmacyFrm.billing()
                Me.Close()
            End If
        End If
    End Sub
    'END!
    '**********************************************************************************
    '!COMMENT: EVENTS
    'i. Form loading
    Private Sub PaymentFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim intrfce As String = "Payment form"
        Dim btn As String = "N/A"
        Dim actn As String = "Open"
        UserActivity(intrfce, btn, actn)
        '
        AcceptButton = pfbtnEnter
        pfamountDue = Val(amountDue)
        pfcustomerName = customerName
        '
        pflblAmountDue.Text = pfamountDue.ToString("0.00")
        '
        amountDue = 0
        amountDue = Nothing
        customerName = Nothing
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'ii. Text Change
    Private Sub pftxtTendered_TextChanged(sender As Object, e As EventArgs) Handles pftxtTendered.TextChanged
        If pfcheckbxAmnt.CheckState = CheckState.Unchecked Then
            Dim result As Decimal = CDec(Val(pftxtTendered.Text) - Val(pflblAmountDue.Text))
            pflblChange.Text = result.ToString("0.00")
        End If
    End Sub
    'iii. Checked change
    Private Sub pfcheckbxExactChnge_CheckedChanged(sender As Object, e As EventArgs) Handles pfcheckbxAmnt.CheckedChanged
        If pfcheckbxAmnt.CheckState = CheckState.Checked Then
            pftxtTendered.Text = ""
            pftxtTendered.Text = pflblAmountDue.Text
            pflblChange.Text = "0.00"
        Else
            pftxtTendered.Text = ""
            pflblChange.Text = "0.00"
        End If
    End Sub
    'iv. Allow numbers inout only
    Private Sub IsNumber(sender As Object, e As KeyPressEventArgs) Handles pftxtTendered.KeyPress
        If Char.IsDigit(e.KeyChar) = False And e.KeyChar <> vbBack And e.KeyChar <> "." Then
            e.Handled = True
        End If
        If e.KeyChar = "." And CType(sender, TextBox).Text.IndexOf(".") > -1 Then
            e.Handled = True
        End If
    End Sub
    'END!
    '**********************************************************************************
    '!COMMENT: METHODS
    'i. Insert new record ofPayments and transactions
    Public Sub insertPaymentandTransactions()
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        Dim tym As TimeSpan = Date.Now.TimeOfDay
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        'Insert payment
        Using cmd As New SqlCommand("Insert into tblPayment (CustomerName,Counter,AmountDue,Tendered,change) values (@customername,@counter,@amountdue,@tendered,@change);", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@customername", System.Data.SqlDbType.VarChar).Value = pfcustomerName
            cmd.Parameters.Add("@counter", System.Data.SqlDbType.VarChar).Value = cp_fname & " " & cp_mname & " " & cp_lname
            cmd.Parameters.Add("@amountdue", System.Data.SqlDbType.Decimal).Value = CDec(pflblAmountDue.Text)
            cmd.Parameters.Add("@tendered", System.Data.SqlDbType.Decimal).Value = CDec(pftxtTendered.Text)
            cmd.Parameters.Add("@change", System.Data.SqlDbType.Decimal).Value = CDec(pflblChange.Text)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Paid!")
        End Using
        'Insert transactions
        Using cmd1 As New SqlCommand("Insert into tblTransactions (Date,Time) values (@date,@time);", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd1.Parameters.Clear()
            cmd1.Parameters.Add("@date", System.Data.SqlDbType.Date).Value = det
            cmd1.Parameters.Add("@time", System.Data.SqlDbType.Time).Value = tym
            cmd1.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd1.Dispose()
        End Using
    End Sub
    'iii. Clear fields
    Public Sub pfclear()
        pftxtTendered.Text = ""
        pflblAmountDue.Text = "0.00"
        pflblChange.Text = "0.00"
        pfcheckbxAmnt.CheckState = CheckState.Unchecked
    End Sub
    'iv.
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
    'v. Capture user activity
    Public Sub UserClickEnter()
        'Capture user activity
        Dim intrfce As String = "Payment form"
        Dim btn As String = "Enter"
        Dim actn As String = "Ordered item(s) paid amounting to " & pflblAmountDue.Text & "."
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!

End Class