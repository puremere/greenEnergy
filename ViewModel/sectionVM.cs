using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace greenEnergy.ViewModel
{

   
    public class getChildContentWebVM
    {
       
    }
    public class aps
    {
        public string alert { get; set; }
    }
    public class apnPayload
    {
        public aps aps { get; set; }
        public string handle { get; set; }
        public string callUUID { get; set; }

    }
    public class getChildContentVM
    {
        public List<pageContentVM> list { get; set; }
        public Dictionary<string, string> newMeta { get; set; }
        public string  stackPose { get; set; }
        public string newPose { get; set; }
        public string  cycleMeta { get; set; }
    }



    public class elementListVM
    {
        public List<elementVM> elementList { get; set; }
        public sectionVM selectedSection { get; set; }
        public List<formVM> allForm { get; set; }
    }

    public class urldataVM
    {
        public string name { get; set; }
        public string formID { get; set; }
        public string flowFields { get; set; }
        public string formFields { get; set; }
        public List<int> resultFlow { get; set; }
    }
    public class elementVM
    {

        public Guid sectionID { get; set; }
        public Guid elementID { get; set; }
        public string formName { get; set; }
        public string formItemName { get; set; }
        public string name { get; set; }
        public string formFields { get; set; }
        public string flowFields { get; set; }
        public int isCycle { get; set; }
        public int? formID { get; set; }
        public int? formItemID { get; set; }
        public int isLinkToMain { get; set; }
        public string operat { get; set; }
    }
    public class metaListVM
    {
        public List<MetaVM> metaList { get; set; }
        public sectionVM selectedSection { get; set; }
    }


    public class MetaVM
    {
        public string Name { get; set; }
        public Guid sectionID { get; set; }
        public Guid metaID { get; set; }
        public string Content { get; set; }
    }
    public class getlayoutDataVM
    {
        public Guid layoutDataID { get; set; }
        public Guid? parentID { get; set; }
        public string urlTitle { get; set; }
        public string dataType { get; set; }
        public string url { get; set; }
        public int priority { get; set; }
        public string image { get; set; }
        public List<getlayoutDataVM> childes { get; set; }
    }
    public class getlayoutPartVM
    {
        public string title { get; set; }
        public Guid layoutPartID { get; set; }
        public List<getlayoutDataVM> LayoutDatas { get; set; }
    }
    public class getsectionLayoutVM
    {
        public Guid sectionLayoutID { get; set; }
        public string menuTitle { get; set; }
        public string title { get; set; }
        public ICollection<getlayoutPartVM> LayoutParts { get; set; }

        public List<layoutDynamics> dynamicList { get; set; }
    }

    public class layoutDynamics
    {
        public string header { get; set; }
        public string title { get; set; }
        public string value { get; set; }
    }


    public class layoutPartDataPageVM
    {
        public List<layoutpartDataVM> datalist { get; set; }
        public List<typeVM> typelist { get; set; }
        public layoutpartVM layoutpart { get; set; }
        public List<string> partDetailList { get; set; }
    }


    public class setSectionLayoutVM
    {
        public Guid sectionLayoutID { get; set; }
        public Guid languageID { get; set; }
        public Guid layoutID { get; set; }
        public string menuTitle { get; set; }

        public List<string> layoutPartID { get; set; }
    }
    public class layoutpartDataVM
    {

        public Guid layoutDataID { get; set; }

        public Guid layoutPartID { get; set; }
        public Guid? sectionTypeID { get; set; }
        public Guid? parentID { get; set; }
        public int priority { get; set; }
        
        public string fromHome { get; set; }
        public string pageurl { get; set; }
        public string title { get; set; }
        public string dataType { get; set; }
        public string urlTitle { get; set; }

        public string parentName { get; set; }

        public string url { get; set; }
        public string image { get; set; }
        public string typeTitle { get; set; }
        public int typeCount { get; set; }
    }


    public class layoutPartSetVM
    {
        public Guid layoutPartID { get; set; }
        public Guid languageID { get; set; }
        public Guid sectionLayoutID { get; set; }
        
        public string title { get; set; }
        public string typeName { get; set; }
    }
    public class layoutPartPageVM
    {
        public List<layoutpartVM> partlist { get; set; }
        public List<languagVM> langauageList { get; set; }
        public List<layoutpartVM> allPart { get; set; }
        public List<string> partNames { get; set; }
        public Guid sectionLayoutID { get; set; }

    }

    public class layoutpartVM
    {
        public Guid layoutPartID { get; set; }
        public string title { get; set; }
        public string typeName { get; set; }
        public Guid languageID { get; set; }
    }
    public class layoutPageVM
    {
        public List<languagVM> langauageList { get; set; }
        public List<layoutVM> layoutLists { get; set; }
        public List<layoutObjectVM> layoutObjectLists { get; set; }
        public List<layoutpartVM> allPart { get; set; }

    }
    public class layoutVM
    {
        public Guid layoutID { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string partName { get; set; }

        public List<layoutpartVM> partlist { get; set; }
    }

    public class layoutObjectVM
    {
        public Guid sectionLayoutID { get; set; }
        public string languageName { get; set; }
        public string menuTitle { get; set; }

        public string title { get; set; }
        public string partName { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public List<string> partnames { get; set; }
        public List<Guid> partID { get; set; }


    }

    public class setPoseVM
    {
        public Guid contentID { get; set; }
        public Guid poseID { get; set; }
        public string isCheckbox { get; set; }
        public string title { get; set; }
        public string title2 { get; set; }
        public string to { get; set; }
        public double constant { get; set; }
    }
    public class setDataVM
    {
        public Guid contentID { get; set; }
        public Guid dataID { get; set; }
        public string url { get; set; }
        public int priority { get; set; }
        public string title { get; set; }
        [AllowHtml]
        public List<string> title2 { get; set; }
        public string description { get; set; }
        public string description2 { get; set; }
        public string mediaURL { get; set; }
        public string viedoIframe { get; set; }
        

    }

    public class removeContentPageVM
    {
        public Guid contentID { get; set; }
        public Guid sectionID { get; set; }
        public Guid parentID { get; set; }
        public string  url { get; set; }


    }
    public class setContentVM
    {
        public string url { get; set; }
        public string fromHome { get; set; }
        public Guid contentID { get; set; }
        public Guid mirrorID { get; set; }
        
        public Guid sectionID { get; set; }
        
        public Guid contentParent { get; set; }
        public Guid newParent { get; set; }
        public List<string> formID { get; set; }
        public Guid htmlID { get; set; }
        public int priority { get; set; }
        public List<string> chosenForCycle { get; set; }
        public string title { get; set; }
        public string buttonText { get; set; }
        public string stackWeight { get; set; }
        public string selfUsed { get; set; }
        
        public string description { get; set; }
        public string parentCategory { get; set; }
        public Guid typeID { get; set; }
    }
    public class contentVM
    {
        public Guid contentID { get; set; }

        public string?  formID { get; set; }
        public Guid typeID { get; set; }
        public Guid htmlID { get; set; }
        public string htmlType { get; set; }
        public string stackWeight { get; set; }
        public string cycleFields { get; set; }
        public string typeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string parentCategory { get; set; }
        public string fields { get; set; }
        public int priority { get; set; }
        public int multilayer { get; set; }
        public string categories { get; set; }

        public string htmlName { get; set; }
        public string htmlFeilds { get; set; }
        public string htmlFormLink { get; set; }
        public string image { get; set; }
    }
    public class HTMLVM
    {
        public Guid htmlID { get; set; }
        public string parentID { get; set; }
        public string htmlName { get; set; }
        public string image { get; set; }
        public string partialView { get; set; }
    }
    
    public class contentListVM
    {
        public List<HTMLVM> htmlList { get; set; }
        public List<formVM> formList { get; set; }
        public List<typeVM> typeList { get; set; }
        public List<contentVM> contentList { get; set; }
        public List<contentVM> allContents { get; set; }
        public sectionVM selectedSection { get; set; }
        public contentVM parentSelected { get; set; }
    }

    public class dataListVM
    {
        public List<string> imageList { get; set; }
        public List<dataVM> dataList { get; set; }
        public contentVM selectedContent { get; set; }


    }

    public class poseListVM
    {
        public List<poseVM> poseList { get; set; }
        public List<contentVM> allElements { get; set; }
        public contentVM selectedContent { get; set; }


    }

    public class poseVM
    {
        public Guid poseID { get; set; }
        public Guid? contentID { get; set; }
        public string title { get; set; }
        public string title2 { get; set; }

    }

    public class dataVM
    {
        public Guid dataID { get; set; }
        public string URL { get; set; }
        public int priority { get; set; }
        public DateTime date { get; set; }
        public string writer { get; set; }
        public string title { get; set; }
        public string title2 { get; set; }
        public string description { get; set; }
        public string description2 { get; set; }
        public string mediaURL { get; set; }
        public string viedoIframe { get; set; }

    }
    public class sectionLayoutVM
    {
        public Guid? sectionLayoutID { get; set; }
        public string menuTitle { get; set; }
    }

    public class pageListVM
    {
        public List<string> imageList { get; set; }
        public List<sectionVM> sectionList { get; set; }
        public List<sectionLayoutVM> layoutList { get; set; }
        public List<languagVM> langauageList { get; set; }
        public List<categoryVM> categoryList { get; set; }
        public List<secTagVM> tagList { get; set; }

        public typeVM selectedType { get; set; }
    }

    public class dashbaordVM
    {
        public List<typeVM> typelist { get; set; }
    }

    public class LanguagePageVM
    {
        public List<languagVM> list { get; set; }
    }
    public class languagVM
    {
        public Guid languageID { get; set; }
        public string title { get; set; }
    }

    public class tagPageVM
    {
        public List<secTagVM> list { get; set; }
        public List<typeVM> typelist { get; set; }
    }
    public class categoryPageVM
    {
        public List<categoryVM> list { get; set; }
        public List<typeVM> typelist { get; set; }
    }
    public class categoryVM
    {
        public Guid categoryID { get; set; }
        public Guid sectionTypeID { get; set; }
        public string sectionTypeName { get; set; }
        public string title { get; set; }
        public string fromHome { get; set; }
        public string url { get; set; }
    }
    public class secTagVM
    {
        public Guid tagID { get; set; }
        public Guid sectionTypeID { get; set; }
        public string sectionTypeName { get; set; }
        public string title { get; set; }
        public string fromHome { get; set; }
        public string url { get; set; }
    }
    public class typePageVM
    {
        public List<typeVM> list { get; set; }
    }
    public class typeVM
    {
        public Guid typeID { get; set; }
        public string title { get; set; }
        public string fromHome { get; set; }
        public string url { get; set; }
    }



    public class sectionTypeVM
    {

    }
    public class AdminDashbaordNodeVM
    {

        public string productsNum { get; set; }
        public string nodeNumRows { get; set; }
        public string userNumRows { get; set; }
        public string ordersNum { get; set; }
    }
    public class BaseViewModel
    {
        public String username { get; set; }
        public String pass { get; set; }
        public String name { get; set; }
    }
    public class sectionVM
    {

        public string url { get; set; }
        public Guid? sectinoID { get; set; }
        public Guid sectinoTypeID { get; set; }
        public Guid languateID { get; set; }
        public Guid? categoryID { get; set; }
        public List<Guid>? secTagID { get; set; }
        public Guid? sectionLayoutID { get; set; }
        public List<secTagVM> tags { get; set; }
        public string title { get; set; }
        public string buttonText { get; set; }

        public string metaTitle { get; set; }
        public string description { get; set; }
        public string writer { get; set; }
        public DateTime date { get; set; }
        public string image { get; set; }
        public string typeName { get; set; }
        public string categoryName { get; set; }
        public string languageName { get; set; }


        public Guid contentParent { get; set; }
        public Guid layoutID { get; set; }

        public Guid mirrorID { get; set; }
        public string isCopy { get; set; }
    }


    public class pageContentVM
    {
        public List<dataVM> dataList { get; set; }
        public List<poseVM> poseList { get; set; }
        public List<sectionVM> childList { get; set; }
        public List<pageContentVM> contentChild { get; set; }

        public int index { get; set; }
        public int multilayer { get; set; }
        public string partialName { get; set; } // از روی اچ تی ام میاد
        public string stackWeight { get; set; } // از روی اچ تی ام میاد
        public string title { get; set; } // از روی اچ تی ام میاد
        public string cycleFields { get; set; }
        public string appMeta { get; set; } // از روی اچ تی ام میاد
        public string poseMeta { get; set; } // از روی اچ تی ام میاد
        public string appType { get; set; } // از روی اچ تی ام میاد
        public string description { get; set; } // از روی اچ تی ام میاد
        public string htmlFields { get; set; } // از روی اچ تی ام میاد
        public int priority { get; set; }
        public int useParentSection { get; set; }
        public Guid? typeID { get; set; } // از روی اچ تی ام میاد
        public Guid conentID { get; set; } // از روی اچ تی ام میاد
        public Guid? parentID { get; set; } // از روی اچ تی ام میاد
        public Guid? sectionID { get; set; } // از روی اچ تی ام میاد
        public string?  formID { get; set; } // از روی اچ تی ام میاد
    }


    public class partialSectionVM
    {
        public List<pageContentVM> list { get; set; }
        public pageContentVM itemModel { get; set; }
    }

    public class appPageSectionVM
    {
        
        public int code { get; set; }
        public JAResult result { get; set; }
    }
    public class JAResult
    {
        public Dictionary<string,object> data { get; set; }
        public string page { get; set; }
        public Dictionary<string, string> initData { get; set; }
    }
    public class JAPage
    {
        public JANav nav { get; set; }
        public JAViewVM view { get; set; }
    }
    
    public class JAViewVM
    {
        public string viewID { get; set; }
        public string type { get; set; }
        public int height { get; set; }
        public int   width { get; set; }

       
    }

    public class JAStackViewVM : JAViewVM
    {
        public int orientation { get; set; }
        public string backColor { get; set; }
        public int cornerRadius { get; set; }
        public List<JAViewVM> content { get; set; }
    }
    public class JAPerTextViewVM: JAViewVM
    {
        public string keyText { get; set; }
        public string valueText { get; set; }
        public string keyColor { get; set; }
        public string valueColor { get; set; }
        
    }

    public class JALableVM : JAViewVM
    {
        public string backColor { get; set; }
        public string color { get; set; }
        public string text { get; set; }
        public string val { get; set; }

    }
    public class JANav
    { 

    }

    public class JAContent<TIn>
    {
        public JAContent() { }
        public JAContent(TIn inpart)
        {
            Input = inpart;
        }
        public TIn Input { get; set; }

        public string title { get; set; }
    }
    public class pageSectionVM
    {
       
        public Guid sectionID { get; set; }
        public string url { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
       
        public string metatitle { get; set; }
        public string image { get; set; }
        public string writer { get; set; }
       
        public List<pageContentVM> Contents { get; set; }
        public  List<MetaVM> Metas { get; set; }
        public List<secTagVM> tags { get; set; }
        public Guid? sectionLayoutID { get; set; }

        public getsectionLayoutVM layoutModel { get; set; }
        public contentListVM contentListVM { get; set; }
        public categoryPageVM catTypeList { get; set; }
        public tagPageVM tagTypeList { get; set; }
        public layoutPageVM layoutList { get; set; }









    }

    public class responseModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public string data { get; set; }
    }
    public class nullclass
    {

    }
    public class doSignIn
    {
        public string code { get; set; }
        public string phone { get; set; }
        public string userType { get; set; }
    }
    public class getURLVM
    {
        public string firstID { get; set; }
        public string userID { get; set; }
        public string slug { get; set; }
        public string lang { get; set; }
        public string form { get; set; }
        public Dictionary<string,string> initdata { get; set; }
        public Dictionary<string, string> data { set; get; }
    }

    public class initDataVM
    {
        public int flowID { get; set; }
        public Guid process { get; set; }
    }
}