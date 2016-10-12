using Phonebook.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Phonebook.Website.Controllers
{
    public class AccountController : Controller
    {
        IUserController cont = ControllerFactory.CreateUserController();
        
        [HttpGet]
        public ActionResult Login()
        {
            //display login form
            return View();
        }

        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home"); //redirect to home
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            var user = cont.GetUser(username, password);

            if(user != null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.SetAuthCookie("username", false);
                return RedirectToAction("Index", "Contact");
            }
            
            ModelState.AddModelError("", "error logging in");
            return View();
        }
    }
}