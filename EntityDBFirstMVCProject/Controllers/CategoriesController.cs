using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDBFirstMVCProject.Models;

namespace EntityDBFirstMVCProject.Controllers
{
    [Authorize(Roles = "A,B")]
    public class CategoriesController : Controller
    {
        // GET: Categories
        MotorMaxEntities db = new MotorMaxEntities();
        public ActionResult List(string x)
        {
            var search = from p in db.Kategorilers select p;
            if (!string.IsNullOrEmpty(x))
            {
                search = search.Where(m => m.KategoriAdı.Contains(x) || m.KategoriAciklamasi.Contains(x));
            }

            return View(search.ToList());
        }
        [HttpGet]
        public ActionResult AddCategories()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategories(Kategoriler kategoriler)
        {
            db.Kategorilers.Add(kategoriler);
            db.SaveChanges();
            return RedirectToAction("List");
        }


        [HttpGet]
        public ActionResult EditCategories(int id)
        {
            var result = db.Kategorilers.Find(id);
            return View(result);

        }
        [HttpPost]
        public ActionResult EditCategories(int id, Kategoriler kategoriler)
        {
            db.Entry(kategoriler).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult DeleteCategories(int id)
        {
            return View(db.Kategorilers.Find(id));
        }
        [HttpPost]
        public ActionResult DeleteCategories(int id, Kategoriler kategoriler)
        {
            db.Kategorilers.Remove(db.Kategorilers.Find(id));
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult DetailsCategories(int id)
        {
            return View(db.Kategorilers.Find(id));
        }
    }
}