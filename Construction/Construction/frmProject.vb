Public Class frmProject
    Dim cnodbcShow As Odbc.OdbcConnection
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call clsResize.Change_Resolution(Me, False)
        ' Me.LV_PatiView.BorderStyle = BorderStyle.Fixed3D
        Call showProject(Me.LV_PatiView)
        Call clsResize.resizeListViewwidth(Me.LV_PatiView)
    End Sub

    Private Sub LV_PatiView_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LV_PatiView.MouseDoubleClick
        Dim SelectedItems As ListView.SelectedListViewItemCollection = _
             CType(Me.LV_PatiView, ListView).SelectedItems
        If (SelectedItems.Count > 0) Then
            ProjectId = SelectedItems(0).SubItems(1).Text
        Else
            MsgBox("Please select the Project", MsgBoxStyle.Information)
            Exit Sub
        End If
        frmProjectStage.ShowDialog()
        frmProjectselected.MdiParent = frmMain
        frmProjectselected.Show()
    End Sub

    Private Sub cmdProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProject.Click
        frmNewProject.ShowDialog()
    End Sub
    Public Function showProject(ByVal PatiView As System.Windows.Forms.ListView) As Boolean
        Try
            Dim strSQL As String 'Query to run
            cnodbcShow = New Odbc.OdbcConnection(odbc_Constr)
            cnodbcShow.Open()
            strSQL = "Select Pro_ID, Agrement_Date, PRO_Name, Area_Building, Rate, Date_Completion, PRO_Cost from Project order by Pro_ID"
            Dim NewQuery As New Odbc.OdbcCommand(strSQL, cnodbcShow)

            Dim rstndp As Odbc.OdbcDataReader = NewQuery.ExecuteReader()

            If rstndp.HasRows = True Then

                Call fill_listview(PatiView, "Project", strSQL, " -50;Project ID;, -100;Date of Agreement; ,150;Name of Project;, -100;Area of Building;Right, 0;Rate;Right, -100;Date of Completion;, -50;Agreed Cost;Right")

            Else
                PatiView.Columns.Clear()
                PatiView.Items.Clear()


            End If
            rstndp.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

End Class
