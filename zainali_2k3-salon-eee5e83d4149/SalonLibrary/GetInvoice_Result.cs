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
    
    public partial class GetInvoice_Result
    {
        public int InvoiceID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string CustomerName { get; set; }
        public Nullable<System.DateTime> AppointmentDateTime { get; set; }
        public string ServiceName { get; set; }
        public string Cost { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<decimal> AdditionalCost { get; set; }
        public string PaymentMode { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Notes { get; set; }
    }
}