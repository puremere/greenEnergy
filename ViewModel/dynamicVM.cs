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


    public class clientOrderListButton : parent
    {
        public string acceptedTabBotton_colorsrt { get; set; }
        public string pendingTabBotton_colorsrt { get; set; }

        


    }
    public class clientorderListPending: parent
    {
        public string projectName_valueTextsrt { get; set; }
        public string orderDate_valueTextsrt { get; set; }
        public string processName_valueTextsrt { get; set; }
        public string historyButton_cycleActionsrt { get; set; }
        public string acceptOrderButton_cycleActionsrt { get; set; }
        
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
        public List<serventChartVM> list { get; set; }
        
    }
    public class formOptionObject:parent
    {
        public List<orderOptionVM> lst { get; set; }
        
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