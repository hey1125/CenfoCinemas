using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class SqlDao
    {
        private static SqlDao _instance;
        private string _connectionString;
        private SqlDao()
        {
         _connectionString= @"Data Source=srv-sqldatebase-dvalerio.database.windows.net;Initial Catalog=cenfocinemas-db;Persist Security Info=True;User ID=sysman;Password=Cenfotec123!;Trust Server Certificate=True"; 
        }
        public static SqlDao GetInstance()
        {
          if (_instance == null)
            {
                _instance = new SqlDao();
            }
            return _instance;
        }
        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    //Set de los parametros
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);
                    }
                    //Ejectura el SP
                    conn.Open();
                    command.ExecuteNonQuery();
                }

            }
        }
        public List<Dictionary<string,object>> ExecuteQueryprocess(SqlOperation Operation)
        {
            var list = new List<Dictionary<string, object>>();
            return list;
        }
    }
}
