<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DoctorDashboard
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnProfile = New System.Windows.Forms.Button()
        Me.btnPrescription = New System.Windows.Forms.Button()
        Me.btnSurgery = New System.Windows.Forms.Button()
        Me.btnLabAndRadrslt = New System.Windows.Forms.Button()
        Me.btnAppointment = New System.Windows.Forms.Button()
        Me.btnDiagnosis = New System.Windows.Forms.Button()
        Me.btnConsultation = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dctrlblFname = New System.Windows.Forms.Label()
        Me.dctrlblDoctor = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.dctrlblDate = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dctrlblTime = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnProfile)
        Me.Panel1.Controls.Add(Me.btnPrescription)
        Me.Panel1.Controls.Add(Me.btnSurgery)
        Me.Panel1.Controls.Add(Me.btnLabAndRadrslt)
        Me.Panel1.Controls.Add(Me.btnAppointment)
        Me.Panel1.Controls.Add(Me.btnDiagnosis)
        Me.Panel1.Controls.Add(Me.btnConsultation)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(253, 978)
        Me.Panel1.TabIndex = 0
        '
        'btnProfile
        '
        Me.btnProfile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnProfile.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProfile.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Contact_Info_65px
        Me.btnProfile.Location = New System.Drawing.Point(0, 868)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Size = New System.Drawing.Size(251, 108)
        Me.btnProfile.TabIndex = 9
        Me.btnProfile.Text = "PROFILE"
        Me.btnProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProfile.UseVisualStyleBackColor = True
        '
        'btnPrescription
        '
        Me.btnPrescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPrescription.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrescription.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Pharmacy_65px
        Me.btnPrescription.Location = New System.Drawing.Point(0, 758)
        Me.btnPrescription.Name = "btnPrescription"
        Me.btnPrescription.Size = New System.Drawing.Size(251, 110)
        Me.btnPrescription.TabIndex = 8
        Me.btnPrescription.Text = "PRESCRIPTION"
        Me.btnPrescription.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrescription.UseVisualStyleBackColor = True
        '
        'btnSurgery
        '
        Me.btnSurgery.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSurgery.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSurgery.Image = Global.MabuhayClinicSystem.My.Resources.Resources.icons8_surgeon_65
        Me.btnSurgery.Location = New System.Drawing.Point(0, 648)
        Me.btnSurgery.Name = "btnSurgery"
        Me.btnSurgery.Size = New System.Drawing.Size(251, 110)
        Me.btnSurgery.TabIndex = 7
        Me.btnSurgery.Text = "SURGERY"
        Me.btnSurgery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSurgery.UseVisualStyleBackColor = True
        '
        'btnLabAndRadrslt
        '
        Me.btnLabAndRadrslt.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnLabAndRadrslt.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLabAndRadrslt.Image = Global.MabuhayClinicSystem.My.Resources.Resources.icons8_laboratory_65
        Me.btnLabAndRadrslt.Location = New System.Drawing.Point(0, 538)
        Me.btnLabAndRadrslt.Name = "btnLabAndRadrslt"
        Me.btnLabAndRadrslt.Size = New System.Drawing.Size(251, 110)
        Me.btnLabAndRadrslt.TabIndex = 6
        Me.btnLabAndRadrslt.Text = "LABORATORY AND RADIOLOGY " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnLabAndRadrslt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLabAndRadrslt.UseVisualStyleBackColor = True
        '
        'btnAppointment
        '
        Me.btnAppointment.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAppointment.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAppointment.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Schedule1_65px
        Me.btnAppointment.Location = New System.Drawing.Point(0, 428)
        Me.btnAppointment.Name = "btnAppointment"
        Me.btnAppointment.Size = New System.Drawing.Size(251, 110)
        Me.btnAppointment.TabIndex = 5
        Me.btnAppointment.Text = "ADD APPOINTMENT"
        Me.btnAppointment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAppointment.UseVisualStyleBackColor = True
        '
        'btnDiagnosis
        '
        Me.btnDiagnosis.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDiagnosis.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDiagnosis.Image = Global.MabuhayClinicSystem.My.Resources.Resources.icons8_diagnosis_65
        Me.btnDiagnosis.Location = New System.Drawing.Point(0, 318)
        Me.btnDiagnosis.Name = "btnDiagnosis"
        Me.btnDiagnosis.Size = New System.Drawing.Size(251, 110)
        Me.btnDiagnosis.TabIndex = 4
        Me.btnDiagnosis.Text = "DIAGNOSIS"
        Me.btnDiagnosis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDiagnosis.UseVisualStyleBackColor = True
        '
        'btnConsultation
        '
        Me.btnConsultation.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnConsultation.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultation.Image = Global.MabuhayClinicSystem.My.Resources.Resources.icons8_medical_doctor_65
        Me.btnConsultation.Location = New System.Drawing.Point(0, 208)
        Me.btnConsultation.Name = "btnConsultation"
        Me.btnConsultation.Size = New System.Drawing.Size(251, 110)
        Me.btnConsultation.TabIndex = 3
        Me.btnConsultation.Text = "CONSULTATION"
        Me.btnConsultation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsultation.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 198)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(251, 10)
        Me.Panel7.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.dctrlblFname)
        Me.Panel2.Controls.Add(Me.dctrlblDoctor)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(251, 198)
        Me.Panel2.TabIndex = 1
        '
        'dctrlblFname
        '
        Me.dctrlblFname.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dctrlblFname.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dctrlblFname.Location = New System.Drawing.Point(2, 151)
        Me.dctrlblFname.Name = "dctrlblFname"
        Me.dctrlblFname.Size = New System.Drawing.Size(242, 23)
        Me.dctrlblFname.TabIndex = 5
        Me.dctrlblFname.Text = "Dr. Jason Labenia"
        Me.dctrlblFname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dctrlblDoctor
        '
        Me.dctrlblDoctor.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dctrlblDoctor.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dctrlblDoctor.Location = New System.Drawing.Point(9, 120)
        Me.dctrlblDoctor.Name = "dctrlblDoctor"
        Me.dctrlblDoctor.Size = New System.Drawing.Size(227, 23)
        Me.dctrlblDoctor.TabIndex = 3
        Me.dctrlblDoctor.Text = "USER: Doctor"
        Me.dctrlblDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Doctor_Female_80px
        Me.Label2.Location = New System.Drawing.Point(62, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 100)
        Me.Label2.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(253, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1036, 66)
        Me.Panel3.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1034, 64)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "SAINT FRANSCIS OF ASSISI MABUHAY CLININC"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(253, 880)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1036, 98)
        Me.Panel4.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.dctrlblDate)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.Location = New System.Drawing.Point(583, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(451, 96)
        Me.Panel6.TabIndex = 4
        '
        'dctrlblDate
        '
        Me.dctrlblDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dctrlblDate.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dctrlblDate.Location = New System.Drawing.Point(0, 0)
        Me.dctrlblDate.Name = "dctrlblDate"
        Me.dctrlblDate.Size = New System.Drawing.Size(449, 94)
        Me.dctrlblDate.TabIndex = 6
        Me.dctrlblDate.Text = "DATE: MUNDAY, 03-23-2023"
        Me.dctrlblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.dctrlblTime)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(583, 96)
        Me.Panel5.TabIndex = 4
        '
        'dctrlblTime
        '
        Me.dctrlblTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dctrlblTime.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dctrlblTime.Location = New System.Drawing.Point(0, 0)
        Me.dctrlblTime.Name = "dctrlblTime"
        Me.dctrlblTime.Size = New System.Drawing.Size(581, 94)
        Me.dctrlblTime.TabIndex = 5
        Me.dctrlblTime.Text = "01:00 PM"
        Me.dctrlblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'DoctorDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1289, 978)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DoctorDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DoctorDashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dctrlblTime As System.Windows.Forms.Label
    Friend WithEvents dctrlblDate As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents dctrlblFname As System.Windows.Forms.Label
    Friend WithEvents dctrlblDoctor As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnConsultation As System.Windows.Forms.Button
    Friend WithEvents btnSurgery As System.Windows.Forms.Button
    Friend WithEvents btnLabAndRadrslt As System.Windows.Forms.Button
    Friend WithEvents btnAppointment As System.Windows.Forms.Button
    Friend WithEvents btnDiagnosis As System.Windows.Forms.Button
    Friend WithEvents btnPrescription As System.Windows.Forms.Button
    Friend WithEvents btnProfile As System.Windows.Forms.Button
End Class
