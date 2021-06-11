using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalonLibrary;
using System.Web.UI.HtmlControls;
namespace SalonWeb
{
    public partial class AppointmentGrid : Pagebase
    {
        public Nullable<int> CustomerID
        {
            get
            {
                if (Request.QueryString["CustomerID"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["CustomerID"]);
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.ValidateUser();
                LoadData();
            }
        }

        public void LoadData()
        {
            var result = Repository.GetAppointment(null, CustomerID, TenantID).Where(c=>c.AppointmentStatusID != (int) Constants.AppointmentStatus.Invoiced).ToList();
            if (result != null)
            {
                rptAppointment.DataSource = result;
                rptAppointment.DataBind();
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
                Label lblDateTime = (e.Item.FindControl("lblDateTime") as Label);
                if (lblDateTime != null && DataBinder.Eval(e.Item.DataItem, "AppointmentDateTime") != null)
                {
                    lblDateTime.Text = GetNullableTypes.GetDateValue(DataBinder.Eval(e.Item.DataItem, "AppointmentDateTime"), Constants.DateTimeFormat);
                }
                Label lblStatus = (e.Item.FindControl("lblStatus") as Label);
                if (lblStatus != null && DataBinder.Eval(e.Item.DataItem, "AppointmentStatusID") != null)
                {
                    if (DataBinder.Eval(e.Item.DataItem, "AppointmentStatusID").ToString() == ((int)Constants.AppointmentStatus.Pending).ToString())
                        lblStatus.Text = "Pending";
                    if (DataBinder.Eval(e.Item.DataItem, "AppointmentStatusID").ToString() == ((int)Constants.AppointmentStatus.Cancelled).ToString())
                        lblStatus.Text = "Cancelled";
                    if (DataBinder.Eval(e.Item.DataItem, "AppointmentStatusID").ToString() == ((int)Constants.AppointmentStatus.Approved).ToString())
                        lblStatus.Text = "Approved";
                    if (DataBinder.Eval(e.Item.DataItem, "AppointmentStatusID").ToString() == ((int)Constants.AppointmentStatus.Invoiced).ToString())
                        lblStatus.Text = "Invoiced";
                }
                Label lblNotes = (e.Item.FindControl("lblNotes") as Label);
                if (lblNotes != null && DataBinder.Eval(e.Item.DataItem, "Notes") != null)
                {
                    lblNotes.Text = DataBinder.Eval(e.Item.DataItem, "Notes").ToString();
                }
                HtmlGenericControl btnEdit = (e.Item.FindControl("btnEdit") as HtmlGenericControl);
                if (btnEdit != null)
                {
                    btnEdit.Attributes.Add("onclick", "editAppointment('" + DataBinder.Eval(e.Item.DataItem, "AppointmentID").ToString() + "')");
                }
            }
        }

        protected void rptAppointment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                HiddenField hdID = e.Item.FindControl("hdIDAppointment") as HiddenField;
                Repository.DeleteAppointment(GetNullableTypes.GetInt(hdID.Value), null);
                LoadData();
            }
        }
    }
}