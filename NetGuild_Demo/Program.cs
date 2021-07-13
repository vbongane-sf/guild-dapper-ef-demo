using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetGuild_Demo.Dapper;
using NetGuild_Demo.EntityFramework;

namespace NetGuild_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                //showMenu = DapperMainMenu();
                showMenu = EFMainMenu();
            }
        }

        #region Dapper Methods

        private static bool DapperMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add Employee");            
            Console.WriteLine("2) Get Employee by FirstName");
            Console.WriteLine("3) Delete Employee by FirstName");
            Console.WriteLine("4) Close the application");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddEmployee();
                    return true;
                case "2":
                    GetEmployeeByFirstName();
                    return true;
                case "3":
                    DeleteEmployeeByFirstName();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
        private static void AddEmployee()
        {
            Console.Write("FirstName: ");
            var firstName = Console.ReadLine();
            Console.Write("LastName: ");
            var lastName = Console.ReadLine();
            Console.Write("Age: ");
            var age = Convert.ToInt32(Console.ReadLine());
            Console.Write("DepartmentId: ");
            var departmentId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine( $"No of rows affected : {DapperDataAccess.InsertEmployee(firstName, lastName, age, departmentId)}");
            Console.ReadLine();            
        }        
        private static void GetEmployeeByFirstName()
        {
            Console.Write("FirstName: ");
            var firstName = Console.ReadLine();

            var emp = DapperDataAccess.GetEmployeeByFirstName(firstName);
            if (emp != null)
            {
                Console.WriteLine($"FirstName : {emp.FirstName}, LastName : {emp.LastName}, Age : {emp.Age}, DepartmentId : {emp.DepartmentId}");
            }
            else
            {
                Console.WriteLine("Employee Not found");
            }
            Console.ReadLine();
        }
        private static void DeleteEmployeeByFirstName()
        {
            Console.Write("FirstName: ");
            var firstName = Console.ReadLine();

            var rowsAffected = DapperDataAccess.DeleteEmployeeByFirstNameUsingSproc(firstName);
            if (rowsAffected > 0)
            {
                Console.WriteLine("Employee Deleted.");                
            }
            else
            {
                Console.WriteLine("Employee Not Deleted or not found.");
            }
            Console.ReadLine();
        }
        #endregion

        #region Entity Framework Methods
        private static bool EFMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add Student");
            Console.WriteLine("2) Get Student by StudentId");
            Console.WriteLine("3) Update Student by StudentId");
            Console.WriteLine("4) Delete Student by StudentId");
            Console.WriteLine("5) Close the application");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddStudent();
                    return true;
                case "2":
                    GetStudentById();
                    return true;
                case "3":
                    UpdateStudentById();
                    return true;
                case "4":
                    DeleteStudentById();
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }
        private static void AddStudent()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("StudentId: ");
            var studentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Age: ");
            var age = Convert.ToInt32(Console.ReadLine());       


            using (var ctx = new SchoolContext())
            {
                var stud = new Student() { StudentName = name, StudentID = studentId, Age = age, GradeId = 4 };
                ctx.Students.Add(stud);
                Console.WriteLine($"No of rows affected : {ctx.SaveChanges()}");
            }
            
            Console.ReadLine();
        }
        private static void GetStudentById()
        {
            Console.Write("StudentId: ");
            var StudentId = Convert.ToInt32(Console.ReadLine());
                        
            using (var ctx = new SchoolContext())
            {
                var student = ctx.Students.SingleOrDefault(e => e.StudentID == StudentId);
                if (student != null)
                {
                    Console.WriteLine($"Name : {student.StudentName}, StudentId : {student.StudentID}, Age : {student.Age}, Grade : {student.GradeId}");
                }
                else
                {
                    Console.WriteLine("Student Not found");
                }
            }           
            Console.ReadLine();
        }

        private static void UpdateStudentById()
        {
            Console.Write("StudentId: ");
            var studentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            var name = Console.ReadLine();

            using (var ctx = new SchoolContext())
            {
                var student = ctx.Students.Single(e => e.StudentID == studentId);
                student.StudentName = name;
                ctx.SaveChanges();
            }
            Console.WriteLine("Student Updated");
            Console.ReadLine();
        }
        private static void DeleteStudentById()
        {
            Console.Write("StudentId: ");
            var studentId = Convert.ToInt32(Console.ReadLine());

            using (var ctx = new SchoolContext())
            {
                var student = ctx.Students.Single(e => e.StudentID == studentId);
                ctx.Students.Remove(student);
                ctx.SaveChanges();
            }
            Console.WriteLine("Student Deleted");
            Console.ReadLine();
        }
        #endregion
    }
}
