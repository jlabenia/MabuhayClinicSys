Imports System.Data.SqlClient
Public Class Queuefrms
    '!COMMENT: BUTTONS
    'i. MANAGE QUEUE
    Private Sub btnManageQue_Click(sender As Object, e As EventArgs) Handles btnManageQue.Click
        Dim intrfce As String = "Manage Queue"
        Dim btn As String = "Manage Queue"
        Dim actn As String = "Click"
        clickManagequeu()
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'ii. Queue dashboard 
    Private Sub btnCustQueDashboard_Click(sender As Object, e As EventArgs) Handles btnCustQueDashboard.Click
        Dim intrfce As String = "Customer Queue Dashboard"
        Dim btn As String = "Customer Que"
        Dim actn As String = "Click"
        QueueDashboard.Enabled = True
        QueueDashboard.Show()
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'iii. ADD QUEU
    Private Sub btnAddQue_Click(sender As Object, e As EventArgs) Handles btnAddQue.Click
        Dim intrfce As String = "Customer Add Queue Dashboard"
        Dim btn As String = "Add Que"
        Dim actn As String = "Click"
        AddQue.Show()
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END BUTTONS!
    '*******************************************************************************************************
    '!COMMENT: EVENTS
    'i. Form closing
    Private Sub Queuefrms_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        UserDashboard.returntoUserDashboard()
    End Sub
    'END EVENTS!
    '********************************************************************************************************
    '!COMMENT: METHODS
    Public Sub clickManagequeu()
        Dim childMQue As New ManageQueue
        UserDashboard.IsMdiContainer = True
        childMQue.MdiParent = UserDashboard
        Me.Hide()
        childMQue.Show()
    End Sub
    '
    Public Sub UserActivity(ByVal intrfce As String, ByVal btn As String, ByVal actn As String)
        'Dim det As Date = CDate(Date.Now.ToShortDateString())
        'Dim tym As TimeSpan = Date.Now.TimeOfDay

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
    'END METHODS!
End Class