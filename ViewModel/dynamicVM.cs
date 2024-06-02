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
    public class mainDictionry: parent
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    

    public class managerFlowList_orderFlowCycle : parent
    {
        public string FlowID { get; set; }
        public string orderName_valueTextsrt { get; set; }
        public string isFinished { get; set; }
        public string isAccespted { get; set; }
        public string processName_valueTextsrt { get; set; }
        public string serventName_valueTextsrt { get; set; }
        public string flowStatus_valueTextsrt { get; set; }
        public string flowStatus_valueColorsrt { get; set; }

        public string flowIsAccepted_valueTextsrt { get; set; }
        public string flowIsAccepted_valueColorsrt { get; set; }


        public List<actionResonse> actions{ get; set; }
    }
    public class cycleStackView_orderListManagerVM : parent
    {
        
        public string orderStatus_valueTextsrt { get; set; }
        public string orderStatus_valueColorsrt { get; set; }
        public string projectName_orderListManager_valueTextsrt { get; set; }

        public string orderDate_orderListManager_valueTextsrt { get; set; }
        public DateTime orderDate_orderListManager_valueTextsrtdate { get; set; }
        public string historyButton_orderListManager_cycleActionsrt { get; set; }

        public string setFlow_orderListManager_cycleActionsrt { get; set; }
        public string setFlow_orderListManager_visibilitysrt { get; set; }


    }


    public class clientOrderListButton : parent
    {
        public string acceptedTabBotton_colorsrt { get; set; }
        public string pendingTabBotton_colorsrt { get; set; }

        


    }
    public class clientorderListAccepted : parent
    {
        public string flowID { get; set; }
        public string projectName_Accepted_valueTextsrt { get; set; }
        public string orderDate_Accepted_valueTextsrt { get; set; }
        public DateTime orderDate_valueText { get; set; }
        public string processName_Accepted_valueTextsrt { get; set; }
        public string historyButton_Accepted_cycleActionsrt { get; set; }
        public string showFormButton_Accepted_cycleActionsrt { get; set; }
       

        public List<actionResonse> actions { get; set; }

    }
    public class clientorderListPending: parent
    {
        public string flowID { get; set; }
        public string projectName_valueTextsrt { get; set; }
        public string orderDate_valueTextsrt { get; set; }
        public DateTime orderDate_valueText { get; set; }
        public string processName_valueTextsrt { get; set; }
        public string historyButton_cycleActionsrt { get; set; }
        public string acceptOrderButton_cycleActionsrt { get; set; }
        public string rejectOrderButton_cycleActionsrt { get; set; }
        

    }

    public class acceptFlowByClient : parent
    {
        public string putVarRejectFlow_valuesrt { get; set; }
        public string relaodAction_actionssrt { get; set; }
        
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

    public class showFormAllVM : parent
    {
        public List<formItemList> allForm { get; set; }

    }
   
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