CREATE TABLE User(
    Id char(36) PRIMARY KEY,
    UserName nvarchar(256) NULL,
	NormalizedUserName nvarchar(256) NULL,
	Email nvarchar(256) NULL,
	NormalizedEmail nvarchar(256) NULL,
	EmailConfirmed bit NOT NULL,
	PasswordHash nvarchar(256) NULL,
	SecurityStamp nvarchar(256) NULL,
	ConcurrencyStamp nvarchar(256) NULL,
	PhoneNumber nvarchar(256) NULL,
	PhoneNumberConfirmed bit NOT NULL,
	TwoFactorEnabled bit NOT NULL,
	LockoutEnd datetime NULL,
	LockoutEnabled bit NOT NULL,
	AccessFailedCount int NOT NULL,
	AuthenticatorKey nvarchar(256) NULL
);

CREATE TABLE Role(
	Id char(36) PRIMARY KEY,
	Name varchar(256) NOT NULL,
	NormalizedName varchar(256) NOT NULL,
	ConcurrencyStamp nvarchar(256) NULL
);

CREATE TABLE UserRole(
	UserId char(36),
	FOREIGN KEY (UserId)
		REFERENCES User(Id)
		ON DELETE CASCADE,

	RoleId char(36),
	FOREIGN KEY (RoleId)
		REFERENCES Role(Id)
		ON DELETE CASCADE,

	PRIMARY KEY (UserId, RoleId)
);
