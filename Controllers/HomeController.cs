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

        [HttpPost]
        public Boolean LoginProcess(string userNameLogin, string passwordLogin)
        {
            if(userNameLogin=="admin" && passwordLogin == "1234")
            {
                HttpCookie myCookie = new HttpCookie("isLoggedIn");
                myCookie.Value = "True";
                myCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(myCookie);

                return true;
        
            }
            else
            {
                return false;
            }
            
        }

        [HttpPost]
        public Boolean RegisterProcess(string userNameRegister, string passwordRegister, int age)
        {
            if (userNameRegister != "yyyyy000" && passwordRegister != "12345678" && age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }

        }





    }
}