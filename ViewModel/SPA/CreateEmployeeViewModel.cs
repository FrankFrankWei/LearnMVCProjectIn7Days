/******************************************************************
** auth: Frank
** date: 12/23/2017 2:23:06 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.SPA
{
    public class CreateEmployeeViewModel
    {
        public CreateEmployeeViewModel()
        { }

        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Salary { set; get; }
    }
}
