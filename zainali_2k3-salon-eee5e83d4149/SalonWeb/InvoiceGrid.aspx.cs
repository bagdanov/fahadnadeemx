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
    public partial class InvoiceGrid : Pagebase
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
            var result = Repository.GetAppointment(null, CustomerID, TenantID).Where(c => c.AppointmentStatusID ==
            ((int)Constants.AppointmentStatus.Invoiced)).ToList();
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
                Label lblAppointmentID = (e.Item.FindControl("lblAppointmentID") as Label);
                if (lblAppointmentID != null && DataBinder.Eval(e.Item.DataItem, "AppointmentID") != null)
                {
                    lblAppointmentID.Text = DataBinder.Eval(e.Item.DataItem, "AppointmentID").ToString();
                }
                Label lblCustomerName = (e.Item.FindControl("lblCustomerName") as Label);
                if (lblCustomerName != null && DataBinder.Eval(e.Item.DataItem, "CustomerName") != null)
                {
                    lblCustomerName.Text = DataBinder.Eval(e.Item.DataItem, "CustomerName").ToString();
                }
                Label lblApDateTime = (e.Item.FindControl("lblApDateTime") as Label);
                if (lblApDateTime != null && DataBinder.Eval(e.Item.DataItem, "AppointmentDateTime") != null)
                {
                    lblApDateTime.Text = GetNullableTypes.GetDateValue(DataBinder.Eval(e.Item.DataItem, "AppointmentDateTime"), Constants.DateTimeFormat);
                }
                Label lblDateTime = (e.Item.FindControl("lblDateTime") as Label);
                if (lblDateTime != null && DataBinder.Eval(e.Item.DataItem, "InvoiceDate") != null)
                {
                    lblDateTime.Text = GetNullableTypes.GetDateValue(DataBinder.Eval(e.Item.DataItem, "InvoiceDate"), Constants.DateTimeFormat);
                }
                Label lblServiceCost = (e.Item.FindControl("lblServiceCost") as Label);
                if (lblServiceCost != null && DataBinder.Eval(e.Item.DataItem, "Cost") != null)
                {
                    lblServiceCost.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(DataBinder.Eval(e.Item.DataItem, "Cost").ToString()));
                }
                Label lblAdditionalCost = (e.Item.FindControl("lblAdditionalCost") as Label);
                if (lblAdditionalCost != null && DataBinder.Eval(e.Item.DataItem, "AdditionalCost") != null)
                {
                    lblAdditionalCost.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(DataBinder.Eval(e.Item.DataItem, "AdditionalCost").ToString()));
                }
                Label lblTotalCost = (e.Item.FindControl("lblTotalCost") as Label);
                if (lblTotalCost != null && DataBinder.Eval(e.Item.DataItem, "TotalCost") != null)
                {
                    lblTotalCost.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(DataBinder.Eval(e.Item.DataItem, "TotalCost").ToString()));
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