using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NetGuild_Demo.Dapper
{
    public class DapperDataAccess
    {
        private static string connString = ConfigurationManager.AppSettings.Get("LocalConnectionString");        
        
        public static int InsertEmployee(string firstName, string lastName, int age, int deptId)
        {
            int affectedRows = 0;
            var parameters = new { FirstName = firstName, LastName = lastName, Age = age, DepartmentId = deptId};            
            var sql = "insert into dbo.Employee(FirstName, LastName, Age, DepartmentId) values (@FirstName, @LastName, @Age, @DepartmentId)";
            //PARAMETERS AS ANONYMOUS TYPES
            using (var connection = new SqlConnection(connString))
            {
                affectedRows = connection.Execute(sql, parameters);                
            }
            return affectedRows;
        }

        public static Employee GetEmployeeByFirstName(string firstName)
        {            
            //DYNAMICPARAMETERS BAG
            var parameters = new DynamicParameters();
            var firstname = firstName;
            parameters.Add("@FirstName", firstname, DbType.String, ParameterDirection.Input, firstName.Length);
            var sql = "select FirstName, LastName, Age, DepartmentId from dbo.Employee where FirstName = @FirstName;";
            
            using (var connection = new SqlConnection(connString))
            {
                return connection.QueryFirstOrDefault<Employee>(sql, parameters);
            }            
        }

        public static int DeleteEmployeeByFirstNameUsingSproc(string firstName)
        {
            //DYNAMICPARAMETERS BAG            
            var parameters = new DynamicParameters();
            var firstname = firstName;
            parameters.Add("@FirstName", firstname, DbType.String, ParameterDirection.Input, firstName.Length);
            var sql = " exec [dbo].[DeleteEmployeeByFirstName]  @FirstName ;";

            using (var connection = new SqlConnection(connString))
            {
                return connection.Execute(sql, parameters);
            }
        }
    }
}
