CREATE PROCEDURE RET_ALL_USERS_PR
AS
BEGIN
    SET NOCOUNT ON

    
    Select Id,Created,Updated,UserCode,Name,Email,Password,BirthDate,Status
	From TBL_User
END
GO
