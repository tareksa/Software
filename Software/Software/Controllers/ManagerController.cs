using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Software.Models;

namespace Software.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        private Model2 mod = new Model2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult One()
        {
            List<User> users=new List<User>();
            List<CourseTb> courses = new List<CourseTb>();
            users.Add(mod.User.FirstOrDefault(x => x.Type.Equals(1)));
            courses.Add(mod.CourseTb.FirstOrDefault());
            foreach (User bb in mod.User)
            {
                if (bb.Type.Equals( 1))
                    users.Add(bb);
            }
            foreach (CourseTb bb in mod.CourseTb)
            {
                    courses.Add(bb);
            }
            TempData["temp"] = users;
            TempData["temp1"] = courses;

            ViewBag.MyList1 = TempData["temp"];
            ViewBag.MyList2 = TempData["temp1"];
            return View();
        }
        public ActionResult Two()
        {
            return View();
        }
        public ActionResult Three()
        {
            return View();
        }
        public ActionResult Four()
        {
            return View();
        }
    }
}