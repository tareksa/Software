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
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            return View();
        }
        public ActionResult Home()
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            return View();
        }
        public ActionResult One()
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            return View();
        }
        public ActionResult CheckOne(User aa)
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            bool ch = false;
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
            CourseTb temp1 = new CourseTb();
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
            newSt.StudentID = aa.ID.ToString();
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
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            return View(mod.CourseTb);
        }
        public ActionResult Edit(CourseTb couID)
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            Session["User"] = couID.ID;
            return View();
        }
        public ActionResult CheckEdit(CourseTb temp)
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            var stam = Session["User"];

            CourseTb cou = new CourseTb(), course = new CourseTb();

            foreach (CourseTb sd in mod.CourseTb)
                if (stam.Equals(sd.ID))
                {
                    course = sd;
                    cou = sd;
                }


            if (temp.Name != null)
                cou.Name = temp.Name;
            if (temp.Points != null)
                cou.Points = temp.Points;
            if (!temp.ExamA.Equals(null))
                cou.ExamA = temp.ExamA;
            if (!temp.ExamB.Equals(null))
                cou.ExamB = temp.ExamB;
            if (temp.Lecturer != null)
                cou.Lecturer = temp.Lecturer;
            if (temp.Time != null)
                cou.Time = temp.Time;
            if (temp.Day != null)
                cou.Day = temp.Day;
            if (temp.Class != null)
                cou.Class = temp.Class;

            if (!course.Equals(cou))
            {
                mod.CourseTb.Remove(cou);
                mod.CourseTb.Add(cou);
                mod.SaveChanges();
            }

            return View("Edit");
        }
        public ActionResult Three()
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            return View(mod.GradesTb);
        }
        public ActionResult CheckThree()
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            return View("Three", mod.GradesTb);
        }
        public ActionResult Four(GradesTb user)
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            //GradesTb Gread = new GradesTb();
            //foreach (GradesTb tempg in mod.GradesTb)
            //    if (tempg.StudentID.Equals(user.StudentID))
            //        if (tempg.CourseID.Equals(user.CourseID))
            //            return View(tempg);
            return View(user);
        }
        public ActionResult EditThree(GradesTb user)
        {
            //var courseDetails = mod.CourseTb.FirstOrDefault(x => x.ID.Equals(user.CourseID));
            //DateTime Adate = courseDetails.ExamA, Bdate = courseDetails.ExamB, datetoday = DateTime.Now;
            //bool exA = true, exB = true;
            bool exA = true, exB = true;
            string datetoday = DateTime.Now.ToString("yyyy-MM-dd");
            double Byear = 0, year = 0, Tyear = Char.GetNumericValue(datetoday[0]) * 1000 + Char.GetNumericValue(datetoday[1]) * 100 + Char.GetNumericValue(datetoday[2]) * 10 + Char.GetNumericValue(datetoday[3]);
            double Bmonth = 0, month = 0, Tmonth = Char.GetNumericValue(datetoday[5]) * 10 + Char.GetNumericValue(datetoday[6]);
            double Bday = 0, day = 0, Tday = Char.GetNumericValue(datetoday[8]) * 10 + Char.GetNumericValue(datetoday[9]);
            foreach (CourseTb tempData in mod.CourseTb)
                if (tempData.ID.Equals(user.CourseID))
                {
                    string Adate = tempData.ExamA, Bdate = tempData.ExamB;
                    year = Char.GetNumericValue(Adate[0]) * 1000 + Char.GetNumericValue(Adate[1]) * 100 + Char.GetNumericValue(Adate[2]) * 10 + Char.GetNumericValue(Adate[3]);
                    month = Char.GetNumericValue(Adate[5]) * 10 + Char.GetNumericValue(Adate[6]);
                    day = Char.GetNumericValue(Adate[8]) * 10 + Char.GetNumericValue(Adate[9]);
                    Byear = Char.GetNumericValue(Bdate[0]) * 1000 + Char.GetNumericValue(Bdate[1]) * 100 + Char.GetNumericValue(Bdate[2]) * 10 + Char.GetNumericValue(Bdate[3]);
                    Bmonth = Char.GetNumericValue(Bdate[5]) * 10 + Char.GetNumericValue(Bdate[6]);
                    Bday = Char.GetNumericValue(Bdate[8]) * 10 + Char.GetNumericValue(Bdate[9]);
                    break;
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
                else
                {
                    //if (DateTime.Compare(datetoday, Adate) > 0)
                    //    exA = false;
                    if (year < Tyear) exA = true;
                    else if (year > Tyear) exA = false;
                    else if (year == Tyear)
                    {
                        if (month < Tmonth) exA = true;
                        else if (month > Tmonth) exA = true;
                        else if (day < Tday) exA = true;
                        else if (day > Tday) exA = false;
                        else exA = true;
                    }
                    if (!exA) TempData["errormsg"] = "Exam A yet to come";
                }

            if (user.GradeB != null)
                if (!(user.GradeB <= 100 && user.GradeB >= 0))
                    TempData["errormsg"] = "Gread B, must be in range [0,100]";
                else
                {

                    //if (DateTime.Compare(datetoday, Bdate) > 0)
                    //    exB = false;
                    if (Byear < Tyear) exB = true;
                    else if (Byear > Tyear) exB = false;
                    else if (Byear == Tyear)
                    {
                        if (Bmonth < Tmonth) exB = true;
                        else if (Bmonth > Tmonth) exB = true;
                        else if (Bday < Tday) exB = true;
                        else if (Bday > Tday) exB = false;
                        else exB = true;
                    }
                    if (!exB) TempData["errormsg"] = "Exam B yet to come";
                }



            List<GradesTb> Gread = new List<GradesTb>();
            if (exA)
                if (exB)
                {
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
                        TempData["confirmmsg"] = "Updated";
                    }

                }

            return View("Four");
        }
        public ActionResult Create()
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            return View("CheckOne");
        }
        public ActionResult CheckCreate(CourseTb temp)
        {
            if (Session["myinfo"] == null)
            {
                ViewBag.lol = "You have to login First";
                return RedirectToAction("Login", "Home", new { msg = ViewBag.lol });
            }
            if (temp.ID == null)
            {
                TempData["errormsg"] = "You must enter ID";
                return View("CheckOne");
            }
            foreach (CourseTb stam in mod.CourseTb)
            {
                if (stam.ID == temp.ID)
                {
                    TempData["errormsg"] = "ID Exist";
                    return View("CheckOne");
                }
            }
            if (temp.Name == null)
                TempData["errormsg"] = "You must enter Name";
            else if (temp.Points == null)
                TempData["errormsg"] = "You must enter Points";
            else if (temp.Time == null)
                TempData["errormsg"] = "You must enter Time";
            else if (temp.ExamA.Equals(null))
                TempData["errormsg"] = "You must enter ExamA";
            else if (temp.ExamB.Equals(null))
                TempData["errormsg"] = "You must enter ExamB";
            else if (temp.Day == null)
                TempData["errormsg"] = "You must enter Day";
            else if (temp.Class == null)
                TempData["errormsg"] = "You must enter Class";
            else
            {
                mod.CourseTb.Add(temp);
                mod.SaveChanges();
                TempData["confirmMsg"] = "Updated ";

            }


            return View("CheckOne");
        }

    }
}