Imports System.Data.SqlClient
Imports System.Globalization
Public Class Add_Appointment
    '!COMMENT: PRIVATE VARIABLES
    Dim personid As Integer = Nothing
    Dim charliePapa As Integer = Nothing
    Dim charlieAlpha As Integer = Nothing
    Dim det As Date = CDate(Date.Now.ToShortDateString)
    Dim checkdet As String = Nothing
    '
    Dim intrfce As String = Nothing
    Dim btn As String = Nothing
    Dim actn As String = Nothing
    'END!
    '********************************************************************************************
    '!COMMENT: BUTTONS
    'i. SAVE
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If charliePapa <> 0 Then
            If txtFullname.Text = "" Then
                msgbBoxShw()
            ElseIf txtNote.Text = "" Then
                msgbBoxShw()
            ElseIf cmbxHour.Text = "" Then
                msgbBoxShw()
            ElseIf cmbxSecond.Text = "" Then
                msgbBoxShw()
            Else
                Dim detDtp As Date = CDate(dtp1.Text)
                If detDtp < det Then
                    MsgBox("Please check the date. Date must not be set backwards.")
                Else
                    captureUAsave()
                    insertNewAppointment()
                    clearFields()
                    txtLastname.Text = ""
                    loadnewappoinment()
                End If
            End If
        End If
    End Sub
    'ii. UPDATE
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim detNow As String = det.ToString()
        Dim dit1 As Date = Nothing
        Dim dit2 As Date = Nothing
        If Date.TryParse(checkdet, dit1) = True And Date.TryParse(detNow, dit2) = True Then
            'Check if the date of record to be updated is = today or beyond
            If dit1 >= dit2 Then
                Dim answer = MessageBox.Show("Please confirm if you would want to update this record.", "Updating...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If answer = Windows.Forms.DialogResult.Yes Then
                    captureUAupdate() ' capture user activity
                    updateAppointment()
                    clearFields()
                End If
            Else
                MessageBox.Show("Security error! You may update appointment records with date today or beyond this day.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub
    'iii. VIEW
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        captureUAview()
        Me.Close()
        DoctorDashboard.loadViewApointment()
    End Sub
    'END!
    '********************************************************************************************
    '!COMMENT: EVENTS
    'i. Load
    Private Sub Add_Appointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureUAloadFrm()
        loadlistofApppointment()
    End Sub
    'ii. DGV cell click (Person)
    Private Sub dgvPerson_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPerson.CellClick
        Try
            btnSave.Enabled = True
            btnUpdate.Enabled = False
            charliePapa = Nothing
            Dim romeo As Integer = Nothing
            If dgvPerson.RowCount > 0 Then
                romeo = dgvPerson.CurrentRow.Index
                charliePapa = dgvPerson.Item(0, romeo).Value
                fromPersontoFields()
            End If
        Catch
            clearFields()
        End Try
    End Sub '//green code
    'iii. Test changed
    Private Sub txtLastname_TextChanged(sender As Object, e As EventArgs) Handles txtLastname.TextChanged
        If txtLastname.Text <> "" Then
            SearcPersonInfo()
            searchAppointment()
        Else
            loadlistofApppointment()
        End If
    End Sub
    'iv. DGV cell click (Appointment)
    Private Sub dgvAppointment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAppointment.CellClick
        Try
            btnSave.Enabled = False
            btnUpdate.Enabled = True
            charlieAlpha = Nothing
            Dim romeo As Integer = Nothing
            If dgvAppointment.RowCount > 0 Then
                romeo = dgvAppointment.CurrentRow.Index
                charlieAlpha = dgvAppointment.Item(0, romeo).Value
                fromAppointmentoFields()
            End If
        Catch
            clearFields()
        End Try
    End Sub
    'v. Keypress
    Private Sub txtLastname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastname.KeyPress
        If Char.IsLetter(e.KeyChar) = False And e.KeyChar <> vbBack AndAlso e.KeyChar <> " " Then
            e.Handled = True
        End If
    End Sub
    'vi. Form closing
    Private Sub Add_Appointment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DoctorDashboard.returnToDashboard()
    End Sub
    'END!
    '********************************************************************************************
    '!COMMENT: METHODS
    'i. Search person by Lastname
    Public Sub SearcPersonInfo()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tp.PersonID, CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', tp.LASTNAME) as FULLNAME,tp.AGE,CONCAT(tp.MONTH,' ',tp.DAY, ' ,',tp.YEAR) as BIRTHDATE,SEX,CONCAT(tp.BARANGAY,' ',tp.MUNICIPALITY,' ',tp.PROVINCE) as ADDRESS,tp.CONTACTNO from tblPerson as tp where CONCAT(tp.LASTNAME, ' ',tp.FIRSTNAME, ' ', tp.MIDDLENAME) like '' +@lname+ '%' Order by FULLNAME DESC ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtLastname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPerson.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'ii. Search appointment by Lastname
    Public Sub searchAppointment()
        Dim dayAhead As Date = Nothing
        For count As Integer = 1 To 8
            dayAhead = det.AddDays(+count)
        Next
        '
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ta.AppointmentID,ta.TOKEN,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', tp.LASTNAME) as FULLNAME,ta.A_DATE,ta.A_TIME,NOTE from tblAppointment as ta " & _
" Inner Join tblPerson as tp On ta.PersonID = tp.PersonID " & _
" Where CONCAT(tp.LASTNAME, ' ',tp.FIRSTNAME, ' ', tp.MIDDLENAME) like '' +@lname+ '%' And  ta.A_DATE >=@det1 And ta.A_DATE <=@det2  Order by ta.A_DATE ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtLastname.Text)
            cmd.Parameters.AddWithValue("@det1", det)
            cmd.Parameters.AddWithValue("@det2", dayAhead)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvAppointment.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'iii. Insert new appointment
    Public Sub insertNewAppointment()
        Dim appointmentid As Integer = Nothing
        Dim deyt As Date = CDate(dtp1.Text)
        '
        Dim strtime As String = cmbxHour.Text + ":" + cmbxSecond.Text 'used by tym
        Dim tym As TimeSpan = TimeSpan.Parse(strtime)
        '
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Insert into tblAppointment(TOKEN,PersonID,A_DATE,A_TIME,NOTE) values (@token,@personid,@date,@time,@note);", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@token", SqlDbType.VarChar).Value = "A_" + appointmentid.ToString()
            cmd.Parameters.Add("@personid", SqlDbType.Int).Value = charliePapa
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = deyt
            cmd.Parameters.Add("@time", SqlDbType.Time).Value = tym
            cmd.Parameters.Add("@note", SqlDbType.VarChar).Value = txtNote.Text
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("New record added!")
            charliePapa = Nothing
        End Using
    End Sub
    'iv. Update appointment
    Public Sub updateAppointment()
        Dim deyt As Date = CDate(dtp1.Text)
        Dim strtime As String = cmbxHour.Text + ":" + cmbxSecond.Text
        Dim format As String = strtime.ToString()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Update tblAppointment Set A_DATE=@det,A_TIME=@time,NOTE=@note from tblAppointment where AppointmentID=@appointmentid ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@appointmentid", charlieAlpha)
            Dim tym As TimeSpan = Date.Parse(format).TimeOfDay
            cmd.Parameters.AddWithValue("@time", tym)
            cmd.Parameters.AddWithValue("@det", deyt)
            cmd.Parameters.AddWithValue("@note", txtNote.Text)
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
            cmd.Dispose()
            MsgBox("Update success!")
        End Using
        'Load updated appointment
        Using cmd As New SqlCommand("Select ta.AppointmentID,ta.TOKEN,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', tp.LASTNAME) as FULLNAME,ta.A_DATE,ta.A_TIME,NOTE from tblAppointment as ta " & _
                                    " Inner Join tblPerson as tp On ta.PersonID = tp.PersonID " & _
                                    " Where ta.AppointmentID=@appointmnetid ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@appointmnetid", charlieAlpha)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvAppointment.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            charlieAlpha = Nothing
            checkdet = Nothing
        End Using
    End Sub
    'v. Populate txt fields (from person to feilds)
    Public Sub fromPersontoFields()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select PersonID,CONCAT(FIRSTNAME, ' ', MIDDLENAME, ' ', LASTNAME) as FULLNAME from tblperson Where PersonID=@personid ", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", charliePapa)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtFullname.Text = dt.Rows(0).Item("FULLNAME")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'vi. Populate txt fields (from appointment to fields)
    Public Sub fromAppointmentoFields()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ta.AppointmentID,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', tp.LASTNAME) as FULLNAME,ta.A_DATE,ta.A_TIME,ta.NOTE from tblAppointment as ta " & _
