using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenEnergy.ViewModel
{
    public class paymentVM
    {
        public int status { get; set; }
        public string to { get; set; }
        public string url { get; set; }
        public string payment { get; set; }
    }
    public class callVM
    {
        public string callUserID { get; set; }
        public string token { get; set; }
        public string api { get; set; }
    }
    public class appViewModel
    {
        public string data { get; set; }
    }

    public class appmainVM : appViewModel
    {

    }
               
    public class flowSelectedVM
    {
        public int flowID { get; set; }
        public int count { get; set; }
    }
    public class pureDataVM
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class appResponse
    {
        public int code { get; set; }
        public resultResponse result { get; set; }
    }

    public class resultResponse
    {
        
        public List<actionResonse> actions { get; set; }
    }

    public class actionResonse
    {
        public string type { get; set; }
        public string to { get; set; }
        public string depth { get; set; }
        public string text { get; set; }
        public string varName { get; set; }
        public string value { get; set; }
        public int startDelay { get; set; }
        public int orientation = 0;
        public List<actionResonse> actions = new List<actionResonse>();


    }
    public class getListResponceVM
    {
        public List<pureDataVM> lst { get; set; }

    }

    public class getListVM
    {
        public string form { get; set; }
        public string initdata { get; set; }
        public string slug { get; set; }
    }

    public class getOrderListapp
    {

    }
    

    public class recycleDataMapVM
    {
        public string viewID { get; set; }
        public string actionID { get; set; }
        public string dataProperty { get; set; }
        public string viewProperty { get; set; }

    }

    public class recycleItemsVM
    {
        public string patternId { get; set; }
        public string backColor { get; set; }
        public string color { get; set; }
        public detailList data { get; set; }
    }

    public class detailList
    {
        public List<detailValue> list { get; set; }
    }

    public class detailValue
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class styleVM
    {
        public string background_image  { get; set; }
        public string background { get; set; }
        public string border_size { get; set; }
        public string border_color { get; set; }
        public string border_radius { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string padding { get; set; }
        public string margin { get; set; }
        public string box_shadow { get; set; }
      
    }
    public class marginVM
    {
        public int top { get; set; }
        public int bottom { get; set; }
        public int lead { get; set; }
        public int trail { get; set; }
    }



    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Dic
    {
        public string cBackground { get; set; }
        public string cPrimary { get; set; }
        public string cTextBody { get; set; }
        public string cTextBodyLight { get; set; }
        public string cBackgorundTextView { get; set; }
        public string cReverse { get; set; }
        public string c { get; set; }
        public string cBackgroundInner { get; set; }
        public string cGray { get; set; }
        public string cGreen { get; set; }
        public string cGrayLight { get; set; }
        public string cRed { get; set; }
        public string cTabNormalItem { get; set; }
        public string cTabSelectedItem { get; set; }
        public string cNavBarColor { get; set; }
    }

    public class Lang
    {
        public int code { get; set; }
        public int version { get; set; }
        public int direction { get; set; }
    }

    public class Page
    {
        public string startPage { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
    }

    public class Result
    {
        public string baseURL { get; set; }
        public string socketURL { get; set; }
        public string endPoint { get; set; }
        public string startPage { get; set; }
        public Lang lang { get; set; }
        public Theme theme { get; set; }
        public TabBar tabBar { get; set; }
        public Dictionary<string, string> data { get; set; }
    }

    public class streamModel
    {
        public int code { get; set; }
        public callVM result { get; set; }
    }
    public class splash
    {
        public int code { get; set; }
        public Result result { get; set; }
       
    }

    public class TabBar
    {
        public List<Page> pages { get; set; }
    }

    public class Theme
    {
        public int code { get; set; }
        public int version { get; set; }
        public int statusBarStyle { get; set; }
        public Dic dic { get; set; }
    }

}