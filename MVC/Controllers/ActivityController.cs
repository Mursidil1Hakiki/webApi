using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            IEnumerable<ActivityModel> actList;
            HttpResponseMessage respose = GlobalVariable.WebApiClient.GetAsync("activities").Result;
            actList = respose.Content.ReadAsAsync<IEnumerable<ActivityModel>>().Result;
            return View(actList);
        }
    }
}