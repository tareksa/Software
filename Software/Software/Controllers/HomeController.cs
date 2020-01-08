using Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Controllers
{
    public class HomeController : Controller
    {
        private Model2 mod = new Model2();
        
        public ActionResult Index()
        {
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
        public ActionResult Login(string msg) 
        {
            if(!string.IsNullOrEmpty(msg))
                TempData["ErrorMSG"] = msg;
            return View();
        }
        public ActionResult valedate(User aa) 
        {
            var loginUser = mod.User.FirstOrDefault(x => x.ID.Equals(aa.ID));
            if (loginUser != null)
            {
                if(aa.Password==null)
                    TempData["ErrorMSG"] = "The Password TextBox is recuerd";
                else if (loginUser.Password.Equals(aa.Password))
                {
                    Session["myinfo"] = loginUser.ID;
                    if (loginUser.Type == 1)
                        return RedirectToAction("Home", "Student");
                    else if (loginUser.Type == 2)
                        return RedirectToAction("Home", "Lecturer");
                    else
                        return RedirectToAction("Home", "Manager");
                }
                else
                    TempData["ErrorMSG"] = "Incorrect Password";

            }
            else
                TempData["ErrorMSG"] = "User not faund";
                return View("Login");
            
        }
    }
}