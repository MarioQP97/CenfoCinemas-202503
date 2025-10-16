using DataAccess.DAO;
using DataAccess.CRUD;
using Entities_DTO;
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using CoreApp;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Crear usuario");
        Console.WriteLine("2. Eliminar usuario");
        Console.WriteLine("3. Actualizar usuario");
        Console.WriteLine("4. Crear película");
        Console.WriteLine("5. Eliminar película");
        Console.WriteLine("6. Actualizar película");
        Console.WriteLine("7. Listar usuarios");

        int opcion = int.Parse(Console.ReadLine());

        var user = new User();
        var movie = new Movie();
        var uCrud = new UserCrudFactory();
        var mCrud = new MovieCrudFactory();

        switch (opcion)
        {
            case 1:
                

                Console.WriteLine("Indique el código de usuario:");
                user.UserCode = Console.ReadLine();

                Console.WriteLine("Indique el nombre de usuario:");
                user.Name = Console.ReadLine();

                Console.WriteLine("Indique el email de usuario:");
                user.Email = Console.ReadLine();

                Console.WriteLine("Indique la contraseña de usuario:");
                user.Password = Console.ReadLine();

                Console.WriteLine("Indique la fecha de nacimiento (yyyy-MM-dd):");
                user.BirthDate = DateTime.Parse(Console.ReadLine());

                user.Status = "AC";

                var uMan = new UserManager();
                uMan.Create(user);

                break;

            case 2:
                var userDelete = new User();

                Console.WriteLine("Indique el ID del usuario a eliminar:");
                userDelete.Id = int.Parse(Console.ReadLine());

                uCrud.Delete(userDelete);
                Console.WriteLine("Usuario eliminado correctamente.");
                break;

            case 3:
                var userUpdate = new User();

                Console.WriteLine("Indique el código de usuario:");
                userUpdate.UserCode = Console.ReadLine();

                Console.WriteLine("Indique el nombre de usuario:");
                userUpdate.Name = Console.ReadLine();

                Console.WriteLine("Indique el email de usuario:");
                userUpdate.Email = Console.ReadLine();

                Console.WriteLine("Indique la contraseña de usuario:");
                userUpdate.Password = Console.ReadLine();

                Console.WriteLine("Indique la fecha de nacimiento (yyyy-MM-dd):");
                userUpdate.BirthDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Indique el ID del usuario a actualizar:");
                userUpdate.Id = int.Parse(Console.ReadLine());

                userUpdate.Status = "AC";

                uCrud.Update(userUpdate);
                Console.WriteLine("Usuario actualizado correctamente.");
                break;

            case 4:
                var movieCreate = new Movie();

                Console.WriteLine("Indique el título de la película:");
                movieCreate.Title = Console.ReadLine();

                Console.WriteLine("Indique la descripción:");
                movieCreate.Description = Console.ReadLine();

                Console.WriteLine("Indique la fecha de estreno (yyyy-MM-dd):");
                movieCreate.ReleaseDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Indique el género:");
                movieCreate.Genre = Console.ReadLine();

                Console.WriteLine("Indique el director:");
                movieCreate.Director = Console.ReadLine();

                mCrud.Create(movieCreate);
                Console.WriteLine("Película creada correctamente.");
                break;

            case 5:
                var movieDelete = new Movie();

                Console.WriteLine("Indique el ID de la película a eliminar:");
                movieDelete.Id = int.Parse(Console.ReadLine());

                mCrud.Delete(movieDelete);
                Console.WriteLine("Película eliminada correctamente.");
                break;

            case 6:
                var movieUpdate = new Movie();

                Console.WriteLine("Indique el título de la película:");
                movieUpdate.Title = Console.ReadLine();

                Console.WriteLine("Indique la descripción:");
                movieUpdate.Description = Console.ReadLine();

                Console.WriteLine("Indique la fecha de estreno (yyyy-MM-dd):");
                movieUpdate.ReleaseDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Indique el género:");
                movieUpdate.Genre = Console.ReadLine();

                Console.WriteLine("Indique el director:");
                movieUpdate.Director = Console.ReadLine();

                Console.WriteLine("Indique el ID de la película a actualizar:");
                movieUpdate.Id = int.Parse(Console.ReadLine());

                mCrud.Update(movieUpdate);
                Console.WriteLine("Película actualizada correctamente.");
                break;
            case 7:
                var users = uCrud.RetrieveAll<User>();
                foreach (var u in users)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(u));
                }
                break;

            default:
                Console.WriteLine("Opción inválida.");
                break;
        }


    }
}
