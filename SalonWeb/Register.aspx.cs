using SalonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalonWeb
{
    public partial class Register : SalonWeb.Pagebase
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
                LoadData();
            }
        }

        private void LoadData()
        {
            if (CustomerID.HasValue)
            {
                var result = Repository.GetCustomer(CustomerID, TenantID).FirstOrDefault();
                if (result != null)
                {
                    txtFirstName.Text = result.FirstName;
                    txtLastName.Text = result.LastName;
                    txtDOB.Text = GetNullableTypes.GetEditableDateValue(result.DateOfBirth, Constants.DateFormat);
                    txtPhoneNumber.Text = result.PhoneNumber;
                    txtAltPhoneNumber.Text = result.AlternatePhoneNumber;
                    txtEmailAddress.Text = result.EmailAddress;
                    txtPassword.Text = result.Password;
                    txtAddress.Text = result.Address;
                    ddlCity.SelectedValue = result.City;
                    txtNotes.Text = result.Notes;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtFirstName.Text != "" && txtPhoneNumber.Text != "" && txtEmailAddress.Text != "" && txtPassword.Text != "")
            {
                Repository.SetCustomer(CustomerID, txtFirstName.Text, txtLastName.Text,
            GetNullableTypes.GetDateTime(txtDOB.Text, Constants.DateFormat), txtPhoneNumber.Text,
            txtAltPhoneNumber.Text, txtEmailAddress.Text, txtPassword.Text, txtAddress.Text, ddlCity.SelectedValue.ToString(),
            UserName, txtNotes.Text, TenantID);
                Response.Redirect("LoginCustomer.aspx");
            }
            else
            {
                lblError.Text = "Missing Value(s) in Required Field(s)";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginCustomer.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = txtLastName.Text = txtDOB.Text = txtPhoneNumber.Text = txtAltPhoneNumber.Text =
            txtEmailAddress.Text = txtPassword.Text = txtAddress.Text = ddlCity.SelectedValue = txtNotes.Text = " ";
        }
    }
}