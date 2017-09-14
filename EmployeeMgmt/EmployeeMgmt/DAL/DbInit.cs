using EmployeeMgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeMgmt.DAL
{
    public class DbInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmployeeContext>
    {
        protected override void Seed(EmployeeContext context)
        {
            var employees = new List<Employee>
            {
                new Employee{Pin="1111", FirstName = "Testo", LastName = "Testić", Address = "Ulica 1, Grad", Email = "Testo@Testic.com", Phone ="123 123"},
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

        }
    }
}