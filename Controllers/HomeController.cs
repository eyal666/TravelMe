using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelMe.ViewModel;
using TravelMe.Extensions;
using TravelMe.Models;

namespace TravelMe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index( 
            string search = null,
            bool r1 = false,
            bool r2 = false,
            bool r3 = false,
            bool r4 = false,
            bool r5 = false,
            string searchOpt = null
            )
        {
            var thumbnails = new List<ThumbnailModel>().GetPostThumbnail(ApplicationDbContext.Create(), search, r1, r2, r3, r4, r5, searchOpt);
            var count = thumbnails.Count() / 4;
            var model = new List<ThumbnailBoxViewModel>();

            for (int i = 0; i <= count; i++)
            {
                model.Add(new ThumbnailBoxViewModel
                {
                    Thumbnails = thumbnails.Skip(i * 4).Take(4)
                });
            }
            return View(model);
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