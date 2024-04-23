-- Table dbo.Color
create table
	[dbo].[Color]
(
	[ColorId] uniqueidentifier not null
	, [ColorName] nvarchar(50) not null
,
constraint [Pk_Color_ColorId] primary key clustered
(
	[ColorId] asc
)
);