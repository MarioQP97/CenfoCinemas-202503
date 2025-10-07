/****** Object:  StoredProcedure [dbo].[UPD_USER_PR]    Script Date: 10/2/2025 4:26:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UPD_USER_PR]
@P_ID INT,
@P_UserCode nvarchar(30),
@P_Name nvarchar(50),
@P_Email nvarchar(30),
@P_Password nvarchar(50),
@P_BirthDate Datetime,
@P_Status nvarchar(10)

AS
BEGIN
	UPDATE tblUsers
		SET
			Name=@P_Name,
			Email=@P_Email,
			Password=@P_Password,
			BirthDate=@P_BirthDate,
			Status=@P_Status,
			UserCode=@P_UserCode
		WHERE ID=@p_ID;
END
