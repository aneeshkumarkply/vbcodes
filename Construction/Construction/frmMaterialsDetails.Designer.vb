<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaterialsDetails
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
        Me.LV_Materials = New System.Windows.Forms.ListView
        Me.cmdClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LV_Materials
        '
        Me.LV_Materials.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_Materials.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_Materials.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_Materials.FullRowSelect = True
        Me.LV_Materials.GridLines = True
        Me.LV_Materials.Location = New System.Drawing.Point(46, 48)
        Me.LV_Materials.MultiSelect = False
        Me.LV_Materials.Name = "LV_Materials"
        Me.LV_Materials.Size = New System.Drawing.Size(1057, 363)
        Me.LV_Materials.TabIndex = 98
        Me.LV_Materials.UseCompatibleStateImageBehavior = False
        Me.LV_Materials.View = System.Windows.Forms.View.Details
        '
        'cmdClose
        '
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(1017, 440)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(86, 25)
        Me.cmdClose.TabIndex = 128
        Me.cmdClose.Text = "Go Back"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmMaterialsDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1152, 744)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.LV_Materials)
        Me.Name = "frmMaterialsDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Materials Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LV_Materials As System.Windows.Forms.ListView
    Friend WithEvents cmdClose As System.Windows.Forms.Button

End Class
