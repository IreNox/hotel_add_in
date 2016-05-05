Imports System.IO
Imports Microsoft.Win32

Public Class Settings
#Region "Private Member"
	Private Shared Function _createKey() As RegistryKey
		Return Registry.CurrentUser.CreateSubKey("Software\\Ioniel Network\\HotelAddIn\\", RegistryKeyPermissionCheck.ReadWriteSubTree)
	End Function

	Private Shared Function _getValue(Of T)(ByVal key As String) As T
		Dim key2 = Registry.CurrentUser.OpenSubKey("Software\\Ioniel Network\\HotelAddIn\\", False)

		If key2 Is Nothing Then key2 = _createKey()

		Dim value As Object = key2.GetValue(key)

		If value IsNot Nothing And TypeOf value IsNot T Then
			key2.DeleteValue(key)
			Dim genericValue As T = Nothing
			Return genericValue
		End If

		Return value
	End Function

	Private Shared Sub _setValue(ByVal key As String, ByVal value As Object)
		Dim key2 = Registry.CurrentUser.OpenSubKey("Software\\Ioniel Network\\HotelAddIn\\", True)

		If key2 Is Nothing Then key2 = _createKey()

		key2.SetValue(key, value)
	End Sub
#End Region

#Region "Fields"
	Public Shared Property PathBonBon() As String
        Get
			Return _getValue(Of String)("PathBonBon")
		End Get
        Set(ByVal value As String)
            _setValue("PathBonBon", value)
        End Set
    End Property

    Public Shared Property PathSQLite() As String
        Get
			Return _getValue(Of String)("PathSQLite")
		End Get
        Set(ByVal value As String)
            _setValue("PathSQLite", value)
        End Set
    End Property

    Public Shared Property PathData() As String
        Get
			Dim path = _getValue(Of String)("PathData")

			If String.IsNullOrEmpty(path) Then path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

            Return path
        End Get
        Set(ByVal value As String)
            _setValue("PathData", value)
        End Set
    End Property

    Public Shared Property ObjectIds() As String
        Get
            Dim path2 = Path.Combine(PathData, "objectids.txt")

            If File.Exists(path2) Then
                Return File.ReadAllText(path2)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            File.WriteAllText(Path.Combine(PathData, "objectids.txt"), value)
        End Set
    End Property
#End Region

#Region "Fields - CubeSQL"
    Public Shared Property CubeSqlHost() As String
        Get
			Return _getValue(Of String)("CubeSqlHost")
		End Get
        Set(ByVal value As String)
            _setValue("CubeSqlHost", value)
        End Set
    End Property

    Public Shared Property CubeSqlPort() As Integer
        Get
			Return _getValue(Of Integer)("CubeSqlPort")
		End Get
        Set(ByVal value As Integer)
            _setValue("CubeSqlPort", value)
        End Set
    End Property

    Public Shared Property CubeSqlUsername() As String
        Get
			Return _getValue(Of String)("CubeSqlUsername")
		End Get
        Set(ByVal value As String)
            _setValue("CubeSqlUsername", value)
        End Set
    End Property

    Public Shared Property CubeSqlPassword() As String
        Get
			Return _getValue(Of String)("CubeSqlPassword")
		End Get
        Set(ByVal value As String)
            _setValue("CubeSqlPassword", value)
        End Set
    End Property
#End Region
End Class
