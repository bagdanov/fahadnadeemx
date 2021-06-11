using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalonLibrary;
using System.Web.UI.HtmlControls;
namespace SalonWeb
{
    public partial class ExpenseGrid : Pagebase
    {
        public Nullable<int> ExpenseID
        {
            get
            {
                if (Request.QueryString["ExpenseID"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["ExpenseID"]);
                }
                return null;
            }
        }

        public void BindExpense(DropDownList ddlExpenseType)
        {
            var result = Repository.GetExpense(null, TenantID);
            if (result != null)
            {
                ddlExpenseType.DataSource = result;
                ddlExpenseType.DataTextField = "ExpenseTypeID";
                ddlExpenseType.DataValueField = "ExpenseID";
                ddlExpenseType.DataBind();
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
            var result = Repository.GetExpense(null, TenantID).ToList();
            if (result != null)
            {
                rptExpense.DataSource = result;
                rptExpense.DataBind();
            }
        }

        protected void rptExpense_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                LinkButton lbtnUpdate = (e.Item.FindControl("lbtnUpdate") as LinkButton);
                if (lbtnUpdate != null)
                {
                    lbtnUpdate.Visible = false;
                }
                DropDownList ddlExpenseType = (e.Item.FindControl("ddlExpenseType") as DropDownList);
                if (ddlExpenseType != null && DataBinder.Eval(e.Item.DataItem, "ExpenseTypeID") != null)
                {
                    ddlExpenseType.Visible = false;
                    if (DataBinder.Eval(e.Item.DataItem, "ExpenseTypeID") != null)
                    {
                        ListItem itm = ddlExpenseType.Items.FindByValue(DataBinder.Eval(e.Item.DataItem, "ExpenseTypeID").ToString());
                        if (itm != null)
                        {
                            itm.Selected = true;
                        }
                    }
                }
                TextBox txtExpenseTypeName = (e.Item.FindControl("txtExpenseTypeName") as TextBox);
                if (txtExpenseTypeName != null && DataBinder.Eval(e.Item.DataItem, "TypeName") != null)
                {
                    txtExpenseTypeName.Visible = false;
                    txtExpenseTypeName.Text = DataBinder.Eval(e.Item.DataItem, "TypeName").ToString();
                }
                TextBox txtDate = (e.Item.FindControl("txtDate") as TextBox);
                if (txtDate != null && DataBinder.Eval(e.Item.DataItem, "Date") != null)
                {
                    txtDate.Visible = false;
                    txtDate.Text = GetNullableTypes.GetDateValue(DataBinder.Eval(e.Item.DataItem, "Date"), Constants.DateFormat);
                }
                TextBox txtAmount = (e.Item.FindControl("txtAmount") as TextBox);
                if (txtAmount != null && DataBinder.Eval(e.Item.DataItem, "Amount") != null)
                {
                    txtAmount.Visible = false;
                    txtAmount.Text = DataBinder.Eval(e.Item.DataItem, "Amount").ToString();
                }
                TextBox txtNote = (e.Item.FindControl("txtNote") as TextBox);
                if (txtNote != null)
                {
                    txtNote.Visible = false;
                    if (DataBinder.Eval(e.Item.DataItem, "Notes") != null)
                        txtNote.Text = DataBinder.Eval(e.Item.DataItem, "Notes").ToString();
                }
                Label lblExpenseType = (e.Item.FindControl("lblExpenseType") as Label);
                if (lblExpenseType != null && DataBinder.Eval(e.Item.DataItem, "ExpenseTypeID") != null)
                {
                    if (ddlExpenseType != null)
                    {
                        ListItem itm = ddlExpenseType.Items.FindByValue(DataBinder.Eval(e.Item.DataItem, "ExpenseTypeID").ToString());
                        if (itm != null)
                        {
                            lblExpenseType.Text = itm.Text;
                        }
                    }
                }
                Label lblExpenseTypeName = (e.Item.FindControl("lblExpenseTypeName") as Label);
                if (lblExpenseTypeName != null && DataBinder.Eval(e.Item.DataItem, "TypeName") != null)
                {
                    lblExpenseTypeName.Text = DataBinder.Eval(e.Item.DataItem, "TypeName").ToString();
                }
                Label lblDate = (e.Item.FindControl("lblDate") as Label);
                if (lblDate != null && DataBinder.Eval(e.Item.DataItem, "Date") != null)
                {
                    lblDate.Text = GetNullableTypes.GetDateValue(DataBinder.Eval(e.Item.DataItem, "Date"), Constants.DateFormat);
                }
                Label lblAmount = (e.Item.FindControl("lblAmount") as Label);
                if (lblAmount != null && DataBinder.Eval(e.Item.DataItem, "Amount") != null)
                {
                    lblAmount.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(DataBinder.Eval(e.Item.DataItem, "Amount").ToString()));
                }
                Label lblNote = (e.Item.FindControl("lblNote") as Label);
                if (lblNote != null && DataBinder.Eval(e.Item.DataItem, "Notes") != null)
                {
                    lblNote.Text = DataBinder.Eval(e.Item.DataItem, "Notes").ToString();
                }
            }
        }

        protected void rptExpense_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                DropDownList ddlExpenseType = e.Item.FindControl("ddlExpenseType") as DropDownList;
                TextBox txtExpenseTypeName = e.Item.FindControl("txtExpenseTypeName") as TextBox;
                TextBox txtDate = e.Item.FindControl("txtDate") as TextBox;
                TextBox txtAmount = e.Item.FindControl("txtAmount") as TextBox;
                TextBox txtNote = e.Item.FindControl("txtNote") as TextBox;
                if (ddlExpenseType.SelectedValue != "0" && txtDate.Text != "" && txtAmount.Text != "")
                {
                    var exID = Repository.SetExpense(null, GetNullableTypes.GetInt(ddlExpenseType.SelectedValue).Value, txtExpenseTypeName.Text, GetNullableTypes.GetDateTime(txtDate.Text, Constants.DateFormat), GetNullableTypes.GetDecimalValue(txtAmount.Text), txtNote.Text, UserName, TenantID);
                    Repository.SetAccount(null, exID, (int)Constants.AccountTypes.Expense,
                     GetNullableTypes.GetDateTime(txtDate.Text, Constants.DateTimeFormat), txtExpenseTypeName.Text, GetNullableTypes.GetDecimal(txtAmount.Text), null, null, UserName, TenantID);
                    LoadData();
                    lblExpenseError.Text = "";
                }
                else
                {
                    lblExpenseError.Text = "Missing Value(s) in Required Field(s)";
                }
            }
            if (e.CommandName == "Delete")
            {
                HiddenField hdID = e.Item.FindControl("hdIDExpense") as HiddenField;
                Repository.DeleteExpense(GetNullableTypes.GetInt(hdID.Value), UserName);
               // Repository.DeleteAccount(
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
                DropDownList ddlExpenseType = (e.Item.FindControl("ddlExpenseType") as DropDownList);
                if (ddlExpenseType != null)
                {
                    ddlExpenseType.Visible = true;
                }
                TextBox txtExpenseTypeName = (e.Item.FindControl("txtExpenseTypeName") as TextBox);
                if (txtExpenseTypeName != null)
                {
                    txtExpenseTypeName.Visible = true;
                }
                TextBox txtDate = (e.Item.FindControl("txtDate") as TextBox);
                if (txtDate != null)
                {
                    txtDate.Visible = true;
                }
                TextBox txtAmount = (e.Item.FindControl("txtAmount") as TextBox);
                if (txtAmount != null)
                {
                    txtAmount.Visible = true;
                }
                TextBox txtNote = (e.Item.FindControl("txtNote") as TextBox);
                if (txtNote != null)
                {
                    txtNote.Visible = true;
                }
                Label lblExpenseType = (e.Item.FindControl("lblExpenseType") as Label);
                if (lblExpenseType != null)
                {
                    lblExpenseType.Visible = false;
                }
                Label lblExpenseTypeName = (e.Item.FindControl("lblExpenseTypeName") as Label);
                if (lblExpenseTypeName != null)
                {
                    lblExpenseTypeName.Visible = false;
                }
                Label lblDate = (e.Item.FindControl("lblDate") as Label);
                if (lblDate != null)
                {
                    lblDate.Visible = false;
                }
                Label lblAmount = (e.Item.FindControl("lblAmount") as Label);
                if (lblAmount != null)
                {
                    lblAmount.Visible = false;
                }
                Label lblNote = (e.Item.FindControl("lblNote") as Label);
                if (lblNote != null)
                {
                    lblNote.Visible = false;
                }
            }
            else if (e.CommandName == "Update")
            {
                DropDownList ddlExpenseType = e.Item.FindControl("ddlExpenseType") as DropDownList;
                TextBox txtExpenseTypeName = e.Item.FindControl("txtExpenseTypeName") as TextBox;
                TextBox txtDate = e.Item.FindControl("txtDate") as TextBox;
                TextBox txtAmount = e.Item.FindControl("txtAmount") as TextBox;
                TextBox txtNote = e.Item.FindControl("txtNote") as TextBox;
                HiddenField hdIDExpense = e.Item.FindControl("hdIDExpense") as HiddenField;
                if (ddlExpenseType.SelectedValue != "0" && txtDate.Text != "" && txtAmount.Text != "")
                {
                    var exID = Repository.SetExpense(GetNullableTypes.GetInt(hdIDExpense.Value),
                        GetNullableTypes.GetInt(ddlExpenseType.SelectedValue).Value, txtExpenseTypeName.Text,
                        GetNullableTypes.GetDateTime(txtDate.Text, Constants.DateFormat), GetNullableTypes.GetDecimalValue(txtAmount.Text), txtNote.Text, UserName, TenantID);
                    Repository.SetAccount(null, exID, (int)Constants.AccountTypes.Expense,
                     GetNullableTypes.GetDateTime(txtDate.Text, Constants.DateTimeFormat), txtExpenseTypeName.Text, GetNullableTypes.GetDecimal(txtAmount.Text), null, null, UserName, TenantID);
                    LoadData();
                    lblExpenseError.Text = "";
                }
                else
                {
                    lblExpenseError.Text = "Missing Value(s) in Required Field(s)";
                }
            }
        }

    }
}