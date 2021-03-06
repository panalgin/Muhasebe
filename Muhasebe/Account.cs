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
    
    public partial class Account
    {
        public int ID { get; set; }
        public int AccountTypeID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        public int ProvinceID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public int OwnerID { get; set; }
        public string TaxDepartment { get; set; }
        public string TaxID { get; set; }
    
        public virtual Province Province { get; set; }
        public virtual City City { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual Company Owner { get; set; }
    }
}
