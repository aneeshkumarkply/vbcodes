Public Class frmCashDetails
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call clsResize.Change_Resolution(Me, False)
        If Incomeid = "By Cash  / Cheque" Then
            Call showIncome(Me.LV_Materials, "Cash")
        Else
            Call showIncome(Me.LV_Materials, "")
        End If
        Call clsResize.resizeListViewwidth(Me.LV_Materials)
    End Sub
End Class
