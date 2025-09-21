

using DataAccess.DAO;
using Entities_DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

public class Program
{


    public static void Main(String[] args)
    {

        var sqlDao = SqlDao.GetInstance();

        //Crea un usuario de prueba
        var user = new User();

        //Ejecucion del procedure
        var sqlOperation = new SqlOperation();
        sqlOperation.ProcedureName = "CRE_USER_PR";

        sqlOperation.AddStringParameter("P_UserCode", "mquiros");
        sqlOperation.AddStringParameter("P_Name", "Mario Quiros");
        sqlOperation.AddStringParameter("P_Email", "mquiros@ucenfotec.ac.cr");
        sqlOperation.AddStringParameter("P_Password", "Qwerty123");
        sqlOperation.AddDateTimeParam("P_BirthDate", DateTime.Now);
        sqlOperation.AddStringParameter("P_Status", "AC");

        //Ejecuta sl SP
        sqlDao.ExecuteProcedure(sqlOperation);


    }
}