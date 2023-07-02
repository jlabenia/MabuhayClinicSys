<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.cbxRemember = New System.Windows.Forms.CheckBox()
        Me.cboxView = New System.Windows.Forms.CheckBox()
        Me.linkChangePass = New System.Windows.Forms.LinkLabel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbxRemember
        '
        Me.cbxRemember.AutoSize = True
        Me.cbxRemember.Location = New System.Drawing.Point(135, 457)
        Me.cbxRemember.Name = "cbxRemember"
        Me.cbxRemember.Size = New System.Drawing.Size(122, 21)
        Me.cbxRemember.TabIndex = 23
        Me.cbxRemember.Text = "Remember Me"
        Me.cbxRemember.UseVisualStyleBackColor = True
        '
        'cboxView
        '
        Me.cboxView.AutoSize = True
        Me.cboxView.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Show_Password_32px
        Me.cboxView.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.cboxView.Location = New System.Drawing.Point(464, 289)
        Me.cboxView.Name = "cboxView"
        Me.cboxView.Size = New System.Drawing.Size(50, 32)
        Me.cboxView.TabIndex = 22
        Me.cboxView.UseVisualStyleBackColor = True
        '
        'linkChangePass
        '
        Me.linkChangePass.AutoSize = True
        Me.linkChangePass.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkChangePass.Location = New System.Drawing.Point(216, 497)
        Me.linkChangePass.Name = "linkChangePass"
        Me.linkChangePass.Size = New System.Drawing.Size(144, 24)
        Me.linkChangePass.TabIndex = 21
        Me.linkChangePass.TabStop = True
        Me.linkChangePass.Text = "Change Password"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Pink
        Me.btnClear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(135, 403)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(323, 48)
        Me.btnClear.TabIndex = 20
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnEnter
        '
        Me.btnEnter.BackColor = System.Drawing.Color.Pink
        Me.btnEnter.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.Location = New System.Drawing.Point(135, 349)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(323, 48)
        Me.btnEnter.TabIndex = 19
        Me.btnEnter.Text = "ENTER"
        Me.btnEnter.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label4.Location = New System.Drawing.Point(0, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(574, 39)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Sign In"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txtPass.Location = New System.Drawing.Point(135, 286)
        Me.txtPass.Multiline = True
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(323, 42)
        Me.txtPass.TabIndex = 17
        Me.txtPass.Text = "Password"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Pink
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(574, 100)
        Me.FlowLayoutPanel1.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Pink
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(571, 100)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Saint Francis of Assissi Mabuhay Clinic Management System"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtUname
        '
        Me.txtUname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUname.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txtUname.Location = New System.Drawing.Point(135, 228)
        Me.txtUname.Multiline = True
        Me.txtUname.Name = "txtUname"
        Me.txtUname.Size = New System.Drawing.Size(323, 42)
        Me.txtUname.TabIndex = 14
        Me.txtUname.Text = "Username"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Password_48px
        Me.Label3.Location = New System.Drawing.Point(73, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 50)
        Me.Label3.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Image = Global.MabuhayClinicSystem.My.Resources.Resources.Username
        Me.Label2.Location = New System.Drawing.Point(73, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 50)
        Me.Label2.TabIndex = 13
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 675)
        Me.Controls.Add(Me.cbxRemember)
        Me.Controls.Add(Me.cboxView)
        Me.Controls.Add(Me.linkChangePass)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnEnter)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.txtUname)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxRemember As System.Windows.Forms.CheckBox
    Friend WithEvents cboxView As System.Windows.Forms.CheckBox
    Friend WithEvents linkChangePass As System.Windows.Forms.LinkLabel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
