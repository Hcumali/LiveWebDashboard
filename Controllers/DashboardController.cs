using deneme1.DBModels;
using deneme1.MongoOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace deneme1.Controllers
{
    public class DashboardController : Controller
    {
        
        public ActionResult Index()
        {

            #region PERMISSION CONTROLS
            HttpCookie cookie_islogged = Request.Cookies["isLoggedIn"];
            // If user has the display permission for dashboard.
            if (cookie_islogged == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (cookie_islogged.Value != "True")
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            

            var view = new Models.DashboardModel();

            HttpCookie DashUserName = Request.Cookies["userName"];
            view.userName = Server.HtmlEncode(DashUserName.Value);

            view.userList = MongoOperations.UserOperations.FindAllUsers();

            return View(view);

        }

        public ActionResult SignOut()
        {
            return View();
        }

        [HttpPost]
        public Boolean DeleteUserProcess(string usernameDelete)
        {
            return UserOperations.DeleteUser(usernameDelete);
        }

        [HttpPost]
        public string GetUser(string userName)
        {
           User userInfo = MongoOperations.UserOperations.GetUserInfo(userName);
            string userInfo_str = userInfo.userName + "," + userInfo.password + "," + userInfo.Age;
            return userInfo_str;
        }
    }
}