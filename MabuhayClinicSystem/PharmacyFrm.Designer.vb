<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PharmacyFrm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtQty = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtnBarcode = New System.Windows.Forms.RadioButton()
        Me.rbtnItemName = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DGVSearchBrcdItem = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtbarcode = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.lblTotalQty = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.txtFullname = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.cmbxSearchCustomer = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.txtDosage = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtExpiryDate = New System.Windows.Forms.TextBox()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.txtGenericname = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.DGVorderitems = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DGVSearchBrcdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.DGVorderitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1546, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "POS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1546, 46)
        Me.Panel1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnEnter)
        Me.Panel3.Controls.Add(Me.GroupBox5)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 46)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1546, 188)
        Me.Panel3.TabIndex = 7
        '
        'btnEnter
        '
        Me.btnEnter.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.Location = New System.Drawing.Point(771, 17)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(169, 39)
        Me.btnEnter.TabIndex = 10
        Me.btnEnter.Text = "ENTER"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtQty)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(643, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(113, 54)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Quantity"
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.Color.Pink
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQty.Font = New System.Drawing.Font("Arial Black", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQty.Location = New System.Drawing.Point(3, 21)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(107, 30)
        Me.txtQty.TabIndex = 0
        Me.txtQty.Text = "0"
        Me.txtQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtnBarcode)
        Me.GroupBox2.Controls.Add(Me.rbtnItemName)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(376, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 54)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search"
        '
        'rbtnBarcode
        '
        Me.rbtnBarcode.AutoSize = True
        Me.rbtnBarcode.Checked = True
        Me.rbtnBarcode.Location = New System.Drawing.Point(24, 23)
        Me.rbtnBarcode.Name = "rbtnBarcode"
        Me.rbtnBarcode.Size = New System.Drawing.Size(84, 21)
        Me.rbtnBarcode.TabIndex = 6
        Me.rbtnBarcode.TabStop = True
        Me.rbtnBarcode.Text = "Barcode"
        Me.rbtnBarcode.UseVisualStyleBackColor = True
        '
        'rbtnItemName
        '
        Me.rbtnItemName.AutoSize = True
        Me.rbtnItemName.Location = New System.Drawing.Point(125, 23)
        Me.rbtnItemName.Name = "rbtnItemName"
        Me.rbtnItemName.Size = New System.Drawing.Size(98, 21)
        Me.rbtnItemName.TabIndex = 7
        Me.rbtnItemName.Text = "Item name"
        Me.rbtnItemName.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.DGVSearchBrcdItem)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 63)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1544, 123)
        Me.Panel4.TabIndex = 5
        '
        'DGVSearchBrcdItem
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.DGVSearchBrcdItem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVSearchBrcdItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVSearchBrcdItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGVSearchBrcdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVSearchBrcdItem.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGVSearchBrcdItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVSearchBrcdItem.EnableHeadersVisualStyles = False
        Me.DGVSearchBrcdItem.Location = New System.Drawing.Point(0, 0)
        Me.DGVSearchBrcdItem.MultiSelect = False
        Me.DGVSearchBrcdItem.Name = "DGVSearchBrcdItem"
        Me.DGVSearchBrcdItem.RowTemplate.Height = 24
        Me.DGVSearchBrcdItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVSearchBrcdItem.Size = New System.Drawing.Size(1544, 123)
        Me.DGVSearchBrcdItem.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtbarcode)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(365, 54)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Barcode/Item name"
        '
        'txtbarcode
        '
        Me.txtbarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtbarcode.Location = New System.Drawing.Point(3, 21)
        Me.txtbarcode.Multiline = True
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.Size = New System.Drawing.Size(359, 30)
        Me.txtbarcode.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 234)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1546, 540)
        Me.Panel2.TabIndex = 8
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnRemove)
        Me.Panel6.Controls.Add(Me.btnPay)
        Me.Panel6.Controls.Add(Me.GroupBox13)
        Me.Panel6.Controls.Add(Me.GroupBox12)
        Me.Panel6.Controls.Add(Me.GroupBox11)
        Me.Panel6.Controls.Add(Me.GroupBox10)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.GroupBox9)
        Me.Panel6.Controls.Add(Me.GroupBox8)
        Me.Panel6.Controls.Add(Me.GroupBox7)
        Me.Panel6.Controls.Add(Me.GroupBox18)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(967, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(577, 538)
        Me.Panel6.TabIndex = 1
        '
        'btnRemove
        '
        Me.btnRemove.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(314, 441)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(223, 58)
        Me.btnRemove.TabIndex = 43
        Me.btnRemove.Text = "REMOVE"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnPay
        '
        Me.btnPay.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPay.Location = New System.Drawing.Point(40, 441)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(223, 58)
        Me.btnPay.TabIndex = 42
        Me.btnPay.Text = "PROCEED TO PAY"
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Panel13)
        Me.GroupBox13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox13.Location = New System.Drawing.Point(304, 349)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(256, 53)
        Me.GroupBox13.TabIndex = 41
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Total Amount"
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.lblTotalAmount)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(3, 21)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(250, 29)
        Me.Panel13.TabIndex = 0
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalAmount.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.Red
        Me.lblTotalAmount.Location = New System.Drawing.Point(0, 0)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(250, 29)
        Me.lblTotalAmount.TabIndex = 21
        Me.lblTotalAmount.Text = "0"
        Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Panel12)
        Me.GroupBox12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(16, 349)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(256, 53)
        Me.GroupBox12.TabIndex = 40
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Total Quantity"
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.lblTotalQty)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(3, 21)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(250, 29)
        Me.Panel12.TabIndex = 0
        '
        'lblTotalQty
        '
        Me.lblTotalQty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotalQty.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalQty.ForeColor = System.Drawing.Color.Red
        Me.lblTotalQty.Location = New System.Drawing.Point(0, 0)
        Me.lblTotalQty.Name = "lblTotalQty"
        Me.lblTotalQty.Size = New System.Drawing.Size(250, 29)
        Me.lblTotalQty.TabIndex = 0
        Me.lblTotalQty.Text = "0"
        Me.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Panel11)
        Me.GroupBox11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(304, 280)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(256, 53)
        Me.GroupBox11.TabIndex = 39
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Full name"
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.txtFullname)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(3, 21)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(250, 29)
        Me.Panel11.TabIndex = 0
        '
        'txtFullname
        '
        Me.txtFullname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFullname.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFullname.Location = New System.Drawing.Point(0, 0)
        Me.txtFullname.Multiline = True
        Me.txtFullname.Name = "txtFullname"
        Me.txtFullname.Size = New System.Drawing.Size(250, 29)
        Me.txtFullname.TabIndex = 20
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Panel10)
        Me.GroupBox10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(16, 280)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(256, 53)
        Me.GroupBox10.TabIndex = 38
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Search Customer"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.cmbxSearchCustomer)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(3, 21)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(250, 29)
        Me.Panel10.TabIndex = 0
        '
        'cmbxSearchCustomer
        '
        Me.cmbxSearchCustomer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbxSearchCustomer.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbxSearchCustomer.FormattingEnabled = True
        Me.cmbxSearchCustomer.Location = New System.Drawing.Point(0, 0)
        Me.cmbxSearchCustomer.Name = "cmbxSearchCustomer"
        Me.cmbxSearchCustomer.Size = New System.Drawing.Size(250, 27)
        Me.cmbxSearchCustomer.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label6.Location = New System.Drawing.Point(2, 244)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(572, 23)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "ORDER DETAILS"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Panel9)
        Me.GroupBox9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(290, 119)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(256, 120)
        Me.GroupBox9.TabIndex = 36
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Dosage"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.txtDosage)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 21)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(250, 96)
        Me.Panel9.TabIndex = 0
        '
        'txtDosage
        '
        Me.txtDosage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDosage.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDosage.Location = New System.Drawing.Point(0, 0)
        Me.txtDosage.Multiline = True
        Me.txtDosage.Name = "txtDosage"
        Me.txtDosage.ReadOnly = True
        Me.txtDosage.Size = New System.Drawing.Size(250, 96)
        Me.txtDosage.TabIndex = 20
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Panel8)
        Me.GroupBox8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(16, 119)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(256, 120)
        Me.GroupBox8.TabIndex = 35
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Description"
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.txtDescription)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 21)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(250, 96)
        Me.Panel8.TabIndex = 0
        '
        'txtDescription
        '
        Me.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescription.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(0, 0)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(250, 96)
        Me.txtDescription.TabIndex = 20
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Panel7)
        Me.GroupBox7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(287, 37)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(256, 76)
        Me.GroupBox7.TabIndex = 34
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Expiration date"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.txtExpiryDate)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 21)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(250, 52)
        Me.Panel7.TabIndex = 0
        '
        'txtExpiryDate
        '
        Me.txtExpiryDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtExpiryDate.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpiryDate.Location = New System.Drawing.Point(0, 0)
        Me.txtExpiryDate.Multiline = True
        Me.txtExpiryDate.Name = "txtExpiryDate"
        Me.txtExpiryDate.ReadOnly = True
        Me.txtExpiryDate.Size = New System.Drawing.Size(250, 52)
        Me.txtExpiryDate.TabIndex = 20
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.Panel18)
        Me.GroupBox18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox18.Location = New System.Drawing.Point(13, 37)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(256, 76)
        Me.GroupBox18.TabIndex = 33
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "Generic name"
        '
        'Panel18
        '
        Me.Panel18.Controls.Add(Me.txtGenericname)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel18.Location = New System.Drawing.Point(3, 21)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(250, 52)
        Me.Panel18.TabIndex = 0
        '
        'txtGenericname
        '
        Me.txtGenericname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGenericname.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGenericname.Location = New System.Drawing.Point(0, 0)
        Me.txtGenericname.Multiline = True
        Me.txtGenericname.Name = "txtGenericname"
        Me.txtGenericname.ReadOnly = True
        Me.txtGenericname.Size = New System.Drawing.Size(250, 52)
        Me.txtGenericname.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(577, 23)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "ITEM DETAILS"
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.GroupBox6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(967, 538)
        Me.Panel5.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.DGVorderitems)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(965, 536)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Ordered items"
        '
        'DGVorderitems
        '
        Me.DGVorderitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVorderitems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVorderitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVorderitems.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGVorderitems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVorderitems.EnableHeadersVisualStyles = False
        Me.DGVorderitems.Location = New System.Drawing.Point(3, 18)
        Me.DGVorderitems.Name = "DGVorderitems"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVorderitems.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGVorderitems.RowTemplate.Height = 24
        Me.DGVorderitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVorderitems.Size = New System.Drawing.Size(959, 515)
        Me.DGVorderitems.TabIndex = 0
        '
        'PharmacyFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Pink
        Me.ClientSize = New System.Drawing.Size(1546, 774)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "PharmacyFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PharmacyFrm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.DGVSearchBrcdItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.DGVorderitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnItemName As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnBarcode As System.Windows.Forms.RadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents DGVSearchBrcdItem As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtbarcode As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnPay As System.Windows.Forms.Button
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents txtFullname As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents cmbxSearchCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents txtDosage As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents txtExpiryDate As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents txtGenericname As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVorderitems As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblTotalQty As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.Label
End Class
