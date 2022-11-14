USE ClarityVentures

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'EmailLogInsert')
		DROP PROCEDURE EmailLogInsert
GO

CREATE PROCEDURE EmailLogInsert(
	@EmailId int output,
	@SenderEmail varchar(250),
	@Recipient varchar(250),
	@EmailSubject varchar(50),
	@Body varchar(3000),
	@SendDate datetime2,
	@SendStatus bit
) AS
BEGIN
	INSERT INTO EmailLog(SenderEmail, Recipient, EmailSubject, Body, SendDate, SendStatus)
		VALUES(@SenderEmail, @Recipient, @EmailSubject, @Body, @SendDate, @SendStatus)
END
GO

select * from EmailLog