Imports System.IO
Imports Common.clsCommon
Public Class frmFileWatcher

        'Instantiate Stored Procedures 
    Private sp As New DataHandling.clsStoredProcedures

    'Instantiate Profile object
    Dim Profile As Common.objProfile = New Common.objProfile

    'Instantiate error handler
    Dim eh As New ErrorHandling.clsErrorHandler
    Dim ep As New Common.errParams(System.Reflection.MethodInfo.GetCurrentMethod.DeclaringType.Name, "", DisplayIt, NotifyIT, LogIt)

    'Instantiate Table objects
    Private tblOrderHeader As New DataTable
    Private tblOrderDetail As New DataTable
    Private tblOrderComplete As New DataTable
    Private tblStatus As New DataTable
    Private tblOrdersToSend As New DataTable
    Private LogMessage As String = String.Empty

    'Define File Locations - Production
    'Dim ToHostBoxFolder = "\\10.10.213.1\D$\Autologik\FTP\ToHost\BoxDet\"
    'Dim ToHostBoxFolderArchive = "\\10.10.213.1\D$\Autologik\FTP\Archive\BoxDet\"
    'Dim ToHostOrderFolder = "\\10.10.213.1\D$\Autologik\FTP\ToHost\OrderComplete\"
    'Dim ToHostOrderFolderArchive = "\\10.10.213.1\D$\Autologik\FTP\Archive\OrderComplete\"

    'Define File Locations - Test
    Dim ToHostBoxFolder = "C:\Autologik\FTP\ToHost\BoxDet\"
    Dim ToHostBoxFolderArchive = "C:\Autologik\FTP\Archive\BoxDet\"
    Dim ToHostOrderFolder = "C:\Autologik\FTP\ToHost\OrderComplete\"
    Dim ToHostOrderFolderArchive = "C:\Autologik\FTP\Archive\OrderComplete\"

    'Badge Controls

    Private ConnectionString As String = ""

    Private Sub frmFileWatcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        End With

        Try
            Profile.p_ConnectionString = sp.SQLServerConnection_GET("GBI", Profile.p_AppMode).Rows(0).Item("ConnectionString").ToString.Trim

        Catch ex As Exception
            eh._Err(Profile, "Form Sorter Control Load", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
        End Try

        tmrRefresh.Start()

    End Sub

    Private Sub btnSend_Click_1(sender As Object, e As EventArgs) Handles btnSend.Click
        
        CloseOrders()

    End Sub

Public Sub CloseOrders()

        tmrRefresh.Stop()

        Dim OrderId As String = String.Empty
        Dim CartonId As String = String.Empty

        Try

            tblOrdersToSend = sp.GetOrdersToClose(Profile.p_ConnectionString)

            If tblOrdersToSend.Rows.Count = 0
                AddAlarm("No orders to close, going to sleep")
            End If

            For i = 0 To tblOrdersToSend.Rows.Count - 1
                OrderId = tblOrdersToSend.Rows(i).Item("OrderId").ToString()
                CartonID = tblOrdersToSend.Rows(i).Item("CartonId").ToString()


            If CartonId <> ""
            WriteBoxDetail(ToHostBoxFolder, _
                                   ToHostBoxFolderArchive, CartonId, _
                                   ".bdf")
            End If

            WriteOrderComplete(ToHostOrderFolder, _
                               ToHostOrderFolderArchive, OrderId, _
                               ".ocf")
            Next

            tmrRefresh.Start()

        Catch ex As Exception
            eh._Err(Profile, "Failed returning orders to close ", ex.Message, ex, DisplayIt, NotifyIT, LogIt)
        End Try
End Sub

#Region " WriteBoxDetail "
    Public Function WriteBoxDetail(ByVal ToHostBoxFolder As String, _
                                   ByVal ToHostBoxFolderArchive As String, ByVal BoxId As String, _
                                   ByVal FileType As String)
        Dim FileNum As Integer
        Try 
            AddAlarm("Writing BoxDetail file for BoxID " & BoxId)

            ' Fetch box contents
            Dim dsOrderClose As DataSet = sp.GetOrderCloseInfo(Profile.p_ConnectionString, BoxId)

            'Fill data table with results
            tblOrderHeader = dsOrderClose.Tables(0)
            tblOrderDetail = dsOrderClose.Tables(1)
           
            BoxId = BoxId.TrimEnd

            ' Delete box file from Archive
            If File.Exists(ToHostBoxFolderArchive & BoxId & FileType) Then
                Kill(ToHostBoxFolderArchive & BoxId & FileType)
            End If

            ' Open new temp box detail file in Archive
            FileNum = FreeFile()
            FileOpen(FileNum, ToHostBoxFolderArchive & BoxId & ".tmp", OpenMode.Output)

            ' Write box details to file
            Print(FileNum, "H")

            Print(FileNum, CStr(tblOrderHeader.Rows(0).Item("Picktckt").ToString()).PadRight(10))
            Print(FileNum, CStr(tblOrderHeader.Rows(0).Item("UserId")).PadRight(7).Substring(0, 7))
            Print(FileNum, CStr(tblOrderHeader.Rows(0).Item("Destination").PadLeft(3, "0"c)))
            Print(FileNum, CStr(tblOrderHeader.Rows(0).Item("BoxId").ToString()).PadRight(20))
            Print(FileNum, CStr(tblOrderHeader.Rows(0).Item("BoxType").ToString()).PadRight(20))
            Print(FileNum, cstr(tblOrderHeader.Rows(0).Item("WorkStation").ToString()))
            Print(FileNum, Date.Today.ToString("HHmmssMMddyyyy"))           
            Print(FileNum, CStr(tblOrderHeader.Rows(0).Item("NumOfBoxes").PadLeft(3, "0"c)))            
            Print(FileNum, IIf(CBool(tblOrderHeader.Rows(0).Item("LastBox")), "1", "0"))
            Print(FileNum, vbCrLf)
            For Row = 0 To tblOrderDetail.Rows.Count - 1
                Print(FileNum, "D")
                Print(FileNum, CStr(tblOrderDetail.Rows(Row).Item("RowId").PadLeft(4, "0"c)))
                Print(FileNum, CStr(tblOrderDetail.Rows(Row).Item("Sku").ToString()).PadRight(20))
                Print(FileNum, CStr(tblOrderDetail.Rows(0).Item("QtyPacked").PadLeft(5, "0"c)))
                Print(FileNum, vbCrLf)
            Next
            FileClose(FileNum)

            ' Rename temp file in archive
            Rename(ToHostBoxFolderArchive & BoxId & ".tmp", _
                   ToHostBoxFolderArchive & BoxId & FileType)

            ' Copy file as .tmp to FTP site
            FileCopy(ToHostBoxFolderArchive & BoxId & FileType, _
                     ToHostBoxFolder & BoxId & ".tmp")

            ' Delete pre-existing box detail files for rename
            If File.Exists(ToHostBoxFolder & BoxId & FileType) Then
                Kill(ToHostBoxFolder & BoxId & FileType)
            End If
            ' Rename .tmp to .BDF
            Rename(ToHostBoxFolder & BoxId & ".tmp", ToHostBoxFolder & BoxId & FileType)

            AddAlarm("Finished writing BoxDetail file for BoxID " & BoxId)

 
        Catch ex As Exception
            AddAlarm("Issue writing BoxDetail file for BoxID " & BoxId)

            eh._Err(Profile, "Failed Writing BoxDetail file for " & BoxId, ex.Message, ex, DisplayIt, NotifyIT, LogIt)
        Finally
            FileClose(FileNum)
        End Try
    End Function
#End Region

#Region " WriteOrderComplete "
    Public Function WriteOrderComplete(ByVal ToHostOrderFolder As String, _
                                       ByVal ToHostOrderFolderArchive As String, ByVal OrderId As String, _
                                       ByVal FileType As String)
        Dim FileNum As Integer
        Dim Status As String = String.Empty
        Try
            ' Fetch order data

            AddAlarm("Writing Order Complete file for OrderID " & OrderID)

            ' Delete previous order completion file
            If File.Exists(ToHostOrderFolderArchive & OrderId & ".tmp") Then
                Kill(ToHostOrderFolderArchive & OrderId & ".tmp")
            End If

            ' Open new temporary order completion file in Archive
            FileNum = FreeFile()
            FileOpen(FileNum, ToHostOrderFolderArchive & OrderId & ".tmp", OpenMode.Output)

            ' Write file
            Print(FileNum, "H")
            Print(FileNum, OrderId.PadRight(20))
            Print(FileNum, "C")
            Print(FileNum, CStr("GBI"))
            Print(FileNum, Date.Today.ToString("HHmmssMMddyyyy"))   
            Print(FileNum, Format(1, "00000"))

            Print(FileNum, vbCrLf)
            FileClose(FileNum)

            ' If the OCF exists
            If File.Exists(ToHostOrderFolderArchive & OrderId & FileType) Then
                ' OCF has alrady been created and passed on - Per Bob Artura 09/19/2007 - Do not over write the OCF
                ' Kill the tmp file and return succesfully.
                Kill(ToHostOrderFolderArchive & OrderId & ".tmp")
                Exit Function
            Else
                ' Rename temporary file in archive
                Rename(ToHostOrderFolderArchive & OrderId & ".tmp", _
                       ToHostOrderFolderArchive & OrderId & FileType)
            End If

            ' Copy file as .tmp to FTP site
            FileCopy(ToHostOrderFolderArchive & OrderId & FileType, _
                     ToHostOrderFolder & OrderId & ".tmp")

            ' Delete pre-existing order complete files
            If File.Exists(ToHostOrderFolder & OrderId & FileType) Then
                Kill(ToHostOrderFolder & OrderId & FileType)
            End If
            ' Rename .tmp to .OCF
            Rename(ToHostOrderFolder & OrderId & ".tmp", _
                   ToHostOrderFolder & OrderId & FileType)

            AddAlarm("Finished writing Order Complete file for OrderID " & OrderID)
           
        Catch ex As Exception 
            AddAlarm("Failed writing Order Complete file for OrderID " & OrderID)
            eh._Err(Profile, "Failed Writing OC file for OrderID " & OrderId, ex.Message, ex, DisplayIt, NotifyIT, LogIt)
        Finally
            FileClose(FileNum)
            Try
                tblStatus = sp.CloseOrder(Profile.p_ConnectionString, OrderId)

                Status = tblStatus.Rows(0).Item("Status").ToString

                If Status = 1
                    AddAlarm(OrderId & " successfully closed in Database")

                End If
            Catch ex As Exception
                   AddAlarm(OrderId & " Failed to close in Database")

            End Try
        End Try
    End Function

    Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
        CloseOrders()
    End Sub
#End Region

    #Region " [private] AddAlarm "
    Private Sub AddAlarm(ByVal Message As String)
        lstAlarm.Items.Insert(0, Format(Now, "MM/dd/yy HH:mm:ss  ") & Message)
        If lstAlarm.Items.Count > 1000 Then
            lstAlarm.Items.RemoveAt(1000)
        End If
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        lstAlarm.Items.Clear()
    End Sub
#End Region
End Class
