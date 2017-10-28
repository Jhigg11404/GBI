Option Strict On

Imports System.Data.SqlClient

Public Class clsStoredProcedures

#Region "SPROC Definitions"

#Region "Control tables"
    Public Function SQLServerConnection_GET(ByVal AppName As String, ByVal Mode As String) As DataTable
        'Returns ConnectionString to SQL Server. Mode = "TEST" returns connection string to test server; "LIVE" -- production.
        'Hard-code to always use production DB to get this info

        Dim params As New Dictionary(Of String, String)
        params.Add("@AppName", AppName)
        params.Add("@Mode", Mode)

        SQLServerConnection_GET = GetDS("Server=10.10.213.76;Database=GALAXY;User Id= GBIAppUser;Pwd=GBI@ppU$ser88**", "SQLServerConnection_GET", params).Tables(0)

    End Function

    Public Function TestSocketMessageLookup(ByVal ConnectionString As String, ByVal Method As String, ByVal Status As String) As DataTable
        'Returns ConnectionString to SQL Server. Mode = "TEST" returns connection string to test server; "LIVE" -- production.
        'Hard-code to always use production DB to get this info

        Dim params As New Dictionary(Of String, String)
        params.Add("@Method", Method)
        params.Add("@Status", Status)

        TestSocketMessageLookup = GetDS(ConnectionString, "TestSocketMessageLookup", params).Tables(0)

    End Function

    Public Function Test_AssignCartons(ByVal ConnectionString As String) As DataTable

        Dim params As New Dictionary(Of String, String)

        Test_AssignCartons = GetDS(ConnectionString, "Test_AssignCartons", params).Tables(0)

    End Function

        Public Function CloseCarton(ByVal ConnectionString As String, ByVal CartonId As String) As DataTable

        Dim params As New Dictionary(Of String, String)
        params.Add("@CartonId", CartonId)

        CloseCarton = GetDS(ConnectionString, "CloseCarton", params).Tables(0)

    End Function

    Public Function CloseOrder(ByVal ConnectionString As String, ByVal OrderId As String) As DataTable

        Dim params As New Dictionary(Of String, String)
        params.Add("@OrderId", OrderID)

        CloseOrder = GetDS(ConnectionString, "CloseOrder", params).Tables(0)

    End Function

        Public Function CloseWave(ByVal ConnectionString As String, ByVal WaveId As String) As DataTable

        Dim params As New Dictionary(Of String, String)
        params.Add("@WaveId", WaveId)

        CloseWave = GetDS(ConnectionString, "CloseWave", params).Tables(0)

    End Function

    Public Function GetOrdersToClose(ByVal ConnectionString As String) As DataTable

        Dim params As New Dictionary(Of String, String)
       
        GetOrdersToClose = GetDS(ConnectionString, "GetOrdersToClose", params).Tables(0)

    End Function

    Public Function GetOrderCloseInfo(ByVal ConnectionString As String, ByVal BoxId As String) As DataSet

        Dim params As New Dictionary(Of String, String)
        params.Add("@BoxId", BoxID)

        Return GetDS(ConnectionString, "GetOrderCloseInfo", params)

    End Function

    Public Function AbortWave(ByVal ConnectionString As String, ByVal Waveid As String, ByVal AbortType As String, ByVal BadgeId As String) As DataSet

        Dim params As New Dictionary(Of String, String)
        params.Add("@Waveid", Waveid)
        params.Add("@AbortType", AbortType)
        params.Add("@BadgeId", BadgeId)

        Return GetDS(ConnectionString, "AbortWave", params)

    End Function

    Public Function VerifyBadge(ByVal ConnectionString As String, ByVal BadgeId As String) As DataSet

        Dim params As New Dictionary(Of String, String)
        params.Add("@BadgeId", BadgeId)

        Return GetDS(ConnectionString, "VerifyBadge", params)

    End Function

    Public Function GetActiveWave(ByVal ConnectionString As String, ByVal Waveid As String) As DataSet

        Dim params As New Dictionary(Of String, String)
        params.Add("@Waveid", Waveid)

        Return GetDS(ConnectionString, "GetActiveWave", params)

    End Function

    Public Function GetDrops(ByVal ConnectionString As String) As DataTable

        Dim params As New Dictionary(Of String, String)

        GetDrops = GetDS(ConnectionString, "GetDrops", params).Tables(0)

    End Function

    Public Function GetShortages(ByVal ConnectionString As String) As DataTable

        Dim params As New Dictionary(Of String, String)

        GetShortages = GetDS(ConnectionString, "GetShortages", params).Tables(0)

    End Function

    Public Function SendRepick(ByVal ConnectionString As String) As DataTable

        Dim params As New Dictionary(Of String, String)

        SendRepick = GetDS(ConnectionString, "SendRepick", params).Tables(0)

    End Function

    Public Function GetCarriers(ByVal ConnectionString As String) As DataTable

        Dim params As New Dictionary(Of String, String)

        GetCarriers = GetDS(ConnectionString, "GetCarriers", params).Tables(0)

    End Function

    Public Function GetMessagesFromGBI(ByVal ConnectionString As String) As DataTable

        Dim params As New Dictionary(Of String, String)

        GetMessagesFromGBI = GetDS(ConnectionString, "GetMessagesFromGBI", params).Tables(0)

    End Function

    Public Function GetLogInfo(ByVal ConnectionString As String) As DataTable

        Dim params As New Dictionary(Of String, String)

        GetLogInfo = GetDS(ConnectionString, "GetLogInfo", params).Tables(0)

    End Function

    Public Function PendingWaveLookup(ByVal ConnectionString As String) As DataTable

        Dim params As New Dictionary(Of String, String)

        PendingWaveLookup = GetDS(ConnectionString, "PendingWaveLookup", params).Tables(0)

    End Function

    Public Function SocketConnectionInfo_GET(ByVal ConnectionString As String, ByVal SocketName As String, ByVal Mode As String) As DataTable

        Dim params As New Dictionary(Of String, String)
        params.Add("@SocketName", SocketName)
        params.Add("@Mode", Mode)

        SocketConnectionInfo_GET = GetDS(ConnectionString, "SocketConnectionInfo_GET", params).Tables(0)

    End Function

    Public Sub ActivateWave(ByVal ConnectionString As String, ByVal WaveId As String)

        Dim params As New Dictionary(Of String, String)
        params.Add("@WaveId", WaveId)

        ExecSPROC(ConnectionString, "ActivateWave", params)

    End Sub

    Public Function GBI_Packets_ADD(ByVal ConnectionString As String, ByVal Socket As String, ByVal SocketMessage As String, ByVal Reply As String) As DataTable

        Dim params As New Dictionary(Of String, String)
        params.Add("@Socket", Socket)
        params.Add("@SocketMessage", SocketMessage)
        params.Add("@Reply", Reply)

        GBI_Packets_ADD = GetDS(ConnectionString, "GBI_Packets_ADD", params).Tables(0)

    End Function

    Public Function FillManualPart(ByVal ConnectionString As String, ByVal Barcode As String) As DataTable

        Dim params As New Dictionary(Of String, String)
        params.Add("@Barcode", Barcode)

        FillManualPart = GetDS(ConnectionString, "FillManualPart", params).Tables(0)

    End Function


