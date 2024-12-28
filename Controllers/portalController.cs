using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using greenEnergy.Classes;
using greenEnergy.ViewModel;
using greenEnergy.Model;
using Newtonsoft.Json;
using System.IO;
using greenEnergy.ViewModel;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;

namespace greenEnergy.Controllers
{
    [portalCheck]
    [doForAll]
    public class portalController : Controller
    {
        string baseServer = System.Configuration.ConfigurationManager.AppSettings["baseurl"];// "http://daynamic.jbar.app";//"https://localhost:44389/api/app";// "https://jbar.app/api/app"; // "https://localhost:44389/api/app";// 
        // GET: panel
        public ActionResult Login()
        {
            //Context dbcontext = new Context();
            //newOrderStatus status1 = new newOrderStatus()
            //{
            //    newOrderStatusID = Guid.NewGuid(),
            //    statusCode = "1",
            //    title = "در انتظار"
            //};
            //dbcontext.newOrderStatuses.Add(status1);
            //dbcontext.SaveChanges();
            //status1 = new newOrderStatus()
            //{
            //    newOrderStatusID = Guid.NewGuid(),
            //    statusCode = "2",
            //    title = "عملیاتی"
            //};
            //dbcontext.newOrderStatuses.Add(status1);
            //dbcontext.SaveChanges();
            //status1 = new newOrderStatus()
            //{
            //    newOrderStatusID = Guid.NewGuid(),
            //    statusCode = "3",
            //    title = "رد شده"
            //};
            //dbcontext.newOrderStatuses.Add(status1);
            //dbcontext.SaveChanges();
            //status1 = new newOrderStatus()
            //{
            //    newOrderStatusID = Guid.NewGuid(),
            //    statusCode = "4",
            //    title = "تمام شده"
            //};
            //dbcontext.newOrderStatuses.Add(status1);
            //dbcontext.SaveChanges();

            //Guid userid = new Guid("9f82f3e1-df02-46aa-86cb-7bdbd9887147");
            //formItemDesign ftd = new formItemDesign()
            //{
            //    formItemDesignID = Guid.NewGuid(),
            //    title = "چند انتخابی - اسلایدر",
            //    number = 1

            //};
            //dbcontext.formItemDesigns.Add(ftd);
            //dbcontext.SaveChanges();
            //formItemType frmt = new formItemType()
            //{
            //    formItemTypeID = Guid.NewGuid(),
            //    title = "آیتم آپلود",
            //    formItemTypeCode = "7",



            //};
            //dbcontext.formItemTypes.Add(frmt);
            //dbcontext.SaveChanges();
            //frmt = new formItemType()
            //{
            //    formItemTypeID = Guid.NewGuid(),
            //    title = "آیتم چند گزینه ای",
            //    formItemTypeCode = "1"

            //};
            //dbcontext.formItemTypes.Add(frmt);
            //dbcontext.SaveChanges();
            //frmt = new formItemType()
            //{
            //    formItemTypeID = Guid.NewGuid(),
            //    title = "آیتم انتخابی",
            //    formItemTypeCode = "6"

            //};
            //dbcontext.formItemTypes.Add(frmt);
            //dbcontext.SaveChanges();
            //frmt = new formItemType()
            //{
            //    formItemTypeID = Guid.NewGuid(),
            //    title = "آیتم تاریخ",
            //    formItemTypeCode = "5"

            //};
            //dbcontext.formItemTypes.Add(frmt);
            //dbcontext.SaveChanges();
            //frmt = new formItemType()
            //{
            //    formItemTypeID = Guid.NewGuid(),
            //    title = "آیتم موقعیت",
            //    formItemTypeCode = "8"

            //};
            //dbcontext.formItemTypes.Add(frmt);
            //dbcontext.SaveChanges();
            //frmt = new formItemType()
            //{
            //    formItemTypeID = Guid.NewGuid(),
            //    title = "آیتم متنی",
            //    formItemTypeCode = "3"

            //};
            //dbcontext.formItemTypes.Add(frmt);
            //frmt = new formItemType()
            //{
            //    formItemTypeID = Guid.NewGuid(),
            //    title = "آیتم متنی عکس دار",
            //    formItemTypeCode = "2"

            //};
            //dbcontext.formItemTypes.Add(frmt);
            //dbcontext.SaveChanges();


            //userWorkingStatus yd = new userWorkingStatus()
            //{
            //    title = "در حال اجرا",
            //    workingStatusID = Guid.NewGuid(),

            //};
            //dbcontext.userWorkingStatuses.Add(yd);
            //dbcontext.SaveChanges();
            //yd = new userWorkingStatus()
            //{
            //    title = "بدون اقدام",
            //    workingStatusID = Guid.NewGuid(),
            //};
            //dbcontext.userWorkingStatuses.Add(yd);
            //dbcontext.SaveChanges();
            //yd = new userWorkingStatus()
            //{
            //    title = "غیر عملیاتی",
            //    workingStatusID = Guid.NewGuid(),
            //};
            //dbcontext.userWorkingStatuses.Add(yd);
            //dbcontext.SaveChanges();



            //verifyStatus vs = new verifyStatus()
            //{
            //    title = "تایید نشده",
            //    verifyStatusID = Guid.NewGuid(),
            //    message = "لازم است برای احراز قویت اقدام نمایید",
            //    statusCode = "0"

            //};
            //dbcontext.verifyStatuses.Add(vs);
            //dbcontext.SaveChanges();

            //vs = new verifyStatus()
            //{
            //    title = "دردست بررسی",
            //    verifyStatusID = Guid.NewGuid(),
            //    message = "مدارک شما در دست بررسی می باشد",
            //    statusCode = "1"

            //};
            //dbcontext.verifyStatuses.Add(vs);
            //dbcontext.SaveChanges();

            //vs = new verifyStatus()
            //{
            //    title = "رد شده",
            //    verifyStatusID = Guid.NewGuid(),
            //    message = "به دلیل عدم ارائه مدارک کافی هویت شما احراز نشدهد است",
            //    statusCode = "2"

            //};
            //dbcontext.verifyStatuses.Add(vs);
            //dbcontext.SaveChanges();


            //vs = new verifyStatus()
            //{
            //    title = "تایید شده",
            //    verifyStatusID = Guid.NewGuid(),
            //    message = " هویت شما احراز شده است",
            //    statusCode = "3"

            //};
            //dbcontext.verifyStatuses.Add(vs);
            //dbcontext.SaveChanges();





            //dbcontext.SaveChanges();

            //namad formula = new namad()
            //{

            //    namadID = Guid.NewGuid(),
            //    value = "&#43;",
            //    title = "plus",
            //    userID = userid,

            //};
            //dbcontext.namads.Add(formula);
            //dbcontext.SaveChanges();
            //formula = new namad()
            //{

            //    namadID = Guid.NewGuid(),
            //    value = "&#8722;",
            //    title = "minus",
            //    userID = userid,
            //};
            //dbcontext.namads.Add(formula);
            //dbcontext.SaveChanges();

            //formula = new namad()
            //{

            //    namadID = Guid.NewGuid(),
            //    value = "&#215;",
            //    title = "multiple",
            //    userID = userid,
            //};
            //dbcontext.namads.Add(formula);
            //dbcontext.SaveChanges();
            //formula = new namad()
            //{

            //    namadID = Guid.NewGuid(),
            //    value = "&#8260;",
            //    title = "fraction",
            //    userID = userid,
            //};
            //dbcontext.namads.Add(formula);
            //dbcontext.SaveChanges();

            //formula = new namad()
            //{

            //    namadID = Guid.NewGuid(),
            //    value = "&#61;",
            //    title = "equal",
            //    userID = userid,
            //};
            //dbcontext.namads.Add(formula);
            //dbcontext.SaveChanges();

            return View();

        }
        public ActionResult Dashboard()
        {
            return View();
        }


