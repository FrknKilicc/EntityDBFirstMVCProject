using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDBFirstMVCProject.Models;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;

namespace EntityDBFirstMVCProject.Controllers
{
    [AllowAnonymous]
    public class ProductsController : Controller
    {
        // GET: Products
        MotorMaxEntities db = new MotorMaxEntities();

        public ActionResult List(string searchString)
        {
            var products = db.Urunlers
        .Include(x => x.Kategoriler)
        .Include(y => y.Tedarikciler);

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p =>
                    p.ÜrünAdi.Contains(searchString) ||
                    p.ÜrünMarkasi.Contains(searchString)
                );
            }

            return View("List", products.ToList());

        }

        [HttpGet]
        public ActionResult AddProducts()
        {

            List<SelectListItem> datas = (from x in db.Kategorilers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAdı,
                                              Value = x.KategoriID.ToString(),


                                          }).ToList();
            List<SelectListItem> dataa = (from y in db.Tedarikcilers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = y.TedarikciAdı,
                                              Value = y.TedarikciID.ToString(),
                                          }).ToList();

            ViewBag.kategoriData = datas;
            ViewBag.tedarikciData = dataa;
            return View();




        }
        [HttpPost]
        public ActionResult AddProducts(Urunler urun)
        {
            try
            {
                db.Urunlers.Add(urun);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            catch (Exception)
            {

                return View();

            }
        }
        [HttpGet]
        public ActionResult DeleteProducts(int id)
        {
            var result = db.Urunlers.Find(id);
            return View(result);
        }
        public ActionResult DeleteProducts(int id, Urunler urun)
        {
            db.Urunlers.Remove(db.Urunlers.Find(id));
            db.SaveChanges();
            return RedirectToAction("List");
        }


        [HttpGet]
        public ActionResult EditProducts(int id)
        {
            List<SelectListItem> datas = (from x in db.Kategorilers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAdı,
                                              Value = x.KategoriID.ToString()
                                          }).ToList();

            ViewBag.kategoridata = datas;
            List<SelectListItem> data = (from y in db.Tedarikcilers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = y.TedarikciAdı,
                                             Value = y.TedarikciID.ToString()

                                         }).ToList();
            ViewBag.tedarikcidata = data;

            var result = db.Urunlers.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditProducts(int id, Urunler urun)
        {


            db.Entry(urun).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult DetailsProduct(int id)
        {
            return View(db.Urunlers.Find(id));
        }

       




    }
}