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
    public partial class CRMGrid : SalonWeb.Pagebase
    {
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
            var result = Repository.GetCustomer(null, TenantID).ToList();
            if (result != null)
            {
                rptCustomer.DataSource = result;
                rptCustomer.DataBind();
            }
        }

        protected void rptCustomer_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                Label lblFullName = (e.Item.FindControl("lblFullName") as Label);
                if (lblFullName != null && DataBinder.Eval(e.Item.DataItem, "FirstName") != null ||
                    DataBinder.Eval(e.Item.DataItem, "LastName") != null)
                {
                    string FirstName = DataBinder.Eval(e.Item.DataItem, "FirstName").ToString();
                    if (DataBinder.Eval(e.Item.DataItem, "LastName") != null)
                    {
                        string LastName = DataBinder.Eval(e.Item.DataItem, "LastName").ToString();
                        lblFullName.Text = FirstName + " " + LastName;
                    }
                    else
                    {
                        lblFullName.Text = FirstName;
                    }
                }
                Label lblPhoneNumber = (e.Item.FindControl("lblPhoneNumber") as Label);
                if (lblPhoneNumber != null && DataBinder.Eval(e.Item.DataItem, "PhoneNumber") != null)
                {
                    lblPhoneNumber.Text = DataBinder.Eval(e.Item.DataItem, "PhoneNumber").ToString();
                }
                Label lblEmailAddress = (e.Item.FindControl("lblEmailAddress") as Label);
                if (lblEmailAddress != null && DataBinder.Eval(e.Item.DataItem, "EmailAddress") != null)
                {
                    lblEmailAddress.Text = DataBinder.Eval(e.Item.DataItem, "EmailAddress").ToString();
                }
                HtmlGenericControl btnEdit = (e.Item.FindControl("btnEdit") as HtmlGenericControl);
                if (btnEdit != null)
                {
                    btnEdit.Attributes.Add("onclick", "editCustomer('" + DataBinder.Eval(e.Item.DataItem, "CustomerID").ToString() + "')");
                }
            }
        }

        protected void rptCustomer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                HiddenField hdID = e.Item.FindControl("hdIDCustomer") as HiddenField;
                Repository.DeleteCustomer(GetNullableTypes.GetInt(hdID.Value), null);
                LoadData();
            }
            if (e.CommandName == "Appointments")
            {
                HiddenField hdID = e.Item.FindControl("hdIDCustomer") as HiddenField;
                Response.Redirect("AppointmentGrid.aspx?CustomerID=" + hdID.Value);
            }
        }
    }

}