Public Class frmProjectStage
    Private ProjectSaved As String
    Private Sub frmProjectStage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL1 As String
        Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL1 = "select * from  Project_stage order by ID"
        cnodbc1.Open()
        Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
        Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()

        If rsTemp1.HasRows = True Then
            Me.cmbStage.Enabled = True
            Dim sqlblock As String = strSQL1
            Combo_List_BoX_DATA_load(Me.cmbStage, sqlblock, "Project_stage", "Stage", "ID")
            Me.cmbStage.Focus()
        End If
        rsTemp1.Close()
        cnodbc1.Close()
        Dim strSQL2 As String
        Dim cnodbc2 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL2 = "select  Pro_Stage from  Project Where Pro_ID='" & ProjectId & "'"
        cnodbc2.Open()
        Dim NewQuery2 As New Odbc.OdbcCommand(strSQL2, cnodbc2)
        Dim rsTemp2 As Odbc.OdbcDataReader = NewQuery2.ExecuteReader()
        If rsTemp2.HasRows = True Then
            ProjectSaved = rsTemp2.Item(0).ToString()
            cmbStage.SelectedValue = ProjectSaved
        End If
        rsTemp2.Close()
        cnodbc2.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If ProjectSaved <> cmbStage.SelectedValue Then
            If MsgBox("Do You Really want to Change the PROTECT STAGE", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Construction") = MsgBoxResult.No Then
                cmbStage.SelectedValue = ProjectSaved
                'Exit Sub
            End If
        End If
        Dim strSQL1 As String
        Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
        strSQL1 = "Update Project set  Pro_Stage =" & cmbStage.SelectedValue & "Where Pro_ID='" & ProjectId & "'"
        cnodbc1.Open()
        Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
        Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()
        rsTemp1.Close()
        cnodbc1.Close()
        Me.Dispose()
        Pro_CurrentStage = cmbStage.SelectedValue
    End Sub
End Class