using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDBFirstMVCProject.Models;

namespace EntityDBFirstMVCProject.Controllers
{
    [AllowAnonymous]

    public class SuppliersController : Controller
    {
        MotorMaxEntities db = new MotorMaxEntities();
        // GET: Suppliers
        public ActionResult Index(string x)
        {
            var search = from y in db.Tedarikcilers select y;
            if (x != null)
            {
                search = search.Where(m => m.TedarikciAdı.Contains(x) || m.TedarikciÜlke.Contains(x));
            }
            return View(search.ToList());

         
        }
        [HttpGet]
        public ActionResult AddSuppliers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSuppliers(Tedarikciler tedarikci)
        {
            try
            {
                db.Tedarikcilers.Add(tedarikci);
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpGet]
        public ActionResult DeleteSuppliers(int id)
        {
            var result = db.Tedarikcilers.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult DeleteSuppliers(int id, Tedarikciler tedarikci)
        {
           
            db.Tedarikcilers.Remove(db.Tedarikcilers.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSuppliers(int id)
        {
            var result = db.Tedarikcilers.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditSuppliers(int id, Tedarikciler tedarikci)
        {
            db.Entry(tedarikci).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var result = db.Tedarikcilers.Find(id);
            return View(result);
        }
      
    }
}