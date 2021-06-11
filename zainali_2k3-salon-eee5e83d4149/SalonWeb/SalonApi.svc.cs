using SalonLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace SalonWeb
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SalonApi
    {
        [WebInvoke(UriTemplate = "/GetCustomerByPhone?phoneNumber={phoneNumber}&tenantID={tenantID}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
        ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public List<GetCustomer_Result> GetCustomerByPhone(string phoneNumber,string tenantID)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber))
                {
                    return null;
                }
                else
                {
                    return Repository.GetCustomerByPhone(phoneNumber, GetNullableTypes.GetInt(tenantID)).ToList();
                }
            }

            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }
        
        [WebInvoke(UriTemplate = "/SetCustomer?customerID={customerID}&firstName={firstName}&lastName={lastName}&dateOfBirth={dateOfBirth}&phoneNumber={phoneNumber}&alternatePhoneNumber={alternatePhoneNumber}&emailAddress={emailAddress}&password={password}&address={address}&city={city}&userName={userName}&notes={notes}&tenantID={tenantID}",
            Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public Nullable<int> SetCustomer(string customerID, string firstName, string lastName, string dateOfBirth, string phoneNumber, string alternatePhoneNumber,
            string emailAddress, string password, string address, string city, string userName, string notes,string tenantID)
        {
            try
            {
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(emailAddress) ||
                    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userName))
                {
                    return null;
                }
                else
                {
                    return Repository.SetCustomer(GetNullableTypes.GetInt(customerID), firstName, lastName, GetNullableTypes.GetDateTime(dateOfBirth, Constants.DateFormat), phoneNumber, alternatePhoneNumber,
                      emailAddress, password, address, city, userName, notes, GetNullableTypes.GetInt(tenantID));
                }

            }

            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }

        [WebInvoke(UriTemplate = "/DeleteCustomer?customerID={customerID}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public Nullable<int> DeleteCustomer(string customerID)
        {
            try
            {
                if (string.IsNullOrEmpty(customerID))
                {
                    return null;
                }
                else
                {
                    return Repository.DeleteCustomer(GetNullableTypes.GetInt(customerID), null);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }



        [WebInvoke(UriTemplate = "/GetDashboardKPI?dateFrom={dateFrom}&dateTo={dateTo}&tenantID={tenantID}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
     ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public List<GetDashboardKPI_Result> GetDashboardKPI(string dateFrom, string dateTo, string tenantID)
        {
            try
            {
                if (string.IsNullOrEmpty(dateFrom) && string.IsNullOrEmpty(dateTo))
                {
                    return null;
                }
                else
                {
                    return Repository.GetDashboardKPI(GetNullableTypes.GetDateTime(dateFrom, Constants.DateFormat), GetNullableTypes.GetDateTime(dateTo, Constants.DateFormat), GetNullableTypes.GetInt(tenantID)).ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }


        [WebInvoke(UriTemplate = "/GetMonthlySales?tenantID={tenantID}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
      ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public List<GetMonthlySales_Result> GetMonthlySales(string tenantID)
        {
            try
            {
                return Repository.GetMonthlySales(GetNullableTypes.GetInt(tenantID)).ToList();

            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }

        [WebInvoke(UriTemplate = "/GetWeeklySales?tenantID={tenantID}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
     ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public List<GetWeeklySales_Result> GetWeeklySales(string tenantID)
        {
            try
            {
                return Repository.GetWeeklySales((int)Constants.AccountTypes.Appointment, GetNullableTypes.GetInt(tenantID)).ToList();

            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }

        [WebInvoke(UriTemplate = "/GetWeeklyRevenue?tenantID={tenantID}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
     ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public List<GetWeeklySales_Result> GetWeeklyRevenue(string tenantID)
        {
            try
            {
                return Repository.GetWeeklySales(null, GetNullableTypes.GetInt(tenantID)).ToList();

            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }

        [WebInvoke(UriTemplate = "/GetAppointment?appointmentid={appointmentid}&tenantID={tenantID}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
     ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public List<GetAppointment_Result> GetAppointment(string appointmentid, string tenantID)
        {
            try
            {
                if (string.IsNullOrEmpty(appointmentid))
                {
                    return null;
                }
                else
                {
                    return Repository.GetAppointment(GetNullableTypes.GetInt(appointmentid), null, GetNullableTypes.GetInt(tenantID)).ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }
        
        [WebInvoke(UriTemplate = "/SetAppointment?appointmentid={appointmentid}&appointmentDateTime={appointmentDateTime}&customerid={customerid}&userName={userName}&notes={notes}&tenantID={tenantID}", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
    ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public Nullable<int> SetAppointment(string appointmentid, string appointmentDateTime,
            string customerid, string userName, string notes, string tenantID)
        {
            try
            {
                if (string.IsNullOrEmpty(appointmentDateTime) || string.IsNullOrEmpty(userName))
                {
                    return null;
                }
                else
                {
                    return Repository.SetAppointment(GetNullableTypes.GetInt(appointmentid), GetNullableTypes.GetDateTime(appointmentDateTime, Constants.DateFormat), 1, GetNullableTypes.GetInt(customerid), null, null, null, userName, notes, GetNullableTypes.GetInt(tenantID));
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }

        [WebInvoke(UriTemplate = "/DeleteAppointment?appointmentid={appointmentid}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public Nullable<int> DeleteAppointment(string appointmentid)
        {
            try
            {
                if (string.IsNullOrEmpty(appointmentid))
                {
                    return null;
                }
                else
                {
                    return Repository.DeleteAppointment(GetNullableTypes.GetInt(appointmentid), null);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }

        [WebInvoke(UriTemplate = "/GetAppointmentService?appointmentid={appointmentid}&tenantID={tenantID}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public List<GetAppointmentService_Result> GetAppointmentService(string appointmentid, string tenantID)
        {
            try
            {
                if (string.IsNullOrEmpty(appointmentid))
                {
                    return null;
                }
                else
                {
                    return Repository.GetAppointmentService(null, GetNullableTypes.GetInt(appointmentid), GetNullableTypes.GetInt(tenantID)).ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }

        [WebInvoke(UriTemplate = "/SetAppointmentService?appointmentserviceid={appointmentserviceid}&appointmentid={appointmentid}&serviceTypeID={serviceTypeID}&serviceID={serviceID}&userName={userName}&notes={notes}&tenantID={tenantID}", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
  ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public Nullable<int> SetAppointmentService(string appointmentServiceid, string appointmentid, string serviceTypeID, string serviceID
          , string userName, string notes, string tenantID)
        {
            try
            {
                if (string.IsNullOrEmpty(appointmentid) || string.IsNullOrEmpty(serviceTypeID) || string.IsNullOrEmpty(serviceID) || string.IsNullOrEmpty(userName))
                {
                    return null;
                }
                else
                {
                    return Repository.SetAppointmentService(GetNullableTypes.GetInt(appointmentServiceid), GetNullableTypes.GetInt(appointmentid), GetNullableTypes.GetInt(serviceTypeID),
                  GetNullableTypes.GetInt(serviceID), null, userName, notes, GetNullableTypes.GetInt(tenantID));
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }

        [WebInvoke(UriTemplate = "/DeleteAppointmentService?appointmentserviceid={appointmentserviceid}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public Nullable<int> DeleteAppointmentService(string appointmentServiceID)
        {
            try
            {
                if (string.IsNullOrEmpty(appointmentServiceID))
                {
                    return null;
                }
                else
                {
                    return Repository.DeleteAppointmentService(GetNullableTypes.GetInt(appointmentServiceID), null, null);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }

        [WebInvoke(UriTemplate = "/GetService?tenantID={tenantID}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
      ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public List<GetService_Result> GetService(string tenantID)
        {
            try
            {
                return Repository.GetService(null, GetNullableTypes.GetInt(tenantID)).ToList();
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }

        [WebInvoke(UriTemplate = "/GetServiceType?serviceID={serviceID}&tenantID={tenantID}", Method = "GET", BodyStyle = WebMessageBodyStyle.WrappedRequest,
    ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public List<GetServiceType_Result> GetServiceType(string serviceID, string tenantID)
        {
            try
            {
                return Repository.GetServiceType(null, GetNullableTypes.GetInt(serviceID), GetNullableTypes.GetInt(tenantID)).ToList();
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
        }

    }
}
