//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Muhasebe
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Nodes = new HashSet<OrderNode>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> AccountID { get; set; }
        public string Note { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int AuthorID { get; set; }
        public int OwnerID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderNode> Nodes { get; set; }
        public virtual Account Account { get; set; }
        public virtual User Author { get; set; }
        public virtual Company Owner { get; set; }
    }
}