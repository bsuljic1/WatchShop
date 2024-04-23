DECLARE @ScriptId uniqueidentifier = '9BF38C72-EC70-4AC9-BA37-0FCB50B3FC1F'
DECLARE @execTime datetime = null;

SELECT @execTime = DateCreated FROM [dbo].[ScriptHistory] WHERE ScriptHistoryId = @ScriptId

IF @execTime is null
BEGIN
	INSERT INTO [dbo].[ScriptHistory](ScriptHistoryId, DateCreated) 
	VALUES(@ScriptId, GETUTCDATE());

	INSERT INTO dbo.Style(StyleId, StyleName) VALUES
	(NEWID(), 'Analog'),
	(NEWID(), 'Digital'),
	(NEWID(), 'Automatic'),
	(NEWID(), 'Chrono'),
	(NEWID(), 'Diving'),
	(NEWID(), 'Dress'),
	(NEWID(), 'Quartz'),
	(NEWID(), 'Mechanical'),
	(NEWID(), 'Pilot'),
	(NEWID(), 'Field'),
	(NEWID(), 'Smart'),
	(NEWID(), 'Luxury')
END 
GO

