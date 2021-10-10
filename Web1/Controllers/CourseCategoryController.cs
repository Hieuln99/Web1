using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web1.Models;

namespace Web1.Controllers
{
    public class CourseCategoryController : Controller
    {
        // GET: Category
        public ActionResult ViewCourse(int id)
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var name = CCCT.category.FirstOrDefault(b => b.id == id);
                TempData["category"] = $"Category: {name.Name}";
            }
            var l = new List<Course>();
            using (var CCCT = new EF.TrainingContext())
            {
                var course = CCCT.course.OrderBy(b => b.id).ToList();
                foreach(var c in course)
                {
                    if (c.categoryid == id)
                    {
                        l.Add(c);
                    }
                }
                return View(l);
            }
        }
        public ActionResult CategoryView()
        {
            using(var CCCTX = new EF.TrainingContext())
            {
                var category = CCCTX.category.OrderBy(b => b.id).ToList();
                return View(category);
            }
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(CourseCategory category)
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var cate = CCCT.category.Add(category);
                CCCT.SaveChanges();
            }
            TempData["message"] = $"Add successfully a course with id: {category.id}";
            return RedirectToAction("CategoryView");
        }
        
        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var Course = CCCT.category.FirstOrDefault(b => b.id == id);
                if(Course == null)
                {
                    return View("CategoryView");
                }
                else
                {
                    return View(Course);
                }
            }
        }
        [HttpPost]
        public ActionResult CategoryEdit(int id, CourseCategory cate)
        {
            using(var CCCT = new EF.TrainingContext())
            {
                CCCT.Entry<CourseCategory>(cate).State = System.Data.Entity.EntityState.Modified;
                CCCT.SaveChanges();
            }
            TempData["message"] = $"Edit successfully a category with id: {cate.id}";
            return RedirectToAction("CategoryView");
        }

        public ActionResult CategoryDelete(int id)
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var cate = CCCT.category.FirstOrDefault(b => b.id == id);
                if(cate != null)
                {
                    CCCT.category.Remove(cate);
                    CCCT.SaveChanges();
                }
                TempData["message"] = $"Delete successfully a category with id: {cate.id}";
                return RedirectToAction("CategoryView");
            }
        }
    }
}