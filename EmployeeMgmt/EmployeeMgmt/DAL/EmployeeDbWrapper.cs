using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EmployeeMgmt.Models;

namespace EmployeeMgmt.DAL
{
    public class EmployeeDbWrapper : IDisposable
    {
        private IEmployeeContext db = new EmployeeContext();

        public EmployeeDbWrapper() {}

        public EmployeeDbWrapper(IEmployeeContext context)
        {
            db = context;
        }

        public Employee GetEmployee(string pin)
        {
            return db.Employees.Find(pin);
        }

        public List<Employee> GetEmployees()
        {
            var employees = db.Employees.ToList();
            return employees;
        }

        public void CreateEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            db.MarkAsModified(employee);            
            db.SaveChanges();
        }

        public void DeleteEmployee(string pin)
        {
            Employee employee = GetEmployee(pin);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public bool EmployeeExists(string id)
        {
            return db.Employees.Any(e => e.Pin == id);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}