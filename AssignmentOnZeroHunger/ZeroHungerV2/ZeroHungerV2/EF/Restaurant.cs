//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHungerV2.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Restaurant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant()
        {
            this.Requests = new HashSet<Request>();
        }
    
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantLocation { get; set; }
        public string RestaurantContactPerson { get; set; }
        public string RestaurantContactNumber { get; set; }
        public string RestaurantEmail { get; set; }
        public int RestaurantOwnerID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
        public virtual User User { get; set; }
    }
}
