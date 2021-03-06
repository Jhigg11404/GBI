﻿USE [Galaxy]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[TestSocketMessageLookup]') AND type = 'P') 
DROP Procedure dbo.TestSocketMessageLookup
GO

/****** Object:  StoredProcedure [dbo].[TestSocketMessageLookup]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[TestSocketMessageLookup]
@Method varchar(15),
@Status Tinyint
as
/*
===============================================================================
	File: 
	Name: TestSocketMessageLookup
	Desc: AENT - GBI
		Verifies badge number
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
set nocount on 

declare
    @error_severity			int
    ,@error_state			int
    ,@error_number			int
    ,@error_line			int
    ,@error_message			varchar(245)
	,@rowcount				int
	,@result				int
	,@return_status			smallint
	-- other work variables
	
	
--Log Info
DECLARE @DateTime DATETIME,
        @Now DATETIME,
        @Process VARCHAR(50),
        @Message VARCHAR(250),
        @Msg VARCHAR(250),
        @Count TINYINT


-- initialise
SET @return_status = 0;
SET @Process = 'Proc = TestSocketMessageLookup';
SET @Now = GETDATE();

/*
===============================================================================

===============================================================================
*/

Begin

	Select 
		TranId,
		SocketMessage
	from Galaxy.dbo.Test_SocketQueue
	where Socket = @Method
	and SocketStatus = @Status

End

 


