using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{

    /*
     * Se encarga de la comunicacion con la base de datos
     * Solo ejecuta store procedures
     * 
     * Esta clase implementa el patron singleton
     * para asegurar la existencia de una unica instancia de este objeto
     */

    public class SqlDao
    {
        //Paso 1: Crear una instancia privada de la misma clase
        private static SqlDao instance;

        private string connectionString;

        //Paso 2: Redefinir el constructor default de la clase, convertir en privado
        private SqlDao()
        {
            connectionString = @"Data Source=srvdb01cenfocinemas.database.windows.net;Initial Catalog=cenfocinemas202503;User ID=sysman;Password=************;Trust Server Certificate=True";
        }

        //Paso 3: Definir el metodo que expone la instancia

        public static SqlDao GetInstance()
        {

            if (instance == null)
            {
                instance = new SqlDao();
            }
            return instance;
        }

        //Metodo para ejecutar SP sin retorno de data
        public void ExecuteProcedure(SqlOperation operation)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(operation.ProcedureName, conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    //Set de los parametros
                    foreach (var param in operation.Parameters) { 
                        command.Parameters.Add(param);
                    }

                    //Ejecuta el SP
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }      
    }
}

