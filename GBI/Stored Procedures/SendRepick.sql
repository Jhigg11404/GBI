USE [Apix2]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[GBI].[PendingWaveLookup]') AND OBJECTPROPERTY(id, N'IsProdedure') = 1) 
DROP Procedure GBI.PendingWaveLookup
GO

/****** Object:  StoredProcedure [GBI].[PendingWaveLookup]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [GBI].[PendingWaveLookup]

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
	
	

-- initialise
set @return_status = 0

/*
===============================================================================

===============================================================================
*/
begin try

end try 


begin catch
        select
		@error_severity = error_severity()
		,@error_state = error_state()
		,@error_number = error_number()
		,@error_line = error_line()
		,@error_message = error_message()
	        
	raiserror('%s: msg %d, line %d'
		,@error_severity
		,@error_state
		,@error_message
		,@error_number
		,@error_line)
			
	goto ErrorHandler

end catch		
/*
===============================================================================
    WRAP UP
===============================================================================
*/
WrapUp:
return

ErrorHandler:
-- prep return

return

