using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZeroHungerV2.Annotations;

namespace ZeroHungerV2.DTOs
{
    public class RequestDTO
    {
        public int RequestID { get; set; }
        public int RestaurantID { get; set; }
        public System.DateTime RequestTime { get; set; }
        [Required]
        [GreaterTime(ErrorMessage = "Invalid Date or Time")]
        public System.DateTime MaxPreservationTime { get; set; }
        public string Status { get; set; }
        [Required]
        public string FoodDetails { get; set; }
    }
}