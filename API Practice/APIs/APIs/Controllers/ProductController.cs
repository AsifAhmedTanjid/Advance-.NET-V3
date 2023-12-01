using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIs.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/asifnumber")]
        public HttpResponseMessage Get()
        {
            

            var nums = new int[] {1,2,3, 4,5};  
            return Request.CreateResponse(HttpStatusCode.OK, nums);
        }
        [HttpPost]
        [Route("api/hola")]
        public HttpResponseMessage Post()
        {

            return Request.CreateResponse(HttpStatusCode.OK, "POST RECIEVED");       
        }
    }
}
