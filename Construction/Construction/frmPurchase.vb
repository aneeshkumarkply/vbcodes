Public Class frmPurchase
    Private changed As Boolean = False
    Private cnbegintrans As Boolean


    Private Sub frmPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL1 As String
        Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL1 = "select * from  Materials_Type order by Item"
        cnodbc1.Open()
        Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
        Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

        If rsTemp1.HasRows = True Then
            Me.cmbItem.Enabled = True
            Dim sqlblock As String = "select * from  Materials_Type order by Item"
            Combo_List_BoX_DATA_load(Me.cmbItem, sqlblock, "Materials_Type", "Item", "ID")
            Me.cmbItem.Focus()
        End If
        rsTemp1.Close()
        cnodbc1.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'On Error GoTo Erro
        Dim strSQL As String
        Dim cn As New ADODB.Connection
        Dim rsMaterials As New ADODB.Recordset
        Dim rsMaterialsStock As New ADODB.Recordset
        Dim rsExpenses As New ADODB.Recordset
        Dim Materialsselect_max_Id As String
        Dim MaterialsStockselect_max_Id As String
        Dim materialssubid As String
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
        If rsMaterials.State = ADODB.ObjectStateEnum.adStateOpen Then rsMaterials.Close()
        rsMaterials.Open("SELECT * FROM Materials", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsExpenses.State = ADODB.ObjectStateEnum.adStateOpen Then rsExpenses.Close()
        rsExpenses.Open("select* from Expenses", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        Materialsselect_max_Id = select_max_Id("M0001", "ID", "Materials", "PRO_ID='" & ProjectId & "'")
        rsMaterials.AddNew()

        rsMaterials.Fields("Pro_ID").Value = ProjectId
        rsMaterials.Fields("ID").Value = Materialsselect_max_Id
        rsMaterials.Fields("Date_Purchase").Value = txtDate.Text
        rsMaterials.Fields("Item").Value = cmbItem.SelectedValue
        rsMaterials.Fields("Sub_item").Value = materialssubid
        rsMaterials.Fields("Quantity").Value = txtQuantity.Text
        rsMaterials.Fields("Rate").Value = txtRate.Text
        rsMaterials.Fields("Amount").Value = txtAmount.Text


        rsExpenses.AddNew()

        rsExpenses.Fields("Pro_ID").Value = ProjectId
        rsExpenses.Fields("Pro_Stage").Value = Pro_CurrentStage
        rsExpenses.Fields("ID").Value = select_max_Id("E0001", "ID", "Expenses", "PRO_ID='" & ProjectId & "'")
        rsExpenses.Fields("Work_type").Value = cmbItem.SelectedValue
        rsExpenses.Fields("Date_Expense").Value = txtDate.Text
        rsExpenses.Fields("Item").Value = "Materials"
        rsExpenses.Fields("Item_ID").Value = Materialsselect_max_Id
        rsExpenses.Fields("Amount").Value = txtAmount.Text
        strSQL = "SELECT * FROM Materials_Stock where PRO_ID='" & ProjectId & "' and Item=" & cmbItem.SelectedValue & " and Rate=" & txtRate.Text & " and Sub_item='" & materialssubid & "'"
        If rsMaterialsStock.State = ADODB.ObjectStateEnum.adStateOpen Then rsMaterialsStock.Close()
        rsMaterialsStock.Open(strsql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMaterialsStock.RecordCount > 0 Then
            rsMaterialsStock.Fields("Quantity").Value = rsMaterialsStock.Fields("Quantity").Value + txtQuantity.Text
        Else
            MaterialsStockselect_max_Id = select_max_Id("MS0001", "ID", "Materials_Stock", "PRO_ID='" & ProjectId & "'")
            rsMaterialsStock.AddNew()
            rsMaterialsStock.Fields("Pro_ID").Value = ProjectId
            rsMaterialsStock.Fields("ID").Value = MaterialsStockselect_max_Id
            rsMaterialsStock.Fields("Item").Value = cmbItem.SelectedValue
            rsMaterialsStock.Fields("Sub_item").Value = materialssubid
            rsMaterialsStock.Fields("Quantity").Value = txtQuantity.Text
            rsMaterialsStock.Fields("Rate").Value = txtRate.Text

        End If


        rsMaterials.Update()
        rsExpenses.Update()
        rsMaterialsStock.Update()
        cn.CommitTrans()
        rsMaterials.Close()
        rsExpenses.Close()
        rsMaterialsStock.Close()
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

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged

    End Sub

    Private Sub txtRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.TextChanged
        If txtQuantity.Text <> "" And txtRate.Text <> "" Then
            txtAmount.Text = txtQuantity.Text * txtRate.Text
        Else
            txtAmount.Text = 0
        End If

    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        If txtQuantity.Text <> "" And txtRate.Text <> "" Then
            txtAmount.Text = txtQuantity.Text * txtRate.Text
        Else
            txtAmount.Text = 0
        End If
    End Sub

    
    Private Sub cmbItem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbItem.LostFocus
        If cmbItem.SelectedValue = 16 Then
            Dim strSQL1 As String
            Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
            strSQL1 = "select * from  Materials_Type_Sub order by Item"
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
    End Sub

    Private Sub cmbItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbItem.SelectedIndexChanged

    End Sub
End Class