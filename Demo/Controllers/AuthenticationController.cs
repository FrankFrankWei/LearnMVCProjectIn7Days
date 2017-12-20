using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using System.Web.Security;

namespace Demo.Controllers
{
    //[AllowAnonymous]
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails user)
        {
            EmployeeBusinessLayer bl = new EmployeeBusinessLayer();
            if(bl.IsValidUser(user))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Invalid user name or password");
                return View("Login");
            }
        }
	}
}