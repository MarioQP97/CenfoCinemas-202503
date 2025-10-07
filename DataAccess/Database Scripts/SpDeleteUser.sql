/****** Object:  StoredProcedure [dbo].[DEL_USER_PR]    Script Date: 10/2/2025 3:05:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DEL_USER_PR]
@P_ID INT

AS
BEGIN
	DELETE FROM tblUsers
	Where ID=@P_ID;
END
