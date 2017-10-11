USE Warehouse

IF EXISTS (SELECT * FROM sysobjects WHERE ID = OBJECT_ID('dbo.syErrLog_ADD') AND sysstat & 0xf = 4)
BEGIN
	DROP PROCEDURE dbo.syErrLog_ADD
END
GO

CREATE PROCEDURE dbo.syErrLog_ADD
/*******************************************************************************************

	Name:		syErrLog_ADD
	
	Desc:		
				Adds a record in syErrLog

				May want to standardize this proc at some point

	Auth:		
	
	Called by:   
             
	Date: 05/05/2016

===============================================================================
	Change History
===============================================================================
	Date:		Author:		Description:
	--------	--------	---------------------------------------------------


===============================================================================
	Tables and Notes
===============================================================================
	CREATE TABLE syErrLog(
	ErrID bigint identity(1,1),
	ErrDate datetime NOT NULL,
	ActionCode char(5) NOT NULL,
	AppName varchar(64) NOT NULL,
	AppVersion varchar(20) NOT NULL,
	AppMode char(4) NOT NULL,
	ComputerName varchar(64) NOT NULL,
	UserProf varchar(64) NOT NULL,
	ErrGroup smallint NOT NULL,
	ErrMessage varchar(256) NOT NULL,
	ErrFullText varchar(max) NOT NULL,
	CONSTRAINT PK_syErrLog PRIMARY KEY CLUSTERED (RowID ASC)
)

If Log And Notify Then ActionCode = "LN" 'Log and Notify
If Log And Not Notify Then ActionCode = "LO" 'Log Only
If Not Log And Notify Then ActionCode = "NO" 'Notify Only

******************************************************************************************/

	@ActionCode char(5),
	@AppName varchar(64),
	@AppVersion varchar(20),
	@AppMode char(4),
	@ComputerName varchar(64),
	@UserProf varchar(64),
	@ErrGroup smallint,
	@ErrMessage varchar(256),
	@ErrFullText varchar(max),
	@StrBody as varchar(max)

AS

SET NOCOUNT ON

--==============================================================================================
--DECLARE/INIT LOCAL VARS
--==============================================================================================
Declare 
	@ErrID bigint,
	@ErrDate as datetime
--==============================================================================================
--BEGIN PROCESSING
--==============================================================================================

Set @ErrID = 0
set @ErrDate = getdate()

if @ActionCode = 'NO' begin goto xNotify end --Notify Only

--Log
insert syErrLog
	(ErrDate, ActionCode, AppName, AppVersion, AppMode, ComputerName, UserProf, ErrGroup, ErrMessage, ErrFullText) 
values
	(@ErrDate, @ActionCode, @AppName, @AppVersion, @AppMode, @ComputerName, @UserProf, @ErrGroup, @ErrMessage, @ErrFullText)

Select @ErrID = SCOPE_IDENTITY()

if @ActionCode = 'LO' begin goto xIT end --Log Only

--Notify
xNotify:
Declare 
	@Subj as char(126),
	@tableHTML as varchar(max)

Set @Subj = '[ERROR]: ' + @AppName + ' on ' + @ComputerName + '. [' + @ErrMessage +  ']'--'Error Alert: ' + @AppName + ' running on ' + @ComputerName

--Set	@tableHTML = N'<H4><u>This happend on ' + DATENAME(weekday, @ErrDate) + ', ' + DATENAME(month, @ErrDate) + ' ' + LTRIM(day(@ErrDate)) + ', ' + LTRIM(year(@ErrDate)) + ': </u></H4>' +
--	N'<style type="text/css">table {font-size: 1.25em;}</style>' +
--	N'<table border="1" bgcolor="LightBlue" width="75%" cellpadding="2" cellspacing="0">' +
--	N'<tr><th nowrap bgcolor="silver">Item</th><th nowrap bgcolor="silver">Info</th></tr>' +
--	N'<tr><td>Program </td><td>' + @AppName + '</td></tr>' +
--	N'<tr><td>User </td><td>' + @UserProf + '</td></tr>' +
--	N'<tr><td>Failure </td><td>' + @ErrMessage + '</td></tr>' +
--	N'<tr><td>ErrID </td><td>' + rtrim(@ErrID) + '</td></tr>' +
--	N'</table>' ;

EXEC msdb.dbo.sp_send_dbmail
    @profile_name = 'sqlserver',
    @recipients = [joshig@aent.com], --[joshig@aent.com;grebra@aent.com]
	@subject = @Subj,
    @body = @strBody, --@tableHTML,
    @body_format = 'text'; --'HTML';

xIT:

Select @ErrID

GO
GRANT  EXECUTE  ON dbo.syErrLog_ADD TO PUBLIC
GO
