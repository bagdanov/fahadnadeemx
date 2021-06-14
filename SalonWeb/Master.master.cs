using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
namespace SalonWeb
{
    public partial class Master : System.Web.UI.MasterPage
    {

        public bool IsClient
        {
            get
            {
                if (Session["IsClient"] != null)
                {
                    return Convert.ToBoolean(Session["IsClient"]);
                }
                return false;
            }
        }

        public int CustomerID
        {
            get
            {
                if (Session["CustomerID"] != null)
                {
                    return Convert.ToInt16(Session["CustomerID"]);
                }
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlAnchor appointment = this.FindControl("appointment") as HtmlAnchor;

            if (Session["IsClient"].ToString().Equals("True"))
            {
                if (CustomerID != 0)
                {
                    this.FindControl("dashboard").Visible = false;
                    this.FindControl("dashboardCustomer").Visible = true;
                }
                else
                {
                    this.FindControl("dashboard").Visible = true;
                    this.FindControl("dashboardCustomer").Visible = false;
                    this.FindControl("crm").Visible = false;
                    this.FindControl("employee").Visible = false;
                    this.FindControl("inventory").Visible = false;
                    this.FindControl("stock").Visible = false;
                    this.FindControl("invoice").Visible = false;
                    this.FindControl("expensegrid").Visible = false;
                    this.FindControl("accounts").Visible = false;
                    this.FindControl("clientsgrid").Visible = false;
                    this.FindControl("services").Visible = false;
                }
                if (appointment != null)
                {
                    appointment.HRef = "AppointmentGrid.aspx?CustomerID=" + CustomerID;
                }
            }
            else if (appointment != null)
            {
                appointment.HRef = "AppointmentGrid.aspx";
            }
            if (CustomerID == 0)
            {
                this.FindControl("dashboard").Visible = true;
                this.FindControl("dashboardCustomer").Visible = false;
            }
            else
            {
                this.FindControl("dashboard").Visible = false;
                this.FindControl("dashboardCustomer").Visible = true;
                this.FindControl("crm").Visible = false;
                this.FindControl("employee").Visible = false;
                this.FindControl("inventory").Visible = false;
                this.FindControl("stock").Visible = false;
                this.FindControl("invoice").Visible = false;
                this.FindControl("expensegrid").Visible = false;
                this.FindControl("accounts").Visible = false;
                this.FindControl("clientsgrid").Visible = false;
                this.FindControl("services").Visible = false;
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session["ServiceResult"] = null;
            Session["CustomerID"] = null;
            if (IsClient)
            {
                Session["IsClient"] = null;
                Response.Redirect("LoginCustomer.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}