-- Table dbo.Purchase
create table
	[dbo].[Purchase]
(
	[PurchaseId] uniqueidentifier not null
	, [PurchasePrice] decimal(32,0) not null
	, [Quantity] int not null
	, [TimeOfPurchase] datetime not null
	, [UserId] uniqueidentifier not null
	, [WatchId] uniqueidentifier not null
,
constraint [Pk_Purchase_PurchaseId] primary key clustered
(
	[PurchaseId] asc
)
);
GO
-- Relationship Fk_Watch_Purchase_WatchId
alter table [dbo].[Purchase]
add constraint [Fk_Watch_Purchase_WatchId] foreign key ([WatchId]) references [dbo].[Watch] ([WatchId]);
GO
-- Relationship Fk_User_Purchase_UserId
alter table [dbo].[Purchase]
add constraint [Fk_User_Purchase_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);