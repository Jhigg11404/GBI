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
        Dim PacketStr As String
        Dim PacketID As String = ""
        Dim PacketMsg As String = ""
        Dim PacketFailed As Boolean
        Dim PacketStatusCode As Integer
        Dim SocketName As String = Profile.p_AppName
        Dim Mode As String = Profile.p_AppMode

        Dim ListenerSocket As Socket
        Dim HandlerSocket As Socket

        ' Data buffer for incoming data.
        Dim bytes() As Byte = New [Byte](1024) {}

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

            'Start listening for connections. Program is suspended while waiting for an incoming connection.
            Console.WriteLine("Waiting for a connection...")
            HandlerSocket = ListenerSocket.Accept

            While True

                PacketStr = Nothing

                Try

                    ' An incoming connection needs to be processed.
                    While True

                        bytes = New Byte(1024) {}
                        bytesRec = HandlerSocket.Receive(bytes)

                        ' check if anything being sent 
                        If bytesRec = 0 Then
                            If dtStart = Nothing Then
                                dtStart = DateTime.Now
                            Else
                                'Break and restart after 10 seconds of inactivity
                                If DateDiff("s", dtStart, Date.Now) > 10 Then
                                    ListenerSocket.Dispose()
                                    Exit Sub
                                End If
                            End If
                        Else
                            If dtStart <> Nothing Then
                                dtStart = Nothing
                            End If
                        End If

                        PacketStr += Encoding.ASCII.GetString(bytes, 0, bytesRec)

                        'STX character received
                        If PacketStr.Contains("695") = True Then Exit While

                        If PacketFailed = True Then Exit While

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

                If PacketFailed = True Then
                    ' Prep return packet message'
                    PacketMsg = Chr(2) & PacketID & "NAK" & "00001NO <ETX> " & Chr(3)
                Else
                    ' Prep return packet message'
                    PacketMsg = Chr(2) & PacketID & "ACK" & "00000" & Chr(3)
                End If

                ' Echo the data back to the client.
                msg = Encoding.ASCII.GetBytes(PacketMsg)
                HandlerSocket.Send(msg)

                PacketStatusCode = 10
                If PacketFailed Then PacketStatusCode = 0
                sp.GBI_Packets_ADD(Profile.p_ConnectionString, "AssignBox", PacketStr, CType(PacketStatusCode, String))

                ' Process Packet if successful
                If PacketFailed = False Then
                End If

            End While

        Catch ex As Exception 'SocketException
            ' Log 
            eh._Err(Profile, "GetPackets in clsGetBpx", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
        End Try
    End Sub

End Class 'Get Orders
