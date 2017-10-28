USE [Galaxy];
GO
IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[FillManualPart]')
          AND type = 'P'
)
    DROP PROCEDURE dbo.FillManualPart;
GO

/****** Object:  StoredProcedure [GBI].[FillManualPart]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE PROCEDURE [dbo].FillManualPart @Barcode VARCHAR(15)
AS
/*
===============================================================================
	File: 
	Name: FillManualPart
	Desc: AENT - GBI
		Returns Log Info
	Auth: Higginbotham, Joshua
	Called by:   
             
	Date: 10/05/2017
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
        @Count TINYINT,
        @intErrorCode INT;

DECLARE @WaveID VARCHAR(8),
        @UPC VARCHAR(15),
        @SKU VARCHAR(15),
        @DropLocation INT,
        @OrderID VARCHAR(20),
        @QtyRequired INT,
        @QtyRemaining INT,
        @ConfirmedDrops INT,
        @Status CHAR(1),
        @CartonID VARCHAR(30);


-- initialise
SET @return_status = 0;
SET @Process = 'Proc = FillManualPart';
SET @Now = GETDATE();

/*
===============================================================================

===============================================================================
*/
BEGIN TRAN;

SELECT TOP 1
    @WaveID = [WaveID],
    @UPC = [UPC],
    @SKU = [SKU],
    @DropLocation = [DropLocation],
    @OrderID = [OrderID],
    @QtyRequired = [QtyRequired],
    @QtyRemaining = [QtyRemaining],
    @ConfirmedDrops = [ConfirmedDrops],
    @Status = [Status],
    @CartonID = [CartonID]
FROM [Galaxy].[dbo].[ProductDistribution]
WHERE QtyRemaining <> 0
      AND UPC = @Barcode
ORDER BY DropLocation;

UPDATE galaxy.dbo.productDistribution
SET QtyRemaining = @QtyRemaining - 1
WHERE upc = @UPC
      AND droplocation = @DropLocation;

SELECT @intErrorCode = @@ERROR;
IF (@intErrorCode <> 0)
    GOTO PROBLEM;

COMMIT TRAN;

PROBLEM:
IF (@intErrorCode <> 0)
BEGIN
    PRINT 'Unexpected error occurred!';
    ROLLBACK TRAN;
END;

SELECT @WaveID AS WaveId,
       @UPC AS UPC,
       @SKU AS SKU,
       @DropLocation AS DropLocation,
       @OrderID AS OrderID,
       @QtyRequired AS QtyRequired,
       @QtyRemaining AS QtyRemaining,
       @ConfirmedDrops AS ConfirmedDrops,
       @Status AS [Status],
       @CartonID AS CartonId;

	







