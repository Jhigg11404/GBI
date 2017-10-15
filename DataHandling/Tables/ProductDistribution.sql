if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductDistribution]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ProductDistribution]
GO

CREATE TABLE [dbo].[ProductDistribution] (
	[SorterID] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[WaveID] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[UPC] [UPC] NOT NULL ,
	[SKU] [UPC] NULL ,
	[Version] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DropLocation] [int] NULL ,
	[OrderID] [ORDER] NOT NULL ,
	[QtyRequired] [int] NULL ,
	[QtyRemaining] [int] NULL ,
	[ConfirmedDrops] [int] NULL ,
	[Status] [STATUS] NULL ,
	[CartonID] [CARTON] NULL ,
	[StickerDesignID] [char] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[StickerStockID] [char] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LabelField1] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LabelField2] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LabelField3] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LabelField4] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LabelField5] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LabelField6] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LabelField7] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LabelField8] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LabelField9] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LabelField10] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ManualLabelCount] [smallint] NULL ,
	[UploadSeq] [int] NULL ,
	[priority] [int] NOT NULL 
) ON [PRIMARY]
GO