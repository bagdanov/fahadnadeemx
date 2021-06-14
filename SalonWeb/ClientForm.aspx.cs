using SalonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalonWeb
{
    public partial class ClientForm : SalonWeb.Pagebase
    {
        public Nullable<int> ClientID
        {
            get
            {
                if (Request.QueryString["ClientID"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["ClientID"]);
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

        //public void BindClient(DropDownList ddlClientType)
        //{
        //    var result = Repository.GetClient(null);
        //    if (result != null)
        //    {
        //        ddlClientType.DataSource = result;
        //        ddlClientType.DataTextField = "ClientTypeID";
        //        //ddlClientType.DataTextField = "TypeName";
        //        ddlClientType.DataValueField = "ClientID";
        //        ddlClientType.DataBind();
        //    }
        //}

        private void LoadData()
        {
            if (ClientID.HasValue)
            {
                var result = Repository.GetClient(ClientID).FirstOrDefault();
                if (result != null)
                {
                    txtName.Text = result.Name;
                    txtNTN.Text = result.NTN;
                    txtSNTN.Text = result.SNTN;
                    txtTagLine.Text = result.TagLine;
                    txtMobile.Text = result.Mobile;
                    txtTelePhoneNumber.Text = result.TelePhoneNumber;
                    txtEmailAddress.Text = result.Email;
                    txtAddress.Text = result.Address;
                    txtCity.Text = result.City;
                    txtCountry.Text = result.Country;
                    txtWebsite.Text = result.Website;
                    if (result.ClientTypeID.HasValue)
                    {
                        ListItem itm = ddlClientType.Items.FindByValue(result.ClientTypeID.Value.ToString());
                        if (itm != null)
                        {
                            itm.Selected = true;
                        }
                    }
                    txtNotes.Text = result.Notes;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Repository.SetClient(ClientID, txtName.Text, txtAddress.Text, txtMobile.Text, txtTelePhoneNumber.Text, txtEmailAddress.Text,
                txtCity.Text, txtCountry.Text, GetNullableTypes.GetInt(ddlClientType.SelectedValue).Value, txtTagLine.Text, txtWebsite.Text, txtNTN.Text,
            txtSNTN.Text, null, txtNotes.Text, UserName);
            Response.Redirect("ClientsGrid.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientsGrid.aspx");
        }
    }
}

