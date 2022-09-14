USE HotelReservationSchema;
GO

--1 Write a query that returns a list of reservations that end in July 2023, including the name of the guest, the room number(s), and the reservation dates.
SELECT
	CONCAT(G.FirstName, G.LastName) GuestName,
	Reservation.RoomNumber,
	Reservation.CheckInDate,
	Reservation.CheckOutDate
FROM
	Guest G
INNER JOIN Reservation ON G.GuestId = Reservation.GuestId
WHERE MONTH(Reservation.CheckOutDate) = 7
	AND YEAR(Reservation.CheckOutDate) = 2023
--GROUP BY G.LastName, G.FirstName, Reservation.RoomNumber, Reservation.CheckInDate, Reservation.CheckOutDate
ORDER BY  Reservation.CheckOutDate;

--LauraWelfley	205	2023-06-28	2023-07-02
--WalterHolaway	204	2023-07-13	2023-07-14
--WilfredVise	401	2023-07-18	2023-07-21
--BettyannSeery	303	2023-07-28	2023-07-29

--2 Write a query that returns a list of all reservations for rooms with a jacuzzi, displaying the guest's name, the room number, and the dates of the reservation.
SELECT 
	CONCAT(G.FirstName, G.LastName) AS GuestName,
	Res.RoomNumber,
	Res.CheckInDate,
	Res.CheckOutDate,
	rt.Jacuzzi
FROM Reservation Res
INNER JOIN Guest G ON Res.GuestId = G.GuestId
INNER JOIN RoomAssignment ra ON Res.ReservationId = ra.ReservationId
INNER JOIN Room R ON ra.RoomId = R.RoomId
INNER JOIN RoomType rt ON R.RoomTypeId = rt.RoomTypeId
WHERE rt.Jacuzzi = 1;
--GROUP BY rt.RoomTypeId, G.GuestId, Res.ReservationId, G.FirstName, G.LastName, Res.RoomNumber, Res.CheckInDate, Res.CheckOutDate;

--	KarieYang	201	2023-03-06	2023-03-07	1
--BettyannSeery	203	2023-02-05	2023-02-10	1
--KarieYang	203	2023-09-13	2023-09-15	1
--LauraWelfley	205	2023-06-28	2023-07-02	1
--WilfredVise	207	2023-04-23	2023-04-24	1
--WalterHolaway	301	2023-04-09	2023-04-13	1
--MackSimmer	301	2023-11-22	2023-11-25	1
--BettyannSeery	303	2023-07-28	2023-07-29	1
--DuaneCullison	305	2023-02-22	2023-02-24	1
--BettyannSeery	305	2023-08-30	2023-09-01	1
--LauraWelfley	307	2023-03-17	2023-03-20	1

--3 Write a query that returns all the rooms reserved for a specific guest, including the guest's name, the room(s) reserved, the starting date of the reservation, and how many people were included in the reservation. (Choose a guest's name from the existing data.)
SELECT 
	CONCAT(G.FirstName, G.LastName) GuestName,
	Res.RoomNumber,
	rt.TypeName,
	Res.CheckInDate,
	Res.CheckInDate,
	Res.NumberOfAdults,
	Res.NumberOfChildren
FROM Reservation Res
INNER JOIN Guest G ON Res.GuestId = G.GuestId
INNER JOIN RoomAssignment ra ON Res.ReservationId = ra.ReservationId
INNER JOIN Room r ON ra.RoomId = r.RoomId
INNER JOIN RoomType rt ON r.RoomTypeId = rt.RoomTypeId
WHERE G.GuestId=4
--GROUP BY G.LastName, Res.CheckInDate, G.FirstName, Res.RoomNumber, Res.NumberOfAdults, Res.NumberOfChildren, rt.TypeName;

--DuaneCullison	305	2023-02-22	2023-02-22	2	0
--DuaneCullison	401	2023-11-22	2023-11-22	2	2


--4 Write a query that returns a list of rooms, reservation ID, and per-room cost for each reservation. The results should include all rooms, whether or not there is a reservation associated with the room.
SELECT
	r.RoomNumber,
	Res.ReservationId,
	(rt.BasePrice + (rt.AdditionalAdultCost*Res.ExtraPersons)) AS TotalRoomCost
FROM RoomType rt
LEFT OUTER JOIN Room r ON rt.RoomTypeId = r.RoomTypeId
LEFT OUTER JOIN RoomAssignment ra ON r.RoomId = ra.RoomId
LEFT OUTER JOIN Reservation Res ON ra.ReservationId = Res.ReservationId

ORDER BY Res.RoomNumber;

--306	NULL	NULL
--402	NULL	NULL
--201	4	179.99
--202	7	179.99
--203	2	179.99
--203	21	179.99
--204	16	189.99
--205	15	NULL
--206	12	NULL
--206	23	NULL
--207	10	NULL
--208	13	NULL
--208	20	NULL
--301	9	179.99
--301	24	179.99
--302	6	189.99
--302	25	179.99
--303	18	179.99
--304	8	179.99
--304	14	179.99
--305	3	NULL
--305	19	NULL
--307	5	NULL
--308	1	NULL
--401	11	399.99
--401	17	399.99
--401	22	399.99


--5 Write a query that returns all the rooms accommodating at least three guests and that are reserved on any date in April 2023.
SELECT
	G.GuestId,
	Res.ReservationId,
	Res.RoomNumber,
	Res.CheckInDate,
	Res.CheckOutDate,
	SUM(Res.NumberOfAdults+Res.NumberOfChildren) AS NumberOfGuests
FROM Guest G
INNER JOIN Reservation Res ON G.GuestId = Res.GuestId
WHERE MONTH(Res.CheckInDate) = 04
	AND YEAR(Res.CheckInDate) = 2023
GROUP BY G.GuestId, Res.ReservationId, Res.RoomNumber, Res.CheckInDate, Res.CheckOutDate
HAVING SUM(Res.NumberOfAdults+Res.NumberOfChildren)>=3
ORDER BY Res.CheckInDate, Res.CheckOutDate;

--empty

--6 Write a query that returns a list of all guest names and the number of reservations per guest, sorted starting with the guest with the most reservations and then by the guest's last name.
SELECT 
	--DISTINCT 
	G.FirstName,
	G.LastName,
	(SELECT COUNT(*)
		FROM Reservation 
		WHERE GuestId = G.GuestId) AS NumberOfReservations
FROM Guest G
--INNER JOIN Reservation Res ON G.GuestId = Res.GuestId;

--Aurore	Lipton	2
--Bettyann	Seery	3
--Duane	Cullison	2
--Jeremiah	Pendergrass	1
--Joleen	Tison	2
--Karie	Yang	2
--Laura	Welfley	2
--Mack	Simmer	4
--Maritza	Tilton	2
--Walter	Holaway	2
--Wilfred	Vise	2
--Zachery	Luechtefeld	1

--7 Write a query that displays the name, address, and phone number of a guest based on their phone number. (Choose a phone number from the existing data.)
SELECT 
	Guest.FirstName,
	Guest.LastName,
	Guest.Address,
	Guest.City,
	Guest.StateAbbr,
	Guest.PrimaryPhone
FROM Guest
WHERE Guest.PrimaryPhone = '834-727-1001';

--Wilfred	Vise	77 West Surrey Street	Oswego	NY	834-727-1001