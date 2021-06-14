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
    public partial class StockGrid : SalonWeb.Pagebase
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
            var result = Repository.GetStock(null, TenantID).ToList();
            if (result != null)
            {
                rptStock.DataSource = result;
                rptStock.DataBind();
            }
        }

        protected void rptStock_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                Label lblProductCategoryName = (e.Item.FindControl("lblProductCategoryName") as Label);
                if (lblProductCategoryName != null && DataBinder.Eval(e.Item.DataItem, "ProductCategoryName") != null)
                {
                    lblProductCategoryName.Text = DataBinder.Eval(e.Item.DataItem, "ProductCategoryName").ToString();
                }
                Label lblProductName = (e.Item.FindControl("lblProductName") as Label);
                if (lblProductName != null && DataBinder.Eval(e.Item.DataItem, "ProductName") != null)
                {
                    lblProductName.Text = DataBinder.Eval(e.Item.DataItem, "ProductName").ToString();
                }
                Label lblDate = (e.Item.FindControl("lblDate") as Label);
                if (lblDate != null && DataBinder.Eval(e.Item.DataItem, "Date") != null)
                {
                    lblDate.Text = GetNullableTypes.GetDateValue(DataBinder.Eval(e.Item.DataItem, "Date"), Constants.DateFormat);
                }
                Label lblQuantity = (e.Item.FindControl("lblQuantity") as Label);
                if (lblQuantity != null && DataBinder.Eval(e.Item.DataItem, "Quantity") != null)
                {
                    lblQuantity.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(DataBinder.Eval(e.Item.DataItem, "Quantity").ToString()));
                }
                Label lblPrice = (e.Item.FindControl("lblPrice") as Label);
                if (lblPrice != null && DataBinder.Eval(e.Item.DataItem, "Price") != null)
                {
                    lblPrice.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(DataBinder.Eval(e.Item.DataItem, "Price").ToString()));
                }
                HtmlGenericControl btnEdit = (e.Item.FindControl("btnEdit") as HtmlGenericControl);
                if (btnEdit != null)
                {
                    btnEdit.Attributes.Add("onclick", "editStock('" + DataBinder.Eval(e.Item.DataItem, "StockID").ToString() + "')");
                }
            }
        }

        protected void rptStock_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                HiddenField hdID = e.Item.FindControl("hdIDStock") as HiddenField;
                Repository.DeleteStock(GetNullableTypes.GetInt(hdID.Value), UserName);
                LoadData();
            }
        }
    }

}