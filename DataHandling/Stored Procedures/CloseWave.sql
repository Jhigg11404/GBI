USE [Apix2]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[CloseWave]') AND OBJECTPROPERTY(id, N'IsProdedure') = 1) 
DROP Procedure dbo.CloseWave
GO

/****** Object:  StoredProcedure [GBI].[PendingWaveLookup]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[CloseWave]

as
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

    Set @Msg = 'Closing Wave On GBI, Wave Number: ' + @WaveNmbr
	Exec Galaxy.dbo.AddLogInfo @DateTime = @Now, @Process = @Process, @Message = @Msg

	Update Waves Set status = 'F' where Waveid = @Waveid

	

    Set @Msg = @WaveNmbr + ' has been closed' 
	Exec Galaxy.dbo.AddLogInfo @DateTime = @Now, @Process = @Process, @Message = @Msg

end 

