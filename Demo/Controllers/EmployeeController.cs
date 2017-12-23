using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Demo.Filters;
using BusinessLayer;
using BusinessEntities;
using ViewModel;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        [Authorize]
        [HeaderFooterFilter]
        public ActionResult Index()
        {
            List<Employee> employees = (new EmployeeBusinessLayer()).GetEmployees();

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.Employees = new List<EmployeeViewModel>();

            foreach (Employee e in employees)
            {
                EmployeeViewModel vm = new EmployeeViewModel();
                vm.EmployeeName = e.FirstName + " " + e.LastName;
                vm.Salary = e.Salary.Value.ToString("C");
                vm.SalaryColor = e.Salary > 15000 ? "yellow" : "green";

                employeeListViewModel.Employees.Add(vm);
            }

            return View(employeeListViewModel);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel vm = new CreateEmployeeViewModel();

            return View("CreateEmployee", vm);
        }

        [AdminFilter]
        [HeaderFooterFilter]
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

        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}