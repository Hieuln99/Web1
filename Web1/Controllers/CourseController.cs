using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web1.Models;

namespace Web1.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course

        private void PrepareViewBag()
        {
            using (var CCCT = new EF.TrainingContext())
            {
                ViewBag.Cate = CCCT.category.Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.id.ToString()
                }).ToList();

                //ViewBag.category = CCCT.category.ToList();
            }
        }


        //public ActionResult CourseView(int id)
        //{
        //    using(var CCCT =new EF.TrainingContext())
        //    {
        //        var course = CCCT.course.FirstOrDefault(c => c.id == id)

        //        return View(course);
        //    }
        //}

        
        private void ViewInfo(int id)
        {
            var l = new List<Trainee>();
            using (var CCCT = new EF.TrainingContext())
            {
                var t = CCCT.trainee.OrderBy(c => c.id).ToList();
                
            }
        }

        [HttpGet]
        public ActionResult CourseAdd()
        {
            PrepareViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult CourseAdd(Course course)
        {
            //customvalidation(course);
            if (!ModelState.IsValid)
            {
                PrepareViewBag();
                return View(course);
            }
            else
            {
                using(var CCCT = new EF.TrainingContext())
                {
                    CCCT.course.Add(course);
                    CCCT.SaveChanges();
                }
                TempData["message"] = $"Add successfully a course with id: {course.id}";
                return RedirectToAction("CourseView");
            }
        }
        
        [HttpGet]
        public ActionResult CourseEdit(int id)
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var course = CCCT.course.FirstOrDefault(c => c.id == id);
                if (course != null)
                {
                    PrepareViewBag();
                    return View(course);
                }
                else
                {
                    return RedirectToAction("CourseView");
                }
            }
        }
        [HttpPost]
        public ActionResult CourseEdit(int id, Course c)
        {
            //customvalidation(c);
            if (!ModelState.IsValid)
            {
                PrepareViewBag();
                return View(c);
            }
            else
            {
                using(var CCCT= new EF.TrainingContext())
                {
                    CCCT.Entry<Course>(c).State = System.Data.Entity.EntityState.Modified;
                    CCCT.SaveChanges();
                }
                TempData["message"] = $"Edit successfully a course with id: {c.id}";
                return RedirectToAction("CourseView");
            }
        }

        public ActionResult CourseDelete(int id)
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var c = CCCT.course.FirstOrDefault(b => b.id == id);
                if (c != null)
                {
                    CCCT.course.Remove(c);
                    CCCT.SaveChanges();
                }
                TempData["message"] = $"Delete successfully a course with id: {c.id}";
                return RedirectToAction("CourseView");
            }
        }

        //private void customvalidation(Course course)
        //{
        //    DateTime time1 = course.Date;
        //    DateTime time2 = new DateTime(2000, 01, 01);

        //    string mon = Convert.ToString(course.Date.Month);
        //    string da = Convert.ToString(course.Date.Year);
        //    string na = Convert.ToString(course.Name);

        //    if (!string.IsNullOrEmpty(na) && !string.IsNullOrEmpty(da) && na.Length < 6)
        //    {
        //        ModelState.AddModelError("Name", "Name must be 6 or more than characters!!!");
        //    }
        //    else if (!string.IsNullOrEmpty(na) && na[0] != 'C')
        //    {
        //        ModelState.AddModelError("Name", "Name have to start with letter C!!!");
        //    }


        //    else if (!string.IsNullOrEmpty(na) && na[5] != 'G' && !string.IsNullOrEmpty(na) && na[5] != 'I' && !string.IsNullOrEmpty(na) && na[5] != 'L')
        //    {
        //        ModelState.AddModelError("Name", "The sixth character must be G, I or L!!!");
        //    }

        //    else if (time2 > time1)
        //    {
        //        ModelState.AddModelError("Date", "Date must after 2001/01/01!!!");
        //    }


        //    else if (course.Date.Month < 10)
        //    {
        //        if (!string.IsNullOrEmpty(na) && na[3] != '0' || !string.IsNullOrEmpty(na) && na[4] != mon[0])
        //        {

        //            ModelState.AddModelError("Name", "The fourth and fifth characters must be month!!!");
        //        }

        //        else if (!string.IsNullOrEmpty(na) && na[1] != da[2] || !string.IsNullOrEmpty(na) && na[2] != da[3])
        //        {
        //            ModelState.AddModelError("name", "second and third characters must be year of start date!");
        //        }

        //    }
        //    else if (course.Date.Month >= 10)
        //    {
        //        if (!string.IsNullOrEmpty(na) && na[3] != mon[0] || !string.IsNullOrEmpty(na) && na[4] != mon[1])
        //        {
        //            ModelState.AddModelError("Name", "The fourth and fifth characters must be month!!!");
        //        }

        //        else if (!string.IsNullOrEmpty(na) && na[1] != da[2] || !string.IsNullOrEmpty(na) && na[2] != da[3])
        //        {
        //            ModelState.AddModelError("name", "second and third characters must be year of start date!");
        //        }

        //    }


        //}
    }
}