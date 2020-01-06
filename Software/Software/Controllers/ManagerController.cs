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

                return View(mod.User);
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