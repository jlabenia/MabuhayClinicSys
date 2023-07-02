<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManagePharmacy
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
        Me.btnManageQue = New System.Windows.Forms.Button()
        Me.btnAddQue = New System.Windows.Forms.Button()
        Me.btnCustQueDashboard = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnManageQue
        '
        Me.btnManageQue.BackColor = System.Drawing.Color.ForestGreen
        Me.btnManageQue.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageQue.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnManageQue.Location = New System.Drawing.Point(516, 23)
        Me.btnManageQue.Name = "btnManageQue"
        Me.btnManageQue.Size = New System.Drawing.Size(469, 97)
        Me.btnManageQue.TabIndex = 8
        Me.btnManageQue.Text = " ITEM DETAILS"
        Me.btnManageQue.UseVisualStyleBackColor = False
        '
        'btnAddQue
        '
        Me.btnAddQue.BackColor = System.Drawing.Color.ForestGreen
        Me.btnAddQue.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddQue.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnAddQue.Location = New System.Drawing.Point(23, 229)
        Me.btnAddQue.Name = "btnAddQue"
        Me.btnAddQue.Size = New System.Drawing.Size(469, 97)
        Me.btnAddQue.TabIndex = 7
        Me.btnAddQue.Text = "STOCK" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " IN"
        Me.btnAddQue.UseVisualStyleBackColor = False
        '
        'btnCustQueDashboard
        '
        Me.btnCustQueDashboard.BackColor = System.Drawing.Color.ForestGreen
        Me.btnCustQueDashboard.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustQueDashboard.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnCustQueDashboard.Location = New System.Drawing.Point(23, 23)
        Me.btnCustQueDashboard.Name = "btnCustQueDashboard"
        Me.btnCustQueDashboard.Size = New System.Drawing.Size(469, 97)
        Me.btnCustQueDashboard.TabIndex = 6
        Me.btnCustQueDashboard.Text = "ITEMS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnCustQueDashboard.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Button1.Location = New System.Drawing.Point(23, 126)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(469, 97)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "SUPPLIER INFO"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.ForestGreen
        Me.Button2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Button2.Location = New System.Drawing.Point(516, 229)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(469, 97)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "TRANSACTIONS AND PAYMENT"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.ForestGreen
        Me.Button3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Button3.Location = New System.Drawing.Point(516, 126)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(469, 97)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "INVENTORY "
        Me.Button3.UseVisualStyleBackColor = False
        '
        'ManagePharmacy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Pink
        Me.ClientSize = New System.Drawing.Size(1011, 350)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnManageQue)
        Me.Controls.Add(Me.btnAddQue)
        Me.Controls.Add(Me.btnCustQueDashboard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "ManagePharmacy"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ManagePharmacy"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnManageQue As System.Windows.Forms.Button
    Friend WithEvents btnAddQue As System.Windows.Forms.Button
    Friend WithEvents btnCustQueDashboard As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
