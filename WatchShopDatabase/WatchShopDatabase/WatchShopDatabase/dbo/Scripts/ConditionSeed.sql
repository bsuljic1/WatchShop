DECLARE @ScriptId uniqueidentifier = '93BD3BB6-443B-4F8B-872A-B14F1E8AB98B';
DECLARE @execTime datetime = null;

SELECT @execTime = DateCreated FROM [dbo].[ScriptHistory] WHERE ScriptHistoryId = @ScriptId

IF @execTime is null
BEGIN
	INSERT INTO [dbo].[ScriptHistory](ScriptHistoryId, DateCreated) 
	VALUES(@ScriptId, GETUTCDATE());

	INSERT INTO dbo.Condition(ConditionId, ConditionName) VALUES
	(NEWID(), 'New'),
	(NEWID(), 'Used')
END 
GO

