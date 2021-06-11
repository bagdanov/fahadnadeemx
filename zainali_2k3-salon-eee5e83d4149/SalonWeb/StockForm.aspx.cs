using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalonLibrary;

namespace SalonWeb
{
    public partial class StockForm : SalonWeb.Pagebase
    {
        public Nullable<int> StockID
        {
            get
            {
                if (Request.QueryString["StockID"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["StockID"]);
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductCategory(ddlProductCategoryName);
                base.ValidateUser();
                BindProduct(ddlProductName);
                LoadData();
                txtDate.Text = DateTime.Now.ToString();
            }
        }

        public void BindProductCategory(DropDownList ddlProductCategoryName)
        {
            var result = Repository.GetProductCategory(null, TenantID);
            if (result != null)
            {
                ddlProductCategoryName.DataSource = result;
                ddlProductCategoryName.DataTextField = "Name";
                ddlProductCategoryName.DataValueField = "ProductCategoryID";
                ddlProductCategoryName.DataBind();
                ddlProductCategoryName.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        public void BindProduct(DropDownList ddlProductName)
        {
            var result = Repository.GetProduct(null, GetNullableTypes.GetInt(ddlProductCategoryName.SelectedValue).Value, TenantID);
            if (result != null)
            {
                ddlProductName.DataSource = result;
                ddlProductName.DataTextField = "ProductName";
                ddlProductName.DataValueField = "ProductID";
                ddlProductName.DataBind();
                ddlProductName.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        private void LoadData()
        {
            if (StockID.HasValue)
            {
                var result = Repository.GetStock(StockID, TenantID).FirstOrDefault();
                if (result != null)
                {
                    txtDate.Text = GetNullableTypes.GetEditableDateValue(result.Date, Constants.DateFormat);
                    txtQuantity.Text = GetNullableTypes.GetEditableValue(result.Quantity);
                    txtPrice.Text = GetNullableTypes.GetEditableValue(result.Price);
                    txtNotes.Text = result.Notes;
                    if (result.ProductCategoryID.HasValue)
                    {
                        ddlProductCategoryName.SelectedValue = (result.ProductCategoryID.Value.ToString());
                        BindProduct(ddlProductName);
                    }
                    if (result.ProductID.HasValue)
                    {
                        ddlProductName.SelectedValue = (result.ProductID.Value.ToString());
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((GetNullableTypes.GetInt(ddlProductName.SelectedValue).Value != 0) || (GetNullableTypes.GetInt(ddlProductCategoryName.SelectedValue).Value != 0) ||
                txtDate.Text == "" || txtQuantity.Text == "" || txtPrice.Text == "" )
            {
                decimal Qty = GetNullableTypes.GetDecimalValue(txtQuantity.Text);
                decimal Price = GetNullableTypes.GetDecimalValue(txtPrice.Text);
                Repository.SetStock(StockID, GetNullableTypes.GetDateTime(txtDate.Text, Constants.DateFormat),
                    GetNullableTypes.GetInt(ddlProductName.SelectedValue).Value, GetNullableTypes.GetInt(ddlProductCategoryName.SelectedValue).Value,
                    Qty, Price, UserName, txtNotes.Text, TenantID);
                Response.Redirect("StockGrid.aspx");
            }
            else
            {
                lblError.Text = "Missing Value(s) in Required Field(s)";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StockGrid.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDate.Text = txtQuantity.Text = txtPrice.Text = txtNotes.Text = " ";
            ddlProductCategoryName.SelectedValue = ddlProductName.SelectedValue = "0";
        }

        protected void ddlProductCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProduct(ddlProductName);
        }
    }
}


