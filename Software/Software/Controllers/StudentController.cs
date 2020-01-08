using Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Software.Controllers
{
    public class StudentController : Controller
    {
        private Model2 mod = new Model2();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult CourseSchedule(/*User myinfo*/)
        {
            List<GradesTb> Greads = new List<GradesTb>();
            List<CourseTb> CoursesLi = new List<CourseTb>();
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            string str = Session["myinfo"].ToString();
            bool chek = false;
            foreach (GradesTb tempData in mod.GradesTb)
            {

                if (tempData.StudentID.Equals(Session["myinfo"].ToString()))
                {
                    //get course details 
                    var courseDetails = mod.CourseTb.FirstOrDefault(x => x.ID.Equals(tempData.CourseID));
                    CoursesLi.Add(courseDetails);
                }
            }
                    
            return View("Schedule", CoursesLi);
        }
        public ActionResult ExamSchedule()
        {
            List<GradesTb> Greads = new List<GradesTb>();
            List<CourseTb> CoursesLi = new List<CourseTb>();
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            string str = Session["myinfo"].ToString();
            foreach (GradesTb tempData in mod.GradesTb)
                if (tempData.StudentID.Equals(Session["myinfo"].ToString()))
                {
                    //get course details 
                    var courseDetails = mod.CourseTb.FirstOrDefault(x => x.ID.Equals(tempData.CourseID));
                    CoursesLi.Add(courseDetails);
                }

            return View("ExamSchedule", CoursesLi);
        }
    }
}
