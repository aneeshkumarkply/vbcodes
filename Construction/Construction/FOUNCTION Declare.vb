Module FOUNCTION_Declare
    Public ProjectId As String
    Public Expenseid As String
    Public Pro_CurrentStage As Integer
    Public Pro_SelectedStage As Integer
    Public Incomeid As String
    Public wusn, wpwd As String
    Public MaterialStockID As String
    'Public ShowActualexpense As Boolean
    Public MaterialSubID As String
    Public Const odbc_Constr As String = "dsn=constr; uid=aneesh;pwd=password;"

    Sub fill_listview(ByVal PatiView As System.Windows.Forms.ListView, ByVal table As String, ByVal strSql As String, ByVal strHeader As String)
        ' Clear list view column headers and items
        clear_ListView(PatiView)
        ' Get SQL Query from textbox
        Dim fillLV_comstr As String = strSql
        Dim fillLV_Con As New Odbc.OdbcConnection(odbc_Constr)

        ' Create Command object
        Dim NewQuery As New Odbc.OdbcCommand(fillLV_comstr, fillLV_Con)

        Try
            ' Open Connection
            Try
                fillLV_Con.Open()
            Catch e As Exception
                MsgBox(e.Message)
            End Try


            ' Execute Command and Get Data 
            Dim NewReader As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            ' Get column names for list view from data reader




            LV_addheaderMaterials(PatiView, strHeader)

            Dim i As Integer
            'For i = 0 To NewReader.FieldCount - 1
            '    Dim header As New ColumnHeader()
            '    header.Text = NewReader.GetName(i)
            '    LV_PatiView.Columns.Add(header)
            'Next

            ' Get rows of data and show in list view
            If NewReader.HasRows = True Then
                While NewReader.Read()

                    ' Create list view item
                    Dim NewItem As New ListViewItem()

                    ' Specify text and subitems of list view
                    'NewItem.Text = NewReader.GetValue(0).ToString
                    NewItem.Text = ""
                    For i = 0 To NewReader.FieldCount - 1
                        If Not IsDBNull(NewReader.GetValue(i)) Then
                            NewItem.SubItems.Add(NewReader.GetValue(i))
                        Else
                            NewItem.SubItems.Add(" ")
                        End If

                    Next

                    ' Add item to list view items collection

                    PatiView.Items.Add(NewItem)
                End While
                PatiView.Items(0).Selected = True
            End If
            ' Close data reader
            NewReader.Close()
            Dim selectItem As New ListViewItem()
            PatiView.FocusedItem = selectItem
        Catch ex As Odbc.OdbcException
            ' Create and error column header
            Dim ErrorHeader As New ColumnHeader()
            ErrorHeader.Text = "oledb Error"
            PatiView.Columns.Add(ErrorHeader)

            ' Add Error List Item
            Dim ErrorItem As New ListViewItem(ex.Message)
            PatiView.Items.Add(ErrorItem)

        Catch ex As Exception
            ' Create and error column header
            Dim ErrorHeader As New ColumnHeader()
            ErrorHeader.Text = "Error"
            PatiView.Columns.Add(ErrorHeader)

            ' Add Error List Item
            Dim ErrorItem As New ListViewItem("An error has occurred")
            PatiView.Items.Add(ErrorItem)

        Finally

            fillLV_Con.Close()
            PatiView.Focus()
        End Try
    End Sub



    Public Function LV_addheaderMaterials(ByVal PatiView As System.Windows.Forms.ListView, ByVal Headname As String) As Boolean
        Try
            Dim txthead As String = " 1;;;," & Headname
            Dim Headername() As String = Split(txthead, ",")

            For Each i In Headername
                Dim head() As String = Split(i, ";", 3)
                Dim txtalign As String
                If head(2) <> "" Then
                    txtalign = head(2)
                Else
                    txtalign = "left"
                End If
                Dim header As New ColumnHeader()
                header.Width = head(0) + 15 * (Len(head(1)))
                Select Case txtalign
                    Case "Center"
                        header.TextAlign = HorizontalAlignment.Center
                    Case "Right"
                        header.TextAlign = HorizontalAlignment.Right
                    Case Else
                        header.TextAlign = HorizontalAlignment.Left
                End Select

                header.Text = head(1)
                PatiView.Columns.Add(header)
            Next

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Function
    Public Function clear_ListView(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        PatiView.Columns.Clear()
        PatiView.Items.Clear()
    End Function

    Public Sub Combo_List_BoX_DATA_load(ByVal mycontrolname As Object, ByVal TheQuery As String, ByVal table As String, ByVal listfield As String, ByVal valuefield As String)
        Try
            Using TheConnection As New Data.Odbc.OdbcConnection(odbc_Constr)
                TheConnection.Open()
                Dim CustomerDataSet As New DataSet
                Dim CustomerDataAdapter As New Odbc.OdbcDataAdapter(TheQuery, TheConnection)
                CustomerDataAdapter.Fill(CustomerDataSet, table)

                With mycontrolname
                    .DataSource = CustomerDataSet.Tables.Item(table)
                    .DisplayMember = listfield
                    .ValueMember = valuefield
                    .SelectedIndex = 0
                End With

                TheConnection.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function GetAssemblyQualifiedName(ByVal ControlType As String) As String
        Dim TYPE_NAME As String = "System.Windows.Forms." + ControlType
        Const FILE_NAME As String = "System.Windows.Forms" 'REMARK! The name of the file without the type (.dll)
        Const VERSION_NUMBER As String = "1.0.3300.0"
        Const CULTURE As String = "neutral"
        Const TOKEN_KEY As String = "b77a5c561934e089"

        'Create the assembly qualified name
        Dim assemblyQualifiedName As String = TYPE_NAME + ", " + FILE_NAME + ", Version=" + VERSION_NUMBER + ", Culture=" + CULTURE + ", PublicKeyToken=" + TOKEN_KEY

        'return the assembly qualified name
        Return assemblyQualifiedName
    End Function
    Public Function select_max_Id(ByVal startid As String, ByVal field As String, ByVal table As String, ByVal strWhere As String) As String
        Try
            select_max_Id = startid
            Dim strSQL1 As String
            Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
            If strWhere <> "" Then
                strSQL1 = "select max(" & field & ") from  " & table & " Where " & strWhere
            Else
                strSQL1 = "select max(" & field & ") from  " & table
            End If

            cnodbc1.Open()
            Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
            Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

            If rsTemp1.HasRows = True Then
                If rsTemp1.Item(0).ToString <> "" Then
                    select_max_Id = Val(Right(rsTemp1.Item(0).ToString, 3)) + 1
                    select_max_Id = Left(rsTemp1.Item(0).ToString, (Len(rsTemp1.Item(0).ToString) - Len(select_max_Id))) & select_max_Id
                End If
            End If
            rsTemp1.Close()
            cnodbc1.Close()
            Return select_max_Id
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function DisallowSingleDoubleQuate(ByVal EventArgs As System.Windows.Forms.KeyPressEventArgs) As Boolean
        Dim KeyAscii As Short = Asc(EventArgs.KeyChar)
        On Error GoTo lblerr
        If KeyAscii = 39 Or KeyAscii = 34 Then
            KeyAscii = 0
        End If
        GoTo EventExitSub
lblerr:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
EventExitSub:
        EventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            EventArgs.Handled = True
        End If
    End Function

    Public Function DisallowTyping(ByVal EventArgs As System.Windows.Forms.KeyPressEventArgs) As Boolean
        Dim KeyAscii As Short = Asc(EventArgs.KeyChar)
        On Error GoTo lblerr
        KeyAscii = 0
        GoTo EventExitSub
lblerr:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
EventExitSub:
        EventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            EventArgs.Handled = True
        End If
    End Function

    Public Function showMaterials(ByVal PatiView As System.Windows.Forms.ListView, Optional ByVal Actualexpense As Boolean = False) As Boolean
        Dim cnodbcShow As Odbc.OdbcConnection
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            If Actualexpense = True Then
                strSQL = "SELECT Materials_used.Date_Used, Materials_Type.Item, Materials_Type_Sub.Item AS Sub_item, Materials_used.Quantity, Materials_used.Rate, Materials_used.Amount FROM Materials_used LEFT OUTER JOIN Materials_Type_Sub ON Materials_used.Sub_item = Materials_Type_Sub.ID AND Materials_used.Item = Materials_Type_Sub.Main_ID LEFT OUTER JOIN Materials_Type ON Materials_used.Item = Materials_Type.ID WHERE (Materials_used.Pro_ID = '" & ProjectId & "')  ORDER BY Materials_used.Date_Used DESC"
            Else
                strSQL = "SELECT Materials.Date_Purchase, Materials_Type.Item, Materials_Type_Sub.Item AS Sub_Item, Materials.Quantity, Materials.Rate, Materials.Amount FROM Materials LEFT OUTER JOIN Materials_Type ON Materials.Item = Materials_Type.ID LEFT OUTER JOIN Materials_Type_Sub ON Materials.Sub_item = Materials_Type_Sub.ID AND Materials.Item = Materials_Type_Sub.Main_ID WHERE (Materials.Pro_ID = '" & ProjectId & "') ORDER BY Materials.Date_Purchase DESC"
            End If

            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then
                If Actualexpense = True Then
                    Call fill_listview(PatiView, "Materials_used", strSQL, " 40;Date;, 90;Item;, 10;Sub_item;, 20;Quantity;Right, 30;Rate;Right, 40;Amount;Right")
                Else
                    Call fill_listview(PatiView, "Materials", strSQL, " 40;Date;, 90;Item;, 10;Sub_item;, 20;Quantity;Right, 30;Rate;Right, 40;Amount;Right")
                End If

            Else
                PatiView.Columns.Clear()
                PatiView.Items.Clear()


            End If
            rstndp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Function showLabour(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        Dim cnodbcShow As Odbc.OdbcConnection
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            strSQL = "SELECT  Labour.Date_Work, Labour_Type.Item, Labour.Sub_item, Labour.Number_lab, Labour.Rate, Labour.Amount FROM Labour INNER JOIN Labour_Type ON Labour.Item = Labour_Type.ID WHERE(Labour.Pro_ID = '" & ProjectId & "') order by Labour.Date_Work desc"
            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                Call fill_listview(PatiView, "Labour", strSQL, " 40;Date;, 90;Item;, 10;Sub_item;, 20;Quantity;Right, 30;Rate;Right, 40;Amount;Right")

            Else
                PatiView.Columns.Clear()
                PatiView.Items.Clear()

            End If
            rstndp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function


    Public Function showSubContract(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        Dim cnodbcShow As Odbc.OdbcConnection
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            strSQL = "SELECT Sub_Contract_type.Sub_Cont_type, SubContractorName.NameContra, SUM(SubContract.Amount) AS Amount  FROM SubContract INNER JOIN SubContractorName ON SubContract.Pro_ID = SubContractorName.PRO_ID AND SubContract.SubCotraType = SubContractorName.SubCotraType INNER JOIN Sub_Contract_type ON SubContract.SubCotraType = Sub_Contract_type.ID GROUP BY Sub_Contract_type.Sub_Cont_type, SubContractorName.PRO_ID, SubContractorName.NameContra HAVING (SubContractorName.PRO_ID = '" & ProjectId & "')"
            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                Call fill_listview(PatiView, "SubContract", strSQL, " -50;Sub Contract Type;,0;Name of Contract;, -50;Amount Advanced;Right")

            Else
                PatiView.Columns.Clear()
                PatiView.Items.Clear()
            End If
            rstndp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Function showSubContractDetails(ByVal PatiView As System.Windows.Forms.ListView, ByVal subcontratype As String) As Boolean
        Dim cnodbcShow As Odbc.OdbcConnection
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            strSQL = "SELECT SubContract.Date_Advanced,  Sub_Contract_type.Sub_Cont_type, SubContract.Amount FROM SubContract INNER JOIN Sub_Contract_type ON SubContract.SubCotraType = Sub_Contract_type.ID  WHERE (SubContract.Pro_ID = '" & ProjectId & "') AND (Sub_Contract_type.Sub_Cont_type = '" & subcontratype & "') order by SubContract.Date_Advanced desc"
            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                Call fill_listview(PatiView, "SubContract", strSQL, " 50;Date;,  -20;Contract Type ;,0;Amount;Right")

            Else
                PatiView.Columns.Clear()
                PatiView.Items.Clear()
            End If
            rstndp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Function showIncome(ByVal PatiView As System.Windows.Forms.ListView, ByVal IncomeType As String) As Boolean
        Dim cnodbcShow As Odbc.OdbcConnection
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            If IncomeType = "Cash" Then
                strSQL = "SELECT Income.Date_receive, Income_Type.Income_Type, Income.Amount FROM Income INNER JOIN Income_Type ON Income.Item = Income_Type.ID WHERE (Income.Pro_ID = '" & ProjectId & "' and Income_Type.ID=1)order by Income.Date_receive desc"
            Else
                strSQL = "SELECT Income.Date_receive, Income_Type.Income_Type, Income.Amount FROM Income INNER JOIN Income_Type ON Income.Item = Income_Type.ID WHERE (Income.Pro_ID = '" & ProjectId & "' and Income_Type.ID=2)order by Income.Date_receive desc"
            End If
            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                Call fill_listview(PatiView, "Income", strSQL, " 40;Date;, 300;Item;,  40;Amount;Right")

            Else
                PatiView.Columns.Clear()
                PatiView.Items.Clear()
            End If
            rstndp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Function showMaterialsTransfer(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        Dim cnodbcShow As Odbc.OdbcConnection
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            strSQL = "SELECT Materials_transfer.Date_Transfer, Project.PRO_Name, Materials_Type.Item, Materials_transfer.Sub_item, Materials_transfer.Quantity, Materials_transfer.Rate, Materials_transfer.Amount FROM Materials_transfer INNER JOIN Project ON Materials_transfer.Pro_ID_To = Project.Pro_ID INNER JOIN Materials_Type ON Materials_transfer.Item = Materials_Type.ID WHERE (Materials_transfer.Pro_ID_from = '" & ProjectId & "')order by Materials_transfer.Date_Transfer desc"
            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                Call fill_listview(PatiView, "Materials_transfer", strSQL, " 40;Date;, 90;Materials Transfered To;Center, 60;Item;, 10;Sub_item;, 0;Quantity;Right, 30;Rate;Right, 20;Amount;Right")
            Else
                PatiView.Columns.Clear()
                PatiView.Items.Clear()
            End If
            rstndp.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function


    Public Function showexpenseStage(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        Dim cnodbcShow As Odbc.OdbcConnection
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            strSQL = "SELECT Item, SUM(Amount) as Amount FROM   ExpensesActual WHERE  (Pro_ID = '" & ProjectId & "'and Pro_Stage<=" & Pro_SelectedStage & ") GROUP BY Item"
            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                Call fill_listview(PatiView, "ExpensesActual", strSQL, " 200;Item;, 60;Amount;Right")


            Else
                PatiView.Columns.Clear()
                PatiView.Items.Clear()


            End If
            rstndp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Function showincomeStage(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        Dim cnodbcShow As Odbc.OdbcConnection
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            strSQL = "SELECT  Income_Type.Income_Type, SUM(Income.Amount) AS Amount  FROM  Income INNER JOIN  Income_Type ON Income.Item = Income_Type.ID where Income.Item<>3 and Pro_Stage<=" & Pro_SelectedStage & " GROUP BY Income_Type.Income_Type, Income.Pro_ID HAVING  (Income.Pro_ID = '" & ProjectId & "')"
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
        cnodbcShow = Nothing
    End Function


    Public Function showBalanceactual(ByVal lblIncomeActual As System.Windows.Forms.Label, ByVal lblExpensesActual As System.Windows.Forms.Label, ByVal lblBalanceActual As System.Windows.Forms.Label, Optional ByVal ProSelectedStage As Integer = 0) As Boolean

        Try
            Dim strSQL As String 'Query to run
            Dim strSQL2 As String
            Dim cn1 As New ADODB.Connection
            Dim rsincome As New ADODB.Recordset
            Dim rsexpenses As New ADODB.Recordset
            cn1.Open(odbc_Constr)
            If ProSelectedStage > 0 Then
                strSQL = "SELECT SUM(Amount) as Amount FROM   Income WHERE  (Pro_ID = '" & ProjectId & "' and Item<>3 and Pro_Stage<=" & Pro_SelectedStage & ")"
                strSQL2 = "SELECT SUM(Amount) as Amount FROM   ExpensesActual WHERE  (Pro_ID = '" & ProjectId & "'and Pro_Stage<=" & Pro_SelectedStage & ")"
            Else
                strSQL = "SELECT SUM(Amount) as Amount FROM   Income WHERE  (Pro_ID = '" & ProjectId & "' and Item<>3)"
                strSQL2 = "SELECT SUM(Amount) as Amount FROM   ExpensesActual WHERE  (Pro_ID = '" & ProjectId & "')"
            End If
            rsincome.Open(strSQL, cn1, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
            rsexpenses.Open(strSQL2, cn1, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)
            If Not IsDBNull(rsincome.Fields(0).Value) Then
                lblIncomeActual.Text = rsincome.Fields(0).Value
            Else
                lblIncomeActual.Text = "0"
            End If

            If Not IsDBNull(rsexpenses.Fields(0).Value) Then
                lblExpensesActual.Text = rsexpenses.Fields(0).Value
            Else
                lblExpensesActual.Text = "0"
            End If

            lblBalanceActual.Text = lblIncomeActual.Text - lblExpensesActual.Text
            If lblIncomeActual.Text - lblExpensesActual.Text < 1 Then
                lblBalanceActual.ForeColor = Color.Red
            Else
                lblBalanceActual.ForeColor = Color.Green
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Function
End Module

