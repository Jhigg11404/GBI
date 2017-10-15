if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sort_Info]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Sort_Info]
GO

CREATE TABLE [dbo].[Sort_Info] (
	[WaveID] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[UPC] [UPC] NULL ,
	[SKU] [UPC] NULL ,
	[DropLocation] [int] NULL ,
	[OrderID] [varchar] (20) NULL ,
	[QtyRequired] [int] NULL ,
	[QtyRemaining] [int] NULL ,
	[ConfirmedDrops] [int] NULL ,
	[Status] [varchar] (2) NULL ,
	[CartonID] [varchar] (30) NULL 
) ON [PRIMARY]
GO