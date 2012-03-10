<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucHotelAddIn
    Inherits System.Windows.Forms.UserControl

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
        Me.txtAnzeige = New System.Windows.Forms.TextBox
        Me.cmdGruppen = New System.Windows.Forms.Button
        Me.cmdArrGesamt = New System.Windows.Forms.Button
        Me.cmdArrEinzeln = New System.Windows.Forms.Button
        Me.cmdFrüstück = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdGaeste = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.dateSelector = New System.Windows.Forms.DateTimePicker
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAnzeige
        '
        Me.txtAnzeige.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAnzeige.Location = New System.Drawing.Point(3, 150)
        Me.txtAnzeige.Multiline = True
        Me.txtAnzeige.Name = "txtAnzeige"
        Me.txtAnzeige.Size = New System.Drawing.Size(578, 295)
        Me.txtAnzeige.TabIndex = 31
        '
        'cmdGruppen
        '
        Me.cmdGruppen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGruppen.Location = New System.Drawing.Point(389, 3)
        Me.cmdGruppen.Name = "cmdGruppen"
        Me.cmdGruppen.Size = New System.Drawing.Size(186, 52)
        Me.cmdGruppen.TabIndex = 37
        Me.cmdGruppen.Text = "Gruppen"
        Me.cmdGruppen.UseVisualStyleBackColor = True
        '
        'cmdArrGesamt
        '
        Me.cmdArrGesamt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdArrGesamt.Location = New System.Drawing.Point(193, 61)
        Me.cmdArrGesamt.Name = "cmdArrGesamt"
        Me.cmdArrGesamt.Size = New System.Drawing.Size(190, 52)
        Me.cmdArrGesamt.TabIndex = 36
        Me.cmdArrGesamt.Text = "Arragements Gesamt"
        Me.cmdArrGesamt.UseVisualStyleBackColor = True
        '
        'cmdArrEinzeln
        '
        Me.cmdArrEinzeln.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdArrEinzeln.Location = New System.Drawing.Point(193, 3)
        Me.cmdArrEinzeln.Name = "cmdArrEinzeln"
        Me.cmdArrEinzeln.Size = New System.Drawing.Size(190, 52)
        Me.cmdArrEinzeln.TabIndex = 35
        Me.cmdArrEinzeln.Text = "Arragements Einzeln"
        Me.cmdArrEinzeln.UseVisualStyleBackColor = True
        '
        'cmdFrüstück
        '
        Me.cmdFrüstück.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFrüstück.Location = New System.Drawing.Point(3, 61)
        Me.cmdFrüstück.Name = "cmdFrüstück"
        Me.cmdFrüstück.Size = New System.Drawing.Size(184, 52)
        Me.cmdFrüstück.TabIndex = 34
        Me.cmdFrüstück.Text = "Anzahl Früstück"
        Me.cmdFrüstück.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(146, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 25)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Datum:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGaeste
        '
        Me.cmdGaeste.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGaeste.Location = New System.Drawing.Point(3, 3)
        Me.cmdGaeste.Name = "cmdGaeste"
        Me.cmdGaeste.Size = New System.Drawing.Size(184, 52)
        Me.cmdGaeste.TabIndex = 30
        Me.cmdGaeste.Text = "Anzahl Gäste im Haus"
        Me.cmdGaeste.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cmdGruppen, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdArrEinzeln, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdGaeste, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdArrGesamt, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdFrüstück, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dateSelector, 1, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(578, 141)
        Me.TableLayoutPanel1.TabIndex = 41
        '
        'dateSelector
        '
        Me.dateSelector.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dateSelector.Location = New System.Drawing.Point(193, 119)
        Me.dateSelector.Name = "dateSelector"
        Me.dateSelector.Size = New System.Drawing.Size(190, 20)
        Me.dateSelector.TabIndex = 38
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtAnzeige, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(584, 448)
        Me.TableLayoutPanel2.TabIndex = 42
        '
        'ucHotelAddIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "ucHotelAddIn"
        Me.Size = New System.Drawing.Size(584, 448)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtAnzeige As System.Windows.Forms.TextBox
    Friend WithEvents cmdGruppen As System.Windows.Forms.Button
    Friend WithEvents cmdArrGesamt As System.Windows.Forms.Button
    Friend WithEvents cmdArrEinzeln As System.Windows.Forms.Button
    Friend WithEvents cmdFrüstück As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdGaeste As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dateSelector As System.Windows.Forms.DateTimePicker
End Class
