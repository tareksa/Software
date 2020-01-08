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
        public ActionResult lecturerSchedule()
        {
            List<GradesTb> Greads = new List<GradesTb>();
            List<CourseTb> CoursesLi = new List<CourseTb>();
            string str = Session["myinfo"].ToString();
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
        public ActionResult lecturerEdit(GradesTb Greads )
        {
            return View(Greads);
        }
        
    }
}

/*

     */