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
            connectionString = @"Data Source=srv-cenfocinemas-2503.database.windows.net; Initial Catalog=cenfocinemasdb-2503;User ID=sysman;Password=Cenfotec123!;Encrypt=True;Trust Server Certificate=True";
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

        //Metodo para ejecutar SP con retorno de data

        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation operation)
        {

            var lstResults = new List<Dictionary<string, object>>();
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(operation.ProcedureName, conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    //Set de los parametros
                    foreach (var param in operation.Parameters)
                    {
                        command.Parameters.Add(param);
                    }

                    //Ejecuta el SP
                    conn.Open();
                    
                    //Setencia que hace la lectura de la data
                    var reader= command.ExecuteReader();

                    if (reader.HasRows) 
                    { 
                    
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (var index = 0; index < reader.FieldCount; index++)
                            {
                                var key=reader.GetName(index);
                                var value = reader.GetValue(index);
                                //Agrega los valortes de la consulta de BD al diccionario
                                row[key]=value;
                            }
                            lstResults.Add(row);
                        }

                    }

                }
            }
            return lstResults;
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

