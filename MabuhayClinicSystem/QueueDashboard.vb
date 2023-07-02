Public Class QueueDashboard
    '!COMMENT: VARIABLES
    Dim i As Integer = 0
    Dim tangoNot As Integer = 0
    'END VARIABLES!
    '*****************************************************************************************************
    '!COMMENT: EVENTS
    'i.Timer 1
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        qdlblTime.Text = Date.Now.ToLongTimeString
    End Sub
    'ii.Tiimer 2
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        i += 1
        If qdNowserving.ForeColor = Color.White And Timer2.Enabled = True Then
            qdNowserving.ForeColor = Color.Red
        Else
            qdNowserving.ForeColor = Color.White
        End If
        '
        If qdNumber1.ForeColor = Color.Blue And Timer2.Enabled = True Then
            qdNumber1.ForeColor = Color.White
        Else
            qdNumber1.ForeColor = Color.Blue
        End If
        '
        If qdNumber2.ForeColor = Color.Blue And Timer2.Enabled = True Then
            qdNumber2.ForeColor = Color.White
        Else
            qdNumber2.ForeColor = Color.Blue
        End If
        '
        If qdNumber3.ForeColor = Color.Blue And Timer2.Enabled = True Then
            qdNumber3.ForeColor = Color.White
        Else
            qdNumber3.ForeColor = Color.Blue
        End If
        If i = 32 Then
            Timer2.Stop()
            i = 0
            qdNowserving.ForeColor = Color.White
            qdNumber1.ForeColor = Color.Blue
            qdNumber2.ForeColor = Color.Blue
            qdNumber3.ForeColor = Color.Blue
        End If
    End Sub
    'iii.Timer 3
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        tangoNot += 1
        If qdNowserving.ForeColor = Color.White Then
            qdNowserving.ForeColor = Color.Red
        Else
            qdNowserving.ForeColor = Color.White
        End If
        If tangoNot = 32 Then
            tangoNot = 0
            Timer3.Stop()
            qdNowserving.ForeColor = Color.White
        End If
    End Sub
    'iv.Load form
    Private Sub QueueDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        qdlblDate.Text = Date.Now.ToLongDateString
    End Sub
    'v. Form closing
    Private Sub QueueDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        mediaplayer1.Ctlcontrols.stop()
    End Sub
    'END EVENTS!
    '*****************************************************************************************************
    '!COMMENTS: METHODS
    'i. CALL
    Public Sub callwithSound()
        Timer2.Start()
        My.Computer.Audio.Play(My.Resources.sounds_effects_mall_announcement_48k_, AudioPlayMode.Background)
    End Sub
    'ii. NOTIFY
    Public Sub notifywithSound()
        Timer3.Start()
        My.Computer.Audio.Play(My.Resources.sounds_effects_mall_announcement_48k_, AudioPlayMode.Background)
    End Sub
    'END METHODS!
End Class