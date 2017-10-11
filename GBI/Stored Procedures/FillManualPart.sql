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
CREATE PROCEDURE [dbo].FillManualPart
@Barcode varchar(15)
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
        @Count TINYINT;


-- initialise
SET @return_status = 0;
SET @Process = 'Proc = FillManualPart';
SET @Now = GETDATE();

/*
===============================================================================

===============================================================================
*/
BEGIN

SELECT Top 1
       [WaveID]
      ,[UPC]
      ,[SKU]
      ,[DropLocation]
      ,[OrderID]
      ,[QtyRequired]
      ,[QtyRemaining]
      ,[ConfirmedDrops]
      ,[Status]
      ,[CartonID]
  FROM [Galaxy].[dbo].[ProductDistribution]
  Where QtyRemaining <> 0
  and UPC = @Barcode
  Order by DropLocation

END;







