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
        public ActionResult Login() 
        {
            return View();
        }
        public ActionResult valedate(User aa) 
        {
            var loginUser = mod.User.FirstOrDefault(x => x.ID.Equals(aa.ID));
            if (loginUser != null)
            {
                if (aa.Password.Equals(loginUser.Password))
                {
                    if(loginUser.Type.Equals(1))
                        return RedirectToAction("Student", "Home");
                    else if(loginUser.Type==2)
                        return RedirectToAction("Lecturer", "Home");
                    else if(loginUser.Type==3)
                        return RedirectToAction("Manager", "Home");
                    else return RedirectToAction("Login", "Home");
                }

            }
            return View("Check");
        }
        public ActionResult Student()
        {
            return View();
        }
        public ActionResult Lecturer()
        {
            return View();
        }

        public ActionResult Manager()
        {
            return View();
        }
    }
}