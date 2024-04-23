-- Table dbo.RolePrivilege
create table
	[dbo].[RolePrivilege]
(
	[RolePrivilegeId] uniqueidentifier not null
	, [RoleId] uniqueidentifier not null
	, [PrivilegeId] uniqueidentifier not null
,
constraint [Pk_RolePrivilege_RolePrivilegeId] primary key clustered
(
	[RolePrivilegeId] asc
)
);
GO
-- Relationship Fk_Role_RolePrivilege_RoleId
alter table [dbo].[RolePrivilege]
add constraint [Fk_Role_RolePrivilege_RoleId] foreign key ([RoleId]) references [dbo].[Role] ([RoleId]);
GO
-- Relationship Fk_Privilege_RolePrivilege_PrivilegeId
alter table [dbo].[RolePrivilege]
add constraint [Fk_Privilege_RolePrivilege_PrivilegeId] foreign key ([PrivilegeId]) references [dbo].[Privilege] ([PrivilegeId]);