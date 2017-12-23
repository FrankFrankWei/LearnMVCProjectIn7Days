using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.SPA;
using OldViewModel = ViewModel;
using BusinessLayer;
using BusinessEntities;
using Demo.Filters;

namespace Demo.Areas.SPA.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /SPA/Main/
        public ActionResult Index()
        {
            MainViewModel mainVM = new MainViewModel();
            mainVM.UserName = User.Identity.Name;
            mainVM.FooterData = new OldViewModel.FooterViewModel();
            mainVM.FooterData.CompanyName = "StepByStepSchools";
            mainVM.FooterData.Year = DateTime.Now.Year.ToString();
            return View(mainVM);
        }

        public ActionResult EmployeeList()
        {
            EmployeeListViewModel employeeListViewModel = new ViewModel.SPA.EmployeeListViewModel();
            employeeListViewModel.Employees = new List<EmployeeViewModel>();
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();

            List<Employee> employees = bal.GetEmployees();

            foreach (var item in employees)
            {
                EmployeeViewModel vm = new EmployeeViewModel();
                vm.EmployeeName = string.Concat(item.FirstName, " ", item.LastName);
                vm.Salary = item.Salary.Value.ToString("C");
                vm.SalaryColor = item.Salary > 15000 ? "yellow" : "green";

                employeeListViewModel.Employees.Add(vm);
            }

            return View("_EmployeeList", employeeListViewModel);
        }

        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("_AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }

        [AdminFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
            return PartialView("_CreateEmployee", vm);
        }

        [AdminFilter]
        public ActionResult SaveEmployee(Employee employee)
        {
            new EmployeeBusinessLayer().SaveEmployee(employee);

            EmployeeViewModel vm = new EmployeeViewModel();
            vm.EmployeeName = string.Concat(employee.FirstName + " " + employee.LastName);
            vm.Salary = employee.Salary.Value.ToString("C");
            vm.SalaryColor = employee.Salary > 15000 ? "yellow" : "green";

            return Json(vm);
        }
    }
}