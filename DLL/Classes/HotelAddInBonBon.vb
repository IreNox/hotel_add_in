Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Threading
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Runtime.InteropServices

<ComVisible(True)> _
<Microsoft.VisualBasic.ComClass()> _
Public Class HotelAddIn
#Region "Vars"
    Private path As String

    Private dbConn As OleDbConnection
    Private dbCmd As OleDbCommand

    Private Jahr As Integer
    Private x3(12, 31) As Integer
    Private ArrayLength As Integer = 8

    Friend status As formStatus
#End Region

#Region "Init"
    Public Sub New()
        Try
            path = Settings.PathBonBon

            dbConn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=dBASE III;Mode=read;")
            dbConn.Open()

            dbCmd = New OleDbCommand()
            dbCmd.Connection = dbConn
        Catch ex As Exception
            MessageBox.Show("Fehler beim öffnen der dBase-Datenbank. Fehler: " + ex.Message)
        End Try
    End Sub

    Public Sub Dispose()
        If dbCmd IsNot Nothing Then dbCmd.Dispose()
        If dbConn IsNot Nothing Then dbConn.Dispose()
    End Sub
#End Region

#Region "Private Member"
    Public Function Query(ByVal inSQL As String) As DataTable
        dbCmd.CommandText = inSQL

        Dim table As New DataTable()
        table.Load(dbCmd.ExecuteReader())

        Return table
    End Function

    Private Function ReadArrangements(ByVal Datum As Date, ByRef Arr As String()()) As Boolean
        Dim arr2 As List(Of String())

        If Arr IsNot Nothing Then
            Dim test As String()() = Arr
            arr2 = New List(Of String())(test)
        Else
            arr2 = New List(Of String())()
        End If

        Dim x As Integer = 1
        If Datum < Date.Today Then x = 2

        For i As Integer = 1 To x
            Dim table = Query("SELECT * FROM RS" + i.ToString() + " WHERE (ABREISE - ANREISE) > (" + Datum.ToString("#MM\/dd\/yyyy#") + " - ANREISE) AND ((" + Datum.ToString("#MM\/dd\/yyyy#") + " - ANREISE) > 0 OR " + Datum.ToString("#MM\/dd\/yyyy#") + " = ANREISE)")

            For Each row As DataRow In table.Rows
                Dim row2(ArrayLength) As String

                On Error Resume Next
                row2(1) = row("Personen")
                row2(2) = row("Best_Fur")
                row2(3) = row("Ar_Name")
                row2(4) = row("Zimmer")
                row2(5) = row("rsnr")
                row2(6) = row("gr_name")
                row2(7) = row("Anreise")
                row2(8) = row("Abreise")

                arr2.Add(row2)
            Next

            table.Dispose()
        Next


        Arr = arr2.ToArray()

        Return True
    End Function

    Public Function ReadGruppe(ByVal datum As Date, ByRef Arr As String()()) As Boolean
        Dim arr2 As String()() = Nothing
        Dim list As New Dictionary(Of String, String())()

        ReadArrangements(datum, arr2)

        For Each row As String() In arr2
            If row(6) IsNot Nothing Then
                If list.ContainsKey(row(6)) Then
                    list(row(6))(1) = (Integer.Parse(list(row(6))(1)) + Integer.Parse(row(1))).ToString()
                    list(row(6))(4) = (list(row(6))(4) & "/" & row(4))
                Else
                    list.Add(row(6), row)
                End If
            Else
                list.Add(System.Guid.NewGuid().ToString(), row)
            End If
        Next

        Arr = New List(Of String())(list.Values).ToArray()

        Return True
    End Function

    Private Function ConvertArray(ByVal arr As String()()) As String(,)
        Dim i As Integer = 0
        Dim arr3(arr.Length, ArrayLength) As String
        For Each row As String() In arr
            For x2 = 0 To ArrayLength
                arr3(i, x2) = row(x2)
            Next

            i += 1
        Next

        Return arr3
    End Function
#End Region

#Region "Anzahl"
    Public Function RsAnzahlGästeImHaus(ByVal Datum As Date) As Integer
        Dim DoRedo As Boolean = Datum < Date.Now
        Dim ret As Integer = 0

        Dim x As Integer = 1
        If Datum < Date.Today Then x = 2

        For i As Integer = 1 To x
            Dim table = Query("SELECT * FROM RS" + i.ToString() + " WHERE ANREISE <= " + Datum.ToString("#MM\/dd\/yyyy#") + " AND ABREISE > " + Datum.ToString("#MM\/dd\/yyyy#"))

            For Each row As DataRow In table.Rows
                ret = ret + row!Personen
            Next

            table.Dispose()
        Next

        Return ret
    End Function

    Public Function RsAnzahlFrühstück(ByVal Datum As Date) As Integer
        Dim ret As Integer

        Dim x As Integer = 1
        If Datum <= Date.Today Then x = 2

        For i As Integer = 1 To x
            Dim table = Query("SELECT * FROM RS" + i.ToString() + " WHERE ANREISE < " + Datum.ToString("#MM\/dd\/yyyy#") + " AND ABREISE >= " + Datum.ToString("#MM\/dd\/yyyy#"))

            For Each row As DataRow In table.Rows
                ret = ret + row!Personen
            Next

            table.Dispose()
        Next

        Return ret
    End Function
