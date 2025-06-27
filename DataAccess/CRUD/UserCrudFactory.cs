using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {
        public UserCrudFactory()
        {
            _sqlDao = SqlDao.GetInstance();
        }
        public override void Create(BaseDTOs baseDTO)
        {
            var user = baseDTO as User;
            var sqlOperation = new SqlOperation() { ProcedureName = "CRE_USER_PR" };

            sqlOperation.AddStringParameter("P_UserCode", user.Usercode);
            sqlOperation.AddStringParameter("P_Name", user.Name);
            sqlOperation.AddStringParameter("P_Email", user.Email);
            sqlOperation.AddStringParameter("P_Password", user.Password);
            sqlOperation.AddStringParameter("P_Status", user.status);
            sqlOperation.AddDateTimeParam("P_BirthDate", user.DateOfBirth);
            
            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTOs baseDTO)
        {
            var user = baseDTO as User;
            var sqlOperation = new SqlOperation() { ProcedureName = "DEL_USER_PR" };
            sqlOperation.AddIntParam("P_ID", user.Id);
            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrive<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetriveAll<T>()
        {
            var lstUsers = new List<T>();

            var sqlOperation = new SqlOperation() { ProcedureName = "RET_ALL_USERS_PR" };
            var lstResult = _sqlDao.ExecuteQueryprocess(sqlOperation);
            if (lstResult.Count > 0)
            {
                foreach(var row in lstResult)
                {
                    var user = BuildUser(row);
                    lstUsers.Add((T)Convert.ChangeType(user,typeof(T)));
                }
            }
            return lstUsers;
        }

        public override T RetriveById<T>(int id)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_USER_BY_ID_PR" };
            sqlOperation.AddIntParam("P_ID", id);

            var lstResult = _sqlDao.ExecuteQueryprocess(sqlOperation);
            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var user = BuildUser(row);

                return (T)Convert.ChangeType(user, typeof(T));
            }
            return default(T);
        }
        public T RetriveByUserCode<T>(User user)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_USER_BY_CODE_PR" };
            sqlOperation.AddStringParameter("P_CODE", user.Usercode);

            var lstResult = _sqlDao.ExecuteQueryprocess(sqlOperation);
             
            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var foundUser = BuildUser(row);
                return (T)Convert.ChangeType(foundUser, typeof(T));
            }
            return default(T);
        }

        public T RetriveByEmail<T>(User user)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_USER_BY_EMAIL_PR" };
            sqlOperation.AddStringParameter("P_EMAIL", user.Email);

            var lstResult = _sqlDao.ExecuteQueryprocess(sqlOperation);

            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var foundUser = BuildUser(row);
                return (T)Convert.ChangeType(foundUser, typeof(T));
            }
            return default(T);
        }


        public override void Update(BaseDTOs baseDTO)
        {
            var user = baseDTO as User;
            var sqlOperation = new SqlOperation() { ProcedureName = "UPD_USER_PR" };

            sqlOperation.AddIntParam("P_ID", user.Id);
            sqlOperation.AddStringParameter("P_UserCode", user.Usercode);
            sqlOperation.AddStringParameter("P_Name", user.Name);
            sqlOperation.AddStringParameter("P_Email", user.Email);
            sqlOperation.AddStringParameter("P_Password", user.Password);
            sqlOperation.AddStringParameter("P_Status", user.status);
            sqlOperation.AddDateTimeParam("P_BirthDate", user.DateOfBirth);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        private User BuildUser(Dictionary<string, object> row)
        {
            var user = new User()
            {
                Id=(int)row["Id"],
                CreatedAt= (DateTime)row["Created"],
                //UpdatedAt = (DateTime)row["Updated"],
                Usercode = (string)row["UserCode"],
                Name = (string)row["Name"],
                Email = (string)row["Email"],
                Password = (string)row["Password"],
                status = (string)row["Status"],
                DateOfBirth = (DateTime)row["BirthDate"]

            };
            return user;
        }
    }
}
