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
            var students = new List<string>();
            var aa=mod.User.FirstOrDefault(x => x.Type.Equals(1));
            if (aa.Type == 1)
                students.Add(aa.ID.ToString());

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