Public Class frmLabourDetails
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call clsResize.Change_Resolution(Me, False)
        'Me.LV_Labour.BorderStyle = BorderStyle.Fixed3D
        Call showLabour(Me.LV_Labour)
        Call clsResize.resizeListViewwidth(Me.LV_Labour)
    End Sub
End Class
