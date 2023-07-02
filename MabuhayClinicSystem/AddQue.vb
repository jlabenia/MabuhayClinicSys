Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class AddQue
    '!COMMENT: PUBLIC VARIABLES
    Dim tymofDay As String = Nothing
    Dim deytofDay As String = Nothing
    Dim patientFullname As String = Nothing
    '
    Dim que As String = Nothing
    Dim appointment As String = Nothing
    '
    Dim WithEvents PD1 As New PrintDocument
    Dim WithEvents PD2 As New PrintDocument
    Dim PDD As New PrintPreviewDialog
    'END VARIABLES!
    '****************************************************************************
    '!COMMENT: BUTTON
    'i. SEARCH 
    Private Sub aqbtnPrint_Click(sender As Object, e As EventArgs) Handles aqbtnPrint.Click
        getAppointment()
        If appointment = "" Then
            MsgBox("Please select a name from the drop down menu.")
        Else
            'Print(preview)
            PDD.Document = PD2
            PDD.ShowDialog()
            'PD2.Print()
            'appointment = Nothing
        End If
    End Sub
    'ii. SUBMIT 
    Private Sub aqbtnSubmit_Click(sender As Object, e As EventArgs) Handles aqbtnSubmit.Click
        Dim bolfname As Boolean = isFieldEmpty(aqtxtbxFname)
        Dim bolmname As Boolean = isFieldEmpty(aqtxtbxMname)
        Dim bolLname As Boolean = isFieldEmpty(aqtxtbxLname)
        Dim bolBrgy As Boolean = isFieldEmpty(aqtxtbxBrgy)
        Dim bolMncplty As Boolean = isFieldEmpty(aqtxbxMunicipality)
        Dim bolPrvnce As Boolean = isFieldEmpty(aqtxtbxProvince)
        If bolfname Then
            MessageBox.Show("Please do not leave the fields empty!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        ElseIf bolmname Then
            MessageBox.Show("Please do not leave the fields empty!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        ElseIf bolLname Then
            MessageBox.Show("Please do not leave the fields empty!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        ElseIf bolBrgy Then
            MessageBox.Show("Please do not leave the fields empty!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        ElseIf bolMncplty Then
            MessageBox.Show("Please do not leave the fields empty!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        ElseIf bolPrvnce Then
            MessageBox.Show("Please do not leave the fields empty!", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        Else
            toNormalLetter()
            loadProperty()
            inserttoQue()
            changePanelToken()
            toLowerLetter()
            aqClear()
            'Print preview
            PDD.Document = PD1
            PDD.ShowDialog()
            'PD1.Print()
        End If
    End Sub
    'END BUTTON!
    '****************************************************************************
    '!COMMENT: EVENTS
    'i. FORM LOAD
    Private Sub AddQue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        loadAppointment()
    End Sub
    'ii. TIMER1
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        aqlblDateTime.Text = ""
        deytofDay = Date.Now.ToLongDateString
        tymofDay = Date.Now.ToLongTimeString
        aqlblDateTime.Text = deytofDay.ToString + "    " + tymofDay.ToString
    End Sub
    'iii. KEY PRESS
    Private Sub IsLetterOnly(sender As Object, e As KeyPressEventArgs) Handles aqtxbxMunicipality.KeyPress, aqtxtbxProvince.KeyPress, aqtxtbxMname.KeyPress, aqtxtbxLname.KeyPress, aqtxtbxFname.KeyPress
        If (Char.IsLetter(e.KeyChar) = False And e.KeyChar <> vbBack And e.KeyChar <> " ") Then
            e.Handled = True
        End If
    End Sub
    'END EVENTS
    '****************************************************************************
    '!COMMENT: METHODS
    'i.CLEAR FIELDS
    Public Sub aqClear()
        aqcmbxSearch.SelectedIndex = -1
        aqtxtbxFname.Text = ""
        aqtxtbxLname.Text = ""
        aqtxtbxMname.Text = ""
        aqtxtbxBrgy.Text = ""
        aqtxbxMunicipality.Text = ""
        aqtxtbxProvince.Text = "NORTHERN SAMAR"
        _fname = Nothing
        _mname = Nothing
        _lname = Nothing
        _brgy = Nothing
        _municpalty = Nothing
        _province = Nothing
    End Sub
    'ii. LOAD APPOINTMENT TO SEARCH BOX
    Public Sub loadAppointment()
        Dim db As New KonekDB
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim deyt As Date = CDate(Date.Now.ToShortDateString)
        Dim str As String = "Select  AppointmentID, TOKEN,A_TIME, CONCAT(FIRSTNAME,' ',MIDDLENAME ,' ', LASTNAME) as Fullname, CONCAT(BARANGAY,MUNICIPALITY,PROVINCE)as ADDRESS, SEX as GENDER, A_DATE from tblAppointment as ta Inner join tblPerson as tp On tp.PersonID = ta.PersonID where A_DATE = @deyt ORDER BY Fullname ASC"
        db.FETCHDBINFO()
        Using cmd As New SqlCommand(str, db.pubSqlCon)
            cmd.Parameters.AddWithValue("@deyt", deyt)
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            db.pubSqlCon.Close()
            aqcmbxSearch.DataSource = dt
            aqcmbxSearch.DisplayMember = "Fullname"
            aqcmbxSearch.ValueMember = "TOKEN"
            cmd.Dispose()
            da.Dispose()
        End Using
        aqcmbxSearch.Text = ""
    End Sub
    'iii. GET APPOINTMENT DATA
    Public Sub getAppointment()
        If aqcmbxSearch.Text = "" Then
        Else
            Dim selectedItem As DataRowView = aqcmbxSearch.SelectedItem
            Dim i As String = selectedItem("TOKEN")
            appointment = i
            MessageBox.Show("Printing...! " + vbCrLf + "This is your token number for Appointment: " + appointment, "Printing.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    'iv. InsertQueue
    Public Sub inserttoQue()
        Dim db As New KonekDB
        Dim qnum As Integer = Nothing
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select MAX(QNUM) as qnum from tblQue", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0).Item("qnum")) = False Then
                    qnum = dt.Rows(0).Item("qnum")
                    qnum += 1
                End If
            End If
            dt.Dispose()
            da.Dispose()
            db.pubSqlCon.Close()
        End Using
        Using cmd As New SqlCommand("Insert into tblQue (TOKENNUMBER,FIRSTNAME,MIDDLENAME,LASTNAME,BARANGAY,MUNICIPALITY,PROVINCE,GENDER,QDATE) values (@token,@fname,@mname,@lname,@brgy,@municipality,@province,@gender,@qdate)", db.pubSqlCon)
            db.pubSqlCon.Open()
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@token", System.Data.SqlDbType.Char).Value = "C_" + qnum.ToString
            '
            que = "C_" + qnum.ToString
            '
            cmd.Parameters.Add("@fname", System.Data.SqlDbType.VarChar).Value = aqtxtbxFname.Text
            cmd.Parameters.Add("@mname", System.Data.SqlDbType.VarChar).Value = aqtxtbxMname.Text
            cmd.Parameters.Add("@lname", System.Data.SqlDbType.VarChar).Value = aqtxtbxLname.Text
            cmd.Parameters.Add("@brgy", System.Data.SqlDbType.VarChar).Value = "Brgy." + aqtxtbxBrgy.Text
            cmd.Parameters.Add("@municipality", System.Data.SqlDbType.VarChar).Value = aqtxbxMunicipality.Text
            cmd.Parameters.Add("@province", System.Data.SqlDbType.VarChar).Value = aqtxtbxProvince.Text
            If aqrbFemale.Checked = True Then
                cmd.Parameters.Add("@gender", System.Data.SqlDbType.VarChar).Value = "Female"
            ElseIf aqrbMale.Checked = True Then
                cmd.Parameters.Add("@gender", System.Data.SqlDbType.VarChar).Value = "Male"
            Else
                cmd.Parameters.Add("@gender", System.Data.SqlDbType.VarChar).Value = "Null"
            End If

            cmd.Parameters.Add("@qdate", System.Data.SqlDbType.Date).Value = det
            cmd.ExecuteNonQuery()
            patientFullname = aqtxtbxFname.Text & " " & aqtxtbxMname.Text & " " & aqtxtbxLname.Text
            aqClear()
            MessageBox.Show("Printing...! " + vbCrLf + "This is your token number for QUE: " + que, "Printing.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'v. Is field empty?
    Public Function isFieldEmpty(txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
    'vi. To Lower
    Public Sub toLowerLetter()
        aqtxtbxFname.CharacterCasing = CharacterCasing.Lower
        aqtxtbxMname.CharacterCasing = CharacterCasing.Lower
        aqtxtbxLname.CharacterCasing = CharacterCasing.Lower
        aqtxtbxBrgy.CharacterCasing = CharacterCasing.Lower
        aqtxbxMunicipality.CharacterCasing = CharacterCasing.Lower
        aqtxtbxProvince.CharacterCasing = CharacterCasing.Lower
    End Sub
    'vii. To Normal
    Public Sub toNormalLetter()
        aqtxtbxFname.CharacterCasing = CharacterCasing.Normal
        aqtxtbxMname.CharacterCasing = CharacterCasing.Normal
        aqtxtbxLname.CharacterCasing = CharacterCasing.Normal
        aqtxtbxBrgy.CharacterCasing = CharacterCasing.Normal
        aqtxbxMunicipality.CharacterCasing = CharacterCasing.Normal
        aqtxtbxProvince.CharacterCasing = CharacterCasing.Normal
    End Sub
    'viii. Load Property
    Public Sub loadProperty()
        ProprtyFname = aqtxtbxFname.Text
        aqtxtbxFname.Text = ProprtyFname
        _fname = ""
        _fname = Nothing
        '
        ProprtyMname = aqtxtbxMname.Text
        aqtxtbxMname.Text = ProprtyMname
        _mname = ""
        _mname = Nothing
        '
        ProprtyLname = aqtxtbxLname.Text
        aqtxtbxLname.Text = ProprtyLname
        _lname = ""
        _lname = Nothing
        '
        ProprtyBrgy = aqtxtbxBrgy.Text
        aqtxtbxBrgy.Text = ProprtyBrgy
        _brgy = ""
        _brgy = Nothing
        '
        ProprtyMunicipality = aqtxbxMunicipality.Text
        aqtxbxMunicipality.Text = ProprtyMunicipality
        _municpalty = ""
        _municpalty = Nothing
        '
        ProprtyProvince = aqtxtbxProvince.Text
        aqtxtbxProvince.Text = ProprtyProvince
        _province = ""
        _province = Nothing
    End Sub
    '
    Public Sub changePanelToken()
        lblTokenNum.Text = que.ToString()
        lblFullname.Text = patientFullname.ToString()
    End Sub
    '
    Public Sub resetPanelToken()
        lblFullname.Text = " "
        lblTokenNum.Text = "0_00"
    End Sub
    '
    Private Sub PD1_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PD1.BeginPrint
        'Local
        Dim pageSetup As New PageSettings
        pageSetup.PaperSize = New PaperSize("Custom", 250, 280)
        PD1.DefaultPageSettings = pageSetup
    End Sub
    '
    Private Sub PD2_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PD2.BeginPrint
        'Local
        Dim pageSetup As New PageSettings
        pageSetup.PaperSize = New PaperSize("Custom", 250, 280)
        PD2.DefaultPageSettings = pageSetup
    End Sub
    '
    Private Sub PD1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD1.PrintPage
        'Font formats
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f16 As New Font("Calibri", 16, FontStyle.Regular)
        Dim f48 As New Font("Calibri", 48, FontStyle.Bold)
        'Page margin
        Dim leftMargin As Integer = PD1.DefaultPageSettings.Margins.Left
        Dim centerMargin As Integer = PD1.DefaultPageSettings.PaperSize.Width / 2
        Dim rightMargin As Integer = PD1.DefaultPageSettings.PaperSize.Width
        'Font alignment
        Dim rightAlign As New StringFormat
        Dim centerAlign As New StringFormat
        Dim leftAlign As New StringFormat
        rightAlign.Alignment = StringAlignment.Far
        centerAlign.Alignment = StringAlignment.Center
        leftAlign.Alignment = StringAlignment.Near
        'call System.Drawing.Printing.PrintEventsArgs
        e.Graphics.DrawString("Welcome to", f16, Brushes.Black, centerMargin, 10, centerAlign)
        e.Graphics.DrawString("Saint Franciss of Assissi", f16, Brushes.Black, centerMargin, 30, centerAlign)
        e.Graphics.DrawString("Mabuhay Clinic", f16, Brushes.Black, centerMargin, 50, centerAlign)
        e.Graphics.DrawString("", f16, Brushes.Black, centerMargin, 80, centerAlign)
        e.Graphics.DrawString("Your token number is ", f10, Brushes.Black, centerMargin, 85, centerAlign)
        e.Graphics.DrawString(que, f48, Brushes.Black, centerMargin, 90, centerAlign)
        e.Graphics.DrawString("(Regular)", f10, Brushes.Black, centerMargin, 175, centerAlign)
        e.Graphics.DrawString("Please wait for your number to be called.", f8, Brushes.Black, centerMargin, 195, centerAlign)
        e.Graphics.DrawString("We would appreciate your patience while waiting.", f8, Brushes.Black, centerMargin, 210, centerAlign)
        e.Graphics.DrawString("Thank you! ", f10, Brushes.Black, centerMargin, 225, centerAlign)
        e.Graphics.DrawString("Date: " & Date.Now.ToLongDateString.ToString(), f8, Brushes.Black, 0, 260)
        e.Graphics.DrawString("Time: " & Date.Now.ToLongTimeString, f8, Brushes.Black, rightMargin, 260, rightAlign)
    End Sub
    '
    Private Sub PD2_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD2.PrintPage
        'Font formats
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f16 As New Font("Calibri", 16, FontStyle.Regular)
        Dim f48 As New Font("Calibri", 48, FontStyle.Bold)
        'Page margin
        Dim leftMargin As Integer = PD2.DefaultPageSettings.Margins.Left
        Dim centerMargin As Integer = PD2.DefaultPageSettings.PaperSize.Width / 2
        Dim rightMargin As Integer = PD2.DefaultPageSettings.PaperSize.Width
        'Font alignment
        Dim rightAlign As New StringFormat
        Dim centerAlign As New StringFormat
        Dim leftAlign As New StringFormat
        rightAlign.Alignment = StringAlignment.Far
        centerAlign.Alignment = StringAlignment.Center
        leftAlign.Alignment = StringAlignment.Near
        'call System.Drawing.Printing.PrintEventsArgs
        e.Graphics.DrawString("Welcome to", f16, Brushes.Black, centerMargin, 10, centerAlign)
        e.Graphics.DrawString("Saint Franciss of Assissi", f16, Brushes.Black, centerMargin, 30, centerAlign)
        e.Graphics.DrawString("Mabuhay Clinic", f16, Brushes.Black, centerMargin, 50, centerAlign)
        e.Graphics.DrawString("", f16, Brushes.Black, centerMargin, 80, centerAlign)
        e.Graphics.DrawString("Your token number is ", f10, Brushes.Black, centerMargin, 85, centerAlign)
        e.Graphics.DrawString(appointment, f48, Brushes.Black, centerMargin, 90, centerAlign)
        e.Graphics.DrawString("(Appointment)", f10, Brushes.Black, centerMargin, 175, centerAlign)
        e.Graphics.DrawString("Please wait for your number to be called.", f8, Brushes.Black, centerMargin, 195, centerAlign)
        e.Graphics.DrawString("We would appreciate your patience while waiting.", f8, Brushes.Black, centerMargin, 210, centerAlign)
        e.Graphics.DrawString("Thank you! ", f10, Brushes.Black, centerMargin, 225, centerAlign)
        e.Graphics.DrawString("Date: " & Date.Now.ToLongDateString.ToString(), f8, Brushes.Black, 0, 260)
        e.Graphics.DrawString("Time: " & Date.Now.ToLongTimeString, f8, Brushes.Black, rightMargin, 260, rightAlign)
    End Sub
    'END METHODS!
    '*****************************************************************************

End Class