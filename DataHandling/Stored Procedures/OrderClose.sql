USE [GRS]
GO
/****** Object:  StoredProcedure [dbo].[OrderClose_BuildShipInfoPackets]    Script Date: 10/10/2017 4:26:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[OrderClose_BuildShipInfoPackets]
/*******************************************************************************************
	Name:		OrderClose_BuildSortInfoPackets
	
	Desc:		For all completed PickTickets, creates Dhcart info packets for transmission to PKMS.

	Auth:		jah
	
	Called by:  
             
	Date: 10/10/2017

===============================================================================
	Change History
===============================================================================
	Date:		Author:		Description:
	--------	--------	---------------------------------------------------


===============================================================================
	Tables and Notes
===============================================================================
CREATE TABLE Galaxy.dbo.SendToPKMS_Packets(
	PacketID bigint IDENTITY(1, 1) NOT NULL,
	PacketHeader varchar(2) not null,
	PickTckt char(10) NOT NULL,
	WaveNmbr char(10) NOT NULL,
	PacketStatusCode tinyint NOT NULL,  --0 = new (unsent), 10=resend, 20=failed, 30=OK, done
	LastResponse varchar(max) NOT NULL,
	LastDateSent datetime2(2) NOT NULL,
	PacketStr varchar(max) NOT NULL,
	InsertDate datetime2(2) NOT NULL,
	CONSTRAINT PK_SendToPM_Packets PRIMARY KEY CLUSTERED (Picktckt, PacketHeader)
)

******************************************************************************************/

AS

SET NOCOUNT ON

--==============================================================================================
--DECLARE/INIT LOCAL VARS
--==============================================================================================
declare @PickTckt char(20), @PickTcktStatusCode char(1), @PickTicketsMax int, @x int = 1
create table #PickTickets (PickTckt char(20), PickTcktStatusCode char(1), RowID int IDENTITY(1,1))

declare @PacketID bigint, @ShipInfoMax int, @ShipInfo_ItemMax int, @i int = 1, @j int = 1
create table #CartonHeader (
	RowID int IDENTITY(1,1),
	PickTckt char(20),
	BoxID char(20),
	BoxType char(20),
	WorkStation char(3),
	Filler1 char(6),
	Filler2 char(8),
	NumOfBoxes tinyint,
	LastBox bit,
	NbrOfDtls tinyint
)

create table #CartonDetail (
	RowID tinyint IDENTITY(1,1),
	Sku char(20),
	QtyPacked tinyint
)

create table #OrderComplete (
    RowID int IDENTITY(1,1),
	Filler1 char(1),
	Picktckt char(20),
	PicktcktStat tinyint,
	Workstation char(3),
	Filler2 char(6),
	Filler3 char(8),
	NbrOfBoxes tinyint
)

declare @PacketStr varchar(max) = ''
declare @PacketIDStr char(10)

declare
	@Picktckt char(20),
	@BoxId Char(20),
	@BoxType char(20),
	@WorkStation char(3),
	@NumOfBoxes tinyint,
	@LastBox bit,
	@NbrOfDtls tinyint,
	@Sku char(20),
	@QtyPacked tinyint,
	@PicktcktStat tinyint,
	@NbrOfBoxes tinyint

