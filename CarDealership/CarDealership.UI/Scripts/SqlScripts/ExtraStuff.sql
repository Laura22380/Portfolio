
	INSERT INTO AspNetRoles
		VALUES(1, 'admin'),(2, 'sales');

		

	INSERT INTO AspNetUsers(Id, Email, EmailConfirmed, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, 
		LockoutEnabled, AccessFailedCount, UserName)
	VALUES('00000000-0000-0000-0000-000000000000', 'user@test.com', 0, '330-000-0000', 0, 0, 0, 0, 'test');


	--INSERT INTO AspNetUsers(Id, Email, EmailConfirmed, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, 
	--	LockoutEnabled, AccessFailedCount, UserName)
	INSERT INTO Users(FirstName, LastName, Email, UserRole)
		VALUES('Austyn', 'Hill', 'ahill@guildcars.com', 'Sales'),
			('Corbin', 'March', 'cmarch@guildcars.com', 'Sales'),
			('Victor', 'Pudelski', 'vpudelski@guildcars.com', 'Sales'),
			('Eric', 'Ward', 'eward@guildcars.com', 'Sales'),
			('Eric', 'Wise', 'ewise@guildcars.com', 'Admin');

SELECT TOP 1 VehicleYear FROM Vehicles
ORDER BY VehicleYear DESC


	SET IDENTITY_INSERT BodyStyles ON;

	INSERT INTO BodyStyles(BodyStyleId, BodyStyleName)
	VALUES(1, 'SUV'),
	(2, 'Van'),
	(3, 'Car'),
	(4, 'Truck');

	SET IDENTITY_INSERT BodyStyles OFF;


	INSERT INTO Colors(ColorName)
		VALUES('black'),('blue'),('beige'),('gray'),('green'),('maroon'),('red'),('silver'),('white');
	
	INSERT INTO Interiors(InteriorName)
		VALUES('black'),('tan');

	INSERT INTO Transmissions(TransmissionName)
		VALUES('automatic'),('manual');

	INSERT INTO States(StateId, StateName)
	VALUES ('AL','ALABAMA'),
		('AK','ALASKA'),
		('AS','AMERICAN SAMOA'),
		('AZ','ARIZONA'),
		('AR','ARKANSAS'),
		('BC','BRITISH COLUMBIA'),
		('CA','CALIFORNIA'),
		('PW','CAROLINE ISLANDS'),
		('CO','COLORADO'),
		('CT','CONNETICUT'),
		('DE','DELAWARE'),
		('DC','DISTRICT OF COLUMBIA'),
		('FM','FEDERATED STATE'),
		('FL','FLORIDA'),
		('GA','GEORGIA'),
		('GU','GUAM'),
		('HI','HAWAII'),
		('ID','IDOHA'),
		('IL','ILLINOIS'),
		('IN','INDIANA'),
		('IA','IOWA'),
		('KS','KANSAS'),
		('KY','KENTUCKY'),
		('LA','LOUSIANA'),
		('ME','MAINE'),
		('MB','MANITOBA'),
		('MP','MARIANA ISLANDS'),
		('MH','MARSHALL ISLANDS'),
		('MD','MARYLAND'),
		('MA','MASSACHUSETTS'),
		('MI','MICHIGAN'),
		('MN','MINNESOTA'),
		('MS','MISSISSIPPI'),
		('MO','MISSOURI'),
		('MT','MONTANA'),
		('NE','NEBRASKA'),
		('NV','NEVADA'),
		('NB','NEW BRUNSWICK'),
		('NH','NEW HAMPSHIRE'),
		('NJ','NEW JERSEY'),
		('NM','NEW MEXICO'),
		('NY','NEW YORK'),
		('NF','NEWFOUNDLAND'),
		('NC','NORTH CAROLINA'),
		('ND','NORTH DAKOTA'),
		('NT','NORTHWEST TERRITORY'),
		('NS','NOVA SCOTIA'),
		('NU','NUNAVUT'),
		('OH','OHIO'),
		('OK','OKLAHOMA'),
		('ON','ONTARIO'),
		('OR','OREGON'),
		('PA','PENNSYLVANIA'),
		('PE','PRINCE EDWARD ISLAND'),
		('PR','PUERTO RICO'),
		('PQ','QUEBEC'),
		('RI','RHODE ISLAND'),
		('SK','SASKATCHEWAN'),
		('SC','SOUTH CAROLINA'),
		('SD','SOUTH DAKOTA'),
		('TN','TENNESSEE'),
		('TX','TEXAS'),
		('UT','UTAH'),
		('VT','VERMONT'),
		('VI','VIRGIN ISLANDS'),
		('VA','VIRGINIA'),
		('WA','WASHINGTON'),
		('WV','WEST VIRGINIA'),
		('WI','WISCONSIN'),
		('WY','WYOMING'),
		('YT','YUKON TERRITORY');
		--('AE','ARMED FORCES - EUROPE'),
		--('AA','ARMED FORCES - AMERICAS'),
		--('AP','ARMED FORCES - PACIFIC');

INSERT INTO Specials(SpecialTitle, SpecialDescription)
	VALUES('Special 1', 'We have all new Ford SUVs on sale for 5% off with $0 down.'),
		('Special 2', 'For the next 7 days, all used cars available to drive off the lot TODAY.'),
		('Special 3', 'All cash payments receive a 2% discount on final price.'),
		('Special 4', 'We have all Subarus on sale to veterans. Ask about the specific details inside!'),
		('Special 5', 'Labor day sale! All new financing options. Starting at 0% APR. Inquire within to see all our financing options.');



SELECT 
	CONCAT(u.FirstName, ' ', u.LastName) UserName, 
	ISNULL(SUM(PurchasePrice),0) TotalSales, 
	Count(VIN) TotalVehicles 
FROM Users u LEFT JOIN VehicleSales vs ON u.UserId = vs.UserId 
WHERE 1=1 
AND SaleDate >= 0001-01-01
AND SaleDate <= 2022-09-07
AND CONCAT(u.FirstName, ' ', u.LastName) LIKE '% %'
GROUP BY u.FirstName, u.LastName 
ORDER BY TotalSales DESC 

