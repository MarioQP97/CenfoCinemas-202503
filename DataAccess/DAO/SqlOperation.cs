using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public SqlOperation() { 
        
            Parameters = new List<SqlParameter>();
        }
    

        public void AddStringParameter(string parameterName, string value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }
        public void AddIntParam(string parameterName, int value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }
        public void AddDoubleParam(string parameterName, double value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }
        public void AddDateTimeParam(string parameterName, DateTime value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }

    }
}
