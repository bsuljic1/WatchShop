-- Table dbo.Privilege
create table
	[dbo].[Privilege]
(
	[PrivilegeId] uniqueidentifier not null
	, [PrivilegeName] nvarchar(50) not null
,
constraint [Pk_Privilege_PrivilegeId] primary key clustered
(
	[PrivilegeId] asc
)
);