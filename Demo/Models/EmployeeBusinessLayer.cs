/******************************************************************
** auth: Frank
** date: 12/16/2017 11:30:17 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
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
    }
}
