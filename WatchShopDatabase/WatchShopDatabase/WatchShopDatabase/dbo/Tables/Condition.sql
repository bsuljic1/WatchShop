-- Table dbo.Condition
create table
	[dbo].[Condition]
(
	[ConditionId] uniqueidentifier not null
	, [ConditionName] nvarchar(20) not null
,
constraint [Pk_Condition_ConditionId] primary key clustered
(
	[ConditionId] asc
)
);