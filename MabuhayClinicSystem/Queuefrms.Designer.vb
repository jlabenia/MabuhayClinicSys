<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Queuefrms
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
        Me.SuspendLayout()
        '
        'btnManageQue
        '
        Me.btnManageQue.BackColor = System.Drawing.Color.ForestGreen
        Me.btnManageQue.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageQue.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnManageQue.Location = New System.Drawing.Point(33, 228)
        Me.btnManageQue.Name = "btnManageQue"
        Me.btnManageQue.Size = New System.Drawing.Size(469, 97)
        Me.btnManageQue.TabIndex = 5
        Me.btnManageQue.Text = "MANAGE QUEUE"
        Me.btnManageQue.UseVisualStyleBackColor = False
        '
        'btnAddQue
        '
        Me.btnAddQue.BackColor = System.Drawing.Color.ForestGreen
        Me.btnAddQue.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddQue.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnAddQue.Location = New System.Drawing.Point(33, 125)
        Me.btnAddQue.Name = "btnAddQue"
        Me.btnAddQue.Size = New System.Drawing.Size(469, 97)
        Me.btnAddQue.TabIndex = 4
        Me.btnAddQue.Text = "ADD QUEUE"
        Me.btnAddQue.UseVisualStyleBackColor = False
        '
        'btnCustQueDashboard
        '
        Me.btnCustQueDashboard.BackColor = System.Drawing.Color.ForestGreen
        Me.btnCustQueDashboard.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustQueDashboard.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnCustQueDashboard.Location = New System.Drawing.Point(33, 22)
        Me.btnCustQueDashboard.Name = "btnCustQueDashboard"
        Me.btnCustQueDashboard.Size = New System.Drawing.Size(469, 97)
        Me.btnCustQueDashboard.TabIndex = 3
        Me.btnCustQueDashboard.Text = "CUSTOMER QUEUE DASHBOARD"
        Me.btnCustQueDashboard.UseVisualStyleBackColor = False
        '
        'Queuefrms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 346)
        Me.Controls.Add(Me.btnManageQue)
        Me.Controls.Add(Me.btnAddQue)
        Me.Controls.Add(Me.btnCustQueDashboard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Queuefrms"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Queuefrms"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnManageQue As System.Windows.Forms.Button
    Friend WithEvents btnAddQue As System.Windows.Forms.Button
    Friend WithEvents btnCustQueDashboard As System.Windows.Forms.Button
End Class
