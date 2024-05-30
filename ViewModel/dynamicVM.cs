using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenEnergy.ViewModel
{

    public class parent
    {
        public string name { get; set; }
    }
    public class mainCycle : parent
    {
        public string stackLable1_text { get; set; }
        public string stackLable2_text { get; set; }
        public Guid orderID { get; set; }
        public List<actionResonse> actions { get; set; }
    }

   public class productDetailApp : parent
    {
        public string pertTextTitle_valueText { get; set; }
        public string pertTextDescription_valueText { get; set; }
    }

    public class itemParent
    {
        public string name { get; set; }
        public List<parent> items { get; set; }
    }
    public class itemOption
    {
        public string name { get; set; }
        public List<orderOptionVM> oplist { get; set; }
    }

    public class viewVM
    {
        public List<itemParent> chunkList { get; set; }
        public List<itemOption> opItems { get; set; }
    }

    public class stackPoseVM
    {
        public string viewID { get; set; }
        public double weight { get; set; }
    }




    /// managerChart
    /// 

    public class managerChartmain : parent
    {
        public string putvarnextweek_value { get; set; }
        public string currentWeekLable_text { get; set; }
        public string putVarPrevious_value { get; set; }    

        public string s7lvalue_text { get; set; }
        public string s6lvalue_text { get; set; }
        public string s5lvalue_text { get; set; }
        public string s4lvalue_text { get; set; }
        public string s3lvalue_text { get; set; }
        public string s2lvalue_text { get; set; }
        public string s1lvalue_text { get; set; }

    }


    public class formSearchChartManager : parent
    {
        public Guid key { get; set; }
        public Guid Value { get; set; }
    }


    public class splashTab
    {
        public string startPage { get; set; }
        public string title  { get; set; }
        public string icon { get; set; }
    }

    public class splashMain
    {
        public string startPage { get; set; }
        public List<splashTab> tabs { get; set; }
    }




    

}