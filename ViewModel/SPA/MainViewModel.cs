/******************************************************************
** auth: Frank
** date: 12/23/2017 1:23:46 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.SPA
{
    public class MainViewModel
    {
        public MainViewModel()
        { }

        public string UserName { set; get; }
        public FooterViewModel FooterData { set; get; }
    }
}
