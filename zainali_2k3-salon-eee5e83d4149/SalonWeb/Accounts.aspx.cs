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
    public partial class Accounts : Pagebase
    {
        public Nullable<int> AccountID
        {
            get
            {
                if (Request.QueryString["AccountID"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["AccountID"]);
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
            var Todate = GetNullableTypes.GetDateTime(txtToDate.Text, Constants.DateTimeFormat);
            var Fromdate = GetNullableTypes.GetDateTime(txtFromDate.Text, Constants.DateTimeFormat);
            var result = Repository.GetAccount(GetNullableTypes.GetDateTime(txtToDate.Text, Constants.DateTimeFormat), GetNullableTypes.GetDateTime(txtFromDate.Text, Constants.DateTimeFormat),TenantID).ToList();
            if (result != null)
            {
                rptAccount.DataSource = result;
                rptAccount.DataBind();
            }
        }

        protected void rptAccount_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hdIDModule = e.Item.FindControl("hdIDModule") as HiddenField;
                var hd = GetNullableTypes.GetInt(DataBinder.Eval(e.Item.DataItem, "ModuleID").ToString());
                if (hd != 4 && hd != 5)
                {
                    LinkButton lbtnEdit = (e.Item.FindControl("lbtnEdit") as LinkButton);
                    if (lbtnEdit != null)
                    {
                        lbtnEdit.Visible = false;
                    }
                    LinkButton lbtnDelete = (e.Item.FindControl("lbtnDelete") as LinkButton);
                    if (lbtnDelete != null)
                    {
                        lbtnDelete.Visible = false;
                    }
                }
                LinkButton lbtnUpdate = (e.Item.FindControl("lbtnUpdate") as LinkButton);
                if (lbtnUpdate != null)
                {
                    lbtnUpdate.Visible = false;
                }
                DropDownList ddlType = (e.Item.FindControl("ddlType") as DropDownList);
                if (ddlType != null && DataBinder.Eval(e.Item.DataItem, "ObjectName") != null)
                {
                    ddlType.Visible = false;
                    if (DataBinder.Eval(e.Item.DataItem, "ObjectName") != null)
                    {
                        ListItem itm = ddlType.Items.FindByValue(DataBinder.Eval(e.Item.DataItem, "ObjectName").ToString());
                        if (itm != null)
                        {
                            itm.Selected = true;
                        }
                    }
                }
                TextBox txtDate = (e.Item.FindControl("txtDate") as TextBox);
                if (txtDate != null && DataBinder.Eval(e.Item.DataItem, "Date") != null)
                {
                    txtDate.Visible = false;
                    txtDate.Text = GetNullableTypes.GetDateValue(DataBinder.Eval(e.Item.DataItem, "Date"), Constants.DateFormat);
                }
                TextBox txtDesciption = (e.Item.FindControl("txtDesciption") as TextBox);
                if (txtDesciption != null)
                {
                    txtDesciption.Visible = false;
                    if (DataBinder.Eval(e.Item.DataItem, "Description") != null)
                        txtDesciption.Text = DataBinder.Eval(e.Item.DataItem, "Description").ToString();
                }
                TextBox txtDebit = (e.Item.FindControl("txtDebit") as TextBox);
                if (txtDebit != null)
                {
                    txtDebit.Visible = false;
                    if (DataBinder.Eval(e.Item.DataItem, "Debit") != null)
                        txtDebit.Text = DataBinder.Eval(e.Item.DataItem, "Debit").ToString();
                }
                TextBox txtCredit = (e.Item.FindControl("txtCredit") as TextBox);
                if (txtCredit != null)
                {
                    txtCredit.Visible = false;
                    if (DataBinder.Eval(e.Item.DataItem, "Credit") != null)
                        txtCredit.Text = DataBinder.Eval(e.Item.DataItem, "Credit").ToString();
                }
                Label lblAccountID = (e.Item.FindControl("lblAccountID") as Label);
                if (lblAccountID != null && DataBinder.Eval(e.Item.DataItem, "AccountID") != null)
                {
                    lblAccountID.Text = DataBinder.Eval(e.Item.DataItem, "AccountID").ToString();
                }
                Label lblObjectID = (e.Item.FindControl("lblObjectID") as Label);
                if (lblObjectID != null && DataBinder.Eval(e.Item.DataItem, "ObjectID") != null)
                {
                    lblObjectID.Text = DataBinder.Eval(e.Item.DataItem, "ObjectID").ToString();
                }
                Label lblType = (e.Item.FindControl("lblType") as Label);
                if (lblType != null && DataBinder.Eval(e.Item.DataItem, "ObjectName") != null)
                {
                    lblType.Text = DataBinder.Eval(e.Item.DataItem, "ObjectName").ToString();
                }
                Label lblDate = (e.Item.FindControl("lblDate") as Label);
                if (lblDate != null && DataBinder.Eval(e.Item.DataItem, "Date") != null)
                {
                    lblDate.Text = GetNullableTypes.GetDateValue(DataBinder.Eval(e.Item.DataItem, "Date"), Constants.DateFormat);
                }
                Label lblDesciption = (e.Item.FindControl("lblDesciption") as Label);
                if (lblDesciption != null && DataBinder.Eval(e.Item.DataItem, "Description") != null)
                {
                    lblDesciption.Text = DataBinder.Eval(e.Item.DataItem, "Description").ToString();
                }
                Label lblDebit = (e.Item.FindControl("lblDebit") as Label);
                if (lblDebit != null && DataBinder.Eval(e.Item.DataItem, "Debit") != null)
                {
                    lblDebit.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(DataBinder.Eval(e.Item.DataItem, "Debit").ToString()));
                }
                Label lblCredit = (e.Item.FindControl("lblCredit") as Label);
                if (lblCredit != null && DataBinder.Eval(e.Item.DataItem, "Credit") != null)
                {
                    lblCredit.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(DataBinder.Eval(e.Item.DataItem, "Credit").ToString()));
                }
                Label lblBalance = (e.Item.FindControl("lblBalance") as Label);
                if (lblBalance != null && DataBinder.Eval(e.Item.DataItem, "Balance") != null)
                {
                    lblBalance.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(DataBinder.Eval(e.Item.DataItem, "Balance").ToString()));
                }
            }
        }

        protected void rptAccount_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                DropDownList ddlType = e.Item.FindControl("ddlType") as DropDownList;
                TextBox txtDate = e.Item.FindControl("txtDate") as TextBox;
                TextBox txtDesciption = e.Item.FindControl("txtDesciption") as TextBox;
                TextBox txtAmount = e.Item.FindControl("txtAmount") as TextBox;
                Nullable<decimal> credit = null;
                Nullable<decimal> debit = null;
                if (ddlType.SelectedValue == ((int)Constants.AccountTypes.CashInHand).ToString() ||
                    ddlType.SelectedValue == ((int)Constants.AccountTypes.StartingBalance).ToString())
                {
                    if (GetNullableTypes.GetDecimal(txtAmount.Text).HasValue)
                        credit = GetNullableTypes.GetDecimalValue(txtAmount.Text);
                }
                else
                {
                    if (GetNullableTypes.GetDecimal(txtAmount.Text).HasValue)
                        debit = GetNullableTypes.GetDecimalValue(txtAmount.Text);
                }
                if (ddlType.SelectedValue != "0" && txtDate.Text != "")
                {
                    Repository.SetAccount(AccountID, null, GetNullableTypes.GetInt(ddlType.SelectedValue),
                        GetNullableTypes.GetDateTime(txtDate.Text, Constants.DateFormat), txtDesciption.Text, debit
                        , credit, null, UserName, TenantID);
                    LoadData();
                    lblAccountError.Text = "";
                }
                else
                {
                    lblAccountError.Text = "Missing Value(s) in Required Field(s)";
                }
            }
            if (e.CommandName == "Delete")
            {
                HiddenField hdID = e.Item.FindControl("hdIDAccount") as HiddenField;
                Repository.DeleteAccount(GetNullableTypes.GetInt(hdID.Value), UserName);
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
                DropDownList ddlType = (e.Item.FindControl("ddlType") as DropDownList);
                if (ddlType != null)
                {
                    ddlType.Visible = true;
                }
                TextBox txtDate = (e.Item.FindControl("txtDate") as TextBox);
                if (txtDate != null)
                {
                    txtDate.Visible = true;
                }
                TextBox txtDesciption = (e.Item.FindControl("txtDesciption") as TextBox);
                if (txtDesciption != null)
                {
                    txtDesciption.Visible = true;
                }
                TextBox txtDebit = (e.Item.FindControl("txtDebit") as TextBox);
                if (txtDebit != null)
                {
                    txtDebit.Visible = true;
                }
                TextBox txtCredit = (e.Item.FindControl("txtCredit") as TextBox);
                if (txtCredit != null)
                {
                    txtCredit.Visible = true;
                }
                Label lblAccountID = (e.Item.FindControl("lblAccountID") as Label);
                if (lblAccountID != null)
                {
                    lblAccountID.Visible = false;
                }
                Label lblObjectID = (e.Item.FindControl("lblObjectID") as Label);
                if (lblObjectID != null)
                {
                    lblObjectID.Visible = false;
                }
                Label lblType = (e.Item.FindControl("lblType") as Label);
                if (lblType != null)
                {
                    lblType.Visible = false;
                }
                Label lblDate = (e.Item.FindControl("lblDate") as Label);
                if (lblDate != null)
                {
                    lblDate.Visible = false;
                }
                Label lblDesciption = (e.Item.FindControl("lblDesciption") as Label);
                if (lblDesciption != null)
                {
                    lblDesciption.Visible = false;
                }
                Label lblDebit = (e.Item.FindControl("lblDebit") as Label);
                if (lblDebit != null)
                {
                    lblDebit.Visible = false;
                }
                Label lblCredit = (e.Item.FindControl("lblCredit") as Label);
                if (lblCredit != null)
                {
                    lblCredit.Visible = false;
                }
                Label lblBalance = (e.Item.FindControl("lblBalance") as Label);
                if (lblBalance != null)
                {
                    lblBalance.Visible = false;
                }
            }
            else if (e.CommandName == "Update")
            {
                DropDownList ddlType = e.Item.FindControl("ddlType") as DropDownList;
                TextBox txtDate = e.Item.FindControl("txtDate") as TextBox;
                TextBox txtDesciption = e.Item.FindControl("txtDesciption") as TextBox;
                TextBox txtDebit = e.Item.FindControl("txtDebit") as TextBox;
                TextBox txtCredit = e.Item.FindControl("txtCredit") as TextBox;
                if (ddlType.SelectedValue != "0" && txtDate.Text != "" && (txtDebit.Text != "" || txtCredit.Text != ""))
                {
                    Repository.SetAccount(AccountID, null, GetNullableTypes.GetInt(ddlType.SelectedValue), GetNullableTypes.GetDateTime(txtDate.Text, Constants.DateFormat), txtDesciption.Text, GetNullableTypes.GetDecimalValue(txtDebit.Text), GetNullableTypes.GetDecimalValue(txtCredit.Text), null, UserName, TenantID);
                    LoadData();
                    lblAccountError.Text = "";
                }
                else
                {
                    lblAccountError.Text = "Missing Value(s) in Required Field(s)";
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}