DECLARE @ScriptId uniqueidentifier = 'AC1C9E29-93C4-47E2-BB55-E2CC99717377';
DECLARE @execTime datetime = null;

SELECT @execTime = DateCreated FROM [dbo].[ScriptHistory] WHERE ScriptHistoryId = @ScriptId

IF @execTime is null
BEGIN
	INSERT INTO [dbo].[ScriptHistory](ScriptHistoryId, DateCreated) 
	VALUES(@ScriptId, GETUTCDATE());

	INSERT INTO dbo.Brand(BrandId, BrandName) VALUES
	(NEWID(), 'Casio'),
	(NEWID(), 'Hugo Boss'),
	(NEWID(), 'Esprit'),
	(NEWID(), 'Festina'),
	(NEWID(), 'Fossil'),
	(NEWID(), 'Calvin Klein'),
	(NEWID(), 'Guess'),
	(NEWID(), 'Michael Kors'),
	(NEWID(), 'Tissot'),
	(NEWID(), 'Daniel Wellington'),
	(NEWID(), 'Lorus')
END 
GO


