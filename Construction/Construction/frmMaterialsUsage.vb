Public Class frmMaterialsUsage
    Private changed As Boolean = False
    Private cnbegintrans As Boolean
    Private materialssubid As String

    Private Sub frmMaterialsUsage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_combomaterilas()
        load_datatotextbox()
        load_comboSubmaterilas()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        On Error GoTo Erro
        Dim cn As New ADODB.Connection
        Dim rsMaterialsused As New ADODB.Recordset
        Dim rsMaterialsStock As New ADODB.Recordset
        Dim rsExpensesActual As New ADODB.Recordset
        Dim Materialsselect_max_Id As String
        If txtAmount.Text = 0 Then
            MsgBox("Please enter Amount", MsgBoxStyle.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If

        If cmbItem.SelectedValue = 16 Then
            materialssubid = cmbSubItem.SelectedValue
        Else
            materialssubid = " "
        End If

        cn.Open(odbc_Constr)
        cn.BeginTrans()
        cnbegintrans = True
        If rsMaterialsused.State = ADODB.ObjectStateEnum.adStateOpen Then rsMaterialsused.Close()
        rsMaterialsused.Open("SELECT * FROM Materials_used", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Materialsselect_max_Id = select_max_Id("MU0001", "ID", "Materials_used", "Pro_ID='" & ProjectId & "'")
        If rsExpensesActual.State = ADODB.ObjectStateEnum.adStateOpen Then rsExpensesActual.Close()
        rsExpensesActual.Open("select* from ExpensesActual", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)


        rsMaterialsused.AddNew()

        rsMaterialsused.Fields("Pro_ID").Value = ProjectId
        rsMaterialsused.Fields("Pro_Stage").Value = Pro_CurrentStage
        rsMaterialsused.Fields("ID").Value = Materialsselect_max_Id
        rsMaterialsused.Fields("Date_Used").Value = txtDate.Text
        rsMaterialsused.Fields("Item").Value = cmbItem.SelectedValue
        rsMaterialsused.Fields("Sub_item").Value = materialssubid
        rsMaterialsused.Fields("Quantity").Value = txtQuantity.Text
        rsMaterialsused.Fields("Rate").Value = txtRate.Text
        rsMaterialsused.Fields("Amount").Value = txtAmount.Text


        If rsMaterialsStock.State = ADODB.ObjectStateEnum.adStateOpen Then rsMaterialsStock.Close()
        rsMaterialsStock.Open("SELECT * FROM Materials_Stock WHERE (ID = '" & MaterialStockID & "' and  Pro_ID='" & ProjectId & " ' and Sub_item='" & materialssubid & "')", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMaterialsStock.RecordCount > 0 Then

            rsMaterialsStock.Fields("Quantity").Value = rsMaterialsStock.Fields("Quantity").Value - txtQuantity.Text

        Else
            MsgBox("Corresponding Data Not Found", MsgBoxStyle.Critical)
        End If

        rsExpensesActual.AddNew()

        rsExpensesActual.Fields("Pro_ID").Value = ProjectId
        rsExpensesActual.Fields("Pro_Stage").Value = Pro_CurrentStage
        rsExpensesActual.Fields("ID").Value = select_max_Id("EA0001", "ID", "ExpensesActual", "PRO_ID='" & ProjectId & "'")
        rsExpensesActual.Fields("Work_type").Value = cmbItem.SelectedValue
        rsExpensesActual.Fields("Date_Expense").Value = txtDate.Text
        rsExpensesActual.Fields("Item").Value = "Materials"
        rsExpensesActual.Fields("Item_ID").Value = Materialsselect_max_Id
        rsExpensesActual.Fields("Amount").Value = txtAmount.Text
        rsMaterialsused.Update()
        rsMaterialsStock.Update()
        rsExpensesActual.Update()
        cn.CommitTrans()
        rsMaterialsused.Close()
        rsMaterialsStock.Close()
        rsExpensesActual.Close()
        cnbegintrans = False
        cn.Execute("Delete from Materials_Stock WHERE ID = '" & MaterialStockID & "' and Quantity=0" & " and  Pro_ID='" & ProjectId & " '")
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
    Private Function load_combomaterilas() As Boolean
        Dim strSQL1 As String
        Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL1 = "SELECT Materials_Type.Item, Materials_Type.ID FROM Materials_Stock INNER JOIN Materials_Type ON Materials_Stock.Item = Materials_Type.ID WHERE (Materials_Stock.ID = '" & MaterialStockID & "' and  Pro_ID='" & ProjectId & " ')"
        cnodbc1.Open()
        Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
        Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

        If rsTemp1.HasRows = True Then
            Me.cmbItem.Enabled = True
            Dim sqlblock As String = strSQL1
            Combo_List_BoX_DATA_load(Me.cmbItem, sqlblock, "Materials_Type", "Item", "ID")
            Me.cmbItem.Focus()
        End If
        rsTemp1.Close()
        cnodbc1.Close()
    End Function
    Private Function load_comboSubmaterilas() As Boolean
        If cmbItem.SelectedValue = 16 Then
            Dim strSQL1 As String
            Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
            strSQL1 = "select * from  Materials_Type_Sub where Main_ID='" & cmbItem.SelectedValue & "' and Item='" & MaterialSubID & "' order by Item"
            cnodbc1.Open()
            Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
            Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

            If rsTemp1.HasRows = True Then
                Me.cmbItem.Enabled = True
                Dim sqlblock As String = strSQL1
                Combo_List_BoX_DATA_load(Me.cmbSubItem, sqlblock, "Materials_Type_Sub", "Item", "ID")
                Me.cmbItem.Focus()
            End If
            rsTemp1.Close()
            cnodbc1.Close()
            cmbSubItem.Visible = True
            Label6.Visible = True
            If changed = False Then
                txtQuantity.Top = txtQuantity.Top + 34
                txtRate.Top = txtRate.Top + 34
                txtAmount.Top = txtAmount.Top + 34
                Label5.Top = Label5.Top + 34
                Label3.Top = Label3.Top + 34
                Label4.Top = Label4.Top + 34
                changed = True
            End If
            cmbSubItem.Focus()
        End If
    End Function

    Private Function load_datatotextbox() As Boolean
        Dim strSQL1 As String
        Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL1 = "SELECT Quantity, Rate FROM Materials_Stock WHERE (ID = '" & MaterialStockID & "' and  Pro_ID='" & ProjectId & " ')"
        cnodbc1.Open()
        Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
        Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

        If rsTemp1.HasRows = True Then
            Me.txtQuantity.Text = rsTemp1.Item(0)
            Me.txtRate.Text = rsTemp1.Item(1)
            Me.txtAmount.Text = rsTemp1.Item(0) * rsTemp1.Item(1)
        End If
        rsTemp1.Close()
        cnodbc1.Close()
    End Function

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        If txtQuantity.Text <> "" And txtRate.Text <> "" Then
            txtAmount.Text = txtQuantity.Text * txtRate.Text
        Else
            txtAmount.Text = 0
        End If
    End Sub
End Class