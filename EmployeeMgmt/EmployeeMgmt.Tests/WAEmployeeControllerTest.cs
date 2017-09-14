using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeMgmt.Models;
using System.Collections.Generic;
using EmployeeMgmt.Controllers;
using EmployeeMgmt.Tests.Helpers;
using System.Web.Http.Results;
using System.Net;
using System.Linq;

namespace EmployeeMgmt.Tests
{
    [TestClass]
    public class WAEmployeeControllerTest
    {
        [TestMethod]
        public void GetEmployeesTest()
        {
            var context = new TestEmployeeContext();

            context.Employees.Add(GetTestEmployee());
            context.Employees.Add(new Employee { Pin = "2222" });
            context.Employees.Add(new Employee { Pin = "3333" });
            context.Employees.Add(new Employee { Pin = "4444" });

            var controller = new WAEmployeeController(context);
            var result = controller.GetEmployees().ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
        }


        [TestMethod]
        public void GetEmployeeTest()
        {
            var context = new TestEmployeeContext();
            context.Employees.Add(GetTestEmployee());

            var controller = new WAEmployeeController(context);
            var result = controller.GetEmployee("1111") as OkNegotiatedContentResult<Employee>;

            Assert.IsNotNull(result);
            Assert.AreEqual("1111", result.Content.Pin);
        }

        [TestMethod]
        public void PutEmployeeTest()
        {
            var controller = new WAEmployeeController(new TestEmployeeContext());

            var item = GetTestEmployee();

            var result = controller.PutEmployee(item.Pin, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);

            var badRequestResult = controller.PutEmployee("", GetTestEmployee());
            Assert.IsInstanceOfType(badRequestResult, typeof(BadRequestResult));
        }


        [TestMethod]
        public void PostEmployeeTest()
        {
            var controller = new WAEmployeeController(new TestEmployeeContext());

            var item = GetTestEmployee();

            var result = controller.PostEmployee(item) as CreatedAtRouteNegotiatedContentResult<Employee>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["Id"], result.Content.Pin);
            Assert.AreEqual(result.Content.FirstName, item.FirstName);
            Assert.AreEqual(result.Content.LastName, item.LastName);
            Assert.AreEqual(result.Content.Address, item.Address);
            Assert.AreEqual(result.Content.Email, item.Email);
            Assert.AreEqual(result.Content.Phone, item.Phone);
        }


        [TestMethod]
        public void DeleteEmployeeTest()
        {
            var context = new TestEmployeeContext();
            var item = GetTestEmployee();
            context.Employees.Add(item);

            var controller = new WAEmployeeController(context);
            var result = controller.DeleteEmployee("1111") as OkNegotiatedContentResult<Employee>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Pin, result.Content.Pin);
        }

        
        private Employee GetTestEmployee()
        {
            return new Employee {Pin = "1111", FirstName = "Testo", LastName = "Testić", Address = "Address", Email = "E@mail.com", Phone = "123 456" };
        }
    }
}
