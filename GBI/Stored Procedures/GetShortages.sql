USE [Galaxy];
GO
IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[GetShortages]')
          AND type = 'P'
)
    DROP PROCEDURE dbo.GetShortages;
GO

/****** Object:  StoredProcedure [dbo].[GetShortages]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE PROCEDURE [dbo].[GetShortages]
AS
/*
===============================================================================
	File: 
	Name: GetShortages
	Desc: AENT - GBI
		Returns shortages for waves for the GBI sorter
	Auth: Higginbotham, Joshua
	Called by:   
             
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

--Log Info
DECLARE @DateTime DATETIME,
        @Now DATETIME,
        @Process VARCHAR(50),
        @Message VARCHAR(250),
        @Msg VARCHAR(250),
        @Count TINYINT;


-- initialise
SET @return_status = 0;
SET @Process = 'Proc = GetShortages';
SET @Now = GETDATE();

/*
===============================================================================

===============================================================================
*/
BEGIN

    SET @Msg = 'Getting shortage Info from the Database';
    EXEC Galaxy.dbo.AddLogInfo @DateTime = @Now,
                               @Process = @Process,
                               @Message = @Msg;

    SELECT [WaveID],
           [UPC],
           [sku],
           [DropLocation],
           [OrderID],
           [QtyRequired],
           [ConfirmedDrops],
           [QtyRemaining]
    FROM [Galaxy].[dbo].[ProductDistribution]
	Where QtyRemaining > 0
    ORDER BY DropLocation;

END;

