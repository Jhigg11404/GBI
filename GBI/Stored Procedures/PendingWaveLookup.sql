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
set @Process = 'Proc = PendingWaveLookup'
set @Now = Getdate()

/*
===============================================================================

===============================================================================
*/
begin
    Set @Msg = 'Checking Pending Waves for GBI'
	Exec Galaxy.dbo.AddLogInfo @DateTime = @Now, @Process = @Process, @Message = @Msg

	Select
		sw.Waveid,
		sw.TotalOrders,
		sw.TotalParts,
		sw.DateTimeSorted
	from 
		[SRV-1LD2APIX01].apix2.dbo.subwaves sw
	where
		sw.[status] = 2
	and 
		sw.sorter = 10
	ORDER BY 
		sw.DateTimeSorted

	Select @Count = @@RowCount
    
	Set @Msg = Cast(@Count as varchar(3)) + ' Pending Waves are assigned to the GBI Sorter' 
	Exec Galaxy.dbo.AddLogInfo @DateTime = @Now, @Process = @Process, @Message = @Msg

end 




