using SalonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalonWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                    {
                        txtEmail.Text = Request.Cookies["UserName"].Value;
                        txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var result = Repository.GetEmployee(null, txtEmail.Text, null).FirstOrDefault();
            if (result != null)
            {
                lblLoginFailed.Text = "";
                if (txtEmail.Text == result.EmailAddress && txtPassword.Text == result.Password )
                {
                    Session["UserName"] = result.EmailAddress;
                    Session["ClientID"] = result.ClientID;
                    Session["IsClient"] = false;
                    Response.Redirect("Dashboard.aspx");
                }

                if (txtEmail.Text == "" || txtPassword.Text == "")
                {
                    lblLoginFailed.Text = "Enter Email & Password to Login";
                    txtEmail.Text = txtPassword.Text = "";
                }
                else
                {
                    lblLoginFailed.Text = "Incorrect Email or Password";
                    txtEmail.Text = txtPassword.Text = "";
                }

                if (chkRememberMe.Checked)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                }
                Response.Cookies["UserName"].Value = txtEmail.Text.Trim();
                Response.Cookies["Password"].Value = txtPassword.Text.Trim();
            }
        }
    }
}