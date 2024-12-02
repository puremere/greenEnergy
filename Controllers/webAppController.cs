using greenEnergy.Classes;
using greenEnergy.ViewModel;
using greenEnergy.ViewModel.webapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace greenEnergy.Controllers
{
    public class webAppController : Controller
    {
        // GET: webApp
        public async Task<ActionResult> Index()
        {
            ViewBag.slug = TempData["page"].ToString(); 
            return View();
        }

        //[HttpPost]
        public async Task<PartialViewResult> getAppUrl(string slug)
        {
            appPageSectionVM responsemodel = new appPageSectionVM();
            getURLVM model = new getURLVM();
            model.slug = slug;
            responsemodel = await methods.PostData(model, responsemodel, "/getAppURL", "");
            webapp view = JsonConvert.DeserializeObject<webapp>(responsemodel.result.page);
            return PartialView("/Views/Shared/_getAppURL.cshtml");
        }
        public async Task<ActionResult> splash()
        {
            splash responsemodel = new splash();
            getURLVM model = new getURLVM();
            responsemodel = await methods.PostData(model, responsemodel, "/getSplash", "");
            TempData["page"] = responsemodel.result.startPage;
            return RedirectToAction("index");
            
        }
        
    }
}