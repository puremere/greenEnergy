using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenEnergy.Classes
{
    public static class dynamicMethods
    {
        public static int getBaseFlowID(string userType)
        {
            // health
            int formbase = 5;
            if (userType == "2")
            {
                formbase = 7;
            }

            // tipax 
            //int formbase = 1;
            //if (userType == "2")
            //{
            //    formbase = 1;
            //}
            return formbase;
        }
    }
}