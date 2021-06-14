using SalonLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalonWeb
{
    public partial class AppointmentForm : Pagebase
    {
        public Nullable<int> AppointmentID
        {
            get
            {
                if (Request.QueryString["AppointmentID"] != null)
                {
                    return Convert.ToInt32(Request.QueryString["AppointmentID"]);
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

        public int count = 0;

        public Nullable<int> CustomerID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["ServiceResult"] = null;
                base.ValidateUser();
                BindService(ddlServiceName);
                //BindEmployee(ddlEmp);
                BindServiceType(ddlServiceTypeName);
                txtApDatetime.Text = DateTime.Now.ToString(Constants.DateTimeFormat);
                LoadData();
                Total();
                if (ddlAppointmentStatus.SelectedValue.ToString() != "4")
                {
                    hideInvoice.Visible = false;
                }
                if (IsClient)
                {
                    ddlAppointmentStatus.Visible = false;
                    lblAppointmentStatus.Visible = false;
                    ddlAppointmentStatus.SelectedValue = "1";
                }
            }
        }

        public void BindService(DropDownList ddlServiceName)
        {
            var result = Repository.GetService(null,TenantID);
            if (result != null)
            {
                ddlServiceName.DataSource = result;
                ddlServiceName.DataTextField = "Name";
                ddlServiceName.DataValueField = "ServiceID";
                ddlServiceName.DataBind();
            }
        }

        public void BindServiceType(DropDownList ddlServiceTypeName)
        {
            var result = Repository.GetServiceType(null, GetNullableTypes.GetInt(ddlServiceName.SelectedValue).Value, TenantID);
            if (result != null)
            {
                ddlServiceTypeName.DataSource = result;
                ddlServiceTypeName.DataTextField = "ServiceTypeName";
                ddlServiceTypeName.DataValueField = "ServiceTypeID";
                ddlServiceTypeName.DataBind();
            }
        }

        //public void BindEmployee(DropDownList ddlEmp)
        //{
        //    var result = Repository.GetEmployee(null, null);
        //    if (result != null)
        //    {
        //        ddlEmp.DataSource = result;
        //        ddlEmp.DataTextField = "FullName";
        //        ddlEmp.DataValueField = "EmployeeID";
        //        ddlEmp.DataBind();
        //    }
        //}

        public void BindAppointmentStatus(DropDownList ddlEmp)
        {
            var result = Repository.GetAppointment(null, null, TenantID);
            if (result != null)
            {
                ddlEmp.DataSource = result;
                ddlEmp.DataTextField = "AppointmentStatusID";
                ddlEmp.DataValueField = "AppointmentID";
                ddlEmp.DataBind();
            }
        }

        private void LoadData()
        {
            if (AppointmentID.HasValue)
            {
                var result = Repository.GetAppointment(AppointmentID, null, TenantID).FirstOrDefault();
                if (result != null)
                {
                    hdCustomerID.Value = GetNullableTypes.GetEditableValue(result.CustomerID);
                    txtCustomerName.Text = result.CustomerName;
                    txtCustomerName.ReadOnly = true;
                    txtPhoneNumber.Text = result.PhoneNumber;
                    txtPhoneNumber.ReadOnly = true;
                    if (result.AppointmentDateTime.HasValue)
                    {
                        txtApDatetime.Text = result.AppointmentDateTime.Value.ToString(Constants.DateTimeFormat);
                    }
                    if (result.AppointmentStatusID.HasValue)
                    {
                        ddlAppointmentStatus.SelectedValue = (result.AppointmentStatusID.Value.ToString());
                    }
                    ddlPaymentMode.SelectedValue = (result.PaymentMode.ToString());
                    txtNotes.Text = result.Notes;
                    txtAdditionalCost.Text = GetNullableTypes.GetEditableValue(result.AdditionalCost);
                    txtInvoiceDate.Text = GetNullableTypes.GetEditableValue(result.InvoiceDate);
                    lblTotalCost.Text = GetNullableTypes.GetEditableValue(result.TotalCost);
                }
                List<GetAppointmentService_Result> serviceResult = Repository.GetAppointmentService(null, AppointmentID, TenantID).ToList();
                if (serviceResult != null)
                {
                    Session["ServiceResult"] = serviceResult;
                    rptServiceType.DataSource = serviceResult;
                    rptServiceType.DataBind();
                    lblServiceCost.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        Math.Round(serviceResult.Sum(c => c.Cost.Value), 2));
                    decimal? time = serviceResult.Sum(c => c.TimeRequired.Value);
                    if (time.HasValue)
                    {
                        lblTotalTime.Text = ((int)(time.Value/60)).ToString() + " Hour(s) " + Math.Round((time % 60).Value,2).ToString() + " Min(s)";
                    }
                }
                else
                    Session["ServiceResult"] = null;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (GetNullableTypes.GetDateTime(txtApDatetime.Text, "dd/MM/yyyy hh:mm:tt").Value < DateTime.Now)
            {
                lblSubmitError.Text = "Sorry, Please provide future date";
                return;
            }
            if (rptServiceType.Items.Count == 0)
            {
                lblSubmitError.Text = "Sorry, Please provide at-least one service in order to save";
            }
            if (txtCustomerName.Text != "" && txtPhoneNumber.Text != "" && txtApDatetime.Text != "")
            {
                var custID = Repository.SetCustomer(GetNullableTypes.GetInt(hdCustomerID.Value), txtCustomerName.Text, null, null, txtPhoneNumber.Text, null, null, null, null, null, null, UserName, TenantID);
                var appntID = Repository.SetAppointment(AppointmentID, GetNullableTypes.GetDateTime(txtApDatetime.Text, Constants.DateTimeFormat),
                    GetNullableTypes.GetInt(ddlAppointmentStatus.SelectedValue).Value, custID,
                    GetNullableTypes.GetDateTime(txtInvoiceDate.Text, Constants.DateTimeFormat), GetNullableTypes.GetDecimalValue(txtAdditionalCost.Text), GetNullableTypes.GetEditableValue(ddlPaymentMode.SelectedValue.ToString()), txtNotes.Text, UserName, TenantID);

                Repository.DeleteAppointmentService(null, appntID, UserName);
                foreach (RepeaterItem item in rptServiceType.Items)
                {
                    HiddenField hdServiceID = item.FindControl("hdServiceID") as HiddenField;
                    HiddenField hdServiceTypeID = item.FindControl("hdServiceTypeID") as HiddenField;
                    Repository.SetAppointmentService(null, appntID, GetNullableTypes.GetInt(hdServiceTypeID.Value),
                        GetNullableTypes.GetInt(hdServiceID.Value), null, string.Empty, UserName, TenantID);
                }
                if (ddlAppointmentStatus.SelectedValue == ((int)Constants.AppointmentStatus.Invoiced).ToString())
                {
                    Repository.SetAccount(null, AppointmentID, (int)Constants.AccountTypes.Appointment,
                        GetNullableTypes.GetDateTime(txtInvoiceDate.Text, Constants.DateTimeFormat), "Appointment Invoiced", null, GetNullableTypes.GetDecimal(lblTotalCost.Text), null, UserName, TenantID);
                }
                Response.Redirect(Link.GetAppointmentGrid());
            }
            else
            {

                lblError.Text = "Missing Value(s) in Required Field(s)";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppointmentGrid.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = txtPhoneNumber.Text = txtNotes.Text = lblTotalCost.Text =
            txtAdditionalCost.Text = " ";
            //ddlEmp.SelectedValue =
            ddlServiceName.SelectedValue = ddlServiceTypeName.SelectedValue = ddlAppointmentStatus.SelectedValue = "1";
        }

        public void lbtnAdd_Click(object sender, EventArgs e)
        {
            List<GetAppointmentService_Result> serviceResult = Session["ServiceResult"] as List<GetAppointmentService_Result>;
            if (serviceResult == null)
                serviceResult = new List<GetAppointmentService_Result>();
            var serviceType = Repository.GetServiceType(GetNullableTypes.GetInt(ddlServiceTypeName.SelectedValue),
                GetNullableTypes.GetInt(ddlServiceName.SelectedValue), TenantID).FirstOrDefault();
            if (serviceType != null)
            {
                serviceResult.Add(new GetAppointmentService_Result()
                {
                    ServiceTypeID = serviceType.ServiceTypeID,
                    ServiceID = serviceType.ServiceID,
                    ServiceTypeName = serviceType.ServiceTypeName,
                    ServiceName = serviceType.ServiceName,
                    Cost = serviceType.Cost,
                    TimeRequired = serviceType.TimeRequired
                });
                rptServiceType.DataSource = serviceResult;
                rptServiceType.DataBind();
                Session["ServiceResult"] = serviceResult;
                lblServiceCost.Text = Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
                        GetNullableTypes.GetDecimal(Math.Round(serviceResult.Sum(c => c.Cost.Value), 2).ToString()));
              
                decimal? time = serviceResult.Sum(c => c.TimeRequired.Value);
                if (time.HasValue)
                {
                    lblTotalTime.Text = ((int)(time.Value / 60)).ToString() + " Hour(s) " + Math.Round((time % 60).Value, 2).ToString() + " Min(s)";
                }

                Total();
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindServiceType(ddlServiceTypeName);
        }

        protected void rptServiceType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
               e.Item.ItemType == ListItemType.Item)
            {
                Label lblServiceName = (e.Item.FindControl("lblServiceName") as Label);
                if (lblServiceName != null && DataBinder.Eval(e.Item.DataItem, "ServiceName") != null)
                {
                    lblServiceName.Text = DataBinder.Eval(e.Item.DataItem, "ServiceName").ToString();
                }
                Label lblServiceType = (e.Item.FindControl("lblServiceType") as Label);
                if (lblServiceType != null && DataBinder.Eval(e.Item.DataItem, "ServiceTypeName") != null)
                {
                    lblServiceType.Text = DataBinder.Eval(e.Item.DataItem, "ServiceTypeName").ToString();
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
            }
        }

        protected void rptServiceType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                HiddenField hdASID = e.Item.FindControl("hdAppointmentServiceID") as HiddenField;
                HiddenField hdAID = e.Item.FindControl("hdAppointmentID") as HiddenField;
                Repository.DeleteAppointmentService(GetNullableTypes.GetInt(hdASID.Value), AppointmentID, UserName);
                LoadData();
                Total();
            }
        }

        protected void ddlAppointmentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAppointmentStatus.SelectedIndex.ToString() == "4")
            {
                hideInvoice.Visible = true;
            }
            else
            {
                hideInvoice.Visible = false;
            }
        }

        protected void txtAdditionalCost_TextChanged(object sender, EventArgs e)
        {
            Total();
        }

        public void Total()
        {
            
            lblTotalCost.Text = (Globalization.GetGlobalizedNumber(Constants.Culture.US, false,
            (GetNullableTypes.GetDecimal(lblServiceCost.Text).HasValue ?
             GetNullableTypes.GetDecimal(lblServiceCost.Text) : 0) + GetNullableTypes.GetDecimal(txtAdditionalCost.Text)).ToString());
            txtInvoiceDate.Text = DateTime.Now.ToString(Constants.DateTimeFormat);
        }
    }
}