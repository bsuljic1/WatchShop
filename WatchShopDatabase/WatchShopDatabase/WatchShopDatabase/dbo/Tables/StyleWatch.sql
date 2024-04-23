-- Table dbo.StyleWatch
create table
	[dbo].[StyleWatch]
(
	[StyleWatchId] uniqueidentifier not null
	, [StyleId] uniqueidentifier not null
	, [WatchId] uniqueidentifier not null
,
constraint [Pk_StyleWatch_StyleWatchIdStyleIdWatchId] primary key clustered
(
	[StyleWatchId] asc
	, [StyleId] asc
	, [WatchId] asc
)
);
GO
-- Relationship Fk_Watch_StyleWatch_WatchId
alter table [dbo].[StyleWatch]
add constraint [Fk_Watch_StyleWatch_WatchId] foreign key ([WatchId]) references [dbo].[Watch] ([WatchId]);
GO
-- Relationship Fk_Style_StyleWatch_StyleId
alter table [dbo].[StyleWatch]
add constraint [Fk_Style_StyleWatch_StyleId] foreign key ([StyleId]) references [dbo].[Style] ([StyleId]);