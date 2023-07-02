Imports System.Data.SqlClient
Public Class ManageQueue
    '!COMMENT: PUBLIC VARIABLES
    Dim charlie As String = Nothing
    Dim tangoNot As Integer = 0
    Dim tangoNext As Integer = 0
    '*************************************************************************************
    '!COMMENT: BUTTONS
    'i.NEXT
    Private Sub mqbtnNext_Click(sender As Object, e As EventArgs) Handles mqbtnNext.Click
        If QueueDashboard.Enabled = True Then
            Dim intrfce As String = "Manage Queue"
            Dim btn As String = "Next"
            Dim actn As String = "Move " & mqlblTokenNum.Text & " to next queue."
            '
            moveQueue()
            pastetoQueDashbrd()
            QueueDashboard.callwithSound()
            loadQue()
            UserActivity(intrfce, btn, actn)
            clearFields()
            timerNext.Start()
            '
            'reset private variables
            intrfce = Nothing
            btn = Nothing
            actn = Nothing
        Else
            MsgBox("Please open the Customer Queue Dashboard.", MsgBoxStyle.Exclamation)
        End If
    End Sub
    'ii. NOTIFY
    Private Sub mqbtnNotify_Click(sender As Object, e As EventArgs) Handles mqbtnNotify.Click
        If QueueDashboard.Enabled = True Then
            Dim intrfce As String = "Manage Queue"
            Dim btn As String = "Notify"
            Dim actn As String = "Call attention of " & mqlblNowServing.Text & "."
            '
            timerNotify.Start()
            QueueDashboard.notifywithSound()
            UserActivity(intrfce, btn, actn)
            'reset private variables
            intrfce = Nothing
            btn = Nothing
            actn = Nothing
        Else
            MsgBox("Please open the Customer Queue Dashboard.", MsgBoxStyle.Exclamation)
        End If
    End Sub
    'iii.PlAY MOVIE
    Private Sub mqbtnPlay_Click(sender As Object, e As EventArgs) Handles mqbtnPlay.Click
        If QueueDashboard.Enabled = True Then
            playMovie()
        Else
            MsgBox("Please open the Customer Queue Dashboard.", MsgBoxStyle.Exclamation)
        End If
    End Sub
    'END BUTTONS!
    '************************************************************************************
    '!COMMENT: EVENTS
    'i.LOAD FORM
    Private Sub ManageQueue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim intrfce As String = "Manage Queue"
        Dim btn As String = "N/A"
        Dim actn As String = "Open"
        '
        loadQue()
        loadAppointment()
        UserActivity(intrfce, btn, actn)
        If QueueDashboard.Enabled = True Then
            copyQueueFields()
        End If
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'ii.QUEUE CELL CLICK
    Private Sub dgvQueue_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQueue.CellClick
        clearFields()
        getColumnPosition(dgvQueue)
        getQueueInfo()
    End Sub
    'iii. APPOINTMENT CELL CLICK
    Private Sub dgvAppoinmnt_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAppoinmnt.CellClick
        clearFields()
        getColumnPosition(dgvAppoinmnt)
        getAppointmentInfo()
        charlie = Nothing
    End Sub
    'iv.FORM CLOSING
    Private Sub ManageQueue_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        UserDashboard.enterQuefrms()
    End Sub
    'v.TIMER NOTIFY
    Private Sub timerNotify_Tick(sender As Object, e As EventArgs) Handles timerNotify.Tick
        tangoNot += 1
        If mqlblNowServing.ForeColor = Color.White Then
            mqlblNowServing.ForeColor = Color.Red
        Else
            mqlblNowServing.ForeColor = Color.White
        End If
        If tangoNot = 32 Then
            tangoNot = 0
            timerNotify.Stop()
            mqlblNowServing.ForeColor = Color.White
        End If
    End Sub
    'TIMER NEXT
    Private Sub timerNext_Tick(sender As Object, e As EventArgs) Handles timerNext.Tick
        tangoNext += 1
        If mqlblNowServing.ForeColor = Color.White Then
            mqlblNowServing.ForeColor = Color.Red
        Else
            mqlblNowServing.ForeColor = Color.White
        End If
        If mqlblNumber1.ForeColor = Color.Black Then
            mqlblNumber1.ForeColor = Color.ForestGreen
        Else
            mqlblNumber1.ForeColor = Color.Black
        End If
        If mqlblNumber2.ForeColor = Color.Black Then
            mqlblNumber2.ForeColor = Color.ForestGreen
        Else
            mqlblNumber2.ForeColor = Color.Black
        End If
        If mqlblNumber3.ForeColor = Color.Black Then
            mqlblNumber3.ForeColor = Color.ForestGreen
        Else
            mqlblNumber3.ForeColor = Color.Black
        End If
        '
        If tangoNext = 32 Then
            tangoNext = 0
            timerNext.Stop()
            mqlblNumber1.ForeColor = Color.Black
            mqlblNumber2.ForeColor = Color.Black
            mqlblNumber3.ForeColor = Color.Black
            mqlblNowServing.ForeColor = Color.White
        End If
    End Sub
    'END EVENTS!
    '**********************************************************************************************************
    '!COMMENT: METHODS
    'i. LOAD DGV QUEUE
    Public Sub loadQue()
        Dim db As New KonekDB
        Dim cmd As New SqlCommand
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        Dim str As String = "Select * From tblQue where QDATE =@det"
        db.FETCHDBINFO()
        With cmd
            .Connection = db.pubSqlCon
            .CommandText = str
            .Parameters.Clear()
            .Parameters.AddWithValue("@det", det)
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        dt.Rows.Clear()
        da.Fill(dt)
        dgvQueue.DataSource = dt
        da.Dispose()
        dt.Dispose()
        cmd.Dispose()
        db.pubSqlCon.Close()
    End Sub
    'ii. LOAD DGV APPOINMENT
    Public Sub loadAppointment()
        Dim db As New KonekDB
        Dim cmd As New SqlCommand
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        Dim str As String = "Select  AppointmentID, TOKEN,A_TIME, FIRSTNAME, MIDDLENAME, LASTNAME, CONCAT(BARANGAY,MUNICIPALITY,PROVINCE)as ADDRESS, SEX as GENDER, A_DATE from tblAppointment as ta Inner join tblPerson as tp On tp.PersonID = ta.PersonID where A_DATE  = @det;"
        db.FETCHDBINFO()
        With cmd
            .Connection = db.pubSqlCon
            .CommandText = str
            .Parameters.Clear()
            .Parameters.AddWithValue("@det", det)
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        dt.Rows.Clear()
        da.Fill(dt)
        dgvAppoinmnt.DataSource = dt
        da.Dispose()
        dt.Dispose()
        cmd.Dispose()
        db.pubSqlCon.Close()
    End Sub
    'iii. GET COLUMN POSITION
    Public Sub getColumnPosition(ByVal dgv As DataGridView)
        Try
            Dim romeo As Integer = Nothing
            If dgv.Rows.Count > 0 Then
                romeo = dgv.CurrentRow.Index
                charlie = dgv.Item(1, romeo).Value
            End If
        Catch

        End Try
    End Sub
    'iv. GET QUE INFO
    Public Sub getQueueInfo()
        Dim db As New KonekDB
        Dim str As String = "Select  TOKENNUMBER, CONCAT(FIRSTNAME,' ',LASTNAME) as FULLNAME, CONCAT(BARANGAY,' ',MUNICIPALITY ,' ', PROVINCE)as ADDRESS, GENDER, QDATE From tblQue where TOKENNUMBER=@token"
        Dim cmd As New SqlCommand
        If charlie <> Nothing Then
            db.FETCHDBINFO()
            With cmd
                .Connection = db.pubSqlCon
                .CommandText = str
                .Parameters.Clear()
                .Parameters.AddWithValue("@token", charlie)
            End With
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                mqlblTokenNum.Text = dt.Rows(0).Item("TOKENNUMBER")
                mqlblDate.Text = dt.Rows(0).Item("QDATE")
                mqlblCategory.Text = "REGULAR"
                mqlblFullname.Text = dt.Rows(0).Item("FULLNAME")
                mqlblGender.Text = dt.Rows(0).Item("GENDER")
                mqlblAddress.Text = dt.Rows(0).Item("ADDRESS")
            End If
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
            db.pubSqlCon.Close()
        End If
    End Sub
    'v. GET APPOINTMENT INFO
    Public Sub getAppointmentInfo()
        Dim db As New KonekDB
        Dim str As String = "Select  TOKEN,A_TIME, CONCAT(FIRSTNAME, ' ',LASTNAME) as FULLNAME, CONCAT(BARANGAY,' ',MUNICIPALITY, ' ', PROVINCE) as  ADDRESS, SEX as GENDER,CONTACTNO, A_DATE  From tblAppointment as ta Inner join tblPerson as tp On tp.PersonID = ta.PersonID where TOKEN=@token"
        Dim cmd As New SqlCommand
        Dim tym As TimeSpan
        If charlie <> Nothing Then
            db.FETCHDBINFO()
            With cmd
                .Connection = db.pubSqlCon
                .CommandText = str
                .Parameters.Clear()
                .Parameters.AddWithValue("@token", charlie)
            End With
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                mqlblTokenNum.Text = dt.Rows(0).Item("TOKEN")
                mqlblDate.Text = dt.Rows(0).Item("A_DATE")
                mqlblCategory.Text = "APPOINTMENT"
                mqlblFullname.Text = dt.Rows(0).Item("FULLNAME")
                mqlblGender.Text = dt.Rows(0).Item("GENDER")
                mqlblAddress.Text = dt.Rows(0).Item("ADDRESS")
                mqlblContactNum.Text = dt.Rows(0).Item("CONTACTNO")
                tym = dt.Rows(0).Item("A_TIME")
                mqlblTime.Text = FormatDateTime(tym.ToString(), DateFormat.LongTime)
            End If
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
            db.pubSqlCon.Close()
        End If
    End Sub
    'vi.CLEAR FIELDS
    Public Sub clearFields()
        mqlblTokenNum.Text = "0_00"
        mqlblDate.Text = ""
        mqlblCategory.Text = ""
        mqlblFullname.Text = ""
        mqlblGender.Text = ""
        mqlblAddress.Text = ""
        mqlblContactNum.Text = ""
        mqlblTime.Text = ""
        charlie = Nothing
    End Sub
    'v.Populate Queue line numbers 0-3
    Public Sub copyQueueFields()
        mqlblTokenNum.Text = ""
        mqlblNumber1.Text = ""
        mqlblNumber2.Text = ""
        mqlblNumber3.Text = ""
        mqlblTokenNum.Text = QueueDashboard.qdNowserving.Text.ToString()
        mqlblNumber1.Text = QueueDashboard.qdNumber1.Text.ToString()
        mqlblNumber2.Text = QueueDashboard.qdNumber2.Text.ToString()
        mqlblNumber3.Text = QueueDashboard.qdNumber3.Text.ToString()
    End Sub
    'vi.Move Queue 
    Public Sub moveQueue()
        mqlblNowServing.Text = ""
        mqlblNowServing.Text = mqlblNumber1.Text
        mqlblNumber1.Text = ""
        mqlblNumber1.Text = mqlblNumber2.Text
        mqlblNumber2.Text = ""
        mqlblNumber2.Text = mqlblNumber3.Text
        mqlblNumber3.Text = ""
        mqlblNumber3.Text = mqlblTokenNum.Text
        mqlblTokenNum.Text = ""
        If mqlblTokenNum.Text = "" Then
            mqlblTokenNum.Text = "0_00"
        End If
    End Sub
    'vii.Paste to Queue Dashboard
    Public Sub pastetoQueDashbrd()
        QueueDashboard.qdNowserving.Text = ""
        QueueDashboard.qdNowserving.Text = mqlblNowServing.Text
        QueueDashboard.qdNumber1.Text = ""
        QueueDashboard.qdNumber1.Text = mqlblNumber1.Text
        QueueDashboard.qdNumber2.Text = ""
        QueueDashboard.qdNumber2.Text = mqlblNumber2.Text
        QueueDashboard.qdNumber3.Text = ""
        QueueDashboard.qdNumber3.Text = mqlblNumber3.Text
    End Sub
    'viii. Delete Queu
    Public Sub deleteQueue()
        Dim db As New KonekDB
        Dim cmd As New SqlCommand
        Dim str As String = "Delete from tblQue where TOKENNUMBER = '" & charlie & "'"
        db.FETCHDBINFO()
        cmd.Connection = db.pubSqlCon
        cmd.CommandText = str
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        db.pubSqlCon.Close()
    End Sub '// for termintion
    'ix. Upload movie
    Public Sub playMovie()
        Dim mediaStr As String = ""
        QueueDashboard.OpenFileDialog1.FileName = ""
        QueueDashboard.OpenFileDialog1.Filter = "Video File | *.mp4; *.mpg;"
        QueueDashboard.OpenFileDialog1.InitialDirectory = "E:\"
        QueueDashboard.OpenFileDialog1.ShowDialog()
        '
        If QueueDashboard.OpenFileDialog1.FileName = "" Then
            Exit Sub
        Else
            mediaStr = QueueDashboard.OpenFileDialog1.FileName.ToString
            QueueDashboard.mediaplayer1.URL = mediaStr
            QueueDashboard.mediaplayer1.Ctlcontrols.play()
        End If
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
End Class