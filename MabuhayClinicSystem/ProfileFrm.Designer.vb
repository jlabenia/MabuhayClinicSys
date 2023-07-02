<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfileFrm
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.upiLname = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.upiGender = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.upiDOByear = New System.Windows.Forms.ComboBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.upiDOBMonth = New System.Windows.Forms.ComboBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.upiDOBday = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.upiCnum = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.upiAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.upiAge = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.upiMname = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.upiFname = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.upiCheckbox = New System.Windows.Forms.CheckBox()
        Me.upibtnUpdate = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.upiLname)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(553, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 58)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Last name"
        '
        'upiLname
        '
        Me.upiLname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upiLname.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upiLname.Location = New System.Drawing.Point(3, 26)
        Me.upiLname.MaxLength = 15
        Me.upiLname.Multiline = True
        Me.upiLname.Name = "upiLname"
        Me.upiLname.Size = New System.Drawing.Size(244, 29)
        Me.upiLname.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.upiGender)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(15, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(250, 58)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gender"
        '
        'upiGender
        '
        Me.upiGender.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upiGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.upiGender.FormattingEnabled = True
        Me.upiGender.IntegralHeight = False
        Me.upiGender.ItemHeight = 23
        Me.upiGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.upiGender.Location = New System.Drawing.Point(3, 26)
        Me.upiGender.Name = "upiGender"
        Me.upiGender.Size = New System.Drawing.Size(244, 29)
        Me.upiGender.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox11)
        Me.GroupBox3.Controls.Add(Me.GroupBox10)
        Me.GroupBox3.Controls.Add(Me.GroupBox9)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(15, 145)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(476, 95)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DOB"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.upiDOByear)
        Me.GroupBox11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(328, 27)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(124, 58)
        Me.GroupBox11.TabIndex = 25
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Year"
        '
        'upiDOByear
        '
        Me.upiDOByear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upiDOByear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.upiDOByear.FormattingEnabled = True
        Me.upiDOByear.IntegralHeight = False
        Me.upiDOByear.ItemHeight = 23
        Me.upiDOByear.Location = New System.Drawing.Point(3, 26)
        Me.upiDOByear.Name = "upiDOByear"
        Me.upiDOByear.Size = New System.Drawing.Size(118, 29)
        Me.upiDOByear.TabIndex = 0
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.upiDOBMonth)
        Me.GroupBox10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(128, 27)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(177, 58)
        Me.GroupBox10.TabIndex = 25
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Month"
        '
        'upiDOBMonth
        '
        Me.upiDOBMonth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upiDOBMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.upiDOBMonth.FormattingEnabled = True
        Me.upiDOBMonth.Items.AddRange(New Object() {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"})
        Me.upiDOBMonth.Location = New System.Drawing.Point(3, 26)
        Me.upiDOBMonth.Name = "upiDOBMonth"
        Me.upiDOBMonth.Size = New System.Drawing.Size(171, 29)
        Me.upiDOBMonth.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.upiDOBday)
        Me.GroupBox9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(25, 27)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(85, 58)
        Me.GroupBox9.TabIndex = 24
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Day"
        '
        'upiDOBday
        '
        Me.upiDOBday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upiDOBday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.upiDOBday.FormattingEnabled = True
        Me.upiDOBday.IntegralHeight = False
        Me.upiDOBday.Location = New System.Drawing.Point(3, 26)
        Me.upiDOBday.Name = "upiDOBday"
        Me.upiDOBday.Size = New System.Drawing.Size(79, 29)
        Me.upiDOBday.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.upiCnum)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(289, 79)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(250, 58)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Contact number"
        '
        'upiCnum
        '
        Me.upiCnum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upiCnum.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upiCnum.Location = New System.Drawing.Point(3, 26)
        Me.upiCnum.MaxLength = 11
        Me.upiCnum.Multiline = True
        Me.upiCnum.Name = "upiCnum"
        Me.upiCnum.Size = New System.Drawing.Size(244, 29)
        Me.upiCnum.TabIndex = 9
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.upiAddress)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 246)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(479, 116)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Address"
        '
        'upiAddress
        '
        Me.upiAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upiAddress.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upiAddress.Location = New System.Drawing.Point(3, 26)
        Me.upiAddress.MaxLength = 300
        Me.upiAddress.Multiline = True
        Me.upiAddress.Name = "upiAddress"
        Me.upiAddress.Size = New System.Drawing.Size(473, 87)
        Me.upiAddress.TabIndex = 9
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.upiAge)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(556, 79)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(110, 58)
        Me.GroupBox6.TabIndex = 19
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Age"
        '
        'upiAge
        '
        Me.upiAge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upiAge.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upiAge.Location = New System.Drawing.Point(3, 26)
        Me.upiAge.Multiline = True
        Me.upiAge.Name = "upiAge"
        Me.upiAge.Size = New System.Drawing.Size(104, 29)
        Me.upiAge.TabIndex = 9
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.upiMname)
        Me.GroupBox7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(286, 15)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(250, 58)
        Me.GroupBox7.TabIndex = 23
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Middle name"
        '
        'upiMname
        '
        Me.upiMname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upiMname.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upiMname.Location = New System.Drawing.Point(3, 26)
        Me.upiMname.MaxLength = 15
        Me.upiMname.Multiline = True
        Me.upiMname.Name = "upiMname"
        Me.upiMname.Size = New System.Drawing.Size(244, 29)
        Me.upiMname.TabIndex = 9
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.upiFname)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(18, 15)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(250, 58)
        Me.GroupBox8.TabIndex = 22
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "First name"
        '
        'upiFname
        '
        Me.upiFname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.upiFname.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upiFname.Location = New System.Drawing.Point(3, 26)
        Me.upiFname.MaxLength = 15
        Me.upiFname.Multiline = True
        Me.upiFname.Name = "upiFname"
        Me.upiFname.Size = New System.Drawing.Size(244, 29)
        Me.upiFname.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Pink
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.upiCheckbox)
        Me.Panel1.Controls.Add(Me.upibtnUpdate)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox7)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox8)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Location = New System.Drawing.Point(7, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(912, 377)
        Me.Panel1.TabIndex = 24
        '
        'upiCheckbox
        '
        Me.upiCheckbox.AutoSize = True
        Me.upiCheckbox.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upiCheckbox.ForeColor = System.Drawing.Color.Blue
        Me.upiCheckbox.Location = New System.Drawing.Point(580, 295)
        Me.upiCheckbox.Name = "upiCheckbox"
        Me.upiCheckbox.Size = New System.Drawing.Size(207, 21)
        Me.upiCheckbox.TabIndex = 25
        Me.upiCheckbox.Text = "Click here to edit text fields."
        Me.upiCheckbox.UseVisualStyleBackColor = True
        '
        'upibtnUpdate
        '
        Me.upibtnUpdate.Enabled = False
        Me.upibtnUpdate.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upibtnUpdate.Location = New System.Drawing.Point(580, 216)
        Me.upibtnUpdate.Name = "upibtnUpdate"
        Me.upibtnUpdate.Size = New System.Drawing.Size(266, 73)
        Me.upibtnUpdate.TabIndex = 24
        Me.upibtnUpdate.Text = "UPDATE"
        Me.upibtnUpdate.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(927, 46)
        Me.Panel2.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(927, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "USER PROFILE INFORMATION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProfileFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(927, 435)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "ProfileFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProfileFrm"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents upiLname As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents upiCnum As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents upiAddress As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents upiAge As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents upiMname As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents upiFname As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents upibtnUpdate As System.Windows.Forms.Button
    Friend WithEvents upiCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents upiDOByear As System.Windows.Forms.ComboBox
    Friend WithEvents upiDOBMonth As System.Windows.Forms.ComboBox
    Friend WithEvents upiDOBday As System.Windows.Forms.ComboBox
    Friend WithEvents upiGender As System.Windows.Forms.ComboBox
End Class
