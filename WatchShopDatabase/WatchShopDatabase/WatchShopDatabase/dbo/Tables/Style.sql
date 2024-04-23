-- Table dbo.Style
create table
	[dbo].[Style]
(
	[StyleId] uniqueidentifier not null
	, [StyleName] nvarchar(50) not null
,
constraint [Pk_Style_StyleId] primary key clustered
(
	[StyleId] asc
)
);