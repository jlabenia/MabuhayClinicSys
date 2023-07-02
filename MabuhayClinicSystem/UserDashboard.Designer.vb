<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserDashboard
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
        Me.udlblFname = New System.Windows.Forms.Label()
        Me.udlblCategory = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.udbtnProfile = New System.Windows.Forms.Button()
        Me.udbtnPharmacy = New System.Windows.Forms.Button()
        Me.udbtnlbtests = New System.Windows.Forms.Button()
        Me.udbtnVitalSign = New System.Windows.Forms.Button()
        Me.udbtnPatientRcrd = New System.Windows.Forms.Button()
        Me.udbtnAppointment = New System.Windows.Forms.Button()
        Me.udbtnQueue = New System.Windows.Forms.Button()
        Me.udlblDate = New System.Windows.Forms.Label()
        Me.udlblTime = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.udlblTitle = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.udTimer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'udlblFname
        '
        Me.udlblFname.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udlblFname.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.udlblFname.Location = New System.Drawing.Point(2, 139)
        Me.udlblFname.Name = "udlblFname"
        Me.udlblFname.Size = New System.Drawing.Size(251, 23)
        Me.udlblFname.TabIndex = 2
        Me.udlblFname.Text = "Jason Labenia"
        Me.udlblFname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'udlblCategory
        '
        Me.udlblCategory.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udlblCategory.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.udlblCategory.Location = New System.Drawing.Point(1, 108)
        Me.udlblCategory.Name = "udlblCategory"
        Me.udlblCategory.Size = New System.Drawing.Size(251, 23)
        Me.udlblCategory.TabIndex = 1
        Me.udlblCategory.Text = "USER: Front Desk"
        Me.udlblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.udlblFname)
        Me.Panel2.Controls.Add(Me.udlblCategory)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(253, 198)
        Me.Panel2.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Medical_Doctor_80px
        Me.Label1.Location = New System.Drawing.Point(66, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 100)
        Me.Label1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 978)
        Me.Panel1.TabIndex = 18
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.udbtnProfile)
        Me.Panel3.Controls.Add(Me.udbtnPharmacy)
        Me.Panel3.Controls.Add(Me.udbtnlbtests)
        Me.Panel3.Controls.Add(Me.udbtnVitalSign)
        Me.Panel3.Controls.Add(Me.udbtnPatientRcrd)
        Me.Panel3.Controls.Add(Me.udbtnAppointment)
        Me.Panel3.Controls.Add(Me.udbtnQueue)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 198)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(253, 778)
        Me.Panel3.TabIndex = 12
        '
        'udbtnProfile
        '
        Me.udbtnProfile.BackColor = System.Drawing.Color.WhiteSmoke
        Me.udbtnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.udbtnProfile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.udbtnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.udbtnProfile.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udbtnProfile.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Contact_Info_65px
        Me.udbtnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.udbtnProfile.Location = New System.Drawing.Point(0, 660)
        Me.udbtnProfile.Name = "udbtnProfile"
        Me.udbtnProfile.Size = New System.Drawing.Size(251, 116)
        Me.udbtnProfile.TabIndex = 12
        Me.udbtnProfile.Text = "USER PROFILE"
        Me.udbtnProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.udbtnProfile.UseVisualStyleBackColor = False
        '
        'udbtnPharmacy
        '
        Me.udbtnPharmacy.BackColor = System.Drawing.Color.WhiteSmoke
        Me.udbtnPharmacy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.udbtnPharmacy.Dock = System.Windows.Forms.DockStyle.Top
        Me.udbtnPharmacy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.udbtnPharmacy.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udbtnPharmacy.Image = Global.MabuhayClinicSystem.My.Resources.Resources.POS_Terminal_65px
        Me.udbtnPharmacy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.udbtnPharmacy.Location = New System.Drawing.Point(0, 550)
        Me.udbtnPharmacy.Name = "udbtnPharmacy"
        Me.udbtnPharmacy.Size = New System.Drawing.Size(251, 110)
        Me.udbtnPharmacy.TabIndex = 17
        Me.udbtnPharmacy.Text = "PHARMACY"
        Me.udbtnPharmacy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.udbtnPharmacy.UseVisualStyleBackColor = False
        '
        'udbtnlbtests
        '
        Me.udbtnlbtests.BackColor = System.Drawing.Color.WhiteSmoke
        Me.udbtnlbtests.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.udbtnlbtests.Dock = System.Windows.Forms.DockStyle.Top
        Me.udbtnlbtests.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.udbtnlbtests.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udbtnlbtests.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Pass_Fail_65px
        Me.udbtnlbtests.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.udbtnlbtests.Location = New System.Drawing.Point(0, 440)
        Me.udbtnlbtests.Name = "udbtnlbtests"
        Me.udbtnlbtests.Size = New System.Drawing.Size(251, 110)
        Me.udbtnlbtests.TabIndex = 16
        Me.udbtnlbtests.Text = "TEST RESULTS"
        Me.udbtnlbtests.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.udbtnlbtests.UseVisualStyleBackColor = False
        '
        'udbtnVitalSign
        '
        Me.udbtnVitalSign.BackColor = System.Drawing.Color.WhiteSmoke
        Me.udbtnVitalSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.udbtnVitalSign.Dock = System.Windows.Forms.DockStyle.Top
        Me.udbtnVitalSign.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.udbtnVitalSign.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udbtnVitalSign.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Hypertension_65px
        Me.udbtnVitalSign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.udbtnVitalSign.Location = New System.Drawing.Point(0, 330)
        Me.udbtnVitalSign.Name = "udbtnVitalSign"
        Me.udbtnVitalSign.Size = New System.Drawing.Size(251, 110)
        Me.udbtnVitalSign.TabIndex = 14
        Me.udbtnVitalSign.Text = "VITAL SIGNS"
        Me.udbtnVitalSign.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.udbtnVitalSign.UseVisualStyleBackColor = False
        '
        'udbtnPatientRcrd
        '
        Me.udbtnPatientRcrd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.udbtnPatientRcrd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.udbtnPatientRcrd.Dock = System.Windows.Forms.DockStyle.Top
        Me.udbtnPatientRcrd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.udbtnPatientRcrd.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udbtnPatientRcrd.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Folder_65px
        Me.udbtnPatientRcrd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.udbtnPatientRcrd.Location = New System.Drawing.Point(0, 220)
        Me.udbtnPatientRcrd.Name = "udbtnPatientRcrd"
        Me.udbtnPatientRcrd.Size = New System.Drawing.Size(251, 110)
        Me.udbtnPatientRcrd.TabIndex = 13
        Me.udbtnPatientRcrd.Text = "PATIENT RECORD"
        Me.udbtnPatientRcrd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.udbtnPatientRcrd.UseVisualStyleBackColor = False
        '
        'udbtnAppointment
        '
        Me.udbtnAppointment.BackColor = System.Drawing.Color.WhiteSmoke
        Me.udbtnAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.udbtnAppointment.Dock = System.Windows.Forms.DockStyle.Top
        Me.udbtnAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.udbtnAppointment.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udbtnAppointment.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Schedule1_65px
        Me.udbtnAppointment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.udbtnAppointment.Location = New System.Drawing.Point(0, 110)
        Me.udbtnAppointment.Name = "udbtnAppointment"
        Me.udbtnAppointment.Size = New System.Drawing.Size(251, 110)
        Me.udbtnAppointment.TabIndex = 15
        Me.udbtnAppointment.Text = "APPOINTMENT"
        Me.udbtnAppointment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.udbtnAppointment.UseVisualStyleBackColor = False
        '
        'udbtnQueue
        '
        Me.udbtnQueue.BackColor = System.Drawing.Color.WhiteSmoke
        Me.udbtnQueue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.udbtnQueue.Dock = System.Windows.Forms.DockStyle.Top
        Me.udbtnQueue.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.udbtnQueue.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udbtnQueue.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Queue_65px
        Me.udbtnQueue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.udbtnQueue.Location = New System.Drawing.Point(0, 0)
        Me.udbtnQueue.Name = "udbtnQueue"
        Me.udbtnQueue.Size = New System.Drawing.Size(251, 110)
        Me.udbtnQueue.TabIndex = 10
        Me.udbtnQueue.Text = "QUEUE"
        Me.udbtnQueue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.udbtnQueue.UseVisualStyleBackColor = False
        '
        'udlblDate
        '
        Me.udlblDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.udlblDate.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udlblDate.Location = New System.Drawing.Point(0, 0)
        Me.udlblDate.Name = "udlblDate"
        Me.udlblDate.Size = New System.Drawing.Size(447, 96)
        Me.udlblDate.TabIndex = 1
        Me.udlblDate.Text = "DATE: FIRDAY, 05/30/2023"
        Me.udlblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'udlblTime
        '
        Me.udlblTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.udlblTime.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udlblTime.Location = New System.Drawing.Point(0, 0)
        Me.udlblTime.Name = "udlblTime"
        Me.udlblTime.Size = New System.Drawing.Size(581, 96)
        Me.udlblTime.TabIndex = 0
        Me.udlblTime.Text = "12:42:00 pm"
        Me.udlblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Panel4)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(255, 878)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1034, 100)
        Me.Panel5.TabIndex = 19
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.udlblDate)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(583, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(449, 98)
        Me.Panel4.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.udlblTime)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(583, 98)
        Me.Panel6.TabIndex = 0
        '
        'udlblTitle
        '
        Me.udlblTitle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.udlblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.udlblTitle.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.udlblTitle.ForeColor = System.Drawing.Color.ForestGreen
        Me.udlblTitle.Location = New System.Drawing.Point(0, 0)
        Me.udlblTitle.Name = "udlblTitle"
        Me.udlblTitle.Size = New System.Drawing.Size(1032, 66)
        Me.udlblTitle.TabIndex = 20
        Me.udlblTitle.Text = "SAINT FRANCIS OF ASSISI MABUHAY CLINIC MANAGEMENT SYSTEM"
        Me.udlblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.udlblTitle)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(255, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1034, 68)
        Me.Panel7.TabIndex = 21
        '
        'udTimer1
        '
        '
        'UserDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1289, 978)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Name = "UserDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UserDashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents udbtnPharmacy As System.Windows.Forms.Button
    Friend WithEvents udbtnlbtests As System.Windows.Forms.Button
    Friend WithEvents udbtnQueue As System.Windows.Forms.Button
    Friend WithEvents udbtnAppointment As System.Windows.Forms.Button
    Friend WithEvents udbtnPatientRcrd As System.Windows.Forms.Button
    Friend WithEvents udbtnVitalSign As System.Windows.Forms.Button
    Friend WithEvents udbtnProfile As System.Windows.Forms.Button
    Friend WithEvents udlblFname As System.Windows.Forms.Label
    Friend WithEvents udlblCategory As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents udlblDate As System.Windows.Forms.Label
    Friend WithEvents udlblTime As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents udlblTitle As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents udTimer1 As System.Windows.Forms.Timer
End Class
