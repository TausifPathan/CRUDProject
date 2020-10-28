using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class EmployeeDBHandle
    {
        private string connectionString;
        public EmployeeDBHandle()
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
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Employee>("EmployeeGet", commandType: CommandType.StoredProcedure);
            }
        }

        public void AddEmployee(Employee e)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@name", e.Name);
            param.Add("@street1", e.Street1);
            param.Add("@street2", e.Street2);
            param.Add("@area", e.Area);
            param.Add("@city", e.City);
            param.Add("@pincode", e.Pincode);

            using (IDbConnection dbConnection = Connection)
            {                
                dbConnection.Open();
                dbConnection.Execute("EmployeeAdd",param, commandType: CommandType.StoredProcedure);
            }
            
        }

        public Employee GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Employee>("EmployeeGetById", new { Id = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void UpdateEmployee(Employee e)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@id", e.Id);
            param.Add("@name", e.Name);
            param.Add("@street1", e.Street1);
            param.Add("@street2", e.Street2);
            param.Add("@area", e.Area);
            param.Add("@city", e.City);
            param.Add("@pincode", e.Pincode);

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("EmployeeUpdate",param, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteEmployee(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {               
                dbConnection.Open();
                dbConnection.Execute("EmployeeDelete", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}