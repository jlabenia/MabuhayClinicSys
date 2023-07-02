<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminDashboard
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblAdminName = New System.Windows.Forms.Label()
        Me.lblAdminUser = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnUserActivity = New System.Windows.Forms.Button()
        Me.btnLoghistory = New System.Windows.Forms.Button()
        Me.btnMUsers = New System.Windows.Forms.Button()
        Me.btnMClinic = New System.Windows.Forms.Button()
        Me.btnMPharmacy = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.lblAdminName)
        Me.Panel2.Controls.Add(Me.lblAdminUser)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(251, 198)
        Me.Panel2.TabIndex = 1
        '
        'lblAdminName
        '
        Me.lblAdminName.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdminName.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblAdminName.Location = New System.Drawing.Point(2, 151)
        Me.lblAdminName.Name = "lblAdminName"
        Me.lblAdminName.Size = New System.Drawing.Size(242, 23)
        Me.lblAdminName.TabIndex = 5
        Me.lblAdminName.Text = "My Name id Admin"
        Me.lblAdminName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAdminUser
        '
        Me.lblAdminUser.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdminUser.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblAdminUser.Location = New System.Drawing.Point(9, 120)
        Me.lblAdminUser.Name = "lblAdminUser"
        Me.lblAdminUser.Size = New System.Drawing.Size(227, 23)
        Me.lblAdminUser.TabIndex = 3
        Me.lblAdminUser.Text = "ADMIN"
        Me.lblAdminUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnReports)
        Me.Panel1.Controls.Add(Me.btnUserActivity)
        Me.Panel1.Controls.Add(Me.btnLoghistory)
        Me.Panel1.Controls.Add(Me.btnMUsers)
        Me.Panel1.Controls.Add(Me.btnMClinic)
        Me.Panel1.Controls.Add(Me.btnMPharmacy)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(253, 978)
        Me.Panel1.TabIndex = 1
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
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(253, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1036, 64)
        Me.Panel3.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1034, 64)
        Me.Label1.TabIndex = 5
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
        Me.Panel4.TabIndex = 4
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.lblDate)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.Location = New System.Drawing.Point(583, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(451, 96)
        Me.Panel6.TabIndex = 4
        '
        'lblDate
        '
        Me.lblDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDate.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(0, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(449, 94)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "DATE: MUNDAY, 03-23-2023"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.lblTime)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(583, 96)
        Me.Panel5.TabIndex = 4
        '
        'lblTime
        '
        Me.lblTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTime.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(0, 0)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(581, 94)
        Me.lblTime.TabIndex = 6
        Me.lblTime.Text = "01:00 PM"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'btnReports
        '
        Me.btnReports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnReports.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.Image = Global.MabuhayClinicSystem.My.Resources.Resources.icons8_print_65
        Me.btnReports.Location = New System.Drawing.Point(0, 848)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(251, 128)
        Me.btnReports.TabIndex = 8
        Me.btnReports.Text = "REPORTS"
        Me.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnReports.UseVisualStyleBackColor = True
        '
        'btnUserActivity
        '
        Me.btnUserActivity.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnUserActivity.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUserActivity.Image = Global.MabuhayClinicSystem.My.Resources.Resources.icons8_log_65__1_
        Me.btnUserActivity.Location = New System.Drawing.Point(0, 720)
        Me.btnUserActivity.Name = "btnUserActivity"
        Me.btnUserActivity.Size = New System.Drawing.Size(251, 128)
        Me.btnUserActivity.TabIndex = 7
        Me.btnUserActivity.Text = "USER ACTIVITY"
        Me.btnUserActivity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUserActivity.UseVisualStyleBackColor = True
        '
        'btnLoghistory
        '
        Me.btnLoghistory.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnLoghistory.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoghistory.Image = Global.MabuhayClinicSystem.My.Resources.Resources.icons8_log_65
        Me.btnLoghistory.Location = New System.Drawing.Point(0, 592)
        Me.btnLoghistory.Name = "btnLoghistory"
        Me.btnLoghistory.Size = New System.Drawing.Size(251, 128)
        Me.btnLoghistory.TabIndex = 6
        Me.btnLoghistory.Text = "LOG HISTORY"
        Me.btnLoghistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLoghistory.UseVisualStyleBackColor = True
        '
        'btnMUsers
        '
        Me.btnMUsers.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMUsers.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMUsers.Image = Global.MabuhayClinicSystem.My.Resources.Resources.icons8_password_85
        Me.btnMUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMUsers.Location = New System.Drawing.Point(0, 464)
        Me.btnMUsers.Name = "btnMUsers"
        Me.btnMUsers.Size = New System.Drawing.Size(251, 128)
        Me.btnMUsers.TabIndex = 5
        Me.btnMUsers.Text = "MANAGE USERS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnMUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMUsers.UseVisualStyleBackColor = True
        '
        'btnMClinic
        '
        Me.btnMClinic.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMClinic.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMClinic.Image = Global.MabuhayClinicSystem.My.Resources.Resources.icons8_clinic_65
        Me.btnMClinic.Location = New System.Drawing.Point(0, 336)
        Me.btnMClinic.Name = "btnMClinic"
        Me.btnMClinic.Size = New System.Drawing.Size(251, 128)
        Me.btnMClinic.TabIndex = 4
        Me.btnMClinic.Text = "MANAGE CLINIC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnMClinic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMClinic.UseVisualStyleBackColor = True
        '
        'btnMPharmacy
        '
        Me.btnMPharmacy.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMPharmacy.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMPharmacy.Image = Global.MabuhayClinicSystem.My.Resources.Resources.icons8_pharmacy_shop_65
        Me.btnMPharmacy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMPharmacy.Location = New System.Drawing.Point(0, 208)
        Me.btnMPharmacy.Name = "btnMPharmacy"
        Me.btnMPharmacy.Size = New System.Drawing.Size(251, 128)
        Me.btnMPharmacy.TabIndex = 3
        Me.btnMPharmacy.Text = "MANAGE PHARMACY" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnMPharmacy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMPharmacy.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Administrator_Male_80px
        Me.Label2.Location = New System.Drawing.Point(62, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 100)
        Me.Label2.TabIndex = 4
        '
        'AdminDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1289, 978)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AdminDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdminDashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblAdminName As System.Windows.Forms.Label
    Friend WithEvents lblAdminUser As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnReports As System.Windows.Forms.Button
    Friend WithEvents btnUserActivity As System.Windows.Forms.Button
    Friend WithEvents btnLoghistory As System.Windows.Forms.Button
    Friend WithEvents btnMUsers As System.Windows.Forms.Button
    Friend WithEvents btnMClinic As System.Windows.Forms.Button
    Friend WithEvents btnMPharmacy As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
