using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web1.Models;
using System.Data.Entity;

namespace Web1.Controllers
{
    public class TraineeController : Controller
    {
        // GET: Trainee
        private void prepare()
        {
            using(var CCCT = new EF.TrainingContext())
            {
                ViewBag.Course = CCCT.course.ToList();
            }
        }

        private List<Course> LoadCourse(EF.TrainingContext CCCT, string form)
        {
            if (form != null)
            {
                var selected = form.Split(',').Select(id => Int32.Parse(id)).ToArray();
                return CCCT.course.Where(c => selected.Contains(c.id)).ToList();
            }
            else
            {
                return CCCT.course.Where(c => c.id == 0).ToList();
            }
        }

        public ActionResult TraineeView()
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var trainee = CCCT.trainee.OrderBy(c => c.id).ToList();
                return View(trainee);
            }
        }

        [HttpGet]
        public ActionResult TraineeAdd()
        {
            prepare();
            return View();
        }

        [HttpPost]
        public ActionResult TraineeAdd(Trainee t, FormCollection f)
        {
            //customvalidation(t);
            if (!ModelState.IsValid)
            {
                prepare();
                TempData["courseIds"] = f["courseIds[]"];
                return View(t);
            }
            else
            {
                using(var CCCT = new EF.TrainingContext())
                {
                    t.courses = LoadCourse(CCCT, f["courses[]"]);
                    CCCT.trainee.Add(t);
                    CCCT.SaveChanges();
                }
                TempData["message"] = $"Add successfully a trainee with id: {t.id}";
                return RedirectToAction("TraineeView");
            }
        }


        [HttpGet]
        public ActionResult TraineeEdit(int id)
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var trainee = CCCT.trainee.Include(c=>c.courses)
                    .FirstOrDefault(t => t.id == id);
                if(trainee != null)
                {
                    prepare();
                    return View(trainee);
                }
                else
                {
                    return RedirectToAction("TraineeView");
                }
            }
        }

        [HttpPost]
        public ActionResult TraineeEdit(int id, Trainee t, FormCollection f)
        {
            //customvalidation(t);
            if (!ModelState.IsValid)
            {
                prepare();
                TempData["courseIds"] = f["courseIds[]"];
                return View(t);
            }
            else
            {
                using(var CCCT = new EF.TrainingContext())
                {
                    CCCT.Entry<Trainee>(t).State = System.Data.Entity.EntityState.Modified;
                    CCCT.Entry<Trainee>(t).Collection(c => c.courses).Load();
                    t.courses = LoadCourse(CCCT, f["courseIds[]"]);
                    CCCT.SaveChanges();
                }
                TempData["message"] = $"Edit successfully a trainee with id: {t.id}";
                return RedirectToAction("TraineeView");
            }
        }

        public ActionResult TraineeDelete(int id)
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var trainee = CCCT.trainee.FirstOrDefault(t => t.id == id);
                if(trainee != null)
                {
                    CCCT.trainee.Remove(trainee);
                    CCCT.SaveChanges();
                }

                TempData["message"] = $"Delete successfully a trainee with id: {trainee.id}";
                return RedirectToAction("TraineeView");
            }
        }

        //private void customvalidation(Trainee t)
        //{

        //    string co = Convert.ToString(t.Contact);

        //    if (!string.IsNullOrEmpty(co) && co[0] != '0')
        //    {
        //        ModelState.AddModelError("Name", "Contact have to start with number 0!!!");
        //    }

        //}
    }
}