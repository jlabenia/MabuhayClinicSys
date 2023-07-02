Public Class ManagePharmacy
    '!COMMENT: BUTTONS
    'i. ITEMS
    Private Sub btnCustQueDashboard_Click(sender As Object, e As EventArgs) Handles btnCustQueDashboard.Click
        Me.Close()
        AdminDashboard.loadItems()
    End Sub
    'END!
    '**************************************************************************************
    '!COMMENT: EVENTS
    'i. Form closing
    Private Sub ManagePharmacy_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.returntoAdminDashboard()
    End Sub
    'END!

    Private Sub btnAddQue_Click(sender As Object, e As EventArgs) Handles btnAddQue.Click
        Me.Close()
        AdminDashboard.loadStockIn()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        AdminDashboard.loadSupplier()
    End Sub

    Private Sub btnManageQue_Click(sender As Object, e As EventArgs) Handles btnManageQue.Click
        Me.Close()
        AdminDashboard.loadItemDetails()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        AdminDashboard.loadInventory()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        AdminDashboard.loadTransactionAndPayment()
    End Sub
End Class