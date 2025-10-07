CREATE PROCEDURE RET_ALL_USER_PR
AS
BEGIN
	SELECT Id, Created, Updated, UserCode, Email, Password, BirthDate, Status
	From tblUsers;
END;