Imports System.Data.SqlClient
Public Class ViewAppointment
    '!COMMENT:PUBLIC VARIABLES
    Dim charlie As String = Nothing
    '
    Dim intrfce As String = Nothing
    Dim btn As String = Nothing
    Dim actn As String = Nothing
    'END PUBLIC VARIABLES!
    '***********************************************************************************************
    '!COMMENT: BUTTONS
    Private Sub vaBtnSearch_Click(sender As Object, e As EventArgs) Handles vaBtnSearch.Click
        searchbyDet()
        totalList()
    End Sub
    'END BUTTONS!
    '************************************************************************************************
    '!COMMENT: EVENTS
    'i. FORM LOADING
    Private Sub ViewAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        captureUAloadFrm()
        vaClear()
        loadAppointment()
        totalList()
    End Sub
    'ii.TextChanged
    Private Sub vatxtbxLname_TextChanged(sender As Object, e As EventArgs) Handles vatxtbxLname.TextChanged
        valblTotal.Text = "0"
        If vatxtbxLname.Text = "" Then
            vaClear()
            loadAppointment()
            totalList()
        Else
            searchLname()
        End If
    End Sub
    'iii.Cell click
    Private Sub vaDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles vaDGV.CellClick
        Try
            vaClear()
            Dim romeo As Integer = Nothing
            If vaDGV.Rows.Count > 0 Then
                romeo = vaDGV.CurrentRow.Index
                charlie = vaDGV.Item(1, romeo).Value
            End If
            romeo = Nothing
            populateFeilds()
        Catch ex As Exception
            vaClear()
            totalList()
        End Try
    End Sub
    'iv.Form closing
    Private Sub ViewAppointment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        UserDashboard.returntoUserDashboard()
    End Sub
    'END EVENTS!
    '************************************************************************************************
    'COMMENT: METHODS
    'i.CLEAR
    Public Sub vaClear()
        valblFname.Text = ""
        valblGender.Text = ""
        valblDOB.Text = ""
        valblAge.Text = ""
        valblContactNum.Text = ""
        valblAddress.Text = ""
        valblTotal.Text = ""
        valblAppntmntDet.Text = ""
        valblTotal.Text = " "
    End Sub
    'ii. Load Appointment
    Public Sub loadAppointment()
        Dim db As New KonekDB
        Dim det As Date = CDate(Date.Now.ToShortDateString)
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select  AppointmentID, TOKEN,A_TIME,A_DATE, CONCAT(FIRSTNAME,' ',MIDDLENAME ,' ', LASTNAME) as FULLNAME, CONCAT(BARANGAY,MUNICIPALITY,PROVINCE)as ADDRESS, SEX as GENDER, CONTACTNO as PHONE_NUMBER from tblAppointment as ta Inner join tblPerson as tp On tp.PersonID = ta.PersonID where A_DATE = @det ORDER BY TOKEN ASC", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", det)
            Dim da As New SqlDataAdapter()
            da.SelectCommand = cmd
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            vaDGV.DataSource = dt
            da.Dispose()
            cmd.Dispose()
        End Using
        det = Nothing
        db.pubSqlCon.Close()
    End Sub
    'iii. Search  by Lastname
    Public Sub searchLname()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select  AppointmentID, TOKEN,A_TIME,A_DATE, LASTNAME, CONCAT(FIRSTNAME,' ',MIDDLENAME ) as NAME,SEX as GENDER, CONTACTNO as PHONE_NUMBER, CONCAT(BARANGAY,' ',MUNICIPALITY,' ', PROVINCE) as _ADDRESS from tblAppointment as ta Inner join tblPerson as tp On tp.PersonID = ta.PersonID where LASTNAME LIKE '%' + @lastname + '%' ORDER BY TOKEN ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@lastname", vatxtbxLname.Text)
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                'Check if there is records
                Dim intrfce As String = "View Appointment"
                Dim btn As String = "Search bar"
                Dim actn As String = "Search appointment of patient " & vatxtbxLname.Text & "."
                '
                UserActivity(intrfce, btn, actn)
                'reset private variables
                intrfce = Nothing
                btn = Nothing
                actn = Nothing
            End If
            vaDGV.DataSource = dt
            cmd.Dispose()
            da.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'iv.SearchBy Date
    Public Sub searchbyDet()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select  AppointmentID, TOKEN,A_TIME,A_DATE, LASTNAME, CONCAT(FIRSTNAME,' ',MIDDLENAME ) as NAME,SEX as GENDER, CONTACTNO as PHONE_NUMBER, CONCAT(BARANGAY,' ',MUNICIPALITY,' ', PROVINCE) as _ADDRESS from tblAppointment as ta Inner join tblPerson as tp On tp.PersonID = ta.PersonID where A_DATE = @det ORDER BY TOKEN ASC;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", CDate(vaDTP.Value.ToShortDateString()))
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                'Check if there is records
                Dim intrfce As String = "View Appointment"
                Dim btn As String = "Enter"
                Dim actn As String = "Search appointment records  " & vaDTP.Value.ToShortDateString() & "."
                '
                UserActivity(intrfce, btn, actn)
                'reset private variables
                intrfce = Nothing
                btn = Nothing
                actn = Nothing
            End If
            vaDGV.DataSource = dt
            cmd.Dispose()
            da.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'v. Count the total list
    Public Sub totalList()
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select COUNT(DISTINCT AppointmentID) As _TOTAL from tblAppointment GROUP BY A_DATE HAVING A_DATE = @det;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det", CDate(vaDTP.Value.ToShortDateString()))
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            da.SelectCommand = cmd
            dt.Rows.Clear()
            da.Fill(dt)
            '
            Dim counresult As Object = cmd.ExecuteScalar
            If counresult IsNot DBNull.Value Then
                valblTotal.Text = counresult
            Else
                valblTotal.Text = "0"
            End If
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
        db.pubSqlCon.Close()
    End Sub
    'Populate fields
    Public Sub populateFeilds()
        Dim db As New KonekDB
        If charlie <> Nothing Then
            db.FETCHDBINFO()
            Using cmd As New SqlCommand("Select CONCAT(FIRSTNAME, ' ', MIDDLENAME, ' ', LASTNAME ) as FULLNAME, AGE, CONCAT(DAY, ' ',MONTH, ' ', YEAR )as DOB, SEX, CONCAT(BARANGAY, ' ', MUNICIPALITY, ' ', PROVINCE ) as ADDRESS, CONTACTNO, A_DATE,NOTE from tblAppointment as ta " & _
                                        " Inner join tblPerson as tp On ta.PersonID = tp.PersonID where TOKEN =@charlie", db.pubSqlCon)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@charlie", charlie)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                dt.Rows.Clear()
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    valblFname.Text = dt.Rows(0).Item("FULLNAME")
                    valblGender.Text = dt.Rows(0).Item("SEX")
                    valblDOB.Text = dt.Rows(0).Item("DOB")
                    valblAge.Text = dt.Rows(0).Item("AGE")
                    valblContactNum.Text = dt.Rows(0).Item("CONTACTNO")
                    valblAddress.Text = dt.Rows(0).Item("ADDRESS")
                    vallblNote.Text = dt.Rows(0).Item("NOTE")
                    Dim mydet As Date = dt.Rows(0).Item("A_DATE")
                    valblAppntmntDet.Text = mydet.ToString("D")
                End If
                dt.Dispose()
                da.Dispose()
                cmd.Dispose()
                db.pubSqlCon.Close()
                charlie = Nothing
            End Using
        End If
    End Sub
    '
    Public Sub UserActivity(ByVal intrfce As String, ByVal btn As String, ByVal actn As String)
        Dim docFullname As String = doctorFname & " " & doctorMname & " " & doctorLname
        Dim userFullname As String = cp_fname & " " & cp_mname & " " & cp_lname
        Dim det As Date = CDate(Date.Now.ToShortDateString())
        Dim tym As TimeSpan = Date.Now.TimeOfDay
        '
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Insert into tblUserActivity (UserID,FULLNAME,UA_DATE,UA_TIME,INTERFACE,BUTTON,ACTION) values (@userid,@fullname,@det,@tym,@interface,@button,@action);", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = loginUserid
            If loginUserType = "DOCTOR" Then
                cmd.Parameters.Add("@fullname", SqlDbType.Text).Value = docFullname
            Else
                cmd.Parameters.Add("@fullname", SqlDbType.Text).Value = userFullname
            End If
            cmd.Parameters.Add("@det", SqlDbType.Date).Value = det
            cmd.Parameters.Add("@tym", SqlDbType.Time).Value = tym
            cmd.Parameters.Add("@interface", SqlDbType.Text).Value = intrfce
            cmd.Parameters.Add("@button", SqlDbType.Text).Value = btn
            cmd.Parameters.Add("@action", SqlDbType.Text).Value = actn
            cmd.ExecuteNonQuery()
            db.pubSqlCon.Close()
        End Using
    End Sub
    'END!
    '************************************************************************************************
    '!COMMENT:USER ACTIVITY METHODS
    'i. Load form
    Public Sub captureUAloadFrm()
        intrfce = "View appointment"
        btn = "N/A"
        actn = "Open"
        '
        UserActivity(intrfce, btn, actn)
        'reset private variables
        intrfce = Nothing
        btn = Nothing
        actn = Nothing
    End Sub
    'END!
End Class
