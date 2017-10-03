Public Class frmShowDetails
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call clsResize.Change_Resolution(Me, False)
    End Sub
    Public Sub loadLV(ByVal Item As String, ByVal ShowActualexpense As Boolean)
        Select Case Item
            Case "Materials"
                If ShowActualexpense = True Then
                    Call showMaterials(Me.LV_Materials, True)
                    ShowActualexpense = False
                Else
                    Call showMaterials(Me.LV_Materials)
                End If
            Case "Income"
                If Incomeid = "By Cash  / Cheque" Then
                    Call showIncome(Me.LV_Materials, "Cash")
                Else
                    Call showIncome(Me.LV_Materials, "")
                End If
            Case "Labour"
                Call showLabour(Me.LV_Materials)
            Case "Sub Contract"
                Call showSubContract(Me.LV_Materials)
                LV_Materials.Width = LV_Materials.Width / 1.65
        End Select
        Call clsResize.resizeListViewwidth(Me.LV_Materials)
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
    End Sub

    Private Sub LV_Materials_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LV_Materials.MouseClick
        Dim SelectedItems As ListView.SelectedListViewItemCollection = _
                     CType(Me.LV_Materials, ListView).SelectedItems
        If (SelectedItems.Count > 0) Then
            showSubContractDetails(LV_SubConDetails, SelectedItems(0).SubItems(1).Text)
            LV_Materials.Focus()
        End If
    End Sub

    Private Sub LV_Materials_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV_Materials.SelectedIndexChanged

    End Sub
End Class
