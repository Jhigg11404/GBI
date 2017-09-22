USE [Galaxy];
GO
IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[GetActiveWave]')
          AND xtype = 'P'
)
    DROP PROCEDURE dbo.GetActiveWave;
GO

/****** Object:  StoredProcedure [GBI].[GetActiveWave]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE PROCEDURE [dbo].GetActiveWave @Waveid VARCHAR(8)
AS
/*
===============================================================================
	File: 
	Name: GetActiveWave
	Desc: AENT - GBI
		Returns active wave info
	Auth: Higginbotham, Joshua
	Called by:   

	exec GetActiveWave ''
             
	Date: 09/19/2017
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

--Log Info
DECLARE @DateTime DATETIME,
        @Now DATETIME,
        @Process VARCHAR(50),
        @Message VARCHAR(250),
        @Msg VARCHAR(250),
        @Count TINYINT;


-- initialise
SET @return_status = 0;
SET @Process = 'Proc = GetActiveWave';
SET @Now = GETDATE();

/*
===============================================================================

===============================================================================
*/
BEGIN
    SET @Msg = 'Checking Wave On GBI';
    EXEC Galaxy.dbo.AddLogInfo @DateTime = @Now,
                               @Process = @Process,
                               @Message = @Msg;

	IF EXISTS
		(SELECT Waveid FROM galaxy.dbo.waves WHERE status = 'A')
	Begin

	SELECT 
		Waveid,
		COUNT(DISTINCT(orderid)) AS Orderid,
		COUNT(DISTINCT(dropLocation)) AS DropLocation,
		SUM(QtyRequired) AS QtyRequired,
		SUM(ConfirmedDrops) AS ConfirmedDrops
	FROM Galaxy.dbo.ProductDistribution
	GROUP BY Waveid

    SELECT TOP 1000
        [WaveID],
        [UPC],
        [SKU],
        [DropLocation],
        [OrderID],
        [QtyRequired],
        [QtyRemaining],
        [ConfirmedDrops],
        [Status],
        [CartonID]
    FROM [Galaxy].[dbo].[ProductDistribution];

END;

End