#End Region

#End Region 'SPROC Definitions

#Region "SQL Calls"


    Private Function GetDS(ConnectionString As String, StoredProcedureName As String, Params As Dictionary(Of String, String)) As DataSet

        GetDS = New DataSet


        Dim cn As SqlConnection
        Dim ad As SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim par As SqlParameter

        'cs = "Server=SRV-1DWDB01;Database=RichData;Trusted_Connection=Yes;"
        cn = New SqlConnection(ConnectionString)

        cn.Open()
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = StoredProcedureName

        For Each kvp As KeyValuePair(Of String, String) In Params
            par = New SqlParameter
            par.ParameterName = kvp.Key.Trim
            par.Value = kvp.Value.Trim
            cmd.Parameters.Add(par)
        Next kvp

        ad = New SqlDataAdapter(cmd)
        ad.Fill(GetDS)

    End Function

    Private Sub ExecSPROC(ConnectionString As String, StoredProcedureName As String, Params As Dictionary(Of String, String))

        Dim cn As SqlConnection
        Dim cmd As New SqlCommand
        Dim par As SqlParameter

        cn = New SqlConnection(ConnectionString)

        cn.Open()
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = StoredProcedureName

        For Each kvp As KeyValuePair(Of String, String) In Params
            par = New SqlParameter
            par.ParameterName = kvp.Key.Trim
            par.Value = kvp.Value.Trim
            cmd.Parameters.Add(par)
        Next kvp

        cmd.ExecuteNonQuery()

    End Sub

#End Region 'SQL Calls


End Class

#Region "Class TableMaker"

Public Class _TableMaker

    Private c_Table As DataTable

    Public ReadOnly Property p_Table() As DataTable

        Get
            Return c_Table
        End Get

    End Property

    Sub New(ByVal TableName As String)

        c_Table = New DataTable(TableName)

    End Sub

    Public Sub _AddColumn(ByVal DataType As String, ByVal ColumnName As String, ByVal RO As Boolean, ByVal Unique As Boolean)

        Dim col As DataColumn = New DataColumn


        col.DataType = System.Type.GetType(DataType)
        col.ColumnName = ColumnName
        col.ReadOnly = RO
        col.Unique = Unique

        c_Table.Columns.Add(col)

    End Sub

End Class

#End Region 'Class TableMaker