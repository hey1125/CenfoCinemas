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
        public override void Create(BaseDTOs baseDTO)
        {
            
            throw new NotImplementedException();
        }

        public override void Delete(BaseDTOs baseDTO)
        {
            throw new NotImplementedException();
        }

        public override T Retrive<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetriveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetriveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTOs baseDTO)
        {
            throw new NotImplementedException();
        }
    }
}
