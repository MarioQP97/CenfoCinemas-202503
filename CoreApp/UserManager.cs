using DataAccess.CRUD;
using Entities_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp

//Las clases de tipo manager, sirven para logica de negocio y aplicacion de validaciones
{
    public class UserManager : BaseManager

    {
        public void Create(User user)
        {
            try
            {
                //Validar que el usuario tenga mas de 18 anios
                if (IsOver18(user))
                {
                    var uCrud = new UserCrudFactory();
                    // Validar que el codigo de usuario no exista en la BD
                    var existingUser = uCrud.RetrieveUserByCode(user.UserCode);
                    if (existingUser != null)
                    {
                        throw new Exception("El código de usuario ya existe en la base de datos.");
                    }

                    uCrud.Create(user);
                }
                else
                {
                    throw new Exception("El usuario debe ser mayor de 18 años.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public List<User> RetrieveAll()
        {
            try
            {
                var uCrud = new UserCrudFactory();
                return uCrud.RetrieveAll<User>();
            }
            catch (Exception ex)
            {
                ManageException(ex);
                return new List<User>();
            }
        }

        public User RetrieveUserById(int id)
        {
            try
            {
                var uCrud = new UserCrudFactory();
                var user = uCrud.RetrieveById<User>(id);

                if (user == null)
                {
                    throw new Exception("No se encontró ningún usuario con el ID especificado.");
                }

                return user;
            }
            catch (Exception ex)
            {
                ManageException(ex);
                return null;
            }
        }

        public void Update(User user)
        {
            try
            {
                var uCrud = new UserCrudFactory();
                var existingUser = uCrud.RetrieveById<User>(user.Id);

                if (existingUser == null)
                {
                    throw new Exception("No se puede actualizar. El usuario no existe.");
                }

                //Validar que el usuario tenga mas de 18 anios
                if (IsOver18(user))
                {
                    uCrud.Update(user);
                }
                else
                {
                    throw new Exception("El usuario debe ser mayor de 18 años.");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public void Delete(User user)
        {
            var uCrud = new UserCrudFactory();
            uCrud.Delete(user);
        }

        private bool IsOver18(User user)
        {
            var currentDate = DateTime.Now;

            int age = currentDate.Year - user.BirthDate.Year;
            if (user.BirthDate > currentDate.AddYears(-age).Date)
            {
                age--;
            }
            return age >= 18;
        }

    }
}