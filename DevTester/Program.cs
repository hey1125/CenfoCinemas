using DataAccess.DAO;
public class Program
{
    public static void Main(string[] args)
    {
        var sqlOperation = new SqlOperation();
        sqlOperation.ProcedureName = "CRE_USER_PR";
        sqlOperation.AddStringParameter("P_UserCode", "Dvalerio");
        sqlOperation.AddStringParameter("P_Name", "daniel");
        sqlOperation.AddStringParameter("P_Email", "jvalerioc@ucenfotec.ac.cr");
        sqlOperation.AddStringParameter("P_Password", "Daniel123!");
        sqlOperation.AddStringParameter("P_Status", "AC");
        sqlOperation.AddDateTimeParam("P_BirthDate", DateTime.Now); 

        var sqlDao = SqlDao.GetInstance();
        sqlDao.ExecuteProcedure(sqlOperation);


    }
}
