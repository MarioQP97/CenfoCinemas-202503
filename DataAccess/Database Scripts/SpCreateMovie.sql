CREATE PROCEDURE CRE_MOVIE_PR
    @P_Title NVARCHAR(100),
    @P_Description NVARCHAR(500),
    @P_ReleaseDate DATETIME,
    @P_Genre NVARCHAR(50),
    @P_Director NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tblMovies (Created, Title, Description, ReleaseDate, Genre, Director)
    VALUES (GETDATE(), @P_Title, @P_Description, @P_ReleaseDate, @P_Genre, @P_Director);
END
GO
