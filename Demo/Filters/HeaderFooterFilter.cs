/******************************************************************
** auth: Frank
** date: 12/21/2017 9:30:51 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.ViewModels;

namespace Demo.Filters
{
    public class HeaderFooterFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewResult result = filterContext.Result as ViewResult;

            if (result != null)
            {
                BaseViewModel bvm = result.Model as BaseViewModel;
                if (bvm != null)
                {
                    bvm.UserName = filterContext.HttpContext.User.Identity.Name;
                    bvm.FooterData = new FooterViewModel();
                    bvm.FooterData.CompanyName = "StepByStepSchools";
                    bvm.FooterData.Year = DateTime.Now.Year.ToString();
                }
            }
        }
    }
}
