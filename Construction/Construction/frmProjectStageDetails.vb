Public Class frmProjectStageDetails
    Private Sub frmProjectStageDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call clsResize.Change_Resolution(Me, False)
        Call showincomeStage(Me.ListViewIncome)
        Call showexpenseStage(Me.ListViewExpense)
        Call clsResize.resizeListViewwidth(Me.ListViewIncome)
        Call clsResize.resizeListViewwidth(Me.ListViewExpense)
        Call showBalanceactual(Me.lblIncomeActual, Me.lblExpensesActual, Me.lblBalanceActual, Pro_SelectedStage)
    End Sub

    Private Sub ListViewExpense_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewExpense.MouseClick
        Dim SelectedItems As ListView.SelectedListViewItemCollection = _
         CType(Me.ListViewExpense, ListView).SelectedItems
        If (SelectedItems.Count > 0) Then
            Expenseid = SelectedItems(0).SubItems(1).Text
        Else
            MsgBox("Please select the Project", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Expenseid = "Materials" Then
            Me.LV1.Visible = True
            Me.LVDetails.Visible = False
            Me.LV1.Left = Me.ListViewIncome.Left
            Me.LV1.Width = Me.ListViewIncome.Width + Me.ListViewExpense.Width
            Call showMaterials(Me.LV1, True)
        ElseIf Expenseid = "Labour" Then
            Me.LV1.Visible = True
            Me.LVDetails.Visible = False
            Me.LV1.Left = Me.ListViewIncome.Left
            Me.LV1.Width = Me.ListViewIncome.Width + Me.ListViewExpense.Width
            showLabour(Me.LV1)
        ElseIf Expenseid = "Sub Contract" Then
            Me.LV1.Visible = True
            Me.LV1.Width = Me.ListViewIncome.Width + (Me.ListViewIncome.Width / 3)
            Me.LV1.Left = Me.LV1.Left / 2
            showSubContract(Me.LV1)
            Me.LVDetails.Visible = True
        End If
        Call clsResize.resizeListViewwidth(Me.LV1)
    End Sub

    Private Sub ListViewIncome_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewIncome.MouseClick
        Dim SelectedItems As ListView.SelectedListViewItemCollection = _
         CType(Me.ListViewIncome, ListView).SelectedItems
        If (SelectedItems.Count > 0) Then
            Incomeid = SelectedItems(0).SubItems(1).Text
        Else
            MsgBox("Please select the Project", MsgBoxStyle.Information)
            Exit Sub
        End If
        Me.LV1.Visible = True
        Me.LVDetails.Visible = False
        Me.LV1.Left = Me.ListViewIncome.Left
        Me.LV1.Width = Me.ListViewIncome.Width + Me.ListViewExpense.Width
        If Incomeid = "By Cash  / Cheque" Then
            Call showIncome(Me.LV1, "Cash")
        Else
            Call showIncome(Me.LV1, "")
        End If
        Call clsResize.resizeListViewwidth(Me.LV1)
    End Sub

    Private Sub LV1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LV1.MouseClick
        Dim SelectedItems As ListView.SelectedListViewItemCollection = _
                     CType(Me.LV1, ListView).SelectedItems
        If (SelectedItems.Count > 0) Then
            Call showSubContractDetails(LVDetails, SelectedItems(0).SubItems(1).Text)
            Call clsResize.resizeListViewwidth(Me.LVDetails)
            LV1.Focus()
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
    End Sub
End Class
