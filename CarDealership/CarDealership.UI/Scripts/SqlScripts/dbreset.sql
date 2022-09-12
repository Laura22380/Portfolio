IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GuildCarsDbReset')
		DROP PROCEDURE GuildCarsDbReset
GO

CREATE PROCEDURE GuildCarsDbReset AS
BEGIN

	DELETE FROM VehicleSales;
	--DELETE FROM Buyers;
	DELETE FROM Vehicles;

	--DBCC CHECKIDENT ('buyers', RESEED, 1);

	INSERT INTO Vehicles(VIN, VehicleYear, MakeId, ModelId, BodyStyleId, TransmissionId, ColorId, InteriorId,
		Mileage, SalePrice, MSRP, VehicleDescription, ImageFileName)
	VALUES('V1234TEST', 2010, 3, 7, 1, 1, 8, 1, '189000', '1800', '6800', 'Test vehicle.', 'silverSUV.jpg');
	INSERT INTO Vehicles(VIN, VehicleYear, MakeId, ModelId, BodyStyleId, TransmissionId, ColorId, InteriorId,
		Mileage, SalePrice, MSRP, VehicleDescription, ImageFileName, IsFeatured, IsPurchased)
	VALUES('V1112TEST0', 2022, 1, 1, 1, 1, 1, 1, 10, 60000, 80000, 'New vehicle good for traveling fast with only a couple people.', 'blackSUV.jpg', 1, 0),
		('V3333TEST0', 2022, 10, 4, 1, 1, 1, 1, '100', 18000, 68000, 'Fast, new car. Spacious trunk. Good features.', 'silverCar.jpg', 1, 0),
		('V2222TEST0', 2021, 3, 6, 2, 2, 2, 2, '5000', 6000, 9000, 'Dodge Dakota with low miles for a used vehicle.', 'usedSUV.jpg', 0, 0),
		('V1113TEST0', 2022, 3, 5, 1, 2, 1, 2, '10', 60000, 80000, 'Description of a really cool car.', 'bluecar.jpg', 0, 0),
		('V1114TEST0', 2011, 3, 9, 1, 1, 2, 1, '500000', 6000, 8000, 'Ford Explorer Lots of leg room.', 'usedSUV.jpg', 0, 0),
		('V1115TEST0', 2018, 7, 14, 3, 1, 1, 1, '40000', 16000, 18000, 'Description of a chevy.', 'silverSUV.jpg', 0, 0),
		('V1116TEST0', 2022, 10, 19, 2, 1, 2, 2, '10', 86000, 89000, 'GMC Description', 'blackCar.jpg', 1, 0),
		('V1117TEST0', 2021, 13, 22, 2, 2, 2, 2, '5000', 30000, 40000, 'Jeep Description', 'Jeep.jpg', 0, 0),
		('V1118TEST0', 2021, 16, 25, 1, 2, 7, 2, '56000', 62000, 68000, 'Firebird Description', 'silverCar.jpg', 0, 0),
		('V1119TEST0', 2019, 17, 27, 3, 1, 8, 1, '100000', 20000, 28000, 'Astra Description', 'blackCar.jpg', 0, 0),
		('V1120TEST0', 2022, 20, 31, 1, 1, 2, 1, '10', 89000, 90000, 'Prius Description', 'silverCar.jpg', 1, 0),
		('V1121TEST0', 2012, 13, 22, 1, 2, 7, 2, '500000', 6000, 8000, 'Jeep Cherokee good for offroad driving.', 'Jeep.jpg', 0, 0),
		('V1122TEST0', 2022, 21, 33, 1, 2, 6, 2, '10', 40000, 44000, 'XC40 newest model with all the specials equipped.', 'VW.jpg', 1, 0),
		('V1123TEST0', 2021, 3, 6, 1, 2, 4, 1, '5000', 62000, 68000, 'Ford comfortable driving model. One previous owner.', 'silverSUV.jpg', 0, 0),
		('V1124TEST0', 2020, 3, 1, 1, 2, 3, 1, '55000', 6000, 8000, 'Audi Description', 'bluecar.jpg', 0, 0),
		('V1125TEST0', 2017, 18, 29, 1, 2, 1, 2, '80000', 20000, 27000, 'Vehicle is reliable and good on fuel consumption.', 'usedSUV.jpg', 0, 0),
		('V1126TEST0', 2017, 18, 28, 1, 2, 5, 1, '80000', 20000, 27000, 'Vehicle with an automatic transmission.', 'usedSUV.jpg', 0, 0),
		('V1127TEST0', 2017, 19, 30, 2, 1, 1, 1, '80000', 20000, 27000, 'Vehicle Description', 'bluecar.jpg', 0, 0),
		('V1128TEST0', 2018, 1, 3, 1, 2, 1, 1, '80000', 20000, 27000, 'Vehicle Description', 'blackCar.jpg', 0, 0),
		('V1129TEST0', 2018, 2, 4, 1, 1, 1, 1, '80000', 20000, 27000, 'Panda Vehicle Description', 'silverCar.jpg', 0, 0),
		('V1130TEST0', 2015, 7, 15, 1, 2, 6, 2, '80000', 20000, 27000, 'Vehicle Description', 'usedSUV.jpg', 0, 0),
		('V1131TEST0', 2022, 4, 10, 3, 1, 7, 1, '80000', 20000, 27000, 'M3 Sedan Vehicle Description', 'VW.jpg', 0, 0),
		('V1132TEST0', 2021, 3, 8, 3, 1, 3, 1, '80000', 20000, 27000, 'EcoSport Vehicle Description', 'blackCar.jpg', 0, 0),
		('V1133TEST0', 2022, 4, 10, 3, 2, 7, 1, '80000', 20000, 27000, 'M3 Sedan 2 Vehicle Description', 'VW.jpg', 0, 0),
		('V1134TEST0', 2022, 9, 18, 1, 1, 2, 1, '80000', 20000, 27000, 'Durango Vehicle Description', 'silverCar.jpg', 0, 0),
		('V1135TEST0', 2022, 9, 18, 4, 1, 6, 1, '10', 90000, 97000, 'Four wheel drive truck to get you around any terrain.', 'fordTruck.jpg', 1, 0),
		('V1136TEST0', 2022, 9, 18, 4, 1, 2, 1, '10', 70000, 77000, 'Plenty of bed space for hauling materials.', 'chevyTruck.jpg', 0, 0),
		('V1137TEST0', 2022, 9, 18, 4, 1, 2, 1, '10', 80000, 87000, 'Comfortable for passengers and safe for all weather.', 'dodgeTruck.jpg', 1, 0),
		('V1138TEST0', 2021, 9, 18, 2, 1, 2, 1, '80000', 20000, 27000, 'Comfortable, all wheel drive, spacious.', 'silverCar.jpg', 0, 0);



	--INSERT INTO Buyers(FirstName, LastName, Street1, City, StateId, Zipcode)
		--VALUES('John', 'Doe', '123 Street Dr', 'Akron', 'OH', 44644);

	--INSERT INTO Contacts(UserId, ContactEmail, ContactPhone)
		--VALUES(1, 'contact@email.com', '330-333-3333');
END
GO