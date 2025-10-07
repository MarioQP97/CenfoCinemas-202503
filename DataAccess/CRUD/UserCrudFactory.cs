using DataAccess.DAO;
using Entities_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {
        public UserCrudFactory() {

            _sqlDao = SqlDao.GetInstance();

        }
        public override void Create(BaseDTO baseDTO)
        {
            var user = baseDTO as User;

            //Ejecucion del procedure
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_USER_PR";

            sqlOperation.AddStringParameter("P_UserCode", user.UserCode);
            sqlOperation.AddStringParameter("P_Name", user.Name);
            sqlOperation.AddStringParameter("P_Email", user.Email);
            sqlOperation.AddStringParameter("P_Password", user.Password);
            sqlOperation.AddDateTimeParam("P_BirthDate", user.BirthDate);
            sqlOperation.AddStringParameter("P_Status", user.Status);

            //Ejecutamos el SP
            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var user = baseDTO as User;

            //Ejecucion del procedure
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "DE_USER_PR";

            sqlOperation.AddIntParam("P_Id", user.Id);

            //Ejecutamos el SP
            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUsers = new List<T>();

            var operation = new SqlOperation();
            operation.ProcedureName = "RET_ALL_USERS_PR";

            var lstResult = _sqlDao.ExecuteQueryProcedure(operation);

            if (lstResult.Count > 0)
            {
                foreach (var item in lstResult) { 
                
                    var user = BuildIser(item);
                    lstUsers.Add((T)Convert.ChangeType(user, typeof(T)));
                }
            }
            return lstUsers;
        }
        //Metodo que convierte una fila del diccionario en un objeto de tipo usuario
        private User BuildIser(Dictionary<string, object> row) { 
            
            var user = new User
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                Name = (string)row["Name"],
                UserCode = (string)row["UserCode"],
                Email = (string)row["Email"],
                Password = (string)row["Password"],
                Status = (string)row["Status"],
                BirthDate = (DateTime)row["BirthDate"],


            };
            return user;
        }


        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_USER_BY_ID_PR" };
            sqlOperation.AddIntParam("P_Id", id);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0) 
            { 
                var row=lstResults [0];
                var user = BuildIser(row);

                return (T)Convert.ChangeType(user, typeof(T));
            }
            return default(T);
        }
        public User RetrieveUserByCode(string code) 
        {
            var sqlOperation = new SqlOperation() { ProcedureName = "RET_USER_BY_CODE_PR" };
            sqlOperation.AddStringParameter("P_Code", code);

            var lstResults = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];
                var user = BuildIser(row);

                return user;
            }
            return null;
        }
        public override void Update(BaseDTO baseDTO)
        {
            var user = baseDTO as User;

            //Ejecucion del procedure
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "UPD_USER_PR";

            sqlOperation.AddStringParameter("P_UserCode", user.UserCode);
            sqlOperation.AddStringParameter("P_Name", user.Name);
            sqlOperation.AddStringParameter("P_Email", user.Email);
            sqlOperation.AddStringParameter("P_Password", user.Password);
            sqlOperation.AddDateTimeParam("P_BirthDate", user.BirthDate);
            sqlOperation.AddStringParameter("P_Status", user.Status);
            sqlOperation.AddIntParam("P_Id", user.Id);

            //Ejecutamos el SP
            _sqlDao.ExecuteProcedure(sqlOperation);
        }
    }
}
