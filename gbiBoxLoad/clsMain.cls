Imports Common.clsCommon

Public Class clsMain

    'https://docs.microsoft.com/en-us/dotnet/framework/windows-services/walkthrough-creating-a-windows-service-application-in-the-component-designer#BK_AddInstallers

    Public Shared Sub Main()

        'Instantiate Profile object
        Dim Profile As Common.objProfile = New Common.objProfile

        'Instantiate error handler
        Dim eh As New ErrorHandling.clsErrorHandler
        Dim ep As New Common.errParams(System.Reflection.MethodInfo.GetCurrentMethod.DeclaringType.Name, "", DisplayIt, NotifyIT, LogIt)
        ep.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name

        'Instantiate Stored Procedures 
        Dim sp As New GBI.clsStoredProcedures

        'TODO: enable live/test mode switching
        With Profile
            .p_AppMode = "LIVE"
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
        End With

        Profile.p_ConnectionString = sp.SQLServerConnection_GET("GBI", Profile.p_AppMode).Rows(0).Item("ConnectionString").ToString.Trim

        Try
            While True
                Dim go As clsGetBox = New clsGetBox
                go.p_Profile = Profile
                go.GetPackets()
            End While

        Catch ex As Exception
            eh._Err(Profile, "Main in clsMain", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
        End Try

    End Sub

End Class
