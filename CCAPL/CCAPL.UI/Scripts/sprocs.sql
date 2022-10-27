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
