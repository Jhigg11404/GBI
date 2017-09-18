USE [Galaxy]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[GetLogInfo]') AND xtype = 'P') 
DROP Procedure dbo.GetLogInfo
GO

/****** Object:  StoredProcedure [GBI].[GetLogInfo]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].GetLogInfo

as
/*
===============================================================================
	File: 
	Name: GetLogInfo
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
set @Process = 'Proc = GetLogInfo'
set @Now = Getdate()

/*
===============================================================================

===============================================================================
*/
begin
    Set @Msg = 'Checking Logs On GBI'
	Exec Galaxy.dbo.AddLogInfo @DateTime = @Now, @Process = @Process, @Message = @Msg

	Select
	   [LOG_ID]
      ,[LOG_TIME]
      ,[Process]
      ,[MESSAGE]
	FROM [Galaxy].[dbo].[LOG]
	Order by
		Log_ID Desc

	Select @Count = @@RowCount 
    
	Set @Msg = Cast(@Count as varchar(3)) + ' Records returned for the Log Table' 
	Exec Galaxy.dbo.AddLogInfo @DateTime = @Now, @Process = @Process, @Message = @Msg

end 







