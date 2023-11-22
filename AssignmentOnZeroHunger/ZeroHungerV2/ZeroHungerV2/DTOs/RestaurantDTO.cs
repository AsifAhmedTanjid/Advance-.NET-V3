using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungerV2.DTOs
{
    public class RestaurantDTO
    {
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantLocation { get; set; }
        public string RestaurantContactPerson { get; set; }
        public string RestaurantContactNumber { get; set; }
        public string RestaurantEmail { get; set; }
        public int RestaurantOwnerID { get; set; }
    }
}