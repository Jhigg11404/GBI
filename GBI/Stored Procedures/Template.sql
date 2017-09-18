USE [Galaxy]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[PendingWaveLookup]') AND xtype = 'P') 
DROP Procedure dbo.PendingWaveLookup
GO

/****** Object:  StoredProcedure [GBI].[PendingWaveLookup]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[PendingWaveLookup]

as
/*
===============================================================================
	File: 
	Name: PendingWaveLookup
	Desc: AENT - GBI
		Returns pending waves for the GBI sorter
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





    Set @Msg = Cast(@Count as varchar(3)) + ' Records returned for the Log Table' 
	Exec Galaxy.dbo.AddLogInfo @DateTime = @Now, @Process = @Process, @Message = @Msg

end 


