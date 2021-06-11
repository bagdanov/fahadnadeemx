using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalonLibrary;
using System.Web.UI.HtmlControls;
using SalonLibrary;

namespace SalonWeb
{
    public partial class ClientsGrid : Pagebase
    {
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
            var result = Repository.GetClient(null).ToList();
            if (result != null)
            {
                rptClient.DataSource = result;
                rptClient.DataBind();
            }
        }

        protected void rptClient_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item)
            {
                Label lblClientName = (e.Item.FindControl("lblClientName") as Label);
                if (lblClientName != null && DataBinder.Eval(e.Item.DataItem, "Name") != null)
                {
                    lblClientName.Text = DataBinder.Eval(e.Item.DataItem, "Name").ToString();
                }
                Label lblClientType = (e.Item.FindControl("lblClientType") as Label);
                if (lblClientType != null && DataBinder.Eval(e.Item.DataItem, "TypeName") != null)
                {
                    lblClientType.Text = DataBinder.Eval(e.Item.DataItem, "TypeName").ToString();
                }
                Label lblMobile = (e.Item.FindControl("lblMobile") as Label);
                if (lblMobile != null && DataBinder.Eval(e.Item.DataItem, "Mobile") != null)
                {
                    lblMobile.Text = DataBinder.Eval(e.Item.DataItem, "Mobile").ToString();
                }
                Label lblWebsite = (e.Item.FindControl("lblWebsite") as Label);
                if (lblWebsite != null && DataBinder.Eval(e.Item.DataItem, "Website") != null)
                {
                    lblWebsite.Text = DataBinder.Eval(e.Item.DataItem, "Website").ToString();
                }
                Label lblNote = (e.Item.FindControl("lblNote") as Label);
                if (lblNote != null && DataBinder.Eval(e.Item.DataItem, "Notes") != null)
                {
                    lblNote.Text = DataBinder.Eval(e.Item.DataItem, "Notes").ToString();
                }
                HtmlGenericControl btnEdit = (e.Item.FindControl("btnEdit") as HtmlGenericControl);
                if (btnEdit != null)
                {
                    btnEdit.Attributes.Add("onclick", "editClient('" + DataBinder.Eval(e.Item.DataItem, "ClientID").ToString() + "')");
                }
            }
        }

        protected void rptClient_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                HiddenField hdID = e.Item.FindControl("hdIDClient") as HiddenField;
                Repository.DeleteClient(GetNullableTypes.GetInt(hdID.Value), UserName);
                LoadData();
            }

        }
    }
}
