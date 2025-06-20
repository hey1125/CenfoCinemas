CREATE PROCEDURE [dbo].[RET_USER_BY_CODE_PR]
@P_CODE nvarchar(30)
AS
BEGIN
    Select Id,Created,Updated,UserCode,Name,Email,Password,BirthDate,Status
	From TBL_User
	WHERE UserCode=@P_CODE;
END
