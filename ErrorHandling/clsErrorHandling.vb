Option Strict On
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Text

''' <summary>
''' Error handlers
''' </summary>


Public Class clsErrorHandler

    'Public Const MailIt As Boolean = True
    'Public Const NoMail As Boolean = False
    'Public Const DisplayIt As Boolean = True
    'Public Const NoDisplay As Boolean = False
    'Public Const NotifyIT As Boolean = True
    'Public Const NoNotify As Boolean = False
    'Public Const LogIt As Boolean = True
    'Public Const NoLog As Boolean = False

    Public Sub _Err(Profile As Common.objProfile, Where As String, What As String, objEx As Exception, Display As Boolean, Notify As Boolean, Log As Boolean)

        Dim sbProfile As New StringBuilder
        sbProfile.AppendLine("UserName: " & Profile.p_UserName)
        sbProfile.AppendLine("UserProf: " & Profile.p_UserProf)
        sbProfile.AppendLine("Authenticated: " & Profile.p_Authenticated)
        sbProfile.AppendLine("Userlvl: " & Profile.p_Userlvl)
        sbProfile.AppendLine("ComputerName: " & Profile.p_ComputerName)
        sbProfile.AppendLine("ComputerType: " & Profile.p_ComputerType)
        sbProfile.AppendLine("ComputerPackPriority: " & Profile.p_PackPriority)
        sbProfile.AppendLine("AppName: " & Profile.p_AppName)
        sbProfile.AppendLine("AppVersion: " & Profile.p_AppVersion)
        sbProfile.AppendLine("SQLConnectionStr: " & Profile.p_ConnectionString.Trim.Substring(0, 34))
        sbProfile.AppendLine("Mode: " & Profile.p_AppMode)

        Dim sbExText As New StringBuilder
        sbExText.AppendLine(objEx.Message)
        sbExText.AppendLine()
        sbExText.AppendLine(sbProfile.ToString)
        sbExText.AppendLine("Where:")
        sbExText.AppendLine(Where)
        sbExText.AppendLine()
        sbExText.AppendLine("What:")
        sbExText.AppendLine(What)
        sbExText.AppendLine()
        sbExText.AppendLine("Full Exception Text:")
        sbExText.AppendLine(objEx.ToString)
        sbExText.AppendLine()
        sbExText.AppendLine("Source: " & objEx.Source)
        'sbExText.AppendLine("TargetSite.Name:" & objEx.TargetSite.Name)
        'sbExText.AppendLine("HRESULT:" & objEx.HResult.ToString)
        sbExText.AppendLine()

        If Notify Or Log Then

            Dim cn As SqlConnection
            Dim cmd As New SqlCommand
            Dim par As SqlParameter
            cn = New SqlConnection("Server=SRV-1LD2APIX01;Database=WAREHOUSE;User Id=apixdata;PWD=dorner")

            Try
                cn.Open()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "syErrLog_ADD"

                '@ActionCode char(5),
                '@AppName varchar(64),
                '@AppVersion varchar(20),
                '@AppMode char(4),
                '@ComputerName varchar(64),
                '@UserProf varchar(64),
                '@ErrGroup smallint,
                '@ErrMessage varchar(256),
                '@ErrFullText varchar(max)

                Dim ActionCode As String
                ActionCode = "??"
                If Log And Notify Then ActionCode = "LN" 'Log and Notify
                If Log And Not Notify Then ActionCode = "LO" 'Log Only
                If Not Log And Notify Then ActionCode = "NO" 'Notify Only

                Dim params As New Dictionary(Of String, String)
                With Profile
                    params.Add("@ActionCode", ActionCode)
                    params.Add("@AppName", .p_AppName)
                    params.Add("@AppVersion", .p_AppVersion)
                    params.Add("@AppMode", .p_AppMode)
                    params.Add("@ComputerName", .p_ComputerName)
                    params.Add("@UserProf", .p_UserProf)
                    params.Add("@ErrGroup", "0")
                    params.Add("@ErrMessage", What)
                    params.Add("@ErrFullText", objEx.ToString)
                    params.Add("@StrBody", sbExText.ToString)
                End With

                For Each kvp As KeyValuePair(Of String, String) In params
                    par = New SqlParameter
                    par.ParameterName = kvp.Key.Trim
                    par.Value = kvp.Value.Trim
                    cmd.Parameters.Add(par)
                Next kvp

                cmd.ExecuteNonQuery()

#If DEBUG Then

#Else
				cmd.ExecuteNonQuery()
#End If



            Catch ex As Exception

                'Connection to SQL Server failed
                'Send eMail to IT
                SendMail(sbProfile.ToString, Profile.p_AppName, Profile.p_ComputerName, ex, sbExText.ToString, Display)

            End Try

            If Display Then
                MsgBox(sbExText.ToString, vbOKOnly)
            End If
        End If


    End Sub

    Private Sub SendMail(ByVal ProfileStr As String, AppName As String, ComputerName As String, SQLEx As Exception, OriginalEx As String, Display As Boolean)

        'THIS SUB WILL ONLY BE CALLED IF ExceptionHandler ITSELF GETS A SQL EXCEPTION

        Dim MailMsg As New MailMessage(New MailAddress("joshig@aent.com"), New MailAddress("joshig@aent.com"))
        'MailMsg.CC.Add(New MailAddress("Joshua.Higginbotham@aent.com"))
        'MailMsg.CC.Add(New MailAddress("Ian.Ching@aent.com"))

        Dim sb As New StringBuilder
        Dim sbProfile As New StringBuilder

        sb.AppendLine("The Exception Handler could not connect to a SQL Server to Log And Notify.")
        sb.AppendLine()
        sb.AppendLine(ProfileStr)
        sb.AppendLine("SQL Exception:")
        sb.AppendLine(SQLEx.ToString)
        sb.AppendLine()
        sb.AppendLine("Source:" & SQLEx.Source)
        sb.AppendLine("TargetSite.Name:" & SQLEx.TargetSite.Name)
        'sb.AppendLine("HRESULT:" & SQLEx.HResult.ToString)
        sb.AppendLine()
        sb.AppendLine("Original Exception:")
        sb.AppendLine()
        sb.Append(OriginalEx)

        With MailMsg
            .Subject = "[ERROR]: " & AppName & " on " & ComputerName & ". [Exception Handler failed to connect to SQL Server]"
            .Body = sb.ToString
        End With

        Dim smtp As New System.Net.Mail.SmtpClient
        With smtp
            .UseDefaultCredentials = False
            .Host = "mailhub.aent.com"
            .Port = 25
            .Send(MailMsg)
        End With

        If Display Then
            sb = New StringBuilder
            sb.AppendLine(AppName & " has encountered an error, and will close.")
            sb.AppendLine()
            sb.AppendLine("Folks in IT have been notified by email, but you might want to grab a screenshot just in case.")
            sb.AppendLine()
            sb.AppendLine("Error message:")
            sb.AppendLine()
            sb.AppendLine(SQLEx.Message)
            MsgBox(sb.ToString, vbOKOnly)
        End If

    End Sub


End Class

'Public Class errParams
'#Region "Properties"

'    Public Property ClassName() As String
'    Public Property MethodName() As String
'    Public Property Display() As Boolean
'    Public Property Notify() As Boolean
'    Public Property Log() As Boolean

'#End Region 'Properties
'    Public Sub New(pClassName As String, pMethodName As String, pDisplay As Boolean, pNotify As Boolean, pLog As Boolean)

'        ClassName = pClassName
'        MethodName = pMethodName
'        Display = pDisplay
'        Notify = pNotify
'        Log = pLog

'    End Sub

'End Class

'Public Class objProfile

'#Region "Properties"

'    Public Property p_UserName() As String
'    Public Property p_UserProf() As String
'    Public Property p_Userlvl() As String
'    Public Property p_Authenticated() As String
'    Public Property p_ComputerName() As String
'    Public Property p_ComputerType() As String
'    Public Property p_PackPriority As String
'    Public Property p_AppName() As String
'    Public Property p_AppVersion() As String
'    Public Property p_AppMode As String
'    Public Property p_ConnectionString() As String

'#End Region 'Properties
'    Public Sub New()

'        p_UserName = ""
'        p_UserProf = ""
'        p_Userlvl = ""
'        p_Authenticated = ""
'        p_ComputerName = ""
'        p_ComputerType = ""
'        p_PackPriority = ""
'        p_AppName = ""
'        p_AppVersion = ""
'        p_AppMode = ""
'        p_ConnectionString = ""
'    End Sub

'End Class

'Public Class spException
'    Inherits Exception

'    Public Property p_Message As String

'    Public Overrides ReadOnly Property Data() As IDictionary
'        Get
'            Return Nothing
'        End Get
'    End Property

'    Public Overrides ReadOnly Property Message() As String
'        Get
'            Return p_Message
'        End Get
'    End Property

'    Public Overrides Property Source() As String

'    Public Overrides ReadOnly Property StackTrace() As String
'        Get
'            Return Nothing
'        End Get
'    End Property


'End Class