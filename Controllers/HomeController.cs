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
    //[homeCheck]
    [doForAll]
    public class HomeController : Controller
    {
       
        public async Task <ActionResult> page(string first, string second)
        {
           
            pageSectionVM responsemodel = new pageSectionVM();
            getURLVM model = new getURLVM();
            
            model.lang = Session["lan"] == null ? @System.Configuration.ConfigurationManager.AppSettings["lan"] : Session["lan"].ToString();
            model.url = (first + "/" + second).Trim('/');
            responsemodel = await methods.PostData(model, responsemodel, "/getURL","" ); //Request.Cookies["clientToken"].Value  فقط برای گرین

            //if (Request.Cookies[responsemodel.sectionLayoutID.ToString()] == null)
            //{
            //    getsectionLayoutVM layoutresponse = new getsectionLayoutVM();
            //    sectionLayoutVM layoutinput = new sectionLayoutVM();
            //    layoutinput.menuTitle = "";
            //    layoutinput.sectionLayoutID = responsemodel.sectionLayoutID;
            //    layoutresponse = await methods.PostData(layoutinput, layoutresponse, "/getPageLayout", Request.Cookies["clientToken"].Value);
            //}
            ViewBag.layoutModel = responsemodel.layoutModel;
            ViewBag.title = responsemodel.title;
            ViewBag.image = responsemodel.image;
            ViewBag.layout = responsemodel.layoutModel.title+".cshtml";
            ViewBag.metaTitle = responsemodel.metatitle;
            
            return View(responsemodel);
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
        public async  Task<ActionResult> setCode(doSignIn mdl)
        {
            string result = "";
            mdl.phone = "100";
            mdl.userType = "0";
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(mdl, responsemodel, "/Verify", "");
            if (responsemodel.status == 200)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(responsemodel.message + ":" + mdl.phone);
                string tkn = System.Convert.ToBase64String(plainTextBytes);
                Response.Cookies["clientToken"].Value = tkn;
                return RedirectToAction("");
            }
            else
            {
                TempData["error"] = 1;
                return RedirectToAction("login");
            }
           

        }
    }
}