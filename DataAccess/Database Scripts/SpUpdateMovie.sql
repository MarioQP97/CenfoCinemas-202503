CREATE PROCEDURE UPD_MOVIE_PR
    @P_ID INT,
    @P_Title NVARCHAR(100),
    @P_Description NVARCHAR(500),
    @P_ReleaseDate DATETIME,
    @P_Genre NVARCHAR(50),
    @P_Director NVARCHAR(100)
AS
BEGIN
    UPDATE tblMovies
    SET
        Title = @P_Title,
        Description = @P_Description,
        ReleaseDate = @P_ReleaseDate,
        Genre = @P_Genre,
        Director = @P_Director,
        Updated = GETDATE()
    WHERE Id = @P_ID;
END
GO