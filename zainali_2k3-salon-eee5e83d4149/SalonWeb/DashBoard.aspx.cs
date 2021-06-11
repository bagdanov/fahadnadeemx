using SalonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalonWeb
{
    public partial class DashBoard : Pagebase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.ValidateUser();
                LoadData();
            }
            DateTime date = DateTime.Now;
            DateTime startDate = new DateTime(date.Year, date.Month, 1);
            var result = Repository.GetDashboardKPI(startDate, date, TenantID).FirstOrDefault();
            if (result != null)
            {
                lblAppointments.Text = GetNullableTypes.GetEditableValue(result.Appointments);
                lblProfit.Text = GetNullableTypes.GetEditableValue(result.Profit);
                lblIncome.Text = GetNullableTypes.GetEditableValue(result.Income);
                lblExpenses.Text = GetNullableTypes.GetEditableValue(result.Expense);
            }
        }

        public void LoadData()
        {
            var result = Repository.GetAppointment(null, null, TenantID).Where(c => c.AppointmentStatusID ==
            ((int)Constants.AppointmentStatus.Approved)).ToList();
            if (result != null)
            {
                rptAppointment.DataSource = result;
                rptAppointment.DataBind();
            }
            var pendingResult = Repository.GetAppointment(null, null, TenantID).Where(c => c.AppointmentStatusID ==
           ((int)Constants.AppointmentStatus.Pending)).ToList();
            if (pendingResult != null)
            {
                rptPendingAppointment.DataSource = pendingResult;
                rptPendingAppointment.DataBind();
            }
        }

        protected void rptAppointment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                Label lblCustomerName = (e.Item.FindControl("lblCustomerName") as Label);
                if (lblCustomerName != null && DataBinder.Eval(e.Item.DataItem, "CustomerName") != null)
                {
                    lblCustomerName.Text = DataBinder.Eval(e.Item.DataItem, "CustomerName").ToString();
                }
                Label lblPhoneNumber = (e.Item.FindControl("lblPhoneNumber") as Label);
                if (lblPhoneNumber != null && DataBinder.Eval(e.Item.DataItem, "PhoneNumber") != null)
                {
                    lblPhoneNumber.Text = DataBinder.Eval(e.Item.DataItem, "PhoneNumber").ToString();
                }
                Label lblDate = (e.Item.FindControl("lblDate") as Label);
                if (lblDate != null && DataBinder.Eval(e.Item.DataItem, "AppointmentDateTime") != null)
                {
                    lblDate.Text = GetNullableTypes.GetDateValue(DataBinder.Eval(e.Item.DataItem, "AppointmentDateTime"), Constants.DateTimeFormat);
                }
            }
        }

        protected void rptPendingAppointment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                Label lblCustomerName = (e.Item.FindControl("lblCustomerName") as Label);
                if (lblCustomerName != null && DataBinder.Eval(e.Item.DataItem, "CustomerName") != null)
                {
                    lblCustomerName.Text = DataBinder.Eval(e.Item.DataItem, "CustomerName").ToString();
                }
                Label lblPhoneNumber = (e.Item.FindControl("lblPhoneNumber") as Label);
                if (lblPhoneNumber != null && DataBinder.Eval(e.Item.DataItem, "PhoneNumber") != null)
                {
                    lblPhoneNumber.Text = DataBinder.Eval(e.Item.DataItem, "PhoneNumber").ToString();
                }
                Label lblDate = (e.Item.FindControl("lblDate") as Label);
                if (lblDate != null && DataBinder.Eval(e.Item.DataItem, "AppointmentDateTime") != null)
                {
                    lblDate.Text = GetNullableTypes.GetDateValue(DataBinder.Eval(e.Item.DataItem, "AppointmentDateTime"), Constants.DateTimeFormat);
                }
            }
        }
    }
}
