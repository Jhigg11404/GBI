USE [Apix2]
GO

INSERT INTO [dbo].[PREPROCESS_RULES]
           ([Sorter]
           ,[Type]
           ,[ComputerName]
           ,[Name]
           ,[Destinations]
           ,[SorterStyle]
           ,[ToSorterFolder]
           ,[MinimumPieceLength]
           ,[MaximumPieceLength]
           ,[MinimumPieceWidth]
           ,[MaximumPieceWidth]
           ,[MinimumPieceHeight]
           ,[MaximumPieceHeight]
           ,[MinimumPieceWeight]
           ,[MaximumPieceWeight]
           ,[AuthorizedHMI]
           ,[SplitOrdersAllowed]
           ,[SplitOrderGreaterThanAverageRuleApplies]
           ,[SplitOrderGreaterThanAverageValue]
           ,[SplitOrdersOnVolume]
           ,[MaximumBoxesPerDest]
           ,[SplitDetailsRuleApplies]
           ,[SplitDetails]
           ,[SeparateSingleUnitOrdersIntoSeparatePtlWavesRuleApplies]
           ,[SeparateSingleUnitOrdersIntoSeparatePtlWaves]
           ,[SeparateOrdersRequiringLabelingIntoSeparatePtlWavesRuleApplies]
           ,[SeparateOrdersRequiringLabelingIntoSeparatePtlWaves]
           ,[MinimumPiecesForSingleOrderDestinationRuleApplies]
           ,[MinimumPiecesForSingleOrderDestinationValue]
           ,[MaximumPiecesForSingleOrderDestinationRuleApplies]
           ,[MaximumPiecesForSingleOrderDestinationValue]
           ,[MaximumPiecesPerPtlDestinationRuleApplies]
           ,[MaximumPiecesPerPtlDestinationValue]
           ,[LabelSglOrdersOnSorterRuleApplies]
           ,[LabelPtlWavesOnSorterRuleApplies]
           ,[PtlAnchorAscendFromDestination]
           ,[PtlAnchorDestinationValue]
           ,[CanHop])
     VALUES
           (10
		   ,'CURRENT'
		   ,'GBI'
		   ,'GBI - Returns'
		   ,148
		   ,'XBELT'
		   ,'D:\Autologik\ProcessedWaves\System_10\'
		   ,0
		   ,9999999
		   ,0
		   ,9999999
		   ,0
		   ,9999999
		   ,0
		   ,9999999
		   ,'AL-APIXHMI'
		   ,1
		   ,0
		   ,99
		   ,0
		   ,1
		   ,0
		   ,1
		   ,1
		   ,1
		   ,1
		   ,0
		   ,0
		   ,45
		   ,0
		   ,240
		   ,0
		   ,45
		   ,0
		   ,1
		   ,0
		   ,1
		   ,0
		   )
GO

Use Galaxy
Go
Create table ProcessAdmins
(
	BadgeId varchar(10) primary Key not null,
	Fullname varchar(50) not null
)

Create Table ProcessLog
(
	ProcessId int identity(1,1) primary key not null,
    ProcessName varchar(50) not null,
    BadgeId varchar(10)not null,
	ProcessDate datetime not null
)
    


