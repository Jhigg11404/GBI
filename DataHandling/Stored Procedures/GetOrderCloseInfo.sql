USE [Galaxy];
GO
IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[GetOrderCloseInfo]')
          AND type = 'P'
)
    DROP PROCEDURE dbo.GetOrderCloseInfo;
GO

/****** Object:  StoredProcedure [dbo].[GetOrderCloseInfo]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE PROCEDURE [dbo].[GetOrderCloseInfo] @BoxId VARCHAR(30)
AS
/*******************************************************************************************
	Name:		GetOrderCloseInfo
	
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

SET NOCOUNT ON;

--==============================================================================================
--DECLARE/INIT LOCAL VARS
--==============================================================================================

DECLARE @Picktckt CHAR(20),
        @BoxType CHAR(20),
        @WorkStation CHAR(3),
        @NumOfBoxes TINYINT,
        @LastBox BIT,
        @NbrOfDtls TINYINT,
        @Sku CHAR(20),
        @QtyPacked TINYINT,
        @PicktcktStat VARCHAR(2),
        @NbrOfBoxes TINYINT;

CREATE TABLE #CartonHeader
(
    RowID INT IDENTITY(1, 1),
    PickTckt VARCHAR(20),
	UserId VARCHAR(7),
	Destination VARCHAR(3),
    BoxID VARCHAR(21),
    BoxType VARCHAR(20),
    WorkStation VARCHAR(3),
    DateTimeClosed DATETIME,
    NumOfBoxes VARCHAR(4),
    LastBox BIT
);

CREATE TABLE #CartonDetail
(
    RowID INT IDENTITY(1, 1),
    Sku VARCHAR(20),
    QtyPacked VARCHAR(5)
);

CREATE TABLE #OrderComplete
(
    RowID INT IDENTITY(1, 1),
    Filler1 VARCHAR(1),
    Picktckt VARCHAR(20),
    PicktcktStat VARCHAR(2),
    Workstation VARCHAR(3),
    Filler2 VARCHAR(6),
    Filler3 VARCHAR(8),
    NbrOfBoxes TINYINT
);

--==============================================================================================
--BEGIN PROCESSING
--==============================================================================================
--Get all completed PickTickets

SELECT DISTINCT
	   @Picktckt = OrderID,
       @PicktcktStat = [Status]
FROM Galaxy.dbo.Sort_Info
WHERE CartonId = @BoxId;

IF @PicktcktStat = 'C'
BEGIN

    --Get ShipInfo data for all orders in PickTckt. If none found, error.
    SELECT @NbrOfDtls = COUNT(si.SKU)
    FROM Galaxy.dbo.Sort_Info AS si
    WHERE OrderID = @Picktckt;

    INSERT #CartonHeader
    (
        PickTckt,
		UserId,
		Destination,
        BoxID,
        BoxType,
        WorkStation,
        DateTimeClosed,
        NumOfBoxes,
        LastBox
    )
    SELECT DISTINCT
        OrderID,
		'',
		DropLocation,
        CartonID,
        '000000000208',
        'GBI',
        GETDATE(),   --6
        1,
        1
    FROM Galaxy.dbo.Sort_Info
    WHERE OrderID = @Picktckt;

    INSERT INTO #CartonDetail
    (
        Sku,
        QtyPacked
    )
    SELECT SKU,
           ConfirmedDrops
    FROM Galaxy.dbo.Sort_Info
    WHERE OrderID = @Picktckt;

	INSERT INTO #OrderComplete
	(
	    Filler1,
	    Picktckt,
	    PicktcktStat,
	    Workstation,
	    Filler2,
	    Filler3,
	    NbrOfBoxes
	)
	SELECT 
		'',
		@Picktckt,
		@PicktcktStat,
		'GBI',
		'',
		'',
		1

    SELECT ch.RowID,
           ch.PickTckt,
		   ch.UserId,
		   ch.Destination,
           ch.BoxID,
           ch.BoxType,
           ch.WorkStation,
           ch.DateTimeClosed,
           ch.NumOfBoxes,
           ch.LastBox
    FROM #CartonHeader AS ch;

    SELECT CAST(cd.RowID AS VARCHAR(4)) AS 'RowId',
           cd.Sku,
           cd.QtyPacked
    FROM #CartonDetail AS cd;

    SELECT oc.RowID,
           oc.Filler1,
           oc.Picktckt,
           oc.PicktcktStat,
           oc.Workstation,
           oc.Filler2,
           oc.Filler3,
           oc.NbrOfBoxes
    FROM #OrderComplete AS oc;

    GOTO xIT;

    --==============================================================================================
    --EXIT
    --==============================================================================================
    xit:

END;
