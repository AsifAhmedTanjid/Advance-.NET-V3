//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIs.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Assignment
    {
        public int AssignmentID { get; set; }
        public int RequestID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime AssignmentTime { get; set; }
        public string Status { get; set; }
    
        public virtual Request Request { get; set; }
        public virtual User User { get; set; }
    }
}
