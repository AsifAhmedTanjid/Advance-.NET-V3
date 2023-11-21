using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerV2.EF;

namespace ZeroHungerV2.Controllers
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
            var db = new ZeroHungerDBV2Entities();
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
            var db= new ZeroHungerDBV2Entities();
            var data = (from us in db.Users
                        where us.Username == u.Username && us.Password == u.Password
                        select us).SingleOrDefault();
            if (data != null)
            {
                Session["id"]=data.ID; 
                Session["name"]=data.Name; 
                Session["username"]=data.Username; 
                Session["password"]=data.Password;
                Session["phone"]=data.Phone;
                Session["email"]=data.Email;
                Session["address"]=data.Address;
                Session["role"]=data.Role;
                Session["status"]=data.Status;
                
                if(data.Role=="employee")
                {

                    return RedirectToAction("Dashboard", "Employee");

                }

                else if (data.Role == "admin")
                {

                    return RedirectToAction("Dashboard", "Admin");

                }

                else if (data.Role == "restaurant")
                {
                    var resdata = (from r in db.Restaurants
                                where r.RestaurantOwnerID == data.ID 
                                select r).SingleOrDefault();
                    if (resdata != null)
                    {
                        Session["restaurantid"] = resdata.RestaurantID;
                        Session["restaurantname"] = resdata.RestaurantName;
                        Session["restaurantlocation"] = resdata.RestaurantLocation;
                        Session["restaurantcontactperson"] = resdata.RestaurantContactPerson;
                        Session["restaurantcontactnumber"] = resdata.RestaurantContactNumber;
                        Session["restaurantemail"] = resdata.RestaurantEmail;
                        Session["restaurantownerid"] = resdata.RestaurantOwnerID;


                        return RedirectToAction("Dashboard", "Restaurant");
                    }

                    

                }

            }

            return RedirectToAction("SignUp","Registration");
        }

    }
}