using asif.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asif.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Category()
        {
            var db = new StoreEntities();
            var data = db.Categories.ToList();

            return View(data);
        }





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