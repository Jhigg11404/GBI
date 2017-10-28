USE [Galaxy]
GO
IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[GetOrdersToClose]')
          AND type = 'P'
)
    DROP PROCEDURE dbo.GetOrdersToClose;
GO
/****** Object:  StoredProcedure [dbo].[GetOrdersToClose]    Script Date: 10/18/2017 8:35:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetOrdersToClose]

as
/*
===============================================================================
	File: 
	Name: GetOrdersToClose
	Desc: AENT - GBI
		Returns orders to close
	Auth: Higginbotham, Joshua
	Called by:   
             
	Date: 10/19/2017
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
set @Process = 'Proc = GetOrdersToClose'
set @Now = Getdate()

/*
===============================================================================

===============================================================================
*/
begin
  
	SELECT DISTINCT
		OrderId,CartonId
	FROM [Galaxy].[dbo].[Sort_Info]
	WHERE OrderClosed = 0

end 







