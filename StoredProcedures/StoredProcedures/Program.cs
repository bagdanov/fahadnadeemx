using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Net;
using System.Text;
using System.Data.Entity;
using SalonLibrary;

namespace StoredProcedures
{
    class Program
    {
        static void Main(string[] args)
        {
             //GetCustomer();
            // SetCustomer();
            //DeleteCustomer();
            //GetAppointment();
            //SetAppointment();
            //DeleteAppointment();
            //GetAppointmentService();
            //SetAppointmentService();
            //DeleteAppointmentService();
            //GetEmployee();
            //SetEmployee();
            //DeleteEmployee();
            //GetEmployeeType();
            //SetEmployeeType();
            //DeleteEmployeeType();
            //GetInvoice();
            //SetInvoice();
            DeleteInvoice();
            //GetService();
            //SetService();
            //DeleteService();
            //GetServiceType();
            //SetServiceType();
            //DeleteServiceType();
            Console.WriteLine("\n\n  Enter any Key to exit ");
            Console.ReadLine();
        }

        #region Customer
        public static void GetCustomer()
        {
            var result = SalonLibrary.Repository.GetCustomer(1);
        }

        public static void SetCustomer()
        {
            int customerID = 2;
            string firstName = "Anna";
            string lastName = "Faris";
            DateTime dateOfBirth = new DateTime(1989, 10, 19);
            string phoneNumber = "1_12349584536";
            string alternatePhoneNumber = null;
            string emailAddress = "anna@gmail.com";
            string address = "Holywood";
            string city = "California";
            string userName = "Jonas";
            string notes = "bcdefg";

            var result = SalonLibrary.Repository.SetCustomer(customerID, firstName, lastName, dateOfBirth, phoneNumber,
            alternatePhoneNumber, emailAddress, address, city, userName, notes);
            Console.WriteLine("\n User Data Inserted Successfully");
        }

        public static void DeleteCustomer()
        {
            var result = SalonLibrary.Repository.DeleteCustomer(1, "Jonas");
            Console.WriteLine("\n\n User Deleted Successfully");
        }
        #endregion

        #region Appointment
        public static void GetAppointment()
        {
            var result = SalonLibrary.Repository.GetAppointment(1);
        }

        public static void SetAppointment()
        {
            int appointmentID = 1;
            DateTime appointmentDateTime = new DateTime(2019, 8, 9, 16, 5, 7); // Constants.DateFormat =;
            int customerID = 2;
            string userName = "Jonas";
            string notes = "Appointment booked for august 2019";
            var result = SalonLibrary.Repository.SetAppointment(appointmentID, appointmentDateTime, customerID, userName, notes); ;
            Console.WriteLine("\n User Data Inserted Successfully");
        }

        public static void DeleteAppointment()
        {
            var result = SalonLibrary.Repository.DeleteAppointment(2, "John");
            Console.WriteLine("\n\n User Deleted Successfully");
        }
        #endregion

        #region AppointmentService
        public static void GetAppointmentService()
        {
            var result = SalonLibrary.Repository.GetAppointmentService(1,1);
        }

        public static void SetAppointmentService()
        {
            int appointmentServiceID = 1;
            int appointmentID = 1;
            int serviceTypeID = 2;
            int servicID = 1;
            int employeeID = 1;
            string userName = "Anne";
            string notes = "She needs some good products";
            var result = SalonLibrary.Repository.SetAppointmentService(null, appointmentID, serviceTypeID, servicID, employeeID,
            userName, notes);
            Console.WriteLine("\n User Data Inserted Successfully");
        }

        public static void DeleteAppointmentService()
        {
            var result = SalonLibrary.Repository.DeleteAppointmentService(2, "John");
            Console.WriteLine("\n\n User Deleted Successfully");
        }
        #endregion

        #region Employee
        public static void GetEmployee()
        {
            var result = SalonLibrary.Repository.GetEmployee(1);
        }

