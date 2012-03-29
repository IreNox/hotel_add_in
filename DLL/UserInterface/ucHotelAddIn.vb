Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class ucHotelAddIn
#Region "Vars"
    Private _addin As New LodgitAddIn
#End Region

#Region "Init"
    Private Sub HotelForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dateSelector.Value = Date.Today
    End Sub
#End Region

#Region "Events"
    Private Sub cmdGaeste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGaeste.Click
        Dim datum As Date = dateSelector.Value

        txtAnzeige.Text = "Gäste im Haus: " + _addin.RsAnzahlGästeImHaus(datum).ToString()
    End Sub

    Private Sub cmdFrüstück_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFrüstück.Click
        txtAnzeige.Text = "Anzahl Früstück: " + _addin.RsAnzahlFrühstück(dateSelector.Value).ToString()
    End Sub

    Private Sub cmdArrEinzeln_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdArrEinzeln.Click
        txtAnzeige.Text = _addin.RsArrEinzeln(dateSelector.Value)
    End Sub

    Private Sub cmdArrGesamt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdArrGesamt.Click
        txtAnzeige.Text = _addin.RsArrGesamt(dateSelector.Value)
    End Sub

    Private Sub cmdGruppen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGruppen.Click
        txtAnzeige.Text = _addin.RsArrGruppe(dateSelector.Value)
    End Sub

    Private Sub cmdJahr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJahr.Click
        Dim text As String = ""
        Dim data As Integer(,) = _addin.RsJahr(dateSelector.Value.Year)

        For Each line In data
            text += line.ToString() + Environment.NewLine
        Next

        txtAnzeige.Text = text
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property AddIn() As LodgitAddIn
        Get
            Return _addin
        End Get
    End Property
#End Region
End Class