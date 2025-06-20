CREATE PROCEDURE [dbo].[RET_USER_BY_ID_PR]
@P_ID INT
AS
BEGIN
    Select Id,Created,Updated,UserCode,Name,Email,Password,BirthDate,Status
	From TBL_User
	WHERE ID=@P_ID;
END
