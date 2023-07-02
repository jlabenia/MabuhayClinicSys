Imports System.Data.SqlClient
Public Class KonekDB
    Public pubSqlCon As SqlConnection         'this variable can be access in other Forms 
    Public Sub FETCHDBINFO()
        Try
            pubSqlCon = New SqlConnection
            pubSqlCon.ConnectionString = "DATA SOURCE=LAPTOP-RO5QH1LF;INITIAL CATALOG=MabuhayClinicDB;TRUSTED_CONNECTION=TRUE;INTEGRATED SECURITY=TRUE"
            pubSqlCon.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            pubSqlCon.Dispose()
            pubSqlCon.Close()
        End Try
    End Sub
    Public Sub FETPHARMAINFO()
        Try
            pubSqlCon = New SqlConnection
            pubSqlCon.ConnectionString = "DATA SOURCE=LAPTOP-RO5QH1LF;INITIAL CATALOG=MabuhayPharmacy;TRUSTED_CONNECTION=TRUE;INTEGRATED SECURITY=TRUE"
            pubSqlCon.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            pubSqlCon.Dispose()
            pubSqlCon.Close()
        End Try
    End Sub
End Class
