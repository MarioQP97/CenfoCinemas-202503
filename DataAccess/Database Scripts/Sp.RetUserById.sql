CREATE PROCEDURE RET_USER_By_ID_PR
@P_ID INT
AS
BEGIN
	SELECT Id, Created, Updated, UserCode, Email, Password, BirthDate, Status
	From tblUsers
	WHERE Id=@P_ID;
END;