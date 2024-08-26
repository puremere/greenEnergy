using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenEnergy.ViewModel
{

    public class parent
    {
        public string name { get; set; }
        public List<actionResonse> actions { get; set; }
    }
    public class mainDictionry: parent
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    /// <summary>
    /// health
    /// </summary>
    /// 
    public class userRelationList : parent
    {
        public string accountItemImageView_srcsrt { get; set; }
        public string accountItemImageLabel_textsrt { get; set; }
        public Guid? partnerID { get; set; }

    }
    public class userProfileList : parent
    {
        public string userFullname_valueTextsrt { get; set; }
        public string status_valueTextsrt { get; set; }
        public Guid? newOrderID { get; set; }

    }
    public class mainStreamVM : parent
    {
        
        public Guid newOrderID { get; set; }
        public string orderName { get; set; }
        public string newOrderStatusCode { get; set; }
        public string newOrderStatusTitle { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime terminationDate { get; set; }

    }

    public class flowHealth : parent
    {
        public int flowForm { get; set; }
    }


    public class flowDetailAll : parent
    {
       public  Dictionary<string, string> allData = new Dictionary<string, string>();
    }

    /// <summary>
    /// tailor
    /// </summary>
    /// 

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
        public string historyButton_visibilitysrt { get; set; }

        public string rejectOrderButton_cycleActionsrt { get; set; }
        public string rejectOrderButton_visibilitysrt { get; set; }

        public string acceptOrderButton_cycleActionsrt { get; set; }
        public string acceptOrderButton_visibilitysrt { get; set; }

        public string setFlowFormButton_cycleActionsrt { get; set; }
        public string setFlowFormButton_visibilitysrt { get; set; }

        public string productRegistration_cycleActionsrt { get; set; }
        public string productRegistration_visibilitysrt { get; set; }

        public string costRegistration_cycleActionsrt { get; set; }
        public string costRegistration_visibilitysrt { get; set; }


    }
    public class profileVM : parent
    {
        public string profileNameLabel_textsrt { get; set; }
    }
    public class setNewFlowForm : parent
    {
        public string flowForm { get; set; }
    }
    public class acceptFlowByClient : parent
    {
        
        public string putVarAcceptFlow_valuesrt { get; set; }
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
    public class showChartAllVM : parent
    {
        public List<chartList> allChart { get; set; }

    }
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
        public Dictionary<string, string> data { set; get; }
        public Dictionary<string, string> input { set; get; }
        
    }

    public class splashMain
    {
        public string startPage { get; set; }
        public List<splashTab> tabs { get; set; }
    }




    

}