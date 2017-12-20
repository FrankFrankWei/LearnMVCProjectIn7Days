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

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails user)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer bl = new EmployeeBusinessLayer();
                if (bl.IsValidUser(user))
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
            else
            {
                return View("Login");
            }
        }
    }
}