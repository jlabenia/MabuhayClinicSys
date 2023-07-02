<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stocks
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtSupplierCode = New System.Windows.Forms.TextBox()
        Me.cmbxSupplier = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSuppliername = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.cmbxItemName = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtStockInCode = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.dtpDatePurchased = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.cmbxPurchasedIn = New System.Windows.Forms.ComboBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtTotalAmountPaid = New System.Windows.Forms.TextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.txtTotalPcs = New System.Windows.Forms.TextBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.txtPiecesPerUnit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.dtpSearchPurchasedDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.txtSearchItemname = New System.Windows.Forms.TextBox()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DGVstocks = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGVstocks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(704, 82)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Supplier"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtSupplierCode)
        Me.GroupBox3.Controls.Add(Me.cmbxSupplier)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(277, 25)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(416, 53)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Select supplier"
        '
        'txtSupplierCode
        '
        Me.txtSupplierCode.BackColor = System.Drawing.Color.Pink
        Me.txtSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupplierCode.Location = New System.Drawing.Point(258, 23)
        Me.txtSupplierCode.Name = "txtSupplierCode"
        Me.txtSupplierCode.Size = New System.Drawing.Size(154, 27)
        Me.txtSupplierCode.TabIndex = 1
        '
        'cmbxSupplier
        '
        Me.cmbxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxSupplier.FormattingEnabled = True
        Me.cmbxSupplier.Location = New System.Drawing.Point(3, 23)
        Me.cmbxSupplier.Name = "cmbxSupplier"
        Me.cmbxSupplier.Size = New System.Drawing.Size(249, 27)
        Me.cmbxSupplier.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSuppliername)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(19, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(255, 53)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Name"
        '
        'txtSuppliername
        '
        Me.txtSuppliername.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSuppliername.Location = New System.Drawing.Point(3, 23)
        Me.txtSuppliername.Multiline = True
        Me.txtSuppliername.Name = "txtSuppliername"
        Me.txtSuppliername.Size = New System.Drawing.Size(249, 27)
        Me.txtSuppliername.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.GroupBox6)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(715, 52)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(709, 82)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Search Item"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtItemCode)
        Me.GroupBox5.Controls.Add(Me.cmbxItemName)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(277, 25)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(421, 53)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Select Item"
        '
        'txtItemCode
        '
        Me.txtItemCode.BackColor = System.Drawing.Color.Pink
        Me.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCode.Location = New System.Drawing.Point(263, 23)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(154, 27)
        Me.txtItemCode.TabIndex = 2
        '
        'cmbxItemName
        '
        Me.cmbxItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxItemName.FormattingEnabled = True
        Me.cmbxItemName.Location = New System.Drawing.Point(8, 23)
        Me.cmbxItemName.Name = "cmbxItemName"
        Me.cmbxItemName.Size = New System.Drawing.Size(249, 27)
        Me.cmbxItemName.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtItemName)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(19, 25)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(255, 53)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Item name"
        '
        'txtItemName
        '
        Me.txtItemName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtItemName.Location = New System.Drawing.Point(3, 23)
        Me.txtItemName.Multiline = True
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(249, 27)
        Me.txtItemName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1432, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADD NEW STOCKS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1432, 46)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtStockInCode)
        Me.GroupBox7.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(27, 166)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(255, 53)
        Me.GroupBox7.TabIndex = 3
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Stock In code"
        '
        'txtStockInCode
        '
        Me.txtStockInCode.BackColor = System.Drawing.Color.Pink
        Me.txtStockInCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockInCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStockInCode.Location = New System.Drawing.Point(3, 23)
        Me.txtStockInCode.Multiline = True
        Me.txtStockInCode.Name = "txtStockInCode"
        Me.txtStockInCode.Size = New System.Drawing.Size(249, 27)
        Me.txtStockInCode.TabIndex = 0
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.dtpDatePurchased)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(1044, 166)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(255, 53)
        Me.GroupBox8.TabIndex = 4
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Date purchase"
        '
        'dtpDatePurchased
        '
        Me.dtpDatePurchased.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDatePurchased.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDatePurchased.Location = New System.Drawing.Point(3, 23)
        Me.dtpDatePurchased.Name = "dtpDatePurchased"
        Me.dtpDatePurchased.Size = New System.Drawing.Size(249, 27)
        Me.dtpDatePurchased.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.cmbxPurchasedIn)
        Me.GroupBox9.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(288, 166)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(164, 53)
        Me.GroupBox9.TabIndex = 5
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Purchased In"
        '
        'cmbxPurchasedIn
        '
        Me.cmbxPurchasedIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbxPurchasedIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbxPurchasedIn.FormattingEnabled = True
        Me.cmbxPurchasedIn.Items.AddRange(New Object() {"", "Box", "Bottle"})
        Me.cmbxPurchasedIn.Location = New System.Drawing.Point(3, 23)
        Me.cmbxPurchasedIn.Name = "cmbxPurchasedIn"
        Me.cmbxPurchasedIn.Size = New System.Drawing.Size(158, 27)
        Me.cmbxPurchasedIn.TabIndex = 1
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txtQuantity)
        Me.GroupBox10.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(458, 166)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(116, 53)
        Me.GroupBox10.TabIndex = 6
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Quantity"
        '
        'txtQuantity
        '
        Me.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQuantity.Location = New System.Drawing.Point(3, 23)
        Me.txtQuantity.MaxLength = 5
        Me.txtQuantity.Multiline = True
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(110, 27)
        Me.txtQuantity.TabIndex = 0
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.txtTotalAmountPaid)
        Me.GroupBox11.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(859, 166)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(179, 53)
        Me.GroupBox11.TabIndex = 7
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Total Amount paid"
        '
        'txtTotalAmountPaid
        '
        Me.txtTotalAmountPaid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTotalAmountPaid.Location = New System.Drawing.Point(3, 23)
        Me.txtTotalAmountPaid.MaxLength = 10
        Me.txtTotalAmountPaid.Multiline = True
        Me.txtTotalAmountPaid.Name = "txtTotalAmountPaid"
        Me.txtTotalAmountPaid.Size = New System.Drawing.Size(173, 27)
        Me.txtTotalAmountPaid.TabIndex = 0
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.txtTotalPcs)
        Me.GroupBox12.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(735, 166)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(118, 53)
        Me.GroupBox12.TabIndex = 8
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Total pieces"
        '
        'txtTotalPcs
        '
        Me.txtTotalPcs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTotalPcs.Location = New System.Drawing.Point(3, 23)
        Me.txtTotalPcs.MaxLength = 5
        Me.txtTotalPcs.Multiline = True
        Me.txtTotalPcs.Name = "txtTotalPcs"
        Me.txtTotalPcs.Size = New System.Drawing.Size(112, 27)
        Me.txtTotalPcs.TabIndex = 0
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.txtPiecesPerUnit)
        Me.GroupBox13.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(580, 166)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(149, 53)
        Me.GroupBox13.TabIndex = 9
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Pieces per unit"
        '
        'txtPiecesPerUnit
        '
        Me.txtPiecesPerUnit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPiecesPerUnit.Location = New System.Drawing.Point(3, 23)
        Me.txtPiecesPerUnit.MaxLength = 7
        Me.txtPiecesPerUnit.Multiline = True
        Me.txtPiecesPerUnit.Name = "txtPiecesPerUnit"
        Me.txtPiecesPerUnit.Size = New System.Drawing.Size(143, 27)
        Me.txtPiecesPerUnit.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label2.Location = New System.Drawing.Point(12, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(190, 28)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Stock In details"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(815, 239)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(174, 52)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(1009, 239)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(174, 52)
        Me.btnUpdate.TabIndex = 13
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(1206, 239)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(174, 52)
        Me.btnClear.TabIndex = 14
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.dtpSearchPurchasedDate)
        Me.GroupBox14.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox14.Location = New System.Drawing.Point(264, 20)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(249, 53)
        Me.GroupBox14.TabIndex = 15
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Date of purchase"
        '
        'dtpSearchPurchasedDate
        '
        Me.dtpSearchPurchasedDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpSearchPurchasedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSearchPurchasedDate.Location = New System.Drawing.Point(3, 23)
        Me.dtpSearchPurchasedDate.Name = "dtpSearchPurchasedDate"
        Me.dtpSearchPurchasedDate.Size = New System.Drawing.Size(243, 27)
        Me.dtpSearchPurchasedDate.TabIndex = 1
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.txtSearchItemname)
        Me.GroupBox15.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox15.Location = New System.Drawing.Point(20, 21)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(235, 53)
        Me.GroupBox15.TabIndex = 16
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Item name"
        '
        'txtSearchItemname
        '
        Me.txtSearchItemname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearchItemname.Location = New System.Drawing.Point(3, 23)
        Me.txtSearchItemname.Multiline = True
        Me.txtSearchItemname.Name = "txtSearchItemname"
        Me.txtSearchItemname.Size = New System.Drawing.Size(229, 27)
        Me.txtSearchItemname.TabIndex = 0
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.btnEnter)
        Me.GroupBox16.Controls.Add(Me.GroupBox15)
        Me.GroupBox16.Controls.Add(Me.GroupBox14)
        Me.GroupBox16.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox16.Location = New System.Drawing.Point(0, 225)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(681, 78)
        Me.GroupBox16.TabIndex = 17
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Search by"
        '
        'btnEnter
        '
        Me.btnEnter.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.Location = New System.Drawing.Point(519, 24)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(148, 46)
        Me.btnEnter.TabIndex = 17
        Me.btnEnter.Text = "ENTER"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DGVstocks)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 309)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1432, 463)
        Me.Panel2.TabIndex = 18
        '
        'DGVstocks
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DGVstocks.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVstocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVstocks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVstocks.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGVstocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVstocks.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGVstocks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVstocks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGVstocks.EnableHeadersVisualStyles = False
        Me.DGVstocks.Location = New System.Drawing.Point(0, 0)
        Me.DGVstocks.Name = "DGVstocks"
        Me.DGVstocks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGVstocks.RowTemplate.Height = 24
        Me.DGVstocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVstocks.Size = New System.Drawing.Size(1432, 463)
        Me.DGVstocks.TabIndex = 0
        '
        'Stocks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Pink
        Me.ClientSize = New System.Drawing.Size(1432, 772)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox16)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Stocks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stocks"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.DGVstocks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbxSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSuppliername As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbxItemName As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStockInCode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDatePurchased As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbxPurchasedIn As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalAmountPaid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalPcs As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPiecesPerUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpSearchPurchasedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSearchItemname As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DGVstocks As System.Windows.Forms.DataGridView
End Class
