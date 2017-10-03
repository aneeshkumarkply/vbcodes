Public Class frmLabour

    Private cnbegintrans As Boolean


    Private Sub frmLabour_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL1 As String
        Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL1 = "select * from  Labour_type order by Item"
        cnodbc1.Open()
        Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
        Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

        If rsTemp1.HasRows = True Then
            Me.cmbItem.Enabled = True
            Dim sqlblock As String = "select * from  Labour_type order by Item"
            Combo_List_BoX_DATA_load(Me.cmbItem, sqlblock, "Labour_type", "Item", "ID")
            Me.cmbItem.Focus()
        End If
        rsTemp1.Close()
        cnodbc1.Close()

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        On Error GoTo Erro
        Dim cn As New ADODB.Connection
        Dim rsLabour As New ADODB.Recordset
        Dim rsExpenses As New ADODB.Recordset
        Dim rsExpensesActual As New ADODB.Recordset
        Dim Labourselect_max_Id As String
        If txtAmount.Text = 0 Then
            MsgBox("Please enter Amount", MsgBoxStyle.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If

        cn.Open(odbc_Constr)
        cn.BeginTrans()
        cnbegintrans = True
        If rsLabour.State = ADODB.ObjectStateEnum.adStateOpen Then rsLabour.Close()
        rsLabour.Open("SELECT * FROM Labour", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsExpenses.State = ADODB.ObjectStateEnum.adStateOpen Then rsExpenses.Close()
        rsExpenses.Open("select* from Expenses", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        If rsExpensesActual.State = ADODB.ObjectStateEnum.adStateOpen Then rsExpensesActual.Close()
        rsExpensesActual.Open("select* from ExpensesActual", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)


        Labourselect_max_Id = select_max_Id("L0001", "ID", "Labour", "PRO_ID='" & ProjectId & "'")

        rsLabour.AddNew()

        rsLabour.Fields("Pro_ID").Value = ProjectId
        rsLabour.Fields("Pro_Stage").Value = Pro_CurrentStage
        rsLabour.Fields("ID").Value = Labourselect_max_Id
        rsLabour.Fields("Date_Work").Value = txtDate.Text
        rsLabour.Fields("Item").Value = cmbItem.SelectedValue
        rsLabour.Fields("Sub_item").Value = cmbLabtype.SelectedValue
        rsLabour.Fields("Number_lab").Value = txtQuantity.Text
        rsLabour.Fields("Rate").Value = txtRate.Text
        rsLabour.Fields("Amount").Value = txtAmount.Text


        rsExpenses.AddNew()

        rsExpenses.Fields("Pro_ID").Value = ProjectId
        rsExpenses.Fields("Pro_Stage").Value = Pro_CurrentStage
        rsExpenses.Fields("ID").Value = select_max_Id("E0001", "ID", "Expenses", "PRO_ID='" & ProjectId & "'")
        rsExpenses.Fields("Work_type").Value = cmbItem.SelectedValue
        rsExpenses.Fields("Date_Expense").Value = txtDate.Text
        rsExpenses.Fields("Item").Value = "Labour"
        rsExpenses.Fields("Item_ID").Value = Labourselect_max_Id
        rsExpenses.Fields("Amount").Value = txtAmount.Text


        rsExpensesActual.AddNew()

        rsExpensesActual.Fields("Pro_ID").Value = ProjectId
        rsExpensesActual.Fields("Pro_Stage").Value = Pro_CurrentStage
        rsExpensesActual.Fields("ID").Value = select_max_Id("EA0001", "ID", "ExpensesActual", "PRO_ID='" & ProjectId & "'")
        rsExpensesActual.Fields("Work_type").Value = cmbItem.SelectedValue
        rsExpensesActual.Fields("Date_Expense").Value = txtDate.Text
        rsExpensesActual.Fields("Item").Value = "Labour"
        rsExpensesActual.Fields("Item_ID").Value = Labourselect_max_Id
        rsExpensesActual.Fields("Amount").Value = txtAmount.Text

        rsLabour.Update()
        rsExpenses.Update()
        rsExpensesActual.Update()
        cn.CommitTrans()
        rsLabour.Close()
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
        txtAmount.Text = txtQuantity.Text * txtRate.Text
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DisallowSingleDoubleQuate(e)
    End Sub

    Private Sub cmbLabtype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLabtype.GotFocus
        Dim strSQL2 As String
        Dim cnodbc2 As New Odbc.OdbcConnection(odbc_Constr)

        strSQL2 = "select * from  Labour_type_Sub Where Main_ID = " & cmbItem.SelectedValue & "order by ID"
        cnodbc2.Open()
        Dim NewQuery2 As New Odbc.OdbcCommand(strSQL2, cnodbc2)
        Dim rsTemp2 As Odbc.OdbcDataReader = NewQuery2.ExecuteReader()

        If rsTemp2.HasRows = True Then
            Me.cmbItem.Enabled = True
            Dim sqlblock As String = strSQL2
            Combo_List_BoX_DATA_load(Me.cmbLabtype, sqlblock, "Labour_type_Civil", "Item", "ID")
            Me.cmbItem.Focus()
        End If
        rsTemp2.Close()
        cnodbc2.Close()
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        If txtQuantity.Text <> "" And txtRate.Text <> "" Then
            txtAmount.Text = txtQuantity.Text * txtRate.Text
        Else
            txtAmount.Text = 0
        End If
    End Sub

    Private Sub txtRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.TextChanged
        If txtQuantity.Text <> "" And txtRate.Text <> "" Then
            txtAmount.Text = txtQuantity.Text * txtRate.Text
        Else
            txtAmount.Text = 0
        End If
    End Sub
End Class