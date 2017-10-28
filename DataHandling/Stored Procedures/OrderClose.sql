USE [GRS];
GO
/****** Object:  StoredProcedure [dbo].[OrderClose]    Script Date: 10/10/2017 4:26:49 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

ALTER PROCEDURE [dbo].[OrderClose]
/*******************************************************************************************
	Name:		OrderClose
	
	Desc:		For all completed PickTickets, creates Dhcart info packets for transmission to PKMS.

	Auth:		jah
	
	Called by:  
             
	Date: 10/10/2017

===============================================================================
	Change History
===============================================================================
	Date:		Author:		Description:
	--------	--------	---------------------------------------------------


===============================================================================
	Tables and Notes
===============================================================================

******************************************************************************************/

AS
SET NOCOUNT ON;

--==============================================================================================
--DECLARE/INIT LOCAL VARS
--==============================================================================================
DECLARE @PickTckt CHAR(20),
        @PickTcktStatusCode CHAR(1),
        @PickTicketsMax INT,
        @x INT = 1;

DECLARE @PacketID BIGINT,
        @ShipInfoMax INT,
        @ShipInfo_ItemMax INT,
        @i INT = 1,
        @j INT = 1;

DECLARE @PacketStr VARCHAR(MAX) 
DECLARE @PacketIDStr CHAR(10);

DECLARE @Picktckt CHAR(20),
        @BoxId CHAR(20),
        @BoxType CHAR(20),
        @WorkStation CHAR(3),
        @NumOfBoxes TINYINT,
        @LastBox BIT,
        @NbrOfDtls TINYINT,
        @Sku CHAR(20),
        @QtyPacked TINYINT,
        @PicktcktStat TINYINT,
        @NbrOfBoxes TINYINT;

CREATE TABLE #PickTickets
(
    PickTckt CHAR(20),
    PickTcktStatusCode CHAR(1),
    RowID INT IDENTITY(1, 1)
);

CREATE TABLE #CartonHeader
(
    RowID INT IDENTITY(1, 1),
    PickTckt CHAR(20),
    BoxID CHAR(20),
    BoxType CHAR(20),
    WorkStation CHAR(3),
    Filler1 CHAR(6),
    Filler2 CHAR(8),
    NumOfBoxes TINYINT,
    LastBox BIT,
    NbrOfDtls TINYINT
);

CREATE TABLE #CartonDetail
(
    RowID TINYINT IDENTITY(1, 1),
    Sku CHAR(20),
    QtyPacked TINYINT
);

CREATE TABLE #OrderComplete
(
    RowID INT IDENTITY(1, 1),
    Filler1 CHAR(1),
    Picktckt CHAR(20),
    PicktcktStat TINYINT,
    Workstation CHAR(3),
    Filler2 CHAR(6),
    Filler3 CHAR(8),
    NbrOfBoxes TINYINT
);

--==============================================================================================
--BEGIN PROCESSING
--==============================================================================================

--==============================================================================================
--
--==============================================================================================

--Get all completed PickTickets
INSERT #PickTickets
SELECT DISTINCT OrderID,
       Status
FROM Galaxy.dbo.Sort_info
WHERE Status = 'C'; -- Complete
SELECT @PickTicketsMax = MAX(RowID)
FROM #PickTickets;
IF ISNULL(@PickTicketsMax, 0) = 0
BEGIN
    GOTO xIT;
END;

