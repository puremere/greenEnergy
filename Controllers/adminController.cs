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

namespace greenEnergy.Controllers
{
    [adminCheck]
    [doForAll]
    public class adminController : Controller
    {
        public ActionResult login()
        {


            //int finalindex = srt.IndexOf(",");
            //string stringBeforeChar = srt.Substring(index, srt.IndexOf(","));

            //string final = "";
            //{"type": "cycleView","id": "cycleViewID","backColor": "backColorsrt","borderColor":"borderColorsrt","cornerRadius":cornerRadiussrt,"multiSelectable": multiSelectablesrt,selectable:selectablesrt,"direction":directionsrt,"gridCount":gridCountsrt,"width":widthsrt,"height":heightsrt,"margin":marginsrt,"distribution":distributionsrt,"patterns": [{"patternId": "patternId1","dataMap": [dataMapString],"view": childMetaString}],"items": dataitemsstring}
            //Context dbcontext = new Context();
            //roleStartPage role = new roleStartPage();
            //Guid roleID = Guid.NewGuid();
            //role.roleStartPageID = roleID;
            //role.isNav = 1;
            //role.startPage = "";
            //dbcontext.roleStartPages.Add(role);
            //dbcontext.SaveChanges();

            //roleNavURL newnav = new roleNavURL()
            //{
            //    roleStartPageID = roleID,
            //    orleNavURLID = Guid.NewGuid(),
            //    startPageURL = "app/searchOrderPageManager",
            //    startPagetitle = "بيت",
            //    startPageIcon = "https://img.icons8.com/?size=128&id=73&format=png"

            //};
            //dbcontext.roleNavURLs.Add(newnav);
            //newnav = new roleNavURL()
            //{
            //    roleStartPageID = roleID,
            //    orleNavURLID = Guid.NewGuid(),
            //    startPageURL = "app/searchChartManager",
            //    startPagetitle = "چارت",
            //    startPageIcon = "https://img.icons8.com/?size=128&id=73&format=png"

            //};
            //dbcontext.roleNavURLs.Add(newnav);
            //newnav = new roleNavURL()
            //{
            //    roleStartPageID = roleID,
            //    orleNavURLID = Guid.NewGuid(),
            //    startPageURL = "app/searchBarcodeManager",
            //    startPagetitle = "بارکد",
            //    startPageIcon = "https://img.icons8.com/?size=128&id=73&format=png"

            //};
            //dbcontext.roleNavURLs.Add(newnav);

            //dbcontext.SaveChanges();
            string srt = "";

            //try
            //{
            //    
            //    html html = new html()
            //    {
            //        htmlID = Guid.NewGuid(),
            //        image = "list1.png",
            //        partialView = "_list1",
            //        title = "list1",
            //    };
            //    dbcontext.htmls.Add(html);
            //    //html html1 = new html()
            //    //{
            //    //    htmlID = Guid.NewGuid(),
            //    //    image = "intro1.png",
            //    //    partialView = "_intro1",
            //    //    title = "slider1",
            //    //};
            //    //dbcontext.htmls.Add(html1);
            //    //html html2 = new html()
            //    //{
            //    //    htmlID = Guid.NewGuid(),
            //    //    image = "banner1.png",
            //    //    partialView = "_banner1",
            //    //    title = "banner1",
            //    //};
            //    //dbcontext.htmls.Add(html2);
            //    dbcontext.SaveChanges();
            //}
            //catch (Exception e)
            //{

            //    throw;
            //}

            //user user1 = new user()
            //{
            //     code = "enterGreen",
            //      phone = "100",
            //       userID = Guid.NewGuid(),
            //        username = "client",
            //         userType = "0"
            //};
            //dbcontext.users.Add(user1);
            //user user2 = new user()
            //{
            //    code = "enterPanel",
            //    phone = "999",
            //    userID = Guid.NewGuid(),
            //    username = "admin",
            //    userType = "1"
            //};
            //dbcontext.users.Add(user2);
            //dbcontext.SaveChanges();


            return View();

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
                return RedirectToAction("dashboard");
            }
            else
            {
                TempData["error"] = 1;
                return RedirectToAction("login");
            }


        }
        public async Task<ActionResult> dashboard()
        {
            dashbaordVM responsemodel = new dashbaordVM();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getDashboard", Request.Cookies["adminToken"].Value);
            typePageVM menuTable = new typePageVM();
            menuTable.list = responsemodel.typelist;
            string typeList = JsonConvert.SerializeObject(menuTable);
            Response.Cookies["typelist"].Value = typeList;
            ViewBag.menu = typeList;
            return View();
        }

