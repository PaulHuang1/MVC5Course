using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginViewModel login, string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                if (login.Email == "paul19890524@gmail.com" && login.Password == "123")
                {
                    FormsAuthentication.RedirectFromLoginPage(login.Email, false);
                    return Redirect(ReturnUrl ?? "/");
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}