--==============================================================================================
--BEGIN PROCESSING
--==============================================================================================
BEGIN TRY
--==============================================================================================
--
--==============================================================================================
	
	--Get all completed PickTickets
	insert #PickTickets select OrderID, Status from Galaxy.dbo.Sort_info where Status = 'C' -- Complete
	select @PickTicketsMax = max(RowID) from #PickTickets
	if isNull(@PickTicketsMax,0) = 0 begin
		goto xIT
	end

	set @x = 1
	--PickTicket loop
	while @x <= @PickTicketsMax begin
		
		select @PickTckt = PickTckt, @PickTcktStatusCode = PickTcktStatusCode from #PickTickets where RowID = @x

		if @PickTcktStatusCode = 'C' begin

		truncate table #CartonHeader
		--Get ShipInfo data for all orders in PickTckt. If none found, error.
		Select @NbrOfDtls = Count(Sku) from galaxy.dbo.ProductDistribution where orderid = @Picktckt
		insert #CartonHeader(
			PickTckt ,
			BoxID ,
			BoxType ,
			WorkStation ,
			Filler1 ,
			Filler2 ,
			NumOfBoxes ,
			LastBox ,
			NbrOfDtls )
		select 
			OrderId, CartonID, 'TOT', 'GBI', 
			'      ',--6
			'        ',--8
			1, 
			1, 
			@NbrOfDtls
		from Galaxy.dbo.Sort_info 
		where OrderId = @PickTckt 
		select @ShipInfoMax = max(RowID) from #ShipInfo
		if isNull(@ShipInfoMax,0) = 0 begin
			set @e = 'No ShipInfo record for PickTckt ' + @PickTckt
			;THROW 99999, @e, 0  
		end

		--for each ShipInfo record, make sure there is at least one ShipInfo_Item record
		while @i <= @ShipInfoMax begin
			select @Picktckt = Picktckt from #OrderHeader where RowID = @i
			Select @ShipInfo_ItemMax = count(*) from GRS..ShipInfo_Item where ShipNmbr = @ShipNmbr
			if isNull(@ShipInfo_ItemMax,0) = 0 begin
				set @e = 'No ShipInfo_Item record for ShipNmbr ' + @ShipNmbr
				;THROW 99999, @e, 0  
			end
			set @i = @i + 1
		end

		--Insert Packet record stub (establishes PacketID)
		insert ShipInfo_Packets(PickTckt,WaveNmbr,Warehouse,PacketStatusCode, LastResponse, LastDateSent, PacketStr)
		select @PickTckt,'','',0,'','1900-01-01','' --PacketStatusCode = 0 (UNPREPPED)
		select @PacketID = Scope_identity()	

		--==============================================================================================
		-- BUILD PACKET STRING
		--==============================================================================================
		--Padded PacketID string
		set @PacketIDStr = RIGHT('0000000000' + rtrim(@PacketID),10)

		--Packet header
		set @PacketStr = CHAR(2) + @PacketIDStr + CHAR(9) + 'H' + CHAR(9) + '' + CHAR(30)

		set @i = 1

		--ShipInfo loop
		while @i <= @ShipInfoMax begin

			Select
				@WaveNmbr = WaveNmbr,
				@OrdNmbr = OrdNmbr,
				@ShipNmbr = ShipNmbr,
				@ShipMethodCode = ShipMethodCode,
				@FreightAmt = FreightAmt,
				@FreightCostAmt = FreightCostAmt,
				@TrkgNmbr = TrkgNmbr,
				@ActualWeightLb = cast(ActualWeightOz / 16 as decimal(10,4)),
				@RatedWeightLb = cast(RatedWeightOz / 16 as decimal(10,4)),
				@SigReq = case when IsSignatureReq = 1 then 'Y' else 'N' end,
				@SatDel = case when IsSaturdayDelivery = 1 then 'Y' else 'N' end
			from #ShipInfo
			where RowID = @i

			--Carton header (ShipInfo level)
			set @PacketStr = @PacketStr +
							'C' + CHAR(9) + 
							rtrim(@WaveNmbr) + CHAR(9) + 
							rtrim(@OrdNmbr) + CHAR(9) +
							rtrim(@ShipNmbr) + CHAR(9) +		--Pass ShpNmbr in CartonNmbr field
							rtrim(@ShipMethodCode) + CHAR(9) + 
							'' + CHAR(9) +
							rtrim(@FreightAmt) + CHAR(9) +
							rtrim(@FreightCostAmt) + CHAR(9) +
							rtrim(@TrkgNmbr) + CHAR(9) + 
							rtrim(@ActualWeightLb) + CHAR(9) +
							rtrim(@RatedWeightLb) + CHAR(9) + 
							CHAR(9) + 
							CHAR(9) +
							@SigReq + CHAR(9) + 
							@SatDel + CHAR(30)

			--Get ShipInfo_Item for @ShipNmbr
			truncate table #ShipInfo_Item
			insert #ShipInfo_Item (WMSID, ItemBarcode, QtyPacked)
			select WMSID, ItemBarcode, QtyPacked
			from GRS..ShipInfo_Item where ShipNmbr = @ShipNmbr order by LinSeqNo
			select @ShipInfo_ItemMax = max(RowID) from #ShipInfo_Item
		
			set @j = 1

			--ShipInfo_Item loop
			while @j <= @ShipInfo_ItemMax begin

				select 
					@WMSID = WMSID,
					@ItemBarcode = ItemBarcode,
					@QtyPacked = QtyPacked
				from
					#ShipInfo_Item
				where RowID = @j

				--Carton Detail (ShipInfo_Item level)
				set @PacketStr = @PacketStr + 
								'D' + CHAR(9) + 
								rtrim(@WMSID) + CHAR(9) +
								rtrim(@ItemBarcode) + CHAR(9) +
								rtrim(@QtyPacked) + CHAR(30)

				set @j = @j + 1

			end -- ShipInfo_Item loop

			set @i = @i + 1

		end -- ShipInfo loop

		-- Packet footer
		Set @PacketStr = @PacketStr + 'T' + CHAR(9) + rtrim(@ShipInfoMax) + CHAR(3)


		--Update Packet record with Packet String, Status, Warehouse, and WaveNmbr)
		update grs..ShipInfo_Packets
		set WaveNmbr = @WaveNmbr,
			Warehouse = case LEFT(@PickTckt, 3) when '120' then 'BAR' when '020' then 'CS2' else 'LD2' end,
			PacketStatusCode = 10, --(READY)
			PacketStr = @PacketStr
		where PacketID = @PacketID

		--Update PickTicket and Order status = 70 -- CLOSED
		update GRS..PickTickets 
		set PickTcktStatusCode = 70
		where PickTckt = @PickTckt

		update OrderHeader
		set OrderStatusCode = 70 --CLOSED
		where PickTckt = @PickTckt

		set @x = @x + 1
	end --PickTicket loop

----	RETURN PACKET RECORD
--	select * from SendToPM_Packets where PacketID = @PacketID
		


	goto xIT

--==============================================================================================
--EXIT
--==============================================================================================
xIT:

