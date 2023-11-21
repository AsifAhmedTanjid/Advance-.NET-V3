using asif.EF;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace asif.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult ProductList()
        {

            var db = new StoreEntities();
            var data = db.Products.ToList();
            return View(data);
        }

        public ActionResult AddToCart(int id)
        {
            var db = new StoreEntities();
            var data = (from p in db.Products
                        where p.Id == id
                        select p).SingleOrDefault();
            Cart cart = new Cart
            {
                CustomerId = Convert.ToInt32(Session["userid"]),
                ProductId = data.Id,
                Quantity = 1,
                Price = data.Price,
               
                
            };
            db.Carts.Add(cart);
            db.SaveChanges();
            return RedirectToAction("ProductList");
            // return View(cart);
        }
        public ActionResult Cart()
        {   var id= Convert.ToInt32(Session["userid"]);
            var db = new StoreEntities();
            var data = (from c in db.Carts
                        where c.CustomerId == id
                        select c).ToList();
            return View(data);
        }

        public ActionResult ClearCart()
        {
            var id = Convert.ToInt32(Session["userid"]);
            var db = new StoreEntities();
            var data = (from c in db.Carts
                        where c.CustomerId == id
                        select c).ToList();
            db.Carts.RemoveRange(data);
            db.SaveChanges();
            return RedirectToAction("Cart");
        }

        public ActionResult DeleteCart(int id)
        {
            var db = new StoreEntities();
            var data = db.Carts.Find(id);
            db.Carts.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Cart");
        }

        public ActionResult PlaceOrder()
        {
            var id = Convert.ToInt32(Session["userid"]);
            var db = new StoreEntities();
            var data = (from c in db.Carts
                        where c.CustomerId == id
                        select c).ToList();
            foreach (var c in data) {

                Order order = new Order
                {
                    CustomerId = Convert.ToInt32(Session["userid"]),
                    ProductId = c.ProductId,
                    Quantity = 1,
                    Price = c.Price,
                    Status = "Ordered"

                };
                db.Orders.Add(order);
              
            }


            db.SaveChanges();
            ClearCart();
            
            return RedirectToAction("MyOrder");
            // return View(cart);
        }

        public ActionResult MyOrder()
        {
            var id = Convert.ToInt32(Session["userid"]);
            var db = new StoreEntities();
            var data = (from c in db.Orders
                        where c.CustomerId == id
                        select c).ToList();
            return View(data);
        }

        public ActionResult CancelOrder()
        {
            var id = Convert.ToInt32(Session["userid"]);
            var db = new StoreEntities();
            var data = (from c in db.Orders
                        where c.CustomerId == id
                        select c).ToList();
            db.Orders.RemoveRange(data);
            db.SaveChanges();
            return RedirectToAction("MyOrder");
        }



    }
}