﻿/*
Deployment script for WatchShopDatabase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "WatchShopDatabase"
:setvar DefaultFilePrefix "WatchShopDatabase"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating Default Constraint unnamed constraint on [dbo].[Cart]...';


GO
ALTER TABLE [dbo].[Cart]
    ADD DEFAULT NEWID() FOR [CartId];


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
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


GO

GO
PRINT N'Update complete.';


GO
