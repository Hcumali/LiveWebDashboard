using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace deneme1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        /*public void LoginOperation(string userName, string password)
        {
            // If login operation is succesfull
            HttpCookie myCookie = new HttpCookie("isLoggedIn");
            myCookie.Value = "false";
            myCookie.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Add(myCookie);
        }*/
    }
}