/******************************************************************
** auth: Frank
** date: 12/16/2017 11:24:55 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModel
{
    public class EmployeeListViewModel : BaseViewModel
    {
        public List<EmployeeViewModel> Employees { set; get; }
    }
}
