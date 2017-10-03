Public Class frmExpenditure
    Private Sub frmExpenditure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL1 As String
        Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL1 = "select * from  Income_Type order by id"
        cnodbc1.Open()
        Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
        Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

        If rsTemp1.HasRows = True Then
            Me.cmbItem.Enabled = True
            Dim sqlblock As String = "select * from  Income_Type order by id"
            Combo_List_BoX_DATA_load(Me.cmbItem, sqlblock, "Income_Type", "Income_Type", "ID")
            Me.cmbItem.Focus()
        End If
        rsTemp1.Close()
        cnodbc1.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtAmount.Text = 0 Then
            MsgBox("Please enter Amount", MsgBoxStyle.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        Dim strSQL1 As String
        Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL1 = "INSERT INTO Income (Pro_ID, ID, [Date], Item, Amount) VALUES(" & ProjectId & "," & select_max_Id(1, "ID", "income") & ", '" & txtDate.Text & "', '" & cmbItem.SelectedValue & "', '" & txtAmount.Text & "')"
        cnodbc1.Open()
        Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
        Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()
        rsTemp1.Close()
        cnodbc1.Close()
        Me.Close()

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


    Private Sub txtAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.GotFocus
        txtAmount.SelectAll()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DisallowSingleDoubleQuate(e)
    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged

    End Sub
End Class