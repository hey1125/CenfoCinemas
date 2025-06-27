CREATE PROCEDURE RET_MOVIE_BY_ID_PR
    @P_ID INT
AS
BEGIN
    SELECT Id, Created, Updated, Title, Description, ReleaseDate, Genre, Director
    FROM TBL_Movie
    WHERE Id = @P_ID;
END
GO
