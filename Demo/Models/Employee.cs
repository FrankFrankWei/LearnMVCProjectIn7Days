/******************************************************************
** auth: Frank
** date: 12/15/2017 10:39:31 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public float Salary { set; get; }
    }
}
