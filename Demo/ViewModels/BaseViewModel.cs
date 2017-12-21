/******************************************************************
** auth: Frank
** date: 12/21/2017 8:52:22 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.ViewModels
{
    public class BaseViewModel
    {
        public string UserName { set; get; }
        public FooterViewModel FooterData { set; get; }
    }
}
