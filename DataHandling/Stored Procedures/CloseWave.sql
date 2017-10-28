USE Galaxy
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[CloseWave]') AND type = 'P')
DROP Procedure dbo.CloseWave
GO

/****** Object:  StoredProcedure [GBI].[CloseWave]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[CloseWave]
@WaveID VARCHAR(8)
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
set @Process = 'Proc = CloseWave'
set @Now = Getdate()

/*
===============================================================================

===============================================================================
*/
begin 

   SET @Msg = 'Closing Wave On GBI, Wave Number: ' + @WaveID;
    EXEC Galaxy.dbo.AddLogInfo @DateTime = @Now,
                               @Process = @Process,
                               @Message = @Msg;

    INSERT INTO galaxy.dbo.Sort_info
    (
        [WaveID],
        [UPC],
        [SKU],
        [DropLocation],
        [OrderID],
        [QtyRequired],
        [QtyRemaining],
        [ConfirmedDrops],
        [Status],
        [CartonID],
        [OrderClosed]
    )
    SELECT pd.Waveid,
           pd.Upc,
           pd.sku,
           pd.droplocation,
           pd.orderid,
           pd.qtyrequired,
           pd.qtyremaining,
           pd.confirmedDrops,
           pd.status,
           pd.CartonId,
           0
    FROM Galaxy.dbo.ProductDistribution pd
    WHERE pd.[Status] <> 'F';

	UPDATE Galaxy.dbo.ProductDistribution
	SET Status = 'F'
	WHERE Status <> 'F'

    EXEC Galaxy.dbo.SetWaveDropStatus @WaveID, 'F';

    UPDATE Waves
    SET status = 'F'
    WHERE Waveid = @Waveid;

	DELETE pd 
	FROM Galaxy.dbo.ProductDistribution AS pd
	WHERE pd.WaveID = @WaveID

	SET @return_status = 1

	SELECT @return_status AS 'Status'

    SET @Msg = @WaveID + ' has been closed';
    EXEC Galaxy.dbo.AddLogInfo @DateTime = @Now,
                               @Process = @Process,
                               @Message = @Msg;
end 

