using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using Demo.ViewModels;

namespace Demo.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            Employee emp = new Employee();
            emp.FirstName = "Wei";
            emp.LastName = "Frank";
            emp.Salary = 20000f;

            EmployeeViewModel vm = new EmployeeViewModel();
            vm.EmployeeName = emp.FirstName + " " + emp.LastName;
            vm.Salary = emp.Salary.ToString("C");
            vm.SalaryColor = emp.Salary > 15000 ? "yellow" : "green";
            vm.UserName = "Admin";

            return View("MyView", vm);
        }
	}
}