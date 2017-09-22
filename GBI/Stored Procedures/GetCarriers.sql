USE [Galaxy];
GO
IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[GetCarriers]')
          AND xtype = 'P'
)
    DROP PROCEDURE dbo.GetCarriers;
GO

/****** Object:  StoredProcedure [GBI].[GetCarriers]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE PROCEDURE [dbo].GetCarriers
AS
/*
===============================================================================
	File: 
	Name: GetCarriers
	Desc: AENT - GBI
		Returns Log Info
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

--Log Info
DECLARE @DateTime DATETIME,
        @Now DATETIME,
        @Process VARCHAR(50),
        @Message VARCHAR(250),
        @Msg VARCHAR(250),
        @Count TINYINT;


-- initialise
SET @return_status = 0;
SET @Process = 'Proc = GetCarriers';
SET @Now = GETDATE();

/*
===============================================================================

===============================================================================
*/
BEGIN
    SET @Msg = 'Checking Carriers On GBI';
    EXEC Galaxy.dbo.AddLogInfo @DateTime = @Now,
                               @Process = @Process,
                               @Message = @Msg;

    SELECT [SorterID],
           [Carrier],
           [IntDrop],
           [ExtDrop],
           [Status],
           [StatusReason],
           [WaveID],
           [OrderID],
           [SKU],
           [UPC],
           [OriginalUPC],
           [ScanTS],
           [SendTS],
           [ConfirmTS]
    FROM [Galaxy].[dbo].[Carriers];

END;







