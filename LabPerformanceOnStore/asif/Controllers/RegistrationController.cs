using asif.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asif.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User u)
        {
            var db = new StoreEntities();
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Login");
            
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {   
            var db = new StoreEntities();
            var data = (from us in db.Users
                        where us.UserName == u.UserName && us.Password == u.Password
                        select us).SingleOrDefault();
            if (data != null)
            {
                Session["userid"] = data.Id;
                Session["username"] = data.UserName;
                Session["userpassword"] = data.Password;
                Session["username"] = data.Name;
                Session["userrole"] = data.Role;
                Session["useraddress"] = data.Address;
                Session["userphone"] = data.Phone;

                if (Session["userrole"] != null && Session["userrole"].ToString() == "admin") { return RedirectToAction("Dashboard", "Admin"); }
                else if (Session["userrole"] != null && Session["userrole"].ToString() == "customer") { return RedirectToAction("Dashboard", "Customer"); }
                
            }
            return RedirectToAction("SignUp", "Registration");
        }

    }
}