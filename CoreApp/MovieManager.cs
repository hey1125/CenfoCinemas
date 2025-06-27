using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;

namespace CoreApp
{
    public class MovieManager : BaseManager
    {
        public void Create(Movies movie)
        {
            try
            {
                var mCrud = new MovieCrudFactory();
                mCrud.Create(movie);
            }
            catch (Exception ex)
            {
                ManagerException(ex);
            }
        }

        public List<Movies> RetrieveAll()
        {
            var mCrud = new MovieCrudFactory();
            return mCrud.RetriveAll<Movies>();
        }

        public Movies RetrieveById(Movies movie)
        {
            try
            {
                var mCrud = new MovieCrudFactory();
                return mCrud.RetriveById<Movies>(movie.Id);
            }
            catch (Exception ex)
            {
                ManagerException(ex);
                return null;
            }
        }

       

        public void Update(Movies movie)
        {
            try
            {
                var mCrud = new MovieCrudFactory();
                mCrud.Update(movie);
            }
            catch (Exception ex)
            {
                ManagerException(ex);
            }
        }

        public void Delete(Movies movie)
        {
            try
            {
                var mCrud = new MovieCrudFactory();
                mCrud.Delete(movie);
            }
            catch (Exception ex)
            {
                ManagerException(ex);
            }
        }
    }
}
