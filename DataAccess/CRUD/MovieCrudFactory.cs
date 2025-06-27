using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class MovieCrudFactory : CrudFactory
    {
        public MovieCrudFactory()
        {
            _sqlDao = SqlDao.GetInstance(); 
        }
        public override void Create(BaseDTOs baseDTO)
        {

            {
                var movie = baseDTO as Movies;
                var op = new SqlOperation { ProcedureName = "CRE_MOVIE_PR" };
                op.AddStringParameter("P_Title", movie.Title);
                op.AddStringParameter("P_Desc", movie.Description);
                op.AddDateTimeParam("P_ReleaseDate", movie.ReleaseDate);
                op.AddStringParameter("P_Genre", movie.Genre);
                op.AddStringParameter("P_Director", movie.Director);
                _sqlDao.ExecuteProcedure(op);
            }
        }

        public override void Delete(BaseDTOs baseDTO)
        {
            var movie = baseDTO as Movies;
            var op = new SqlOperation { ProcedureName = "DEL_MOVIE_PR" };
            op.AddIntParam("P_ID", movie.Id);
            _sqlDao.ExecuteProcedure(op);
        }

        public override T Retrive<T>()
        {
            {
                throw new NotImplementedException();
            }
        }

        public override List<T> RetriveAll<T>()
        {
            {
                var list = new List<T>();
                var op = new SqlOperation { ProcedureName = "RET_ALL_MOVIES_PR" };
                var results = _sqlDao.ExecuteQueryprocess(op);

                foreach (var row in results)
                {
                    var m = BuildMovie(row);
                    list.Add((T)Convert.ChangeType(m, typeof(T)));
                }

                return list;
            }
        }

        public override T RetriveById<T>(int id)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_MOVIE_BY_ID_PR" };
            sqlOperation.AddIntParam("P_ID", id);

            var lstResult = _sqlDao.ExecuteQueryprocess(sqlOperation);
            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var movie = BuildMovie(row);

                return (T)Convert.ChangeType(movie, typeof(T));
            }

            return default(T);
        }

        public override void Update(BaseDTOs baseDTO)
        {
            {
                var movie = baseDTO as Movies;
                var op = new SqlOperation { ProcedureName = "UPD_MOVIE_PR" };
                op.AddIntParam("P_ID", movie.Id);
                op.AddStringParameter("P_Title", movie.Title);
                op.AddStringParameter("P_Desc", movie.Description);
                op.AddDateTimeParam("P_ReleaseDate", movie.ReleaseDate);
                op.AddStringParameter("P_Genre", movie.Genre);
                op.AddStringParameter("P_Director", movie.Director);
                _sqlDao.ExecuteProcedure(op);
            }
        }

        private Movies BuildMovie(Dictionary<string, object> row)
        {
            return new Movies
            {
                Id = (int)row["Id"],
                CreatedAt = (DateTime)row["Created"],
                //UpdatedAt = (DateTime)row["Updated"],
                Title = (string)row["Title"],
                Description = (string)row["Description"],
                ReleaseDate = (DateTime)row["ReleaseDate"],
                Genre = (string)row["Genre"],
                Director = (string)row["Director"]
            };
        }
    }
}
