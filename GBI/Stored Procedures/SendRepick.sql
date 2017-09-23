USE [Galaxy]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[SendRepick]') AND Type = 'P') 
DROP Procedure dbo.SendRepick
GO

/****** Object:  StoredProcedure [GBI].[PendingWaveLookup]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SendRepick]

as
/*
===============================================================================
	File: 
	Name: SendRepick
	Desc: AENT - GBI
		Build repick dataset for the GBI sorter
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

	Select 
			pd.Orderid,
			pd.UPC,
			pd.QtyRemaining
	from Galaxy.dbo.ProductDistribution pd

end 


