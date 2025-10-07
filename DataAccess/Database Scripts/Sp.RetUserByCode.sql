CREATE PROCEDURE RET_USER_BY_CODE_PR
@P_UserCode NVARCHAR(25)
AS
BEGIN
    SELECT 
        Id, 
        Created, 
        Updated, 
        UserCode, 
        Name,
        Email, 
        BirthDate, 
        Status
    FROM tblUsers
    WHERE UserCode = @P_UserCode;
END;