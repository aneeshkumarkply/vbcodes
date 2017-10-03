<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubontractDetails1
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
        Me.LV_SubConDetails = New System.Windows.Forms.ListView
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
        Me.LV_PatiView.Location = New System.Drawing.Point(23, 48)
        Me.LV_PatiView.MultiSelect = False
        Me.LV_PatiView.Name = "LV_PatiView"
        Me.LV_PatiView.Size = New System.Drawing.Size(688, 556)
        Me.LV_PatiView.TabIndex = 98
        Me.LV_PatiView.UseCompatibleStateImageBehavior = False
        Me.LV_PatiView.View = System.Windows.Forms.View.Details
        '
        'LV_SubConDetails
        '
        Me.LV_SubConDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_SubConDetails.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LV_SubConDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LV_SubConDetails.FullRowSelect = True
        Me.LV_SubConDetails.GridLines = True
        Me.LV_SubConDetails.Location = New System.Drawing.Point(735, 48)
        Me.LV_SubConDetails.MultiSelect = False
        Me.LV_SubConDetails.Name = "LV_SubConDetails"
        Me.LV_SubConDetails.Size = New System.Drawing.Size(398, 556)
        Me.LV_SubConDetails.TabIndex = 99
        Me.LV_SubConDetails.UseCompatibleStateImageBehavior = False
        Me.LV_SubConDetails.View = System.Windows.Forms.View.Details
        '
        'frmSubontractDetails1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1152, 744)
        Me.Controls.Add(Me.LV_SubConDetails)
        Me.Controls.Add(Me.LV_PatiView)
        Me.Name = "frmSubontractDetails1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Project"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LV_PatiView As System.Windows.Forms.ListView
    Friend WithEvents LV_SubConDetails As System.Windows.Forms.ListView

End Class
