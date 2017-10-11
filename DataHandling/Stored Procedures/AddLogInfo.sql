USE [Galaxy]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[AddLogInfo]') AND OBJECTPROPERTY(id, N'IsProdedure') = 1) 
DROP Procedure GBI.AddLogInfo
GO

/****** Object:  StoredProcedure [dbo].[AddLogInfo]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddLogInfo]
@Datetime datetime,
@Process varchar(50),
@Message varchar(250)
as
/*
===============================================================================
	File: 
	Name: AddLogInfo
	Desc: AENT - GBI
		Insert Log info for troubleshooting and reporting
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
	
	

-- initialise
set @return_status = 0

/*
===============================================================================

===============================================================================
*/
begin

	Insert into Galaxy.dbo.[Log]
	(
	 Log_Time,
	 Process,
	 [Message]
	)
	Values
	(@DateTime,
	 @Process,
	 @Message
	)

end 


