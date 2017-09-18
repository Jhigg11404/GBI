USE Galaxy
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[SQLServerConnection_GET]') AND xtype = 'P') 
DROP Procedure dbo.SQLServerConnection_GET
GO

/****** Object:  StoredProcedure [dbo].[SQLServerConnection_GET]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SQLServerConnection_GET]
@Appname Varchar(25),
@Mode varchar(4)
as
/*
===============================================================================
	File: 
	Name: SQLServerConnection_GET
	Desc: AENT - GBI
		Returns Connection string for Program
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
		ConnectionString
	from 
		Galaxy.dbo.Control_SQLServers 
	where 
		AppName = @AppName and Mode = @Mode
		
end



