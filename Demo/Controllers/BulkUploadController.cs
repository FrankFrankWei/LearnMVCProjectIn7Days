using Demo.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.ViewModels;
using Demo.Models;
using System.IO;

namespace Demo.Controllers
{
    public class BulkUploadController : Controller
    {
        //
        // GET: /BulkUpload/
        [AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        public ActionResult Upload(FileUploadViewModel file)
        {
            List<Employee> employees = GetEmployeesFromUploadFile(file);
            (new EmployeeBusinessLayer()).UploadEmployees(employees);

            return RedirectToAction("Index", "Employee");
        }

        private List<Employee> GetEmployeesFromUploadFile(FileUploadViewModel file)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader reader = new StreamReader(file.FileUpload.InputStream);
            reader.ReadLine();// assuming first line is header

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(','); // values are comma seperated
                Employee e = new Employee();
                e.FirstName = values[0];
                e.LastName = values[1];
                e.Salary = int.Parse(values[2]);

                employees.Add(e);
            }

            return employees;
        }
	}
}