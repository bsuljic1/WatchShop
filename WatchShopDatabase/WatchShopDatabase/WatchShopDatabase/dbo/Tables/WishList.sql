-- Table dbo.WishList
create table
	[dbo].[WishList]
(
	[WishListId] uniqueidentifier not null
	, [WatchId] uniqueidentifier not null
	, [UserId] uniqueidentifier not null
,
constraint [Pk_WishList_WishListId] primary key clustered
(
	[WishListId] asc
)
);
GO
-- Relationship Fk_Watch_WishList_WatchId
alter table [dbo].[WishList]
add constraint [Fk_Watch_WishList_WatchId] foreign key ([WatchId]) references [dbo].[Watch] ([WatchId]);
GO
-- Relationship Fk_User_WishList_UserId
alter table [dbo].[WishList]
add constraint [Fk_User_WishList_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);