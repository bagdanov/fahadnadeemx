//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalonLibrary
{
    using System;
    
    public partial class GetServiceType_Result
    {
        public int ServiceTypeID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceTypeName { get; set; }
        public Nullable<decimal> TimeRequired { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Notes { get; set; }
        public int ServiceID { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> ClientID { get; set; }
    }
}