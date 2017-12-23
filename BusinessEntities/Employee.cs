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

namespace BusinessEntities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { set; get; }

        [EmployeeFirstNameValidation(ErrorMessage="Invalid first name")]
        public string FirstName { set; get; }

        [StringLength(5, ErrorMessage="Last Name length should not be greater than 5")]
        public string LastName { set; get; }

        public int? Salary { set; get; }
    }

}
