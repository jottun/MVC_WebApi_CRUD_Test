using EmployeeMgmt.Models;
using System.Linq;

namespace EmployeeMgmt.Tests.Helpers
{
    class TestEmployeeDbSet
    : TestDbSet<Employee>
    {
        public override Employee Find(params object[] keyValues)
        {
            return this.SingleOrDefault(e => e.Pin == (string)keyValues.Single());
        }
    }
}