#End Region

#Region "RsArr*"
    Public Function RsArrEinzeln(ByVal Datum As Date) As String
        Dim Arr As String()() = Nothing
        Dim ret As String = ""

        If Not ReadArrangements(Datum, Arr) Then
            Return ""
        End If

        For Each row In Arr
            ret = ret & row(1) & " x (" & row(4) & ") " & row(3) & " (" & row(2) & ")" & Environment.NewLine
        Next

        Return ret
    End Function

    Public Function RsArrGesamt(ByVal Datum As Date) As String
        Dim Arr As String()() = Nothing
        Dim ret As String = ""
        Dim list As New Dictionary(Of String, Integer)()

        If Not ReadArrangements(Datum, Arr) Then
            Return ""
        End If

        For Each row In Arr
            If list.ContainsKey(row(3)) Then
                list(row(3)) += Integer.Parse(row(1))
            Else
                list.Add(row(3), row(1))
            End If
        Next

        For Each kvp As KeyValuePair(Of String, Integer) In list
            ret += kvp.Value.ToString() + " x " + kvp.Key + Environment.NewLine
        Next

        Return ret
    End Function
#End Region

#Region "Rechnungen"
    Public Function ReadData(ByVal Table As String, ByVal Where As String) As Object
        Dim arr2 As New List(Of String())

        'Query(String.Format("SELECT * FROM {0}", Table), Table)
        Dim row2 As New List(Of String)
        Dim table2 = Query(String.Format("SELECT * FROM {0} {1}", Table, Where))
        'Query("SELECT * FROM "" WHERE {1}", Table, Where), Table)

        For Each row As DataRow In table2.Rows

            For Each Field As DataColumn In row.Table.Columns
                row2.Add(row(Field).ToString)
            Next
            arr2.Add(row2.ToArray)
        Next

        table2.Dispose()

        Return ConvertArray(arr2.ToArray())
    End Function
#End Region

#Region "Gruppen"
    Public Function RsGruppen(ByVal Datum As Date) As Object
        Dim Arr As Object = Nothing
        ReadGruppe(Datum, Arr)

        Return ConvertArray(Arr)
    End Function

    Public Function RsArrGruppe(ByVal Datum As Date) As String
        Dim Arr As String()() = Nothing
        Dim ret As String = ""

        If Not ReadGruppe(Datum, Arr) Then
            Return ""
        End If

        For Each row In Arr
            If row(6) Is Nothing Then
                ret += row(1) + " x " + row(3) + "(" + row(2) + ")" + Environment.NewLine
            Else
                ret += row(1) + " x " + row(3) + "(" + row(6) + ")" + Environment.NewLine
            End If
        Next

        Return ret
    End Function
#End Region

#Region "Array functions"
    Public Function RsArrangements(ByVal datum As Date) As Object
        Dim Arr As Object = Nothing

        ReadArrangements(datum, Arr)

        Return ConvertArray(Arr)
    End Function

    Public Function RsJahr(ByVal Jahr As Integer) As Object
        Dim x(12, 31) As Integer
        Dim b As Integer = 1
        Dim c As Integer = 0
        Dim value As Integer = 0
        Dim Datum As Date

        Me.Jahr = Jahr

        If status Is Nothing Then status = New formStatus()

        status.Show()

        Dim table(2) As DataTable

        status.SetStatus("Lese RS1")
        table(1) = Query("SELECT * FROM RS1")
        status.SetStatus("Lese RS2")
        table(2) = Query("SELECT * FROM RS2")

        c = table(1).Rows.Count + table(2).Rows.Count + 1

        For i As Integer = 1 To 2
            For Each row As DataRow In table(i).Rows
                Datum = row("Anreise")

                If Datum.Year = Jahr Or row("Abreise").Year = Jahr Then
                    While Datum < row("Abreise")
                        If Datum.Year = Jahr Then
                            x(Datum.Month, Datum.Day) += row("Personen")
                        End If

                        Datum = DateAdd("d", +1, Datum)
                    End While
                End If

                status.SetStatus("RS" + i.ToString() + " - " + b.ToString() + " von " + c.ToString())
                value = Convert.ToInt32(Convert.ToSingle(100) / c * b)
                status.SetPercent(value)

                b += 1
            Next
        Next

        x3 = x

        status.Close()

        Return x3
    End Function
#End Region

#Region "Form"
    Public Sub ShowForm()
        Dim form As New formConfigAddIn
        form.ShowDialog()
    End Sub
#End Region
End Class
