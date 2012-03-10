Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.CubeSql.Native
Imports System.Threading
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Runtime.InteropServices

<ComVisible(True)> _
<Microsoft.VisualBasic.ComClass()> _
Public Class CubeSqlAddIn
#Region "Vars"
    Private dbConn As CubeSqlConnection
    Private dbCmd As CubeSqlCommand

    Private Jahr As Integer
    Private x3(12, 31) As Integer
    Private status As formStatus
    Private ArrayLength As Integer = 8
#End Region

#Region "Init"
    Public Sub New()
        Try
            Dim data As String = Settings.PathSQLite

            dbConn = New CubeSqlConnection(_buildConnectionString())
            'dbConn.Open()

            dbCmd = New CubeSqlCommand()
            dbCmd.Connection = dbConn
        Catch ex As Exception
            MessageBox.Show("Fehler: " + ex.Message)
        End Try
    End Sub

    Public Sub Dispose()
        If dbCmd IsNot Nothing Then dbCmd.Dispose()
        If dbConn IsNot Nothing Then dbConn.Dispose()
    End Sub
#End Region

#Region "Private Member"
    Private Function _buildConnectionString() As String
        Return String.Format( _
            "Host={0};Port={1};Username={2};Password={3};Database={4}", _
            Settings.CubeSqlHost, _
            Settings.CubeSqlPort, _
            Settings.CubeSqlUsername, _
            Settings.CubeSqlPassword, _
            Path.GetFileName(Settings.PathSQLite) _
        )
        '"driver={{cubeSQL ODBC}};database={4};server={0};uid={2};pwd={3};", _

        '"Host={0};Port={1};Username={2};Password={3};Database={4}", _
    End Function

    Public Function Query(ByVal inSQL As String) As DataTable
        dbCmd.CommandText = inSQL

        Try
            dbConn.Open()

            Dim ds As New DataSet()
            ds.EnforceConstraints = False

            Dim table As New DataTable()
            ds.Tables.Add(table)
            table.Load(dbCmd.ExecuteReader())

            dbConn.Close()

            Return table
        Catch e As Exception
            MessageBox.Show(e.Message)
            Return New DataTable()
        End Try
    End Function

    Public Function CreateObjectSql(ByVal where As String, ByVal ParamArray fields As String()) As DataTable
        Dim str As New StringBuilder()

        str.AppendLine("SELECT")

        If fields.Length = 0 Then
            str.AppendLine("    booking.*")
        Else
            Dim first As Boolean = True

            For Each field As String In fields
                If Not first Then str.Append(",")
                str.AppendLine("    booking." + field)

                first = False
            Next
        End If

        str.AppendLine("FROM")
        str.AppendLine("    b_buchungen as booking,")
        str.AppendLine("    o_mieteinheit as room,")
        str.AppendLine("    o_objekt as hotel")
        str.AppendLine("WHERE")
        str.AppendLine("    room.rowid = booking.BU_ZIMMER AND")
        str.AppendLine("    hotel.rowid = room.ME_OBJEKT")

        If Not String.IsNullOrEmpty(Settings.ObjectIds) Then
            str.AppendLine("    AND hotel.rowid IN (" + Settings.ObjectIds + ")")
        End If

        If Not String.IsNullOrEmpty(where) Then
            str.Append("    AND ")
            str.Append(where)
        End If

        Return Query(str.ToString())
    End Function
#End Region

