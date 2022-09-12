USE DVDLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'RatingsSelectAll')
		DROP PROCEDURE RatingsSelectAll
GO

CREATE PROCEDURE RatingsSelectAll AS
BEGIN
	SELECT RatingId, Rating
	FROM Ratings
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsInsert')
		DROP PROCEDURE DvdsInsert
GO

CREATE PROCEDURE DvdsInsert  (
	@DvdId int output,
	@Title varchar(50),
	@ReleaseYear int,
	@Director varchar(50),
	@Rating varchar(5)
	)
AS
BEGIN
	INSERT INTO Dvds (DvdId, Title, ReleaseYear, Director, Rating)
	VALUES(@DvdId, @Title, @ReleaseYear, @Director, @Rating);

	SET @DvdId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsUpdate')
		DROP PROCEDURE DvdsUpdate
GO

CREATE PROCEDURE DvdsUpdate  (
	@DvdId int,
	@Title varchar(50),
	@ReleaseYear int,
	@Director varchar(50),
	@Rating varchar(5)
	)
AS
BEGIN
	UPDATE Dvds SET
		--DvdId = @DvdId, 
		Title = @Title, 
		ReleaseYear = @ReleaseYear, 
		Director = @Director, 
		Rating = @Rating 
	WHERE DvdId = @DvdId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsDelete')
		DROP PROCEDURE DvdsDelete
GO

CREATE PROCEDURE DvdsDelete  (
	@DvdId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Dvds WHERE DvdId = @DvdId;

	COMMIT TRANSACTION
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsSelect')
		DROP PROCEDURE DvdsSelect
GO

CREATE PROCEDURE DvdsSelect  (
	@DvdId int
) AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating
	FROM Dvds
	WHERE DvdId = @DvdId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsSelectAll')
		DROP PROCEDURE DvdsSelectAll
GO

CREATE PROCEDURE DvdsSelectAll AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating
	FROM Dvds
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsSelectAllByTitle')
		DROP PROCEDURE DvdsSelectAllByTitle
GO

CREATE PROCEDURE DvdsSelectAllByTitle (
	@Title varchar(50))
AS
BEGIN
	SELECT *
	FROM Dvds
	WHERE Title LIKE '%@Title%'
END
GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsSelectAllByYear')
		DROP PROCEDURE DvdsSelectAllByYear
GO

CREATE PROCEDURE DvdsSelectAllByYear (
	@ReleaseYear int)
AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating
	FROM Dvds
	WHERE ReleaseYear = @ReleaseYear
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsSelectAllByDirector')
		DROP PROCEDURE DvdsSelectAllByDirector
GO

CREATE PROCEDURE DvdsSelectAllByDirector (
	@Director varchar(50))
AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating
	FROM Dvds
	WHERE Director LIKE '%@Director%'
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsSelectAllByRating')
		DROP PROCEDURE DvdsSelectAllByRating
GO

CREATE PROCEDURE DvdsSelectAllByRating (
	@Rating varchar(5))
AS
BEGIN
	SELECT *
	FROM Dvds
	WHERE Rating = @Rating
END
GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'YearsSelect')
		DROP PROCEDURE YearsSelect
GO

CREATE PROCEDURE YearsSelect AS
BEGIN
INSERT INTO ReleaseYears
	VALUES (1980),(1981),(1982),(1983),(1984),(1985),(1986),(1987),(1988),(1989),
		(1990),(1991),(1992),(1993),(1994),(1995),(1996),(1997),(1998),(1999),
		(2000),(2001),(2002),(2003),(2004),(2005),(2006),(2007),(2008),(2009),
		(2010),(2011),(2012),(2013),(2014),(2015),(2016),(2017),(2018),(2019),
		(2020),(2021),(2022)
END
GO
