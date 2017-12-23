using BusinessEntities;
using Demo.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.SPA;
using System.IO;
using System.Threading.Tasks;
using BusinessLayer;

namespace Demo.Areas.SPA.Controllers
{
    public class SpaBulkUploadController : Controller
    {
        //
        // GET: /SPA/SpaBulkUpload/
        [AdminFilter]
        public ActionResult Index()
        {
            return PartialView("_Index");
        }

        public async Task<ActionResult> Upload(FileUploadViewModel file)
        {
            List<Employee> employees = await Task.Factory.StartNew<List<Employee>>(() => GetEmployeesFromFile(file));

            EmployeeBusinessLayer bl = new EmployeeBusinessLayer();
            bl.UploadEmployees(employees);

            EmployeeListViewModel vm = new EmployeeListViewModel();
            vm.Employees = new List<EmployeeViewModel>();

            foreach (var item in employees)
            {
                EmployeeViewModel v = new EmployeeViewModel();
                v.EmployeeName = string.Concat(item.FirstName + " " + item.LastName);
                v.Salary = item.Salary.Value.ToString("C");
                v.SalaryColor = item.Salary > 15000 ? "yellow" : "green";

                vm.Employees.Add(v);
            }

            return Json(vm);
        }

        private List<Employee> GetEmployeesFromFile(FileUploadViewModel file)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader reader = new StreamReader(file.fileUpload.InputStream);
            reader.ReadLine();// assuming first line is header

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                Employee e = new Employee()
                {
                    FirstName = values[0],
                    LastName = values[1],
                    Salary = int.Parse(values[2])
                };

                employees.Add(e);
            }

            return employees;
        }
	}
}