#Region "Arrangements"
    Private Function ReadArrangements(ByVal Datum As Date, ByRef Arr As String()()) As Boolean
        Dim arr2 As List(Of String())

        If Arr IsNot Nothing Then
            Dim test As String()() = Arr
            arr2 = New List(Of String())(test)
        Else
            arr2 = New List(Of String())()
        End If

        Dim table = Query(String.Format(My.Resources.queryArr, Datum.ToString("yyyy-MM-dd")))

        For Each row As DataRow In table.Rows
            Dim row2(ArrayLength) As String
            Dim article As String = row("article_name")

            On Error Resume Next
            row2(1) = row("booking_persons")
            row2(2) = row("customer_name")
            row2(3) = article.Substring(article.IndexOf(")") + 1)
            row2(4) = row("room_name")
            row2(5) = row("booking_id")
            row2(6) = row("group_name")
            row2(7) = row("booking_arrival")
            row2(8) = row("booking_depature")

            arr2.Add(row2)
        Next

        table.Dispose()

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
        Dim ret As Integer = 0
        Dim table = Me.CreateObjectSql("date([BU_DATUM_VON]) <= date('" + Datum.ToString("yyyy-MM-dd") + "') AND date([BU_DATUM_BIS]) > date('" + Datum.ToString("yyyy-MM-dd") + "')", "BU_PERS_TOTAL")

        'Query("SELECT * FROM b_buchungen WHERE date([BU_DATUM_VON]) <= date('" + Datum.ToString("yyyy-MM-dd") + "') AND date([BU_DATUM_BIS]) > date('" + Datum.ToString("yyyy-MM-dd") + "')")

        For Each row As DataRow In table.Rows
            ret = ret + row("BU_PERS_TOTAL")
        Next

        table.Dispose()

        Return ret
    End Function

    Public Function RsAnzahlFrühstück(ByVal Datum As Date) As Integer
        Dim ret As Integer
        Dim table = Me.CreateObjectSql("date([BU_DATUM_VON]) < date('" + Datum.ToString("yyyy-MM-dd") + "') AND date([BU_DATUM_BIS]) >= date('" + Datum.ToString("yyyy-MM-dd") + "')", "BU_PERS_TOTAL")

        'Query("SELECT * FROM b_buchungen WHERE date([BU_DATUM_VON]) < date('" + Datum.ToString("yyyy-MM-dd") + "') AND date([BU_DATUM_BIS]) >= date('" + Datum.ToString("yyyy-MM-dd") + "')")

        For Each row As DataRow In table.Rows
            ret = ret + row("BU_PERS_TOTAL")
        Next

        table.Dispose()

        Return ret
    End Function
#End Region

#Region "RsArr*"
    Public Function RsArrangements(ByVal datum As Date) As Object
        Dim Arr As Object = Nothing

        ReadArrangements(datum, Arr)

        Return ConvertArray(Arr)
    End Function

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
        Dim dbTable = Query(String.Format("SELECT * FROM {0} {1}", Table, Where))
        'Query("SELECT * FROM "" WHERE {1}", Table, Where), Table)

        For Each row As DataRow In dbTable.Rows()
            For Each Field As DataColumn In row.Table.Columns
                row2.Add(row(Field).ToString)
            Next
            arr2.Add(row2.ToArray)
        Next

        dbTable.Dispose()

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

#Region "Statistik"
    Private Sub _rsJahrWork(ByVal x As Integer(,), ByVal Jahr As Integer, ByVal table As DataTable, ByVal keyArrival As String, ByVal keyDepature As String, ByVal keyPersons As String)
        Dim b As Integer = 1
        Dim c As Integer = table.Rows.Count + 1
        Dim Datum As Date
        Dim value As Integer = 0

        For Each row As DataRow In table.Rows
            Datum = row(keyArrival)

            If Datum.Year = Jahr Or row(keyDepature).Year = Jahr Then
                While Datum < row(keyDepature)
                    If Datum.Year = Jahr Then
                        x(Datum.Month, Datum.Day) += row(keyPersons)
                    End If

                    Datum = DateAdd("d", +1, Datum)
                End While
            End If

            status.SetStatus("Buchung: " + b.ToString() + " von " + c.ToString())
            value = Convert.ToInt32(Convert.ToSingle(100) / c * b)
            status.SetPercent(value)

            b += 1
        Next

        table.Dispose()
    End Sub

    Public Function RsJahr(ByVal Jahr As Integer) As Object
        status = New formStatus()
        Dim x(12, 31) As Integer

        Me.Jahr = Jahr

        status.Show()
        status.SetStatus("Lese Datenbank...")

        _rsJahrWork(x, Jahr, Me.CreateObjectSql(""), "BU_DATUM_VON", "BU_DATUM_BIS", "BU_PERS_TOTAL")

        'Query("SELECT * FROM b_buchungen")

        If Jahr = 2011 Then
            Dim bb As New HotelAddIn()

            status.SetStatus("Lese RS2...")

            _rsJahrWork(x, Jahr, bb.Query("SELECT * FROM RS2"), "ANREISE", "ABREISE", "PERSONEN")

            bb.Dispose()
        End If

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
