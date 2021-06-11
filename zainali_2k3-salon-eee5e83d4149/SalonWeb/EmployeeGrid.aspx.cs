using SalonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SalonWeb
{
    public partial class EmployeeGrid : SalonWeb.Pagebase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                base.ValidateUser();
                LoadData();
            }
        }

        public void LoadData()
        {
            var result = Repository.GetEmployee(null, null, TenantID).ToList();
            if (result != null)
            {
                rptEmployee.DataSource = result;
                rptEmployee.DataBind();
            }
        }

        protected void rptEmployee_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                Label lblFullName = (e.Item.FindControl("lblFullName") as Label);
                if (lblFullName != null && DataBinder.Eval(e.Item.DataItem, "FullName") != null ||
                    DataBinder.Eval(e.Item.DataItem, "FullName") != null)
                {
                    lblFullName.Text = DataBinder.Eval(e.Item.DataItem, "FullName").ToString();
                }
                Label lblPhoneNumber = (e.Item.FindControl("lblPhoneNumber") as Label);
                if (lblPhoneNumber != null && DataBinder.Eval(e.Item.DataItem, "PhoneNumber") != null)
                {
                    lblPhoneNumber.Text = DataBinder.Eval(e.Item.DataItem, "PhoneNumber").ToString();
                }
                Label lblEmpType = (e.Item.FindControl("lblEmpType") as Label);
                if (lblEmpType != null && DataBinder.Eval(e.Item.DataItem, "EmployeeType") != null)
                {
                    lblEmpType.Text = DataBinder.Eval(e.Item.DataItem, "EmployeeType").ToString();
                }
                Label lblEmailAddress = (e.Item.FindControl("lblEmailAddress") as Label);
                if (lblEmailAddress != null && DataBinder.Eval(e.Item.DataItem, "EmailAddress") != null)
                {
                    lblEmailAddress.Text = DataBinder.Eval(e.Item.DataItem, "EmailAddress").ToString();
                }
                HtmlGenericControl btnEdit = (e.Item.FindControl("btnEdit") as HtmlGenericControl);
                if (btnEdit != null)
                {
                    btnEdit.Attributes.Add("onclick", "editEmployee('" + DataBinder.Eval(e.Item.DataItem, "EmployeeID").ToString() + "')");
                }
            }
        }

        protected void rptEmployee_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                HiddenField hdID = e.Item.FindControl("hdIDEmployee") as HiddenField;
                Repository.DeleteEmployee(GetNullableTypes.GetInt(hdID.Value), null);
                LoadData();
            }
        }
    }
}