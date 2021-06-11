
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
    public partial class Inventory : SalonWeb.Pagebase
    {
            public Nullable<int> ProductCategoryID
            {
                get
                {
                    if (Request.QueryString["ProductCategoryID"] != null)
                    {
                        return Convert.ToInt32(Request.QueryString["ProductCategoryID"]);
                    }
                    return null;
                }
            }

            public Nullable<int> ProductID
            {
                get
                {
                    if (Request.QueryString["ProductID"] != null)
                    {
                        return Convert.ToInt32(Request.QueryString["ProductID"]);
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

            public void LoadData()
            {
            var resultCategory = Repository.GetProductCategory(null, TenantID).ToList();
                if (resultCategory != null)
                {
                rptProductCategory.DataSource = resultCategory;
                rptProductCategory.DataBind();
                }
                var result = Repository.GetProduct(null, null, TenantID).ToList();
                if (result != null)
                {
                rptProduct.DataSource = result;
                rptProduct.DataBind();
                }
            }

            public void BindProductCategory(DropDownList ddlProductCategory)
            {
                var result = Repository.GetProductCategory(null, TenantID);
                if (result != null)
                {
                ddlProductCategory.DataSource = result;
                ddlProductCategory.DataTextField = "Name";
                ddlProductCategory.DataValueField = "ProductCategoryID";
                ddlProductCategory.DataBind();
                }
            }

            protected void rptProductCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.AlternatingItem ||
                    e.Item.ItemType == ListItemType.Item)
                {
                    LinkButton lbtnUpdate = (e.Item.FindControl("lbtnUpdate") as LinkButton);
                    if (lbtnUpdate != null)
                    {
                        lbtnUpdate.Visible = false;
                    }
                    TextBox txtName = (e.Item.FindControl("txtName") as TextBox);
                    if (txtName != null && DataBinder.Eval(e.Item.DataItem, "Name") != null)
                    {
                        txtName.Visible = false;
                        txtName.Text = DataBinder.Eval(e.Item.DataItem, "Name").ToString();
                    }
                    TextBox txtNote = (e.Item.FindControl("txtNote") as TextBox);
                    if (txtNote != null)
                    {
                        txtNote.Visible = false;
                        if (DataBinder.Eval(e.Item.DataItem, "Notes") != null)
                            txtNote.Text = DataBinder.Eval(e.Item.DataItem, "Notes").ToString();
                    }
                    Label lblName = (e.Item.FindControl("lblName") as Label);
                    if (lblName != null && DataBinder.Eval(e.Item.DataItem, "Name") != null)
                    {
                        lblName.Text = DataBinder.Eval(e.Item.DataItem, "Name").ToString();
                    }
                    Label lblNote = (e.Item.FindControl("lblNote") as Label);
                    if (lblNote != null && DataBinder.Eval(e.Item.DataItem, "Notes") != null)
                    {
                        lblNote.Text = DataBinder.Eval(e.Item.DataItem, "Notes").ToString();
                    }
                }
            }

            protected void rptProductCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
            if (e.CommandName == "Add")
            {
                TextBox txtName = e.Item.FindControl("txtName") as TextBox;
                TextBox txtNote = e.Item.FindControl("txtNote") as TextBox;
                if (txtName.Text != "")
                {
                    Repository.SetProductCategory(null, txtName.Text, txtNote.Text, UserName, TenantID);
                    LoadData();
                    lblProductCategoryError.Text = "";
                }
                else
                {
                    lblProductCategoryError.Text = "Missing Value(s) in Required Field(s)";
                }
            }
                if (e.CommandName == "Delete")
                {
                    HiddenField hdID = e.Item.FindControl("hdProductCategoryID") as HiddenField;
                    Repository.DeleteProductCategory(GetNullableTypes.GetInt(hdID.Value),UserName);
                    LoadData();
                }
            else if (e.CommandName == "Edit")
            {
                LinkButton lbtnUpdate = (e.Item.FindControl("lbtnUpdate") as LinkButton);
                if (lbtnUpdate != null)
                {
                    lbtnUpdate.Visible = true;
                }

                LinkButton lbtnEdit = (e.Item.FindControl("lbtnEdit") as LinkButton);
                if (lbtnEdit != null)
                {
                    lbtnEdit.Visible = false;
                }
                TextBox txtName = (e.Item.FindControl("txtName") as TextBox);
                if (txtName != null)
                {
                    txtName.Visible = true;
                }
                TextBox txtNote = (e.Item.FindControl("txtNote") as TextBox);
                if (txtNote != null)
                {
                    txtNote.Visible = true;
                }
                Label lblName = (e.Item.FindControl("lblName") as Label);
                if (lblName != null)
                {
                    lblName.Visible = false;
                }
                Label lblNote = (e.Item.FindControl("lblNote") as Label);
                if (lblNote != null)
                {
                    lblNote.Visible = false;
                }
            }
            else if (e.CommandName == "Update")
            {
                TextBox txtName = e.Item.FindControl("txtName") as TextBox;
                TextBox txtNote = e.Item.FindControl("txtNote") as TextBox;
                HiddenField hdProductCategoryID = e.Item.FindControl("hdProductCategoryID") as HiddenField;
                if (txtName.Text != "")
                {
                    Repository.SetProductCategory(GetNullableTypes.GetInt(hdProductCategoryID.Value), txtName.Text,
                    txtNote.Text, UserName, TenantID);
                    LoadData();
                    lblProductCategoryError.Text = "";
                }
                else
                {
                    lblProductCategoryError.Text = "Missing Value(s) in Required Field(s)";
                }
            }
       }

            protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.AlternatingItem ||
                    e.Item.ItemType == ListItemType.Item)
                {
                    LinkButton lbtnUpdate = (e.Item.FindControl("lbtnUpdate") as LinkButton);
                    if (lbtnUpdate != null)
                    {
                        lbtnUpdate.Visible = false;
                    }
                    DropDownList ddlProductCategory = (e.Item.FindControl("ddlProductCategory") as DropDownList);
                    if (ddlProductCategory != null && DataBinder.Eval(e.Item.DataItem, "ProductCategoryID") != null)
                    {
                        ddlProductCategory.Visible = false;
                        BindProductCategory(ddlProductCategory);
                        if (DataBinder.Eval(e.Item.DataItem, "ProductCategoryID") != null)
                        {
                            ListItem itm = ddlProductCategory.Items.FindByValue(DataBinder.Eval(e.Item.DataItem, "ProductCategoryID").ToString());
                            if (itm != null)
                            {
                                itm.Selected = true;
                            }
                        }
                    }
                    TextBox txtProductName = (e.Item.FindControl("txtProductName") as TextBox);
                    if (txtProductName != null)
                    {
                    txtProductName.Visible = false;
                        if (DataBinder.Eval(e.Item.DataItem, "ProductName") != null)
                    txtProductName.Text = DataBinder.Eval(e.Item.DataItem, "ProductName").ToString();
                    }
                    TextBox txtNote = (e.Item.FindControl("txtNote") as TextBox);
                    if (txtNote != null)
                    {
                        txtNote.Visible = false;
                        if (DataBinder.Eval(e.Item.DataItem, "Notes") != null)
                            txtNote.Text = DataBinder.Eval(e.Item.DataItem, "Notes").ToString();
                    }

                    Label lblProductCategory = (e.Item.FindControl("lblProductCategory") as Label);
                    if (lblProductCategory != null && DataBinder.Eval(e.Item.DataItem, "ProductCategoryName") != null)
                    {
                    lblProductCategory.Text = DataBinder.Eval(e.Item.DataItem, "ProductCategoryName").ToString();
                    }
                    Label lblProductName = (e.Item.FindControl("lblProductName") as Label);
                    if (lblProductName != null && DataBinder.Eval(e.Item.DataItem, "ProductName") != null)
                    {
                    lblProductName.Text = DataBinder.Eval(e.Item.DataItem, "ProductName").ToString();
                    }
                    Label lblNote = (e.Item.FindControl("lblNote") as Label);
                    if (lblNote != null && DataBinder.Eval(e.Item.DataItem, "Notes") != null)
                    {
                        lblNote.Text = DataBinder.Eval(e.Item.DataItem, "Notes").ToString();
                    }
                }
                else if (e.Item.ItemType == ListItemType.Footer)
                {
                    DropDownList ddlProductCategory = (e.Item.FindControl("ddlProductCategory") as DropDownList);
                    if (ddlProductCategory != null)
                    {
                    BindProductCategory(ddlProductCategory);
                    }
                }
            }

            protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                if (e.CommandName == "Add")
                {
                    DropDownList ddlProductCategory = e.Item.FindControl("ddlProductCategory") as DropDownList;
                    TextBox txtProductName = e.Item.FindControl("txtProductName") as TextBox;
                    TextBox txtNote = e.Item.FindControl("txtNote") as TextBox;
                    if (txtProductName.Text != "")
                    {
                        Repository.SetProduct(null, GetNullableTypes.GetInt(ddlProductCategory.SelectedValue).Value, txtProductName.Text,txtNote.Text, UserName, TenantID);
                        LoadData();
                    lblProductError.Text = "";
                    }
                    else
                    {
                    lblProductError.Text = "Missing Value(s) in Required Field(s)";
                    }
                }
                if (e.CommandName == "Delete")
                {
                    HiddenField hdID = e.Item.FindControl("hdProductID") as HiddenField;
                    Repository.DeleteProduct(GetNullableTypes.GetInt(hdID.Value), UserName);
                    LoadData();
                }
                else if (e.CommandName == "Edit")
                {
                    LinkButton lbtnUpdate = (e.Item.FindControl("lbtnUpdate") as LinkButton);
                    if (lbtnUpdate != null)
                    {
                        lbtnUpdate.Visible = true;
                    }

                    LinkButton lbtnEdit = (e.Item.FindControl("lbtnEdit") as LinkButton);
                    if (lbtnEdit != null)
                    {
                        lbtnEdit.Visible = false;
                    }
                    DropDownList ddlProductCategory = (e.Item.FindControl("ddlProductCategory") as DropDownList);
                    if (ddlProductCategory != null)
                    {
                    ddlProductCategory.Visible = true;
                    }
                    TextBox txtProductName = (e.Item.FindControl("txtProductName") as TextBox);
                    if (txtProductName != null)
                    {
                    txtProductName.Visible = true;
                    }
                    TextBox txtNote = (e.Item.FindControl("txtNote") as TextBox);
                    if (txtNote != null)
                    {
                        txtNote.Visible = true;
                    }
                    Label lblProductCategory = (e.Item.FindControl("lblProductCategory") as Label);
                    if (lblProductCategory != null)
                    {
                    lblProductCategory.Visible = false;
                    }
                    Label lblProductName = (e.Item.FindControl("lblProductName") as Label);
                    if (lblProductName != null)
                    {
                    lblProductName.Visible = false;
                    }
                    Label lblNote = (e.Item.FindControl("lblNote") as Label);
                    if (lblNote != null)
                    {
                        lblNote.Visible = false;
                    }
                }
                else if (e.CommandName == "Update")
                {
                    DropDownList ddlProductCategory = e.Item.FindControl("ddlProductCategory") as DropDownList;
                    TextBox txtProductName = e.Item.FindControl("txtProductName") as TextBox;
                    TextBox txtNote = e.Item.FindControl("txtNote") as TextBox;
                    HiddenField hdProductCategoryID = e.Item.FindControl("hdProductCategoryID") as HiddenField;
                    HiddenField hdProductID = e.Item.FindControl("hdProductID") as HiddenField;


                    if (txtProductName.Text != "")
                    {
                        Repository.SetProduct(GetNullableTypes.GetInt(hdProductID.Value), GetNullableTypes.GetInt(ddlProductCategory.SelectedValue).Value, txtProductName.Text,
                        txtNote.Text, UserName, TenantID);
                        LoadData();
                    lblProductError.Text = "";
                    }
                    else
                    {
                    lblProductError.Text = "Missing Value(s) in Required Field(s)";
                    }
                }
            }

        }
    }

