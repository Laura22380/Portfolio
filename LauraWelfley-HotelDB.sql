if exists (select * from sys.databases where name = N'HotelReservationSchema')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'HotelReservationSchema';
	ALTER DATABASE HotelReservationSchema SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE HotelReservationSchema;
end
CREATE DATABASE HotelReservationSchema;
GO

USE HotelReservationSchema;
GO

CREATE TABLE State (
	StateAbbr CHAR(2) NOT NULL PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
);

CREATE TABLE Guest (
	GuestId INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(256) NOT NULL,
	City VARCHAR(100) NOT NULL,
	StateAbbr CHAR(2) NOT NULL UNIQUE,
	PostalCode VARCHAR(10) NOT NULL,
	PrimaryPhone VARCHAR(15) NOT NULL UNIQUE,
	CONSTRAINT fk_Gues_State FOREIGN KEY (StateAbbr) 
		REFERENCES State(StateAbbr)
);


CREATE TABLE Reservation (
	ReservationId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	GuestId INT NOT NULL,
	RoomNumber SMALLINT NOT NULL,
	NumberOfAdults SMALLINT NOT NULL,
	NumberOfChildren SMALLINT,
	CheckInDate DATE NOT NULL,
	CheckOutDate DATE NOT NULL,
	ExtraPersons INT,
	CONSTRAINT fk_Reservation_Guest FOREIGN KEY (GuestId)
		REFERENCES Guest(GuestId)
);

CREATE TABLE RoomType (
	RoomTypeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	TypeName VARCHAR(6) NOT NULL,
	ADA BIT NOT NULL,
	BasePrice DEC(10,2) NOT NULL,
	StandardOccupancy INT,
	MaximumOccupancy INT,
	AdditionalAdultCost DEC(10,2),
	Jacuzzi BIT DEFAULT 0
);

CREATE TABLE Room (
	RoomId INT PRIMARY KEY IDENTITY(201,1),
	RoomTypeId INT NOT NULL,
	RoomNumber SMALLINT NOT NULL,
	CONSTRAINT fk_RoomType_Room FOREIGN KEY (RoomTypeId)
		REFERENCES RoomType(RoomTypeId)
);

CREATE TABLE RoomAssignment (
	RoomId INT NOT NULL,
	ReservationId INT NOT NULL,
	GuestId INT NOT NULL,
	CONSTRAINT pk_RoomId PRIMARY KEY (RoomId, ReservationId),
	CONSTRAINT fk_RoomAssignment_Room FOREIGN KEY (RoomId) 
		REFERENCES Room(RoomId),
	CONSTRAINT fk_RoomAssignment_Guest FOREIGN KEY (GuestId)
		REFERENCES Guest(GuestId)
);

CREATE TABLE Ammenity (
	AmmenityId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Description VARCHAR(30) NOT NULL
);

CREATE TABLE RoomTypeAmmenity (
	RoomTypeId INT NOT NULL,
	AmmenityId INT NOT NULL,
	CONSTRAINT pk_RoomTypeAmmenity PRIMARY KEY (RoomTypeId, AmmenityId),
	CONSTRAINT fk_RoomTypeAmmenity_RoomType FOREIGN KEY (RoomTypeId) 
		REFERENCES RoomType(RoomTypeId),
	CONSTRAINT fk_RoomTypeAmmenity_Ammenity FOREIGN KEY (AmmenityId)
		REFERENCES Ammenity(AmmenityId)
);