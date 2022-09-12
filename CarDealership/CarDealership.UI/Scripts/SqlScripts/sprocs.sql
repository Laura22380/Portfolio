IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'StatesSelectAll')
		DROP PROCEDURE StatesSelectAll
GO

CREATE PROCEDURE StatesSelectAll AS
BEGIN
	SELECT StateId, StateName
	FROM States
	ORDER BY StateName
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStylesSelectAll')
		DROP PROCEDURE BodyStylesSelectAll
GO

CREATE PROCEDURE BodyStylesSelectAll AS
BEGIN
	SELECT BodyStyleId, BodyStyleName
	FROM BodyStyles
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ColorsSelectAll')
		DROP PROCEDURE ColorsSelectAll
GO

CREATE PROCEDURE ColorsSelectAll AS
BEGIN
	SELECT ColorId, ColorName
	FROM Colors
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InteriorsSelectAll')
		DROP PROCEDURE InteriorsSelectAll
GO

CREATE PROCEDURE InteriorsSelectAll AS
BEGIN
	SELECT InteriorId, InteriorName
	FROM Interiors
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransmissionsSelectAll')
		DROP PROCEDURE TransmissionsSelectAll
GO

CREATE PROCEDURE TransmissionsSelectAll AS
BEGIN
	SELECT TransmissionId, TransmissionName
	FROM Transmissions
END
GO




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelsSelectAll')
		DROP PROCEDURE ModelsSelectAll
GO

CREATE PROCEDURE ModelsSelectAll AS
BEGIN
	SELECT ma.MakeName, ModelId, ModelName, ModelDateAdded, u.Email
	FROM Models m
	INNER JOIN Users u ON m.UserId = u.UserId
	INNER JOIN Makes ma ON m.MakeId = ma.MakeId
END
GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakesSelectAll')
		DROP PROCEDURE MakesSelectAll
GO

CREATE PROCEDURE MakesSelectAll AS
BEGIN
	SELECT MakeId, MakeName, MakeDateAdded, u.Email
	FROM Makes m
	INNER JOIN Users u ON m.UserId = u.UserId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesInsert')
		DROP PROCEDURE VehiclesInsert
GO

CREATE PROCEDURE VehiclesInsert(
	@VIN char(20),
	@VehicleYear int,
	@MakeId int,
	@ModelId int,
	@BodyStyleId int,
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Mileage varchar(50),
	@SalePrice decimal(7,2),
	@MSRP decimal(7,2),
	@VehicleDescription varchar(1000),
	@ImageFileName varchar(50),
	@IsFeatured bit,
	@IsPurchased bit
) AS
BEGIN
	INSERT INTO Vehicles(VIN, VehicleYear, MakeId, ModelId, BodyStyleId, TransmissionId, ColorId, InteriorId,
		Mileage, SalePrice, MSRP, VehicleDescription, ImageFileName, IsFeatured, IsPurchased)
		VALUES(@VIN, @VehicleYear, @MakeId, @ModelId, @BodyStyleId, @TransmissionId, @ColorId, @InteriorId,
			@Mileage, @SalePrice, @MSRP, @VehicleDescription, @ImageFileName, @IsFeatured, @IsPurchased);
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesUpdate')
		DROP PROCEDURE VehiclesUpdate
GO

CREATE PROCEDURE VehiclesUpdate(
	@VIN char(20),
	@VehicleYear int,
	@MakeId int,
	@ModelId int,
	@BodyStyleId int,
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Mileage varchar(50),
	@SalePrice decimal(7,2),
	@MSRP decimal(7,2),
	@VehicleDescription varchar(1000),
	@ImageFileName varchar(50),
	@IsFeatured bit,
	@IsPurchased bit
) AS
BEGIN
	UPDATE Vehicles SET
		VehicleYear = @VehicleYear, 
		MakeId = @MakeId, 
		ModelId = @ModelId, 
		BodyStyleId = @BodyStyleId, 
		TransmissionId = @TransmissionId, 
		ColorId = @ColorId, 
		InteriorId = @InteriorId,
		Mileage = @Mileage, 
		SalePrice = @SalePrice, 
		MSRP = @MSRP, 
		VehicleDescription = @VehicleDescription, 
		ImageFileName = @ImageFileName,
		IsFeatured = @IsFeatured,
		IsPurchased = @IsPurchased
	WHERE VIN = @VIN
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesDelete')
		DROP PROCEDURE VehiclesDelete
