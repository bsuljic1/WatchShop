-- Table dbo.Cart
create table
	[dbo].[Cart]
(
	[CartId] uniqueidentifier not null DEFAULT NEWID()
	, [TotalPrice] decimal(32,0) not null
	, [Quantity] int not null
	, [WatchId] uniqueidentifier not null
	, [UserId] uniqueidentifier not null
,
constraint [Pk_Cart_CartId] primary key clustered
(
	[CartId] asc
)
);
GO
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Watch_Cart_WatchId
alter table [dbo].[Cart]
add constraint [Fk_Watch_Cart_WatchId] foreign key ([WatchId]) references [dbo].[Watch] ([WatchId]);
GO
-- Relationship Fk_User_Cart_UserId
alter table [dbo].[Cart]
add constraint [Fk_User_Cart_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);