using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungerV2.DTOs
{
    public class RequestDTO
    {
        public int RequestID { get; set; }
        public int RestaurantID { get; set; }
        public System.DateTime RequestTime { get; set; }
        public System.DateTime MaxPreservationTime { get; set; }
        public string Status { get; set; }
    }
}