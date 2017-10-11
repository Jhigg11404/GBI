Option Strict On

Imports Common.clsCommon
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Configuration

Public Class clsGetBox

    'Instantiate Profile object
    Private Profile As Common.objProfile = New Common.objProfile

    'Instantiate error handler
    Private eh As New ErrorHandling.clsErrorHandler
    Private ep As New Common.errParams(System.Reflection.MethodInfo.GetCurrentMethod.DeclaringType.Name, "", DisplayIt, NotifyIT, LogIt)

    'Instantiate Stored Procedures 
    Private sp As New GBI.clsStoredProcedures

    'Data tables
    Private tblSocket As DataTable
    Private tblReply As DataTable

#Region "Properties"

    Public WriteOnly Property p_Profile() As Common.objProfile
        Set(ByVal Value As Common.objProfile)
            Profile = Value
        End Set
    End Property

#End Region 'Properties

    Public Sub GetPackets()
        ep.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name

        ' Incoming data from the client.
        Dim SocketName As String = Profile.p_AppName
        Dim Mode As String = Profile.p_AppMode

        Dim ListenerSocket As Socket
        Dim HandlerSocket As Socket

        ' Data buffer for incoming data.
        'Dim bytes() As Byte = New [Byte](1024) {}

        Console.WriteLine("Getting Socket connection info...")

        tblSocket = sp.SocketConnectionInfo_GET(Profile.p_ConnectionString, SocketName, Mode)

        Dim ipAddr As String = tblSocket.Rows(0).Item("IpAddr").ToString()
        Dim epPort As Integer = CType(tblSocket.Rows(0).Item("epPort").ToString(), Integer)
        Dim tmTimeOut As Integer = CType(tblSocket.Rows(0).Item("TimeOut").ToString(), Integer)


        ' Establish the local endpoint for the socket.
        Dim ipAddress As IPAddress = IPAddress.Parse(ipAddr)
        Dim localEndPoint As New IPEndPoint(ipAddress, epPort)


        Dim bytesRec As Integer
        Dim msg As Byte()

        Dim dtStart As DateTime = Nothing

        Try
            ' Create a TCP/IP socket.
            ListenerSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            'Bind the socket to the local endpoint
            ListenerSocket.Bind(localEndPoint)
            ListenerSocket.Listen(10)
            ListenerSocket.ReceiveTimeout = tmTimeOut

            While True

                Dim PacketStr As String = ""
                Dim PacketID As String = ""
                Dim PacketMsg As String = ""
                Dim PacketFailed As Boolean = False
                Dim PacketStatusCode As Integer = 10

                Try
                    'Start listening for connections. Program is suspended while waiting for an incoming connection.
                    Console.WriteLine("Waiting for a connection...")
                    HandlerSocket = ListenerSocket.Accept


                    ' An incoming connection needs to be processed.
                    While True

                        'bytes = New Byte(1024) {}
                        Dim bytes(HandlerSocket.ReceiveBufferSize) As Byte
                        bytesRec = HandlerSocket.Receive(bytes)

                        ' check if anything being sent 
                        If bytesRec = 0 Then
                            If dtStart = Nothing Then
                                dtStart = DateTime.Now
                            Else
                                'Break and restart after 10 seconds of inactivity
                                If DateDiff("s", dtStart, Date.Now) > 10 Then
                                    Console.WriteLine("Going to sleep...")
                                    ListenerSocket.Dispose()
                                    GoTo Sleep
                                    Exit Sub
                                End If
                            End If
                        Else
                            If dtStart <> Nothing Then
                                dtStart = Nothing
                            End If
                        End If
                        Console.WriteLine("Connection established...")

                        PacketStr += Encoding.ASCII.GetString(bytes, 0, bytesRec)

                        If PacketStr = Nothing Then
                            Console.WriteLine("Going to sleep...")
                            GoTo Sleep
                        End If

                        PacketID = Trim(PacketStr.Substring(4, 10))

                        Console.WriteLine("Message Recieved: " + PacketStr)

                        'STX character received
                        If PacketStr.Contains("695") = True Then Exit While

                        If PacketFailed = True Then Exit While
Sleep:
                    End While

                Catch ee As SocketException

                    ' Prep return packet message'
                    PacketMsg = Chr(2) & PacketID & Chr(6) & "00099" & Chr(3)
                    ' Echo the data back to the client.
                    msg = Encoding.ASCII.GetBytes(PacketMsg)
                    HandlerSocket.Send(msg)
                    HandlerSocket.Shutdown(SocketShutdown.Both)
                    HandlerSocket.Close()
                    PacketFailed = True

                Finally

                End Try

                Console.WriteLine("Packet Failed: " + CType(PacketFailed, String))
                If PacketFailed = True Then
                    ' Prep return packet message'
                    PacketMsg = Chr(2) & PacketID & "NAK"
                Else
                    ' Prep return packet message'
                    PacketMsg = Chr(2) & PacketID & "ACK"
                End If

                PacketStatusCode = 10
                If PacketFailed Then PacketStatusCode = 0

                PacketStr = Trim(PacketStr.Substring(1, 36))

                tblReply = sp.GBI_Packets_ADD(Profile.p_ConnectionString, "AssignBox", PacketStr, PacketMsg)

                Dim Orderid As String = tblReply.Rows(0).Item("OrderID").ToString()

                PacketMsg = PacketMsg & Orderid & Chr(3)

                Console.WriteLine("Message Returned: " + PacketMsg)

                ' Echo the data back to the client.
                msg = Encoding.ASCII.GetBytes(PacketMsg)
                HandlerSocket.Send(msg)

            End While

        Catch ex As Exception 'SocketException
            eh._Err(Profile, "GetPackets in clsGetBox", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
        End Try
    End Sub

End Class 'Get Orders
