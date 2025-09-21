
CREATE PROCEDURE CRE_USER_PR
	@P_UserCode nvarchar(25),
	@P_Name nvarchar(50),
	@P_Email nvarchar(50),
	@P_Password nvarchar(20),
	@P_BirthDate datetime,
	@P_Status nvarchar(2)
	AS
	BEGIN

	INSERT INTO tblUsers(Created, UserCode, Name, Email, Password, Birthdate,Status)
	VALUES(GETDATE(),@P_UserCode, @P_Name, @P_Email, @P_Password, @P_BirthDate, @P_Status);

	END
	GO