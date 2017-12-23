/******************************************************************
** auth: Frank
** date: 12/23/2017 2:02:39 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.SPA
{
    public class EmployeeListViewModel
    {
        public EmployeeListViewModel()
        { }

        public List<EmployeeViewModel> Employees { set; get; }
    }
}
