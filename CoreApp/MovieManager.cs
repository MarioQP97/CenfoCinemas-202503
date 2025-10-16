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
    public class MovieManager : BaseManager

    {
        public void Create(Movie movie)
        {
            try
            {
                //Validar que el título no esté vacío
                if (string.IsNullOrWhiteSpace(movie.Title))
                {
                    throw new Exception("El título de la película no puede estar vacío.");
                }

                //Validar que la fecha de estreno no sea futura
                if (movie.ReleaseDate > DateTime.Now)
                {
                    throw new Exception("La fecha de estreno no puede ser una fecha futura.");
                }

                var mCrud = new MovieCrudFactory();

                // Validar que no exista una película con el mismo título
                var existingMovie = RetrieveByTitle(movie.Title);
                if (existingMovie != null)
                {
                    throw new Exception("Ya existe una película con el mismo título en la base de datos.");
                }

                mCrud.Create(movie);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public List<Movie> RetrieveAll()
        {
            try
            {
                var mCrud = new MovieCrudFactory();
                return mCrud.RetrieveAll<Movie>();
            }
            catch (Exception ex)
            {
                ManageException(ex);
                return new List<Movie>();
            }
        }

        public Movie RetrieveMovieById(int id)
        {
            try
            {
                var mCrud = new MovieCrudFactory();
                var movie = mCrud.RetrieveById<Movie>(id);

                if (movie == null)
                {
                    throw new Exception("No se encontró ninguna película con el ID especificado.");
                }

                return movie;
            }
            catch (Exception ex)
            {
                ManageException(ex);
                return null;
            }
        }

        public void Update(Movie movie)
        {
            try
            {
                var mCrud = new MovieCrudFactory();
                var existingMovie = mCrud.RetrieveById<Movie>(movie.Id);

                if (existingMovie == null)
                {
                    throw new Exception("No se puede actualizar. La película no existe.");
                }

                //Validar que el título no esté vacío
                if (string.IsNullOrWhiteSpace(movie.Title))
                {
                    throw new Exception("El título de la película no puede estar vacío.");
                }

                //Validar que la fecha de estreno no sea futura
                if (movie.ReleaseDate > DateTime.Now)
                {
                    throw new Exception("La fecha de estreno no puede ser una fecha futura.");
                }

                mCrud.Update(movie);
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public void Delete(Movie movie)
        {
            
            {
                var mCrud = new MovieCrudFactory();
                mCrud.Delete(movie);
            }

        }

        //Metodo auxiliar para buscar una película por título
        private Movie RetrieveByTitle(string title)
        {
            try
            {
                var mCrud = new MovieCrudFactory();
                var movies = mCrud.RetrieveAll<Movie>();

                return movies.FirstOrDefault(m =>
                    m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
