--SP para crear un usuario
CREATE PROCEDURE CRE_MOVIE_PR

   @P_Title nvarchar(75),
   @P_Desc nvarchar(250),
   @P_ReleaseDate Datetime,
   @P_Genre nvarchar(20),
   @P_Director nvarchar(30)
   AS
BEGIN
	insert into TBL_Movie(created,Title,Description,ReleaseDate,Genre,Director)
	values(GETDATE(),@P_Title,@P_Desc,@P_ReleaseDate,@P_Genre,@P_Director);
END
GO
