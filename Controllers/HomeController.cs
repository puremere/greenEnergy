using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
                string lang = Session["lan"] == null ? @System.Configuration.ConfigurationManager.AppSettings["lan"] : Session["lan"].ToString();
                if (first == "de")
                    lang = "de";
                if (first == "fa")
                    lang = "fa";
                if (first == "en" || string.IsNullOrEmpty(first))
                    lang = "/";
                Session["lan"] = lang;
                ViewBag.lang = lang == "/" ? "En" : lang;
                model.lang = lang == "/" ? "en" : lang; 
                model.slug = (first + "/" + second ).Trim('/');
                model.slug = !string.IsNullOrEmpty(third) ? model.slug + "/" + third : model.slug;
                responsemodel = await methods.PostData(model, responsemodel, "/getURL", ""); //Request.Cookies["clientToken"].Value  فقط برای گرین
                if (Request.Cookies["adminToken"] != null)
                {
                    sectionVM inputModel = new sectionVM();
                    inputModel.sectinoID =  new Guid();
                    inputModel.contentParent = responsemodel.Contents.First().conentID;
                    contentListVM outputModel = new contentListVM();
                    outputModel = await methods.PostData(inputModel, outputModel, "/getContent", Request.Cookies["adminToken"].Value);
                    responsemodel.contentListVM = outputModel;


                    categoryPageVM catTypeResponsemodel = new categoryPageVM();
                    catTypeResponsemodel = await methods.PostData(new nullclass(), catTypeResponsemodel, "/getCategoryList", Request.Cookies["adminToken"].Value);
                    responsemodel.catTypeList = catTypeResponsemodel;
                    tagPageVM tagTypeResponsemodel = new tagPageVM();
                    tagTypeResponsemodel = await methods.PostData(new nullclass(), tagTypeResponsemodel, "/getTagList", Request.Cookies["adminToken"].Value);
                    responsemodel.tagTypeList = tagTypeResponsemodel;
                    layoutPageVM layoutResponsemodel = new layoutPageVM();
                    layoutResponsemodel = await methods.PostData(new nullclass(), layoutResponsemodel, "/getLayout", Request.Cookies["adminToken"].Value);
                    responsemodel.layoutList = layoutResponsemodel;


                }

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
                ViewBag.slug = model.slug;
                //doctorListCycleView,go*a.reload*app/clientDashboard_putvar*formType*3;
                //go*a.reload*app/clientDashboard_putvar*formType*3

                return View(responsemodel);
            }
            catch (Exception e)
            {
                string message = e.InnerException != null ? e.InnerException.Message : e.Message;
                return Content(message);
            }
        }
        

        public async Task<ActionResult> addSubContent(string contentID)
        {
            sectionVM model = new sectionVM();
            model.contentParent = !string.IsNullOrEmpty(contentID) ? new Guid(contentID) : new Guid();
            contentListVM responsemodel = new contentListVM();
            responsemodel = await methods.PostData(model, responsemodel, "/getSubHTML", Request.Cookies["adminToken"].Value);
            string partialaddress = "/Views/Shared/" + @System.Configuration.ConfigurationManager.AppSettings["name"] + "/Layouts/_subContent.cshtml";
           
            //return Content("jhjh");
            return PartialView(partialaddress, responsemodel);
        }
        public async Task<ActionResult> getTypeCatList()
        {
            categoryPageVM responsemodel = new categoryPageVM();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getCategoryList", Request.Cookies["adminToken"].Value);

            return PartialView("_TypeCatList.cshtml",responsemodel);
        }

        public ActionResult getTypeTagList()
        {
            return PartialView();
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


        [AllowAnonymous]
        public ActionResult GetMonifest()
        {
            return File(Server.MapPath("~/site.webmanifest"), "text/webmanifest");
        }
        public ActionResult GetRobot()
        {
            return File(Server.MapPath("~/robots.txt"), "text");
        }
        public ActionResult GetSitemap()
        {
            return File(Server.MapPath("~/sitemap.xml"), "text");
        }
        public ActionResult GetApp()
        {
            // return File(Server.MapPath("~/Files/app.apk"),"apk");
            string fileName = "pals.apk";
            string path = Server.MapPath("~/Files/") + fileName;
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
       



        public ActionResult code(string phone, string error)
        {
            ViewBag.phone = phone;
            ViewBag.error = error;
            return View();
        }





        [HttpPost]
        public async Task<ActionResult> setCode(string phone, string code)
        {
            string baseServer = "https://test.remkali.com/api/app/setFormData";
            string result = "";
            ViewModel.pals.formVM data = new ViewModel.pals.formVM();
            List<ViewModel.pals.formVM> datalist = new List<ViewModel.pals.formVM>();
            data.formItemID = "4";
            data.key = "code";
            data.value = code;
            data.formItemTypeCode = "3";
            data.operat = "";
            data.relatedFormItemID = "";
            data.formID = "6";
            datalist.Add(data);



            string form = JsonConvert.SerializeObject(datalist);


            Dictionary<string, string> datadic = new Dictionary<string, string>();
            datadic.Add("phone", phone);
            ViewModel.pals.payload payload = new ViewModel.pals.payload();
            payload.form = form;
            payload.slug = "app/setCode";
            payload.data = datadic;
            ViewModel.pals.serverResponse response = new ViewModel.pals.serverResponse();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseServer);
                client.DefaultRequestHeaders.Add("Authorization", "Basic ");
                string content = JsonConvert.SerializeObject(payload);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var rsp = await client.PostAsync("", byteContent).ConfigureAwait(false);
                string final = await rsp.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ViewModel.pals.serverResponse>(final);
            }
            if (response.result.actions.Count == 2)
            {
                Session["userToken"] = "1";
                return RedirectToAction("factor", new { type = TempData["type"].ToString(), item = TempData["item"].ToString() });
            }
            else
            {
                return RedirectToAction("code", new { phone = phone, error = "1" });
            }





        }

        [HttpPost]
        public ActionResult getCode(string phone)
        {
            string baseServer = "https://test.remkali.com/api/app/setFormData";
            string result = "";
            ViewModel.pals.formVM  data = new ViewModel.pals.formVM();
            List<ViewModel.pals.formVM> datalist = new List<ViewModel.pals.formVM>();
            data.formItemID = "2";
            data.key = "phone";
            data.value = phone;
            data.formItemTypeCode = "3";
            data.operat = "";
            data.relatedFormItemID = "";
            data.formID = "0";
            datalist.Add(data);
            string form = JsonConvert.SerializeObject(datalist);
            using (WebClient client = new WebClient())
            {
                var collection = new NameValueCollection();
                collection.Add("slug", "app/verify");
                collection.Add("form", form);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // .NET 4.5
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // .NET 4.0
                byte[] response = client.UploadValues(baseServer, collection);
                result = System.Text.Encoding.UTF8.GetString(response);
            }
            ViewModel.pals.serverResponse resp = JsonConvert.DeserializeObject< ViewModel.pals.serverResponse> (result);

            return RedirectToAction("code", new { phone = phone });
        }


        public ActionResult factor(string item, string type)
        {
            ViewBag.item = item;
            ViewBag.type = type;
            if (type == "1")
            {
                ViewBag.price = "1000000";
                ViewBag.afzoode = "90000";
                ViewBag.total = "1090000";
            }
            else if (type == "3")
            {
                ViewBag.price = "2000000";
                ViewBag.afzoode = "180000";
                ViewBag.total = "2180000";
            }
            else if (type == "6")
            {
                ViewBag.price = "3000000";
                ViewBag.afzoode = "2700000";
                ViewBag.total = "3270000";
            }

            return View();
        }
        public ActionResult verify()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult dashboard()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult newService()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

      
    }



}