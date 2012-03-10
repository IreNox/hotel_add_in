<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formStatus
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtStatus = New System.Windows.Forms.Label
        Me.barStatus = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Status:"
        '
        'txtStatus
        '
        Me.txtStatus.AutoSize = True
        Me.txtStatus.Location = New System.Drawing.Point(58, 9)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(28, 13)
        Me.txtStatus.TabIndex = 1
        Me.txtStatus.Text = "###"
        '
        'barStatus
        '
        Me.barStatus.Location = New System.Drawing.Point(12, 36)
        Me.barStatus.Name = "barStatus"
        Me.barStatus.Size = New System.Drawing.Size(292, 23)
        Me.barStatus.TabIndex = 2
        '
        'formStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 70)
        Me.ControlBox = False
        Me.Controls.Add(Me.barStatus)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "formStatus"
        Me.Text = "Status"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.Label
    Friend WithEvents barStatus As System.Windows.Forms.ProgressBar
End Class
