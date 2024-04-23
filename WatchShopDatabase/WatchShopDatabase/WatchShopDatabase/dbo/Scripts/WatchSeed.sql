DECLARE @ScriptId uniqueidentifier = 'AC60F730-A780-47EE-A4C8-3FD4EC67AEE3';
DECLARE @execTime datetime = null;

SELECT @execTime = DateCreated FROM [dbo].[ScriptHistory] WHERE ScriptHistoryId = @ScriptId

IF @execTime is null
BEGIN
	INSERT INTO [dbo].[ScriptHistory](ScriptHistoryId, DateCreated) 
	VALUES(@ScriptId, GETUTCDATE());
	INSERT INTO dbo.Watch(WatchId, Model, DatePublished, BraceletMaterial, CaseDiameter, WaterResistant, Price, ShippingPrice, 
	Guarantee, ImagePath, BrandId, GenderId, ConditionId, ColorId) VALUES
	(NEWID(), 'MTP-1314PL-8AVEF', '2019-10-20', 'Leather', 45, 50, 50, 5, 24, 'https://www.citytime.ba/media/slikeIT/MTP-1314PL-8AVEF.jpg', 
		(SELECT BrandId FROM dbo.Brand WHERE BrandName='Casio'), (SELECT GenderId FROM dbo.Gender WHERE GenderName='Man'), 
		(SELECT ConditionId FROM dbo.Condition WHERE ConditionName='New'), (SELECT ColorId FROM dbo.Color WHERE ColorName='Black') ),
	(NEWID(), 'GA-100-1A1ER', '2019-10-20', 'Plastic', 51, 200, 180, 5, 24, 'https://www.citytime.ba/media/slikeIT/GA-100-1A1ER.jpg', 
		(SELECT BrandId FROM dbo.Brand WHERE BrandName='Casio'), (SELECT GenderId FROM dbo.Gender WHERE GenderName='Man'), 
		(SELECT ConditionId FROM dbo.Condition WHERE ConditionName='New'), (SELECT ColorId FROM dbo.Color WHERE ColorName='Black') ),
	(NEWID(), 'G-2900F-1VER', '2019-10-20', 'Plastic', 46, 200, 90, 5, 24, 'https://www.citytime.ba/media/slikeIT/rocna-ura-casio-g-shock-G-2900F-1VER.jpg', 
		(SELECT BrandId FROM dbo.Brand WHERE BrandName='Casio'), (SELECT GenderId FROM dbo.Gender WHERE GenderName='Man'), 
		(SELECT ConditionId FROM dbo.Condition WHERE ConditionName='New'), (SELECT ColorId FROM dbo.Color WHERE ColorName='Black') ),
	(NEWID(), 'LTP-E140G-9AEF', '2019-10-20', 'Plastic', 38, 30, 180, 5, 24, 'https://www.citytime.ba/media/slikeIT/rocna-ura-Casio-LTP-E140G-9AEF.jpg', 
		(SELECT BrandId FROM dbo.Brand WHERE BrandName='Casio'), (SELECT GenderId FROM dbo.Gender WHERE GenderName='Woman'), 
		(SELECT ConditionId FROM dbo.Condition WHERE ConditionName='New'), (SELECT ColorId FROM dbo.Color WHERE ColorName='Gold') ),
	(NEWID(), 'ES3545', '2019-10-20', 'Stainless steel', 36, 30, 180, 5, 24, 'https://www.citytime.ba/media/slikeIT/ES3545.jpg', 
		(SELECT BrandId FROM dbo.Brand WHERE BrandName='Fossil'), (SELECT GenderId FROM dbo.Gender WHERE GenderName='Woman'), 
		(SELECT ConditionId FROM dbo.Condition WHERE ConditionName='New'), (SELECT ColorId FROM dbo.Color WHERE ColorName='Silver') ),
	(NEWID(), 'ES2811', '2019-10-20', 'Stainless steel', 38, 100, 200, 5, 24, 'https://www.citytime.ba/media/slikeIT/rocna-ura-fossil-ES2811.jpg', 
		(SELECT BrandId FROM dbo.Brand WHERE BrandName='Fossil'), (SELECT GenderId FROM dbo.Gender WHERE GenderName='Woman'), 
		(SELECT ConditionId FROM dbo.Condition WHERE ConditionName='New'), (SELECT ColorId FROM dbo.Color WHERE ColorName='Gold') ),
	(NEWID(), '1513598', '2019-10-20', 'Leather', 42, 50, 310, 5, 24, 'https://www.citytime.ba/media/slikeIT/rocna-ura-Hugo-Boss-1513598.jpg', 
		(SELECT BrandId FROM dbo.Brand WHERE BrandName='Hugo Boss'), (SELECT GenderId FROM dbo.Gender WHERE GenderName='Man'), 
		(SELECT ConditionId FROM dbo.Condition WHERE ConditionName='New'), (SELECT ColorId FROM dbo.Color WHERE ColorName='Brown') )
END 
GO

