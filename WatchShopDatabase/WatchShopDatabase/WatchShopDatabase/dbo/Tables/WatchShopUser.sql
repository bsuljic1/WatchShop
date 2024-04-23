-- Table dbo.User
create table
	[dbo].WatchShopUser
(
	[UserId] uniqueidentifier not null
	, [UserFirstName] nvarchar(50) not null
	, [UserLastName] nvarchar(50) not null
	, [Email] nvarchar(250) not null
	, [UserPassword] nvarchar(50) not null
	, [Phone] nvarchar(50) not null
	, [Address] nvarchar(200) not null
,
constraint [Pk_WatchShopUser_UserId] primary key clustered
(
	[UserId] asc
)
);