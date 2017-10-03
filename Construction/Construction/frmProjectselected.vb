Public Class frmProjectselected
    Dim cnodbcShow As Odbc.OdbcConnection
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call clsResize.Change_Resolution(Me, False)
        Me.LV_PatiView.BorderStyle = BorderStyle.Fixed3D
        Call showProject(Me.LV_PatiView)
        Call showincome(Me.ListViewIncome)
        Call showexpense(Me.ListViewExpense)
        Call showProjectStages(Me.ListViewStages)
        Call showStock(Me.ListViewMaterilStock)
        Call clsResize.resizeListViewwidth(Me.LV_PatiView)
        Call clsResize.resizeListViewwidth(Me.ListViewIncome)
        Call clsResize.resizeListViewwidth(Me.ListViewExpense)
        Call clsResize.resizeListViewwidth(Me.ListViewMaterilStock)
        Call clsResize.resizeListViewwidth(Me.ListViewStages)
        Call showBalance()
        Call showBalanceactual(Me.lblIncomeActual, Me.lblExpensesActual, Me.lblBalanceActual)
    End Sub

    Public Function showProject(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            'strSQL = "Select Agrement_Date, PRO_Name, Area_Building, Rate, Date_Completion, PRO_Cost,  from Project where Pro_ID='" & ProjectId & "'"
            strSQL = "SELECT Project.Agrement_Date, Project.PRO_Name, Project.Area_Building, Project.Rate, Project.Date_Completion, Project.PRO_Cost, Project_stage.Stage FROM Project INNER JOIN Project_stage ON Project.Pro_Stage = Project_stage.ID where  Project.Pro_ID='" & ProjectId & "'"
            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                Call fill_listview(PatiView, "Project", strSQL, "-120;Date of Agreement; ,70;Name of Project;, -120;Area of Building;Right, 0;Rate;Right, -150;Date of Completion;, -60;Agreed Cost;Right, 80;Current Stage;Center")


            Else
                PatiView.Columns.Clear()
                PatiView.Items.Clear()


            End If
            rstndp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Function showincome(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            strSQL = "SELECT  Income_Type.Income_Type, SUM(Income.Amount) AS Amount  FROM  Income INNER JOIN  Income_Type ON Income.Item = Income_Type.ID  GROUP BY Income_Type.Income_Type, Income.Pro_ID HAVING  (Income.Pro_ID = '" & ProjectId & "')"
            'strSQL = "SELECT Item, SUM(Amount) as Amount FROM   Income WHERE  (Pro_ID = '" & ProjectId & "') GROUP BY Item"
            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                Call fill_listview(PatiView, "Income", strSQL, " 200;Item;, 60;Amount;Right")

            Else
                PatiView.Columns.Clear()
                PatiView.Items.Clear()


            End If
            rstndp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Function showexpense(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            strSQL = "SELECT Item, SUM(Amount) as Amount FROM   Expenses WHERE  (Pro_ID = '" & ProjectId & "') GROUP BY Item"
            'strSQL = "SELECT [Date], Item, Amount FROM   Income" ' WHERE  (Pro_ID = 'P001') GROUP BY [Date], Item"
            '"Select * from Project where Pro_ID='" & ProjectId & "'"
            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                Call fill_listview(PatiView, "Expenses", strSQL, " 200;Item;, 60;Amount;Right")


            Else
                PatiView.Columns.Clear()
                PatiView.Items.Clear()


            End If
            rstndp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub CmdIncome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdIncome.Click
        
        If (ProjectId <> "") Then
            frmIncome.ShowDialog()
        Else
            MsgBox("Please select the Project", MsgBoxStyle.Information)
            Exit Sub
        End If
        Call showincome(Me.ListViewIncome)
        Call showBalance()
        Call showBalanceactual(Me.lblIncomeActual, Me.lblExpensesActual, Me.lblBalanceActual)
    End Sub

    Private Sub cmdProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmNewProject.ShowDialog()
    End Sub

    Private Sub cmdPurchase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPurchase.Click
        
        If ProjectId <> "" Then

            frmPurchase.ShowDialog()
        Else
            MsgBox("Please select the Project", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call showexpense(Me.ListViewExpense)
        Call showStock(Me.ListViewMaterilStock)
        Call showBalance()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If ProjectId <> "" Then

            frmLabour.ShowDialog()
        Else
            MsgBox("Please select the Project", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call showexpense(Me.ListViewExpense)
        Call showBalance()
        Call showBalanceactual(Me.lblIncomeActual, Me.lblExpensesActual, Me.lblBalanceActual)
    End Sub

    Public Function showBalance() As Boolean
        Try
            Dim strSQL As String 'Query to run
            Dim strSQL2 As String
            Dim cn1 As New ADODB.Connection
            Dim rsincome As New ADODB.Recordset
            Dim rsexpenses As New ADODB.Recordset
            cn1.Open(odbc_Constr)
            strSQL = "SELECT SUM(Amount) as Amount FROM   Income WHERE  (Pro_ID = '" & ProjectId & "') "
            strSQL2 = "SELECT SUM(Amount) as Amount FROM   Expenses WHERE  (Pro_ID = '" & ProjectId & "')"
            rsincome.Open(strSQL, cn1, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
            rsexpenses.Open(strSQL2, cn1, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
            If Not IsDBNull(rsincome.Fields(0).Value) Then
                lblIncome.Text = rsincome.Fields(0).Value
            Else
                lblIncome.Text = "0"
            End If

            If Not IsDBNull(rsexpenses.Fields(0).Value) Then
                lblExpenses.Text = rsexpenses.Fields(0).Value
            Else
                lblExpenses.Text = "0"
            End If
            
            lblBalance.Text = lblIncome.Text - lblExpenses.Text
            If lblIncome.Text - lblExpenses.Text < 1 Then
                lblBalance.ForeColor = Color.Red
            Else
                lblBalance.ForeColor = Color.Green
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub cmdTransferMaterilas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransferMaterilas.Click
        If (ProjectId <> "") Then
            If MaterialStockID <> "" Then
                frmMaterialsTransfer.ShowDialog()
            Else
                MsgBox("Please select the Item on Materials Stock", MsgBoxStyle.Information)
                Exit Sub
            End If
        Else
            MsgBox("Please select the Project", MsgBoxStyle.Information)
            Exit Sub
        End If
        Call showincome(Me.ListViewIncome)
        Call showStock(Me.ListViewMaterilStock)
        Call showBalance()
        MaterialStockID = ""
    End Sub

    Private Sub ListViewExpense_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewExpense.MouseDoubleClick
        Dim SelectedItems As ListView.SelectedListViewItemCollection = _
         CType(Me.ListViewExpense, ListView).SelectedItems
        If (SelectedItems.Count > 0) Then
            Expenseid = SelectedItems(0).SubItems(1).Text
        Else
            MsgBox("Please select the Project", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Expenseid = "Materials" Then
            frmShowDetails.MdiParent = frmMain
            frmShowDetails.Show()
            frmShowDetails.loadLV("Materials", False)
        ElseIf Expenseid = "Labour" Then
            frmShowDetails.MdiParent = frmMain
            frmShowDetails.Show()
            frmShowDetails.loadLV("Labour", False)
        ElseIf Expenseid = "Sub Contract" Then
            frmShowDetails.MdiParent = frmMain
            frmShowDetails.Show()
            frmShowDetails.loadLV("Sub Contract", False)
        End If

    End Sub

    Private Sub ListViewIncome_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewIncome.MouseDoubleClick
        Dim SelectedItems As ListView.SelectedListViewItemCollection = _
         CType(Me.ListViewIncome, ListView).SelectedItems
        If (SelectedItems.Count > 0) Then
            Incomeid = SelectedItems(0).SubItems(1).Text
        Else
            MsgBox("Please select the Project", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Incomeid = "By Cash  / Cheque" Or Incomeid = "Selling Cement Bag / Scrap Items" Then
            frmShowDetails.MdiParent = frmMain
            frmShowDetails.Show()
            frmShowDetails.loadLV("Income", False)
        Else
            frmShowDetails.MdiParent = frmMain
            frmShowDetails.Show()
            Call showMaterialsTransfer(frmShowDetails.LV_Materials)
            Call clsResize.resizeListViewwidth(frmShowDetails.LV_Materials)
        End If

    End Sub


    Private Sub cmdSubContr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubContr.Click
        If (ProjectId <> "") Then
            frmSubCotract.ShowDialog()
        Else
            MsgBox("Please select the Project", MsgBoxStyle.Information)
            Exit Sub
        End If
        Call showexpense(Me.ListViewExpense)
        Call showBalance()
        Call showBalanceactual(Me.lblIncomeActual, Me.lblExpensesActual, Me.lblBalanceActual)
    End Sub

    Public Function showStock(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            'strSQL = "SELECT Materials_Stock.ID, Materials_Type.Item, Materials_Stock.Rate, Materials_Stock.Quantity FROM Materials_Type INNER JOIN Materials_Stock ON Materials_Type.ID = Materials_Stock.Item  WHERE (Materials_Stock.Pro_ID = '" & ProjectId & "')"
            strSQL = "SELECT Materials_Stock.ID, Materials_Type.Item, Materials_Type_Sub.Item AS Sub_Item, Materials_Stock.Rate, Materials_Stock.Quantity FROM Materials_Stock LEFT OUTER JOIN Materials_Type ON Materials_Stock.Item = Materials_Type.ID LEFT OUTER JOIN Materials_Type_Sub ON Materials_Stock.Sub_item = Materials_Type_Sub.ID AND Materials_Stock.Item = Materials_Type_Sub.Main_ID WHERE (Materials_Stock.Pro_ID = '" & ProjectId & "')"
            'strSQL = "SELECT Item, SUM(Amount) as Amount FROM   Income WHERE  (Pro_ID = '" & ProjectId & "') GROUP BY Item"
            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                Call fill_listview(PatiView, "Materials_Stock", strSQL, "40;ID;Center, 100;Item;,-20;Sub Item;,0;Rate;Right,-20;Quantity;Right")
                Me.cmdMaterialsUsage.Enabled = True
                Me.cmdTransferMaterilas.Enabled = True
            Else
                'PatiView.Columns.Clear()
                PatiView.Items.Clear()
                Me.cmdMaterialsUsage.Enabled = False
                Me.cmdTransferMaterilas.Enabled = False

            End If
            rstndp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub ListViewMaterilStock_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewMaterilStock.MouseClick
        Dim SelectedItems As ListView.SelectedListViewItemCollection = _
             CType(Me.ListViewMaterilStock, ListView).SelectedItems
        If (SelectedItems.Count > 0) Then
            MaterialStockID = SelectedItems(0).SubItems(1).Text
            MaterialSubID = SelectedItems(0).SubItems(3).Text
        End If
    End Sub

    Public Function showProjectStages(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        Try
            Dim strSQL As String 'Query to run
            Dim strSQL1 As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            'strSQL = "Select Agrement_Date, PRO_Name, Area_Building, Rate, Date_Completion, PRO_Cost,  from Project where Pro_ID='" & ProjectId & "'"
            strSQL = "SELECT Pro_Stage FROM Project WHERE Pro_ID = '" & ProjectId & "'"



            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                strSQL1 = "SELECT ID, Stage from Project_stage where ID<=" & rstndp.Item(0)
                Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbcShow)

                Dim rstndp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

                If rstndp1.HasRows = True Then

                    Call fill_listview(PatiView, "Project_stage", strSQL1, "50;ID; , 200;Stages;")


                Else
                    PatiView.Columns.Clear()
                    PatiView.Items.Clear()


                End If
                rstndp1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub cmdMaterialsUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMaterialsUsage.Click
        If (ProjectId <> "") Then
            If MaterialStockID <> "" Then
                frmMaterialsUsage.ShowDialog()
            Else
                MsgBox("Please select the Item on Materials Stock", MsgBoxStyle.Information)
                Exit Sub
            End If
        Else
            MsgBox("Please select the Project", MsgBoxStyle.Information)
            Exit Sub
        End If
        Call showincome(Me.ListViewIncome)
        Call showStock(Me.ListViewMaterilStock)
        Call showBalance()
        Call showBalanceactual(Me.lblIncomeActual, Me.lblExpensesActual, Me.lblBalanceActual)
        MaterialStockID = ""
    End Sub

    Private Sub mnuMaterialsTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaterialsTransfer.Click
        If cmdTransferMaterilas.Enabled = True Then
            cmdTransferMaterilas_Click(sender, e)
        Else
            MsgBox("No Materials in Stock to Transfer", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub mnuMaterialsUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMaterialsUsage.Click

        If cmdMaterialsUsage.Enabled = True Then
            cmdMaterialsUsage_Click(sender, e)
        Else
            MsgBox("No Materials in Stock to Use", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub ListViewStages_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewStages.MouseDoubleClick
        Dim SelectedItems As ListView.SelectedListViewItemCollection = _
         CType(Me.ListViewStages, ListView).SelectedItems
        If (SelectedItems.Count > 0) Then
            Pro_SelectedStage = SelectedItems(0).SubItems(1).Text
        Else
            MsgBox("Please select the Stage", MsgBoxStyle.Information)
            Exit Sub
        End If
        frmProjectStageDetails.MdiParent = frmMain
        frmProjectStageDetails.Show()
    End Sub

    Private Sub ListViewMaterilStock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewMaterilStock.SelectedIndexChanged

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
    End Sub

    Private Sub ListViewIncome_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewIncome.SelectedIndexChanged

    End Sub

    Private Sub ListViewExpense_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewExpense.SelectedIndexChanged

    End Sub

    Private Sub ListViewStages_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewStages.SelectedIndexChanged

    End Sub
End Class
