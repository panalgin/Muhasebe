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
    
    public partial class PropertyReminder
    {
        public int ID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<decimal> Minimum { get; set; }
        public Nullable<decimal> Maximum { get; set; }
        public Nullable<int> OwnerID { get; set; }
        public Nullable<int> ResponsibleID { get; set; }
        public Nullable<int> PropertyReminderMethodID { get; set; }
    
        public virtual Company Owner { get; set; }
        public virtual Item Item { get; set; }
        public virtual User Responsible { get; set; }
        public virtual PropertyRemindingMethod PropertyRemindingMethod { get; set; }
    }
}
