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
        [Authorize]
        public ActionResult Index()
        {
            List<Employee> employees = (new EmployeeBusinessLayer()).GetEmployees();

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.UserName = User.Identity.Name;
            employeeListViewModel.Employees = new List<EmployeeViewModel>();

            foreach (Employee e in employees)
            {
                EmployeeViewModel vm = new EmployeeViewModel();
                vm.EmployeeName = e.FirstName + " " + e.LastName;
                vm.Salary = e.Salary.Value.ToString("C");
                vm.SalaryColor = e.Salary > 15000 ? "yellow" : "green";

                employeeListViewModel.Employees.Add(vm);
            }

            employeeListViewModel.FooterData = new FooterViewModel();
            employeeListViewModel.FooterData.CompanyName = "StepByStepSchools";
            employeeListViewModel.FooterData.Year = DateTime.Now.ToString();

            return View(employeeListViewModel);
        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        public ActionResult SaveEmployee(Employee e, string btnSubmit)
        {
            switch (btnSubmit)
            {
                case "Save":
                    if (ModelState.IsValid)
                    {
                        (new EmployeeBusinessLayer()).SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;

                        if (e.Salary.HasValue)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }

                        return View("CreateEmployee", vm);
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }

            return new EmptyResult();
        }

    }
}