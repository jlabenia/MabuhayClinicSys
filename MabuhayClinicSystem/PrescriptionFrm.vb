Imports System.Data.SqlClient
Imports System.Drawing.Printing
Public Class PrescriptionFrm
    '!COMMENT: PRIVATE VARIABLES
    Dim charlie As Integer = Nothing
    Dim WithEvents PD As New PrintDocument
    Dim PDD As New PrintPreviewDialog
    'Capture user activity
    Dim intrfce As String = Nothing
    Dim btn As String = Nothing
    Dim actn As String = Nothing
    'END!
    '***************************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearAll()
    End Sub
    '
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddToListbox()
    End Sub
    '
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If txtListbox.SelectedItem IsNot Nothing Then
            Dim answer As DialogResult = MessageBox.Show("Remove the selected item?", "Removing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.Yes Then
                For i As Integer = txtListbox.SelectedIndices.Count - 1 To 0 Step -1
                    txtListbox.Items.RemoveAt(txtListbox.SelectedIndices(i))
                Next
            Else
                txtListbox.SelectedItem = Nothing
                Exit Sub
            End If
        Else
            Exit Sub
        End If
        txtListbox.SelectedItem = Nothing
    End Sub
    '
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PDD.Document = PD
        PDD.ShowDialog()
        '
        captureBtnPrint()
    End Sub
    'END!
    '***************************************************************************************
    '!COMMENT: EVENTS
    Private Sub PrescriptionFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureloadForm()
    End Sub
    '
    Private Sub txtMedicine_TextChanged(sender As Object, e As EventArgs) Handles txtMedicine.TextChanged
        If txtMedicine.Text <> "" Then
            searchItem()
        End If
    End Sub
    '
    Private Sub txtLname_TextChanged(sender As Object, e As EventArgs) Handles txtLname.TextChanged
        If txtLname.Text <> "" Then
            searchPatient()
        End If
    End Sub
    '
    Private Sub dgvPatient_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPatient.CellClick
        getColumnPosition(dgvPatient)
        populatePatientFields()
    End Sub
    '
    Private Sub dgvMedicine_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicine.CellClick
        getColumnPosition(dgvMedicine)
        populateMedicineFields()
    End Sub
    '
    Private Sub PrescriptionFrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DoctorDashboard.returnToDashboard()
    End Sub
    '
    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        If Char.IsNumber(e.KeyChar) = False And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    'END!
    '***************************************************************************************
    '!COMMENT: METHODS
    Public Sub searchPatient()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select PersonID as PatientID, CONCAT(FIRSTNAME, ' ', MIDDLENAME, ' ', LASTNAME) as PATIENT, AGE, SEX, CONCAT(BARANGAY, ' ',MUNICIPALITY, ' ', PROVINCE) as ADDRESS from tblPerson " & _
                                    " Where CONCAT(FIRSTNAME, ' ', MIDDLENAME, ' ',LASTNAME) like '' +@lname+ '%' Order by PATIENT ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lname", txtLname.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvPatient.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub populatePatientFields()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select CONCAT(FIRSTNAME, ' ', MIDDLENAME, ' ', LASTNAME) as PATIENT, AGE, SEX, CONCAT(BARANGAY, ' ',MUNICIPALITY, ' ', PROVINCE) as ADDRESS from tblPerson " & _
" Where PersonID = @personid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@personid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtFullname.Text = dt.Rows(0).Item("PATIENT")
                txtAge.Text = dt.Rows(0).Item("AGE")
                txtGender.Text = dt.Rows(0).Item("SEX")
                txtAddress.Text = dt.Rows(0).Item("ADDRESS")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
            charlie = Nothing
        End Using
    End Sub
    '
    Public Sub searchItem()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select ti.ItemID, ti.ItemName,ti.GenericName,tid.UOM, ti.TypeofItem, Sum(tinv.Remaining) as PcsLeft,ti.Dosage from tblItems as ti " & _
" Inner Join tblStockIn as tsi On ti.ItemID = tsi.ItemID " & _
" Inner Join tblItemDetails as tid On tsi.StockInID = tid.StockInID " & _
" Inner Join tblInventory as tinv On tid.ItemDetailsID =tinv.ItemDetailsID " & _
" Where ti.Itemname like '' +@itemname+ '%' and tinv.Status = 'Available' " & _
" Group by ti.ItemID, ti.ItemName,ti.GenericName,tid.UOM, ti.TypeofItem,ti.Dosage;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemname", txtMedicine.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvMedicine.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub populateMedicineFields()
        Dim db As New KonekDB
        db.FETPHARMAINFO()
        Using cmd As New SqlCommand("Select ti.ItemID, ti.ItemName,ti.GenericName,tid.UOM, ti.TypeofItem,ti.Dosage from tblItems as ti " & _
" Inner Join tblStockIn as tsi On ti.ItemID = tsi.ItemID  " & _
" Inner Join tblItemDetails as tid On tsi.StockInID = tid.StockInID " & _
" Where ti.ItemID = @itemid;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@itemid", charlie)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtBrandName.Text = dt.Rows(0).Item("ItemName") & " " & dt.Rows(0).Item("UOM")
                txtGenericName.Text = dt.Rows(0).Item("GenericName")
                txtType.Text = dt.Rows(0).Item("TypeofItem")
                txtDescription.Text = dt.Rows(0).Item("Dosage")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
            charlie = Nothing
        End Using
    End Sub
    '
    Public Sub getColumnPosition(ByVal dgv As DataGridView)
        Try
            Dim romeo As Integer = Nothing
            If dgv.Rows.Count > 0 Then
                romeo = dgv.CurrentRow.Index
                charlie = dgv.Item(0, romeo).Value
            End If
        Catch
            charlie = Nothing
        End Try
    End Sub
    '
    Public Sub clearAll()
        txtLname.Text = ""
        txtFullname.Text = ""
        txtAge.Text = ""
        txtGender.Text = ""
        txtAddress.Text = ""
        txtBrandName.Text = ""
        txtGenericName.Text = ""
        txtQty.Text = ""
        txtType.Text = ""
        txtDescription.Text = ""
        txtListbox.Items.Clear()
    End Sub
    '
    Public Sub clearPrescriptionField()
        txtBrandName.Text = ""
        txtGenericName.Text = ""
        txtQty.Text = ""
        txtType.Text = ""
        txtDescription.Text = ""
    End Sub
    '
    Public Function IsEmpty(ByVal txtbox As TextBox) As Boolean
        Return String.IsNullOrEmpty(txtbox.Text)
    End Function
    '
    Public Sub AddToListbox()
        Dim bolfullname As Boolean = IsEmpty(txtFullname)
        Dim bolBrandName As Boolean = IsEmpty(txtBrandName)
        Dim bolGenricName As Boolean = IsEmpty(txtGenericName)
        Dim bolQty As Boolean = IsEmpty(txtQty)
        Dim bolType As Boolean = IsEmpty(txtType)
        Dim bolDescription As Boolean = IsEmpty(txtDescription)
        If bolfullname Then
            msgbBoxShw()
        ElseIf bolBrandName Then
            msgbBoxShw()
        ElseIf bolGenricName Then
            msgbBoxShw()
        ElseIf bolQty Then
            msgbBoxShw()
        ElseIf bolType Then
            msgbBoxShw()
        ElseIf bolDescription Then
            msgbBoxShw()
        Else
            txtListbox.Items.Add("-" & txtBrandName.Text & "(" & txtGenericName.Text & ") - #" & txtQty.Text & " " & txtType.Text & " - " & txtDescription.Text)
                clearPrescriptionField()
        End If
    End Sub
    '
    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim strName As String = "Sabine Korth"
        Dim strLine As String = "__________________________________________________________________"
        Dim strLine1 As String = "__________________________________________________________________"
        'Font formats   
        'Dim f8 As New Font("Arial", 8, FontStyle.Regular)
        'Dim f10 As New Font("Arial", 11, FontStyle.Regular)
        Dim f10 As New Font("Arial", 10, FontStyle.Regular)
        Dim f9 As New Font("Lucida Calligraphy", 9, FontStyle.Regular)
        Dim f14b As New Font("Arial", 14, FontStyle.Bold)
        Dim f16b As New Font("Arial Rounded MT Bold", 16, FontStyle.Bold)
        Dim f60b As New Font("Bookman Old Style,", 60, FontStyle.Bold)
        'Page margin
        Dim leftMargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centerMargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightMargin As Integer = PD.DefaultPageSettings.PaperSize.Width
        'Font alignment
        Dim rightAlign As New StringFormat
        Dim centerAlign As New StringFormat
        Dim leftAlign As New StringFormat
        rightAlign.Alignment = StringAlignment.Far
        centerAlign.Alignment = StringAlignment.Center
        leftAlign.Alignment = StringAlignment.Near
        'call System.Drawing.Printing.PrintEventsArgs
        e.Graphics.DrawString("Saint Francis of Assisi Mabuhay Clinic", f16b, Brushes.ForestGreen, centerMargin, 50, centerAlign)
        e.Graphics.DrawString("Brgy. Bugko, Mondragon Northern Samar", f10, Brushes.Black, centerMargin, 80, centerAlign)
        e.Graphics.DrawString(doctorFname & " " & doctorMname & " " & doctorLname & ",MD", f16b, Brushes.Black, centerMargin, 110, centerAlign) '//Type here
        e.Graphics.DrawString(strLine, f16b, Brushes.Black, centerMargin, 130, centerAlign)
        e.Graphics.DrawString(strLine, f16b, Brushes.Black, centerMargin, 132, centerAlign)
        e.Graphics.DrawString("Patient name: ", f10, Brushes.Black, 40, 170)
        e.Graphics.DrawString(txtFullname.Text, f10, Brushes.Black, 135, 170) '//Type here
        e.Graphics.DrawString("Address: ", f10, Brushes.Black, 40, 200)
        e.Graphics.DrawString(txtAddress.Text, f10, Brushes.Black, 135, 200) '//Type here
        e.Graphics.DrawString("Date: " & Date.Now.ToLongDateString(), f10, Brushes.Black, rightMargin - 50, 170, rightAlign)
        e.Graphics.DrawString("Age: " & txtAge.Text & "     " & "Gender: " & txtGender.Text, f10, Brushes.Black, rightMargin - 50, 200, rightAlign) '//type here
        e.Graphics.DrawString("Rx", f60b, Brushes.Black, 20, 250, leftAlign)
        '
        Dim spacePerLine As Integer = 380
        '
        For i As Integer = 0 To txtListbox.Items.Count - 1
            Dim itemListValue As String = txtListbox.Items(i).ToString
            e.Graphics.DrawString(itemListValue, f9, Brushes.Black, 50, spacePerLine, leftAlign) '
            spacePerLine += 25
        Next
        e.Graphics.DrawString("Refill: " & "Yes:____| No:____", f10, Brushes.Black, 40, spacePerLine + 100, leftAlign)
        e.Graphics.DrawString("Physician signature: " & "___________________M.D.", f10, Brushes.Black, rightMargin - 40, spacePerLine + 100, rightAlign)
        e.Graphics.DrawString("License No: ", f10, Brushes.Black, 612, spacePerLine + 120, rightAlign)
        e.Graphics.DrawString(licensedNo, f10, Brushes.Black, rightMargin - 50, spacePerLine + 120, rightAlign) '//Type here
        e.Graphics.DrawString("_____________________", f10, Brushes.Black, rightMargin - 50, spacePerLine + 122, rightAlign)
        e.Graphics.DrawString("PTR No: ", f10, Brushes.Black, rightMargin - 215, spacePerLine + 140, rightAlign)
        e.Graphics.DrawString("_____________________", f10, Brushes.Black, rightMargin - 50, spacePerLine + 142, rightAlign)
    End Sub
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
    'i. Load form
    Public Sub captureloadForm()
        intrfce = "Prescription"
        btn = "N/A"
        actn = "Open"
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    '
    Public Sub captureBtnPrint()
        intrfce = "Prescription"
        btn = "Print"
        actn = "Print prescription for patient " & txtFullname.Text & "."
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub

    'END!
    '***************************************************************************************

End Class