USE [Galaxy];
GO
IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[GetDrops]')
          AND type = 'P'
)
    DROP PROCEDURE dbo.GetDrops;
GO

/****** Object:  StoredProcedure [dbo].[GetDrops]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE PROCEDURE [dbo].[GetDrops]
AS
/*
===============================================================================
	File: 
	Name: GetDrops
	Desc: AENT - GBI
		Returns drops for the GBI sorter
	Auth: Higginbotham, Joshua
	Called by:   
             
	Date: 09/21/2017
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
	Declare 
	 @DateTime DateTime
	,@Now DateTime
	,@Process Varchar(50)
	,@Message Varchar(250)
	,@Msg Varchar(250)
	,@Count tinyint
	

-- initialise
set @return_status = 0
set @Process = 'Proc = GetDrops'
set @Now = Getdate()

/*
===============================================================================

===============================================================================
*/
BEGIN

    /****** Script for SelectTopNRows command from SSMS  ******/
    SELECT OrderID,
           CartonID,
           DropLocation,
           SUM(QtyRequired) AS QtyRequired,
           SUM(ConfirmedDrops) AS ConfrimedDrops,
           SUM(QtyRemaining) AS QtyRemaining,
           [Status]
    FROM [Galaxy].[dbo].[ProductDistribution]
	WHERE status <> 'F'
    GROUP BY OrderID,
             CartonID,
             DropLocation,
             [Status]
    ORDER BY DropLocation;

END;

