using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenEnergy.ViewModel
{

    public class layoutPartDataPageVM
    {
        public List<layoutpartDataVM> datalist { get; set; }
        public List<typeVM> typelist { get; set; }
        public layoutpartVM layoutpart { get; set; }
    }

   
    public class setSectionLayoutVM
    {
        public Guid  languageID { get; set; }
        public Guid  layoutID { get; set; }
        public string menuTitle { get; set; }
        
        public List<string>  layoutPartID { get; set; }
    }
    public class layoutpartDataVM
    {
      
        public Guid layoutDataID { get; set; }
       
        public Guid layoutPartID { get; set; }
        public Guid? sectionTypeID { get; set; }
        public Guid? parentID { get; set; }
        public int priority { get; set; }
        public string title { get; set; }
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
        public string   title { get; set; }
        public string   typeName { get; set; }
    }
    public class layoutPartPageVM
    {
       public List<layoutpartVM>  partlist { get; set; }
        public List<languagVM> langauageList { get; set; }
      
        
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
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public List<string> partnames { get; set; }


    }
    public class setDataVM
    {
        public Guid contentID { get; set; }
        public Guid dataID { get; set; }
        public string title { get; set; }
        public string title2 { get; set; }
        public string description { get; set; }
        public string description2 { get; set; }
        public string mediaURL { get; set; }
        public string viedoIframe { get; set; }
    }

    public class setContentVM
    {
        public Guid contentID { get; set; }
        public Guid sectionID { get; set; }
        public Guid htmlID { get; set; }
        public int priority { get; set; }
        public string title { get; set; }
        public Guid typeID { get; set; }
    }
    public class contentVM
    {
        public Guid contentID { get; set; }


        public Guid typeID { get; set; }
        public Guid htmlID { get; set; }
        public string typeName { get; set; }
        public string title  { get; set; }

        public string htmlName { get; set; }
        public string image{ get; set; }
    }
    public class HTMLVM
    {
        public Guid htmlID { get; set; }
        public string htmlName { get; set; }
        public string image { get; set; }
        public string partialView { get; set; }
    }
    public class contentListVM
    {
        public List<HTMLVM> htmlList { get; set; }
        public List<typeVM> typeList { get; set; }
        public List<contentVM> contentList { get; set; }
        public sectionVM selectedSection { get; set; }
    }

    public class dataListVM
    {
        public List<dataVM> dataList { get; set; }
        public contentVM selectedContent { get; set; }
    }

    public class dataVM
    {
        public Guid dataID { get; set; }
        public string title { get; set; }
        public string title2 { get; set; }
        public string description { get; set; }
        public string description2 { get; set; }
        public string mediaURL { get; set; }
        public string viedoIframe { get; set; }
        
    }
    public class sectionLayoutVM
    {
        public Guid sectionLayoutID { get; set; }
        public string menuTitle { get; set; }
    }

    public class pageListVM
    {
        public List<sectionVM> sectionList { get; set; }
        public List<sectionLayoutVM> layoutList { get; set; }
        public List<languagVM> langauageList { get; set; }
        public List<categoryVM> categoryList { get; set; }

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
        public Guid  languageID { get; set; }
        public string  title { get; set; }
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
    }
    public class typePageVM
    {
        public List<typeVM> list { get; set; }
    }
    public class typeVM
    {
        public Guid typeID { get; set; }
        public string title { get; set; }
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
        public Guid sectinoID { get; set; }
        public Guid sectinoTypeID { get; set; }
        public Guid languateID { get; set; }
        public Guid categoryID { get; set; }
        public Guid sectionLayoutID { get; set; }
        public string title { get; set; }
        public string metaTitle { get; set; }
        public string description { get; set; }
        public string writer { get; set; }
        public string image { get; set; }
    }


    public class pageContentVM
    {
        public List<dataVM> dataList { get; set; }
        public string partialName { get; set; } // از روی اچ تی ام میاد
    }

    public class meta
    {
        public string key { get; set; }
        public string value { get; set; }
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
        public  List<meta> Metas { get; set; }
        public string layout { get; set; }

       






       
       
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
        public string url { get; set; }
        public string lang { get; set; }
    }
}