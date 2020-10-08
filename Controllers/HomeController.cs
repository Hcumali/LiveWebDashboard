using deneme1.DBModels;
using deneme1.MongoOperations;
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

            User user = new User
            {
                userName = userNameLogin,
                password = passwordLogin
            };

            var loginCheck = UserOperations.IsThereUser(user);
            
            if(loginCheck)
            {
                // for navbar icon's add (Dashboard and Sign out) 
                HttpCookie myCookie = new HttpCookie("isLoggedIn")
                {
                    Value = "True",
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Add(myCookie);

                // for read username after entered dashboard
                HttpCookie UserNameValue = new HttpCookie("userName")
                {
                    Value = userNameLogin,
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Add(UserNameValue);

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

            User user = new User
            {
                userName = userNameRegister,
                password = passwordRegister,
                Age = age
            };

            Boolean Value = UserOperations.CreateUser(user);

            return Value;
        }

        [HttpPost]
        public void DeleteCookie(string cookieName)
        {
            Response.Cookies[cookieName].Value = "False";
        }

    }
}