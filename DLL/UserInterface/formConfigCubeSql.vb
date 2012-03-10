Imports System.Windows.Forms

Public Class formConfigCubeSql
    Private Sub formConfigCubeSql_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            textHost.Text = Settings.CubeSqlHost
            textPort.Text = Settings.CubeSqlPort
            textUsername.Text = Settings.CubeSqlUsername
            textPassword.Text = Settings.CubeSqlPassword
        Catch ex As Exception
            MessageBox.Show("Fehler: " + ex.Message)
        End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Settings.CubeSqlHost = textHost.Text
        Settings.CubeSqlPort = Int32.Parse(textPort.Text)
        Settings.CubeSqlUsername = textUsername.Text
        Settings.CubeSqlPassword = textPassword.Text

        MessageBox.Show("Änderungen gespeichert. Änderungen werden erst nach neustart des Programms wirksam.")
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class