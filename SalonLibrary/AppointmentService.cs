
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
    using System.Collections.Generic;
    
public partial class AppointmentService
{

    public int AppointmentServiceID { get; set; }

    public Nullable<int> AppointmentID { get; set; }

    public Nullable<int> ServiceTypeID { get; set; }

    public Nullable<int> EmployeeID { get; set; }

    public Nullable<bool> IsActive { get; set; }

    public string CreatedBy { get; set; }

    public Nullable<System.DateTime> CreatedDate { get; set; }

    public Nullable<System.DateTime> ModifiedDate { get; set; }

    public string ModifiedBy { get; set; }

    public string Notes { get; set; }

    public Nullable<int> ServiceID { get; set; }

    public Nullable<int> ClientID { get; set; }

}

}
