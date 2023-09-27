using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDBFirstMVCProject.Models;

namespace EntityDBFirstMVCProject.Controllers
{
    [Authorize(Roles = "A,B")]
    public class LogisticsController : Controller
    {

        // GET: Logistics
        MotorMaxEntities db = new MotorMaxEntities();
        public ActionResult List(string x)
        {
            var search = from p in db.Lojistiks select p;
            if (!string.IsNullOrEmpty(x))
            {
                search = search.Where(m => m.LojistikFirmaAdi.Contains(x) || m.FirmaTel.Contains(x));
            }

            return View(search.ToList());
        }

        public ActionResult AddLogistics()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLogistics(Lojistik logi)
        {
            db.Lojistiks.Add(logi);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult EditLogistics(int id)
        {
            return View(db.Lojistiks.Find(id));
        }

        [HttpPost]
        public ActionResult EditLogistics(int id, Lojistik logi)
        {
            db.Entry(logi).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult DeleteLogistics(int id)
        {
            return View(db.Lojistiks.Find(id));
        }

        [HttpPost]
        public ActionResult DeleteLogistics(int id, Lojistik logi)
        {
            db.Lojistiks.Remove(db.Lojistiks.Find(id));
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult DetailLogistics(int id)
        {
            return View(db.Lojistiks.Find(id));
        }
    }

}