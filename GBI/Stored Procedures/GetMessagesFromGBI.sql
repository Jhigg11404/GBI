USE [Galaxy];
GO
IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[GetMessagesFromGBI]')
          AND xtype = 'P'
)
    DROP PROCEDURE dbo.GetMessagesFromGBI;
GO

/****** Object:  StoredProcedure [GBI].[GetMessagesFromGBI]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE PROCEDURE [dbo].GetMessagesFromGBI
AS
/*
===============================================================================
	File: 
	Name: GetMessagesFromGBI
	Desc: AENT - GBI
		Returns records from the Messages table on the Galaxy database
	Auth: Higginbotham, Joshua
	Called by:   
             
	Date: 09/18/2017
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
SET @Process = 'Proc = GetMessagesFromGBI';
SET @Now = GETDATE();

/*
===============================================================================

===============================================================================
*/
BEGIN

    SET @Msg = 'Getting Message Info from the Database';
    EXEC Galaxy.dbo.AddLogInfo @DateTime = @Now,
                               @Process = @Process,
                               @Message = @Msg;

    SELECT TOP 1000
        [MsgID],
        [MsgTimestamp],
        [MsgSeverity],
        [MsgText],
        [MsgSource]
    FROM [Galaxy].[dbo].[Messages]
	WHERE CONVERT(VARCHAR(15),MsgTimeStamp,110) = CONVERT(VARCHAR(15),GETDATE(),110)
    ORDER BY MsgId DESC;

END;


