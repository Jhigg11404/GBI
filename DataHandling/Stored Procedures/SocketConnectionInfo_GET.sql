USE Galaxy

IF EXISTS (SELECT * FROM sysobjects WHERE ID = OBJECT_ID('dbo.SocketConnectionInfo_Get') AND sysstat & 0xf = 4)
BEGIN
       DROP PROCEDURE dbo.SocketConnectionInfo_Get
END
GO

CREATE PROCEDURE SocketConnectionInfo_Get
 @SocketName   varchar(30),
 @Mode   	   varchar(10)
as
/*
===============================================================================
	File: 
	Name: SocketConnectionInfo_Get
	Desc: AENT 
		Gets socket connection info.

	Auth: JAH
	Called by:   
             
	Date:  10/02/2017

	Exec SocketConnectionInfo_Get 'gbiCartonSocketCons','prod'
===============================================================================
	Change History
===============================================================================
	Date:		Author:		Description:
	
	----------  -------     ---------------------------------------------------                             
===============================================================================
*/
set nocount on 
declare
    @error_severity               int
    , @error_state                int
    , @error_number               int
    , @error_line                 int
    , @error_message			  varchar(245)
       , @rowcount                int
       , @result                  int
       , @return_status           smallint
       -- other work variables

      
Set @return_status = 0

/*
===============================================================================
       GET LIST
===============================================================================
*/

Begin

	Select 
		css.IpAddr,
		css.epPort,
		css.Timeout
	from 
		Galaxy.dbo.Control_SocketServers css
	where
		css.AppName = @SocketName
	and
		css.Mode = @Mode

End
			

