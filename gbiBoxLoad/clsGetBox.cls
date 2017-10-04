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

        Dim ListenerSocket As Socket
        Dim HandlerSocket As Socket

        ' Data buffer for incoming data.
        Dim bytes() As Byte = New [Byte](1024) {}

        ' Get communication params  -- MAKE THIS TABLE DRIVEN ASAP
        Dim ipAddr As String = ConfigurationManager.AppSettings("ipAddr")
        Dim epPort As Integer = CType(ConfigurationManager.AppSettings("epPort"), Integer)
        Dim tmTimeOut As Integer = CType(ConfigurationManager.AppSettings("ListenTimeOut"), Integer)

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
            'Console.WriteLine("Waiting for a connection...")
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
                        If PacketStr.Contains(Chr(2)) = True Then PacketID = PacketStr.Substring(2, 10)

                        'ETX character received
                        If PacketStr.Contains(Chr(3)) = True Then Exit While

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
                sp.Order_Packets_ADD(Profile, ep, PacketID, PacketStr, PacketMsg, PacketStatusCode)

                ' Process Packet if successful
                If PacketFailed = False Then
                    Dim imp As clsImportBox = New clsImportBox
                    imp.p_Profile = Profile
                    imp.p_PacketID = PacketID
                    imp.p_Packet = PacketStr
                    imp.ProcessPacket()
                End If

            End While

        Catch ex As Exception 'SocketException
            ' Log 
            'sp.SocketMsg_Add(Profile, Profile.p_AppName, PacketID, PacketStr, ex.Message)
            eh._Err(Profile, "GetPackets in clsGetBpx", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
        End Try
    End Sub

End Class 'Get Orders
