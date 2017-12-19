using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using Demo.ViewModels;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            List<Employee> employees = (new EmployeeBusinessLayer()).GetEmployees();

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.Employees = new List<EmployeeViewModel>();

            foreach (Employee e in employees)
            {
                EmployeeViewModel vm = new EmployeeViewModel();
                vm.EmployeeName = e.FirstName + " " + e.LastName;
                vm.Salary = e.Salary.ToString("C");
                vm.SalaryColor = e.Salary > 15000 ? "yellow" : "green";

                employeeListViewModel.Employees.Add(vm);
            }


            return View(employeeListViewModel);
        }
    }
}