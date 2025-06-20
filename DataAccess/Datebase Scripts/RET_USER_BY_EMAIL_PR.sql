CREATE PROCEDURE [dbo].[RET_USER_BY_EMAIL_PR]
@P_EMAIL nvarchar(30)
AS
BEGIN
    Select Id,Created,Updated,UserCode,Name,Email,Password,BirthDate,Status
	From TBL_User
	WHERE Email=@P_EMAIL;
END