        public async Task<ActionResult> language()
        {
            LanguagePageVM responsemodel = new LanguagePageVM();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getLanguageList", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();



            return View(responsemodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setlanguage(languagVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setLanguage", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();

            return RedirectToAction("language");
        }
        public async Task<ActionResult> Type()
        {
            typePageVM responsemodel = new typePageVM();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getTypeList", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return View(responsemodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setType(typeVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setType", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return RedirectToAction("type");
        }

        public async Task<ActionResult> tag()
        {
            categoryPageVM responsemodel = new categoryPageVM();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getTagList", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return View(responsemodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setTag(secTagVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setsecTag", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return RedirectToAction("tag");
        }

        public async Task<ActionResult> category()
        {
            categoryPageVM responsemodel = new categoryPageVM();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getCategoryList", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return View(responsemodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setCategory(categoryVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setCategory", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return RedirectToAction("category");
        }

        // page
        public async Task<ActionResult> Page(Guid id)
        {
            typeVM model = new typeVM();
            model.typeID = id;
            pageListVM responsemodel = new pageListVM();
            responsemodel = await methods.PostData(model, responsemodel, "/getPage", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return View(responsemodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setPage(sectionVM model)
        {

            if (System.Web.HttpContext.Current.Request.Files.Count > 0)
            {
                //Create the Directory.
                string path = System.Web.HttpContext.Current.Server.MapPath("/Images/" + @System.Configuration.ConfigurationManager.AppSettings["name"] + "/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                HttpPostedFile postedFile = System.Web.HttpContext.Current.Request.Files[0];


                if (postedFile.ContentLength != 0)
                {
                    string fileName = "";
                    string name = methods.RandomString(5);
                    //Fetch the File Name.
                    fileName = name + Path.GetExtension(postedFile.FileName);
                    //Save the File.
                    postedFile.SaveAs(path + fileName);
                    model.image = fileName;
                }
            }


            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setSection", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {
                if (!string.IsNullOrEmpty(responsemodel.message))
                {
                    string fname = Path.Combine(Server.MapPath("/Images/" + @System.Configuration.ConfigurationManager.AppSettings["name"] + "/Uploads/"), responsemodel.message);
                    bool exists = System.IO.File.Exists(fname);
                    if (exists)
                        System.IO.File.Delete(fname);

                }
            }
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();

            return RedirectToAction("Page", new { id = model.sectinoTypeID });
        }



        // contents
        public async Task<ActionResult> Content(string id, string contentID)
        {
            sectionVM model = new sectionVM();

            model.sectinoID = !string.IsNullOrEmpty(id) ? new Guid(id) : new Guid();
            model.contentParent = !string.IsNullOrEmpty(contentID) ? new Guid(contentID) : new Guid();


            contentListVM responsemodel = new contentListVM();
            responsemodel = await methods.PostData(model, responsemodel, "/getContent", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return View(responsemodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setContnet(setContentVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setContent", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {
                string image = responsemodel.message;
            }
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return RedirectToAction("Content", new { id = model.sectionID, contentID = model.contentParent });
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> removeContent(removeContentPageVM model)
        {
            responseModel responsemodel = new responseModel();
            try
            {
                responsemodel = await methods.PostData(model, responsemodel, "/removeContent", Request.Cookies["adminToken"].Value);
                if (responsemodel.status != 200)
                    TempData["er"] = responsemodel.message;
                else
                {

                    if (!string.IsNullOrEmpty(responsemodel.message))
                    {
                        string fname = Path.Combine(Server.MapPath("/Images/" + @System.Configuration.ConfigurationManager.AppSettings["name"] + "/Uploads/"), responsemodel.message);
                        bool exists = System.IO.File.Exists(fname);
                        if (exists)
                            System.IO.File.Delete(fname);

                    }
                }
                if (Request.Cookies["typelist"] != null)
                    ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            }
            catch (Exception e)
            {

                return Content(e.InnerException.Message);
            }


            //return Content("");
            return RedirectToAction("Content", new { id = model.sectionID, contentID = model.parentID });
        }

        //meta 

        public async Task<ActionResult> meta(Guid id)
        {
            sectionVM model = new sectionVM();
            model.sectinoID = id;
            metaListVM responsemodel = new metaListVM();
            responsemodel = await methods.PostData(model, responsemodel, "/getMeta", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return View(responsemodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setMeta(MetaVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setMeta", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {
                string image = responsemodel.message;
            }
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return RedirectToAction("meta", new { id = model.sectionID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> removeMeta(MetaVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/removeContent", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {

                if (!string.IsNullOrEmpty(responsemodel.message))
                {
                    string fname = Path.Combine(Server.MapPath("/Images/" + @System.Configuration.ConfigurationManager.AppSettings["name"] + "/Uploads/"), responsemodel.message);
                    bool exists = System.IO.File.Exists(fname);
                    if (exists)
                        System.IO.File.Delete(fname);

                }
            }
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return RedirectToAction("meta", new { id = model.sectionID });
        }


        // data
        public async Task<ActionResult> Data(Guid id, string del)
        {
            contentVM model = new contentVM();
            model.contentID = id;
            model.fields = del;
            dataListVM responsemodel = new dataListVM();
            responsemodel = await methods.PostData(model, responsemodel, "/getData", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return View(responsemodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setData(setDataVM model)
        {
            if (System.Web.HttpContext.Current.Request.Files.Count > 0)
            {
                //Create the Directory.
                string path = System.Web.HttpContext.Current.Server.MapPath("/Images/" + @System.Configuration.ConfigurationManager.AppSettings["name"] + "/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                HttpPostedFile postedFile = System.Web.HttpContext.Current.Request.Files[0];
                if (postedFile.ContentLength != 0)
                {
                    string fileName = "";
                    string name = methods.RandomString(5);
                    //Fetch the File Name.
                    fileName = name + Path.GetExtension(postedFile.FileName);
                    //Save the File.
                    postedFile.SaveAs(path + fileName);
                    List<string> lst = new List<string>();
                    lst.Add(fileName);
                    model.title2 = lst;
                }
            }
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setData", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {
                if (!string.IsNullOrEmpty(responsemodel.message))
                {
                    string fname = Path.Combine(Server.MapPath("/Images/" + @System.Configuration.ConfigurationManager.AppSettings["name"] + "/Uploads/"), responsemodel.message);
                    bool exists = System.IO.File.Exists(fname);
                    if (exists)
                        System.IO.File.Delete(fname);

                }
            }
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return RedirectToAction("Data", new { id = model.contentID });
        }


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> removeData(setDataVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/removeData", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {

                if (!string.IsNullOrEmpty(responsemodel.message))
                {
                    string fname = Path.Combine(Server.MapPath("/Images/" + @System.Configuration.ConfigurationManager.AppSettings["name"] + "/Uploads/"), responsemodel.message);
                    bool exists = System.IO.File.Exists(fname);
                    if (exists)
                        System.IO.File.Delete(fname);

                }
            }
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return RedirectToAction("Data", new { id = model.contentID, del = "1" });
        }

        // pose

        public async Task<ActionResult> Pose(Guid id)
        {

            poseparent posemodel = new poseparent();
            string posestring = JsonConvert.SerializeObject(posemodel);
            contentVM model = new contentVM();
            model.contentID = id;
            poseListVM responsemodel = new poseListVM();
            responsemodel = await methods.PostData(model, responsemodel, "/getPose", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return View(responsemodel);
        }
        //{"viewID":"ViewIDsrt","top2top":top2topsrt,"bottom2bottom":bottom2bottomsrt,"lead2lead":lead2leadsrt,"trail2trail":trail2trailsrt,"top2bottom":top2bottomsrt,"bottom2top":bottom2topsrt,"trail2lead":trail2leadsrt,"lead2trail":"lead2trailsrt","centerX":centerXsrt,"centerY":centerYsrt}
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setPose(setPoseVM model)
        {

            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setPose", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;

            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return RedirectToAction("Pose", new { id = model.contentID });
        }


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> removePose(setPoseVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/removePose", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;

            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return RedirectToAction("Pose", new { id = model.contentID });
        }

        //layoutPart
        public async Task<ActionResult> LayoutPart(Guid ID)
        {
            layoutPartPageVM responsemodel = new layoutPartPageVM();
            sectionLayoutVM input = new sectionLayoutVM()
            {
                sectionLayoutID = ID
            };
            responsemodel = await methods.PostData(input, responsemodel, "/getLayoutPart", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            responsemodel.sectionLayoutID = ID;
            return View(responsemodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setLayoutPart(layoutPartSetVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setLayoutPart", Request.Cookies["adminToken"].Value);
            return RedirectToAction("LayoutPart", new { ID = model.sectionLayoutID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> removeLayoutpart(layoutPartSetVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/removeLayoutPart", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;

            return RedirectToAction("LayoutPart");
        }



        //layoutPartData
        public async Task<ActionResult> LayoutPartData(Guid id)
        {
            layoutpartVM model = new layoutpartVM();
            model.layoutPartID = id;
            layoutPartDataPageVM responsemodel = new layoutPartDataPageVM();
            responsemodel = await methods.PostData(model, responsemodel, "/getLayoutPartData", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return View(responsemodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setLayoutPartData(layoutpartDataVM model)
        {
            if (System.Web.HttpContext.Current.Request.Files.Count > 0)
            {
                //Create the Directory.
                string path = System.Web.HttpContext.Current.Server.MapPath("/Images/" + @System.Configuration.ConfigurationManager.AppSettings["name"] + "/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                HttpPostedFile postedFile = System.Web.HttpContext.Current.Request.Files[0];


                if (postedFile.ContentLength != 0)
                {
                    string fileName = "";
                    string name = methods.RandomString(6);
                    //Fetch the File Name.
                    fileName = name + Path.GetExtension(postedFile.FileName);
                    //Save the File.
                    postedFile.SaveAs(path + fileName);
                    model.image = fileName;
                }
            }
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setLayoutPartData", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {
                if (!string.IsNullOrEmpty(responsemodel.message))
                {
                    string fname = Path.Combine(Server.MapPath("/Images/" + @System.Configuration.ConfigurationManager.AppSettings["name"] + "/Uploads/"), responsemodel.message);
                    bool exists = System.IO.File.Exists(fname);
                    if (exists)
                        System.IO.File.Delete(fname);

                }
            }
            return RedirectToAction("LayoutPartData", new { id = model.layoutPartID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> removeLayoutpartData(layoutpartDataVM model)
        {
            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/removeLayoutPartData", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;
            else
            {
                if (!string.IsNullOrEmpty(responsemodel.message))
                {
                    string fname = Path.Combine(Server.MapPath("/Images/" + @System.Configuration.ConfigurationManager.AppSettings["name"] + "/Uploads/"), responsemodel.message);
                    bool exists = System.IO.File.Exists(fname);
                    if (exists)
                        System.IO.File.Delete(fname);

                }
            }

            return RedirectToAction("LayoutPartData", new { id = model.layoutPartID });
        }


        //layout
        public async Task<ActionResult> Layout()
        {
            layoutPageVM responsemodel = new layoutPageVM();
            responsemodel = await methods.PostData(new nullclass(), responsemodel, "/getLayout", Request.Cookies["adminToken"].Value);
            if (Request.Cookies["typelist"] != null)
                ViewBag.menu = Request.Cookies["typelist"].Value.ToString();
            return View(responsemodel);


        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> setNewSectionLayout(setSectionLayoutVM model)
        {

            responseModel responsemodel = new responseModel();
            responsemodel = await methods.PostData(model, responsemodel, "/setSectionLayout", Request.Cookies["adminToken"].Value);
            if (responsemodel.status != 200)
                TempData["er"] = responsemodel.message;

            return RedirectToAction("Layout");
        }
    }
}