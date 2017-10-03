Public Class frmSubCotract
    Private Sub frmSubCotract_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL1 As String
        Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL1 = "select * from  Sub_Contract_type order by id"
        cnodbc1.Open()
        Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
        Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

        If rsTemp1.HasRows = True Then
            Me.cmbItem.Enabled = True
            Dim sqlblock As String = strSQL1
            Combo_List_BoX_DATA_load(Me.cmbItem, sqlblock, "Sub_Contract_type", "Sub_Cont_type", "ID")
            Me.cmbItem.Focus()
        End If
        rsTemp1.Close()
        cnodbc1.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        ' On Error GoTo Erro
        Dim cnbegintrans As Boolean = False
        Dim cn As New ADODB.Connection
        Dim rsSubcont As New ADODB.Recordset
        Dim rsExpenses As New ADODB.Recordset
        Dim rsExpensesActual As New ADODB.Recordset
        Dim rssubcontraname As New ADODB.Recordset
        Dim SubContraselect_max_Id As String
        Dim SubContranameselect_max_Id As String
        If txtAmount.Text = 0 Then
            MsgBox("Please enter Amount", MsgBoxStyle.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If

        cn.Open(odbc_Constr)
        cn.BeginTrans()
        cnbegintrans = True
        If rsSubcont.State = ADODB.ObjectStateEnum.adStateOpen Then rsSubcont.Close()
        rsSubcont.Open("SELECT * FROM SubContract", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsExpenses.State = ADODB.ObjectStateEnum.adStateOpen Then rsExpenses.Close()
        rsExpenses.Open("select* from Expenses", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        If rsExpensesActual.State = ADODB.ObjectStateEnum.adStateOpen Then rsExpensesActual.Close()
        rsExpensesActual.Open("select* from ExpensesActual", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        SubContraselect_max_Id = select_max_Id("SC0001", "ID", "SubContract", "PRO_ID='" & ProjectId & "'")

        rsSubcont.AddNew()

        rsSubcont.Fields("Pro_ID").Value = ProjectId
        rsSubcont.Fields("Pro_Stage").Value = Pro_CurrentStage
        rsSubcont.Fields("ID").Value = SubContraselect_max_Id
        rsSubcont.Fields("Date_Advanced").Value = txtDate.Text
        rsSubcont.Fields("SubCotraType").Value = cmbItem.SelectedValue
        rsSubcont.Fields("Amount").Value = txtAmount.Text


        rsExpenses.AddNew()

        rsExpenses.Fields("Pro_ID").Value = ProjectId
        rsExpenses.Fields("Pro_Stage").Value = Pro_CurrentStage
        rsExpenses.Fields("ID").Value = select_max_Id("E0001", "ID", "Expenses", "PRO_ID='" & ProjectId & "'")
        rsExpenses.Fields("Work_type").Value = cmbItem.SelectedValue
        rsExpenses.Fields("Date_Expense").Value = txtDate.Text
        rsExpenses.Fields("Item").Value = "Sub Contract"
        rsExpenses.Fields("Item_ID").Value = SubContraselect_max_Id
        rsExpenses.Fields("Amount").Value = txtAmount.Text

        rsExpensesActual.AddNew()

        rsExpensesActual.Fields("Pro_ID").Value = ProjectId
        rsExpensesActual.Fields("Pro_Stage").Value = Pro_CurrentStage
        rsExpensesActual.Fields("ID").Value = select_max_Id("EA0001", "ID", "ExpensesActual", "PRO_ID='" & ProjectId & "'")
        rsExpensesActual.Fields("Work_type").Value = cmbItem.SelectedValue
        rsExpensesActual.Fields("Date_Expense").Value = txtDate.Text
        rsExpensesActual.Fields("Item").Value = "Sub Contract"
        rsExpensesActual.Fields("Item_ID").Value = SubContraselect_max_Id
        rsExpensesActual.Fields("Amount").Value = txtAmount.Text


        If rssubcontraname.State = ADODB.ObjectStateEnum.adStateOpen Then rssubcontraname.Close()
        rssubcontraname.Open("SELECT * FROM SubContractorName where PRO_ID='" & ProjectId & "' and SubCotraType=" & cmbItem.SelectedValue, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rssubcontraname.RecordCount = 0 Then
            SubContranameselect_max_Id = select_max_Id("C0001", "ID", "SubContractorName", "PRO_ID='" & ProjectId & "'")
            rssubcontraname.AddNew()
            rssubcontraname.Fields("Pro_ID").Value = ProjectId
            rssubcontraname.Fields("ID").Value = SubContranameselect_max_Id
            rssubcontraname.Fields("SubCotraType").Value = cmbItem.SelectedValue
            rssubcontraname.Fields("NameContra").Value = txtNameContra.Text
            rssubcontraname.Update()
        End If


        rsSubcont.Update()
        rsExpenses.Update()
        rsExpensesActual.Update()
        cn.CommitTrans()
        rsSubcont.Close()
        rsExpenses.Close()
        rsExpensesActual.Close()
        cnbegintrans = False
        MsgBox("Saved Sucessfully", MsgBoxStyle.Information, "Construction")
        cn.Close()
        Me.Dispose()
        Exit Sub
Erro:
        If cnbegintrans = True Then
            cn.RollbackTrans()
            cnbegintrans = False
        End If
        If cn.State = ADODB.ObjectStateEnum.adStateOpen Then cn.Close()
        MsgBox(Err.Number & Err.Description)

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
    End Sub

    Private Sub txtAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.GotFocus
        txtAmount.SelectAll()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DisallowSingleDoubleQuate(e)
    End Sub


    Private Sub txtNameContra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNameContra.GotFocus
        Dim strSQL1 As String
        Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL1 = "SELECT NameContra FROM SubContractorName where PRO_ID='" & ProjectId & "' and SubCotraType=" & cmbItem.SelectedValue
        cnodbc1.Open()
        Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
        Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

        If rsTemp1.HasRows = True Then
            Me.txtNameContra.Text = rsTemp1.Item(0).ToString
        Else
            Me.txtNameContra.Text = ""
        End If
        rsTemp1.Close()
        cnodbc1.Close()
    End Sub
End Class