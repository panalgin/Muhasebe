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
    
    public partial class Device
    {
        public int ID { get; set; }
        public int TypeID { get; set; }
        public int OwnerID { get; set; }
        public string Parameters { get; set; }
        public Nullable<int> ConnectionTypeID { get; set; }
    
        public virtual DeviceType Type { get; set; }
        public virtual Company Company { get; set; }
        public virtual ConnectionType ConnectionType { get; set; }
    }
}
