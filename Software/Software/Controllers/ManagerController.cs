﻿using System;
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
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            return View();
        }
        public ActionResult Home()
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            return View();
        }
        public ActionResult One()
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            return View();
        }
        public ActionResult CheckOne(User aa)
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            bool ch=false;
            foreach (User temp in mod.User)
            {
                if (aa.ID == temp.ID && temp.Type.Equals(1))
                {
                    ch = true;
                }
            }
            if (!ch)
            {
                TempData["temp1"] = " Student not found";
                return View("One");
            }
            ch = false;
            foreach (CourseTb temp in mod.CourseTb)
            {
                if (aa.Lname == temp.ID)
                {
                    ch = true;
                }
            }
            if (!ch)
            {
                TempData["temp1"] = " Course not found";
                return View("One");
            }

            foreach (GradesTb temp in mod.GradesTb) 
            {
                if (aa.ID.ToString() == temp.StudentID && aa.Lname == temp.CourseID)
                {
                    TempData["temp1"] = "The student already in course";
                    return View("One");
                }
            }
            foreach (GradesTb temp in mod.GradesTb)
            {
                if (aa.ID.ToString() == temp.StudentID && aa.Lname == temp.CourseID)
                {
                    TempData["temp1"] = "The student already in course";
                    return View("One");
                }
            }
            CourseTb temp1=new CourseTb(); 
            foreach (CourseTb temp in mod.CourseTb)
            {
                if (aa.Lname == temp.ID)
                {
                    temp1 = temp;
                }
            }
            foreach (CourseTb temp in mod.CourseTb)
            {
                if (temp1.Day == temp.Day && temp1.Time == temp.Time && temp1.ID != temp.ID)
                {
                    TempData["temp1"] = "The course time is busy";
                    return View("One");
                }
            }
            GradesTb newSt = new GradesTb();
            newSt.CourseID = aa.Lname;
            newSt.StudentID= aa.ID.ToString();
            newSt.GradeB = null;
            newSt.GradeA = null;
            mod.GradesTb.Add(newSt);
            mod.SaveChanges();
            TempData["temp1"] = "Done!";
            return View("One");
        }
        public ActionResult Two()
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            return View(mod.CourseTb);
        }
        public ActionResult Edit(CourseTb couID)
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            Session["User"] = couID.ID;
            return View();
        }
        public ActionResult CheckEdit(CourseTb temp)
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            var stam = Session["User"];

            CourseTb cou = new CourseTb();
            foreach (CourseTb sd in mod.CourseTb)
            {
                if (stam.Equals(sd.ID))
                {
                    cou = sd;
                }
            }



            if (temp.Name != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Name = temp.Name;
                mod.CourseTb.Add(cou);
                //mod.SaveChanges();
            }
            else if (temp.Points != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Points = temp.Points;
                mod.CourseTb.Add(cou);
                //mod.SaveChanges();
            }
            else if (temp.ExamA != null)
            {
                mod.CourseTb.Remove(cou);
                cou.ExamA = temp.ExamA;
                mod.CourseTb.Add(cou);
               // mod.SaveChanges();
            }
            else if (temp.ExamB != null)
            {
                mod.CourseTb.Remove(cou);
                cou.ExamB = temp.ExamB;
                mod.CourseTb.Add(cou);
                //mod.SaveChanges();
            }
            else if (temp.Lecturer != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Lecturer = temp.Lecturer;
                mod.CourseTb.Add(cou);
                //mod.SaveChanges();
            }
            else if (temp.Time != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Time = temp.Time;
                mod.CourseTb.Add(cou);
                //mod.SaveChanges();
            }
            else if (temp.Day != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Day = temp.Day;
                mod.CourseTb.Add(cou);
               // mod.SaveChanges();
            }
            else if (temp.Class != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Class = temp.Class;
                mod.CourseTb.Add(cou);
                //mod.SaveChanges();
            }


            return View("Edit");
        }
        public ActionResult Three()
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            return View(mod.GradesTb);
        }
        public ActionResult CheckThree()
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            return View("Three",mod.GradesTb);
        }
        public ActionResult EditThree(GradesTb user)
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol= "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
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
                //mod.SaveChanges();
                TempData["confirmmsg"] = "Updated ";
            }


            //return View(mod.GradesTb.FirstOrDefault(x => x.StudentID.Equals("1")));
            return View("Four");
        }
        public ActionResult Create()
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            return View("CheckOne");
        }
        public ActionResult CheckCreate(CourseTb temp)
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", ViewBag.lol);
            }
            if (temp.ID == null)
            {
                TempData["errormsg"] = "You must enter ID";
                return View("CheckOne");
            }
            foreach(CourseTb stam in mod.CourseTb)
            {
                if(stam.ID==temp.ID)
                {
                    TempData["errormsg"] = "ID Exist";
                    return View("CheckOne");
                }
            }
            if(temp.Name==null)
                TempData["errormsg"] = "You must enter Name";
            else if (temp.Points == null)
                TempData["errormsg"] = "You must enter Points";
            else if (temp.Time == null)
                TempData["errormsg"] = "You must enter Time";
            else if (temp.ExamA == null)
                TempData["errormsg"] = "You must enter ExamA";
            else if (temp.ExamB == null)
                TempData["errormsg"] = "You must enter ExamB";
            else if (temp.Day == null)
                TempData["errormsg"] = "You must enter Day";
            else if (temp.Class == null)
                TempData["errormsg"] = "You must enter Class";
            else
            {
                mod.CourseTb.Add(temp);
                mod.SaveChanges();
                TempData["confirmmsg"] = "Updated ";

            }


            return View("CheckOne");
        }

    }
}