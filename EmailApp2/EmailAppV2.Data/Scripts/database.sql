USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name='ClarityVentures')
DROP DATABASE ClarityVentures
GO

CREATE DATABASE ClarityVentures
GO

USE ClarityVentures

IF EXISTS(SELECT * FROM sys.tables WHERE name='EmailLog')
	DROP TABLE EmailLog
GO

CREATE TABLE EmailLog(
	EmailId int identity(1,1) not null primary key,
	SenderEmail varchar(250) not null,
	Recipient varchar(250) not null,
	EmailSubject varchar(50) not null,
	Body varchar(3000) not null,
	SendDate datetime2 not null default(getdate()),
	SendStatus bit not null
)