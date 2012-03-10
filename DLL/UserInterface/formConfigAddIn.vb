Imports System.Windows.Forms

Public Class formConfigAddIn
    Private Sub formConfigAddIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtPathBonBon.Text = Settings.PathBonBon
            txtPathSQLite.Text = Settings.PathSQLite
            textPathData.Text = Settings.PathData
        Catch ex As Exception
            MessageBox.Show("Fehler: " + ex.Message)
        End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Settings.PathBonBon = txtPathBonBon.Text
        Settings.PathSQLite = txtPathSQLite.Text
        Settings.PathData = textPathData.Text

        MessageBox.Show("Änderungen gespeichert. Änderungen werden erst nach neustart des Programms wirksam.")
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class