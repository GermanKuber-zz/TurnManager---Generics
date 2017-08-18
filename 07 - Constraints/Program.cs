using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataManager
{
    class Program
    {
        static void Main(string[] args)
        {


            using (IRepository<Employee> employeeRepository
                = new SqlRepository<Employee>(NewContext()))
            {
                AddEmployees(employeeRepository);
                AddManagers(employeeRepository);
                CountEmployees(employeeRepository);
                QueryEmployees(employeeRepository);
                DumpPeople(employeeRepository);

                IEnumerable<Person> temp = employeeRepository.FindAll();
            };
        }
        private static void AddManagers(IWriteOnlyRepository<Manager> employeeRepository)
        {
            employeeRepository.Add(new Manager { Name = "Alex" });
            employeeRepository.Commit();
        }

        private static void DumpPeople(IReadOnlyRepository<Person> employeeRepository)
        {
            var employees = employeeRepository.FindAll();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static void QueryEmployees(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.FindById(1);
            Console.WriteLine(employee.Name);
        }

        private static void CountEmployees(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine(employeeRepository.FindAll().Count());
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Name = "Fran" });
            employeeRepository.Add(new Employee { Name = "Tere" });
            employeeRepository.Add(new Employee { Name = "Jorge" });
            employeeRepository.Commit();
        }
        private static DbContext NewContext()
        {
            //Configuro mi contexto para utilizar la data enmemoria
            var options = new DbContextOptionsBuilder<EmployeeDb>()
                .UseInMemoryDatabase(databaseName: "DBTest")
                .Options;
            var db = new EmployeeDb(options);

            return db;
        }
    }
}
