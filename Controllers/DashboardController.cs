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
            HttpCookie cookie_islogged = Request.Cookies["isLoggedIn"];

            #region PERMISSION CONTROLS
            // If user has the display permission for dashboard.
            if (cookie_islogged == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if(cookie_islogged.Value != "True")
            {
                return RedirectToAction("Index", "Home");
            }
            #endregion

            return View();
        }

        public ActionResult SignOut()
        {
            return View();
        }
    }
}