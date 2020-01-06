using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }public ActionResult CourseSchedule()
        {
            return View("Schedule");
        }public ActionResult ExamSchedule()
        {
            return View("ExamSchedule");
        }
    }
}