-- Table dbo.User
create table
	[dbo].[User]
(
	[UserId] uniqueidentifier not null
	, [UserFirstName] nvarchar(50) not null
	, [UserLastName] nvarchar(50) not null
	, [Email] nvarchar(250) not null
	, [Password] nvarchar(50) not null
	, [Phone] nvarchar(50) not null
	, [Address] nvarchar(200) not null
,
constraint [Pk_User_UserId] primary key clustered
(
	[UserId] asc
)
);