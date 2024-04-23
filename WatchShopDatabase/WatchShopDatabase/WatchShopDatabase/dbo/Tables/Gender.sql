-- Table dbo.Gender
create table
	[dbo].[Gender]
(
	[GenderId] uniqueidentifier not null
	, [GenderName] nvarchar(10) not null
,
constraint [Pk_Gender_GenderId] primary key clustered
(
	[GenderId] asc
)
);