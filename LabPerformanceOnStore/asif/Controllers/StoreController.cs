using asif.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asif.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Product()
        {
            var db = new StoreEntities();
            var data = db.Products.ToList();

            return View(data);
        }

        public ActionResult Category()
        {
            var db = new StoreEntities();
            var data = db.Categories.ToList();

            return View(data);
        }

        #region

        [HttpGet]
        public ActionResult CreateProduct()
        {
            var db = new StoreEntities();
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {

            var db = new StoreEntities();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Product");


        }

        public ActionResult DeleteProduct(int id)
        {
            var db = new StoreEntities();
            var data = db.Products.Find(id);
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Product");
        }




        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var db = new StoreEntities();
            ViewBag.Categories = db.Categories.ToList();
            var data = (from p in db.Products
                        where p.Id == id
                        select p).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            var db = new StoreEntities();
            var data = db.Products.Find(p.Id);
            data.Name = p.Name;
            data.Price = p.Price;
            data.CategoryId = p.CategoryId;
            data.Description = p.Description;
            db.SaveChanges();


            return RedirectToAction("Product");

        }
        #endregion

        [HttpGet]
        public ActionResult CreateCategory()
        {
            var db = new StoreEntities();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category c)
        {

            var db = new StoreEntities();
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Category");


        }

        public ActionResult DeleteCategory(int id)
        {
            var db = new StoreEntities();
            var data = db.Categories.Find(id);
            db.Categories.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        public ActionResult EditCategory(int id)
        {
            var db = new StoreEntities();
            var data = (from c in db.Categories
                        where c.Id == id
                        select c).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult EditCategory(Category c)
        {
            var db = new StoreEntities();
            var data = db.Categories.Find(c.Id);
            data.Name = c.Name;
            db.SaveChanges();


            return RedirectToAction("Category");

        }
    }
}