<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectselected
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
        Me.LV_PatiView = New System.Windows.Forms.ListView
        Me.CmdIncome = New System.Windows.Forms.Button
        Me.cmdPurchase = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListViewIncome = New System.Windows.Forms.ListView
        Me.ListViewExpense = New System.Windows.Forms.ListView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblBalance = New System.Windows.Forms.Label
        Me.lblIncome = New System.Windows.Forms.Label
        Me.lblExpenses = New System.Windows.Forms.Label
        Me.cmdTransferMaterilas = New System.Windows.Forms.Button
        Me.cmdSubContr = New System.Windows.Forms.Button
        Me.ListViewMaterilStock = New System.Windows.Forms.ListView
        Me.cmsStock = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMaterialsTransfer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMaterialsUsage = New System.Windows.Forms.ToolStripMenuItem
        Me.Label7 = New System.Windows.Forms.Label
        Me.ListViewStages = New System.Windows.Forms.ListView
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblExpensesActual = New System.Windows.Forms.Label
        Me.lblBalanceActual = New System.Windows.Forms.Label
        Me.lblIncomeActual = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmdMaterialsUsage = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmsStock.SuspendLayout()
        Me.SuspendLayout()
        '
        'LV_PatiView
        '
        Me.LV_PatiView.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_PatiView.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_PatiView.FullRowSelect = True
        Me.LV_PatiView.GridLines = True
        Me.LV_PatiView.Location = New System.Drawing.Point(12, 23)
        Me.LV_PatiView.MultiSelect = False
        Me.LV_PatiView.Name = "LV_PatiView"
        Me.LV_PatiView.Size = New System.Drawing.Size(1124, 70)
        Me.LV_PatiView.TabIndex = 98
        Me.LV_PatiView.UseCompatibleStateImageBehavior = False
        Me.LV_PatiView.View = System.Windows.Forms.View.Details
        '
        'CmdIncome
        '
        Me.CmdIncome.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdIncome.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdIncome.Location = New System.Drawing.Point(1040, 114)
        Me.CmdIncome.Name = "CmdIncome"
        Me.CmdIncome.Size = New System.Drawing.Size(86, 25)
        Me.CmdIncome.TabIndex = 99
        Me.CmdIncome.Text = "Income"
        Me.CmdIncome.UseVisualStyleBackColor = True
        '
        'cmdPurchase
        '
        Me.cmdPurchase.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPurchase.Location = New System.Drawing.Point(1040, 143)
        Me.cmdPurchase.Name = "cmdPurchase"
        Me.cmdPurchase.Size = New System.Drawing.Size(86, 25)
        Me.cmdPurchase.TabIndex = 101
        Me.cmdPurchase.Text = "Purchase"
        Me.cmdPurchase.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(435, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 18)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Current Project"
        '
        'ListViewIncome
        '
        Me.ListViewIncome.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewIncome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ListViewIncome.FullRowSelect = True
        Me.ListViewIncome.GridLines = True
        Me.ListViewIncome.Location = New System.Drawing.Point(12, 114)
        Me.ListViewIncome.MultiSelect = False
        Me.ListViewIncome.Name = "ListViewIncome"
        Me.ListViewIncome.Size = New System.Drawing.Size(498, 81)
        Me.ListViewIncome.TabIndex = 103
        Me.ToolTip1.SetToolTip(Me.ListViewIncome, "Double Clitck to veiw details")
        Me.ListViewIncome.UseCompatibleStateImageBehavior = False
        Me.ListViewIncome.View = System.Windows.Forms.View.Details
        '
        'ListViewExpense
        '
        Me.ListViewExpense.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewExpense.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ListViewExpense.FullRowSelect = True
        Me.ListViewExpense.GridLines = True
        Me.ListViewExpense.Location = New System.Drawing.Point(516, 114)
        Me.ListViewExpense.MultiSelect = False
        Me.ListViewExpense.Name = "ListViewExpense"
        Me.ListViewExpense.Size = New System.Drawing.Size(505, 81)
        Me.ListViewExpense.TabIndex = 104
        Me.ToolTip1.SetToolTip(Me.ListViewExpense, "Double Clitck to veiw details")
        Me.ListViewExpense.UseCompatibleStateImageBehavior = False
        Me.ListViewExpense.View = System.Windows.Forms.View.Details
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(234, 96)
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
        Me.Label3.Location = New System.Drawing.Point(728, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 18)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Expenses"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1040, 172)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 25)
        Me.Button1.TabIndex = 107
        Me.Button1.Text = "Labour"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 207)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 18)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Total Income:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(405, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 18)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Total Expenses:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(831, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 18)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "Balance:"
        '
        'lblBalance
        '
        Me.lblBalance.AutoSize = True
        Me.lblBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalance.Location = New System.Drawing.Point(905, 207)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(0, 18)
        Me.lblBalance.TabIndex = 112
        '
        'lblIncome
        '
        Me.lblIncome.AutoSize = True
        Me.lblIncome.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncome.Location = New System.Drawing.Point(143, 207)
        Me.lblIncome.Name = "lblIncome"
        Me.lblIncome.Size = New System.Drawing.Size(0, 18)
        Me.lblIncome.TabIndex = 111
        '
        'lblExpenses
        '
        Me.lblExpenses.AutoSize = True
        Me.lblExpenses.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpenses.Location = New System.Drawing.Point(535, 207)
        Me.lblExpenses.Name = "lblExpenses"
        Me.lblExpenses.Size = New System.Drawing.Size(0, 18)
        Me.lblExpenses.TabIndex = 113
        '
        'cmdTransferMaterilas
        '
        Me.cmdTransferMaterilas.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTransferMaterilas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTransferMaterilas.Location = New System.Drawing.Point(1040, 256)
        Me.cmdTransferMaterilas.Name = "cmdTransferMaterilas"
        Me.cmdTransferMaterilas.Size = New System.Drawing.Size(86, 48)
        Me.cmdTransferMaterilas.TabIndex = 114
        Me.cmdTransferMaterilas.Text = "Transfer Materials"
        Me.cmdTransferMaterilas.UseVisualStyleBackColor = True
        '
        'cmdSubContr
        '
        Me.cmdSubContr.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSubContr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubContr.Location = New System.Drawing.Point(1040, 201)
        Me.cmdSubContr.Name = "cmdSubContr"
        Me.cmdSubContr.Size = New System.Drawing.Size(86, 49)
        Me.cmdSubContr.TabIndex = 115
        Me.cmdSubContr.Text = "Sub Contract"
        Me.cmdSubContr.UseVisualStyleBackColor = True
        '
        'ListViewMaterilStock
        '
        Me.ListViewMaterilStock.ContextMenuStrip = Me.cmsStock
        Me.ListViewMaterilStock.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewMaterilStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ListViewMaterilStock.FullRowSelect = True
        Me.ListViewMaterilStock.GridLines = True
        Me.ListViewMaterilStock.Location = New System.Drawing.Point(12, 258)
        Me.ListViewMaterilStock.MultiSelect = False
        Me.ListViewMaterilStock.Name = "ListViewMaterilStock"
        Me.ListViewMaterilStock.Size = New System.Drawing.Size(498, 265)
        Me.ListViewMaterilStock.TabIndex = 116
        Me.ListViewMaterilStock.UseCompatibleStateImageBehavior = False
        Me.ListViewMaterilStock.View = System.Windows.Forms.View.Details
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(167, 239)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 18)
        Me.Label7.TabIndex = 117
        Me.Label7.Text = "Materials Stock"
        '
        'ListViewStages
        '
        Me.ListViewStages.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewStages.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ListViewStages.FullRowSelect = True
        Me.ListViewStages.GridLines = True
        Me.ListViewStages.Location = New System.Drawing.Point(523, 258)
        Me.ListViewStages.MultiSelect = False
        Me.ListViewStages.Name = "ListViewStages"
        Me.ListViewStages.Size = New System.Drawing.Size(498, 265)
        Me.ListViewStages.TabIndex = 118
        Me.ToolTip1.SetToolTip(Me.ListViewStages, "Double Clitck to veiw details")
        Me.ListViewStages.UseCompatibleStateImageBehavior = False
        Me.ListViewStages.View = System.Windows.Forms.View.Details
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(667, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(192, 18)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "Stages including Current"
        '
        'lblExpensesActual
        '
        Me.lblExpensesActual.AutoSize = True
        Me.lblExpensesActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpensesActual.Location = New System.Drawing.Point(558, 536)
        Me.lblExpensesActual.Name = "lblExpensesActual"
        Me.lblExpensesActual.Size = New System.Drawing.Size(0, 18)
        Me.lblExpensesActual.TabIndex = 125
        '
        'lblBalanceActual
        '
        Me.lblBalanceActual.AutoSize = True
        Me.lblBalanceActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalanceActual.Location = New System.Drawing.Point(928, 536)
        Me.lblBalanceActual.Name = "lblBalanceActual"
        Me.lblBalanceActual.Size = New System.Drawing.Size(0, 18)
        Me.lblBalanceActual.TabIndex = 124
        '
        'lblIncomeActual
        '
        Me.lblIncomeActual.AutoSize = True
        Me.lblIncomeActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncomeActual.Location = New System.Drawing.Point(174, 536)
        Me.lblIncomeActual.Name = "lblIncomeActual"
        Me.lblIncomeActual.Size = New System.Drawing.Size(0, 18)
        Me.lblIncomeActual.TabIndex = 123
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(854, 536)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 18)
        Me.Label12.TabIndex = 122
        Me.Label12.Text = "Balance:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(415, 536)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(137, 18)
        Me.Label13.TabIndex = 121
        Me.Label13.Text = "Actual Expenses:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(55, 536)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 18)
        Me.Label14.TabIndex = 120
        Me.Label14.Text = "Actual Income:"
        '
        'cmdMaterialsUsage
        '
        Me.cmdMaterialsUsage.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMaterialsUsage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMaterialsUsage.Location = New System.Drawing.Point(1040, 310)
        Me.cmdMaterialsUsage.Name = "cmdMaterialsUsage"
        Me.cmdMaterialsUsage.Size = New System.Drawing.Size(86, 48)
        Me.cmdMaterialsUsage.TabIndex = 126
        Me.cmdMaterialsUsage.Text = "Materials Usage"
        Me.cmdMaterialsUsage.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.Tag = ""
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'cmdClose
        '
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(1040, 498)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(86, 25)
        Me.cmdClose.TabIndex = 127
        Me.cmdClose.Text = "Go Back"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmProjectselected
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1152, 744)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdMaterialsUsage)
        Me.Controls.Add(Me.lblExpensesActual)
        Me.Controls.Add(Me.lblBalanceActual)
        Me.Controls.Add(Me.lblIncomeActual)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ListViewStages)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ListViewMaterilStock)
        Me.Controls.Add(Me.cmdSubContr)
        Me.Controls.Add(Me.cmdTransferMaterilas)
        Me.Controls.Add(Me.lblExpenses)
        Me.Controls.Add(Me.lblBalance)
        Me.Controls.Add(Me.lblIncome)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListViewExpense)
        Me.Controls.Add(Me.ListViewIncome)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdPurchase)
        Me.Controls.Add(Me.CmdIncome)
        Me.Controls.Add(Me.LV_PatiView)
        Me.Name = "frmProjectselected"
        Me.Text = "Current Project"
        Me.cmsStock.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LV_PatiView As System.Windows.Forms.ListView
    Friend WithEvents CmdIncome As System.Windows.Forms.Button
    Friend WithEvents cmdPurchase As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListViewIncome As System.Windows.Forms.ListView
    Friend WithEvents ListViewExpense As System.Windows.Forms.ListView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents lblIncome As System.Windows.Forms.Label
    Friend WithEvents lblExpenses As System.Windows.Forms.Label
    Friend WithEvents cmdTransferMaterilas As System.Windows.Forms.Button
    Friend WithEvents cmdSubContr As System.Windows.Forms.Button
    Friend WithEvents ListViewMaterilStock As System.Windows.Forms.ListView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ListViewStages As System.Windows.Forms.ListView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblExpensesActual As System.Windows.Forms.Label
    Friend WithEvents lblBalanceActual As System.Windows.Forms.Label
    Friend WithEvents lblIncomeActual As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmdMaterialsUsage As System.Windows.Forms.Button
    Friend WithEvents cmsStock As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMaterialsTransfer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMaterialsUsage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdClose As System.Windows.Forms.Button

End Class
