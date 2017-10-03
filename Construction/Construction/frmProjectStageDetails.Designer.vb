<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectStageDetails
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
        Me.components = New System.ComponentModel.Container
        Me.ListViewIncome = New System.Windows.Forms.ListView
        Me.ListViewExpense = New System.Windows.Forms.ListView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmsStock = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMaterialsTransfer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMaterialsUsage = New System.Windows.Forms.ToolStripMenuItem
        Me.lblExpensesActual = New System.Windows.Forms.Label
        Me.lblBalanceActual = New System.Windows.Forms.Label
        Me.lblIncomeActual = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.LV1 = New System.Windows.Forms.ListView
        Me.LVDetails = New System.Windows.Forms.ListView
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmsStock.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewIncome
        '
        Me.ListViewIncome.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewIncome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ListViewIncome.FullRowSelect = True
        Me.ListViewIncome.GridLines = True
        Me.ListViewIncome.Location = New System.Drawing.Point(77, 21)
        Me.ListViewIncome.MultiSelect = False
        Me.ListViewIncome.Name = "ListViewIncome"
        Me.ListViewIncome.Size = New System.Drawing.Size(498, 92)
        Me.ListViewIncome.TabIndex = 103
        Me.ListViewIncome.UseCompatibleStateImageBehavior = False
        Me.ListViewIncome.View = System.Windows.Forms.View.Details
        '
        'ListViewExpense
        '
        Me.ListViewExpense.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewExpense.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ListViewExpense.FullRowSelect = True
        Me.ListViewExpense.GridLines = True
        Me.ListViewExpense.Location = New System.Drawing.Point(581, 21)
        Me.ListViewExpense.MultiSelect = False
        Me.ListViewExpense.Name = "ListViewExpense"
        Me.ListViewExpense.Size = New System.Drawing.Size(505, 92)
        Me.ListViewExpense.TabIndex = 104
        Me.ListViewExpense.UseCompatibleStateImageBehavior = False
        Me.ListViewExpense.View = System.Windows.Forms.View.Details
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(299, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 18)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Income"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(793, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 18)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Expenses"
        '
        'cmsStock
        '
        Me.cmsStock.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMaterialsTransfer, Me.mnuMaterialsUsage})
        Me.cmsStock.Name = "cmsStock"
        Me.cmsStock.Size = New System.Drawing.Size(162, 48)
        '
        'mnuMaterialsTransfer
        '
        Me.mnuMaterialsTransfer.Name = "mnuMaterialsTransfer"
        Me.mnuMaterialsTransfer.Size = New System.Drawing.Size(161, 22)
        Me.mnuMaterialsTransfer.Text = "Materials Transfer"
        '
        'mnuMaterialsUsage
        '
        Me.mnuMaterialsUsage.Name = "mnuMaterialsUsage"
        Me.mnuMaterialsUsage.Size = New System.Drawing.Size(161, 22)
        Me.mnuMaterialsUsage.Text = "Materials Usage"
        '
        'lblExpensesActual
        '
        Me.lblExpensesActual.AutoSize = True
        Me.lblExpensesActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpensesActual.Location = New System.Drawing.Point(627, 125)
        Me.lblExpensesActual.Name = "lblExpensesActual"
        Me.lblExpensesActual.Size = New System.Drawing.Size(0, 18)
        Me.lblExpensesActual.TabIndex = 125
        '
        'lblBalanceActual
        '
        Me.lblBalanceActual.AutoSize = True
        Me.lblBalanceActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalanceActual.Location = New System.Drawing.Point(997, 125)
        Me.lblBalanceActual.Name = "lblBalanceActual"
        Me.lblBalanceActual.Size = New System.Drawing.Size(0, 18)
        Me.lblBalanceActual.TabIndex = 124
        '
        'lblIncomeActual
        '
        Me.lblIncomeActual.AutoSize = True
        Me.lblIncomeActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncomeActual.Location = New System.Drawing.Point(243, 125)
        Me.lblIncomeActual.Name = "lblIncomeActual"
        Me.lblIncomeActual.Size = New System.Drawing.Size(0, 18)
        Me.lblIncomeActual.TabIndex = 123
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(923, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 18)
        Me.Label12.TabIndex = 122
        Me.Label12.Text = "Balance:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(484, 125)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(137, 18)
        Me.Label13.TabIndex = 121
        Me.Label13.Text = "Actual Expenses:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(124, 125)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 18)
        Me.Label14.TabIndex = 120
        Me.Label14.Text = "Actual Income:"
        '
        'LV1
        '
        Me.LV1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV1.FullRowSelect = True
        Me.LV1.GridLines = True
        Me.LV1.Location = New System.Drawing.Point(77, 174)
        Me.LV1.MultiSelect = False
        Me.LV1.Name = "LV1"
        Me.LV1.Size = New System.Drawing.Size(1009, 355)
        Me.LV1.TabIndex = 126
        Me.LV1.UseCompatibleStateImageBehavior = False
        Me.LV1.View = System.Windows.Forms.View.Details
        Me.LV1.Visible = False
        '
        'LVDetails
        '
        Me.LVDetails.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LVDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LVDetails.FullRowSelect = True
        Me.LVDetails.GridLines = True
        Me.LVDetails.Location = New System.Drawing.Point(726, 174)
        Me.LVDetails.MultiSelect = False
        Me.LVDetails.Name = "LVDetails"
        Me.LVDetails.Size = New System.Drawing.Size(409, 355)
        Me.LVDetails.TabIndex = 127
        Me.LVDetails.UseCompatibleStateImageBehavior = False
        Me.LVDetails.View = System.Windows.Forms.View.Details
        Me.LVDetails.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(1043, 546)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(86, 25)
        Me.cmdClose.TabIndex = 128
        Me.cmdClose.Text = "Go Back"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmProjectStageDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1152, 744)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.LVDetails)
        Me.Controls.Add(Me.LV1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblExpensesActual)
        Me.Controls.Add(Me.lblBalanceActual)
        Me.Controls.Add(Me.lblIncomeActual)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ListViewExpense)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ListViewIncome)
        Me.Name = "frmProjectStageDetails"
        Me.Text = "Current Project"
        Me.cmsStock.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListViewIncome As System.Windows.Forms.ListView
    Friend WithEvents ListViewExpense As System.Windows.Forms.ListView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblExpensesActual As System.Windows.Forms.Label
    Friend WithEvents lblBalanceActual As System.Windows.Forms.Label
    Friend WithEvents lblIncomeActual As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmsStock As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMaterialsTransfer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaterialsUsage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LV1 As System.Windows.Forms.ListView
    Friend WithEvents LVDetails As System.Windows.Forms.ListView
    Friend WithEvents cmdClose As System.Windows.Forms.Button

End Class
