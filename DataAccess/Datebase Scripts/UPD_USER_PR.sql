CREATE PROCEDURE UPD_USER_PR
    @P_ID INT,
    @P_UserCode NVARCHAR(30),
    @P_Name NVARCHAR(50),
    @P_Email NVARCHAR(30),
    @P_Password NVARCHAR(50),
    @P_BirthDate DATETIME,
    @P_Status NVARCHAR(10)
AS
BEGIN
    UPDATE TBL_User
    SET
        Updated = GETDATE(),
        UserCode = @P_UserCode,
        Name = @P_Name,
        Email = @P_Email,
        Password = @P_Password,
        BirthDate = @P_BirthDate,
        Status = @P_Status
    WHERE Id = @P_ID;
END
GO
