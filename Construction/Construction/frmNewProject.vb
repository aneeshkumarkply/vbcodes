Public Class frmNewProject

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtAmount.Text = 0 Then
            MsgBox("Please enter Amount", MsgBoxStyle.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        Try
            ProjectId = select_max_Id("P0001", "Pro_ID", " Project", "")
            Dim strSQL1 As String
            Dim cnodbc1 As New Odbc.OdbcConnection(odbc_Constr)
            strSQL1 = "INSERT INTO Project (  Pro_ID, Agrement_Date, Pro_year, PRO_Name, Area_Building, Rate, Date_Completion, PRO_Cost,Pro_Stage) VALUES('" & ProjectId & "', CONVERT(DATETIME, '" & txtDate.Text & "', 103)," & txtDate.Value.Year & ",'" & txtName.Text & "', " & txtarea.Text & ", " & txtRate.Text & ", CONVERT(DATETIME, '" & txtDateCompli.Text & "', 103)," & txtAmount.Text & ",1)"
            cnodbc1.Open()
            Dim NewQuery1 As New Odbc.OdbcCommand(strSQL1, cnodbc1)
            Dim rsTemp1 As Odbc.OdbcDataReader = NewQuery1.ExecuteReader()
            rsTemp1.Close()
            cnodbc1.Close()
            frmProject.showProject(frmProject.LV_PatiView)
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal EventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        DisallowSingleDoubleQuate(EventArgs)
    End Sub

    Private Sub txtarea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtarea.TextChanged
        If txtarea.Text <> "" And txtRate.Text <> "" Then
            txtAmount.Text = txtarea.Text * txtRate.Text
        Else
            txtAmount.Text = 0
        End If
    End Sub

    Private Sub txtRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.TextChanged
        If txtarea.Text <> "" And txtRate.Text <> "" Then
            txtAmount.Text = txtarea.Text * txtRate.Text
        Else
            txtAmount.Text = 0
        End If
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

    End Sub
End Class