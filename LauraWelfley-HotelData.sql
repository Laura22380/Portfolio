USE HotelReservationSchema;
GO

INSERT INTO State (StateAbbr, Name)
	VALUES ('AL','ALABAMA'),
	('AK','ALASKA'),
	('AB','ALBERTA'),
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
	('NT','NORTHWEST TERRITORIES'),
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
	('WY','WYOMING');
SELECT * FROM State;

INSERT INTO RoomType (TypeName, ADA, BasePrice, StandardOccupancy, MaximumOccupancy, AdditionalAdultCost, Jacuzzi)
	VALUES ('Single', 0, 149.99, 2, 2, NULL, 1),
		('Single', 1, 149.99, 2, 2, NULL, 0),
		('Double', 0, 179.99, 2, 4, 10.00, 1),
		('Double', 1, 179.99, 2, 4, 10.00, 0),
		('Suite', 1, 399.99, 3, 8, 20.00, 0);
SELECT * FROM RoomType;

INSERT INTO Guest (FirstName, LastName, Address, City, StateAbbr, PostalCode, PrimaryPhone)
	VALUES ('Laura', 'Welfley', '123 State St.', 'Dover', 'OH', '44622', '330-987-2028'),
			('Mack', 'Simmer', '379 Old Shore Street', 'Council Bluffs', 'IA', '51501',	'291-553-0508'),
			('Bettyann', 'Seery', '750 Wintergreen Dr.', 'Wasilla', 'AK', '99654', '478-277-9632'),
			('Duane', 'Cullison', '9662 Foxrun Lane', 'Harlingen', 'TX', '78552', '3084940198'),
			('Karie', 'Yang', '9378 W. Augusta Ave.', 'West Deptford', 'NJ', '08096', '214-730-0298'),
			('Aurore', 'Lipton', '762 Wild Rose Street', 'Saginaw', 'MI', '48601', '377-507-0974'),
			('Zachery', 'Luechtefeld', '7 Poplar Dr.', 'Arvada', 'CO', '80003', '814-485-2615'),
			('Jeremiah', 'Pendergrass',	'70 Oakwood St.', 'Zion', 'IL', '60099', '279-491-0960'),
			('Walter', 'Holaway', '7556 Arrowhead St.', 'Cumberland', 'RI', '02864', '446-396-6785'),
			('Wilfred', 'Vise', '77 West Surrey Street', 'Oswego', 'NY', '13126', '834-727-1001'),
			('Maritza', 'Tilton', '939 Linda Rd.', 'Burke', 'VA', '22015', '446-351-6860'),
			('Joleen', 'Tison', '87 Queen St.', 'Drexel Hill', 'PA', '19026', '231-893-2755');
SELECT *
FROM Guest;


INSERT INTO Ammenity (Description)
	VALUES ('Microwave'),
		('Refrigerator'),
		('Microwave/Refrigerator'),
		('Full kitchen');
SELECT * FROM Ammenity;

SET IDENTITY_INSERT Room ON;
INSERT INTO Room (RoomId, RoomNumber, RoomTypeId)
	VALUES (201, 201, 3),
			(202, 202, 4),
			(203, 203, 3),
			(204, 204, 4),
			(205, 205, 1),
			(206, 206, 2),
			(207, 207, 1),
			(208, 208, 2),
			(301, 301, 3),
			(302, 302, 4),
			(303, 303, 3),
			(304, 304, 4),
			(305, 305, 1),
			(306, 306, 2),
			(307, 307, 1),
			(308, 308, 2),
			(401, 401, 5),
			(402, 402, 5);
SET IDENTITY_INSERT Room OFF;
SELECT * FROM Room;

INSERT INTO Reservation (GuestId, RoomNumber, NumberOfAdults, NumberOfChildren, CheckInDate, CheckOutDate, ExtraPersons)
	VALUES (2, 308, 1, 0, '2023-02-02', '2023-02-04', 0),
			(3, 203, 2, 1, '2023-02-05', '2023-02-10', 0),
			(4, 305, 2, 0, '2023-02-22', '2023-02-24', 0),
			(5, 201, 2, 2, '2023-03-06', '2023-03-07', 0),
			(1, 307, 1, 1, '2023-03-17', '2023-03-20', 0),
			(6, 302, 3, 0, '2023-03-18', '2023-03-23', 1),
			(7, 202, 2, 2, '2023-03-29', '2023-03-31', 0),
			(8, 304, 2, 0, '2023-03-31', '2023-04-05', 0),
			(9, 301, 1, 0, '2023-04-09', '2023-04-13', 0),
			(10, 207, 1, 1, '2023-04-23', '2023-04-24', 0),
			(11, 401, 2, 4, '2023-05-30', '2023-06-02', 0),
			(12, 206, 2, 0, '2023-06-10', '2023-06-14', 0),
			(12, 208, 1, 0, '2023-06-23', '2023-06-14', 0),
			(6, 304, 3, 0, '2023-06-17', '2023-06-18', 0),
			(1, 205, 2, 0, '2023-06-28', '2023-07-02', 0),
			(9, 204, 3, 1, '2023-07-13', '2023-07-14', 1),
			(10, 401, 4, 2, '2023-07-18', '2023-07-21', 0),
			(3, 303, 2, 1, '2023-07-28', '2023-07-29', 0),
			(3, 305, 1, 0, '2023-08-30', '2023-09-01', 0),
			(2, 208, 2, 0, '2023-09-16', '2023-09-17', 0),
			(5, 203, 2, 2, '2023-09-13', '2023-09-15', 0),
			(4, 401, 2, 2, '2023-11-22', '2023-11-25', 0),
			(2, 206, 2, 0, '2023-11-22', '2023-11-25', 0),
			(2, 301, 2, 2, '2023-11-22', '2023-11-25', 0),
			(11, 302, 2, 0, '2023-12-24', '2023-12-28', 0);
SELECT * FROM Reservation;

INSERT INTO RoomAssignment(RoomId, ReservationId, GuestId)
	VALUES (308, 1, 2),
			(203, 2, 3),
			(305, 3, 4),
			(201, 4, 5),
			(307, 5, 1),
			(302, 6, 6),
			(202, 7, 7),
			(304, 8, 8),
			(301, 9, 9),
			(207, 10, 10),
			(401, 11, 11),
			(206, 12, 12),
			(208, 13, 12),
			(304, 14, 6),
			(205, 15, 1),
			(204, 16, 9),
			(401, 17, 10),
			(303, 18, 3),
			(305, 19, 3),
			(208, 20, 2),
			(203, 21, 5),
			(401, 22, 4),
			(206, 23, 2),
			(301, 24, 2),
			(302, 25, 11);

SELECT * FROM Reservation WHERE Reservation.GuestId = 8;
DELETE FROM Reservation
	WHERE Reservation.GuestId = 8;
DELETE FROM Guest
	WHERE Guest.GuestId = 8;