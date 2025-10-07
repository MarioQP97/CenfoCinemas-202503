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
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>()
        {
            throw new NotImplementedException();
        }
    }
}
