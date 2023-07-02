Imports System.Data.SqlClient
Public Class AdminDashboard
    '!COMMENT:  PRIVATE 
    'END!
    '**************************************************************************************
    '!COMMENT: BUTTONS
    'i. MANAGE PHARMACY
    Private Sub btnMPharmacy_Click(sender As Object, e As EventArgs) Handles btnMPharmacy.Click
        loadManagePharmacy()
    End Sub
    '
    Private Sub btnMClinic_Click(sender As Object, e As EventArgs) Handles btnMClinic.Click
        loadManageClinic()
    End Sub
    '
    Private Sub btnMUsers_Click(sender As Object, e As EventArgs) Handles btnMUsers.Click
        manageUsers()
    End Sub
    '
    Private Sub btnLoghistory_Click(sender As Object, e As EventArgs) Handles btnLoghistory.Click
        loadLogHistory()
    End Sub
    '
    Private Sub btnUserActivity_Click(sender As Object, e As EventArgs) Handles btnUserActivity.Click
        loadUserActivity()
    End Sub
    'END!
    '**************************************************************************************
    '!COMMENT: EVENTS
    'i. Form load
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadIntoDashboard()
    End Sub
    'ii. Form closing
    Private Sub AdminDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        logOut()
        reset_Adminvariables()
        reset_login_variables()
        LoginForm.Show()
        backtoLoginfrm()
    End Sub
    'ii. Timer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTime.Text = Date.Now.ToLongTimeString
    End Sub
    'END!
    '**************************************************************************************
    '!COMMENT: METHODS
    'i. Load into Dashboard
    Public Sub loadIntoDashboard()
        lblDate.Text = Date.Now.ToLongDateString
        Timer1.Start()
        lblAdminName.Text = adminfirstname + " " + adminMiddlename + " " + adminLastname
        lblAdminUser.Text = loginUserType
    End Sub '//green code
    'ii. back to login form
    Public Sub backtoLoginfrm()
        My.Settings.rememberMe = True
        My.Settings.Reload()
        LoginForm.txtPass.Text = My.Settings.password
        LoginForm.txtUname.Text = My.Settings.username
        LoginForm.cboxView.Checked = True
        If LoginForm.txtUname.Text = "" And LoginForm.txtPass.Text = "" Then
            LoginForm.lfClear()
        End If
    End Sub
    'iii. Return to admin dashboard
    Public Sub returntoAdminDashboard()
        btnMPharmacy.Enabled = True
        btnMClinic.Enabled = True
        btnMUsers.Enabled = True
        btnLoghistory.Enabled = True
        btnUserActivity.Enabled = True
        btnReports.Enabled = True
    End Sub
    '
    'END!
    '!COMMENT: METHODS EXTENSION
    'i. Load Manage Pharmacy
    Public Sub loadManagePharmacy()
        Me.IsMdiContainer = True
        ManagePharmacy.MdiParent = Me
        ManagePharmacy.Show()
        btnMPharmacy.Enabled = True
        btnMClinic.Enabled = False
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    'a. 
    Public Sub loadItems()
        Me.IsMdiContainer = True
        Items.MdiParent = Me
        Items.Show()
        btnMPharmacy.Enabled = True
        btnMClinic.Enabled = False
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub loadStockIn()
        Me.IsMdiContainer = True
        Stocks.MdiParent = Me
        Stocks.Show()
        btnMPharmacy.Enabled = True
        btnMClinic.Enabled = False
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub loadSupplier()
        Me.IsMdiContainer = True
        Supplier.MdiParent = Me
        Supplier.Show()
        btnMPharmacy.Enabled = True
        btnMClinic.Enabled = False
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub loadItemDetails()
        Me.IsMdiContainer = True
        ItemDetails.MdiParent = Me
        ItemDetails.Show()
        btnMPharmacy.Enabled = True
        btnMClinic.Enabled = False
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub loadInventory()
        Me.IsMdiContainer = True
        Inventory.MdiParent = Me
        Inventory.Show()
        btnMPharmacy.Enabled = True
        btnMClinic.Enabled = False
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub loadTransactionAndPayment()
        Me.IsMdiContainer = True
        TransactionAndPayment.MdiParent = Me
        TransactionAndPayment.Show()
        btnMPharmacy.Enabled = True
        btnMClinic.Enabled = False
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub loadOrderList()
        Me.IsMdiContainer = True
        OrderList.MdiParent = Me
        OrderList.Show()
        btnMPharmacy.Enabled = True
        btnMClinic.Enabled = False
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    'ii. Load Clinic
    Public Sub loadManageClinic()
        Me.IsMdiContainer = True
        ManageClinic.MdiParent = Me
        ManageClinic.Show()
        btnMPharmacy.Enabled = False
        btnMClinic.Enabled = True
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub load_AdminQue()
        Me.IsMdiContainer = True
        AdminQue.MdiParent = Me
        AdminQue.Show()
        btnMPharmacy.Enabled = False
        btnMClinic.Enabled = True
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub load_AdminAppointment()
        Me.IsMdiContainer = True
        AdminAppointment.MdiParent = Me
        AdminAppointment.Show()
        btnMPharmacy.Enabled = False
        btnMClinic.Enabled = True
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub load_ClinincPersonnel()
        Me.IsMdiContainer = True
        AdminClinicPersonnelInfo.MdiParent = Me
        AdminClinicPersonnelInfo.Show()
        btnMPharmacy.Enabled = False
        btnMClinic.Enabled = True
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub load_DoctorInfo()
        Me.IsMdiContainer = True
        AdminDoctoriInfo.MdiParent = Me
        AdminDoctoriInfo.Show()
        btnMPharmacy.Enabled = False
        btnMClinic.Enabled = True
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub load_PatientInfo()
        Me.IsMdiContainer = True
        AdminPatientRecords.MdiParent = Me
        AdminPatientRecords.Show()
        btnMPharmacy.Enabled = False
        btnMClinic.Enabled = True
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    '
    Public Sub load_ViewPatient()
        Me.IsMdiContainer = True
        ViewPatients.MdiParent = Me
        ViewPatients.Show()
        btnMPharmacy.Enabled = False
        btnMClinic.Enabled = True
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    'iii. Manage Users
    Public Sub manageUsers()
        Me.IsMdiContainer = True
        AdminUserAccount.MdiParent = Me
        AdminUserAccount.Show()
        btnMPharmacy.Enabled = False
        btnMClinic.Enabled = False
        btnMUsers.Enabled = True
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    'iv. Log history
    Public Sub loadLogHistory()
        Me.IsMdiContainer = True
        LogHistory.MdiParent = Me
        LogHistory.Show()
        btnMPharmacy.Enabled = False
        btnMClinic.Enabled = False
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = True
        btnUserActivity.Enabled = False
        btnReports.Enabled = False
    End Sub
    'v. User Activity
    Public Sub loadUserActivity()
        Me.IsMdiContainer = True
        UserActivity.MdiParent = Me
        UserActivity.Show()
        btnMPharmacy.Enabled = False
        btnMClinic.Enabled = False
        btnMUsers.Enabled = False
        btnLoghistory.Enabled = False
        btnUserActivity.Enabled = True
        btnReports.Enabled = False
    End Sub
    'vi. Log Out
    Public Sub logOut()
        ''Capture logout
        'Dim det As Date = CDate(Date.Now.ToShortDateString())
        'Dim taym As TimeSpan = Date.Now.TimeOfDay
        'Dim db As New KonekDB
        'db.FETCHDBINFO()
        'Using cmd = New SqlCommand("Update tblLogHistory Set LOGOUT_TIME =@logout_time,LOGOUT_DATE=@logout_date Where UserID=@userid And LogNo=@logno ;", db.pubSqlCon)
        '    cmd.Parameters.Clear()
        '    cmd.Parameters.AddWithValue("@logout_time", taym)
        '    cmd.Parameters.AddWithValue("@logout_date", det)
        '    '
        '    cmd.Parameters.AddWithValue("@userid", loginUserid)
        '    cmd.Parameters.AddWithValue("@logno ", logNo)
        '    cmd.ExecuteNonQuery()
        '    db.pubSqlCon.Close()
        '    cmd.Dispose()
        'End Using
    End Sub '//green code

    'END!
End Class