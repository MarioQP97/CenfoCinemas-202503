using DataAccess.DAO;
using Entities_DTO;
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

        public override void Create(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_MOVIE_PR";

            sqlOperation.AddStringParameter("P_Title", movie.Title);
            sqlOperation.AddStringParameter("P_Description", movie.Description);
            sqlOperation.AddDateTimeParam("P_ReleaseDate", movie.ReleaseDate);
            sqlOperation.AddStringParameter("P_Genre", movie.Genre);
            sqlOperation.AddStringParameter("P_Director", movie.Director);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "DEL_MOVIE_PR";

            sqlOperation.AddIntParam("P_Id", movie.Id);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "UPD_MOVIE_PR";

            sqlOperation.AddIntParam("P_Id", movie.Id);
            sqlOperation.AddStringParameter("P_Title", movie.Title);
            sqlOperation.AddStringParameter("P_Description", movie.Description);
            sqlOperation.AddDateTimeParam("P_ReleaseDate", movie.ReleaseDate);
            sqlOperation.AddStringParameter("P_Genre", movie.Genre);
            sqlOperation.AddStringParameter("P_Director", movie.Director);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>()
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_MOVIE_PR" };

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var movie = BuildMovie(row);

                return (T)Convert.ChangeType(movie, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstMovies = new List<T>();

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "RET_ALL_MOVIE_PR";

            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
                foreach (var item in lstResult)
                {
                    var movie = BuildMovie(item);
                    lstMovies.Add((T)Convert.ChangeType(movie, typeof(T)));
                }
            }

            return lstMovies;
        }

        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_MOVIE_BY_ID_PR" };
            sqlOperation.AddIntParam("P_Id", id);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var movie = BuildMovie(row);

                return (T)Convert.ChangeType(movie, typeof(T));
            }

            return default(T);
        }

        private Movie BuildMovie(Dictionary<string, object> row)
        {
            var movie = new Movie
            {
                Id = (int)row["Id"],
                Title = row["Title"].ToString(),
                Description = row["Description"].ToString(),
                ReleaseDate = (DateTime)row["ReleaseDate"],
                Genre = row["Genre"].ToString(),
                Director = row["Director"].ToString()
            };

            return movie;
        }
    }
}
