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
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult One()
        {
            return View();
        }
        public ActionResult CheckOne(User aa)
        {
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
            return View(mod.CourseTb);
        }
        public ActionResult Edit(string UserID)
        {
            Session["User"] = UserID;
            return View();
        }
        public ActionResult CheckEdit(CourseTb temp)
        {

            var cou = mod.CourseTb.Find(Session["User"]);

 

            if (temp.Name != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Name = temp.Name;
                mod.CourseTb.Add(cou);
                mod.SaveChanges();
            }
            else if (temp.Points != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Points = temp.Points;
                mod.CourseTb.Add(cou);
                mod.SaveChanges();
            }
            else if (temp.ExamA != null)
            {
                mod.CourseTb.Remove(cou);
                cou.ExamA = temp.ExamA;
                mod.CourseTb.Add(cou);
                mod.SaveChanges();
            }
            else if (temp.ExamB != null)
            {
                mod.CourseTb.Remove(cou);
                cou.ExamB = temp.ExamB;
                mod.CourseTb.Add(cou);
                mod.SaveChanges();
            }
            else if (temp.Lecturer != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Lecturer = temp.Lecturer;
                mod.CourseTb.Add(cou);
                mod.SaveChanges();
            }
            else if (temp.Time != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Time = temp.Time;
                mod.CourseTb.Add(cou);
                mod.SaveChanges();
            }
            else if (temp.Day != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Day = temp.Day;
                mod.CourseTb.Add(cou);
                mod.SaveChanges();
            }
            else if (temp.Class != null)
            {
                mod.CourseTb.Remove(cou);
                cou.Class = temp.Class;
                mod.CourseTb.Add(cou);
                mod.SaveChanges();
            }


            return View();
        }
    }
}