DECLARE @ScriptId uniqueidentifier = 'C4153851-EF29-4DE7-91A1-A1CF9E06F65D';
DECLARE @execTime datetime = null;

SELECT @execTime = DateCreated FROM [dbo].[ScriptHistory] WHERE ScriptHistoryId = @ScriptId

IF @execTime is null
BEGIN
	INSERT INTO [dbo].[ScriptHistory](ScriptHistoryId, DateCreated) 
	VALUES(@ScriptId, GETUTCDATE());

	INSERT INTO dbo.Role(RoleId, RoleName) VALUES
	(NEWID(), 'Administrator'),
	(NEWID(), 'Registered Costumer'),
	(NEWID(), 'Unregistered Costumer')
END 
GO


