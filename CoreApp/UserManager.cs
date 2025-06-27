using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class UserManager : BaseManager
    {
        public void Create(User user)
        {
            try
            {
                if (IsOver18(user)){
                    var uCrud= new UserCrudFactory();
                    var uExist = uCrud.RetriveByUserCode<User>(user);
                    if (uExist == null)
                    {
                        uExist = uCrud.RetriveByEmail<User>(user);
                        if (uExist==null){
                            uCrud.Create(user);
                        }
                        else
                        {
                            throw new Exception("El correo ya esta registrado");
                        }
                        {
                            
                        }
                    }
                    else
                    {
                        throw new Exception("Codigo no disponible");
                    }
                }
                else
                {
                    throw new Exception("Usuario no tiene 18");
                }
            }
            catch (Exception ex)
            {
                ManagerException(ex);
            }
        }

        public List<User> RetriveAll()
        {
         
            var uCrud = new UserCrudFactory();
            return uCrud.RetriveAll<User>();
            
            
        }

        public User RetrieveById(User user)
        {
            try
            {
                var uCrud = new UserCrudFactory();
                return uCrud.RetriveById<User>(user.Id);
            }
            catch (Exception ex)
            {
                ManagerException(ex);
                return null;
            }
        }

        public User RetrieveByEmail(User user)
        {
            try
            {
                var factory = new UserCrudFactory();
                return factory.RetriveByEmail<User>(user);
            }
            catch (Exception ex)
            {
                ManagerException(ex);
                return null;
            }
        }

        public User RetrieveByUserCode(User user)
        {
            try
            {
                var factory = new UserCrudFactory();
                return factory.RetriveByUserCode<User>(user);
            }
            catch (Exception ex)
            {
                ManagerException(ex);
                return null;
            }
        }

        public void Update(User user)
        {
            try
            {
                var factory = new UserCrudFactory();
                factory.Update(user);
            }
            catch (Exception ex)
            {
                ManagerException(ex);
            }
        }

        public void Delete(User user)
        {
            try
            {
                var factory = new UserCrudFactory();
                factory.Delete(user);
            }
            catch (Exception ex)
            {
                ManagerException(ex);
            }
        }


        private bool IsOver18(User user)
        {
            var currentDate = DateTime.Now; 
            int age = currentDate.Year - user.DateOfBirth.Year;

            if (user.DateOfBirth > currentDate.AddYears(-age).Date)
            {
                age--;
            }
            return age >= 18;
        }

    }

}      

        

    