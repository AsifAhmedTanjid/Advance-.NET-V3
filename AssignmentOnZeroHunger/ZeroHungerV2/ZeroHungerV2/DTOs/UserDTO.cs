using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZeroHungerV2.Annotations;

namespace ZeroHungerV2.DTOs
{
    public class UserDTO
    {
        
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a Username")]
        [UniqueUsername(ErrorMessage = "This UserName Already Exists")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide a Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please provide your Phone number")]
        [UniquePhone(ErrorMessage = "This Phone Number Already Exists")]
        [StringLength(11)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please provide your Email Address")]
        [UniqueEmail(ErrorMessage = "This Email Address Already Exists")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide your Address")]
        public string Address { get; set; }
        
        public string Role { get; set; }
      
        public string Status { get; set; }
    }
}