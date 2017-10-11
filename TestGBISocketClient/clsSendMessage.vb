Imports Common.clsCommon
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports ErrorHandling.clsErrorHandler
Class clsSendMessage
    'Instantiate Profile object
    Private Profile As Common.objProfile = New Common.objProfile

    'Instantiate error handler
    Private eh As New ErrorHandling.clsErrorHandler
    Private ep As New Common.errParams(System.Reflection.MethodInfo.GetCurrentMethod.DeclaringType.Name, "", DisplayIt, NotifyIT, LogIt)

    'Instantiate Stored Procedures 
    Private sp As New GBI.clsStoredProcedures

#Region "Properties"

    Public WriteOnly Property p_Profile() As Common.objProfile
        Set(ByVal Value As Common.objProfile)
            Profile = Value
        End Set
    End Property

#End Region 'Properties

    Private Sub Main()

    End Sub

    Public Sub GetMessageToSend()
        Dim Method As String = "AssignBox"
        Dim Status As String = "10"
        Dim i As Integer = 0
        Dim SocketName As String = "AssignBox"
        Dim Mode As String = Profile.p_AppMode

        Try

            Dim tblShipInfo As New DataTable
            tblShipInfo = sp.TestSocketMessageLookup(Profile.p_ConnectionString, Method, Status)
            If tblShipInfo.Rows.Count = 0 Then
                Console.WriteLine("No packets to process Exiting....")
            End If
            'Loop thru rows until nothing left to process
            For i = 0 To tblShipInfo.Rows.Count - 1
                With tblShipInfo.Rows(i)
                    Dim TransId As String = String.Empty
                    Dim SocketMessage As String = String.Empty

                    TransID = .Item("TranID").ToString()
                    SocketMessage = .Item("SocketMessage").ToString()

                    CallPKMS(SocketName, Mode, TransId, SocketMessage)

                End With
            Next


        Catch ex As Exception
            eh._Err(Profile, "GetPackets in clsGetBox", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
        End Try
    End Sub

    Private Function parseInMsg(ByVal InMsg As String) As Boolean
        Dim strMsg As String = ""
        Dim intLen As Integer
        Dim intIndex As Integer
        Dim strErrCode As String = String.Empty
        Dim strErrMsg As String = String.Empty
        Dim InMsgStat As Boolean = False

        ' initialise
        parseInMsg = False

        Try
            If InMsg.Contains("ACK") = True Then
                parseInMsg = True
                Exit Function
            End If

            If InMsg.Contains("Carton Header Not Found") = True Then
                Exit Function
            End If

            intLen = InMsg.Length
            intIndex = InStr(InMsg, Chr(21))

            strErrCode = InMsg.Substring(intIndex, 5)
            strErrMsg = InMsg.Substring(intIndex + 5, intLen - (intIndex + 6))

            strMsg = "Error Code: " & strErrCode & ", Error Msg: " & strErrMsg

        Catch ex As Exception
            eh._Err(Profile, "GetPackets in clsGetBox", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
        End Try
    End Function

    Public Sub CallPKMS(ByVal SocketName As String, ByVal Mode As String, ByVal TranID As String, ByVal SocketMessage As String)
        Dim IpAddr As String = String.Empty
        Dim ePort As Int32 = 0
        Try

            Dim tblSocketInfo As New DataTable
            tblSocketInfo = sp.SocketConnectionInfo_GET(Profile.p_ConnectionString, SocketName, Mode)

            With tblSocketInfo.Rows(0)
                IpAddr = .Item("IpAddr").ToString()
                ePort = CLng(.Item("epPort").ToString())
            End With


            ' connection variables
            Dim ipAddress As IPAddress = IPAddress.Parse(IpAddr)
            Dim remoteEP As New IPEndPoint(ipAddress, ePort)

            'connect the socket to the remote endpoint.
            Dim tcpClient As New System.Net.Sockets.TcpClient()
            tcpClient.Connect(remoteEP)
            Dim networkStream As NetworkStream = tcpClient.GetStream()

            'Set the time out in miliseconds
            tcpClient.ReceiveTimeout = 200000

            If networkStream.CanWrite And networkStream.CanRead Then
                Console.WriteLine(SocketMessage)
                Dim bytesAsList As New List(Of Byte)
                bytesAsList.Add(2) 'stx
                bytesAsList.AddRange(System.Text.ASCIIEncoding.ASCII.GetBytes(SocketMessage)) 'the data
                bytesAsList.Add(3) 'etx

                Dim buff() As Byte = bytesAsList.ToArray 'as byte array

                networkStream.Write(buff, 0, buff.Length)

                ' Read the NetworkStream into a byte buffer.
                Dim bytes(tcpClient.ReceiveBufferSize) As Byte
                networkStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))

                ' Output the data received from the host to the console.
                Dim returndata As String = Encoding.ASCII.GetString(bytes)

                'Parse the return message from the Server.
                parseInMsg(returndata)
                Console.WriteLine(returndata)
            End If
            tcpClient.Close()
            tcpClient = Nothing

        Catch ex As Exception
            eh._Err(Profile, "GetPackets in clsGetBox", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
        End Try

    End Sub

End Class
