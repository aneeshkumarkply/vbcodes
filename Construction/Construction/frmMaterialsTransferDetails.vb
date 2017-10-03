Public Class frmMaterialsTransferDetails

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call clsResize.Change_Resolution(Me, False)
        ' Me.LV_Materials.BorderStyle = BorderStyle.Fixed3D
        Call showMaterialsTransfer(Me.LV_Materials)
        Call clsResize.resizeListViewwidth(Me.LV_Materials)
    End Sub
End Class
