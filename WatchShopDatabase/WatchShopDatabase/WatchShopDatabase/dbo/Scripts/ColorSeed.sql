DECLARE @ScriptId uniqueidentifier = 'C9AC2F5F-F2A8-4179-BFFD-45E1145C5FA9';
DECLARE @execTime datetime = null;

SELECT @execTime = DateCreated FROM [dbo].[ScriptHistory] WHERE ScriptHistoryId = @ScriptId

IF @execTime is null
BEGIN
	INSERT INTO [dbo].[ScriptHistory](ScriptHistoryId, DateCreated) 
	VALUES(@ScriptId, GETUTCDATE());

	INSERT INTO dbo.Color(ColorId, ColorName) VALUES
	(NEWID(), 'Black'),
	(NEWID(), 'White'),
	(NEWID(), 'Silver'),
	(NEWID(), 'Gold'),
	(NEWID(), 'Blue'),
	(NEWID(), 'Brown'),
	(NEWID(), 'Pink'),
	(NEWID(), 'Beige')
END 
GO

