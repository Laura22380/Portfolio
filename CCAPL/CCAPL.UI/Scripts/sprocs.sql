USE CCAPLDB
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MembersSelectAll')
		DROP PROCEDURE MembersSelectAll
GO

CREATE PROCEDURE MembersSelectAll AS
BEGIN
	SELECT MemberId, MemberFirstName, MemberLastName, MemberPhone, MemberEmail
	FROM Members
	ORDER BY MemberLastName
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MembersSelect')
		DROP PROCEDURE MembersSelect
GO

CREATE PROCEDURE MembersSelect(
	@MemberId int
) AS
BEGIN
	SELECT MemberId, MemberFirstName, MemberLastName, MemberPhone, MemberEmail
	FROM Members
	WHERE MemberId = @MemberId
END
GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MembersInsert')
		DROP PROCEDURE MembersInsert
GO

CREATE PROCEDURE MembersInsert(
	@MemberId int output,
	@MemberFirstName varchar(15),
	@MemberLastName varchar(15),
	@MemberEmail varchar(25),
	@MemberPhone varchar(15)
) AS
BEGIN
	INSERT INTO Members(MemberFirstName, MemberLastName, MemberEmail, MemberPhone)
		VALUES(@MemberFirstName, @MemberLastName, @MemberEmail, @MemberPhone)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TributesSelectAll')
		DROP PROCEDURE TributesSelectAll
GO

CREATE PROCEDURE TributesSelectAll AS
BEGIN
	SELECT TributeId, TributeMessage, DonationAmount, MemberId, CreatedDate
	FROM Tributes
	ORDER BY CreatedDate
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TributesSelect')
		DROP PROCEDURE TributesSelect
GO

CREATE PROCEDURE TributesSelect(
	@TributeId int
) AS
BEGIN
	SELECT TributeId, TributeMessage, DonationAmount, MemberId, CreatedDate
	FROM Tributes
	WHERE TributeId = @TributeId
END
GO
