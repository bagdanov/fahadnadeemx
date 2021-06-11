using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonLibrary
{
    public class Repository
    {
        #region Customer
        public static List<GetCustomer_Result> GetCustomer(Nullable<int> customerID, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetCustomer(customerID, null, clientID).ToList();
            }
        }

        public static List<GetCustomer_Result> GetCustomerByPhone(string phoneNumber, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetCustomer(null, phoneNumber, clientID).ToList();
            }
        }

        public static Nullable<int> SetCustomer(Nullable<int> customerID, string firstName, string lastName, Nullable<DateTime> dateOfBirth,
            string phoneNumber, string alternatePhoneNumber, string emailAddress, string password, string address, string city,
            string notes, string userName,  Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetCustomer(customerID, firstName, lastName, dateOfBirth, phoneNumber, alternatePhoneNumber,
                emailAddress, password, address, city, notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteCustomer(Nullable<int> customerID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteCustomer(customerID, userName).FirstOrDefault();
            }
        }
        #endregion

        #region Appointment
        public static List<GetAppointment_Result> GetAppointment(Nullable<int> appointmentID, Nullable<int> customerID, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetAppointment(appointmentID, customerID, null,null,null, clientID).ToList();
            }
        }

        public static Nullable<int> SetAppointment(Nullable<int> appointmentID,
            Nullable<DateTime> appointmentDateTime, int appointmentStatusID,
            Nullable<int> customerID, Nullable<DateTime> invoiceDateTime, Nullable<decimal> additionalCost, string paymentMode, 
            string notes, string userName, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetAppointment(appointmentID, appointmentDateTime, appointmentStatusID, customerID, invoiceDateTime,
                    additionalCost, paymentMode, notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteAppointment(Nullable<int> appointmentID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteAppointment(appointmentID, userName).FirstOrDefault();
            }
        }
        #endregion

        #region AppointmentService
        public static List<GetAppointmentService_Result> GetAppointmentService(Nullable<int> appointmentServiceID,
            Nullable<int> appointmentID, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetAppointmentService(appointmentServiceID, appointmentID, clientID).ToList();
            }
        }

        public static Nullable<int> SetAppointmentService(Nullable<int> appointmentServiceID, Nullable<int> appointmentID,
            Nullable<int> serviceTypeID, Nullable<int> serviceID, Nullable<int> employeeID, string notes, string userName, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetAppointmentService(appointmentServiceID, appointmentID, serviceTypeID, serviceID, employeeID,
                notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteAppointmentService(Nullable<int> appointmentServiceID, Nullable<int> appointmentID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteAppointmentService(appointmentServiceID, appointmentID, userName).FirstOrDefault();
            }
        }
        #endregion

        #region Employee
        public static List<GetEmployee_Result> GetEmployee(Nullable<int> employeeID, string emailAddress, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetEmployee(employeeID, emailAddress, clientID).ToList();
            }
        }

        public static Nullable<int> SetEmployee(Nullable<int> employeeID, string fullName, string phoneNumber,
            string alternatePhoneNumber, Nullable<DateTime> dateOfBirth, string cNIC, string emailAddress, string password,
            string address, Nullable<int> employeeTypeID, string notes, string userName, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetEmployee(employeeID, fullName, phoneNumber, alternatePhoneNumber, dateOfBirth, cNIC,
                emailAddress, password, address, employeeTypeID, notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteEmployee(Nullable<int> employeeID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteEmployee(employeeID, userName).FirstOrDefault();
            }
        }
        #endregion

        #region EmployeeType
        public static List<GetEmployeeType_Result> GetEmployeeType(Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetEmployeeType(clientID).ToList();
            }
        }

        public static Nullable<int> SetEmployeeType(Nullable<int> employeeTypeID, string name, string description, string notes,
            string userName, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetEmployeeType(employeeTypeID, name, description, notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteEmployeeType(Nullable<int> employeeTypeID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteEmployeeType(employeeTypeID, userName).FirstOrDefault();
            }

        }
        #endregion

        //#region Invoice
        //public static List<GetInvoice_Result> GetInvoice(Nullable<int> invoiceID)
        //{
        //    using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
        //    {
        //        return S.GetInvoice(invoiceID).ToList();
        //    }
        //}

        //public static Nullable<int> SetInvoice(Nullable<int> invoiceID, Nullable<DateTime> date, decimal totalCost, decimal additionalCost,
        //     string paymetMode, Nullable<int> customerID, Nullable<int> appointmentID, string notes, string userName)
        //{
        //    using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
        //    {
        //        return S.SetInvoice(invoiceID, date, totalCost, additionalCost, paymetMode, customerID,
        //        appointmentID, notes, userName).FirstOrDefault();
        //    }
        //}

        //public static Nullable<int> DeleteInvoice(Nullable<int> invoiceID, string userName)
        //{
        //    using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
        //    {
        //        return S.DeleteInvoice(invoiceID, userName).FirstOrDefault();
        //    }
        //}
        //#endregion

        #region Service
        public static List<GetService_Result> GetService(Nullable<int> serviceID, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetService(serviceID, clientID).ToList();
            }
        }

        public static Nullable<int> SetService(Nullable<int> serviceID, string name, string notes, string userName, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetService(serviceID, name, notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteService(Nullable<int> serviceID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteService(serviceID, userName).FirstOrDefault();
            }
        }
        #endregion

        #region ServiceType
        public static List<GetServiceType_Result> GetServiceType(Nullable<int> serviceTypeID, Nullable<int> serviceID, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetServiceType(serviceTypeID, serviceID, clientID).ToList();
            }
        }

        public static Nullable<int> SetServiceType(Nullable<int> serviceTypeID, Nullable<int> serviceID, string name,
             Nullable<decimal> cost, Nullable<decimal> timeRequired, string notes, string userName, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetServiceType(serviceTypeID, serviceID, name, cost, timeRequired, notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteServiceType(Nullable<int> serviceTypeID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteServiceType(serviceTypeID, userName).FirstOrDefault();
            }
        }
        #endregion

        #region Product
        public static List<GetProduct_Result> GetProduct(Nullable<int> productID, Nullable<int> productCategoryID, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetProduct(productID, productCategoryID, clientID).ToList();
            }
        }

        public static Nullable<int> SetProduct(Nullable<int> productID, Nullable<int> productCategoryID, string name,
            string notes, string userName, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetProduct(productID, productCategoryID, name, notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteProduct(Nullable<int> productID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteProduct(productID, userName).FirstOrDefault();
            }
        }
        #endregion

        #region ProductCategory
        public static List<GetProductCategory_Result> GetProductCategory(Nullable<int> productCategoryID, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetProductCategory(productCategoryID, clientID).ToList();
            }
        }

        public static Nullable<int> SetProductCategory(Nullable<int> productCategoryID, string name,
            string notes, string userName, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetProductCategory(productCategoryID, name, notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteProductCategory(Nullable<int> productCategoryID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteProductCategory(productCategoryID, userName).FirstOrDefault();
            }
        }
        #endregion

        #region Stock
        public static List<GetStock_Result> GetStock(Nullable<int> stockID, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetStock(stockID, clientID).ToList();
            }
        }

        public static Nullable<int> SetStock(Nullable<int> stockID, Nullable<DateTime> date, Nullable<int> productID, Nullable<int> productCategoryID, Nullable<decimal> quantity,
             Nullable<decimal> price, string notes, string userName, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetStock(stockID, date, productID, productCategoryID, quantity, price, notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteStock(Nullable<int> stockID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteStock(stockID, userName).FirstOrDefault();
            }
        }
        #endregion

        //#region ProductService
        //public static List<GetProductService_Result> GetProductService(Nullable<int> productServiceID)
        //{
        //    using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
        //    {
        //        return S.GetProductService(productServiceID).ToList();
        //    }
        //}

        //public static Nullable<int> SetProductService(Nullable<int> productServiceID, Nullable<int> serviceID, Nullable<int> serviceTypeID,
        //    Nullable<int> productCategoryID, Nullable<int> productID, decimal quantity, string notes, string userName)
        //{
        //    using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
        //    {
        //        return S.SetProductService(productServiceID, serviceID, serviceTypeID, productCategoryID, productID, quantity, notes, userName).FirstOrDefault();
        //    }
        //}

        //public static Nullable<int> DeleteProductService(Nullable<int> productServiceID, string userName)
        //{
        //    using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
        //    {
        //        return S.DeleteProductService(productServiceID, userName).FirstOrDefault();
        //    }
        //}
        //#endregion

        #region Expense
        public static List<GetExpense_Result> GetExpense(Nullable<int> expenseID, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetExpense(expenseID, clientID).ToList();
            }
        }

        public static Nullable<int> SetExpense(Nullable<int> expenseID, Nullable<int> expenseTypeID, string typeName, Nullable<DateTime> date, Nullable<decimal> amount,
            string notes, string userName, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetExpense(expenseID, expenseTypeID, typeName, date, amount, notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteExpense(Nullable<int> expenseID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteExpense(expenseID, userName).FirstOrDefault();
            }
        }
        #endregion

        #region Account
        public static List<GetAccount_Result> GetAccount(Nullable<DateTime> toDate, Nullable<DateTime> fromDate, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetAccount(toDate, fromDate,clientID).ToList();
            }
        }

        public static Nullable<int> SetAccount(Nullable<int> accountID, Nullable<int> objectID, Nullable<int> moduleID, Nullable<DateTime> date,
         string description, Nullable<decimal> debit, Nullable<decimal> credit, string notes, string userName, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetAccount(accountID, objectID, moduleID, date, description, debit, credit, notes, userName, clientID).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteAccount(Nullable<int> accountID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteAccount(accountID, userName).FirstOrDefault();
            }
        }
        #endregion

        #region Client
        public static List<GetClient_Result> GetClient(Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetClient(clientID).ToList();
            }
        }

        public static Nullable<int> SetClient(Nullable<int> clientID, string name, string address, string mobile, string telePhoneNumber,
            string email, string city, string country, Nullable<int> clientTypeID, string tagLine, string website, string nTN, string sNTN,
            string logo, string notes, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetClient(clientID, name, address, mobile, telePhoneNumber, email, city, country, clientTypeID,
                tagLine, website, nTN, sNTN, logo, notes, userName).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteClient(Nullable<int> clientID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteClient(clientID, userName).FirstOrDefault();
            }
        }
        #endregion

        #region ClientType
        public static List<GetClientType_Result> GetClientType(Nullable<int> clientTypeID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetClientType(clientTypeID).ToList();
            }
        }

        public static Nullable<int> SetClientType(Nullable<int> clientTypeID, string typeName, Nullable<decimal> charges, string packageName, string notes,
            string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.SetClientType(clientTypeID, typeName, charges, packageName, notes, userName).FirstOrDefault();
            }
        }

        public static Nullable<int> DeleteClientType(Nullable<int> clientTypeID, string userName)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.DeleteClientType(clientTypeID, userName).FirstOrDefault();
            }

        }
        #endregion

        #region Dashboard
        public static List<GetDashboardKPI_Result> GetDashboardKPI(Nullable<DateTime> FromDate, Nullable<DateTime> toDate, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetDashboardKPI(FromDate, toDate, clientID).ToList();
            }
        }
        public static List<GetMonthlySales_Result> GetMonthlySales(Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetMonthlySales(clientID).ToList();
            }
        }

        public static List<GetWeeklySales_Result> GetWeeklySales(Nullable<int> moduleID, Nullable<int> clientID)
        {
            using (SalonManagementSystemEntities S = new SalonManagementSystemEntities())
            {
                return S.GetWeeklySales(moduleID, clientID).ToList();
            }
        }

        #endregion


    }
}
