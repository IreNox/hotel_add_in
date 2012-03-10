Friend Class formStatus
    Public Delegate Sub SetStatusDel(ByVal msg As String)
    Public _setStatus As SetStatusDel

    Public Delegate Sub SetPercentDel(ByVal value As Integer)
    Public _setPercent As SetPercentDel

    Public Sub New()
        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        _setStatus = New SetStatusDel(AddressOf SetStatus2)
        _setPercent = New SetPercentDel(AddressOf SetPercent2)
    End Sub
    Public Sub SetStatus(ByVal msg As String)
        If txtStatus.InvokeRequired Then
            txtStatus.Invoke(_setStatus, msg)
        Else
            SetStatus2(msg)
        End If
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub SetStatus2(ByVal msg As String)
        txtStatus.Text = msg
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Public Sub SetPercent(ByVal value As Integer)
        If txtStatus.InvokeRequired Then
            txtStatus.Invoke(_setPercent, value)
        Else
            SetPercent2(value)
            System.Windows.Forms.Application.DoEvents()
        End If
    End Sub

    Private Sub SetPercent2(ByVal value As Integer)
        barStatus.Value = value
        System.Windows.Forms.Application.DoEvents()
    End Sub
End Class