-- Table dbo.UserRole
create table
	[dbo].[UserRole]
(
	[UserId] uniqueidentifier not null
	, [RoleId] uniqueidentifier not null
,
constraint [Pk_UserRole_UserIdRoleId] primary key clustered
(
	[UserId] asc
	, [RoleId] asc
)
);
GO
-- Relationship Fk_User_UserRole_UserId
alter table [dbo].[UserRole]
add constraint [Fk_User_UserRole_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);
GO
-- Relationship Fk_Role_UserRole_RoleId
alter table [dbo].[UserRole]
add constraint [Fk_Role_UserRole_RoleId] foreign key ([RoleId]) references [dbo].[Role] ([RoleId]);