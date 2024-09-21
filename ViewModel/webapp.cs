using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenEnergy.ViewModel.webapp
{
    
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Action
    {
        public string type { get; set; }
        public string to { get; set; }
    }

    public class AllForm
    {
        public List<FormItemDetailList> formItemDetailList { get; set; }
        public int formID { get; set; }
        public string formTitle { get; set; }
        public object formImage { get; set; }
        public object formHieght { get; set; }
        public object formWidth { get; set; }
        public object zaribWidth { get; set; }
        public object zaribHeight { get; set; }
    }

    public class Content
    {
        public string type { get; set; }
        public string viewID { get; set; }
        public string text { get; set; }
        public string color { get; set; }
        public string font { get; set; }
        public int size { get; set; }
        public Margin margin { get; set; }
        public int? height { get; set; }
        public int? showTitle { get; set; }
        public Form form { get; set; }
        public string backColor { get; set; }
        public int? cornerRadius { get; set; }
        public List<Action> actions { get; set; }
    }

    public class Form
    {
        public List<AllForm> allForm { get; set; }
        public string orderID { get; set; }
        public string processID { get; set; }
    }

    public class FormItemDetailList
    {
        public List<object> orderOptions { get; set; }
        public object stringImageCollection { get; set; }
        public int formItemID { get; set; }
        public object itemValue { get; set; }
        public object groupNumber { get; set; }
        public object hiddenCheckBox { get; set; }
        public int isHidden { get; set; }
        public int priority { get; set; }
        public object relatedFormItemID { get; set; }
        public object operat { get; set; }
        public string itemName { get; set; }
        public object itemx { get; set; }
        public object itemy { get; set; }
        public object itemHeight { get; set; }
        public object itemlength { get; set; }
        public int pageNumber { get; set; }
        public string itemDesc { get; set; }
        public string itemPlaceholder { get; set; }
        public string itemtImage { get; set; }
        public object catchUrl { get; set; }
        public object isMultiple { get; set; }
        public object isRequired { get; set; }
        public string validationType { get; set; }
        public object otherFieldName { get; set; }
        public object referTo { get; set; }
        public double minNumber { get; set; }
        public double maxNumber { get; set; }
        public object regx { get; set; }
        public object mediaType { get; set; }
        public object collectionName { get; set; }
        public object UIName { get; set; }
        public string formItemTypeTitle { get; set; }
        public string formItemTypeCode { get; set; }
        public object optionSelected { get; set; }
        public object formItemDesingID { get; set; }
        public int formItemDesignNumber { get; set; }
        public string formItemTypeID { get; set; }
        public int formID { get; set; }
    }

    public class Margin
    {
        public int top { get; set; }
        public int bottom { get; set; }
        public int lead { get; set; }
        public int trail { get; set; }
    }

    public class Nav
    {
        public object sample { get; set; }
        public object leading { get; set; }
        public object trailing { get; set; }
    }

    public class webapp
    {
        public Nav nav { get; set; }
        public string viewID { get; set; }
        public View view { get; set; }
    }

    public class View
    {
        public string type { get; set; }
        public string viewID { get; set; }
        public int orientation { get; set; }
        public int scrollable { get; set; }
        public List<object> pose { get; set; }
        public List<Content> content { get; set; }
    }


}