        public static void SetEmployee()
        {
            int employeeID = 2;
            string fullName = "SmithJim";
            string phoneNumber = "2584536";
            string alternatePhoneNumber = null;
            DateTime dateOfBirth = new DateTime(1994, 10, 19);
            string cNIC = null;
            string emailAddress = "smith@gmail.com";
            string address = "1233";
            int employeeTypeID = 1;
            string userName = "Faiza";
            string notes = "Employee  junior";
            var result = SalonLibrary.Repository.SetEmployee(employeeID, fullName, phoneNumber, alternatePhoneNumber, dateOfBirth, cNIC,
            emailAddress, address, employeeTypeID, userName, notes);
            Console.WriteLine("\n User Data Inserted Successfully");
        }

        public static void DeleteEmployee()
        {
            var result = SalonLibrary.Repository.DeleteEmployee(1, "John");
            Console.WriteLine("\n\n User Deleted Successfully");
        }
        #endregion

        #region EmployeeType
        public static void GetEmployeeType()
        {
            var result = SalonLibrary.Repository.GetEmployeeType(1,1);
        }

        public static void SetEmployeeType()
        {
            int employeeTypeID = 3;
            string name = "Hair Consultant and Cut Expert";
            string description = "Expert Hair Consultant and Hair Expert";
            string userName = "Faiza";
            string notes = "The best of all consultants and experts";
            var result = SalonLibrary.Repository.SetEmployeeType(employeeTypeID, name, description, userName, notes);
            Console.WriteLine("\n User Data Inserted Successfully");
        }

        public static void DeleteEmployeeType()
        {
            var result = SalonLibrary.Repository.DeleteEmployeeType(4, "John");
            Console.WriteLine("\n\n User Deleted Successfully");
        }
        #endregion

        #region Invoice
        public static void GetInvoice()
        {
            var result = Repository.GetInvoice(1);
        }

        public static void SetInvoice()
        {
            int invoiceID = 2;
            DateTime date = DateTime.Now;
            decimal totalCost = 1202;
            decimal additionalCost = 300;
            string paymetMode = "card";
            int customerID = 3;
            int appointmentID = 2;
            string userName = "Jimmy";
            string notes = "200rs remaining";
            var result = Repository.SetInvoice(invoiceID, date, totalCost, additionalCost, paymetMode, customerID,
            appointmentID, userName, notes);
            Console.WriteLine("\n User Data Inserted Successfully");
        }

        public static void DeleteInvoice()
        {
            var result = SalonLibrary.Repository.DeleteInvoice(4, "Timmy");
            Console.WriteLine("\n\n User Deleted Successfully");
        }
        #endregion

        #region Service
        public static void GetService()
        {
            var result = SalonLibrary.Repository.GetService(1);
        }

        public static void SetService()
        {
            int serviceID = 1;
            string name = "Makeup";
            string userName = "FaizaNasir";
            string notes = "defghijkl";
            var result = SalonLibrary.Repository.SetService(null, name, userName, notes);
            Console.WriteLine("\n Data Inserted Successfully");
        }

        public static void DeleteService()
        {
            var result = SalonLibrary.Repository.DeleteService(4, "John");
            Console.WriteLine("\n\n User Deleted Successfully");
        }
        #endregion

        #region ServiceType
        public static void GetServiceType()
        {
            var result = SalonLibrary.Repository.GetServiceType(1,1);
        }

        public static void SetServiceType()
        {
            int serviceTypeID = 1;
            int serviceID = 1;
            string name = "Steps Cut";
            string cost = "2000";
            decimal timeRequired = 12342;
            string userName = "Faiza";
            string notes = "defghijkl";
            var result = SalonLibrary.Repository.SetServiceType(serviceTypeID, serviceID, name, cost, timeRequired, notes, userName);
            Console.WriteLine("\n Data Inserted Successfully");
        }

        public static void DeleteServiceType()
        {
            var result = SalonLibrary.Repository.DeleteServiceType(4, "John");
            Console.WriteLine("\n\n User Deleted Successfully");
        }
        #endregion
    }
}
