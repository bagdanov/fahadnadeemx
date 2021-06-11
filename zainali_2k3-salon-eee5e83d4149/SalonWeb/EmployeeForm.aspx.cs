using SalonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SalonWeb
{
    public partial class EmployeeForm : SalonWeb.Pagebase
    {
        public Nullable<int> EmployeeID
        {
            get
            {
                if (Request.QueryString["EmployeeID"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["EmployeeID"]);
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
                txtDOB.Text = DateTime.Now.ToString(Constants.DateFormat);
            }
        }

        private void LoadData()
        {
            if (EmployeeID.HasValue)
            {
                var result = Repository.GetEmployee(EmployeeID, null, TenantID).FirstOrDefault();
                if (result != null)
                {
                    BindEmployeeType();
                    txtFullName.Text = result.FullName;
                    txtCNIC.Text = result.CNIC;
                    if (result.DateOfBirth.HasValue)
                        txtDOB.Text = result.DateOfBirth.Value.ToString(Constants.DateFormat);
                    txtPhoneNumber.Text = result.PhoneNumber;
                    txtAltPhoneNumber.Text = result.AlternatePhoneNumber;
                    txtEmailAddress.Text = result.EmailAddress;
                    txtPassword.Text = result.Password;
                    txtAddress.Text = result.Address;
                    if (result.EmployeeTypeID.HasValue)
                    {
                        ListItem itm = ddlEmpType.Items.FindByValue(result.EmployeeTypeID.Value.ToString());
                        if (itm != null)
                        {
                            itm.Selected = true;
                        }
                    }
                    txtNotes.Text = result.Notes;
                }
            }
        }

        public void BindEmployeeType()
        {
            var result = Repository.GetEmployeeType(TenantID);
            if (result != null)
            {
                ddlEmpType.DataSource = result;
                ddlEmpType.DataTextField = "Type";
                ddlEmpType.DataValueField = "EmployeeTypeID";
                ddlEmpType.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlEmpType.SelectedValue != "0" && txtFullName.Text != "" && txtPhoneNumber.Text != "" && txtAddress.Text != "" && txtDOB.Text
                != "" && txtEmailAddress.Text != "" && txtPassword.Text != "" && txtCNIC.Text != "")
            {
                Repository.SetEmployee(EmployeeID, txtFullName.Text, txtPhoneNumber.Text, 
                    txtAltPhoneNumber.Text, GetNullableTypes.GetDateTime(txtDOB.Text, Constants.DateFormat), txtCNIC.Text,
            txtEmailAddress.Text, txtPassword.Text, txtAddress.Text, GetNullableTypes.GetInt(ddlEmpType.SelectedValue).Value, UserName, txtNotes.Text, TenantID);
                Response.Redirect("EmployeeGrid.aspx");
            }
            else
            {
                lblError.Text = "Missing Value(s) in Required Field(s)";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeGrid.aspx");
        }

    }
}