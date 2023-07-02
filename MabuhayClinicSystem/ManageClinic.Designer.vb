<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageClinic
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnDoctorInfo = New System.Windows.Forms.Button()
        Me.btnClinicPersonnel = New System.Windows.Forms.Button()
        Me.btnPatients = New System.Windows.Forms.Button()
        Me.btnAppointment = New System.Windows.Forms.Button()
        Me.btnQueue = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnDoctorInfo
        '
        Me.btnDoctorInfo.BackColor = System.Drawing.Color.ForestGreen
        Me.btnDoctorInfo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDoctorInfo.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnDoctorInfo.Location = New System.Drawing.Point(517, 126)
        Me.btnDoctorInfo.Name = "btnDoctorInfo"
        Me.btnDoctorInfo.Size = New System.Drawing.Size(469, 97)
        Me.btnDoctorInfo.TabIndex = 16
        Me.btnDoctorInfo.Text = "DOCTOR INFO"
        Me.btnDoctorInfo.UseVisualStyleBackColor = False
        '
        'btnClinicPersonnel
        '
        Me.btnClinicPersonnel.BackColor = System.Drawing.Color.ForestGreen
        Me.btnClinicPersonnel.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClinicPersonnel.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnClinicPersonnel.Location = New System.Drawing.Point(517, 23)
        Me.btnClinicPersonnel.Name = "btnClinicPersonnel"
        Me.btnClinicPersonnel.Size = New System.Drawing.Size(469, 97)
        Me.btnClinicPersonnel.TabIndex = 15
        Me.btnClinicPersonnel.Text = "CLINIC PERSONEL INFO"
        Me.btnClinicPersonnel.UseVisualStyleBackColor = False
        '
        'btnPatients
        '
        Me.btnPatients.BackColor = System.Drawing.Color.ForestGreen
        Me.btnPatients.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPatients.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnPatients.Location = New System.Drawing.Point(276, 229)
        Me.btnPatients.Name = "btnPatients"
        Me.btnPatients.Size = New System.Drawing.Size(469, 97)
        Me.btnPatients.TabIndex = 14
        Me.btnPatients.Text = "PATIENTS"
        Me.btnPatients.UseVisualStyleBackColor = False
        '
        'btnAppointment
        '
        Me.btnAppointment.BackColor = System.Drawing.Color.ForestGreen
        Me.btnAppointment.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAppointment.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnAppointment.Location = New System.Drawing.Point(21, 126)
        Me.btnAppointment.Name = "btnAppointment"
        Me.btnAppointment.Size = New System.Drawing.Size(469, 97)
        Me.btnAppointment.TabIndex = 13
        Me.btnAppointment.Text = "APPOINTMENT"
        Me.btnAppointment.UseVisualStyleBackColor = False
        '
        'btnQueue
        '
        Me.btnQueue.BackColor = System.Drawing.Color.ForestGreen
        Me.btnQueue.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQueue.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnQueue.Location = New System.Drawing.Point(21, 23)
        Me.btnQueue.Name = "btnQueue"
        Me.btnQueue.Size = New System.Drawing.Size(469, 97)
        Me.btnQueue.TabIndex = 12
        Me.btnQueue.Text = "QUEUE"
        Me.btnQueue.UseVisualStyleBackColor = False
        '
        'ManageClinic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Pink
        Me.ClientSize = New System.Drawing.Size(1008, 346)
        Me.Controls.Add(Me.btnDoctorInfo)
        Me.Controls.Add(Me.btnClinicPersonnel)
        Me.Controls.Add(Me.btnPatients)
        Me.Controls.Add(Me.btnAppointment)
        Me.Controls.Add(Me.btnQueue)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "ManageClinic"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ManageClinic"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDoctorInfo As System.Windows.Forms.Button
    Friend WithEvents btnClinicPersonnel As System.Windows.Forms.Button
    Friend WithEvents btnPatients As System.Windows.Forms.Button
    Friend WithEvents btnAppointment As System.Windows.Forms.Button
    Friend WithEvents btnQueue As System.Windows.Forms.Button
End Class
