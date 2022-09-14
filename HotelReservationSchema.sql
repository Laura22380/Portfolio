USE master
GO

if exists (select * from sys.databases where name = N'HotelReservationDB')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'HotelReservationDB';
	ALTER DATABASE HotelReservationDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE HotelReservationDB;
end
CREATE DATABASE HotelReservationDB;
GO

USE HotelReservationDB;
GO

CREATE TABLE Guest (
	GuestId INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(256) NOT NULL,
	City VARCHAR(100) NOT NULL,
	StateAbbr CHAR(2) NOT NULL UNIQUE,
	PostalCode VARCHAR(10) NOT NULL,
	PrimaryPhone VARCHAR(15) NOT NULL UNIQUE
);

CREATE TABLE State (
	StateAbbr CHAR(2) NOT NULL PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	CONSTRAINT fk_State_Guest FOREIGN KEY (StateAbbr) 
		REFERENCES Guest(StateAbbr)
);

CREATE TABLE Reservation (
	ReservationId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	GuestId INT NOT NULL,
	RoomNumber SMALLINT NOT NULL,
	NumberOfAdults SMALLINT NOT NULL,
	NumberOfChildren SMALLINT,
	CheckInDate DATE NOT NULL,
	CheckOutDate DATE NOT NULL,
	CONSTRAINT fk_Reservation_Guest FOREIGN KEY (GuestId)
		REFERENCES Guest(GuestId)
);

CREATE TABLE RoomType (
	RoomTypeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	TypeName VARCHAR(6) NOT NULL,
	ADA BIT,
	BasePrice DEC(10,2),
	StandardOccupancy INT,
	MaximumOccupancy INT,
	ExtraPersons INT
);

CREATE TABLE Room (
	RoomId INT PRIMARY KEY,
	RoomTypeId INT NOT NULL UNIQUE,
	RoomNumber SMALLINT NOT NULL,
	CONSTRAINT fk_RoomType_RoomTypeId FOREIGN KEY (RoomTypeId)
		REFERENCES RoomType(RoomTypeId)
);

CREATE TABLE RoomAssignment (
	RoomId INT NOT NULL,
	ReservationId INT NOT NULL,
	CONSTRAINT pk_RoomId PRIMARY KEY (RoomId, ReservationId),
	CONSTRAINT fk_RoomId_Room FOREIGN KEY (RoomId) 
		REFERENCES Room(RoomId),
	CONSTRAINT fk_GuestId_Guest FOREIGN KEY (ReservationId)
		REFERENCES Guest(GuestId)
);




CREATE TABLE Ammenity (
	AmmenityId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Description VARCHAR NOT NULL
);

CREATE TABLE RoomTypeAmmenity (
	RoomTypeId INT NOT NULL,
	AmmenityId INT NOT NULL,
	CONSTRAINT pk_RoomTypeAmmenity PRIMARY KEY (RoomTypeId, AmmenityId),
	CONSTRAINT fk_RoomTypeId_RoomType FOREIGN KEY (RoomTypeId) 
		REFERENCES Room(RoomId),
	CONSTRAINT fk_AmmenityId_Ammenity FOREIGN KEY (AmmenityId)
		REFERENCES Ammenity(AmmenityId)
);
