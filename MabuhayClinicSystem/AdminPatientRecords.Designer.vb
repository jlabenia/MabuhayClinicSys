<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminPatientRecords
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtBarangay = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.txtContactNo = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.cmbxGender = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cmbxDOBmonth = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmbxDOBday = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtLname = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtMname = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFname = New System.Windows.Forms.TextBox()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.txtPatientID = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cmbxDOByear = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMunicipality = New System.Windows.Forms.TextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.txtProvince = New System.Windows.Forms.TextBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbtnVitalSigns = New System.Windows.Forms.RadioButton()
        Me.rbtnTestResults = New System.Windows.Forms.RadioButton()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.txtSearchLname = New System.Windows.Forms.TextBox()
        Me.rbtnDiagnosis = New System.Windows.Forms.RadioButton()
        Me.rbtnConsultation = New System.Windows.Forms.RadioButton()
        Me.rbtnSurgery = New System.Windows.Forms.RadioButton()
        Me.rbtnPatientInfo = New System.Windows.Forms.RadioButton()
        Me.rbtnAppointment = New System.Windows.Forms.RadioButton()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.rbtnSelectedDet = New System.Windows.Forms.RadioButton()
        Me.rbtnSelectedItem = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvPatientRecords = New System.Windows.Forms.DataGridView()
        Me.btnView = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvPatientRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1405, 46)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1405, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PATIENT'S MEDICAL RECORDS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.txtBarangay)
        Me.GroupBox11.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(604, 104)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(287, 54)
        Me.GroupBox11.TabIndex = 49
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Barangay"
        '
        'txtBarangay
        '
        Me.txtBarangay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBarangay.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarangay.Location = New System.Drawing.Point(3, 23)
        Me.txtBarangay.Multiline = True
        Me.txtBarangay.Name = "txtBarangay"
        Me.txtBarangay.Size = New System.Drawing.Size(281, 28)
        Me.txtBarangay.TabIndex = 0
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txtContactNo)
        Me.GroupBox10.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(767, 49)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(200, 54)
        Me.GroupBox10.TabIndex = 48
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Contact No."
        '
        'txtContactNo
        '
        Me.txtContactNo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtContactNo.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactNo.Location = New System.Drawing.Point(3, 23)
        Me.txtContactNo.MaxLength = 11
        Me.txtContactNo.Multiline = True
        Me.txtContactNo.Name = "txtContactNo"
        Me.txtContactNo.Size = New System.Drawing.Size(194, 28)
        Me.txtContactNo.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.cmbxGender)
        Me.GroupBox9.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(973, 49)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(133, 54)
        Me.GroupBox9.TabIndex = 47
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Gender"
        '
        'cmbxGender
        '
        Me.cmbxGender.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxGender.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbxGender.FormattingEnabled = True
        Me.cmbxGender.Items.AddRange(New Object() {"", "Male", "Female"})
        Me.cmbxGender.Location = New System.Drawing.Point(3, 23)
        Me.cmbxGender.Name = "cmbxGender"
        Me.cmbxGender.Size = New System.Drawing.Size(127, 27)
        Me.cmbxGender.TabIndex = 2
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cmbxDOBmonth)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(143, 108)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(200, 54)
        Me.GroupBox6.TabIndex = 46
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "DOB Month"
        '
        'cmbxDOBmonth
        '
        Me.cmbxDOBmonth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbxDOBmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxDOBmonth.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbxDOBmonth.FormattingEnabled = True
        Me.cmbxDOBmonth.Items.AddRange(New Object() {"", "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"})
        Me.cmbxDOBmonth.Location = New System.Drawing.Point(3, 23)
        Me.cmbxDOBmonth.Name = "cmbxDOBmonth"
        Me.cmbxDOBmonth.Size = New System.Drawing.Size(194, 27)
        Me.cmbxDOBmonth.TabIndex = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbxDOBday)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(5, 108)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(132, 54)
        Me.GroupBox5.TabIndex = 44
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "DOB day"
        '
        'cmbxDOBday
        '
        Me.cmbxDOBday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbxDOBday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxDOBday.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbxDOBday.FormattingEnabled = True
        Me.cmbxDOBday.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cmbxDOBday.Location = New System.Drawing.Point(3, 23)
        Me.cmbxDOBday.Name = "cmbxDOBday"
        Me.cmbxDOBday.Size = New System.Drawing.Size(126, 27)
        Me.cmbxDOBday.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtLname)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(561, 49)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 54)
        Me.GroupBox4.TabIndex = 43
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Last name"
        '
        'txtLname
        '
        Me.txtLname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLname.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLname.Location = New System.Drawing.Point(3, 23)
        Me.txtLname.MaxLength = 50
        Me.txtLname.Multiline = True
        Me.txtLname.Name = "txtLname"
        Me.txtLname.Size = New System.Drawing.Size(194, 28)
        Me.txtLname.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtMname)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(355, 49)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 54)
        Me.GroupBox3.TabIndex = 42
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Middle name"
        '
        'txtMname
        '
        Me.txtMname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMname.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMname.Location = New System.Drawing.Point(3, 23)
        Me.txtMname.MaxLength = 50
        Me.txtMname.Multiline = True
        Me.txtMname.Name = "txtMname"
        Me.txtMname.Size = New System.Drawing.Size(194, 28)
        Me.txtMname.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFname)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(149, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 54)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "First name"
        '
        'txtFname
        '
        Me.txtFname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFname.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFname.Location = New System.Drawing.Point(3, 23)
        Me.txtFname.MaxLength = 50
        Me.txtFname.Multiline = True
        Me.txtFname.Name = "txtFname"
        Me.txtFname.Size = New System.Drawing.Size(194, 28)
        Me.txtFname.TabIndex = 0
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.txtPatientID)
        Me.GroupBox15.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox15.Location = New System.Drawing.Point(7, 49)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(114, 54)
        Me.GroupBox15.TabIndex = 50
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Patient ID"
        '
        'txtPatientID
        '
        Me.txtPatientID.BackColor = System.Drawing.Color.Pink
        Me.txtPatientID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPatientID.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientID.Location = New System.Drawing.Point(3, 23)
        Me.txtPatientID.MaxLength = 50
        Me.txtPatientID.Multiline = True
        Me.txtPatientID.Name = "txtPatientID"
        Me.txtPatientID.ReadOnly = True
        Me.txtPatientID.Size = New System.Drawing.Size(108, 28)
        Me.txtPatientID.TabIndex = 0
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.txtAge)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(509, 105)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(89, 54)
        Me.GroupBox8.TabIndex = 45
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Age"
        '
        'txtAge
        '
        Me.txtAge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAge.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAge.Location = New System.Drawing.Point(3, 23)
        Me.txtAge.Multiline = True
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ReadOnly = True
        Me.txtAge.Size = New System.Drawing.Size(83, 28)
        Me.txtAge.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cmbxDOByear)
        Me.GroupBox7.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(349, 108)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(154, 54)
        Me.GroupBox7.TabIndex = 51
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "DOB Year"
        '
        'cmbxDOByear
        '
        Me.cmbxDOByear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbxDOByear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxDOByear.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbxDOByear.FormattingEnabled = True
        Me.cmbxDOByear.Location = New System.Drawing.Point(3, 23)
        Me.cmbxDOByear.Name = "cmbxDOByear"
        Me.cmbxDOByear.Size = New System.Drawing.Size(148, 27)
        Me.cmbxDOByear.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMunicipality)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(897, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(227, 54)
        Me.GroupBox2.TabIndex = 52
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Municipality"
        '
        'txtMunicipality
        '
        Me.txtMunicipality.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMunicipality.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMunicipality.Location = New System.Drawing.Point(3, 23)
        Me.txtMunicipality.Multiline = True
        Me.txtMunicipality.Name = "txtMunicipality"
        Me.txtMunicipality.Size = New System.Drawing.Size(221, 28)
        Me.txtMunicipality.TabIndex = 0
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.txtProvince)
        Me.GroupBox12.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(1130, 104)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(266, 54)
        Me.GroupBox12.TabIndex = 53
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Province"
        '
        'txtProvince
        '
        Me.txtProvince.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProvince.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProvince.Location = New System.Drawing.Point(3, 23)
        Me.txtProvince.Multiline = True
        Me.txtProvince.Name = "txtProvince"
        Me.txtProvince.Size = New System.Drawing.Size(260, 28)
        Me.txtProvince.TabIndex = 0
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Label2)
        Me.GroupBox13.Controls.Add(Me.rbtnVitalSigns)
        Me.GroupBox13.Controls.Add(Me.rbtnTestResults)
        Me.GroupBox13.Controls.Add(Me.GroupBox14)
        Me.GroupBox13.Controls.Add(Me.rbtnDiagnosis)
        Me.GroupBox13.Controls.Add(Me.rbtnConsultation)
        Me.GroupBox13.Controls.Add(Me.rbtnSurgery)
        Me.GroupBox13.Controls.Add(Me.rbtnPatientInfo)
        Me.GroupBox13.Controls.Add(Me.rbtnAppointment)
        Me.GroupBox13.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(3, 168)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(595, 130)
        Me.GroupBox13.TabIndex = 54
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Search by"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(235, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 19)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Selection"
        '
        'rbtnVitalSigns
        '
        Me.rbtnVitalSigns.AutoSize = True
        Me.rbtnVitalSigns.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnVitalSigns.Location = New System.Drawing.Point(264, 67)
        Me.rbtnVitalSigns.Name = "rbtnVitalSigns"
        Me.rbtnVitalSigns.Size = New System.Drawing.Size(102, 23)
        Me.rbtnVitalSigns.TabIndex = 61
        Me.rbtnVitalSigns.Text = "VitalSigns"
        Me.rbtnVitalSigns.UseVisualStyleBackColor = True
        '
        'rbtnTestResults
        '
        Me.rbtnTestResults.AutoSize = True
        Me.rbtnTestResults.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnTestResults.Location = New System.Drawing.Point(432, 99)
        Me.rbtnTestResults.Name = "rbtnTestResults"
        Me.rbtnTestResults.Size = New System.Drawing.Size(115, 23)
        Me.rbtnTestResults.TabIndex = 60
        Me.rbtnTestResults.Text = "Test Results"
        Me.rbtnTestResults.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.txtSearchLname)
        Me.GroupBox14.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox14.Location = New System.Drawing.Point(6, 69)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(221, 54)
        Me.GroupBox14.TabIndex = 56
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Last name"
        '
        'txtSearchLname
        '
        Me.txtSearchLname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearchLname.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchLname.Location = New System.Drawing.Point(3, 23)
        Me.txtSearchLname.MaxLength = 50
        Me.txtSearchLname.Multiline = True
        Me.txtSearchLname.Name = "txtSearchLname"
        Me.txtSearchLname.Size = New System.Drawing.Size(215, 28)
        Me.txtSearchLname.TabIndex = 0
        '
        'rbtnDiagnosis
        '
        Me.rbtnDiagnosis.AutoSize = True
        Me.rbtnDiagnosis.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnDiagnosis.Location = New System.Drawing.Point(432, 70)
        Me.rbtnDiagnosis.Name = "rbtnDiagnosis"
        Me.rbtnDiagnosis.Size = New System.Drawing.Size(102, 23)
        Me.rbtnDiagnosis.TabIndex = 56
        Me.rbtnDiagnosis.Text = "Diagnosis"
        Me.rbtnDiagnosis.UseVisualStyleBackColor = True
        '
        'rbtnConsultation
        '
        Me.rbtnConsultation.AutoSize = True
        Me.rbtnConsultation.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnConsultation.Location = New System.Drawing.Point(432, 41)
        Me.rbtnConsultation.Name = "rbtnConsultation"
        Me.rbtnConsultation.Size = New System.Drawing.Size(119, 23)
        Me.rbtnConsultation.TabIndex = 58
        Me.rbtnConsultation.Text = "Consultation"
        Me.rbtnConsultation.UseVisualStyleBackColor = True
        '
        'rbtnSurgery
        '
        Me.rbtnSurgery.AutoSize = True
        Me.rbtnSurgery.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSurgery.Location = New System.Drawing.Point(264, 96)
        Me.rbtnSurgery.Name = "rbtnSurgery"
        Me.rbtnSurgery.Size = New System.Drawing.Size(94, 23)
        Me.rbtnSurgery.TabIndex = 59
        Me.rbtnSurgery.Text = "Surgery "
        Me.rbtnSurgery.UseVisualStyleBackColor = True
        '
        'rbtnPatientInfo
        '
        Me.rbtnPatientInfo.AutoSize = True
        Me.rbtnPatientInfo.Checked = True
        Me.rbtnPatientInfo.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnPatientInfo.Location = New System.Drawing.Point(18, 36)
        Me.rbtnPatientInfo.Name = "rbtnPatientInfo"
        Me.rbtnPatientInfo.Size = New System.Drawing.Size(179, 23)
        Me.rbtnPatientInfo.TabIndex = 55
        Me.rbtnPatientInfo.TabStop = True
        Me.rbtnPatientInfo.Text = "Patient personal info"
        Me.rbtnPatientInfo.UseVisualStyleBackColor = True
        '
        'rbtnAppointment
        '
        Me.rbtnAppointment.AutoSize = True
        Me.rbtnAppointment.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAppointment.Location = New System.Drawing.Point(264, 41)
        Me.rbtnAppointment.Name = "rbtnAppointment"
        Me.rbtnAppointment.Size = New System.Drawing.Size(120, 23)
        Me.rbtnAppointment.TabIndex = 57
        Me.rbtnAppointment.Text = "Appointment"
        Me.rbtnAppointment.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(616, 240)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(174, 52)
        Me.btnClear.TabIndex = 57
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(801, 180)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(174, 52)
        Me.btnUpdate.TabIndex = 56
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(616, 180)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(174, 52)
        Me.btnAdd.TabIndex = 55
        Me.btnAdd.Text = "SAVE"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.GroupBox18)
        Me.GroupBox16.Controls.Add(Me.btnDelete)
        Me.GroupBox16.Controls.Add(Me.GroupBox17)
        Me.GroupBox16.Controls.Add(Me.rbtnSelectedDet)
        Me.GroupBox16.Controls.Add(Me.rbtnSelectedItem)
        Me.GroupBox16.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox16.Location = New System.Drawing.Point(981, 165)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(412, 138)
        Me.GroupBox16.TabIndex = 58
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Delete"
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.dtp1)
        Me.GroupBox18.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox18.Location = New System.Drawing.Point(6, 79)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(195, 54)
        Me.GroupBox18.TabIndex = 43
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "From"
        '
        'dtp1
        '
        Me.dtp1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtp1.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(3, 23)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(189, 27)
        Me.dtp1.TabIndex = 1
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Red
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnDelete.Location = New System.Drawing.Point(189, 15)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(186, 52)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.dtp2)
        Me.GroupBox17.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox17.Location = New System.Drawing.Point(207, 78)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(199, 54)
        Me.GroupBox17.TabIndex = 42
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "To"
        '
        'dtp2
        '
        Me.dtp2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtp2.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(3, 23)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(193, 27)
        Me.dtp2.TabIndex = 0
        '
        'rbtnSelectedDet
        '
        Me.rbtnSelectedDet.AutoSize = True
        Me.rbtnSelectedDet.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSelectedDet.Location = New System.Drawing.Point(27, 54)
        Me.rbtnSelectedDet.Name = "rbtnSelectedDet"
        Me.rbtnSelectedDet.Size = New System.Drawing.Size(129, 23)
        Me.rbtnSelectedDet.TabIndex = 1
        Me.rbtnSelectedDet.Text = "Selected date"
        Me.rbtnSelectedDet.UseVisualStyleBackColor = True
        '
        'rbtnSelectedItem
        '
        Me.rbtnSelectedItem.AutoSize = True
        Me.rbtnSelectedItem.Checked = True
        Me.rbtnSelectedItem.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSelectedItem.Location = New System.Drawing.Point(27, 25)
        Me.rbtnSelectedItem.Name = "rbtnSelectedItem"
        Me.rbtnSelectedItem.Size = New System.Drawing.Size(129, 23)
        Me.rbtnSelectedItem.TabIndex = 0
        Me.rbtnSelectedItem.TabStop = True
        Me.rbtnSelectedItem.Text = "Selected Item"
        Me.rbtnSelectedItem.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvPatientRecords)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 306)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1405, 466)
        Me.Panel2.TabIndex = 59
        '
        'dgvPatientRecords
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvPatientRecords.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPatientRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientRecords.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPatientRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPatientRecords.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPatientRecords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPatientRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPatientRecords.EnableHeadersVisualStyles = False
        Me.dgvPatientRecords.Location = New System.Drawing.Point(0, 0)
        Me.dgvPatientRecords.Name = "dgvPatientRecords"
        Me.dgvPatientRecords.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPatientRecords.RowTemplate.Height = 24
        Me.dgvPatientRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPatientRecords.Size = New System.Drawing.Size(1405, 466)
        Me.dgvPatientRecords.TabIndex = 0
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Location = New System.Drawing.Point(801, 238)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(174, 52)
        Me.btnView.TabIndex = 60
        Me.btnView.Text = "VIEW"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'AdminPatientRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Pink
        Me.ClientSize = New System.Drawing.Size(1405, 772)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox16)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox15)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "AdminPatientRecords"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdminPatientRecords"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox17.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvPatientRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBarangay As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtContactNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbxGender As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbxDOBmonth As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbxDOBday As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLname As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMname As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFname As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPatientID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbxDOByear As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMunicipality As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents txtProvince As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnTestResults As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSearchLname As System.Windows.Forms.TextBox
    Friend WithEvents rbtnDiagnosis As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnConsultation As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSurgery As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPatientInfo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnAppointment As System.Windows.Forms.RadioButton
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbtnSelectedDet As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSelectedItem As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvPatientRecords As System.Windows.Forms.DataGridView
    Friend WithEvents rbtnVitalSigns As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnView As System.Windows.Forms.Button
End Class
