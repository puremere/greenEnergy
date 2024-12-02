using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenEnergy.ViewModel.pals
{
    public class pals
    {
    }
    public class formVM
    {
        public string key { get; set; }
        public string formItemTypeCode { get; set; }
        public string formID { get; set; }
        public string operat { get; set; }
        public string formItemID { get; set; }
        public string value { get; set; }
        public string relatedFormItemID { get; set; }

    }
    
    public class serverResponse
    {
        public int code { get; set; }
        public Result result { get; set; }
    }

    public class Result
    {
        public List<Action> actions { get; set; }
    }
    public class payload
    {
        public string slug { get; set; }
        public string form { get; set; }
        public Dictionary<string, string> data { get; set; }
    }
}