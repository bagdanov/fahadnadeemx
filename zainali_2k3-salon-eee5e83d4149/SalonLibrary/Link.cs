using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonLibrary
{
    public class Link
    {
        public static string GetAppointmentGrid()
        {
            return "AppointmentGrid.aspx";
        }

        public static string GetCustomerForm(string customerID)
        {
            return "CustomerForm.aspx?CustomerID=" + customerID;
        }
    }
}
