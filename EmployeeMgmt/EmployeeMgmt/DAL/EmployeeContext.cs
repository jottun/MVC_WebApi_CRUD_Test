using EmployeeMgmt.Models;
using System.Data.Entity;

namespace EmployeeMgmt.DAL
{
    public class EmployeeContext : DbContext, IEmployeeContext
    {
        public EmployeeContext() : base() { }
        public DbSet<Employee> Employees { get; set; }

        public void MarkAsModified(Employee item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}