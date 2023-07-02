Public Class ManageClinic

    Private Sub ManageClinic_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AdminDashboard.returntoAdminDashboard()
    End Sub

    Private Sub btnQueue_Click(sender As Object, e As EventArgs) Handles btnQueue.Click
        Me.Close()
        AdminDashboard.load_AdminQue()
    End Sub

    Private Sub btnAppointment_Click(sender As Object, e As EventArgs) Handles btnAppointment.Click
        Me.Close()
        AdminDashboard.load_AdminAppointment()
    End Sub

    Private Sub btnClinicPersonnel_Click(sender As Object, e As EventArgs) Handles btnClinicPersonnel.Click
        Me.Close()
        AdminDashboard.load_ClinincPersonnel()
    End Sub

    Private Sub btnDoctorInfo_Click(sender As Object, e As EventArgs) Handles btnDoctorInfo.Click
        Me.Close()
        AdminDashboard.load_DoctorInfo()
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
        Me.Close()
        AdminDashboard.load_PatientInfo()
    End Sub
End Class