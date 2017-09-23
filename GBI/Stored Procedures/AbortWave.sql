USE [Galaxy]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[AbortWave]') AND type = 'P') 
DROP Procedure dbo.AbortWave
GO

/****** Object:  StoredProcedure [dbo].[AbortWave]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AbortWave]
@WaveID varchar(8),
@AbortType varchar(10),
@BadgeNbr varchar(10)
as
/*
===============================================================================
	File: 
	Name: AbortWave
	Desc: AENT - GBI
		Aborts a wave on the GBI sorter
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
        @Count TINYINT;


-- initialise
SET @return_status = 0;
SET @Process = 'Proc = AbortWave';
SET @Now = GETDATE();

/*
===============================================================================

===============================================================================
*/
If @AbortType = 'Reset'

Begin

    SET @Msg = 'Resetting wave ' + @WaveId;
    EXEC Galaxy.dbo.AddLogInfo @DateTime = @Now,
                               @Process = @Process,
                               @Message = @Msg;

	Update Galaxy.dbo.ProductDistribution
    set ConfirmedDrops  = 0
    ,QtyRemaining = QtyRequired
    Where Waveid = @WaveId

End

Else

    SET @Msg = 'Aborting wave ' + @WaveId;
    EXEC Galaxy.dbo.AddLogInfo @DateTime = @Now,
                               @Process = @Process,
                               @Message = @Msg;

	Begin

	TRUNCATE TABLE Galaxy.dbo.ProductDistribution
	TRUNCATE TABLE Galaxy.dbo.Waves
	TRUNCATE TABLE Galaxy.dbo.Profile_Configuration

	End
 


