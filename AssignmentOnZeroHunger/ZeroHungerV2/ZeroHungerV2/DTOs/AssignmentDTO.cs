using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungerV2.DTOs
{
    public class AssignmentDTO
    {
        public int AssignmentID { get; set; }
        public int RequestID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime AssignmentTime { get; set; }
        public string Status { get; set; }
    }
}