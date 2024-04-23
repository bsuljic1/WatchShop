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



GO

GO
PRINT N'Update complete.';


GO
