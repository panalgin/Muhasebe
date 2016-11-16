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
    
    public partial class StockMovement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockMovement()
        {
            this.Nodes = new HashSet<StockMovementNode>();
        }
    
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int AccountID { get; set; }
        public int OwnerID { get; set; }
    
        public virtual Company Owner { get; set; }
        public virtual User Author { get; set; }
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockMovementNode> Nodes { get; set; }
    }
}
