USE [Galaxy];
GO
IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[CloseOrder]')
          AND type = 'P'
)
    DROP PROCEDURE dbo.CloseOrder;
GO

/****** Object:  StoredProcedure [GBI].[CloseOrder]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE PROCEDURE [dbo].[CloseOrder]
@OrderId VARCHAR(25)
AS
/*
===============================================================================
	File: 
	Name: CloseWave
	Desc: AENT - GBI
		Closes an active wave on the sorter
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
SET @Process = 'Proc = GetLogInfo';
SET @Now = GETDATE();

/*
===============================================================================

===============================================================================
*/
BEGIN

	UPDATE Galaxy.dbo.Sort_Info
	SET OrderClosed = 1
	WHERE OrderId = @Orderid
	
	IF @@ROWCOUNT <> 0
	BEGIN
		SET @return_status = 1
	END

	SELECT @return_status AS 'Status'

END;

