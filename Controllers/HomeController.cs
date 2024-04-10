using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using greenEnergy.Classes;
using greenEnergy.ViewModel;
using Newtonsoft.Json;

namespace greenEnergy.Controllers
{
    [homeCheck]
    [doForAll]
    public class HomeController : Controller
    {
       
        public async Task <ActionResult> page(string first, string second)
        {
           
            pageSectionVM responsemodel = new pageSectionVM();
            getURLVM model = new getURLVM();
            
            model.lang = Session["lan"] == null ?  "En" : Session["lan"].ToString();
            model.url = (first + "/" + second).Trim('/');
            responsemodel = await methods.PostData(model, responsemodel, "/getURL", "");
            ViewBag.layout = responsemodel.layout;
            ViewBag.Title = responsemodel.title;
            

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public async  Task<ActionResult> setCode(string phone, string code)
        {
            string result = "";
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/Verify", "");
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(responsemodel.message + ":" + phone);
            string tkn = System.Convert.ToBase64String(plainTextBytes);
            Response.Cookies["clientToken"].Value = tkn;
            return RedirectToAction("orders");

        }
    }
}