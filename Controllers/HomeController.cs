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
       
        public async Task <ActionResult> page(string first, string second,string third)
        {
            try
            {
                
                pageSectionVM responsemodel = new pageSectionVM();
                getURLVM model = new getURLVM();
                string lang = Session["lang"] == null ? @System.Configuration.ConfigurationManager.AppSettings["lan"] : Session["lang"].ToString();
                if (first == "de")
                    lang = "de";
                if (first == "fa")
                    lang = "fa";
                if (first == "en" || string.IsNullOrEmpty(first))
                    lang = "/";
                Session["lan"] = lang;
                ViewBag.lang = lang;
                model.lang = lang == "/" ? "en" : lang; 
                model.slug = (first + "/" + second ).Trim('/');
                model.slug = !string.IsNullOrEmpty(third) ? model.slug + "/" + third : model.slug;
                responsemodel = await methods.PostData(model, responsemodel, "/getURL", ""); //Request.Cookies["clientToken"].Value  فقط برای گرین

                //if (Request.Cookies[responsemodel.sectionLayoutID.ToString()] == null)
                //{
                //    getsectionLayoutVM layoutresponse = new getsectionLayoutVM();
                //    sectionLayoutVM layoutinput = new sectionLayoutVM();
                //    layoutinput.menuTitle = "";
                //    layoutinput.sectionLayoutID = responsemodel.sectionLayoutID;
                //    layoutresponse = await methods.PostData(layoutinput, layoutresponse, "/getPageLayout","");
                //}


                ViewBag.layoutModel = responsemodel.layoutModel;
                ViewBag.title = responsemodel.title;
                ViewBag.image = responsemodel.image;
                ViewBag.layout = responsemodel.layoutModel.title + ".cshtml";
                ViewBag.metaTitle = responsemodel.metatitle;
                //doctorListCycleView,go*a.reload*app/clientDashboard_putvar*formType*3;
                //go*a.reload*app/clientDashboard_putvar*formType*3

                return View(responsemodel);
            }
            catch (Exception e)
            {

                return Content("");
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public void changeLang(string lang)
        {
            Session["lang"] = lang.Replace("/","");
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