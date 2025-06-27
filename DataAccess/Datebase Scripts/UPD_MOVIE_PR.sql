CREATE PROCEDURE UPD_MOVIE_PR
    @P_ID INT,
    @P_Title NVARCHAR(75),
    @P_Desc NVARCHAR(250),
    @P_ReleaseDate DATETIME,
    @P_Genre NVARCHAR(20),
    @P_Director NVARCHAR(30)
AS
BEGIN
    UPDATE TBL_Movie
    SET
        Updated = GETDATE(),
        Title = @P_Title,
        Description = @P_Desc,
        ReleaseDate = @P_ReleaseDate,
        Genre = @P_Genre,
        Director = @P_Director
    WHERE Id = @P_ID;
END
GO
