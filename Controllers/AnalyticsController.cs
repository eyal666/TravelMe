using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelMe.Utils;

namespace TravelMe.Controllers
{
    [Authorize(Roles = SD.AdminUserRole)]
    public class AnalyticsController : Controller
    {
        // GET: Analytics
        public ActionResult Index()
        {
            return View();
        }
    }
}