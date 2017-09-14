using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using EmployeeMgmt.DAL;
using EmployeeMgmt.Models;

namespace EmployeeMgmt.Controllers
{
    public class WAEmployeeController : ApiController
    {
        private EmployeeDbWrapper db;

        public WAEmployeeController()
        {
            db = new EmployeeDbWrapper();
        }

        public WAEmployeeController(IEmployeeContext context)
        {
            db = new EmployeeDbWrapper(context);
        }

        // GET: api/WAEmployee
        public IQueryable<Employee> GetEmployees()
        {
            return db.GetEmployees().AsQueryable();
        }

        // GET: api/WAEmployee/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(string pin)
        {
            Employee employee = db.GetEmployee(pin);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/WAEmployee/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(string pin, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pin != employee.Pin)
            {
                return BadRequest();
            }

            try
            {
                db.UpdateEmployee(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!db.EmployeeExists(pin))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WAEmployee
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           

            try
            {
                db.CreateEmployee(employee);
            }
            catch (DbUpdateException)
            {
                if (db.EmployeeExists(employee.Pin))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employee.Pin }, employee);
        }

        // DELETE: api/WAEmployee/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(string pin)
        {
            Employee employee = db.GetEmployee(pin);
            if (employee == null)
            {
                return NotFound();
            }

            db.DeleteEmployee(pin);

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
               
    }
}