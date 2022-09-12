
USE GuildCars
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleSales')
	DROP TABLE VehicleSales
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Contacts')
	DROP TABLE Contacts
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Models')
	DROP TABLE Models
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Makes')
	DROP TABLE Makes
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Users')
	DROP TABLE Users
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Buyers')
	DROP TABLE Buyers
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicles')
	DROP TABLE Vehicles
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
	DROP TABLE States
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyles')
	DROP TABLE BodyStyles
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmissions')
	DROP TABLE Transmissions
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Colors')
	DROP TABLE Colors
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Interiors')
	DROP TABLE Interiors
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials
GO

CREATE TABLE States(
	StateId char(2) not null primary key,
	StateName varchar(20) not null
)


CREATE TABLE BodyStyles(
	BodyStyleId int identity(1,1) not null primary key,
	BodyStyleName varchar(15) not null
)

CREATE TABLE Transmissions(
	TransmissionId int identity(1,1) not null primary key,
	TransmissionName varchar(20) not null
)

CREATE TABLE Colors(
	ColorId int identity(1,1) not null primary key,
	ColorName varchar(20) not null
)

CREATE TABLE Interiors(
	InteriorId int identity(1,1) not null primary key,
	InteriorName varchar(20) not null
)

CREATE TABLE Users(
	UserId int identity(1,1) not null primary key,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	Email varchar(250) not null,
	UserRole varchar(50) not null,
)

CREATE TABLE Makes(
	MakeId int identity(1,1) not null primary key,
	MakeName varchar(20) not null,
	MakeDateAdded datetime not null default(getdate()),
	UserId int foreign key references Users(UserId)
)

CREATE TABLE Models(
	ModelId int identity(1,1) not null primary key,
	MakeId int foreign key references Makes(MakeId),
	ModelName varchar(20) not null,
	ModelDateAdded datetime not null default(getdate()),
	UserId int foreign key references Users(UserId)
)

CREATE TABLE Vehicles(
	VIN char(20) not null primary key,
	VehicleYear int not null,
	MakeId int foreign key references Makes(MakeId),
	ModelId int foreign key references Models(ModelId),
	BodyStyleId int null foreign key references BodyStyles(BodyStyleId),
	TransmissionId int not null foreign key references Transmissions(TransmissionId),
	ColorId int not null foreign key references Colors(ColorId),
	InteriorId int not null foreign key references Interiors(InteriorId),
	Mileage varchar(10) not null,
	SalePrice decimal(7,2) not null,
	MSRP decimal (7,2) not null,
	VehicleDescription varchar(1000) null,
	ImageFileName varchar(50)  null,
	IsFeatured bit not null default 0,
	IsPurchased bit not null default 0
)

CREATE TABLE Buyers(
	BuyerId int identity(1,1) not null primary key,
	BuyerName varchar(100) not null,
	BuyerEmail varchar(50) null,
	BuyerPhone varchar(15) null,
	Street1 varchar(50) not null,
	Street2 varchar(50) null,
	BuyerCity varchar(50) not null,
	StateId char(2) not null foreign key references States(StateId),
	BuyerZipcode int not null
)




CREATE TABLE Contacts(
	ContactId int identity(1,1) primary key,
	UserId int null foreign key references Users(UserId),
	ContactEmail varchar(50) null,
	ContactPhone varchar(15) null,
	ContactName varchar(125) null,
	ContactMessage varchar(1000) null
)

CREATE TABLE VehicleSales(
	SaleId int identity(1,1)  primary key,
	VIN char(20) not null foreign key references Vehicles(VIN),
	UserId int not null foreign key references Users(UserId),
	BuyerId int not null foreign key references Buyers(BuyerId),
	PurchasePrice decimal not null,
	PurchaseType varchar(15),
	SaleDate date not null default(getdate())
)

CREATE TABLE Specials(
	SpecialId int identity(1,1) not null primary key,
	SpecialTitle varchar(20) not null,
	SpecialDescription varchar(1000) not null
)
