/******************************************************************
** auth: Frank
** date: 12/19/2017 9:45:52 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModel
{
    public class CreateEmployeeViewModel : BaseViewModel
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Salary { set; get; }
    }
}
