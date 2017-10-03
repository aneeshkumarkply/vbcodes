Imports System.Windows.Forms
'Imports CrystalReportPreveiwer.Report
Public Class frmMain

    Private WithEvents Backup_Restore As New SQLSereverBackupRestore.BackupREstore

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmLogin.ShowDialog()
        frmProject.MdiParent = Me
        frmProject.Show()
    End Sub

    Private Sub ProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectToolStripMenuItem.Click
        frmProject.MdiParent = Me
        frmProject.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.ShowDialog()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Dim cnserver As New ADODB.Connection
        Dim rss As New ADODB.Recordset
        cnserver.Open(odbc_Constr)
        Dim strdatabase As String = cnserver.DefaultDatabase
        rss.Open("select  @@servername", cnserver)
        Dim strserver As String = rss.Fields(0).Value
        S1.FileName = strdatabase & "on" & Now.ToString("yyyyMMddhhmmss")
        S1.AddExtension = True
        S1.Filter = "BackUp Files(*.bak)|*.bak"
        S1.ShowDialog()
        Dim strbackupfile As String = S1.FileName
        Backup_Restore.BackupDB(strserver, strdatabase, strbackupfile)

    End Sub

    Private Sub ReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportToolStripMenuItem.Click
        Dim Prev As New CrystalReportPreveiwer.Report
        Prev.Connectionstring = (odbc_Constr)
        Prev.ReportFileName = My.Application.Info.DirectoryPath & "\Materials.rpt"
        Prev.exportFilePath = My.Application.Info.DirectoryPath & "\Materials.pdf"
        Prev.EporttoPDF()
    End Sub
End Class
