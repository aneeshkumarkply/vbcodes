Public Class frmMaterialsDetails
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call clsResize.Change_Resolution(Me, False)
        Me.LV_Materials.BorderStyle = BorderStyle.Fixed3D
        If ShowActualexpense = True Then
            Call showMaterials(Me.LV_Materials, True)
            ShowActualexpense = False
        Else
            Call showMaterials(Me.LV_Materials)
        End If
        Call clsResize.resizeListViewwidth(Me.LV_Materials)
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
    End Sub
End Class
