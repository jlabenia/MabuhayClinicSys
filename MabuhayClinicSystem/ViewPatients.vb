Imports System.Data.SqlClient
Public Class ViewPatients
    '!COMMENT:
    'END!
    '***********************************************************************************
    '!COMMENT: BUTTONS
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        searchByDateRange()
        totalRecords()
    End Sub
    'END!
    '***********************************************************************************
    '!COMMENT: EVENTS
    Private Sub ViewPatients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPatientInfo()
    End Sub
    '
    Private Sub ViewPatients_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.load_PatientInfo()
    End Sub
    'END!
    '***********************************************************************************
    '!COMMENT: METHODS
    Public Sub loadPatientInfo()
        'Load latest top 100 patient info
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using da As New SqlDataAdapter("Select top 100 tp.PersonID as PatientID, CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ',tp.LASTNAME ) as PATIENT,tp.AGE,CONCAT(tp.DAY,'-',tp.MONTH,'-',tp.YEAR) as BIRTHDATE,tp.SEX as GENDER,tp.CONTACTNO,CONCAT(tp.BARANGAY,' ',tp.MUNICIPALITY, ' ',tp.PROVINCE) as ADDRESS, tv.VS_DATE as LAST_VISIT from tblPerson as tp " & _
" Inner join tblVitalSigns as tv On tp.PersonID = tv.PersonID order by tp.PersonID DESC;", db.pubSqlCon)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvView.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
        End Using
    End Sub
    '
    Public Sub totalRecords()
        Dim det1 As Date = CDate(dtp1.Text)
        Dim det2 As Date = CDate(dtp2.Text)
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select COUNT(tp.PersonID) as total from tblPerson as tp " & _
                                        " Inner join tblVitalSigns as tv On tp.PersonID = tv.PersonID " & _
                                        " Where tv.VS_DATE between @det1 And @det2;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", det1)
            cmd.Parameters.AddWithValue("@det2", det2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtTotal.Text = dt.Rows(0).Item("total")
            End If
            db.pubSqlCon.Close()
            dt.Dispose()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    '
    Public Sub searchByDateRange()
        Dim det1 As Date = CDate(dtp1.Text)
        Dim det2 As Date = CDate(dtp2.Text)
        Dim db As New KonekDB
        db.FETCHDBINFO()
        Using cmd As New SqlCommand("Select tp.PersonID as PatientID, CONCAT(tp.FIRSTNAME, ' ', tp.MIDDLENAME, ' ',tp.LASTNAME ) as PATIENT,tp.AGE,CONCAT(tp.DAY,'-',tp.MONTH,'-',tp.YEAR) as BIRTHDATE,tp.SEX as GENDER,tp.CONTACTNO,CONCAT(tp.BARANGAY,' ',tp.MUNICIPALITY, ' ',tp.PROVINCE) as ADDRESS, tv.VS_DATE as LAST_VISIT from tblPerson as tp " & _
                                    " Inner join tblVitalSigns as tv On tp.PersonID = tv.PersonID " & _
                                    " Where tv.VS_DATE between @det1 And @det2;", db.pubSqlCon)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@det1", det1)
            cmd.Parameters.AddWithValue("@det2", det2)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Rows.Clear()
            da.Fill(dt)
            dgvView.DataSource = dt
            db.pubSqlCon.Close()
            da.Dispose()
            cmd.Dispose()
        End Using
    End Sub
    'END!
End Class