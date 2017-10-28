USE [Galaxy];
GO
IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[ActivateWave]')
          AND xtype = 'P'
)
    DROP PROCEDURE dbo.ActivateWave;
GO

/****** Object:  StoredProcedure [dbo].[ActivateWave]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE PROCEDURE dbo.[ActivateWave] @WaveId VARCHAR(8)
AS
/*
===============================================================================
	File: 
	Name: ActivateWave
	Desc: AENT - GBI
		Activates Wave on GBI Sorter
	Auth: Higginbotham, Joshua
	Called by:   

	--exec dbo.ActivateWave '01413632'
             
	Date: 09/09/2017
===============================================================================
	Change History
===============================================================================
	Date:		Author:		Description:
	
	----------  -------     ---------------------------------------------------                             
===============================================================================
*/
SET NOCOUNT ON;

DECLARE @error_severity INT,
        @error_state INT,
        @error_number INT,
        @error_line INT,
        @error_message VARCHAR(245),
        @rowcount INT,
        @result INT,
        @return_status SMALLINT;
-- other work variables

DECLARE @Wave TABLE
(
    WaveId VARCHAR(8),
    OrderId VARCHAR(10),
    DropLocation INT IDENTITY(3, 1)
);

DECLARE @Orders TABLE
(
    OrderId VARCHAR(10),
    Sku VARCHAR(12),
    Barcode VARCHAR(15),
    QtyRequired SMALLINT
);

--Log Info
DECLARE @DateTime DATETIME,
        @Now DATETIME,
        @Process VARCHAR(50),
        @Message VARCHAR(250),
        @Msg VARCHAR(250),
        @Count TINYINT;


-- initialise
SET @return_status = 0;
SET @Process = 'Proc = ActivateWave';
SET @Now = GETDATE();

/*
===============================================================================

===============================================================================
*/
BEGIN

    SET @Msg = 'Activating Wave number ' + @WaveId + '.';
    EXEC Galaxy.dbo.AddLogInfo @DateTime = @Now,
                               @Process = @Process,
                               @Message = @Msg;


    TRUNCATE TABLE Galaxy.dbo.ProductDistribution;
    TRUNCATE TABLE Galaxy.dbo.Waves;
    TRUNCATE TABLE Galaxy.dbo.Profile_Configuration;

    INSERT INTO @Wave
    (
        WaveId,
        OrderId
    )
    SELECT DISTINCT
        ord.Waveid,
        ord.orderid
    FROM [SRV-1LD2APIX01].Apix2.dbo.orders ord
        INNER JOIN [SRV-1LD2APIX01].apix2.dbo.details dtl
            ON ord.orderid = dtl.orderid
    WHERE ord.Waveid = @WaveId;

    INSERT INTO @Orders
    (
        OrderId,
        Sku,
        Barcode,
        QtyRequired
    )
    SELECT ord.orderid,
           dtl.ProductID,
           dtl.verifybcr,
           dtl.QtyRequired
    FROM [SRV-1LD2APIX01].Apix2.dbo.orders ord
        INNER JOIN [SRV-1LD2APIX01].apix2.dbo.details dtl
            ON ord.orderid = dtl.orderid
    WHERE ord.Waveid = @WaveId;


    INSERT INTO Galaxy.dbo.Waves
    (
        SorterId,
        WaveId,
        PickPlan,
        Status,
        SortType,
        Priority,
        WaveLoadTime,
        WaveStartTime,
        WaveCloseTime,
        VendorConfigId,
        DefaultMaxCount
    )
    VALUES
    ('A', @WaveId, '', 'N', 'OF', 1, GETDATE(), GETDATE(), '1900-01-01', '', '');

    UPDATE Galaxy.dbo.Carriers
    SET VendorId = @WaveId,
        RecNum = @WaveId;

    UPDATE Galaxy.dbo.Drops
    SET WaveID = CASE
                     WHEN ExtDrop
                          BETWEEN 3 AND 150 THEN
                         ''
                     WHEN ExtDrop = 1 THEN
                         'No Read'
                     WHEN ExtDrop = 2 THEN
                         'No Need'
                     ELSE
                         ''
                 END,
        Status = CASE
                     WHEN ExtDrop IN ( 1, 2 ) THEN
                         'N'
                     ELSE
                         'U'
                 END,
        LastChangeTS = GETDATE(),
        EnRoute_Count = 0,
        EnRoute_Value = 0,
        EnRoute_Volume = 0,
        EnRoute_Weight = 0,
        Color = 'X',
        Tier = '1';


    INSERT INTO Galaxy.dbo.ProductDistribution
    SELECT 'A',
           wve.WaveId,
           ord.Barcode,
           ord.Sku,
           '',
           wve.DropLocation,
           wve.OrderId,
           ord.QtyRequired,
           ord.QtyRequired,
           0,
           'N',
           '',
           '',
           '',
           '',
           '',
           '',
           '',
           '',
           '',
           '',
           '',
           '',
           '',
           '',
           0,
           0
    FROM @Wave wve
        INNER JOIN @Orders AS ord
            ON wve.OrderId = ord.OrderId
    ORDER BY DropLocation;

    INSERT INTO Galaxy.dbo.Profile_Configuration
    SELECT DISTINCT
        wve.WaveId,
        wve.DropLocation,
        wve.OrderId,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0
    FROM @Wave wve;

    EXEC Galaxy.dbo.SetWaveDrops @Wave = @WaveId;

    UPDATE Waves
    SET status = 'A'
    WHERE Waveid = @WaveId;

    DELETE si
    FROM Galaxy.dbo.Sort_Info AS si
    WHERE si.waveid = @WaveId;

    SET @Msg = 'Finished Activating Wave number ' + @WaveId + '.';
    EXEC Galaxy.dbo.AddLogInfo @DateTime = @Now,
                               @Process = @Process,
                               @Message = @Msg;

END;

