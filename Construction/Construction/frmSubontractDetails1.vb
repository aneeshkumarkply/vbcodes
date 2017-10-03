Public Class frmSubontractDetails1
    Private Sub frmSubontractDetails1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call clsResize.Change_Resolution(Me, False)
        ' Me.LV_PatiView.BorderStyle = BorderStyle.Fixed3D
        Call showSubContract(Me.LV_PatiView)
        Call clsResize.resizeListViewwidth(Me.LV_PatiView)
    End Sub

    Private Sub LV_PatiView_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LV_PatiView.MouseClick
        Dim SelectedItems As ListView.SelectedListViewItemCollection = _
                     CType(Me.LV_PatiView, ListView).SelectedItems
        If (SelectedItems.Count > 0) Then
            showSubContractDetails(LV_SubConDetails, SelectedItems(0).SubItems(1).Text)
            LV_PatiView.Focus()
        End If
    End Sub

    Private Sub cmdProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmNewProject.ShowDialog()
    End Sub
End Class
