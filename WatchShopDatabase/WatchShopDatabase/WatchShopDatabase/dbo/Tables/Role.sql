-- Table dbo.Role
create table
	[dbo].[Role]
(
	[RoleId] uniqueidentifier not null
	, [RoleName] nvarchar(50) not null
,
constraint [Pk_Role_RoleId] primary key clustered
(
	[RoleId] asc
)
);