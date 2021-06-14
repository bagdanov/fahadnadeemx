using SalonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalonWeb
{
    public partial class LoginCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                {
                    if (!IsPostBack)
                    {
                        if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                        {
                            txtPhone.Text = Request.Cookies["UserName"].Value;
                            txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                        }
                    }
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

        protected void btnSubmit_Click(object sender, EventArgs e)

        {
                var result = Repository.GetCustomerByPhone(txtPhone.Text, null).FirstOrDefault();
                if (result != null)
                {
                    lblLoginFailed.Text = "";
                    if (txtPhone.Text == result.PhoneNumber && txtPassword.Text == result.Password)
                    {
                        Session["UserName"] = result.PhoneNumber;
                        Session["ClientID"] = result.ClientID;
                        Session["IsClient"] = true;
                        Session["CustomerID"] = result.CustomerID;
                    Response.Redirect("AppointmentForm.aspx");

                    }

                    if (txtPhone.Text == "" || txtPassword.Text == "")
                    {
                        lblLoginFailed.Text = "Enter Email & Password to Login";
                        txtPhone.Text = txtPassword.Text = "";
                    }
                    else
                    {
                        lblLoginFailed.Text = "Incorrect Email or Password";
                        txtPhone.Text = txtPassword.Text = "";
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
                    Response.Cookies["UserName"].Value = txtPhone.Text.Trim();
                    Response.Cookies["Password"].Value = txtPassword.Text.Trim();
                }
            }
        }

    }