GO

CREATE PROCEDURE VehiclesDelete(
	@VIN char(20)
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Vehicles WHERE VIN = @VIN;

	COMMIT TRANSACTION
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelect')
		DROP PROCEDURE VehiclesSelect
GO

CREATE PROCEDURE VehiclesSelect(
	@VIN char(20)
) AS
BEGIN
	SELECT VIN, VehicleYear, MakeId, ModelId, BodyStyleId, TransmissionId, ColorId, InteriorId,
		Mileage, SalePrice, MSRP, VehicleDescription, ImageFileName, IsFeatured, IsPurchased
	FROM Vehicles
	WHERE VIN = @VIN
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectFeatured')
		DROP PROCEDURE VehiclesSelectFeatured
GO

CREATE PROCEDURE VehiclesSelectFeatured AS
BEGIN
	SELECT TOP 6 VIN, VehicleYear, v.MakeId, MakeName, v.ModelId, ModelName, SalePrice, ImageFileName
	FROM Vehicles v
	INNER JOIN Makes m ON v.MakeId = m.MakeId
	INNER JOIN Models mo ON v.ModelId = mo.ModelId
	WHERE IsFeatured = 1 
	ORDER BY SalePrice DESC
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectDetails')
		DROP PROCEDURE VehiclesSelectDetails
GO

CREATE PROCEDURE VehiclesSelectDetails(
	@VIN char(20)
) AS
BEGIN
	SELECT  VIN, VehicleYear, v.MakeId, MakeName, v.ModelId, ModelName, b.BodyStyleId, BodyStyleName, 
			v.ColorId, ColorName, v.TransmissionId, TransmissionName, v.InteriorId, InteriorName, 
			Mileage, SalePrice, MSRP, ImageFileName, VehicleDescription, IsFeatured
	FROM Vehicles v
	INNER JOIN BodyStyles b on v.BodyStyleId = b.BodyStyleId
	INNER JOIN Colors c on v.ColorId = c.ColorId
	INNER JOIN Transmissions t ON v.TransmissionId = t.TransmissionId
	INNER JOIN Interiors i ON v.InteriorId = i.InteriorId
	INNER JOIN Makes m ON v.MakeId = m.MakeId
	INNER JOIN Models mo ON v.ModelId = mo.ModelId
	WHERE VIN = @VIN
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectInventory')
		DROP PROCEDURE VehiclesSelectInventory
GO
--Combine the rows if make, model, and year are the same, add the saleprice to be new column StockValue
--add new column Count for how many are the same.

CREATE PROCEDURE VehiclesSelectInventory AS
BEGIN
	SELECT COUNT(v.ModelId) VehicleCount, SUM(SalePrice) StockValue, VehicleYear, 
		MakeName, ModelName
	FROM Vehicles v
	INNER JOIN Makes m ON v.MakeId = m.MakeId
	INNER JOIN Models mo ON v.ModelId = mo.ModelId
	WHERE IsPurchased = 0 
	--AND VehicleYear = 2022
	GROUP BY MakeName, ModelName, VehicleYear
	ORDER BY VehicleYear DESC
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SalesSelectReport')
		DROP PROCEDURE SalesSelectReport
GO
--make rows combine for totalSales and totalVehicles

CREATE PROCEDURE SalesSelectReport AS
BEGIN
	SELECT CONCAT(u.FirstName, ' ', u.LastName) UserName, 
		ISNULL(SUM(PurchasePrice),0) TotalSales,
		Count(VIN) TotalVehicles
	FROM Users u
	LEFT JOIN VehicleSales vs ON u.UserId = vs.UserId
	GROUP BY u.FirstName, u.LastName
	ORDER BY TotalSales DESC
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersInsert')
		DROP PROCEDURE UsersInsert
GO

CREATE PROCEDURE UsersInsert(
	@UserId int output,
	@FirstName varchar(50),
	@LastName varchar(50),
	@Email varchar(250),
	@UserRole varchar(50)
) AS
BEGIN
	INSERT INTO Users(FirstName, LastName, Email, UserRole)
		VALUES(@FirstName, @LastName, @Email, @UserRole)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersDelete')
		DROP PROCEDURE UsersDelete
GO

CREATE PROCEDURE UsersDelete(
	@UserId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Users WHERE UserId = @UserId;

	COMMIT TRANSACTION
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersSelectAll')
		DROP PROCEDURE UsersSelectAll
GO

CREATE PROCEDURE UsersSelectAll AS
BEGIN
	SELECT UserId, FirstName, LastName, Email, UserRole
	FROM Users
	ORDER BY LastName
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersSelectById')
		DROP PROCEDURE UsersSelectById
GO

CREATE PROCEDURE UsersSelectById(
	@UserId int
)AS
BEGIN
	SELECT UserId, FirstName, LastName, Email, UserRole
	FROM Users
	WHERE @UserId = UserId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersUpdate')
		DROP PROCEDURE UsersUpdate
GO

CREATE PROCEDURE UsersUpdate(
	@UserId int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@Email varchar(250),
	@UserRole varchar(50)
) AS
BEGIN
	UPDATE Users SET
		FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		UserRole = @UserRole
	WHERE UserId = @UserId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakesInsert')
		DROP PROCEDURE MakesInsert
GO

CREATE PROCEDURE MakesInsert(
	@MakeId int output,
	@MakeName varchar(20),
	@MakeDateAdded datetime,
	@UserId int
) AS
BEGIN
	INSERT INTO Makes(MakeName, MakeDateAdded, UserId)
		VALUES(@MakeName, @MakeDateAdded, @UserId)
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelsInsert')
		DROP PROCEDURE ModelsInsert
GO

CREATE PROCEDURE ModelsInsert(
	@ModelId int output,
	@MakeId int,
	@ModelName varchar(50),
	@ModelDateAdded datetime,
	@UserId int
) AS
BEGIN
	INSERT INTO Models(MakeId, ModelName, ModelDateAdded, UserId)
		VALUES(@MakeId, @ModelName, @ModelDateAdded, @UserId)
END
GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectAll')
		DROP PROCEDURE VehiclesSelectAll
GO

CREATE PROCEDURE VehiclesSelectAll AS
BEGIN
	SELECT TOP 20 VIN, VehicleYear, v.MakeId, MakeName, v.ModelId, ModelName,
		v.BodyStyleId, BodyStyleName, v.TransmissionId, TransmissionName,
		v.ColorId, ColorName, v.InteriorId, InteriorName,
		Mileage, SalePrice, MSRP, VehicleDescription, ImageFileName, IsFeatured, IsPurchased
	FROM Vehicles v
	INNER JOIN BodyStyles b ON v.BodyStyleId = b.BodyStyleId
	INNER JOIN Transmissions t ON v.TransmissionId = t.TransmissionId
	INNER JOIN Colors c ON v.ColorId = c.ColorId
	INNER JOIN Interiors i ON v.InteriorId = i.InteriorId
	INNER JOIN Makes m ON v.MakeId = m.MakeId
	INNER JOIN Models mo ON v.ModelId = mo.ModelId
	WHERE IsPurchased = 0
	ORDER BY MSRP DESC
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectAllNew')
		DROP PROCEDURE VehiclesSelectAllNew
GO

CREATE PROCEDURE VehiclesSelectAllNew AS
BEGIN
	SELECT TOP 20 VIN, VehicleYear, v.MakeId, MakeName, v.ModelId, ModelName, v.BodyStyleId, 
		BodyStyleName, v.TransmissionId, TransmissionName,
		v.ColorId, ColorName, v.InteriorId, InteriorName,
		Mileage, SalePrice, MSRP, VehicleDescription, ImageFileName, IsFeatured, IsPurchased
	FROM Vehicles v
	INNER JOIN BodyStyles b ON v.BodyStyleId = b.BodyStyleId
	INNER JOIN Transmissions t ON v.TransmissionId = t.TransmissionId
	INNER JOIN Colors c ON v.ColorId = c.ColorId
	INNER JOIN Interiors i ON v.InteriorId = i.InteriorId
	INNER JOIN Makes m ON v.MakeId = m.MakeId
	INNER JOIN Models mo ON v.ModelId = mo.ModelId
	WHERE IsPurchased = 0 AND VehicleYear = 2022
	ORDER BY MSRP DESC
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectAllUsed')
		DROP PROCEDURE VehiclesSelectAllUsed
GO

CREATE PROCEDURE VehiclesSelectAllUsed AS
BEGIN
	SELECT TOP 20 VIN, VehicleYear, v.MakeId, MakeName, v.ModelId, ModelName,
		v.BodyStyleId, BodyStyleName, v.TransmissionId, 
		TransmissionName, v.ColorId, ColorName, v.InteriorId, InteriorName,
		Mileage, SalePrice, MSRP, VehicleDescription, ImageFileName, IsFeatured, IsPurchased
	FROM Vehicles v
	INNER JOIN BodyStyles b ON v.BodyStyleId = b.BodyStyleId
	INNER JOIN Transmissions t ON v.TransmissionId = t.TransmissionId
	INNER JOIN Colors c ON v.ColorId = c.ColorId
	INNER JOIN Interiors i ON v.InteriorId = i.InteriorId
	INNER JOIN Makes m ON v.MakeId = m.MakeId
	INNER JOIN Models mo ON v.ModelId = mo.ModelId
	WHERE IsPurchased = 0 AND VehicleYear < 2022
	ORDER BY MSRP DESC
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactsInsert')
		DROP PROCEDURE ContactsInsert
GO

CREATE PROCEDURE ContactsInsert(
	@ContactId int output,
	@ContactName varchar(125),
	@ContactEmail varchar(50),
	@ContactPhone varchar(15),
	@ContactMessage varchar(1000)
) AS
BEGIN
	INSERT INTO Contacts(ContactName, ContactEmail, ContactPhone, ContactMessage)
		VALUES(@ContactName, @ContactEmail, @ContactPhone, @ContactMessage);
	SET @ContactId = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SelectMinimumYear')
		DROP PROCEDURE SelectMinimumYear
GO

CREATE PROCEDURE SelectMinimumYear AS
BEGIN
	SELECT TOP 1 VehicleYear FROM Vehicles
	ORDER BY VehicleYear 
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsSelectAll')
		DROP PROCEDURE SpecialsSelectAll
GO

CREATE PROCEDURE SpecialsSelectAll AS
BEGIN
	SELECT SpecialTitle, SpecialDescription
	FROM Specials
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsInsert')
		DROP PROCEDURE SpecialsInsert
GO

CREATE PROCEDURE SpecialsInsert(
	@SpecialId int output,
	@SpecialTitle varchar(20),
	@SpecialDescription varchar(1000)
) AS
BEGIN
	INSERT INTO Specials(SpecialTitle, SpecialDescription)
		VALUES(@SpecialTitle, @SpecialDescription)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsDelete')
		DROP PROCEDURE SpecialsDelete
GO

CREATE PROCEDURE SpecialsDelete(
	@SpecialId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Specials WHERE SpecialId = @SpecialId;

	COMMIT TRANSACTION
END
GO




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSalesInsert')
		DROP PROCEDURE VehicleSalesInsert
GO

CREATE PROCEDURE VehicleSalesInsert(
	@SaleId int output,
	@VIN char(20),
	@UserId int,
	@BuyerId int,
	@PurchasePrice decimal(7,2),
	@PurchaseType varchar(15),
	@SaleDate datetime2(7)
) AS
BEGIN
	INSERT INTO VehicleSales(VIN, UserId, BuyerId, PurchasePrice, PurchaseType, SaleDate)
		VALUES(@VIN, @UserId, @BuyerId, @PurchasePrice, @PurchaseType, @SaleDate);
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BuyersInsert')
		DROP PROCEDURE BuyersInsert
GO

CREATE PROCEDURE BuyersInsert(
	@BuyerId int output,
	@BuyerName varchar(100),
	@BuyerEmail varchar(50),
	@BuyerPhone varchar(15),
	@Street1 varchar(50),
	@Street2 varchar(50),
	@BuyerCity varchar(50),
	@StateId char(2),
	@BuyerZipcode int
) AS
BEGIN
	INSERT INTO Buyers(BuyerName, BuyerEmail, BuyerPhone, Street1, Street2, BuyerCity, StateId, BuyerZipcode)
		VALUES(@BuyerName, @BuyerEmail, @BuyerPhone, @Street1, @Street2, @BuyerCity, @StateId, @BuyerZipcode)
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BuyersSelect')
		DROP PROCEDURE BuyersSelect
GO

CREATE PROCEDURE BuyersSelect(
	@BuyerName varchar(100)
) AS
BEGIN
	SELECT BuyerId, BuyerName, BuyerEmail, BuyerPhone, Street1, Street2, BuyerCity, StateId, BuyerZipcode
	FROM Buyers
	WHERE BuyerName = @BuyerName
END
GO

