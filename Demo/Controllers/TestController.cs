using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

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

            return View("MyView", emp);
        }
	}
}