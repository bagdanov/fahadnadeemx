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
    public partial class ServiceGrid : SalonWeb.Pagebase
    {
        public Nullable<int> ServiceID
        {
            get
            {
                if (Request.QueryString["ServiceID"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["ServiceID"]);
                }
                return null;
            }
        }

        public Nullable<int> ServiceTypeID
        {
            get
            {
                if (Request.QueryString["ServiceTypeID"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["ServiceTypeID"]);
                }
                return null;
            }
        }

        public bool IsClient
        {
            get
            {
                if (Session["IsClient"] != null)
                {
                    return Convert.ToBoolean(Session["IsClient"]);
                }
                return false;
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
            var result = Repository.GetService(null, TenantID).ToList();
            if (result != null)
            {
                rptService.DataSource = result;
                rptService.DataBind();
            }
            var resulttype = Repository.GetServiceType(null, null, TenantID).ToList();
            if (resulttype != null)
            {
                rptServiceType.DataSource = resulttype;
                rptServiceType.DataBind();
            }
        }

        public void BindService(DropDownList ddlServiceName)
        {
            var result = Repository.GetService(null, TenantID);
            if (result != null)
            {
                ddlServiceName.DataSource = result;
                ddlServiceName.DataTextField = "Name";
                ddlServiceName.DataValueField = "ServiceID";
                ddlServiceName.DataBind();
            }
        }

        protected void rptService_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                HtmlTableCell headerEdit = (e.Item.FindControl("headerEdit") as HtmlTableCell);
                if (headerEdit != null && IsClient)
                {
                    headerEdit.Style.Add("display", "none");
                }
                HtmlTableCell headerNotes = (e.Item.FindControl("headerNotes") as HtmlTableCell);
                if (headerNotes != null && IsClient)
                {
                    headerNotes.Style.Add("display", "none");
                }
                HtmlTableCell headerDelete = (e.Item.FindControl("headerDelete") as HtmlTableCell);
                if (headerDelete != null && IsClient)
                {
                    headerDelete.Style.Add("display", "none");
                }

            }
           
            else if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {

                if (IsClient)
                {
                    HtmlTableCell edit = (e.Item.FindControl("edit") as HtmlTableCell);
                    if (edit != null && IsClient)
                    {
                        edit.Style.Add("display", "none");
                    }
                    HtmlTableCell notes = (e.Item.FindControl("notes") as HtmlTableCell);
                    if (notes != null && IsClient)
                    {
                        notes.Style.Add("display", "none");
                    }
                    HtmlTableCell del = (e.Item.FindControl("del") as HtmlTableCell);
                    if (del != null && IsClient)
                    {
                        del.Style.Add("display", "none");
                    }
                }
                LinkButton lbtnUpdate = (e.Item.FindControl("lbtnUpdate") as LinkButton);
                if (lbtnUpdate != null)
                {
                    lbtnUpdate.Visible = false;
                }
                LinkButton lbtnEdit = (e.Item.FindControl("lbtnEdit") as LinkButton);
                if (lbtnEdit != null && IsClient)
                {
                    lbtnEdit.Visible = false;
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

                LinkButton lbtnDeleteService = (e.Item.FindControl("lbtnDeleteService") as LinkButton);
                if (lbtnDeleteService != null && IsClient)
                {
                    lbtnDeleteService.Visible = false;
                }


            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                if (IsClient)
                {
                    HtmlTableRow foot = (e.Item.FindControl("foot") as HtmlTableRow);
                    if (foot != null && IsClient)
                    {
                        foot.Style.Add("display", "none");
                    }
                }
            }
            LinkButton lbtnAdd = (e.Item.FindControl("lbtnAdd") as LinkButton);
            if (lbtnAdd != null && IsClient)
            {
                lbtnAdd.Visible = false;
            }
        }

        protected void rptService_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                TextBox txtName = e.Item.FindControl("txtName") as TextBox;
                TextBox txtNote = e.Item.FindControl("txtNote") as TextBox;
                if (txtName.Text != "")
                {
                    Repository.SetService(null, txtName.Text, null, txtNote.Text, TenantID);
                    LoadData();
                    lblServiceError.Text = "";
                }
                else
                {
                    lblServiceError.Text = "Missing Value(s) in Required Field(s)";
                }
            }
            if (e.CommandName == "Delete")
            {
                HiddenField hdID = e.Item.FindControl("hdIDService") as HiddenField;
                Repository.DeleteService(GetNullableTypes.GetInt(hdID.Value), null);
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
                HiddenField hdID = e.Item.FindControl("hdIDService") as HiddenField;
                if (txtName.Text != "")
                {
                    Repository.SetService(GetNullableTypes.GetInt(hdID.Value), txtName.Text, null, txtNote.Text, TenantID);
                    LoadData();
                    lblServiceError.Text = "";
                }
                else
                {
                    lblServiceError.Text = "Missing Value(s) in Required Field(s)";
                }
            }
        }

        protected void rptServiceType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                HtmlTableCell headerEdit = (e.Item.FindControl("stHeaderEdit") as HtmlTableCell);
                if (headerEdit != null && IsClient)
                {
                    headerEdit.Style.Add("display", "none");
                }
                HtmlTableCell headerNotes = (e.Item.FindControl("stHeaderNotes") as HtmlTableCell);
                if (headerNotes != null && IsClient)
                {
                    headerNotes.Style.Add("display", "none");
                }
                HtmlTableCell headerDelete = (e.Item.FindControl("stHeaderDelete") as HtmlTableCell);
                if (headerDelete != null && IsClient)
                {
                    headerDelete.Style.Add("display", "none");
                }
            }
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                if (IsClient)
                {
                    HtmlTableCell edit = (e.Item.FindControl("stEdit") as HtmlTableCell);
                    if (edit != null && IsClient)
                    {
                        edit.Style.Add("display", "none");
                    }
                    HtmlTableCell notes = (e.Item.FindControl("stNotes") as HtmlTableCell);
                    if (notes != null && IsClient)
                    {
                        notes.Style.Add("display", "none");
                    }
                    HtmlTableCell del = (e.Item.FindControl("stDel") as HtmlTableCell);
                    if (del != null && IsClient)
                    {
                        del.Style.Add("display", "none");
                    }
                }
                LinkButton lbtnUpdate = (e.Item.FindControl("lbtnUpdate") as LinkButton);
                if (lbtnUpdate != null)
                {
                    lbtnUpdate.Visible = false;
                }
                LinkButton lbtnEdit = (e.Item.FindControl("lbtnEdit") as LinkButton);
                if (lbtnEdit != null && IsClient)
                {
                    lbtnEdit.Visible = false;
                }
                DropDownList ddlServiceName = (e.Item.FindControl("ddlServiceName") as DropDownList);
                if (ddlServiceName != null && DataBinder.Eval(e.Item.DataItem, "ServiceID") != null)
                {
                    ddlServiceName.Visible = false;
                    BindService(ddlServiceName);
                    if (DataBinder.Eval(e.Item.DataItem, "ServiceID") != null)
                    {
                        ListItem itm = ddlServiceName.Items.FindByValue(DataBinder.Eval(e.Item.DataItem, "ServiceID").ToString());
                        if (itm != null)
                        {
                            itm.Selected = true;
                        }
                    }
                }
                TextBox txtTypeName = (e.Item.FindControl("txtTypeName") as TextBox);
                if (txtTypeName != null)
                {
                    txtTypeName.Visible = false;
                    if (DataBinder.Eval(e.Item.DataItem, "ServiceTypeName") != null) 
                    txtTypeName.Text = DataBinder.Eval(e.Item.DataItem, "ServiceTypeName").ToString();
                }
                TextBox txtCost = (e.Item.FindControl("txtCost") as TextBox);

                if (txtCost != null)
                {
                    txtCost.Visible = false;
                    if (DataBinder.Eval(e.Item.DataItem, "Cost") != null)
                        txtCost.Text = DataBinder.Eval(e.Item.DataItem, "Cost").ToString();
                }
                TextBox txtTimeRequired = (e.Item.FindControl("txtTimeRequired") as TextBox);
                if (txtTimeRequired != null)
                {
                    txtTimeRequired.Visible = false;
                    if (DataBinder.Eval(e.Item.DataItem, "TimeRequired") != null)
                        txtTimeRequired.Text = DataBinder.Eval(e.Item.DataItem, "TimeRequired").ToString();
                }
                TextBox txtNote = (e.Item.FindControl("txtNote") as TextBox);
                if (txtNote != null)
                {
                    txtNote.Visible = false;
                    if (DataBinder.Eval(e.Item.DataItem, "Notes") != null)
                        txtNote.Text = DataBinder.Eval(e.Item.DataItem, "Notes").ToString();
                }

                Label lblName = (e.Item.FindControl("lblName") as Label);
                if (lblName != null && DataBinder.Eval(e.Item.DataItem, "ServiceName") != null)
                {
                    lblName.Text = DataBinder.Eval(e.Item.DataItem, "ServiceName").ToString();
                }
                Label lblTypeName = (e.Item.FindControl("lblTypeName") as Label);
                if (lblTypeName != null && DataBinder.Eval(e.Item.DataItem, "ServiceTypeName") != null)
                {
                    lblTypeName.Text = DataBinder.Eval(e.Item.DataItem, "ServiceTypeName").ToString();
                }
                Label lblCost = (e.Item.FindControl("lblCost") as Label);
                if (lblCost != null && DataBinder.Eval(e.Item.DataItem, "Cost") != null)
                {
                    lblCost.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(DataBinder.Eval(e.Item.DataItem, "Cost").ToString()));
                }
                Label lblTimeRequired = (e.Item.FindControl("lblTimeRequired") as Label);
                if (lblTimeRequired != null && DataBinder.Eval(e.Item.DataItem, "TimeRequired") != null)
                {
                    lblTimeRequired.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(DataBinder.Eval(e.Item.DataItem, "TimeRequired").ToString()));
                }
                Label lblNote = (e.Item.FindControl("lblNote") as Label);
                if (lblNote != null && DataBinder.Eval(e.Item.DataItem, "Notes") != null)
                {
                    lblNote.Text = DataBinder.Eval(e.Item.DataItem, "Notes").ToString();
                }

                LinkButton lbtnDeleteType = (e.Item.FindControl("lbtnDeleteType") as LinkButton);
                if (lbtnDeleteType != null && IsClient)
                {
                    lbtnDeleteType.Visible = false;
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                if (IsClient)
                {
                    HtmlTableRow stFoot = (e.Item.FindControl("stFoot") as HtmlTableRow);
                    if (stFoot != null && IsClient)
                    {
                        stFoot.Style.Add("display", "none");
                    }
                }
                else
                {
                    DropDownList ddlServiceName = (e.Item.FindControl("ddlServiceName") as DropDownList);
                    if (ddlServiceName != null)
                    {
                        BindService(ddlServiceName);
                    }
                }
            }
            LinkButton lbtnAdd = (e.Item.FindControl("lbtnAdd") as LinkButton);
                if (lbtnAdd != null && IsClient)
                {
                    lbtnAdd.Visible = false;
                }
                
            
        }

        protected void rptServiceType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
                if (e.CommandName == "Add")
                {
                    DropDownList ddlServiceName = e.Item.FindControl("ddlServiceName") as DropDownList;
                    TextBox txtTypeName = e.Item.FindControl("txtTypeName") as TextBox;
                    TextBox txtCost = e.Item.FindControl("txtCost") as TextBox;
                    TextBox txtTimeRequired = e.Item.FindControl("txtTimeRequired") as TextBox;
                    TextBox txtNote = e.Item.FindControl("txtNote") as TextBox;
                    if (txtTypeName.Text != "" && txtCost.Text != "" && txtTimeRequired.Text != "")
                    {
                        Repository.SetServiceType(null, GetNullableTypes.GetInt(ddlServiceName.SelectedValue).Value, txtTypeName.Text, GetNullableTypes.GetDecimal(txtCost.Text),
                        GetNullableTypes.GetDecimal(txtTimeRequired.Text), txtNote.Text, UserName, TenantID);
                        LoadData();
                        lblServiceTypeError.Text = "";
                    }
                    else
                    {
                        lblServiceTypeError.Text = "Missing Value(s) in Required Field(s)";
                    }
                }
                if (e.CommandName == "Delete")
                {
                    HiddenField hdID = e.Item.FindControl("hdIDServiceType") as HiddenField;
                    Repository.DeleteServiceType(GetNullableTypes.GetInt(hdID.Value), null);
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
                    DropDownList ddlServiceName = (e.Item.FindControl("ddlServiceName") as DropDownList);
                    if (ddlServiceName != null)
                    {
                        ddlServiceName.Visible = true;
                    }
                    TextBox txtTypeName = (e.Item.FindControl("txtTypeName") as TextBox);
                    if (txtTypeName != null)
                    {
                        txtTypeName.Visible = true;
                    }
                    TextBox txtCost = (e.Item.FindControl("txtCost") as TextBox);
                    if (txtCost != null)
                    {
                        txtCost.Visible = true;
                    }
                    TextBox txtTimeRequired = (e.Item.FindControl("txtTimeRequired") as TextBox);
                    if (txtTimeRequired != null)
                    {
                        txtTimeRequired.Visible = true;
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
                    Label lblTypeName = (e.Item.FindControl("lblTypeName") as Label);
                    if (lblTypeName != null)
                    {
                        lblTypeName.Visible = false;
                    }
                    Label lblCost = (e.Item.FindControl("lblCost") as Label);
                    if (lblCost != null)
                    {
                        lblCost.Visible = false;
                    }
                    Label lblTimeRequired = (e.Item.FindControl("lblTimeRequired") as Label);
                    if (lblTimeRequired != null)
                    {
                        lblTimeRequired.Visible = false;
                    }
                    Label lblNote = (e.Item.FindControl("lblNote") as Label);
                    if (lblNote != null)
                    {
                        lblNote.Visible = false;
                    }
                }
                else if (e.CommandName == "Update")
                {
                    DropDownList ddlServiceName = e.Item.FindControl("ddlServiceName") as DropDownList;
                    TextBox txtTypeName = e.Item.FindControl("txtTypeName") as TextBox;
                    TextBox txtCost = e.Item.FindControl("txtCost") as TextBox;
                    TextBox txtTimeRequired = e.Item.FindControl("txtTimeRequired") as TextBox;
                    TextBox txtNote = e.Item.FindControl("txtNote") as TextBox;
                    HiddenField hdIDServiceType = e.Item.FindControl("hdIDServiceType") as HiddenField;
                    HiddenField hdIDService = e.Item.FindControl("hdIDService") as HiddenField;

                    if (txtTypeName.Text != "" && txtCost.Text != "" && txtTimeRequired.Text != "")
                    {
                        Repository.SetServiceType(GetNullableTypes.GetInt(hdIDServiceType.Value), GetNullableTypes.GetInt(ddlServiceName.SelectedValue).Value, txtTypeName.Text,
                        GetNullableTypes.GetDecimal(txtCost.Text), GetNullableTypes.GetDecimal(txtTimeRequired.Text), txtNote.Text, UserName, TenantID);
                        LoadData();
                        lblServiceTypeError.Text = "";
                    }
                    else
                    {
                        lblServiceTypeError.Text = "Missing Value(s) in Required Field(s)";
                    }

                }
            
        }
    }
}
