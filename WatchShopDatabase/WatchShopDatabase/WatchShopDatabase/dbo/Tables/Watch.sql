-- Table dbo.Watch
create table
	[dbo].[Watch]
(
	[WatchId] uniqueidentifier not null DEFAULT NEWID()
	, [Model] nvarchar(100) not null
	, [DatePublished] date not null
	, [BraceletMaterial] nvarchar(100) not null
	, [CaseDiameter] decimal(18,0) not null
	, [WaterResistant] int not null
	, [Price] decimal(32,0) not null
	, [ShippingPrice] decimal(32,0) not null
	, [Guarantee] int not null
	, [ImagePath] nvarchar(500) not null
	, [BrandId] uniqueidentifier not null
	, [GenderId] uniqueidentifier not null
	, [ConditionId] uniqueidentifier not null
	, [ColorId] uniqueidentifier not null
	, [Available] int not null DEFAULT 0
,
[Name] NVARCHAR(10) NULL, 
    constraint [Pk_Watch_WatchId] primary key clustered
(
	[WatchId] asc
)
);
GO
-- Relationship Fk_Condition_Watch_ConditionId
alter table [dbo].[Watch]
add constraint [Fk_Condition_Watch_ConditionId] foreign key ([ConditionId]) references [dbo].[Condition] ([ConditionId]);
GO
-- Relationship Fk_Brand_Watch_BrandId
alter table [dbo].[Watch]
add constraint [Fk_Brand_Watch_BrandId] foreign key ([BrandId]) references [dbo].[Brand] ([BrandId]);
GO
-- Relationship Fk_Gender_Watch_GenderId
alter table [dbo].[Watch]
add constraint [Fk_Gender_Watch_GenderId] foreign key ([GenderId]) references [dbo].[Gender] ([GenderId]);
GO
-- Relationship Fk_Color_Watch_ColorId
alter table [dbo].[Watch]
add constraint [Fk_Color_Watch_ColorId] foreign key ([ColorId]) references [dbo].[Color] ([ColorId]);