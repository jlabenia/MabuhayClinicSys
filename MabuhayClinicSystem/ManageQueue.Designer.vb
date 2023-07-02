<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageQueue
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvAppoinmnt = New System.Windows.Forms.DataGridView()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.mqlblTime = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.mqlblContactNum = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.mqlblAddress = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.mqlblGender = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.mqlblFullname = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.mqlblDate = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.mqlblCategory = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.mqlblTokenNum = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.mqbtnPlay = New System.Windows.Forms.Button()
        Me.mqbtnNotify = New System.Windows.Forms.Button()
        Me.mqbtnNext = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.mqlblNumber3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.mqlblNumber2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.mqlblNumber1 = New System.Windows.Forms.Label()
        Me.mqlblNowServing = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvQueue = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.timerNext = New System.Windows.Forms.Timer(Me.components)
        Me.timerNotify = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvAppoinmnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvQueue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvAppoinmnt)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(689, 375)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(715, 350)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Appointment"
        '
        'dgvAppoinmnt
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvAppoinmnt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAppoinmnt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAppoinmnt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAppoinmnt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAppoinmnt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAppoinmnt.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAppoinmnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAppoinmnt.EnableHeadersVisualStyles = False
        Me.dgvAppoinmnt.Location = New System.Drawing.Point(3, 23)
        Me.dgvAppoinmnt.MultiSelect = False
        Me.dgvAppoinmnt.Name = "dgvAppoinmnt"
        Me.dgvAppoinmnt.RowTemplate.Height = 24
        Me.dgvAppoinmnt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAppoinmnt.Size = New System.Drawing.Size(709, 324)
        Me.dgvAppoinmnt.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.AutoSize = True
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel9.Location = New System.Drawing.Point(0, 728)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1404, 0)
        Me.Panel9.TabIndex = 13
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.GroupBox13)
        Me.Panel6.Controls.Add(Me.GroupBox12)
        Me.Panel6.Controls.Add(Me.GroupBox11)
        Me.Panel6.Controls.Add(Me.GroupBox10)
        Me.Panel6.Controls.Add(Me.GroupBox9)
        Me.Panel6.Controls.Add(Me.GroupBox8)
        Me.Panel6.Controls.Add(Me.GroupBox7)
        Me.Panel6.Controls.Add(Me.GroupBox6)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(649, 36)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(753, 331)
        Me.Panel6.TabIndex = 9
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Panel16)
        Me.GroupBox13.Location = New System.Drawing.Point(505, 73)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(212, 56)
        Me.GroupBox13.TabIndex = 15
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "TIME"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.Silver
        Me.Panel16.Controls.Add(Me.mqlblTime)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel16.Location = New System.Drawing.Point(3, 18)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(206, 35)
        Me.Panel16.TabIndex = 0
        '
        'mqlblTime
        '
        Me.mqlblTime.BackColor = System.Drawing.Color.White
        Me.mqlblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mqlblTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mqlblTime.Font = New System.Drawing.Font("Arial", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblTime.ForeColor = System.Drawing.Color.ForestGreen
        Me.mqlblTime.Location = New System.Drawing.Point(0, 0)
        Me.mqlblTime.Name = "mqlblTime"
        Me.mqlblTime.Size = New System.Drawing.Size(206, 35)
        Me.mqlblTime.TabIndex = 10
        Me.mqlblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Panel15)
        Me.GroupBox12.Location = New System.Drawing.Point(505, 145)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(212, 56)
        Me.GroupBox12.TabIndex = 14
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "CONTACT NUMBER"
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.Silver
        Me.Panel15.Controls.Add(Me.mqlblContactNum)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel15.Location = New System.Drawing.Point(3, 18)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(206, 35)
        Me.Panel15.TabIndex = 0
        '
        'mqlblContactNum
        '
        Me.mqlblContactNum.BackColor = System.Drawing.Color.White
        Me.mqlblContactNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mqlblContactNum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mqlblContactNum.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblContactNum.Location = New System.Drawing.Point(0, 0)
        Me.mqlblContactNum.Name = "mqlblContactNum"
        Me.mqlblContactNum.Size = New System.Drawing.Size(206, 35)
        Me.mqlblContactNum.TabIndex = 10
        Me.mqlblContactNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Panel14)
        Me.GroupBox11.Location = New System.Drawing.Point(28, 145)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(456, 56)
        Me.GroupBox11.TabIndex = 13
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "ADDRESS"
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Silver
        Me.Panel14.Controls.Add(Me.mqlblAddress)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(3, 18)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(450, 35)
        Me.Panel14.TabIndex = 0
        '
        'mqlblAddress
        '
        Me.mqlblAddress.BackColor = System.Drawing.Color.White
        Me.mqlblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mqlblAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mqlblAddress.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblAddress.Location = New System.Drawing.Point(0, 0)
        Me.mqlblAddress.Name = "mqlblAddress"
        Me.mqlblAddress.Size = New System.Drawing.Size(450, 35)
        Me.mqlblAddress.TabIndex = 10
        Me.mqlblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Panel13)
        Me.GroupBox10.Location = New System.Drawing.Point(333, 73)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(148, 56)
        Me.GroupBox10.TabIndex = 12
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "GENDER"
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Silver
        Me.Panel13.Controls.Add(Me.mqlblGender)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(3, 18)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(142, 35)
        Me.Panel13.TabIndex = 0
        '
        'mqlblGender
        '
        Me.mqlblGender.BackColor = System.Drawing.Color.White
        Me.mqlblGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mqlblGender.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mqlblGender.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblGender.Location = New System.Drawing.Point(0, 0)
        Me.mqlblGender.Name = "mqlblGender"
        Me.mqlblGender.Size = New System.Drawing.Size(142, 35)
        Me.mqlblGender.TabIndex = 10
        Me.mqlblGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Panel12)
        Me.GroupBox9.Location = New System.Drawing.Point(28, 73)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(268, 56)
        Me.GroupBox9.TabIndex = 11
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "FULLNAME"
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Silver
        Me.Panel12.Controls.Add(Me.mqlblFullname)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(3, 18)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(262, 35)
        Me.Panel12.TabIndex = 0
        '
        'mqlblFullname
        '
        Me.mqlblFullname.BackColor = System.Drawing.Color.White
        Me.mqlblFullname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mqlblFullname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mqlblFullname.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblFullname.Location = New System.Drawing.Point(0, 0)
        Me.mqlblFullname.Name = "mqlblFullname"
        Me.mqlblFullname.Size = New System.Drawing.Size(262, 35)
        Me.mqlblFullname.TabIndex = 10
        Me.mqlblFullname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Panel11)
        Me.GroupBox8.Location = New System.Drawing.Point(502, 5)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(215, 56)
        Me.GroupBox8.TabIndex = 10
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "DATE"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Silver
        Me.Panel11.Controls.Add(Me.mqlblDate)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(3, 18)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(209, 35)
        Me.Panel11.TabIndex = 0
        '
        'mqlblDate
        '
        Me.mqlblDate.BackColor = System.Drawing.Color.White
        Me.mqlblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mqlblDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mqlblDate.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblDate.Location = New System.Drawing.Point(0, 0)
        Me.mqlblDate.Name = "mqlblDate"
        Me.mqlblDate.Size = New System.Drawing.Size(209, 35)
        Me.mqlblDate.TabIndex = 10
        Me.mqlblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Panel10)
        Me.GroupBox7.Location = New System.Drawing.Point(274, 5)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(207, 56)
        Me.GroupBox7.TabIndex = 9
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "CATEGORY"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Silver
        Me.Panel10.Controls.Add(Me.mqlblCategory)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(3, 18)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(201, 35)
        Me.Panel10.TabIndex = 0
        '
        'mqlblCategory
        '
        Me.mqlblCategory.BackColor = System.Drawing.Color.White
        Me.mqlblCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mqlblCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mqlblCategory.Font = New System.Drawing.Font("Arial Narrow", 13.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblCategory.ForeColor = System.Drawing.Color.ForestGreen
        Me.mqlblCategory.Location = New System.Drawing.Point(0, 0)
        Me.mqlblCategory.Name = "mqlblCategory"
        Me.mqlblCategory.Size = New System.Drawing.Size(201, 35)
        Me.mqlblCategory.TabIndex = 10
        Me.mqlblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Panel8)
        Me.GroupBox6.Location = New System.Drawing.Point(28, 5)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(194, 56)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "TOKEN"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Silver
        Me.Panel8.Controls.Add(Me.mqlblTokenNum)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 18)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(188, 35)
        Me.Panel8.TabIndex = 0
        '
        'mqlblTokenNum
        '
        Me.mqlblTokenNum.BackColor = System.Drawing.Color.White
        Me.mqlblTokenNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mqlblTokenNum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mqlblTokenNum.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblTokenNum.Location = New System.Drawing.Point(0, 0)
        Me.mqlblTokenNum.Name = "mqlblTokenNum"
        Me.mqlblTokenNum.Size = New System.Drawing.Size(188, 35)
        Me.mqlblTokenNum.TabIndex = 10
        Me.mqlblTokenNum.Text = "0_00"
        Me.mqlblTokenNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel7.Controls.Add(Me.mqbtnPlay)
        Me.Panel7.Controls.Add(Me.mqbtnNotify)
        Me.Panel7.Controls.Add(Me.mqbtnNext)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 214)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(751, 115)
        Me.Panel7.TabIndex = 0
        '
        'mqbtnPlay
        '
        Me.mqbtnPlay.Location = New System.Drawing.Point(515, 12)
        Me.mqbtnPlay.Name = "mqbtnPlay"
        Me.mqbtnPlay.Size = New System.Drawing.Size(222, 91)
        Me.mqbtnPlay.TabIndex = 3
        Me.mqbtnPlay.Text = "PLAY"
        Me.mqbtnPlay.UseVisualStyleBackColor = True
        '
        'mqbtnNotify
        '
        Me.mqbtnNotify.Location = New System.Drawing.Point(265, 12)
        Me.mqbtnNotify.Name = "mqbtnNotify"
        Me.mqbtnNotify.Size = New System.Drawing.Size(222, 91)
        Me.mqbtnNotify.TabIndex = 2
        Me.mqbtnNotify.Text = "NOTIFY"
        Me.mqbtnNotify.UseVisualStyleBackColor = True
        '
        'mqbtnNext
        '
        Me.mqbtnNext.Location = New System.Drawing.Point(19, 12)
        Me.mqbtnNext.Name = "mqbtnNext"
        Me.mqbtnNext.Size = New System.Drawing.Size(222, 91)
        Me.mqbtnNext.TabIndex = 0
        Me.mqbtnNext.Text = "NEXT"
        Me.mqbtnNext.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Panel5)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 254)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(194, 100)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "3"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Controls.Add(Me.mqlblNumber3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 18)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(188, 79)
        Me.Panel5.TabIndex = 0
        '
        'mqlblNumber3
        '
        Me.mqlblNumber3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblNumber3.ForeColor = System.Drawing.Color.Black
        Me.mqlblNumber3.Location = New System.Drawing.Point(3, 3)
        Me.mqlblNumber3.Name = "mqlblNumber3"
        Me.mqlblNumber3.Size = New System.Drawing.Size(182, 72)
        Me.mqlblNumber3.TabIndex = 10
        Me.mqlblNumber3.Text = "0_00"
        Me.mqlblNumber3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Panel4)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 148)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(194, 100)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "2"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Silver
        Me.Panel4.Controls.Add(Me.mqlblNumber2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 18)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(188, 79)
        Me.Panel4.TabIndex = 0
        '
        'mqlblNumber2
        '
        Me.mqlblNumber2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblNumber2.ForeColor = System.Drawing.Color.Black
        Me.mqlblNumber2.Location = New System.Drawing.Point(3, 2)
        Me.mqlblNumber2.Name = "mqlblNumber2"
        Me.mqlblNumber2.Size = New System.Drawing.Size(182, 72)
        Me.mqlblNumber2.TabIndex = 10
        Me.mqlblNumber2.Text = "0_00"
        Me.mqlblNumber2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel3)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(194, 100)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.Controls.Add(Me.mqlblNumber1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 18)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(188, 79)
        Me.Panel3.TabIndex = 0
        '
        'mqlblNumber1
        '
        Me.mqlblNumber1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblNumber1.ForeColor = System.Drawing.Color.Black
        Me.mqlblNumber1.Location = New System.Drawing.Point(3, 1)
        Me.mqlblNumber1.Name = "mqlblNumber1"
        Me.mqlblNumber1.Size = New System.Drawing.Size(182, 72)
        Me.mqlblNumber1.TabIndex = 9
        Me.mqlblNumber1.Text = "0_00"
        Me.mqlblNumber1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mqlblNowServing
        '
        Me.mqlblNowServing.AutoSize = True
        Me.mqlblNowServing.Font = New System.Drawing.Font("Arial Rounded MT Bold", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mqlblNowServing.ForeColor = System.Drawing.Color.White
        Me.mqlblNowServing.Location = New System.Drawing.Point(349, 193)
        Me.mqlblNowServing.Name = "mqlblNowServing"
        Me.mqlblNowServing.Size = New System.Drawing.Size(135, 55)
        Me.mqlblNowServing.TabIndex = 5
        Me.mqlblNowServing.Text = "0_00"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(267, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(339, 50)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "NOW SERVING"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1402, 36)
        Me.Panel2.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(1402, 36)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "MANAGE QUEUE"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvQueue)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 375)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(671, 350)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "On Queue"
        '
        'dgvQueue
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvQueue.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvQueue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQueue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQueue.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvQueue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvQueue.EnableHeadersVisualStyles = False
        Me.dgvQueue.Location = New System.Drawing.Point(3, 23)
        Me.dgvQueue.MultiSelect = False
        Me.dgvQueue.Name = "dgvQueue"
        Me.dgvQueue.RowTemplate.Height = 24
        Me.dgvQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQueue.Size = New System.Drawing.Size(665, 324)
        Me.dgvQueue.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Pink
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.mqlblNowServing)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1404, 369)
        Me.Panel1.TabIndex = 14
        '
        'timerNext
        '
        Me.timerNext.Interval = 200
        '
        'timerNotify
        '
        Me.timerNotify.Interval = 200
        '
        'ManageQueue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1404, 728)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ManageQueue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ManageQueue"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvAppoinmnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvQueue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvAppoinmnt As System.Windows.Forms.DataGridView
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents mqbtnPlay As System.Windows.Forms.Button
    Friend WithEvents mqbtnNotify As System.Windows.Forms.Button
    Friend WithEvents mqbtnNext As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents mqlblNumber3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents mqlblNumber2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents mqlblNumber1 As System.Windows.Forms.Label
    Friend WithEvents mqlblNowServing As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvQueue As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents mqlblTokenNum As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents mqlblCategory As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents mqlblFullname As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents mqlblDate As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents mqlblAddress As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents mqlblGender As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents mqlblContactNum As System.Windows.Forms.Label
    Friend WithEvents timerNext As System.Windows.Forms.Timer
    Friend WithEvents timerNotify As System.Windows.Forms.Timer
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents mqlblTime As System.Windows.Forms.Label
End Class
