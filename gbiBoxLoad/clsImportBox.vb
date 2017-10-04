Option Strict On

Imports Common.clsCommon

Public Class clsImportBox

    'Instantiate error handler
    Private eh As New ErrorHandling.clsErrorHandler
    Private ep As New Common.errParams(System.Reflection.MethodInfo.GetCurrentMethod.DeclaringType.Name, "", DisplayIt, NotifyIT, LogIt)

    'Instantiate Stored Procedures 
    Private sp As New GBI.clsStoredProcedures

    'Datasets and tables
    Private dsOrderHeader As DataSet
    Private dsOrderItem As DataSet
    Private tblOrderHeader As DataTable
    Private tblOrderItem As DataTable

    'Accumulators
    Private c_TotQtyOrdered As Integer
    Private c_TotQtyToPack As Integer

#Region "Properties"

    Private ClassName As String = System.Reflection.MethodInfo.GetCurrentMethod.DeclaringType.Name
    'IN
    Private Profile As Common.objProfile
    Private c_PacketID As String = String.Empty
    Private c_Packet As String = String.Empty

    Public WriteOnly Property p_Profile() As Common.objProfile
        Set(ByVal Value As Common.objProfile)
            Profile = Value
        End Set
    End Property

    Public WriteOnly Property p_PacketID As String
        Set(value As String)
            c_PacketID = value
        End Set
    End Property

    Public WriteOnly Property p_Packet As String
        Set(value As String)
            c_Packet = value
        End Set
    End Property

#End Region 'Properties

