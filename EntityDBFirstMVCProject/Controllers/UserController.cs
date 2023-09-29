using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDBFirstMVCProject.Models;

namespace EntityDBFirstMVCProject.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        // GET: User
        MotorMaxEntities db = new MotorMaxEntities();

        [AllowAnonymous]
        public ActionResult UserDashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(db.Müsteriler.ToList());
        }
        public ActionResult AddCustomer()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddCustomer(Müsteriler musteri)
        {
            db.Müsteriler.Add(musteri);
            db.SaveChanges();

            return RedirectToAction("List", "User");

        }
        public ActionResult EditCustomer(int id)
        {

            return View(db.Müsteriler.Find(id));
        }

        [HttpPost]
        public ActionResult EditCustomer(int id, Müsteriler musteri)
        {
            db.Entry(musteri).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List", "User");
        }

        public ActionResult DeleteCustomer(int id)
        {
            return View(db.Müsteriler.Find(id));
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int id, Müsteriler müsteri)
        {
            db.Müsteriler.Remove(db.Müsteriler.Find(id));
            db.SaveChanges();
            return RedirectToAction("List", "User");

        }

        public ActionResult DetailCustomer(int id)
        {
            return View(db.Müsteriler.Find(id));
        }
    }
}