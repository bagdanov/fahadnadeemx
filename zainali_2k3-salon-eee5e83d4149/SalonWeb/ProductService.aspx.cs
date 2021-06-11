//using SalonLibrary;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;

//namespace SalonWeb
//{
//    public partial class ProductService : SalonWeb.Pagebase
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!this.IsPostBack)
//            {
//                base.ValidateUser();
//                LoadData();
//            }
//        }
//        public void LoadData()
//        {
//            var result = Repository.GetProductService(null).ToList();
//            if (result != null)
//            {
//                rptProductService.DataSource = result;
//                rptProductService.DataBind();
//            }
//        }

//        protected void rptProductService_ItemDataBound(object sender, RepeaterItemEventArgs e)
//        {
//            if (e.Item.ItemType == ListItemType.AlternatingItem ||
//                e.Item.ItemType == ListItemType.Item)
//            {
//                Label lblService = (e.Item.FindControl("lblService") as Label);
//                if (lblService != null && DataBinder.Eval(e.Item.DataItem, "ServiceName") != null)
//                {
//                    lblService.Text = DataBinder.Eval(e.Item.DataItem, "ServiceName").ToString();
//                }
//                Label lblServiceType = (e.Item.FindControl("lblServiceType") as Label);
//                if (lblServiceType != null && DataBinder.Eval(e.Item.DataItem, "ServiceTypeName") != null)
//                {
//                    lblServiceType.Text = DataBinder.Eval(e.Item.DataItem, "ServiceTypeName").ToString();
//                }
//                Label lblProductCategory = (e.Item.FindControl("lblProductCategory") as Label);
//                if (lblProductCategory != null && DataBinder.Eval(e.Item.DataItem, "ProductCategoryName") != null)
//                {
//                    lblProductCategory.Text = DataBinder.Eval(e.Item.DataItem, "ProductCategoryName").ToString();
//                }
//                Label lblProduct = (e.Item.FindControl("lblProduct") as Label);
//                if (lblProduct != null && DataBinder.Eval(e.Item.DataItem, "ProductName") != null)
//                {
//                    lblProduct.Text = DataBinder.Eval(e.Item.DataItem, "ProductName").ToString();
//                }
//                Label lblQuantity = (e.Item.FindControl("lblQuantity") as Label);
//                if (lblQuantity != null && DataBinder.Eval(e.Item.DataItem, "Quantity") != null)
//                {
//                    lblQuantity.Text = DataBinder.Eval(e.Item.DataItem, "Quantity").ToString();
//                }
//                Label lblNotes = (e.Item.FindControl("lblNotes") as Label);
//                if (lblNotes != null && DataBinder.Eval(e.Item.DataItem, "Notes") != null)
//                {
//                    lblNotes.Text = DataBinder.Eval(e.Item.DataItem, "Notes").ToString();
//                }
//                HtmlGenericControl btnEdit = (e.Item.FindControl("btnEdit") as HtmlGenericControl);
//                if (btnEdit != null)
//                {
//                    btnEdit.Attributes.Add("onclick", "editProductService('" + DataBinder.Eval(e.Item.DataItem, "ProductServiceID").ToString() + "')");
//                }
//            }
//        }

//        protected void rptProductService_ItemCommand(object source, RepeaterCommandEventArgs e)
//        {
//            if (e.CommandName == "Delete")
//            {
//                HiddenField hdID = e.Item.FindControl("hdIDProductService") as HiddenField;
//                Repository.DeleteProductService(GetNullableTypes.GetInt(hdID.Value), UserName);
//                LoadData();
//            }
//        }
//    }
//}
