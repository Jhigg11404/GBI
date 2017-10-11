USE [Galaxy]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[VerifyBadge]') AND type = 'P') 
DROP Procedure dbo.VerifyBadge
GO

/****** Object:  StoredProcedure [dbo].[VerifyBadge]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[VerifyBadge]
@BadgeId varchar(10)
as
/*
===============================================================================
	File: 
	Name: VerifyBadge
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
        @Count TINYINT,
        @Status varchar(15);


-- initialise
SET @return_status = 0;
SET @Process = 'Proc = VerifyBadge';
SET @Now = GETDATE();
SET @Status = '';

/*
===============================================================================

===============================================================================
*/

Begin

    SET @Msg = 'Verifing Badge number ' + @BadgeId;
	Exec Galaxy.dbo.AddLogInfo @DateTime = @Now, @Process = @Process, @Message = @Msg

	If exists 
		(Select BadgeId from Galaxy.dbo.ProcessAdmins where BadgeId = @BadgeId)
			Begin
				Select @Status = 'Approved'
			End

	Else
		Begin
				Select @Status = 'Denied' 
		End

	SET @Msg = 'Badge number ' + @BadgeId + ' is ' + @Status;
	Exec Galaxy.dbo.AddLogInfo @DateTime = @Now, @Process = @Process, @Message = @Msg

	Select @Status as 'Status'

End

 


