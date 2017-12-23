using System;
using System.Web.Mvc;

namespace Demo.Controllers
{
    //[AllowAnonymous]
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        public ActionResult Index()
        {
            Exception e = new Exception("Invalid Controller or/and Action name");
            HandleErrorInfo eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }
	}
}