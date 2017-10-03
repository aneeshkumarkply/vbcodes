Public Class frmMaterialsTransfer
    Private changed As Boolean = False
    Private cnbegintrans As Boolean
    Private strQuantity As String
    Private materialssubid As String

    Private Sub frmMaterilasTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_comboproject()
        load_combomaterilas()
        load_comboSubmaterilas()
        load_datatotextbox()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'On Error GoTo Erro
        Dim cn As New ADODB.Connection
        Dim rsMaterials As New ADODB.Recordset
        Dim rsExpenses As New ADODB.Recordset
        Dim rsIncome As New ADODB.Recordset
        Dim rsprostage As New ADODB.Recordset
        Dim rsMaterialsStock As New ADODB.Recordset
        Dim rsMaterialsStock1 As New ADODB.Recordset
        Dim rsMaterialstransfer As New ADODB.Recordset
        Dim Materialsselect_max_Id As String
        Dim MaterialsTransferselect_max_Id As String
        Dim MaterialsStockselect_max_Id As String
        Dim strincomeID As String
        If txtAmount.Text = 0 Then
            MsgBox("Please enter Amount", MsgBoxStyle.Exclamation)
            'txtAmount.Focus()
            Exit Sub
        End If
        If txtAmountNew.Text = 0 Then
            MsgBox("Please enter Amount", MsgBoxStyle.Exclamation)
            'txtAmount.Focus()
            Exit Sub
        End If
        If cmbProject.SelectedValue = Nothing Then
            MsgBox("No Project Selected You Can't Continue", MsgBoxStyle.Exclamation)
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
        If rsIncome.State = ADODB.ObjectStateEnum.adStateOpen Then rsIncome.Close()
        rsIncome.Open("select* from Income", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMaterialstransfer.State = ADODB.ObjectStateEnum.adStateOpen Then rsMaterialstransfer.Close()
        rsMaterialstransfer.Open("SELECT * FROM Materials_transfer", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        MaterialsTransferselect_max_Id = select_max_Id("MT0001", "ID", "Materials_transfer", "Pro_ID_from='" & ProjectId & "'")
        Materialsselect_max_Id = select_max_Id("M0001", "ID", "Materials", "PRO_ID='" & cmbProject.SelectedValue & "'")
        strincomeID = select_max_Id("I0001", "ID", "income", "PRO_ID='" & ProjectId & "'")
        rsMaterials.AddNew()

        rsMaterials.Fields("Pro_ID").Value = cmbProject.SelectedValue
        rsMaterials.Fields("ID").Value = Materialsselect_max_Id
        rsMaterials.Fields("Date_Purchase").Value = txtDate.Text
        rsMaterials.Fields("Item").Value = cmbItem.SelectedValue
        rsMaterials.Fields("Sub_item").Value = materialssubid
        rsMaterials.Fields("Quantity").Value = txtQuantity.Text
        rsMaterials.Fields("Rate").Value = txtRateNew.Text
        rsMaterials.Fields("Amount").Value = txtAmountNew.Text


        rsprostage.Open("SELECT Pro_Stage FROM Project WHERE Pro_ID = '" & cmbProject.SelectedValue & "'", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        rsExpenses.AddNew()


        rsExpenses.Fields("Pro_ID").Value = cmbProject.SelectedValue
        rsExpenses.Fields("Pro_Stage").Value = rsprostage.Fields(0).Value
        rsExpenses.Fields("ID").Value = select_max_Id("E0001", "ID", "Expenses", "PRO_ID='" & cmbProject.SelectedValue & "'")
        rsExpenses.Fields("Work_type").Value = cmbItem.SelectedValue
        rsExpenses.Fields("Date_Expense").Value = txtDate.Text
        rsExpenses.Fields("Item").Value = "Materials"
        rsExpenses.Fields("Item_ID").Value = Materialsselect_max_Id
        rsExpenses.Fields("Amount").Value = txtAmountNew.Text

        rsIncome.AddNew()
        rsIncome.Fields("Pro_ID").Value = ProjectId
        rsIncome.Fields("Pro_Stage").Value = Pro_CurrentStage
        rsIncome.Fields("ID").Value = strincomeID
        rsIncome.Fields("Date_receive").Value = txtDate.Text
        rsIncome.Fields("Item").Value = "3"
        rsIncome.Fields("Amount").Value = txtAmount.Text

        'Materials_transfer
        rsMaterialstransfer.AddNew()
        rsMaterialstransfer("Pro_ID_from").Value = ProjectId
        rsMaterialstransfer("Pro_ID_To").Value = cmbProject.SelectedValue
        rsMaterialstransfer("ID").Value = MaterialsTransferselect_max_Id
        rsMaterialstransfer("Date_Transfer").Value = txtDate.Text
        rsMaterialstransfer("Item").Value = cmbItem.SelectedValue
        rsMaterialstransfer("Sub_item").Value = materialssubid
        rsMaterialstransfer("Quantity").Value = txtQuantity.Text
        rsMaterialstransfer("Rate").Value = txtRate.Text
        rsMaterialstransfer("Amount").Value = txtAmount.Text
        rsMaterialstransfer("RateNew").Value = txtRateNew.Text
        rsMaterialstransfer("AmountNew").Value = txtAmountNew.Text


        If rsMaterialsStock.State = ADODB.ObjectStateEnum.adStateOpen Then rsMaterialsStock.Close()
        rsMaterialsStock.Open("SELECT * FROM Materials_Stock WHERE (ID = '" & MaterialStockID & "' and  Pro_ID='" & ProjectId & " ' and Sub_item='" & materialssubid & "')", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMaterialsStock.RecordCount > 0 Then

            rsMaterialsStock.Fields("Quantity").Value = rsMaterialsStock.Fields("Quantity").Value - txtQuantity.Text

        Else
            MsgBox("Corresponding Data Not Found You Can't Continue", MsgBoxStyle.Critical)
            GoTo Erro
        End If

        If rsMaterialsStock1.State = ADODB.ObjectStateEnum.adStateOpen Then rsMaterialsStock1.Close()
        rsMaterialsStock1.Open("SELECT * FROM Materials_Stock where PRO_ID='" & cmbProject.SelectedValue & "' and Item=" & cmbItem.SelectedValue & " and Rate=" & txtRate.Text & " and Sub_item='" & materialssubid & "'", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMaterialsStock1.RecordCount > 0 Then
            rsMaterialsStock1.Fields("Quantity").Value = rsMaterialsStock1.Fields("Quantity").Value + txtQuantity.Text
        Else
            MaterialsStockselect_max_Id = select_max_Id("MS0001", "ID", "Materials_Stock", "PRO_ID='" & cmbProject.SelectedValue & "'")
            rsMaterialsStock1.AddNew()
            rsMaterialsStock1.Fields("Pro_ID").Value = cmbProject.SelectedValue
            rsMaterialsStock1.Fields("ID").Value = MaterialsStockselect_max_Id
            rsMaterialsStock1.Fields("Item").Value = cmbItem.SelectedValue
            rsMaterialsStock1.Fields("Sub_item").Value = materialssubid
            rsMaterialsStock1.Fields("Quantity").Value = txtQuantity.Text
            rsMaterialsStock1.Fields("Rate").Value = txtRateNew.Text

        End If

        rsMaterials.Update()
        rsExpenses.Update()
        rsIncome.Update()
        rsMaterialstransfer.Update()
        rsMaterialsStock.Update()
        rsMaterialsStock1.Update()
        cn.CommitTrans()
        rsMaterials.Close()
        rsExpenses.Close()
        rsIncome.Close()
        rsprostage.Close()
        rsMaterialstransfer.Close()
        rsMaterialsStock1.Close()
        cnbegintrans = False
        cn.Execute("Delete from Materials_Stock WHERE ID = '" & MaterialStockID & "' and Quantity=0" & " and  Pro_ID='" & ProjectId & "'")
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
    Private Function load_comboproject() As Boolean
        Dim strSQL1 As String
        Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL1 = "select * from  Project where Pro_ID<>'" & ProjectId & "' order by PRO_Name"
        cnodbc1.Open()
        Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
        Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

        If rsTemp1.HasRows = True Then
            Me.cmbItem.Enabled = True
            Dim sqlblock As String = strSQL1
            Combo_List_BoX_DATA_load(Me.cmbProject, sqlblock, "Project", "PRO_Name", "Pro_ID")
            Me.cmbItem.Focus()
        End If
        rsTemp1.Close()
        cnodbc1.Close()
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
            strQuantity = rsTemp1.Item(0)
            Me.txtRate.Text = rsTemp1.Item(1)
            Me.txtAmount.Text = rsTemp1.Item(0) * rsTemp1.Item(1)
            Me.txtRateNew.Text = rsTemp1.Item(1)
            Me.txtAmountNew.Text = rsTemp1.Item(0) * rsTemp1.Item(1)
        End If
        rsTemp1.Close()
        cnodbc1.Close()
    End Function

    Private Sub txtQuantity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.LostFocus
        If Val(txtQuantity.Text) > Val(strQuantity) Then
            MsgBox("Can't Transfer Materials Higher than tha actual stock", MsgBoxStyle.Question)
            txtQuantity.Text = strQuantity
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged

        If txtQuantity.Text = "." Then
            'txtQuantity.Text = "0."
            txtQuantity.AppendText("0")
        End If

        If txtQuantity.Text <> "" And txtRate.Text <> "" Then
            txtAmount.Text = txtQuantity.Text * txtRate.Text
        Else
            txtAmount.Text = 0
        End If
        If txtQuantity.Text <> "" And txtRateNew.Text <> "" Then
            txtAmountNew.Text = txtQuantity.Text * txtRateNew.Text
        Else
            txtAmountNew.Text = 0
        End If
    End Sub

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
            Label7.Visible = True
            If changed = False Then
                txtQuantity.Top = txtQuantity.Top + 34
                txtRate.Top = txtRate.Top + 34
                txtAmount.Top = txtAmount.Top + 34
                Label5.Top = Label5.Top + 34
                Label3.Top = Label3.Top + 34
                Label4.Top = Label4.Top + 34
                Label6.Top = Label6.Top + 34
                cmbProject.Top = cmbProject.Top + 34
                txtRateNew.Top = txtRateNew.Top + 34
                txtAmountNew.Top = txtAmountNew.Top + 34
                Label8.Top = Label8.Top + 34
                Label9.Top = Label9.Top + 34
                changed = True
            End If
            cmbSubItem.Focus()
        End If
    End Function

    Private Sub txtRateNew_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRateNew.TextChanged
        If txtQuantity.Text <> "" And txtRateNew.Text <> "" Then
            txtAmountNew.Text = txtQuantity.Text * txtRateNew.Text
        Else
            txtAmountNew.Text = 0
        End If
    End Sub

    Private Sub txtRateNew_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRateNew.LostFocus
        If txtRateNew.Text = "" Then txtRateNew.Text = txtRate.Text
    End Sub
End Class