SET @x = 1;
--PickTicket loop
WHILE @x <= @PickTicketsMax
BEGIN

    SELECT @Picktckt = PickTckt,
           @PickTcktStatusCode = PickTcktStatusCode
    FROM #PickTickets
    WHERE RowID = @x;

    IF @PickTcktStatusCode = 'C'
    BEGIN

        --Get ShipInfo data for all orders in PickTckt. If none found, error.
        SELECT @NbrOfDtls = COUNT(Sku)
        FROM galaxy.dbo.ProductDistribution
        WHERE orderid = @Picktckt;
        INSERT #CartonHeader
        (
            PickTckt,
            BoxID,
            BoxType,
            WorkStation,
            Filler1,
            Filler2,
            NumOfBoxes,
            LastBox,
            NbrOfDtls
        )
        SELECT OrderId,
               CartonID,
               'TOT',
               'GBI',
               '      ',   --6
               '        ', --8
               1,
               1,
               @NbrOfDtls
        FROM Galaxy.dbo.Sort_info
        WHERE OrderId = @Picktckt;
        SELECT @ShipInfoMax = MAX(RowID)
        FROM #ShipInfo;

        --Insert Packet record stub (establishes PacketID)
        INSERT ShipInfo_Packets
        (
            PickTckt,
            WaveNmbr,
            Warehouse,
            PacketStatusCode,
            LastResponse,
            LastDateSent,
            PacketStr
        )
        SELECT @Picktckt,
               '',
               '',
               0,
               '',
               '1900-01-01',
               ''; --PacketStatusCode = 0 (UNPREPPED)
        SELECT @PacketID = SCOPE_IDENTITY();

        --==============================================================================================
        -- BUILD PACKET STRING
        --==============================================================================================
        --Padded PacketID string
        SET @PacketIDStr = RIGHT('0000000000' + RTRIM(@PacketID), 10);

        --Packet header
        SET @PacketStr = CHAR(2) + @PacketIDStr + CHAR(9) + 'H' + CHAR(9) + '' + CHAR(30);

        SET @i = 1;

        --ShipInfo loop
        WHILE @i <= @ShipInfoMax
        BEGIN

            SELECT @WaveNmbr = WaveNmbr,
                   @OrdNmbr = OrdNmbr,
                   @ShipNmbr = ShipNmbr,
                   @ShipMethodCode = ShipMethodCode,
                   @FreightAmt = FreightAmt,
                   @FreightCostAmt = FreightCostAmt,
                   @TrkgNmbr = TrkgNmbr,
                   @ActualWeightLb = CAST(ActualWeightOz / 16 AS DECIMAL(10, 4)),
                   @RatedWeightLb = CAST(RatedWeightOz / 16 AS DECIMAL(10, 4)),
                   @SigReq = CASE
                                 WHEN IsSignatureReq = 1 THEN
                                     'Y'
                                 ELSE
                                     'N'
                             END,
                   @SatDel = CASE
                                 WHEN IsSaturdayDelivery = 1 THEN
                                     'Y'
                                 ELSE
                                     'N'
                             END
            FROM #ShipInfo
            WHERE RowID = @i;

            --Carton header (ShipInfo level)
            SET @PacketStr
                = @PacketStr + 'C' + CHAR(9) + RTRIM(@WaveNmbr) + CHAR(9) + RTRIM(@OrdNmbr) + CHAR(9)
                  + RTRIM(@ShipNmbr) + CHAR(9) + --Pass ShpNmbr in CartonNmbr field
            RTRIM(@ShipMethodCode) + CHAR(9) + '' + CHAR(9) + RTRIM(@FreightAmt) + CHAR(9) + RTRIM(@FreightCostAmt)
                  + CHAR(9) + RTRIM(@TrkgNmbr) + CHAR(9) + RTRIM(@ActualWeightLb) + CHAR(9) + RTRIM(@RatedWeightLb)
                  + CHAR(9) + CHAR(9) + CHAR(9) + @SigReq + CHAR(9) + @SatDel + CHAR(30);

            --Get ShipInfo_Item for @ShipNmbr
            TRUNCATE TABLE #ShipInfo_Item;
            INSERT #ShipInfo_Item
            (
                WMSID,
                ItemBarcode,
                QtyPacked
            )
            SELECT WMSID,
                   ItemBarcode,
                   QtyPacked
            FROM GRS..ShipInfo_Item
            WHERE ShipNmbr = @ShipNmbr
            ORDER BY LinSeqNo;
            SELECT @ShipInfo_ItemMax = MAX(RowID)
            FROM #ShipInfo_Item;

            SET @j = 1;

            --ShipInfo_Item loop
            WHILE @j <= @ShipInfo_ItemMax
            BEGIN

                SELECT @WMSID = WMSID,
                       @ItemBarcode = ItemBarcode,
                       @QtyPacked = QtyPacked
                FROM #ShipInfo_Item
                WHERE RowID = @j;

                --Carton Detail (ShipInfo_Item level)
                SET @PacketStr
                    = @PacketStr + 'D' + CHAR(9) + RTRIM(@WMSID) + CHAR(9) + RTRIM(@ItemBarcode) + CHAR(9)
                      + RTRIM(@QtyPacked) + CHAR(30);

                SET @j = @j + 1;

            END; -- ShipInfo_Item loop

            SET @i = @i + 1;

        END; -- ShipInfo loop

        -- Packet footer
        SET @PacketStr = @PacketStr + 'T' + CHAR(9) + RTRIM(@ShipInfoMax) + CHAR(3);


        --Update Packet record with Packet String, Status, Warehouse, and WaveNmbr)
        UPDATE grs..ShipInfo_Packets
        SET WaveNmbr = @WaveNmbr,
            Warehouse = CASE LEFT(@Picktckt, 3)
                            WHEN '120' THEN
                                'BAR'
                            WHEN '020' THEN
                                'CS2'
                            ELSE
                                'LD2'
                        END,
            PacketStatusCode = 10, --(READY)
            PacketStr = @PacketStr
        WHERE PacketID = @PacketID;

        --Update PickTicket and Order status = 70 -- CLOSED
        UPDATE GRS..PickTickets
        SET PickTcktStatusCode = 70
        WHERE PickTckt = @Picktckt;

        UPDATE OrderHeader
        SET OrderStatusCode = 70 --CLOSED
        WHERE PickTckt = @Picktckt;

        SET @x = @x + 1;
    END; --PickTicket loop

    ----	RETURN PACKET RECORD
    --	select * from SendToPM_Packets where PacketID = @PacketID



    GOTO xIT;



    --==============================================================================================
    --EXIT
    --==============================================================================================
    xit:

END;
