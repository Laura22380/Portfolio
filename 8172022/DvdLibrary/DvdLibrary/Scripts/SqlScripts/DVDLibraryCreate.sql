USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name='DVDLibrary')
DROP DATABASE DVDLibrary
GO

CREATE DATABASE DVDLibrary
GO

USE DVDLibrary
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='DVDs')
	DROP TABLE DVDs
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Ratings')
	DROP TABLE Ratings
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ReleaseYears')
	DROP TABLE ReleaseYears
GO

--IF EXISTS(SELECT * FROM sys.tables WHERE name='BathroomTypes')
--	DROP TABLE BathroomTypes
--GO



CREATE TABLE Ratings(
	RatingId int identity(1,1) not null primary key,
	Rating varchar(5) not null
)
GO

CREATE TABLE DVDs(
	DvdId int identity(1,1) not null primary key,
	Title varchar(50) not null,
	ReleaseYear int not null 
		CONSTRAINT CHK_ReleaseYear_Validity
		CHECK (ReleaseYear BETWEEN 1900 AND 9999),
	Director varchar(50) not null,
	Rating varchar(5) not null
)
GO

CREATE TABLE ReleaseYears(
	ReleaseYear varchar(4)
)
GO

--CREATE TABLE Listings(
--	ListingId int identity(1,1) not null primary key,
--	UserId nvarchar(128) not null,
--	StateId char(2) not null foreign key references States(StateId),
--	BathroomTypeId int null foreign key references BathroomTypes(BathroomTypeId),
--	Nickname nvarchar(50) not null,
--	City nvarchar(50) not null,
--	Rate decimal(7,2) not null,
--	SquareFootage decimal (7,2) not null,
--	HasElectric bit not null,
--	HasHeat bit not null,
--	ListingDescription varchar(500) null,
--	ImageFileName varchar(50),
--	CreatedDate datetime2 not null default(getdate())
--)






