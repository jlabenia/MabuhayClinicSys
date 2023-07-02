Imports System.Data.SqlClient
Public Class DoctorDashboard
    '!COMMENT: Public variables
    Dim intrfce As String = Nothing
    Dim btn As String = Nothing
    Dim actn As String = Nothing
    'END!
    '****************************************************************************************
    '!COMMENT: BUTTON
    'i. CONSULTATION
    Private Sub btnConsultation_Click(sender As Object, e As EventArgs) Handles btnConsultation.Click
        captureUAConsultation()
        loadAddConsultation()
    End Sub
    'ii. DIAGNOSIS
    Private Sub btnDiagnosis_Click(sender As Object, e As EventArgs) Handles btnDiagnosis.Click
        captureUADiagnosis()
        loadAddDiagnosis()
    End Sub
    'iii. APPOINTMENT
    Private Sub btnAppointment_Click(sender As Object, e As EventArgs) Handles btnAppointment.Click
        captureUAaddAppoinmnt()
        loadAddappointment()
    End Sub
    'iv. LAB AND RAD RESULT
    Private Sub btnLabAndRadrslt_Click(sender As Object, e As EventArgs) Handles btnLabAndRadrslt.Click
        captureUAtestResult()
        loadlabandradResult()
    End Sub
    'v. SURGERY
    Private Sub btnSurgery_Click(sender As Object, e As EventArgs) Handles btnSurgery.Click
        captureUASurgery()
        loadAddsurgery()
    End Sub
    'vi. PROFILE
    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        captureUAprofile()
        loadDoctorProfile()
    End Sub
    'vii. PRESCRIPTION
    Private Sub btnPrescription_Click(sender As Object, e As EventArgs) Handles btnPrescription.Click
        captureUAPrescription()
        loadPrescription()
    End Sub
    'END!
    '****************************************************************************************
    '!COMMENT: EVENTS
    'i. Timer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        dctrlblTime.Text = Date.Now.ToLongTimeString
    End Sub '//green code
    'ii. Load
    Private Sub DoctorDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureUAloadfrm()
        loadIntoDashboard()
    End Sub '//green code
    'iii. Form closing
    Private Sub DoctorDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        logOut()
        reset_login_variables()
        reset_doctor_variables()
        clearDoctorInfo()
        LoginForm.Show()
        backtoLoginfrm()
    End Sub '//green code
    'END!
    '****************************************************************************************
    '!COMMMENT: METHODS
    'i. Return to login form
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
    'ii. Retrieve and clear info when Load dashboard 
    Public Sub loadIntoDashboard()
        dctrlblDate.Text = Date.Now.ToLongDateString
        Timer1.Start()
        dctrlblFname.Text = doctorFname + " " + doctorMname + " " + doctorLname
        dctrlblDoctor.Text = loginUserType
    End Sub '//green code
    'iv. Clear 
    Public Sub clearDoctorInfo()
        dctrlblFname.Text = ""
        dctrlblDoctor.Text = ""
    End Sub '//green code
    'END!
    '****************************************************************************************
    '!COMMENT: EXTENSION OF METHODS
    'i. Return to Dashboard
    Public Sub returnToDashboard()
        Me.Refresh()
        btnConsultation.Enabled = True
        btnDiagnosis.Enabled = True
        btnAppointment.Enabled = True
        btnLabAndRadrslt.Enabled = True
        btnSurgery.Enabled = True
        btnPrescription.Enabled = True
        btnProfile.Enabled = True
    End Sub
    'ii. CONSULTATION
    'a. (VIEW)
    Public Sub loadViewConsultation()
        Me.IsMdiContainer = True
        ViewConsultation.MdiParent = Me
        ViewConsultation.Show()
        btnConsultation.Enabled = False
        btnDiagnosis.Enabled = False
        btnAppointment.Enabled = False
        btnLabAndRadrslt.Enabled = False
        btnSurgery.Enabled = False
        btnPrescription.Enabled = False
        btnProfile.Enabled = False
    End Sub '//green code
    'b. (ADD)
    Public Sub loadAddConsultation()
        Me.IsMdiContainer = True
        Consultation.MdiParent = Me
        Consultation.Show()
        btnConsultation.Enabled = True
        btnDiagnosis.Enabled = False
        btnAppointment.Enabled = False
        btnLabAndRadrslt.Enabled = False
        btnSurgery.Enabled = False
        btnPrescription.Enabled = False
        btnProfile.Enabled = False
    End Sub
    'iii. DIAGNOSIS
    'a. (ADD)
    Public Sub loadAddDiagnosis()
        Me.IsMdiContainer = True
        Diagnosis.MdiParent = Me
        Diagnosis.Show()
        btnConsultation.Enabled = False
        btnDiagnosis.Enabled = True
        btnAppointment.Enabled = False
        btnLabAndRadrslt.Enabled = False
        btnSurgery.Enabled = False
        btnPrescription.Enabled = False
        btnProfile.Enabled = False
    End Sub
    'b. (VIEW)
    Public Sub loadViewDiagnosis()
        Me.IsMdiContainer = True
        ViewDiagnosis.MdiParent = Me
        ViewDiagnosis.Show()
        btnConsultation.Enabled = False
        btnDiagnosis.Enabled = True
        btnAppointment.Enabled = False
        btnLabAndRadrslt.Enabled = False
        btnSurgery.Enabled = False
        btnPrescription.Enabled = False
        btnProfile.Enabled = False
    End Sub
    'iii. APPOINTMENT
    'a. (Add)
    Public Sub loadAddappointment()
        Me.IsMdiContainer = True
        Add_Appointment.MdiParent = Me
        Add_Appointment.Show()
        btnConsultation.Enabled = False
        btnDiagnosis.Enabled = False
        btnAppointment.Enabled = True
        btnLabAndRadrslt.Enabled = False
        btnSurgery.Enabled = False
        btnPrescription.Enabled = False
        btnProfile.Enabled = False
    End Sub
    'a. (View)
    Public Sub loadViewApointment()
        Me.IsMdiContainer = True
        ViewAppointment.MdiParent = Me
        ViewAppointment.Show()
        btnConsultation.Enabled = False
        btnDiagnosis.Enabled = False
        btnAppointment.Enabled = True
        btnLabAndRadrslt.Enabled = False
        btnSurgery.Enabled = False
        btnPrescription.Enabled = False
        btnProfile.Enabled = False
    End Sub
    'iv. LAB AND RAD RESULT
    Public Sub loadlabandradResult()
        Me.IsMdiContainer = True
        ViewLaboratoryAndRadiology.MdiParent = Me
        ViewLaboratoryAndRadiology.Show()
        btnConsultation.Enabled = False
        btnDiagnosis.Enabled = False
        btnAppointment.Enabled = False
        btnLabAndRadrslt.Enabled = True
        btnSurgery.Enabled = False
        btnPrescription.Enabled = False
        btnProfile.Enabled = False
    End Sub
    'v. SURGERY
    'a. (Add)
    Public Sub loadAddsurgery()
        Me.IsMdiContainer = True
        Surgery.MdiParent = Me
        Surgery.Show()
        btnConsultation.Enabled = False
        btnDiagnosis.Enabled = False
        btnAppointment.Enabled = False
        btnLabAndRadrslt.Enabled = False
        btnSurgery.Enabled = True
        btnPrescription.Enabled = False
        btnProfile.Enabled = False
    End Sub
    'b. (View)
    Public Sub loadViewSurgery()
        Me.IsMdiContainer = True
        ViewSurgery.MdiParent = Me
        ViewSurgery.Show()
        btnConsultation.Enabled = False
        btnDiagnosis.Enabled = False
        btnAppointment.Enabled = False
        btnLabAndRadrslt.Enabled = False
        btnSurgery.Enabled = True
        btnPrescription.Enabled = False
        btnProfile.Enabled = False
    End Sub
    'vi. PROFILE
    Public Sub loadDoctorProfile()
        Me.IsMdiContainer = True
        DoctorProfilefrm.MdiParent = Me
        DoctorProfilefrm.Show()
        btnConsultation.Enabled = False
        btnDiagnosis.Enabled = False
        btnAppointment.Enabled = False
        btnLabAndRadrslt.Enabled = False
        btnSurgery.Enabled = False
        btnPrescription.Enabled = False
        btnProfile.Enabled = True
    End Sub
    'viii. PRESCRIPTION
    Public Sub loadPrescription()
        Me.IsMdiContainer = True
        PrescriptionFrm.MdiParent = Me
        PrescriptionFrm.Show()
        btnConsultation.Enabled = False
        btnDiagnosis.Enabled = False
        btnAppointment.Enabled = False
        btnLabAndRadrslt.Enabled = False
        btnSurgery.Enabled = False
        btnPrescription.Enabled = True
        btnProfile.Enabled = False
    End Sub
    'ix. Log out
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
        'Using cmd As New SqlCommand("insert into tbluseractivity (userid,fullname,ua_date,ua_time,interface,button,action) values (@userid,@fullname,@det,@tym,@interface,@button,@action);", db.pubSqlCon)
        '    cmd.Parameters.Clear()
        '    cmd.Parameters.Add("@userid", SqlDbType.Int).Value = loginUserid
        '    cmd.Parameters.Add("@fullname", SqlDbType.Text).Value = doctorFname & " " & doctorMname & " " & doctorLname
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
    'i. Loa form
    Public Sub captureUAloadfrm()
        intrfce = "Doctor Dashboard"
        btn = "N/A"
        actn = "Open"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'ii. Consultattion
    Public Sub captureUAConsultation()
        intrfce = "Doctor Dashboard"
        btn = "Consultation"
        actn = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'iii. Diagnosis
    Public Sub captureUADiagnosis()
        intrfce = "Doctor Dashboard"
        btn = "Diagnosis"
        actn = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'iv. Add appointment
    Public Sub captureUAaddAppoinmnt()
        intrfce = "Doctor Dashboard"
        btn = "Add appointment"
        actn = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'v. Laboratory and radiology
    Public Sub captureUAtestResult()
        intrfce = "Doctor Dashboard"
        btn = "Laboratory and Radiology"
        actn = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'vi. Surgery
    Public Sub captureUASurgery()
        intrfce = "Doctor Dashboard"
        btn = "Surgery"
        actn = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'vii. Prescription
    Public Sub captureUAPrescription()
        intrfce = "Doctor Dashboard"
        btn = "Prescription"
        actn = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'viii. Profile
    Public Sub captureUAprofile()
        intrfce = "Doctor Dashboard"
        btn = "Profile"
        actn = "Click"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!
End Class