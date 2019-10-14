using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelMe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Subtitle = "Our story";
            ViewBag.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec elementum magna ultricies eros tincidunt scelerisque. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Sed sed elit lacus. Etiam egestas consectetur lectus ut malesuada. Nam ut lacus nec mi imperdiet ultrices. Ut rhoncus vitae diam ut consequat.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}