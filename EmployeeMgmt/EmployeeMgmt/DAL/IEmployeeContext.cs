using EmployeeMgmt.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EmployeeMgmt.DAL
{
    public interface IEmployeeContext : IDisposable
    {
        DbSet<Employee> Employees { get; }
        int SaveChanges();
        void MarkAsModified(Employee item);
    }

}