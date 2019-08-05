using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp
{
    class Employee
    {
        //typically a constant has a capital name
        private const string TEXT_FILE_NAMES = "Employee.txt";
        public string Name { get; set; }
        //public/private type name {allow people to read and write}
        public string Title { get; set; }
        
        public static void WriteEmployee(Employee employee)
        {
            var employeeData = $"{employee.Name}, {employee.Title}";
            FileHelper.WriteTextFile(TEXT_FILE_NAMES, employeeData);
        }
    }
}
