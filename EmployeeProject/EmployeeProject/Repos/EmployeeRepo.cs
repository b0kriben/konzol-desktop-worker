using EmployeeProject.Context;
using EmployeeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Repos
{
    public class EmployeeRepo
    {
        private readonly DatabaseContext _dbContext;

        public EmployeeRepo()
        {
            _dbContext = new DatabaseContext();
        }

        // Dolgozók száma
        public int GetNumberOfEmployees() =>
            _dbContext.Employees.Count();

        // Fizetést kapó dolgozók száma
        public int GetNumberOfEmployeesWithPayment() =>
            _dbContext.Employees.Count(e => e.Salary > 0);

        // Fizetés nélküli dolgozók
        public int GetNumberOfEmployeesWithoutPayment() =>
            _dbContext.Employees.Count(e => e.Salary == 0);

        // Fizetések átlaga
        public double GetAverageSalary() =>
            _dbContext.Employees.Average(e => e.Salary);

        // Összes dolgozó
        public List<Employee> GetEmployees() =>
            _dbContext.Employees.ToList();

        // Dolgozó e-mail cím alapján
        public Employee? GetEmployeeByEmail(string email) =>
            _dbContext.Employees.Find(email);

        // Adott dolgozónak fizetés adása
        public void AddSalary(string email, int amount)
        {
            Employee? employee = GetEmployeeByEmail(email);

            if(employee is not null)
            {
                employee.AddSalary(amount);
                _dbContext.SaveChanges();
            }
        }

        // Dolgozó törlése
        public void DeleteEmployee(string email)
        {
            Employee? employee = GetEmployeeByEmail(email);

            if (employee is not null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
        }
    }
}