#Region "Public Methods"

    Public Sub ProcessPacket()

        Dim aPacket As String()
        Dim aRecord As String()

        Dim PickTckt As String
        Dim CustNmbr As String
        Dim isSISQ As String
        Dim OrdNmbr As String = ""
        Dim LinSeqNo As Integer

        MakeDatasets()

        Try
            ' get Packet records
            aPacket = c_Packet.Split(New Char() {Chr(30)})

            'Parse first record (packet header + pick tick header "H" records)
            aRecord = aPacket(0).Split(New Char() {Chr(9)})

            'Check number of elements
            If aRecord.Length <> 5 Then Throw New ArgumentOutOfRangeException(" Wrong number of elements in H record. Packet ID " & c_PacketID)

            'Get header fields
            PickTckt = aRecord(2).Trim
            CustNmbr = aRecord(3).Trim
            isSISQ = aRecord(4).Trim

            'Throw exception if any header fields are blank
            Select Case String.Empty
                Case PickTckt
                    Throw New ArgumentOutOfRangeException(" WMS Control # cannot be blank. Packet ID " & c_PacketID)
                Case CustNmbr
                    Throw New ArgumentOutOfRangeException(" Customer # cannot be blank. Packet ID " & c_PacketID)
                Case isSISQ
                    Throw New ArgumentOutOfRangeException(" isSISQ cannot be blank. Packet ID " & c_PacketID)
            End Select

            'parse packet records
            For i = 1 To (aPacket.Length - 1)

                aRecord = aPacket(i).Split(New Char() {Chr(9)})

                Select Case aRecord(0)

                    Case "O" 'order header: START OF NEW ORDER

                        'If previous order exists in dataset, add it to SQL tables
                        If dsOrderHeader.Tables(0).Rows.Count > 0 Then
                            If AddOrder() = "err" Then Exit Sub
                        End If

                        'Create new order header and detail datasets for each order
                        dsOrderHeader.Clear()
                        dsOrderItem.Clear()

                        'Parse O record into Order Header dataset
                        OrdNmbr = ParseOrderHeader(aRecord, PickTckt, CustNmbr, isSISQ)
                        If OrdNmbr = "err" Then Exit Sub

                        'Start new detail line sequence and accumulators
                        LinSeqNo = 0
                        c_TotQtyOrdered = 0
                        c_TotQtyToPack = 0

                    Case "D"    'order detail

                        LinSeqNo += 1

                        'Parse D record into Order Detail dataset
                        If ParseOrderItem(aRecord, PickTckt, OrdNmbr, LinSeqNo, CustNmbr) = "err" Then Exit Sub

                    Case "T"    'packet end

                        If dsOrderHeader.Tables(0).Rows.Count > 0 Then
                            If AddOrder() = "err" Then Exit Sub
                        End If
                        LinSeqNo = 0
                        c_TotQtyOrdered = 0
                        c_TotQtyToPack = 0

                End Select

            Next i

        Catch ex As Exception
            eh._Err(Profile, "processPacket in clsImportOrders", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
            Exit Sub
        End Try

    End Sub

#End Region 'Public Methods

    Private Sub MakeDatasets()

        dsOrderHeader = New DataSet
        dsOrderItem = New DataSet
        tblOrderHeader = New DataTable
        tblOrderItem = New DataTable

        Dim tm As New Common._TableMaker("tblOrderHeader")
        tm._AddColumn("System.String", "PickTckt", False, False)
        tm._AddColumn("System.String", "OrdNmbr", False, False)
        tm._AddColumn("System.String", "CustNmbr", False, False)

        tm._AddColumn("System.String", "ShipCompleteOnly", False, False)
        tm._AddColumn("System.String", "IsSISQ", False, False)

        tm._AddColumn("System.String", "AecConfID", False, False)
        tm._AddColumn("System.String", "RtlPoID", False, False)
        tm._AddColumn("System.String", "RtlCstPoNbr", False, False)
        tm._AddColumn("System.String", "RtlShipMthd", False, False)
        tm._AddColumn("System.String", "ShipMthdCd", False, False)
        tm._AddColumn("System.String", "ShipMthdDesc", False, False)

        tm._AddColumn("System.String", "BillName", False, False)
        tm._AddColumn("System.String", "BillAddr1", False, False)
        tm._AddColumn("System.String", "BillAddr2", False, False)
        tm._AddColumn("System.String", "BillAddr3", False, False)
        tm._AddColumn("System.String", "BillCoName", False, False)
        tm._AddColumn("System.String", "BillCity", False, False)
        tm._AddColumn("System.String", "BillState", False, False)
        tm._AddColumn("System.String", "BillZip", False, False)
        tm._AddColumn("System.String", "BillCtryCd", False, False)
        tm._AddColumn("System.String", "BillCtry", False, False)
        tm._AddColumn("System.String", "BillPhone", False, False)
        tm._AddColumn("System.String", "BillEmail", False, False)

        tm._AddColumn("System.String", "ShipName", False, False)
        tm._AddColumn("System.String", "ShipAddr1", False, False)
        tm._AddColumn("System.String", "ShipAddr2", False, False)
        tm._AddColumn("System.String", "ShipAddr3", False, False)
        tm._AddColumn("System.String", "ShipCoName", False, False)
        tm._AddColumn("System.String", "ShipCity", False, False)
        tm._AddColumn("System.String", "ShipState", False, False)
        tm._AddColumn("System.String", "ShipZip", False, False)
        tm._AddColumn("System.String", "ShipCtryCd", False, False)
        tm._AddColumn("System.String", "ShipCtry", False, False)
        tm._AddColumn("System.String", "ShipPhone", False, False)
        tm._AddColumn("System.String", "ShipEmail", False, False)

        tm._AddColumn("System.String", "TotQtyOrdered", False, False)
        tm._AddColumn("System.String", "TotQtyToPack", False, False)
        tm._AddColumn("System.String", "SigReqrd", False, False)
        tm._AddColumn("System.String", "SatDlvry", False, False)
        tm._AddColumn("System.String", "OrdGiftMsg", False, False)
        tm._AddColumn("System.String", "InvMsg", False, False)
        tblOrderHeader = tm.p_Table
        tm = Nothing
        dsOrderHeader.Tables.Add(tblOrderHeader)

        tm = New Common._TableMaker("tblOrderItem")
        tm._AddColumn("System.String", "ShipNmbr", False, False)
        tm._AddColumn("System.String", "PickTckt", False, False)
        tm._AddColumn("System.String", "OrdNmbr", False, False)
        tm._AddColumn("System.String", "LinSeqNo", False, False)

        tm._AddColumn("System.String", "QtyOrdered", False, False)
        tm._AddColumn("System.String", "QtyToPack", False, False)

        tm._AddColumn("System.String", "Barcode", False, False)
        tm._AddColumn("System.String", "Barcode2", False, False)
        tm._AddColumn("System.String", "Barcode3", False, False)
        tm._AddColumn("System.String", "WMSID", False, False)
        tm._AddColumn("System.String", "ItemDesc", False, False)
        tm._AddColumn("System.String", "ProdTypeCode", False, False)

        tm._AddColumn("System.String", "UnitPrice", False, False)
        tm._AddColumn("System.String", "WeightOz", False, False)

        tm._AddColumn("System.String", "CustSKU", False, False)
        tm._AddColumn("System.String", "CustReturnMethod", False, False)
        tm._AddColumn("System.String", "LnGiftMsg", False, False)
        tm._AddColumn("System.String", "LnInvMsg", False, False)

        tm._AddColumn("System.String", "CustNmbr", False, False)
        tblOrderItem = tm.p_Table
        tm = Nothing
        dsOrderItem.Tables.Add(tblOrderItem)

    End Sub

    Private Function ParseOrderHeader(aHeader As String(), PickTckt As String, CustNmbr As String, IsSISQ As String) As String

        ParseOrderHeader = ""

        Try

            ' Verify number of elements
            If aHeader.Length <> 38 Then Throw New ArgumentOutOfRangeException(" Wrong number of elements in O record. Pick Ticket " & PickTckt)
            ' Check Order Number
            If aHeader(1).Trim = String.Empty Then Throw New ArgumentOutOfRangeException(" AEC Order # cannot be blank. Pick Ticket " & PickTckt)
            ' Check AEC Confirmation ID        ' For Super D, it will be their Retail PO ID (IS THIS STILL THE CASE?)
            If aHeader(2) = String.Empty Then Throw New ArgumentOutOfRangeException(" AEC Confirmation cannot be blank. Pick Ticket " & PickTckt & " Order # " & aHeader(1))
            ' Ship Method Code cannot be blank
            If aHeader(7).Trim = String.Empty Then Throw New ArgumentOutOfRangeException(" Ship Method Code cannot be blank. Pick Ticket " & PickTckt & " Order # " & aHeader(1))

            Dim r As DataRow = dsOrderHeader.Tables(0).NewRow
            r("PickTckt") = PickTckt
            r("CustNmbr") = CustNmbr
            r("IsSISQ") = IsSISQ

            r("OrdNmbr") = aHeader(1) 'strOrdNmbr
            r("AecConfID") = aHeader(2) 'strAecConfID
            r("RtlPoID") = aHeader(3) 'strRtlPoID
            r("RtlCstPoNbr") = aHeader(4) 'strRtlCstPoNbr
            r("ShipCompleteOnly") = aHeader(5) 'strShipComplete       strShipComplete 
            r("RtlShipMthd") = aHeader(6) 'strRtlShipMthd        strRtlShipMthd =
            r("ShipMthdCd") = aHeader(7) 'intShipMthdCd         intShipMthdCd =
            r("ShipMthdDesc") = aHeader(8) 'strShipMthdDesc       strShipMthdDesc 

            r("BillName") = aHeader(9) 'strBillName	          strBillName =	
            r("BillAddr1") = aHeader(10) 'strBillAddr1         strBillAddr1 =	
            r("BillAddr2") = aHeader(11) 'strBillAddr2         strBillAddr2 =	
            r("BillAddr3") = aHeader(12) 'strBillAddr3         strBillAddr3 =	
            r("BillCoName") = aHeader(13) 'strBillCoName        strBillCoName =
            r("BillCity") = aHeader(14) 'strBillCity          strBillCity =	
            r("BillState") = aHeader(15) 'strBillState         strBillState =	
            r("BillZip") = aHeader(16) 'strBillZip	          strBillZip =	
            r("BillCtryCd") = aHeader(17) 'strBillCtryCd        strBillCtryCd =
            r("BillCtry") = aHeader(18) 'strBillCtry          strBillCtry =	
            r("BillPhone") = aHeader(19) 'strBillPhone         strBillPhone =	
            r("BillEmail") = aHeader(20) 'strBillEmail         strBillEmail =	

            r("ShipName") = aHeader(21) 'strShipName          strShipName =	
            r("ShipAddr1") = aHeader(22) 'strShipAddr1         strShipAddr1 =	
            r("ShipAddr2") = aHeader(23) 'strShipAddr2         strShipAddr2 =	
            r("ShipAddr3") = aHeader(24) 'strShipAddr3         strShipAddr3 =	
            r("ShipCoName") = aHeader(25) 'strShipCoName        strShipCoName =
            r("ShipCity") = aHeader(26) 'strShipCity          strShipCity =	
            r("ShipState") = aHeader(27) 'strShipState         strShipState =	
            r("ShipZip") = aHeader(28) 'strShipZip	          strShipZip =	
            r("ShipCtryCd") = aHeader(29) 'strShipCtryCd        strShipCtryCd =
            r("ShipCtry") = aHeader(30) 'strShipCtry          strShipCtry =	
            r("ShipPhone") = aHeader(31) 'strShipPhone         strShipPhone =	
            r("ShipEmail") = aHeader(32) 'strShipEmail         strShipEmail =	

            r("OrdGiftMsg") = aHeader(34) 'strOrdGiftMsg        strOrdGiftMsg =
            r("InvMsg") = aHeader(35) 'strInvMsg	          strInvMsg =		
            r("SigReqrd") = aHeader(36) 'strSigReqrd          strSigReqrd =	
            r("SatDlvry") = aHeader(37) 'strSatDlvry          strSatDlvry =	
            dsOrderHeader.Tables(0).Rows.Add(r)
            r = Nothing

            'Return order number
            Return aHeader(1).Trim

        Catch ex As Exception

            eh._Err(Profile, "ParseOrderHeader in clsImportOrders", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
            Return "err"
        End Try

    End Function

    Private Function ParseOrderItem(aItem As String(), PickTckt As String, OrdNmbr As String, LinSeqNo As Integer, CustNmbr As String) As String

        Try

            If aItem.Length <> 15 Then Throw New ArgumentOutOfRangeException(" Wrong number of elements in D record. Pick Ticket " & PickTckt & " Order # " & OrdNmbr)
            If aItem(1).Trim = String.Empty Then Throw New ArgumentOutOfRangeException(" WMS Id cannot be blank. Pick Ticket " & PickTckt & " Order # " & OrdNmbr)
            If aItem(2).Trim = String.Empty Then Throw New ArgumentOutOfRangeException(" UPC/EAN cannot be blank. Pick Ticket " & PickTckt & " Order # " & OrdNmbr)

            Dim r As DataRow = dsOrderItem.Tables(0).NewRow

            r("ShipNmbr") = ""
            r("PickTckt") = PickTckt
            r("OrdNmbr") = OrdNmbr
            r("LinSeqNo") = LinSeqNo.ToString
            r("CustNmbr") = CustNmbr

            r("WMSID") = aItem(1).Trim 'strWmsID =		
            r("Barcode") = aItem(2).Trim 'strBarcode =	
            r("ProdTypeCode") = aItem(3).Trim 'strProdTypeCd = 
            r("QtyOrdered") = aItem(4).Trim 'intQtyOrd =		
            r("QtyToPack") = aItem(5).Trim 'intQtyToPick =	
            r("UnitPrice") = aItem(6).Trim 'decUnitPrice =	
            r("WeightOz") = aItem(7).Trim 'decWeightOz =	
            r("ItemDesc") = aItem(8).Trim 'strItemDesc =	
            r("CustSKU") = aItem(9).Trim 'strSkuRefID =	
            r("LnGiftMsg") = aItem(10).Trim 'strLnGiftMsg =	
            r("Barcode2") = aItem(11).Trim 'strBarcode2 =	
            r("Barcode3") = aItem(12).Trim 'strBarcode3 =	
            r("LnInvMsg") = aItem(13).Trim 'strLnInvMsg =	
            r("CustReturnMethod") = aItem(14).Trim 'strRtnMthd =	

            dsOrderItem.Tables(0).Rows.Add(r)
            r = Nothing

            c_TotQtyOrdered += CInt(aItem(4).Trim)
            c_TotQtyToPack += CInt(aItem(5).Trim)

            Return ""

        Catch ex As Exception

            eh._Err(Profile, "ParseOrderItem in clsImportOrders", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
            Return "err"
        End Try

    End Function

    Private Function AddOrder() As String
        ep.MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name

        Dim ds As DataSet
        Dim ShipNmbr As String

        Try

            Dim dOrderHeader As New Dictionary(Of String, String)

            'get data row
            With dsOrderHeader.Tables(0).Rows(0)

                dOrderHeader.Add("@PickTckt", .Item("PickTckt").ToString)
                dOrderHeader.Add("@OrdNmbr", .Item("OrdNmbr").ToString)
                dOrderHeader.Add("@CustNmbr", .Item("CustNmbr").ToString)

                dOrderHeader.Add("@ShipCompleteOnly", .Item("ShipCompleteOnly").ToString)
                dOrderHeader.Add("@IsSISQ", .Item("IsSISQ").ToString)

                dOrderHeader.Add("@AecConfId", .Item("AecConfId").ToString)
                dOrderHeader.Add("@RtlPoID", .Item("RtlPoID").ToString)
                dOrderHeader.Add("@RtlCstPoNbr", .Item("RtlCstPoNbr").ToString)
                dOrderHeader.Add("@RtlShipMthd", .Item("RtlShipMthd").ToString)
                dOrderHeader.Add("@ShipMthdCd", .Item("ShipMthdCd").ToString)
                dOrderHeader.Add("@ShipMthdDesc", .Item("ShipMthdDesc").ToString)

                dOrderHeader.Add("@BillName", .Item("BillName").ToString)
                dOrderHeader.Add("@BillAddr1", .Item("BillAddr1").ToString)
                dOrderHeader.Add("@BillAddr2", .Item("BillAddr2").ToString)
                dOrderHeader.Add("@BillAddr3", .Item("BillAddr3").ToString)
                dOrderHeader.Add("@BillCoName", .Item("BillCoName").ToString)
                dOrderHeader.Add("@BillCity", .Item("BillCity").ToString)
                dOrderHeader.Add("@BillState", .Item("BillState").ToString)
                dOrderHeader.Add("@BillZip", .Item("BillZip").ToString)
                dOrderHeader.Add("@BillCtryCd", .Item("BillCtryCd").ToString)
                dOrderHeader.Add("@BillCtry", .Item("BillCtry").ToString)
                dOrderHeader.Add("@BillPhone", .Item("BillPhone").ToString)
                dOrderHeader.Add("@BillEmail", .Item("BillEmail").ToString)

                dOrderHeader.Add("@ShipName", .Item("ShipName").ToString)
                dOrderHeader.Add("@ShipAddr1", .Item("ShipAddr1").ToString)
                dOrderHeader.Add("@ShipAddr2", .Item("ShipAddr2").ToString)
                dOrderHeader.Add("@ShipAddr3", .Item("ShipAddr3").ToString)
                dOrderHeader.Add("@ShipCoName", .Item("ShipCoName").ToString)
                dOrderHeader.Add("@ShipCity", .Item("ShipCity").ToString)
                dOrderHeader.Add("@ShipState", .Item("ShipState").ToString)
                dOrderHeader.Add("@ShipZip", .Item("ShipZip").ToString)
                dOrderHeader.Add("@ShipCtryCd", .Item("ShipCtryCd").ToString)
                dOrderHeader.Add("@ShipCtry", .Item("ShipCtry").ToString)
                dOrderHeader.Add("@ShipPhone", .Item("ShipPhone").ToString)
                dOrderHeader.Add("@ShipEmail", .Item("ShipEmail").ToString)

                dOrderHeader.Add("@TotQtyOrdered", c_TotQtyOrdered.ToString)
                dOrderHeader.Add("@TotQtyToPack", c_TotQtyToPack.ToString)
                dOrderHeader.Add("@SigReqrd", .Item("SigReqrd").ToString)
                dOrderHeader.Add("@SatDlvry", .Item("SatDlvry").ToString)
                dOrderHeader.Add("@OrdGiftMsg", .Item("OrdGiftMsg").ToString)
                dOrderHeader.Add("@InvMsg", .Item("InvMsg").ToString)

            End With

            ds = sp.OrderLoad_OrderHeader_ADD(Profile, ep, dOrderHeader)
            If spResult(ds) = "err" Then Return "err"

            ShipNmbr = ds.Tables(0).Rows(0)("ShipNmbr").ToString

            Dim dOrderItem As Dictionary(Of String, String)

            For Each r As DataRow In dsOrderItem.Tables(0).Rows

                dOrderItem = New Dictionary(Of String, String)

                dOrderItem.Add("@ShipNmbr", ShipNmbr)
                dOrderItem.Add("@PickTckt", r.Item("PickTckt").ToString)
                dOrderItem.Add("@OrdNmbr", r.Item("OrdNmbr").ToString)
                dOrderItem.Add("@LinSeqNo", r.Item("LinSeqNo").ToString)

                dOrderItem.Add("@QtyOrdered", r.Item("QtyOrdered").ToString)
                dOrderItem.Add("@QtyToPack", r.Item("QtyToPack").ToString)

                dOrderItem.Add("@Barcode", r.Item("Barcode").ToString)
                dOrderItem.Add("@Barcode2", r.Item("Barcode2").ToString)
                dOrderItem.Add("@Barcode3", r.Item("Barcode3").ToString)
                dOrderItem.Add("@WMSID", r.Item("WMSID").ToString)
                dOrderItem.Add("@ItemDesc", r.Item("ItemDesc").ToString)
                dOrderItem.Add("@ProdTypeCode", r.Item("ProdTypeCode").ToString)

                dOrderItem.Add("@UnitPrice", r.Item("UnitPrice").ToString)
                dOrderItem.Add("@WeightOz", r.Item("WeightOz").ToString)

                dOrderItem.Add("@CustSKU", r.Item("CustSKU").ToString)
                dOrderItem.Add("@CustReturnMethod", r.Item("CustReturnMethod").ToString)
                dOrderItem.Add("@LnGiftMsg", r.Item("LnGiftMsg").ToString)
                dOrderItem.Add("@LnInvMsg", r.Item("LnInvMsg").ToString)

                dOrderItem.Add("@CustNmbr", r.Item("CustNmbr").ToString)

                ds = sp.OrderLoad_OrderItem_ADD(Profile, ep, dOrderItem)
                If spResult(ds) = "err" Then Return "err"

            Next r

            Return ""

        Catch ex As Exception

            eh._Err(Profile, "AddOrder in clsImportOrders", ex.Message, ex, NoDisplay, NotifyIT, LogIt)
            Return "err"

        End Try

    End Function

    Public Function spResult(ds As DataSet) As String

        'Status table always last in dataset
        Dim tblStatus As DataTable = ds.Tables(ds.Tables.Count - 1)
        Dim spStatus As String = tblStatus.Rows(0)("Status").ToString.Trim.ToLower
        Dim spErr As String = tblStatus.Rows(0)("Err").ToString
        Dim spErrDetail As String = tblStatus.Rows(0)("ErrDetail").ToString

        'If status is err, display/notify/log the error
        If spStatus = "err" Then
            Dim objEx As New Common.spException
            objEx.p_Message = spErrDetail
            objEx.Source = ep.ClassName
            eh._Err(Profile, ep.MethodName, spErr, objEx, ep.Display, ep.Notify, ep.Log)
        End If

        Return spStatus

    End Function

End Class
