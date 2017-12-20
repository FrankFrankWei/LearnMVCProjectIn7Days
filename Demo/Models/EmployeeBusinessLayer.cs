/******************************************************************
** auth: Frank
** date: 12/16/2017 11:30:17 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.DataAccessLayer;

namespace Demo.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            //return MockData();
            SalesERPDAL dal = new SalesERPDAL();
            return dal.Employees.ToList();
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL dal = new SalesERPDAL();
            dal.Employees.Add(e);
            dal.SaveChanges();
            return e;
        }

        public bool IsValidUser(UserDetails user)
        {
            if (user.UserName == "admin" && user.Password == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region private methods
        private List<Employee> MockData()
        {
            List<Employee> employees = new List<Employee>();
            for(int i = 0; i < 10; i++)
            {
                Employee e = new Employee();
                e.FirstName = "Wei" + i;
                e.LastName = "Frank" + i;
                e.Salary = 14995 + i;

                employees.Add(e);
            }

            return employees;
        }

        #endregion
    }
}
