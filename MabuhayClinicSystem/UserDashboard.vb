Imports System.Data.SqlClient
Public Class UserDashboard
    '!COMMENT: PRIVATE VARIABLES
    'END!
    '!COMMENT: BUTTON
    'i. QUEUE
    Private Sub udbtnQueue_Click(sender As Object, e As EventArgs) Handles udbtnQueue.Click
        captureUAbtnQue()
        enterQuefrms()
    End Sub
    'ii.APPOINMENT
    Private Sub udbtnAppointment_Click(sender As Object, e As EventArgs) Handles udbtnAppointment.Click
        captureUAappointment()
        enterAppointment()
    End Sub
    'iii.PATIENT RECORD
    Private Sub udbtnPatientRcrd_Click(sender As Object, e As EventArgs) Handles udbtnPatientRcrd.Click
        captureUApatientRcrd()
        enterPatientRecord()
    End Sub
    'iv. VITAL SIGNS
    Private Sub udbtnVitalSign_Click(sender As Object, e As EventArgs) Handles udbtnVitalSign.Click
        captureUAvitalsigns()
        enterVitalsign()
    End Sub
    'v. TEST 
    Private Sub udbtnlbtests_Click(sender As Object, e As EventArgs) Handles udbtnlbtests.Click
        captureUAtest()
        enterLabRadResults()
    End Sub
    'vi. PROFILE
    Private Sub udbtnProfile_Click(sender As Object, e As EventArgs) Handles udbtnProfile.Click
        captureUAprofile()
        enterProfile()
    End Sub
    'vii. PHAMACY
    Private Sub udbtnPharmacy_Click(sender As Object, e As EventArgs) Handles udbtnPharmacy.Click
        captureUApharmacy()
        enterPharmacy()
    End Sub
    'END BUTTON!
    '*************************************************************************************************
    '!COMMENT: EVENTS
    Private Sub UserDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        udTimer1.Start()
        udlblDate.Text = Date.Now.ToLongDateString.ToString
        udlblCategory.Text = loginUserType
        udlblFname.Text = cp_fname & " " & cp_mname & " " & cp_lname
        captureUAloadfrm()
    End Sub '//green code
    '
    Private Sub UserDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        logOut()
        reset_login_variables()
        reset_cp_variables()
        LoginForm.Show()
        backtoLoginfrm()
    End Sub '//green code
    '
    Private Sub udTimer1_Tick(sender As Object, e As EventArgs) Handles udTimer1.Tick
        udlblTime.Text = Date.Now.ToLongTimeString.ToString
    End Sub '//green code
    'END EVENTS!
    '*************************************************************************************************
    '!COMMENT: METHODS
    'i. Back to login form
    Public Sub backtoLoginfrm()
        My.Settings.rememberMe = True
        My.Settings.Reload()
        LoginForm.txtPass.Text = My.Settings.password
        LoginForm.txtUname.Text = My.Settings.username
        LoginForm.cboxView.Checked = True
        If LoginForm.txtUname.Text = "" And LoginForm.txtPass.Text = "" Then
            LoginForm.lfClear()
        End If
    End Sub '//green code
    'ii. Back to user dashboard
    Public Sub returntoUserDashboard()
        udbtnQueue.Enabled = True
        udbtnAppointment.Enabled = True
        udbtnPatientRcrd.Enabled = True
        udbtnVitalSign.Enabled = True
        udbtnlbtests.Enabled = True
        udbtnProfile.Enabled = True
        udbtnPharmacy.Enabled = True
    End Sub
    'iii. Queue form (enter)
    Public Sub enterQuefrms()
        Me.IsMdiContainer = True
        Queuefrms.MdiParent = Me
        Queuefrms.Show()
        udbtnAppointment.Enabled = False
        udbtnPatientRcrd.Enabled = False
        udbtnVitalSign.Enabled = False
        udbtnlbtests.Enabled = False
        udbtnProfile.Enabled = False
        udbtnPharmacy.Enabled = False
    End Sub
    'iv. Appoitnment(enter)
    Public Sub enterAppointment()
        Me.IsMdiContainer = True
        ViewAppointment.MdiParent = Me
        ViewAppointment.Show()
        udbtnQueue.Enabled = False
        udbtnPatientRcrd.Enabled = False
        udbtnlbtests.Enabled = False
        udbtnProfile.Enabled = False
        udbtnPharmacy.Enabled = False
        udbtnVitalSign.Enabled = False
        udbtnlbtests.Enabled = False
    End Sub
    'v. Patient record (enter)
    Public Sub enterPatientRecord()
        Me.IsMdiContainer = True
        AddPatientRecord.MdiParent = Me
        AddPatientRecord.Show()
        udbtnQueue.Enabled = False
        udbtnAppointment.Enabled = False
        udbtnVitalSign.Enabled = False
        udbtnlbtests.Enabled = False
        udbtnPharmacy.Enabled = False
        udbtnVitalSign.Enabled = False
        udbtnProfile.Enabled = False
    End Sub
    'vi. Vital signs (enter)
    Public Sub enterVitalsign()
        Me.IsMdiContainer = True
        VitalSigns.MdiParent = Me
        VitalSigns.Show()
        udbtnPatientRcrd.Enabled = False
        udbtnQueue.Enabled = False
        udbtnAppointment.Enabled = False
        udbtnlbtests.Enabled = False
        udbtnPharmacy.Enabled = False
        udbtnlbtests.Enabled = False
        udbtnProfile.Enabled = False
    End Sub
    ' Lab and Rad results
    Public Sub enterLabRadResults()
        Me.IsMdiContainer = True
        labandradtests.MdiParent = Me
        labandradtests.Show()
        udbtnPatientRcrd.Enabled = False
        udbtnQueue.Enabled = False
        udbtnAppointment.Enabled = False
        udbtnVitalSign.Enabled = False
        udbtnlbtests.Enabled = True
        udbtnPharmacy.Enabled = False
        udbtnlbtests.Enabled = False
        udbtnProfile.Enabled = False
    End Sub
    'vii. Profile (enter)
    Public Sub enterProfile()
        Me.IsMdiContainer = True
        ProfileFrm.MdiParent = Me
        ProfileFrm.Show()
        udbtnProfile.Enabled = True
        udbtnVitalSign.Enabled = False
        udbtnPatientRcrd.Enabled = False
        udbtnQueue.Enabled = False
        udbtnAppointment.Enabled = False
        udbtnlbtests.Enabled = False
        udbtnPharmacy.Enabled = False
        udbtnlbtests.Enabled = False
    End Sub
    'viii. Pharmacy
    Public Sub enterPharmacy()
        Me.IsMdiContainer = True
        PharmacyFrm.MdiParent = Me
        PharmacyFrm.Show()
        udbtnProfile.Enabled = False
        udbtnVitalSign.Enabled = False
        udbtnPatientRcrd.Enabled = False
        udbtnQueue.Enabled = False
        udbtnAppointment.Enabled = False
        udbtnlbtests.Enabled = False
        udbtnPharmacy.Enabled = True
        udbtnlbtests.Enabled = False
    End Sub
    'ix. 
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
    'END!
    '************************************************************************************************
    '!COMMENT:USER ACTIVITY METHODS
    'i. btnQue
    Public Sub captureUAbtnQue()
        Dim intrfce As String = "User Dashboard"
        Dim btn As String = "Queue"
        Dim actn As String = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'ii. btnAppointment
    Public Sub captureUAappointment()
        Dim intrfce As String = "User Dashboard"
        Dim btn As String = "Appointment"
        Dim actn As String = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'iii. btnPatieRcd
    Public Sub captureUApatientRcrd()
        Dim intrfce As String = "User Dashboard"
        Dim btn As String = "Patient record"
        Dim actn As String = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'iv. btnVitalSigns
    Public Sub captureUAvitalsigns()
        Dim intrfce As String = "User Dashboard"
        Dim btn As String = "Vital Signs"
        Dim actn As String = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'v. btnLabRadTest
    Public Sub captureUAtest()
        Dim intrfce As String = "User Dashboard"
        Dim btn As String = "Test results"
        Dim actn As String = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'vi. btnProfile
    Public Sub captureUAprofile()
        Dim intrfce As String = "User Dashboard"
        Dim btn As String = "Profile"
        Dim actn As String = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'vii. btnPharmacy
    Public Sub captureUApharmacy()
        Dim intrfce As String = "User Dashboard"
        Dim btn As String = "Pharmacy"
        Dim actn As String = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAloadfrm()
        Dim intrfce As String = "User Dashboard"
        Dim btn As String = "N/A"
        Dim actn As String = "Open"
        'Capture user activity
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!
End Class