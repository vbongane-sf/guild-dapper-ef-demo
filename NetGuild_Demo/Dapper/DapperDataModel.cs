using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetGuild_Demo.Dapper
{
    class DapperDataModel
    {
    }
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }

    }

    public class Department 
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
