<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VitalSigns
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VitalSigns))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.vstxtbxBT = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.vslblAge = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.vslblFname = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.vslblGender = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.vstxtbxBP = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.vstxtbxPR = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.vstxtbxResp = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.vstxtO2sat = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.vstxtbxHeight = New System.Windows.Forms.TextBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.vstxtbxWeight = New System.Windows.Forms.TextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.vscmbxBT = New System.Windows.Forms.ComboBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.vscmbxBP = New System.Windows.Forms.ComboBox()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.vscmbxPR = New System.Windows.Forms.ComboBox()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.vscmbxResp = New System.Windows.Forms.ComboBox()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.vscmbxO2sat = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.vsDGV = New System.Windows.Forms.DataGridView()
        Me.vsbtnSave = New System.Windows.Forms.Button()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.vstxtbxSrchLname = New System.Windows.Forms.TextBox()
        Me.vsbtnUpdate = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtpersonID = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip5 = New System.Windows.Forms.ToolTip(Me.components)
        Me.vsrbRegular = New System.Windows.Forms.RadioButton()
        Me.vsrbAppointment = New System.Windows.Forms.RadioButton()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.vsDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox17.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Pink
        Me.GroupBox9.Controls.Add(Me.vstxtbxBT)
        Me.GroupBox9.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox9.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(359, 48)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox9.TabIndex = 78
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Body temp (°C )"
        '
        'vstxtbxBT
        '
        Me.vstxtbxBT.BackColor = System.Drawing.Color.White
        Me.vstxtbxBT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vstxtbxBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vstxtbxBT.Location = New System.Drawing.Point(3, 23)
        Me.vstxtbxBT.MaxLength = 4
        Me.vstxtbxBT.Multiline = True
        Me.vstxtbxBT.Name = "vstxtbxBT"
        Me.vstxtbxBT.Size = New System.Drawing.Size(172, 29)
        Me.vstxtbxBT.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label8.Location = New System.Drawing.Point(333, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 28)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Vital Signs"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label7.Location = New System.Drawing.Point(13, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(202, 28)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Personal Details"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Pink
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 722)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1247, 10)
        Me.Panel1.TabIndex = 67
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(1377, 46)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "ADD VITAL SIGNS INFO"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Pink
        Me.GroupBox5.Controls.Add(Me.vslblAge)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(18, 106)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(82, 55)
        Me.GroupBox5.TabIndex = 72
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Age"
        '
        'vslblAge
        '
        Me.vslblAge.BackColor = System.Drawing.Color.Pink
        Me.vslblAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vslblAge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vslblAge.Location = New System.Drawing.Point(3, 23)
        Me.vslblAge.Name = "vslblAge"
        Me.vslblAge.Size = New System.Drawing.Size(76, 29)
        Me.vslblAge.TabIndex = 93
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1247, 46)
        Me.Panel2.TabIndex = 85
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Pink
        Me.GroupBox1.Controls.Add(Me.vslblFname)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 55)
        Me.GroupBox1.TabIndex = 86
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Full name"
        '
        'vslblFname
        '
        Me.vslblFname.BackColor = System.Drawing.Color.Pink
        Me.vslblFname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vslblFname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vslblFname.Location = New System.Drawing.Point(3, 23)
        Me.vslblFname.Name = "vslblFname"
        Me.vslblFname.Size = New System.Drawing.Size(238, 29)
        Me.vslblFname.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Pink
        Me.GroupBox2.Controls.Add(Me.vslblGender)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(18, 166)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(165, 55)
        Me.GroupBox2.TabIndex = 87
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gender"
        '
        'vslblGender
        '
        Me.vslblGender.BackColor = System.Drawing.Color.Pink
        Me.vslblGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vslblGender.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vslblGender.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.vslblGender.Location = New System.Drawing.Point(3, 23)
        Me.vslblGender.Name = "vslblGender"
        Me.vslblGender.Size = New System.Drawing.Size(159, 29)
        Me.vslblGender.TabIndex = 92
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Pink
        Me.GroupBox4.Controls.Add(Me.vstxtbxBP)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(359, 109)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox4.TabIndex = 92
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "BP (mmHg)"
        '
        'vstxtbxBP
        '
        Me.vstxtbxBP.BackColor = System.Drawing.Color.White
        Me.vstxtbxBP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vstxtbxBP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vstxtbxBP.Location = New System.Drawing.Point(3, 23)
        Me.vstxtbxBP.MaxLength = 7
        Me.vstxtbxBP.Multiline = True
        Me.vstxtbxBP.Name = "vstxtbxBP"
        Me.vstxtbxBP.Size = New System.Drawing.Size(172, 29)
        Me.vstxtbxBP.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Pink
        Me.GroupBox7.Controls.Add(Me.vstxtbxPR)
        Me.GroupBox7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox7.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(359, 171)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox7.TabIndex = 94
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Pulse rate (bpm)"
        '
        'vstxtbxPR
        '
        Me.vstxtbxPR.BackColor = System.Drawing.Color.White
        Me.vstxtbxPR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vstxtbxPR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vstxtbxPR.Location = New System.Drawing.Point(3, 23)
        Me.vstxtbxPR.MaxLength = 3
        Me.vstxtbxPR.Multiline = True
        Me.vstxtbxPR.Name = "vstxtbxPR"
        Me.vstxtbxPR.Size = New System.Drawing.Size(172, 29)
        Me.vstxtbxPR.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Pink
        Me.GroupBox6.Controls.Add(Me.vstxtbxResp)
        Me.GroupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(813, 45)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox6.TabIndex = 95
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Respiration (bpm)"
        '
        'vstxtbxResp
        '
        Me.vstxtbxResp.BackColor = System.Drawing.Color.White
        Me.vstxtbxResp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vstxtbxResp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vstxtbxResp.Location = New System.Drawing.Point(3, 23)
        Me.vstxtbxResp.MaxLength = 2
        Me.vstxtbxResp.Multiline = True
        Me.vstxtbxResp.Name = "vstxtbxResp"
        Me.vstxtbxResp.Size = New System.Drawing.Size(172, 29)
        Me.vstxtbxResp.TabIndex = 0
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Pink
        Me.GroupBox8.Controls.Add(Me.vstxtO2sat)
        Me.GroupBox8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(813, 104)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox8.TabIndex = 96
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "O2 sat(%)"
        '
        'vstxtO2sat
        '
        Me.vstxtO2sat.BackColor = System.Drawing.Color.White
        Me.vstxtO2sat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vstxtO2sat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vstxtO2sat.Location = New System.Drawing.Point(3, 23)
        Me.vstxtO2sat.MaxLength = 3
        Me.vstxtO2sat.Multiline = True
        Me.vstxtO2sat.Name = "vstxtO2sat"
        Me.vstxtO2sat.Size = New System.Drawing.Size(172, 29)
        Me.vstxtO2sat.TabIndex = 0
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Pink
        Me.GroupBox10.Controls.Add(Me.vstxtbxHeight)
        Me.GroupBox10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox10.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(198, 2)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox10.TabIndex = 97
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Height(cm)"
        '
        'vstxtbxHeight
        '
        Me.vstxtbxHeight.BackColor = System.Drawing.Color.White
        Me.vstxtbxHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vstxtbxHeight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vstxtbxHeight.Location = New System.Drawing.Point(3, 23)
        Me.vstxtbxHeight.MaxLength = 6
        Me.vstxtbxHeight.Multiline = True
        Me.vstxtbxHeight.Name = "vstxtbxHeight"
        Me.vstxtbxHeight.Size = New System.Drawing.Size(172, 29)
        Me.vstxtbxHeight.TabIndex = 0
        Me.vstxtbxHeight.Text = "171.5"
        '
        'GroupBox11
        '
        Me.GroupBox11.BackColor = System.Drawing.Color.Pink
        Me.GroupBox11.Controls.Add(Me.vstxtbxWeight)
        Me.GroupBox11.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox11.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox11.TabIndex = 98
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Weight(kg)"
        '
        'vstxtbxWeight
        '
        Me.vstxtbxWeight.BackColor = System.Drawing.Color.White
        Me.vstxtbxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vstxtbxWeight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vstxtbxWeight.Location = New System.Drawing.Point(3, 23)
        Me.vstxtbxWeight.MaxLength = 6
        Me.vstxtbxWeight.Multiline = True
        Me.vstxtbxWeight.Name = "vstxtbxWeight"
        Me.vstxtbxWeight.Size = New System.Drawing.Size(172, 29)
        Me.vstxtbxWeight.TabIndex = 0
        '
        'GroupBox12
        '
        Me.GroupBox12.BackColor = System.Drawing.Color.Pink
        Me.GroupBox12.Controls.Add(Me.vscmbxBT)
        Me.GroupBox12.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox12.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(558, 48)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox12.TabIndex = 99
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Normal?"
        '
        'vscmbxBT
        '
        Me.vscmbxBT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vscmbxBT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.vscmbxBT.FormattingEnabled = True
        Me.vscmbxBT.Items.AddRange(New Object() {"Yes", "No"})
        Me.vscmbxBT.Location = New System.Drawing.Point(3, 23)
        Me.vscmbxBT.Name = "vscmbxBT"
        Me.vscmbxBT.Size = New System.Drawing.Size(172, 27)
        Me.vscmbxBT.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.vscmbxBT, "Will not exceed below 36.1°C or above 37.2°C" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.Color.Pink
        Me.GroupBox13.Controls.Add(Me.vscmbxBP)
        Me.GroupBox13.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox13.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(558, 109)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox13.TabIndex = 100
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Normal?"
        '
        'vscmbxBP
        '
        Me.vscmbxBP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vscmbxBP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.vscmbxBP.FormattingEnabled = True
        Me.vscmbxBP.Items.AddRange(New Object() {"Yes", "No"})
        Me.vscmbxBP.Location = New System.Drawing.Point(3, 23)
        Me.vscmbxBP.Name = "vscmbxBP"
        Me.vscmbxBP.Size = New System.Drawing.Size(172, 27)
        Me.vscmbxBP.TabIndex = 0
        Me.ToolTip2.SetToolTip(Me.vscmbxBP, "Top number (systolic): <120mmHg/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bottom number (diastolic): <80mmHg")
        '
        'GroupBox14
        '
        Me.GroupBox14.BackColor = System.Drawing.Color.Pink
        Me.GroupBox14.Controls.Add(Me.vscmbxPR)
        Me.GroupBox14.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox14.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox14.Location = New System.Drawing.Point(558, 171)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox14.TabIndex = 101
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Normal?"
        '
        'vscmbxPR
        '
        Me.vscmbxPR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vscmbxPR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.vscmbxPR.FormattingEnabled = True
        Me.vscmbxPR.Items.AddRange(New Object() {"Yes", "No"})
        Me.vscmbxPR.Location = New System.Drawing.Point(3, 23)
        Me.vscmbxPR.Name = "vscmbxPR"
        Me.vscmbxPR.Size = New System.Drawing.Size(172, 27)
        Me.vscmbxPR.TabIndex = 0
        Me.ToolTip3.SetToolTip(Me.vscmbxPR, resources.GetString("vscmbxPR.ToolTip"))
        '
        'GroupBox15
        '
        Me.GroupBox15.BackColor = System.Drawing.Color.Pink
        Me.GroupBox15.Controls.Add(Me.vscmbxResp)
        Me.GroupBox15.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox15.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox15.Location = New System.Drawing.Point(1012, 45)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox15.TabIndex = 102
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Normal?"
        '
        'vscmbxResp
        '
        Me.vscmbxResp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vscmbxResp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.vscmbxResp.FormattingEnabled = True
        Me.vscmbxResp.Items.AddRange(New Object() {"Yes", "No"})
        Me.vscmbxResp.Location = New System.Drawing.Point(3, 23)
        Me.vscmbxResp.Name = "vscmbxResp"
        Me.vscmbxResp.Size = New System.Drawing.Size(172, 27)
        Me.vscmbxResp.TabIndex = 0
        Me.ToolTip4.SetToolTip(Me.vscmbxResp, resources.GetString("vscmbxResp.ToolTip"))
        '
        'GroupBox16
        '
        Me.GroupBox16.BackColor = System.Drawing.Color.Pink
        Me.GroupBox16.Controls.Add(Me.vscmbxO2sat)
        Me.GroupBox16.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox16.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox16.Location = New System.Drawing.Point(1013, 104)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(178, 55)
        Me.GroupBox16.TabIndex = 103
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Normal?"
        '
        'vscmbxO2sat
        '
        Me.vscmbxO2sat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vscmbxO2sat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.vscmbxO2sat.FormattingEnabled = True
        Me.vscmbxO2sat.Items.AddRange(New Object() {"Yes", "No"})
        Me.vscmbxO2sat.Location = New System.Drawing.Point(3, 23)
        Me.vscmbxO2sat.Name = "vscmbxO2sat"
        Me.vscmbxO2sat.Size = New System.Drawing.Size(172, 27)
        Me.vscmbxO2sat.TabIndex = 0
        Me.ToolTip5.SetToolTip(Me.vscmbxO2sat, "Will not exceed below 95% or above 100%")
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.GroupBox11)
        Me.Panel3.Controls.Add(Me.GroupBox10)
        Me.Panel3.Location = New System.Drawing.Point(813, 166)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(381, 60)
        Me.Panel3.TabIndex = 104
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.vsDGV)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 444)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1247, 278)
        Me.Panel4.TabIndex = 105
        '
        'vsDGV
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.vsDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.vsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.vsDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.vsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.vsDGV.DefaultCellStyle = DataGridViewCellStyle3
        Me.vsDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vsDGV.EnableHeadersVisualStyles = False
        Me.vsDGV.Location = New System.Drawing.Point(0, 0)
        Me.vsDGV.MultiSelect = False
        Me.vsDGV.Name = "vsDGV"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.vsDGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.vsDGV.RowTemplate.Height = 24
        Me.vsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.vsDGV.Size = New System.Drawing.Size(1247, 278)
        Me.vsDGV.TabIndex = 0
        '
        'vsbtnSave
        '
        Me.vsbtnSave.Enabled = False
        Me.vsbtnSave.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vsbtnSave.Location = New System.Drawing.Point(429, 386)
        Me.vsbtnSave.Name = "vsbtnSave"
        Me.vsbtnSave.Size = New System.Drawing.Size(176, 43)
        Me.vsbtnSave.TabIndex = 106
        Me.vsbtnSave.Text = "SAVE"
        Me.vsbtnSave.UseVisualStyleBackColor = True
        '
        'GroupBox17
        '
        Me.GroupBox17.BackColor = System.Drawing.Color.Pink
        Me.GroupBox17.Controls.Add(Me.vstxtbxSrchLname)
        Me.GroupBox17.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox17.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox17.Location = New System.Drawing.Point(5, 380)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(194, 55)
        Me.GroupBox17.TabIndex = 108
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Last name"
        '
        'vstxtbxSrchLname
        '
        Me.vstxtbxSrchLname.BackColor = System.Drawing.Color.White
        Me.vstxtbxSrchLname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vstxtbxSrchLname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vstxtbxSrchLname.Location = New System.Drawing.Point(3, 23)
        Me.vstxtbxSrchLname.Multiline = True
        Me.vstxtbxSrchLname.Name = "vstxtbxSrchLname"
        Me.vstxtbxSrchLname.Size = New System.Drawing.Size(188, 29)
        Me.vstxtbxSrchLname.TabIndex = 1
        '
        'vsbtnUpdate
        '
        Me.vsbtnUpdate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vsbtnUpdate.Location = New System.Drawing.Point(669, 386)
        Me.vsbtnUpdate.Name = "vsbtnUpdate"
        Me.vsbtnUpdate.Size = New System.Drawing.Size(176, 43)
        Me.vsbtnUpdate.TabIndex = 109
        Me.vsbtnUpdate.Text = "UPDATE"
        Me.vsbtnUpdate.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.GroupBox3)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.GroupBox5)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.GroupBox9)
        Me.Panel5.Controls.Add(Me.GroupBox1)
        Me.Panel5.Controls.Add(Me.Panel3)
        Me.Panel5.Controls.Add(Me.GroupBox2)
        Me.Panel5.Controls.Add(Me.GroupBox16)
        Me.Panel5.Controls.Add(Me.GroupBox4)
        Me.Panel5.Controls.Add(Me.GroupBox15)
        Me.Panel5.Controls.Add(Me.GroupBox7)
        Me.Panel5.Controls.Add(Me.GroupBox14)
        Me.Panel5.Controls.Add(Me.GroupBox6)
        Me.Panel5.Controls.Add(Me.GroupBox13)
        Me.Panel5.Controls.Add(Me.GroupBox8)
        Me.Panel5.Controls.Add(Me.GroupBox12)
        Me.Panel5.Location = New System.Drawing.Point(16, 122)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1207, 249)
        Me.Panel5.TabIndex = 110
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Pink
        Me.GroupBox3.Controls.Add(Me.txtpersonID)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(268, 48)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(82, 55)
        Me.GroupBox3.TabIndex = 105
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ID"
        '
        'txtpersonID
        '
        Me.txtpersonID.BackColor = System.Drawing.Color.Pink
        Me.txtpersonID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpersonID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtpersonID.Location = New System.Drawing.Point(3, 23)
        Me.txtpersonID.Name = "txtpersonID"
        Me.txtpersonID.Size = New System.Drawing.Size(76, 29)
        Me.txtpersonID.TabIndex = 93
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 9000
        Me.ToolTip1.InitialDelay = 100000
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Normal Body Temperature"
        '
        'ToolTip2
        '
        Me.ToolTip2.AutoPopDelay = 9000
        Me.ToolTip2.InitialDelay = 500
        Me.ToolTip2.IsBalloon = True
        Me.ToolTip2.ReshowDelay = 100
        Me.ToolTip2.ToolTipTitle = "Normal Blood Pressure"
        '
        'ToolTip3
        '
        Me.ToolTip3.AutoPopDelay = 9000
        Me.ToolTip3.InitialDelay = 500
        Me.ToolTip3.IsBalloon = True
        Me.ToolTip3.ReshowDelay = 100
        Me.ToolTip3.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip3.ToolTipTitle = "Normal Pulse rate (beats per  minute)"
        '
        'ToolTip4
        '
        Me.ToolTip4.AutoPopDelay = 9000
        Me.ToolTip4.InitialDelay = 500
        Me.ToolTip4.IsBalloon = True
        Me.ToolTip4.ReshowDelay = 100
        Me.ToolTip4.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip4.ToolTipTitle = "Normal Breaths per minute"
        '
        'ToolTip5
        '
        Me.ToolTip5.AutoPopDelay = 9000
        Me.ToolTip5.InitialDelay = 500
        Me.ToolTip5.IsBalloon = True
        Me.ToolTip5.ReshowDelay = 100
        Me.ToolTip5.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip5.ToolTipTitle = "Normal O2 sat per %"
        '
        'vsrbRegular
        '
        Me.vsrbRegular.AutoSize = True
        Me.vsrbRegular.Checked = True
        Me.vsrbRegular.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vsrbRegular.Location = New System.Drawing.Point(25, 27)
        Me.vsrbRegular.Name = "vsrbRegular"
        Me.vsrbRegular.Size = New System.Drawing.Size(86, 23)
        Me.vsrbRegular.TabIndex = 111
        Me.vsrbRegular.TabStop = True
        Me.vsrbRegular.Text = "Regular"
        Me.vsrbRegular.UseVisualStyleBackColor = True
        '
        'vsrbAppointment
        '
        Me.vsrbAppointment.AutoSize = True
        Me.vsrbAppointment.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vsrbAppointment.Location = New System.Drawing.Point(133, 28)
        Me.vsrbAppointment.Name = "vsrbAppointment"
        Me.vsrbAppointment.Size = New System.Drawing.Size(120, 23)
        Me.vsrbAppointment.TabIndex = 112
        Me.vsrbAppointment.Text = "Appointment"
        Me.vsrbAppointment.UseVisualStyleBackColor = True
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.vsrbAppointment)
        Me.GroupBox18.Controls.Add(Me.vsrbRegular)
        Me.GroupBox18.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox18.Location = New System.Drawing.Point(951, 53)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(272, 63)
        Me.GroupBox18.TabIndex = 113
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Patient status"
        '
        'VitalSigns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Pink
        Me.ClientSize = New System.Drawing.Size(1247, 732)
        Me.Controls.Add(Me.GroupBox18)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.vsbtnUpdate)
        Me.Controls.Add(Me.GroupBox17)
        Me.Controls.Add(Me.vsbtnSave)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "VitalSigns"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VitalSigns"
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox16.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.vsDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents vstxtbxBT As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents vslblAge As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents vslblFname As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents vslblGender As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents vstxtbxBP As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents vstxtbxPR As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents vstxtbxResp As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents vstxtO2sat As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents vstxtbxHeight As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents vstxtbxWeight As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents vscmbxBT As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents vscmbxBP As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents vscmbxPR As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents vscmbxResp As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents vscmbxO2sat As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents vsDGV As System.Windows.Forms.DataGridView
    Friend WithEvents vsbtnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents vsbtnUpdate As System.Windows.Forms.Button
    Friend WithEvents vstxtbxSrchLname As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip4 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip5 As System.Windows.Forms.ToolTip
    Friend WithEvents vsrbRegular As System.Windows.Forms.RadioButton
    Friend WithEvents vsrbAppointment As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtpersonID As System.Windows.Forms.Label
End Class
