using CoreApp;
using DataAccess.CRUD;
using DataAccess.DAO;
using DTOs;
using Newtonsoft.Json;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Selecione la opcion deseada:");
        Console.WriteLine("1. Crear Usuario");
        Console.WriteLine("2. Consultar Usuario");
        Console.WriteLine("3. Actualizar Usuario");
        Console.WriteLine("4. Eliminar Usuario");
        Console.WriteLine("5. Crear pelicula");
        Console.WriteLine("6. Consultar Pelicula");
        Console.WriteLine("7. Actualizar Pelicula");
        Console.WriteLine("8. Eliminar Pelicula");
        var option = Int32.Parse(Console.ReadLine());
        var sqlOperation = new SqlOperation();
        
        switch (option)
        {

            case 1:
                Console.WriteLine("Digite el codifo de usuario");
                var userCode = Console.ReadLine();

                Console.WriteLine("Digite el nombre del usuario");
                var name = Console.ReadLine();

                Console.WriteLine("Digite el correo del usuario");
                var email = Console.ReadLine();

                Console.WriteLine("Digite la contrasena del usuario");
                var password = Console.ReadLine();

                var status = "AC";
                Console.WriteLine("Digite la fecha de nacimiento");
                var bDate = DateTime.Parse(Console.ReadLine());


                var user = new User()
                {
                    Usercode = userCode,
                    Name = name,
                    Email = email,
                    Password = password,
                    status = status,
                    DateOfBirth = bDate
                    
                };
                var um= new UserManager();
                um.Create(user);

                break;
            case 2:
                //uCrud = new UserCrudFactory();
                //var listUsers = uCrud.RetriveAll<User>();
                //foreach (var u in listUsers)
                //{
                //    Console.WriteLine(JsonConvert.SerializeObject(u));
                //}

                break;
            case 3:
                // Actualizar Usuario
                break;
            case 4:
                // Eliminar Usuario
                break;
            case 5:
                Console.WriteLine("Titulo de la pelicula");
                var title = Console.ReadLine();

                Console.WriteLine("Descripcion de la pelicula");
                var desc= Console.ReadLine();

                Console.WriteLine("Digite la fecha de lanzamiento");
                var releaseDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Digite el genero de la pelicula");
                var genre = Console.ReadLine();

                Console.WriteLine("Digite el director");
                var director = Console.ReadLine();

                sqlOperation.ProcedureName = "CRE_MOVIE_PR";
                sqlOperation.AddStringParameter("P_Title", title);
                sqlOperation.AddStringParameter("P_Desc", desc);
                sqlOperation.AddDateTimeParam("P_ReleaseDate", releaseDate);
                sqlOperation.AddStringParameter("P_Genre", genre);
                sqlOperation.AddStringParameter("P_Director", director);
                break;
            case 6:
                // Consultar Pelicula
                break;
            case 7:
                // Actualizar Pelicula
                break;
            case 8:
                // Eliminar Pelicula
                break;
            default:
                Console.WriteLine("Opcion no valida");
                break;
        }
       

        //var sqlDao = SqlDao.GetInstance();
        


    }
}
