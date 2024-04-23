-- Model New Model
-- Updated 11/17/2021 11:49:45 AM
-- DDL Generated 11/17/2021 11:54:24 AM

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Brand
create table
	[dbo].[Brand]
(
	[BrandId] uniqueidentifier not null
	, [BrandName] nvarchar(50) not null
,
constraint [Pk_Brand_BrandId] primary key clustered
(
	[BrandId] asc
)
);