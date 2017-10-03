<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProject
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
        Me.LV_PatiView = New System.Windows.Forms.ListView
        Me.cmdProject = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LV_PatiView
        '
        Me.LV_PatiView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_PatiView.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_PatiView.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_PatiView.FullRowSelect = True
        Me.LV_PatiView.GridLines = True
        Me.LV_PatiView.Location = New System.Drawing.Point(12, 48)
        Me.LV_PatiView.MultiSelect = False
        Me.LV_PatiView.Name = "LV_PatiView"
        Me.LV_PatiView.Size = New System.Drawing.Size(1132, 556)
        Me.LV_PatiView.TabIndex = 98
        Me.LV_PatiView.UseCompatibleStateImageBehavior = False
        Me.LV_PatiView.View = System.Windows.Forms.View.Details
        '
        'cmdProject
        '
        Me.cmdProject.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProject.Location = New System.Drawing.Point(963, 12)
        Me.cmdProject.Name = "cmdProject"
        Me.cmdProject.Size = New System.Drawing.Size(120, 25)
        Me.cmdProject.TabIndex = 101
        Me.cmdProject.Text = "New Project"
        Me.cmdProject.UseVisualStyleBackColor = True
        '
        'frmProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1152, 744)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdProject)
        Me.Controls.Add(Me.LV_PatiView)
        Me.Name = "frmProject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Project"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LV_PatiView As System.Windows.Forms.ListView
    Friend WithEvents cmdProject As System.Windows.Forms.Button

End Class
