using APIs.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIs.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/viewalluser")]
        public HttpResponseMessage GetAll()
        {
            var db = new ZeroHungerDBV2Entities();
            try
            {
                var data = db.Users.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            
            }

        }

        [HttpGet]
        [Route("api/finduser/{id}")]
        public HttpResponseMessage Get(int id)
        {

            var db = new ZeroHungerDBV2Entities();
            try
            {
                var data = db.Users.Find(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else 
                    return Request.CreateResponse(HttpStatusCode.NotFound,new { Msg = "No data Found" });
            }
            catch (Exception ex)

            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }


        }

        [HttpPost]
        [Route("api/user/create")]
        public HttpResponseMessage Create (User user)
        {
            var db = new ZeroHungerDBV2Entities();
            try
            {
                db.Users.Add(user);
                db.SaveChanges();

             
                    return Request.CreateResponse(HttpStatusCode.Created, new { Msg = "User Added" });
            }
            catch (Exception ex)

            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }

        }

        [HttpPost]
        [Route("api/user/Update")]
        public HttpResponseMessage Update(User user)
        {
            var db = new ZeroHungerDBV2Entities();
            try
            {
                var us = db.Users.Find(user.ID);
                db.Entry(us).CurrentValues.SetValues(user);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, us);
            }
            catch (Exception ex)

            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }

        }

        [HttpPost]
        [Route("api/user/delete/{id}")]
        public HttpResponseMessage delete(int id)
        {
            var db = new ZeroHungerDBV2Entities();
            try
            {
                var us = db.Users.Find(id);
                db.Users.Remove(us);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "User deleted" });
            }
            catch (Exception ex)

            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }

        }







    }
}
