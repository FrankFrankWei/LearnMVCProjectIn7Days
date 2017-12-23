using BusinessEntities;
using BusinessLayer;
using System.Web.Mvc;
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
                UserStatus userStatus = bl.GetUserStatus(user);
                bool isAdmin = false;

                if (userStatus == UserStatus.AuthenticatedAdmin)
                {
                    isAdmin = true;
                }
                else if (userStatus == UserStatus.AuthenticatedUser)
                {
                    isAdmin = false;
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid user name or password");
                    return View("Login");
                }

                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["IsAdmin"] = isAdmin;
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View("Login");
            }
        }
    }
}