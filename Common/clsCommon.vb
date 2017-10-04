Public Class clsCommon

    Public Const MailIt As Boolean = True
    Public Const NoMail As Boolean = False
    Public Const DisplayIt As Boolean = True
    Public Const NoDisplay As Boolean = False
    Public Const NotifyIT As Boolean = True
    Public Const NoNotify As Boolean = False
    Public Const LogIt As Boolean = True
    Public Const NoLog As Boolean = False


    Public Enum opcClientTypes As Integer
        PACK = 0
        SHIP = 1

    End Enum
    Public Enum opcItemTreeLevels As Integer
        project = 0
        channel = 1
        device = 2
        itemgroup = 3
        item = 4
    End Enum

End Class


Public Class errParams

#Region "Properties"

    Public Property ClassName() As String
    Public Property MethodName() As String
    Public Property Display() As Boolean
    Public Property Notify() As Boolean
    Public Property Log() As Boolean

#End Region 'Properties
    Public Sub New(pClassName As String, pMethodName As String, pDisplay As Boolean, pNotify As Boolean, pLog As Boolean)

        ClassName = pClassName
        MethodName = pMethodName
        Display = pDisplay
        Notify = pNotify
        Log = pLog

    End Sub

End Class

Public Class objProfile

#Region "Properties"

    Public Property p_UserName() As String
    Public Property p_UserProf() As String
    Public Property p_Userlvl() As String
    Public Property p_Authenticated() As String
    Public Property p_ComputerName() As String
    Public Property p_ComputerType() As String
    Public Property p_PackPriority As String
    Public Property p_AppName() As String
    Public Property p_AppVersion() As String
    Public Property p_AppMode As String
    Public Property p_ConnectionString() As String

#End Region 'Properties
    Public Sub New()

        p_UserName = ""
        p_UserProf = ""
        p_Userlvl = ""
        p_Authenticated = ""
        p_ComputerName = ""
        p_ComputerType = ""
        p_PackPriority = ""
        p_AppName = ""
        p_AppVersion = ""
        p_AppMode = ""
        p_ConnectionString = ""
    End Sub

End Class

Public Class spException
    Inherits Exception

    Public Property p_Message As String

    Public Overrides ReadOnly Property Data() As IDictionary
        Get
            Return Nothing
        End Get
    End Property

    Public Overrides ReadOnly Property Message() As String
        Get
            Return p_Message
        End Get
    End Property

    Public Overrides Property Source() As String

    Public Overrides ReadOnly Property StackTrace() As String
        Get
            Return Nothing
        End Get
    End Property


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