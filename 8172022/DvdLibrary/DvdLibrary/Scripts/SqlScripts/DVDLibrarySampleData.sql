USE DVDLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DVDLibrarySampleData')
		DROP PROCEDURE DVDLibrarySampleData
GO

CREATE PROCEDURE DVDLibrarySampleData AS
BEGIN

	DELETE FROM DVDs;

SET IDENTITY_INSERT DVDs ON;
	INSERT INTO DVDs(DvdId, Title, ReleaseYear, Director, Rating)
	VALUES(1, 'Superbad', 2007, 'Greg Mottola', 'R'),
		(2, 'Anchorman', 2004,'Adam McKay','PG-13'),
		(3, '300', 2007, 'Zack Snyder', 'R'),
		(4, 'Pain and Gain', 2013, 'Michael Bay', 'R'),
		(5, 'The Hangover', 2009, 'Todd Phillips', 'R'),
		(6, 'Ghostbusters', 1984, 'Ivan Reitman', 'PG'),
		(7, 'Finding Nemo', 2003, 'Andrew Stanton', 'G');
	SET IDENTITY_INSERT DVDs OFF;
END
GO