" Inner Join tblPerson as tp On ta.PersonID = tp.PersonID " & _
" Where ta.AppointmentID=@appointmentid ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@appointmentid", charlieAlpha)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Dim tymStr As String = ""
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtFullname.Text = dt.Rows(0).Item("FULLNAME")
                dtp1.Value = dt.Rows(0).Item("A_DATE")
                checkdet = dt.Rows(0).Item("A_DATE").ToString()
                tymStr = dt.Rows(0).Item("A_TIME").ToString()
                '
                cmbxHour.Text = tymStr.Substring(0, 2).ToString()
                cmbxSecond.Text = tymStr.Substring(3, 2).ToString()
                txtNote.Text = dt.Rows(0).Item("NOTE")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'vii. Clear fields
    Public Sub clearFields()
        txtFullname.Text = ""
        txtNote.Text = ""
        cmbxHour.SelectedIndex = -1
        cmbxSecond.SelectedIndex = -1
        dtp1.Text = Date.Now.ToShortDateString
        charliePapa = Nothing
    End Sub
    'viii. Load new appointment 
    Public Sub loadnewappoinment()
        Dim appointmentid As Integer = Nothing
        Dim db As New KonekDB
        db.FETCHDBINFO()
        'Get current appointment id
        Using da As New SqlDataAdapter("Select Max(AppointmentID) as id from tblAppointment;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                appointmentid = dt.Rows(0).Item("id")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
        End Using
        '
        Using cmd As New SqlCommand("Select ta.AppointmentID,ta.TOKEN,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', tp.LASTNAME) as FULLNAME,ta.A_DATE,ta.A_TIME,NOTE from tblAppointment as ta " & _
" Inner Join tblPerson as tp On ta.PersonID = tp.PersonID " & _
" Where ta.AppointmentID=@appointmnetid ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@appointmnetid ", appointmentid)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvAppointment.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
            charlieAlpha = Nothing
        End Using
    End Sub
    'ix. load list appointment tommorow
    Public Sub loadlistofApppointment()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select ta.AppointmentID,ta.TOKEN,CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ', tp.LASTNAME) as FULLNAME,ta.A_DATE,ta.A_TIME,NOTE from tblAppointment as ta " & _
" Inner Join tblPerson as tp On ta.PersonID = tp.PersonID " & _
" Where ta.A_DATE=@det Order by ta.TOKEN ASC ;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvAppointment.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
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
    'i. Load form
    Public Sub captureUAloadFrm()
        intrfce = "Add appointment"
        btn = "N/A"
        actn = "Open"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAsave()
        intrfce = "Add appointment"
        btn = "Save"
        actn = "Save appointment of " & txtFullname.Text & "."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAupdate()
        intrfce = "Add appointment"
        btn = "Update"
        actn = "Update appointment of " & txtFullname.Text & "."
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureUAview()
        intrfce = "Add appointment"
        btn = "View"
        actn = "Click"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!
End Class