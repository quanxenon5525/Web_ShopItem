//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProject.dbEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int id { get; set; }
        public string NameProduct { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> CreateOrder { get; set; }
        public string idCus { get; set; }
        public string pay { get; set; }
    }
}
