using asif.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asif.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Orders()
        {
            var db = new StoreEntities();
            var data = db.Orders.ToList();

            return View(data);
        }

        public ActionResult ManageOrder(int id,string status)
        {
            var db = new StoreEntities();
            var data = (from p in db.Orders
                        where p.Id == id
                        select p).SingleOrDefault();
            if (status == "Process")
            {
                data.Status = "Processing";
            }
            else if (status =="Decline")
            {
                data.Status = "Declined";
            }

            db.SaveChanges();

            return RedirectToAction("Orders");
        }


    }
}