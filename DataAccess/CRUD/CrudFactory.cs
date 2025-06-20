using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public abstract class CrudFactory
    { 
        protected SqlDao _sqlDao;
        public abstract void Create(BaseDTOs baseDTO);

        public abstract void Update(BaseDTOs baseDTO);

        public abstract void Delete(BaseDTOs baseDTO);

        public abstract T Retrive<T>();
        public abstract T RetriveById<T>(int id);
        public abstract List<T> RetriveAll<T>();
    }
}
