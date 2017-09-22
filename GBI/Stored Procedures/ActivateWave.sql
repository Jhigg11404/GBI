USE [Galaxy]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[ActivateWave]') AND xtype = 'P') 
DROP Procedure dbo.ActivateWave
GO

/****** Object:  StoredProcedure [dbo].[ActivateWave]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure dbo.[ActivateWave]
@WaveId varchar(8)
as
/*
===============================================================================
	File: 
	Name: ActivateWave
	Desc: AENT - GBI
		Activates Wave on GBI Sorter
	Auth: Higginbotham, Joshua
	Called by:   

	--exec dbo.ActivateWave '01413632'
             
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

		Declare @WaveTable table
		(
			WaveId varchar(8),
			OrderId varchar(10),
			Barcode varchar(15),
			DropLocation smallint,
			QtyRequired smallint
		)

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
set @Process = 'Proc = ActivateWave'
set @Now = Getdate()

/*
===============================================================================

===============================================================================
*/
begin
	
	Set @Msg = 'Activating Wave number ' + @Waveid + '.'
	Exec Galaxy.dbo.AddLogInfo @DateTime = @Now, @Process = @Process, @Message = @Msg


	TRUNCATE TABLE Galaxy.dbo.ProductDistribution
	TRUNCATE TABLE Galaxy.dbo.Waves
	TRUNCATE TABLE Galaxy.dbo.Profile_Configuration
	
		Insert into @WaveTable
		(
			WaveId,
			OrderId,
			Barcode,
			DropLocation,
			QtyRequired
		)
		Select 
			ord.waveid,
			ord.orderid,
			dtl.verifybcr,
			ord.ActiveDest + 4,
			dtl.QtyRequired
		from 
			[SRV-1LD2APIX01].Apix2.dbo.orders ord
		inner join 
			[SRV-1LD2APIX01].apix2.dbo.details dtl
		on 
			ord.orderid = dtl.orderid
		Where 
			ord.Waveid = @WaveID


Insert into Galaxy.dbo.Waves
	(
		SorterId,
		WaveId,
		PickPlan,
		Status,
		SortType,
		Priority,
		WaveLoadTime,
		WaveStartTime,
		WaveCloseTime,
		VendorConfigId,
		DefaultMaxCount
	)
Values
	(
		'A',
		@Waveid,
		'',
		'N',
		'OF',
		1,
		Getdate(),
		Getdate(),
		'1900-01-01',
		'',
		''
	)

Update Galaxy.dbo.Carriers
Set VendorId = @Waveid,
	RecNum = @Waveid

Update Galaxy.dbo.Drops
SET WaveID = CASE
                 WHEN ExtDrop
                      BETWEEN 3 AND 150 THEN
                     ''
                 WHEN ExtDrop = 1 THEN
                     'No Read'
                 WHEN ExtDrop = 2 THEN
                     'No Need'
                 ELSE
                     ''
             END,
    Status = CASE
                 WHEN ExtDrop IN ( 1, 2 ) THEN
                     'N'
                 ELSE
                     'U'
             END,
    LastChangeTS = GETDATE(),
    EnRoute_Count = 0,
    EnRoute_Value = 0,
    EnRoute_Volume = 0,
    EnRoute_Weight = 0,
    Color = 'X',
    Tier = '1'


Insert into Galaxy.dbo.ProductDistribution
Select
	'A',
	wve.WaveId,
	wve.Barcode,
	wve.Barcode,
	'',
	wve.DropLocation,
	wve.Orderid,
	wve.QtyRequired,
	wve.QtyRequired,
	0,
	'N',
	'',
	'',
	'',
	'',
	'',
	'',
	'',
	'',
	'',
	'',
	'',
	'',
	'',
	'',
	0,
	0
From
	@WaveTable wve
Order by DropLocation

Insert into Galaxy.dbo.Profile_Configuration
Select Distinct
	wve.Waveid,
	wve.DropLocation,
	wve.OrderId,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0
From
	@WaveTable wve

exec Galaxy.dbo.SetWaveDrops @Wave = @Waveid

Update Waves Set status = 'A' where Waveid = @Waveid

	Set @Msg = 'Finished Activating Wave number ' + @Waveid + '.'
	Exec Galaxy.dbo.AddLogInfo @DateTime = @Now, @Process = @Process, @Message = @Msg

End

