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
         _connectionString= string.Empty; 
        }
        public static SqlDao GetInstance()
        {
          if (_instance == null)
            {
                _instance = new SqlDao();
            }
            return _instance;
        }
        public void executeprocess(SqlOperation Operation)
        {
            
        }
        public List<Dictionary<string,object>> ExecuteQueryprocess(SqlOperation Operation)
        {
            var list = new List<Dictionary<string, object>>();
            return list;
        }
    }
}
