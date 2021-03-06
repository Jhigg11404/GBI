﻿USE [Galaxy]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id (N'[dbo].[GBI_Packets_ADD]') AND type = 'P') 
DROP Procedure dbo.GBI_Packets_ADD
GO

/****** Object:  StoredProcedure [dbo].[GBI_Packets_ADD]    Script Date: 9/9/2017 2:14:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GBI_Packets_ADD]
@Socket varchar(30),
@SocketMessage varchar(200),
@Reply Varchar(50)
as
/*
===============================================================================
	File: 
	Name: GBI_Packets_ADD
	Desc: AENT - GBI
		Writes socket message to table for processing
	Auth: Higginbotham, Joshua
	Called by:   
             
	Date: 10/02/2017
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

--Work Variables
Declare
	@CartonId varchar(30),
	@DropLocation varchar(3),
	@TransId varchar(15),
	@OrderID varchar(20),
	@DropStatus varchar(1)


-- initialise
SET @return_status = 0;
SET @Process = 'Proc = GBI_Packets_ADD';
SET @Now = GETDATE();
SET @Status = '';
Set @CartonId = '';
Set @DropLocation = '';
Set @TransId = '';
Set @OrderID = '';
Set @DropStatus = '';

/*
===============================================================================

===============================================================================
*/

Begin

	If @Socket = 'AssignBox'
	Begin
		--Parse the socket message to get info needed to assign the box.
		select @Transid = Substring (@SocketMessage, 4, 10), @CartonID = SUBSTRING(@socketMessage, 14,20), @DropLocation = SUBSTRING(@SocketMessage, 34,3)
		--Insert the carton into the table for Operations
		Exec Galaxy.dbo.AssignCarton @CartonId, @DropLocation

		Update Galaxy.dbo.Control_SocketLog
		Set Status = 90
		where SocketMessage = @SocketMessage

Insert into Galaxy.dbo.Control_socketLog
	(SocketDate
	,Socket
	,TransId
	,SocketMessage
	,Reply
	,Status
	)
Values
	(
	getdate()
	,@Socket
	,@TransId
	,@SocketMessage
	,@Reply
	,10
	)

	  SELECT distinct OrderID, [Status]
	  FROM [Galaxy].[dbo].[ProductDistribution]
      where droplocation = @DropLocation
	 End
End

 


