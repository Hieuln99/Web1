using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web1.Models;
using System.Data.Entity;

namespace Web1.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        private void Prepare()
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

        public ActionResult TrainerView()
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var trainer = CCCT.trainer.OrderBy(c => c.id).ToList();
                return View(trainer);
            }
        }

        [HttpGet]
        public ActionResult TrainerAdd()
        {
            Prepare();
            return View();
        }

        [HttpPost]
        public ActionResult TrainerAdd(Trainer t, FormCollection f)
        {
            //customvalidation(t);
            if (!ModelState.IsValid)
            {
                Prepare();
                TempData["courseIds"] = f["courseIds[]"];
                return View(t);
            }
            else
            {
                using(var CCCT = new EF.TrainingContext())
                {
                    t.courses = LoadCourse(CCCT, f["courses[]"]);
                    CCCT.trainer.Add(t);
                    CCCT.SaveChanges();
                }
                TempData["message"] = $"Add successfully a trainer with id: {t.id}";
                return RedirectToAction("TrainerView");
            }
        }
        [HttpGet]
        public ActionResult TrainerEdit(int id)
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var trainer = CCCT.trainer.Include(c=>c.courses)
                                    .FirstOrDefault(b => b.id == id);
                if(trainer != null)
                {
                    Prepare();
                    return View(trainer);
                }
                else
                {
                    return RedirectToAction("TrainerView");
                }
            }
        }

        [HttpPost]
        public ActionResult TrainerEdit(int id, Trainer t, FormCollection f)
        {
            //customvalidation(t);
            if (!ModelState.IsValid)
            {
                Prepare();
                TempData["courseIds"] = f["courseIds[]"];
                return View(t);
            }
            else
            {
                using(var CCCT =new EF.TrainingContext())
                {
                    CCCT.Entry<Trainer>(t).State = System.Data.Entity.EntityState.Modified;
                    CCCT.Entry<Trainer>(t).Collection(c => c.courses).Load();
                    t.courses = LoadCourse(CCCT, f["courseIds[]"]);
                    CCCT.SaveChanges();
                }
                TempData["message"] = $"Edit successfully a trainer with id: {t.id}";
                return RedirectToAction("TrainerView");
            }
        }

        public ActionResult TrainerDelete(int id)
        {
            using(var CCCT = new EF.TrainingContext())
            {
                var trainer = CCCT.trainer.FirstOrDefault(c => c.id == id);
                if(trainer != null)
                {
                    CCCT.trainer.Remove(trainer);
                    CCCT.SaveChanges();
                }
                TempData["message"] = $"Delete successfull a trainer with id: {trainer.id}";
            }
            return RedirectToAction("TrainerView");
        }
        //private void customvalidation(Trainer trainer)
        //{
        //    string mon = Convert.ToString(trainer.DOB.Month);
        //    string ye = Convert.ToString(trainer.DOB.Year);
        //    string ss = Convert.ToString(trainer.SSID);


        //    if (!string.IsNullOrEmpty(ss) && ss.Length < 11)
        //    {
        //        ModelState.AddModelError("Name", "SSID must be more characters!!!");
        //    }
        //    else if (!string.IsNullOrEmpty(ye) && ye.Length < 4)
        //    {
        //        ModelState.AddModelError("Name", "Date is invalid!!!");
        //    }
        //    else if (!string.IsNullOrEmpty(ss) && ss[0] != '0' && !string.IsNullOrEmpty(ss) && ss[0] != '1')
        //    {
        //        ModelState.AddModelError("Name", "SSID have to start with number 0 or 1!!!");
        //    }
        //    else if (!string.IsNullOrEmpty(ss) && ss[1] != '0' && !string.IsNullOrEmpty(ss) && ss[1] != '1')
        //    {
        //        ModelState.AddModelError("Name", "SSID have second number is 0 or 1!!!");
        //    }

        //    else if (!string.IsNullOrEmpty(ye) && ss[2] != ye[2] || !string.IsNullOrEmpty(ye) && ss[3] != ye[3])
        //    {
        //        ModelState.AddModelError("Name", "The third and fourth number of SSID are year of DOB!!!");
        //    }

        //    else if (trainer.DOB.Month < 10)
        //    {
        //        if (!string.IsNullOrEmpty(ss) && ss[4] != '0' || !string.IsNullOrEmpty(ss) && ss[5] != mon[0])
        //        {

        //            ModelState.AddModelError("Name", "The fifth and sixth numbers must be month!!!");
        //        }

        //    }
        //    else if (trainer.DOB.Month >= 10)
        //    {
        //        if (!string.IsNullOrEmpty(ss) && ss[4] != mon[0] || !string.IsNullOrEmpty(ss) && ss[5] != mon[1])
        //        {
        //            ModelState.AddModelError("Name", "The fifth and sixth numbers must be month!!!");
        //        }

        //    }
        //}
    }
}