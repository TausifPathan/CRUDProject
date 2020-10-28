using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class HRDBHandle
    {
        private string connectionString;
        public HRDBHandle()
        {
            connectionString = @"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=CompanyDatabase;Integrated Security=True;Pooling=False;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<HR>("HRGet", commandType: CommandType.StoredProcedure);
            }
        }
    }
}