<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formConfigCubeSql
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.textUsername = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.textPort = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.textHost = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdOk = New System.Windows.Forms.Button
        Me.textPassword = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'textUsername
        '
        Me.textUsername.Location = New System.Drawing.Point(91, 92)
        Me.textUsername.Name = "textUsername"
        Me.textUsername.Size = New System.Drawing.Size(188, 20)
        Me.textUsername.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Username:"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(204, 154)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 59
        Me.cmdCancel.Text = "Abbrechen"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Bitte geben Sie hier die pfade zu den Datenbanken ein."
        '
        'textPort
        '
        Me.textPort.Location = New System.Drawing.Point(91, 66)
        Me.textPort.Name = "textPort"
        Me.textPort.Size = New System.Drawing.Size(188, 20)
        Me.textPort.TabIndex = 56
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Port:"
        '
        'textHost
        '
        Me.textHost.Location = New System.Drawing.Point(91, 39)
        Me.textHost.Name = "textHost"
        Me.textHost.Size = New System.Drawing.Size(188, 20)
        Me.textHost.TabIndex = 53
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Host:"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(123, 154)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 55
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'textPassword
        '
        Me.textPassword.Location = New System.Drawing.Point(91, 118)
        Me.textPassword.Name = "textPassword"
        Me.textPassword.Size = New System.Drawing.Size(188, 20)
        Me.textPassword.TabIndex = 62
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Passwort:"
        '
        'formConfigCubeSql
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 189)
        Me.ControlBox = False
        Me.Controls.Add(Me.textPassword)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.textUsername)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textPort)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.textHost)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "formConfigCubeSql"
        Me.Text = "CubeSql - Einsellungen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents textUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents textPort As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents textHost As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents textPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
