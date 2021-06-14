using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalonLibrary;
namespace SalonWeb
{
    public partial class Pagebase : System.Web.UI.Page
    {
        public string UserName
        {
            get
            {
                if (Session["UserName"] != null)
                {
                    return Session["UserName"].ToString();
                }
                return "-1";
            }
        }

        public int TenantID
        {
            get
            {
                if (Session["ClientID"] != null)
                {
                    return GetNullableTypes.GetInt(Session["ClientID"].ToString()).Value;
                }
                return -1;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        } 

        internal void ValidateUser()
        {
            if (UserName == "-1")
                Response.Redirect("Login.aspx");
        }
    }
}