using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonLibrary
{
    public class Constants
    {
        public const string DateFormat = "dd/MM/yyyy";

        public const string DateTimeFormat = "dd/MM/yyyy hh:mm:ss";

        public enum EmployeeType
        {
            Admin = 1
        }

        public enum AppointmentStatus
        {
            Pending = 1,
            Cancelled = 2,
            Approved = 3,
            Invoiced = 4
        }

        public enum AccountTypes
        {
            Appointment = 1,
            Expense = 2,
            Purchase = 3,
            CashInHand = 4,
            StartingBalance = 5
        }


        public enum ExpenseType
        {
            WaterTanker = 1,
            ElectricBill = 2,
            WaterBottles = 3,
            Tea = 4,
            Sweeper = 5,
            InternalWork = 6,
            ProductPurchasing = 7,
            OtherExpenses = 8
        }

        public static CultureInfo GetCultureInfo(Culture cltr, bool isCurrencyRequired)
        {
            CultureInfo result = null;
            if (cltr == null)
                result = CultureInfo.InvariantCulture;

            switch (cltr)
            {
                case Culture.US:
                    result = new CultureInfo("en-US");
                    result.NumberFormat.CurrencySymbol = "USD ";
                    result.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
                    break;
                case Culture.FR:
                    result = new CultureInfo("fr-FR");
                    result.NumberFormat.CurrencySymbol = "EUR";
                    result.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                    break;
            }
            if (!isCurrencyRequired)
                result.NumberFormat.CurrencySymbol = "";
            return result;
        }

        public enum Culture
        {
            US,
            UK,
            UAE,
            FR
        }
    }

    public static class GetNullableTypes
    {
        public static Nullable<int> GetInt(string StringValues)
        {
            if (StringValues != "")
            {
                return Convert.ToInt32(StringValues);
            }

            else
            {
                return null;
            }
        }


        public static Nullable<double> GetDouble(string StringValues)
        {
            if (StringValues != "")
            {
                return Convert.ToDouble(StringValues);
            }

            else
            {
                return null;
            }
        }


        public static Nullable<int> GetInt(string StringValues, bool avoidZero)
        {
            if (StringValues != "")
            {
                if (StringValues.Equals("0") && avoidZero)
                    return null;
                else
                    return Convert.ToInt32(StringValues);
            }

            else
            {
                return null;
            }
        }

        public static int GetIntValue(string StringValues)
        {
            if (StringValues != "")
            {
                return Convert.ToInt32(StringValues);
            }

            else
            {
                return 0;
            }
        }

        public static Nullable<decimal> GetDecimal(string StringValues, string culture)
        {
            if (StringValues != "")
            {
                try
                {
                    return Convert.ToDecimal(StringValues, new CultureInfo(culture));
                }
                catch (FormatException e)
                {
                    return Convert.ToDecimal(StringValues.Trim().Replace(" ", "").Replace(",", "."));
                }
            }

            else
            {
                return null;
            }
        }

        public static Nullable<decimal> GetDecimal(string StringValues)
        {
            if (StringValues != "")
            {
                try
                {
                    return Convert.ToDecimal(StringValues);
                }
                catch (FormatException e)
                {
                    return Convert.ToDecimal(StringValues.Trim().Replace(" ", "").Replace(",", "."));
                }

            }

            else
            {
                return null;
            }
        }

        public static decimal GetDecimalValue(string StringValues)
        {
            if (StringValues != "")
            {
                try
                {
                    return Convert.ToDecimal(StringValues);
                }
                catch (FormatException e)
                {
                    return Convert.ToDecimal(StringValues.Trim().Replace(" ", "").Replace(",", "."));
                }

            }

            else
            {
                return 0;
            }
        }

        public static string GetDecimal(Nullable<decimal> val)
        {
            if (val != null || val.HasValue)
            {
                return Math.Round(val.Value, 2).ToString();
            }

            else
            {
                return "";
            }
        }

        public static string GetDecimal(Nullable<decimal> val, int precision)
        {
            if (val != null || val.HasValue)
            {
                return Math.Round(val.Value, precision).ToString();
            }

            else
            {
                return "";
            }
        }

        public static Nullable<DateTime> GetDateTime(string date, string format)
        {
            try
            {
                if (date != "")
                {
                    try
                    {
                        IFormatProvider culture = null;
                        if (format == "MM/dd/yyyy")
                            culture = new System.Globalization.CultureInfo("en-US", true);
                        else
                            culture = new System.Globalization.CultureInfo("fr-FR", true);
                        return Convert.ToDateTime(date, culture);
                    }

                    catch
                    {
                        return DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
                    }
                }

                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetNullString(string date)
        {
            if (date != "")
            {



                return date;



            }

            else
            {
                return null;
            }
        }

        public static string GetComboNullString(string date)
        {
            if (date != "" && date != "Select...")
            {



                return date;



            }

            else
            {
                return null;
            }
        }

        public static string GetEditableValue(Object Value)
        {
            return Value != null ? Value.ToString() : "";
        }

        public static string GetEditableDateValue(Nullable<DateTime> Value, string dateFormat)
        {
            if (Value != null)
            {
                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
                return Convert.ToDateTime(Value, culture).ToString(dateFormat);
            }
            return "";
        }

        public static string GetDateValue(object Value, string dateFormat)
        {
            if (Value != null)
            {
                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
                return Convert.ToDateTime(Value, culture).ToString(dateFormat);
            }
            return "";
        }


        public static string GetEditableDateValue(string Value, string dateFormat)
        {
            if (Value != null && Value != "")
            {
                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
                // return Convert.ToDateTime(Value, culture).ToString(dateFormat);
                return Convert.ToDateTime(Value).ToString(dateFormat);
            }
            return "";
        }

        internal static string GetBool(bool? val)
        {
            if (val.HasValue)
            {
                return val.Value ? "Yes" : "No";
            }
            else
                return "";
        }

        internal static string GetInt(int? val, bool avoidZero)
        {
            if (val.HasValue)
            {
                if (val.Value == 0 && avoidZero)
                    return string.Empty;
                return val.Value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetTime(string time)
        {
            DateTime date = Convert.ToDateTime(time);
            return date.ToString("hh:mm tt");
        }
    }

    public class Globalization
    {
        public static string GetGlobalizedNumber(Constants.Culture culture, bool isCurrencyRequired, int? value)
        {
            if (value == null || !value.HasValue)
                return "";
            CultureInfo cultureInfo = Constants.GetCultureInfo(culture, isCurrencyRequired);
            if (cultureInfo == null)
                cultureInfo = CultureInfo.InvariantCulture;
            string result = string.Empty;
            result = value.Value.ToString("C", cultureInfo);
            return result.Replace(".00", "");
        }

        public static string GetGlobalizedNumber(Constants.Culture culture, bool isCurrencyRequired, double? value, int round)
        {
            if (value == null || !value.HasValue)
                return "";
            CultureInfo cultureInfo = Constants.GetCultureInfo(culture, isCurrencyRequired);
            if (cultureInfo == null)
                cultureInfo = CultureInfo.InvariantCulture;
            string result = string.Empty;
            result = Math.Round(value.Value, round).ToString("C", cultureInfo);
            string delimeter = "";
            if (culture == Constants.Culture.FR)
                delimeter = ",";
            else if (culture == Constants.Culture.US)
                delimeter = ".";
            int index = result.IndexOf(delimeter);
            if (index != -1 && index + round + 1 < result.Length)
            {
                result = result.Substring(0, index + round + 1);
                if (result.Contains("("))
                    result += ")";
            }
            return result;
        }


        public static string GetGlobalizedNumber(Constants.Culture culture, bool isCurrencyRequired, decimal? value, bool roundOff)
        {
            if (value == null || !value.HasValue)
                return "";
            if (roundOff)
                value = Math.Round(value.Value);
            CultureInfo cultureInfo = Constants.GetCultureInfo(culture, isCurrencyRequired);
            if (cultureInfo == null)
                cultureInfo = CultureInfo.InvariantCulture;
            string result = string.Empty;
            result = value.Value.ToString("C", cultureInfo);
            if (roundOff && culture == Constants.Culture.US)
            {
                result = result.Remove(result.IndexOf("."));
                if (result.StartsWith("(") && !result.EndsWith(")"))
                    result += ")";
            }
            if (roundOff && culture == Constants.Culture.FR)
                result = result.Remove(result.IndexOf(","));
            //if (roundOff)
            //    result =Math.Round(decimal.Parse(result, (IFormatProvider)cultureInfo)).ToString();
            return result;
        }

        public static string GetGlobalizedNumber(Constants.Culture culture, bool isCurrencyRequired, double? value)
        {
            if (value == null || !value.HasValue)
                return "";
            CultureInfo cultureInfo = Constants.GetCultureInfo(culture, isCurrencyRequired);
            if (cultureInfo == null)
                cultureInfo = CultureInfo.InvariantCulture;
            string result = string.Empty;
            result = value.Value.ToString("C", cultureInfo);
            return result;
        }

        public static string GetGlobalizedNumber(Constants.Culture culture, bool isCurrencyRequired, decimal? value)
        {
            if (value == null || !value.HasValue)
                return "";
            CultureInfo cultureInfo = Constants.GetCultureInfo(culture, isCurrencyRequired);
            if (cultureInfo == null)
                cultureInfo = CultureInfo.InvariantCulture;
            string result = string.Empty;
            result = Math.Abs(value.Value).ToString("C", cultureInfo);
            return (value.Value < 0 ? "-" : "") + result;
        }


        public static string GetGlobalizedNumber(Constants.Culture culture, bool isCurrencyRequired, decimal? value, int round)
        {
            if (value == null || !value.HasValue)
                return "";
            CultureInfo cultureInfo = Constants.GetCultureInfo(culture, isCurrencyRequired);
            if (cultureInfo == null)
                cultureInfo = CultureInfo.InvariantCulture;
            string result = string.Empty;
            result = Math.Round(value.Value, round).ToString("C", cultureInfo);
            string delimeter = "";
            if (culture == Constants.Culture.FR)
                delimeter = ",";
            else if (culture == Constants.Culture.US)
                delimeter = ".";
            int index = result.IndexOf(delimeter);
            if (index != -1 && index + round + 1 < result.Length)
            {
                result = result.Substring(0, index + round + 1);

                if (result.EndsWith(delimeter))
                    result = result.Remove(result.Length - 1);
            }
            if (result.StartsWith("(") && !result.EndsWith(")"))
                result += ")";
            return result;
        }


        public static string GetGlobalizedNumber(Constants.Culture culture, bool isCurrencyRequired, DateTime? value)
        {
            if (value == null || !value.HasValue)
                return "";
            CultureInfo cultureInfo = Constants.GetCultureInfo(culture, isCurrencyRequired);
            if (cultureInfo == null)
                cultureInfo = CultureInfo.InvariantCulture;
            string result = string.Empty;
            result = value.Value.ToString("d", cultureInfo);
            return result;
        }

        public static object GetNumber(Constants.Culture culture, bool isCurrencyRequired, string number)
        {
            if (number.Equals(string.Empty))
                return null;
            CultureInfo cultureInfo = Constants.GetCultureInfo(culture, isCurrencyRequired);

            if (cultureInfo == null)
                cultureInfo = CultureInfo.InvariantCulture;
            return double.Parse(number, NumberStyles.Any, cultureInfo);
        }

        public static DateTime GetDate(Constants.Culture culture, string date)
        {
            CultureInfo cultureInfo = Constants.GetCultureInfo(culture, false);

            if (cultureInfo == null)
                cultureInfo = CultureInfo.InvariantCulture;
            return DateTime.Parse(date, cultureInfo);
        }
    }
}
