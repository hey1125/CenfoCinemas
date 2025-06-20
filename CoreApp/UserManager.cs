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

        

    