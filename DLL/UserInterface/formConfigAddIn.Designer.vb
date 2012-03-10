<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formConfigAddIn
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
        Me.txtPathSQLite = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPathBonBon = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.textPathData = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtPathSQLite
        '
        Me.txtPathSQLite.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtPathSQLite.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtPathSQLite.Location = New System.Drawing.Point(91, 66)
        Me.txtPathSQLite.Name = "txtPathSQLite"
        Me.txtPathSQLite.Size = New System.Drawing.Size(188, 20)
        Me.txtPathSQLite.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "SQLite Path:"
        '
        'txtPathBonBon
        '
        Me.txtPathBonBon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtPathBonBon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtPathBonBon.Location = New System.Drawing.Point(91, 39)
        Me.txtPathBonBon.Name = "txtPathBonBon"
        Me.txtPathBonBon.Size = New System.Drawing.Size(188, 20)
        Me.txtPathBonBon.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "BonBon Path:"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(123, 130)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Bitte geben Sie hier die pfade zu den Datenbanken ein."
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(204, 130)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Abbrechen"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'textPathData
        '
        Me.textPathData.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.textPathData.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.textPathData.Location = New System.Drawing.Point(91, 92)
        Me.textPathData.Name = "textPathData"
        Me.textPathData.Size = New System.Drawing.Size(188, 20)
        Me.textPathData.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Datenpfad:"
        '
        'formConfigAddIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 165)
        Me.ControlBox = False
        Me.Controls.Add(Me.textPathData)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPathSQLite)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPathBonBon)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "formConfigAddIn"
        Me.ShowInTaskbar = False
        Me.Text = "Datenbank-Einstellungen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPathSQLite As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPathBonBon As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents textPathData As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
