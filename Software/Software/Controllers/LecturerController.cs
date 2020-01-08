using Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Controllers
{
    public class LecturerController : Controller
    {
        private Model2 mod = new Model2();
        // GET: Lecturer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();

        }
        public ActionResult chekSession(object ss)
        {
            if (ss == null)
                return RedirectToAction("Login", "Home", "You need to log in first");
            return View();
        }
        public ActionResult lecturerSchedule()
        {
            List<GradesTb> Greads = new List<GradesTb>();
            List<CourseTb> CoursesLi = new List<CourseTb>();
            chekSession(Session["myinfo"]);

            foreach (CourseTb tempData in mod.CourseTb)
                if (tempData.Lecturer.Equals(Session["myinfo"].ToString()))
                {
                    //get course details 
                    //var courseDetails = mod.CourseTb.FirstOrDefault(x => x.ID.Equals(tempData.CourseID));
                    CoursesLi.Add(tempData);
                }
            return View(CoursesLi);
        }
        public ActionResult lecturStudents()
        {
            List<GradesTb> Greads = new List<GradesTb>();
            List<CourseTb> CoursesLi = new List<CourseTb>();
            List<User> StudentsIN = new List<User>();
            List<string> userid = new List<string>();
            chekSession(Session["myinfo"]);
            string str = Session["myinfo"].ToString();
            //return a list of lecturer courses
            foreach (CourseTb tempData in mod.CourseTb)
                if (tempData.Lecturer.Equals(Session["myinfo"].ToString()))
                    CoursesLi.Add(tempData);

            //return a list of student's for every lecturer's courses
            foreach (CourseTb tempc in CoursesLi)
                foreach (GradesTb tempg in mod.GradesTb)
                    if (tempg.CourseID.Equals(tempc.ID))
                        userid.Add(tempg.StudentID);

            //return a list of student Data for every lecturer's courses
            foreach (User St in mod.User)
                foreach (string UID in userid)
                    if (UID.Equals(St.ID.ToString()))
                        StudentsIN.Add(St);
            //        StudentsIN.Add(tempData);
            return View(StudentsIN);
        }
        public ActionResult lecturerGreads()
        {

            List<GradesTb> Greads = new List<GradesTb>();
            List<CourseTb> CoursesLi = new List<CourseTb>();

            chekSession(Session["myinfo"]);

            //return a list of lecturer courses
            foreach (CourseTb tempData in mod.CourseTb)
                if (tempData.Lecturer.Equals(Session["myinfo"].ToString()))
                    CoursesLi.Add(tempData);

            //return a list of student's for every lecturer's courses
            foreach (CourseTb tempc in CoursesLi)
                foreach (GradesTb tempg in mod.GradesTb)
                    if (tempg.CourseID.Equals(tempc.ID))
                        Greads.Add(tempg);

            return View(Greads);
        }

        public ActionResult lecturerEdit(string StudentID, string CourseID)
        {
            chekSession(Session["myinfo"]);
            GradesTb Gread = new GradesTb();
            foreach (GradesTb tempg in mod.GradesTb)
                if (tempg.StudentID.Equals(StudentID))
                    if (tempg.CourseID.Equals(CourseID))
                        return View(tempg);

            //return View(mod.GradesTb.FirstOrDefault(x => x.StudentID.Equals("1")));
            return View();
        }
        public ActionResult chkEdit(GradesTb user)
        {
            GradesTb Greaddddd = new GradesTb();
            if (user == null)
                TempData["errormsg"] = "ERROR! Fill in again ";
            if (user.StudentID == null)
                TempData["errormsg"] = "Fill in StudentID ";
            if (user.CourseID == null)
                TempData["errormsg"] = "Fill in CourseID ";
            if (user.GradeA != null)
                if (!(user.GradeA <= 100 && user.GradeA >= 0))
                    TempData["errormsg"] = "Gread A, must be in range [0,100]";
            if (user.GradeB != null)
                if (!(user.GradeB <= 100 && user.GradeB >= 0))
                    TempData["errormsg"] = "Gread B, must be in range [0,100]";
            List<GradesTb> Gread = new List<GradesTb>();
            foreach (GradesTb tempg in mod.GradesTb)
                if (tempg.StudentID.Equals(user.StudentID))
                    if (tempg.CourseID.Equals(user.CourseID))
                    { Greaddddd = tempg; Gread.Add(tempg); Gread.Add(user); break; }
            if (Greaddddd == null || Greaddddd == null || Greaddddd.CourseID == null || Greaddddd.StudentID == null)
                TempData["errormsg"] = "Course/Student not found ";
            else
            {
                mod.GradesTb.Remove(Greaddddd);
                mod.GradesTb.Add(user);
                mod.SaveChanges();
                TempData["confirmmsg"] = "Updated ";
            }


                //return View(mod.GradesTb.FirstOrDefault(x => x.StudentID.Equals("1")));
                return View("lecturerEdit");
        }
        public ActionResult EditGread(List<GradesTb> newStudent)
        {
            
            mod.GradesTb.Remove(newStudent[1]);
            mod.GradesTb.Add(newStudent[0]);
            mod.SaveChanges();


            return View();
        }
    }
}

/*

     */
