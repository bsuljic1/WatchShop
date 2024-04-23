DECLARE @ScriptId uniqueidentifier = '66107DFD-BD5C-452C-964D-93D6A93D2C4E';
DECLARE @execTime datetime = null;

SELECT @execTime = DateCreated FROM [dbo].[ScriptHistory] WHERE ScriptHistoryId = @ScriptId

IF @execTime is null
BEGIN
	INSERT INTO [dbo].[ScriptHistory](ScriptHistoryId, DateCreated) 
	VALUES(@ScriptId, GETUTCDATE());

	INSERT INTO dbo.Gender(GenderId, GenderName) VALUES
	(NEWID(), 'Man'),
	(NEWID(), 'Woman'),
	(NEWID(), 'Unisex')
END 
GO

