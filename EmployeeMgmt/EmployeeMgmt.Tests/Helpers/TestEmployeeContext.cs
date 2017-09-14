using EmployeeMgmt.DAL;
using EmployeeMgmt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace EmployeeMgmt.Tests.Helpers
{
    class TestEmployeeContext : IEmployeeContext
    {
        public TestEmployeeContext()
        {
            this.Employees = new TestEmployeeDbSet();
        }

        public DbSet<Employee> Employees { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Employee item) { }
        public void Dispose() { }

    }
}
