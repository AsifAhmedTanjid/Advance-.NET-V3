using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerV2.Auth;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        [Logged]
        public ActionResult Dashboard()
        {
            return View();
        }
        [Logged]
        [HttpGet]
        public ActionResult CreateNewRequest()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CreateNewRequest(Request request)
        {
            var db = new ZeroHungerDBV2Entities();
            db.Requests.Add(request);
            db.SaveChanges();
            return RedirectToAction("PendingRequest");
        }
        [Logged]
        public ActionResult PendingRequest()
        {
            var id = Convert.ToInt32(Session["restaurantid"]);
            var db = new ZeroHungerDBV2Entities();
            var data = (from requests in db.Requests
                        where requests.RestaurantID == id && requests.Status == "Requested"
                        select requests).ToList();

            return View(data);
        }
        public ActionResult DeleteRequest(int id) 
        {
            var db = new ZeroHungerDBV2Entities();
            var data = db.Requests.Find(id);
            db.Requests.Remove(data);
            db.SaveChanges();

            return RedirectToAction("PendingRequest");
        }
        [Logged]
        public ActionResult DonateHistory()
        {
            var id = Convert.ToInt32(Session["restaurantid"]);
            var db = new ZeroHungerDBV2Entities();
            var data = (from requests in db.Requests
                        where requests.RestaurantID == id && requests.Status == "Completed"
                        select requests).ToList();

            return View(data);
        }
    }
}