using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace greenEnergy.Classes
{
    public static class dynamicMethods
    {
        public static int getBaseFlowID(string userType)
        {
            // tailor
            int formbase = 983073566;
            // health
            //int formbase = 5;
            //if (userType == "2")
            //{
            //    formbase = 7;
            //}

            //tipax
            //int formbase = 1;
            //if (userType == "2")
            //{
            //    formbase = 1;
            //}
            return formbase;
        }

        public static bool IsValidPhone(string Phone)
        {
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                var r = new Regex(@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$");
                return r.IsMatch(Phone);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}