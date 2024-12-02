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
        public string varName { get; set; }
        public string value { get; set; }
    }

    public class Bottom2bottom
    {
        public string to { get; set; }
        public double constant { get; set; }
    }

    public class Content
    {
        public string type { get; set; }
        public string viewID { get; set; }
        public string src { get; set; }
        public int width { get; set; }
        public Margin margin { get; set; }
        public List<Action> actions { get; set; }
        public List<object> content { get; set; }
        public List<object> pose { get; set; }
        public string text { get; set; }
        public string color { get; set; }
        public string font { get; set; }
        public int size { get; set; }
        public string backColor { get; set; }
        public int cornerRadius { get; set; }
        public int height { get; set; }
        public int scaleType { get; set; }
        public int scrollable { get; set; }
        public int androidH { get; set; }
        public string alignment { get; set; }
        public int? visibility { get; set; }
        public int? orientation { get; set; }
        public int? androidW { get; set; }
        public int? direction { get; set; }
        public List<Pattern> patterns { get; set; }
        public List<object> items { get; set; }
        public string borderColor { get; set; }
    }

    public class DataMap
    {
        public string viewID { get; set; }
        public object actionID { get; set; }
        public string dataProperty { get; set; }
        public string viewProperty { get; set; }
    }

    public class Lead2lead
    {
        public string to { get; set; }
        public double constant { get; set; }
    }

    public class Leading
    {
        public string type { get; set; }
        public string viewID { get; set; }
        public int orientation { get; set; }
        public List<object> pose { get; set; }
        public List<Content> content { get; set; }
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
        public string image { get; set; }
        public Leading leading { get; set; }
        public Trailing trailing { get; set; }
    }

    public class Pattern
    {
        public string patternId { get; set; }
        public List<DataMap> dataMap { get; set; }
        public View view { get; set; }
    }

    public class Pose
    {
        public string viewID { get; set; }
        public double weight { get; set; }
        public Top2top top2top { get; set; }
        public Bottom2bottom bottom2bottom { get; set; }
        public Lead2lead lead2lead { get; set; }
        public Trail2trail trail2trail { get; set; }
        public Trail2lead trail2lead { get; set; }
        public bool centerX { get; set; }
        public bool centerY { get; set; }
    }

    public class webapp
    {
        public Nav nav { get; set; }
        public string viewID { get; set; }
        public View view { get; set; }
    }

    public class Top2top
    {
        public string to { get; set; }
        public double constant { get; set; }
    }

    public class Trail2lead
    {
        public string to { get; set; }
        public double constant { get; set; }
    }

    public class Trail2trail
    {
        public string to { get; set; }
        public double constant { get; set; }
    }

    public class Trailing
    {
        public string type { get; set; }
        public string viewID { get; set; }
        public List<object> pose { get; set; }
        public List<Content> content { get; set; }
    }

    public class View
    {
        public string type { get; set; }
        public string viewID { get; set; }
        public List<Content> content { get; set; }
        public List<Pose> pose { get; set; }
        public Margin margin { get; set; }
    }




}


