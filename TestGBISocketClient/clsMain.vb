Imports Common.clsCommon
Imports System

Public Class clsMain

    Public Shared Sub Main()

        'Instantiate Profile object
        Dim Profile As Common.objProfile = New Common.objProfile

        'Instantiate error handler
        Dim eh As New ErrorHandling.clsErrorHandler
        Dim ep As New Common.errParams(System.Reflection.MethodInfo.GetCurrentMethod.DeclaringType.Name, "", DisplayIt, NotifyIT, LogIt)
        ep.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name

        'Instantiate Stored Procedures 
        Dim sp As New GBI.clsStoredProcedures

        'TODO: enable live/test mode switching; datasourse TESTSOCKET = test socket from PM; TESTTABLE = socket msg table in sdPack; SOPTABLE = SOP tables in sdPack; LIVE = live socket from PM
        With Profile
            .p_AppMode = "PROD"
            .p_UserName = My.User.Name
            .p_UserProf = My.Computer.Name
            .p_Userlvl = "0"
            .p_Authenticated = "False"
            .p_ComputerName = My.Computer.Name
            .p_AppName = My.Application.Info.AssemblyName
            .p_AppVersion = String.Format("Version {0}", My.Application.Info.Version.ToString)
            If Not Debugger.IsAttached And System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                Dim Deploy As Version = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
                .p_AppVersion = String.Format("Version {0}.{1}.{2}.{3}", Deploy.Major, Deploy.Minor, Deploy.Build, Deploy.Revision)
            End If
            .p_ConnectionString = sp.SQLServerConnection_GET("GBI", Profile.p_AppMode).Rows(0).Item("ConnectionString").ToString.Trim
        End With

        Try

            Dim go As clsSendMessage = New clsSendMessage
            go.p_Profile = Profile
            go.GetMessageToSend()

        Catch ex As Exception
            eh._Err(Profile, "Main in clsMain", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
        End Try

    End Sub

End Class