        public async Task<ActionResult> setOrder()
        {

            panelSetOrder fmodel = new panelSetOrder();
            fmodel = await methods.PostData(new nullclass(), fmodel, "/setOrderAction", Request.Cookies["adminToken"].Value);
            return View(fmodel);
        }

        public PartialViewResult getCityPartail(string name, string ID)
        {

            string result = "";

            using (WebClient client = new WebClient())
            {
                var collection = new NameValueCollection();
                collection.Add("ID", ID);

                byte[] response = client.UploadValues(baseServer + "/getCity", collection);

                result = System.Text.Encoding.UTF8.GetString(response);

            }
            sendCityVM res = JsonConvert.DeserializeObject<sendCityVM>(result);
            panelCityVM model = new panelCityVM()
            {
                listname = name,
                cityList = res
            };

            return PartialView("/Views/Shared/panel/_cityPartial.cshtml", model);
        }

        public ActionResult getCity(string ID, string search)
        {
            string result = "";
            using (WebClient client = new WebClient())
            {
                var collection = new NameValueCollection();
                collection.Add("ID", ID);
                collection.Add("search", search);
                byte[] response = client.UploadValues(baseServer + "/getCity", collection);
                result = System.Text.Encoding.UTF8.GetString(response);
            }
            sendCityVM res = JsonConvert.DeserializeObject<sendCityVM>(result);
            if (ID == null && search == null)
            {
                return PartialView("/Views/Shared/_statePartial.cshtml", res);

            }
            else
            {
                return PartialView("/Views/Shared/_cityPartial.cshtml", res);

            }
        }
        public ActionResult Orders()
        {
            if (Request.Cookies["adminToken"] == null)
            {
                return RedirectToAction("Login");
            }
            string token = Request.Cookies["adminToken"].Value;
            string result = "";
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Set("Authorization", "Basic " + token);
                    var collection = new NameValueCollection();
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // .NET 4.5
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // .NET 4.0
                    byte[] response = client.UploadValues(baseServer + "/getOrderClient", collection);

                    result = System.Text.Encoding.UTF8.GetString(response);
                    getOrderVM model = JsonConvert.DeserializeObject<getOrderVM>(result);
                    return View(model);
                }
            }
            catch (Exception e)
            {

                HttpCookie nameCookie = Request.Cookies["adminToken"];
                nameCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(nameCookie);
                return RedirectToAction("Login");
            }

        }

        public async Task<ActionResult> OrderDetail(string ID)
        {
            if (Request.Cookies["adminToken"] == null)
            {
                return RedirectToAction("Login");
            }
            sendDetailVM mdl = new sendDetailVM();
            sendDetailVM responsemodel = new sendDetailVM();
            string token = Request.Cookies["adminToken"].Value;
            string result = "";
            try
            {
                if (TempData["er"] != null)
                    ViewBag.error = TempData["er"].ToString();


                mdl.orderID = ID;
                responsemodel = await methods.PostData(mdl, responsemodel, "/getOrderDetailClientAsync", Request.Cookies["adminToken"].Value);
                return View(responsemodel);

                //using (WebClient client = new WebClient())
                //{
                //    client.Headers.Set("Authorization", "Basic " + token);
                //    var collection = new NameValueCollection();
                //    collection.Add("orderID", ID);
                //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // .NET 4.5
                //    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // .NET 4.0
                //    byte[] response = client.UploadValues(baseServer + "/getOrderDetailClient", collection);

                //    result = System.Text.Encoding.UTF8.GetString(response);

                //    model.orderID = ID;

                //}
            }
            catch (Exception e)
            {


                HttpCookie nameCookie = Request.Cookies["adminToken"];
                nameCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(nameCookie);
                return RedirectToAction("Login");

            }
            return View(responsemodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setCode(doSignIn mdl)
        {

            responseModel responsemodel = new responseModel();
            mdl.userType = "1";
            responsemodel = await methods.PostData(mdl, responsemodel, "/Verify", "");

            if (responsemodel.status == 200)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(responsemodel.message + ":" + mdl.phone);
                string tkn = System.Convert.ToBase64String(plainTextBytes);
                Response.Cookies["adminToken"].Value = tkn;
                return RedirectToAction("form");
            }
            else
            {
                TempData["error"] = 1;
                return RedirectToAction("login");
            }


        }

        [HttpPost]
        public ActionResult getCode(string phone)
        {


            string result = "";

            using (WebClient client = new WebClient())
            {

                var collection = new NameValueCollection();
                collection.Add("phone", phone);
                collection.Add("userType", "0");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // .NET 4.5
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // .NET 4.0
                byte[] response = client.UploadValues(baseServer + "/register", collection);

                result = System.Text.Encoding.UTF8.GetString(response);
            }
            ViewBag.phone = phone;
            return View("Verify");
        }
        [HttpPost]
        public async Task<ActionResult> setOrder(setOrderVM model)
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            JObject responsemodel = new JObject();
            responsemodel = await methods.PostData(model, responsemodel, "/setOrder", Request.Cookies["adminToken"].Value);
            return RedirectToAction("Orders");
        }



        // process
        public async Task<ActionResult> Process()
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            processActionVM responsemodel = new processActionVM();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getProcess", Request.Cookies["adminToken"].Value);
            return View(responsemodel);
        }
        public async Task<ActionResult> setNewProcess(process model)
        {
            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/setProcess", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            return RedirectToAction("process");
        }

        // processForm


        public async Task<ActionResult> processForm(Guid processID)
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            processFormActionVM responsemodel = new processFormActionVM();
            process model = new process();
            model.processID = processID;
            responsemodel = await methods.PostData(model, responsemodel, "/getProcessForm", Request.Cookies["adminToken"].Value);
            responsemodel.process = model;
            return View(responsemodel);
        }
        [HttpPost]
        public async Task<ActionResult> setNewFormProcess(setNewFormProcessVM model)
        {

            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/setNewFormProcess", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;

            return RedirectToAction("processForm", new { processID = model.processID });
        }
        [HttpPost]
        public async Task<ActionResult> removeProcessForm(setNewFormProcessVM model)
        {

            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/removeProcessForm", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;


            return RedirectToAction("processForm", new { processID = model.processID });
        }


        // formItem

        public async Task<ActionResult> formItem(int formID)
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            formItemActionVM responsemodel = new formItemActionVM();
            form model = new form();
            model.formID = formID;
            responsemodel = await methods.PostData(model, responsemodel, "/getFormItem", Request.Cookies["adminToken"].Value);
            responsemodel.form = model;
            return View(responsemodel);
        }
        [HttpPost]
        public async Task<ActionResult> addFormItem(formItemVM model)
        {
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                if (file.ContentLength > 0)
                {
                    string fname = file.FileName;


                    file.SaveAs(Server.MapPath("~/Uploads/") + fname);
                    model.itemtImage = file.FileName;
                }

            }
            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/setFormItem", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;

            return RedirectToAction("formItem", new { formID = model.formID });
        }
        [HttpPost]
        public async Task<ActionResult> removeFormItem(formItemVM model)
        {

            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/removeFormItem", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {
                if (!string.IsNullOrEmpty(responsemodel.message))
                {
                    string fname = Path.Combine(Server.MapPath("Uploads"), responsemodel.message);
                    bool exists = System.IO.File.Exists(fname);
                    if (exists)
                        System.IO.File.Delete(fname);

                }
            }

            return RedirectToAction("formItem", new { formID = model.formID });
        }

        // processFormula
        [HttpPost]
        public async Task<ActionResult> processFormula(process model)
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            processFormulaActionVM responsemodel = new processFormulaActionVM();
            responsemodel = await methods.PostData(model, responsemodel, "/getProcessFormula", Request.Cookies["adminToken"].Value);
            responsemodel.process = model;
            return View(responsemodel);
        }
        [HttpPost]
        public async Task<ActionResult> addFormulaToProcess(processFormula model)
        {
            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/setProcessFormula", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            process pr = new process();
            pr.processID = model.proccessID;
            return RedirectToAction("processFormula", pr);
        }



        // formula
        public async Task<ActionResult> Formula(Guid processID)
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            process pr = new process();
            pr.processID = processID;
            formulaActionVM responsemodel = await methods.PostData(pr, new formulaActionVM(), "/getFormula", Request.Cookies["adminToken"].Value);
            responsemodel.process = pr;
            return View(responsemodel);
        }
        [HttpPost]
        public async Task<ActionResult> setNewFormula(formula model)
        {

            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/setFormula", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;


            return RedirectToAction("Formula", new { processID = model.processID });
        }


        //coding
        public async Task<ActionResult> Coding()
        {

            //Context dbcontext = new Context();
            //dbcontext.Database.ExecuteSqlCommand("TRUNCATE TABLE [codings]");
            //dbcontext.SaveChanges();
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            List<coding> responsemodel = new List<coding>();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getCoding", Request.Cookies["adminToken"].Value);
            return View(responsemodel);

        }

        [HttpPost]
        public async Task<ActionResult> setNewCoding(coding model)
        {

            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/setCoding", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            return RedirectToAction("Coding");
        }



        //coDriver
        public async Task<ActionResult> coDriver()
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            getCoDriverResponse responsemodel = new getCoDriverResponse();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getCoDriverAsync", Request.Cookies["adminToken"].Value);
            return View(responsemodel);

        }
        [HttpPost]
        public async Task<ActionResult> getCodriverList(coDriverSearchVM model)
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            getCoDriverResponse responsemodel = new getCoDriverResponse();
            responsemodel = await methods.PostData(model, responsemodel, "/getCodriverList", Request.Cookies["adminToken"].Value);
            return PartialView("/Views/Shared/panel/_codriverList.cshtml", responsemodel);

        }
        public async Task<ActionResult> addDriverAsync(addDriverVM model)
        {
            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/addDriverAsync", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            return RedirectToAction("coDriver");
        }
        [HttpPost]
        public async Task<ActionResult> setInfoForDriver(setVehicleForVM model)
        {
            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/changeUserInfoAsync", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            return RedirectToAction("coDriver");
        }



        //vehicle

        public async Task<ActionResult> vehicle()
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            getVehicleResponce responsemodel = new getVehicleResponce();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getVehicleAsync", Request.Cookies["adminToken"].Value);
            return View(responsemodel);

        }
        [HttpPost]
        public async Task<ActionResult> getVehicleList(vehicleSearchVM model)
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            getVehicleResponce responsemodel = new getVehicleResponce();
            responsemodel = await methods.PostData(model, responsemodel, "/getVehicleList", Request.Cookies["adminToken"].Value);
            return PartialView("/Views/Shared/panel/_vehicleList.cshtml", responsemodel);

        }
        [HttpPost]
        public async Task<ActionResult> changeVehicleInfo(setYadakForVM model)
        {
            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/changeVehicleInfoAsync", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            return RedirectToAction("vehicle");
        }

        //yadak

        public async Task<ActionResult> yadak()
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            getYadakResponce responsemodel = new getYadakResponce();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getYadakAsync", Request.Cookies["adminToken"].Value);
            return View(responsemodel);

        }
        [HttpPost]
        public async Task<ActionResult> getYadakList(vehicleSearchVM model)
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            getYadakResponce responsemodel = new getYadakResponce();
            responsemodel = await methods.PostData(model, responsemodel, "/getYadakList", Request.Cookies["adminToken"].Value);
            return PartialView("/Views/Shared/panel/_yadakList.cshtml", responsemodel);

        }
       

        [HttpPost]
        public async Task<ActionResult> changeYadakInfo(setYadakForVM model)
        {
            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/changeYadakInfoAsync", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            return RedirectToAction("vehicle");
        }


        // product
        public async Task<ActionResult> products()
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            productActionVM responsemodel = new productActionVM();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getProductsAsync", Request.Cookies["adminToken"].Value);
            return View(responsemodel);
        }

        public async Task<ActionResult> setProductAsync(addProductVM model)
        {
            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/setProductAsync", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            return RedirectToAction("products");
        }

        public async Task<ActionResult> removeProductAsync(addProductVM model)
        {
            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/removeProductAsync", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            return RedirectToAction("products");
        }
        //productType
        public async Task<ActionResult> productType()
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            productTypeActionVM responsemodel = new productTypeActionVM();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getProductTypeAsync", Request.Cookies["adminToken"].Value);
            return View(responsemodel);
        }
        [HttpPost]
        public async Task<ActionResult> addProductTypeAsync(addProductTypeVM model)
        {
            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/addProductTypeAsync", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            return RedirectToAction(model.from);
        }

        // tag 
        public async Task<ActionResult> setTag(tagVM model)
        {
            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/setTag", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            return RedirectToAction(model.from);
        }


        //orderOptions
        public async Task<ActionResult> orderOptions()
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            orderOptionActionVM responsemodel = new orderOptionActionVM();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getOrderOptionAsync", Request.Cookies["adminToken"].Value);
            return View(responsemodel);
        }
        [HttpPost]
        public async Task<ActionResult> addOrderOptionsAsync(addOrderOptionVM model)
        {
            HttpFileCollectionBase files = Request.Files;
            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    if (files[i].ContentLength > 0)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname = file.FileName;


                        file.SaveAs(Server.MapPath("~/Uploads/") + fname);
                        model.image = file.FileName;
                    }

                }
            }

            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/addOrderOptionAsync", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {
                if (!string.IsNullOrEmpty(responsemodel.message))
                {
                    string fname = Path.Combine(Server.MapPath("Uploads"), responsemodel.message);
                    bool exists = System.IO.File.Exists(fname);
                    if (exists)
                        System.IO.File.Delete(fname);

                }
            }
            return RedirectToAction("orderOptions");
        }

        [HttpPost]
        public async Task<ActionResult> removeOrderOption(addOrderOptionVM model)
        {

            responseModel responsemodel = await methods.PostData(model, new responseModel(), "/removeOrderOption", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {
                if (!string.IsNullOrEmpty(responsemodel.message))
                {
                    string fname = Path.Combine(Server.MapPath("Uploads"), responsemodel.message);
                    bool exists = System.IO.File.Exists(fname);
                    if (exists)
                        System.IO.File.Delete(fname);

                }
            }

            return RedirectToAction("orderOptions");
        }

        //form type


        public async Task<ActionResult> formType(process model)
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            processFormActionVM responsemodel = new processFormActionVM();
            responsemodel = await methods.PostData(model, responsemodel, "/getFormType", Request.Cookies["adminToken"].Value);

            return View(responsemodel);
        }
        public async Task<ActionResult> setNewFormType(formVM model)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/PDF/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string pdfBase = methods.RandomString(5) + ".pdf";
            string pdf = methods.RandomString(6) + ".pdf";
            if (model.baseFile != null)
            {
                if (model.baseFile.ContentLength > 0)
                {
                    model.baseFile.SaveAs(path + pdfBase);
                }






            }
            if (model.file != null)
            {
                if (model.file.ContentLength > 0)
                {
                    model.file.SaveAs(path + pdf);
                }



            }
            model.pdfBase = null;
            model.pdf = null;
            form modeltogo = new form()
            {
                title = model.title,
                pdfBase = pdfBase,
                pdf = pdf,
                formID = model.formID
            };
            responseModel responsemodel = await methods.PostData(modeltogo, new responseModel(), "/setForm", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {
                List<string> lst = responsemodel.message.Trim(',').Split(',').ToList();
                if (lst.Count() > 0)
                {
                    foreach (var file in lst)
                    {
                        if (!string.IsNullOrEmpty(file))
                        {
                            string fname = Path.Combine(Server.MapPath("~/PDF/"), file);
                            bool exists = System.IO.File.Exists(fname);
                            if (exists)
                                System.IO.File.Delete(fname);
                        }

                    }
                }
            }
            return RedirectToAction("form");
        }


        //form


        public async Task<ActionResult> Form(process model)
        {
            if (TempData["er"] != null)
                ViewBag.error = TempData["er"].ToString();
            processFormActionVM responsemodel = new processFormActionVM();
            responsemodel = await methods.PostData(model, responsemodel, "/getForm", Request.Cookies["adminToken"].Value);

            return View(responsemodel);
        }
        [HttpPost]
        public async Task<ActionResult> setNewForm(formVM model)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/PDF/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string pdfBase = methods.RandomString(5) + ".pdf";
            string pdf = methods.RandomString(6) + ".pdf";
            if (model.baseFile != null)
            {
                if (model.baseFile.ContentLength > 0)
                {
                    model.baseFile.SaveAs(path + pdfBase);
                }
            }
            if (model.file != null)
            {
                if (model.file.ContentLength > 0)
                {
                    model.file.SaveAs(path + pdf);
                }



            }
            model.pdfBase = null;
            model.pdf = null;
            formVM modeltogo = new formVM()
            {
                title = model.title,
                pdfBase = pdfBase,
                pdf = pdf,
                formID = model.formID,
                userSelected = model.userSelected,
                formTypeID = model.formTypeID
            };
            responseModel responsemodel = await methods.PostData(modeltogo, new responseModel(), "/setForm", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {
                List<string> lst = responsemodel.message.Trim(',').Split(',').ToList();
                if (lst.Count() > 0)
                {
                    foreach (var file in lst)
                    {
                        if (!string.IsNullOrEmpty(file))
                        {
                            string fname = Path.Combine(Server.MapPath("~/PDF/"), file);
                            bool exists = System.IO.File.Exists(fname);
                            if (exists)
                                System.IO.File.Delete(fname);
                        }

                    }
                }
            }
            return RedirectToAction("form");
        }

        public async Task<ActionResult> updateFormItemPostion(int formID)
        {
            form form = new form();
            form.formID = formID;
            responseModel responsemodel = await methods.PostData(form, new responseModel(), "/updateFormItemPostion", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
            {
                TempData["er"] = "jhgjhg";//responsemodel.message;
            }


            return RedirectToAction("Form");
        }
    }
}